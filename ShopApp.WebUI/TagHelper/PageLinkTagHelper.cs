using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ShopApp.WebUI.Models;
using System.Text;

namespace ShopApp.WebUI.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        public PageInfo PageInfo { get; set; }
        override public void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder result = new StringBuilder();
            stringBuilder.Append("<ul class='pagination'>");
            for (int i = 1; i <= PageInfo.TotalPages; i++)
            {
                stringBuilder.AppendFormat("<li class='page-item'><a class='page-link' href='{0}?page={1}'>{2}</a></li>",
                    PageInfo.CurrentCategory, i, i);
            }
            base.Process(context, output);

        }
    }
}
