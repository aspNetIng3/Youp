using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupService;
using YoupRepository.Model.POCO;
using YoupRepository.Model.DTO;
using YoupRepository.DAL;

namespace FrontOffice.Controllers.APIControllers
{
    public class EventAPIController : ApiController
    {
        EventDatabase eventBase;
        EventService service;
        /*
         * This generate an internal server error (no default constructor for this controller)
        public EventAPIController(IEventService iEvtSvc)
        {
            _iEvtService = iEvtSvc;
        }
         */

        public EventAPIController()
        {
            eventBase = new EventDatabase();
            service = new EventService(eventBase);
        }

        // GET api/events
        /// <summary>
        /// Gets all events from database
        /// </summary>
        /// <returns><![CDATA[IEnumerable<Event>]]></returns>
        [HttpGet]
        public IEnumerable<EventPOCO> AllEvents()
        {
            //the default constructor not present, should pass an IEventService objet to my constructo and I don't know how to do this so I hack this here:
      
            List<EventPOCO> list = service.getEvents();
            if (list == null)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return list;
        }

        // GET api/event/5
        /// <summary>
        /// Gets the event which id is passed as parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public EventPOCO Event(string id)
        {
            EventPOCO evpc = service.getEvent(id);
            if (evpc == null)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return evpc;
        }

        // POST api/event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        [HttpPost]
        public EventPOCO createEvent([FromBody]EventDTO evt)
        {
            EventPOCO poco = new EventPOCO(evt);
            return service.createEvent(poco);
        }

        // DELETE api/event/5
        /// <summary>
        /// Deletes the event which id is passed as parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool RemoveEvent(string id)
        {
            return service.deleteEvent(id);
        }

        // PUT api/event
        /// <summary>
        /// Updates the event passed in PUT
        /// </summary>
        /// <param name="evpc"></param>
        /// <returns></returns>
        [HttpPut]
        public bool UpdateEvent([FromBody] EventPOCO evpc)
        {
            return service.updateEvent(evpc);
        }


    }
}
