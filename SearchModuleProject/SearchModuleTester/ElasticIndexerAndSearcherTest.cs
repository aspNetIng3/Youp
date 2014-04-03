using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoupRepository;
using YoupSearchModule;
using Newtonsoft.Json;

namespace SearchModuleTester
{
    internal class Index
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public object Var { get; set; }
    }

    [TestClass]
    public class ElasticIndexerAndSearcherTest
    {
        private List<Index> indexes = new List<Index>();

        public ElasticIndexerAndSearcherTest()
        {
            Users u = new Users()
            {
                Address = "...",
                Birthday = DateTime.MinValue,
                CreatedAt = DateTime.Now,
                Gender = "Man",
                Id = "1",
                UserName = "Jean-Du-Moul-1",
                Email = "jean-du-moulin@parla.com",
                UpdatedAt = DateTime.Now
            };
            indexes.Add(new Index { Name = "users", Type = "user", Id = u.Id, Var = u });

            Themes t = new Themes()
            {
                Name = "sALES-Event",
                Description = "Concern a sale of anything anywhere in the world",
                ThemeId = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            indexes.Add(new Index { Name = "themes", Type = "theme", Id = "1", Var = t });

            Events e = new Events()
            {
                Address = "3 Rue du Moulin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Description = "Vente de Tapis",
                Lattitude = 3353,
                Longitude = 1957,
                Public = 1,
                Id = "1",
                ThemeId = 1,
                Name = "Sales Event at Rue du Moulin",
                Slots = 2,
                UserId = "1"
            };
            indexes.Add(new Index { Name = "events", Type = "event", Id = e.Id, Var = e });
        }

        [TestMethod]
        public void WriteIndexesTest()
        {
            PlainElasticIndexer elasticIndexer = new PlainElasticIndexer();
            
            try
            {
                foreach (Index ob in indexes)
                {
                    elasticIndexer.Write(JsonConvert.SerializeObject(ob.Var), ob.Id, ob.Name, ob.Type);
                    Assert.IsTrue(true);
                }
                
            }
            catch(Exception ex)
            {
                Assert.IsTrue(false, ex.Message);
            }
            SearchIndexTest();
        }

        public void SearchIndexTest()
        {
            PlainElasticSearcher searcher = new PlainElasticSearcher();
            foreach (Index ob in indexes)
            {
                try
                {
                    string result = searcher.Search("", ob.Name, ob.Type);
                    Assert.IsFalse(result.Equals(string.Empty));
                }
                catch (Exception e)
                {
                    Assert.IsTrue(false, e.Message);
                }
                try
                {
                    searcher.Search("", "IndexName-which-doesn't-exists", "Event");
                    Assert.IsTrue(false, "When index doesn't exists, method must throw an error");
                }
                catch
                {
                    Assert.IsTrue(true);
                }
                try
                {
                    searcher.Search("","Events", "Type-which-doesn't-exists");
                    Assert.IsTrue(false, "When Type doesn't exists, method must throw an error");
                }
                catch
                {
                    Assert.IsTrue(true);
                }
            }

        }
    }
}
