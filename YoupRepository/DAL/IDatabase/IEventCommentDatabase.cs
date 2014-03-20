using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IEventCommentDatabase
    {
        List<EventComment> getEventComments();

        EventComment Create(EventComment tpc);

        bool Delete(int id);

        bool Update(EventComment tpc);

        EventComment getEventComment(int id);
    }
}
