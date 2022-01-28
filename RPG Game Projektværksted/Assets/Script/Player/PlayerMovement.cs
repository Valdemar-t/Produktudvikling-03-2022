using CustomInspector.Attributes;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Header("Movement")] private float MovementSpeed = 5f;
    
        private Vector3 moveDirection = Vector3.zero;
        private float horizontal, vertical;

        private void Update() => OnUpdate();

        protected virtual void OnUpdate() 
        {
            MoveInput();
            transform.position += moveDirection * (Time.deltaTime * MovementSpeed);
        }

        private void MoveInput()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            moveDirection.x = horizontal;
            moveDirection.y = vertical;
            moveDirection = moveDirection.normalized;
        }
    }
}
