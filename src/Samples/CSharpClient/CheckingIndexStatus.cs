using FlexSearch.Api.Api;
using FlexSearch.Api.Constants;
using System;

namespace CSharpClient
{
    public class CheckingIndexStatus
    {
        public void CheckIfExists()
        {
            var indicesApi = new IndicesApi("http://localhost:9800");

            var response = indicesApi.IndexExists("some-index-name");

            if (response.Error?.Message != null)
                Console.WriteLine(response.Error.Message);
            else
            {
                bool exists = response.Data.Exists;
            }
        }

        public void GetStatus()
        {
            var indicesApi = new IndicesApi("http://localhost:9800");

            var response = indicesApi.GetStatus("country");

            if (response.Error?.Message != null)
                Console.WriteLine(response.Error.Message);
            else
            {
                IndexStatus status = response.Data.IndexStatus;
            }
        }
    }
}
