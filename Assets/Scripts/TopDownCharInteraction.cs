using UnityEngine;
using System.Collections;

namespace TinyAdventure
{
    public class TopDownCharInteraction : MonoBehaviour
    {
        public void SetInteractionInPosition()
        {
            gameObject.SetActive(true);
            //actionTrigger.transform.position = _newPosition;

            StartCoroutine(DisableRoutine());
        }

        IEnumerator DisableRoutine()
        {
            yield return new WaitForSeconds(0.25f);
            gameObject.SetActive(false);
        }

        void Start()
        {
            gameObject.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Interaction"))
            {
                if (collision.CompareTag("Mushroom"))
                {
                    DataManager.CollectMushroom();
                    collision.gameObject.SetActive(false);

                    if (TryGetComponent(out PlayerSounds sounds))
                    {
                        sounds.PlayCollect();
                    }
                }

                // else if (!string.IsNullOrEmpty(tag2) && collision.CompareTag(tag2))
                // {
                //     if (collision.TryGetComponent(out SimpleDialog dialog))
                //     {
                //         dialog.ActiveDialog();
                //     }

                //     else
                //     {
                //         Debug.LogWarning("No SimpleDialog component found on this GameObject.");
                //     }
                // }

                // else if (!string.IsNullOrEmpty(tag3) && collision.CompareTag(tag3))
                // {
                //     collision.gameObject.SetActive(false);
                // }
            }
        }
    }
}