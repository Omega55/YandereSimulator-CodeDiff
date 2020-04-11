using System;
using UnityEngine;

public class RandomStabScript : MonoBehaviour
{
	public AudioClip[] Stabs;

	public AudioClip Bite;

	public bool Biting;

	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (!this.Biting)
		{
			component.clip = this.Stabs[Random.Range(0, this.Stabs.Length)];
			component.Play();
			return;
		}
		component.clip = this.Bite;
		component.pitch = Random.Range(0.5f, 1f);
		component.Play();
	}
}
