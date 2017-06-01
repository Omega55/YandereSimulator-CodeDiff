using System;
using UnityEngine;

[Serializable]
public class MovingEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public PortalScript Portal;

	public PromptScript Prompt;

	public ClockScript Clock;

	public StudentScript EventStudent;

	public Transform[] EventLocation;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public Collider BenchCollider;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventCheck;

	public bool EventOver;

	public bool Poisoned;

	public int EventPhase;

	public int EventDay;

	public float Distance;

	public float Timer;

	public MovingEventScript()
	{
		this.EventPhase = 1;
		this.EventDay = 3;
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
		if (!this.Clock.StopTime && this.EventCheck && this.Clock.HourTime > (float)13)
		{
			this.EventStudent = this.StudentManager.Students[7];
			if (this.EventStudent != null)
			{
				this.EventStudent.Character.animation[this.EventStudent.BentoAnim].weight = (float)1;
				this.EventStudent.CurrentDestination = this.EventLocation[0];
				this.EventStudent.Pathfinding.target = this.EventLocation[0];
				this.EventStudent.Bento.active = true;
				this.EventStudent.MovingEvent = this;
				this.EventStudent.InEvent = true;
				this.EventStudent.Private = true;
				this.EventCheck = false;
				this.EventActive = true;
			}
		}
		if (this.EventActive)
		{
			if (this.Prompt.Circle[0].fillAmount <= (float)0)
			{
				this.Portal.InEvent = true;
				this.Poisoned = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			if ((this.Clock.HourTime > 13.375f && !this.Poisoned) || this.EventStudent.Dying || this.EventStudent.Splashed)
			{
				this.EndEvent();
			}
			else
			{
				this.Distance = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
				if (!this.EventStudent.Alarmed && this.EventStudent.DistanceToDestination < this.EventStudent.TargetDistance && !this.EventStudent.Pathfinding.canMove)
				{
					if (this.EventPhase == 0)
					{
						this.EventStudent.Character.animation.CrossFade(this.EventStudent.IdleAnim);
						if (this.Clock.HourTime > 13.05f)
						{
							this.EventStudent.CurrentDestination = this.EventLocation[1];
							this.EventStudent.Pathfinding.target = this.EventLocation[1];
							this.EventPhase++;
						}
					}
					else if (this.EventPhase == 1)
					{
						if (!this.StudentManager.Students[1].WitnessedCorpse)
						{
							if (this.Timer == (float)0)
							{
								this.PlayClip(this.EventClip[1], this.EventStudent.transform.position + Vector3.up * 1.5f);
								this.EventStudent.Character.animation.CrossFade(this.EventStudent.IdleAnim);
								if (this.Distance < (float)10)
								{
									this.EventSubtitle.text = this.EventSpeech[1];
								}
								this.EventStudent.Prompt.Hide();
								this.EventStudent.Prompt.enabled = false;
							}
							this.Timer += Time.deltaTime;
							if (this.Timer > (float)2)
							{
								this.EventStudent.CurrentDestination = this.EventLocation[2];
								this.EventStudent.Pathfinding.target = this.EventLocation[2];
								if (this.Distance < (float)10)
								{
									this.EventSubtitle.text = string.Empty;
								}
								this.EventPhase++;
								this.Timer = (float)0;
							}
						}
						else
						{
							this.EventPhase = 7;
							this.Timer = (float)3;
						}
					}
					else if (this.EventPhase == 2)
					{
						this.EventStudent.Character.animation[this.EventStudent.BentoAnim].weight = this.EventStudent.Character.animation[this.EventStudent.BentoAnim].weight - Time.deltaTime;
						if (this.Timer == (float)0)
						{
							this.EventStudent.Character.animation.CrossFade("f02_bentoPlace_00");
						}
						this.Timer += Time.deltaTime;
						if (this.Timer > (float)1 && this.EventStudent.Bento.transform.parent != null)
						{
							this.EventStudent.Bento.transform.parent = null;
							this.EventStudent.Bento.transform.position = new Vector3((float)8, 0.5f, -2.2965f);
							this.EventStudent.Bento.transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
							this.EventStudent.Bento.transform.localScale = new Vector3(1.4f, 1.5f, 1.4f);
						}
						if (this.Timer > (float)2)
						{
							if (this.Yandere.PossessPoison)
							{
								this.Prompt.HideButton[0] = false;
							}
							this.EventStudent.CurrentDestination = this.EventLocation[3];
							this.EventStudent.Pathfinding.target = this.EventLocation[3];
							this.EventPhase++;
							this.Timer = (float)0;
						}
					}
					else if (this.EventPhase == 3)
					{
						this.PlayClip(this.EventClip[2], this.EventStudent.transform.position + Vector3.up * 1.5f);
						this.EventStudent.Character.animation.CrossFade("f02_cornerPeek_00");
						if (this.Distance < (float)10)
						{
							this.EventSubtitle.text = this.EventSpeech[2];
						}
						this.EventPhase++;
					}
					else if (this.EventPhase == 4)
					{
						this.Timer += Time.deltaTime;
						if (this.Timer > 5.5f)
						{
							this.PlayClip(this.EventClip[3], this.EventStudent.transform.position + Vector3.up * 1.5f);
							if (this.Distance < (float)10)
							{
								this.EventSubtitle.text = this.EventSpeech[3];
							}
							this.EventPhase++;
							this.Timer = (float)0;
						}
					}
					else if (this.EventPhase == 5)
					{
						this.Timer += Time.deltaTime;
						if (this.Timer > 5.5f)
						{
							this.PlayClip(this.EventClip[4], this.EventStudent.transform.position + Vector3.up * 1.5f);
							if (this.Distance < (float)10)
							{
								this.EventSubtitle.text = this.EventSpeech[4];
							}
							this.EventPhase++;
							this.Timer = (float)0;
						}
					}
					else if (this.EventPhase == 6)
					{
						this.Timer += Time.deltaTime;
						if (this.Timer > (float)3)
						{
							this.EventStudent.CurrentDestination = this.EventLocation[2];
							this.EventStudent.Pathfinding.target = this.EventLocation[2];
							if (this.Distance < (float)10)
							{
								this.EventSubtitle.text = string.Empty;
							}
							this.EventPhase++;
							this.Prompt.Hide();
							this.Prompt.enabled = false;
							this.Timer = (float)0;
						}
					}
					else if (this.EventPhase == 7)
					{
						if (this.Timer == (float)0)
						{
							this.EventStudent.Character.animation["f02_bentoPlace_00"].time = this.EventStudent.Character.animation["f02_bentoPlace_00"].length;
							this.EventStudent.Character.animation["f02_bentoPlace_00"].speed = (float)-1;
							this.EventStudent.Character.animation.CrossFade("f02_bentoPlace_00");
						}
						this.Timer += Time.deltaTime;
						if (this.Timer > (float)1 && this.EventStudent.Bento.transform.parent == null)
						{
							this.EventStudent.Bento.transform.parent = this.EventStudent.LeftHand;
							this.EventStudent.Bento.transform.localPosition = new Vector3((float)0, -0.0906f, -0.032f);
							this.EventStudent.Bento.transform.localEulerAngles = new Vector3((float)0, (float)90, (float)90);
							this.EventStudent.Bento.transform.localScale = new Vector3(1.4f, 1.5f, 1.4f);
						}
						if (this.Timer > (float)2)
						{
							this.EventStudent.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, (float)0);
							this.EventStudent.Bento.transform.localEulerAngles = new Vector3((float)0, (float)165, 82.5f);
							this.EventStudent.CurrentDestination = this.EventLocation[4];
							this.EventStudent.Pathfinding.target = this.EventLocation[4];
							this.EventStudent.Prompt.Hide();
							this.EventStudent.Prompt.enabled = false;
							this.EventPhase++;
							this.Timer = (float)0;
						}
					}
					else if (this.EventPhase == 8)
					{
						if (!this.Poisoned)
						{
							this.EventStudent.Character.animation[this.EventStudent.BentoAnim].weight = (float)0;
							this.EventStudent.Character.animation.CrossFade(this.EventStudent.EatAnim);
							if (!this.EventStudent.Chopsticks[0].active)
							{
								this.EventStudent.Chopsticks[0].active = true;
								this.EventStudent.Chopsticks[1].active = true;
							}
						}
						else
						{
							this.EventStudent.Character.animation.CrossFade("f02_poisonDeath_00");
							this.Timer += Time.deltaTime;
							if (this.Timer < 13.55f)
							{
								if (!this.EventStudent.Chopsticks[0].active)
								{
									this.PlayClip(this.EventClip[5], this.EventStudent.transform.position + Vector3.up * (float)1);
									this.EventStudent.Chopsticks[0].active = true;
									this.EventStudent.Chopsticks[1].active = true;
									this.EventStudent.Distracted = true;
								}
							}
							else if (this.Timer < 16.33333f)
							{
								if (this.EventStudent.Chopsticks[0].transform.parent != this.EventStudent.Bento.transform)
								{
									this.EventStudent.Chopsticks[0].transform.parent = this.EventStudent.Bento.transform;
									this.EventStudent.Chopsticks[1].transform.parent = this.EventStudent.Bento.transform;
								}
								this.EventStudent.EyeShrink = this.EventStudent.EyeShrink + Time.deltaTime;
								if (this.EventStudent.EyeShrink > 0.9f)
								{
									this.EventStudent.EyeShrink = 0.9f;
								}
							}
							else if (this.EventStudent.Bento.transform.parent != null)
							{
								this.EventStudent.Bento.transform.parent = null;
								((Collider)this.EventStudent.Bento.GetComponent(typeof(Collider))).isTrigger = false;
								this.EventStudent.Bento.AddComponent(typeof(Rigidbody));
								this.EventStudent.Bento.rigidbody.AddRelativeForce(Vector3.up * (float)100);
								this.EventStudent.Bento.rigidbody.AddRelativeForce(Vector3.left * (float)100);
								this.EventStudent.Bento.rigidbody.AddRelativeForce(Vector3.forward * (float)-100);
							}
							if (this.EventStudent.Character.animation["f02_poisonDeath_00"].time > this.EventStudent.Character.animation["f02_poisonDeath_00"].length)
							{
								this.EventStudent.Ragdoll.Poisoned = true;
								this.EventStudent.BecomeRagdoll();
								this.Yandere.Police.PoisonScene = true;
								this.EventOver = true;
								this.EndEvent();
							}
						}
					}
					if (this.Distance < (float)11)
					{
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
			this.EventStudent.Character.animation[this.EventStudent.BentoAnim].weight = (float)0;
			this.EventStudent.Chopsticks[0].active = false;
			this.EventStudent.Chopsticks[1].active = false;
			this.EventStudent.Bento.active = false;
			this.EventStudent.Prompt.enabled = true;
			this.EventStudent.MovingEvent = null;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents();
		}
		this.Portal.InEvent = false;
		this.EventActive = false;
		this.EventCheck = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	public virtual void Main()
	{
	}
}
