using Microsoft.EntityFrameworkCore;
using PortfolioSystem.Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSystem.Data_Access.SqlServer
{
    public class PortfolioSystemContext : DbContext
    {
        public PortfolioSystemContext(DbContextOptions<PortfolioSystemContext> options) : base(options)
        {

        }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Stock> Bonds { get; set; }
    }
}
