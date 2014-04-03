using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youpe.search.Module;

namespace Youpe.search.Interfaces
{
    public interface ISearcherFacade
    {
        void Search(string jsonQuery, string indexName = "", string indexType = "");
        IList<ElasticSearchEntity> Results();
        string GetJsonResult();
    }
}
