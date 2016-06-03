using System;
using UnityEngine;

[Serializable]
public class BatheEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript EventStudent;

	public UILabel EventSubtitle;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public GameObject RivalPhone;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventOver;

	public float EventTime;

	public int EventPhase;

	public int EventDay;

	public Vector3 OriginalPosition;

	public float CurrentClipLength;

	public float Timer;

	public BatheEventScript()
	{
		this.EventTime = 15.1f;
		this.EventPhase = 1;
		this.EventDay = 4;
	}

	public virtual void Start()
	{
		this.RivalPhone.active = false;
		if (PlayerPrefs.GetInt("Weekday") != this.EventDay)
		{
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (!this.Clock.StopTime && !this.EventActive && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[7];
			if (this.EventStudent != null && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Meeting)
			{
				if (!this.EventStudent.WitnessedMurder)
				{
					this.OriginalPosition = this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition;
					this.EventStudent.CurrentDestination = this.StudentManager.StripSpot;
					this.EventStudent.Pathfinding.target = this.StudentManager.StripSpot;
					this.EventStudent.Character.animation.CrossFade(this.EventStudent.WalkAnim);
					this.EventStudent.Pathfinding.canSearch = true;
					this.EventStudent.Pathfinding.canMove = true;
					this.EventStudent.Pathfinding.speed = (float)1;
					this.EventStudent.DistanceToDestination = (float)100;
					this.EventStudent.Obstacle.checkTime = (float)99;
					this.EventStudent.InEvent = true;
					this.EventStudent.Private = true;
					this.EventStudent.Prompt.Hide();
					this.EventActive = true;
					if (this.EventStudent.Following)
					{
						this.EventStudent.Pathfinding.canMove = true;
						this.EventStudent.Pathfinding.speed = (float)1;
						this.EventStudent.Following = false;
						this.EventStudent.Routine = true;
						this.Yandere.Followers = this.Yandere.Followers - 1;
						this.EventStudent.Subtitle.UpdateLabel("Stop Follow Apology", 0, (float)3);
						this.EventStudent.Prompt.Label[0].text = "     " + "Talk";
					}
				}
				else
				{
					this.enabled = false;
				}
			}
		}
		if (this.EventActive)
		{
			if (this.Clock.HourTime > this.EventTime + (float)1 || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying || this.EventStudent.Dead)
			{
				this.EndEvent();
			}
			else
			{
				if (this.EventStudent.DistanceToDestination < 0.5f)
				{
					if (this.EventPhase == 1)
					{
						this.EventStudent.Routine = false;
						this.EventStudent.BathePhase = 1;
						this.EventStudent.Wet = true;
						this.EventPhase++;
					}
					else if (this.EventPhase == 2)
					{
						if (this.EventStudent.BathePhase == 4)
						{
							this.RivalPhone.active = true;
							this.EventPhase++;
						}
					}
					else if (this.EventPhase == 3 && !this.EventStudent.Wet)
					{
						if (!this.RivalPhone.active)
						{
							this.EventStudent.Character.animation.CrossFade(this.EventAnim[0]);
							this.EventStudent.Pathfinding.canSearch = false;
							this.EventStudent.Pathfinding.canMove = false;
							this.EventStudent.Routine = false;
							this.StudentManager.CommunalLocker.Open = true;
							this.EventSubtitle.text = this.EventSpeech[0];
							this.PlayClip(this.EventClip[0], this.EventStudent.transform.position + Vector3.up);
							this.EventPhase++;
						}
						else
						{
							this.EndEvent();
						}
					}
				}
				if (this.EventPhase == 4)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > this.CurrentClipLength + (float)1)
					{
						this.EventStudent.Routine = true;
						this.EndEvent();
					}
				}
				float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
				if (num < (float)11)
				{
					if (num < (float)10)
					{
						float num2 = Mathf.Abs((num - (float)10) * 0.2f);
						if (num2 < (float)0)
						{
							num2 = (float)0;
						}
						if (num2 > (float)1)
						{
							num2 = (float)1;
						}
						this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
					}
					else
					{
						this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
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
		this.CurrentClipLength = clip.length;
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = (float)5;
		audioSource.maxDistance = (float)10;
		this.VoiceClip = gameObject;
	}

	public virtual void EndEvent()
	{
		if (!this.EventOver)
		{
			if (this.VoiceClip != null)
			{
				UnityEngine.Object.Destroy(this.VoiceClip);
			}
			this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Obstacle.checkTime = (float)1;
			if (!this.EventStudent.Dying)
			{
				this.EventStudent.Prompt.enabled = true;
			}
			this.EventStudent.Pathfinding.canSearch = true;
			this.EventStudent.Pathfinding.canMove = true;
			this.EventStudent.Pathfinding.speed = (float)1;
			this.EventStudent.TargetDistance = (float)1;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents();
		}
		this.EventActive = false;
		this.enabled = false;
	}

	public virtual void Main()
	{
	}
}
