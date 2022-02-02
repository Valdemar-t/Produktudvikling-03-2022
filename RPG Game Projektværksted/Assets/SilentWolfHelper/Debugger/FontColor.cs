#region

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

#endregion

namespace SilentWolfHelper.Debugger
{
    public static class FontColor
    {
        private const string suffix = "</color>";

        private static readonly Dictionary<string, Color> Colors = new Dictionary<string, Color>
        {
            {"red", Color.red},
            {"yellow", Color.yellow},
            {"green", Color.green},
            {"blue", Color.blue},
            {"cyan", Color.cyan},
            {"magenta", Color.magenta},

            {"orange", "#FFA500".ToColor()},
            {"olive", "#808000".ToColor()},
            {"purple", "#800080".ToColor()},
            {"darkRed", "#8B0000".ToColor()},
            {"darkGreen", "#006400".ToColor()},
            {"darkOrange", "#FF8C00".ToColor()},
            {"gold", "#FFD700".ToColor()},
            {"violet", "#8B00FF".ToColor()},
            {"lightRed", "#FF4447".ToColor()},
            {"lightBlue", "#4470FF".ToColor()},
            {"lightGreen", "#44FF47".ToColor()},
            {"lightPurple", "#7944FF".ToColor()}
        };

        private static readonly Dictionary<string, Color> RainBowColors = new Dictionary<string, Color>
        {
            {"lightRed", "#FF4447".ToColor()},
            {"orange", "#FFA500".ToColor()},
            {"yellow", Color.yellow},
            {"lightGreen", "#44FF47".ToColor()},
            {"lightBlue", "#4470FF".ToColor()},
            {"lightPurple", "#7944FF".ToColor()}
        };

        private static string prefix;

        public static string GetColorfulText(string text, GroupCollection groups)
        {
            string colorName = string.Empty;

            for (int i = 0; i < groups.Count; i++)
            {
                colorName = GetPossibleValue(groups[i].Value);
                if (colorName != string.Empty) break;
            }

            if (colorName.Equals("rainbow"))
            {
                string message = "";
                int counter = 0;
                foreach (char character in text)
                {
                    if (counter >= RainBowColors.Count) counter = 0;
                    string randomColor = RainBowColors.ElementAt(counter).Key;
                    prefix = ConvertToHtml(RainBowColors[randomColor]);
                    message += $"{prefix}{character}{suffix}";
                    counter++;
                }

                return message;
            }


            if (Colors.ContainsKey(colorName)) prefix = ConvertToHtml(Colors[colorName]);
            else return text;

            return $"{prefix}{text}{suffix}";
        }

        private static string ConvertToHtml(Color color) => $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>";

        public static string GetPossibleValue(string value) => Colors.ContainsKey(value) || value == "rainbow" ? value : string.Empty;
    }
}