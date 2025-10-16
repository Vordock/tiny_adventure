using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundControl : MonoBehaviour
{
	private AudioSource audioSource;

	public AudioClip woodCrack;


	void OnEnable()
	{
		GameManager.PlayWoodCrack += () => PlaySound(woodCrack);
	}

	void OnDisable()
	{
		GameManager.PlayWoodCrack -= () => PlaySound(woodCrack);
	}

	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}


	void PlaySound(AudioClip clip)
	{
		AudioSource.PlayClipAtPoint(clip, transform.position);
	}
}