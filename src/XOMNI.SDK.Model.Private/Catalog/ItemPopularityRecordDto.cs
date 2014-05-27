
namespace XOMNI.SDK.Model.Private.Catalog
{
    public class ItemPopularityRecordDto
    {
        public int? StoreId { get; set; }
        public string ActionType { get; set; }
        public double TotalTimeImpactValue { get; set; }
        public double TotalActionTypeImpactValue { get; set; }
        public double TotalValue { get; set; }
        public int TotalActionCount { get; set; }
    }
}
