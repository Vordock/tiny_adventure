using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakableObject : MonoBehaviour
{
    public GameObject objectToDrop;

    public AudioClip destroySFX;

    void OnDestroy()
    {
        if (objectToDrop && gameObject.scene.isLoaded) Instantiate(objectToDrop, transform.position, quaternion.identity);
        if (destroySFX) AudioManager.Instance.PlaySFX(destroySFX);
    }
}
