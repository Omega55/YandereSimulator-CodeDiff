using System;
using UnityEngine;

[Serializable]
public class JukeboxScript : MonoBehaviour
{
	public YandereScript Yandere;

	public AudioSource Piano;

	public AudioSource HipHop;

	public AudioSource AttackOnTitan;

	public AudioSource Sane;

	public AudioSource Halfsane;

	public AudioSource Insane;

	public float FadeSpeed;

	public float Volume;

	public int Track;

	public float Timer;

	public bool AoT;

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (!this.AoT)
		{
			if (Input.GetKeyDown("m"))
			{
				if (this.Volume == (float)1)
				{
					this.FadeSpeed = (float)10;
					this.Volume = (float)0;
				}
				else
				{
					this.FadeSpeed = (float)1;
					this.Volume = (float)1;
				}
			}
			if (Input.GetKeyDown("n"))
			{
				this.Sane.time = this.Sane.time + (float)60;
				this.Halfsane.time = this.Halfsane.time + (float)60;
				this.Insane.time = this.Insane.time + (float)60;
			}
			if (this.Timer > (float)5)
			{
				if (this.Yandere.Sanity >= 66.66666f)
				{
					this.Sane.volume = Mathf.MoveTowards(this.Sane.volume, this.Volume, Time.deltaTime * this.FadeSpeed);
					this.Halfsane.volume = Mathf.MoveTowards(this.Halfsane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.Insane.volume = Mathf.MoveTowards(this.Insane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
				}
				else if (this.Yandere.Sanity >= 33.33333f)
				{
					this.Sane.volume = Mathf.MoveTowards(this.Sane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.Halfsane.volume = Mathf.MoveTowards(this.Halfsane.volume, this.Volume, Time.deltaTime * this.FadeSpeed);
					this.Insane.volume = Mathf.MoveTowards(this.Insane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
				}
				else
				{
					this.Sane.volume = Mathf.MoveTowards(this.Sane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.Halfsane.volume = Mathf.MoveTowards(this.Halfsane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.Insane.volume = Mathf.MoveTowards(this.Insane.volume, this.Volume, Time.deltaTime * this.FadeSpeed);
				}
			}
		}
		else if (!this.AttackOnTitan.enabled)
		{
			this.AttackOnTitan.enabled = true;
			this.Sane.volume = (float)0;
			this.Halfsane.volume = (float)0;
			this.Insane.volume = (float)0;
		}
		if (Input.GetKeyDown("l"))
		{
			this.AoT = true;
		}
	}

	public virtual void Main()
	{
	}
}
