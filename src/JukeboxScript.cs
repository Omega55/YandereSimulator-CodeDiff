using System;
using UnityEngine;

public class JukeboxScript : MonoBehaviour
{
	public YandereScript Yandere;

	public AudioSource SFX;

	public AudioSource AttackOnTitan;

	public AudioSource Megalovania;

	public AudioSource MissionMode;

	public AudioSource Skeletons;

	public AudioSource Metroid;

	public AudioSource Nuclear;

	public AudioSource Slender;

	public AudioSource Sukeban;

	public AudioSource Custom;

	public AudioSource Hatred;

	public AudioSource Hitman;

	public AudioSource Touhou;

	public AudioSource Falcon;

	public AudioSource Ebola;

	public AudioSource Ninja;

	public AudioSource Punch;

	public AudioSource Galo;

	public AudioSource Jojo;

	public AudioSource DK;

	public AudioSource FullSanity;

	public AudioSource HalfSanity;

	public AudioSource NoSanity;

	public AudioSource Chase;

	public float LastVolume;

	public float FadeSpeed;

	public float ClubDip;

	public float Volume;

	public int Track;

	public float Timer;

	public float Dip = 1f;

	public bool Egg;

	public AudioClip[] FullSanities;

	public AudioClip[] HalfSanities;

	public AudioClip[] NoSanities;

	public AudioClip[] AlternateFull;

	public AudioClip[] AlternateHalf;

	public AudioClip[] AlternateNo;

	private void Start()
	{
		if (UnityEngine.Random.Range(0, 2) > 0)
		{
			this.FullSanities = this.AlternateFull;
			this.HalfSanities = this.AlternateHalf;
			this.NoSanities = this.AlternateNo;
		}
		if (!Globals.SchoolAtmosphereSet)
		{
			Globals.SchoolAtmosphereSet = true;
			Globals.SchoolAtmosphere = 100f;
		}
		int num;
		if (Globals.SchoolAtmosphere >= 66.6666641f)
		{
			num = 3;
		}
		else if (Globals.SchoolAtmosphere >= 33.3333321f)
		{
			num = 2;
		}
		else
		{
			num = 1;
		}
		this.FullSanity.clip = this.FullSanities[num];
		this.HalfSanity.clip = this.HalfSanities[num];
		this.NoSanity.clip = this.NoSanities[num];
		this.FullSanity.Play();
		this.HalfSanity.Play();
		this.NoSanity.Play();
		this.Volume = 0.25f;
		this.Hitman.time = 26f;
	}

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (Input.GetKeyDown("m"))
		{
			if (this.Custom.isPlaying)
			{
				this.Egg = false;
				this.Custom.Stop();
			}
			if (this.Volume == 0f)
			{
				this.FadeSpeed = 1f;
				this.Volume = this.LastVolume;
			}
			else
			{
				this.LastVolume = this.Volume;
				this.FadeSpeed = 10f;
				this.Volume = 0f;
			}
		}
		if (Input.GetKeyDown("n") && this.Volume < 1f)
		{
			this.Volume += 0.1f;
		}
		if (Input.GetKeyDown("b") && this.Volume > 0f)
		{
			this.Volume -= 0.1f;
		}
		if (!this.Egg)
		{
			if (this.Timer > 5f)
			{
				if (this.Yandere.Sanity >= 66.6666641f)
				{
					this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, this.Volume * this.Dip - this.ClubDip, Time.deltaTime * this.FadeSpeed);
					this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
					this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
				}
				else if (this.Yandere.Sanity >= 33.3333321f)
				{
					this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
					this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, this.Volume * this.Dip - this.ClubDip, Time.deltaTime * this.FadeSpeed);
					this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
				}
				else
				{
					this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
					this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
					this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, this.Volume * this.Dip - this.ClubDip, Time.deltaTime * this.FadeSpeed);
				}
			}
		}
		else
		{
			this.AttackOnTitan.volume = Mathf.MoveTowards(this.AttackOnTitan.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Megalovania.volume = Mathf.MoveTowards(this.Megalovania.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.MissionMode.volume = Mathf.MoveTowards(this.MissionMode.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Skeletons.volume = Mathf.MoveTowards(this.Skeletons.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Metroid.volume = Mathf.MoveTowards(this.Metroid.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Nuclear.volume = Mathf.MoveTowards(this.Nuclear.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Slender.volume = Mathf.MoveTowards(this.Slender.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Sukeban.volume = Mathf.MoveTowards(this.Sukeban.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Custom.volume = Mathf.MoveTowards(this.Custom.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Hatred.volume = Mathf.MoveTowards(this.Hatred.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Hitman.volume = Mathf.MoveTowards(this.Hitman.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Touhou.volume = Mathf.MoveTowards(this.Touhou.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Falcon.volume = Mathf.MoveTowards(this.Falcon.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Ebola.volume = Mathf.MoveTowards(this.Ebola.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Ninja.volume = Mathf.MoveTowards(this.Ninja.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Punch.volume = Mathf.MoveTowards(this.Punch.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Galo.volume = Mathf.MoveTowards(this.Galo.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.Jojo.volume = Mathf.MoveTowards(this.Jojo.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
			this.DK.volume = Mathf.MoveTowards(this.DK.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
		}
		if (!this.Yandere.PauseScreen.Show && !this.Yandere.Noticed && this.Yandere.CanMove && this.Yandere.EasterEggMenu.activeInHierarchy && !this.Egg)
		{
			if (Input.GetKeyDown("t"))
			{
				this.Egg = true;
				this.KillVolume();
				this.AttackOnTitan.enabled = true;
			}
			else if (Input.GetKeyDown("p"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Nuclear.enabled = true;
			}
			else if (Input.GetKeyDown("h"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Hatred.enabled = true;
			}
			else if (Input.GetKeyDown("b"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Sukeban.enabled = true;
			}
			else if (Input.GetKeyDown("x") || Input.GetKeyDown("z"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Slender.enabled = true;
			}
			else if (Input.GetKeyDown("g"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Galo.enabled = true;
			}
			else if (Input.GetKeyDown("l"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Hitman.enabled = true;
			}
			else if (Input.GetKeyDown("s"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Skeletons.enabled = true;
			}
			else if (Input.GetKeyDown("k"))
			{
				this.Egg = true;
				this.KillVolume();
				this.DK.enabled = true;
			}
			else if (Input.GetKeyDown("c"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Touhou.enabled = true;
			}
			else if (Input.GetKeyDown("f"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Falcon.enabled = true;
			}
			else if (Input.GetKeyDown("o"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Punch.enabled = true;
			}
			else if (Input.GetKeyDown("u"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Megalovania.enabled = true;
			}
			else if (Input.GetKeyDown("q"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Metroid.enabled = true;
			}
			else if (Input.GetKeyDown("y"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Ninja.enabled = true;
			}
			else if (Input.GetKeyDown("e") || Input.GetKeyDown("6") || Input.GetKeyDown("7"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Ebola.enabled = true;
			}
		}
	}

	public void KillVolume()
	{
		this.FullSanity.volume = 0f;
		this.HalfSanity.volume = 0f;
		this.NoSanity.volume = 0f;
		this.Volume = 0.5f;
	}

	public void GameOver()
	{
		this.AttackOnTitan.Stop();
		this.Megalovania.Stop();
		this.MissionMode.Stop();
		this.Skeletons.Stop();
		this.Metroid.Stop();
		this.Nuclear.Stop();
		this.Sukeban.Stop();
		this.Custom.Stop();
		this.Slender.Stop();
		this.Hatred.Stop();
		this.Hitman.Stop();
		this.Touhou.Stop();
		this.Falcon.Stop();
		this.Ebola.Stop();
		this.Punch.Stop();
		this.Ninja.Stop();
		this.Galo.Stop();
		this.DK.Stop();
		this.FullSanity.Stop();
		this.HalfSanity.Stop();
		this.NoSanity.Stop();
	}

	public void PlayJojo()
	{
		this.Egg = true;
		this.KillVolume();
		this.Jojo.enabled = true;
	}

	public void PlayCustom()
	{
		this.Egg = true;
		this.KillVolume();
		this.Custom.enabled = true;
		this.Custom.Play();
	}
}
