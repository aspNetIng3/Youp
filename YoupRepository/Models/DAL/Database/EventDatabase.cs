using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models.DAL.IDatabase;
using YoupRepository.Models.DAL;

namespace YoupRepository.Models.DAL.Database
{
    public class EventDatabase : IEventDatabase
    {
        public List<Events> GetEvents()
        {
            var sle = new YoupEntities();
            return sle.Events.ToList();
        }

        public Themes GetTheme(string id)
        {
            var sle = new YoupEntities();
            var ev = sle.Events.Where(e => e.Id.Equals(id)).SingleOrDefault();
            if (ev == null)
            {
                return null;
            }
            return ev.Themes;
        }
    }
}
