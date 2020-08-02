using AutoMapper;
using Common.Commands;
using Identity.Data_Access.Entities;
using Identity.Domain.Models;
using Identity.HelperMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Map_Profile
{
    /// <summary>
    /// Class to create the maps for AutoMapper
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// In the constructor is where mapper creates the mapping / reverse mapping.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<CreateUser, UserRegister>().ReverseMap();
            CreateMap<LoginInputModel, AuthenticateUser>().ReverseMap();
            CreateMap<UserRegister, UserRegistered>();
        }
    }
}
