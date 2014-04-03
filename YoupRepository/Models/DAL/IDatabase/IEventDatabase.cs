using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace YoupRepository.Models.DAL.IDatabase
{
    public interface IEventDatabase
    {
        List<Events> GetEvents();
        Themes GetTheme(string id);
    }
}
