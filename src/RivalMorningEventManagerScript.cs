﻿using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RivalMorningEventManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public SpyScript Spy;

	public StudentScript Senpai;

	public StudentScript Rival;

	public Transform[] Location;

	public Transform Epicenter;

	public AudioClip SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool Transfer;

	public float TransferTime;

	public float Distance;

	public float Scale;

	public float Timer;

	public int SpeechPhase;

	public int EventDay;

	public int Phase;

	public int Frame;

	public string Weekday;

	public RivalMorningEventManagerScript()
	{
		this.SpeechPhase = 1;
		this.Weekday = string.Empty;
	}

	public virtual void Start()
	{
		this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		if (PlayerPrefs.GetInt("Weekday") != this.EventDay)
		{
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0 && this.StudentManager.Students[1].active && this.StudentManager.Students[33] != null)
			{
				this.Senpai = this.StudentManager.Students[1];
				this.Rival = this.StudentManager.Students[33];
				this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Senpai.CharacterAnimation.Play(this.Senpai.IdleAnim);
				this.Senpai.transform.position = this.Location[1].position;
				this.Senpai.transform.eulerAngles = this.Location[1].eulerAngles;
				this.Senpai.Pathfinding.canSearch = false;
				this.Senpai.Pathfinding.canMove = false;
				this.Senpai.Routine = false;
				this.Senpai.InEvent = true;
				this.Senpai.Prompt.Hide();
				this.Senpai.Prompt.enabled = false;
				this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Rival.CharacterAnimation.Play(this.Rival.IdleAnim);
				this.Rival.transform.position = this.Location[2].position;
				this.Rival.transform.eulerAngles = this.Location[2].eulerAngles;
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Routine = false;
				this.Rival.InEvent = true;
				this.Rival.Prompt.Hide();
				this.Rival.Prompt.enabled = false;
				this.Spy.Prompt.enabled = true;
				this.Phase++;
				if (this.EventDay == 2)
				{
					this.StudentManager.Students[1].EventBook.active = true;
				}
			}
			this.Frame++;
		}
		else if (this.Phase == 1)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)1)
			{
				this.PlayClip(this.SpeechClip, this.Epicenter.position + Vector3.up * 1.5f);
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.Weekday + "_1");
				this.Senpai.CharacterAnimation.CrossFade(string.Empty + this.Weekday + "_1");
				this.Timer = (float)0;
				this.Phase++;
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.VoiceClip != null)
			{
				this.VoiceClip.audio.pitch = Time.timeScale;
			}
			if (this.SpeechPhase < Extensions.get_length(this.SpeechTime))
			{
				if (this.Timer > this.SpeechTime[this.SpeechPhase])
				{
					this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
					this.SpeechPhase++;
				}
			}
			else if (this.Rival.CharacterAnimation["f02_" + this.Weekday + "_1"].time >= this.Rival.CharacterAnimation["f02_" + this.Weekday + "_1"].length)
			{
				this.EndEvent();
			}
			if (this.Transfer && this.Rival.CharacterAnimation["f02_" + this.Weekday + "_1"].time > this.TransferTime)
			{
				this.Senpai.DestinationNames[2] = "Patrol";
				this.Senpai.DestinationNames[6] = "Patrol";
				this.Senpai.ActionNames[2] = "Patrol";
				this.Senpai.ActionNames[6] = "Patrol";
				this.Senpai.GetDestinations();
				this.Senpai.EventBook.active = false;
				this.Rival.EventBook.active = true;
				this.Transfer = false;
			}
			if (this.Clock.Period > 1)
			{
				this.EndEvent();
			}
			if (this.Senpai.Alarmed || this.Rival.Alarmed)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity);
				((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).NoScream = true;
				this.EndEvent();
			}
			this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Epicenter.position);
			if (this.enabled)
			{
				if (this.Distance - (float)4 < (float)15)
				{
					this.Scale = Mathf.Abs((float)1 - (this.Distance - (float)4) / (float)15);
					if (this.Scale < (float)0)
					{
						this.Scale = (float)0;
					}
					if (this.Scale > (float)1)
					{
						this.Scale = (float)1;
					}
					this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
					if (this.VoiceClip != null)
					{
						this.VoiceClip.audio.volume = this.Scale;
					}
					if (this.Distance < (float)5)
					{
						this.Yandere.Eavesdropping = true;
					}
					else
					{
						this.Yandere.Eavesdropping = false;
					}
				}
				else
				{
					this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
					if (this.VoiceClip != null)
					{
						this.VoiceClip.audio.volume = (float)0;
					}
				}
			}
		}
	}

	public virtual void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = (float)5;
		audioSource.maxDistance = (float)10;
		this.VoiceClip = gameObject;
		if (this.Yandere.transform.position.y < gameObject.transform.position.y - (float)2)
		{
			audioSource.volume = (float)0;
		}
		else
		{
			audioSource.volume = (float)1;
		}
	}

	public virtual void EndEvent()
	{
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (!this.Senpai.Alarmed)
		{
			this.Senpai.Pathfinding.canSearch = true;
			this.Senpai.Pathfinding.canMove = true;
			this.Senpai.Routine = true;
		}
		this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Senpai.EventBook.active = false;
		this.Senpai.InEvent = false;
		this.Senpai.Private = false;
		if (!this.Rival.Alarmed)
		{
			this.Rival.Pathfinding.canSearch = true;
			this.Rival.Pathfinding.canMove = true;
			this.Rival.Routine = true;
		}
		this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Rival.EventBook.active = false;
		this.Rival.Prompt.enabled = true;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents();
		}
		this.Spy.Prompt.Hide();
		this.Spy.Prompt.enabled = false;
		if (this.Spy.Phase > 0)
		{
			this.Spy.End();
		}
		this.Yandere.Eavesdropping = false;
		this.EventSubtitle.text = string.Empty;
		this.enabled = false;
	}

	public virtual void Main()
	{
	}
}
