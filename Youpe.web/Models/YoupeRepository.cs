using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Youpe.data.Repositories;
using Youpe.search.Service;
using Youpe.web.Controllers;

namespace Youpe.web.Models
{
    public class YoupeRepository : YoupRepository
    {
        public static T Add<T, S>(T entity, S model,  bool _indexObject = false) 
            where T : class
            where S : class
        {
            //Add(entity);
            T _entity =  YoupRepository.add(entity, model);

            if ((bool)_indexObject)
            {
                YoupSearchIndexer.Create(_entity);
            }

            return _entity;
        }

        public static T Upd<T, S>(T entity, S model,  bool _indexed = false) 
            where T : class
            where S : class
        {
            
            T _entity = YoupRepository.upd(entity,model);

            if ((bool)_indexed)
            {
                YoupSearchIndexer.Update(_entity);
            }

            return _entity;
            
        }

        
        public static void Del<T>(T entity, bool? _indexed = false) where T : class
        {
            YoupRepository.del(entity);
            if ((bool)_indexed)
            {
                YoupSearchIndexer.Delete(entity);
            }
            
        }
    }
}