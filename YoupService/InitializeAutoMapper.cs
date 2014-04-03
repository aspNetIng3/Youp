using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository;
using YoupRepository.Model;

namespace YoupService
{
    public static class InitializeAutoMapper
    {
        public static void Initialize()
        {
            CreateModelsToViewModels();
        }

        private static void CreateModelsToViewModels()
        {
            Mapper.CreateMap<Thread, ThreadDTO>()
                .ForMember(c => c.Event, option => option.Ignore())
                .ForMember(c => c.Messages, option => option.Ignore())
                .ForMember(c => c.Theme, option => option.Ignore())
                .ForMember(c => c.Favorites, option => option.Ignore());
            Mapper.CreateMap<Message, MessageDTO>()
                .ForMember(c => c.Thread, option => option.Ignore())
                .ForMember(c => c.User, option => option.Ignore());
            Mapper.CreateMap<Favorite, FavoriteDTO>()
                .ForMember(c => c.Thread, option => option.Ignore())
                .ForMember(c => c.User, option => option.Ignore());
            Mapper.CreateMap<Theme, ThemeDTO>()
                .ForMember(c => c.Theme1, option => option.Ignore())
                .ForMember(c => c.Theme2, option => option.Ignore())
                .ForMember(c => c.Threads, option => option.Ignore())
                .ForMember(c => c.Event, option => option.Ignore())
                .ForMember(c => c.Posts, option => option.Ignore())
                .ForMember(c => c.Users, option => option.Ignore());
        }
    }
}
