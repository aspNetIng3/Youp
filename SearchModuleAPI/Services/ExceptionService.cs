using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchModuleAPI.Common;
using SearchModuleAPI.Enum;

namespace SearchModuleAPI.Service
{
    public class ExceptionService : ExceptionRoot
    {
        public ExceptionService()
            : base() { }
        public ExceptionService(string message)
            : base(message) { }
        public ExceptionService(string message, Exception inner)
            : base(message, inner) { }
        public ExceptionService(string message, Exception inner, DomainCodeError dce, string cName)
            : base(message, inner, dce, cName) { }
    }
}