using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomInspector.SilentWolfHelper
{
    public static class Helpers
    {
        private static Color color;
        public static IEnumerator<Image> Fade(Image renderer)
        {
            color = renderer.color;
            float alpha = 0;
            
            renderer.enabled = !renderer.enabled;

            if (alpha <= 1f) for (; alpha >= 0; alpha -= 0.1f) SetAlpha(renderer, alpha);
            else for (; alpha <= 1f; alpha += 0.1f) SetAlpha(renderer, alpha);

            renderer.enabled = !renderer.enabled;
            yield return null;
        }

        private static void SetAlpha(Graphic renderer, float alpha)
        {
            color.a = alpha;
            renderer.color = color; 
        }
    }
}