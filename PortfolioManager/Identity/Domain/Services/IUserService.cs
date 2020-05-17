using Common.Commands;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    public interface IUserService
    {
        Task LoginAsync(AuthenticateUser authenticateUser);
        Task<UserRegistered> RegisterAsync(UserRegister userRegister);
    }
}
