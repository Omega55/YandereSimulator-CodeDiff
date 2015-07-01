using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class GentlemanScript : MonoBehaviour
{
	public YandereScript Yandere;

	public AudioClip[] Clips;

	public virtual void Update()
	{
		if (Input.GetButtonDown("RB") && !this.audio.isPlaying)
		{
			this.audio.clip = this.Clips[NGUITools.RandomRange(0, Extensions.get_length(this.Clips) - 1)];
			this.audio.Play();
			this.Yandere.Sanity = this.Yandere.Sanity + (float)10;
			this.Yandere.UpdateSanity();
		}
	}

	public virtual void Main()
	{
	}
}
