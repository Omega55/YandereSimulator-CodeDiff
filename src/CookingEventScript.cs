using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class CookingEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public RefrigeratorScript Snacks;

	public SchemesScript Schemes;

	public YandereScript Yandere;

	public ClockScript Clock;

	public GameObject Refrigerator;

	public GameObject RivalPhone;

	public GameObject Octodog;

	public GameObject Sausage;

	public Transform CookingClub;

	public Transform JarLid;

	public Transform Knife;

	public Transform Plate;

	public Transform Jar;

	public Transform[] Octodogs;

	public StudentScript EventStudent;

	public UILabel EventSubtitle;

	public Transform[] EventLocations;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public int[] ClubMembers;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventCheck;

	public bool EventOver;

	public int EventStudentID;

	public float EventTime;

	public int EventPhase;

	public int EventDay;

	public int Loop;

	public float CurrentClipLength;

	public float Rotation;

	public float Timer;

	public CookingEventScript()
	{
		this.EventTime = 7f;
		this.EventPhase = 1;
		this.EventDay = 2;
	}

	public virtual void Start()
	{
		this.Octodog.active = false;
		this.Sausage.active = false;
		this.Rotation = (float)-90;
		for (int i = 0; i < Extensions.get_length(this.Octodogs); i++)
		{
			this.Octodogs[i].active = false;
		}
		this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.EventCheck = true;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
		}
		if (!this.Clock.StopTime && this.EventCheck && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[this.EventStudentID];
			if (this.EventStudent != null && !this.EventStudent.Distracted)
			{
				if (!this.EventStudent.WitnessedMurder)
				{
					this.Snacks.Prompt.Hide();
					this.Snacks.Prompt.enabled = false;
					this.Snacks.enabled = false;
					this.EventStudent.CurrentDestination = this.EventLocations[0];
					this.EventStudent.Pathfinding.target = this.EventLocations[0];
					this.EventStudent.Obstacle.checkTime = (float)99;
					this.EventStudent.CookingEvent = this;
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
		if (this.EventActive)
		{
			if (this.Clock.HourTime > this.EventTime + 1.5f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying)
			{
				this.EndEvent();
			}
			else if (!this.EventStudent.Pathfinding.canMove)
			{
				if (this.EventPhase == -1)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > (float)5)
					{
						PlayerPrefs.SetInt("Scheme_4_Stage", 5);
						this.Schemes.UpdateInstructions();
						this.RivalPhone.active = false;
						this.EventSubtitle.text = string.Empty;
						this.EventPhase++;
						this.Timer = (float)0;
					}
				}
				if (this.EventPhase == 0)
				{
					if (!this.RivalPhone.active)
					{
						this.EventStudent.Character.animation.Play("f02_prepareFood_00");
						this.Octodog.transform.parent = this.EventStudent.RightHand;
						this.Octodog.transform.localPosition = new Vector3(0.0129f, -0.02475f, 0.0316f);
						this.Octodog.transform.localEulerAngles = new Vector3((float)-90, (float)0, (float)0);
						this.Sausage.transform.parent = this.EventStudent.RightHand;
						this.Sausage.transform.localPosition = new Vector3(0.013f, -0.038f, 0.015f);
						this.Sausage.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
						this.EventPhase++;
					}
					else
					{
						this.PlayClip(this.EventClip[0], this.EventStudent.transform.position + Vector3.up);
						this.EventStudent.Character.animation.CrossFade(this.EventAnim[0]);
						this.EventSubtitle.text = this.EventSpeech[0];
						this.EventPhase--;
					}
				}
				else if (this.EventPhase == 1)
				{
					if (this.EventStudent.Character.animation["f02_prepareFood_00"].time > (float)1)
					{
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 2)
				{
					this.Refrigerator.animation.Play("FridgeOpen");
					if (this.EventStudent.Character.animation["f02_prepareFood_00"].time > (float)3)
					{
						this.Jar.transform.parent = this.EventStudent.RightHand;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 3)
				{
					if (this.EventStudent.Character.animation["f02_prepareFood_00"].time > (float)5)
					{
						this.JarLid.transform.parent = this.EventStudent.LeftHand;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 4)
				{
					if (this.EventStudent.Character.animation["f02_prepareFood_00"].time > (float)6)
					{
						this.JarLid.transform.parent = this.CookingClub;
						this.JarLid.transform.localPosition = new Vector3(0.334585f, (float)1, -0.2528915f);
						this.JarLid.transform.localEulerAngles = new Vector3((float)0, (float)30, (float)0);
						this.Jar.transform.parent = this.CookingClub;
						this.Jar.transform.localPosition = new Vector3(0.29559f, (float)1, 0.2029152f);
						this.Jar.transform.localEulerAngles = new Vector3((float)0, (float)-150, (float)0);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 5)
				{
					if (this.EventStudent.Character.animation["f02_prepareFood_00"].time > (float)7)
					{
						((WeaponScript)this.Knife.GetComponent(typeof(WeaponScript))).FingerprintID = this.EventStudent.StudentID;
						this.Knife.parent = this.EventStudent.LeftHand;
						this.Knife.localPosition = new Vector3((float)0, -0.01f, (float)0);
						this.Knife.localEulerAngles = new Vector3((float)0, (float)0, (float)-90);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 6)
				{
					if (this.EventStudent.Character.animation["f02_prepareFood_00"].time >= this.EventStudent.Character.animation["f02_prepareFood_00"].length)
					{
						this.EventStudent.Character.animation.CrossFade("f02_cutFood_00");
						this.Sausage.active = true;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 7)
				{
					if (this.EventStudent.Character.animation["f02_cutFood_00"].time > 2.66666f)
					{
						this.Octodog.active = true;
						this.Sausage.active = false;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 8)
				{
					if (this.EventStudent.Character.animation["f02_cutFood_00"].time > (float)3)
					{
						this.Rotation = Mathf.MoveTowards(this.Rotation, (float)90, Time.deltaTime * (float)360);
						float rotation = this.Rotation;
						Vector3 localEulerAngles = this.Octodog.transform.localEulerAngles;
						float num = localEulerAngles.x = rotation;
						Vector3 vector = this.Octodog.transform.localEulerAngles = localEulerAngles;
						float z = Mathf.MoveTowards(this.Octodog.transform.localPosition.z, 0.012f, Time.deltaTime);
						Vector3 localPosition = this.Octodog.transform.localPosition;
						float num2 = localPosition.z = z;
						Vector3 vector2 = this.Octodog.transform.localPosition = localPosition;
					}
					if (this.EventStudent.Character.animation["f02_cutFood_00"].time > (float)6)
					{
						this.Octodog.active = false;
						this.Octodogs[this.Loop].active = true;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 9)
				{
					if (this.EventStudent.Character.animation["f02_cutFood_00"].time >= this.EventStudent.Character.animation["f02_cutFood_00"].length)
					{
						if (this.Loop < Extensions.get_length(this.Octodogs) - 1)
						{
							int num3 = -90;
							Vector3 localEulerAngles2 = this.Octodog.transform.localEulerAngles;
							float num4 = localEulerAngles2.x = (float)num3;
							Vector3 vector3 = this.Octodog.transform.localEulerAngles = localEulerAngles2;
							float z2 = 0.0316f;
							Vector3 localPosition2 = this.Octodog.transform.localPosition;
							float num5 = localPosition2.z = z2;
							Vector3 vector4 = this.Octodog.transform.localPosition = localPosition2;
							this.EventStudent.Character.animation["f02_cutFood_00"].time = (float)0;
							this.EventStudent.Character.animation.Play("f02_cutFood_00");
							this.Sausage.active = true;
							this.EventPhase = 7;
							this.Rotation = (float)-90;
							this.Loop++;
						}
						else
						{
							this.EventStudent.Character.animation.Play("f02_prepareFood_00");
							this.EventStudent.Character.animation["f02_prepareFood_00"].time = this.EventStudent.Character.animation["f02_prepareFood_00"].length;
							this.EventStudent.Character.animation["f02_prepareFood_00"].speed = (float)-1;
							this.EventPhase++;
						}
					}
				}
				else if (this.EventPhase == 10)
				{
					if (this.EventStudent.Character.animation["f02_prepareFood_00"].time < this.EventStudent.Character.animation["f02_prepareFood_00"].length - (float)1)
					{
						this.Knife.parent = this.CookingClub;
						this.Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.33333f);
						this.Knife.localEulerAngles = new Vector3((float)45, (float)-90, (float)-90);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 11)
				{
					if (this.EventStudent.Character.animation["f02_prepareFood_00"].time < this.EventStudent.Character.animation["f02_prepareFood_00"].length - (float)2)
					{
						this.JarLid.parent = this.EventStudent.LeftHand;
						this.Jar.parent = this.EventStudent.RightHand;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 12)
				{
					if (this.EventStudent.Character.animation["f02_prepareFood_00"].time < this.EventStudent.Character.animation["f02_prepareFood_00"].length - (float)3)
					{
						this.JarLid.parent = this.Jar;
						this.JarLid.localPosition = new Vector3((float)0, 0.175f, (float)0);
						this.JarLid.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
						this.Refrigerator.animation.Play("FridgeOpen");
						this.Refrigerator.animation["FridgeOpen"].time = this.Refrigerator.animation["FridgeOpen"].length;
						this.Refrigerator.animation["FridgeOpen"].speed = (float)-1;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 13)
				{
					if (this.EventStudent.Character.animation["f02_prepareFood_00"].time < this.EventStudent.Character.animation["f02_prepareFood_00"].length - (float)5)
					{
						this.Jar.parent = this.CookingClub;
						this.Jar.localPosition = new Vector3(0.1f, 0.941f, 0.75f);
						this.Jar.localEulerAngles = new Vector3((float)0, (float)90, (float)0);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 14)
				{
					if (this.EventStudent.Character.animation["f02_prepareFood_00"].time <= (float)0)
					{
						((Collider)this.Knife.GetComponent(typeof(Collider))).enabled = true;
						this.Plate.parent = this.EventStudent.RightHand;
						this.Plate.localPosition = new Vector3((float)0, 0.011f, -0.156765f);
						this.Plate.localEulerAngles = new Vector3((float)0, (float)-90, (float)-180);
						this.EventStudent.CurrentDestination = this.EventLocations[1];
						this.EventStudent.Pathfinding.target = this.EventLocations[1];
						this.EventStudent.Character.animation[this.EventStudent.CarryAnim].weight = (float)1;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 15)
				{
					this.Plate.parent = this.CookingClub;
					this.Plate.localPosition = new Vector3(-3.66666f, 0.9066666f, -2.379f);
					this.Plate.localEulerAngles = new Vector3((float)0, (float)-90, (float)0);
					this.EndEvent();
				}
				float num6 = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
				if (num6 < (float)10)
				{
					float num7 = Mathf.Abs((num6 - (float)10) * 0.2f);
					if (num7 < (float)0)
					{
						num7 = (float)0;
					}
					if (num7 > (float)1)
					{
						num7 = (float)1;
					}
					this.EventSubtitle.transform.localScale = new Vector3(num7, num7, num7);
				}
				else
				{
					this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
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
			if (this.Plate.parent == this.EventStudent.RightHand)
			{
				this.Plate.parent = null;
				this.Plate.rigidbody.useGravity = true;
				((BoxCollider)this.Plate.GetComponent(typeof(BoxCollider))).enabled = true;
			}
			this.EventStudent.Character.animation[this.EventStudent.CarryAnim].weight = (float)0;
			this.EventStudent.Pathfinding.speed = (float)1;
			this.EventStudent.Phone.active = false;
			this.EventStudent.TargetDistance = (float)1;
			this.EventStudent.PhoneEvent = null;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventSubtitle.text = string.Empty;
			if (this.Knife.parent == this.EventStudent.LeftHand)
			{
				this.Knife.parent = this.CookingClub;
				this.Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.33333f);
				this.Knife.localEulerAngles = new Vector3((float)45, (float)-90, (float)-90);
				((Collider)this.Knife.GetComponent(typeof(Collider))).enabled = true;
			}
			this.StudentManager.UpdateStudents();
		}
		this.EventActive = false;
		this.EventCheck = false;
	}

	public virtual void Main()
	{
	}
}
