using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RandomStabScript : MonoBehaviour
{
	public AudioClip[] Stabs;

	public virtual void Start()
	{
		this.audio.clip = this.Stabs[UnityEngine.Random.Range(0, Extensions.get_length(this.Stabs))];
		this.audio.Play();
	}

	public virtual void Main()
	{
	}
}
