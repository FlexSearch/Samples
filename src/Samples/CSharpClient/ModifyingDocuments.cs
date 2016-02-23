using FlexSearch.Api.Api;
using FlexSearch.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClient
{
    public class ModifyingDocuments
    {
        public void DoWork()
        {
            var documentsApi = new DocumentsApi("http://localhost:9800");

            SetupSampleDocument(documentsApi);

            var correctedDocument = new Document("7", "contact");
            // We need to supply *ALL* fields, even if we're not changing them
            correctedDocument.Fields.Add("name", "Vladimir");
            correctedDocument.Fields.Add("age", "26");

            var response = documentsApi.UpdateDocument(correctedDocument, "contact", "7");

            // This method doesn't return any significant data. It just reports any errors.
            if (response.Error?.Message != null)
                Console.WriteLine(response.Error.Message);
        }

        private void SetupSampleDocument(DocumentsApi documentsApi)
        {
            var doc = new Document("7", "contact");
            doc.Fields.Add("age", "26");
            doc.Fields.Add("name", "Vladimir");

            documentsApi.CreateDocument(doc, "contact");
        }
    }
}
