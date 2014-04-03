using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoupRepository;
using YoupSearchModule;
using YoupService;

namespace YoupFO.Models
{
    public class IndexCreator
    {
        public static List<string> LaunchIndexCreation()
        {
            var sle = new YoupEntities();
            List<object> tables = new List<object>()
            {
                sle.BlogComments,
                sle.Blogs,
                sle.Cards,
                sle.EventComments,
                sle.Events,
                sle.Favorites,
                sle.Messages,
                sle.Photos,
                sle.Posts,
                sle.Ranks,
                sle.Ratings,
                sle.Roles,
                sle.Themes,
                sle.Threads,
                sle.Users
            };
            PlainElasticIndexer index = new PlainElasticIndexer();
            return index.CreateAllIndexFromDbSet(tables);
        }
    }
}