using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO;
using YoupRepository.DAL;
using YoupRepository;
using AutoMapper;

namespace YoupService
{
    public static class AutoMapperInitializer
    {

        public static void Initialize()
        {
            CreateModelsToViewModels();
        }

        private static void CreateModelsToViewModels()
        {
            //Event mapping
            Mapper.CreateMap<Event, EventDTO>()
                .AfterMap((src,dest) =>
                    {
                        dest.Theme.Events = null;
                    });
            Mapper.CreateMap<EventDTO, Event>();

            //User mapping
            Mapper.CreateMap<User, UserDTO>()
                .ForMember(c => c.Events, option => option.Ignore())
                .ForMember(c => c.Events1, option => option.Ignore())
                .ForMember(c => c.Card, option => option.Ignore());

            //Comment mapping
            Mapper.CreateMap<EventComment, EventCommentDTO>()
                .ForMember(c => c.Event, option => option.Ignore());

            //role mapping
            Mapper.CreateMap<Role, RoleDTO>()
                .ForMember(c => c.Users, option => option.Ignore());

            //Card mapping
            Mapper.CreateMap<Card, CardDTO>()
                .ForMember(c => c.Event, option => option.Ignore())
                .ForMember(c => c.User, option => option.Ignore());
            Mapper.CreateMap<CardDTO, Card>();

            //theme mapping
            Mapper.CreateMap<Theme, ThemeDTO>()
              //  .ForMember(c => c.Events, option => option.Ignore());
                .AfterMap((src, dest) =>
                    {                        
                        foreach (var i in dest.Events)
                        {
                            i.Cards = null;
                            i.Theme = null;
                            i.Users = null;
                            i.User = null;
                        }
                       
                    });
                
                
                         //.ForMember(c => c.Events, option => option.Ignore())
   


            /*
             * 
             * 
             * 

             * 
             * 
             * 
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
             * */
        }

    }
}
