using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Passbook
{
    public class PassbookTemplateRequest
    {
        public int Id { get; set; }
        public string UniqueName { get; set; }
        public string Name { get; set; }
        public string LogoText { get; set; }
        public int BarcodeType { get; set; }
        public string FormatVersion { get; set; }
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
        public int IconImageAssetId { get; set; }
        public int IconRetinaImageAssetId { get; set; }
        public int LogoImageAssetId { get; set; }
        public int LogoRetinaImageAssetId { get; set; }
        public int StripImageAssetId { get; set; }
        public int StripRetinaImageAssetId { get; set; }
        public string Description { get; set; }
        public string PassbookBodyFormat { get; set; }
        public bool SupressStripShine { get; set; }
        public int? PassbookAssociatedStoreIdentifier { get; set; }
        public string BarcodeMessageFormat { get; set; }
        public string BackFieldLabel1 { get; set; }
        public string BackFieldLabel2 { get; set; }
        public string BackFieldLabel3 { get; set; }
        public string BackFieldPlaceholder1 { get; set; }
        public string BackFieldPlaceholder2 { get; set; }
        public string BackFieldPlaceholder3 { get; set; }
        public int PriceTypeId { get; set; }
    }
}
