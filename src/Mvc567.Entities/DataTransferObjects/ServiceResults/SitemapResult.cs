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
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Mvc567.Entities.DataTransferObjects.ServiceResults
{
    [XmlType(TypeName = "urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    [XmlRoot(Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9", IsNullable = false)]
    [Serializable]
    public class SitemapResult
    {
        public SitemapResult()
        {
            Urls = new List<Url>();
        }

        [XmlElement("url")]
        public List<Url> Urls { get; set; }
    }

    public class Url
    {
        [XmlElement("loc")]
        public string Location { get; set; }

        [XmlElement("lastmod")]
        public string LastModification { get; set; }

        [XmlElement("changefreq")]
        public string ChangeFrequency { get; set; }

        [XmlElement("priority")]
        public string Priority { get; set; }
    }
}
