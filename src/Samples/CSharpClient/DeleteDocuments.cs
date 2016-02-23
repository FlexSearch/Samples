using FlexSearch.Api.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClient
{
    public class DeleteDocuments
    {
        public void DoWork()
        {
            var documentsApi = new DocumentsApi("http://localhost:9800");

            var response = documentsApi.DeleteDocument("contact", "7");

            // This method doesn't return any significant data. It just reports any errors.
            if (response.Error?.Message != null)
                Console.WriteLine(response.Error.Message);
        }
    }
}
