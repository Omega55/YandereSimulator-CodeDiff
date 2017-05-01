using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RandomSoundScript : MonoBehaviour
{
	public AudioClip[] Clips;

	public virtual void Start()
	{
		this.audio.clip = this.Clips[UnityEngine.Random.Range(1, Extensions.get_length(this.Clips))];
		this.audio.Play();
	}

	public virtual void Main()
	{
	}
}
