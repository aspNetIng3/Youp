using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.search.Interfaces
{
    public interface IElasticSearcher
    {
        string Search(string jsonQuery, string indexName, string indexType);
    }
}
