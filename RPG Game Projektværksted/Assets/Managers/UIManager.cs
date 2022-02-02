#region

using UnityEngine;

#endregion

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public GameObject inventoryMenu;

        private void Start() => inventoryMenu.gameObject.SetActive(false);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)) InventoryControl();
        }

        public void InventoryControl()
        {

            if (GameManager.instance.isPaused) Resume();
            else Pause();
        }

        private void Resume()
        {
            inventoryMenu.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            GameManager.instance.isPaused = false;
        }

        private void Pause()
        {
            inventoryMenu.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            GameManager.instance.isPaused = true;
        }
    }
}