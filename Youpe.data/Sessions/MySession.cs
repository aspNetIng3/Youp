using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Youpe.data.Sessions
{
    public class MySession
    {
        private string _currentIp;
        private long _currentUserId = 0;
        private long _currentBlogID = 0;
        private MySession() { }
        private static MySession _current;

        public static MySession Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new MySession();
                }

                return _current;
            }
        }

        

        public Int64 GetCurrentUserID 
        {
            get
            {
                if (_currentUserId == 0)
                {
                    return 1;
                }

                return _currentUserId;
            }

            set
            {
                _currentUserId = value;
            }
        }
        public string GetCurrentIP 
        {
            get
            {
                _currentIp = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(_currentIp))
                {
                    _currentIp = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                return _currentIp;
            }
        }
        public long GetCurrentBlogID
        {
            get
            {

                if (HttpContext.Current.Session["_currentBlogId_"] == null)
                {
                    this._currentBlogID = 1;
                    HttpContext.Current.Session["_currentBlogId_"] = this._currentBlogID;
                }
                else
                {
                    this._currentBlogID = (long)HttpContext.Current.Session["_currentBlogId_"];
                }


                return this._currentBlogID;
            }

            set
            {
                if (value == 0)
                {
                    this._currentBlogID = 1;
                }
                else
                {
                    this._currentBlogID = value;
                }

                HttpContext.Current.Session.Add("_currentBlogId_", this._currentBlogID);
                
            }
        }
    }
}
