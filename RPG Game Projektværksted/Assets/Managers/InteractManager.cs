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

        private Vector2 origin;

        private bool rayCreated, rayHitter, rayInteractable;

        private float time;

        private void Awake()
        {
            if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
            if (player == null) player = FindObjectOfType<Player.Scripts.Player>();
        }

        private void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
                if (!Input.GetKeyDown(KeyCode.E)) rayInteractable = rayHitter = rayCreated = false;
                else time = 1;

            origin = playerEyes.position;
            directionToShootRay = player.transform.right;
            rayToDraw = CreateRay(origin, directionToShootRay);
        }

        internal void Interact()
        {
            ray = CreateRay2D(origin, directionToShootRay);
            if (rayToDraw.origin.Equals(origin)) rayCreated = true;
            raycastHit = CreateRaycast2D(ray, player.interactRange, interactableMask);
            if (!raycastHit) return;
            rayCreated = false;
            rayHitter = true;
            Interactable.Interactable interactable = raycastHit.transform.GetComponent<Interactable.Interactable>();
            if (interactable)
            {
                rayHitter = false;
                rayInteractable = true;
                interactable.Interaction();
            }
        }

        private static Ray2D CreateRay2D(Vector2 origin, Vector2 direction) => new Ray2D(origin, direction);

        private static RaycastHit2D CreateRaycast2D(Ray2D ray, float maxDistance, LayerMask layerMask) => Physics2D.Raycast(ray.origin, ray.direction, maxDistance, layerMask);

        private static Ray CreateRay(Vector3 origin, Vector3 direction) => new Ray(origin, direction);

        private void OnDrawGizmos()
        {
            if (rayCreated) Gizmos.color = Color.blue;
            else if (rayHitter) Gizmos.color = Color.yellow;
            else if (rayInteractable) Gizmos.color = Color.green;
            
            Gizmos.DrawRay(rayToDraw);
        }
    }
}