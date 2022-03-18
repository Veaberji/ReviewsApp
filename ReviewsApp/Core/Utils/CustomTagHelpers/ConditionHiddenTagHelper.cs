using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ReviewsApp.Core.Utils.CustomTagHelpers
{
    [HtmlTargetElement(Attributes = TagHelperName)]
    public class ConditionHiddenTagHelper : TagHelper
    {
        private const string TagHelperName = "condition-hidden";

        [HtmlAttributeName(TagHelperName)]
        public bool IsFulfilled { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsFulfilled)
            {
                output.Attributes.Add("hidden", true);
            }
        }
    }
}
