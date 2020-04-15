using System;
using UnityEngine;

public class CheerScript : MonoBehaviour
{
	public AudioSource MyAudio;

	public AudioClip[] Cheers;

	public float Timer;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.MyAudio.clip = this.Cheers[UnityEngine.Random.Range(1, this.Cheers.Length)];
			this.MyAudio.Play();
			this.Timer = 0f;
		}
	}
}
