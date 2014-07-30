namespace Sample.Core.Extensions
{
    public static class StringExtensions
    {
        public static string NullSafe(this string source)
        {
            return source ?? string.Empty;
        }

        public static string FormatWith(this string source, params object[] args)
        {
            return string.Format(source, args);
        }
    }
}
