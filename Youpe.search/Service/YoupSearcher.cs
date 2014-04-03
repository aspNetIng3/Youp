using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youpe.search.Interfaces;
using Youpe.search.Module;

namespace Youpe.search.Service
{
    /// <summary>
    /// Pattern Facade to use the search module
    /// </summary>
    public class YoupSearcher : ISearcherFacade
    {
        //private static IElasticSearcher elasticSearcher;
        private IList<ElasticSearchEntity> searchResults;
        private string jsonResult = string.Empty;


        public static IElasticSearcher Facade
        {
            get
            {
                return new PlainElasticSearcher(); 
            }
        }


        /// <summary>
        /// Use this constructor if the client will be dealing with dynamic ElasticEntity.
        /// </summary>
        /// <param name="elasticSearcher"></param>
        //public YoupSearcher(IElasticSearcher elasticSearcher)
        //{
        //    elasticSearcher = new PlainElasticSearcher();
        //}

        /// <summary>
        /// Launch a reseach from a json string
        /// </summary>
        /// <param name="jsonQuery">element of research</param>
        /// <param name="indexName">name of the index to research</param>
        /// <param name="indexType">type of the index to research</param>
        /// <returns></returns>
        public void Search(string jsonQuery, string indexName = "", string indexType = "")
        {

            string json_query = QuerySearch.getJsonElasticQuery(jsonQuery);
            jsonResult = Facade.Search(json_query, indexName, indexType);
            searchResults = EntityMapper.ToElasticSearchEntity(jsonResult);
        }

        public IList<ElasticSearchEntity> mySearch(string jsonQuery, string indexName = "", string indexType = "")
        {

            return null;
        }


        /// <summary>
        /// Return all research results
        /// </summary>
        /// <returns>Collection of ElasticSearchEntity</returns>
        public IList<ElasticSearchEntity> Results()
        {
            return searchResults;
        }

        /// <summary>
        /// Return the json string of the query search result
        /// </summary>
        /// <returns>json string</returns>
        public string GetJsonResult()
        {
            return jsonResult;
        }
    }
}
