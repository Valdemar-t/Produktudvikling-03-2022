using UnityEngine;
using UnityEngine.UI;

namespace SilentWolfHelper
{
    public static class Helpers
    {
        private static Color color;

        private static void SetAlpha(Graphic renderer, float alpha)
        {
            color.a = alpha;
            renderer.color = color; 
        }
    }
}