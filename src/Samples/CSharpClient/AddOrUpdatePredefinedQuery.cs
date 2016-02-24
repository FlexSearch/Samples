using FlexSearch.Api.Api;
using FlexSearch.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClient
{
    public class AddOrUpdatePredefinedQuery
    {
        public void DoWork()
        {
            var indicesApi = new IndicesApi("http://localhost:9800");

            var updatedQuery =
                new SearchQuery("country", "allof(agriproducts, 'wheat', 'corn', 'grapes') AND like(countryname, @countryName)")
                {
                    QueryName = "agriSearch"
                };

            var response = indicesApi.UpdateIndexPredefinedQuery(updatedQuery, "country");

            // This method doesn't return any significant data. It just reports any errors.
            if (response.Error?.Message != null)
                Console.WriteLine(response.Error.Message);
        }
    }
}
