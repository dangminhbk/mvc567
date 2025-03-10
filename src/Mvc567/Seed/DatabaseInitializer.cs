// This file is part of the mvc567 distribution (https://github.com/intellisoft567/mvc567).
// Copyright (C) 2019 Georgi Karagogov
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mvc567.Common.Enums;
using Mvc567.DataAccess;
using Mvc567.DataAccess.Identity;
using Mvc567.Entities.Database;
using Mvc567.Services.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc567.Seed
{
    public class DatabaseInitializer<TDatabaseContext> : IDatabaseInitializer where TDatabaseContext : AbstractDatabaseContext<TDatabaseContext>
    {
        private readonly TDatabaseContext context;
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;

        public DatabaseInitializer(TDatabaseContext context, UserManager<User> userManager, IIdentityService identityService)
        {
            this.context = context;
            this.userManager = userManager;
            this.identityService = identityService;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.MigrateAsync();

            if (!await this.context.Roles.AnyAsync())
            {
                await EnsureRoleAsync(UserRoles.Admin, "Administrator", ApplicationPermissions.GetAllPermissionValues());
                await EnsureRoleAsync(UserRoles.User, "User", new string[] { });
            }

            if (!await this.context.Users.AnyAsync())
            {
                await CreateUserAsync("admin@example.com", "Admin123!", "AdminFirst", "AdminLast", new string[] { UserRoles.Admin.ToString() });
                await CreateUserAsync("user@example.com", "User123!", "UserFirst", "UserLast", new string[] { UserRoles.User.ToString() });
            }
        }

        private async Task EnsureRoleAsync(string roleName, string description, string[] claims)
        {
            if (!(await this.context.Roles.Where(x => x.Name == roleName).AnyAsync()))
            {
                Role role = new Role(roleName, description);
                var result = await this.identityService.CreateRoleAsync(role, claims);
            }
        }

        private async Task<User> CreateUserAsync(string email, string password, string firstName, string lastName, string[] roles)
        {
            User user = new User
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                EmailConfirmed = true,
                RegistrationDate = DateTime.Now
            };

            var result = await this.userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await this.userManager.AddToRolesAsync(user, roles);
            }
            return user;
        }
    }
}
