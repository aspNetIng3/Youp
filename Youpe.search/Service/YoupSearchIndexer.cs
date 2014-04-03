using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youpe.search.Interfaces;
using Youpe.search.Module;

namespace Youpe.search.Service
{
    public class YoupSearchIndexer
    {
        private static IElasticIndexer _indexer = new PlainElasticIndexer();
        private static string IndexName = "";
        private static string IndexType = "";
        private static string IndexId = "";
        private static string IndexJsonData = "";

        private static void IndexerElementData<T>(T entity) where T : class
        {
            var _name = entity.GetType().Name.ToLower();
            var _name_type = _name;
            dynamic data = entity;

            if (_name.Substring(_name.Length - 1) != "s")
            {
                _name = String.Format("{0}s", _name);
            }

            IndexName = _name;
            IndexType = _name_type;
            IndexId = data.Id.ToString();
            IndexJsonData = JsonConvert.SerializeObject(entity);

        }

        // Indexer Object
        public static void Create<T>(T entity) where T : class
        {
            try
            {
                IndexerElementData(entity);
                _indexer.Write(IndexJsonData, IndexId, IndexName, IndexType);
            }
            catch
            {

            }
            

        }

        public static void Update<T>(T entity) where T : class
        {
            try
            {
                IndexerElementData(entity);
                _indexer.Update(IndexJsonData, IndexId, IndexName, IndexType);
            }
            catch
            {

            }
            
        }

        public static void Delete<T>(T entity) where T : class
        {
            try
            {
                IndexerElementData(entity);
                _indexer.Delete(IndexId, IndexName, IndexType);
            }
            catch
            {

            }
            
        }


        public static List<string> IndexAll()
        {
            return null;
        }


    }
}
