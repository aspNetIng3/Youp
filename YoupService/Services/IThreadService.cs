using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.DAL;
using YoupRepository.Model;

namespace YoupService.Services
{
    public interface IThreadService
    {
        List<ThreadPOCO> getThreads(int page, int nbResultsPerPage);
        List<ThreadPOCO> getThreadsByTheme(int themeId, int page, int nbResultsPerPage);
        List<ThreadPOCO> getThreadsMostCommented(int page, int nbResultsPerPage);
        List<ThreadPOCO> getThreadsMostRecent(int page, int nbResultsPerPage);
        List<ThreadPOCO> getThreadsByFavorites(int userId, int page, int nbResultsPerPage);

        ThreadPOCO Create(ThreadPOCO tpc);
        bool Delete(int id);

        bool Update(ThreadPOCO tpc);

        ThreadPOCO getThread(int id);
    }
}
