using AutoMapper;
using UMS.Dtos;
using UMS.Models;

namespace UMS.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            //Source -> Target
            CreateMap<User, UserReadDto>();

        }

    }

}