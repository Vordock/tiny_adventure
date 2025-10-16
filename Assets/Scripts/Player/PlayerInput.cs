using System.Collections;
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

        bool canMove = true;

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

            GameManager.HoldPlayerMovement += HoldPlayerMovement;
        }

        private void OnDisable()
        {
            inputActions.Player.Move.performed -= MoveHandler;
            inputActions.Player.Move.canceled -= MoveHandler;
            inputActions.Disable();


            GameManager.HoldPlayerMovement -= HoldPlayerMovement;
        }

        public void MoveHandler(InputAction.CallbackContext context)
        {
            if (canMove)
            {
                movingDirection = context.ReadValue<Vector2>();

                if (movingDirection != Vector2.zero) lastDirection = movingDirection;

                if (spriteRenderer) FlipSpriteByDirection(movingDirection);

                moveScript.Move(movingDirection);
            }
        }

        void Update()
        {
            if (inputActions.Player.Attack.WasPressedThisFrame())
            {
                //Debug.Log($"Last Direction to attack: {lastDirection}");

                attackScript.StartAttack(lastDirection);

                StartCoroutine(StopMovementForSeconds(attackScript.attackSpeed));
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

        IEnumerator StopMovementForSeconds(float seconds)
        {
            canMove = false;
            moveScript.Move(Vector2.zero);
            yield return new WaitForSeconds(seconds);

            canMove = true;
            // Lê o input atual do jogador
            movingDirection = inputActions.Player.Move.ReadValue<Vector2>();
            moveScript.Move(movingDirection);
        }

        void HoldPlayerMovement(bool hold)
        {
            if (hold)
            {
                moveScript.Move(Vector2.zero);
                canMove = false;
            }

            else
            {
                canMove = true;
                moveScript.Move(lastDirection);
            }
        }
    }
}
