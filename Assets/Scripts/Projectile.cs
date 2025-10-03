using UnityEngine;

namespace TinyAdventure
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        Rigidbody2D body;

        void Awake()
        {
           body = GetComponent<Rigidbody2D>();
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {

        }
    }
}
