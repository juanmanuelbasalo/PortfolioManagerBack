using Identity.Data_Access.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Data.Seed
{
    public class Roles
    {
        public static void CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "Standard"};
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = RoleManager.RoleExistsAsync(roleName).Result;
                if (!roleExist)
                {
                    //create the roles and seed them to the database
                    roleResult = RoleManager.CreateAsync(new IdentityRole(roleName)).Result;
                }
            }
        }
    }
}
