using SearchModuleAPI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace SearchModuleAPI.Common
{
    public class ExceptionDatabase : ExceptionRoot, IErrorHandler
    {
        public ExceptionDatabase()
            : base(){}
        public ExceptionDatabase(string message)
            : base(message){}
        public ExceptionDatabase(string message, Exception inner)
            : base(message,inner){}
        public ExceptionDatabase(string message, Exception inner, DomainCodeError dce, string cName)
            : base(message, inner, dce, cName) {}

        public bool HandleError(Exception error)
        {
            return true;
        }

        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
          
        }
    }
}