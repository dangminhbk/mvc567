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
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mvc567.Components.TagHelpers
{
    [HtmlTargetElement("bool-radio", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class BoolRadioTagHelper : TagHelper
    {
        [HtmlAttributeName("name")]
        public string ModelName { get; set; }

        [HtmlAttributeName("value")]
        public bool Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            string tagContent = RenderTag();
            output.Content.SetHtmlContent(new HtmlString(tagContent));
        }
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            string tagContent = RenderTag();
            output.Content.SetHtmlContent(new HtmlString(tagContent));
            return base.ProcessAsync(context, output);
        }

        public string RenderTag()
        {
            StringBuilder contentStringBuilder = new StringBuilder();

            string checkedString = "checked=\"checked\" ";
            string trueCheckedString = Value ? checkedString : string.Empty;
            string falseCheckedString = !Value ? checkedString : string.Empty;

            contentStringBuilder.Append("<div class=\"row m-0\">");
            contentStringBuilder.Append("<div class=\"form-radio mr-3 my-0 form-radio-flat\">");
            contentStringBuilder.Append("<label class=\"form-check-label\">");
            contentStringBuilder.Append($"<input type=\"radio\" class=\"form-check-input\" name=\"{ModelName}\" id=\"flatRadios-{ModelName}-yes\" {trueCheckedString}value=\"True\"> Yes <i class=\"input-helper\"></i>");
            contentStringBuilder.Append("</label>");
            contentStringBuilder.Append("</div>");
            contentStringBuilder.Append("<div class=\"form-radio mr-3 my-0 form-radio-flat\">");
            contentStringBuilder.Append("<label class=\"form-check-label\">");
            contentStringBuilder.Append($"<input type=\"radio\" class=\"form-check-input\" name=\"{ModelName}\" id=\"flatRadios-{ModelName}-no\" {falseCheckedString}value=\"False\"> No <i class=\"input-helper\"></i>");
            contentStringBuilder.Append("</label>");
            contentStringBuilder.Append("</div>");
            contentStringBuilder.Append("</div>");

            return contentStringBuilder.ToString();
        }
    }
}
