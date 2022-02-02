namespace SilentWolfHelper.Debugger
{
    public class FontFormat
    {

        public static FontFormat Bold = new FontFormat("b");
        public static FontFormat Italic = new FontFormat("i");
        private readonly string _prefix;

        private readonly string _suffix;
        private FontFormat(string format)
        {
            _prefix = $"<{format}>";
            _suffix = $"</{format}>";
        }

        public static string operator %(string text, FontFormat textFormat) => $"{textFormat._prefix}{text}{textFormat._suffix}";
    }
}