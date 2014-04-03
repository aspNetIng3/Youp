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
    public class MessagesController : MasterApiController
    {
        // GET api/<controller>
        public IEnumerable<object> Get()
        {
            var _lst = MessageRepository.Context.Messages.ToList();

            return _lst;
        }

        public object Get(string id)
        {
            var _entity = MessageRepository.findById<Message>(long.Parse(id));

            if (_entity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return _entity;
        }

        public HttpResponseMessage Post(MessageModel form)
        {
            // Mapper

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Message _entity = new Message();

            _entity = MessageRepository.Add<Message, MessageModel>(_entity, form, true);

            var response = Request.CreateResponse<Message>(HttpStatusCode.Created, _entity);
            string uri = Url.Link("DefaultApi", new { id = _entity.Id });
            response.Headers.Location = new Uri(uri);
            return response;

        }

        public HttpResponseMessage Put(string id, MessageModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Message _entity = MessageRepository.findById<Message>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _entity = MessageRepository.Upd(_entity, model, false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        public HttpResponseMessage Delete(string id)
        {
            Message _entity = MessageRepository.findById<Message>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                ThreadRepository.Del(_entity);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _entity);
        }


        public IEnumerable<object> getAllMessages(long threadId)
        {
            var _lst = MessageRepository.Context.Messages.Where(m=>m.ThreadId == threadId).ToList();

            return _lst;
        }


        private List<object> getPaginatedMessages(List<object> messages, int page, int nbResultsPerPage)
        {
            List<object> paginatedList = new List<object>();
            int lastAvailableIndex = messages.Count - 1;
            int firstIndex = (page - 1) * nbResultsPerPage;
            int lastIndex = page * nbResultsPerPage - 1;
            if (firstIndex > lastAvailableIndex || page <= 0 || nbResultsPerPage <= 0)
            {
                return paginatedList;
            }
            else
            {
                int lastValidIndex = lastIndex > lastAvailableIndex ? lastAvailableIndex : lastIndex;
                int count = lastValidIndex - firstIndex + 1;
                return messages.GetRange(firstIndex, count);
            }
        }

    }
}