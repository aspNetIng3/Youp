using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupRepository;

namespace StatsAPI.Controllers.v1
{
    public class HeatmapController : ApiController
    {
        // POST api/v1/heatmap
        public void Post()
        {
            int x = 5;
            int y = 9;


            System.Diagnostics.Debug.WriteLine(x.ToString() + " " + y.ToString() + " ");
        }
    }
}
