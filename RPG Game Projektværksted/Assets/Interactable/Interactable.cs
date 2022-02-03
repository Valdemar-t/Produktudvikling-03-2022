using Managers;
using SilentWolfHelper.Debugger;
using UnityEngine;

namespace Interactable
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField, Space] private protected GameManager gameManager;

        private Player.Scripts.Player player;
        protected internal virtual void Interaction()
        {
            if (gameManager.debug) DebugSW.Log("Hi, I am a interactable object", this);
        }

        public bool IsClose(Vector3 currentPosition, Vector3 targetPosition) => Vector3.Distance(currentPosition, new Vector3(targetPosition.x, targetPosition.y, currentPosition.z)) <= 1;

        private void Awake() => OnAwake();
        
        private void Start() => OnStart();

        private void Update() => OnUpdate();

        protected virtual void OnAwake()
        {
            if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
        }

        protected virtual void OnStart()
        {
            if (player == null) player = FindObjectOfType<Player.Scripts.Player>();
        }
        
        protected virtual void OnUpdate() {}

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player")) Debug.Log($"Player Interacted with {name}");
        }
    }
}
