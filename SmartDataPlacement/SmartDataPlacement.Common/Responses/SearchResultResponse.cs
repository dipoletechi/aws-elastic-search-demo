using System.Collections.Generic;

namespace SmartDataPlacement.Common.Responses
{
    public class SearchResultResponse
    {
        public List<PropertyData> Properties { get; set; }
        public List<ManagementData> Managements { get; set; }
    }
}
