using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IRankDatabase
    {
        List<Rank> getRanks();

        Rank Create(Rank tpc);

        bool Delete(int id);

        bool Update(Rank tpc);

        Rank getRank(int id);
    }
}
