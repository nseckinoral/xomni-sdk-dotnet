﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Private.ApiAccess.Passbook;

namespace XOMNI.SDK.Private.Passbook
{
    public class PassbookBarcodeTypeManagement : ManagementBase
    {
        private PassbookBarcodeType apiAccess = null;

        public PassbookBarcodeTypeManagement()
        {
            apiAccess = new PassbookBarcodeType();
        }

        public Task<IDictionary<int, string>> GetAllAsync()
        {
            return apiAccess.GetAllAsync(this.ApiCredential);
        }

        public XOMNIRequestMessage<IDictionary<int, string>> CreateGetAllRequest()
        {
            return apiAccess.CreateGetAllRequest(this.ApiCredential);
        }
    }
}
