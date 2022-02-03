#region

using System.Collections.Generic;
using Managers;
using SilentWolfHelper.Debugger;
using UnityEngine;

#endregion

namespace Inventory.Components
{
    public class PickupItem : MonoBehaviour
    {

        public static readonly List<Item> maxItemQuantityInInventoryList = new List<Item>();
        [Header("Visual Effects"), Space] public SpriteRenderer spriteRenderer;
        [Space] public Sprite item;
        [Space] public GameObject pickupFX;
        [Header("Sound Effects"), Space] public AudioSource pickupSFX;
        [Header("Data"), Space, SerializeField] private Item itemData;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            switch (GameManager.instance.inventoryManager.items.Count < GameManager.instance.inventoryManager.slots.Length)
            {
                case true when maxItemQuantityInInventoryList.Contains(itemData): return;
                case true:
                    if (pickupFX != null) Instantiate(pickupFX, transform.position, Quaternion.identity);
                    if (pickupSFX != null) pickupSFX.Play();
                    Destroy(gameObject);
                    GameManager.instance.inventoryManager.AddItem(itemData);
                    break;
                default:
                    InventoryIsFull();
                    break;
            }
        }

        private void OnValidate()
        {
            if (spriteRenderer.sprite != item) spriteRenderer.sprite = item;
        }

        private static void InventoryIsFull()
        {
            if (GameManager.instance.debug) DebugSW.Log("INVENTORY IS FULL:rainbow:b;");
        }
    }
}