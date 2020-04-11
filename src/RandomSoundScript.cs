using System;
using UnityEngine;

public class RandomSoundScript : MonoBehaviour
{
	public AudioClip[] Clips;

	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Clips[Random.Range(1, this.Clips.Length)];
		component.Play();
	}
}
