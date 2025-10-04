using UnityEngine;

namespace TinyAdventure
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TopDownCharMove : MonoBehaviour
    {
        public RectTransform attackIndicator;

        public Vector2 rightInteractionPoint, leftInteractionPoint, upInteractionPoint, downInteractionPoint;

        [SerializeField] private float moveSpeed = 5f;

        private Rigidbody2D body;

        void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 input)
        {
            Vector2 direction = input.normalized;
            body.linearVelocity = moveSpeed * direction;

            if (attackIndicator)
            {
                if (direction.x > 0)
                {
                    attackIndicator.localPosition = rightInteractionPoint * 100;
                }
                else if (direction.x < 0)
                {
                    attackIndicator.localPosition = leftInteractionPoint * 100;
                }
                else if (direction.y > 0)
                {
                    attackIndicator.localPosition = upInteractionPoint * 100;
                }
                else if (direction.y < 0)
                {
                    attackIndicator.localPosition = downInteractionPoint * 100;
                }
            }
        }

        public void Stop() => body.linearVelocity = Vector2.zero;
    }
}
