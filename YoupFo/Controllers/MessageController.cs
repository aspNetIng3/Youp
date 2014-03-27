using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupFo.Models;
using YoupRepository;
using YoupService.Services;

namespace YoupFo.Controllers
{
    public class MessageController : YoupController
    {
        private IMessageServices messageService = new MessageService();
        private IThreadService threadService = new ThreadService();
        public ActionResult Index(int id)
        {
            ViewBag.Thread = threadService.getThread(id);
            //ViewBag.Messages = messageService.getMessages(id, 50);
            return View();
        }
        [HttpPost]
        public ActionResult Create(MessageModels message)
        {
            //messageService.Create(new YoupRepository.Model.MessagePOCO(new YoupRepository.Model.MessageDTO(message.Title, message.Content, message.Thread, message.User)));
            return RedirectToAction("Index", new { id = message.Thread });
        }
        
    }
}
