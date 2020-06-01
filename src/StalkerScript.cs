using System;
using UnityEngine;

public class StalkerScript : MonoBehaviour
{
	public StalkerYandereScript Yandere;

	public AudioClip CrunchSound;

	public Animation MyAnimation;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

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
				this.Subtitle.text = this.SpeechText[0];
				this.MyAudio.Play();
				this.Started = true;
				return;
			}
			this.MyAudio.pitch = Time.timeScale;
			if (this.SpeechPhase < this.SpeechTime.Length && this.MyAudio.time > this.SpeechTime[this.SpeechPhase])
			{
				this.Subtitle.text = this.SpeechText[this.SpeechPhase];
				this.SpeechPhase++;
			}
			this.Scale = Mathf.Abs(1f - (this.Distance - 1f) / (this.MinimumDistance - 1f));
			if (this.Scale < 0f)
			{
				this.Scale = 0f;
			}
			if (this.Scale > 1f)
			{
				this.Scale = 1f;
			}
			this.Jukebox.volume = 1f - 0.9f * this.Scale;
			this.Subtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
			this.MyAudio.volume = this.Scale;
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
		this.MyAudio.Stop();
	}
}
