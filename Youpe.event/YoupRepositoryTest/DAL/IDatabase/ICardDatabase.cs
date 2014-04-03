using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public interface ICardDatabase
    {
        List<Card> GetCards();
        Card getCard(int cardID);
        Card Create(Card card);
        Boolean Delete(int cardID);
        Boolean Update(Card cardUpc);

    }
}
