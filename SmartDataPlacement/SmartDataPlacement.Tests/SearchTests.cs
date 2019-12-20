using NUnit.Framework;
using SmartDataPlacement.Services;

namespace SmartDataPlacement.Tests
{   
    public class SearchTests:TestBase
    {
        
        [Test]
        public void Test_All_Search()
        {
            var propertyService = new SearchService();
            var data=propertyService.Search(0,28);

            Assert.IsNotNull(data);            
            Assert.IsTrue(data.Managements.Count>0);
            Assert.IsTrue(data.Properties.Count > 0);
        }

        [Test]
        public void Test_SearchByKeyword()
        {
            var keyword = "east";
            var searchService = new SearchService();                       
            var testData = searchService.Search(0, 2, keyword);

            Assert.IsNotNull(testData);
            Assert.IsTrue(testData.Managements.Count <= 2);

            foreach (var d in testData.Managements)
            {
                Assert.IsTrue(d.Mgmt.Name.ToLower().Contains(keyword));
            }

            Assert.IsTrue(testData.Properties.Count <= 2);

            foreach (var d in testData.Properties)
            {
                Assert.IsTrue(d.Property.Name.ToLower().Contains(keyword) ||
                    d.Property.StreetAddress.ToLower().Contains(keyword) ||
                    d.Property.FormerName.ToLower().Contains(keyword));
            }
        }

        [Test]
        public void Test_SearchByKeywordAndMarket()
        {            
            var keyword = "east";
            var market = "Atlanta";
            var size = 5;
            var searchService = new SearchService();
            var propertyTestData = searchService.Search(0, size, keyword, market);

            Assert.IsNotNull(propertyTestData);
            Assert.IsTrue(propertyTestData.Properties.Count <= size && propertyTestData.Properties.Count > 0);

            foreach (var d in propertyTestData.Properties)
            {
                Assert.IsTrue((d.Property.Name.ToLower().Contains(keyword) ||
                    d.Property.StreetAddress.ToLower().Contains(keyword) ||
                    d.Property.FormerName.ToLower().Contains(keyword))
                    && d.Property.Market == market);
            }


            keyword = "management";
            market = "San Francisco";            
            var managementTestData = searchService.Search(0, size, keyword, market);

            Assert.IsNotNull(managementTestData);
            Assert.IsTrue(managementTestData.Managements.Count <= size && managementTestData.Managements.Count > 0);

            foreach (var d in managementTestData.Managements)
            {
                Assert.IsTrue(d.Mgmt.Name.ToLower().Contains(keyword) && d.Mgmt.Market==market);
            }
        }
    }    
}
