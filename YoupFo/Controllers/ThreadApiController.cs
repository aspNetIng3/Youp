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
    public class ThreadApiController : ApiController
    {
        IThreadService _cs;

        public ThreadApiController() 
        {
            _cs = new ThreadService();
        }
        public ThreadApiController(IThreadService threadService)
        {
            _cs = threadService;
        }

        public List<ThreadDTO> GetAll()
        {
            List<ThreadDTO> listThreadsDto = new List<ThreadDTO>();
            _cs.getThreads(1,10).ForEach(c => listThreadsDto.Add(c.Data));
            return listThreadsDto;
        }
        public HttpResponseMessage Post(ThreadDTO item)
        {
            ThreadPOCO current = new ThreadPOCO(item);
            current = _cs.Create(current);
            var response = Request.CreateResponse<ThreadDTO>(HttpStatusCode.Created, current.Data);
            string uri = Url.Link("DefaultApi", new { id = current.Data.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        public ThreadDTO Get(int id)
        {
            ThreadPOCO current = _cs.getThread(id);
            if (current.Data == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return current.Data;
        }

        public void Put(int id, ThreadDTO thread)
        {
            ThreadPOCO current = new ThreadPOCO(thread);
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
