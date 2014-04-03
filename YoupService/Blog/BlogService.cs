using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models.DAL.IDatabase;
using YoupRepository.Models.DAL.Database;
using YoupRepository.Models;
using YoupRepository.Models.POCO;
using AutoMapper;
using YoupRepository.Models.DTO;

namespace YoupService.Blog
{
    public class BlogService : IBlogService
    {

        IBlogDatabase blogDatabase;

        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="blog"></param>
        public BlogService(IBlogDatabase blog)
        {
            this.blogDatabase = blog;
     
        }

        /// <summary>
        /// Automapper
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public BlogsPOCO ProcessToDto(YoupRepository.Blog b)
        {
            Mapper.CreateMap<YoupRepository.Blog, BlogsDTO>();
            return new BlogsPOCO(Mapper.Map<YoupRepository.Blog, BlogsDTO>(b));
        }

        /// <summary>
        /// Delete blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return blogDatabase.Delete(id);
        }

        /// <summary>
        /// Update blog
        /// </summary>
        /// <param name="upc"></param>
        /// <returns></returns>
        public bool Update(BlogsPOCO upc)
        {
            Mapper.CreateMap<BlogsDTO, YoupRepository.Blog>();
            return blogDatabase.Update(Mapper.Map<BlogsDTO, YoupRepository.Blog>(upc.Data));
        }

    
        /// <summary>
        /// Get blog with userID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public BlogsPOCO GetBlog(string userId)
        {

            Mapper.CreateMap<BlogsDTO, YoupRepository.Blog>();
    
            YoupRepository.Blog blog = blogDatabase.GetBlog(userId);

            Mapper.CreateMap<YoupRepository.Blog, BlogsDTO>();
   
            return new BlogsPOCO(Mapper.Map<YoupRepository.Blog, BlogsDTO>(blog));
        }

        /// <summary>
        /// Create blog
        /// </summary>
        /// <param name="cgp"></param>
        /// <returns></returns>
        public BlogsPOCO Create(BlogsPOCO cgp)
        {
        

            Mapper.CreateMap<BlogsDTO, YoupRepository.Blog>();
            YoupRepository.Blog cat = blogDatabase.Create(Mapper.Map<BlogsDTO, YoupRepository.Blog>(cgp.Data));
            Mapper.CreateMap<YoupRepository.Blog, BlogsDTO>();
            return new BlogsPOCO(Mapper.Map<YoupRepository.Blog, BlogsDTO>(cat));
        }


        /// <summary>
        /// Get blog with name
        /// </summary>
        /// <param name="nameBlog"></param>
        /// <returns></returns>
        public BlogsPOCO GetBlogByName(string nameBlog)
        {
            Mapper.CreateMap<BlogsDTO, YoupRepository.Blog>();
            YoupRepository.Blog blog = blogDatabase.GetBlogByName(nameBlog);
            return new BlogsPOCO(Mapper.Map<YoupRepository.Blog, BlogsDTO>(blog));
        }


        public List<BlogsPOCO> GetBlogs()
        {
            List<BlogsPOCO> listBlog = new List<BlogsPOCO>();
            blogDatabase.GetBlogs().ForEach(
                c =>
                {
                    try
                    {
                        listBlog.Add(ProcessToDto(c));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                });
            return listBlog;
        }
    }
}
