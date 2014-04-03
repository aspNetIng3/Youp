using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using YoupSearchModule;
using System.IO;

namespace YoupService
{
    /// <summary>
    /// Pattern Facade to use the search module
    /// </summary>
    public class SearchFacade : ISearcherFacade
    {
        private IElasticSearcher elasticSearcher;
        private IList<ElasticSearchEntity> searchResults;
        private string jsonResult = string.Empty;

        /// <summary>
        /// Use this constructor if the client will be dealing with dynamic ElasticEntity.
        /// </summary>
        /// <param name="elasticSearcher"></param>
        public SearchFacade(IElasticSearcher elasticSearcher)
        {
            this.elasticSearcher = elasticSearcher;
        }

        /// <summary>
        /// Launch a reseach from a json string
        /// </summary>
        /// <param name="jsonQuery">element of research</param>
        /// <param name="indexName">name of the index to research</param>
        /// <param name="indexType">type of the index to research</param>
        /// <returns></returns>
        public void Search(string jsonQuery, string indexName = "", string indexType = "")
        {
            jsonResult = elasticSearcher.Search(jsonQuery, indexName, indexType);
            searchResults = EntityMapper.ToElasticSearchEntity(jsonResult);
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
