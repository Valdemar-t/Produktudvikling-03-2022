#region

using System.Collections;
using System.Text.RegularExpressions;

#endregion

namespace SilentWolfHelper.Debugger
{
    public static class FontStyle
    {
        private static string _prefix;

        private static string _suffix;


        private static readonly string[] styles = {"b", "i"};

        private static void ConvertToHtml(string format)
        {
            _prefix = $"<{format}>";
            _suffix = $"</{format}>";
        }

        public static string GetStyledText(string text, GroupCollection groups)
        {
            string style = string.Empty;

            for (int i = 0; i < groups.Count; i++)
            {
                style = GetPossibleValue(groups[i].Value);
                if (style != string.Empty) break;
            }

            if (((IList)styles).Contains(style)) ConvertToHtml(style);
            else return text;

            return _prefix + text + _suffix;
        }

        public static string GetPossibleValue(string value) => ((IList)styles).Contains(value) ? value : string.Empty;
    }
}