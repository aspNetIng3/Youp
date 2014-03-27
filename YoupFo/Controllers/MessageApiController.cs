using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupRepository.Model;
using YoupService.Services;

namespace YoupFo.Controllers
{
    public class MessageApiController : ApiController
    {
        IMessageServices _cs;

        public MessageApiController() 
        {
            _cs = new MessageService();
        }
        public MessageApiController(IMessageServices MessageService)
        {
            _cs = MessageService;
        }

        public List<MessageDTO> GetAll()
        {
            List<MessageDTO> listMessagesDto = new List<MessageDTO>();
            _cs.getMessages(1,10).ForEach(c => listMessagesDto.Add(c.Data));
            return listMessagesDto;
        }
        public HttpResponseMessage Post(MessageDTO item)
        {
            MessagePOCO current = new MessagePOCO(item);
            current = _cs.Create(current);
            var response = Request.CreateResponse<MessageDTO>(HttpStatusCode.Created, current.Data);
            string uri = Url.Link("DefaultApi", new { id = current.Data.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        public MessageDTO Get(int id)
        {
            MessagePOCO current = _cs.getMessage(id);
            if (current.Data == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return current.Data;
        }

        public void Put(int id, MessageDTO Message)
        {
            MessagePOCO current = new MessagePOCO(Message);
            current.Data.Id = id;
            if (!_cs.Update(current))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void Delete(int id)
        {
            if (!_cs.Delete(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
