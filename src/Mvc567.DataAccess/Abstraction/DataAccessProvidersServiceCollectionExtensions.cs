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

using System;
using Microsoft.Extensions.DependencyInjection;
using Mvc567.DataAccess.Abstraction.Context;
using Microsoft.AspNetCore.Identity;
using Mvc567.DataAccess.Abstraction.Repositories;

namespace Mvc567.DataAccess.Abstraction
{
    public static class DataAccessProvidersServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataAccessProviders<TUnitOfWork, TContext, TUser, TRole>(this IServiceCollection services)
            where TUnitOfWork : UnitOfWork<TContext, TUser, TRole>
            where TContext : DatabaseContextBase<TContext, TUser, TRole>
            where TUser : IdentityUser<Guid>
            where TRole : IdentityRole<Guid>
        {
            services.AddSingleton<IUowProvider, UowProvider>();
            services.AddTransient<IDatabaseContext, TContext>();
            services.AddTransient<IUnitOfWork, TUnitOfWork>();
            services.AddScoped<IStandardRepository, StandardRepository<TContext>>();

            return services;
        }
    }
}
