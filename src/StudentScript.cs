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

	public LightSwitchScript LightSwitch;

	public MovingEventScript MovingEvent;

	public ToiletEventScript ToiletEvent;

	public DynamicGridObstacle Obstacle;

	public PhoneEventScript PhoneEvent;

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

	public Projector LiquidProjector;

	public Texture BloodTexture;

	public Texture WaterTexture;

	public Texture DrillTexture;

	public Texture HairTexture;

	public Camera VisionCone;

	public Color EyeColor;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer MaleHairRenderer;

	public Renderer PonyRenderer;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public Renderer EyeR;

	public Renderer EyeL;

	public Transform CurrentDestination;

	public Transform TeacherTalkPoint;

	public Transform MyReporter;

	public Transform WitnessPOV;

	public Transform RightHand;

	public Transform LeftHand;

	public Transform MeetSpot;

	public Transform DrillR;

	public Transform DrillL;

	public Transform Head;

	public Transform Eyes;

	public ParticleSystem[] LiquidEmitters;

	public Texture[] FemaleUniformTextures;

	public Texture[] MaleUniformTextures;

	public GameObject[] MaleHairstyles;

	public string[] DestinationNames;

	public OutlineScript[] Outlines;

	public Transform[] Destinations;

	public GameObject[] Chopsticks;

	public string[] AnimationNames;

	public Texture[] FaceTextures;

	public Texture[] SkinTextures;

	public Mesh[] FemaleUniforms;

	public string[] ActionNames;

	public GameObject[] Eyewear;

	public Mesh[] MaleUniforms;

	public float[] PhaseTimes;

	public GameObject[] Bones;

	public Transform[] Arm;

	public LayerMask Mask;

	public Plane[] Planes;

	public int[] Actions;

	public SphereCollider HipCollider;

	public Collider NotFaceCollider;

	public Collider PantyCollider;

	public Collider SkirtCollider;

	public Collider FaceCollider;

	public GameObject DeathScream;

	public GameObject BloodSpray;

	public GameObject MainCamera;

	public GameObject AlarmDisc;

	public GameObject Character;

	public GameObject LongHair;

	public GameObject Marker;

	public GameObject Bento;

	public GameObject Phone;

	public bool WitnessedCorpse;

	public bool WitnessedMurder;

	public bool RepeatReaction;

	public bool YandereVisible;

	public bool FleeWhenClean;

	public bool Complimented;

	public bool Electrocuted;

	public bool Distracted;

	public bool InDarkness;

	public bool BatheFast;

	public bool DiscCheck;

	public bool ShortHair;

	public bool HidePony;

	public bool Pushable;

	public bool Splashed;

	public bool Tranquil;

	public bool Alarmed;

	public bool Drowned;

	public bool Forgave;

	public bool InEvent;

	public bool Private;

	public bool Reacted;

	public bool Teacher;

	public bool Witness;

	public bool Bloody;

	public bool Routine;

	public bool Pushed;

	public bool Dead;

	public bool Halt;

	public bool Male;

	public bool Safe;

	public bool Stop;

	public bool Wet;

	public bool DK;

	public bool Following;

	public bool Reporting;

	public bool Fleeing;

	public bool Meeting;

	public bool Talking;

	public bool Waiting;

	public bool Dying;

	public float DistanceToDestination;

	public float DistanceToPlayer;

	public float TargetDistance;

	public float ElectroTimer;

	public float IgnoreTimer;

	public float ReportTimer;

	public float SplashTimer;

	public float AlarmTimer;

	public float MeetTimer;

	public float TalkTimer;

	public float WaitTimer;

	public float PreviousAlarm;

	public float BreastSize;

	public float PendingRep;

	public float EyeShrink;

	public float MeetTime;

	public float Paranoia;

	public float RepLoss;

	public float Alarm;

	public int WeaponWitnessed;

	public int Interaction;

	public int SplashPhase;

	public int BathePhase;

	public int Schoolwear;

	public int SkinColor;

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

	public string DrownAnim;

	public string WetAnim;

	public string SplashedAnim;

	public string StripAnim;

	public string ParanoidAnim;

	public int ReportPhase;

	public int StudentID;

	public int Persona;

	public int Class;

	public int Club;

	public int ID;

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

	public Texture[] SocksTextures;

	public GameObject[] ElectroSteam;

	public GameObject[] CensorSteam;

	public Texture NudeTexture;

	public Mesh BaldNudeMesh;

	public Mesh NudeMesh;

	public Mesh SchoolUniform;

	public Mesh SchoolSwimsuit;

	public Mesh GymUniform;

	public Texture UniformTexture;

	public Texture SwimsuitTexture;

	public Texture GymTexture;

	public bool AoT;

	public bool Spooky;

	public StudentScript()
	{
		this.Routine = true;
		this.SkinColor = 3;
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
		this.DrownAnim = string.Empty;
		this.WetAnim = string.Empty;
		this.SplashedAnim = string.Empty;
		this.StripAnim = string.Empty;
		this.ParanoidAnim = string.Empty;
		this.MaxSpeed = 10f;
	}

	public virtual void Start()
	{
		if (PlayerPrefs.GetFloat("SchoolAtmosphere") <= 33.33333f)
		{
			this.IdleAnim = this.ParanoidAnim;
		}
		this.Paranoia = (float)2 - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f;
		this.VisionCone.farClipPlane = (float)10 * this.Paranoia;
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
			this.Character.animation[this.StripAnim].speed = 1.5f;
			this.Character.animation[this.GameAnim].speed = (float)2;
			this.UpdateHair();
			this.SetColors();
			if (this.Club == 9)
			{
				this.BecomeTeacher();
			}
			this.Character.animation[this.WetAnim].layer = 4;
			this.Character.animation.Play(this.WetAnim);
			this.Character.animation[this.WetAnim].weight = (float)0;
			this.Character.animation[this.BentoAnim].layer = 3;
			this.Character.animation.Play(this.BentoAnim);
			this.Character.animation[this.BentoAnim].weight = (float)0;
			this.Character.animation[this.AngryFaceAnim].layer = 2;
			this.Character.animation.Play(this.AngryFaceAnim);
			this.Character.animation[this.AngryFaceAnim].weight = (float)0;
			this.Character.animation[this.PhoneAnim].layer = 1;
			this.Character.animation[this.PhoneAnim].weight = (float)0;
			this.Character.animation.Play(this.PhoneAnim);
			this.Character.animation["f02_wetIdle_00"].speed = 1.25f;
			this.LiquidProjector.enabled = false;
			this.Bento.active = false;
			this.Chopsticks[0].active = false;
			this.Chopsticks[1].active = false;
			this.ElectroSteam[0].active = false;
			this.ElectroSteam[1].active = false;
			this.ElectroSteam[2].active = false;
			this.ElectroSteam[3].active = false;
			this.CensorSteam[0].active = false;
			this.CensorSteam[1].active = false;
			this.CensorSteam[2].active = false;
			this.CensorSteam[3].active = false;
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.LiquidEmitters))
			{
				this.LiquidEmitters[this.ID].gameObject.active = false;
				this.ID++;
			}
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Bones))
			{
				this.Bones[this.ID].active = false;
				this.ID++;
			}
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
			if (this.StudentID == 15)
			{
				this.Character.animation["angryMouth_00"].layer = 4;
				this.Character.animation.Play("angryMouth_00");
				this.Character.animation[this.GameAnim].speed = (float)2;
			}
		}
		if (this.AoT)
		{
			this.AttackOnTitan();
		}
		if (this.Spooky)
		{
			this.Spook();
		}
		this.Prompt.HideButton[0] = true;
		this.Prompt.HideButton[2] = true;
		this.ID = 0;
		while (this.ID < this.Ragdoll.AllRigidbodies.Length)
		{
			this.Ragdoll.AllRigidbodies[this.ID].isKinematic = true;
			this.Ragdoll.AllColliders[this.ID].enabled = false;
			this.ID++;
		}
		this.Ragdoll.AllColliders[10].enabled = true;
		if (this.StudentID == 1)
		{
			if (PlayerPrefs.GetInt("SenpaiEyeWear") > 0)
			{
				this.Eyewear[PlayerPrefs.GetInt("SenpaiEyeWear")].active = true;
			}
			((DetectionMarkerScript)this.DetectionMarker.GetComponent(typeof(DetectionMarkerScript))).Tex.color = new Color((float)1, (float)0, (float)0, (float)0);
			this.Yandere.Senpai = this.transform;
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Outlines))
			{
				this.Outlines[this.ID].enabled = true;
				this.Outlines[this.ID].color = new Color((float)1, (float)0, (float)1);
				this.ID++;
			}
			this.Prompt.ButtonActive[0] = false;
			this.Prompt.ButtonActive[1] = false;
			this.Prompt.ButtonActive[2] = false;
			this.Prompt.ButtonActive[3] = false;
		}
		else if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Photographed") == 0)
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Outlines))
			{
				this.Outlines[this.ID].enabled = false;
				this.Outlines[this.ID].color = new Color((float)0, (float)1, (float)0);
				this.ID++;
			}
		}
	}

	public virtual void Update()
	{
		if (!this.Stop)
		{
			if (this.Routine)
			{
				if (this.Phase < Extensions.get_length(this.PhaseTimes) - 1)
				{
					if (this.Clock.HourTime >= this.PhaseTimes[this.Phase] && !this.InEvent)
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
					if (this.Pathfinding.speed == (float)1)
					{
						this.Character.animation.CrossFade(this.WalkAnim);
						this.Character.animation[this.WalkAnim].speed = this.Pathfinding.currentSpeed;
					}
					else
					{
						this.Character.animation.CrossFade(this.SprintAnim);
					}
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
							if (PlayerPrefs.GetFloat("SchoolAtmosphere") < 33.33333f)
							{
								this.Character.animation.CrossFade(this.IdleAnim);
							}
							else
							{
								this.Character.animation.CrossFade(this.RandomAnim);
								if (this.Character.animation[this.RandomAnim].time >= this.Character.animation[this.RandomAnim].length)
								{
									this.PickRandomAnim();
								}
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
				if (this.CurrentDestination != null)
				{
					this.DistanceToDestination = Vector3.Distance(this.transform.position, this.CurrentDestination.position);
				}
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
								this.Pathfinding.speed = 7.5f;
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
									if (this.StudentManager.Teachers[this.Class].Alarmed)
									{
										this.Pathfinding.target = this.StudentManager.Seats.List[this.StudentID];
										this.CurrentDestination = this.StudentManager.Seats.List[this.StudentID];
										this.ReportPhase = 2;
									}
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
				if (this.Wet)
				{
					if (this.DistanceToDestination < this.TargetDistance)
					{
						if (!this.Splashed)
						{
							if (!this.InDarkness)
							{
								if (this.BathePhase == 1)
								{
									this.StudentManager.CommunalLocker.Open = true;
									this.StudentManager.CommunalLocker.Student = this;
									this.StudentManager.CommunalLocker.SpawnSteam();
									this.Pathfinding.speed = (float)1;
									this.Schoolwear = 0;
									this.BathePhase++;
								}
								else if (this.BathePhase == 2)
								{
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * (float)10);
									this.MoveTowardsTarget(this.CurrentDestination.position);
								}
								else if (this.BathePhase == 3)
								{
									this.StudentManager.CommunalLocker.Open = false;
									this.Character.animation.CrossFade(this.WalkAnim);
									if (!this.BatheFast)
									{
										this.CurrentDestination = this.StudentManager.BatheSpot;
										this.Pathfinding.target = this.StudentManager.BatheSpot;
									}
									else
									{
										this.CurrentDestination = this.StudentManager.FastBatheSpot;
										this.Pathfinding.target = this.StudentManager.FastBatheSpot;
									}
									this.Pathfinding.canSearch = true;
									this.Pathfinding.canMove = true;
									this.BathePhase++;
								}
								else if (this.BathePhase == 4)
								{
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * (float)10);
									this.MoveTowardsTarget(this.CurrentDestination.position);
									if (!this.BatheFast)
									{
										this.Character.animation.cullingType = AnimationCullingType.AlwaysAnimate;
										this.Character.animation.CrossFade("f02_bathEnter_00");
										if (this.Character.animation["f02_bathEnter_00"].time >= this.Character.animation["f02_bathEnter_00"].length)
										{
											this.Character.animation.CrossFade("f02_bathIdle_00");
											this.BathePhase++;
										}
										this.Pathfinding.canSearch = false;
										this.Pathfinding.canMove = false;
										this.MyController.radius = (float)0;
										this.Distracted = true;
									}
									else
									{
										this.Character.animation.CrossFade("f02_stoolBathing_00");
										if (this.Character.animation["f02_stoolBathing_00"].time >= this.Character.animation["f02_stoolBathing_00"].length)
										{
											this.LiquidProjector.enabled = false;
											this.Bloody = false;
											this.BathePhase = 7;
											this.GoChange();
											this.UnWet();
										}
									}
								}
								else if (this.BathePhase == 5)
								{
									if (this.Character.animation["f02_bathIdle_00"].time >= this.Character.animation["f02_bathIdle_00"].length)
									{
										this.Character.animation.CrossFade("f02_bathExit_00");
										this.LiquidProjector.enabled = false;
										this.Bloody = false;
										this.BathePhase++;
										this.UnWet();
									}
								}
								else if (this.BathePhase == 6)
								{
									if (this.Character.animation["f02_bathExit_00"].time >= this.Character.animation["f02_bathExit_00"].length)
									{
										this.Character.animation.cullingType = AnimationCullingType.BasedOnRenderers;
										this.MyController.radius = 0.12f;
										this.BathePhase++;
										this.GoChange();
									}
								}
								else if (this.BathePhase == 7)
								{
									this.StudentManager.CommunalLocker.Open = true;
									this.StudentManager.CommunalLocker.Student = this;
									this.StudentManager.CommunalLocker.SpawnSteam();
									this.Schoolwear = 3;
									this.BathePhase++;
								}
								else if (this.BathePhase == 8)
								{
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * (float)10);
									this.MoveTowardsTarget(this.CurrentDestination.position);
								}
								else if (this.BathePhase == 9)
								{
									this.StudentManager.CommunalLocker.Open = false;
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
									this.Routine = true;
									this.Wet = false;
									if (this.FleeWhenClean)
									{
										this.Pathfinding.target = this.StudentManager.Exit;
										this.TargetDistance = (float)0;
										this.Routine = false;
										this.Fleeing = true;
									}
								}
							}
							else if (this.BathePhase == -1)
							{
								this.Character.animation.cullingType = AnimationCullingType.AlwaysAnimate;
								this.Subtitle.UpdateLabel("Light Switch Reaction", 2, (float)5);
								this.Character.animation.CrossFade("f02_electrocution_00");
								this.Pathfinding.canSearch = false;
								this.Pathfinding.canMove = false;
								this.BathePhase++;
							}
							else if (this.BathePhase == 0)
							{
								this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * (float)10);
								this.MoveTowardsTarget(this.CurrentDestination.position);
								if (this.Character.animation["f02_electrocution_00"].time > (float)2 && this.Character.animation["f02_electrocution_00"].time < 5.95f)
								{
									if (!this.LightSwitch.Panel.useGravity)
									{
										if (!this.Bloody)
										{
											this.Subtitle.UpdateLabel("Splash Reaction", 2, (float)5);
										}
										else
										{
											this.Subtitle.UpdateLabel("Splash Reaction", 4, (float)5);
										}
										this.CurrentDestination = this.StudentManager.StripSpot;
										this.Pathfinding.target = this.StudentManager.StripSpot;
										this.Pathfinding.canSearch = true;
										this.Pathfinding.canMove = true;
										this.Pathfinding.speed = (float)4;
										this.Character.animation.CrossFade(this.WalkAnim);
										this.BathePhase++;
										this.LightSwitch.Prompt.Label[0].text = "     " + "Turn Off";
										this.LightSwitch.BathroomLight.active = true;
										this.LightSwitch.audio.clip = this.LightSwitch.Flick[0];
										this.LightSwitch.audio.Play();
									}
									else
									{
										if (!this.LightSwitch.Flicker)
										{
											this.Character.animation["f02_electrocution_00"].speed = 0.85f;
											GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.LightSwitch.Electricity, this.transform.position, Quaternion.identity);
											gameObject.transform.parent = this.Bones[1].transform;
											gameObject.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
											AudioSource audio = this.LightSwitch.audio;
											object obj2;
											object obj = obj2 = UnityRuntimeServices.GetProperty(this.LightSwitch, "ElectricityCackling");
											if (!(obj is AudioClip))
											{
												obj2 = RuntimeServices.Coerce(obj, typeof(AudioClip));
											}
											audio.clip = (AudioClip)obj2;
											this.Subtitle.UpdateLabel("Light Switch Reaction", 3, (float)0);
											this.LightSwitch.audio.clip = this.LightSwitch.Flick[2];
											this.LightSwitch.Flicker = true;
											this.LightSwitch.audio.Play();
											this.EyeShrink = (float)1;
											this.ElectroSteam[0].active = true;
											this.ElectroSteam[1].active = true;
											this.ElectroSteam[2].active = true;
											this.ElectroSteam[3].active = true;
										}
										this.DrillR.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
										this.DrillL.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
										this.ElectroTimer += Time.deltaTime;
										if (this.ElectroTimer > 0.1f)
										{
											this.ElectroTimer = (float)0;
											if (this.MyRenderer.enabled)
											{
												this.Spook();
											}
											else
											{
												this.Unspook();
											}
										}
									}
								}
								else if (this.Character.animation["f02_electrocution_00"].time > 5.95f && this.Character.animation["f02_electrocution_00"].time < this.Character.animation["f02_electrocution_00"].length)
								{
									if (this.LightSwitch.Flicker)
									{
										this.Character.animation["f02_electrocution_00"].speed = (float)1;
										this.Prompt.Label[0].text = "     " + "Turn Off";
										this.LightSwitch.BathroomLight.active = true;
										this.DrillR.localEulerAngles = new Vector3((float)0, (float)0, (float)45);
										this.DrillL.localEulerAngles = new Vector3((float)0, (float)0, (float)-45);
										this.LightSwitch.Flicker = false;
										this.Unspook();
										this.UnWet();
									}
								}
								else if (this.Character.animation["f02_electrocution_00"].time >= this.Character.animation["f02_electrocution_00"].length)
								{
									this.Electrocuted = true;
									this.BecomeRagdoll();
									this.Dead = true;
								}
							}
						}
					}
					else if (this.Pathfinding.canMove)
					{
						if (this.BathePhase == 1 || this.FleeWhenClean)
						{
							this.Character.animation.CrossFade(this.SprintAnim);
							this.Pathfinding.speed = (float)4;
						}
						else
						{
							this.Character.animation.CrossFade(this.WalkAnim);
							this.Pathfinding.speed = (float)1;
						}
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
						this.ID = 0;
						while (this.ID < this.Police.Corpses)
						{
							if (this.Police.CorpseList[this.ID] != null)
							{
								this.Planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
								if (GeometryUtility.TestPlanesAABB(this.Planes, this.Police.CorpseList[this.ID].AllColliders[0].bounds))
								{
									RaycastHit raycastHit = default(RaycastHit);
									Debug.DrawLine(this.Eyes.transform.position, this.Police.CorpseList[this.ID].AllColliders[0].transform.position, Color.green);
									if (Physics.Linecast(this.Eyes.transform.position, this.Police.CorpseList[this.ID].AllColliders[0].transform.position, out raycastHit, this.Mask) && (raycastHit.collider.gameObject.layer == 11 || raycastHit.collider.gameObject.layer == 14))
									{
										num++;
										this.Corpse = this.Police.CorpseList[this.ID];
										if (this.Persona == 2 && this.StudentManager.Reporter == null && !this.Police.Called)
										{
											this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
											this.StudentManager.Reporter = this;
											this.Reporting = true;
										}
									}
								}
							}
							this.ID++;
						}
						if (num > 0)
						{
							if (!this.WitnessedCorpse)
							{
								this.Alarm = (float)200;
								this.WitnessedCorpse = true;
								this.StudentManager.UpdateMe(this.StudentID - 1);
								if (!this.Teacher)
								{
									this.SpawnAlarmDisc();
									if (this.Corpse.Natural)
									{
										this.Persona = 2;
									}
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
								if (this.Following)
								{
									this.Yandere.Followers = this.Yandere.Followers - 1;
									this.Following = false;
								}
							}
							if (this.Corpse.Dragged || this.Corpse.Dumped)
							{
								if (this.Teacher)
								{
									this.Subtitle.UpdateLabel("Teacher Murder Reaction", UnityEngine.Random.Range(1, 3), (float)3);
									this.StudentManager.Portal.active = false;
								}
								this.WitnessMurder();
							}
						}
						this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
						this.PreviousAlarm = this.Alarm;
						if (this.DistanceToPlayer < (float)11 * this.Paranoia)
						{
							if (!this.Talking)
							{
								if (!this.Yandere.Noticed)
								{
									if (!this.Yandere.Chased)
									{
										if ((this.Yandere.Armed && this.Yandere.Weapon[this.Yandere.Equipped].Suspicious) || (this.Yandere.Bloodiness > (float)0 || this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Dragging || this.Yandere.Lewd || (this.Yandere.Laughing && this.Yandere.LaughIntensity > (float)15)) || (this.Private && this.Yandere.Trespassing) || (this.Teacher && this.Yandere.Trespassing) || (this.StudentID == 1 && this.Yandere.NearSenpai && !this.Yandere.Talking))
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
														this.YandereVisible = true;
														if (this.Yandere.Attacking || (this.Yandere.NearBodies > 0 && this.Yandere.Bloodiness > (float)0) || (this.Yandere.NearBodies > 0 && this.Yandere.Armed) || (this.Yandere.NearBodies > 0 && this.Yandere.Sanity < 66.66666f) || this.Yandere.Dragging)
														{
															this.WitnessMurder();
														}
														else if (!this.Fleeing)
														{
															if (!this.Alarmed && this.IgnoreTimer <= (float)0)
															{
																this.Alarm += Time.deltaTime * ((float)100 / this.DistanceToPlayer) * this.Paranoia;
																if (this.StudentID == 1 && this.Yandere.TimeSkipping)
																{
																	this.Clock.EndTimeSkip();
																}
															}
														}
														else
														{
															this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
														}
													}
													else
													{
														this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
													}
												}
											}
											else
											{
												this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
											}
										}
										else
										{
											this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
										}
									}
									else
									{
										this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
									}
								}
								else
								{
									this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
								}
							}
							else
							{
								this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
							}
						}
						else
						{
							this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
						}
						if (this.PreviousAlarm > this.Alarm && this.Alarm < (float)100)
						{
							this.YandereVisible = false;
						}
						if (this.Alarm > (float)100 && (!this.Alarmed || this.DiscCheck))
						{
							this.ID = 0;
							while (this.ID < Extensions.get_length(this.Outlines))
							{
								this.Outlines[this.ID].color = new Color((float)1, (float)1, (float)0, (float)1);
								this.ID++;
							}
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.DiscCheck = false;
							this.Routine = false;
							this.Alarmed = true;
							this.Witness = true;
							string b = this.Witnessed;
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
							if (this.YandereVisible)
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
									if (!this.Bloody)
									{
										this.RepLoss = (float)10;
										this.Concern = 5;
									}
									else
									{
										this.RepLoss = (float)0;
										this.Concern = 0;
									}
								}
								else if (this.Yandere.Sanity < 33.333f)
								{
									this.Witnessed = "Insanity";
									this.RepLoss = (float)10;
									this.Concern = 5;
								}
								else if (this.Yandere.Laughing)
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
								else if (this.Yandere.Trespassing && this.StudentID > 1)
								{
									if (this.Private)
									{
										this.Witnessed = "Interruption";
									}
									else
									{
										this.Witnessed = "Trespassing";
									}
									this.Witness = false;
									this.Concern++;
								}
								else if (this.Yandere.NearSenpai)
								{
									this.Witnessed = "Stalking";
									this.Concern++;
								}
								else
								{
									this.DiscCheck = true;
								}
								if (this.EventManager != null)
								{
									this.EventManager.EndEvent();
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
								if (!this.Teacher && this.Witnessed == b)
								{
									this.RepeatReaction = true;
								}
								this.Reputation.PendingRep = this.Reputation.PendingRep - this.RepLoss * this.Paranoia;
								this.PendingRep -= this.RepLoss * this.Paranoia;
								if (this.ToiletEvent != null && this.ToiletEvent.EventDay == 1)
								{
									this.ToiletEvent.EndEvent();
								}
							}
							else
							{
								this.DiscCheck = true;
							}
						}
					}
					else
					{
						this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
					}
				}
				else if (!this.InEvent && this.BathePhase < 4)
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
			if (this.Alarm < (float)0)
			{
				this.Alarm = (float)0;
			}
			if (this.Alarm <= (float)100)
			{
				float y = this.Alarm / (float)100;
				Vector3 localScale = this.DetectionMarker.Tex.transform.localScale;
				float num2 = localScale.y = y;
				Vector3 vector = this.DetectionMarker.Tex.transform.localScale = localScale;
			}
			else
			{
				int num3 = 1;
				Vector3 localScale2 = this.DetectionMarker.Tex.transform.localScale;
				float num4 = localScale2.y = (float)num3;
				Vector3 vector2 = this.DetectionMarker.Tex.transform.localScale = localScale2;
			}
			float a = this.Alarm / (float)100;
			Color color = this.DetectionMarker.Tex.color;
			float num5 = color.a = a;
			Color color2 = this.DetectionMarker.Tex.color = color;
			if (this.StudentID > 1)
			{
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
						this.Character.animation.cullingType = AnimationCullingType.AlwaysAnimate;
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
					else if (this.InEvent || this.Meeting || this.Wet)
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
							float num6 = color3.a = a2;
							Color color4 = this.DialogueWheel.Shadow[1].color = color3;
						}
						if (this.Complimented)
						{
							float a3 = 0.75f;
							Color color5 = this.DialogueWheel.Shadow[2].color;
							float num7 = color5.a = a3;
							Color color6 = this.DialogueWheel.Shadow[2].color = color5;
						}
						this.Yandere.WeaponMenu.KeyboardShow = false;
						this.Yandere.WeaponMenu.Show = false;
						this.DialogueWheel.Show = true;
						this.TalkTimer = (float)0;
					}
				}
				if (this.Prompt.Circle[2].fillAmount <= (float)0 && !this.Yandere.NearSenpai && !this.Yandere.Attacking && !this.Yandere.Crouching)
				{
					this.AttackReaction();
				}
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
						this.ID = 0;
						while (this.ID < Extensions.get_length(this.Outlines))
						{
							this.Outlines[this.ID].color = new Color((float)0, (float)1, (float)0, (float)1);
							this.ID++;
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
						if (!this.Following && !this.Wet)
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
				this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
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
				this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
				this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1, Time.deltaTime * (float)10);
				if (this.Character.animation[this.PushedAnim].time >= this.Character.animation[this.PushedAnim].length)
				{
					this.BecomeRagdoll();
				}
			}
			else if (this.Drowned)
			{
				this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
				this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1, Time.deltaTime * (float)10);
				if (this.Character.animation[this.DrownAnim].time >= this.Character.animation[this.DrownAnim].length)
				{
					this.BecomeRagdoll();
				}
			}
			else if (this.WitnessedMurder)
			{
				if (!this.Fleeing)
				{
					if (this.StudentID > 1)
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
								this.Subtitle.UpdateLabel("Teacher Murder Reaction", UnityEngine.Random.Range(1, 3), (float)3);
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
				this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
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
					else if (!this.Following && !this.Wet)
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
							if (!this.Bloody)
							{
								this.Subtitle.UpdateLabel("Blood Reaction", 1, (float)3);
							}
							else
							{
								this.Subtitle.UpdateLabel("Wet Blood Reaction", 1, (float)3);
								string b = string.Empty;
								this.Witnessed = string.Empty;
								this.Witness = false;
							}
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
			else if (this.Splashed)
			{
				this.SplashTimer += Time.deltaTime;
				if (this.SplashTimer > (float)2 && this.SplashPhase == 1)
				{
					if (!this.Bloody)
					{
						this.Subtitle.UpdateLabel("Splash Reaction", 1, (float)5);
					}
					else
					{
						this.Subtitle.UpdateLabel("Splash Reaction", 3, (float)5);
					}
					this.SplashPhase++;
				}
				if (this.SplashTimer > (float)8 && this.SplashPhase == 2)
				{
					if (this.LightSwitch == null)
					{
						if (!this.Bloody)
						{
							this.Subtitle.UpdateLabel("Splash Reaction", 2, (float)5);
						}
						else
						{
							this.Subtitle.UpdateLabel("Splash Reaction", 4, (float)5);
						}
						this.SplashPhase++;
						this.CurrentDestination = this.StudentManager.StripSpot;
						this.Pathfinding.target = this.StudentManager.StripSpot;
					}
					else if (!this.LightSwitch.BathroomLight.active)
					{
						if (this.LightSwitch.Panel.useGravity)
						{
							this.LightSwitch.Prompt.Hide();
							this.LightSwitch.Prompt.enabled = false;
							this.Prompt.Hide();
							this.Prompt.enabled = false;
						}
						this.Subtitle.UpdateLabel("Light Switch Reaction", 1, (float)5);
						this.CurrentDestination = this.LightSwitch.ElectrocutionSpot;
						this.Pathfinding.target = this.LightSwitch.ElectrocutionSpot;
						this.Pathfinding.speed = (float)1;
						this.BathePhase = -1;
						this.InDarkness = true;
					}
					else
					{
						if (!this.Bloody)
						{
							this.Subtitle.UpdateLabel("Splash Reaction", 2, (float)5);
						}
						else
						{
							this.Subtitle.UpdateLabel("Splash Reaction", 4, (float)5);
						}
						this.SplashPhase++;
						this.CurrentDestination = this.StudentManager.StripSpot;
						this.Pathfinding.target = this.StudentManager.StripSpot;
					}
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Splashed = false;
				}
			}
			if (this.IgnoreTimer > (float)0)
			{
				this.IgnoreTimer -= Time.deltaTime;
			}
			if (!this.Fleeing && this.transform.position.y < (float)0)
			{
				int num8 = 0;
				Vector3 position = this.transform.position;
				float num9 = position.y = (float)num8;
				Vector3 vector3 = this.transform.position = position;
			}
			int num10 = 0;
			Vector3 localEulerAngles = this.transform.localEulerAngles;
			float num11 = localEulerAngles.x = (float)num10;
			Vector3 vector4 = this.transform.localEulerAngles = localEulerAngles;
			int num12 = 0;
			Vector3 localEulerAngles2 = this.transform.localEulerAngles;
			float num13 = localEulerAngles2.z = (float)num12;
			Vector3 vector5 = this.transform.localEulerAngles = localEulerAngles2;
			if (!this.Male)
			{
				if (!this.Splashed && this.Wet && !this.Dying && Mathf.Abs(this.BathePhase) == 1)
				{
					this.Character.animation[this.WetAnim].weight = (float)1;
				}
				else
				{
					this.Character.animation[this.WetAnim].weight = (float)0;
				}
			}
			if (this.Dying)
			{
				this.Character.animation.cullingType = AnimationCullingType.AlwaysAnimate;
			}
		}
		else
		{
			this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
		}
		if (this.AoT)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)10, (float)10, (float)10), Time.deltaTime);
		}
	}

	public virtual void LateUpdate()
	{
		if (this.EyeShrink > (float)1)
		{
			this.EyeShrink = (float)1;
		}
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
		if (this.DK)
		{
			this.Arm[0].localScale = new Vector3((float)2, (float)2, (float)2);
			this.Arm[1].localScale = new Vector3((float)2, (float)2, (float)2);
			this.Head.localScale = new Vector3((float)2, (float)2, (float)2);
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
		this.DetectionMarker.Tex.enabled = false;
		this.MyController.radius = (float)0;
		this.Alarmed = false;
		this.Fleeing = false;
		this.Routine = false;
		this.Dying = true;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		if (this.ToiletEvent != null)
		{
			this.ToiletEvent.EndEvent();
		}
		if (!this.Dying && this.Following)
		{
			this.Yandere.Followers = this.Yandere.Followers - 1;
			this.Following = false;
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
			this.SpawnAlarmDisc();
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
			this.Stop = false;
		}
	}

	public virtual void WitnessMurder()
	{
		if (this.StudentID > 1)
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Outlines))
			{
				this.Outlines[this.ID].color = new Color((float)1, (float)0, (float)0, (float)1);
				this.Outlines[this.ID].enabled = true;
				this.ID++;
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
			this.Prompt.Label[0].text = "     " + "Talk";
			this.Prompt.HideButton[0] = true;
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
		this.WitnessedMurder = true;
		this.Reacted = false;
		this.Routine = false;
		this.Alarmed = true;
		this.AlarmTimer = (float)0;
		this.Alarm = (float)0;
		if (this.Teacher)
		{
			this.Pathfinding.target = this.Yandere.transform;
			this.Pathfinding.speed = 7.5f;
			this.StudentManager.Portal.active = false;
			this.Yandere.Chased = true;
			this.TargetDistance = 0.5f;
			this.StudentManager.UpdateStudents();
		}
		else
		{
			this.SpawnAlarmDisc();
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
			if (this.Schoolwear > 0)
			{
				if (!this.Bloody)
				{
					this.Pathfinding.target = this.StudentManager.Exit;
					this.TargetDistance = (float)0;
					this.Routine = false;
					this.Fleeing = true;
				}
				else
				{
					this.FleeWhenClean = true;
					this.TargetDistance = (float)1;
					this.BatheFast = true;
				}
			}
			else
			{
				this.FleeWhenClean = true;
				if (!this.Bloody)
				{
					this.BathePhase = 7;
					this.GoChange();
				}
				else
				{
					this.CurrentDestination = this.StudentManager.FastBatheSpot;
					this.Pathfinding.target = this.StudentManager.FastBatheSpot;
					this.TargetDistance = (float)1;
					this.BatheFast = true;
				}
			}
		}
		else if (this.Persona == 2)
		{
			if (this.StudentManager.Reporter == this)
			{
				this.Pathfinding.target = this.StudentManager.Teachers[this.Class].TeacherTalkPoint;
				this.CurrentDestination = this.StudentManager.Teachers[this.Class].TeacherTalkPoint;
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
				this.CurrentDestination = this.StudentManager.Seats.List[this.StudentID];
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
		else if (this.Persona == 9)
		{
			if (this.WitnessedMurder)
			{
				this.Subtitle.UpdateLabel("Teacher Murder Reaction", 3, (float)3);
				this.Pathfinding.target = this.Yandere.transform;
				this.Pathfinding.speed = 7.5f;
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
		this.ID = 1;
		while (this.ID < this.JSON.StudentDestinations[this.StudentID].length)
		{
			if (this.DestinationNames[this.ID] == "Locker")
			{
				this.Destinations[this.ID] = this.StudentManager.Lockers.List[this.StudentID];
			}
			else if (this.DestinationNames[this.ID] == "Seat")
			{
				this.Destinations[this.ID] = this.StudentManager.Seats.List[this.StudentID];
			}
			else if (this.DestinationNames[this.ID] == "Podium")
			{
				this.Destinations[this.ID] = this.StudentManager.Podiums.List[this.Class];
			}
			else if (this.DestinationNames[this.ID] == "Exit")
			{
				this.Destinations[this.ID] = this.StudentManager.Hangouts.List[0];
			}
			else if (this.DestinationNames[this.ID] == "Hangout")
			{
				this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
			}
			else if (this.DestinationNames[this.ID] == "LunchSpot")
			{
				this.Destinations[this.ID] = this.StudentManager.LunchSpots.List[this.StudentID];
			}
			this.ID++;
		}
		this.ActionNames = (string[])this.JSON.StudentActions[this.StudentID].ToBuiltin(typeof(string));
		this.ID = 1;
		while (this.ID < this.JSON.StudentActions[this.StudentID].length)
		{
			if (this.ActionNames[this.ID] == "Stand")
			{
				this.Actions[this.ID] = 0;
			}
			else if (this.ActionNames[this.ID] == "Socialize")
			{
				this.Actions[this.ID] = 1;
			}
			else if (this.ActionNames[this.ID] == "Game")
			{
				this.Actions[this.ID] = 2;
			}
			this.ID++;
		}
	}

	public virtual void SetColors()
	{
		string a = "Default";
		string a2 = this.JSON.StudentColors[this.StudentID];
		string a3 = this.JSON.StudentStockings[this.StudentID];
		this.ID = 1;
		if (!this.Male)
		{
			if (a2 == "Red")
			{
				this.HairTexture = this.StudentManager.Colors[0];
			}
			else if (a2 == "Yellow")
			{
				this.HairTexture = this.StudentManager.Colors[1];
			}
			else if (a2 == "Green")
			{
				this.HairTexture = this.StudentManager.Colors[2];
			}
			else if (a2 == "Cyan")
			{
				this.HairTexture = this.StudentManager.Colors[3];
			}
			else if (a2 == "Blue")
			{
				this.HairTexture = this.StudentManager.Colors[4];
			}
			else if (a2 == "Purple")
			{
				this.HairTexture = this.StudentManager.Colors[5];
				this.DrillTexture = this.StudentManager.Colors[6];
			}
			else if (a2 == "Brown")
			{
				this.HairTexture = this.StudentManager.Colors[7];
			}
			else if (a2 == "Pippi")
			{
				this.HairTexture = this.StudentManager.Colors[8];
			}
			else if (a2 == "Black")
			{
				this.HairTexture = this.StudentManager.Colors[9];
			}
			this.PonyRenderer.material.mainTexture = this.HairTexture;
		}
		else
		{
			int num;
			if (this.StudentID > 1)
			{
				num = UnityBuiltins.parseInt(this.Hairstyle);
			}
			else if (PlayerPrefs.GetInt("CustomSenpai") == 1)
			{
				num = UnityBuiltins.parseInt(PlayerPrefs.GetInt("SenpaiHairStyle"));
				a = PlayerPrefs.GetString("SenpaiEyeColor");
				a2 = PlayerPrefs.GetString("SenpaiHairColor");
			}
			else
			{
				a2 = "Default";
				num = 1;
			}
			if (num > 0)
			{
				this.MaleHairstyles[num].active = true;
				if (num < 8)
				{
					this.MaleHairRenderer = (Renderer)this.MaleHairstyles[num].GetComponent(typeof(Renderer));
				}
			}
			if (this.MaleHairRenderer != null && num < 8)
			{
				if (a2 == "Red")
				{
					this.MaleHairRenderer.material.color = new Color((float)1, (float)0, (float)0);
				}
				else if (a2 == "Yellow")
				{
					this.MaleHairRenderer.material.color = new Color((float)1, (float)1, (float)0);
				}
				else if (a2 == "Green")
				{
					this.MaleHairRenderer.material.color = new Color((float)0, (float)1, (float)0);
				}
				else if (a2 == "Cyan")
				{
					this.MaleHairRenderer.material.color = new Color((float)0, (float)1, (float)1);
				}
				else if (a2 == "Blue")
				{
					this.MaleHairRenderer.material.color = new Color((float)0, (float)0, (float)1);
				}
				else if (a2 == "Purple")
				{
					this.MaleHairRenderer.material.color = new Color((float)1, (float)0, (float)1);
				}
				else if (a2 == "Default")
				{
					this.MaleHairRenderer.material.color = new Color((float)1, (float)1, (float)1);
				}
				else if (a2 == "Orange")
				{
					this.MaleHairRenderer.material.color = new Color((float)1, 0.5f, (float)0);
				}
				else if (a2 == "Brown")
				{
					this.MaleHairRenderer.material.color = new Color(0.5f, 0.25f, (float)0);
				}
				else if (a2 == "Black")
				{
					this.MaleHairRenderer.material.color = new Color(0.5f, 0.5f, 0.5f);
				}
			}
			if (this.StudentID > 1)
			{
				if (num < 8)
				{
					this.EyeR.material.color = this.MaleHairRenderer.material.color;
					this.EyeL.material.color = this.MaleHairRenderer.material.color;
				}
			}
			else
			{
				if (a == "Red")
				{
					this.EyeColor = new Color((float)1, (float)0, (float)0);
				}
				else if (a == "Yellow")
				{
					this.EyeColor = new Color((float)1, (float)1, (float)0);
				}
				else if (a == "Green")
				{
					this.EyeColor = new Color((float)0, (float)1, (float)0);
				}
				else if (a == "Cyan")
				{
					this.EyeColor = new Color((float)0, (float)1, (float)1);
				}
				else if (a == "Blue")
				{
					this.EyeColor = new Color((float)0, (float)0, (float)1);
				}
				else if (a == "Purple")
				{
					this.EyeColor = new Color((float)1, (float)0, (float)1);
				}
				else if (a == "Default")
				{
					this.EyeColor = new Color((float)1, (float)1, (float)1);
				}
				else if (a == "Orange")
				{
					this.EyeColor = new Color((float)1, 0.5f, (float)0);
				}
				else if (a == "Brown")
				{
					this.EyeColor = new Color(0.5f, 0.25f, (float)0);
				}
				else if (a == "Black")
				{
					this.EyeColor = new Color(0.5f, 0.5f, 0.5f);
				}
				this.EyeR.material.color = this.EyeColor;
				this.EyeL.material.color = this.EyeColor;
			}
		}
		if (a3 == "Socks")
		{
			this.MyRenderer.materials[0].mainTexture = this.StudentManager.Stockings[0];
		}
		else if (a3 == "ThighhighGreen")
		{
			this.MyRenderer.materials[0].mainTexture = this.StudentManager.Stockings[1];
			this.MyRenderer.materials[1].mainTexture = this.StudentManager.Stockings[1];
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
			if (!this.Teacher)
			{
				this.SetFemaleUniform();
			}
		}
		else
		{
			this.SetMaleUniform();
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Outlines))
		{
			if (this.Outlines[this.ID].h != null)
			{
				this.Outlines[this.ID].h.ReinitMaterials();
			}
			this.ID++;
		}
	}

	public virtual void UpdateHair()
	{
		this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.LongHair.active = false;
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
		else if (this.Hairstyle == "Long")
		{
			this.PonyRenderer.gameObject.active = false;
			this.LongHair.active = true;
		}
	}

	public virtual void UpdateOutlines()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Outlines))
		{
			this.Outlines[this.ID].color = new Color((float)1, 0.5f, (float)0, (float)1);
			this.Outlines[this.ID].enabled = true;
			this.ID++;
		}
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
		this.MyRenderer.materials[1].mainTexture = this.HairTexture;
		this.MyRenderer.materials[2].mainTexture = this.TeacherTexture;
		this.PonyRenderer.material.mainTexture = this.HairTexture;
	}

	public virtual void RemoveShoes()
	{
		if (this.Schoolwear == 1)
		{
			this.MyRenderer.materials[0].mainTexture = this.SocksTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[1].mainTexture = this.SocksTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
		else if (this.Schoolwear == 3)
		{
			this.MyRenderer.materials[0].mainTexture = this.SocksTextures[0];
			this.MyRenderer.materials[1].mainTexture = this.SocksTextures[0];
		}
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
		if (!this.Male)
		{
			this.LiquidProjector.ignoreLayers = -2049;
		}
		this.Character.animation.cullingType = AnimationCullingType.AlwaysAnimate;
		this.Ragdoll.AllColliders[10].isTrigger = false;
		this.NotFaceCollider.enabled = false;
		this.FaceCollider.enabled = false;
		this.MyController.enabled = false;
		this.Pathfinding.enabled = false;
		this.HipCollider.enabled = true;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.enabled = false;
		this.UnWet();
		this.Ragdoll.RightEyeOrigin = this.RightEyeOrigin;
		this.Ragdoll.LeftEyeOrigin = this.LeftEyeOrigin;
		this.Ragdoll.Electrocuted = this.Electrocuted;
		this.Ragdoll.BreastSize = this.BreastSize;
		this.Ragdoll.EyeShrink = this.EyeShrink;
		this.Ragdoll.HidePony = this.HidePony;
		this.Ragdoll.Tranquil = this.Tranquil;
		this.Ragdoll.Drowned = this.Drowned;
		this.Ragdoll.Yandere = this.Yandere;
		this.Ragdoll.Police = this.Police;
		this.Ragdoll.Pushed = this.Pushed;
		this.Ragdoll.Male = this.Male;
		this.Police.Deaths = this.Police.Deaths + 1;
		this.Ragdoll.enabled = true;
		this.Reputation.PendingRep = this.Reputation.PendingRep + this.PendingRep * (float)-1;
		if (this.WitnessedMurder)
		{
			this.Police.Witnesses = this.Police.Witnesses - 1;
		}
		this.UpdateOutlines();
		UnityEngine.Object.Destroy(this.DetectionMarker);
		this.SetLayerRecursively(this.gameObject, 11);
		this.tag = "Blood";
		PlayerPrefs.SetInt("Student_" + this.StudentID + "_Dying", 1);
	}

	public virtual void GetWet()
	{
		this.Character.animation.CrossFade(this.SplashedAnim);
		this.LiquidProjector.enabled = true;
		if (this.Bloody)
		{
			this.LiquidProjector.material.mainTexture = this.BloodTexture;
		}
		else
		{
			this.LiquidProjector.material.mainTexture = this.WaterTexture;
		}
		this.Subtitle.UpdateLabel("Splash Reaction", 0, (float)1);
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.SplashTimer = (float)0;
		this.SplashPhase = 1;
		this.BathePhase = 1;
		this.Splashed = true;
		this.Routine = false;
		this.Wet = true;
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.LiquidEmitters))
		{
			this.LiquidEmitters[this.ID].gameObject.active = true;
			if (this.Bloody)
			{
				this.LiquidEmitters[this.ID].startColor = new Color((float)1, (float)0, (float)0, (float)1);
			}
			else
			{
				this.LiquidEmitters[this.ID].startColor = new Color((float)0, (float)1, (float)1, (float)1);
			}
			this.ID++;
		}
	}

	public virtual void UnWet()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.LiquidEmitters))
		{
			this.LiquidEmitters[this.ID].gameObject.active = false;
			this.ID++;
		}
	}

	public virtual void SetMaleUniform()
	{
		if (this.StudentID == 1)
		{
			this.SkinColor = PlayerPrefs.GetInt("SenpaiSkinColor");
		}
		this.MyRenderer.sharedMesh = this.MaleUniforms[PlayerPrefs.GetInt("MaleUniform")];
		if (PlayerPrefs.GetInt("MaleUniform") == 1)
		{
			this.MyRenderer.materials[0].mainTexture = this.SkinTextures[this.SkinColor];
			this.MyRenderer.materials[1].mainTexture = this.MaleUniformTextures[1];
			this.MyRenderer.materials[2].mainTexture = this.FaceTextures[this.SkinColor];
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 2)
		{
			this.MyRenderer.materials[0].mainTexture = this.MaleUniformTextures[2];
			this.MyRenderer.materials[1].mainTexture = this.FaceTextures[this.SkinColor];
			this.MyRenderer.materials[2].mainTexture = this.SkinTextures[this.SkinColor];
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 3)
		{
			this.MyRenderer.materials[0].mainTexture = this.MaleUniformTextures[3];
			this.MyRenderer.materials[1].mainTexture = this.FaceTextures[this.SkinColor];
			this.MyRenderer.materials[2].mainTexture = this.SkinTextures[this.SkinColor];
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 4)
		{
			this.MyRenderer.materials[0].mainTexture = this.FaceTextures[this.SkinColor];
			this.MyRenderer.materials[1].mainTexture = this.SkinTextures[this.SkinColor];
			this.MyRenderer.materials[2].mainTexture = this.MaleUniformTextures[4];
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 5)
		{
			this.MyRenderer.materials[0].mainTexture = this.FaceTextures[this.SkinColor];
			this.MyRenderer.materials[1].mainTexture = this.SkinTextures[this.SkinColor];
			this.MyRenderer.materials[2].mainTexture = this.MaleUniformTextures[5];
		}
	}

	public virtual void SetFemaleUniform()
	{
		this.MyRenderer.sharedMesh = this.FemaleUniforms[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[2].mainTexture = this.HairTexture;
	}

	public virtual void Nude()
	{
		this.MyRenderer.sharedMesh = this.BaldNudeMesh;
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = null;
			this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		}
		else
		{
			this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
			this.MyRenderer.materials[1].mainTexture = null;
			this.MyRenderer.materials[2].mainTexture = this.FaceTextures[this.SkinColor];
		}
		if (!this.AoT)
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.CensorSteam))
			{
				this.CensorSteam[this.ID].active = true;
				this.ID++;
			}
		}
	}

	public virtual void ChangeSchoolwear()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.CensorSteam))
		{
			this.CensorSteam[this.ID].active = false;
			this.ID++;
		}
		if (this.Schoolwear == 0)
		{
			this.Nude();
		}
		else if (this.Schoolwear == 1)
		{
			this.MyRenderer.sharedMesh = this.SchoolUniform;
			this.SetColors();
		}
		else if (this.Schoolwear == 2)
		{
			this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
		}
		else if (this.Schoolwear == 3)
		{
			this.MyRenderer.sharedMesh = this.GymUniform;
			this.MyRenderer.materials[0].mainTexture = this.GymTexture;
			this.MyRenderer.materials[1].mainTexture = this.GymTexture;
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
		}
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
		this.Nude();
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Outlines))
		{
			if (this.Outlines[this.ID].h == null)
			{
				this.Outlines[this.ID].Awake();
			}
			this.Outlines[this.ID].h.ReinitMaterials();
			this.ID++;
		}
		if (!this.Male && !this.Teacher)
		{
			this.PantyCollider.enabled = false;
			this.SkirtCollider.enabled = false;
		}
	}

	public virtual void Spook()
	{
		if (!this.Male)
		{
			this.MyRenderer.enabled = false;
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Bones))
			{
				this.Bones[this.ID].active = true;
				this.ID++;
			}
		}
	}

	public virtual void Unspook()
	{
		this.MyRenderer.enabled = true;
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Bones))
		{
			this.Bones[this.ID].active = false;
			this.ID++;
		}
	}

	public virtual void GoChange()
	{
		this.CurrentDestination = this.StudentManager.StripSpot;
		this.Pathfinding.target = this.StudentManager.StripSpot;
		this.Pathfinding.canSearch = true;
		this.Pathfinding.canMove = true;
		this.Distracted = false;
	}

	public virtual void SpawnAlarmDisc()
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.AlarmDisc, this.transform.position + Vector3.up * (float)1, Quaternion.identity);
		((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).Male = this.Male;
		((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).Student = this;
	}

	public virtual void Main()
	{
	}
}
