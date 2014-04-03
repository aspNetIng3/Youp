using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.search.Interfaces
{
    interface IElasticIndexer
    {
        void Write(string jsonData, string elementId, string indexName, string indexType);
        void Delete(string elementId, string indexName = null, string indexType = null);
        void Update(string jsonData, string elementId, string indexName = null, string indexType = null);
    }
}
