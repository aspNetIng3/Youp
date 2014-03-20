using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class CardDatabase : ICardDatabase
    {
        public List<Card> getCards()
        {
            YoupEntities ye = new YoupEntities();

            return ye.Cards.ToList();
        }

        public Card Create(Card tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Cards.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            Card notDisplay = ye.Cards.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(Card tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Card>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Card getCard(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Cards.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
