using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Core.Exception;
using XOMNI.SDK.Private.Catalog;
using XOMNI.SDK.Tests.Private.Asset;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public abstract class CatalogAssetBaseFixture : SDKFixtureBase
    {
        TemporaryStorageManagementFixture tempFixture = null;

        public override void Init()
        {
            base.Init();
            tempFixture = new TemporaryStorageManagementFixture();
        }

        public abstract int relatedId { get; }
        public abstract IAssetRelation CatalogAssetBaseBusiness { get; }


        public virtual async Task PostGetUpdateDeleteImageRelationTest()
        {
            string fileName = Guid.NewGuid().ToString();
            int tempAssetId = await tempFixture.UploadAndCommitAsync(fileName);

            var relation = new AssetRelation()
            {
                IsDefault = true,
                TempAssetId = tempAssetId,
                ContentMimeType = "image/jpeg"
            };

            await CatalogAssetBaseBusiness.RelateImageAsync(relatedId, relation);


            string fileName1 = Guid.NewGuid().ToString();
            int tempAssetId1 = await tempFixture.UploadAndCommitAsync(fileName1);

            var relation1 = new AssetRelation()
            {
                IsDefault = true,
                TempAssetId = tempAssetId1,
                ContentMimeType = "image/jpeg"
            };

            await CatalogAssetBaseBusiness.RelateImageAsync(relatedId, relation1);

            try
            {
                await CatalogAssetBaseBusiness.RelateImageAsync(relatedId, relation1);
            }
            catch (BadRequestException)
            {
                //OK!
            }

            var notFoundRelation = new AssetRelation()
            {
                IsDefault = true,
                TempAssetId = -1,
                ContentMimeType = "image/jpeg"
            };

            try
            {
                await CatalogAssetBaseBusiness.RelateImageAsync(relatedId, notFoundRelation);
            }
            catch (NotFoundException)
            {
                //OK!
            }

            var assets = await CatalogAssetBaseBusiness.GetImagesAsync(relatedId);

            Assert.AreEqual(2, assets.Count, "Asset counts did not match");
            Assert.AreEqual(false, assets[0].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(true, assets[1].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(fileName, assets[0].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual(fileName1, assets[1].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual("image/jpeg", assets[0].ContentMimeType, "Content MIME Type value is wrong");
            Assert.AreEqual("image/jpeg", assets[1].ContentMimeType, "Content MIME Type  value is wrong");


            await CatalogAssetBaseBusiness.UpdateImageRelation(relatedId, assets[0].AssetId, true);

            var assets1 = await CatalogAssetBaseBusiness.GetImagesAsync(relatedId);

            var asset0 = assets1.Where(t => t.AssetId == assets[0].AssetId).Single();
            var asset1 = assets1.Where(t => t.AssetId == assets[1].AssetId).Single();

            Assert.AreEqual(true, asset0.IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(false, asset1.IsDefault, "API returned wrong default asset value");

            await CatalogAssetBaseBusiness.UnrelateImageAsync(relatedId, assets[0].AssetId);
            await CatalogAssetBaseBusiness.UnrelateImageAsync(relatedId, assets[1].AssetId);

            await tempFixture.DeleteAsync(fileName);
            await tempFixture.DeleteAsync(fileName1);

            try
            {
                assets = await CatalogAssetBaseBusiness.GetImagesAsync(relatedId);
            }
            catch (NotFoundException)
            {
                // OK
            }

            await CatalogAssetBaseBusiness.RelateImageAsync(relatedId, asset0.AssetId);

            try
            {
                await CatalogAssetBaseBusiness.RelateImageAsync(relatedId, asset0.AssetId);
            }
            catch (BadRequestException)
            {
                // OK (Existed relation)
            }

            try
            {
                await CatalogAssetBaseBusiness.RelateImageAsync(9999999, asset0.AssetId);
            }
            catch (NotFoundException)
            {
                // OK (Related id could not be found.)
            }

            await CatalogAssetBaseBusiness.RelateImageAsync(relatedId, asset1.AssetId, true);

            assets = await CatalogAssetBaseBusiness.GetImagesAsync(relatedId);

            Assert.AreEqual(2, assets.Count, "Asset counts did not match");
            Assert.AreEqual(false, assets[0].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(true, assets[1].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(fileName, assets[0].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual(fileName1, assets[1].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual("image/jpeg", assets[0].ContentMimeType, "Content MIME Type value is wrong");
            Assert.AreEqual("image/jpeg", assets[1].ContentMimeType, "Content MIME Type  value is wrong");

            await CatalogAssetBaseBusiness.UnrelateImageAsync(relatedId, assets[0].AssetId);
            await CatalogAssetBaseBusiness.UnrelateImageAsync(relatedId, assets[1].AssetId);
            //await tempFixture.DeleteAsync(tempAssetId);
        }

        public virtual async Task PostGetUpdateDeleteDocumentRelationTest()
        {
            string fileName = Guid.NewGuid().ToString();
            int tempAssetId = await tempFixture.UploadAndCommitAsync(fileName);

            var relation = new AssetRelation()
            {
                IsDefault = true,
                TempAssetId = tempAssetId,
                ContentMimeType = "image/jpeg"
            };

            await CatalogAssetBaseBusiness.RelateDocumentAsync(relatedId, relation);


            string fileName1 = Guid.NewGuid().ToString();
            int tempAssetId1 = await tempFixture.UploadAndCommitAsync(fileName1);

            var relation1 = new AssetRelation()
            {
                IsDefault = true,
                TempAssetId = tempAssetId1,
                ContentMimeType = "image/jpeg"
            };

            await CatalogAssetBaseBusiness.RelateDocumentAsync(relatedId, relation1);

            try
            {
                await CatalogAssetBaseBusiness.RelateDocumentAsync(relatedId, relation1);
            }
            catch (BadRequestException)
            {
                //OK!
            }

            var notFoundRelation = new AssetRelation()
            {
                IsDefault = true,
                TempAssetId = -1,
                ContentMimeType = "image/jpeg"
            };

            try
            {
                await CatalogAssetBaseBusiness.RelateDocumentAsync(relatedId, notFoundRelation);
            }
            catch (NotFoundException)
            {
                //OK!
            }

            var assets = await CatalogAssetBaseBusiness.GetDocumentsAsync(relatedId);

            Assert.AreEqual(2, assets.Count, "Asset counts did not match");
            Assert.AreEqual(false, assets[0].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(true, assets[1].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(fileName, assets[0].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual(fileName1, assets[1].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual("image/jpeg", assets[0].ContentMimeType, "Content MIME Type value is wrong");
            Assert.AreEqual("image/jpeg", assets[1].ContentMimeType, "Content MIME Type  value is wrong");


            await CatalogAssetBaseBusiness.UpdateDocumentRelation(relatedId, assets[0].AssetId, true);

            var assets1 = await CatalogAssetBaseBusiness.GetDocumentsAsync(relatedId);

            var asset0 = assets1.Where(t => t.AssetId == assets[0].AssetId).Single();
            var asset1 = assets1.Where(t => t.AssetId == assets[1].AssetId).Single();

            Assert.AreEqual(true, asset0.IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(false, asset1.IsDefault, "API returned wrong default asset value");

            await CatalogAssetBaseBusiness.UnrelateDocumentAsync(relatedId, assets[0].AssetId);
            await CatalogAssetBaseBusiness.UnrelateDocumentAsync(relatedId, assets[1].AssetId);

            await tempFixture.DeleteAsync(fileName);
            await tempFixture.DeleteAsync(fileName1);

            try
            {
                assets = await CatalogAssetBaseBusiness.GetDocumentsAsync(relatedId);
            }
            catch (NotFoundException)
            {
                // OK
            }

            await CatalogAssetBaseBusiness.RelateDocumentAsync(relatedId, asset0.AssetId);

            try
            {
                await CatalogAssetBaseBusiness.RelateDocumentAsync(relatedId, asset0.AssetId);
            }
            catch (BadRequestException)
            {
                // OK (Existed relation)
            }

            try
            {
                await CatalogAssetBaseBusiness.RelateDocumentAsync(9999999, asset0.AssetId);
            }
            catch (NotFoundException)
            {
                // OK (Related id could not be found.)
            }

            await CatalogAssetBaseBusiness.RelateDocumentAsync(relatedId, asset1.AssetId, true);

            assets = await CatalogAssetBaseBusiness.GetDocumentsAsync(relatedId);

            Assert.AreEqual(2, assets.Count, "Asset counts did not match");
            Assert.AreEqual(false, assets[0].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(true, assets[1].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(fileName, assets[0].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual(fileName1, assets[1].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual("image/jpeg", assets[0].ContentMimeType, "Content MIME Type value is wrong");
            Assert.AreEqual("image/jpeg", assets[1].ContentMimeType, "Content MIME Type  value is wrong");

            await CatalogAssetBaseBusiness.UnrelateDocumentAsync(relatedId, assets[0].AssetId);
            await CatalogAssetBaseBusiness.UnrelateDocumentAsync(relatedId, assets[1].AssetId);
            //await tempFixture.DeleteAsync(tempAssetId);
        }

        public virtual async Task PostGetUpdateDeleteVideoRelationTest()
        {
            string fileName = Guid.NewGuid().ToString();
            int tempAssetId = await tempFixture.UploadAndCommitAsync(fileName);

            var relation = new AssetRelation()
            {
                IsDefault = true,
                TempAssetId = tempAssetId,
                ContentMimeType = "image/jpeg"
            };

            await CatalogAssetBaseBusiness.RelateVideoAsync(relatedId, relation);


            string fileName1 = Guid.NewGuid().ToString();
            int tempAssetId1 = await tempFixture.UploadAndCommitAsync(fileName1);

            var relation1 = new AssetRelation()
            {
                IsDefault = true,
                TempAssetId = tempAssetId1,
                ContentMimeType = "image/jpeg"
            };

            await CatalogAssetBaseBusiness.RelateVideoAsync(relatedId, relation1);

            try
            {
                await CatalogAssetBaseBusiness.RelateVideoAsync(relatedId, relation1);
            }
            catch (BadRequestException)
            {
                //OK!
            }

            var notFoundRelation = new AssetRelation()
            {
                IsDefault = true,
                TempAssetId = -1,
                ContentMimeType = "image/jpeg"
            };

            try
            {
                await CatalogAssetBaseBusiness.RelateVideoAsync(relatedId, notFoundRelation);
            }
            catch (NotFoundException)
            {
                //OK!
            }

            var assets = await CatalogAssetBaseBusiness.GetVideosAsync(relatedId);

            Assert.AreEqual(2, assets.Count, "Asset counts did not match");
            Assert.AreEqual(false, assets[0].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(true, assets[1].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(fileName, assets[0].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual(fileName1, assets[1].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual("image/jpeg", assets[0].ContentMimeType, "Content MIME Type value is wrong");
            Assert.AreEqual("image/jpeg", assets[1].ContentMimeType, "Content MIME Type  value is wrong");


            await CatalogAssetBaseBusiness.UpdateVideoRelation(relatedId, assets[0].AssetId, true);

            var assets1 = await CatalogAssetBaseBusiness.GetVideosAsync(relatedId);

            var asset0 = assets1.Where(t => t.AssetId == assets[0].AssetId).Single();
            var asset1 = assets1.Where(t => t.AssetId == assets[1].AssetId).Single();

            Assert.AreEqual(true, asset0.IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(false, asset1.IsDefault, "API returned wrong default asset value");

            await CatalogAssetBaseBusiness.UnrelateVideoAsync(relatedId, assets[0].AssetId);
            await CatalogAssetBaseBusiness.UnrelateVideoAsync(relatedId, assets[1].AssetId);

            await tempFixture.DeleteAsync(fileName);
            await tempFixture.DeleteAsync(fileName1);

            try
            {
                assets = await CatalogAssetBaseBusiness.GetVideosAsync(relatedId);
            }
            catch (NotFoundException)
            {
                // OK
            }

            await CatalogAssetBaseBusiness.RelateVideoAsync(relatedId, asset0.AssetId);

            try
            {
                await CatalogAssetBaseBusiness.RelateVideoAsync(relatedId, asset0.AssetId);
            }
            catch (BadRequestException)
            {
                // OK (Existed relation)
            }

            try
            {
                await CatalogAssetBaseBusiness.RelateVideoAsync(9999999, asset0.AssetId);
            }
            catch (NotFoundException)
            {
                // OK (Related id could not be found.)
            }

            await CatalogAssetBaseBusiness.RelateVideoAsync(relatedId, asset1.AssetId, true);

            assets = await CatalogAssetBaseBusiness.GetVideosAsync(relatedId);

            Assert.AreEqual(2, assets.Count, "Asset counts did not match");
            Assert.AreEqual(false, assets[0].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(true, assets[1].IsDefault, "API returned wrong default asset value");
            Assert.AreEqual(fileName, assets[0].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual(fileName1, assets[1].OriginalFilename, "Orginal file name value is wrong");
            Assert.AreEqual("image/jpeg", assets[0].ContentMimeType, "Content MIME Type value is wrong");
            Assert.AreEqual("image/jpeg", assets[1].ContentMimeType, "Content MIME Type  value is wrong");

            await CatalogAssetBaseBusiness.UnrelateVideoAsync(relatedId, assets[0].AssetId);
            await CatalogAssetBaseBusiness.UnrelateVideoAsync(relatedId, assets[1].AssetId);
            //await tempFixture.DeleteAsync(tempAssetId);
        }
    }
}
