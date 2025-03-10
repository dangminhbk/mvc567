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

using Mvc567.DataAccess.Abstraction.Entities;
using Mvc567.Entities.DataTransferObjects.Api;
using Mvc567.Entities.DataTransferObjects.ServiceResults;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mvc567.Services.Infrastructure
{
    public interface IEntityManager
    {
        Task<IEnumerable<TEntityDto>> GetAllEntitiesAsync<TEntity, TEntityDto>() where TEntity : class, IEntityBase, new();

        Task<TEntityDto> GetEntityAsync<TEntity, TEntityDto>(Guid id) where TEntity : class, IEntityBase, new();

        Task<PaginatedEntitiesResult<TEntityDto>> GetAllEntitiesPaginatedAsync<TEntity, TEntityDto>(int page, string searchQuery = null) where TEntity : class, IEntityBase, new();

        Task<Guid?> CreateEntityAsync<TEntity, TEntityDto>(TEntityDto entity) where TEntity : class, IEntityBase, new();

        Task<Guid?> ModifyEntityAsync<TEntity, TEntityDto>(Guid id, TEntityDto modifiedEntity) where TEntity : class, IEntityBase, new();

        Task<bool> DeleteEntityAsync<TEntity>(Guid id) where TEntity : class, IEntityBase, new();

        Task MoveTempFileAsync<TEntity>(TEntity entity);

        Task<PaginatedEntitiesResult<TEntityDto>> FilterEntitiesAsync<TEntity, TEntityDto>(FilterQueryRequest filterQuery) where TEntity : class, IEntityBase, new();
    }
}
