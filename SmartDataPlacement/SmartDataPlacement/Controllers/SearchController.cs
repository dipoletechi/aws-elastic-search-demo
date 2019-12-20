using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SmartDataPlacement.Common.DataFactories;
using SmartDataPlacement.Common.DataTransferObjects;
using SmartDataPlacement.Common.Responses;
using SmartDataPlacement.Contracts;

namespace SmartDataPlacement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _log;        
        private readonly ISearchContract _searchRepository;        

        public SearchController(ISearchContract searchRepository,                                 
                                ILogger<SearchController> log)
        {            
            _searchRepository = searchRepository;           
            _log = log;            
        }

        [HttpGet]
        public object Get()
        {
            return "Welcome to SmartDataApartment Search API";
        }

        [Authorize]
        [HttpGet("{keyword}/{market}/{from}/{size}")]
        public object Get(string keyword,string market,int from,int size)
        {            
            try
            {
                var searchResultResponse = new SearchResultResponse();
                var searchResult = new List<SearchResultDto>();
                
                //if neither market selected and nor keyword given than get all data
                if (string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(market))
                {
                    searchResultResponse = _searchRepository.Search(from, size);                    
                }

                //market not selected and trying to search in all data
                if (!string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(market))
                {
                    searchResultResponse = _searchRepository.Search(from, size, keyword);                    
                }

                //search in selected market
                if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(market))
                {
                    searchResultResponse = _searchRepository.Search(from, size, keyword, market);                    
                }
             
                searchResult.AddRange(PropertyDataFactory.ResponseToDto(searchResultResponse.Properties));
                searchResult.AddRange(ManagementDataFactory.ResponseToDto(searchResultResponse.Managements));

                return searchResult;
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message,ex);
                 return ex;
            }            
        }
        
    }
}
