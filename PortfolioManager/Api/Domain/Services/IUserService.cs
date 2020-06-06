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
        public bool DeleteUser(User user);
        public bool UpdateUser(User user);
        public User GetAsync(Guid userId);
        public Task<IEnumerable<User>> GetAllAsync();
    }
}
