#region

using System.Collections.Generic;
using System.Text.RegularExpressions;

#endregion

namespace SilentWolfHelper.Debugger
{
    public static class Emoji
    {

        private static readonly Dictionary<string, string> Emojis = new Dictionary<string, string>
        {
            {"love", "\u2764"},
            {"heart", "\u2764"},
            {"sniper", "(　-_･) ︻デ═一 ▸"},
            {"shrug", @"¯\_(ツ)_/¯"}
        };

        public static string GetEmoji(string text, string emoji)
        {
            emoji = emoji.Trim();
            if (!Emojis.ContainsKey(emoji)) return text;

            string spaces = Regex.Replace(text, "[^ ]", "");
            return spaces + Emojis[emoji];
        }
    }
}