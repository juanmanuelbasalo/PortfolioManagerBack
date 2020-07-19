using AutoMapper;
using Common.Commands;
using PortfolioSystem.Data_Access.Entities;
using PortfolioSystem.Domain.Models;
using PortfolioSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSystem.Map_Profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePortfolio, Portfolio>()
                .IgnoreProperty(p => p.ProfitAndLoss)
                .IgnoreProperty(p => p.LiquidationValue)
                .IgnoreProperty(p => p.Securities)
                .IgnoreProperty(p => p.LastUpdate);
            CreateMap<Portfolio, PortfolioCreated>();
        }
    }
}
