using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using static Managers.GameManager;
using static UnityEngine.Debug;
using static UnityEngine.GameObject;
using static UnityEngine.RectTransformUtility;

namespace Inventory.Scripts
{
    public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public int buttonID;
        public Item thisItem;

        public ToolTips tooltip;
        private Vector2 position;

        //HELPER FUNCTION to get the items on this button
        private Item GetThisItem()
        {
            for (int i = 0; i < instance.items.Count; i++) if (buttonID == i) thisItem = instance.items[i];

            return thisItem;
        }

        public void CloseButton()
        {
            instance.RemoveItem(GetThisItem());

            thisItem = GetThisItem();
            if (thisItem != null)
            {
                tooltip.ShowTooltip();

                tooltip.UpdateTooltip(GetDetailText(thisItem));
                ScreenPointToLocalPointInRectangle(Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
                tooltip.SetPosition(position);
            }
            else
            {
                tooltip.HideTooltip();
                tooltip.UpdateTooltip("");
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            GetThisItem();

            if (thisItem == null) return;
            Log($"ENTER {thisItem.Name} SLOT");

            tooltip.ShowTooltip();

            tooltip.UpdateTooltip(GetDetailText(thisItem));
            ScreenPointToLocalPointInRectangle(Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
            tooltip.SetPosition(position);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.HideTooltip();
            tooltip.UpdateTooltip("");
        }

        private static string GetDetailText(Item item)
        {
            if (item == null) return "";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"<color=black>Item: </color> <color=orange>{item.Name}</color>\n\n");
            stringBuilder.Append($"<color=black>Sell Price: </color> <color=red>{item.SellPrice}</color>\n\nDescription: <color=grey>{item.Description}</color>\n\n");
            return stringBuilder.ToString();
        }
    }
}