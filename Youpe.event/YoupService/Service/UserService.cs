using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.POCO;
using YoupRepository.Model.DTO;
using YoupRepository;
using YoupRepository.DAL;
using AutoMapper;

namespace YoupService
{
    public class UserService : IUserService
    {
        IUserDatabase _iUserDatabase;

        public UserService(IUserDatabase iUserDatabase)
        {
            _iUserDatabase = iUserDatabase;
        }


        public List<UserPOCO> getAllUsers()
        {
            List<UserPOCO> usersList = new List<UserPOCO>();
            _iUserDatabase.GetUsers().ForEach(
              c =>
              {
                  try
                  {
                      usersList.Add(processToDTO(c));
                  }
                  catch (Exception ex)
                  {
                      throw ex;
                  }

              });

            return usersList;
        }
        public UserPOCO getUser(string userID)
        {
            Mapper.CreateMap<User, UserDTO>();
            User user = _iUserDatabase.GetUser(userID);
            return new UserPOCO(Mapper.Map<User, UserDTO>(user));
        }

        public bool updateUser(UserPOCO userUPC)
        {
            Mapper.CreateMap<UserDTO, User>();
            return _iUserDatabase.Update(Mapper.Map<UserDTO, User>(userUPC.data));
        }
  
        UserPOCO processToDTO(User user)
        {
            Mapper.CreateMap<User, UserDTO>();
            return new UserPOCO(Mapper.Map<User, UserDTO>(user));
        }
    }
}
