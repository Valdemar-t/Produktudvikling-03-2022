using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        [Header("Game Manager"), Space] public GameManager gameManager;
        [Header("Keybindings"), Space] public KeyCode inventory = KeyCode.I;
        [Space] public KeyCode interact = KeyCode.E;

        private Player.Scripts.Player player;

        private void Awake()
        {
            if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
            if (player == null) player = FindObjectOfType<Player.Scripts.Player>();
        }

        private void Update()
        {
            if (KeyDown(inventory)) gameManager.uiManager.InventoryControl();
            if (KeyDown(interact)) gameManager.interactManager.Interact();
            if (gameManager.debug && Input.GetKeyDown(KeyCode.Alpha1)) player.Damage(5);
        }

        private static bool KeyDown(KeyCode keyCode) => Input.GetKeyDown(keyCode);
    }
}