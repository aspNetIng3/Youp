using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace YoupSearchModule
{
    public interface IElasticSearcher
    {
        string Search(string jsonQuery, string indexName, string indexType);
    }
}
