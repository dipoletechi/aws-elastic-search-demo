using System.Linq;
using System.Collections.Generic;

using SmartDataPlacement.Common.DataTransferObjects;
using SmartDataPlacement.Common.Enums;
using SmartDataPlacement.Common.Responses;

namespace SmartDataPlacement.Common.DataFactories
{
    public class ManagementDataFactory
    {
        public static List<SearchResultDto> ResponseToDto(List<ManagementData> managementSearchResponse)
        {
            return managementSearchResponse.Select(managementData => new SearchResultDto
            {
                SearchResultType = ESearchResultType.Management,
                Title = managementData.Mgmt.Name,
                MarketName = managementData.Mgmt.Market
            }).ToList();           
        }
    }
}
