#region

using UnityEngine;

#endregion

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [Header("Game Manager"), Space] public GameManager gameManager;
        [Header("Inventory UI/Menu"), Space] public GameObject inventoryMenu;

        private void Awake()
        {
            if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
        }

        private void Start() => inventoryMenu.gameObject.SetActive(false);

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