using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RivalMorningEventManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript Senpai;

	public StudentScript Rival;

	public Transform[] Location;

	public Transform Epicenter;

	public int RivalStudentID;

	public string RivalName;

	public GameObject RivalHairstyle;

	public string RivalIdle;

	public AudioClip SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool Spoken;

	public float Distance;

	public float Scale;

	public float Timer;

	public int Phase;

	public int Frame;

	public virtual void Start()
	{
		this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		if (PlayerPrefs.GetInt("Weekday") != 1)
		{
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (this.Phase == -1)
		{
			this.Frame++;
			if (this.Frame > 2)
			{
				this.Senpai = this.StudentManager.Students[1];
				this.Rival = this.StudentManager.Students[33];
				this.Senpai.CharacterAnimation.Play(this.Senpai.IdleAnim);
				this.Senpai.transform.position = this.Location[1].position;
				this.Senpai.transform.eulerAngles = this.Location[1].eulerAngles;
				this.Senpai.Pathfinding.canSearch = false;
				this.Senpai.Pathfinding.canMove = false;
				this.Senpai.Routine = false;
				this.Senpai.InEvent = true;
				this.Senpai.Prompt.Hide();
				this.Senpai.Prompt.enabled = false;
				this.Rival.CharacterAnimation.Play(this.Rival.IdleAnim);
				this.Rival.transform.position = this.Location[2].position;
				this.Rival.transform.eulerAngles = this.Location[2].eulerAngles;
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Routine = false;
				this.Rival.InEvent = true;
				this.Rival.Prompt.Hide();
				this.Rival.Prompt.enabled = false;
				this.Phase++;
			}
		}
		else if (this.Phase == 0)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)1)
			{
				this.PlayClip(this.SpeechClip, this.Epicenter.position + Vector3.up * 1.5f);
				this.Rival.CharacterAnimation.CrossFade("f02_Monday_1");
				this.Senpai.CharacterAnimation.CrossFade("Monday_1");
				this.Timer = (float)0;
				this.Phase++;
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.Phase < Extensions.get_length(this.SpeechTime))
			{
				if (this.Timer > this.SpeechTime[this.Phase])
				{
					this.EventSubtitle.text = this.SpeechText[this.Phase];
					this.Phase++;
				}
			}
			else if (this.Rival.CharacterAnimation["f02_Monday_1"].time >= this.Rival.CharacterAnimation["f02_Monday_1"].length)
			{
				this.EndEvent();
			}
			this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Epicenter.position);
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
		this.Senpai.Pathfinding.canSearch = true;
		this.Senpai.Pathfinding.canMove = true;
		this.Senpai.InEvent = false;
		this.Senpai.Private = false;
		this.Senpai.Routine = true;
		this.Rival.Pathfinding.canSearch = true;
		this.Rival.Pathfinding.canMove = true;
		this.Rival.Prompt.enabled = true;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		this.Rival.Routine = true;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents();
		}
		this.EventSubtitle.text = string.Empty;
		this.EventActive = false;
		this.enabled = false;
	}

	public virtual void Main()
	{
	}
}
