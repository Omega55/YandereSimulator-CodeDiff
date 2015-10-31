using System;
using UnityEngine;

[Serializable]
public class YanvaniaJukeboxScript : MonoBehaviour
{
	public AudioClip BossIntro;

	public AudioClip BossMain;

	public AudioClip ApproachIntro;

	public AudioClip ApproachMain;

	public bool Boss;

	public virtual void Update()
	{
		if (this.Boss)
		{
			if (this.audio.time + Time.deltaTime * (float)1 > this.audio.clip.length)
			{
				this.audio.clip = this.BossMain;
				this.audio.loop = true;
				this.audio.Play();
			}
		}
		else if (this.audio.time + Time.deltaTime * (float)1 > this.audio.clip.length)
		{
			this.audio.clip = this.ApproachMain;
			this.audio.loop = true;
			this.audio.Play();
		}
	}

	public virtual void BossBattle()
	{
		this.audio.clip = this.BossIntro;
		this.audio.loop = false;
		this.audio.volume = 0.25f;
		this.audio.Play();
		this.Boss = true;
	}

	public virtual void Main()
	{
	}
}
