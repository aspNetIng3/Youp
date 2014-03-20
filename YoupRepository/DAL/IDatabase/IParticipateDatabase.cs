using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IParticipateDatabase
    {
        List<Participate> getParticipates();

        Participate Create(Participate tpc);

        bool Delete(string id);

        bool Update(Participate tpc);

        Participate getParticipate(string id);
    }
}
