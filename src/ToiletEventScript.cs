using System;
using UnityEngine;

[Serializable]
public class ToiletEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public LightSwitchScript LightSwitch;

	public BucketPourScript BucketPour;

	public ParticleSystem Splashes;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public DoorScript StallDoor;

	public PromptScript Prompt;

	public ClockScript Clock;

	public Collider Toilet;

	public StudentScript EventStudent;

	public Transform[] EventLocation;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventCheck;

	public bool EventOver;

	public float EventTime;

	public int EventPhase;

	public int EventDay;

	public float ToiletCountdown;

	public float Distance;

	public float Timer;

	public ToiletEventScript()
	{
		this.EventTime = 7f;
		this.EventPhase = 1;
		this.EventDay = 4;
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
		if (!this.Clock.StopTime && this.EventCheck && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[6];
			if (this.EventStudent != null && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Alarmed)
			{
				if (!this.EventStudent.WitnessedMurder)
				{
					this.EventStudent.CurrentDestination = this.EventLocation[1];
					this.EventStudent.Pathfinding.target = this.EventLocation[1];
					this.EventStudent.Pathfinding.canMove = true;
					this.EventStudent.LightSwitch = this.LightSwitch;
					this.EventStudent.Obstacle.checkTime = (float)99;
					this.EventStudent.ToiletEvent = this;
					this.EventStudent.InEvent = true;
					this.EventStudent.Prompt.Hide();
					this.Prompt.enabled = true;
					this.EventCheck = false;
					this.EventActive = true;
					if (this.EventStudent.Following)
					{
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
			if (this.Prompt.Circle[0].fillAmount <= (float)0)
			{
				this.Yandere.EmptyHands();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.EventPhase = 5;
				this.Timer = (float)0;
				this.PlayClip(this.EventClip[1], this.EventStudent.transform.position + Vector3.up * 1.5f);
				this.EventSubtitle.text = this.EventSpeech[1];
				this.EventStudent.MyController.enabled = false;
				this.EventStudent.Distracted = true;
				this.EventStudent.Routine = false;
				this.EventStudent.Drowned = true;
				this.Yandere.TargetStudent = this.EventStudent;
				this.Yandere.Attacking = true;
				this.Yandere.CanMove = false;
				this.Yandere.Drown = true;
				if (this.EventDay == 4)
				{
					this.Yandere.DrownAnim = "f02_toiletDrownA_00";
					this.EventStudent.DrownAnim = "f02_toiletDrownB_00";
				}
				else
				{
					this.Yandere.DrownAnim = "f02_fountainDrownA_00";
					this.EventStudent.DrownAnim = "f02_fountainDrownB_00";
				}
				this.EventStudent.Character.animation.CrossFade(this.EventStudent.DrownAnim);
			}
			if (this.Clock.HourTime > this.EventTime + 0.5f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed)
			{
				this.EndEvent();
			}
			else if (!this.EventStudent.Alarmed)
			{
				if (!this.EventStudent.Pathfinding.canMove)
				{
					if (this.EventPhase == 1)
					{
						if (this.Timer == (float)0)
						{
							this.EventStudent.Character.animation.CrossFade(this.EventStudent.IdleAnim);
							this.Prompt.HideButton[0] = false;
							this.EventStudent.Prompt.Hide();
							this.EventStudent.Prompt.enabled = false;
							if (this.EventDay == 4)
							{
								this.StallDoor.Prompt.enabled = false;
								this.StallDoor.Prompt.Hide();
							}
						}
						this.Timer += Time.deltaTime;
						if (this.Timer > (float)3)
						{
							if (this.EventDay == 4)
							{
								this.StallDoor.Locked = true;
								this.StallDoor.CloseDoor();
								this.Toilet.enabled = false;
								this.Prompt.Hide();
								this.Prompt.enabled = false;
							}
							this.EventStudent.CurrentDestination = this.EventLocation[2];
							this.EventStudent.Pathfinding.target = this.EventLocation[2];
							this.EventStudent.TargetDistance = (float)2;
							this.EventPhase++;
							this.Timer = (float)0;
						}
					}
					else if (this.EventPhase == 2)
					{
						if (this.Timer == (float)0)
						{
							this.EventStudent.Character.animation.CrossFade(this.EventAnim[1]);
							if (this.EventDay == 4)
							{
								this.BucketPour.enabled = true;
							}
						}
						this.Timer += Time.deltaTime;
						if (this.Timer > (float)10)
						{
							if (this.EventDay == 4)
							{
								this.PlayClip(this.EventClip[2], this.Toilet.transform.position);
								this.EventPhase++;
								this.Timer = (float)0;
							}
							else
							{
								this.EndEvent();
							}
						}
					}
					else if (this.EventPhase == 3)
					{
						this.Timer += Time.deltaTime;
						if (this.Timer > (float)4)
						{
							this.EventStudent.CurrentDestination = this.EventLocation[3];
							this.EventStudent.Pathfinding.target = this.EventLocation[3];
							this.EventStudent.TargetDistance = (float)2;
							this.StallDoor.gameObject.active = true;
							this.StallDoor.Prompt.enabled = true;
							this.StallDoor.Locked = false;
							this.EventPhase++;
							this.Timer = (float)0;
						}
					}
					else if (this.EventPhase == 4)
					{
						this.EventStudent.Character.animation.CrossFade("f02_washHands_00");
						this.Timer += Time.deltaTime;
						if (this.Timer > (float)5)
						{
							this.EndEvent();
						}
					}
					else if (this.EventPhase == 5)
					{
						this.Timer += Time.deltaTime;
						if (this.Timer > (float)9)
						{
							this.Splashes.Stop();
							this.EventOver = true;
							this.EndEvent();
						}
						else if (this.Timer > (float)3)
						{
							this.EventSubtitle.text = string.Empty;
							this.Splashes.Play();
						}
					}
					this.Distance = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
					if (this.Distance < (float)10)
					{
						float num = Mathf.Abs((this.Distance - (float)10) * 0.2f);
						if (num < (float)0)
						{
							num = (float)0;
						}
						if (num > (float)1)
						{
							num = (float)1;
						}
						this.EventSubtitle.transform.localScale = new Vector3(num, num, num);
					}
					else
					{
						this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
					}
				}
			}
			else
			{
				this.EndEvent();
			}
		}
		if (this.EventDay == 4 && this.ToiletCountdown > (float)0)
		{
			this.ToiletCountdown -= Time.deltaTime;
			if (this.ToiletCountdown < (float)0)
			{
				this.Toilet.enabled = true;
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
			this.EventStudent.TargetDistance = (float)1;
			this.EventStudent.ToiletEvent = null;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents();
		}
		if (this.EventDay == 4)
		{
			this.StallDoor.gameObject.active = true;
			this.StallDoor.Prompt.enabled = true;
			this.StallDoor.Locked = false;
			this.BucketPour.enabled = false;
			this.BucketPour.Prompt.Hide();
			this.BucketPour.Prompt.enabled = false;
		}
		this.EventActive = false;
		this.EventCheck = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.ToiletCountdown = (float)1;
	}

	public virtual void Main()
	{
	}
}
