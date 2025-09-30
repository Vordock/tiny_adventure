using UnityEngine;
using UnityEngine.InputSystem;

namespace TinyAdventure
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        private Rigidbody2D rb;
        private InputActions inputActions; // Nome da sua classe gerada

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            inputActions = new InputActions();
        }

        private void OnEnable()
        {
            inputActions.Player.Move.performed += OnMove;
            inputActions.Player.Move.canceled += OnMove;
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Player.Move.performed -= OnMove;
            inputActions.Player.Move.canceled -= OnMove;
            inputActions.Disable();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            rb.linearVelocity = new Vector2(input.x * moveSpeed, input.y * moveSpeed);
        }


    }

}
