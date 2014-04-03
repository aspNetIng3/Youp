using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models.DAL.IDatabase;
using YoupRepository.Models.POCO;
using YoupRepository.Models.DTO;

namespace YoupService.Post
{
    public class PostService : IPostService
    {

          IPostDatabase postDatabase;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="post"></param>
          public PostService(IPostDatabase post)
        {
            this.postDatabase = post;
     
        }

        /// <summary>
        /// Automapper
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public PostsPOCO ProcessToDto(YoupRepository.Post p)
        {
            Mapper.CreateMap<YoupRepository.Post, PostsDTO>();
            return new PostsPOCO(Mapper.Map<YoupRepository.Post, PostsDTO>(p));
        }

        /// <summary>
        /// Create an article
        /// </summary>
        /// <param name="upc"></param>
        /// <returns></returns>
        public PostsPOCO Create(PostsPOCO upc)
        {
            Mapper.CreateMap<PostsDTO, YoupRepository.Post>();
            YoupRepository.Post post = postDatabase.Create(Mapper.Map<PostsDTO, YoupRepository.Post>(upc.Data));
            Mapper.CreateMap<YoupRepository.Post, PostsDTO>();
            return new PostsPOCO(Mapper.Map<YoupRepository.Post, PostsDTO>(post));
        }

        /// <summary>
        /// Delete article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return postDatabase.Delete(id);
        }

        /// <summary>
        /// Update article
        /// </summary>
        /// <param name="upc"></param>
        /// <returns></returns>
        public bool Update(PostsPOCO upc)
        {
            Mapper.CreateMap<PostsDTO, YoupRepository.Post>();
            return postDatabase.Update(Mapper.Map<PostsDTO, YoupRepository.Post>(upc.Data));
        }

        /// <summary>
        /// Get article with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PostsPOCO GetPost(int id)
        {
            Mapper.CreateMap<PostsDTO, YoupRepository.Post>();
            YoupRepository.Post post = postDatabase.GetPost(id);
            return new PostsPOCO(Mapper.Map<YoupRepository.Post, PostsDTO>(post));
          
        }

        /// <summary>
        /// Get article from blog
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public List<PostsPOCO> GetPostsForBlog(int blogId)
        {
            List<PostsPOCO> listPost = new List<PostsPOCO>();

            listPost = GetPosts();
            listPost = listPost.Where(c => c.Data.BlogId == blogId).ToList();


            return listPost;


        }

        /// <summary>
        /// Get all articles
        /// </summary>
        /// <returns></returns>
        public List<PostsPOCO> GetPosts()
        {

            List<PostsPOCO> listPost = new List<PostsPOCO>();
            postDatabase.GetPosts().ForEach(
                c =>
                {
                    try
                    {
                        listPost.Add(ProcessToDto(c));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                });
            return listPost;
        }
    }
}
