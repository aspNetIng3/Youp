using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupService;

namespace ManageProductsAndCategories.Controllers
{
    public class BlogCommentsController : ElasticSearchController
    {
        public BlogCommentsController(ISearcherFacade searcherService) : base(searcherService) { }
    }
}
