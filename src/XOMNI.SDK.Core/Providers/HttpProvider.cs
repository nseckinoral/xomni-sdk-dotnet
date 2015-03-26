﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Exception;

namespace XOMNI.SDK.Core.Providers
{
    public class HttpProvider
    {
        internal static HttpClient client;
        private const string PIITokenHeaderName = "PIIToken";
        private const string ApiAuthorizationHeaderName = "Basic";
        private const string piiHeaderFormat = "username:{0};password:{1}";
        private const string apiAuthorizationHeaderFormat = "{0}:{1}";

        static HttpProvider()
        {
            var handler = new RetryHandler(new HttpClientHandler());
            client = new HttpClient(handler);
            client.Timeout = new TimeSpan(1, 0, 0);
        }

        private static void InitalizeAuthorizationHeader(HttpRequestMessage requestMessage, ApiBasicCredential credential)
        {
            string encodedHeaderValue = EncodeHeader(String.Format(apiAuthorizationHeaderFormat, credential.Username, credential.Password));
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(ApiAuthorizationHeaderName, encodedHeaderValue);
        }

        public static HttpRequestMessage CreateRequestMessage(HttpMethod method, string requestUri, ApiBasicCredential credential, object body = null)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(method, requestUri);
            InitializeDefaultHttpHeaders(requestMessage);
            InitalizeAuthorizationHeader(requestMessage, credential);
            if (body != null)
            {
                InitializeRequestContent(requestMessage, body);
            }
            return requestMessage;
        }

        private static void InitializeRequestContent(HttpRequestMessage requestMessage, object body)
        {
            HttpContent content = null;
            if (body is byte[])
            {
                var array = (byte[])body;
                content = new StreamContent(new MemoryStream(array), array.Count());
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            }
            else
            {
                var json = JsonConvert.SerializeObject(body);
                content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            requestMessage.Content = content;
        }

        private static string EncodeHeader(string header)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(header));
        }

        private static void InitializeDefaultHttpHeaders(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Accept.ParseAdd("application/json");
            requestMessage.Headers.Accept.ParseAdd(string.Format("application/vnd.xomni.api-{0}", "v3_1"));
            requestMessage.Headers.Host = Configuration.Configuration.Host;
        }

        #region Http Get Methods
        public static HttpRequestMessage CreateGetRequest(string url, ApiBasicCredential credential)
        {
            return CreateRequestMessage(HttpMethod.Get, url, credential);
        }


        public static async Task<T> GetAsync<T>(string url, ApiBasicCredential credential)
        {
            using (var requestMessage = CreateGetRequest(url, credential))
            {
                var response = await client.SendAsync(requestMessage);
                await ControlResponseAsync(response);
                return await response.Content.ReadAsAsync<T>();
            }
        }

        #endregion

        #region Http Post Methods
        public static HttpRequestMessage CreatePostRequest(string url, ApiBasicCredential credential, object body)
        {
            return CreateRequestMessage(HttpMethod.Post, url, credential, body);
        }

        public static async Task<T> PostAsync<T>(string url, object body, ApiBasicCredential credential, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            var response = await PostInternalAsync(url, body, credential, expectedCode);
            return await response.Content.ReadAsAsync<T>();
        }

        private static async Task<HttpResponseMessage> PostInternalAsync(string url, object body, ApiBasicCredential credential, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            using (HttpRequestMessage requestMessage = CreatePostRequest(url, credential, body))
            {
                var response = await client.SendAsync(requestMessage);
                await ControlResponseAsync(response, expectedCode);
                return response;
            }
        }

        public static async Task PostAsync(string url, object body, ApiBasicCredential credential)
        {
            var response = await PostInternalAsync(url, body, credential);
        }
        #endregion

        #region Http Put Methods
        public static HttpRequestMessage CreatePutRequest(string url, ApiBasicCredential credential, object body)
        {
            return CreateRequestMessage(HttpMethod.Put, url, credential, body);
        }

        public static async Task<T> PutAsync<T>(string url, object body, ApiBasicCredential credential)
        {
            using (HttpRequestMessage requestMessage = CreatePutRequest(url, credential, body))
            {
                var response = await client.SendAsync(requestMessage);
                await ControlResponseAsync(response);
                return await response.Content.ReadAsAsync<T>();
            }
        }

        #endregion

        #region Http Patch Methods

        public static HttpRequestMessage CreatePatchRequest(string url, ApiBasicCredential credential, object body)
        {
            return CreateRequestMessage(new HttpMethod("PATCH"), url, credential, body);
        }

        public static async Task<T> PatchAsync<T>(string url, object body, ApiBasicCredential credential, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            using (HttpRequestMessage requestMessage = CreatePatchRequest(url, credential, body))
            {
                var response = await client.SendAsync(requestMessage);
                await ControlResponseAsync(response, expectedCode);
                return await response.Content.ReadAsAsync<T>();
            }
        }

        #endregion

        #region Http Delete Methods

        public static HttpRequestMessage CreateDeleteRequest(string url, ApiBasicCredential credential)
        {
            return CreateRequestMessage(HttpMethod.Delete, url, credential);
        }

        public static async Task DeleteAsync(string url, ApiBasicCredential credential)
        {
            using (var requestMessage = CreateDeleteRequest(url, credential))
            {
                var response = await client.SendAsync(requestMessage);
                await ControlResponseAsync(response, HttpStatusCode.Accepted);
            }
        }

        #endregion

        public void AddHeader(string headerName, string value)
        {
            client.DefaultRequestHeaders.Add(headerName, value);
        }

        internal async static Task ControlResponseAsync(HttpResponseMessage response, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            if (response.StatusCode != expectedCode)
            {
                if (!response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            throw ExceptionBase.Create<NotFoundException>(responseContent);
                        case HttpStatusCode.InternalServerError:
                            throw ExceptionBase.Create<InternalServerErrorException>(responseContent);
                        case HttpStatusCode.BadRequest:
                            throw ExceptionBase.Create<BadRequestException>(responseContent);
                        case HttpStatusCode.Conflict:
                            throw ExceptionBase.Create<ConflictException>(responseContent);
                        case HttpStatusCode.RequestEntityTooLarge:
                            throw ExceptionBase.Create<RequestEntityTooLargeException>(responseContent);
                        case HttpStatusCode.Unauthorized:
                            throw ExceptionBase.Create<UnauthorizedException>(responseContent);
                        case HttpStatusCode.Forbidden:
                            throw ExceptionBase.Create<ForbiddenException>(responseContent);
                        default:
                            var exception = ExceptionBase.Create<UnhandledHttpException>(responseContent);
                            exception.HttpStatusCode = response.StatusCode;
                            throw exception;
                    }
                }
            }
        }
    }
}
