using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchModuleAPI.Enum
{
    public enum DomainCodeError
    {
        NOFOUND = -1,
        SQL = 40000,
        NOKIA = 50000,
        CARBEO = 60000,
        SERVICES = 70000,
        AUTHENTIFICATION = 80000
    }
}