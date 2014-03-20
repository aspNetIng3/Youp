using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupRepository;

namespace StatsAPI.Controllers
{
    public class ForumController : ApiController
    {
        YoupEntities db = new YoupEntities();

        // GET api/v1/forum/GetCountMessagesByUser/{user_id}
        // Retourne le nombre de messages pour l'utilisateur choisi
        public HttpResponseMessage GetCountMessagesByUser(int userId)
        {
            User user = db.Users.Find(userId);

            if(User == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Utilisateur introuvable");
            }
            else
            {
                return Request.CreateResponse(user.Messages.Count().ToString());
            }
        }

        // GET api/v1/forum/GetTopUsers
        // Retourne le top utilisateurs
        public HttpResponseMessage GetTopUsers()
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

    }
}
