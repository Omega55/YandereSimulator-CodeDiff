using System;
using UnityEngine;

public class StalkerScript : MonoBehaviour
{
	public StalkerYandereScript Yandere;

	public AudioClip CrunchSound;

	public Animation MyAnimation;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public AudioClip Crunch;

	public UILabel Subtitle;

	public AudioClip[] AlarmedClip;

	public string[] AlarmedText;

	public float[] AlarmedTime;

	public AudioClip[] SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public Collider[] Boundary;

	public float MinimumDistance;

	public float Distance;

	public float Scale;

	public float Timer;

	public bool Alarmed;

	public bool Started;

	public int SpeechPhase;

	public int Limit;

	private void Update()
	{
		this.Distance = Vector3.Distance(this.Yandere.transform.position, base.transform.position);
		if (!this.Alarmed)
		{
			for (int i = 0; i < this.Boundary.Length; i++)
			{
				if (this.Boundary[i].bounds.Contains(this.Yandere.transform.position))
				{
					AudioSource.PlayClipAtPoint(this.CrunchSound, Camera.main.transform.position);
					this.TriggerAlarm();
				}
			}
			if (this.Distance < 0.5f)
			{
				this.TriggerAlarm();
			}
		}
		else
		{
			base.transform.LookAt(this.Yandere.transform.position);
		}
		if (this.Distance < this.MinimumDistance)
		{
			if (!this.Started)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.Subtitle.transform.localScale = new Vector3(1f, 1f, 1f);
					this.Subtitle.text = this.SpeechText[0];
					this.MyAudio.clip = this.SpeechClip[0];
					this.MyAudio.Play();
					this.Started = true;
					this.SpeechPhase++;
					return;
				}
			}
			else
			{
				this.MyAudio.pitch = Time.timeScale;
				if (!this.Alarmed)
				{
					if (this.SpeechPhase < this.SpeechTime.Length && !this.MyAudio.isPlaying)
					{
						this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
						this.MyAudio.Play();
						this.Subtitle.text = this.SpeechText[this.SpeechPhase];
						this.SpeechPhase++;
					}
				}
				else if (this.SpeechPhase < this.Limit && !this.MyAudio.isPlaying)
				{
					this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
					this.MyAudio.Play();
					this.Subtitle.text = this.SpeechText[this.SpeechPhase];
					this.SpeechPhase++;
				}
				if (this.MyAudio.isPlaying)
				{
					this.Jukebox.volume = 0.1f;
					return;
				}
				this.Jukebox.volume = 1f;
				return;
			}
		}
		else
		{
			this.Subtitle.text = "";
		}
	}

	private void TriggerAlarm()
	{
		this.MyAnimation.CrossFade("readyToFight_00");
		this.SpeechClip = this.AlarmedClip;
		this.SpeechText = this.AlarmedText;
		this.SpeechTime = this.AlarmedTime;
		this.Subtitle.text = "";
		this.Started = false;
		this.Alarmed = true;
		this.SpeechPhase = 0;
		this.Timer = 0f;
		this.MyAudio.Stop();
	}
}
