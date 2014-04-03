using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youpe.data.Models;
using Youpe.web.Controllers.api;

namespace Youpe.web.Controllers.ctrl
{
    public class MessageController : MasterController
    {
        //private IMessageServices messageService = new MessageService();
        //private IThreadService threadService = new ThreadService();
        private ThreadsController _thrApi = new ThreadsController();

        public ActionResult Index(int id)
        {
            ViewBag.Thread = _thrApi.Get(id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(MessageModel message)
        {
            //messageService.Create(new YoupRepository.Model.MessagePOCO(new YoupRepository.Model.MessageDTO(message.Title, message.Content, message.Thread, message.User)));
            return RedirectToAction("Index", new { id = message.Id });
        }
        
    }
}
