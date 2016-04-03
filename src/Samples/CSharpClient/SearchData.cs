using FlexSearch.Api.Api;
using FlexSearch.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClient
{
    public class SearchData
    {
        public void Search()
        {
            var searchApi = new SearchApi("http://localhost:9800");

            var queryString = "gt(population, '100000000') AND allOf(countryname, 'United')";
            var query = new SearchQuery("country", queryString)
            {
                Columns = new string[] { "*" }
            };

            var response = searchApi.Search("country", query);

            InterpretResponse(response);
        }

        private void InterpretResponse(SearchResponse response)
        {
            if (response.Error?.Message != null)
            {
                Console.WriteLine(response.Error.Message);
            }
            else
            {
                var records = response.Data.Documents;
                var countryNameOfFirstRecord = records[0].Fields["countryname"];
                var totalAvailableNumberOfRecords = response.Data.TotalAvailable;
            }
        }
    }
}
