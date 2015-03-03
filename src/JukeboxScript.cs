﻿using System;
using UnityEngine;

[Serializable]
public class JukeboxScript : MonoBehaviour
{
	public YandereScript Yandere;

	public AudioSource Piano;

	public AudioSource HipHop;

	public AudioSource AttackOnTitan;

	public AudioSource Nuclear;

	public AudioSource Sane;

	public AudioSource Halfsane;

	public AudioSource Insane;

	public AudioSource Chase;

	public float FadeSpeed;

	public float Volume;

	public int Track;

	public float Timer;

	public bool Egg;

	public bool AoT;

	public bool MGS;

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
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
		if (Input.GetKeyDown("n") && this.Volume < (float)1)
		{
			this.Volume += 0.1f;
		}
		if (Input.GetKeyDown("b") && this.Volume > (float)0)
		{
			this.Volume -= 0.1f;
		}
		if (!this.Egg)
		{
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
				if (this.Yandere.Police.Witnesses > 0 && Input.GetButton("LB"))
				{
					this.Chase.volume = Mathf.MoveTowards(this.Chase.volume, this.Volume, Time.deltaTime * (float)10);
				}
				else
				{
					this.Chase.volume = Mathf.MoveTowards(this.Chase.volume, (float)0, Time.deltaTime * (float)10);
				}
			}
		}
		else
		{
			this.AttackOnTitan.volume = Mathf.MoveTowards(this.AttackOnTitan.volume, this.Volume, Time.deltaTime * (float)10);
			this.Nuclear.volume = Mathf.MoveTowards(this.Nuclear.volume, this.Volume, Time.deltaTime * (float)10);
			if (this.AoT)
			{
				if (!this.AttackOnTitan.enabled)
				{
					this.AttackOnTitan.enabled = true;
					this.Nuclear.enabled = false;
				}
			}
			else if (this.MGS && !this.Nuclear.enabled)
			{
				this.AttackOnTitan.enabled = false;
				this.Nuclear.enabled = true;
			}
		}
		if (Input.GetKeyDown("l"))
		{
			this.Egg = true;
			this.AoT = true;
			this.MGS = false;
			this.Sane.volume = (float)0;
			this.Halfsane.volume = (float)0;
			this.Insane.volume = (float)0;
			this.Chase.volume = (float)0;
		}
		if (Input.GetKeyDown("k"))
		{
			this.Egg = true;
			this.AoT = false;
			this.MGS = true;
			this.Sane.volume = (float)0;
			this.Halfsane.volume = (float)0;
			this.Insane.volume = (float)0;
			this.Chase.volume = (float)0;
		}
	}

	public virtual void Main()
	{
	}
}
