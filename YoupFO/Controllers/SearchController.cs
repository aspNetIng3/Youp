using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

using YoupService;
using YoupFO.Models;
using System.Dynamic;

namespace YoupFO.Controllers
{
    public class SearchController : Controller
    {
        private ISearcherFacade searcherFacade;
        private bool as_criterias = false;

        public SearchController(ISearcherFacade searcherService)
        {
            this.searcherFacade = searcherService;
        }

        // GET: /Search/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string search, string stats, string forums, string blogs, string events, string users)
        {
            return View("Index", GetAllResults(search, stats, forums, blogs, events, users));
        }

        private IList<object> GetAllResults(string search, string stats, string forums, string blogs, string events, string users)
        {
            List<dynamic> results = GetSearchResultsWithCriterias(search, stats, forums, blogs, events, users);
            if (!as_criterias)
            {
                results.AddRange(GetResults(search, "",""));
            }
            return results;
        }

        private List<object> GetSearchResultsWithCriterias(string search, string stats, string forums, string blogs, string events, string users)
        {
            List<dynamic> results = new List<dynamic>(); 
            foreach (object research in new List<object>() { stats, forums, blogs, events, users })
            {
                if (research != null)
                {
                    results.AddRange(GetResults(search, research.ToString(), ""));
                    as_criterias = true;
                }
            }
            return results;
        }

        private List<dynamic> GetResults(string search, string indexName, string indexType)
        {
            searcherFacade.Search(QuerySearch.getJsonElasticQuery(search), indexName, indexType);
            return searcherFacade.Results().Cast<dynamic>().ToList();
        }

	}
}