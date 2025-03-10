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

using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Mvc567.Common.Attributes;
using Mvc567.Common.Enums;
using Mvc567.Entities.Database;
using Mvc567.Entities.ViewModels.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Mvc567.Entities.DataTransferObjects.Entities
{
    [AutoMap(typeof(TranslationValue), ReverseMap = true)]
    public class TranslationValueDto : CreateEditEntityViewModel
    {
        [EntityIdentifier]
        [DetailsOrder(0)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Language is required field.")]
        [CreateEditEntityInput("Language", CreateEntityInputType.DatabaseRadio)]
        [DatabaseEnum(typeof(Language), "Name")]
        public string LanguageId { get; set; }

        [DetailsOrder(1)]
        [TableCell(1, "Language", TableCellType.Text)]
        [Ignore]
        public string LanguageName
        {
            get
            {
                return Language?.Name;
            }
        }

        public LanguageDto Language { get; set; }

        [Required(ErrorMessage = "Translation Key is required field.")]
        [CreateEditEntityInput("Translation Key", CreateEntityInputType.DatabaseSelect)]
        [DatabaseEnum(typeof(TranslationKey), "Key")]
        public string TranslationKeyId { get; set; }

        public TranslationKeyDto TranslationKey { get; set; }

        [DetailsOrder(2)]
        [TableCell(2, "Translation Key", TableCellType.Text)]
        [Ignore]
        public string TranslationKeyValue
        {
            get
            {
                return TranslationKey?.Key;
            }
        }

        [DetailsOrder(3)]
        [TableCell(3, "Value", TableCellType.Text)]
        [Required(ErrorMessage = "Value is required field.")]
        [CreateEditEntityInput("Value", CreateEntityInputType.Text)]
        public string Value { get; set; }
    }
}
