using System;
using UnityEngine;

[Serializable]
public class RingEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript EventStudent;

	public UILabel EventSubtitle;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventOver;

	public float EventTime;

	public int EventPhase;

	public Vector3 OriginalPosition;

	public float CurrentClipLength;

	public float Timer;

	public RingEventScript()
	{
		this.EventTime = 13.1f;
		this.EventPhase = 1;
	}

	public virtual void Update()
	{
		if (!this.Clock.StopTime && !this.EventActive && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[17];
			if (this.EventStudent != null && !this.EventStudent.Distracted && !this.EventStudent.Talking)
			{
				if (!this.EventStudent.WitnessedMurder)
				{
					if (this.EventStudent.Cosmetic.FemaleAccessories[3].active)
					{
						if (PlayerPrefs.GetInt("Scheme_2_Stage") < 100)
						{
							this.OriginalPosition = this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition;
							this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
							this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
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
					else
					{
						this.enabled = false;
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
					this.EventPhase++;
				}
				else if (this.EventPhase == 2)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > (float)5)
					{
						this.EventStudent.Character.animation.CrossFade(this.EventStudent.EatAnim);
						this.EventStudent.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, (float)0);
						this.EventStudent.Bento.transform.localEulerAngles = new Vector3((float)0, (float)165, 82.5f);
						this.EventStudent.Chopsticks[0].active = true;
						this.EventStudent.Chopsticks[1].active = true;
						this.EventStudent.Bento.active = true;
						this.EventPhase++;
						this.Timer = (float)0;
					}
					else if (this.Timer > (float)4)
					{
						if (this.EventStudent.Cosmetic.FemaleAccessories[3] != null)
						{
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.parent = null;
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.position = new Vector3(0.9f, 12.471f, -29.3f);
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.eulerAngles = new Vector3((float)-15, (float)-90, (float)0);
							((BoxCollider)this.EventStudent.Cosmetic.FemaleAccessories[3].GetComponent(typeof(BoxCollider))).enabled = true;
						}
					}
					else if (this.Timer > (float)2)
					{
						this.EventStudent.Cosmetic.FemaleAccessories[3].transform.parent = this.EventStudent.RightHand;
					}
				}
				else if (this.EventPhase == 3)
				{
					if (this.Clock.HourTime > 13.375f)
					{
						this.EventStudent.Bento.active = false;
						this.EventStudent.Chopsticks[0].active = false;
						this.EventStudent.Chopsticks[1].active = false;
						this.EventStudent.Character.animation[this.EventAnim[0]].time = this.EventStudent.Character.animation[this.EventAnim[0]].length;
						this.EventStudent.Character.animation[this.EventAnim[0]].speed = (float)-1;
						if (this.EventStudent.Cosmetic.FemaleAccessories[3] != null)
						{
							this.EventStudent.Character.animation.CrossFade(this.EventAnim[0]);
						}
						else
						{
							this.EventStudent.Character.animation.CrossFade(this.EventAnim[1]);
						}
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 4)
				{
					this.Timer += Time.deltaTime;
					if (this.EventStudent.Cosmetic.FemaleAccessories[3] != null)
					{
						if (this.Timer > (float)1)
						{
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.parent = this.EventStudent.RightHand;
						}
						if (this.Timer > (float)3)
						{
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.parent = this.EventStudent.LeftMiddleFinger;
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition = this.OriginalPosition;
							((BoxCollider)this.EventStudent.Cosmetic.FemaleAccessories[3].GetComponent(typeof(BoxCollider))).enabled = false;
						}
						if (this.Timer > (float)5)
						{
							this.EndEvent();
						}
					}
					else if (this.Timer > 1.5f && this.Yandere.transform.position.z < (float)0)
					{
						this.EventSubtitle.text = this.EventSpeech[0];
						this.PlayClip(this.EventClip[0], this.EventStudent.transform.position + Vector3.up);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 5)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 9.5f)
					{
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
