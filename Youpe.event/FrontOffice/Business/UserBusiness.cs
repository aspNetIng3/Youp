using FrontOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoupRepository;

namespace FrontOffice.Business
{
    public class UserBusiness
    {
        public static User getDAL(UserFO ev)
        {
            User result = new User();

            return result;
        }

        public static UserFO getModel(User ev)
        {
            UserFO result = new UserFO();

            return result;
        }
    }
    
}