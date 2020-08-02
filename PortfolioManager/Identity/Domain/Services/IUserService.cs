using Common.Commands;
using Identity.Data_Access.Entities;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    public interface IUserService
    {
        Task<ApplicationUser> LoginUserAsync(AuthenticateUser authenticateUser);
        Task LogoutAsync();
        Task<UserRegistered> RegisterAsync(UserRegister userRegister);
    }
}
