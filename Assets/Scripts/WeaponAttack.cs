using UnityEngine;
using DG.Tweening;

namespace TinyAdventure
{
    //[RequireComponent(typeof(CharacterMoviment))]
    public class WeaponAttack : MonoBehaviour
    {
        public float attackCooldown;

        void Start()
        {
            gameObject.SetActive(false);
        }

        void OnEnable()
        {
            StartAttack(Vector2.up);
        }

        public void StartAttack(Vector2 direction)
        {
            if (direction == Vector2.up)
            {
                transform.DORotate(new Vector3(0, 0, -180), 1f, RotateMode.Fast);
            }

        }
    }
}