using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class EventManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript[] EventStudent;

	public Transform[] EventLocation;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public int[] EventSpeaker;

	public GameObject InterruptZone;

	public GameObject RivalLocker;

	public GameObject VoiceClip;

	public bool EventCheck;

	public bool EventOn;

	public bool Spoken;

	public int EventPhase;

	public float Timer;

	public float Scale;

	public virtual void Start()
	{
		this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.InterruptZone.active = false;
		if (PlayerPrefs.GetInt("Weekday") == 1)
		{
			this.EventCheck = true;
		}
		if (PlayerPrefs.GetInt("Event1") == 1)
		{
			this.RivalLocker.active = true;
		}
	}

	public virtual void Update()
	{
		if (!this.Clock.StopTime && this.EventCheck)
		{
			if (this.EventStudent[1] == null)
			{
				this.EventStudent[1] = this.StudentManager.Students[5];
			}
			else if (this.EventStudent[1].Dead)
			{
				this.EventCheck = false;
				this.enabled = false;
			}
			if (this.EventStudent[2] == null)
			{
				this.EventStudent[2] = this.StudentManager.Students[6];
			}
			else if (this.EventStudent[2].Dead)
			{
				this.EventCheck = false;
				this.enabled = false;
			}
			if (this.Clock.HourTime > 13.06f && this.EventStudent[1] != null && this.EventStudent[2] != null && this.EventStudent[1].Pathfinding.canMove && this.EventStudent[1].Pathfinding.canMove)
			{
				this.EventStudent[1].CurrentDestination = this.EventLocation[1];
				this.EventStudent[1].Pathfinding.target = this.EventLocation[1];
				this.EventStudent[1].EventManager = this;
				this.EventStudent[1].InEvent = true;
				this.EventStudent[2].CurrentDestination = this.EventLocation[2];
				this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
				this.EventStudent[2].EventManager = this;
				this.EventStudent[2].InEvent = true;
				this.EventCheck = false;
				this.EventOn = true;
			}
		}
		if (this.EventOn)
		{
			if (this.Clock.HourTime > 13.5f)
			{
				this.EndEvent();
			}
			else
			{
				if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[1].Private)
				{
					this.EventStudent[1].Character.animation.CrossFade(this.EventStudent[1].IdleAnim);
					this.EventStudent[1].Private = true;
					this.StudentManager.UpdateStudents();
				}
				if (!this.EventStudent[2].Pathfinding.canMove && !this.EventStudent[2].Private)
				{
					this.EventStudent[2].Character.animation.CrossFade(this.EventStudent[2].IdleAnim);
					this.EventStudent[2].Private = true;
					this.StudentManager.UpdateStudents();
				}
				if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[2].Pathfinding.canMove)
				{
					if (!this.InterruptZone.active)
					{
						this.InterruptZone.active = true;
					}
					if (!this.Spoken)
					{
						this.EventStudent[this.EventSpeaker[this.EventPhase]].Character.animation.CrossFade(this.EventAnim[this.EventPhase]);
						this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
						this.PlayClip(this.EventClip[this.EventPhase], this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position + Vector3.up * 1.5f);
						this.Spoken = true;
					}
					else
					{
						this.Timer += Time.deltaTime;
						if (this.Timer > this.EventClip[this.EventPhase].length)
						{
							this.EventSubtitle.text = string.Empty;
						}
						float num;
						if (this.Yandere.transform.position.y < this.EventStudent[1].transform.position.y - (float)1)
						{
							this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
						}
						else
						{
							num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position);
							if (num < (float)10)
							{
								this.Scale = Mathf.Abs((num - (float)10) * 0.2f);
								if (this.Scale < (float)0)
								{
									this.Scale = (float)0;
								}
								if (this.Scale > (float)1)
								{
									this.Scale = (float)1;
								}
								this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
							}
							else
							{
								this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
							}
						}
						if (this.EventStudent[this.EventSpeaker[this.EventPhase]].Character.animation[this.EventAnim[this.EventPhase]].time >= this.EventStudent[this.EventSpeaker[this.EventPhase]].Character.animation[this.EventAnim[this.EventPhase]].length)
						{
							this.EventStudent[this.EventSpeaker[this.EventPhase]].Character.animation.CrossFade(this.EventStudent[this.EventSpeaker[this.EventPhase]].IdleAnim);
						}
						if (this.Timer > this.EventClip[this.EventPhase].length + (float)1)
						{
							this.Spoken = false;
							this.EventPhase++;
							this.Timer = (float)0;
							if (this.EventPhase == Extensions.get_length(this.EventSpeech))
							{
								this.EndEvent();
							}
						}
						if (this.EventPhase == 7 && num < (float)5 && !this.RivalLocker.active)
						{
							this.Yandere.NotificationManager.DisplayNotification("Info");
							PlayerPrefs.SetInt("Event1", 1);
							this.RivalLocker.active = true;
						}
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
		this.EventStudent[1].CurrentDestination = this.EventStudent[1].Destinations[this.EventStudent[1].Phase];
		this.EventStudent[1].Pathfinding.target = this.EventStudent[1].Destinations[this.EventStudent[1].Phase];
		this.EventStudent[1].EventManager = null;
		this.EventStudent[1].InEvent = false;
		this.EventStudent[1].Private = false;
		this.EventStudent[2].CurrentDestination = this.EventStudent[2].Destinations[this.EventStudent[2].Phase];
		this.EventStudent[2].Pathfinding.target = this.EventStudent[2].Destinations[this.EventStudent[2].Phase];
		this.EventStudent[2].EventManager = null;
		this.EventStudent[2].InEvent = false;
		this.EventStudent[2].Private = false;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents();
		}
		this.InterruptZone.active = false;
		this.Yandere.Trespassing = false;
		this.EventSubtitle.text = string.Empty;
		this.EventCheck = false;
		this.EventOn = false;
	}

	public virtual void Main()
	{
	}
}
