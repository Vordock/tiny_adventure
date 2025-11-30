using UnityEngine;

namespace TinyAdventure
{
    public class PlayerSword : MonoBehaviour
    {
        public string damageAgent;
        public int damageAmount;

        void Start()
        {
            damageAgent = transform.parent.tag;
            gameObject.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D _other)
        {
            if (_other.gameObject.layer == LayerMask.NameToLayer("Vulnerable"))
            {
                if (damageAgent.Equals("Player"))
                {
                    //Destroy(_other.gameObject);
                    //_other.gameObject.SetActive(false);

                    if (_other.TryGetComponent(out Health health))
                    {
                        if (_other.CompareTag("Crate"))
                        {
                            ActionManager.PlayWoodCrack?.Invoke();
                        }

                        health.GetDamage(damageAmount);
                    }
                }
            }
        }
    }
}
