using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupFO.Models;
using YoupService;

namespace ManageProductsAndCategories.Controllers
{
    public class ElasticSearchController : ApiController
    {
        protected readonly string INDEX_NAME = string.Empty;
        protected ISearcherFacade searcherFacade;
        private const string NAME_COMPLEMENT = "controller";

        protected ElasticSearchController(ISearcherFacade searcherService)
        {
            
            this.searcherFacade = searcherService;
            INDEX_NAME = this.GetType().Name.ToLower().Replace(NAME_COMPLEMENT,"");
         
        }
        
        public virtual string GetAll()
        {
            searcherFacade.Search(QuerySearch.getJsonElasticQuery("*"), INDEX_NAME, "");
            return searcherFacade.GetJsonResult();
        }

        public virtual string Get(int id = -1)
        {
            if (id == -1) return null;
            searcherFacade.Search(QuerySearch.getJsonElasticQuery(string.Format("_id:{0}", id)), INDEX_NAME, "");

            if (searcherFacade.GetJsonResult() == string.Empty)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return searcherFacade.GetJsonResult();
        }
    }
}
