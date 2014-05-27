using System.Collections.Generic;

namespace XOMNI.SDK.Model.Private.Catalog
{
    public class TrendingItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public double TotalPoint { get; set; }

        public IEnumerable<ItemPopularityRecordDto> ItemPopularityRecords { get; set; }
    }
}
