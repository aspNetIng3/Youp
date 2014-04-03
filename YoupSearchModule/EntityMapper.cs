using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;

namespace YoupSearchModule
{
    /// <summary>
    /// Map a JSON string to a ElasticSearchEntity
    /// </summary>
    public class EntityMapper : JavaScriptConverter
    {
        /// <summary>
        /// Convert a json string to a List Of ElasticSearchEntity
        /// </summary>
        /// <param name="json">JSON string which contains results of the query</param>
        /// <returns></returns>
        public static IList<ElasticSearchEntity> ToElasticSearchEntity(string json)
        {
            IList<ElasticSearchEntity> results = new List<ElasticSearchEntity>();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.RegisterConverters(new JavaScriptConverter[] { new EntityMapper() });

            JsonTextReader jsonReader = new JsonTextReader(new StringReader(json));
            if (json.Length > 0)
            {
                var jObj = JObject.Parse(json);
                foreach (var child in jObj["hits"]["hits"])
                {
                    var tmp = child["_source"].ToString();
                    dynamic dynamicDict = jss.Deserialize(tmp, typeof(object)) as dynamic;
                    dynamicDict.Add("type", child["_type"].ToString());
                    ElasticSearchEntity elasticSearchEntity = ElasticSearchEntity.CreateFrom(dynamicDict);
                    results.Add(elasticSearchEntity);
                }
            }
            return results;
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="type"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            return new Dictionary<string, object>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            return new Dictionary<string, object>();
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new List<Type>(); }
        }
    }
}
