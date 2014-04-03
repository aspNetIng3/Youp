using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchModuleAPI.Tracer
{
    public class PerfRecord
    {
        public Guid RequestId { get; set; }
        public double Msec { get; set; }
        public string Category { get; set; }
        public string Operation { get; set; }
    }
}