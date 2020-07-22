using Api.Domain.Models;
using AutoMapper;
using Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Map_Profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PortfolioCreated, Portfolio>();
        }
    }
}
