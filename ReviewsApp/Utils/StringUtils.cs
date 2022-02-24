using System.Collections.Generic;

namespace ReviewsApp.Utils
{
    public static class StringUtils
    {
        public static string FormatTextWithLastWord(IEnumerable<char> chars)
        {
            var text = string.Concat(chars);
            var lastSpaceIndex = text.LastIndexOf(' ');
            return text[..lastSpaceIndex];
        }
    }
}
