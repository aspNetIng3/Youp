using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace YoupFO.Models
{
    public class QuerySearch
    {
        public static string CleanQuery(string query)
        {
            StringBuilder sb = new StringBuilder (query)
            .Replace("\"", "").Replace("'","");
            return sb.ToString().ToLower().Trim();
        }

        public static string getJsonElasticQuery(string search_query){
            if (search_query != string.Empty)
            {
                search_query += "*";
            }
            return "{ " +
                        "\"query\": {" +
                            "\"query_string\":{ \"query\": \"" + CleanQuery(search_query) + "\"}" +
                        "}" +
                    "}";
        }
    }
}