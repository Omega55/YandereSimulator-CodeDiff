using System;
using UnityEngine;

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

	public int EventStudentID = 7;

	public float EventTime = 7.5f;

	public int EventPhase = 1;

	public int EventDay = 1;

	public float CurrentClipLength;

	public float FailSafe;

	public float Timer;

	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (PlayerPrefs.GetInt("Weekday") == this.EventDay)
		{
			this.EventCheck = true;
		}
	}

	private void Update()
	{
		if (!this.Clock.StopTime && this.EventCheck)
		{
			if (this.Clock.HourTime > this.EventTime + 0.5f)
			{
				base.enabled = false;
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
						this.EventStudent.Obstacle.checkTime = 99f;
						this.EventStudent.SpeechLines.Stop();
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
							this.EventStudent.Pathfinding.speed = 1f;
							this.EventStudent.Following = false;
							this.EventStudent.Routine = true;
							this.Yandere.Followers--;
							this.EventStudent.Subtitle.UpdateLabel("Stop Follow Apology", 0, 3f);
							this.EventStudent.Prompt.Label[0].text = "     Talk";
						}
					}
					else
					{
						base.enabled = false;
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
					this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[0]);
					this.PlayClip(this.EventClip[0], this.EventStudent.transform.position);
					this.EventPhase++;
				}
				else if (this.EventPhase == 2)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1.5f)
					{
						if (this.EventStudent.StudentID == 33)
						{
							this.EventStudent.SmartPhone.SetActive(true);
						}
						else
						{
							this.EventStudent.Phone.SetActive(true);
						}
					}
					if (this.Timer > 3f)
					{
						this.PlayClip(this.EventClip[1], this.EventStudent.transform.position);
						this.EventSubtitle.text = this.EventSpeech[1];
						this.Timer = 0f;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 3)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > this.CurrentClipLength)
					{
						this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.RunAnim);
						this.EventStudent.CurrentDestination = this.EventLocation;
						this.EventStudent.Pathfinding.target = this.EventLocation;
						this.EventStudent.Pathfinding.canSearch = true;
						this.EventStudent.Pathfinding.canMove = true;
						this.EventStudent.Pathfinding.speed = 4f;
						this.EventSubtitle.text = string.Empty;
						this.Timer = 0f;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 4)
				{
					this.DumpPoint.enabled = true;
					this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[2]);
					this.PlayClip(this.EventClip[2], this.EventStudent.transform.position);
					this.EventPhase++;
				}
				else if (this.EventPhase < 13)
				{
					if (this.VoiceClip != null)
					{
						this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
						this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time = this.VoiceClip.GetComponent<AudioSource>().time;
						if (this.VoiceClip.GetComponent<AudioSource>().time > this.SpeechTimes[this.EventPhase - 3])
						{
							this.EventSubtitle.text = this.EventSpeech[this.EventPhase - 3];
							this.EventPhase++;
						}
					}
				}
				else
				{
					if (this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time >= this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].length * 90.33333f)
					{
						if (this.EventStudent.StudentID == 33)
						{
							this.EventStudent.SmartPhone.SetActive(true);
						}
						else
						{
							this.EventStudent.Phone.SetActive(true);
						}
					}
					if (this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time >= this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].length)
					{
						this.EndEvent();
					}
				}
				float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
				if (num < 10f)
				{
					float num2 = Mathf.Abs((num - 10f) * 0.2f);
					if (num2 < 0f)
					{
						num2 = 0f;
					}
					if (num2 > 1f)
					{
						num2 = 1f;
					}
					this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
				}
				else
				{
					this.EventSubtitle.transform.localScale = Vector3.zero;
				}
				if (this.EventPhase == 11 && num < 5f && PlayerPrefs.GetInt("Event2") == 0)
				{
					PlayerPrefs.SetInt("Event2", 1);
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
					PlayerPrefs.SetInt("Topic_25_Discovered", 1);
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
					PlayerPrefs.SetInt("Topic_25_Student_" + this.EventStudentID.ToString() + "_Learned", 1);
				}
			}
		}
	}

	private void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		this.CurrentClipLength = clip.length;
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = 5f;
		audioSource.maxDistance = 10f;
		audioSource.spatialBlend = 1f;
		this.VoiceClip = gameObject;
	}

	private void EndEvent()
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
			this.EventStudent.Obstacle.checkTime = 1f;
			if (!this.EventStudent.Dying)
			{
				this.EventStudent.Prompt.enabled = true;
			}
			this.EventStudent.SmartPhone.SetActive(false);
			this.EventStudent.Pathfinding.speed = 1f;
			this.EventStudent.Phone.SetActive(false);
			this.EventStudent.TargetDistance = 1f;
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
}
