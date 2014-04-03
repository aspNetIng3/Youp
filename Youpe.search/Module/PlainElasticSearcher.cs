using PlainElastic.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youpe.search.Connection;
using Youpe.search.Interfaces;

namespace Youpe.search.Module
{
    /// <summary>
    /// Class usefull to search objects on a cluster with a JSON query
    /// </summary>
    class PlainElasticSearcher : IElasticSearcher
    {
        //private ElasticConnection elasticSearchConnection;

        /// <summary>
        /// Initialize object to search indexes with a default connection to the cluster of Elastic Search (host= localhost, port=9200)
        /// </summary>
        public PlainElasticSearcher()
        {
            //elasticSearchConnection = new ElasticConnection("localhost", 9200);
        }

        /// <summary>
        /// Initialize object to search indexes with  connection to the cluster of Elastic Search
        /// </summary>
        /// <param name="host">Host of the cluster</param>
        /// <param name="port">Port to connect to the cluster</param>
        public PlainElasticSearcher(string host, int port)
        {
            //elasticSearchConnection = new ElasticConnection(host, port);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonQuery">JSONQuery which contain elements to catch in the searched object</param>
        /// <param name="indexName">Name of the index which contains the searched object</param>
        /// <param name="indexType">String Type of the searched object</param>
        /// <returns></returns>
        public string Search(string jsonQuery, string indexName, string indexType)
        {
            string command = new SearchCommand(indexName, indexType).WithParameter("search_type", "query_and_fetch");
            try
            {
                //return elasticSearchConnection.Post(command, jsonQuery);
                return SearchConnection.Client.Post(command, jsonQuery);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
