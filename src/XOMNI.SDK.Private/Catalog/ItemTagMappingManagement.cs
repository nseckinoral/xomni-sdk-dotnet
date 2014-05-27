﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Model;
using XOMNI.SDK.Private.ApiAccess.Catalog;

namespace XOMNI.SDK.Private.Catalog
{
    public class ItemTagMappingManagement : ManagementBase
    {
        ItemTagMapping apiAccess = new ItemTagMapping();

        public Task<XOMNI.SDK.Model.Catalog.ItemTagMapping> AddAsync(int itemId, int tagId)
        {
            return apiAccess.AddAsync(new XOMNI.SDK.Model.Catalog.ItemTagMapping { ItemId = itemId, TagId = tagId  }, base.ApiCredential);
        }

        public Task DeleteAsync(int itemId, int tagId)
        {
            return apiAccess.DeleteAsync(itemId, tagId, base.ApiCredential);
        }

        public Task<List<XOMNI.SDK.Model.Catalog.ItemTagMapping>> GetByItemIdAsync(int itemId)
        {
            return apiAccess.GetByItemIdAsync(itemId, base.ApiCredential);
        }

        public Task<List<XOMNI.SDK.Model.Catalog.ItemTagMapping>> GetByTagIdAsync(int tagId)
        {
            return apiAccess.GetByTagIdAsync(tagId, base.ApiCredential);
        }

        public Task<CountedCollectionContainer<XOMNI.SDK.Model.Catalog.ItemTagMapping>> GetAll(int skip, int take)
        {
            return apiAccess.GetAll(skip, take, base.ApiCredential);
        }
    }
}
