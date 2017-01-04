using System;
using UnityEngine;

[Serializable]
public class PhoneEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public BucketPourScript DumpPoint;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript EventStudent;

	public UILabel EventSubtitle;

	public Transform EventLocation;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public float[] SpeechTimes;

	public string[] EventAnim;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventCheck;

	public bool EventOver;

	public int EventStudentID;

	public float EventTime;

	public int EventPhase;

	public int EventDay;

	public float CurrentClipLength;

	public float FailSafe;

	public float Timer;

	public PhoneEventScript()
	{
		this.EventStudentID = 7;
		this.EventTime = 7.5f;
		this.EventPhase = 1;
		this.EventDay = 1;
	}

	public virtual void Start()
	{
		this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		if (PlayerPrefs.GetInt("Weekday") == this.EventDay)
		{
			this.EventCheck = true;
		}
	}

	public virtual void Update()
	{
		if (!this.Clock.StopTime && this.EventCheck)
		{
			if (this.Clock.HourTime > this.EventTime + 0.5f)
			{
				this.enabled = false;
			}
			else if (this.Clock.HourTime > this.EventTime)
			{
				this.EventStudent = this.StudentManager.Students[this.EventStudentID];
				if (this.EventStudent != null && this.EventStudent.Routine && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Meeting && this.EventStudent.Indoors)
				{
					if (!this.EventStudent.WitnessedMurder)
					{
						this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
						this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
						this.EventStudent.Obstacle.checkTime = (float)99;
						this.EventStudent.PhoneEvent = this;
						this.EventStudent.CanTalk = false;
						this.EventStudent.InEvent = true;
						this.EventStudent.Private = true;
						this.EventStudent.Prompt.Hide();
						this.EventCheck = false;
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
		}
		if (this.EventActive)
		{
			if (this.EventStudent.DistanceToDestination < 0.5f)
			{
				this.EventStudent.Pathfinding.canSearch = false;
				this.EventStudent.Pathfinding.canMove = false;
			}
			if (this.Clock.HourTime > this.EventTime + 0.5f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying || this.EventStudent.Dead)
			{
				this.EndEvent();
			}
			else if (!this.EventStudent.Pathfinding.canMove)
			{
				if (this.EventPhase == 1)
				{
					this.Timer += Time.deltaTime;
					this.EventStudent.Character.animation.CrossFade(this.EventAnim[0]);
					this.PlayClip(this.EventClip[0], this.EventStudent.transform.position);
					this.EventPhase++;
				}
				else if (this.EventPhase == 2)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > (float)2)
					{
						this.EventStudent.Phone.active = true;
					}
					if (this.Timer > (float)4)
					{
						this.EventStudent.Character.animation.CrossFade(this.EventAnim[1]);
						this.PlayClip(this.EventClip[1], this.EventStudent.transform.position);
						this.EventSubtitle.text = this.EventSpeech[1];
						this.Timer = (float)0;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 3)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > this.CurrentClipLength)
					{
						this.EventStudent.Character.animation.CrossFade(this.EventStudent.RunAnim);
						this.EventStudent.CurrentDestination = this.EventLocation;
						this.EventStudent.Pathfinding.target = this.EventLocation;
						this.EventStudent.Pathfinding.canSearch = true;
						this.EventStudent.Pathfinding.canMove = true;
						this.EventStudent.Pathfinding.speed = (float)4;
						this.EventSubtitle.text = string.Empty;
						this.Timer = (float)0;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 4)
				{
					this.DumpPoint.enabled = true;
					this.EventStudent.Character.animation.CrossFade(this.EventAnim[2]);
					this.PlayClip(this.EventClip[2], this.EventStudent.transform.position);
					this.EventPhase++;
				}
				else if (this.EventPhase < 13)
				{
					if (this.VoiceClip != null)
					{
						this.VoiceClip.audio.pitch = Time.timeScale;
						this.EventStudent.Character.animation[this.EventAnim[2]].time = this.VoiceClip.audio.time;
						if (this.VoiceClip.audio.time > this.SpeechTimes[this.EventPhase - 3])
						{
							this.EventSubtitle.text = this.EventSpeech[this.EventPhase - 3];
							this.EventPhase++;
						}
					}
				}
				else if (this.EventStudent.Character.animation[this.EventAnim[2]].time >= this.EventStudent.Character.animation[this.EventAnim[2]].length)
				{
					this.EndEvent();
				}
				float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
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
				if (this.EventPhase == 11 && num < (float)5 && PlayerPrefs.GetInt("Event2") == 0)
				{
					PlayerPrefs.SetInt("Event2", 1);
					this.Yandere.NotificationManager.DisplayNotification("Info");
					PlayerPrefs.SetInt("Topic_25_Discovered", 1);
					this.Yandere.NotificationManager.DisplayNotification("Topic");
					this.Yandere.NotificationManager.DisplayNotification("Opinion");
					PlayerPrefs.SetInt("Topic_25_Student_" + this.EventStudentID + "_Learned", 1);
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
		Debug.Log("Osana's phone event ended.");
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
			this.EventStudent.Pathfinding.speed = (float)1;
			this.EventStudent.Phone.active = false;
			this.EventStudent.TargetDistance = (float)1;
			this.EventStudent.PhoneEvent = null;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventStudent.CanTalk = true;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents();
			this.DumpPoint.enabled = false;
			this.DumpPoint.Prompt.Hide();
			this.DumpPoint.Prompt.enabled = false;
		}
		this.EventActive = false;
		this.EventCheck = false;
	}

	public virtual void Main()
	{
	}
}
