using UnityEngine;
using System.Collections.Generic;

namespace tiny_adventure
{
    public class ItemSystem : MonoBehaviour
    {
        public static ItemSystem Instance;

        public GameObject keyPrefab;

        // Track if items were spawned or collected
        private HashSet<string> spawnedItems = new();
        private HashSet<string> collectedItems = new();

        private void Awake()
        {
            Instance = this;
        }

        public void SpawnItem(string id, Vector3 pos)
        {
            // Do not spawn twice
            if (spawnedItems.Contains(id))
                return;

            if (id == "SageKey")
            {
                Instantiate(keyPrefab, pos, Quaternion.identity);
            }

            spawnedItems.Add(id);
        }

        public bool WasItemSpawned(string id)
        {
            return spawnedItems.Contains(id);
        }

        public bool HasItem(string id)
        {
            return collectedItems.Contains(id);
        }

        public void CollectItem(string id)
        {
            if (!collectedItems.Contains(id))
            {
                collectedItems.Add(id);
            }
        }
    }
}
