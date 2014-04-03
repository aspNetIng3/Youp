using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Youpe.search.Models;
using Youpe.search.Service;

namespace Youpe.web.Controllers.api
{
    public class SearchController : MasterApiController
    {


        private bool as_criterias = false;
        private string query = "merci";


        public IEnumerable<object> Get(SearchModel _form)
        {

            //if (ModelState.IsValid)
            //{
            //    return GetAllResults(_form);
            //}

            return GetAllResults(_form);
            //return null;
        }

        private IEnumerable<object> GetAllResults(SearchModel _searchModel)
        {
            List<object> results = new List<object>();

            if (_searchModel != null)
            {
                results = GetSearchResultsWithCriterias(_searchModel);
                query = _searchModel.search;
                if (!as_criterias)
                {
                    results.AddRange(GetResults(_searchModel.search, "", ""));
                }
            }
            else
            {
                results.AddRange(GetResults(query, "", ""));
            }

            return results;
        }

        private List<object> GetSearchResultsWithCriterias(SearchModel _searchModel)
        {
            List<object> results = new List<object>();
            foreach (var prop in _searchModel.GetType().GetProperties())
            {
                if (prop.Name != "search" && prop.GetValue(_searchModel, null) != null)
                {
                    results.AddRange(GetResults(_searchModel.search, prop.Name));
                    as_criterias = true;
                }
            }

            return results;
        }


        private List<object> GetResults(string search, string indexName, string indexType = "")
        {
            YoupSearcher ys = new YoupSearcher();

            ys.Search(search, indexName, indexType);
            return ys.Results().Cast<object>().ToList();
        }



        public void CreateAllIndex()
        {

        }

    }
}