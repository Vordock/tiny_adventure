using UnityEngine;
using System.Collections;

namespace TinyAdventure
{
    public class TopDownCharInteraction : MonoBehaviour
    {
        [SerializeField]
        GameObject actionTrigger;

        public void SetInteractionInPosition()
        {
            actionTrigger.SetActive(true);
            //actionTrigger.transform.position = _newPosition;

            StartCoroutine(DisableRoutine());
        }

        IEnumerator DisableRoutine()
        {
            yield return new WaitForSeconds(0.25f);
            actionTrigger.SetActive(false);
        }
    }
}