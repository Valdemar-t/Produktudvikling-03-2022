#region

using System;
using UnityEngine;

#endregion

namespace SilentWolfHelper.Debugger
{
    public static class StringEx
    {
        public static Color ToColor(this string color)
        {
            if (color.StartsWith("#", StringComparison.InvariantCulture)) color = color.Substring(1);
            if (color.Length.Equals(6)) color += "FF";

            uint hex = Convert.ToUInt32(color, 16);
            float r = ((hex & 0xff000000) >> 0x18) / 255f, g = ((hex & 0xff0000) >> 0x10) / 255f, b = ((hex & 0xff00) >> 8) / 255f, a = (hex & 0xff) / 255f;

            return new Color(r, g, b, a);
        }
    }
}