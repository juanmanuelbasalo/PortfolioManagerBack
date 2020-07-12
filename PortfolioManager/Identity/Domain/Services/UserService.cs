using AutoMapper;
using Common.Commands;
using Common.Exceptions;
using Common.Repositories;
using Identity.Data_Access.Entities;
using Identity.Domain.Models;
using Identity.HelperMethods;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<LoggedInUser> LoginAsync(AuthenticateUser authenticateUser)
        {
            if (authenticateUser == null) throw new CustomException("empty_credentials", $"Credentials are empty");

            var user = await repository.FindAsync(u => authenticateUser.Email.ToLower().Equals(u.Email));
            
            var isValid = SecurePasswordHasher.IsValid(authenticateUser.Password, user?.Password);
            if (!isValid) return null;

            var loggedUser = new LoggedInUser()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Name, $"{user.Name} {user.LastName}"),
                    new Claim(JwtClaimTypes.Email, user.Email),
                    new Claim("role", user.Role),
                    new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
                }
            };

            return loggedUser;
        }

        public async Task<UserRegistered> RegisterAsync(UserRegister userRegister)
        {
            if (userRegister == null) throw new CustomException("empty_user", $"User is empty.");

            var existingUser = await repository.FindAsync(user => userRegister.Email.ToLower() == user.Email.ToLower());

            if (existingUser != null) return null;

            var user = mapper.Map<User>(userRegister);
            user.Role = "standard";
            user.CreatedBy = "Angular";
            user.CreatedAt = DateTimeOffset.UtcNow;

            repository.Insert(user);
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
