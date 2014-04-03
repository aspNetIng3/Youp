using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class CardDatabase : ICardDatabase
    {

        public List<Card> GetCards()
        {
            YoupEntities context = new YoupEntities();
            return context.Cards.ToList();
        }
        public Card getCard(int cardID)
        {
            YoupEntities context = new YoupEntities();
            return context.Cards.Where(c => c.Id == cardID).SingleOrDefault();
        }

        public Card Create(Card card)
        {
            YoupEntities context = new YoupEntities();
            context.Cards.Add(card);
            if(context.SaveChanges() == 1)
            {
                return card;
            }
            return null;
        }
        public Boolean Delete(int cardID)
        {
            YoupEntities context = new YoupEntities();
            Card cardToDelete = this.getCard(cardID);
            if(cardToDelete != null)
            {
                context.Cards.Remove(cardToDelete);
                if (context.SaveChanges() == 1)
                    return true;
            }

            return false;

        }
        public Boolean Update(Card cardUpc)
        {
            YoupEntities context = new YoupEntities();
            context.Entry(cardUpc).State = System.Data.Entity.EntityState.Modified;
            if (context.SaveChanges() == 1)
                return true;
            return false;
        }
    }
}
