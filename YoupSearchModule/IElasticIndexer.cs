using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace YoupSearchModule
{
    public interface IElasticIndexer
    {
        void Write(string jsonData, string elementId, string indexName, string indexType);
        void Delete(string elementId, string indexName = null, string indexType = null);
        void Update(string jsonData, string elementId, string indexName = null, string indexType = null);
    }
}
