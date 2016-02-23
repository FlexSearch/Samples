using FlexSearch.Api.Api;
using FlexSearch.Api.Constants;
using FlexSearch.Api.Model;
using System.Diagnostics;

namespace CSharpClient
{
    public class CreatingIndex
    {
        public void Work()
        {
            var indicesApi = new IndicesApi("http://localhost:9800");

            var index = new Index("contact")
            {
                Fields = new Field[]
                {
                    new Field("name", FieldType.Text),
                    new Field("age", FieldType.Int)
                }
            };

            var response = indicesApi.CreateIndex(index);
            Debug.Assert(response.Error?.Message == null);
            var indexName = response.Data.Id; // should be "contact"
        }
    }
}
