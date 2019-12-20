using System.Linq;

using Nest;

using SmartDataPlacement.Repositories;
using SmartDataPlacement.Common.Responses;
using SmartDataPlacement.Common.Enums;

namespace SmartDataPlacement.Services
{
    public class SearchService : SearchRepository
    {
        public SearchResultResponse Search(int from, int size)
        {
            var searchResultResponse = ElasticSearchClientInstance.Instance.elasticClient.MultiSearch(null, ms => ms
                                     .Search<PropertyData>(EAppSettingsVariable.properties.ToString(), p => p.From(from).Size(size))
                                     .Search<ManagementData>(EAppSettingsVariable.managements.ToString(), mg => mg.From(from).Size(size)));

            return GetDataFromMultiSearchResponse(searchResultResponse);
        }

        public SearchResultResponse Search(int from, int size, string keyword)
        {
            var searchResultResponse = ElasticSearchClientInstance.Instance.elasticClient.MultiSearch(null, ms => ms
                                      .Search<PropertyData>(EAppSettingsVariable.properties.ToString(), p => p.From(from).Size(size)
                                             .Query(q => q.MultiMatch(mm => mm.Fields(f => f.Field(ff => ff.Property.Name)
                                             .Field(ff => ff.Property.StreetAddress).Field(ff => ff.Property.FormerName))
                                             .Type(TextQueryType.PhrasePrefix).Query(keyword))))
                                      .Search<ManagementData>(EAppSettingsVariable.managements.ToString(), mg => mg.From(from).Size(size)
                                             .Query(q => q.MatchPhrase(mp => mp.Field(f => f.Mgmt.Name).Query(keyword)))));

            return GetDataFromMultiSearchResponse(searchResultResponse);
        }

        public SearchResultResponse Search(int from, int size, string keyword, string market)
        {
            var searchResultResponse = ElasticSearchClientInstance.Instance.elasticClient.MultiSearch(null, ms=>ms
                                      .Search<PropertyData>(EAppSettingsVariable.properties.ToString(),p => p.From(from).Size(size)            
                                            .Query(q => q.Match(m => m.Field(f => f.Property.Market).Query(market)) && q.MultiMatch(mm => mm.Fields(f => f.Field(ff => ff.Property.Name)
                                            .Field(ff => ff.Property.StreetAddress).Field(ff => ff.Property.FormerName))
                                            .Type(TextQueryType.PhrasePrefix).Query(keyword))))
                                      .Search<ManagementData>(EAppSettingsVariable.managements.ToString(),mg=>mg.From(from).Size(size)
                                            .Query(q=>q.Match(m=>m.Field(f=>f.Mgmt.Market)
                                            .Query(market)) && q.MatchPhrase(mp=>mp.Field(f=>f.Mgmt.Name)
                                            .Query(keyword)))));
            
            return GetDataFromMultiSearchResponse(searchResultResponse);
        }

        private SearchResultResponse GetDataFromMultiSearchResponse(MultiSearchResponse multiSearchResponse)
        {
            return new SearchResultResponse
            {
                Managements = multiSearchResponse.GetResponse<ManagementData>(EAppSettingsVariable.managements.ToString()).Documents.ToList(),
                Properties = multiSearchResponse.GetResponse<PropertyData>(EAppSettingsVariable.properties.ToString()).Documents.ToList()
            };            
        }
    }
}
