using AutoMapper;
using Common.Commands;
using Common.Exceptions;
using Common.Repositories;
using Identity.Data_Access.Entities;
using Identity.Domain.Models;
using Identity.HelperMethods;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserService(IMapper mapper,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        //public async Task<LoggedInUser> LoginAsync(AuthenticateUser authenticateUser)
        //{
        //    if (authenticateUser == null) throw new CustomException("empty_credentials", $"Credentials are empty");

        //    var user = await repository.FindAsync(u => authenticateUser.Email.ToLower().Equals(u.Email));

        //    var isValid = SecurePasswordHasher.IsValid(authenticateUser.Password, user?.Password);
        //    if (!isValid) return null;

        //    var loggedUser = new LoggedInUser()
        //    {
        //        Email = user.Email,
        //        Id = user.Id,
        //        Name = user.Name,
        //        UserName = user.UserName,
        //        Claims = new List<Claim>
        //        {
        //            new Claim(JwtClaimTypes.Email, user.Email),
        //            new Claim("role", user.Role),
        //        }
        //    };

        //    return loggedUser;
        //}
        public async Task<ApplicationUser> LoginUserAsync(AuthenticateUser authenticateUser)
        {
            if (authenticateUser == null) throw new CustomException("empty_credentials", $"Credentials are empty");

            var user = await userManager.FindByEmailAsync(authenticateUser.Email) ?? await userManager.FindByNameAsync(authenticateUser.Email);

            if (user == null) return null;

            var result = await signInManager.PasswordSignInAsync(user?.UserName, authenticateUser.Password,
                                                                 authenticateUser.RememberLogin, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                return null;
            }

            return user;
        }
        public async Task<UserRegistered> RegisterAsync(UserRegister userRegister)
        {
            if (userRegister == null) throw new CustomException("empty_user", $"User is empty.");

            var existingUser = await userManager.FindByEmailAsync(userRegister.Email);

            if (existingUser != null) return null;

            var user = new ApplicationUser
            {
                UserName = userRegister.UserName,
                Email = userRegister.Email,
                EmailConfirmed = false,
                LastActive = DateTimeOffset.UtcNow,
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = "backend",
            };

            var result = await userManager.CreateAsync(user, userRegister.Password);
            if (!result.Succeeded) throw new CustomException(result.Errors.First().Code, result.Errors.First().Description);

            result = await userManager.AddClaimsAsync(user, new Claim[]{
                        new Claim(JwtClaimTypes.Name, user.UserName),
                        new Claim(JwtClaimTypes.GivenName, userRegister.Name),
                        new Claim(JwtClaimTypes.FamilyName, userRegister.LastName),
                        new Claim(JwtClaimTypes.Email, userRegister.Email),
                        new Claim(JwtClaimTypes.EmailVerified, user.EmailConfirmed.ToString(), ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "Standard")
                    });

            if (!result.Succeeded)
            {
                throw new CustomException("problem_saving_user", $"{result.Errors.First().Description}.");
            }

            result = await userManager.AddToRoleAsync(user, "Standard");

            if (!result.Succeeded)
            {
                throw new CustomException("problem_saving_roles", $"{result.Errors.First().Description}.");
            }

            var registeredUser = mapper.Map<UserRegistered>(userRegister);
            return registeredUser;
        }
        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
