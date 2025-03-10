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

using AutoMapper.Configuration.Annotations;
using Mvc567.Common.Attributes;
using Mvc567.DataAccess.Abstraction.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc567.Entities.Database
{
    [Table("TranslationValues")]
    public class TranslationValue : AuditableEntityBase
    {
        [SearchCriteria]
        public Guid LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; }

        public Guid TranslationKeyId { get; set; }

        [ForeignKey("TranslationKeyId")]
        public virtual TranslationKey TranslationKey { get; set; }

        [SearchCriteria]
        public string Value { get; set; }
    }
}
