using System;
using UnityEngine;

public class GentlemanScript : MonoBehaviour
{
	public YandereScript Yandere;

	public AudioClip[] Clips;

	private void Update()
	{
		if (Input.GetButtonDown("RB"))
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (!component.isPlaying)
			{
				component.clip = this.Clips[UnityEngine.Random.Range(0, this.Clips.Length - 1)];
				component.Play();
				this.Yandere.Sanity += 10f;
			}
		}
	}
}
