#region

using TMPro;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Inventory.Components
{
    public class ItemSlot : MonoBehaviour
    {
        public bool disabled;
        public Sprite item;
        public Image close, itemImage;
        public TextMeshProUGUI itemAmount;
        public Color color;
        [Range(0, 1)] public float alpha;

        private void OnValidate()
        {
            color.a = alpha;
            itemImage.sprite = item;
            close.color = color;
            itemImage.color = color;
            itemAmount.color = color;
            close.enabled = !disabled;
            itemImage.enabled = !disabled;
            itemAmount.enabled = !disabled;
        }
    }
}