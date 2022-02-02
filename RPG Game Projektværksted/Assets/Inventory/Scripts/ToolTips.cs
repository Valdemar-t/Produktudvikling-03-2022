using TMPro;
using UnityEngine;

namespace Inventory.Scripts
{
    public class ToolTips : MonoBehaviour
    {
        public TextMeshProUGUI detailText;

        public void Start() => gameObject.SetActive(false);
        public void ShowTooltip() => gameObject.SetActive(true);
        public void HideTooltip() => gameObject.SetActive(false);
        public void UpdateTooltip(string updatedDetailText) => detailText.text = updatedDetailText;
        public void SetPosition(Vector2 position) => transform.localPosition = position; 
    }

}