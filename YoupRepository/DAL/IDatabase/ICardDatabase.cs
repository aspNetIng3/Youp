using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface ICardDatabase
    {
        List<Card> getCards();

        Card Create(Card tpc);

        bool Delete(int id);

        bool Update(Card tpc);

        Card getCard(int id);
    }
}
