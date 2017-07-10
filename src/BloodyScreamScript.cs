using System;
using UnityEngine;

public class BloodyScreamScript : MonoBehaviour
{
	public AudioClip[] Screams;

	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Screams[UnityEngine.Random.Range(0, this.Screams.Length)];
		component.Play();
	}
}
