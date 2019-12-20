using System.Collections.Generic;
using SmartDataPlacement.Common.Responses;

namespace SmartDataPlacement.Contracts
{
    public interface ISearchContract
    {        
        SearchResultResponse Search(int from, int size);        
        SearchResultResponse Search(int from, int size,string keyword);
        SearchResultResponse Search(int from, int size, string keyword, string market);
    }
}
