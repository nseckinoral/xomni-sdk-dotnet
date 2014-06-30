using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Exception;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Tests.Private.Catalog
{
    [TestClass]
    public abstract class BaseCRUDManagementFixture<T> : SDKFixtureBase
    {
        public abstract BaseCRUDSkipTakeManagement<T> CrudManagement { get; }

        public virtual bool CheckConflictedEntity { get { return true; } }
        public abstract T GetBadEntityModel();
        public abstract int GetNotFoundEntityId();
        public abstract T GetValidEntityModel();
        public abstract int GetInUseEntityId();
        public abstract void CheckNewAddedEntity(T newEntityModel, T oldEntityModel);
        public abstract int GetMeYourNewFuckingEntityIdIWillDelete();
        public virtual T GetEntityForUpdate()
        {
            return default(T);
        }
        public virtual void CheckUpdatedEntity(T newEntityModel, T oldEntityModel)
        {

        }



        public virtual async Task CRUDTest()
        {
            var badEntity = GetBadEntityModel();

            if (badEntity != null)
            {
                try
                {
                    await CrudManagement.AddAsync(badEntity);
                    Assert.Fail("Bad Request exception should has been thrown.");
                }
                catch (BadRequestException)
                {
                    //OK!
                }
            }

            var totalEntityCount = await GetTotalEntityCount();

            var validEntity = GetValidEntityModel();
            var retrievedEntity = await CrudManagement.AddAsync(validEntity);
            
            CheckNewAddedEntity(retrievedEntity, validEntity);

            var entityToUpdate = GetEntityForUpdate();
            if (entityToUpdate != null)
            {
                var updatedEntity = await CrudManagement.UpdateAsync(entityToUpdate);
                CheckUpdatedEntity(updatedEntity, entityToUpdate);             
            }

            if (CheckConflictedEntity)
            {
                try
                {
                    await CrudManagement.AddAsync(retrievedEntity);
                    Assert.Fail("Conflict exception should has been thrown.");
                }
                catch (ConflictException)
                {
                    // OK! (Existed)
                } 
            }

            var totalEntityCount1 = await GetTotalEntityCount();
            Assert.AreEqual(totalEntityCount + 1, totalEntityCount1, "Total entity count does not match.");

            var notFoundEntityId = GetNotFoundEntityId();
            try
            {
                await CrudManagement.GetByIdAsync(notFoundEntityId);
                Assert.Fail("Not found exception should has been thrown.");
            }
            catch (NotFoundException)
            {
                //OK!
            }

            try
            {
                await CrudManagement.DeleteAsync(notFoundEntityId);
                Assert.Fail("Not found exception should has been thrown.");
            }
            catch (NotFoundException)
            {
                //OK!
            }

            await CrudManagement.DeleteAsync(GetMeYourNewFuckingEntityIdIWillDelete());

            try
            {
                var inUseEntityId = GetInUseEntityId();
                if (inUseEntityId > 0)
                {
                    await CrudManagement.DeleteAsync(inUseEntityId);
                    Assert.Fail("Bad Request exception should has been thrown.");
                }
            }
            catch (BadRequestException)
            {
                //OK! (Is in use)
            }
        }

        private async Task<int> GetTotalEntityCount()
        {
            int returnCount;
            try
            {
                var allEntities = await CrudManagement.GetAllAsync(0, 1);
                returnCount = allEntities.TotalCount;
            }
            catch (NotFoundException)
            {
                returnCount = 0;
            }
            return returnCount;
        }
    }
}
