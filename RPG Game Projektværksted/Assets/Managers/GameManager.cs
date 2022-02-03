#region

using UnityEngine;

#endregion

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        [SerializeField] protected internal bool debug;
        [HideInInspector] public bool isPaused;

        [Header("Managers"), Space] public InputManager inputManager;
        [Space] public InventoryManager inventoryManager;
        [Space] public InteractManager interactManager;
        [Space] public UIManager uiManager;

        private void Awake()
        {
            if (instance == null) instance = this;
            else if (instance != this) Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            InitializeManagers();
            inventoryManager.DisplayItems();
        }

        private void InitializeManagers()
        {
            if (inventoryManager == null) FindObjectOfType<InventoryManager>();
            if (interactManager == null) FindObjectOfType<InteractManager>();
            if (uiManager == null) FindObjectOfType<UIManager>();
        }
    }
}