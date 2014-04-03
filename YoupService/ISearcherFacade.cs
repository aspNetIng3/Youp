using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupSearchModule;

namespace YoupService
{
    public interface ISearcherFacade
    {
        void Search(string jsonQuery, string indexName = "", string indexType = "");
        IList<ElasticSearchEntity> Results();
        string GetJsonResult();
    }
}
