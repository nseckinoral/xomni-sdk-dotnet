using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Exception;

namespace XOMNI.SDK.Tests.Private.Asset
{
    [TestClass]
    public class TemporaryStorageManagementFixture : SDKFixtureBase
    {
        private XOMNI.SDK.Private.Asset.TemporaryStorageManagement tempAssetBusiness = null;

        public override void Init()
        {
            base.Init();
            tempAssetBusiness = new XOMNI.SDK.Private.Asset.TemporaryStorageManagement();
        }

        [TestMethod]
        [TestCategory("SDK.Private.Asset"), TestCategory("Integration"), TestCategory("SDK.Private.Asset.TemporaryStorageManagement")]
        public async Task UploadCommitDeleteTest()
        {
            string fileName = "testImage.jpg";

            List<string> blockIds = new List<string>();

            using (var file = new FileStream(@"testAssets/bigtestImage.jpg", FileMode.Open, FileAccess.Read))
            {
                blockIds = await UploadAsync(fileName, file);
            }

            var tempAssetId = await CommitAsync(fileName, blockIds.ToArray());
            Assert.IsTrue(tempAssetId > 0, "Temp asset id could not be null or empty.");

            await DeleteAsync(fileName);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Asset"), TestCategory("Integration"), TestCategory("SDK.Private.Asset.TemporaryStorageManagement")]
        public async Task UploadDuplicatedFileNameTest()
        {
            string fileName = "testImage.jpg";

            List<string> blockIds = new List<string>();

            using (var file = new FileStream(@"testAssets/testImage.jpg", FileMode.Open, FileAccess.Read))
            {
                blockIds = await UploadAsync(fileName, file);
            }

            await CommitAsync(fileName, blockIds.ToArray());

            try
            {
                using (var file = new FileStream(@"testAssets/testImage.jpg", FileMode.Open, FileAccess.Read))
                {
                    blockIds = await UploadAsync(fileName, file);
                }
            }
            catch (ConflictException ce)
            {
                //OK!
            }
            catch (Exception ex)
            {
                Assert.Fail("Invalid exception throwed. Expected exception type is ConflictException.");
            }

            await DeleteAsync(fileName);
        }

        [TestMethod]
        [TestCategory("SDK.Private.Asset"), TestCategory("Integration"), TestCategory("SDK.Private.Asset.TemporaryStorageManagement")]
        public async Task UploadBiggerChunkTest()
        {
            string fileName = "testImage.jpg";

            List<string> blockIds = new List<string>();

            try
            {
                using (var file = new FileStream(@"testAssets/bigtestImage.jpg", FileMode.Open, FileAccess.Read))
                {
                    blockIds = await UploadAsync(fileName, file, 5000);
                }
            }
            catch (RequestEntityTooLargeException retle)
            {
                //OK!
            }
            catch (Exception ex)
            {
                Assert.Fail("Invalid exception throwed. Expected exception type is RequestEntityTooLargeException.");
            }
        }


        public async Task<List<string>> UploadAsync(string fileName, FileStream file, int blockSize = 3000)
        {
            List<string> retVal = new List<string>();

            while (file.Position < file.Length)
            {
                var bufferSize = blockSize * 1024 < file.Length - file.Position ? blockSize * 1024 : file.Length - file.Position;
                var buffer = new byte[bufferSize];
                int bytesread = file.Read(buffer, 0, buffer.Length);
                var blockId = await tempAssetBusiness.UploadAsync(fileName, buffer);

                Assert.IsTrue(!string.IsNullOrEmpty(blockId), "Temp asset chunk block id could not be null or empty.");

                retVal.Add(blockId);
            }

            return retVal;
        }

        public async Task<int> CommitAsync(string fileName, string[] blockIds)
        {
            return await tempAssetBusiness.CommitAsync(fileName, blockIds);
        }

        public async Task DeleteAsync(string fileName)
        {
            await tempAssetBusiness.DeleteAsync(fileName);
        }

        public async Task<int> UploadAndCommitAsync(string fileName, FileStream file, int blocksize = 3000)
        {
            var blockIds = await UploadAsync(fileName, file, blocksize);
            return await CommitAsync(fileName, blockIds.ToArray());
        }

        public async Task<int> UploadAndCommitAsync(string fileName)
        {
            var tempAssetId = 0;
            using (var file = new FileStream(@"testAssets/testImage.jpg", FileMode.Open, FileAccess.Read))
            {
                tempAssetId = await UploadAndCommitAsync(fileName, file);
            }

            return tempAssetId;
        }
    }
}
