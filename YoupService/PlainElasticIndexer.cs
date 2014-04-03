using System;
using System.Web;
using System.ComponentModel;
using PlainElastic.Net;
using YoupSearchModule;
using YoupRepository;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace YoupService
{
    /// <summary>
    /// Class usefull to create index on a cluster which contains JSON elements
    /// </summary>
    public class PlainElasticIndexer : IElasticIndexer
    {
        private ElasticConnection elasticConnection;

        /// <summary>
        /// Initialize a local connection on the default port 9200 by default
        /// </summary>
        public PlainElasticIndexer()
        {
            elasticConnection = new ElasticConnection("localhost", 9200);
        }

        /// <summary>
        /// Initialize a connection on the host and the port specified in the method
        /// </summary>
        /// <param name="host">Web Host default locahost</param>
        /// <param name="port">Port Web default 8000</param>
        public PlainElasticIndexer(string host, int port)
        {
            elasticConnection = new ElasticConnection(host, port);
        }

        /// <summary>
        /// Add a new index for elastic search
        /// </summary>
        /// <param name="jsonData">Contain data to store</param>
        /// <param name="elementId">Uniq id of jsonData</param>
        /// <param name="indexName">Name of the index which contains the searched object</param>
        /// <param name="indexType">String Type of the searched object<</param>
        public void Write(string jsonData, string elementId, string indexName, string indexType)
        {
            string command = Commands.Index(indexName, indexType, elementId);
            elasticConnection.Put(command, jsonData);
        }

        /// <summary>
        /// Delete an index
        /// </summary>
        /// <param name="jsonData">Contain data to store</param>
        /// <param name="elementId">Uniq id of jsonData</param>
        /// <param name="indexName">Name of the index which contains the searched object</param>
        /// <param name="indexType">String Type of the searched object<</param>
        public void Delete(string elementId, string indexName = null, string indexType = null)
        {
            string command = Commands.Delete(indexName, indexType, elementId);
            elasticConnection.Delete(command);
        }

        /// <summary>
        /// Delete the existing index et reinsert it with the new value
        /// </summary>
        /// <param name="jsonData">Contain data to store</param>
        /// <param name="elementId">Uniq id of jsonData</param>
        /// <param name="indexName">Name of the index which contains the searched object</param>
        /// <param name="indexType">String Type of the searched object<</param>
        public void Update(string jsonData, string elementId, string indexName = null, string indexType = null)
        {
            if (Commands.IndexExists(indexName).Index != null)
            {
                Delete(elementId, indexName, indexType);
                Write(jsonData, elementId, indexName, indexType);
            }
        }

        /// <summary>
        /// Create all index from database
        /// </summary>
        /// <param name="tables">Collection of Object, the object must have a table type and a id key</param>
        public List<string> CreateAllIndexFromDbSet(List<object> tables)
        {
            List<string> results = new List<string>();
            foreach (dynamic table in tables)
            {
                foreach (dynamic data in table.ToList())
                {
                    string name = table.GetType().Name.ToLower();
                    if (data["id"] != null)
                    {
                        Write(JsonConvert.SerializeObject(data), data["id"], String.Format("{0}s", name), name);
                        results.Add(string.Format("The object {0} has successfully been referenced", name));
                    }
                    else
                    {
                        results.Add(string.Format("The object {0} hasn't been referenced"));
                    }
                }
            }
            return results;
        }
    }
}
