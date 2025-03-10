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

using Mvc567.Entities.ViewModels.Abstractions.Table;
using System.Collections.Generic;

namespace Mvc567.Entities.ViewModels.Abstractions
{
    public class AllEntitiesViewModel
    {
        public AllEntitiesViewModel()
        {
            NavigationActions = new List<NavigationActionViewModel>();
        }

        public string Title { get; set; }

        public string SingleEntityName { get; set; }

        public TableViewModel Table { get; set; }

        public List<NavigationActionViewModel> NavigationActions { get; set; }
    }
}
