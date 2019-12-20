using System.Linq;
using System.Collections.Generic;

using SmartDataPlacement.Common.DataTransferObjects;
using SmartDataPlacement.Common.Enums;
using SmartDataPlacement.Common.Responses;

namespace SmartDataPlacement.Common.DataFactories
{
    public class PropertyDataFactory
    {
        public static List<SearchResultDto> ResponseToDto(List<PropertyData> propertySearchResponse)
        {
            return propertySearchResponse.Select(propertyData => new SearchResultDto {
                SearchResultType = ESearchResultType.Property,
                StreetAddress = propertyData.Property.StreetAddress,
                Title = propertyData.Property.Name,
                MarketName = propertyData.Property.Market
            }).ToList();            
        }
    }
}
