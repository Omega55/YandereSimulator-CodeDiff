using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class IntroScript : MonoBehaviour
{
	public AudioSource Narration;

	public AudioSource Music;

	public UILabel Label;

	public string[] Lines;

	public float[] Cue;

	public bool Narrating;

	public bool Musicing;

	public float Timer;

	public int ID;

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1)
		{
			if (!this.Narrating)
			{
				this.Narration.Play();
				this.Narrating = true;
			}
			if (!this.Musicing && this.Timer > (float)5)
			{
				this.Music.Play();
				this.Musicing = true;
			}
			if (this.ID < Extensions.get_length(this.Cue) && this.Timer > this.Cue[this.ID])
			{
				this.ID++;
			}
		}
		if (Input.GetKeyDown("space"))
		{
			this.Music.time = this.Music.time + (float)5;
		}
	}

	public virtual void Main()
	{
	}
}
