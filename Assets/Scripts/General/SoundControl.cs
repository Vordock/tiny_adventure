using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundControl : MonoBehaviour
{
	//private AudioSource audioSource;

	public AudioClip woodCrack;
	public AudioClip pickupItem;

	void OnEnable()
	{
		GameManager.PlayWoodCrack += () => PlaySound(woodCrack);
		GameManager.PlayPickupItem += () => PlaySound(pickupItem);
	}

	void OnDisable()
	{
		GameManager.PlayWoodCrack -= () => PlaySound(woodCrack);
		GameManager.PlayPickupItem -= () => PlaySound(pickupItem);
	}

	// void Awake()
	// {
	// 	audioSource = GetComponent<AudioSource>();
	// }

	void PlaySound(AudioClip clip)
	{
		AudioSource.PlayClipAtPoint(clip, transform.position);
	}
}