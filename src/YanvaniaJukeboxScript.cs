using System;
using UnityEngine;

public class YanvaniaJukeboxScript : MonoBehaviour
{
	public AudioClip BossIntro;

	public AudioClip BossMain;

	public AudioClip ApproachIntro;

	public AudioClip ApproachMain;

	public bool Boss;

	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (component.time + Time.deltaTime > component.clip.length)
		{
			component.clip = (this.Boss ? this.BossMain : this.ApproachMain);
			component.loop = true;
			component.Play();
		}
	}

	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}
}
