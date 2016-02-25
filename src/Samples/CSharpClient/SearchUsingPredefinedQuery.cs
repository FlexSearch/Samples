using FlexSearch.Api.Api;
using FlexSearch.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClient
{
    public class SearchUsingPredefinedQuery
    {
        public void SearchWithoutVariables()
        {
            var searchApi = new SearchApi("http://localhost:9800");

            var query = new SearchQuery()
            {
                IndexName = "country",
                QueryName = "agrisearch"
            };

            var response = searchApi.PostSearch(query, "country");

            InterpretResponse(response);
        }

        public void SearchWithVariables()
        {
            var searchApi = new SearchApi("http://localhost:9800");

            var query = new SearchQuery()
            {
                IndexName = "country",
                QueryName = "agrisearch"
            };

            query.Variables.Add("countryname", "romania");

            var response = searchApi.PostSearch(query, "country");

            InterpretResponse(response);
        }

        private void InterpretResponse(SearchResultsResponse response)
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
