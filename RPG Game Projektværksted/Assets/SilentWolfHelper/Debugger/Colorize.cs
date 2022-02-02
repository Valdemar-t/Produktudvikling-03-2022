#region

using UnityEngine;

#endregion

namespace SilentWolfHelper.Debugger
{
    public class Colorize
    {

        private const string Suffix = "</color>";

        // Color Example

        public static Colorize Red = new Colorize(Color.red), Yellow = new Colorize(Color.yellow), Green = new Colorize(Color.green), Blue = new Colorize(Color.blue), Cyan = new Colorize(Color.cyan), Magenta = new Colorize(Color.magenta);

        // Hex Example

        public static Colorize Orange = new Colorize("#FFA500"), Olive = new Colorize("#808000"), Purple = new Colorize("#800080"), DarkRed = new Colorize("#8B0000"), DarkGreen = new Colorize("#006400"), DarkOrange = new Colorize("#FF8C00"), Gold = new Colorize("#FFD700");

        private readonly string _prefix;

        // Convert Color to HtmlString
        private Colorize(Color color) => _prefix = $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>";

        // Use Hex Color
        private Colorize(string hexColor) => _prefix = $"<color={hexColor}>";

        public static string operator %(string text, Colorize color) => $"{color._prefix}{text}{Suffix}";
    }
}