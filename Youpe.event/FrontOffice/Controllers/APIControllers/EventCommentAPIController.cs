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
    public class EventCommentAPIController : ApiController
    {
        


        // POST api/eventcommentapi
        /// <summary>
        /// Creates a comment
        /// </summary>
        /// <param name="eventComment"></param>
        /// <returns></returns>
        [HttpPost]
        public EventCommentPOCO PostEventComment([FromBody]EventCommentPOCO eventComment)
        {
            EventCommentDatabase eventCommentDb= new EventCommentDatabase();
            EventCommentService eventCommentService = new EventCommentService(eventCommentDb);

            return eventCommentService.CreateEventComment(eventComment);

        }

        // PUT api/eventcommentapi/5
        /// <summary>
        /// Updates a comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventComment"></param>
        /// <returns></returns>
        [HttpPut]
        public bool PutEventComment(int id, [FromBody]EventCommentPOCO eventComment)
        {
            EventCommentDatabase eventCommentDb = new EventCommentDatabase();
            EventCommentService eventCommentService = new EventCommentService(eventCommentDb);

            return eventCommentService.UpdateEventComment(eventComment);
        }

        // DELETE api/eventcommentapi/5
        /// <summary>
        /// Deletes a comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool DeleteEventComment(int id)
        {
            EventCommentDatabase eventCommentDb = new EventCommentDatabase();
            EventCommentService eventCommentService = new EventCommentService(eventCommentDb);

            return eventCommentService.DeleteEventComment(id);
        }
    }
}
