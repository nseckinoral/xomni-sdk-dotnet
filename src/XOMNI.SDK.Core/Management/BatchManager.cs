using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Providers;
using System.Reflection;
using XOMNI.SDK.Core.Exception;
using System.Net;

namespace XOMNI.SDK.Core.Management
{
    public class BatchManager : ManagementBase
    {
        public async Task<List<XOMNIResponseMessage>> ExecuteAsync(params XOMNIRequestMessage[] messages)
        {
            var retVal = new List<XOMNIResponseMessage>();

            using (HttpRequestMessage batchRequest = new HttpRequestMessage(HttpMethod.Post, "URL GOES HERE"))
            using (MultipartContent multipartContent = new MultipartContent("mixed", "batch_" + Guid.NewGuid().ToString()))
            {
                foreach (var item in messages)
                {
                    multipartContent.Add(new HttpMessageContent(item.requestMessage));
                }

                var result = await HttpProvider.client.SendAsync(batchRequest);
                var resultContent = await result.Content.ReadAsMultipartAsync();

                for (int i = 0; i < messages.Count(); i++)
                {
                    XOMNIResponseMessage responseMessage = null;
                    var requestGenericTypeArguments = messages[i].GetType().GetTypeInfo().GenericTypeArguments;

                    var httpResponseMessage = await resultContent.Contents[i].ReadAsHttpResponseMessageAsync();

                    bool isSucceed = false;
                    ExceptionBase exception = null;

                    try
                    {
                        await HttpProvider.ControlResponse(httpResponseMessage, messages[i].expectedStatusCode);
                        isSucceed = true;
                    }
                    catch (ExceptionBase ex)
                    {
                        exception = ex;
                    }

                    if (requestGenericTypeArguments.Any())
                    {
                        var requestGenericType = requestGenericTypeArguments.First();
                        var repositoryOpenType = typeof(XOMNIResponseMessage<>);
                        var repositoryClosedType = repositoryOpenType.MakeGenericType(requestGenericType);

                        var responseEntity = await resultContent.Contents[i].ReadAsAsync(requestGenericType);
                        responseMessage = (XOMNIResponseMessage)Activator.CreateInstance(repositoryClosedType, isSucceed, exception, responseEntity);
                    }
                    else
                    {
                        responseMessage = new XOMNIResponseMessage(isSucceed, exception);
                    }

                    retVal.Add(responseMessage);
                }
            }

            return retVal;
        }
    }

}
