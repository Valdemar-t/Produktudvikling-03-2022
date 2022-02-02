using Managers;
using UnityEngine;

namespace InventoryComponents.Scripts
{
    public class UIManager : MonoBehaviour
    {
        public GameObject inventoryMenu;

        private void Start()
        {
            inventoryMenu.gameObject.SetActive(false);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.E)) InventoryControl();
        }

        public void InventoryControl()
        {

            if (GameManager.instance.isPaused) Resume();
            else Pause();
        }

        private void Resume()
        {
            inventoryMenu.gameObject.SetActive(false);
            Time.timeScale = 1.0f;//Real time is 1.0f
            GameManager.instance.isPaused = false;
        }

        private void Pause()
        {
            inventoryMenu.gameObject.SetActive(true);
            Time.timeScale = 0.0f;//STOP THE TIME
            GameManager.instance.isPaused = true;
        }


    }
}
