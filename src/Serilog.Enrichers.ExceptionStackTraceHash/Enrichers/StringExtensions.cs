using System.Text.RegularExpressions;

namespace Serilog.Enrichers
{
    internal static class StringExtensions
    {
        private static readonly Regex guidRegex = new Regex("[0-9a-f]{8}[-][0-9a-f]{4}[-][0-9a-f]{4}[-][0-9a-f]{4}[-][0-9a-f]{12}", RegexOptions.Compiled);
        private static readonly Regex lambdaRegex = new Regex("lambda_method\\d+", RegexOptions.Compiled);

        public static string RemoveGuids(this string source)
        {
            return guidRegex.Replace(source, string.Empty);
        }

        public static string NormalizeLambdaMethods(this string source)
        {
            return lambdaRegex.Replace(source, "lambda_method~");
        }
    }
}