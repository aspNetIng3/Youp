using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Youpe.data.POCO;
using Youpe.Models.Repo;
using Youpe.search.Models;
using Youpe.search.Service;


namespace Youpe.web.Controllers.ctrl
{
    public class SearchController : MasterController
    {
        //private ISearcherFacade searcherFacade;
        private bool as_criterias = false;


        // GET: /Search/
        public ActionResult Index()
        {
            Blog bl = new Blog();
            bl.Name = "Blog 2";
            //BlogRepository.Add(bl, false);
            


            //Message msg = new Message();
            //msg.Title = "Message 3";
            //msg.Content = "Message 2";
            //YoupFORepository.Add(msg, false);
            //YoupFORepository.SaveChanges();

            //Theme th = new Theme();
            //th.Name= "Mon premier Theme";
            //th.Description = "La description de mon theme est a suivante";
            //YoupFORepository.Add(th);
            //YoupFORepository.SaveChanges();


            return View();
        }

        public ActionResult Search(SearchModel _form)
        {
            IList<object> lstObj = new List<object>();
            if (ModelState.IsValid)
            {
                lstObj = GetAllResults(_form);
                return View("Index", lstObj);
            }

            return View();
        }

        private IList<object> GetAllResults(SearchModel _searchModel)
        {
            List<dynamic> results = GetSearchResultsWithCriterias(_searchModel);
            if (!as_criterias)
            {
                results.AddRange(GetResults(_searchModel.search, "", ""));
            }
            return results;
        }

        private List<object> GetSearchResultsWithCriterias(SearchModel _searchModel)
        {
            List<dynamic> results = new List<dynamic>();
            foreach (var prop in _searchModel.GetType().GetProperties())
            {
                if (prop.Name != "search" && prop.GetValue(_searchModel,null) != null)
                {
                    results.AddRange(GetResults(_searchModel.search, prop.Name));
                    as_criterias = true;
                }
            }

            return results;
        }


        private List<dynamic> GetResults(string search, string indexName, string indexType = "")
        {
            YoupSearcher ys = new YoupSearcher();

            ys.Search(search,indexName, indexType);
            return ys.Results().Cast<dynamic>().ToList();
        }



        public ActionResult CreateAllIndex()
        {
            return RedirectToAction("Index");
        }




        //public ActionResult Search(string search, string stats, string forums, string blogs, string events, string users)
        //{
        //    return View("Index", GetAllResults(search, stats, forums, blogs, events, users));
        //}

        //private IList<object> GetAllResults(string search, string stats, string forums, string blogs, string events, string users)
        //{
        //    List<dynamic> results = GetSearchResultsWithCriterias(search, stats, forums, blogs, events, users);
        //    if (!as_criterias)
        //    {
        //        results.AddRange(GetResults(search, "",""));
        //    }
        //    return results;
        //}

        //private List<object> GetSearchResultsWithCriterias(string search, string stats, string forums, string blogs, string events, string users)
        //{
        //    List<dynamic> results = new List<dynamic>(); 
        //    foreach (object research in new List<object>() { stats, forums, blogs, events, users })
        //    {
        //        if (research != null)
        //        {
        //            results.AddRange(GetResults(search, research.ToString(), ""));
        //            as_criterias = true;
        //        }
        //    }
        //    return results;
        //}

        //private List<dynamic> GetResults(string search, string indexName, string indexType = "")
        //{
        //    searcherFacade.Search(QuerySearch.getJsonElasticQuery(search), indexName, indexType);
        //    return searcherFacade.Results().Cast<dynamic>().ToList();
        //}

	}
}