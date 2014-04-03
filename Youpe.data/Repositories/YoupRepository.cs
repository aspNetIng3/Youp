using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Youpe.data.Contexts;
using Youpe.data.Extensions;

namespace Youpe.data.Repositories
{
    public class YoupRepository //: IYoupRepository
    {
        private static YoupContext _context;

        public static YoupContext Context
        {
            get
            {
                //YoupContext context = (YoupContext)HttpContext.Current.Session["__CONTEXT__"];
                if (_context == null)
                {
                    _context = new YoupContext();
                    //HttpContext.Current.Session["__CONTEXT__"] = context;
                }

                return _context;
            }

            set { }
        }


        public static IQueryable<T> Query<T>() where T : class
        {
            return Context.Set<T>();
        }



        public static T add<T, S>(T entity, S model = null)
            where T : class
            where S : class
        {

            if (model != null)
            {
                Mapper.CreateMap<S, T>().IgnoreAllNonExisting();
                entity = Mapper.Map<T>(model);
            }
            

            Context.Set<T>().Add(entity);

            // Save Change
            saveChanges();

            return entity;
        }


        private static T updPre<T>(T entity) where T : class
        {
            Context.Entry(entity).State = EntityState.Detached;

            return entity;
        }


        public static T upd<T, S>(T entity, S model = null)
            where T : class
            where S : class
        {
            if (model != null)
            {
                long _myId = 0;
                PropertyInfo pi = entity.GetType().GetProperties().Where(x => x.Name == "Id").FirstOrDefault();
                if (pi != null)
                {
                    _myId = long.Parse(pi.GetValue(entity, null).ToString());
                }

                entity = updPre(entity);
                Mapper.CreateMap<S, T>().IgnoreAllNonExisting();
                entity = Mapper.Map<T>(model);

                if (pi != null)
                {
                    pi.SetValue(entity, _myId, null);
                }
            }


            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<T>().Attach(entity);
            }

            Context.Entry<T>(entity).State = EntityState.Modified;

            // Save Change
            saveChanges();

            return entity;

        }


        public static void del<T>(T entity) where T : class
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<T>().Attach(entity);
            }
            Context.Entry<T>(entity).State = EntityState.Deleted;

            saveChanges();
        }

        public static T findById<T>(Int64 id) where T : class
        {
            var _entity = Context.Set<T>().Find(id);

            if (_entity != null)
            {
                //Dispose();
                return _entity;
            }
                

            return null;
        }

        public static void saveChanges()
        {
            Context.SaveChanges();
        }

        public static void dispose()
        {
            (Context as IDisposable).Dispose();
            Context = null;
        }
        
    }
}
