using System.Text.RegularExpressions;

namespace GoogleSearch
{
    public static class StringExtensions
    {
        private const string OneOrMoreWhiteSpaceCharacters = @"\s+";
        private const string SingleBlankSpaceCharacter = " ";

        public static string CollapseWhiteSpace(this string text)
        {
            return Regex.Replace(text, OneOrMoreWhiteSpaceCharacters, SingleBlankSpaceCharacter);
        }
    }
}
