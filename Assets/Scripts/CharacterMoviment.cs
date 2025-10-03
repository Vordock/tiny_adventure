using UnityEngine;

namespace TinyAdventure
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMoviment : MonoBehaviour
    {
        public bool canMove;

        [SerializeField] private float moveSpeed = 5f;
        private Rigidbody2D body;

        void Awake()
        {
            if (!TryGetComponent(out body))
            {
                Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
            }
        }

        public void Move(Vector2 input)
        {
            Vector2 direction = input.normalized;
            body.linearVelocity = moveSpeed * direction;
        }

        public void Stop() => body.linearVelocity = Vector2.zero;
    }
}
