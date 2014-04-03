using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SearchModuleAPI.Common
{
    public class ConfigurationApplication
    {
        public static T GetValue<T>(String element, ConfSettings cs)
        {
            try
            {
                if (cs.Equals(ConfSettings.Key))
                {
                    return (T)Convert.ChangeType(System.Configuration.ConfigurationManager.AppSettings[element], typeof(T));
                }
                if (cs.Equals(ConfSettings.ConnectionString))
                {
                    return (T)Convert.ChangeType(System.Configuration.ConfigurationManager.ConnectionStrings[element].ConnectionString, typeof(T));
                }
            }
            catch 
            {
                if (typeof(T).Equals(typeof(Guid)))
                {
                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(System.Configuration.ConfigurationManager.AppSettings[element]);
                }
            }
            return default(T);
        }

    }
}