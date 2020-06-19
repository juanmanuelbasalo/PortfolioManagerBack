using Api.Domain.Models;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Domain.Services
{
    public interface IUserService
    {
        public Task AddUserAsync(User user);
        public Task<bool> EmailTakenAsync(string email);
        public Task<IEnumerable<User>> GetAllAsync();
    }
}
