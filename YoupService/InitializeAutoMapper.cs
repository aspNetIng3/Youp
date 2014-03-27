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

            Mapper.CreateMap<ThreadDTO, Thread>()
                .ForMember(c => c.Event, option => option.Ignore())
                .ForMember(c => c.Messages, option => option.Ignore())
                .ForMember(c => c.Theme, option => option.Ignore())
                .ForMember(c => c.Favorites, option => option.Ignore());
            Mapper.CreateMap<MessageDTO, Message>()
                .ForMember(c => c.Thread, option => option.Ignore())
                .ForMember(c => c.User, option => option.Ignore());
            Mapper.CreateMap<FavoriteDTO, Favorite>()
                .ForMember(c => c.Thread, option => option.Ignore())
                .ForMember(c => c.User, option => option.Ignore());
        }
    }
}
