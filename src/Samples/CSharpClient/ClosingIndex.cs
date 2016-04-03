using FlexSearch.Api.Api;
using System;

namespace CSharpClient
{
    public class ClosingIndex
    {
        public void DoWork()
        {
            var indicesApi = new IndicesApi("http://localhost:9800");

            var response = indicesApi.UpdateIndexStatus("contact", "offline");

            // This method doesn't return any significant data. It just reports any errors.
            if (response.Error?.Message != null)
                Console.WriteLine(response.Error.Message);
        }
    }
}
