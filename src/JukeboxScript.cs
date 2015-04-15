﻿using System;
using UnityEngine;

[Serializable]
public class JukeboxScript : MonoBehaviour
{
	public YandereScript Yandere;

	public AudioSource SFX;

	public AudioSource AttackOnTitan;

	public AudioSource Nuclear;

	public AudioSource Hatred;

	public AudioSource Sane;

	public AudioSource Halfsane;

	public AudioSource Insane;

	public AudioSource Chase;

	public float FadeSpeed;

	public float Volume;

	public int Track;

	public float Timer;

	public bool Egg;

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
				if (this.Yandere.Police.Witnesses <= 0 || Input.GetButton("LB"))
				{
				}
			}
		}
		else
		{
			this.AttackOnTitan.volume = Mathf.MoveTowards(this.AttackOnTitan.volume, this.Volume, Time.deltaTime * (float)10);
			this.Nuclear.volume = Mathf.MoveTowards(this.Nuclear.volume, this.Volume, Time.deltaTime * (float)10);
			this.Hatred.volume = Mathf.MoveTowards(this.Hatred.volume, this.Volume, Time.deltaTime * (float)10);
		}
		if (!this.Yandere.PauseScreen.Show && !this.Yandere.Noticed)
		{
			if (Input.GetKeyDown("l") && !this.Egg)
			{
				this.Egg = true;
				this.Sane.volume = (float)0;
				this.Halfsane.volume = (float)0;
				this.Insane.volume = (float)0;
				this.Chase.volume = (float)0;
				this.AttackOnTitan.enabled = true;
			}
			if (Input.GetKeyDown("k") && !this.Egg)
			{
				this.Egg = true;
				this.Sane.volume = (float)0;
				this.Halfsane.volume = (float)0;
				this.Insane.volume = (float)0;
				this.Chase.volume = (float)0;
				this.Nuclear.enabled = true;
			}
			if (Input.GetKeyDown("j") && !this.Egg)
			{
				this.Egg = true;
				this.Sane.volume = (float)0;
				this.Halfsane.volume = (float)0;
				this.Insane.volume = (float)0;
				this.Chase.volume = (float)0;
				this.Hatred.enabled = true;
			}
		}
	}

	public virtual void GameOver()
	{
		this.AttackOnTitan.Stop();
		this.Nuclear.Stop();
		this.Hatred.Stop();
		this.Sane.Stop();
		this.Halfsane.Stop();
		this.Insane.Stop();
		this.Chase.Stop();
	}

	public virtual void Main()
	{
	}
}
