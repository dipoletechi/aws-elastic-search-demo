using SmartDataPlacement.Common.Enums;

namespace SmartDataPlacement.Common.DataTransferObjects
{
    public class SearchResultDto
    {
        public string Title { get; set; }
        public string StreetAddress { get; set; }
        public ESearchResultType SearchResultType { get; set; }
        public string MarketName { get; set; }
    }
}
