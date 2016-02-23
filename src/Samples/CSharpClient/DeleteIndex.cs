using FlexSearch.Api.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClient
{
    public class DeleteIndex
    {
        public void DoWork()
        {
            var indicesApi = new IndicesApi("http://localhost:9800");

            var response = indicesApi.DeleteIndex("contact");

            // This method doesn't return any significant data. It just reports any errors.
            if (response.Error?.Message != null)
                Console.WriteLine(response.Error.Message);
        }
    }
}
