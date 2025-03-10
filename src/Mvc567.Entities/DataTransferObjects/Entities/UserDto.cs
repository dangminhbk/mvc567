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
using Mvc567.Common.Enums;
using Mvc567.Common.Attributes;
using Mvc567.Entities.Database;
using System;

namespace Mvc567.Entities.DataTransferObjects.Entities
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class UserDto
    {
        [DetailsOrder(0)]
        public string Id { get; set; }

        [TableCell(1, "Email", TableCellType.Text)]
        [DetailsOrder(1)]
        public string Email { get; set; }

        [DetailsOrder(2)]
        public string FirstName { get; set; }

        [DetailsOrder(3)]
        public string LastName { get; set; }

        [TableCell(2, "Name", TableCellType.Text)]
        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [TableCell(5, "Registration", TableCellType.DateTime)]
        [DetailsOrder(6)]
        public DateTime RegistrationDate { get; set; }

        [TableCell(3, "2FA", TableCellType.Flag)]
        [DetailsOrder(4)]
        public bool TwoFactorEnabled { get; set; }

        [TableCell(4, "Locked Out", TableCellType.Flag)]
        [DetailsOrder(5)]
        public bool IsLockedOut { get; set; }
    }
}
