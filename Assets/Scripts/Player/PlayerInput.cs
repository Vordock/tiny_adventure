using UnityEngine;
using UnityEngine.InputSystem;

namespace TinyAdventure
{
    [RequireComponent(typeof(TopDownCharMove), typeof(TopDownMeleeAttack), typeof(TopDownCharInteraction))]
    public class PlayerInput : MonoBehaviour
    {
        TopDownCharMove moveScript;
        TopDownMeleeAttack attackScript;

        public SpriteRenderer spriteRenderer;

        public InputActions inputActions; // Nome da sua classe gerada

        public Vector2 movingDirection;
        public Vector2 lastDirection;

        private void Awake()
        {
            inputActions = new InputActions();

            moveScript = GetComponent<TopDownCharMove>();

            attackScript = GetComponent<TopDownMeleeAttack>();
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
            movingDirection = context.ReadValue<Vector2>();

            if (movingDirection != Vector2.zero) lastDirection = movingDirection;

            if (spriteRenderer) FlipSpriteByDirection(movingDirection);

            moveScript.Move(movingDirection);
        }

        void Update()
        {
            if (inputActions.Player.Attack.WasPressedThisFrame())
            {
                //Debug.Log($"Last Direction to attack: {lastDirection}");

                attackScript.StartAttack(lastDirection);
            }

            if (inputActions.Player.Interact.WasPressedThisFrame())
            {
                GetComponent<TopDownCharInteraction>().SetInteractionInPosition();
            }
        }

        void FlipSpriteByDirection(Vector2 direction)
        {
            if (direction.x != 0)
                spriteRenderer.flipX = direction.x < 0;
        }
    }
}
