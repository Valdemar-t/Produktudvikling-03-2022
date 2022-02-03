#region

using Unity.Collections;
using UnityEngine;

#endregion

namespace Inventory.Components
{
    [CreateAssetMenu(menuName = "Create New Item", fileName = "New Item")]
    public class Item : ScriptableObject
    {
        [Header("Text"), Space(2)] public string Name;
        [Space(0.4f), Multiline] public string Description;
        [Header("Texture"), Space(2)] public Sprite Sprite;
        [Header("Price"), Space(2), SerializeField, ContextMenuItem("Random Sell Value", "RandomPriceValue"), ReadOnly] private int priceDifference;
        [Space(0.4f)] public int BuyPrice;
        [Space(0.4f)] public int SellPrice;

        private void OnValidate() => priceDifference = BuyPrice - SellPrice;

        private void RandomPriceValue()
        {
            BuyPrice = Random.Range(100, 1000);
            SellPrice = Random.Range(1, 100);
            priceDifference = BuyPrice - SellPrice;
        }
    }
}