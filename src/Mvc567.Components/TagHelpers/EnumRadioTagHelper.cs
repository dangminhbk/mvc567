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
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mvc567.Common.Utilities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Mvc567.Components.TagHelpers
{
    [HtmlTargetElement("enum-radio", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class EnumRadioTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "row m-0");
            string tagContent = RenderTag();
            output.Content.SetHtmlContent(new HtmlString(tagContent));
        }
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "row m-0");
            string tagContent = RenderTag();
            output.Content.SetHtmlContent(new HtmlString(tagContent));
            return base.ProcessAsync(context, output);
        }

        [HtmlAttributeName("enum")]
        public Type Enum { get; set; }

        [HtmlAttributeName("selected-value")]
        public int SelectedValue { get; set; }

        [HtmlAttributeName("model-name")]
        public string ModelName { get; set; }

        private string RenderTag()
        {
            StringBuilder contentStringBuilder = new StringBuilder();
            var enumDictionary = EnumFunctions.GetEnumList(Enum);
            foreach (var enumItem in enumDictionary)
            {
                contentStringBuilder.Append(GetRadioItemHtml(enumItem.Value, enumItem.Key, enumItem.Key == SelectedValue));
            }
            return contentStringBuilder.ToString();
        }

        private string GetRadioItemHtml(string name, int value, bool selected)
        {
            StringBuilder contentStringBuilder = new StringBuilder();
            contentStringBuilder.Append("<div class=\"form-radio mr-3 mt-1 mb-2 form-radio-flat\">");
            contentStringBuilder.Append("<label class=\"form-check-label\">");
            contentStringBuilder.Append($"<input type=\"radio\" class=\"form-check-input\" name=\"{ModelName}\" id=\"flatRadios-{Guid.NewGuid().ToString()}\" {(selected ? "checked=\"checked\"" : string.Empty)} value=\"{value}\"> {name} <i class=\"input-helper\"></i>");
            contentStringBuilder.Append("</label>");
            contentStringBuilder.Append("</div>");

            return contentStringBuilder.ToString();
        }
    }
}
