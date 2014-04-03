using System;
using System.Web;
using System.ComponentModel;

namespace YoupService
{
    public interface IElasticIndexer
    {
        void Write(string jsonData, string elementId, string indexName, string indexType);
    }
}
