using System;
using AutoMapper;
using Login.DTO.UserDTOs;
using Login.Entities;

namespace Login.Profiles;

public class UserProfiles : Profile
{
    public UserProfiles(){
           CreateMap<User,UserDTO>().ReverseMap();
           CreateMap<User,UserGetDTO>().ReverseMap();
           CreateMap<User,createUserDTO>().ReverseMap();
           
    }
}
