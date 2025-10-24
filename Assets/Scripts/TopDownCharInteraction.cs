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

                    PlayerSounds sounds = GetComponentInParent<PlayerSounds>();

                    if (sounds)
                    {
                        sounds.PlayCollect();
                    }

                    else
                    {
                        Debug.Log("Not found sound clip!");
                    }
                }

                if (collision.CompareTag("Sign"))
                {
                    SimpleDialog dialog = collision.GetComponent<SimpleDialog>();

                    dialog?.ActiveDialog();
                }
            }
        }
    }
}