using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Catalog;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Catalog
{
    [TestClass]
    public class CategoryClientFixture : BaseClientFixture<CategoryClient>
    {
        #region GetAsyncCategoryTree

        const string validAPIResponseForCategoryTreeItem = @"{  
           'Data':{  
              'Categories':[  
                 {  
                    'Id':1,
                    'Name':'Sample Category 0',
                    'ShortDescription':'Sample Short Description',
                    'LongDescription':'Sample Long Description',
                    'CategoryMetadata':[  
                       {  
                          'Key':'Key0',
                          'Value':'Value0'
                       },
                       {  
                          'Key':'Key1',
                          'Value':'Value1'
                       }
                    ],
                    'ImageAssets':[  
                       {  
                          'ResizedAssets':[  
                             {  
                                'ImageSizeProfile':{  
                                   'Id':1,
                                   'Height':300,
                                   'Width':500
                                },
                                'AssetUrl':'https://xomni.blob.core.windows.net/images/6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
                             },
                             {  
                                'ImageSizeProfile':{  
                                   'Id':2,
                                   'Height':600,
                                   'Width':1000
                                },
                                'AssetUrl':'https://xomni.blob.core.windows.net/images/6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
                             },
                             {  
                                'ImageSizeProfile':{  
                                   'Id':3,
                                   'Height':900,
                                   'Width':1500
                                },
                                'AssetUrl':'https://xomni.blob.core.windows.net/images/6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
                             }
                          ],
                          'AssetMetadata':[  
                             {  
                                'Key':'assetmetadatakey1',
                                'Value':'assetmetadatavalue1'
                             },
                             {  
                                'Key':'assetmetadatakey2',
                                'Value':'assetmetadatavalu2'
                             },
                             {  
                                'Key':'assetmetadatakey3',
                                'Value':'assetmetadatavalue3'
                             }
                          ],
                          'AssetId':1,
                          'AssetUrl':'https://xomni.blob.core.windows.net/images/5e2dd075-957f-4884-8992-030d1eabcc79',
                          'IsDefault':true
                       }
                    ],
                    'DocumentAssets':[  
                       {  
                          'AssetMetadata':[  
                             {  
                                'Key':'assetmetadatakey2',
                                'Value':'assetmetadatavalue2'
                             },
                             {  
                                'Key':'assetmetadatakey5',
                                'Value':'assetmetadatavalue5'
                             },
                             {  
                                'Key':'assetmetadatakey6',
                                'Value':'assetmetadatavalue6'
                             }
                          ],
                          'AssetId':3,
                          'AssetUrl':'https://xomni.blob.core.windows.net/documents/5e2dd075-957f-4884-8992-030d1eabcc79'
                       }
                    ],
                    'VideoAssets':[  

                    ],
                    'CategoryTreeItems':[  
                       {  
                          'Id':11,
                          'Name':'Sample Sub Category 0',
                          'ShortDescription':'Sub category sample short description',
                          'LongDescription':'Sub category sample long description',
                          'CategoryMetadata':[  

                          ],
                          'ImageAssets':[  

                          ],
                          'DocumentAssets':[  

                          ],
                          'VideoAssets':[  

                          ],
                          'CategoryTreeItems':[  

                          ]
                       },
                       {  
                          'Id':12,
                          'Name':'Sample Sub Category 1',
                          'ShortDescription':'Sample Sub Category 1 Short Description',
                          'LongDescription':'Sample Sub Category 1 Long Description',
                          'CategoryMetadata':[  

                          ],
                          'CategoryTreeItems':[  

                          ],
                          'ImageAssets':[  

                          ],
                          'DocumentAssets':[  

                          ],
                          'VideoAssets':[  

                          ]
                       }
                    ]
                 },
                 {  
                    'Id':2,
                    'Name':'Sample Category 1',
                    'ShortDescription':'Sample Category 1 Short Description',
                    'LongDescription':'Sample Category 1 Long Description',
                    'CategoryMetadata':[  
                       {  
                          'Key':'categorymetadata0key',
                          'Value':'categorymetadata0value'
                       },
                       {  
                          'Key':'categorymetadata1key',
                          'Value':'categorymetadata1value'
                       }
                    ],
                    'CategoryTreeItems':[  

                    ],
                    'ImageAssets':[  

                    ],
                    'DocumentAssets':[  

                    ],
                    'VideoAssets':[  

                    ]
                 }
              ]
           }
        }";

        const string validAPIResponseForSubCategories = @"{
            'Data': [
                {
                    'Id': 1,
                    'Name': 'SampleCategory0',
                    'ShortDescription': 'SampleCategory0',
                    'LongDescription': 'SampleCategory0',
                    'SubCategoryCount': 2,
                    'CategoryMetadata': [
                        {
                            'Key': 'categorymetadatakey1',
                            'Value': 'categorymetadatavalue1'
                        },
                        {
                            'Key': 'categorymetadatakey2',
                            'Value': 'categorymetadatavalue2'
                        }
                    ],
                    'ImageAssets': [
                        {
                            'ResizedAssets': [
                                {
                                    'ImageSizeProfile': {
                                        'Id': 1,
                                        'Height': 300,
                                        'Width': 500
                                    },
                                    'AssetUrl': 'https: //xomni.blob.core.windows.net/images/6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
                                },
                                {
                                    'ImageSizeProfile': {
                                        'Id': 2,
                                        'Height': 600,
                                        'Width': 1000
                                    },
                                    'AssetUrl': 'https: //xomni.blob.core.windows.net/images/6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
                                },
                                {
                                    'ImageSizeProfile': {
                                        'Id': 3,
                                        'Height': 900,
                                        'Width': 1500
                                    },
                                    'AssetUrl': 'https: //xomni.blob.core.windows.net/images/6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
                                }
                            ],
                            'AssetMetadata': [
                                {
                                    'Key': 'assetmetadatakey1',
                                    'Value': 'assetmetadatavalue1'
                                },
                                {
                                    'Key': 'assetmetadatakey2',
                                    'Value': 'assetmetadatavalue2'
                                },
                                {
                                    'Key': 'assetmetadatakey3',
                                    'Value': 'assetmetadatavalue3'
                                }
                            ],
                            'AssetId': 1,
                            'AssetUrl': 'https: //xomni.blob.core.windows.net/images/5e2dd075-957f-4884-8992-030d1eabcc79',
                            'IsDefault': true
                        }
                    ],
                    'DocumentAssets': [
                        {
                            'AssetMetadata': [
                                {
                                    'Key': 'assetmetadatakey3',
                                    'Value': 'assetmetadatavalue3'
                                },
                                {
                                    'Key': 'assetmetadatakey6',
                                    'Value': 'assetmetadatavalue6'
                                },
                                {
                                    'Key': 'assetmetadatakey5',
                                    'Value': 'assetmetadatavalue5'
                                }
                            ],
                            'AssetId': 3,
                            'AssetUrl': 'https: //xomni.blob.core.windows.net/images/5e2dd075-957f-4884-8992-030d1eabcc79'
                        }
                    ],
                    'VideoAssets': [
                
                    ],
                    'ParentCategoryId': 1,
                    'ParentCategoryName': 'Shoes'
                },
                {
                    'Id': 2,
                    'Name': 'SampleCategory1',
                    'ShortDescription': 'SampleCategory1ShortDescription',
                    'LongDescription': 'SampleCategory1LongDescription: ',
                    'SubCategoryCount': 0,
                    'CategoryMetadata': [
                        {
                            'Key': 'categorymetadatakey1',
                            'Value': 'categorymetadatavalue1'
                        },
                        {
                            'Key': 'categorymetadatakey5',
                            'Value': 'categorymetadatavalue5'
                        }
                    ],
                    'ParentCategoryId': 1,
                    'ParentCategoryName': 'Shoes'
                }
            ]
        }";

        readonly HttpResponseMessage validHttpResponseMessageForCategoryTreeItem = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponseForCategoryTreeItem)
        };

        [TestMethod, TestCategory("CategoryClient"), TestCategory("GetCategoryTreeAsync"), TestCategory("HTTP.GET")]
        public async Task GetCategoryTreeAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (CategoryClient c) => c.GetCategoryTreeAsync(false, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata),
                validHttpResponseMessageForCategoryTreeItem,
                validAPIResponseForCategoryTreeItem
                );
        }

        [TestMethod, TestCategory("CategoryClient"), TestCategory("GetCategoryTreeAsync"), TestCategory("HTTP.GET")]
        public async Task GetCategoryTreeAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (CategoryClient c) => c.GetCategoryTreeAsync(false, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("CategoryClient"), TestCategory("GetCategoryTreeAsync"), TestCategory("HTTP.GET")]
        public async Task GetCategoryTreeAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (CategoryClient p) => p.GetCategoryTreeAsync(false, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata),
              string.Format("/catalog/categories?includeMetadata={0}&imageAssetDetail={1}&videoAssetDetail={2}&documentAssetDetail={3}", false, 4,4,4));
        }

        [TestMethod, TestCategory("CategoryClient"), TestCategory("GetCategoryTreeAsync"), TestCategory("HTTP.GET")]
        public async Task GetCategoryTreeAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (CategoryClient c) => c.GetCategoryTreeAsync(false, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata)
            );
        }

        [TestMethod, TestCategory("CategoryClient"), TestCategory("GetCategoryTreeAsync"), TestCategory("HTTP.GET")]
        public async Task GetCategoryTreeAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (CategoryClient t) => t.GetCategoryTreeAsync(false, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }
        #endregion

        #region GetSubCategoriesAsync



        readonly HttpResponseMessage validHttpResponseMessageForSubCategories = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new MockedJsonContent(validAPIResponseForSubCategories)
        };

        [TestMethod, TestCategory("CategoryClient"), TestCategory("GetSubCategoriesAsync"), TestCategory("HTTP.GET")]
        public async Task GetSubCategoriesAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (CategoryClient c) => c.GetSubCategoriesAsync(1, false, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata),
                validHttpResponseMessageForSubCategories,
                validAPIResponseForSubCategories
                );
        }

        [TestMethod, TestCategory("CategoryClient"), TestCategory("GetSubCategoriesAsync"), TestCategory("HTTP.GET")]
        public async Task GetSubCategoriesAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (CategoryClient c) => c.GetSubCategoriesAsync(1, false, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("CategoryClient"), TestCategory("GetSubCategoriesAsync"), TestCategory("HTTP.GET")]
        public async Task GetSubCategoriesAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (CategoryClient p) => p.GetSubCategoriesAsync(1, false, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata),
              string.Format("/catalog/categories?parentCategoryId={0}&includeMetadata={1}&imageAssetDetail={2}&videoAssetDetail={3}&documentAssetDetail={4}", 1, false, 4, 4, 4));
        }

        [TestMethod, TestCategory("CategoryClient"), TestCategory("GetSubCategoriesAsync"), TestCategory("HTTP.GET")]
        public async Task GetSubCategoriesAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (CategoryClient c) => c.GetSubCategoriesAsync(1, false, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata)
            );
        }

        [TestMethod, TestCategory("CategoryClient"), TestCategory("GetSubCategoriesAsync"), TestCategory("HTTP.GET")]
        public async Task GetSubCategoriesAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (CategoryClient t) => t.GetSubCategoriesAsync(1, false, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata, AssetDetailType.IncludeOnlyDefaultWithMetadata),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }
    }
}
        #endregion