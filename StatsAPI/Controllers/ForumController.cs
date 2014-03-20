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

        // GET api/v1/forum/GetCountThreadsByTheme/{id}
        // Retourne le nombre de threads dans la categorie
        public HttpResponseMessage GetCountThreadsByTheme(int id)
        {
            Theme theme = db.Themes.Find(id);

            if (theme == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Categorie introuvable");
            }
            else
            {
                return Request.CreateResponse(theme.Threads.Count().ToString());
            }
        }

        // GET api/v1/forum/GetCountMessagesByThread/{id}
        // Retourne le nombre de messages dans le thread
        public HttpResponseMessage GetCountMessagesByThread(int id)
        {
            Thread thread = db.Threads.Find(id);

            if (thread == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Thread introuvable");
            }
            else
            {
                return Request.CreateResponse(thread.Messages.Count().ToString());
            }
        }

        // GET api/v1/forum/GetCountMessagesByUser/{userId}
        // Retourne le nombre de messages pour l'utilisateur choisi
        public HttpResponseMessage GetCountMessagesByUser(int userId)
        {
            User user = db.Users.Find(userId);

            if(user == null)
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
