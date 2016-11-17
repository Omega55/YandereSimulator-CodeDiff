using System;
using UnityEngine;

[Serializable]
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

	public float Dip;

	public bool MuteCopyrights;

	public bool Egg;

	public AudioClip[] FullSanities;

	public AudioClip[] HalfSanities;

	public AudioClip[] NoSanities;

	public AudioClip[] AlternateFull;

	public AudioClip[] AlternateHalf;

	public AudioClip[] AlternateNo;

	public JukeboxScript()
	{
		this.Dip = 1f;
	}

	public virtual void Start()
	{
		if (UnityEngine.Random.Range(0, 2) > 0)
		{
			this.FullSanities = this.AlternateFull;
			this.HalfSanities = this.AlternateHalf;
			this.NoSanities = this.AlternateNo;
		}
		if (PlayerPrefs.GetInt("SchoolAtmosphereSet") == 0)
		{
			PlayerPrefs.SetInt("SchoolAtmosphereSet", 1);
			PlayerPrefs.SetFloat("SchoolAtmosphere", (float)100);
		}
		int num;
		if (PlayerPrefs.GetFloat("SchoolAtmosphere") >= 66.66666f)
		{
			num = 3;
		}
		else if (PlayerPrefs.GetFloat("SchoolAtmosphere") >= 33.33333f)
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
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (Input.GetKeyDown("m"))
		{
			if (this.Volume == (float)0)
			{
				this.FadeSpeed = (float)1;
				this.Volume = this.LastVolume;
			}
			else
			{
				this.LastVolume = this.Volume;
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
					this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, this.Volume * this.Dip - this.ClubDip, Time.deltaTime * this.FadeSpeed);
					this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, (float)0, Time.deltaTime * this.FadeSpeed);
				}
				else if (this.Yandere.Sanity >= 33.33333f)
				{
					this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, this.Volume * this.Dip - this.ClubDip, Time.deltaTime * this.FadeSpeed);
					this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, (float)0, Time.deltaTime * this.FadeSpeed);
				}
				else
				{
					this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, (float)0, Time.deltaTime * this.FadeSpeed);
					this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, this.Volume * this.Dip - this.ClubDip, Time.deltaTime * this.FadeSpeed);
				}
				if (this.Yandere.Police.Witnesses <= 0 || Input.GetButton("LB"))
				{
				}
			}
		}
		else
		{
			this.AttackOnTitan.volume = Mathf.MoveTowards(this.AttackOnTitan.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Megalovania.volume = Mathf.MoveTowards(this.Megalovania.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.MissionMode.volume = Mathf.MoveTowards(this.MissionMode.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Skeletons.volume = Mathf.MoveTowards(this.Skeletons.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Metroid.volume = Mathf.MoveTowards(this.Metroid.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Nuclear.volume = Mathf.MoveTowards(this.Nuclear.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Slender.volume = Mathf.MoveTowards(this.Slender.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Sukeban.volume = Mathf.MoveTowards(this.Sukeban.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Hatred.volume = Mathf.MoveTowards(this.Hatred.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Hitman.volume = Mathf.MoveTowards(this.Hitman.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Touhou.volume = Mathf.MoveTowards(this.Touhou.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Falcon.volume = Mathf.MoveTowards(this.Falcon.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Ebola.volume = Mathf.MoveTowards(this.Ebola.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Ninja.volume = Mathf.MoveTowards(this.Ninja.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Punch.volume = Mathf.MoveTowards(this.Punch.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Galo.volume = Mathf.MoveTowards(this.Galo.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.Jojo.volume = Mathf.MoveTowards(this.Jojo.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
			this.DK.volume = Mathf.MoveTowards(this.DK.volume, this.Volume * this.Dip, Time.deltaTime * (float)10);
		}
		if (!this.Yandere.PauseScreen.Show && !this.Yandere.Noticed && this.Yandere.CanMove && this.Yandere.EasterEggMenu.active && !this.Egg)
		{
			if (Input.GetKeyDown("t"))
			{
				if (!this.MuteCopyrights)
				{
					this.Egg = true;
					this.KillVolume();
					this.AttackOnTitan.enabled = true;
				}
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
				if (!this.MuteCopyrights)
				{
					this.Egg = true;
					this.KillVolume();
					this.Galo.enabled = true;
				}
			}
			else if (Input.GetKeyDown("j"))
			{
				if (!this.MuteCopyrights)
				{
					this.Egg = true;
					this.KillVolume();
					this.Jojo.enabled = true;
				}
			}
			else if (Input.GetKeyDown("l"))
			{
				if (!this.MuteCopyrights)
				{
					this.Egg = true;
					this.KillVolume();
					this.Hitman.enabled = true;
				}
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
				if (!this.MuteCopyrights)
				{
					this.Egg = true;
					this.KillVolume();
					this.Falcon.enabled = true;
				}
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
				if (!this.MuteCopyrights)
				{
					this.Egg = true;
					this.KillVolume();
					this.Metroid.enabled = true;
				}
			}
			else if (Input.GetKeyDown("y"))
			{
				this.Egg = true;
				this.KillVolume();
				this.Ninja.enabled = true;
			}
			else if (Input.GetKeyDown("e") && !this.MuteCopyrights)
			{
				this.Egg = true;
				this.KillVolume();
				this.Ebola.enabled = true;
			}
		}
	}

	public virtual void KillVolume()
	{
		this.FullSanity.volume = (float)0;
		this.HalfSanity.volume = (float)0;
		this.NoSanity.volume = (float)0;
		this.Volume = 0.5f;
	}

	public virtual void GameOver()
	{
		this.AttackOnTitan.Stop();
		this.Megalovania.Stop();
		this.MissionMode.Stop();
		this.Skeletons.Stop();
		this.Metroid.Stop();
		this.Nuclear.Stop();
		this.Sukeban.Stop();
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

	public virtual void Main()
	{
	}
}
