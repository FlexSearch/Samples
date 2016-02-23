using FlexSearch.Api.Api;
using FlexSearch.Api.Model;
using System.Collections.Generic;
using System.Diagnostics;

namespace CSharpClient
{
    class IndexingDocuments
    {
        public IEnumerable<Document> GetSampleDocuments(int count, string indexName)
        {
            for (var i = 1; i < count + 1; i++)
            {
                var documentId = i.ToString();
                var d = new Document(documentId, indexName);

                // Assume the given index has 2 fields: 'name' and 'age'
                d.Fields.Add("name", "name-number-" + i);
                d.Fields.Add("age", (i + 20).ToString());

                yield return d;
            }
        }

        public void DoWork()
        {
            var documentsApi = new DocumentsApi("http://localhost:9800");

            foreach (var doc in GetSampleDocuments(10, "contact"))
            {
                var response = documentsApi.CreateDocument(doc, doc.Id);

                Debug.Assert(response.Error?.Message == null);
                var createdDocumentId = response.Data.Id; // Should be between 1 and 10
            }
        }
    }
}
