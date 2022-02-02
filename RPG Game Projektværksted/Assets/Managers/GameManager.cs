using System.Collections.Generic;
using Inventory.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance; //MARKER SINGLETON PATTERN
        public bool isPaused;

        public List<Item> items = new List<Item>(); //WHAT KIND OF ITEMS WE HAVE 
        public List<int> itemNumbers = new List<int>(); //HOW MANY ITEMS WE HAVE 
        public GameObject[] slots;

        //public Dictionary<Item, int> itemDict = new Dictionary<Item, int>();//OPTIONAL

        public ItemButton thisButton; //Keep Track of which Item Button We are mouse Hovering
        public ItemButton[] itemButtons; //ALL of ITEM BUTTONS in this game [Used for reset]


        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                if(instance != this)
                {
                    Destroy(gameObject);
                }
            }
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            DisplayItems();
        }

        private void DisplayItems()
        {
            //We IGNORE the fact
            for(int i = 0; i < slots.Length; i++)
            {
                Image itemImage = slots[i].transform.GetChild(0).GetComponent<Image>();
                TextMeshProUGUI countText = slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                Transform closeButton = slots[i].transform.GetChild(2);
                if(i < items.Count)
                {
                    //UPDATE slots Item Image
                    
                    itemImage.color = new Color(1, 1, 1, 1);
                    itemImage.sprite = items[i].Sprite;
                    //UPDATE slots Count Text
                    
                    countText.color = new Color(1, 1, 1, 0.8235294f);
                    countText.text = itemNumbers[i].ToString();

                    //UPDATE CLOSE/THROW button
                    closeButton.gameObject.SetActive(true);
                }
                else//Some Remove Items
                {
                    //UPDATE slots Item Image
                    itemImage.color = new Color(1, 1, 1, 0);
                    itemImage.sprite = null;

                    //UPDATE slots Count Text
                    countText.color = new Color(1, 1, 1, 0);
                    countText.text = null;

                    //UPDATE CLOSE/THROW button
                    closeButton.gameObject.SetActive(false);
                }
            }
        }

        public void AddItem(Item _item)
        {
            if(!items.Contains(_item))
            {
                items.Add(_item);
                itemNumbers.Add(1);
            }
            else for (int i = 0; i < items.Count; i++) if (_item == items[i]) itemNumbers[i]++;

            DisplayItems();
        }

        public void RemoveItem(Item _item)
        {
            if (items.Contains(_item)) //IF There is one existing item in our bags(List)
                for (int i = 0; i < items.Count; i++)
                {
                    if (_item != items[i]) continue;
                    itemNumbers[i]--;
                    
                    if (itemNumbers[i] != 0) continue;
                    items.Remove(_item);
                    itemNumbers.Remove(itemNumbers[i]);
                }
            else Debug.Log($"THERE IS NO {_item} in my Bags");

            ResetButtonItems();
            DisplayItems();
        }

        public void ResetButtonItems()
        {
            for(int i = 0; i < itemButtons.Length; i++) itemButtons[i].thisItem = i < items.Count ? items[i] : null;
        } 

    }
}
