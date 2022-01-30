using System.Text.RegularExpressions;
using UnityEngine;

namespace SilentWolfHelper.Debugger
{
    public static class DebugSW
    {
        public static void Log(string input, Object context)
        {
            const string pattern = @"([^;:]*)\:?([^;:]*)\:?([^;:]*)\:?([^;:]*)\;";
            const RegexOptions options = RegexOptions.Multiline;
            Regex regex = new Regex(pattern, options);
            MatchCollection matches = regex.Matches(input);

            string text = string.Empty;


            for (int i = 0; i < matches.Count; i++)
            {
                string emoji = Emoji.GetEmoji(matches[i].Groups[1].Value, matches[i].Groups[1].Value);
                string colorfulText = FontColor.GetColorfulText(emoji, matches[i].Groups);
                string styledText = FontStyle.GetStyledText(colorfulText, matches[i].Groups);

                text += styledText;
            }

            Debug.Log(text, context);
        }

        public static void Log(string input)
        {
            const string pattern = @"([^;:]*)\:?([^;:]*)\:?([^;:]*)\:?([^;:]*)\;";
            const RegexOptions options = RegexOptions.Multiline;
            Regex regex = new Regex(pattern, options);
            MatchCollection matches = regex.Matches(input);

            string text = string.Empty;


            for (int i = 0; i < matches.Count; i++)
            {
                string emoji = Emoji.GetEmoji(matches[i].Groups[1].Value, matches[i].Groups[1].Value);
                string colorfulText = FontColor.GetColorfulText(emoji, matches[i].Groups);
                string styledText = FontStyle.GetStyledText(colorfulText, matches[i].Groups);

                text += styledText;
            }

            Debug.Log(text);
        }
    }
}
