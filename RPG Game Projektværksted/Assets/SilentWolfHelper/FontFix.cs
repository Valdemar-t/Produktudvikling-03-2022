#region

using System.Diagnostics.CodeAnalysis;
using UnityEngine;

#endregion

// ReSharper disable InvertIf

namespace SilentWolfHelper
{
    [SuppressMessage("ReSharper", "ConvertIfStatementToSwitchStatement")]
    public class FontFix : MonoBehaviour
    {
        [SerializeField] private Font[] fonts;
        [SerializeField] private FontFixMode filterMode;

        private void Start()
        {
            if (fonts.Length <= 0) return;
            if (filterMode.Equals(FontFixMode.Bilinear) || filterMode.Equals(FontFixMode.Normal))
                foreach (Font font in fonts)
                    font.material.mainTexture.filterMode = FilterMode.Bilinear;
            if (filterMode.Equals(FontFixMode.Trilinear))
                foreach (Font font in fonts)
                    font.material.mainTexture.filterMode = FilterMode.Trilinear;
            if (filterMode.Equals(FontFixMode.Point))
                foreach (Font font in fonts)
                    font.material.mainTexture.filterMode = FilterMode.Point;
        }
    }
}