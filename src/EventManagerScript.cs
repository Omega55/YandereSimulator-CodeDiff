using System;
using UnityEngine;

public class EventManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public NoteLockerScript NoteLocker;

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

	public GameObject VoiceClip;

	public bool EventCheck;

	public bool EventOn;

	public bool Spoken;

	public int EventPhase;

	public float Timer;

	public float Scale;

	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		this.InterruptZone.SetActive(false);
		if (PlayerPrefs.GetInt("Weekday") == 1)
		{
			this.EventCheck = true;
		}
		this.NoteLocker.Prompt.enabled = true;
		this.NoteLocker.CanLeaveNote = true;
	}

	private void Update()
	{
		if (!this.Clock.StopTime && this.EventCheck)
		{
			if (this.EventStudent[1] == null)
			{
				this.EventStudent[1] = this.StudentManager.Students[6];
			}
			else if (this.EventStudent[1].Dead)
			{
				this.EventCheck = false;
				base.enabled = false;
			}
			if (this.EventStudent[2] == null)
			{
				this.EventStudent[2] = this.StudentManager.Students[7];
			}
			else if (this.EventStudent[2].Dead)
			{
				this.EventCheck = false;
				base.enabled = false;
			}
			if (this.Clock.HourTime > 13.01f && this.EventStudent[1] != null && this.EventStudent[2] != null && this.EventStudent[1].Pathfinding.canMove && this.EventStudent[1].Pathfinding.canMove)
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
			float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position);
			if (this.Clock.HourTime > 13.5f || this.EventStudent[1].WitnessedCorpse || this.EventStudent[2].WitnessedCorpse || this.EventStudent[1].Dying || this.EventStudent[2].Dying || this.EventStudent[2].Splashed)
			{
				this.EndEvent();
			}
			else
			{
				if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[1].Private)
				{
					this.EventStudent[1].Character.GetComponent<Animation>().CrossFade(this.EventStudent[1].IdleAnim);
					this.EventStudent[1].Private = true;
					this.StudentManager.UpdateStudents();
				}
				if (!this.EventStudent[2].Pathfinding.canMove && !this.EventStudent[2].Private)
				{
					this.EventStudent[2].Character.GetComponent<Animation>().CrossFade(this.EventStudent[2].IdleAnim);
					this.EventStudent[2].Private = true;
					this.StudentManager.UpdateStudents();
				}
				if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[2].Pathfinding.canMove)
				{
					if (!this.InterruptZone.activeInHierarchy)
					{
						this.InterruptZone.SetActive(true);
					}
					if (!this.Spoken)
					{
						this.EventStudent[this.EventSpeaker[this.EventPhase]].Character.GetComponent<Animation>().CrossFade(this.EventAnim[this.EventPhase]);
						if (num < 10f)
						{
							this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
						}
						this.PlayClip(this.EventClip[this.EventPhase], this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position + Vector3.up * 1.5f);
						this.Spoken = true;
					}
					else
					{
						if (this.Yandere.transform.position.z > 0f)
						{
							this.Timer += Time.deltaTime;
							if (this.Timer > this.EventClip[this.EventPhase].length)
							{
								this.EventSubtitle.text = string.Empty;
							}
							if (this.Yandere.transform.position.y < this.EventStudent[1].transform.position.y - 1f)
							{
								this.EventSubtitle.transform.localScale = Vector3.zero;
							}
							else if (num < 10f)
							{
								this.Scale = Mathf.Abs((num - 10f) * 0.2f);
								if (this.Scale < 0f)
								{
									this.Scale = 0f;
								}
								if (this.Scale > 1f)
								{
									this.Scale = 1f;
								}
								this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
							}
							else
							{
								this.EventSubtitle.transform.localScale = Vector3.zero;
							}
							Animation component = this.EventStudent[this.EventSpeaker[this.EventPhase]].Character.GetComponent<Animation>();
							if (component[this.EventAnim[this.EventPhase]].time >= component[this.EventAnim[this.EventPhase]].length)
							{
								component.CrossFade(this.EventStudent[this.EventSpeaker[this.EventPhase]].IdleAnim);
							}
							if (this.Timer > this.EventClip[this.EventPhase].length + 1f)
							{
								this.Spoken = false;
								this.EventPhase++;
								this.Timer = 0f;
								if (this.EventPhase == 4)
								{
									if (PlayerPrefs.GetInt("Topic_22_Discovered") == 0)
									{
										this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
										PlayerPrefs.SetInt("Topic_22_Discovered", 1);
									}
									if (PlayerPrefs.GetInt("Topic_22_Student_7_Learned") == 0)
									{
										this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
										PlayerPrefs.SetInt("Topic_22_Student_7_Learned", 1);
									}
								}
								if (this.EventPhase == this.EventSpeech.Length)
								{
									this.EndEvent();
								}
							}
						}
						if (this.Yandere.transform.position.y > this.EventStudent[1].transform.position.y - 1f && this.EventPhase == 7 && num < 5f && PlayerPrefs.GetInt("Event1") == 0)
						{
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
							PlayerPrefs.SetInt("Event1", 1);
						}
					}
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
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = 5f;
		audioSource.maxDistance = 10f;
		audioSource.spatialBlend = 1f;
		this.VoiceClip = gameObject;
		audioSource.volume = ((this.Yandere.transform.position.y >= gameObject.transform.position.y - 2f) ? 1f : 0f);
	}

	public void EndEvent()
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
		this.InterruptZone.SetActive(false);
		this.Yandere.Trespassing = false;
		this.EventSubtitle.text = string.Empty;
		this.EventCheck = false;
		this.EventOn = false;
	}
}
