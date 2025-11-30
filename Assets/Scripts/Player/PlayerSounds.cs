using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip swordClip;
    [SerializeField] private AudioClip hurtClip;
    [SerializeField] private AudioClip CollectClip;

    AudioSource m_audio;

    void Awake()
    {
        m_audio = GetComponent<AudioSource>();
    }

    void PlaySFX(AudioClip x)
    {
        m_audio.clip = x;
        m_audio.Play();
    }

    public void PlaySword()
    {
        PlaySFX(swordClip);
    }

    public void PlayHurt()
    {
        PlaySFX(hurtClip);
    }

    public void PlayCollect()
    {
        PlaySFX(CollectClip);
    }

}
