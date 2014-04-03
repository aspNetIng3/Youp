using PlainElastic.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.search.Connection
{
    class SearchConnection
    {
        //private string _Default_Index_Name = "";
        //private string _Default_Index_Type = "";
        private static ElasticConnection _connection = null;

        public static ElasticConnection Client
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new ElasticConnection("localhost", 9200);
                }

                return _connection;
            }
        }
    }
}
