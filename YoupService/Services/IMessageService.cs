using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model;

namespace YoupService.Services
{
    public interface IMessageServices
    {
        List<MessagePOCO> getMessages(int thread, int nbResultsPerThread);

        MessagePOCO Create(MessagePOCO tpc);
        bool Delete(int id);

        bool Update(MessagePOCO tpc);

        MessagePOCO getMessage(int id);
    }
}
