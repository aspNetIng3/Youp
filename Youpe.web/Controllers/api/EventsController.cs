using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Youpe.data.Models;
using Youpe.data.POCO;
using Youpe.Models.Repo;

namespace Youpe.web.Controllers.api
{
    public class EventsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Event> Get()
        {
            var lstEvents = EventRepository.Context.Events.ToList();

            return lstEvents;
        }

        public Event Get(long id)
        {
            var _entity = EventRepository.findById<Event>(id);

            if (_entity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return _entity;
        }

        public HttpResponseMessage Post(EventModel model)
        {
            // Mapper

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Event _entity = new Event();

            _entity = EventRepository.Add<Event, EventModel>(_entity, model, true);

            var response = Request.CreateResponse<Event>(HttpStatusCode.Created, _entity);
            string uri = Url.Link("DefaultApi", new { id = _entity.Id });
            response.Headers.Location = new Uri(uri);
            return response;

        }

        public HttpResponseMessage Put(string id, EventModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Event _entity = EventRepository.findById<Event>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _entity = EventRepository.Upd(_entity, model, false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        public HttpResponseMessage Delete(string id)
        {
            Event _entity = EventRepository.findById<Event>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                EventRepository.Del(_entity);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _entity);
        }





    }
}