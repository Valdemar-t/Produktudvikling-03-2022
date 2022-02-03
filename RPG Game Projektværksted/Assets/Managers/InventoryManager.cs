using System.Collections.Generic;
using Inventory.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class InventoryManager : MonoBehaviour
    {
        [Header("Game Manager"), Space] public GameManager gameManager;
        
        [HideInInspector] public List<Item> items = new List<Item>();
        [HideInInspector] public List<int> itemNumbers = new List<int>();
        [Header("Inventory Setup"), Space] public GameObject[] slots;
        [Space] public ItemButton[] itemButtons;


        private void Awake()
        {
            if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
        }

        internal void DisplayItems()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                Image itemImage = slots[i].transform.GetChild(0).GetComponent<Image>();
                TextMeshProUGUI countText = slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                Transform closeButton = slots[i].transform.GetChild(2);
                if (i < items.Count)
                {
                    if (itemNumbers[i].Equals(99999)) PickupItem.maxItemQuantityInInventoryList.Add(items[i]);
                    itemImage.color = new Color(1, 1, 1, 1);
                    itemImage.sprite = items[i].Sprite;
                    countText.color = new Color(1, 1, 1, 0.8235294f);
                    countText.text = itemNumbers[i].ToString();
                    closeButton.gameObject.SetActive(true);
                }
                else
                {
                    itemImage.color = new Color(1, 1, 1, 0);
                    itemImage.sprite = null;
                    countText.color = new Color(1, 1, 1, 0);
                    countText.text = null;
                    closeButton.gameObject.SetActive(false);
                }
            }
        }

        public void AddItem(Item item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
                itemNumbers.Add(1);
            }
            else for (int i = 0; i < items.Count; i++) if (item.Equals(items[i])) itemNumbers[i]++;

            DisplayItems();
        }

        public void RemoveItem(Item item)
        {
            if (items.Contains(item)) //IF There is one existing item in our bag(List)
                for (int i = 0; i < items.Count; i++)
                {
                    if (item != items[i]) continue;
                    itemNumbers[i]--;

                    if (itemNumbers[i] != 0) continue;
                    items.Remove(item);
                    itemNumbers.Remove(itemNumbers[i]);
                    PickupItem.maxItemQuantityInInventoryList.Remove(items[i]);
                }
            else
            {
                if (gameManager.debug) Debug.Log($"THERE IS NO {item} in my Bag");
            }

            ResetButtonItems();
            DisplayItems();
        }

        private void ResetButtonItems()
        {
            for (int i = 0; i < itemButtons.Length; i++) itemButtons[i].thisItem = i < items.Count ? items[i] : null;
        }
    }
}