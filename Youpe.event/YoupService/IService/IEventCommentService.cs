using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.POCO;

namespace YoupService
{
    interface IEventCommentService
    {
        EventCommentPOCO CreateEventComment(EventCommentPOCO eventComment);
        bool UpdateEventComment(EventCommentPOCO eventComment);
        bool DeleteEventComment(int id);
    }
}
