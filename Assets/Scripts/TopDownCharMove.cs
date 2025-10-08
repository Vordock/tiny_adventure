using UnityEngine;

namespace TinyAdventure
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TopDownCharMove : MonoBehaviour
    {
        public RectTransform attackIndicator;

        public Transform interactionTrigger;

        public Vector2 rightInteractionPoint, leftInteractionPoint, upInteractionPoint, downInteractionPoint;

        [SerializeField] private float moveSpeed = 5f;

        private Rigidbody2D body;

        void Awake()
        {
            body = GetComponent<Rigidbody2D>();

            GetComponentInChildren<Canvas>().worldCamera = Camera.main;
        }

        public void Move(Vector2 input)
        {
            Vector2 direction = input.normalized;
            body.linearVelocity = moveSpeed * direction;

            if (direction.x > 0)
            {
                if (attackIndicator) attackIndicator.localPosition = rightInteractionPoint * 100;

                interactionTrigger.localPosition = rightInteractionPoint * 2;
            }
            else if (direction.x < 0)
            {
                if (attackIndicator) attackIndicator.localPosition = leftInteractionPoint * 100;

                interactionTrigger.localPosition = leftInteractionPoint * 2;
            }
            else if (direction.y > 0)
            {
                if (attackIndicator) attackIndicator.localPosition = upInteractionPoint * 100;

                interactionTrigger.localPosition = upInteractionPoint * 2;
            }
            else if (direction.y < 0)
            {
                if (attackIndicator) attackIndicator.localPosition = downInteractionPoint * 100;

                interactionTrigger.localPosition = downInteractionPoint * 2;
            }
        }

        public void Stop() => body.linearVelocity = Vector2.zero;
    }
}
