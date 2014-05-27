using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Private.Catalog
{
    public class PriceManagement : BaseCRUDManagement<XOMNI.SDK.Model.Private.Catalog.Price> 
    {
        protected override Core.ApiAccess.CRUDApiAccessBase<Model.Private.Catalog.Price> ApiAccess
        {
            get { return new XOMNI.SDK.Private.ApiAccess.Catalog.Price(); }
        }

        public Task<List<XOMNI.SDK.Model.Private.Catalog.Price>> GetByItemIdAsync(int itemId)
        {
            return ((XOMNI.SDK.Private.ApiAccess.Catalog.Price)ApiAccess).GetByItemIdAsync(itemId, base.ApiCredential);
        }
    }
}
