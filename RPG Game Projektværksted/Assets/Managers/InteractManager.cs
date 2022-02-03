using UnityEngine;

namespace Managers
{
    public class InteractManager : MonoBehaviour
    {
        [Header("Game Manager"), Space] public GameManager gameManager;
        [Header("Setup"), Space] public Player.Scripts.Player player;
        [Space] public Transform playerEyes;
        [Space] public LayerMask interactableMask;
        [Space] public Vector3 directionToShootRay = Vector3.right;

        private Ray rayToDraw;
        private Ray2D ray;
        private RaycastHit2D raycastHit;

        private void Awake()
        {
            if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
            if (player == null) player = FindObjectOfType<Player.Scripts.Player>();
        }

        private void Update()
        {
            Vector3 origin = playerEyes.position;
            directionToShootRay = player.transform.right;
            rayToDraw = CreateRay(origin, directionToShootRay);
        }

        internal void Interact()
        {
            Vector2 origin = player.transform.position;
            ray = CreateRay2D(origin, directionToShootRay);
            raycastHit = CreateRaycast2D(ray, player.interactRange, interactableMask);
            if (!raycastHit) return;
            Gizmos.color = Color.yellow;
            if (raycastHit.distance <= 2)
            {
                if (raycastHit.transform.TryGetComponent(out Interactable.Interactable interactable))
                {
                    Gizmos.color = Color.green;
                    interactable.Interaction();
                }
            }
        }

        private static Ray2D CreateRay2D(Vector2 origin, Vector2 direction) => new Ray2D(origin, direction);

        private static RaycastHit2D CreateRaycast2D(Ray2D ray, float maxDistance, LayerMask layerMask) => Physics2D.Raycast(ray.origin, ray.direction, maxDistance, layerMask);

        private static Ray CreateRay(Vector3 origin, Vector3 direction) => new Ray(origin, direction);

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawRay(rayToDraw);
        }
    }
}