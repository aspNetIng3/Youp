using SearchModuleAPI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchModuleAPI.Common
{
    public class ExceptionRoot : Exception
    {
        private DomainCodeError _dce;
        public DomainCodeError DomainNameCode
        {
            get { return _dce; }
            set { _dce = value; }
        }

        private String _cName;
        public String CName
        {
            get { return _cName; }
            set { _cName = value; }
        }

        public ExceptionRoot() { }
        public ExceptionRoot(string message) : base(message) { }
        public ExceptionRoot(string message, Exception inner) :
            base(message, inner) { }
        public ExceptionRoot(string message, Exception inner, DomainCodeError dce, string cName)
            : base(message, inner)
        {
            _dce = dce;
            _cName = cName;
        }
    }
}