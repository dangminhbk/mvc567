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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc567.Common;
using Mvc567.Common.Attributes;
using Mvc567.Controllers.Abstractions;
using Mvc567.DataAccess.Identity;
using Mvc567.Entities.Database;
using Mvc567.Entities.DataTransferObjects.Entities;
using Mvc567.Entities.ViewModels.Abstractions;
using Mvc567.Services.Infrastructure;

namespace Mvc567.Controllers.MVC.Admin
{
    [Area("Admin")]
    [Route("admin/seo/sitemap-patterns/")]
    [ValidateAdminCookie]
    [Authorize(Policy = ApplicationPermissions.AccessAdministrationPolicy)]
    [Authorize(Policy = ApplicationPermissions.SearchEngineOptimizationManagementPolicy)]
    public class AdminSitemapPatternsController : AbstractEntityController<SitemapItemPattern, SitemapItemPatternDto>
    {
        public AdminSitemapPatternsController(IEntityManager entityManager) : base(entityManager)
        {

        }

        protected override void InitNavigationActionsIntoListPage(ref AllEntitiesViewModel model)
        {
            base.InitNavigationActionsIntoListPage(ref model);

            model.NavigationActions.Add(new NavigationActionViewModel
            {
                Name = "View Sitemap",
                ActionUrl = "/sitemap.xml",
                Icon = MaterialDesignIcons.Sitemap,
                SeparatePage = true
            });
        }
    }
}
