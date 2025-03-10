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

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace Mvc567.Components.TagHelpers
{
    public class HeadTagHelper : TagHelper
    {
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder headInjections = (StringBuilder)ViewContext.ViewData[typeof(HeadTagHelper).FullName];
            if (headInjections == null)
            {
                headInjections = new StringBuilder();
            }

            output.PostContent.AppendHtml(new HtmlString(headInjections.ToString()));

            return base.ProcessAsync(context, output);
        }
    }

    public static class HeadTagHelperExtensions
    {
        public static void AppendIntoTheHead(this ViewContext viewContext, string headLine)
        {
            if (viewContext.ViewData[typeof(HeadTagHelper).FullName] == null)
            {
                viewContext.ViewData[typeof(HeadTagHelper).FullName] = new StringBuilder();
            }

            ((StringBuilder)viewContext.ViewData[typeof(HeadTagHelper).FullName]).AppendLine(headLine);
        }
    }
}
