using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StudentScript : MonoBehaviour
{
	private Quaternion targetRotation;

	public DetectionMarkerScript DetectionMarker;

	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public DialogueWheelScript DialogueWheel;

	public WitnessCameraScript WitnessCamera;

	public EventManagerScript EventManager;

	public MovingEventScript MovingEvent;

	public DynamicGridObstacle Obstacle;

	public ReputationScript Reputation;

	public SubtitleScript Subtitle;

	public RagdollScript Ragdoll;

	public YandereScript Yandere;

	public RagdollScript Corpse;

	public PoliceScript Police;

	public PromptScript Prompt;

	public AIPath Pathfinding;

	public ClockScript Clock;

	public JsonScript JSON;

	public CharacterController MyController;

	public Texture DrillTexture;

	public Texture HairTexture;

	public Camera VisionCone;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public Transform CurrentDestination;

	public Transform TeacherTalkPoint;

	public Transform MyReporter;

	public Transform WitnessPOV;

	public Transform RightHand;

	public Transform LeftHand;

	public Transform MeetSpot;

	public Transform Eyes;

	public string[] DestinationNames;

	public OutlineScript[] Outlines;

	public Transform[] Destinations;

	public GameObject[] Chopsticks;

	public string[] AnimationNames;

	public string[] ActionNames;

	public float[] PhaseTimes;

	public Plane[] Planes;

	public int[] Actions;

	public SphereCollider HipCollider;

	public Collider NotFaceCollider;

	public Collider PantyCollider;

	public Collider SkirtCollider;

	public Collider FaceCollider;

	public GameObject AlarmSphere;

	public GameObject BloodSpray;

	public GameObject MainCamera;

	public GameObject Character;

	public GameObject Marker;

	public GameObject Bento;

	public GameObject Phone;

	public bool WitnessedCorpse;

	public bool WitnessedMurder;

	public bool RepeatReaction;

	public bool YandereVisible;

	public bool Complimented;

	public bool Distracted;

	public bool ShortHair;

	public bool HidePony;

	public bool Pushable;

	public bool Tranquil;

	public bool Alarmed;

	public bool Forgave;

	public bool InEvent;

	public bool Private;

	public bool Reacted;

	public bool Teacher;

	public bool Witness;

	public bool Routine;

	public bool Pushed;

	public bool Dead;

	public bool Safe;

	public bool Male;

	public bool Following;

	public bool Reporting;

	public bool Fleeing;

	public bool Meeting;

	public bool Talking;

	public bool Waiting;

	public bool Dying;

	public bool Halt;

	public float DistanceToDestination;

	public float DistanceToPlayer;

	public float TargetDistance;

	public float ReportTimer;

	public float IgnoreTimer;

	public float AlarmTimer;

	public float MeetTimer;

	public float TalkTimer;

	public float WaitTimer;

	public float PreviousAlarm;

	public float BreastSize;

	public float PendingRep;

	public float EyeShrink;

	public float MeetTime;

	public float RepLoss;

	public float Alarm;

	public int WeaponWitnessed;

	public int Interaction;

	public int Concern;

	public int Phase;

	public string GameOverCause;

	public string RandomAnim;

	public string Witnessed;

	public string Hairstyle;

	public string Name;

	public string WalkAnim;

	public string RunAnim;

	public string SprintAnim;

	public string IdleAnim;

	public string Nod1Anim;

	public string Nod2Anim;

	public string DefendAnim;

	public string DeathAnim;

	public string ScaredAnim;

	public string LookDownAnim;

	public string PhoneAnim;

	public string AngryFaceAnim;

	public string KneelAnim;

	public string KneelScanAnim;

	public string CallAnim;

	public string CounterAnim;

	public string PushedAnim;

	public string GameAnim;

	public string BentoAnim;

	public string EatAnim;

	public int ReportPhase;

	public int StudentID;

	public int Persona;

	public int Class;

	public int Club;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform Ponytail;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform HairL;

	public Transform HairR;

	private float MaxSpeed;

	public Mesh TeacherMesh;

	public Texture TeacherTexture;

	public Mesh NudeMesh;

	public Texture NudeTexture;

	public bool AoT;

	public Texture SocksTexture;

	public StudentScript()
	{
		this.Routine = true;
		this.GameOverCause = string.Empty;
		this.RandomAnim = string.Empty;
		this.Witnessed = string.Empty;
		this.Hairstyle = string.Empty;
		this.Name = string.Empty;
		this.WalkAnim = string.Empty;
		this.RunAnim = string.Empty;
		this.SprintAnim = string.Empty;
		this.IdleAnim = string.Empty;
		this.Nod1Anim = string.Empty;
		this.Nod2Anim = string.Empty;
		this.DefendAnim = string.Empty;
		this.DeathAnim = string.Empty;
		this.ScaredAnim = string.Empty;
		this.LookDownAnim = string.Empty;
		this.PhoneAnim = string.Empty;
		this.AngryFaceAnim = string.Empty;
		this.KneelAnim = string.Empty;
		this.KneelScanAnim = string.Empty;
		this.CallAnim = string.Empty;
		this.CounterAnim = string.Empty;
		this.PushedAnim = string.Empty;
		this.GameAnim = string.Empty;
		this.BentoAnim = string.Empty;
		this.EatAnim = string.Empty;
		this.MaxSpeed = 10f;
	}

	public virtual void Start()
	{
		this.DetectionMarker = (DetectionMarkerScript)((GameObject)UnityEngine.Object.Instantiate(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity)).GetComponent(typeof(DetectionMarkerScript));
		this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
		this.DetectionMarker.Target = this.transform;
		this.PhaseTimes = (float[])this.JSON.StudentTimes[this.StudentID].ToBuiltin(typeof(float));
		this.Persona = this.JSON.StudentPersonas[this.StudentID];
		this.Class = this.JSON.StudentClasses[this.StudentID];
		this.Club = this.JSON.StudentClubs[this.StudentID];
		this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
		this.Hairstyle = this.JSON.StudentHairstyles[this.StudentID];
		this.Name = this.JSON.StudentNames[this.StudentID];
		this.GetDestinations();
		this.DialogueWheel = (DialogueWheelScript)GameObject.Find("DialogueWheel").GetComponent(typeof(DialogueWheelScript));
		this.Reputation = (ReputationScript)GameObject.Find("Reputation").GetComponent(typeof(ReputationScript));
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.Subtitle = (SubtitleScript)GameObject.Find("Subtitle").GetComponent(typeof(SubtitleScript));
		this.Police = (PoliceScript)GameObject.Find("Police").GetComponent(typeof(PoliceScript));
		this.Clock = (ClockScript)GameObject.Find("Clock").GetComponent(typeof(ClockScript));
		this.MainCamera = GameObject.Find("MainCamera");
		this.ShoulderCamera = (ShoulderCameraScript)this.MainCamera.GetComponent(typeof(ShoulderCameraScript));
		this.CameraEffects = (CameraEffectsScript)this.MainCamera.GetComponent(typeof(CameraEffectsScript));
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		this.PickRandomAnim();
		if (!this.Male)
		{
			this.Character.animation[this.GameAnim].speed = (float)2;
			if (this.Club == 9)
			{
				this.BecomeTeacher();
			}
			this.UpdateHair();
			this.SetColors();
			this.Character.animation[this.BentoAnim].layer = 3;
			this.Character.animation.Play(this.BentoAnim);
			this.Character.animation[this.BentoAnim].weight = (float)0;
			this.Character.animation[this.AngryFaceAnim].layer = 2;
			this.Character.animation.Play(this.AngryFaceAnim);
			this.Character.animation[this.AngryFaceAnim].weight = (float)0;
			this.Character.animation[this.PhoneAnim].layer = 1;
			this.Character.animation[this.PhoneAnim].weight = (float)0;
			this.Character.animation.Play(this.PhoneAnim);
			this.Bento.active = false;
			this.Chopsticks[0].active = false;
			this.Chopsticks[1].active = false;
		}
		else
		{
			this.SetColors();
			this.Character.animation["scaredFace_00"].layer = 3;
			this.Character.animation.Play("scaredFace_00");
			this.Character.animation["scaredFace_00"].weight = (float)0;
			this.Character.animation[this.AngryFaceAnim].layer = 2;
			this.Character.animation.Play(this.AngryFaceAnim);
			this.Character.animation[this.AngryFaceAnim].weight = (float)0;
			this.Character.animation[this.PhoneAnim].layer = 1;
			this.Character.animation.Play(this.PhoneAnim);
			this.Character.animation[this.PhoneAnim].weight = (float)0;
		}
		if (this.AoT)
		{
			this.AttackOnTitan();
		}
		this.Prompt.HideButton[0] = true;
		this.Prompt.HideButton[2] = true;
		for (int i = 0; i < this.Ragdoll.AllRigidbodies.Length; i++)
		{
			this.Ragdoll.AllRigidbodies[i].isKinematic = true;
			this.Ragdoll.AllColliders[i].enabled = false;
		}
		this.Ragdoll.AllColliders[10].enabled = true;
		if (this.StudentID == 1)
		{
			((DetectionMarkerScript)this.DetectionMarker.GetComponent(typeof(DetectionMarkerScript))).Tex.color = new Color((float)1, (float)0, (float)0, (float)0);
			this.Yandere.Senpai = this.transform;
			for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
			{
				this.Outlines[i].enabled = true;
				this.Outlines[i].color = new Color((float)1, (float)0, (float)1);
			}
		}
		else if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Photographed") == 0)
		{
			for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
			{
				this.Outlines[i].enabled = false;
			}
		}
	}

	public virtual void Update()
	{
		if (this.Routine)
		{
			if (this.Phase < Extensions.get_length(this.PhaseTimes) - 1)
			{
				if (this.Clock.HourTime >= this.PhaseTimes[this.Phase])
				{
					this.Phase++;
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
				}
				if (this.MeetTime > (float)0 && this.Clock.HourTime > this.MeetTime)
				{
					this.CurrentDestination = this.MeetSpot;
					this.Pathfinding.target = this.MeetSpot;
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Meeting = true;
					this.MeetTime = (float)0;
				}
			}
			this.DistanceToDestination = Vector3.Distance(this.transform.position, this.CurrentDestination.position);
			if (this.DistanceToDestination > 0.5f)
			{
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Obstacle.enabled = false;
				this.Character.animation.CrossFade(this.WalkAnim);
				this.Character.animation[this.WalkAnim].speed = this.Pathfinding.currentSpeed;
			}
			else
			{
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				this.Obstacle.enabled = true;
				this.MoveTowardsTarget(this.CurrentDestination.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, (float)10 * Time.deltaTime);
				if (!this.Meeting)
				{
					if (this.Actions[this.Phase] == 0)
					{
						if (!this.InEvent)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
						}
					}
					else if (this.Actions[this.Phase] == 2)
					{
						if (!this.InEvent)
						{
							this.Character.animation.CrossFade(this.GameAnim);
						}
					}
					else if (!this.InEvent)
					{
						this.Character.animation.CrossFade(this.RandomAnim);
						if (this.Character.animation[this.RandomAnim].time >= this.Character.animation[this.RandomAnim].length)
						{
							this.PickRandomAnim();
						}
					}
				}
				else
				{
					if (this.MeetTimer == (float)0 && this.transform.position.y > (float)11)
					{
						this.Prompt.Label[0].text = "     " + "Push";
						this.Pushable = true;
					}
					this.Character.animation.CrossFade(this.IdleAnim);
					this.MeetTimer += Time.deltaTime;
					if (this.MeetTimer > (float)60)
					{
						this.Subtitle.UpdateLabel("Note Reaction", 4, (float)3);
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
						this.Prompt.Label[0].text = "     Talk";
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Pushable = false;
						this.Meeting = false;
						this.MeetTimer = (float)0;
					}
				}
			}
		}
		else
		{
			if (this.Fleeing && this.AlarmTimer == (float)0)
			{
				if (this.Persona == 2 && this.StudentManager.Reporter == null && !this.Police.Called)
				{
					this.Pathfinding.target = this.StudentManager.Teachers[this.Class].TeacherTalkPoint;
					this.StudentManager.Reporter = this;
					this.Reporting = true;
				}
				if (this.transform.position.y < (float)-2)
				{
					this.Police.Witnesses = this.Police.Witnesses - 1;
					this.Police.Show = true;
					this.active = false;
				}
				if (this.transform.position.z < (float)-49)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Safe = true;
				}
				this.DistanceToDestination = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
				if (this.AlarmTimer == (float)0)
				{
					if (this.DistanceToDestination > this.TargetDistance)
					{
						this.Character.animation.CrossFade(this.SprintAnim);
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						if (this.Yandere.Chased)
						{
							this.Pathfinding.repathRate = (float)0;
							this.Pathfinding.speed = (float)7;
						}
						else
						{
							this.Pathfinding.speed = (float)4;
						}
					}
					else
					{
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						if (!this.Halt)
						{
							this.MoveTowardsTarget(this.Pathfinding.target.position);
							this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Pathfinding.target.rotation, (float)10 * Time.deltaTime);
						}
						else if (this.Persona == 2)
						{
							this.targetRotation = Quaternion.LookRotation(this.StudentManager.Teachers[this.Class].transform.position - this.transform.position);
							this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
						}
						if (this.Persona == 2)
						{
							this.Character.animation.CrossFade(this.ScaredAnim);
							if (this.Reporting)
							{
								if (this.ReportPhase == 0)
								{
									if (this.WitnessedCorpse)
									{
										this.Subtitle.UpdateLabel("Pet Corpse Report", 2, (float)3);
									}
									else
									{
										this.Subtitle.UpdateLabel("Pet Murder Report", 2, (float)3);
									}
									this.ReportPhase++;
								}
								else if (this.ReportPhase == 1)
								{
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer >= (float)3)
									{
										this.StudentManager.Teachers[this.Class].MyReporter = this.transform;
										this.StudentManager.Teachers[this.Class].Routine = false;
										this.StudentManager.Teachers[this.Class].Fleeing = true;
										this.ReportTimer = (float)0;
										this.ReportPhase++;
									}
								}
								else if (this.ReportPhase == 100)
								{
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer >= (float)5)
									{
										if (this.StudentManager.Reporter == this)
										{
											this.StudentManager.Reporter = null;
											this.StudentManager.StopFleeing();
											this.StudentManager.UpdateStudents();
										}
										this.Pathfinding.target = this.Destinations[this.Phase];
										this.Pathfinding.speed = (float)1;
										this.ReportPhase = 0;
										this.ReportTimer = (float)0;
										this.AlarmTimer = (float)0;
										this.WitnessedCorpse = false;
										this.WitnessedMurder = false;
										this.Reporting = false;
										this.Reacted = false;
										this.Alarmed = false;
										this.Fleeing = false;
										this.Routine = true;
										this.Halt = false;
									}
								}
							}
						}
						else if (this.Persona == 9)
						{
							if (!this.WitnessedMurder)
							{
								if (this.ReportPhase == 0)
								{
									this.Subtitle.UpdateLabel("Teacher Report Reaction", 1, (float)3);
									this.ReportPhase++;
								}
								else if (this.ReportPhase == 1)
								{
									this.Character.animation.CrossFade(this.IdleAnim);
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer >= (float)3)
									{
										if (!this.StudentManager.Reporter.Teacher)
										{
											this.StudentManager.Reporter.Pathfinding.target = this.StudentManager.CorpseLocation;
										}
										this.Pathfinding.target = this.StudentManager.CorpseLocation;
										this.StudentManager.Reporter.TargetDistance = (float)2;
										this.StudentManager.Reporter.Halt = true;
										this.TargetDistance = (float)1;
										this.Halt = true;
										this.ReportTimer = (float)0;
										this.ReportPhase++;
									}
								}
								else if (this.ReportPhase == 2)
								{
									if (this.WitnessedCorpse)
									{
										if (!this.Corpse.Natural)
										{
											this.Subtitle.UpdateLabel("Teacher Corpse Inspection", 1, (float)5);
										}
										else
										{
											this.Subtitle.UpdateLabel("Teacher Corpse Inspection", 2, (float)2);
										}
										this.ReportPhase++;
									}
									else
									{
										this.Character.animation.CrossFade(this.IdleAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer > (float)5)
										{
											this.Subtitle.UpdateLabel("Teacher Prank Reaction", 1, (float)7);
											this.ReportPhase = 98;
											this.ReportTimer = (float)0;
										}
									}
								}
								else if (this.ReportPhase == 3)
								{
									this.Character.animation.CrossFade(this.KneelAnim);
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer >= (float)6)
									{
										this.ReportTimer = (float)0;
										this.ReportPhase++;
									}
								}
								else if (this.ReportPhase == 4)
								{
									this.Subtitle.UpdateLabel("Teacher Police Report", 1, (float)5);
									this.Phone.active = true;
									this.ReportPhase++;
								}
								else if (this.ReportPhase == 5)
								{
									this.Character.animation.CrossFade(this.CallAnim);
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer >= (float)5)
									{
										if (this.Corpse.Natural)
										{
											this.Police.Timer = 1E-06f;
										}
										this.Character.animation.CrossFade(this.KneelScanAnim);
										this.Phone.active = false;
										this.Police.Show = true;
										this.Fleeing = false;
										this.ReportTimer = (float)0;
										this.ReportPhase++;
									}
								}
								else if (this.ReportPhase == 98)
								{
									this.targetRotation = Quaternion.LookRotation(this.MyReporter.transform.position - this.transform.position);
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer > (float)7)
									{
										this.ReportPhase++;
									}
								}
								else if (this.ReportPhase == 99)
								{
									this.Subtitle.UpdateLabel("Prank Reaction", 1, (float)5);
									this.StudentManager.Reporter.ReportPhase = 100;
									this.Pathfinding.target = this.Destinations[this.Phase];
									this.ReportTimer = (float)0;
									this.ReportPhase++;
								}
								else if (this.ReportPhase == 100)
								{
									this.ReportPhase = 0;
									this.Fleeing = false;
									this.Routine = true;
								}
							}
							else if (!this.Yandere.Dumping && !this.Yandere.Attacking)
							{
								if (this.Yandere.Aiming)
								{
									this.Yandere.StopAiming();
								}
								if (this.Yandere.Dragging || this.Yandere.Mopping || this.Yandere.PickUp != null)
								{
									this.Yandere.Mopping = false;
									this.Yandere.EmptyHands();
								}
								this.AttackReaction();
								this.Character.animation[this.CounterAnim].time = (float)5;
								this.Yandere.Character.animation["f02_counterA_00"].time = (float)5;
								this.Yandere.ShoulderCamera.DoNotMove = true;
								this.Yandere.ShoulderCamera.Timer = (float)5;
								this.Yandere.ShoulderCamera.Phase = 3;
								this.Police.Show = false;
								this.Yandere.CameraEffects.MurderWitnessed();
								this.Yandere.Jukebox.GameOver();
							}
							else
							{
								this.Character.animation.CrossFade(this.IdleAnim);
							}
						}
					}
				}
				else
				{
					this.Character.animation.CrossFade(this.ScaredAnim);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					if (this.WitnessedMurder)
					{
						this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
					}
					else if (this.WitnessedCorpse)
					{
						this.targetRotation = Quaternion.LookRotation(this.Corpse.AllColliders[0].transform.position - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
					}
				}
			}
			if (this.Following && !this.Waiting)
			{
				this.DistanceToDestination = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
				if (this.DistanceToDestination > (float)5)
				{
					this.Character.animation.CrossFade(this.RunAnim);
					this.Pathfinding.speed = (float)4;
					this.Obstacle.enabled = false;
				}
				else if (this.DistanceToDestination > (float)1)
				{
					this.Character.animation.CrossFade(this.WalkAnim);
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = (float)1;
					this.Obstacle.enabled = false;
				}
				else
				{
					this.Character.animation.CrossFade(this.IdleAnim);
					this.Pathfinding.canMove = false;
					this.Obstacle.enabled = true;
				}
				if (this.Phase < Extensions.get_length(this.PhaseTimes) - 1 && this.Clock.HourTime >= this.PhaseTimes[this.Phase])
				{
					this.Phase++;
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = (float)1;
					this.Yandere.Followers = this.Yandere.Followers - 1;
					this.Following = false;
					this.Routine = true;
					this.Subtitle.UpdateLabel("Stop Follow Apology", 0, (float)3);
					this.Prompt.Label[0].text = "     " + "Talk";
				}
			}
		}
		if (!this.Dying)
		{
			if (!this.Distracted)
			{
				this.Character.animation[this.PhoneAnim].weight = Mathf.Lerp(this.Character.animation[this.PhoneAnim].weight, (float)0, Time.deltaTime * (float)10);
				if (!this.WitnessedMurder)
				{
					int num = 0;
					for (int i = 0; i < this.Police.Corpses; i++)
					{
						if (this.Police.CorpseList[i] != null)
						{
							this.Planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
							if (GeometryUtility.TestPlanesAABB(this.Planes, this.Police.CorpseList[i].AllColliders[0].bounds))
							{
								RaycastHit raycastHit = default(RaycastHit);
								Debug.DrawLine(this.Eyes.transform.position, this.Police.CorpseList[i].AllColliders[0].transform.position, Color.green);
								if (Physics.Linecast(this.Eyes.transform.position, this.Police.CorpseList[i].AllColliders[0].transform.position, out raycastHit) && (raycastHit.collider.gameObject.layer == 11 || raycastHit.collider.gameObject.layer == 14))
								{
									num++;
									this.Corpse = this.Police.CorpseList[i];
									if (this.Persona == 2 && this.StudentManager.Reporter == null && !this.Police.Called)
									{
										this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
										this.StudentManager.Reporter = this;
										this.Reporting = true;
									}
								}
							}
						}
					}
					if (num > 0)
					{
						if (!this.WitnessedCorpse)
						{
							this.Alarm = (float)200;
							this.WitnessedCorpse = true;
							this.StudentManager.UpdateMe(this.StudentID - 1);
							if (!this.Teacher && this.Corpse.Natural)
							{
								this.Persona = 2;
							}
						}
						if (this.Corpse.Dragged || this.Corpse.Dumped)
						{
							if (this.Teacher)
							{
								this.Subtitle.UpdateLabel("Teacher Murder Reaction", 1, (float)3);
								this.StudentManager.Portal.active = false;
							}
							this.WitnessMurder();
						}
					}
					this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
					this.PreviousAlarm = this.Alarm;
					if (this.DistanceToPlayer < (float)11)
					{
						if (!this.Talking)
						{
							if (!this.Yandere.Noticed)
							{
								if (!this.Yandere.Chased)
								{
									if ((this.Yandere.Armed && this.Yandere.Weapon[this.Yandere.Equipped].Suspicious) || (this.Yandere.Bloodiness > (float)0 || this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Dragging || this.Yandere.Lewd || (this.Private && this.Yandere.Trespassing)) || (this.Teacher && this.Yandere.Trespassing) || (this.StudentID == 1 && this.Yandere.NearSenpai && !this.Yandere.Talking))
									{
										this.Planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
										if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.collider.bounds))
										{
											RaycastHit raycastHit2 = default(RaycastHit);
											Debug.DrawLine(this.Eyes.transform.position, this.Yandere.transform.position + Vector3.up * (float)1, Color.green);
											if (Physics.Linecast(this.Eyes.transform.position, this.Yandere.transform.position + Vector3.up * (float)1, out raycastHit2))
											{
												if (raycastHit2.collider.gameObject == this.Yandere.gameObject)
												{
													if (this.Yandere.Attacking || (this.Yandere.NearBodies > 0 && this.Yandere.Bloodiness > (float)0) || (this.Yandere.NearBodies > 0 && this.Yandere.Armed) || (this.Yandere.NearBodies > 0 && this.Yandere.Sanity < 66.66666f) || this.Yandere.Dragging)
													{
														this.WitnessMurder();
													}
													else if (!this.Fleeing)
													{
														if (!this.Alarmed && this.IgnoreTimer <= (float)0)
														{
															this.Alarm += Time.deltaTime * ((float)100 / this.DistanceToPlayer);
															this.YandereVisible = true;
															if (this.StudentID == 1 && this.Yandere.TimeSkipping)
															{
																this.Clock.EndTimeSkip();
															}
														}
													}
													else
													{
														this.Alarm -= Time.deltaTime * (float)100;
													}
												}
												else
												{
													this.Alarm -= Time.deltaTime * (float)100;
												}
											}
										}
										else
										{
											this.Alarm -= Time.deltaTime * (float)100;
										}
									}
									else
									{
										this.Alarm -= Time.deltaTime * (float)100;
									}
								}
								else
								{
									this.Alarm -= Time.deltaTime * (float)100;
								}
							}
							else
							{
								this.Alarm -= Time.deltaTime * (float)100;
							}
						}
						else
						{
							this.Alarm -= Time.deltaTime * (float)100;
						}
					}
					else
					{
						this.Alarm -= Time.deltaTime * (float)100;
					}
					if (this.PreviousAlarm > this.Alarm && this.Alarm < (float)100)
					{
						this.YandereVisible = false;
					}
					if (this.Alarm > (float)100 && !this.Alarmed)
					{
						for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
						{
							this.Outlines[i].color = new Color((float)1, (float)1, (float)0, (float)1);
						}
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Routine = false;
						this.Alarmed = true;
						this.Witness = true;
						string witnessed = this.Witnessed;
						bool flag = false;
						if (this.Yandere.Armed && this.Yandere.Weapon[this.Yandere.Equipped].Suspicious)
						{
							flag = true;
						}
						if (this.WitnessedCorpse && !this.WitnessedMurder)
						{
							this.Witnessed = "Corpse";
							this.EyeShrink = 0.9f;
						}
						else if (this.YandereVisible)
						{
							if (flag && this.Yandere.Bloodiness > (float)0 && this.Yandere.Sanity < 33.333f)
							{
								this.Witnessed = "Weapon and Blood and Insanity";
								this.RepLoss = (float)30;
								this.Concern = 5;
							}
							else if (flag && this.Yandere.Sanity < 33.333f)
							{
								this.Witnessed = "Weapon and Insanity";
								this.RepLoss = (float)20;
								this.Concern = 5;
							}
							else if (this.Yandere.Bloodiness > (float)0 && this.Yandere.Sanity < 33.333f)
							{
								this.Witnessed = "Blood and Insanity";
								this.RepLoss = (float)20;
								this.Concern = 5;
							}
							else if (flag && this.Yandere.Bloodiness > (float)0)
							{
								this.Witnessed = "Weapon and Blood";
								this.RepLoss = (float)20;
								this.Concern = 5;
							}
							else if (flag)
							{
								this.WeaponWitnessed = this.Yandere.Weapon[this.Yandere.Equipped].WeaponID;
								this.Witnessed = "Weapon";
								this.RepLoss = (float)10;
								this.Concern = 5;
							}
							else if (this.Yandere.Bloodiness > (float)0)
							{
								this.Witnessed = "Blood";
								this.RepLoss = (float)10;
								this.Concern = 5;
							}
							else if (this.Yandere.Sanity < 33.333f)
							{
								this.Witnessed = "Insanity";
								this.RepLoss = (float)10;
								this.Concern = 5;
							}
							else if (this.Yandere.Lewd)
							{
								this.Witnessed = "Lewd";
								this.RepLoss = (float)10;
								this.Concern = 5;
							}
							else if (this.Yandere.Trespassing)
							{
								if (this.Private)
								{
									this.Witnessed = "Interruption";
									if (this.EventManager != null)
									{
										this.EventManager.EndEvent();
									}
								}
								else
								{
									this.Witnessed = "Trespassing";
								}
								this.Concern++;
							}
							else if (this.Yandere.NearSenpai)
							{
								this.Witnessed = "Stalking";
								this.Concern++;
							}
							if (this.Teacher && this.WitnessedCorpse)
							{
								this.Concern = 1;
							}
							if (this.StudentID == 1)
							{
								if (this.Concern == 5)
								{
									this.SenpaiNoticed();
									if (this.Witnessed == "Stalking")
									{
										this.Character.animation.CrossFade(this.IdleAnim);
										this.Character.animation[this.AngryFaceAnim].weight = (float)1;
									}
									else
									{
										this.Character.animation.CrossFade(this.ScaredAnim);
										this.Character.animation["scaredFace_00"].weight = (float)1;
									}
									this.CameraEffects.MurderWitnessed();
								}
								else
								{
									this.Character.animation.CrossFade(this.IdleAnim);
									this.CameraEffects.Alarm();
								}
							}
							else if (!this.Teacher)
							{
								this.CameraEffects.Alarm();
							}
							else if (this.Concern < 5)
							{
								this.CameraEffects.Alarm();
							}
							else
							{
								this.SenpaiNoticed();
								this.CameraEffects.MurderWitnessed();
							}
							if (!this.Teacher && this.Witnessed == witnessed)
							{
								this.RepeatReaction = true;
							}
							this.Reputation.PendingRep = this.Reputation.PendingRep - this.RepLoss;
							this.PendingRep -= this.RepLoss;
						}
					}
				}
				else if (!this.Alarmed)
				{
					this.Alarm -= Time.deltaTime * (float)100;
				}
			}
			else
			{
				this.Character.animation[this.PhoneAnim].weight = Mathf.Lerp(this.Character.animation[this.PhoneAnim].weight, (float)1, Time.deltaTime * (float)10);
				if (this.transform.position.z > (float)-49)
				{
					this.Phone.active = false;
					this.Distracted = false;
					this.Safe = false;
					this.StudentManager.UpdateStudents();
				}
			}
		}
		if (this.Alarm > (float)100)
		{
			this.Alarm = (float)100;
		}
		if (this.Alarm < (float)0)
		{
			this.Alarm = (float)0;
		}
		float y = this.Alarm / (float)100;
		Vector3 localScale = this.DetectionMarker.Tex.transform.localScale;
		float num2 = localScale.y = y;
		Vector3 vector = this.DetectionMarker.Tex.transform.localScale = localScale;
		float a = this.Alarm / (float)100;
		Color color = this.DetectionMarker.Tex.color;
		float num3 = color.a = a;
		Color color2 = this.DetectionMarker.Tex.color = color;
		if (this.Alarm > (float)0 || this.AlarmTimer > (float)0 || this.Yandere.Armed)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			if (this.Following)
			{
				this.Subtitle.UpdateLabel("Student Farewell", 0, (float)3);
				this.Prompt.Label[0].text = "     " + "Talk";
				this.Prompt.Circle[0].fillAmount = (float)1;
				this.Yandere.Followers = this.Yandere.Followers - 1;
				this.Following = false;
				this.Routine = true;
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.Destinations[this.Phase];
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Pathfinding.speed = (float)1;
			}
			else if (this.Pushable)
			{
				this.Subtitle.UpdateLabel("Note Reaction", 5, (float)3);
				this.Prompt.Label[0].text = "     " + "Talk";
				this.Prompt.Circle[0].fillAmount = (float)1;
				this.Yandere.TargetStudent = this;
				this.Yandere.Attacking = true;
				this.Yandere.RoofPush = true;
				this.Yandere.CanMove = false;
				this.Routine = false;
				this.Pushed = true;
				this.Character.animation.CrossFade(this.PushedAnim);
			}
			else if (this.InEvent)
			{
				this.Subtitle.UpdateLabel("Event Apology", 1, (float)3);
				this.Prompt.Circle[0].fillAmount = (float)1;
			}
			else if (!this.Witness && this.Yandere.Bloodiness > (float)0)
			{
				this.Prompt.Circle[0].fillAmount = (float)1;
				this.YandereVisible = true;
				this.Alarm = (float)200;
			}
			else
			{
				this.Subtitle.UpdateLabel("Greeting", 0, (float)3);
				this.ShoulderCamera.OverShoulder = true;
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				this.Obstacle.enabled = true;
				this.Yandere.TargetStudent = this;
				this.Yandere.Obscurance.enabled = false;
				this.Yandere.YandereVision = false;
				this.Yandere.CanMove = false;
				this.Yandere.Talking = true;
				this.Reacted = false;
				this.Talking = true;
				this.Routine = false;
				this.StudentManager.DisablePrompts();
				this.DialogueWheel.HideShadows();
				if (!this.Witness || this.Forgave)
				{
					float a2 = 0.75f;
					Color color3 = this.DialogueWheel.Shadow[1].color;
					float num4 = color3.a = a2;
					Color color4 = this.DialogueWheel.Shadow[1].color = color3;
				}
				if (this.Complimented)
				{
					float a3 = 0.75f;
					Color color5 = this.DialogueWheel.Shadow[2].color;
					float num5 = color5.a = a3;
					Color color6 = this.DialogueWheel.Shadow[2].color = color5;
				}
				this.Yandere.WeaponMenu.KeyboardShow = false;
				this.Yandere.WeaponMenu.Show = false;
				this.DialogueWheel.Show = true;
				this.TalkTimer = (float)0;
			}
		}
		if (this.Prompt.Circle[2].fillAmount <= (float)0 && !this.Yandere.Attacking)
		{
			this.AttackReaction();
		}
		if (this.Talking)
		{
			if (this.Interaction == 0)
			{
				this.Character.animation.CrossFade(this.IdleAnim);
				if (this.TalkTimer == (float)0)
				{
					this.DialogueWheel.Impatience.fillAmount = this.DialogueWheel.Impatience.fillAmount + Time.deltaTime * 0.1f;
					if (this.DialogueWheel.Impatience.fillAmount > 0.5f && this.Subtitle.Timer == (float)0)
					{
						this.Subtitle.UpdateLabel("Impatience", 1, (float)5);
					}
					if (this.DialogueWheel.Impatience.fillAmount >= (float)1)
					{
						this.Subtitle.UpdateLabel("Impatience", 2, (float)3);
						this.DialogueWheel.End();
						this.WaitTimer = (float)0;
					}
				}
			}
			else if (this.Interaction == 1)
			{
				if (this.TalkTimer == (float)3)
				{
					this.Character.animation.CrossFade(this.Nod2Anim);
					this.Reputation.PendingRep = this.Reputation.PendingRep + (float)5;
					this.PendingRep += (float)5;
					for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
					{
						this.Outlines[i].color = new Color((float)0, (float)1, (float)0, (float)1);
					}
					this.Forgave = true;
					if (this.Witnessed == "Insanity" || this.Witnessed == "Weapon and Blood and Insanity" || this.Witnessed == "Weapon and Insanity" || this.Witnessed == "Blood and Insanity")
					{
						this.Subtitle.UpdateLabel("Forgiving Insanity", 0, (float)3);
					}
					else
					{
						this.Subtitle.UpdateLabel("Forgiving", 0, (float)3);
					}
				}
				else
				{
					if (this.Character.animation[this.Nod2Anim].time >= this.Character.animation[this.Nod2Anim].length)
					{
						this.Character.animation.CrossFade(this.IdleAnim);
					}
					if (this.TalkTimer <= (float)0)
					{
						this.IgnoreTimer = (float)5;
						this.DialogueWheel.End();
					}
				}
				this.TalkTimer -= Time.deltaTime;
			}
			else if (this.Interaction == 2)
			{
				if (this.TalkTimer == (float)3)
				{
					this.Subtitle.UpdateLabel("Student Compliment", 0, (float)3);
					this.Reputation.PendingRep = this.Reputation.PendingRep + (float)2;
					this.PendingRep += (float)2;
					this.Complimented = true;
				}
				this.Character.animation.CrossFade(this.LookDownAnim);
				this.TalkTimer -= Time.deltaTime;
				if (this.TalkTimer <= (float)0)
				{
					this.DialogueWheel.End();
				}
			}
			else if (this.Interaction == 4)
			{
				if (this.TalkTimer == (float)2)
				{
					this.Subtitle.UpdateLabel("Student Farewell", 0, (float)2);
				}
				this.Character.animation.CrossFade(this.IdleAnim);
				this.TalkTimer -= Time.deltaTime;
				if (this.TalkTimer <= (float)0)
				{
					this.DialogueWheel.End();
				}
			}
			else if (this.Interaction == 9)
			{
				if (this.TalkTimer == (float)2)
				{
					this.Character.animation.CrossFade(this.Nod1Anim);
					this.Subtitle.UpdateLabel("Student Follow", 0, (float)2);
				}
				else
				{
					if (this.Character.animation[this.Nod1Anim].time >= this.Character.animation[this.Nod1Anim].length)
					{
						this.Character.animation.CrossFade(this.IdleAnim);
					}
					if (this.TalkTimer <= (float)0)
					{
						this.DialogueWheel.End();
						this.Pathfinding.target = this.Yandere.transform;
						this.Prompt.Label[0].text = "     " + "Stop";
						this.Yandere.Follower = this;
						this.Yandere.Followers = this.Yandere.Followers + 1;
						this.Following = true;
					}
				}
				this.TalkTimer -= Time.deltaTime;
			}
			if (this.Waiting)
			{
				this.WaitTimer -= Time.deltaTime;
				if (this.WaitTimer <= (float)0)
				{
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Obstacle.enabled = false;
					this.Alarmed = false;
					this.Talking = false;
					this.Waiting = false;
					if (!this.Following)
					{
						this.Routine = true;
					}
					this.StudentManager.EnablePrompts();
				}
			}
			else
			{
				this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
			}
		}
		else if (this.Dying)
		{
			if (this.EventManager != null)
			{
				this.EventManager.EndEvent();
			}
			this.Alarm -= Time.deltaTime * (float)100;
			if (!this.Teacher)
			{
				this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1, Time.deltaTime * (float)10);
				if (!this.Dead)
				{
					this.Character.animation.CrossFade(this.DefendAnim);
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
					this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.1f);
				}
				else
				{
					this.Character.animation.CrossFade(this.DeathAnim);
					if (this.Character.animation[this.DeathAnim].time < (float)1)
					{
						this.transform.Translate(Vector3.back * Time.deltaTime);
					}
					else
					{
						this.BecomeRagdoll();
					}
				}
			}
			else
			{
				if (this.Yandere.Laughing)
				{
					this.Yandere.Laughing = false;
				}
				if (this.Yandere.Dipping)
				{
					this.Yandere.Dipping = false;
				}
				if (this.Yandere.RPGCamera.enabled)
				{
					this.Yandere.RPGCamera.enabled = false;
				}
				if (this.Phone.active)
				{
					this.Phone.active = false;
				}
				if (this.Police.Show)
				{
					this.Police.Show = false;
				}
				this.Character.animation.CrossFade(this.CounterAnim);
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
				this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * (float)1);
				this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
		}
		else if (this.Pushed)
		{
			this.Alarm -= Time.deltaTime * (float)100;
			this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1, Time.deltaTime * (float)10);
			if (this.Character.animation[this.PushedAnim].time >= this.Character.animation[this.PushedAnim].length)
			{
				this.BecomeRagdoll();
			}
		}
		else if (this.WitnessedMurder)
		{
			if (!this.Fleeing)
			{
				if (this.StudentID > 1 && this.EyeShrink < (float)1)
				{
					this.EyeShrink += Time.deltaTime * 0.2f;
				}
				this.Character.animation.CrossFade(this.ScaredAnim);
				this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
				this.AlarmTimer += Time.deltaTime;
				if (this.AlarmTimer > (float)5)
				{
					this.PersonaReaction();
					this.AlarmTimer = (float)0;
				}
				else if (this.AlarmTimer > (float)1 && !this.Reacted)
				{
					if (this.StudentID > 1)
					{
						if (!this.Teacher)
						{
							this.Subtitle.UpdateLabel("Murder Reaction", 1, (float)3);
						}
						else
						{
							this.Subtitle.UpdateLabel("Teacher Murder Reaction", 1, (float)3);
							this.StudentManager.Portal.active = false;
						}
					}
					else
					{
						this.Subtitle.UpdateLabel("Senpai Murder Reaction", 1, 4.5f);
						this.GameOverCause = "Murder";
						this.SenpaiNoticed();
						this.Character.animation.CrossFade(this.ScaredAnim);
						this.Yandere.ShoulderCamera.enabled = true;
						this.Yandere.ShoulderCamera.Noticed = true;
						this.Yandere.RPGCamera.enabled = false;
						this.enabled = false;
					}
					this.Reacted = true;
				}
			}
		}
		else if (this.Alarmed)
		{
			if (this.WitnessedCorpse)
			{
				this.Character.animation.CrossFade(this.ScaredAnim);
			}
			else if (this.StudentID > 1)
			{
				this.Character.animation.CrossFade(this.IdleAnim);
			}
			if (this.WitnessedCorpse)
			{
				this.targetRotation = Quaternion.LookRotation(this.Corpse.AllColliders[0].transform.position - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
			}
			else
			{
				this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
			}
			this.AlarmTimer += Time.deltaTime;
			this.Alarm -= Time.deltaTime * (float)100;
			if (this.AlarmTimer > (float)5)
			{
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				if (this.StudentID == 1 || this.Teacher)
				{
					this.IgnoreTimer = 0.0001f;
				}
				else
				{
					this.IgnoreTimer = (float)5;
				}
				this.Alarmed = false;
				this.Reacted = false;
				this.AlarmTimer = (float)0;
				if (this.WitnessedCorpse)
				{
					this.PersonaReaction();
				}
				else if (!this.Following)
				{
					this.Routine = true;
				}
			}
			else if (this.AlarmTimer > (float)1 && !this.Reacted)
			{
				if (this.Teacher)
				{
					if (!this.WitnessedCorpse)
					{
						if (this.Witnessed == "Weapon and Blood and Insanity")
						{
							this.Subtitle.UpdateLabel("Teacher Insanity Reaction", 1, (float)6);
							this.GameOverCause = "Insanity";
						}
						else if (this.Witnessed == "Weapon and Blood")
						{
							this.Subtitle.UpdateLabel("Teacher Weapon Reaction", 1, (float)6);
							this.GameOverCause = "Weapon";
						}
						else if (this.Witnessed == "Weapon and Insanity")
						{
							this.Subtitle.UpdateLabel("Teacher Insanity Reaction", 1, (float)6);
							this.GameOverCause = "Insanity";
						}
						else if (this.Witnessed == "Blood and Insanity")
						{
							this.Subtitle.UpdateLabel("Teacher Insanity Reaction", 1, (float)6);
							this.GameOverCause = "Insanity";
						}
						else if (this.Witnessed == "Weapon")
						{
							this.Subtitle.UpdateLabel("Teacher Weapon Reaction", 1, (float)6);
							this.GameOverCause = "Weapon";
						}
						else if (this.Witnessed == "Blood")
						{
							this.Subtitle.UpdateLabel("Teacher Blood Reaction", 1, (float)6);
							this.GameOverCause = "Blood";
						}
						else if (this.Witnessed == "Insanity")
						{
							this.Subtitle.UpdateLabel("Teacher Insanity Reaction", 1, (float)6);
							this.GameOverCause = "Insanity";
						}
						else if (this.Witnessed == "Lewd")
						{
							this.Subtitle.UpdateLabel("Teacher Lewd Reaction", 1, (float)6);
							this.GameOverCause = "Lewd";
						}
						else if (this.Witnessed == "Trespassing")
						{
							this.Subtitle.UpdateLabel("Teacher Trespassing Reaction", this.Concern, (float)5);
						}
					}
					else
					{
						this.Concern = 1;
						if (this.Witnessed == "Weapon and Blood and Insanity")
						{
							this.Subtitle.UpdateLabel("Teacher Insanity Hostile", 1, (float)6);
							this.GameOverCause = "Insanity";
							this.WitnessedMurder = true;
						}
						else if (this.Witnessed == "Weapon and Blood")
						{
							this.Subtitle.UpdateLabel("Teacher Weapon Hostile", 1, (float)6);
							this.GameOverCause = "Weapon";
							this.WitnessedMurder = true;
						}
						else if (this.Witnessed == "Weapon and Insanity")
						{
							this.Subtitle.UpdateLabel("Teacher Insanity Hostile", 1, (float)6);
							this.GameOverCause = "Insanity";
							this.WitnessedMurder = true;
						}
						else if (this.Witnessed == "Blood and Insanity")
						{
							this.Subtitle.UpdateLabel("Teacher Insanity Hostile", 1, (float)6);
							this.GameOverCause = "Insanity";
							this.WitnessedMurder = true;
						}
						else if (this.Witnessed == "Weapon")
						{
							this.Subtitle.UpdateLabel("Teacher Weapon Hostile", 1, (float)6);
							this.GameOverCause = "Weapon";
							this.WitnessedMurder = true;
						}
						else if (this.Witnessed == "Blood")
						{
							this.Subtitle.UpdateLabel("Teacher Blood Hostile", 1, (float)6);
							this.GameOverCause = "Blood";
							this.WitnessedMurder = true;
						}
						else if (this.Witnessed == "Insanity")
						{
							this.Subtitle.UpdateLabel("Teacher Insanity Hostile", 1, (float)6);
							this.GameOverCause = "Insanity";
							this.WitnessedMurder = true;
						}
						else if (this.Witnessed == "Lewd")
						{
							this.Subtitle.UpdateLabel("Teacher Lewd Reaction", 1, (float)6);
							this.GameOverCause = "Lewd";
						}
						else if (this.Witnessed == "Trespassing")
						{
							this.Subtitle.UpdateLabel("Teacher Trespassing Reaction", this.Concern, (float)5);
						}
						else if (this.Witnessed == "Corpse")
						{
							this.Subtitle.UpdateLabel("Teacher Corpse Reaction", 1, (float)3);
							this.Police.Called = true;
						}
					}
					if (this.Concern == 5)
					{
						this.Character.animation[this.AngryFaceAnim].weight = (float)1;
						this.Yandere.ShoulderCamera.enabled = true;
						this.Yandere.ShoulderCamera.Noticed = true;
						this.Yandere.RPGCamera.enabled = false;
						this.enabled = false;
					}
				}
				else if (this.StudentID > 1)
				{
					if (this.RepeatReaction)
					{
						this.Subtitle.UpdateLabel("Repeat Reaction", 1, (float)3);
						this.RepeatReaction = false;
					}
					else if (this.Witnessed == "Weapon and Blood and Insanity")
					{
						this.Subtitle.UpdateLabel("Weapon and Blood and Insanity Reaction", 1, (float)3);
					}
					else if (this.Witnessed == "Weapon and Blood")
					{
						this.Subtitle.UpdateLabel("Weapon and Blood Reaction", 1, (float)3);
					}
					else if (this.Witnessed == "Weapon and Insanity")
					{
						this.Subtitle.UpdateLabel("Weapon and Insanity Reaction", 1, (float)3);
					}
					else if (this.Witnessed == "Blood and Insanity")
					{
						this.Subtitle.UpdateLabel("Blood and Insanity Reaction", 1, (float)3);
					}
					else if (this.Witnessed == "Weapon")
					{
						this.Subtitle.UpdateLabel("Weapon Reaction", this.WeaponWitnessed, (float)3);
					}
					else if (this.Witnessed == "Blood")
					{
						this.Subtitle.UpdateLabel("Blood Reaction", 1, (float)3);
					}
					else if (this.Witnessed == "Insanity")
					{
						this.Subtitle.UpdateLabel("Insanity Reaction", 1, (float)3);
					}
					else if (this.Witnessed == "Lewd")
					{
						this.Subtitle.UpdateLabel("Lewd Reaction", 1, (float)3);
					}
					else if (this.Witnessed == "Corpse")
					{
						this.Subtitle.UpdateLabel("Corpse Reaction", 1, (float)5);
					}
					else if (this.Witnessed == "Interruption")
					{
						this.Subtitle.UpdateLabel("Interruption Reaction", 1, (float)5);
					}
				}
				else
				{
					if (this.Witnessed == "Weapon and Blood and Insanity")
					{
						this.Subtitle.UpdateLabel("Senpai Insanity Reaction", 1, 4.5f);
						this.GameOverCause = "Insanity";
					}
					else if (this.Witnessed == "Weapon and Blood")
					{
						this.Subtitle.UpdateLabel("Senpai Weapon Reaction", 1, 4.5f);
						this.GameOverCause = "Weapon";
					}
					else if (this.Witnessed == "Weapon and Insanity")
					{
						this.Subtitle.UpdateLabel("Senpai Insanity Reaction", 1, 4.5f);
						this.GameOverCause = "Insanity";
					}
					else if (this.Witnessed == "Blood and Insanity")
					{
						this.Subtitle.UpdateLabel("Senpai Insanity Reaction", 1, 4.5f);
						this.GameOverCause = "Insanity";
					}
					else if (this.Witnessed == "Weapon")
					{
						this.Subtitle.UpdateLabel("Senpai Weapon Reaction", 1, 4.5f);
						this.GameOverCause = "Weapon";
					}
					else if (this.Witnessed == "Blood")
					{
						this.Subtitle.UpdateLabel("Senpai Blood Reaction", 1, 4.5f);
						this.GameOverCause = "Blood";
					}
					else if (this.Witnessed == "Insanity")
					{
						this.Subtitle.UpdateLabel("Senpai Insanity Reaction", 1, 4.5f);
						this.GameOverCause = "Insanity";
					}
					else if (this.Witnessed == "Lewd")
					{
						this.Subtitle.UpdateLabel("Senpai Lewd Reaction", 1, 4.5f);
						this.GameOverCause = "Lewd";
					}
					else if (this.Witnessed == "Stalking")
					{
						this.Subtitle.UpdateLabel("Senpai Stalking Reaction", this.Concern, 4.5f);
						this.GameOverCause = "Stalking";
					}
					else if (this.Witnessed == "Corpse")
					{
						this.Subtitle.UpdateLabel("Senpai Corpse Reaction", 1, (float)5);
					}
					if (this.Concern == 5)
					{
						this.Yandere.ShoulderCamera.enabled = true;
						this.Yandere.ShoulderCamera.Noticed = true;
						this.Yandere.RPGCamera.enabled = false;
						this.enabled = false;
					}
				}
				this.Reacted = true;
			}
		}
		if (this.IgnoreTimer > (float)0)
		{
			this.IgnoreTimer -= Time.deltaTime;
		}
		if (this.AoT)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)10, (float)10, (float)10), Time.deltaTime);
		}
		if (!this.Fleeing && this.transform.position.y < (float)0)
		{
			int num6 = 0;
			Vector3 position = this.transform.position;
			float num7 = position.y = (float)num6;
			Vector3 vector2 = this.transform.position = position;
		}
		int num8 = 0;
		Vector3 localEulerAngles = this.transform.localEulerAngles;
		float num9 = localEulerAngles.x = (float)num8;
		Vector3 vector3 = this.transform.localEulerAngles = localEulerAngles;
	}

	public virtual void LateUpdate()
	{
		float z = this.LeftEyeOrigin.z - this.EyeShrink * 0.01f;
		Vector3 localPosition = this.LeftEye.localPosition;
		float num = localPosition.z = z;
		Vector3 vector = this.LeftEye.localPosition = localPosition;
		float z2 = this.RightEyeOrigin.z + this.EyeShrink * 0.01f;
		Vector3 localPosition2 = this.RightEye.localPosition;
		float num2 = localPosition2.z = z2;
		Vector3 vector2 = this.RightEye.localPosition = localPosition2;
		float x = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale = this.LeftEye.localScale;
		float num3 = localScale.x = x;
		Vector3 vector3 = this.LeftEye.localScale = localScale;
		float y = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale2 = this.LeftEye.localScale;
		float num4 = localScale2.y = y;
		Vector3 vector4 = this.LeftEye.localScale = localScale2;
		float x2 = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale3 = this.RightEye.localScale;
		float num5 = localScale3.x = x2;
		Vector3 vector5 = this.RightEye.localScale = localScale3;
		float y2 = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale4 = this.RightEye.localScale;
		float num6 = localScale4.y = y2;
		Vector3 vector6 = this.RightEye.localScale = localScale4;
		if (!this.Male)
		{
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			if (this.HidePony)
			{
				this.Ponytail.parent.transform.localScale = new Vector3((float)1, (float)1, 0.93f);
				this.Ponytail.localScale = new Vector3((float)0, (float)0, (float)0);
				this.HairR.localScale = new Vector3((float)0, (float)0, (float)0);
				this.HairL.localScale = new Vector3((float)0, (float)0, (float)0);
			}
			if (this.ShortHair)
			{
				this.HairR.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				this.HairL.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			}
		}
	}

	public virtual void MoveTowardsTarget(Vector3 target)
	{
		if (Time.timeScale > (float)0)
		{
			Vector3 a = target - this.transform.position;
			float d = Vector3.Distance(this.transform.position, target);
			a = a.normalized * d;
			this.MyController.Move(a * (Time.deltaTime * (float)10 / Time.timeScale));
		}
	}

	public virtual void AttackReaction()
	{
		this.WitnessCamera.Show = false;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Yandere.Character.animation["f02_idleShort_00"].time = (float)0;
		this.Yandere.MyController.radius = (float)0;
		this.Yandere.TargetStudent = this;
		this.Yandere.Obscurance.enabled = false;
		this.Yandere.YandereVision = false;
		this.Yandere.Attacking = true;
		this.Yandere.CanMove = false;
		this.MyController.radius = (float)0;
		this.Alarmed = false;
		this.Fleeing = false;
		this.Routine = false;
		this.Dying = true;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		if (!this.Dying && this.Following)
		{
			this.Yandere.Followers = this.Yandere.Followers - 1;
			this.Following = false;
			Debug.Log("Here?");
		}
		if (this.Teacher)
		{
			this.Yandere.HeartRate.gameObject.active = false;
			this.Yandere.ShoulderCamera.Counter = true;
			this.ShoulderCamera.OverShoulder = false;
			this.Yandere.RPGCamera.enabled = false;
			this.Yandere.Senpai = this.transform;
			this.Yandere.Talking = false;
			this.Yandere.Noticed = true;
			this.Yandere.HUD.alpha = (float)0;
		}
		else
		{
			this.Subtitle.UpdateLabel("Dying", 0, (float)1);
		}
	}

	public virtual void SenpaiNoticed()
	{
		if (!this.Yandere.Attacking && this.Yandere.Armed)
		{
			this.Yandere.Weapon[this.Yandere.Equipped].Drop();
		}
		if (this.Yandere.Dragging)
		{
			this.Yandere.EmptyHands();
		}
		this.Yandere.Senpai = this.transform;
		if (this.Yandere.Aiming)
		{
			this.Yandere.StopAiming();
		}
		this.Yandere.DetectionPanel.alpha = (float)0;
		this.Yandere.RPGCamera.mouseSpeed = (float)0;
		this.Yandere.HUD.alpha = (float)0;
		this.Yandere.EyeShrink = (float)0;
		this.Yandere.Sanity = (float)100;
		this.Yandere.HeartRate.gameObject.active = false;
		this.ShoulderCamera.OverShoulder = false;
		this.Yandere.Obscurance.enabled = false;
		this.Yandere.YandereVision = false;
		this.Yandere.Police.Show = false;
		this.Yandere.Crouching = false;
		this.Yandere.Crawling = false;
		this.Yandere.Laughing = false;
		this.Yandere.CanMove = false;
		this.Yandere.Dipping = false;
		this.Yandere.Mopping = false;
		this.Yandere.Talking = false;
		this.Yandere.Noticed = true;
		this.Yandere.Jukebox.GameOver();
		this.Yandere.UpdateSanity();
		this.StudentManager.StopMoving();
		if (this.Teacher)
		{
			this.enabled = true;
		}
	}

	public virtual void WitnessMurder()
	{
		if (this.StudentID > 1)
		{
			for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
			{
				this.Outlines[i].color = new Color((float)1, (float)0, (float)0, (float)1);
				this.Outlines[i].enabled = true;
			}
			this.WitnessCamera.transform.parent = this.WitnessPOV;
			this.WitnessCamera.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
			this.WitnessCamera.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.WitnessCamera.MyCamera.enabled = true;
			this.WitnessCamera.Show = true;
			this.CameraEffects.MurderWitnessed();
			this.Witnessed = "Murder";
			this.Police.Witnesses = this.Police.Witnesses + 1;
			if (this.Teacher)
			{
				this.StudentManager.Reporter = this;
			}
			if (this.Talking)
			{
				this.DialogueWheel.End();
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Obstacle.enabled = false;
				this.Talking = false;
				this.Waiting = false;
				this.StudentManager.EnablePrompts();
			}
		}
		else
		{
			if (!this.Yandere.Attacking)
			{
				this.SenpaiNoticed();
			}
			this.EyeShrink = (float)0;
			this.Fleeing = false;
			this.Yandere.Noticed = true;
			this.Yandere.Talking = false;
			this.CameraEffects.MurderWitnessed();
			this.ShoulderCamera.OverShoulder = false;
			this.Character.animation.CrossFade(this.ScaredAnim);
			this.Character.animation["scaredFace_00"].weight = (float)1;
		}
		if (this.Persona == 2 && this.StudentManager.Reporter == null && !this.Police.Called)
		{
			this.StudentManager.CorpseLocation.position = this.Yandere.transform.position;
			this.StudentManager.Reporter = this;
			this.Reporting = true;
		}
		if (this.Following)
		{
			this.Yandere.Followers = this.Yandere.Followers - 1;
			this.Following = false;
		}
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Prompt.Label[0].text = "     " + "Talk";
		this.Prompt.HideButton[0] = true;
		this.WitnessedMurder = true;
		this.Reacted = false;
		this.Routine = false;
		this.Alarmed = true;
		this.AlarmTimer = (float)0;
		this.Alarm = (float)0;
		if (this.Teacher)
		{
			this.Pathfinding.target = this.Yandere.transform;
		}
		this.StudentManager.UpdateMe(this.StudentID - 1);
	}

	public virtual void PersonaReaction()
	{
		if (this.Persona == 1)
		{
			if (this.WitnessedMurder)
			{
				this.Subtitle.UpdateLabel("Coward Murder Reaction", 1, (float)3);
			}
			else
			{
				this.Subtitle.UpdateLabel("Coward Corpse Reaction", 1, (float)3);
			}
			this.Pathfinding.target = this.StudentManager.Exit;
			this.TargetDistance = (float)0;
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == 2)
		{
			if (this.StudentManager.Reporter == this)
			{
				this.Pathfinding.target = this.StudentManager.Teachers[this.Class].TeacherTalkPoint;
				if (this.WitnessedMurder)
				{
					this.Subtitle.UpdateLabel("Pet Murder Report", 1, (float)3);
				}
				else
				{
					this.Subtitle.UpdateLabel("Pet Corpse Report", 1, (float)3);
				}
				this.TargetDistance = (float)2;
			}
			else
			{
				this.Pathfinding.target = this.StudentManager.Seats.List[this.StudentID];
				if (this.WitnessedMurder)
				{
					this.Subtitle.UpdateLabel("Pet Murder Reaction", 1, (float)3);
				}
				else
				{
					this.Subtitle.UpdateLabel("Pet Corpse Reaction", 1, (float)3);
				}
				this.TargetDistance = (float)1;
			}
			this.Routine = false;
			this.Fleeing = true;
		}
		else
		{
			if (this.WitnessedMurder)
			{
				this.Subtitle.UpdateLabel("Teacher Murder Reaction", 1, (float)3);
				this.Pathfinding.target = this.Yandere.transform;
				this.StudentManager.Portal.active = false;
				this.Yandere.Chased = true;
				this.TargetDistance = 0.5f;
				this.StudentManager.UpdateStudents();
			}
			else if (this.WitnessedCorpse)
			{
				if (this.ReportPhase == 0)
				{
					this.Subtitle.UpdateLabel("Teacher Corpse Reaction", 1, (float)3);
				}
				this.Pathfinding.target = this.Corpse.AllColliders[0].transform;
				this.TargetDistance = (float)1;
				this.ReportPhase = 2;
			}
			this.Routine = false;
			this.Fleeing = true;
		}
	}

	public virtual void GetDestinations()
	{
		this.DestinationNames = (string[])this.JSON.StudentDestinations[this.StudentID].ToBuiltin(typeof(string));
		for (int i = 1; i < this.JSON.StudentDestinations[this.StudentID].length; i++)
		{
			if (this.DestinationNames[i] == "Locker")
			{
				this.Destinations[i] = this.StudentManager.Lockers.List[this.StudentID];
			}
			else if (this.DestinationNames[i] == "Seat")
			{
				this.Destinations[i] = this.StudentManager.Seats.List[this.StudentID];
			}
			else if (this.DestinationNames[i] == "Podium")
			{
				this.Destinations[i] = this.StudentManager.Podiums.List[this.Class];
			}
			else if (this.DestinationNames[i] == "Exit")
			{
				this.Destinations[i] = this.StudentManager.Hangouts.List[0];
			}
			else if (this.DestinationNames[i] == "Hangout")
			{
				this.Destinations[i] = this.StudentManager.Hangouts.List[this.StudentID];
			}
			else if (this.DestinationNames[i] == "LunchSpot")
			{
				this.Destinations[i] = this.StudentManager.LunchSpots.List[this.StudentID];
			}
		}
		this.ActionNames = (string[])this.JSON.StudentActions[this.StudentID].ToBuiltin(typeof(string));
		for (int i = 1; i < this.JSON.StudentActions[this.StudentID].length; i++)
		{
			if (this.ActionNames[i] == "Stand")
			{
				this.Actions[i] = 0;
			}
			else if (this.ActionNames[i] == "Socialize")
			{
				this.Actions[i] = 1;
			}
			else if (this.ActionNames[i] == "Game")
			{
				this.Actions[i] = 2;
			}
		}
	}

	public virtual void SetColors()
	{
		string a = this.JSON.StudentColors[this.StudentID];
		string a2 = this.JSON.StudentStockings[this.StudentID];
		if (!this.Male)
		{
			if (a == "Red")
			{
				this.HairTexture = this.StudentManager.Colors[0];
			}
			else if (a == "Yellow")
			{
				this.HairTexture = this.StudentManager.Colors[1];
			}
			else if (a == "Green")
			{
				this.HairTexture = this.StudentManager.Colors[2];
			}
			else if (a == "Cyan")
			{
				this.HairTexture = this.StudentManager.Colors[3];
			}
			else if (a == "Blue")
			{
				this.HairTexture = this.StudentManager.Colors[4];
			}
			else if (a == "Purple")
			{
				this.HairTexture = this.StudentManager.Colors[5];
				this.DrillTexture = this.StudentManager.Colors[6];
			}
			else if (a == "Brown")
			{
				this.HairTexture = this.StudentManager.Colors[7];
			}
			else if (a == "Pippi")
			{
				this.HairTexture = this.StudentManager.Colors[8];
			}
			if (!this.Teacher)
			{
				this.MyRenderer.materials[1].mainTexture = this.HairTexture;
				this.MyRenderer.materials[3].mainTexture = this.HairTexture;
			}
			else
			{
				this.MyRenderer.materials[1].mainTexture = this.HairTexture;
				this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			}
		}
		else
		{
			if (a == "Red")
			{
				this.HairTexture = this.StudentManager.MaleColors[0];
			}
			else if (a == "Yellow")
			{
				this.HairTexture = this.StudentManager.MaleColors[1];
			}
			else if (a == "Green")
			{
				this.HairTexture = this.StudentManager.MaleColors[2];
			}
			else if (a == "Cyan")
			{
				this.HairTexture = this.StudentManager.MaleColors[3];
			}
			else if (a == "Blue")
			{
				this.HairTexture = this.StudentManager.MaleColors[4];
			}
			else if (a == "Purple")
			{
				this.HairTexture = this.StudentManager.MaleColors[5];
			}
			else if (a == "Black")
			{
				this.HairTexture = this.StudentManager.MaleColors[6];
			}
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.HairTexture;
		}
		if (a2 == "Socks")
		{
			this.MyRenderer.materials[0].mainTexture = this.StudentManager.Stockings[0];
		}
		if (!this.Male)
		{
			this.PigtailR.material.mainTexture = this.HairTexture;
			this.PigtailL.material.mainTexture = this.HairTexture;
			if (this.DrillTexture != null)
			{
				this.Drills.materials[0].mainTexture = this.DrillTexture;
				this.Drills.materials[1].mainTexture = this.DrillTexture;
				this.Drills.materials[2].mainTexture = this.DrillTexture;
			}
		}
		for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
		{
			this.Outlines[i].h.ReinitMaterials();
		}
	}

	public virtual void UpdateHair()
	{
		this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailR.active = false;
		this.PigtailL.active = false;
		this.Drills.active = false;
		this.HidePony = true;
		if (this.Hairstyle == "PonyTail")
		{
			this.HidePony = false;
			this.Ponytail.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairR.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairL.localScale = new Vector3((float)1, (float)1, (float)1);
		}
		else if (this.Hairstyle == "RightTail")
		{
			this.PigtailR.active = true;
		}
		else if (this.Hairstyle == "LeftTail")
		{
			this.PigtailL.active = true;
		}
		else if (this.Hairstyle == "PigTails")
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
		}
		else if (this.Hairstyle == "TriTails")
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
			this.HidePony = false;
			this.Ponytail.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairR.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairL.localScale = new Vector3((float)1, (float)1, (float)1);
		}
		else if (this.Hairstyle == "TwinTails")
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
			this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
			this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
		}
		else if (this.Hairstyle == "Drills")
		{
			this.Drills.active = true;
		}
		else if (this.Hairstyle == "Short")
		{
			this.ShortHair = true;
		}
	}

	public virtual void TransferHair()
	{
		for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
		{
			this.Outlines[i].color = new Color((float)1, 0.5f, (float)0, (float)1);
			this.Outlines[i].enabled = true;
		}
		this.Ragdoll.HidePony = this.HidePony;
	}

	public virtual void PickRandomAnim()
	{
		this.RandomAnim = this.AnimationNames[UnityEngine.Random.Range(0, Extensions.get_length(this.AnimationNames))];
	}

	public virtual void BecomeTeacher()
	{
		this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
		this.StudentManager.Teachers[this.Class] = this;
		this.MyRenderer.sharedMesh = this.TeacherMesh;
		this.PantyCollider.enabled = false;
		this.SkirtCollider.enabled = false;
		this.VisionCone.farClipPlane = (float)12;
		this.name = "Teacher_" + this.Class;
		this.Teacher = true;
		this.MyRenderer.materials[0].mainTexture = this.TeacherTexture;
		this.MyRenderer.materials[3].mainTexture = this.TeacherTexture;
	}

	public virtual void AttackOnTitan()
	{
		this.AoT = true;
		float y = 0.0825f;
		Vector3 center = this.MyController.center;
		float num = center.y = y;
		Vector3 vector = this.MyController.center = center;
		this.MyController.radius = 0.015f;
		this.MyController.height = 0.15f;
		this.MyRenderer.sharedMesh = this.NudeMesh;
		if (!this.Male)
		{
			this.MyRenderer.materials[3].mainTexture = this.NudeTexture;
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
		}
		else
		{
			this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
		}
		for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
		{
			this.Outlines[i].h.ReinitMaterials();
		}
		if (!this.Male && !this.Teacher)
		{
			this.PantyCollider.enabled = false;
			this.SkirtCollider.enabled = false;
		}
	}

	public virtual void RemoveShoes()
	{
		this.MyRenderer.materials[0].mainTexture = this.SocksTexture;
	}

	public virtual void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(obj.transform);
		while (enumerator.MoveNext())
		{
			object obj2 = enumerator.Current;
			object obj4;
			object obj3 = obj4 = obj2;
			if (!(obj3 is Transform))
			{
				obj4 = RuntimeServices.Coerce(obj3, typeof(Transform));
			}
			Transform transform = (Transform)obj4;
			this.SetLayerRecursively(transform.gameObject, newLayer);
			UnityRuntimeServices.Update(enumerator, transform);
		}
	}

	public virtual void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(obj.transform);
		while (enumerator.MoveNext())
		{
			object obj2 = enumerator.Current;
			object obj4;
			object obj3 = obj4 = obj2;
			if (!(obj3 is Transform))
			{
				obj4 = RuntimeServices.Coerce(obj3, typeof(Transform));
			}
			Transform transform = (Transform)obj4;
			this.SetTagRecursively(transform.gameObject, newTag);
			UnityRuntimeServices.Update(enumerator, transform);
		}
	}

	public virtual void BecomeRagdoll()
	{
		if (this.Pushed)
		{
			this.Police.SuicideScene = true;
			this.Ragdoll.Suicide = true;
			this.Police.Suicide = true;
		}
		else if (!this.Tranquil && !this.Ragdoll.Natural)
		{
			this.Police.MurderScene = true;
		}
		if (!this.Tranquil)
		{
			this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
			this.Police.Corpses = this.Police.Corpses + 1;
		}
		this.Ragdoll.AllColliders[10].isTrigger = false;
		this.NotFaceCollider.enabled = false;
		this.FaceCollider.enabled = false;
		this.MyController.enabled = false;
		this.Pathfinding.enabled = false;
		this.HipCollider.enabled = true;
		this.Prompt.enabled = false;
		this.enabled = false;
		this.Ragdoll.RightEyeOrigin = this.RightEyeOrigin;
		this.Ragdoll.LeftEyeOrigin = this.LeftEyeOrigin;
		this.Ragdoll.BreastSize = this.BreastSize;
		this.Ragdoll.EyeShrink = this.EyeShrink;
		this.Ragdoll.Tranquil = this.Tranquil;
		this.Ragdoll.Yandere = this.Yandere;
		this.Ragdoll.Police = this.Police;
		this.Ragdoll.Male = this.Male;
		this.Ragdoll.enabled = true;
		this.Reputation.PendingRep = this.Reputation.PendingRep + this.PendingRep * (float)-1;
		if (this.WitnessedMurder)
		{
			this.Police.Witnesses = this.Police.Witnesses - 1;
		}
		this.TransferHair();
		UnityEngine.Object.Destroy(this.DetectionMarker);
		this.SetLayerRecursively(this.gameObject, 11);
		this.tag = "Blood";
		PlayerPrefs.SetInt("Student_" + this.StudentID + "_Dying", 1);
	}

	public virtual void Main()
	{
	}
}
