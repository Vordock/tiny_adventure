using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip swordClip;
    [SerializeField] private AudioClip hurtClip;
    [SerializeField] private AudioClip CollectClip;

    public void PlaySword()
    {
        AudioManager.Instance.PlaySFX(swordClip);
    }

    public void PlayHurt()
    {
        AudioManager.Instance.PlaySFX(hurtClip);
    }

    public void PlayCollect()
    {
        AudioManager.Instance.PlaySFX(CollectClip);
    }

}
