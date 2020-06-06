using Api.Domain.Models;
using Common.Exceptions;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly ISqlServerRepository<User> repository;

        public UserService(ISqlServerRepository<User> repository)
        {
            this.repository = repository;
        }

        public async Task AddUserAsync(User user)
        {
            if (user == null)
                throw new CustomException("empty_user", "There was a problem with this user, please contact support.");

            repository.Insert(user);
            var saved = await repository.SaveAsync();

            if(!saved)
                throw new CustomException("problem_saving", "Problem creating the user.");
        }

        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await repository.FindAllAsync(user => user.Email != null);
        }

        public User GetAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
