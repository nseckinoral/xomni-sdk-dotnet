using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.OmniPlay;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Models.OmniPlay;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.OmniPlay
{
    [TestClass]
    public class PollingClientFixture : BaseClientFixture<PollingClient>
    {
        const string validAPIResponseForGetWishlistAsync = @"{
            'Data': {
                'Name': 'Wishlist Sample Name',
                'WishlistItems': [
                    {
                        'CategoryMetadata': null,
                        'Item': {
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
                            'UnitTypeName': 'Quantity',
                            'UnitTypeCode': 'Quantity',
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
                            'Weights': [],
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
                            'ImageAssets': [],
                            'VideoAssets': [],
                            'DocumentAssets': [],
                            'HasVariants': true
                        },
                        'BluetoothId': 'BluetoothId',
                        'DateAdded': '2013-07-12T12:53:39.777',
                        'UniqueKey': '90a1de56-20ea-4460-b6f1-6ab533387f6b'
                    },
                    {
                        'CategoryMetadata': null,
                        'Item': {
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
                            'UnitTypeName': '250 Kilogram',
                            'UnitTypeCode': 'Kg',
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
                                    'Name': 'c4da4bd6-2783-4a45-8fa8-2c4777113f19',
                                    'Description': 'c4da4bd6-2783-4a45-8fa8-2c4777113f19',
                                    'TagMetadata': []
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
                            'ImageAssets': [],
                            'VideoAssets': [],
                            'DocumentAssets': [],
                            'HasVariants': true
                        },
                        'BluetoothId': 'BluetoothId',
                        'DateAdded': '2013-07-12T12:53:40.753',
                        'UniqueKey': '5df0c833-326f-4ac1-8ea2-a118b17b6e95'
                    }
                ],
                'LastSeenLocation': null,
                'IsPublic': true,
                'UniqueKey': '3d6a2c36-d85e-458f-b13f-438c03bc22be'
            }
        }";

        const string validAPIResponseForGetShoppingcartAsync = @"{
            'Data': {
                'Name': 'ShoppingCart Sample Name',
                'ShoppingCartItems': [
                    {
                        'CategoryMetadata': null,
                        'Quantity':5,
                        'Item': {
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
                            'UnitTypeName': 'Quantity',
                            'UnitTypeCode': 'Quantity',
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
                            'Weights': [],
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
                            'ImageAssets': [],
                            'VideoAssets': [],
                            'DocumentAssets': [],
                            'HasVariants': true
                        },
                        'BluetoothId': 'BluetoothId',
                        'DateAdded': '2013-07-12T12:53:39.777',
                        'UniqueKey': '90a1de56-20ea-4460-b6f1-6ab533387f6b'
                    },
                    {
                        'CategoryMetadata': null,
                        'Quantity':5,
                        'Item': {
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
                            'UnitTypeName': '250 Kilogram',
                            'UnitTypeCode': 'Kg',
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
                                    'Name': 'c4da4bd6-2783-4a45-8fa8-2c4777113f19',
                                    'Description': 'c4da4bd6-2783-4a45-8fa8-2c4777113f19',
                                    'TagMetadata': []
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
                            'ImageAssets': [],
                            'VideoAssets': [],
                            'DocumentAssets': [],
                            'HasVariants': true
                        },
                        'BluetoothId': 'BluetoothId',
                        'DateAdded': '2013-07-12T12:53:40.753',
                        'UniqueKey': '5df0c833-326f-4ac1-8ea2-a118b17b6e95'
                    }
                ],
                'LastSeenLocation': null,
                'IsPublic': true,
                'UniqueKey': '3d6a2c36-d85e-458f-b13f-438c03bc22be'
            }
        }";

        readonly OmniTicket sampleTicket = new OmniTicket()
        {
            Ticket = uniqueId
        };

        readonly Location validLocation = new Location()
          {
              Latitude = 21.22,
              Longitude = 28.43
          };

        #region GetWishlistAsync

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetWishlistAsync"), TestCategory("HTTP.GET")]
        public async Task GetWishlistAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (PollingClient c) => c.GetWishlistAsync(Guid.Parse(uniqueId)),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForGetWishlistAsync)
                },
                validAPIResponseForGetWishlistAsync
                );
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetWishlistAsync"), TestCategory("HTTP.GET")]
        public async Task GetWishlistAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (PollingClient c) => c.GetWishlistAsync(Guid.Parse(uniqueId)),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetWishlistAsync"), TestCategory("HTTP.GET")]
        public async Task GetWishlistAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (PollingClient c) => c.GetWishlistAsync(Guid.Parse(uniqueId)),
              string.Format("/omniplay/wishlist?wishlistUniqueKey={0}&includeItemStaticProperties={1}&includeItemDynamicProperties={2}&includeCategoryMetadata={3}&imageAssetDetail={4}&videoAssetDetail={5}&documentAssetDetail={6}", uniqueId, true, false, false, (int)AssetDetailType.None, (int)AssetDetailType.None, (int)AssetDetailType.None)
              );

            await base.UriTestAsync(
              (PollingClient c) => c.GetWishlistAsync(Guid.Parse(uniqueId), validLocation),
              string.Format("/omniplay/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}", uniqueId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString(), true, false, false, (int)AssetDetailType.None, (int)AssetDetailType.None, (int)AssetDetailType.None)
              );

            await base.UriTestAsync(
              (PollingClient c) => c.GetWishlistAsync(Guid.Parse(uniqueId), validLocation, metadataKey: "key", metadataValue: "value"),
              string.Format("/omniplay/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}&metadataKey={9}&metadataValue={10}", uniqueId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString(), true, false, false, (int)AssetDetailType.None, (int)AssetDetailType.None, (int)AssetDetailType.None, "key", "value")
              );

            await base.UriTestAsync(
              (PollingClient c) => c.GetWishlistAsync(Guid.Parse(uniqueId), validLocation, includeItemStaticProperties: false, includeItemDynamicProperties: true, includeCategoryMetadata: true),
              string.Format("/omniplay/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}", uniqueId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString(), false, true, true, (int)AssetDetailType.None, (int)AssetDetailType.None, (int)AssetDetailType.None)
              );

            await base.UriTestAsync(
              (PollingClient c) => c.GetWishlistAsync(Guid.Parse(uniqueId), validLocation, includeItemStaticProperties: false, includeItemDynamicProperties: true, includeCategoryMetadata: true, metadataKey: "key", metadataValue: "value"),
              string.Format("/omniplay/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}&metadataKey={9}&metadataValue={10}", uniqueId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString(), false, true, true, (int)AssetDetailType.None, (int)AssetDetailType.None, (int)AssetDetailType.None, "key", "value")
              );

            await base.UriTestAsync(
              (PollingClient c) => c.GetWishlistAsync(Guid.Parse(uniqueId), validLocation, includeItemStaticProperties: false, includeItemDynamicProperties: true, includeCategoryMetadata: true, metadataKey: "key", metadataValue: "value", imageAssetDetail: AssetDetailType.IncludeOnlyDefaultWithMetadata, documentAssetDetail: AssetDetailType.IncludeOnlyDefaultWithMetadata, videoAssetDetail: AssetDetailType.IncludeOnlyDefaultWithMetadata),
              string.Format("/omniplay/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}&metadataKey={9}&metadataValue={10}", uniqueId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString(), false, true, true, (int)AssetDetailType.IncludeOnlyDefaultWithMetadata, (int)AssetDetailType.IncludeOnlyDefaultWithMetadata, (int)AssetDetailType.IncludeOnlyDefaultWithMetadata, "key", "value")
              );
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetWishlistAsync"), TestCategory("HTTP.GET")]
        public async Task GetWishlistAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
              (PollingClient c) => c.GetWishlistAsync(Guid.Parse(uniqueId))
              );
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetWishlistAsync"), TestCategory("HTTP.GET")]
        public async Task GetWishlistAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (PollingClient p) => p.GetWishlistAsync(Guid.Parse(uniqueId), new Location()
                {
                    Latitude = 100,
                    Longitude = 23.32
                }),
                new ArgumentOutOfRangeException("Latitude", 100, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90))
            );

            await base.SDKExceptionResponseTestAsync(
                 (PollingClient p) => p.GetWishlistAsync(Guid.Parse(uniqueId), new Location()
                 {
                     Latitude = 34.23,
                     Longitude = 181.23
                 }),
                 new ArgumentOutOfRangeException("Longitude", 181.23, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180))
            );

            await base.SDKExceptionResponseTestAsync(
                (PollingClient p) => p.GetWishlistAsync(Guid.Parse(uniqueId), metadataKey: "key"),
               new ArgumentException(string.Format("{0} can not be empty or null.", "metadataValue"))
             );

            await base.SDKExceptionResponseTestAsync(
                (PollingClient p) => p.GetWishlistAsync(Guid.Parse(uniqueId), metadataValue: "value"),
               new ArgumentException(string.Format("{0} can not be empty or null.", "metadataKey"))
             );
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetWishlistAsync"), TestCategory("HTTP.GET")]
        public async Task GetWishlistAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (PollingClient c) => c.GetWishlistAsync(Guid.Parse(uniqueId)),
              notFoundHttpResponseMessage,
              expectedExceptionResult
              );
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetWishlistAsync"), TestCategory("HTTP.GET")]
        public async Task GetWishlistAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (PollingClient c) => c.GetWishlistAsync(Guid.Parse(uniqueId)),
              forbiddenHttpResponseMessage,
              expectedExceptionResult
              );
        }

        #endregion

        #region GetShoppingcartAsync

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetShoppingcartAsync"), TestCategory("HTTP.GET")]
        public async Task GetShoppingcartAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (PollingClient p) => p.GetShoppingcartAsync(Guid.Parse(uniqueId)),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForGetShoppingcartAsync)
                },
                validAPIResponseForGetShoppingcartAsync);
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetShoppingcartAsync"), TestCategory("HTTP.GET")]
        public async Task GetShoppingcartAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (PollingClient c) => c.GetShoppingcartAsync(Guid.Parse(uniqueId)),
                HttpMethod.Get
                );
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetShoppingcartAsync"), TestCategory("HTTP.GET")]
        public async Task GetShoppingcartAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (PollingClient c) => c.GetShoppingcartAsync(Guid.Parse(uniqueId)),
              string.Format("/omniplay/shoppingcart?shoppingCartUniqueKey={0}&includeItemStaticProperties={1}&includeItemDynamicProperties={2}&includeCategoryMetadata={3}&imageAssetDetail={4}&videoAssetDetail={5}&documentAssetDetail={6}", uniqueId, true, false, false, (int)AssetDetailType.None, (int)AssetDetailType.None, (int)AssetDetailType.None));

            await base.UriTestAsync(
              (PollingClient p) => p.GetWishlistAsync(Guid.Parse(uniqueId), validLocation),
              string.Format("/omniplay/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}", uniqueId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString(), true, false, false, (int)AssetDetailType.None, (int)AssetDetailType.None, (int)AssetDetailType.None));

            await base.UriTestAsync(
              (PollingClient c) => c.GetShoppingcartAsync(Guid.Parse(uniqueId), validLocation, metadataKey: "key", metadataValue: "value"),
              string.Format("/omniplay/shoppingcart?shoppingCartUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}&metadataKey={9}&metadataValue={10}", uniqueId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString(), true, false, false, (int)AssetDetailType.None, (int)AssetDetailType.None, (int)AssetDetailType.None, "key", "value"));

            await base.UriTestAsync(
              (PollingClient c) => c.GetShoppingcartAsync(Guid.Parse(uniqueId), validLocation, includeItemStaticProperties: false, includeItemDynamicProperties: true, includeCategoryMetadata: true),
              string.Format("/omniplay/shoppingcart?shoppingCartUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}", uniqueId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString(), false, true, true, (int)AssetDetailType.None, (int)AssetDetailType.None, (int)AssetDetailType.None));

            await base.UriTestAsync(
              (PollingClient c) => c.GetShoppingcartAsync(Guid.Parse(uniqueId), validLocation, includeItemStaticProperties: false, includeItemDynamicProperties: true, includeCategoryMetadata: true, metadataKey: "key", metadataValue: "value"),
              string.Format("/omniplay/shoppingcart?shoppingCartUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}&metadataKey={9}&metadataValue={10}", uniqueId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString(), false, true, true, (int)AssetDetailType.None, (int)AssetDetailType.None, (int)AssetDetailType.None, "key", "value"));

            await base.UriTestAsync(
              (PollingClient c) => c.GetShoppingcartAsync(Guid.Parse(uniqueId), validLocation, includeItemStaticProperties: false, includeItemDynamicProperties: true, includeCategoryMetadata: true, metadataKey: "key", metadataValue: "value", imageAssetDetail: AssetDetailType.IncludeOnlyDefaultWithMetadata, documentAssetDetail: AssetDetailType.IncludeOnlyDefaultWithMetadata, videoAssetDetail: AssetDetailType.IncludeOnlyDefaultWithMetadata),
              string.Format("/omniplay/shoppingcart?shoppingCartUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}&metadataKey={9}&metadataValue={10}", uniqueId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString(), false, true, true, (int)AssetDetailType.IncludeOnlyDefaultWithMetadata, (int)AssetDetailType.IncludeOnlyDefaultWithMetadata, (int)AssetDetailType.IncludeOnlyDefaultWithMetadata, "key", "value"));
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetShoppingcartAsync"), TestCategory("HTTP.GET")]
        public async Task GetShoppingcartAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
              (PollingClient c) => c.GetShoppingcartAsync(Guid.Parse(uniqueId))
              );
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetShoppingcartAsync"), TestCategory("HTTP.GET")]
        public async Task GetShoppingcartAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (PollingClient p) => p.GetShoppingcartAsync(Guid.Parse(uniqueId), new Location()
                {
                    Latitude = 100,
                    Longitude = 23.32
                }),
                new ArgumentOutOfRangeException("Latitude", 100, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90))
            );

            await base.SDKExceptionResponseTestAsync(
                 (PollingClient p) => p.GetShoppingcartAsync(Guid.Parse(uniqueId), new Location()
                 {
                     Latitude = 34.23,
                     Longitude = 181.23
                 }),
                 new ArgumentOutOfRangeException("Longitude", 181.23, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180))
            );

            await base.SDKExceptionResponseTestAsync(
                (PollingClient p) => p.GetShoppingcartAsync(Guid.Parse(uniqueId), metadataKey: "key"),
               new ArgumentException(string.Format("{0} can not be empty or null.", "metadataValue"))
             );

            await base.SDKExceptionResponseTestAsync(
                (PollingClient p) => p.GetShoppingcartAsync(Guid.Parse(uniqueId), metadataValue: "value"),
               new ArgumentException(string.Format("{0} can not be empty or null.", "metadataKey"))
             );
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetShoppingcartAsync"), TestCategory("HTTP.GET")]
        public async Task GetShoppingcartAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (PollingClient c) => c.GetShoppingcartAsync(Guid.Parse(uniqueId)),
              notFoundHttpResponseMessage,
              expectedExceptionResult
              );
        }

        [TestMethod, TestCategory("PollingClient"), TestCategory("GetShoppingcartAsync"), TestCategory("HTTP.GET")]
        public async Task GetShoppingcartAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (PollingClient c) => c.GetShoppingcartAsync(Guid.Parse(uniqueId)),
              forbiddenHttpResponseMessage,
              expectedExceptionResult
              );
        }

        #endregion
    }
}
