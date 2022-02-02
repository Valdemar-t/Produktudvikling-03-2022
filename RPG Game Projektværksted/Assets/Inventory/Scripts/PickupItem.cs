using System.Collections.Generic;
using Managers;
using SilentWolfHelper.Debugger;
using UnityEngine;

namespace Inventory.Scripts
{
    public class PickupItem : MonoBehaviour
    {
        [Header("Visual Effects"), Space] public SpriteRenderer spriteRenderer;
        [Space] public Sprite item;
        [Space] public GameObject pickupFX;
        [Header("Sound Effects"), Space] public AudioSource pickupSFX;
        [Header("Data"), Space, SerializeField] private Item itemData;

        public static readonly List<Item> maxItemQuantityInInventoryList = new List<Item>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            switch (GameManager.instance.items.Count < GameManager.instance.slots.Length)
            {
                case true when maxItemQuantityInInventoryList.Contains(itemData): return;
                case true:
                    if (pickupFX != null) Instantiate(pickupFX, transform.position, Quaternion.identity);
                    if (pickupSFX != null) pickupSFX.Play();
                    Destroy(gameObject);
                    GameManager.instance.AddItem(itemData);
                    break;
                default:
                    InventoryIsFull();
                    break;
            }
        }

        private static void InventoryIsFull() => DebugSW.Log("INVENTORY IS FULL:rainbow:b;");

        private void OnValidate()
        {
            if (spriteRenderer.sprite != item) spriteRenderer.sprite = item;
        }
    }
}
