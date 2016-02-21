using System;
using UnityEngine;

[Serializable]
public class BloodyScreamScript : MonoBehaviour
{
	public AudioClip[] Screams;

	public virtual void Start()
	{
		this.audio.clip = this.Screams[UnityEngine.Random.Range(0, this.Screams.Length)];
		this.audio.Play();
	}

	public virtual void Main()
	{
	}
}
