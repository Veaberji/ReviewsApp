using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReviewsApp.Core.Utils.CustomTagHelpers
{
    [HtmlTargetElement(Attributes = TagHelperPrefix + "*")]
    public class ConditionClassTagHelper : TagHelper
    {
        private const string TagHelperPrefix = "condition-class-";

        [HtmlAttributeName("class")]
        public string CssClass { get; set; }

        private IDictionary<string, bool> _classValues;

        [HtmlAttributeName("", DictionaryAttributePrefix = TagHelperPrefix)]
        public IDictionary<string, bool> ClassValues => _classValues ??=
                    new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var items = ClassValues.Where(e => e.Value)
                .Select(e => e.Key).ToList();

            if (!string.IsNullOrEmpty(CssClass))
            {
                items.Insert(0, CssClass);
            }

            if (items.Any())
            {
                var classes = string.Join(" ", items);
                output.Attributes.Add("class", classes);
            }
        }
    }
}
