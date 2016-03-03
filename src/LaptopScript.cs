﻿using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class LaptopScript : MonoBehaviour
{
	public Camera LaptopCamera;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public Transform LaptopScreen;

	public AudioClip ShutDown;

	public GameObject SCP;

	public bool React;

	public bool Off;

	public float[] Cues;

	public string[] Subs;

	public int FirstFrame;

	public float Timer;

	public UILabel EventSubtitle;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("SCP") == 1)
		{
			this.LaptopScreen.localScale = new Vector3((float)0, (float)0, (float)0);
			this.SCP.active = false;
			this.enabled = false;
		}
		else
		{
			this.SCP.animation["f02_scp_00"].speed = (float)0;
			this.SCP.animation["f02_scp_00"].time = (float)0;
		}
	}

	public virtual void Update()
	{
		if (this.FirstFrame == 2)
		{
			this.LaptopCamera.enabled = false;
		}
		this.FirstFrame++;
		if (!this.Off)
		{
			if (!this.React)
			{
				if (this.Yandere.transform.position.x > this.transform.position.x + (float)1 && Vector3.Distance(this.Yandere.transform.position, new Vector3(this.transform.position.x, (float)4, this.transform.position.z)) < (float)2 && this.Yandere.Followers == 0)
				{
					this.EventSubtitle.transform.localScale = new Vector3((float)1, (float)1, (float)1);
					this.SCP.animation["f02_scp_00"].time = (float)0;
					this.LaptopCamera.enabled = true;
					this.SCP.animation.Play();
					this.Jukebox.Dip = 0.5f;
					this.audio.Play();
					this.React = true;
				}
			}
			else
			{
				this.audio.pitch = Time.timeScale;
				for (int i = 0; i < Extensions.get_length(this.Cues); i++)
				{
					if (this.audio.time > this.Cues[i])
					{
						this.EventSubtitle.text = this.Subs[i];
					}
				}
				if (this.audio.time >= this.audio.clip.length - (float)1)
				{
					this.SCP.animation["f02_scp_00"].speed = (float)1;
					this.Timer += Time.deltaTime;
				}
				else
				{
					this.SCP.animation["f02_scp_00"].time = this.audio.time;
				}
				if (this.Timer > (float)1)
				{
					this.audio.clip = this.ShutDown;
					this.audio.Play();
					this.EventSubtitle.text = string.Empty;
					PlayerPrefs.SetInt("SCP", 1);
					this.LaptopCamera.enabled = false;
					this.Jukebox.Dip = (float)1;
					this.React = false;
					this.Off = true;
				}
			}
		}
		else
		{
			this.LaptopScreen.localScale = Vector3.Lerp(this.LaptopScreen.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		if (this.Off)
		{
			this.LaptopScreen.localScale = Vector3.Lerp(this.LaptopScreen.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
	}

	public virtual void Main()
	{
	}
}