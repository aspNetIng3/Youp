using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchModuleAPI.Common
{
    public class ClassError
    {
        public static readonly ClassError ProductService = new ClassError("ProductService");
        public static readonly ClassError CategorieService = new ClassError("CategorieService");

        private ClassError(string value)
        {
            Value = value;
        }
        public string Value { get; private set; }
    }
}