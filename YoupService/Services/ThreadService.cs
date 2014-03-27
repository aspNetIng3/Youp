using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository;
using YoupRepository.DAL;
using YoupRepository.Model;

namespace YoupService.Services
{
    public class ThreadService : IThreadService
    {
        IThreadDatabase _threadDatabase;
        IFavoriteDatabase _favoritesDatabase;

        public ThreadService() {
            _threadDatabase = new ThreadDatabase();
            _favoritesDatabase = new FavoriteDatabase();
        }

        public List<ThreadPOCO> getThreads(int page, int nbResultsPerPage)
        {
            return getPaginatedThreads(getAllThreads(new Filter(FilterType.ALL, null)), page, nbResultsPerPage);
        }

        public List<ThreadPOCO> getThreadsByTheme(int themeId, int page, int nbResultsPerPage)
        {
            return getPaginatedThreads(getAllThreads(new Filter(FilterType.BY_THEME, themeId.ToString())), page, nbResultsPerPage);
        }
        public List<ThreadPOCO> getThreadsMostCommented(int page, int nbResultsPerPage)
        {
            return getPaginatedThreads(getAllThreads(new Filter(FilterType.MOST_COMMENTED, null)), page, nbResultsPerPage);
        }
        public List<ThreadPOCO> getThreadsMostRecent(int page, int nbResultsPerPage)
        {
            return getPaginatedThreads(getAllThreads(new Filter(FilterType.MOST_RECENT, null)), page, nbResultsPerPage);
        }
        public List<ThreadPOCO> getThreadsByFavorites(int userId, int page, int nbResultsPerPage)
        {
            return getPaginatedThreads(getAllThreads(new Filter(FilterType.FAVORITES, userId.ToString())), page, nbResultsPerPage);
        }

        public ThreadPOCO Create(ThreadPOCO tpc)
        {
            Thread th = _threadDatabase.Create(Mapper.Map<ThreadDTO, Thread>(tpc.Data));
            return new ThreadPOCO(Mapper.Map<Thread, ThreadDTO>(th));
        }

        public bool Delete(int id)
        {
            return _threadDatabase.Delete(id);
        }

        public bool Update(ThreadPOCO tpc)
        {
            return _threadDatabase.Update(Mapper.Map<ThreadDTO, Thread>(tpc.Data));
        }

        public ThreadPOCO getThread(int id)
        {
            Thread th = _threadDatabase.getThread(id);
            return new ThreadPOCO(Mapper.Map<Thread, ThreadDTO>(th));
        }

        public ThreadPOCO ProcessToPoco(Thread p)
        {
            return new ThreadPOCO(Mapper.Map<Thread, ThreadDTO>(p));
        }

        private List<ThreadPOCO> getPaginatedThreads(List<ThreadPOCO> threads, int page, int nbResultsPerPage) {
            List<ThreadPOCO> paginatedList = new List<ThreadPOCO>();
            int lastAvailableIndex = threads.Count - 1;
            int firstIndex = (page - 1) * nbResultsPerPage;
            int lastIndex = page * nbResultsPerPage - 1;
            if (firstIndex > lastAvailableIndex || page <= 0 || nbResultsPerPage <= 0)
            {
                return paginatedList;
            }
            else {
                int lastValidIndex = lastIndex > lastAvailableIndex ? lastAvailableIndex : lastIndex;
                int count = lastValidIndex - firstIndex;
                return threads.GetRange(firstIndex, count);
            }
        }

        private List<ThreadPOCO> getAllThreads(Filter filter) {
            List<ThreadPOCO> threads = new List<ThreadPOCO>();

            if (filter.type == FilterType.BY_THEME) {
                String themeId = filter.content;
                _threadDatabase.getThreads()
                    .Where(th => th.ThemeId.ToString() == themeId)
                    .ToList()
                    .ForEach(th => { threads.Add(ProcessToPoco(th)); });
                return threads;
            }
            else if (filter.type == FilterType.FAVORITES)
            {
                String userId = filter.content;
                _favoritesDatabase.getFavorites()
                    .Where(fav => fav.UserId == userId)
                    .ToList()
                    .ForEach(fav => { threads.Add(ProcessToPoco(_threadDatabase.getThread(fav.ThreadId))); });
                return threads;
            }
            else if (filter.type == FilterType.MOST_COMMENTED)
            {
                _threadDatabase.getThreads()
                    .OrderByDescending(th => th.Messages.Count)
                    .ToList()
                    .ForEach(th => { threads.Add(ProcessToPoco(th)); });
                return threads;
            }
            else if (filter.type == FilterType.MOST_RECENT)
            {
                _threadDatabase.getThreads()
                    .OrderByDescending(th => th.UpdatedAt)
                    .ToList()
                    .ForEach(th => { threads.Add(ProcessToPoco(th)); });
                return threads;
            }

            // If no filter was specified, return all threads
            _threadDatabase.getThreads().ForEach(
                th => { threads.Add(ProcessToPoco(th)); }
            );
            return threads;
        }

        public class Filter {
            public FilterType type { get; set; }
            public string content { get; set; }

            public Filter(FilterType filterType, string content) {
                this.type = filterType;
                this.content = content;
            }
        }

        public enum FilterType { MOST_RECENT, MOST_COMMENTED, BY_THEME, FAVORITES, ALL };
    }
}
