using UnityEngine;
using DG.Tweening;
using System.Collections;


namespace TinyAdventure
{
    //[RequireComponent(typeof(CharacterMoviment))]
    public class TopDownMeleeAttack : MonoBehaviour
    {
        public GameObject weapon;

        public float attackCooldown;
        public float attackSpeed = 0.2f;
        public bool canAttack = true;

        public void StartAttack(Vector2 _movingDirection)
        {
            //Debug.Log(_movingDirection + " / " + _damageAgent);

            if (!canAttack) return;

            weapon.gameObject.SetActive(true);

            if (TryGetComponent(out TopDownCharMove moveScript))

                // Prioriza o eixo X
                if (_movingDirection.x > 0)
                {
                    SwingAttack(0, -180);
                    weapon.transform.localPosition = moveScript.rightInteractionPoint;
                }
                else if (_movingDirection.x < 0)
                {
                    SwingAttack(0, 180);
                    weapon.transform.localPosition = moveScript.leftInteractionPoint;
                }
                else if (_movingDirection.y > 0)
                {
                    SwingAttack(90, -90);
                    weapon.transform.localPosition = moveScript.upInteractionPoint;
                }
                else if (_movingDirection.y < 0)
                {
                    SwingAttack(-90, -270);
                    weapon.transform.localPosition = moveScript.downInteractionPoint;
                }

                else
                {
                    Debug.LogWarning("Direção de ataque indefinida: " + _movingDirection);
                }

            StartCoroutine(CooldownRoutine());

        }

        void SwingAttack(int _startAngle, int _finalAngle)
        {
            // Set the initial rotation
            weapon.transform.rotation = Quaternion.Euler(0, 0, _startAngle);

            // Perform the rotation animation
            weapon.transform.DORotate(new Vector3(0, 0, _finalAngle), attackSpeed, RotateMode.Fast)
                .OnComplete(() => weapon.gameObject.SetActive(false));
        }

        IEnumerator CooldownRoutine()
        {
            canAttack = false;
            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        }

    }
}