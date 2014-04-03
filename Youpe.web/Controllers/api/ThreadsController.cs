using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Youpe.data.Models;
using Youpe.data.POCO;
using Youpe.Models.Repo;

namespace Youpe.web.Controllers.api
{
    public class ThreadsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Thread> Get()
        {
            var _lst = ThreadRepository.Context.Threads.ToList();

            return _lst;
        }

        public Thread Get(long id)
        {
            var _entity = ThreadRepository.findById<Thread>(id);

            if (_entity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return _entity;
        }

        public HttpResponseMessage Post(ThreadModel form)
        {
            // Mapper

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Thread _entity = new Thread();

            _entity = ThreadRepository.Add<Thread, ThreadModel>(_entity, form, true);

            var response = Request.CreateResponse<Thread>(HttpStatusCode.Created, _entity);
            string uri = Url.Link("DefaultApi", new { id = _entity.Id });
            response.Headers.Location = new Uri(uri);
            return response;

        }

        public HttpResponseMessage Put(string id, ThreadModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Thread _entity = ThreadRepository.findById<Thread>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _entity = ThreadRepository.Upd(_entity, model, false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        public HttpResponseMessage Delete(string id)
        {
            Thread _entity = ThreadRepository.findById<Thread>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                ThreadRepository.Del(_entity);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _entity);
        }





        public List<Thread> getThreads(int page, int nbResultsPerPage)
        {
            return getPaginatedThreads(getAllThreads(new Filter(FilterType.ALL, null)), page, nbResultsPerPage);
        }

        public List<Thread> getThreadsByTheme(int themeId, int page, int nbResultsPerPage)
        {
            return getPaginatedThreads(getAllThreads(new Filter(FilterType.BY_THEME, themeId.ToString())), page, nbResultsPerPage);
        }
        public List<Thread> getThreadsMostCommented(int page, int nbResultsPerPage)
        {

            return Get().ToList();
            //return getPaginatedThreads(getAllThreads(new Filter(FilterType.MOST_COMMENTED, null)), page, nbResultsPerPage);
        }
        public List<Thread> getThreadsMostRecent(int page, int nbResultsPerPage)
        {
            return Get().ToList();
            //return getPaginatedThreads(getAllThreads(new Filter(FilterType.MOST_RECENT, null)), page, nbResultsPerPage);
        }
        public List<Thread> getThreadsByFavorites(int userId, int page, int nbResultsPerPage)
        {

            return Get().ToList();

            //return getPaginatedThreads(getAllThreads(new Filter(FilterType.FAVORITES, userId.ToString())), page, nbResultsPerPage);
        }



        private List<Thread> getPaginatedThreads(List<Thread> threads, int page, int nbResultsPerPage)
        {
            List<Thread> paginatedList = new List<Thread>();
            int lastAvailableIndex = threads.Count - 1;
            int firstIndex = (page - 1) * nbResultsPerPage;
            int lastIndex = page * nbResultsPerPage - 1;
            if (firstIndex > lastAvailableIndex || page <= 0 || nbResultsPerPage <= 0)
            {
                return paginatedList;
            }
            else
            {
                int lastValidIndex = lastIndex > lastAvailableIndex ? lastAvailableIndex : lastIndex;
                int count = lastValidIndex - firstIndex;
                return threads.GetRange(firstIndex, count);
            }
        }

        private List<Thread> getAllThreads(Filter filter)
        {
            List<Thread> threads = new List<Thread>();

            if (filter.type == FilterType.BY_THEME)
            {
                String themeId = filter.content;
                Get()
                    .Where(th => th.ThemeId.ToString() == themeId)
                    .ToList();

                return threads;
            }
            else if (filter.type == FilterType.FAVORITES)
            {
                FavoritesController _favApi = new FavoritesController();

                String userId = filter.content;
                _favApi.Get()
                    .Where(f=>f.UserId == long.Parse(userId))
                    .ToList()
                    .ForEach(f => { threads.Add(Get(f.Id)); });
                return threads;
            }
            else if (filter.type == FilterType.MOST_COMMENTED)
            {
                Get()
                    .OrderByDescending(th => th.Messages.Count)
                    .ToList();
                return threads;
            }
            else if (filter.type == FilterType.MOST_RECENT)
            {
                Get()
                    .OrderByDescending(th => th.UpdatedAt)
                    .ToList()
                    .ForEach(th => { threads.Add(th); });
                return threads;
            }

            // If no filter was specified, return all threads
            threads = Get().ToList();
            return threads;
        }

        public class Filter
        {
            public FilterType type { get; set; }
            public string content { get; set; }

            public Filter(FilterType filterType, string content)
            {
                this.type = filterType;
                this.content = content;
            }
        }

        public enum FilterType { MOST_RECENT, MOST_COMMENTED, BY_THEME, FAVORITES, ALL };


    }
}