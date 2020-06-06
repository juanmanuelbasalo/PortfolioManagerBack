using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data_Access.Sql_Context
{
    /// <summary>
    /// Representes my Api gateway database
    /// </summary>
    public class ApiContext : DbContext
    {
        /// <summary>
        /// Constructor for the context
        /// </summary>
        /// <param name="options">Passes the options/connection with the database.</param>
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        public ApiContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ApiStorage;User Id=sa;Password=joamod%22b;");
        }

        /// <summary>
        /// Represents the Users table from the database as a DbSet.
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
