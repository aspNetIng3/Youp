using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoupSearchModule;

namespace SearchModuleTester
{
    [TestClass]
    public class ElasticSearchEntityFacadeTest
    {
        private ElasticSearchEntity _elasticSearch;

        public ElasticSearchEntityFacadeTest()
        {
            var members = new Dictionary<string, object>();
            _elasticSearch = ElasticSearchEntity.CreateFrom(members);
        }

        [TestMethod]
        public void ElasticSearchEntityInitializationTests()
        {
            Assert.IsTrue(_elasticSearch.GetType() == typeof(ElasticSearchEntity));
            Assert.IsTrue(_elasticSearch.GetDictionary().Count == 0);
        }

        [TestMethod]
        public void SetPropertyAndValue()
        {
            Assert.IsTrue(_elasticSearch.GetValue("").Equals(string.Empty));
            _elasticSearch.SetPropertyAndValue("property_test", new object());
            Assert.IsTrue(_elasticSearch.GetDictionary().ContainsKey("property_test"));
            _elasticSearch.SetPropertyAndValue("property_test", new object());
            Assert.IsTrue(_elasticSearch.GetDictionary().Count == 1);
            _elasticSearch.SetPropertyAndValue("Event", new object());
            Assert.IsTrue(_elasticSearch.GetDictionary().Count == 2);
        }

        [TestMethod]
        public void TryGetMemberTests()
        {

        }

        delegate void Delegate();

        [TestMethod]
        public void TryInvokeMemberTests()
        {
            var obj = new object();
            Assert.IsFalse(_elasticSearch.TryInvokeMember(new Binder("", true, new CallInfo(0, new string[0])), new object[0], out obj));
            _elasticSearch.SetPropertyAndValue("SearchModuleTester.Event", new YoupRepository.Event());
            //Assert.IsTrue(_elasticSearch.TryInvokeMember(new Binder("SearchModuleTester.Event", true, new CallInfo(0, new string[0])), new object[0], out obj));
        }
    }
}
