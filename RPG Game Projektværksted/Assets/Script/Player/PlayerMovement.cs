using CustomInspector.Attributes;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Header("Toggles"), LeftToggle, Tooltip("This is a Debug switch")] public bool debug;
        [SerializeField, LeftToggle, Tooltip("This determines if the player should respawn or not after death")] public bool shouldRespawn;
        [SerializeField, Header("Movement")] private float movementSpeed = 5f;
        [SerializeField, Range(0.1f, 2)] private float rotationSensitivity = 1;
        
        private Vector3 moveDirection;
        private float horizontal, vertical;

        private Camera cam;
        private Vector3 mousePosition, screenPoint;
        private Vector2 rotationOffset;
        private float angle;

        private void Update() => OnUpdate();

        protected virtual void OnUpdate()
        {
            PlayerMove();
            PlayerRotation();
        }

        private void PlayerMove()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            moveDirection.x = horizontal;
            moveDirection.y = vertical;
            moveDirection = moveDirection.normalized;

            transform.position += moveDirection * (Time.deltaTime * movementSpeed);
        }

        private void PlayerRotation()
        {
            if (cam == null)
            {
                cam = Camera.main;
                return;
            }

            mousePosition = Input.mousePosition;
            screenPoint = cam.WorldToScreenPoint(transform.localPosition);

            rotationOffset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
            
            angle = Mathf.Atan2(rotationOffset.y, rotationOffset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle * rotationSensitivity);
        }
    }
}
