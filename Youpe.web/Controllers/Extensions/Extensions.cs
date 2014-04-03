using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using AutoMapper;

namespace Youpe.web.Controllers
{
    public static class Extensions
    {
        public static bool Like(this string s, string pattern)
        {
            pattern = ".*" + pattern + ".*";

            return Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase);
        }
    }
}