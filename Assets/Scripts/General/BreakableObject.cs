using Unity.Mathematics;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject objectToDrop;

    public AudioClip destroySFX;

    void OnDestroy()
    {
        if (destroySFX) AudioManager.Instance.PlaySFX(destroySFX);

        if (objectToDrop) Instantiate(objectToDrop, transform.position, quaternion.identity);
    }
}
