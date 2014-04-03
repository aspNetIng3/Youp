using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupRepository.DAL;
using YoupRepository.Model.POCO;
using YoupService;

namespace FrontOffice.Controllers.APIControllers
{
    public class SubscriptionAPIController : ApiController
    {
        IEventService _iEvtService;
        EventDatabase eventBase;
        EventService eService;

        IUserService _iUsrService;
        UserDatabase userBase;
        UserService uService;

        public SubscriptionAPIController()
        {
            eventBase = new EventDatabase();
            eService = new EventService(eventBase);

            userBase = new UserDatabase();
            uService = new UserService(userBase);
        }

        [HttpGet]
        public string getInfo()
        {
            return "this is the subscription API controller";
        }


        //POST api/subscription
        /// <summary>
        /// Subscribes an user to an event
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="event_id"></param>
        [HttpPost]
        public void PostSubscription([FromBody] string user_id, string event_id)
        {
            UserPOCO upc= uService.getUser(user_id);
            EventPOCO evpc = eService.getEvent(event_id);

            evpc.data.Users.Add(upc.data);
            upc.data.Events1.Add(evpc.data);

            eService.updateEvent(evpc);
            uService.updateUser(upc);
        }

        //DELETE api/subscription
        /// <summary>
        /// Cancels a subscription
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="event_id"></param>
        [HttpDelete]
        public bool CancelASubscription(string user_id, string event_id)
        {

            UserPOCO userPoco = uService.getUser(user_id);
            EventPOCO eventPoco = eService.getEvent(event_id);

            eventPoco.data.Users.Remove(userPoco.data);
            userPoco.data.Events1.Remove(eventPoco.data);

            bool successs = false;
            successs = eService.updateEvent(eventPoco);
            successs = uService.updateUser(userPoco);

            return successs;

        }


    }
}
