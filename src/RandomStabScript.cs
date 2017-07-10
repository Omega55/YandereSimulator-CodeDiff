using System;
using UnityEngine;

public class RandomStabScript : MonoBehaviour
{
	public AudioClip[] Stabs;

	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Stabs[UnityEngine.Random.Range(0, this.Stabs.Length)];
		component.Play();
	}
}
