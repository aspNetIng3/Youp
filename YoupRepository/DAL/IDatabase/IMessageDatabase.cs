using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IMessageDatabase
    {
        List<Message> getMessages();

        Message Create(Message tpc);

        bool Delete(int id);

        bool Update(Message tpc);

        Message getMessage(int id);
    }
}
