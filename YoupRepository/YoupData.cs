using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository
{
    public class YoupData
    {
        private YoupEntities data;

        public YoupData()
        {
            data = new YoupEntities();
        }

        public User GetUser(Guid id)
        {
            return data.Users.Where(u => u.Id == id).Single();
        }
    }
}
