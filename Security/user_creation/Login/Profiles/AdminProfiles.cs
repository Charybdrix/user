using System;
using AutoMapper;
using Login.DTO.AdminDTOs;
using Login.Entities;

namespace Login.Profiles;

public class AdminProfiles : Profile
{
        public AdminProfiles(){
           CreateMap<Admin,AdminDTO>().ReverseMap();
           CreateMap<Admin,AdminGetDTO>().ReverseMap();
           CreateMap<Admin,createAdminDTO>().ReverseMap();
        }
}
