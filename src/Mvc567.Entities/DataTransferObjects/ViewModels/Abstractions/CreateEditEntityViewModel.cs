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

using Mvc567.Common.Attributes;
using Mvc567.Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mvc567.Entities.ViewModels.Abstractions
{
    public class CreateEditEntityViewModel : ICreateEditEntityDto
    {
        [JsonIgnore]
        public string EntityName { get; set; }

        [JsonIgnore]
        public string Area { get; set; }

        [JsonIgnore]
        public string Controller { get; set; }

        [JsonIgnore]
        public string Action { get; set; }

        public List<CreateEditInputViewModel> GetModelInputList()
        {
            var resultList = new List<CreateEditInputViewModel>();
            Type modelType = this.GetType();
            var modelProperties = modelType.GetProperties();
            foreach (var property in modelProperties)
            {
                if (property.GetCustomAttributes(typeof(CreateEditEntityInputAttribute), false).Any())
                {
                    CreateEditEntityInputAttribute propertyAttribute = (CreateEditEntityInputAttribute)property.GetCustomAttributes(typeof(CreateEditEntityInputAttribute), false).FirstOrDefault();
                    var inputViewModel = new CreateEditInputViewModel
                    {
                        Label = propertyAttribute.Name,
                        Name = property.Name,
                        Type = propertyAttribute.Type,
                        EnumType = (property.PropertyType.IsEnum) ? property.PropertyType : null,
                        Value = property.GetValue(this)
                    };

                    if (inputViewModel.EnumType == null && property.PropertyType.IsArray && property.PropertyType.GetElementType().IsEnum)
                    {
                        inputViewModel.EnumType = property.PropertyType.GetElementType();
                    }
                    else if (property.HasAttribute<DatabaseEnumAttribute>())
                    {
                        var databasePropertyAttribute = property.GetAttribute<DatabaseEnumAttribute>();
                        inputViewModel.DatabaseEntityType = databasePropertyAttribute.EntityType;
                        inputViewModel.DatabaseEntityVisibleProperty = databasePropertyAttribute.Property;
                    }

                    resultList.Add(inputViewModel);
                }
            }

            return resultList;
        }
    }
}
