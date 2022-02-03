#region

using Managers;
using SilentWolfHelper.CustomInspector.Attributes;
using SilentWolfHelper.Debugger;
using UnityEngine;

#endregion

namespace Player.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Header("Toggles"), LeftToggle, Tooltip("This is a Debug switch")] public bool debug;
        [SerializeField, LeftToggle, Tooltip("This determines if the player should respawn or not after death")] public bool shouldRespawn;
        [SerializeField, Header("Movement")] private float movementSpeed = 5f;
        [SerializeField, Range(0.1f, 2)] private float rotationSensitivity = 1;
        private float angle;

        private Camera cam;
        private float horizontal, vertical;
        private Vector3 mousePosition, screenPoint;

        private Vector3 moveDirection;
        private Vector2 rotationOffset;

        #region Movement

        private void PlayerMove()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            moveDirection.x = horizontal;
            moveDirection.y = vertical;
            moveDirection = moveDirection.normalized;

            transform.position += moveDirection * (Time.deltaTime * movementSpeed);
        }

        #endregion

        #region Rotation

        private void PlayerRotation()
        {
            if (cam == null)
            {
                if (debug || GameManager.instance.debug) DebugSW.Log($"This is a cool colorful debug log method made with:rainbow:b; {Emoji.GetEmoji("love", "\u2764")}:red:b; by SilentWolf:rainbow:b; {Emoji.GetEmoji("sniper", "(-_･) ︻デ═一 ▸")}:rainbow:b;");
                cam = Camera.main;
                return;
            }

            mousePosition = Input.mousePosition;
            screenPoint = cam.WorldToScreenPoint(transform.localPosition);

            rotationOffset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);

            angle = Mathf.Atan2(rotationOffset.y, rotationOffset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle * rotationSensitivity);
        }

        #endregion

        #region Unity MonoBehaviour Methods

        private void Awake() => OnAwake();

        private void Start() => OnStart();

        private void Update() => OnUpdate();

        #endregion

        #region Custom MonoBehaviour Methods

        protected virtual void OnAwake() {}

        protected virtual void OnStart() {}

        protected virtual void OnUpdate()
        {
            PlayerMove();
            PlayerRotation();
        }

        #endregion
    }
}