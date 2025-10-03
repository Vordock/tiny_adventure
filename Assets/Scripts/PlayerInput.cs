using UnityEngine;
using UnityEngine.InputSystem;

namespace TinyAdventure
{
    [RequireComponent(typeof(CharacterMoviment))]
    public class PlayerInput : MonoBehaviour
    {
        private CharacterMoviment moveScript;

        public SpriteRenderer spriteRenderer;

        public InputActions inputActions; // Nome da sua classe gerada

        private void Awake()
        {
            inputActions = new InputActions();

            moveScript = GetComponent<CharacterMoviment>();

        }

        private void OnEnable()
        {
            inputActions.Player.Move.performed += MoveHandler;
            inputActions.Player.Move.canceled += MoveHandler;
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Player.Move.performed -= MoveHandler;
            inputActions.Player.Move.canceled -= MoveHandler;
            inputActions.Disable();
        }

        public void MoveHandler(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();

            moveScript.Move(input);

           if (spriteRenderer) FlipSpriteByDirection(input);
        }

        void FlipSpriteByDirection(Vector2 direction)
        {
            if (direction.x != 0)
                spriteRenderer.flipX = direction.x < 0;
        }
    
    }

}
