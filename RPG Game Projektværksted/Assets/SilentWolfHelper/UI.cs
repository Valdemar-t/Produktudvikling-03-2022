using UnityEngine;
// ReSharper disable ClassNeverInstantiated.Global

namespace SilentWolfHelper
{
    public class UI
    {
        private static bool fadeIn;
        private static bool fadeOut;
        
        private static CanvasGroup currentUI;
        
        public static void Fade()
        {
            if (fadeIn && currentUI.alpha < 1)
            {
                currentUI.alpha += Time.deltaTime;
                if (currentUI.alpha >= 1) fadeIn = false;
            }

            if (!fadeOut || !(currentUI.alpha >= 0)) return;
            currentUI.alpha -= Time.deltaTime;
            if (currentUI.alpha == 0) fadeOut = false;
        }

        public static void Show(CanvasGroup currentUIGroup, bool fade = false)
        {
            if (currentUI == null) currentUI = currentUIGroup;
            fadeIn = true;
            if (fade) Hide(currentUI);
        }

        public static void Hide(CanvasGroup currentUIGroup)
        {
            if (currentUI == null) currentUI = currentUIGroup;
            fadeOut = true;
        }

        public static void Fade(CanvasGroup currentUIGroup)
        {
            currentUI = currentUIGroup;
            Show(currentUI, true);
        }
    }
}