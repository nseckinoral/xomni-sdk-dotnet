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
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Catalog
{
    [TestClass]
    public class ItemCompareClientFixture : BaseClientFixture<ItemCompareClient>
    {
        #region arrange

        protected const string validAPIResponseForCompare = @"{
            'Data': {
                'Items': [
                    {
                        'Id': 1,
                        'RFID': null,
                        'UUID': null,
                        'SKU': null,
                        'Name': 'D1 Red-S-A Style',
                        'Model': 'Model 1',
                        'Title': 'D1 Title',
                        'ShortDescription': 'Master Item 1 Short Description',
                        'LongDescription': null,
                        'Rating': null,
                        'LikeCount': 80,
                        'CategoryId': 66,
                        'InStock': true,
                        'PublicWebLink': null,
                        'DefaultItemId': 1,
                        'BrandId': 1,
                        'UnitTypeId': 3,
                        'UnitTypeCode': 'Quantity',
                        'UnitTypeName': 'Quantity',
                        'DynamicAttributes': [
                            {
                                'TypeId': 1,
                                'TypeValueId': 1,
                                'Value': 'Red',
                                'TypeName': 'Color'
                            },
                            {
                                'TypeId': 3,
                                'TypeValueId': 7,
                                'Value': 'A',
                                'TypeName': 'Style'
                            },
                            {
                                'TypeId': 2,
                                'TypeValueId': 9,
                                'Value': 'S',
                                'TypeName': 'Size'
                            }
                        ],
                        'Prices': [
                            {
                                'NormalPrice': 100.55,
                                'DiscountPrice': null,
                                'CurrencySymbol': '€',
                                'CurrencyId': 2
                            },
                            {
                                'NormalPrice': 140.55,
                                'DiscountPrice': null,
                                'CurrencySymbol': '$',
                                'CurrencyId': 1
                            }
                        ],
                        'Tags': [],
                        'Weights': [
                            {
                                'WeightTypeId': 1,
                                'WeightTypeDescription': 'Kg',
                                'Value': 20
                            },
                            {
                                'WeightTypeId': 1,
                                'WeightTypeDescription': 'Kg',
                                'Value': 40
                            }
                        ],
                        'Dimensions': [
                            {
                                'DimensionTypeId': 1,
                                'DimensionDescription': 'Meter',
                                'Width': 1,
                                'Height': 1,
                                'Depth': 1
                            },
                            {
                                'DimensionTypeId': 2,
                                'DimensionDescription': 'Inch',
                                'Width': 3,
                                'Height': 3,
                                'Depth': 3
                            }
                        ],
                        'Metadata': []
                    },
                    {
                        'Id': 2,
                        'RFID': null,
                        'UUID': null,
                        'SKU': null,
                        'Name': 'D2 Red-S-A Style',
                        'Model': 'Model 2',
                        'Title': 'D2 Title',
                        'ShortDescription': 'D2 Short Description',
                        'LongDescription': 'D2 Long Description',
                        'Rating': null,
                        'LikeCount': null,
                        'CategoryId': 67,
                        'InStock': true,
                        'PublicWebLink': null,
                        'DefaultItemId': 2,
                        'BrandId': 2,
                        'UnitTypeId': 2,
                        'UnitTypeCode': 'Kg',
                        'UnitTypeName': '250 Kilogram',
                        'DynamicAttributes': [
                            {
                                'TypeId': 1,
                                'TypeValueId': 1,
                                'Value': 'Red',
                                'TypeName': 'Color'
                            },
                            {
                                'TypeId': 3,
                                'TypeValueId': 7,
                                'Value': 'A',
                                'TypeName': 'Style'
                            },
                            {
                                'TypeId': 2,
                                'TypeValueId': 9,
                                'Value': 'S',
                                'TypeName': 'Size'
                            }
                        ],
                        'Prices': [
                            {
                                'NormalPrice': 10.55,
                                'DiscountPrice': null,
                                'CurrencySymbol': '$',
                                'CurrencyId': 1
                            },
                            {
                                'NormalPrice': 20.55,
                                'DiscountPrice': 15,
                                'CurrencySymbol': '€',
                                'CurrencyId': 2
                            }
                        ],
                        'Tags': [
                            {
                                'Id': 2,
                                'Name': '3e129d70-2308-4dc5-bd33-c389b92859d2',
                                'Description': '3e129d70-2308-4dc5-bd33-c389b92859d2'
                            }
                        ],
                        'Weights': [],
                        'Dimensions': [
                            {
                                'DimensionTypeId': 1,
                                'DimensionDescription': 'Meter',
                                'Width': 11,
                                'Height': 11,
                                'Depth': 11
                            },
                            {
                                'DimensionTypeId': 2,
                                'DimensionDescription': 'Inch',
                                'Width': 5,
                                'Height': 5,
                                'Depth': 5
                            }
                        ],
                        'Metadata': []
                    },
                    {
                        'Id': 3,
                        'RFID': null,
                        'UUID': null,
                        'SKU': null,
                        'Name': 'D1V2 Red-M-A Style',
                        'Model': 'Model Name',
                        'Title': 'D1 Title',
                        'ShortDescription': 'D1V2 Short Description',
                        'LongDescription': null,
                        'Rating': null,
                        'LikeCount': 55,
                        'CategoryId': 66,
                        'InStock': true,
                        'PublicWebLink': null,
                        'DefaultItemId': 1,
                        'BrandId': 1,
                        'UnitTypeId': 3,
                        'UnitTypeCode': 'Quantity',
                        'UnitTypeName': 'Quantity',
                        'DynamicAttributes': [
                            {
                                'TypeId': 1,
                                'TypeValueId': 1,
                                'Value': 'Red',
                                'TypeName': 'Color'
                            },
                            {
                                'TypeId': 2,
                                'TypeValueId': 4,
                                'Value': 'M',
                                'TypeName': 'Size'
                            },
                            {
                                'TypeId': 3,
                                'TypeValueId': 7,
                                'Value': 'A',
                                'TypeName': 'Style'
                            }
                        ],
                        'Prices': [
                            {
                                'NormalPrice': 111.55,
                                'DiscountPrice': null,
                                'CurrencySymbol': '€',
                                'CurrencyId': 2
                            },
                            {
                                'NormalPrice': 160.55,
                                'DiscountPrice': null,
                                'CurrencySymbol': '$',
                                'CurrencyId': 1
                            }
                        ],
                        'Tags': [],
                        'Weights': [
                            {
                                'WeightTypeId': 1,
                                'WeightTypeDescription': 'Kg',
                                'Value': 20
                            },
                            {
                                'WeightTypeId': 1,
                                'WeightTypeDescription': 'Kg',
                                'Value': 40
                            }
                        ],
                        'Dimensions': [
                            {
                                'DimensionTypeId': 1,
                                'DimensionDescription': 'Meter',
                                'Width': 1,
                                'Height': 1,
                                'Depth': 1
                            },
                            {
                                'DimensionTypeId': 2,
                                'DimensionDescription': 'Inch',
                                'Width': 3,
                                'Height': 3,
                                'Depth': 3
                            }
                        ],
                        'Metadata': []
                    }
                ],
                'TotalItemCount': 3,
                'DynamicNavigation': null,
                'StaticNavigation': null
            }
        }";

        protected const string validAPIResponseForCompareMatrix = @"{
            'Data': {
                'TableRows': [
                    {
                        'Cells': [
                            {
                                'Value': 'Name'
                            },
                            {
                                'Value': 'Default Item 1 Red-S-A Style'
                            },
                            {
                                'Value': 'Master Item 1 Red-S-B Style'
                            },
                            {
                                'Value': 'Master Item 1 Red-M-A Style'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'RFID'
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'UUID'
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'SKU'
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Model'
                            },
                            {
                                'Value': 'Model Name'
                            },
                            {
                                'Value': 'Model Name'
                            },
                            {
                                'Value': 'Model Name'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Title'
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'ShortDescription'
                            },
                            {
                                'Value': 'Master Item 1 Short Description'
                            },
                            {
                                'Value': 'Master Item 1 Variant 1 Short Description'
                            },
                            {
                                'Value': 'Master Item 1 Variant 1 Short Description'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'LongDescription'
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Width'
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Height'
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Weight'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'InStock'
                            },
                            {
                                'Value': 'True'
                            },
                            {
                                'Value': 'True'
                            },
                            {
                                'Value': 'True'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Rating'
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'LikeCount'
                            },
                            {
                                'Value': '80'
                            },
                            {
                                'Value': '80'
                            },
                            {
                                'Value': '80'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'UnitTypeName'
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Category'
                            },
                            {
                                'Value': 'Category 1 Sub 1 Sub 1'
                            },
                            {
                                'Value': 'Category 1 Sub 1 Sub 1'
                            },
                            {
                                'Value': 'Category 1 Sub 1 Sub 1'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Brand'
                            },
                            {
                                'Value': 'Brand 1'
                            },
                            {
                                'Value': 'Brand 1'
                            },
                            {
                                'Value': 'Brand 1'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Normal Price - €'
                            },
                            {
                                'Value': '100,55'
                            },
                            {
                                'Value': '100,55'
                            },
                            {
                                'Value': '100,55'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Discount Price - €'
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Normal Price - $'
                            },
                            {
                                'Value': '140,55'
                            },
                            {
                                'Value': '140,55'
                            },
                            {
                                'Value': '140,55'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Discount Price - $'
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            },
                            {
                                'Value': ''
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Color'
                            },
                            {
                                'Value': 'Red'
                            },
                            {
                                'Value': 'Red'
                            },
                            {
                                'Value': 'Red'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Style'
                            },
                            {
                                'Value': 'A'
                            },
                            {
                                'Value': 'B'
                            },
                            {
                                'Value': 'A'
                            }
                        ]
                    },
                    {
                        'Cells': [
                            {
                                'Value': 'Size'
                            },
                            {
                                'Value': 'S'
                            },
                            {
                                'Value': 'S'
                            },
                            {
                                'Value': 'M'
                            }
                        ]
                    }
                ]
            }
        }";

        readonly List<int> sampleRequest = new List<int>()
        {
            1,2,3
        };

        #endregion

        #region CompareAsync
        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareAsync"), TestCategory("HTTP.POST")]
        public async Task CompareAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ItemCompareClient c) => c.CompareAsync(sampleRequest)
            );
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareAsync"), TestCategory("HTTP.POST")]
        public async Task CompareAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ItemCompareClient c) => c.CompareAsync(sampleRequest),
                HttpMethod.Post
                );
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareAsync"), TestCategory("HTTP.POST")]
        public async Task CompareAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ItemCompareClient c) => c.CompareAsync(sampleRequest),
              string.Format("/catalog/itemcompare"));
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareAsync"), TestCategory("HTTP.POST")]
        public async Task CompareAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (ItemCompareClient p) => p.CompareAsync(new List<int>() 
              {
                1,2,3,4,5,6
              }),
            new ArgumentOutOfRangeException("Count", 6, string.Format("{0} must be in range ({1} - {2}).", "Count", 2, 5)));
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareAsync"), TestCategory("HTTP.POST")]
        public async Task CompareAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (ItemCompareClient c) => c.CompareAsync(sampleRequest),
              badRequestHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareAsync"), TestCategory("HTTP.POST")]
        public async Task CompareAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ItemCompareClient c) => c.CompareAsync(sampleRequest),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareAsync"), TestCategory("HTTP.POST")]
        public async Task CompareAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ItemCompareClient c) => c.CompareAsync(sampleRequest));
        }
        #endregion

        #region CompareMatrixAsync

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareMatrixAsync"), TestCategory("HTTP.POST")]
        public async Task CompareMatrixAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ItemCompareClient c) => c.CompareMatrixAsync(sampleRequest)
            );
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareMatrixAsync"), TestCategory("HTTP.POST")]
        public async Task CompareMatrixAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ItemCompareClient c) => c.CompareMatrixAsync(sampleRequest),
                HttpMethod.Post
                );
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareMatrixAsync"), TestCategory("HTTP.POST")]
        public async Task CompareMatrixAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ItemCompareClient c) => c.CompareMatrixAsync(sampleRequest),
              string.Format("/catalog/itemcomparematrix"));
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareMatrixAsync"), TestCategory("HTTP.POST")]
        public async Task CompareMatrixAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (ItemCompareClient p) => p.CompareMatrixAsync(new List<int>() 
              {
                1,2,3,4,5,6
              }),
            new ArgumentOutOfRangeException("Count", 6, string.Format("{0} must be in range ({1} - {2}).", "Count", 2, 5)));
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareMatrixAsync"), TestCategory("HTTP.POST")]
        public async Task CompareMatrixAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (ItemCompareClient c) => c.CompareMatrixAsync(sampleRequest),
              badRequestHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareMatrixAsync"), TestCategory("HTTP.POST")]
        public async Task CompareMatrixAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ItemCompareClient c) => c.CompareMatrixAsync(sampleRequest),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("ItemCompareClient"), TestCategory("CompareMatrixAsync"), TestCategory("HTTP.POST")]
        public async Task CompareMatrixAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ItemCompareClient c) => c.CompareMatrixAsync(sampleRequest));
        }
        #endregion
    }
}
