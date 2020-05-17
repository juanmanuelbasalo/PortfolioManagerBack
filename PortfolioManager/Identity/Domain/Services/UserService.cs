using AutoMapper;
using Common.Commands;
using Common.Exceptions;
using Common.Repositories;
using Identity.Data_Access.Entities;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly ISqlServerRepository<User> repository;
        private readonly IMapper mapper;

        public UserService(ISqlServerRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task LoginAsync(AuthenticateUser authenticateUser)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRegistered> RegisterAsync(UserRegister userRegister)
        {
            if (userRegister == null) throw new CustomException("empty_user", $"User is empty.");

            var existingUser = await repository.FindAsync(user => userRegister.Email.Equals(user.Email, StringComparison.CurrentCultureIgnoreCase));

            if (existingUser != null) return null;

            var user = mapper.Map<User>(userRegister);
            user.Password = userRegister.HashedPassword();

            var success = await repository.SaveAsync();

            if (success) 
            {
                var registeredUser = mapper.Map<UserRegistered>(user);
                return registeredUser;
            }

            throw new CustomException("problem_saving_user", $"Could not save the user: {user.Email}.");
        }
    }
}
