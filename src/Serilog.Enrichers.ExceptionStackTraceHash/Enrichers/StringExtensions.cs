using System.Text.RegularExpressions;

namespace Serilog.Enrichers
{
    public static class StringExtentions
    {
        public static string RemoveGuids(this string source)
        {
            return GuidRegex.Replace(source, string.Empty);
        }

        private static readonly Regex GuidRegex = new Regex("[0-9a-f]{8}[-][0-9a-f]{4}[-][0-9a-f]{4}[-][0-9a-f]{4}[-][0-9a-f]{12}", RegexOptions.Compiled);
    }
}