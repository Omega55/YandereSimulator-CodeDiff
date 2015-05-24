using System;
using UnityEngine;

[Serializable]
public class JukeboxScript : MonoBehaviour
{
	public YandereScript Yandere;

	public AudioSource SFX;

	public AudioSource AttackOnTitan;

	public AudioSource Nuclear;

	public AudioSource Slender;

	public AudioSource Sukeban;

	public AudioSource Hatred;

	public AudioSource Sane;

	public AudioSource Halfsane;

	public AudioSource Insane;

	public AudioSource Chase;

	public float FadeSpeed;

	public float Volume;

	public int Track;

	public float Timer;

	public float Dip;

	public bool Egg;

	public JukeboxScript()
	{
		this.Dip = 1f;
	}

	public virtual void Start()
	{
		this.Volume = 0.25f;
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (Input.GetKeyDown("m"))
		{
			if (this.Volume == (float)0)
			{
				this.FadeSpeed = (float)1;
				this.Volume = (float)1;
			}
			else
			{
				this.FadeSpeed = (float)10;
				this.Volume = (float)0;
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
					this.Sane.volume = Mathf.MoveTowards(this.Sane.volume, this.Volume * this.Dip, Time.deltaTime * this.FadeSpeed);
					this.Halfsane.volume = Mathf.MoveTowards(this.Halfsane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.Insane.volume = Mathf.MoveTowards(this.Insane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
				}
				else if (this.Yandere.Sanity >= 33.33333f)
				{
					this.Sane.volume = Mathf.MoveTowards(this.Sane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.Halfsane.volume = Mathf.MoveTowards(this.Halfsane.volume, this.Volume * this.Dip, Time.deltaTime * this.FadeSpeed);
					this.Insane.volume = Mathf.MoveTowards(this.Insane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
				}
				else
				{
					this.Sane.volume = Mathf.MoveTowards(this.Sane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.Halfsane.volume = Mathf.MoveTowards(this.Halfsane.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.Insane.volume = Mathf.MoveTowards(this.Insane.volume, this.Volume * this.Dip, Time.deltaTime * this.FadeSpeed);
				}
				if (this.Yandere.Police.Witnesses <= 0 || Input.GetButton("LB"))
				{
				}
			}
		}
		else
		{
			this.AttackOnTitan.volume = Mathf.MoveTowards(this.AttackOnTitan.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Nuclear.volume = Mathf.MoveTowards(this.Nuclear.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Sukeban.volume = Mathf.MoveTowards(this.Sukeban.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Hatred.volume = Mathf.MoveTowards(this.Hatred.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Slender.volume = Mathf.MoveTowards(this.Slender.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
		}
		if (!this.Yandere.PauseScreen.Show && !this.Yandere.Noticed && this.Yandere.CanMove)
		{
			if (Input.GetKeyDown("l") && !this.Egg)
			{
				this.Egg = true;
				this.Sane.volume = (float)0;
				this.Halfsane.volume = (float)0;
				this.Insane.volume = (float)0;
				this.Chase.volume = (float)0;
				this.Volume = 0.5f;
				this.AttackOnTitan.enabled = true;
			}
			if (Input.GetKeyDown("k") && !this.Egg)
			{
				this.Egg = true;
				this.Sane.volume = (float)0;
				this.Halfsane.volume = (float)0;
				this.Insane.volume = (float)0;
				this.Chase.volume = (float)0;
				this.Volume = 0.5f;
				this.Nuclear.enabled = true;
			}
			if (Input.GetKeyDown("j") && !this.Egg)
			{
				this.Egg = true;
				this.Sane.volume = (float)0;
				this.Halfsane.volume = (float)0;
				this.Insane.volume = (float)0;
				this.Chase.volume = (float)0;
				this.Volume = 0.5f;
				this.Hatred.enabled = true;
			}
			if (Input.GetKeyDown("g") && !this.Egg)
			{
				this.Egg = true;
				this.Sane.volume = (float)0;
				this.Halfsane.volume = (float)0;
				this.Insane.volume = (float)0;
				this.Chase.volume = (float)0;
				this.Volume = 0.5f;
				this.Sukeban.enabled = true;
			}
			if (Input.GetKeyDown("v") && !this.Egg)
			{
				this.Egg = true;
				this.Sane.volume = (float)0;
				this.Halfsane.volume = (float)0;
				this.Insane.volume = (float)0;
				this.Chase.volume = (float)0;
				this.Volume = 0.5f;
				this.Slender.enabled = true;
			}
		}
	}

	public virtual void GameOver()
	{
		this.AttackOnTitan.Stop();
		this.Nuclear.Stop();
		this.Sukeban.Stop();
		this.Hatred.Stop();
		this.Slender.Stop();
		this.Sane.Stop();
		this.Halfsane.Stop();
		this.Insane.Stop();
		this.Chase.Stop();
	}

	public virtual void Main()
	{
	}
}
