using System;
using System.Collections;
using Pathfinding;
using UnityEngine;

public class StudentScript : MonoBehaviour
{
	public Quaternion targetRotation;

	public DetectionMarkerScript DetectionMarker;

	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public ChangingBoothScript ChangingBooth;

	public DialogueWheelScript DialogueWheel;

	public WitnessCameraScript WitnessCamera;

	public StudentScript DistractionTarget;

	public CookingEventScript CookingEvent;

	public EventManagerScript EventManager;

	public GradingPaperScript GradingPaper;

	public ClubManagerScript ClubManager;

	public LightSwitchScript LightSwitch;

	public MovingEventScript MovingEvent;

	public ShoeRemovalScript ShoeRemoval;

	public StruggleBarScript StruggleBar;

	public ToiletEventScript ToiletEvent;

	public DynamicGridObstacle Obstacle;

	public PhoneEventScript PhoneEvent;

	public ReputationScript Reputation;

	public Renderer SmartPhoneScreen;

	public StudentScript MyTeacher;

	public BoneSetsScript BoneSets;

	public CosmeticScript Cosmetic;

	public SubtitleScript Subtitle;

	public DynamicBone OsanaHairL;

	public DynamicBone OsanaHairR;

	public WeaponScript MyWeapon;

	public StudentScript Partner;

	public RagdollScript Ragdoll;

	public YandereScript Yandere;

	public BrokenScript Broken;

	public RagdollScript Corpse;

	public PoliceScript Police;

	public PromptScript Prompt;

	public AIPath Pathfinding;

	public ClockScript Clock;

	public RadioScript Radio;

	public JsonScript JSON;

	public Rigidbody MyRigidbody;

	public Collider MyCollider;

	public CharacterController MyController;

	public ParticleSystem BloodFountain;

	public Animation CharacterAnimation;

	public ParticleSystem VomitEmitter;

	public ParticleSystem SpeechLines;

	public Projector LiquidProjector;

	public ParticleSystem Hearts;

	public Camera VisionCone;

	public Texture OsanaPhoneTexture;

	public Texture RedBookTexture;

	public Texture BloodTexture;

	public Texture WaterTexture;

	public Texture GasTexture;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer BookRenderer;

	public Transform CurrentDestination;

	public Transform TeacherTalkPoint;

	public Transform LeftMiddleFinger;

	public Transform Distraction;

	public Transform ItemParent;

	public Transform MyReporter;

	public Transform WitnessPOV;

	public Transform RightDrill;

	public Transform LeftDrill;

	public Transform RightHand;

	public Transform LeftHand;

	public Transform MeetSpot;

	public Transform MyLocker;

	public Transform Eyes;

	public Transform Head;

	public Transform Neck;

	public Transform Seat;

	public ParticleSystem[] LiquidEmitters;

	public ParticleSystem[] FireEmitters;

	public ScheduleBlock[] ScheduleBlocks;

	public Transform[] Destinations;

	public OutlineScript[] Outlines;

	public GameObject[] Chopsticks;

	public string[] AnimationNames;

	public GameObject[] Bones;

	public Transform[] Skirt;

	public Transform[] Arm;

	public LayerMask Mask;

	public Plane[] Planes;

	public StudentActionType[] Actions;

	public StudentActionType[] OriginalActions;

	public AudioClip MurderSuicideKiller;

	public AudioClip MurderSuicideVictim;

	public AudioClip MurderSuicideSounds;

	public AudioClip[] FemaleAttacks;

	public AudioClip[] MaleAttacks;

	public AudioClip BurningClip;

	public SphereCollider HipCollider;

	public Collider RightHandCollider;

	public Collider LeftHandCollider;

	public Collider NotFaceCollider;

	public Collider PantyCollider;

	public Collider SkirtCollider;

	public Collider FaceCollider;

	public Collider NEStairs;

	public Collider NWStairs;

	public Collider SEStairs;

	public Collider SWStairs;

	public GameObject BloodSprayCollider;

	public GameObject EmptyGameObject;

	public GameObject StabBloodEffect;

	public GameObject RightEmptyEye;

	public GameObject LeftEmptyEye;

	public GameObject AnimatedBook;

	public GameObject BloodyScream;

	public GameObject ChaseCamera;

	public GameObject DeathScream;

	public GameObject BloodEffect;

	public GameObject BloodSpray;

	public GameObject SmartPhone;

	public GameObject MainCamera;

	public GameObject OccultBook;

	public GameObject AlarmDisc;

	public GameObject Character;

	public GameObject Countdown;

	public GameObject EventBook;

	public GameObject OsanaHair;

	public GameObject Earpiece;

	public GameObject Armband;

	public GameObject MyPaper;

	public GameObject Giggle;

	public GameObject Marker;

	public GameObject Weapon;

	public GameObject Bento;

	public GameObject Paper;

	public GameObject Phone;

	public GameObject Note;

	public GameObject Pen;

	public GameObject Lid;

	public bool TargetedForDistraction;

	public bool OriginallyTeacher;

	public bool WitnessedCorpse;

	public bool WitnessedMurder;

	public bool YandereInnocent;

	public bool PinDownWitness;

	public bool RepeatReaction;

	public bool WitnessedBlood;

	public bool YandereVisible;

	public bool FleeWhenClean;

	public bool MurderSuicide;

	public bool BoobsResized;

	public bool CheckingNote;

	public bool ClubActivity;

	public bool Complimented;

	public bool Electrocuted;

	public bool HoldingHands;

	public bool PlayingAudio;

	public bool TurnOffRadio;

	public bool ClubAttire;

	public bool Confessing;

	public bool Distracted;

	public bool LewdPhotos;

	public bool InDarkness;

	public bool SwitchBack;

	public bool BatheFast;

	public bool Depressed;

	public bool DiscCheck;

	public bool DressCode;

	public bool Drownable;

	public bool EndSearch;

	public bool KnifeDown;

	public bool Phoneless;

	public bool Attacked;

	public bool Gossiped;

	public bool Pushable;

	public bool Splashed;

	public bool Tranquil;

	public bool WalkBack;

	public bool Alarmed;

	public bool BadTime;

	public bool Drowned;

	public bool Forgave;

	public bool Indoors;

	public bool InEvent;

	public bool Nemesis;

	public bool OnPhone;

	public bool Private;

	public bool Reacted;

	public bool SawMask;

	public bool Spawned;

	public bool Started;

	public bool Suicide;

	public bool Teacher;

	public bool Witness;

	public bool Bloody;

	public bool CanTalk = true;

	public bool Emetic;

	public bool Lethal;

	public bool Routine = true;

	public bool GoAway;

	public bool Grudge;

	public bool Pushed;

	public bool Warned;

	public bool Hurry;

	public bool Rival;

	public bool Slave;

	public DeathType DeathType;

	public bool Halt;

	public bool Lost;

	public bool Male;

	public bool Rose;

	public bool Safe;

	public bool Stop;

	public bool Fed;

	public bool Gas;

	public bool Shy;

	public bool Wet;

	public bool Won;

	public bool DK;

	public bool CameraReacting;

	public bool UsingRigidbody;

	public bool Investigating;

	public bool Distracting;

	public bool PinningDown;

	public bool Struggling;

	public bool Following;

	public bool Reporting;

	public bool Guarding;

	public bool Vomiting;

	public bool Burning;

	public bool Fleeing;

	public bool Hunting;

	public bool Leaving;

	public bool Meeting;

	public bool Talking;

	public bool Waiting;

	public bool Dying;

	public float DistanceToDestination;

	public float DistanceToPlayer;

	public float TargetDistance;

	public float InvestigationTimer;

	public float CameraPoseTimer;

	public float DistractTimer;

	public float ReactionTimer;

	public float WalkBackTimer;

	public float ElectroTimer;

	public float GoAwayTimer;

	public float PatrolTimer;

	public float IgnoreTimer;

	public float ReportTimer;

	public float SplashTimer;

	public float AlarmTimer;

	public float BatheTimer;

	public float RadioTimer;

	public float StuckTimer;

	public float MeetTimer;

	public float TalkTimer;

	public float WaitTimer;

	public float OriginalYPosition;

	public float PreviousEyeShrink;

	public float PreviousAlarm;

	public float RepDeduction;

	public float BreastSize;

	public float Hesitation;

	public float PendingRep;

	public float Perception = 1f;

	public float EyeShrink;

	public float MeetTime;

	public float Paranoia;

	public float RepLoss;

	public float Alarm;

	public int InvestigationPhase;

	public int MurderSuicidePhase;

	public int CameraReactPhase;

	public int SplashPhase;

	public int BathePhase;

	public int VomitPhase;

	public int ClubPhase;

	public int TaskPhase;

	public int ReadPhase;

	public int PinPhase;

	public int Phase;

	public int MurdersWitnessed;

	public PersonaType OriginalPersona;

	public int WeaponWitnessed;

	public int MurderReaction;

	public int GossipBonus;

	public StudentInteractionType Interaction;

	public float RepRecovery;

	public int DeathCause;

	public int Schoolwear;

	public int SkinColor = 3;

	public int RepBonus;

	public int Strength;

	public int Concern;

	public int Crush;

	public string GameOverCause = string.Empty;

	public string CurrentAnim = string.Empty;

	public string RivalPrefix = string.Empty;

	public string RandomAnim = string.Empty;

	public string Accessory = string.Empty;

	public string Hairstyle = string.Empty;

	public string Witnessed = string.Empty;

	public string Name = string.Empty;

	public string OriginalWalkAnim = string.Empty;

	public string WalkAnim = string.Empty;

	public string RunAnim = string.Empty;

	public string SprintAnim = string.Empty;

	public string IdleAnim = string.Empty;

	public string Nod1Anim = string.Empty;

	public string Nod2Anim = string.Empty;

	public string DefendAnim = string.Empty;

	public string DeathAnim = string.Empty;

	public string ScaredAnim = string.Empty;

	public string EvilWitnessAnim = string.Empty;

	public string LookDownAnim = string.Empty;

	public string PhoneAnim = string.Empty;

	public string AngryFaceAnim = string.Empty;

	public string InspectAnim = string.Empty;

	public string GuardAnim = string.Empty;

	public string CallAnim = string.Empty;

	public string CounterAnim = string.Empty;

	public string PushedAnim = string.Empty;

	public string GameAnim = string.Empty;

	public string BentoAnim = string.Empty;

	public string EatAnim = string.Empty;

	public string DrownAnim = string.Empty;

	public string WetAnim = string.Empty;

	public string SplashedAnim = string.Empty;

	public string StripAnim = string.Empty;

	public string ParanoidAnim = string.Empty;

	public string GossipAnim = string.Empty;

	public string SadSitAnim = string.Empty;

	public string BrokenAnim = string.Empty;

	public string BrokenSitAnim = string.Empty;

	public string BrokenWalkAnim = string.Empty;

	public string FistAnim = string.Empty;

	public string AttackAnim = string.Empty;

	public string SuicideAnim = string.Empty;

	public string RelaxAnim = string.Empty;

	public string SitAnim = string.Empty;

	public string ShyAnim = string.Empty;

	public string StalkAnim = string.Empty;

	public string ClubAnim = string.Empty;

	public string StruggleAnim = string.Empty;

	public string StruggleWonAnim = string.Empty;

	public string StruggleLostAnim = string.Empty;

	public string SocialSitAnim = string.Empty;

	public string CarryAnim = string.Empty;

	public string ActivityAnim = string.Empty;

	public string GrudgeAnim = string.Empty;

	public string SadFaceAnim = string.Empty;

	public string CowardAnim = string.Empty;

	public string EvilAnim = string.Empty;

	public string SocialReportAnim = string.Empty;

	public string SocialFearAnim = string.Empty;

	public string SocialTerrorAnim = string.Empty;

	public string BuzzSawDeathAnim = string.Empty;

	public string SwingDeathAnim = string.Empty;

	public string CyborgDeathAnim = string.Empty;

	public string WalkBackAnim = string.Empty;

	public string PatrolAnim = string.Empty;

	public string RadioAnim = string.Empty;

	public string BookSitAnim = string.Empty;

	public string BookReadAnim = string.Empty;

	public string LovedOneAnim = string.Empty;

	public string CuddleAnim = string.Empty;

	public string VomitAnim = string.Empty;

	public string WashFaceAnim = string.Empty;

	public string EmeticAnim = string.Empty;

	public string BurningAnim = string.Empty;

	public string JojoReactAnim = string.Empty;

	public string TeachAnim = string.Empty;

	public string LeanAnim = string.Empty;

	public string DeskTextAnim = string.Empty;

	public string CarryShoulderAnim = string.Empty;

	public string ReadyToFightAnim = string.Empty;

	public string SearchPatrolAnim = string.Empty;

	public string DiscoverPhoneAnim = string.Empty;

	public string[] CameraAnims;

	public string[] SocialAnims;

	public string[] CowardAnims;

	public string[] EvilAnims;

	public string[] HeroAnims;

	public string[] TaskAnims;

	public int ClubMemberID;

	public int ConfessPhase = 1;

	public int ReportPhase;

	public int RadioPhase = 1;

	public int StudentID;

	public int PatrolID;

	public PersonaType Persona;

	public int Class;

	public ClubType Club;

	public int ID;

	public Vector3 LastKnownCorpse;

	public Vector3 DistractionSpot;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Vector3 LastPosition;

	public Vector3 BurnTarget;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform RightEye;

	public Transform LeftEye;

	private float MaxSpeed = 10f;

	public int Frame;

	public Transform DefaultTarget;

	public Transform GushTarget;

	public bool Gush;

	public float LookSpeed = 2f;

	public LowPolyStudentScript LowPoly;

	public Texture[] SocksTextures;

	public GameObject JojoHitEffect;

	public GameObject[] ElectroSteam;

	public GameObject[] CensorSteam;

	public Texture NudeTexture;

	public Mesh BaldNudeMesh;

	public Mesh NudeMesh;

	public Mesh SchoolSwimsuit;

	public Mesh GymUniform;

	public Texture UniformTexture;

	public Texture SwimsuitTexture;

	public Texture GymTexture;

	public bool AoT;

	public Texture TitanBodyTexture;

	public Texture TitanFaceTexture;

	public bool Spooky;

	public Mesh JudoGiMesh;

	public Texture JudoGiTexture;

	public Mesh NoArmsNoTorso;

	public GameObject RiggedAccessory;

	public int CoupleID;

	public bool Alive
	{
		get
		{
			return this.DeathType == DeathType.None;
		}
	}

	public void Start()
	{
		if (!this.Started)
		{
			this.CharacterAnimation = this.Character.GetComponent<Animation>();
			this.CharacterAnimation[this.WalkAnim].time = UnityEngine.Random.Range(0f, this.CharacterAnimation[this.WalkAnim].length);
			this.CharacterAnimation[this.LeanAnim].speed = 0.8f + (float)this.StudentID * 0.01f;
			if (!GameGlobals.LoveSick && SchoolAtmosphere.Type == SchoolAtmosphereType.Low && this.Club <= ClubType.Gaming)
			{
				this.IdleAnim = this.ParanoidAnim;
			}
			if (ClubGlobals.Club == ClubType.Occult)
			{
				this.Perception = 0.5f;
			}
			this.Hearts.emission.enabled = false;
			this.Paranoia = 2f - SchoolGlobals.SchoolAtmosphere * 0.01f;
			this.VisionCone.farClipPlane = ((PlayerGlobals.PantiesEquipped != 4) ? 10f : 5f) * this.Paranoia;
			if (GameObject.Find("DetectionCamera") != null)
			{
				this.DetectionMarker = UnityEngine.Object.Instantiate<GameObject>(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
				this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
				this.DetectionMarker.Target = base.transform;
			}
			StudentJson studentJson = this.JSON.Students[this.StudentID];
			this.ScheduleBlocks = studentJson.ScheduleBlocks;
			this.Persona = studentJson.Persona;
			this.Class = studentJson.Class;
			this.Crush = studentJson.Crush;
			this.Club = studentJson.Club;
			this.BreastSize = studentJson.BreastSize;
			this.Strength = studentJson.Strength;
			this.Hairstyle = studentJson.Hairstyle;
			this.Accessory = studentJson.Accessory;
			this.Name = studentJson.Name;
			if (this.Name == "Random")
			{
				this.Persona = (PersonaType)UnityEngine.Random.Range(1, 7);
				studentJson.Persona = this.Persona;
				if (this.Persona == PersonaType.Heroic)
				{
					this.Strength = UnityEngine.Random.Range(1, 5);
					studentJson.Strength = this.Strength;
				}
			}
			this.Seat = this.StudentManager.Seats[this.Class].List[studentJson.Seat];
			base.gameObject.name = string.Concat(new string[]
			{
				"Student_",
				this.StudentID.ToString(),
				" (",
				this.Name,
				")"
			});
			this.OriginalPersona = this.Persona;
			if (this.Persona == PersonaType.Loner || this.Persona == PersonaType.Coward)
			{
				this.CameraAnims = this.CowardAnims;
			}
			else if (this.Persona == PersonaType.TeachersPet || this.Persona == PersonaType.Heroic || this.Persona == PersonaType.Strict)
			{
				this.CameraAnims = this.HeroAnims;
			}
			else if (this.Persona == PersonaType.Evil)
			{
				this.CameraAnims = this.EvilAnims;
			}
			else if (this.Persona == PersonaType.SocialButterfly || this.Persona == PersonaType.Tsundere)
			{
				this.CameraAnims = this.SocialAnims;
			}
			if (ClubGlobals.GetClubClosed(this.Club))
			{
				this.Club = ClubType.None;
			}
			this.DialogueWheel = GameObject.Find("DialogueWheel").GetComponent<DialogueWheelScript>();
			this.ClubManager = GameObject.Find("ClubManager").GetComponent<ClubManagerScript>();
			this.Reputation = GameObject.Find("Reputation").GetComponent<ReputationScript>();
			this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
			this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
			this.Clock = GameObject.Find("Clock").GetComponent<ClockScript>();
			this.MainCamera = GameObject.Find("MainCamera");
			this.Subtitle = this.Yandere.Subtitle;
			this.ShoulderCamera = this.MainCamera.GetComponent<ShoulderCameraScript>();
			this.CameraEffects = this.MainCamera.GetComponent<CameraEffectsScript>();
			this.RightEyeOrigin = this.RightEye.localPosition;
			this.LeftEyeOrigin = this.LeftEye.localPosition;
			this.PickRandomAnim();
			this.Chopsticks[0].SetActive(false);
			this.Chopsticks[1].SetActive(false);
			this.SmartPhone.SetActive(false);
			this.OccultBook.SetActive(false);
			this.EventBook.SetActive(false);
			this.Bento.SetActive(false);
			this.Pen.SetActive(false);
			this.SpeechLines.Stop();
			this.OriginalWalkAnim = this.WalkAnim;
			if (this.Persona == PersonaType.Evil)
			{
				this.ScaredAnim = this.EvilWitnessAnim;
			}
			if (!this.Male)
			{
				this.AnimatedBook.SetActive(false);
				this.CharacterAnimation[this.StripAnim].speed = 1.5f;
				this.CharacterAnimation[this.GameAnim].speed = 2f;
				if (this.Club >= ClubType.Teacher)
				{
					this.BecomeTeacher();
				}
				if (this.StudentManager.Censor && !this.Teacher)
				{
					this.Cosmetic.CensorPanties();
				}
				this.CharacterAnimation["f02_topHalfTexting_00"].layer = 9;
				this.CharacterAnimation.Play("f02_topHalfTexting_00");
				this.CharacterAnimation["f02_topHalfTexting_00"].weight = 0f;
				this.CharacterAnimation[this.CarryAnim].layer = 8;
				this.CharacterAnimation.Play(this.CarryAnim);
				this.CharacterAnimation[this.CarryAnim].weight = 0f;
				this.CharacterAnimation[this.SocialSitAnim].layer = 7;
				this.CharacterAnimation.Play(this.SocialSitAnim);
				this.CharacterAnimation[this.SocialSitAnim].weight = 0f;
				this.CharacterAnimation[this.ShyAnim].layer = 6;
				this.CharacterAnimation.Play(this.ShyAnim);
				this.CharacterAnimation[this.ShyAnim].weight = 0f;
				this.CharacterAnimation[this.FistAnim].layer = 5;
				this.CharacterAnimation[this.FistAnim].weight = 0f;
				this.CharacterAnimation[this.WetAnim].layer = 4;
				this.CharacterAnimation.Play(this.WetAnim);
				this.CharacterAnimation[this.WetAnim].weight = 0f;
				this.CharacterAnimation[this.BentoAnim].layer = 3;
				this.CharacterAnimation.Play(this.BentoAnim);
				this.CharacterAnimation[this.BentoAnim].weight = 0f;
				this.CharacterAnimation[this.AngryFaceAnim].layer = 2;
				this.CharacterAnimation.Play(this.AngryFaceAnim);
				this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
				this.DisableEffects();
				this.CharacterAnimation["f02_wetIdle_00"].speed = 1.25f;
				this.DisableEffects();
			}
			else
			{
				this.CharacterAnimation[this.LeanAnim].speed *= -1f;
				this.CharacterAnimation[this.CarryShoulderAnim].layer = 5;
				this.CharacterAnimation.Play(this.CarryShoulderAnim);
				this.CharacterAnimation[this.CarryShoulderAnim].weight = 0f;
				this.CharacterAnimation["scaredFace_00"].layer = 4;
				this.CharacterAnimation.Play("scaredFace_00");
				this.CharacterAnimation["scaredFace_00"].weight = 0f;
				this.CharacterAnimation[this.SadFaceAnim].layer = 3;
				this.CharacterAnimation.Play(this.SadFaceAnim);
				this.CharacterAnimation[this.SadFaceAnim].weight = 0f;
				this.CharacterAnimation[this.AngryFaceAnim].layer = 2;
				this.CharacterAnimation.Play(this.AngryFaceAnim);
				this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
				this.Earpiece.SetActive(false);
			}
			if (this.StudentID == 7 || this.StudentID == 13)
			{
				if (DatingGlobals.SuitorProgress == 2)
				{
					this.Partner = ((this.StudentID != 7) ? this.StudentManager.Students[7] : this.StudentManager.Students[13]);
					ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
					scheduleBlock.destination = "Cuddle";
					scheduleBlock.action = "Cuddle";
				}
			}
			else if (this.StudentID == 16)
			{
				this.SmartPhone.GetComponent<AudioSource>().playOnAwake = true;
				this.PatrolAnim = "f02_texting_00";
			}
			else if (this.StudentID == 17)
			{
				if (StudentGlobals.GetStudentDead(18))
				{
					ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[2];
					scheduleBlock2.destination = "Mourn";
					scheduleBlock2.action = "Mourn";
				}
			}
			else if (this.StudentID == 18)
			{
				if (StudentGlobals.GetStudentDead(17))
				{
					ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[2];
					scheduleBlock3.destination = "Mourn";
					scheduleBlock3.action = "Mourn";
				}
			}
			else if (this.StudentID == 34)
			{
			}
			if (this.StudentID == this.StudentManager.RivalID)
			{
				this.RivalPrefix = "Rival ";
			}
			if (this.Club == ClubType.None)
			{
				if (this.StudentID == 33)
				{
					this.SmartPhone.transform.localPosition = new Vector3(-0.0075f, -0.0025f, -0.0075f);
					this.SmartPhone.transform.localEulerAngles = new Vector3(5f, -150f, 170f);
					this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.OsanaPhoneTexture;
					this.IdleAnim = "f02_tsunIdle_00";
					this.WalkAnim = "f02_tsunWalk_00";
					this.TaskAnims[0] = "f02_Task33_Line0";
					this.TaskAnims[1] = "f02_Task33_Line1";
					this.TaskAnims[2] = "f02_Task33_Line2";
					this.TaskAnims[3] = "f02_Task33_Line3";
					this.TaskAnims[4] = "f02_Task33_Line4";
					this.TaskAnims[5] = "f02_Task33_Line5";
				}
			}
			else if (this.Club == ClubType.Occult)
			{
				if (this.StudentID == 26)
				{
					if (StudentGlobals.GetStudentDead(17) && StudentGlobals.GetStudentDead(18))
					{
						ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[2];
						scheduleBlock4.destination = "Club";
						scheduleBlock4.action = "Club";
					}
					this.ClubAnim = this.IdleAnim;
					this.Shy = true;
				}
				else if (this.Male)
				{
					this.CharacterAnimation[this.SadFaceAnim].weight = 1f;
				}
			}
			else if (this.Club == ClubType.MartialArts)
			{
				this.ChangingBooth = this.StudentManager.ChangingBooths[6];
				this.DressCode = true;
				if (this.StudentID == 21)
				{
					this.IdleAnim = "pose_03";
					this.ClubAnim = "pose_03";
				}
				else if (this.StudentID == 22)
				{
					this.ClubAnim = "idle_20";
					this.ActivityAnim = "kick_24";
				}
				else if (this.StudentID == 23)
				{
					this.ClubAnim = "sit_04";
					this.ActivityAnim = "kick_24";
				}
				else if (this.StudentID == 24)
				{
					this.ClubAnim = "f02_idle_20";
					this.ActivityAnim = "f02_kick_23";
				}
				else if (this.StudentID == 25)
				{
					this.ClubAnim = "f02_sit_05";
					this.ActivityAnim = "f02_kick_23";
				}
				this.ClubMemberID = this.StudentID - 20;
			}
			if (this.Cosmetic.Hairstyle == 20)
			{
				this.IdleAnim = "f02_tsunIdle_00";
			}
			this.GetDestinations();
			if (this.AoT)
			{
				this.AttackOnTitan();
			}
			if (this.Slave)
			{
				this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
				this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
				this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
				this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
				this.IdleAnim = this.BrokenAnim;
				this.WalkAnim = this.BrokenWalkAnim;
				this.Phone.SetActive(false);
				this.Distracted = true;
				this.OnPhone = false;
				this.Indoors = true;
				this.Safe = false;
				this.ID = 0;
				while (this.ID < this.ScheduleBlocks.Length)
				{
					this.ScheduleBlocks[this.ID].time = 0f;
					this.ID++;
				}
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
				this.DetectionMarker.GetComponent<DetectionMarkerScript>().Tex.color = new Color(1f, 0f, 0f, 0f);
				this.Yandere.Senpai = base.transform;
				this.ID = 0;
				while (this.ID < this.Outlines.Length)
				{
					this.Outlines[this.ID].enabled = true;
					this.Outlines[this.ID].color = new Color(1f, 0f, 1f);
					this.ID++;
				}
				this.Prompt.ButtonActive[0] = false;
				this.Prompt.ButtonActive[1] = false;
				this.Prompt.ButtonActive[2] = false;
				this.Prompt.ButtonActive[3] = false;
				if (this.StudentManager.MissionMode)
				{
					base.transform.position = Vector3.zero;
					base.gameObject.SetActive(false);
				}
			}
			else if (!StudentGlobals.GetStudentPhotographed(this.StudentID))
			{
				this.ID = 0;
				while (this.ID < this.Outlines.Length)
				{
					this.Outlines[this.ID].enabled = false;
					this.Outlines[this.ID].color = new Color(0f, 1f, 0f);
					this.ID++;
				}
			}
			if (StudentGlobals.GetStudentGrudge(this.StudentID))
			{
				if (this.Persona != PersonaType.Coward && this.Persona != PersonaType.Evil)
				{
					this.CameraAnims = this.EvilAnims;
					this.Reputation.PendingRep -= 10f;
					this.PendingRep -= 10f;
					this.ID = 0;
					while (this.ID < this.Outlines.Length)
					{
						this.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
						this.ID++;
					}
				}
				this.Grudge = true;
				this.CameraAnims = this.EvilAnims;
			}
			if (StudentGlobals.GetStudentBroken(this.StudentID))
			{
				this.Cosmetic.RightEyeRenderer.gameObject.SetActive(false);
				this.Cosmetic.LeftEyeRenderer.gameObject.SetActive(false);
				this.Cosmetic.RightIrisLight.SetActive(false);
				this.Cosmetic.LeftIrisLight.SetActive(false);
				this.RightEmptyEye.SetActive(true);
				this.LeftEmptyEye.SetActive(true);
				this.Shy = true;
			}
			if (this.Club != ClubType.None && (this.StudentID == 21 || this.StudentID == 26))
			{
				this.Armband.SetActive(true);
			}
			if (!this.Teacher)
			{
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.Destinations[this.Phase];
			}
			else
			{
				this.Indoors = true;
			}
			if (this.StudentID == 1 || this.StudentID == 19 || this.StudentID == 33)
			{
				this.BookRenderer.material.mainTexture = this.RedBookTexture;
			}
			this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			if (this.StudentManager.MissionMode && this.StudentID == MissionModeGlobals.MissionTarget)
			{
				this.ID = 0;
				while (this.ID < this.Outlines.Length)
				{
					this.Outlines[this.ID].enabled = true;
					this.Outlines[this.ID].color = new Color(1f, 0f, 0f);
					this.ID++;
				}
			}
			UnityEngine.Object.Destroy(this.MyRigidbody);
			this.Started = true;
			if (this.Name == "Delinquent")
			{
				this.CharacterAnimation[this.CarryShoulderAnim].weight = 1f;
				this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
				this.Weapon.SetActive(true);
			}
		}
	}

	private bool AffectedByEbola(float distance)
	{
		bool flag = this.Yandere.EbolaHair != null && this.Yandere.EbolaHair.activeInHierarchy;
		return distance <= 1f && flag;
	}

	private void Update()
	{
		if (!this.Stop)
		{
			this.DistanceToPlayer = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
			if (this.AffectedByEbola(this.DistanceToPlayer) && this.Alive)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Yandere.EbolaEffect, base.transform.position + Vector3.up, Quaternion.identity);
				this.SpawnAlarmDisc();
				this.BecomeRagdoll();
				this.DeathType = DeathType.EasterEgg;
			}
			this.UpdateRoutine();
			this.UpdateVision();
			this.UpdateDetectionMarker();
			this.UpdateTalkInput();
			if (this.Dying)
			{
				this.UpdateDying();
			}
			else if (this.Pushed)
			{
				this.UpdatePushed();
			}
			else if (this.Drowned)
			{
				this.UpdateDrowned();
			}
			else if (this.WitnessedMurder)
			{
				this.UpdateWitnessedMurder();
			}
			else if (this.Alarmed)
			{
				this.UpdateAlarmed();
			}
			if (this.Burning)
			{
				this.UpdateBurning();
			}
			else if (this.Splashed)
			{
				this.UpdateSplashed();
			}
			this.UpdateTurningOffRadio();
			this.UpdateVomiting();
			this.UpdateConfessing();
			this.UpdateMisc();
		}
		else if (this.StudentManager.Pose)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Pose();
			}
		}
		else if (!this.ClubActivity)
		{
			if (!this.Yandere.Talking && this.Yandere.Noticed)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			}
		}
		else if (this.Police.Darkness.color.a < 1f)
		{
			this.CharacterAnimation.Play(this.ActivityAnim);
			if (this.Club == ClubType.MartialArts)
			{
				AudioSource component = base.GetComponent<AudioSource>();
				if (!this.Male)
				{
					if (this.CharacterAnimation["f02_kick_23"].time > 1f)
					{
						if (!this.PlayingAudio)
						{
							component.clip = this.FemaleAttacks[UnityEngine.Random.Range(0, this.FemaleAttacks.Length)];
							component.Play();
							this.PlayingAudio = true;
						}
						if (this.CharacterAnimation["f02_kick_23"].time >= this.CharacterAnimation["f02_kick_23"].length)
						{
							this.CharacterAnimation["f02_kick_23"].time = 0f;
							this.PlayingAudio = false;
						}
					}
				}
				else if (this.CharacterAnimation["kick_24"].time > 1f)
				{
					if (!this.PlayingAudio)
					{
						component.clip = this.MaleAttacks[UnityEngine.Random.Range(0, this.MaleAttacks.Length)];
						component.Play();
						this.PlayingAudio = true;
					}
					if (this.CharacterAnimation["kick_24"].time >= this.CharacterAnimation["kick_24"].length)
					{
						this.CharacterAnimation["kick_24"].time = 0f;
						this.PlayingAudio = false;
					}
				}
			}
		}
		if (this.AoT)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(10f, 10f, 10f), Time.deltaTime);
		}
		if (this.Prompt.Label[0] != null)
		{
			if (this.StudentManager.Pose)
			{
				this.Prompt.Label[0].text = "     Pose";
			}
			else if (this.BadTime)
			{
				this.Prompt.Label[0].text = "     Psychokinesis";
			}
		}
	}

	private void UpdateRoutine()
	{
		if (this.Routine)
		{
			if (this.CurrentDestination != null)
			{
				this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
			}
			if (!this.Indoors)
			{
				if (this.Phase == 0)
				{
					if (this.DistanceToDestination < 1f)
					{
						this.CurrentDestination = this.MyLocker;
						this.Pathfinding.target = this.MyLocker;
						this.Phase++;
					}
				}
				else if (this.DistanceToDestination < 0.5f && !this.ShoeRemoval.enabled)
				{
					if (this.Shy)
					{
						this.CharacterAnimation[this.ShyAnim].weight = 0.5f;
					}
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.ShoeRemoval.enabled = true;
					this.Routine = false;
				}
			}
			else if (this.Phase < this.ScheduleBlocks.Length - 1 && this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time && !this.InEvent && !this.Meeting)
			{
				this.Phase++;
				if (this.StudentID == 33)
				{
					Debug.Log("Osana's phase has increased to " + this.Phase.ToString() + ".");
				}
				if (this.Schoolwear > 1 && this.Destinations[this.Phase] == this.MyLocker)
				{
					this.Phase++;
				}
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.Destinations[this.Phase];
				if (this.StudentID == 7 && this.Actions[this.Phase] == StudentActionType.ChangeShoes && this.StudentManager.DatingMinigame.Affection == 100f)
				{
					this.CurrentDestination = this.StudentManager.SuitorLocker;
					this.Pathfinding.target = this.StudentManager.SuitorLocker;
					this.Confessing = true;
					this.Routine = false;
					this.CanTalk = false;
				}
				if (this.CurrentDestination != null)
				{
					this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
				}
				if (this.Bento != null && this.Bento.activeInHierarchy)
				{
					this.Bento.SetActive(false);
					this.Chopsticks[0].SetActive(false);
					this.Chopsticks[1].SetActive(false);
				}
				if (this.Male)
				{
					this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 0f);
				}
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.OccultBook.SetActive(false);
				this.Phone.SetActive(false);
				this.Pen.SetActive(false);
				this.SpeechLines.Stop();
				this.GoAway = false;
				this.ReadPhase = 0;
			}
			if (this.MeetTime > 0f && this.Clock.HourTime > this.MeetTime)
			{
				this.CurrentDestination = this.MeetSpot;
				this.Pathfinding.target = this.MeetSpot;
				this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Pathfinding.speed = 4f;
				this.Meeting = true;
				this.MeetTime = 0f;
			}
			if (this.DistanceToDestination > this.TargetDistance)
			{
				if (!this.InEvent && !this.Meeting && this.DressCode)
				{
					if (this.Actions[this.Phase] == StudentActionType.ClubAction)
					{
						if (!this.ClubAttire)
						{
							if (!this.ChangingBooth.Occupied)
							{
								this.CurrentDestination = this.ChangingBooth.transform;
								this.Pathfinding.target = this.ChangingBooth.transform;
							}
							else
							{
								this.CurrentDestination = this.ChangingBooth.WaitSpots[this.ClubMemberID];
								this.Pathfinding.target = this.ChangingBooth.WaitSpots[this.ClubMemberID];
							}
						}
						else if (this.Indoors)
						{
							this.CurrentDestination = this.Destinations[this.Phase];
							this.Pathfinding.target = this.Destinations[this.Phase];
						}
					}
					else if (this.ClubAttire)
					{
						if (!this.ChangingBooth.Occupied)
						{
							this.CurrentDestination = this.ChangingBooth.transform;
							this.Pathfinding.target = this.ChangingBooth.transform;
						}
						else
						{
							this.CurrentDestination = this.ChangingBooth.WaitSpots[this.ClubMemberID];
							this.Pathfinding.target = this.ChangingBooth.WaitSpots[this.ClubMemberID];
						}
					}
					else if (this.Indoors)
					{
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
					}
				}
				if (!this.Pathfinding.canMove)
				{
					if (!this.Spawned)
					{
						base.transform.position = this.StudentManager.SpawnPositions[this.StudentID].position;
						this.Spawned = true;
					}
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Obstacle.enabled = false;
				}
				if (this.Pathfinding.speed > 0f)
				{
					if (this.Pathfinding.speed == 1f)
					{
						if (!this.OnPhone)
						{
							if (!this.CharacterAnimation.IsPlaying(this.WalkAnim))
							{
								this.CharacterAnimation.CrossFade(this.WalkAnim);
							}
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.PhoneAnim);
						}
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.SprintAnim);
					}
				}
				if (this.Club == ClubType.Occult && this.Actions[this.Phase] != StudentActionType.ClubAction)
				{
					this.OccultBook.SetActive(false);
				}
			}
			else
			{
				if (this.CurrentDestination != null)
				{
					this.MoveTowardsTarget(this.CurrentDestination.position);
					float num = Quaternion.Angle(base.transform.rotation, this.CurrentDestination.rotation);
					if (num > 1f)
					{
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, 10f * Time.deltaTime);
					}
					if (!this.Hurry)
					{
						this.Pathfinding.speed = 1f;
					}
					else
					{
						this.Pathfinding.speed = 4f;
					}
				}
				if (this.Pathfinding.canMove)
				{
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.Obstacle.enabled = true;
				}
				if (!this.InEvent && !this.Meeting && this.DressCode)
				{
					if (this.Actions[this.Phase] == StudentActionType.ClubAction)
					{
						if (!this.ClubAttire)
						{
							if (!this.ChangingBooth.Occupied)
							{
								if (this.CurrentDestination == this.ChangingBooth.transform)
								{
									this.ChangingBooth.Occupied = true;
									this.ChangingBooth.Student = this;
									this.ChangingBooth.CheckYandereClub();
								}
								this.CurrentDestination = this.ChangingBooth.transform;
								this.Pathfinding.target = this.ChangingBooth.transform;
							}
							else
							{
								this.CharacterAnimation.CrossFade(this.IdleAnim);
							}
						}
						else
						{
							this.CurrentDestination = this.Destinations[this.Phase];
							this.Pathfinding.target = this.Destinations[this.Phase];
						}
					}
					else if (this.ClubAttire)
					{
						if (!this.ChangingBooth.Occupied)
						{
							if (this.CurrentDestination == this.ChangingBooth.transform)
							{
								this.ChangingBooth.Occupied = true;
								this.ChangingBooth.Student = this;
								this.ChangingBooth.CheckYandereClub();
							}
							this.CurrentDestination = this.ChangingBooth.transform;
							this.Pathfinding.target = this.ChangingBooth.transform;
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
					}
					else
					{
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
					}
				}
				if (!this.InEvent)
				{
					if (!this.Meeting)
					{
						if (!this.GoAway)
						{
							if (this.Actions[this.Phase] == StudentActionType.AtLocker)
							{
								this.CharacterAnimation.CrossFade(this.IdleAnim);
							}
							else if (this.Actions[this.Phase] == StudentActionType.Socializing)
							{
								if (this.Paranoia > 1.66666f && !GameGlobals.LoveSick)
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
								}
								else
								{
									if (!this.SpeechLines.isPlaying)
									{
										this.SpeechLines.Play();
									}
									this.CharacterAnimation.CrossFade(this.RandomAnim);
									if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
									{
										this.PickRandomAnim();
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Gaming)
							{
								this.CharacterAnimation.CrossFade(this.GameAnim);
							}
							else if (this.Actions[this.Phase] == StudentActionType.Shamed)
							{
								this.CharacterAnimation.CrossFade(this.SadSitAnim);
							}
							else if (this.Actions[this.Phase] == StudentActionType.Slave)
							{
								this.CharacterAnimation.CrossFade(this.BrokenSitAnim);
							}
							else if (this.Actions[this.Phase] == StudentActionType.Relax)
							{
								this.CharacterAnimation.CrossFade(this.RelaxAnim);
							}
							else if (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes)
							{
								if (this.Rival && this.Phoneless && this.StudentManager.CommunalLocker.RivalPhone.gameObject.activeInHierarchy && !this.EndSearch && this.Yandere.CanMove)
								{
									this.CharacterAnimation.CrossFade(this.DiscoverPhoneAnim);
									this.Subtitle.UpdateLabel(this.RivalPrefix + "Lost Phone", 2, 5f);
									this.EndSearch = true;
									this.Routine = false;
								}
								if (!this.EndSearch)
								{
									if (this.Clock.Period != 2 && this.Clock.Period != 4)
									{
										if (this.DressCode && this.ClubAttire)
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
										}
										else if (!this.Phoneless)
										{
											if (!this.Phone.activeInHierarchy)
											{
												this.Phone.transform.localPosition = new Vector3(0.02f, 0.01f, 0.02f);
												this.Phone.transform.localEulerAngles = new Vector3(-15f, 30f, 0f);
												this.Phone.SetActive(true);
											}
											this.CharacterAnimation.CrossFade(this.DeskTextAnim);
										}
										else
										{
											this.CharacterAnimation.CrossFade("f02_sadDeskSit_00");
										}
									}
									else if (this.MyTeacher.SpeechLines.isPlaying)
									{
										if (this.DressCode && this.ClubAttire)
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
										}
										else
										{
											if (!this.Depressed && !this.Pen.activeInHierarchy)
											{
												this.Pen.SetActive(true);
											}
											if (this.Phone.activeInHierarchy)
											{
												this.Phone.SetActive(false);
											}
											if (this.MyPaper == null)
											{
												if (base.transform.position.x < 0f)
												{
													this.MyPaper = UnityEngine.Object.Instantiate<GameObject>(this.Paper, this.Seat.position + new Vector3(-0.4f, 0.772f, 0f), Quaternion.identity);
												}
												else
												{
													this.MyPaper = UnityEngine.Object.Instantiate<GameObject>(this.Paper, this.Seat.position + new Vector3(0.4f, 0.772f, 0f), Quaternion.identity);
												}
												this.MyPaper.transform.eulerAngles = new Vector3(0f, 0f, -90f);
												this.MyPaper.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
												this.MyPaper.transform.parent = this.StudentManager.Papers;
											}
											this.CharacterAnimation.CrossFade(this.SitAnim);
										}
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Stalk)
							{
								this.CharacterAnimation.CrossFade(this.StalkAnim);
								if (this.Male)
								{
									this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.ClubAction)
							{
								if (this.DressCode && !this.ClubAttire)
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ClubAnim);
								}
								if (this.Club == ClubType.Occult && this.StudentID != 26)
								{
									this.OccultBook.SetActive(true);
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.SitAndSocialize)
							{
								if (this.Paranoia > 1.66666f)
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
								}
								else
								{
									if (!this.SpeechLines.isPlaying)
									{
										this.SpeechLines.Play();
									}
									this.CharacterAnimation.CrossFade(this.RandomAnim);
									if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
									{
										this.PickRandomAnim();
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.SitAndEatBento)
							{
								if (!this.Ragdoll.Poisoned && !this.Bento.activeInHierarchy)
								{
									this.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
									this.Bento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
									this.Chopsticks[0].SetActive(true);
									this.Chopsticks[1].SetActive(true);
									this.Bento.SetActive(true);
									this.Lid.SetActive(false);
								}
								if (!this.Emetic && !this.Lethal)
								{
									this.CharacterAnimation.CrossFade(this.EatAnim);
								}
								else if (this.Emetic)
								{
									if (!this.Distracted)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										this.CharacterAnimation.CrossFade(this.EmeticAnim);
										this.Distracted = true;
										this.CanTalk = false;
									}
									if (this.CharacterAnimation[this.EmeticAnim].time >= this.CharacterAnimation[this.EmeticAnim].length)
									{
										this.WalkAnim = "f02_stomachPainWalk_00";
										this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
										this.Pathfinding.target = this.StudentManager.FemaleVomitSpot;
										this.CurrentDestination = this.StudentManager.FemaleVomitSpot;
										this.CharacterAnimation.CrossFade(this.WalkAnim);
										this.Pathfinding.canSearch = true;
										this.DistanceToDestination = 100f;
										this.Pathfinding.canMove = true;
										this.Pathfinding.speed = 2f;
										this.Routine = false;
										this.Vomiting = true;
										this.Private = true;
										this.Chopsticks[0].SetActive(false);
										this.Chopsticks[1].SetActive(false);
										this.Bento.SetActive(false);
									}
								}
								else
								{
									if (!this.Distracted)
									{
										this.StudentManager.Students[1].CharacterAnimation.CrossFade("witnessPoisoning_00");
										this.StudentManager.Students[1].Distracted = true;
										this.StudentManager.Students[1].Routine = false;
										this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										this.CharacterAnimation.CrossFade("f02_poisonDeath_00");
										this.Ragdoll.Poisoned = true;
										this.Distracted = true;
										this.Prompt.Hide();
										this.Prompt.enabled = false;
									}
									if (this.CharacterAnimation["f02_poisonDeath_00"].time >= 17.5f && this.Bento.activeInHierarchy)
									{
										this.StudentManager.Students[1].Chopsticks[0].SetActive(false);
										this.StudentManager.Students[1].Chopsticks[1].SetActive(false);
										this.StudentManager.Students[1].Bento.SetActive(false);
										this.Chopsticks[0].SetActive(false);
										this.Chopsticks[1].SetActive(false);
										this.Bento.SetActive(false);
									}
									if (this.CharacterAnimation["f02_poisonDeath_00"].time >= this.CharacterAnimation["f02_poisonDeath_00"].length)
									{
										this.BecomeRagdoll();
										this.DeathType = DeathType.Poison;
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.ChangeShoes)
							{
								if (this.MeetTime == 0f)
								{
									if (this.StudentID == 13 && this.StudentManager.LoveManager.LeftNote)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										this.CharacterAnimation.CrossFade("keepNote_00");
										this.ShoeRemoval.Locker.GetComponent<Animation>().CrossFade("lockerKeepNote");
										this.Pathfinding.canSearch = false;
										this.Pathfinding.canMove = false;
										this.Confessing = true;
										this.CanTalk = false;
										this.Routine = false;
									}
									else
									{
										this.Pathfinding.canSearch = false;
										this.Pathfinding.canMove = false;
										this.ShoeRemoval.enabled = true;
										this.CanTalk = false;
										this.Routine = false;
										this.ShoeRemoval.LeavingSchool();
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.GradePapers)
							{
								this.CharacterAnimation.CrossFade("f02_deskWrite");
								this.GradingPaper.Writing = true;
								this.Obstacle.enabled = true;
								this.Pen.SetActive(true);
							}
							else if (this.Actions[this.Phase] == StudentActionType.Patrol)
							{
								this.PatrolTimer += Time.deltaTime;
								this.CharacterAnimation.CrossFade(this.PatrolAnim);
								if (this.PatrolTimer >= this.CharacterAnimation[this.PatrolAnim].length)
								{
									this.PatrolID++;
									if (this.PatrolID == this.StudentManager.Patrols.List[this.StudentID].childCount)
									{
										this.PatrolID = 0;
									}
									this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
									this.Pathfinding.target = this.CurrentDestination;
									if (this.StudentID == 16)
									{
										this.CharacterAnimation["f02_topHalfTexting_00"].weight = 1f;
									}
									this.PatrolTimer = 0f;
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Read)
							{
								if (this.ReadPhase == 0)
								{
									this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
									this.CharacterAnimation.CrossFade(this.BookSitAnim);
									if (this.CharacterAnimation[this.BookSitAnim].time > this.CharacterAnimation[this.BookSitAnim].length)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
										this.CharacterAnimation.CrossFade(this.BookReadAnim);
										this.ReadPhase++;
									}
									else if (this.CharacterAnimation[this.BookSitAnim].time > 1f)
									{
										this.OccultBook.SetActive(true);
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Texting)
							{
								this.CharacterAnimation.CrossFade("f02_texting_00");
								if (!this.SmartPhone.activeInHierarchy && base.transform.position.y > 11f)
								{
									this.SmartPhone.SetActive(true);
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Mourn)
							{
								this.CharacterAnimation.CrossFade("f02_brokenSit_00");
							}
							else if (this.Actions[this.Phase] == StudentActionType.Cuddle)
							{
								if (Vector3.Distance(base.transform.position, this.Partner.transform.position) < 1f)
								{
									ParticleSystem.EmissionModule emission = this.Hearts.emission;
									if (!emission.enabled)
									{
										emission.enabled = true;
										if (!this.Male)
										{
											this.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
										}
										else
										{
											this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
										}
									}
									this.CharacterAnimation.CrossFade(this.CuddleAnim);
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Teaching)
							{
								if (this.Clock.Period != 2 && this.Clock.Period != 4)
								{
									this.CharacterAnimation.CrossFade("f02_teacherPodium_00");
								}
								else
								{
									if (!this.SpeechLines.isPlaying)
									{
										this.SpeechLines.Play();
									}
									this.CharacterAnimation.CrossFade(this.TeachAnim);
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.SearchPatrol)
							{
								if (this.PatrolID == 0 && this.StudentManager.CommunalLocker.RivalPhone.gameObject.activeInHierarchy && !this.EndSearch)
								{
									this.CharacterAnimation.CrossFade(this.DiscoverPhoneAnim);
									this.Subtitle.UpdateLabel(this.RivalPrefix + "Lost Phone", 2, 5f);
									this.EndSearch = true;
									this.Routine = false;
								}
								if (!this.EndSearch)
								{
									this.PatrolTimer += Time.deltaTime;
									this.CharacterAnimation.CrossFade(this.SearchPatrolAnim);
									if (this.PatrolTimer >= this.CharacterAnimation[this.SearchPatrolAnim].length)
									{
										this.PatrolID++;
										if (this.PatrolID == this.StudentManager.SearchPatrols.List[this.StudentID].childCount)
										{
											this.PatrolID = 0;
										}
										this.CurrentDestination = this.StudentManager.SearchPatrols.List[this.StudentID].GetChild(this.PatrolID);
										this.Pathfinding.target = this.CurrentDestination;
										this.DistanceToDestination = 100f;
										if (this.StudentID == 16)
										{
											this.CharacterAnimation["f02_topHalfTexting_00"].weight = 1f;
										}
										this.PatrolTimer = 0f;
									}
								}
							}
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.GoAwayTimer += Time.deltaTime;
							if (this.GoAwayTimer > 60f)
							{
								this.CurrentDestination = this.Destinations[this.Phase];
								this.Pathfinding.target = this.Destinations[this.Phase];
								this.GoAwayTimer = 0f;
								this.GoAway = false;
							}
						}
					}
					else
					{
						if (this.MeetTimer == 0f)
						{
							if (PlayerGlobals.GetStudentFriend(7) && this.Yandere.Bloodiness == 0f && (double)this.Yandere.Sanity >= 66.66666 && (this.CurrentDestination == this.StudentManager.MeetSpots.List[8] || this.CurrentDestination == this.StudentManager.MeetSpots.List[9] || this.CurrentDestination == this.StudentManager.MeetSpots.List[10]))
							{
								this.StudentManager.OfferHelp.UpdateLocation();
								this.StudentManager.OfferHelp.enabled = true;
							}
							if (base.transform.position.y > 11f)
							{
								this.Prompt.Label[0].text = "     Push";
								this.Prompt.HideButton[0] = false;
								this.Pushable = true;
							}
							if (this.CurrentDestination == this.StudentManager.FountainSpot)
							{
								this.Prompt.Label[0].text = "     Drown";
								this.Prompt.HideButton[0] = false;
								this.Drownable = true;
							}
						}
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.MeetTimer += Time.deltaTime;
						if (this.MeetTimer > 60f)
						{
							if (!this.Male)
							{
								this.Subtitle.UpdateLabel("Note Reaction", 4, 3f);
							}
							else
							{
								this.Subtitle.UpdateLabel("Note Reaction", 6, 3f);
							}
							while (this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time)
							{
								this.Phase++;
							}
							this.CurrentDestination = this.Destinations[this.Phase];
							this.Pathfinding.target = this.Destinations[this.Phase];
							this.StopMeeting();
						}
					}
				}
			}
		}
		else
		{
			if (this.CurrentDestination != null)
			{
				this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
			}
			if (this.Fleeing)
			{
				if (!this.PinningDown)
				{
					if (this.Yandere.Chased)
					{
						this.Pathfinding.speed += Time.deltaTime;
					}
					this.DistanceToDestination = Vector3.Distance(base.transform.position, this.Pathfinding.target.position);
					if (this.AlarmTimer > 0f)
					{
						this.AlarmTimer = Mathf.MoveTowards(this.AlarmTimer, 0f, Time.deltaTime);
						if (this.StudentID == 1)
						{
							Debug.Log("Senpai entered his scared animation.");
						}
						this.CharacterAnimation.CrossFade(this.ScaredAnim);
						if (this.AlarmTimer == 0f)
						{
							this.WalkBack = false;
							this.Alarmed = false;
						}
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						if (this.WitnessedMurder)
						{
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
						}
						else if (this.WitnessedCorpse)
						{
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - base.transform.position);
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
						}
					}
					else
					{
						if (this.Persona == PersonaType.TeachersPet && this.StudentManager.Reporter == null && !this.Police.Called)
						{
							this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
							this.StudentManager.Reporter = this;
							this.Reporting = true;
						}
						if (base.transform.position.y < -2f)
						{
							if (this.Persona != PersonaType.Coward && this.Persona != PersonaType.Evil && this.OriginalPersona != PersonaType.Evil)
							{
								this.Police.Witnesses--;
								this.Police.Show = true;
							}
							base.gameObject.SetActive(false);
						}
						if (base.transform.position.z < -99f)
						{
							this.Prompt.Hide();
							this.Prompt.enabled = false;
							this.Safe = true;
						}
						if (this.DistanceToDestination > this.TargetDistance)
						{
							this.CharacterAnimation.CrossFade(this.SprintAnim);
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
							if (this.Yandere.Chased)
							{
								this.Pathfinding.repathRate = 0f;
								this.Pathfinding.speed = 7.5f;
							}
							else
							{
								this.Pathfinding.speed = 4f;
							}
						}
						else
						{
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							if (!this.Halt)
							{
								this.MoveTowardsTarget(this.Pathfinding.target.position);
								if (!this.Teacher)
								{
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
								}
							}
							else if (this.Persona == PersonaType.TeachersPet)
							{
								this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Teachers[this.Class].transform.position.x, base.transform.position.y, this.StudentManager.Teachers[this.Class].transform.position.z) - base.transform.position);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
							}
							if (this.Persona == PersonaType.TeachersPet)
							{
								if (this.Reporting)
								{
									if (this.StudentManager.Teachers[this.Class].Alarmed)
									{
										this.Pathfinding.target = this.Seat;
										this.CurrentDestination = this.Seat;
										this.ReportPhase = 2;
									}
									if (this.ReportPhase == 0)
									{
										this.CharacterAnimation.CrossFade(this.ScaredAnim);
										if (this.WitnessedCorpse)
										{
											this.Subtitle.UpdateLabel("Pet Corpse Report", 2, 3f);
										}
										else
										{
											this.Subtitle.UpdateLabel("Pet Murder Report", 2, 3f);
										}
										this.StudentManager.Teachers[this.Class].CharacterAnimation.CrossFade(this.StudentManager.Teachers[this.Class].IdleAnim);
										this.StudentManager.Teachers[this.Class].Routine = false;
										this.Halt = true;
										this.ReportPhase++;
									}
									else if (this.ReportPhase == 1)
									{
										this.CharacterAnimation.CrossFade(this.ScaredAnim);
										this.StudentManager.Teachers[this.Class].targetRotation = Quaternion.LookRotation(base.transform.position - this.StudentManager.Teachers[this.Class].transform.position);
										this.StudentManager.Teachers[this.Class].transform.rotation = Quaternion.Slerp(this.StudentManager.Teachers[this.Class].transform.rotation, this.StudentManager.Teachers[this.Class].targetRotation, 10f * Time.deltaTime);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 3f)
										{
											base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
											this.StudentManager.Teachers[this.Class].MyReporter = base.transform;
											this.StudentManager.Teachers[this.Class].Routine = false;
											this.StudentManager.Teachers[this.Class].Fleeing = true;
											this.ReportTimer = 0f;
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase < 100)
									{
										this.CharacterAnimation.CrossFade(this.ParanoidAnim);
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.ScaredAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 5f)
										{
											if (this.StudentManager.Reporter == this)
											{
												this.StudentManager.Reporter = null;
												this.StudentManager.StopFleeing();
												this.StudentManager.UpdateStudents();
											}
											this.Pathfinding.target = this.Destinations[this.Phase];
											this.Pathfinding.speed = 1f;
											this.ReportPhase = 0;
											this.ReportTimer = 0f;
											this.AlarmTimer = 0f;
											this.WitnessedCorpse = false;
											this.WitnessedMurder = false;
											this.Reporting = false;
											this.Reacted = false;
											this.Alarmed = false;
											this.Fleeing = false;
											this.Routine = true;
											this.Halt = false;
											this.ID = 0;
											while (this.ID < this.Outlines.Length)
											{
												this.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
												this.ID++;
											}
										}
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ParanoidAnim);
								}
							}
							else if (this.Persona == PersonaType.Heroic)
							{
								if (!this.Yandere.Attacking)
								{
									if (!this.Yandere.Struggling)
									{
										this.BeginStruggle();
									}
									if (!this.Teacher)
									{
										this.CharacterAnimation[this.StruggleAnim].time = this.Yandere.CharacterAnimation["f02_struggleA_00"].time;
									}
									else
									{
										this.CharacterAnimation[this.StruggleAnim].time = this.Yandere.CharacterAnimation["f02_teacherStruggleA_00"].time;
									}
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Yandere.transform.rotation, 10f * Time.deltaTime);
									this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.425f);
									if (!this.Yandere.Armed || !this.Yandere.EquippedWeapon.Concealable)
									{
										this.Yandere.StruggleBar.HeroWins();
									}
									if (this.Lost)
									{
										this.CharacterAnimation.CrossFade(this.StruggleWonAnim);
										if (this.CharacterAnimation[this.StruggleWonAnim].time > 1f)
										{
											this.EyeShrink = 1f;
										}
										if (this.CharacterAnimation[this.StruggleWonAnim].time >= this.CharacterAnimation[this.StruggleWonAnim].length)
										{
										}
									}
									else if (this.Won)
									{
										this.CharacterAnimation.CrossFade(this.StruggleLostAnim);
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
								}
							}
							else if (this.Persona == PersonaType.Coward)
							{
								this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
								this.CharacterAnimation.CrossFade(this.CowardAnim);
								this.ReactionTimer += Time.deltaTime;
								if (this.ReactionTimer > 5f)
								{
									this.CurrentDestination = this.StudentManager.Exit;
									this.Pathfinding.target = this.StudentManager.Exit;
								}
							}
							else if (this.Persona == PersonaType.Evil)
							{
								this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
								this.CharacterAnimation.CrossFade(this.EvilAnim);
								this.ReactionTimer += Time.deltaTime;
								if (this.ReactionTimer > 5f)
								{
									this.CurrentDestination = this.StudentManager.Exit;
									this.Pathfinding.target = this.StudentManager.Exit;
								}
							}
							else if (this.Persona == PersonaType.SocialButterfly)
							{
								if (this.ReportPhase < 4)
								{
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
								}
								if (this.ReportPhase == 1)
								{
									if (!this.Phone.activeInHierarchy)
									{
										if (this.StudentManager.Reporter == null && !this.Police.Called)
										{
											this.CharacterAnimation.CrossFade(this.SocialReportAnim);
											this.Subtitle.UpdateLabel("Social Report", 1, 5f);
											this.StudentManager.Reporter = this;
											this.Phone.SetActive(true);
										}
										else
										{
											this.ReportTimer = 5f;
										}
									}
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer > 5f)
									{
										if (this.StudentManager.Reporter == this)
										{
											this.Police.Called = true;
											this.Police.Show = true;
										}
										this.CharacterAnimation.CrossFade(this.ParanoidAnim);
										this.Phone.SetActive(false);
										this.ReportPhase++;
										this.Halt = false;
									}
								}
								else if (this.ReportPhase == 2)
								{
									if (this.WitnessedMurder && (!this.SawMask || (this.SawMask && this.Yandere.Mask != null)))
									{
										this.LookForYandere();
									}
								}
								else if (this.ReportPhase == 3)
								{
									this.CharacterAnimation.CrossFade(this.SocialFearAnim);
									this.Subtitle.UpdateLabel("Social Fear", 1, 5f);
									this.SpawnAlarmDisc();
									this.ReportPhase++;
								}
								else if (this.ReportPhase == 4)
								{
									this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
									if (this.Yandere.Attacking)
									{
										this.LookForYandere();
									}
								}
								else if (this.ReportPhase == 5)
								{
									this.CharacterAnimation.CrossFade(this.SocialTerrorAnim);
									this.Subtitle.UpdateLabel("Social Terror", 1, 5f);
									this.VisionCone.farClipPlane = 0f;
									this.SpawnAlarmDisc();
									this.ReportPhase++;
								}
							}
							else if (this.Persona == PersonaType.Strict)
							{
								if (!this.WitnessedMurder)
								{
									if (this.ReportPhase == 0)
									{
										this.Subtitle.UpdateLabel("Teacher Report Reaction", 1, 3f);
										this.ReportPhase++;
									}
									else if (this.ReportPhase == 1)
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 3f)
										{
											base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
											if (this.StudentManager.CorpseLocation.position == Vector3.zero)
											{
												this.StudentManager.CorpseLocation.position = this.StudentManager.Reporter.LastKnownCorpse;
												this.StudentManager.CorpseLocation.LookAt(base.transform.position);
												this.StudentManager.CorpseLocation.Translate(this.StudentManager.CorpseLocation.forward);
												this.StudentManager.LowerCorpsePostion();
											}
											if (!this.StudentManager.Reporter.Teacher)
											{
												this.StudentManager.Reporter.Pathfinding.target = this.StudentManager.CorpseLocation;
											}
											this.Pathfinding.target = this.StudentManager.CorpseLocation;
											this.StudentManager.Reporter.TargetDistance = 2f;
											this.TargetDistance = 1f;
											this.ReportTimer = 0f;
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase == 2)
									{
										if (this.WitnessedCorpse)
										{
											if (!this.Corpse.Poisoned)
											{
												this.Subtitle.UpdateLabel("Teacher Corpse Inspection", 1, 5f);
											}
											else
											{
												this.Subtitle.UpdateLabel("Teacher Corpse Inspection", 2, 2f);
											}
											this.ReportPhase++;
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
											this.ReportTimer += Time.deltaTime;
											if (this.ReportTimer > 5f)
											{
												this.Subtitle.UpdateLabel("Teacher Prank Reaction", 1, 7f);
												this.ReportPhase = 98;
												this.ReportTimer = 0f;
											}
										}
									}
									else if (this.ReportPhase == 3)
									{
										this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
										this.CharacterAnimation.CrossFade(this.InspectAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 6f)
										{
											this.ReportTimer = 0f;
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase == 4)
									{
										this.Subtitle.UpdateLabel("Teacher Police Report", 1, 5f);
										this.Phone.SetActive(true);
										this.ReportPhase++;
									}
									else if ((float)this.ReportPhase == 5f)
									{
										this.CharacterAnimation.CrossFade(this.CallAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 5f)
										{
											this.CharacterAnimation.CrossFade(this.GuardAnim);
											this.Phone.SetActive(false);
											this.Police.Called = true;
											this.Police.Show = true;
											this.ReportTimer = 0f;
											this.Guarding = true;
											this.Fleeing = false;
											this.Reacted = false;
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase == 98)
									{
										this.targetRotation = Quaternion.LookRotation(this.MyReporter.transform.position - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer > 7f)
										{
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase == 99)
									{
										this.Subtitle.UpdateLabel("Prank Reaction", 1, 5f);
										this.StudentManager.Reporter.ReportPhase = 100;
										this.Pathfinding.target = this.Destinations[this.Phase];
										this.ReportTimer = 0f;
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
									if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus == 0)
									{
										Debug.Log("A teacher is taking down Yandere-chan.");
										if (this.Yandere.Aiming)
										{
											this.Yandere.StopAiming();
										}
										this.Yandere.Mopping = false;
										this.Yandere.EmptyHands();
										this.AttackReaction();
										this.CharacterAnimation[this.CounterAnim].time = 5f;
										this.Yandere.CharacterAnimation["f02_counterA_00"].time = 5f;
										this.Yandere.ShoulderCamera.DoNotMove = true;
										this.Yandere.ShoulderCamera.Timer = 5f;
										this.Yandere.ShoulderCamera.Phase = 3;
										this.Police.Show = false;
										this.Yandere.CameraEffects.MurderWitnessed();
										this.Yandere.Jukebox.GameOver();
									}
									else
									{
										this.Persona = PersonaType.Heroic;
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
								}
							}
						}
					}
				}
				else if (this.PinPhase == 0)
				{
					if (this.DistanceToDestination < 1f)
					{
						if (this.Pathfinding.canSearch)
						{
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
						}
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
						this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
						this.MoveTowardsTarget(this.CurrentDestination.position);
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.SprintAnim);
						if (!this.Pathfinding.canSearch)
						{
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
						}
					}
				}
				else
				{
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
					this.MoveTowardsTarget(this.CurrentDestination.position);
				}
			}
			if (this.Following && !this.Waiting)
			{
				this.DistanceToDestination = Vector3.Distance(base.transform.position, this.Pathfinding.target.position);
				if (this.DistanceToDestination > 2f)
				{
					this.CharacterAnimation.CrossFade(this.RunAnim);
					this.Pathfinding.speed = 4f;
					this.Obstacle.enabled = false;
				}
				else if (this.DistanceToDestination > 1f)
				{
					this.CharacterAnimation.CrossFade(this.WalkAnim);
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = 1f;
					this.Obstacle.enabled = false;
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.Pathfinding.canMove = false;
					this.Obstacle.enabled = true;
				}
				if (this.Phase < this.ScheduleBlocks.Length - 1 && this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time)
				{
					this.Phase++;
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.Hearts.emission.enabled = false;
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = 1f;
					this.Yandere.Followers--;
					this.Following = false;
					this.Routine = true;
					this.Subtitle.UpdateLabel("Stop Follow Apology", 0, 3f);
					this.Prompt.Label[0].text = "     Talk";
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
								this.Pathfinding.speed = 1f;
								this.Schoolwear = 0;
								this.BathePhase++;
							}
							else if (this.BathePhase == 2)
							{
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
								this.MoveTowardsTarget(this.CurrentDestination.position);
							}
							else if (this.BathePhase == 3)
							{
								this.StudentManager.CommunalLocker.Open = false;
								this.CharacterAnimation.CrossFade(this.WalkAnim);
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
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
								this.MoveTowardsTarget(this.CurrentDestination.position);
								if (!this.BatheFast)
								{
									this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
									this.CharacterAnimation.CrossFade("f02_bathEnter_00");
									if (this.CharacterAnimation["f02_bathEnter_00"].time >= this.CharacterAnimation["f02_bathEnter_00"].length)
									{
										this.CharacterAnimation.CrossFade("f02_bathIdle_00");
										this.BathePhase++;
									}
									this.Pathfinding.canSearch = false;
									this.Pathfinding.canMove = false;
									this.MyController.radius = 0f;
									this.Distracted = true;
								}
								else
								{
									this.CharacterAnimation.CrossFade("f02_stoolBathing_00");
									if (this.CharacterAnimation["f02_stoolBathing_00"].time >= this.CharacterAnimation["f02_stoolBathing_00"].length)
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
								if (this.CharacterAnimation["f02_bathIdle_00"].time >= this.CharacterAnimation["f02_bathIdle_00"].length)
								{
									this.CharacterAnimation.CrossFade("f02_bathExit_00");
									this.LiquidProjector.enabled = false;
									this.Bloody = false;
									this.BathePhase++;
									this.UnWet();
								}
							}
							else if (this.BathePhase == 6)
							{
								if (this.CharacterAnimation["f02_bathExit_00"].time >= this.CharacterAnimation["f02_bathExit_00"].length)
								{
									this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
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
								this.Schoolwear = ((!this.InEvent) ? 3 : 1);
								this.BathePhase++;
							}
							else if (this.BathePhase == 8)
							{
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
								this.MoveTowardsTarget(this.CurrentDestination.position);
							}
							else if (this.BathePhase == 9)
							{
								if (this.StudentID == this.StudentManager.RivalID)
								{
									if (this.StudentManager.CommunalLocker.RivalPhone.Stolen)
									{
										this.CharacterAnimation.CrossFade("f02_losingPhone_00");
										this.Subtitle.UpdateLabel(this.RivalPrefix + "Lost Phone", 1, 5f);
										this.RealizePhoneIsMissing();
										this.BatheTimer = 6f;
										this.BathePhase++;
									}
									else
									{
										Debug.Log("Turning it off here?");
										this.StudentManager.CommunalLocker.RivalPhone.gameObject.SetActive(false);
										this.BathePhase++;
									}
								}
								else
								{
									this.BathePhase += 2;
								}
							}
							else if (this.BathePhase == 10)
							{
								if (this.BatheTimer == 0f)
								{
									this.BathePhase++;
								}
								else
								{
									this.BatheTimer = Mathf.MoveTowards(this.BatheTimer, 0f, Time.deltaTime);
								}
							}
							else if (this.BathePhase == 11)
							{
								this.StudentManager.CommunalLocker.Open = false;
								if (this.Phase == 1)
								{
									this.Phase++;
								}
								this.CurrentDestination = this.Destinations[this.Phase];
								this.Pathfinding.target = this.Destinations[this.Phase];
								this.Pathfinding.canSearch = true;
								this.Pathfinding.canMove = true;
								this.DistanceToDestination = 100f;
								this.Routine = true;
								this.Wet = false;
								if (this.FleeWhenClean)
								{
									this.CurrentDestination = this.StudentManager.Exit;
									this.Pathfinding.target = this.StudentManager.Exit;
									this.TargetDistance = 0f;
									this.Routine = false;
									this.Fleeing = true;
								}
							}
						}
						else if (this.BathePhase == -1)
						{
							this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
							this.Subtitle.UpdateLabel("Light Switch Reaction", 2, 5f);
							this.CharacterAnimation.CrossFade("f02_electrocution_00");
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.Distracted = true;
							this.BathePhase++;
						}
						else if (this.BathePhase == 0)
						{
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
							this.MoveTowardsTarget(this.CurrentDestination.position);
							if (this.CharacterAnimation["f02_electrocution_00"].time > 2f && this.CharacterAnimation["f02_electrocution_00"].time < 5.95000029f)
							{
								if (!this.LightSwitch.Panel.useGravity)
								{
									if (!this.Bloody)
									{
										this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 2, 5f);
									}
									else
									{
										this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 4, 5f);
									}
									this.CurrentDestination = this.StudentManager.StripSpot;
									this.Pathfinding.target = this.StudentManager.StripSpot;
									this.Pathfinding.canSearch = true;
									this.Pathfinding.canMove = true;
									this.Pathfinding.speed = 4f;
									this.CharacterAnimation.CrossFade(this.WalkAnim);
									this.BathePhase++;
									this.LightSwitch.Prompt.Label[0].text = "     Turn Off";
									this.LightSwitch.BathroomLight.SetActive(true);
									this.LightSwitch.GetComponent<AudioSource>().clip = this.LightSwitch.Flick[0];
									this.LightSwitch.GetComponent<AudioSource>().Play();
									this.InDarkness = false;
								}
								else
								{
									if (!this.LightSwitch.Flicker)
									{
										this.CharacterAnimation["f02_electrocution_00"].speed = 0.85f;
										GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LightSwitch.Electricity, base.transform.position, Quaternion.identity);
										gameObject.transform.parent = this.Bones[1].transform;
										gameObject.transform.localPosition = Vector3.zero;
										this.Subtitle.UpdateLabel("Light Switch Reaction", 3, 0f);
										this.LightSwitch.GetComponent<AudioSource>().clip = this.LightSwitch.Flick[2];
										this.LightSwitch.Flicker = true;
										this.LightSwitch.GetComponent<AudioSource>().Play();
										this.EyeShrink = 1f;
										this.ElectroSteam[0].SetActive(true);
										this.ElectroSteam[1].SetActive(true);
										this.ElectroSteam[2].SetActive(true);
										this.ElectroSteam[3].SetActive(true);
									}
									this.RightDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
									this.LeftDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
									this.ElectroTimer += Time.deltaTime;
									if (this.ElectroTimer > 0.1f)
									{
										this.ElectroTimer = 0f;
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
							else if (this.CharacterAnimation["f02_electrocution_00"].time > 5.95000029f && this.CharacterAnimation["f02_electrocution_00"].time < this.CharacterAnimation["f02_electrocution_00"].length)
							{
								if (this.LightSwitch.Flicker)
								{
									this.CharacterAnimation["f02_electrocution_00"].speed = 1f;
									this.Prompt.Label[0].text = "     Turn Off";
									this.LightSwitch.BathroomLight.SetActive(true);
									this.RightDrill.localEulerAngles = new Vector3(0f, 0f, 68.30447f);
									this.LeftDrill.localEulerAngles = new Vector3(0f, -180f, -159.417f);
									this.LightSwitch.Flicker = false;
									this.Unspook();
									this.UnWet();
								}
							}
							else if (this.CharacterAnimation["f02_electrocution_00"].time >= this.CharacterAnimation["f02_electrocution_00"].length)
							{
								this.Police.ElectrocutedStudentName = this.Name;
								this.Police.ElectroScene = true;
								this.Electrocuted = true;
								this.BecomeRagdoll();
								this.DeathType = DeathType.Electrocution;
							}
						}
					}
				}
				else if (this.Pathfinding.canMove)
				{
					if (this.BathePhase == 1 || this.FleeWhenClean)
					{
						this.CharacterAnimation.CrossFade(this.SprintAnim);
						this.Pathfinding.speed = 4f;
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.Pathfinding.speed = 1f;
					}
				}
			}
			if (this.Distracting)
			{
				if (this.DistractionTarget.Dying)
				{
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.DistractionTarget.TargetedForDistraction = false;
					this.DistractionTarget.Pathfinding.canSearch = true;
					this.DistractionTarget.Pathfinding.canMove = true;
					this.DistractionTarget.Pathfinding.speed = 1f;
					this.DistractionTarget.Distraction = null;
					this.DistractionTarget.Distracted = false;
					this.DistractionTarget.CanTalk = true;
					this.DistractionTarget.Routine = true;
					this.Pathfinding.speed = 1f;
					this.Distracting = false;
					this.Distracted = false;
					this.CanTalk = true;
					this.Routine = true;
				}
				else if (this.DistractionTarget.InEvent || this.DistractionTarget.Talking || this.DistractionTarget.Following || this.DistractionTarget.TurnOffRadio || this.DistractionTarget.Splashed)
				{
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.DistractionTarget.TargetedForDistraction = false;
					this.Pathfinding.speed = 1f;
					this.Distracting = false;
					this.Distracted = false;
					this.CanTalk = true;
					this.Routine = true;
				}
				else if (this.DistanceToDestination < this.TargetDistance)
				{
					if (!this.DistractionTarget.Distracted)
					{
						this.DistractionTarget.Pathfinding.canSearch = false;
						this.DistractionTarget.Pathfinding.canMove = false;
						this.DistractionTarget.OccultBook.SetActive(false);
						this.DistractionTarget.Distraction = base.transform;
						this.DistractionTarget.CameraReacting = false;
						this.DistractionTarget.Pathfinding.speed = 0f;
						this.DistractionTarget.Pen.SetActive(false);
						this.DistractionTarget.Distracted = true;
						this.DistractionTarget.Routine = false;
						this.DistractionTarget.CanTalk = false;
						this.DistractionTarget.ReadPhase = 0;
						this.DistractionTarget.SpeechLines.Play();
						this.SpeechLines.Play();
						this.Pathfinding.speed = 0f;
						this.Distracted = true;
					}
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.DistractionTarget.transform.position.x, base.transform.position.y, this.DistractionTarget.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.CharacterAnimation.CrossFade(this.RandomAnim);
					if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
					{
						this.PickRandomAnim();
					}
					this.DistractTimer -= Time.deltaTime;
					if (this.DistractTimer <= 0f)
					{
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
						this.DistractionTarget.TargetedForDistraction = false;
						this.DistractionTarget.Pathfinding.canSearch = true;
						this.DistractionTarget.Pathfinding.canMove = true;
						this.DistractionTarget.Pathfinding.speed = 1f;
						this.DistractionTarget.Distraction = null;
						this.DistractionTarget.Distracted = false;
						this.DistractionTarget.CanTalk = true;
						this.DistractionTarget.Routine = true;
						this.DistractionTarget.SpeechLines.Stop();
						this.SpeechLines.Stop();
						this.Pathfinding.speed = 1f;
						this.Distracting = false;
						this.Distracted = false;
						this.CanTalk = true;
						this.Routine = true;
					}
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.RunAnim);
				}
			}
			if (this.Hunting)
			{
				StudentScript studentScript = this.StudentManager.Students[7];
				if (studentScript != null)
				{
					if (studentScript.Prompt.enabled)
					{
						studentScript.Prompt.Hide();
						studentScript.Prompt.enabled = false;
					}
					this.Pathfinding.target = studentScript.transform;
					this.CurrentDestination = studentScript.transform;
					if (studentScript.Alive && !studentScript.Tranquil)
					{
						if (this.DistanceToDestination > this.TargetDistance)
						{
							if (this.MurderSuicidePhase == 0)
							{
								if (this.CharacterAnimation["f02_brokenStandUp_00"].time >= this.CharacterAnimation["f02_brokenStandUp_00"].length)
								{
									this.MurderSuicidePhase++;
									this.Pathfinding.canSearch = true;
									this.Pathfinding.canMove = true;
									this.CharacterAnimation.CrossFade(this.WalkAnim);
									this.Pathfinding.speed = 1f;
								}
							}
							else if (this.MurderSuicidePhase > 1)
							{
								studentScript.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.01f);
							}
						}
						else if (!this.NEStairs.bounds.Contains(base.transform.position) && !this.NWStairs.bounds.Contains(base.transform.position) && !this.SEStairs.bounds.Contains(base.transform.position) && !this.SWStairs.bounds.Contains(base.transform.position))
						{
							if (!this.NEStairs.bounds.Contains(studentScript.transform.position) && !this.NWStairs.bounds.Contains(studentScript.transform.position) && !this.SEStairs.bounds.Contains(studentScript.transform.position) && !this.SWStairs.bounds.Contains(studentScript.transform.position))
							{
								if (this.Pathfinding.canMove)
								{
									this.CharacterAnimation.CrossFade("f02_murderSuicide_00");
									this.Pathfinding.canSearch = false;
									this.Pathfinding.canMove = false;
									this.Broken.Subtitle.text = string.Empty;
									this.MyController.radius = 0f;
									this.Broken.Done = true;
									AudioSource.PlayClipAtPoint(this.MurderSuicideSounds, base.transform.position + new Vector3(0f, 1f, 0f));
									AudioSource component = base.GetComponent<AudioSource>();
									component.clip = this.MurderSuicideKiller;
									component.Play();
									studentScript.DetectionMarker.Tex.enabled = false;
									studentScript.TargetedForDistraction = false;
									studentScript.Pathfinding.canSearch = false;
									studentScript.Pathfinding.canMove = false;
									studentScript.WitnessCamera.Show = false;
									studentScript.CameraReacting = false;
									studentScript.Investigating = false;
									studentScript.Distracting = false;
									studentScript.Splashed = false;
									studentScript.Alarmed = false;
									studentScript.Burning = false;
									studentScript.Fleeing = false;
									studentScript.Routine = false;
									studentScript.Wet = false;
									studentScript.Prompt.Hide();
									studentScript.Prompt.enabled = false;
									studentScript.CharacterAnimation.CrossFade("f02_murderSuicide_01");
									studentScript.Subtitle.UpdateLabel("Dying", 0, 1f);
									studentScript.MyController.radius = 0f;
									studentScript.SpeechLines.Stop();
									studentScript.EyeShrink = 1f;
									studentScript.GetComponent<AudioSource>().clip = this.MurderSuicideVictim;
									studentScript.GetComponent<AudioSource>().Play();
									this.Police.CorpseList[this.Police.Corpses] = studentScript.Ragdoll;
									this.Police.Corpses++;
									studentScript.SetLayerRecursively(studentScript.gameObject, 11);
									studentScript.tag = "Blood";
									studentScript.Ragdoll.Disturbing = true;
									studentScript.Dying = true;
									studentScript.SpawnAlarmDisc();
									if (studentScript.Following)
									{
										this.Yandere.Followers--;
										this.Hearts.emission.enabled = false;
										studentScript.Following = false;
									}
									this.OriginalYPosition = studentScript.transform.position.y;
								}
								else
								{
									if (this.MurderSuicidePhase > 0)
									{
										studentScript.targetRotation = Quaternion.LookRotation(studentScript.transform.position - base.transform.position);
										studentScript.transform.rotation = Quaternion.Slerp(studentScript.transform.rotation, studentScript.targetRotation, Time.deltaTime * 10f);
										studentScript.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.01f);
										studentScript.transform.position = new Vector3(studentScript.transform.position.x, this.OriginalYPosition, studentScript.transform.position.z);
										this.targetRotation = Quaternion.LookRotation(studentScript.transform.position - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
									}
									if (this.MurderSuicidePhase == 1)
									{
										if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 2.4f)
										{
											this.MyWeapon.transform.parent = this.ItemParent;
											this.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
											this.MyWeapon.transform.localPosition = Vector3.zero;
											this.MyWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
											this.MurderSuicidePhase++;
										}
									}
									else if (this.MurderSuicidePhase == 2)
									{
										if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 3.3f)
										{
											GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.Ragdoll.BloodPoolSpawner.BloodPool, base.transform.position + base.transform.up * 0.012f + base.transform.forward, Quaternion.identity);
											gameObject2.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
											gameObject2.transform.parent = this.Police.BloodParent;
											this.MyWeapon.Victims[7] = true;
											this.MyWeapon.Blood.enabled = true;
											if (!this.MyWeapon.Evidence)
											{
												this.MyWeapon.Evidence = true;
												this.Police.MurderWeapons++;
											}
											UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
											this.KnifeDown = true;
											this.MurderSuicidePhase++;
										}
									}
									else if (this.MurderSuicidePhase == 3)
									{
										if (!this.KnifeDown)
										{
											if (this.MyWeapon.transform.position.y < base.transform.position.y + 0.333333343f)
											{
												UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
												this.KnifeDown = true;
												Debug.Log("Stab!");
											}
										}
										else if (this.MyWeapon.transform.position.y > base.transform.position.y + 0.333333343f)
										{
											this.KnifeDown = false;
										}
										if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 16.666666f)
										{
											Debug.Log("Released knife!");
											this.MyWeapon.transform.parent = null;
											this.MurderSuicidePhase++;
										}
									}
									else if (this.MurderSuicidePhase == 4)
									{
										if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 18.9f)
										{
											Debug.Log("Yanked out knife!");
											UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
											this.MyWeapon.transform.parent = this.ItemParent;
											this.MyWeapon.transform.localPosition = Vector3.zero;
											this.MyWeapon.transform.localEulerAngles = Vector3.zero;
											this.MurderSuicidePhase++;
										}
									}
									else if (this.MurderSuicidePhase == 5)
									{
										if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 26.166666f)
										{
											Debug.Log("Stabbed neck!");
											UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
											this.MyWeapon.Victims[this.StudentID] = true;
											this.MurderSuicidePhase++;
										}
									}
									else if (this.MurderSuicidePhase == 6)
									{
										if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 30.5f)
										{
											Debug.Log("BLOOD FOUNTAIN!");
											this.BloodFountain.Play();
											this.MurderSuicidePhase++;
										}
									}
									else if (this.MurderSuicidePhase == 7)
									{
										if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 31.5f)
										{
											this.BloodSprayCollider.SetActive(true);
											this.MurderSuicidePhase++;
										}
									}
									else if (this.CharacterAnimation["f02_murderSuicide_00"].time >= this.CharacterAnimation["f02_murderSuicide_00"].length)
									{
										this.MyWeapon.transform.parent = null;
										this.MyWeapon.Drop();
										this.MyWeapon = null;
										this.StudentManager.StopHesitating();
										studentScript.BecomeRagdoll();
										studentScript.Ragdoll.MurderSuicide = true;
										studentScript.DeathType = DeathType.Weapon;
										if (this.BloodSprayCollider != null)
										{
											this.BloodSprayCollider.SetActive(false);
										}
										this.BecomeRagdoll();
										this.DeathType = DeathType.Weapon;
										this.Police.MurderSuicideScene = true;
										this.Ragdoll.MurderSuicide = true;
										this.MurderSuicide = true;
									}
								}
							}
						}
					}
					else
					{
						this.Hunting = false;
						this.Suicide = true;
					}
				}
				else
				{
					this.Hunting = false;
					this.Suicide = true;
				}
			}
			if (this.Suicide)
			{
				if (this.MurderSuicidePhase == 0)
				{
					if (this.CharacterAnimation["f02_brokenStandUp_00"].time >= this.CharacterAnimation["f02_brokenStandUp_00"].length)
					{
						this.MurderSuicidePhase++;
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Pathfinding.speed = 0f;
						this.CharacterAnimation.CrossFade("f02_suicide_00");
					}
				}
				else if (this.MurderSuicidePhase == 1)
				{
					if (this.Pathfinding.speed > 0f)
					{
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Pathfinding.speed = 0f;
						this.CharacterAnimation.CrossFade("f02_suicide_00");
					}
					if (this.CharacterAnimation["f02_suicide_00"].time >= 0.733333349f)
					{
						this.MyWeapon.transform.parent = this.ItemParent;
						this.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
						this.MyWeapon.transform.localPosition = Vector3.zero;
						this.MyWeapon.transform.localEulerAngles = Vector3.zero;
						this.Broken.Subtitle.text = string.Empty;
						this.Broken.Done = true;
						this.MurderSuicidePhase++;
					}
				}
				else if (this.MurderSuicidePhase == 2)
				{
					if (this.CharacterAnimation["f02_suicide_00"].time >= 4.16666651f)
					{
						Debug.Log("Stabbed neck!");
						UnityEngine.Object.Instantiate<GameObject>(this.StabBloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
						this.MyWeapon.Victims[this.StudentID] = true;
						this.MyWeapon.Blood.enabled = true;
						if (!this.MyWeapon.Evidence)
						{
							this.MyWeapon.Evidence = true;
							this.Police.MurderWeapons++;
						}
						this.MurderSuicidePhase++;
					}
				}
				else if (this.MurderSuicidePhase == 3)
				{
					if (this.CharacterAnimation["f02_suicide_00"].time >= 6.16666651f)
					{
						Debug.Log("BLOOD FOUNTAIN!");
						this.BloodFountain.gameObject.GetComponent<AudioSource>().Play();
						this.BloodFountain.Play();
						this.MurderSuicidePhase++;
					}
				}
				else if (this.MurderSuicidePhase == 4)
				{
					if (this.CharacterAnimation["f02_suicide_00"].time >= 7f)
					{
						this.Ragdoll.BloodPoolSpawner.SpawnPool(base.transform);
						this.BloodSprayCollider.SetActive(true);
						this.MurderSuicidePhase++;
					}
				}
				else if (this.MurderSuicidePhase == 5 && this.CharacterAnimation["f02_suicide_00"].time >= this.CharacterAnimation["f02_suicide_00"].length)
				{
					this.MyWeapon.transform.parent = null;
					this.MyWeapon.Drop();
					this.MyWeapon = null;
					this.StudentManager.StopHesitating();
					if (this.BloodSprayCollider != null)
					{
						this.BloodSprayCollider.SetActive(false);
					}
					this.BecomeRagdoll();
					this.DeathType = DeathType.Weapon;
				}
			}
			if (this.CameraReacting)
			{
				this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				if (!this.Yandere.ClubAccessories[7].activeInHierarchy)
				{
					if (this.CameraReactPhase == 1)
					{
						if (this.CharacterAnimation[this.CameraAnims[1]].time >= this.CharacterAnimation[this.CameraAnims[1]].length)
						{
							this.CharacterAnimation.CrossFade(this.CameraAnims[2]);
							this.CameraReactPhase = 2;
							this.CameraPoseTimer = 1f;
						}
					}
					else if (this.CameraReactPhase == 2)
					{
						this.CameraPoseTimer -= Time.deltaTime;
						if (this.CameraPoseTimer <= 0f)
						{
							this.CharacterAnimation.CrossFade(this.CameraAnims[3]);
							this.CameraReactPhase = 3;
						}
					}
					else if (this.CameraReactPhase == 3)
					{
						if (this.CameraPoseTimer == 1f)
						{
							this.CharacterAnimation.CrossFade(this.CameraAnims[2]);
							this.CameraReactPhase = 2;
						}
						if (this.CharacterAnimation[this.CameraAnims[3]].time >= this.CharacterAnimation[this.CameraAnims[3]].length)
						{
							this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
							this.Obstacle.enabled = false;
							this.CameraReacting = false;
							this.Routine = true;
							this.ReadPhase = 0;
						}
					}
				}
				else if (this.Yandere.Shutter.TargetStudent != this.StudentID)
				{
					this.CameraPoseTimer -= Time.deltaTime;
					if (this.CameraPoseTimer <= 0f)
					{
						this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
						this.Obstacle.enabled = false;
						this.CameraReacting = false;
						this.Routine = true;
						this.ReadPhase = 0;
					}
				}
				else
				{
					this.CameraPoseTimer = 1f;
				}
				if (this.InEvent)
				{
					this.CameraReacting = false;
					this.ReadPhase = 0;
				}
			}
			if (this.Investigating)
			{
				if (!this.YandereInnocent && this.InvestigationPhase < 100)
				{
					this.Planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
					RaycastHit raycastHit;
					if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.GetComponent<Collider>().bounds) && Physics.Linecast(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), out raycastHit) && raycastHit.collider.gameObject == this.Yandere.gameObject)
					{
						if (Vector3.Distance(this.Yandere.transform.position, this.Giggle.transform.position) > 2.5f)
						{
							this.YandereInnocent = true;
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.InvestigationPhase = 100;
							this.InvestigationTimer = 0f;
						}
					}
				}
				if (this.InvestigationPhase == 0)
				{
					if (this.InvestigationTimer < 5f)
					{
						this.InvestigationTimer += Time.deltaTime;
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Giggle.transform.position.x, base.transform.position.y, this.Giggle.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Pathfinding.target = this.Giggle.transform;
						this.CurrentDestination = this.Giggle.transform;
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Pathfinding.speed = 1f;
						this.InvestigationPhase++;
					}
				}
				else if (this.InvestigationPhase == 1)
				{
					if (this.DistanceToDestination > 1f)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
					}
					else if (this.InvestigationPhase == 1)
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.InvestigationPhase++;
					}
				}
				else if (this.InvestigationPhase == 2)
				{
					this.InvestigationTimer += Time.deltaTime;
					if (this.InvestigationTimer > 10f)
					{
						this.StopInvestigating();
					}
				}
				else if (this.InvestigationPhase == 100)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.InvestigationTimer += Time.deltaTime;
					if (this.InvestigationTimer > 2f)
					{
						this.StopInvestigating();
					}
				}
			}
			if (this.EndSearch)
			{
				this.MoveTowardsTarget(this.Pathfinding.target.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
				this.PatrolTimer += Time.deltaTime;
				if (this.PatrolTimer > 5f)
				{
					this.StudentManager.CommunalLocker.RivalPhone.gameObject.SetActive(false);
					ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
					scheduleBlock.destination = "Hangout";
					scheduleBlock.action = "Hangout";
					this.GetDestinations();
					ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
					scheduleBlock2.destination = "Hangout";
					scheduleBlock2.action = "Hangout";
					this.GetDestinations();
					ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[6];
					scheduleBlock3.destination = "Hangout";
					scheduleBlock3.action = "Hangout";
					this.GetDestinations();
					this.Actions[2] = StudentActionType.AtLocker;
					this.Actions[4] = StudentActionType.AtLocker;
					this.Actions[6] = StudentActionType.AtLocker;
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.DistanceToDestination = 100f;
					this.LewdPhotos = this.StudentManager.CommunalLocker.RivalPhone.LewdPhotos;
					this.EndSearch = false;
					this.Phoneless = false;
					this.Routine = true;
				}
			}
		}
	}

	private void UpdateVision()
	{
		if (!this.Dying)
		{
			if (!this.Distracted)
			{
				if (!this.WitnessedMurder && !this.CheckingNote)
				{
					int num = 0;
					this.ID = 0;
					while (this.ID < this.Police.Corpses)
					{
						if (this.Police.CorpseList[this.ID] != null && !this.Police.CorpseList[this.ID].Hidden)
						{
							this.Planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
							if (GeometryUtility.TestPlanesAABB(this.Planes, this.Police.CorpseList[this.ID].AllColliders[0].bounds))
							{
								Debug.DrawLine(this.Eyes.transform.position, this.Police.CorpseList[this.ID].AllColliders[0].transform.position, Color.green);
								RaycastHit raycastHit;
								if (Physics.Linecast(this.Eyes.transform.position, this.Police.CorpseList[this.ID].AllColliders[0].transform.position, out raycastHit, this.Mask) && (raycastHit.collider.gameObject.layer == 11 || raycastHit.collider.gameObject.layer == 14))
								{
									num++;
									this.Corpse = this.Police.CorpseList[this.ID];
									if (this.Persona == PersonaType.TeachersPet && this.StudentManager.Reporter == null && !this.Police.Called)
									{
										this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
										this.StudentManager.CorpseLocation.LookAt(base.transform.position);
										this.StudentManager.CorpseLocation.Translate(this.StudentManager.CorpseLocation.forward);
										this.StudentManager.LowerCorpsePostion();
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
							if (!this.Male)
							{
								this.CharacterAnimation["f02_smile_00"].weight = 0f;
							}
							this.AlarmTimer = 0f;
							this.Alarm = 200f;
							this.LastKnownCorpse = this.Corpse.AllColliders[0].transform.position;
							this.WitnessedCorpse = true;
							this.Investigating = false;
							this.ForgetRadio();
							if (this.Wet)
							{
								this.Persona = PersonaType.Loner;
							}
							if (this.Corpse.Burning)
							{
								this.WalkBackTimer = 5f;
								this.WalkBack = true;
								this.Hesitation = 0.5f;
							}
							if (this.Corpse.Disturbing)
							{
								this.WalkBackTimer = 5f;
								this.WalkBack = true;
								this.Hesitation = 1f;
							}
							this.StudentManager.UpdateMe(this.StudentID);
							if (!this.Teacher)
							{
								this.SpawnAlarmDisc();
							}
							else
							{
								this.AlarmTimer = 3f;
							}
							ParticleSystem.EmissionModule emission = this.Hearts.emission;
							if (this.Talking)
							{
								this.DialogueWheel.End();
								emission.enabled = false;
								this.Pathfinding.canSearch = true;
								this.Pathfinding.canMove = true;
								this.Obstacle.enabled = false;
								this.Talking = false;
								this.Waiting = false;
								this.StudentManager.EnablePrompts();
							}
							if (this.Following)
							{
								emission.enabled = false;
								this.Yandere.Followers--;
								this.Following = false;
							}
						}
						if (this.Corpse.Dragged || this.Corpse.Dumped)
						{
							if (this.Teacher)
							{
								this.Subtitle.UpdateLabel("Teacher Murder Reaction", UnityEngine.Random.Range(1, 3), 3f);
								this.StudentManager.Portal.SetActive(false);
							}
							if (!this.Yandere.Egg)
							{
								this.WitnessMurder();
							}
						}
					}
					this.PreviousAlarm = this.Alarm;
					if (this.DistanceToPlayer < this.VisionCone.farClipPlane)
					{
						if (!this.Talking)
						{
							if (!this.Yandere.Noticed)
							{
								if (!this.Yandere.Chased)
								{
									if ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious) || (this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) || (this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Dragging || this.Yandere.Lewd || this.Yandere.Carrying || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null)) || (this.Yandere.Laughing && this.Yandere.LaughIntensity > 15f) || (this.Private && this.Yandere.Trespassing) || (this.Teacher && this.Yandere.Trespassing) || (this.Teacher && this.Yandere.Rummaging) || (this.StudentID == 1 && this.Yandere.NearSenpai && !this.Yandere.Talking) || (this.StudentID == 1 && this.Yandere.Eavesdropping) || (this.StudentID == 33 && this.Yandere.Eavesdropping))
									{
										this.Planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
										if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.GetComponent<Collider>().bounds))
										{
											Debug.DrawLine(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), Color.green);
											RaycastHit raycastHit2;
											if (Physics.Linecast(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), out raycastHit2))
											{
												if (raycastHit2.collider.gameObject == this.Yandere.gameObject)
												{
													this.YandereVisible = true;
													if (this.Yandere.Attacking || this.Yandere.Struggling || (this.Yandere.NearBodies > 0 && this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) || (this.Yandere.NearBodies > 0 && this.Yandere.Armed) || (this.Yandere.NearBodies > 0 && this.Yandere.Sanity < 66.66666f) || this.Yandere.Carrying || this.Yandere.Dragging)
													{
														if (!this.Yandere.Egg)
														{
															this.WitnessMurder();
														}
													}
													else if (!this.Fleeing)
													{
														if (!this.Alarmed)
														{
															if (this.Teacher && this.Yandere.Rummaging)
															{
																this.Alarm = 200f;
															}
															if (this.IgnoreTimer <= 0f)
															{
																this.Alarm += Time.deltaTime * (100f / this.DistanceToPlayer) * this.Paranoia * this.Perception;
																if (this.StudentID == 1 && this.Yandere.TimeSkipping)
																{
																	this.Clock.EndTimeSkip();
																}
															}
														}
													}
													else
													{
														this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
													}
												}
												else
												{
													this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
												}
											}
										}
										else
										{
											this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
										}
									}
									else
									{
										this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
									}
								}
								else
								{
									this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
								}
							}
							else
							{
								this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
							}
						}
						else
						{
							this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
						}
					}
					else
					{
						this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
					}
					if (this.PreviousAlarm > this.Alarm && this.Alarm < 100f)
					{
						this.YandereVisible = false;
					}
					if (this.Teacher && this.Yandere.Egg)
					{
						this.Alarm = 0f;
					}
					if (this.Alarm > 100f && (!this.Alarmed || this.DiscCheck))
					{
						this.Yandere.Alerts++;
						if (this.StudentID > 1)
						{
							this.ID = 0;
							while (this.ID < this.Outlines.Length)
							{
								this.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
								this.ID++;
							}
						}
						if (this.DistractionTarget != null)
						{
							this.DistractionTarget.TargetedForDistraction = false;
						}
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.CameraReacting = false;
						this.Distracting = false;
						this.Distracted = false;
						this.DiscCheck = false;
						this.Routine = false;
						this.Alarmed = true;
						this.Witness = true;
						this.ReadPhase = 0;
						string witnessed = this.Witnessed;
						bool flag = false;
						if (this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious)
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
							if (this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Carrying || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart))
							{
								if (!this.Yandere.Egg)
								{
									this.WitnessMurder();
								}
							}
							else
							{
								this.WitnessedBlood = false;
								if (this.Yandere.Bloodiness > 0f && !this.Yandere.Paint)
								{
									this.WitnessedBlood = true;
								}
								if (this.Yandere.Rummaging)
								{
									this.Witnessed = "Theft";
									this.Concern = 5;
								}
								else if (this.Yandere.Pickpocketing)
								{
									Debug.Log("Saw Yandere-chan pickpocketing.");
									this.Yandere.Pickpocketing = false;
									this.Witnessed = "Pickpocketing";
									this.Concern = 5;
								}
								else if (flag && this.WitnessedBlood && this.Yandere.Sanity < 33.333f)
								{
									this.Witnessed = "Weapon and Blood and Insanity";
									this.RepLoss = 30f;
									this.Concern = 5;
								}
								else if (flag && this.Yandere.Sanity < 33.333f)
								{
									this.Witnessed = "Weapon and Insanity";
									this.RepLoss = 20f;
									this.Concern = 5;
								}
								else if (this.WitnessedBlood && this.Yandere.Sanity < 33.333f)
								{
									this.Witnessed = "Blood and Insanity";
									this.RepLoss = 20f;
									this.Concern = 5;
								}
								else if (flag && this.WitnessedBlood)
								{
									this.Witnessed = "Weapon and Blood";
									this.RepLoss = 20f;
									this.Concern = 5;
								}
								else if (flag)
								{
									this.WeaponWitnessed = this.Yandere.EquippedWeapon.WeaponID;
									this.Witnessed = "Weapon";
									this.RepLoss = 10f;
									this.Concern = 5;
								}
								else if (this.WitnessedBlood)
								{
									this.Witnessed = "Blood";
									if (!this.Bloody)
									{
										this.RepLoss = 10f;
										this.Concern = 5;
									}
									else
									{
										this.RepLoss = 0f;
										this.Concern = 0;
									}
								}
								else if (this.Yandere.Sanity < 33.333f)
								{
									this.Witnessed = "Insanity";
									this.RepLoss = 10f;
									this.Concern = 5;
								}
								else if (this.Yandere.Laughing)
								{
									this.Witnessed = "Insanity";
									this.RepLoss = 10f;
									this.Concern = 5;
								}
								else if (this.Yandere.Lewd)
								{
									this.Witnessed = "Lewd";
									this.RepLoss = 10f;
									this.Concern = 5;
								}
								else if (this.Yandere.Trespassing && this.StudentID > 1)
								{
									this.Witnessed = ((!this.Private) ? "Trespassing" : "Interruption");
									this.Witness = false;
									this.Concern++;
								}
								else if (this.Yandere.NearSenpai)
								{
									this.Witnessed = "Stalking";
									this.Concern++;
								}
								else if (this.Yandere.Eavesdropping)
								{
									if (this.StudentID == 1)
									{
										this.Witnessed = "Stalking";
										this.Concern++;
									}
									else if (this.StudentID == 33)
									{
										this.Witnessed = "Eavesdropping";
										this.RepLoss = 10f;
										this.Concern = 5;
									}
								}
								else if (this.Yandere.Aiming)
								{
									this.Witnessed = "Stalking";
									this.Concern++;
								}
								else
								{
									Debug.Log("Apparently, we didn't even see anything! 1");
									this.DiscCheck = true;
									this.Witness = false;
								}
							}
							if (this.Teacher && this.WitnessedCorpse)
							{
								this.Concern = 1;
							}
							if (this.StudentID == 1 && this.Yandere.Mask == null)
							{
								if (this.Concern == 5)
								{
									Debug.Log("Senpai noticed stalking or lewdness.");
									this.SenpaiNoticed();
									if (this.Witnessed == "Stalking" || this.Witnessed == "Lewd")
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
										this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
									}
									else
									{
										if (this.StudentID == 1)
										{
											Debug.Log("Senpai entered his scared animation.");
										}
										this.CharacterAnimation.CrossFade(this.ScaredAnim);
										this.CharacterAnimation["scaredFace_00"].weight = 1f;
									}
									this.CameraEffects.MurderWitnessed();
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
									this.CameraEffects.Alarm();
								}
							}
							else if (!this.Teacher)
							{
								this.CameraEffects.Alarm();
							}
							else
							{
								Debug.Log("A teacher has just witnessed Yandere-chan doing something bad.");
								if (!this.Fleeing)
								{
									if (this.Concern < 5)
									{
										this.CameraEffects.Alarm();
									}
									else
									{
										if (!this.Yandere.Struggling)
										{
											this.SenpaiNoticed();
										}
										this.CameraEffects.MurderWitnessed();
									}
								}
								else
								{
									this.PersonaReaction();
									this.AlarmTimer = 0f;
									if (this.Concern < 5)
									{
										this.CameraEffects.Alarm();
									}
									else
									{
										this.CameraEffects.MurderWitnessed();
									}
								}
							}
							if (!this.Teacher && this.Witnessed == witnessed)
							{
								this.RepeatReaction = true;
							}
							if (this.Yandere.Mask == null)
							{
								this.RepDeduction = 0f;
								this.CalculateReputationPenalty();
								if (this.RepDeduction >= 0f)
								{
									this.RepLoss -= this.RepDeduction;
								}
								this.Reputation.PendingRep -= this.RepLoss * this.Paranoia;
								this.PendingRep -= this.RepLoss * this.Paranoia;
							}
							if (this.ToiletEvent != null && this.ToiletEvent.EventDay == 1)
							{
								this.ToiletEvent.EndEvent();
							}
						}
						else
						{
							Debug.Log("Apparently, we didn't even see anything! 2");
							this.DiscCheck = true;
							this.Witness = false;
						}
					}
				}
				else
				{
					this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
				}
			}
			else
			{
				if (this.Distraction != null)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Distraction.position.x, base.transform.position.y, this.Distraction.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.CharacterAnimation.CrossFade(this.RandomAnim);
					if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
					{
						this.PickRandomAnim();
					}
				}
				if (this.OnPhone)
				{
					this.CharacterAnimation.CrossFade(this.PhoneAnim);
					this.CharacterAnimation[this.WalkAnim].time = this.CharacterAnimation[this.PhoneAnim].time;
					if (base.transform.position.z > -49.3351f)
					{
						if (!this.Slave)
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
							this.Distracted = false;
						}
						this.Phone.SetActive(false);
						this.OnPhone = false;
						this.Safe = false;
						this.StudentManager.UpdateStudents();
					}
				}
			}
		}
	}

	private void UpdateDetectionMarker()
	{
		if (this.Alarm < 0f)
		{
			this.Alarm = 0f;
		}
		if (this.DetectionMarker != null)
		{
			this.DetectionMarker.Tex.transform.localScale = new Vector3(this.DetectionMarker.Tex.transform.localScale.x, (this.Alarm > 100f) ? 1f : (this.Alarm / 100f), this.DetectionMarker.Tex.transform.localScale.z);
			if (this.Alarm > 0f)
			{
				if (!this.DetectionMarker.Tex.enabled)
				{
					this.DetectionMarker.Tex.enabled = true;
				}
				this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, this.Alarm / 100f);
			}
			else if (this.DetectionMarker.Tex.color.a != 0f)
			{
				this.DetectionMarker.Tex.enabled = false;
				this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0f);
			}
		}
	}

	private void UpdateTalkInput()
	{
		if (this.StudentID > 1)
		{
			if (!this.Pathfinding.canMove && this.Actions[this.Phase] == StudentActionType.ClubAction && this.Armband.activeInHierarchy)
			{
				this.Warned = false;
			}
			if ((this.Alarm > 0f || this.AlarmTimer > 0f || this.Yandere.Armed) && !this.Slave && !this.BadTime)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.OccultBook.SetActive(false);
				this.SpeechLines.Stop();
				this.Pen.SetActive(false);
				if (this.StudentManager.Pose)
				{
					this.MyController.enabled = false;
					this.Pathfinding.enabled = false;
					this.Stop = true;
					this.Pose();
				}
				else if (this.BadTime)
				{
					this.Yandere.EmptyHands();
					this.BecomeRagdoll();
					this.Yandere.RagdollPK.connectedBody = this.Ragdoll.AllRigidbodies[5];
					this.Yandere.RagdollPK.connectedAnchor = this.Ragdoll.LimbAnchor[4];
					this.DialogueWheel.PromptBar.ClearButtons();
					this.DialogueWheel.PromptBar.Label[1].text = "Back";
					this.DialogueWheel.PromptBar.UpdateButtons();
					this.DialogueWheel.PromptBar.Show = true;
					this.Yandere.Ragdoll = this.Ragdoll.gameObject;
					this.Yandere.SansEyes[0].SetActive(true);
					this.Yandere.SansEyes[1].SetActive(true);
					this.Yandere.GlowEffect.Play();
					this.Yandere.CanMove = false;
					this.Yandere.PK = true;
					this.DeathType = DeathType.EasterEgg;
				}
				else if (this.Slave)
				{
					this.StudentManager.MurderTakingPlace = true;
					this.Yandere.EquippedWeapon.transform.parent = this.HipCollider.transform;
					this.Yandere.EquippedWeapon.transform.localPosition = Vector3.zero;
					this.Yandere.EquippedWeapon.transform.localScale = Vector3.zero;
					this.MyWeapon = this.Yandere.EquippedWeapon;
					this.MyWeapon.FingerprintID = this.StudentID;
					this.Yandere.EquippedWeapon = null;
					this.Yandere.Equipped = 0;
					this.StudentManager.UpdateStudents();
					this.Yandere.WeaponManager.UpdateLabels();
					this.Yandere.WeaponMenu.UpdateSprites();
					this.Yandere.WeaponWarning = false;
					this.CharacterAnimation.CrossFade("f02_brokenStandUp_00");
					if (this.StudentID != 7)
					{
						this.DistanceToDestination = 100f;
						this.Broken.Hunting = true;
						this.TargetDistance = 1f;
						this.Routine = false;
						this.Hunting = true;
					}
					else
					{
						this.Broken.enabled = false;
						this.Routine = false;
						this.Suicide = true;
					}
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
				else if (this.Following)
				{
					this.Subtitle.UpdateLabel("Student Farewell", 0, 3f);
					this.Prompt.Label[0].text = "     Talk";
					this.Prompt.Circle[0].fillAmount = 1f;
					this.Hearts.emission.enabled = false;
					this.Yandere.Followers--;
					this.Following = false;
					this.Routine = true;
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = 1f;
				}
				else if (this.Pushable)
				{
					this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Subtitle.UpdateLabel("Note Reaction", 5, 3f);
					this.Prompt.Label[0].text = "     Talk";
					this.Prompt.Circle[0].fillAmount = 1f;
					this.Yandere.TargetStudent = this;
					this.Yandere.Attacking = true;
					this.Yandere.RoofPush = true;
					this.Yandere.CanMove = false;
					this.Distracted = true;
					this.Routine = false;
					this.Pushed = true;
					this.CharacterAnimation.CrossFade(this.PushedAnim);
				}
				else if (this.Drownable)
				{
					Debug.Log("Just began to drown someone.");
					if (!this.Male)
					{
						this.StudentManager.FemaleVomitDoor.Prompt.enabled = true;
					}
					this.Yandere.EmptyHands();
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Prompt.Circle[0].fillAmount = 1f;
					this.StudentManager.Fountain.Drowning = true;
					this.Police.DrownedStudentName = this.Name;
					this.MyController.enabled = false;
					this.Police.DrownScene = true;
					this.VomitEmitter.Stop();
					this.Distracted = true;
					this.Drownable = false;
					this.Routine = false;
					this.Drowned = true;
					this.Subtitle.UpdateLabel("Drown Reaction", 0, 3f);
					this.Yandere.TargetStudent = this;
					this.Yandere.Attacking = true;
					this.Yandere.CanMove = false;
					this.Yandere.Drown = true;
					this.Yandere.DrownAnim = "f02_fountainDrownA_00";
					this.DrownAnim = "f02_fountainDrownB_00";
					this.CharacterAnimation.CrossFade(this.DrownAnim);
				}
				else if (this.Clock.Period == 2 || this.Clock.Period == 4)
				{
					this.Subtitle.UpdateLabel("Class Apology", 0, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
				}
				else if (this.InEvent || !this.CanTalk || this.GoAway || (this.Meeting && !this.Drownable) || this.Wet || this.TurnOffRadio)
				{
					this.Subtitle.UpdateLabel("Event Apology", 1, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
				}
				else if (this.Warned)
				{
					this.Subtitle.UpdateLabel("Grudge Refusal", 0, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
				}
				else
				{
					this.WitnessedBlood = false;
					if (this.Yandere.Bloodiness > 0f && !this.Yandere.Paint)
					{
						this.WitnessedBlood = true;
					}
					if (!this.Witness && this.WitnessedBlood)
					{
						this.Prompt.Circle[0].fillAmount = 1f;
						this.YandereVisible = true;
						this.Alarm = 200f;
					}
					else
					{
						this.Yandere.TargetStudent = this;
						if (!this.Grudge)
						{
							this.ClubManager.CheckGrudge(this.Club);
							if (ClubGlobals.GetClubKicked(this.Club) && !this.Pathfinding.canMove && this.Actions[this.Phase] == StudentActionType.ClubAction && this.Armband.activeInHierarchy)
							{
								this.Interaction = StudentInteractionType.ClubUnwelcome;
								this.TalkTimer = 5f;
								this.Warned = true;
							}
							else if (ClubGlobals.Club == this.Club && !this.Pathfinding.canMove && this.Actions[this.Phase] == StudentActionType.ClubAction && this.Armband.activeInHierarchy && this.ClubManager.ClubGrudge)
							{
								this.Interaction = StudentInteractionType.ClubKick;
								this.TalkTimer = 5f;
								this.Warned = true;
							}
							else if (this.Prompt.Label[0].text == "     Feed")
							{
								this.Interaction = StudentInteractionType.Feeding;
								this.TalkTimer = 3f;
							}
							else
							{
								if (!this.Pathfinding.canMove && this.Actions[this.Phase] == StudentActionType.ClubAction && this.Armband.activeInHierarchy)
								{
									this.Subtitle.UpdateLabel("Club Greeting", (int)this.Club, 4f);
									this.DialogueWheel.ClubLeader = true;
								}
								else
								{
									this.Subtitle.UpdateLabel("Greeting", 0, 3f);
								}
								if ((this.Male && PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 0) || PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 4)
								{
									ParticleSystem.EmissionModule emission = this.Hearts.emission;
									emission.rateOverTime = (float)PlayerGlobals.Seduction;
									emission.enabled = true;
									this.Hearts.Play();
								}
								this.StudentManager.DisablePrompts();
								this.DialogueWheel.HideShadows();
								this.DialogueWheel.Show = true;
								this.DialogueWheel.Panel.enabled = true;
								this.TalkTimer = 0f;
							}
						}
						else if (!this.Pathfinding.canMove && this.Actions[this.Phase] == StudentActionType.ClubAction && this.Armband.activeInHierarchy)
						{
							this.Interaction = StudentInteractionType.ClubUnwelcome;
							this.TalkTimer = 5f;
							this.Warned = true;
						}
						else
						{
							this.Interaction = StudentInteractionType.PersonalGrudge;
							this.TalkTimer = 5f;
							this.Warned = true;
						}
						this.ShoulderCamera.OverShoulder = true;
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Obstacle.enabled = true;
						this.Giggle = null;
						this.Yandere.WeaponMenu.KeyboardShow = false;
						this.Yandere.Obscurance.enabled = false;
						this.Yandere.WeaponMenu.Show = false;
						this.Yandere.YandereVision = false;
						this.Yandere.CanMove = false;
						this.Yandere.Talking = true;
						this.Investigating = false;
						this.Reacted = false;
						this.Routine = false;
						this.Talking = true;
						this.ReadPhase = 0;
						if (!this.Male)
						{
							this.SmartPhone.SetActive(false);
						}
					}
				}
			}
			if (this.Prompt.Circle[2].fillAmount == 0f && !this.Yandere.NearSenpai && !this.Yandere.Attacking && this.Yandere.Stance.Current != StanceType.Crouching)
			{
				if (this.Yandere.EquippedWeapon.Flaming || this.Yandere.CyborgParts[1].activeInHierarchy)
				{
					this.Yandere.SanityBased = false;
				}
				this.AttackReaction();
			}
		}
	}

	private void UpdateDying()
	{
		this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
		if (this.Attacked)
		{
			if (!this.Teacher)
			{
				this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
				if (this.Alive && !this.Tranquil)
				{
					if (!this.Yandere.SanityBased)
					{
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
						if (this.Yandere.EquippedWeapon.WeaponID == 11)
						{
							this.CharacterAnimation.CrossFade(this.CyborgDeathAnim);
							this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
							if (this.CharacterAnimation[this.CyborgDeathAnim].time >= this.CharacterAnimation[this.CyborgDeathAnim].length - 0.25f && this.Yandere.EquippedWeapon.WeaponID == 11)
							{
								UnityEngine.Object.Instantiate<GameObject>(this.BloodyScream, base.transform.position + Vector3.up, Quaternion.identity);
								this.DeathType = DeathType.EasterEgg;
								this.BecomeRagdoll();
								this.Ragdoll.Dismember();
							}
						}
						else if (this.Yandere.EquippedWeapon.WeaponID == 7)
						{
							this.CharacterAnimation.CrossFade(this.BuzzSawDeathAnim);
							this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
						}
						else if (!this.Yandere.EquippedWeapon.Concealable)
						{
							this.CharacterAnimation.CrossFade(this.SwingDeathAnim);
							this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.DefendAnim);
							this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.1f);
						}
					}
					else
					{
						this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * this.Yandere.AttackManager.Distance);
						if (!this.Yandere.AttackManager.Stealth)
						{
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
						}
						else
						{
							this.targetRotation = Quaternion.LookRotation(base.transform.position - new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z));
						}
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					}
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.DeathAnim);
					if (this.CharacterAnimation[this.DeathAnim].time < 1f)
					{
						base.transform.Translate(Vector3.back * Time.deltaTime);
					}
					else
					{
						this.BecomeRagdoll();
					}
				}
			}
			else
			{
				if (!this.StudentManager.Stop)
				{
					this.StudentManager.StopMoving();
					this.Yandere.Laughing = false;
					this.Yandere.Dipping = false;
					this.Yandere.RPGCamera.enabled = false;
					this.Phone.SetActive(false);
					this.Police.Show = false;
				}
				this.CharacterAnimation.CrossFade(this.CounterAnim);
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
		}
	}

	private void UpdatePushed()
	{
		this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
		this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
		if (this.CharacterAnimation[this.PushedAnim].time >= this.CharacterAnimation[this.PushedAnim].length)
		{
			this.BecomeRagdoll();
		}
	}

	private void UpdateDrowned()
	{
		this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
		this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
		if (this.CharacterAnimation[this.DrownAnim].time >= this.CharacterAnimation[this.DrownAnim].length)
		{
			this.BecomeRagdoll();
		}
	}

	private void UpdateWitnessedMurder()
	{
		if (!this.Fleeing)
		{
			if (this.StudentID > 1 && this.Persona != PersonaType.Evil)
			{
				this.EyeShrink += Time.deltaTime * 0.2f;
			}
			if (this.Yandere.TargetStudent != null && this.LovedOneIsTargeted(this.Yandere.TargetStudent.StudentID))
			{
				this.Strength = 5;
				this.Persona = PersonaType.Heroic;
			}
			if (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null && this.Yandere.PickUp.BodyPart.Type == 1 && this.LovedOneIsTargeted(this.Yandere.PickUp.BodyPart.StudentID))
			{
				this.Strength = 5;
				this.Persona = PersonaType.Heroic;
			}
			if (this.StudentID == 1)
			{
				Debug.Log("Senpai entered his scared animation.");
			}
			this.CharacterAnimation.CrossFade(this.ScaredAnim);
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.position.x, base.transform.position.y, this.Yandere.Hips.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			if (!this.Yandere.Struggling)
			{
				if (this.Persona != PersonaType.Heroic)
				{
					this.AlarmTimer += Time.deltaTime * (float)this.MurdersWitnessed;
				}
				else
				{
					this.AlarmTimer += Time.deltaTime * ((float)this.MurdersWitnessed * 5f);
				}
			}
			if (this.AlarmTimer > 5f)
			{
				this.PersonaReaction();
				this.AlarmTimer = 0f;
			}
			else if (this.AlarmTimer > 1f && !this.Reacted)
			{
				if (this.StudentID > 1 || this.Yandere.Mask != null)
				{
					if (!this.Teacher)
					{
						this.Subtitle.UpdateLabel("Murder Reaction", 1, 3f);
					}
					else
					{
						this.Subtitle.UpdateLabel("Teacher Murder Reaction", UnityEngine.Random.Range(1, 3), 3f);
						this.StudentManager.Portal.SetActive(false);
					}
				}
				else
				{
					Debug.Log("Senpai witnessed murder, and entered a specific murder reaction animation.");
					this.MurderReaction = UnityEngine.Random.Range(1, 6);
					this.CharacterAnimation.CrossFade("senpaiMurderReaction_0" + this.MurderReaction);
					this.GameOverCause = "Murder";
					this.SenpaiNoticed();
					this.CharacterAnimation["scaredFace_00"].weight = 0f;
					this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
					this.Yandere.ShoulderCamera.enabled = true;
					this.Yandere.ShoulderCamera.Noticed = true;
					this.Yandere.RPGCamera.enabled = false;
					this.Stop = true;
				}
				this.Reacted = true;
			}
		}
	}

	private void UpdateAlarmed()
	{
		if (!this.Male)
		{
			this.SpeechLines.Stop();
		}
		this.SmartPhone.SetActive(false);
		this.OccultBook.SetActive(false);
		this.SpeechLines.Stop();
		this.Pen.SetActive(false);
		this.ReadPhase = 0;
		if (this.WitnessedCorpse)
		{
			if (!this.WalkBack)
			{
				if (this.StudentID == 1)
				{
					Debug.Log("Senpai entered his scared animation.");
				}
				this.CharacterAnimation.CrossFade(this.ScaredAnim);
			}
			else
			{
				this.MyController.Move(base.transform.forward * (-0.5f * Time.deltaTime));
				this.CharacterAnimation.CrossFade(this.WalkBackAnim);
				this.WalkBackTimer -= Time.deltaTime;
				if (this.WalkBackTimer <= 0f)
				{
					this.WalkBack = false;
				}
			}
		}
		else if (this.StudentID > 1)
		{
			this.CharacterAnimation.CrossFade(this.LeanAnim);
		}
		if (this.WitnessedMurder)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
		}
		else if (this.WitnessedCorpse)
		{
			if (this.Corpse != null && this.Corpse.AllColliders[0] != null)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			}
		}
		else if (!this.DiscCheck)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
		}
		else
		{
			this.targetRotation = Quaternion.LookRotation(this.DistractionSpot - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
		}
		if (!this.Fleeing)
		{
			this.AlarmTimer += Time.deltaTime * (1f - this.Hesitation);
		}
		this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
		if (this.AlarmTimer > 5f)
		{
			this.Pathfinding.canSearch = true;
			this.Pathfinding.canMove = true;
			if (this.StudentID == 1 || this.Teacher)
			{
				this.IgnoreTimer = 0.0001f;
			}
			else
			{
				this.IgnoreTimer = 5f;
			}
			this.DiscCheck = false;
			this.Alarmed = false;
			this.Reacted = false;
			this.Hesitation = 0f;
			this.AlarmTimer = 0f;
			if (this.WitnessedCorpse)
			{
				this.PersonaReaction();
			}
			else if (!this.Following && !this.Wet && !this.Investigating)
			{
				this.Routine = true;
			}
		}
		else if (this.AlarmTimer > 1f && !this.Reacted)
		{
			if (this.Teacher)
			{
				if (!this.WitnessedCorpse)
				{
					Debug.Log("A teacher's reaction is now being determined.");
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					if (this.Witnessed == "Weapon and Blood and Insanity")
					{
						this.Subtitle.UpdateLabel("Teacher Insanity Reaction", 1, 6f);
						this.GameOverCause = "Insanity";
					}
					else if (this.Witnessed == "Weapon and Blood")
					{
						this.Subtitle.UpdateLabel("Teacher Weapon Reaction", 1, 6f);
						this.GameOverCause = "Weapon";
					}
					else if (this.Witnessed == "Weapon and Insanity")
					{
						this.Subtitle.UpdateLabel("Teacher Insanity Reaction", 1, 6f);
						this.GameOverCause = "Insanity";
					}
					else if (this.Witnessed == "Blood and Insanity")
					{
						this.Subtitle.UpdateLabel("Teacher Insanity Reaction", 1, 6f);
						this.GameOverCause = "Insanity";
					}
					else if (this.Witnessed == "Weapon")
					{
						this.Subtitle.UpdateLabel("Teacher Weapon Reaction", 1, 6f);
						this.GameOverCause = "Weapon";
					}
					else if (this.Witnessed == "Blood")
					{
						this.Subtitle.UpdateLabel("Teacher Blood Reaction", 1, 6f);
						this.GameOverCause = "Blood";
					}
					else if (this.Witnessed == "Insanity")
					{
						this.Subtitle.UpdateLabel("Teacher Insanity Reaction", 1, 6f);
						this.GameOverCause = "Insanity";
					}
					else if (this.Witnessed == "Lewd")
					{
						this.Subtitle.UpdateLabel("Teacher Lewd Reaction", 1, 6f);
						this.GameOverCause = "Lewd";
					}
					else if (this.Witnessed == "Trespassing")
					{
						this.Subtitle.UpdateLabel("Teacher Trespassing Reaction", this.Concern, 5f);
					}
					else if (this.Witnessed == "Theft")
					{
						this.Subtitle.UpdateLabel("Teacher Theft Reaction", 1, 6f);
					}
					else if (this.Witnessed == "Pickpocketing")
					{
						this.Subtitle.UpdateLabel(this.RivalPrefix + "Pickpocket Reaction", 1, 5f);
					}
				}
				else
				{
					this.Concern = 1;
					if (this.Witnessed == "Weapon and Blood and Insanity")
					{
						this.Subtitle.UpdateLabel("Teacher Insanity Hostile", 1, 6f);
						this.GameOverCause = "Insanity";
						this.WitnessedMurder = true;
					}
					else if (this.Witnessed == "Weapon and Blood")
					{
						this.Subtitle.UpdateLabel("Teacher Weapon Hostile", 1, 6f);
						this.GameOverCause = "Weapon";
						this.WitnessedMurder = true;
					}
					else if (this.Witnessed == "Weapon and Insanity")
					{
						this.Subtitle.UpdateLabel("Teacher Insanity Hostile", 1, 6f);
						this.GameOverCause = "Insanity";
						this.WitnessedMurder = true;
					}
					else if (this.Witnessed == "Blood and Insanity")
					{
						this.Subtitle.UpdateLabel("Teacher Insanity Hostile", 1, 6f);
						this.GameOverCause = "Insanity";
						this.WitnessedMurder = true;
					}
					else if (this.Witnessed == "Weapon")
					{
						this.Subtitle.UpdateLabel("Teacher Weapon Hostile", 1, 6f);
						this.GameOverCause = "Weapon";
						this.WitnessedMurder = true;
					}
					else if (this.Witnessed == "Blood")
					{
						this.Subtitle.UpdateLabel("Teacher Blood Hostile", 1, 6f);
						this.GameOverCause = "Blood";
						this.WitnessedMurder = true;
					}
					else if (this.Witnessed == "Insanity")
					{
						this.Subtitle.UpdateLabel("Teacher Insanity Hostile", 1, 6f);
						this.GameOverCause = "Insanity";
						this.WitnessedMurder = true;
					}
					else if (this.Witnessed == "Lewd")
					{
						this.Subtitle.UpdateLabel("Teacher Lewd Reaction", 1, 6f);
						this.GameOverCause = "Lewd";
					}
					else if (this.Witnessed == "Trespassing")
					{
						this.Subtitle.UpdateLabel("Teacher Trespassing Reaction", this.Concern, 5f);
					}
					else if (this.Witnessed == "Corpse")
					{
						this.Subtitle.UpdateLabel("Teacher Corpse Reaction", 1, 3f);
						this.Police.Called = true;
					}
					if (this.WitnessedMurder && !this.Yandere.Chased)
					{
						this.ChaseYandere();
					}
				}
				if (this.Concern == 5)
				{
					Debug.Log("A Game Over will now occur.");
					this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
					this.Yandere.ShoulderCamera.enabled = true;
					this.Yandere.ShoulderCamera.Noticed = true;
					this.Yandere.RPGCamera.enabled = false;
					this.Stop = true;
				}
			}
			else if (this.StudentID > 1 || this.Yandere.Mask != null)
			{
				if (this.RepeatReaction)
				{
					this.Subtitle.UpdateLabel("Repeat Reaction", 1, 3f);
					this.RepeatReaction = false;
				}
				else if (this.Witnessed == "Weapon and Blood and Insanity")
				{
					this.Subtitle.UpdateLabel("Weapon and Blood and Insanity Reaction", 1, 3f);
				}
				else if (this.Witnessed == "Weapon and Blood")
				{
					this.Subtitle.UpdateLabel("Weapon and Blood Reaction", 1, 3f);
				}
				else if (this.Witnessed == "Weapon and Insanity")
				{
					this.Subtitle.UpdateLabel("Weapon and Insanity Reaction", 1, 3f);
				}
				else if (this.Witnessed == "Blood and Insanity")
				{
					this.Subtitle.UpdateLabel("Blood and Insanity Reaction", 1, 3f);
				}
				else if (this.Witnessed == "Weapon")
				{
					this.Subtitle.UpdateLabel("Weapon Reaction", this.WeaponWitnessed, 3f);
				}
				else if (this.Witnessed == "Blood")
				{
					if (!this.Bloody)
					{
						this.Subtitle.UpdateLabel("Blood Reaction", 1, 3f);
					}
					else
					{
						this.Subtitle.UpdateLabel("Wet Blood Reaction", 1, 3f);
						this.Witnessed = string.Empty;
						this.Witness = false;
					}
				}
				else if (this.Witnessed == "Insanity")
				{
					this.Subtitle.UpdateLabel("Insanity Reaction", 1, 3f);
				}
				else if (this.Witnessed == "Lewd")
				{
					this.Subtitle.UpdateLabel("Lewd Reaction", 1, 3f);
				}
				else if (this.Witnessed == "Corpse")
				{
					if (this.Persona == PersonaType.Evil)
					{
						this.Subtitle.UpdateLabel("Evil Corpse Reaction", 1, 5f);
					}
					else
					{
						this.Subtitle.UpdateLabel("Corpse Reaction", 1, 5f);
					}
				}
				else if (this.Witnessed == "Interruption")
				{
					this.Subtitle.UpdateLabel("Interruption Reaction", 1, 5f);
				}
				else if (this.Witnessed == "Eavesdropping")
				{
					this.Subtitle.UpdateLabel("Eavesdrop Reaction", 1, 5f);
				}
				else if (this.Witnessed == "Pickpocketing")
				{
					this.Subtitle.UpdateLabel(this.RivalPrefix + "Pickpocket Reaction", 1, 5f);
				}
			}
			else
			{
				if (this.Witnessed == "Weapon and Blood and Insanity")
				{
					this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
					this.GameOverCause = "Insanity";
				}
				else if (this.Witnessed == "Weapon and Blood")
				{
					this.CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
					this.GameOverCause = "Weapon";
				}
				else if (this.Witnessed == "Weapon and Insanity")
				{
					this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
					this.GameOverCause = "Insanity";
				}
				else if (this.Witnessed == "Blood and Insanity")
				{
					this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
					this.GameOverCause = "Insanity";
				}
				else if (this.Witnessed == "Weapon")
				{
					this.CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
					this.GameOverCause = "Weapon";
				}
				else if (this.Witnessed == "Blood")
				{
					this.CharacterAnimation.CrossFade("senpaiBloodReaction_00");
					this.GameOverCause = "Blood";
				}
				else if (this.Witnessed == "Insanity")
				{
					this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
					this.GameOverCause = "Insanity";
				}
				else if (this.Witnessed == "Lewd")
				{
					this.CharacterAnimation.CrossFade("senpaiLewdReaction_00");
					this.GameOverCause = "Lewd";
				}
				else if (this.Witnessed == "Stalking")
				{
					if (this.Concern < 5)
					{
						this.Subtitle.UpdateLabel("Senpai Stalking Reaction", this.Concern, 4.5f);
					}
					else
					{
						this.CharacterAnimation.CrossFade("senpaiCreepyReaction_00");
						this.GameOverCause = "Stalking";
					}
					this.Witnessed = string.Empty;
				}
				else if (this.Witnessed == "Corpse")
				{
					this.Subtitle.UpdateLabel("Senpai Corpse Reaction", 1, 5f);
				}
				if (this.Concern == 5)
				{
					this.CharacterAnimation["scaredFace_00"].weight = 0f;
					this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
					this.Yandere.ShoulderCamera.enabled = true;
					this.Yandere.ShoulderCamera.Noticed = true;
					this.Yandere.RPGCamera.enabled = false;
					this.Stop = true;
				}
			}
			this.Reacted = true;
		}
	}

	private void UpdateBurning()
	{
		if (this.BurnTarget != Vector3.zero)
		{
			this.MoveTowardsTarget(this.BurnTarget);
		}
		if (this.CharacterAnimation[this.BurningAnim].time > this.CharacterAnimation[this.BurningAnim].length)
		{
			this.DeathType = DeathType.Burning;
			this.BecomeRagdoll();
		}
	}

	private void UpdateSplashed()
	{
		if (this.Yandere.Tripping)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
		}
		if (!this.Alarmed)
		{
			this.SplashTimer += Time.deltaTime;
			if (this.SplashTimer > 2f && this.SplashPhase == 1)
			{
				if (this.Gas)
				{
					this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 5, 5f);
				}
				else if (this.Bloody)
				{
					this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 3, 5f);
				}
				else if (this.Yandere.Tripping)
				{
					this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 7, 5f);
				}
				else
				{
					this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 1, 5f);
				}
				this.CharacterAnimation[this.SplashedAnim].speed = 0.5f;
				this.SplashPhase++;
			}
			if (this.SplashTimer > 12f && this.SplashPhase == 2)
			{
				if (this.LightSwitch == null)
				{
					if (this.Gas)
					{
						this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 6, 5f);
					}
					else if (this.Bloody)
					{
						this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 4, 5f);
					}
					else
					{
						this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 2, 5f);
					}
					this.SplashPhase++;
					this.CurrentDestination = this.StudentManager.StripSpot;
					this.Pathfinding.target = this.StudentManager.StripSpot;
				}
				else if (!this.LightSwitch.BathroomLight.activeInHierarchy)
				{
					if (this.LightSwitch.Panel.useGravity)
					{
						this.LightSwitch.Prompt.Hide();
						this.LightSwitch.Prompt.enabled = false;
						this.Prompt.Hide();
						this.Prompt.enabled = false;
					}
					this.Subtitle.UpdateLabel("Light Switch Reaction", 1, 5f);
					this.CurrentDestination = this.LightSwitch.ElectrocutionSpot;
					this.Pathfinding.target = this.LightSwitch.ElectrocutionSpot;
					this.Pathfinding.speed = 1f;
					this.BathePhase = -1;
					this.InDarkness = true;
				}
				else
				{
					if (!this.Bloody)
					{
						this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 2, 5f);
					}
					else
					{
						this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 4, 5f);
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
	}

	private void UpdateTurningOffRadio()
	{
		if (this.TurnOffRadio)
		{
			if (this.Radio.On || (this.RadioPhase == 3 && this.Radio.transform.parent == null))
			{
				if (this.RadioPhase == 1)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, base.transform.position.y, this.Radio.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.RadioTimer += Time.deltaTime;
					if (this.RadioTimer > 3f)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.CurrentDestination = this.Radio.transform;
						this.Pathfinding.target = this.Radio.transform;
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.RadioTimer = 0f;
						this.RadioPhase++;
					}
				}
				else if (this.RadioPhase == 2)
				{
					if (this.DistanceToDestination < 0.5f)
					{
						this.CharacterAnimation.CrossFade(this.RadioAnim);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.RadioPhase++;
					}
				}
				else if (this.RadioPhase == 3)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, base.transform.position.y, this.Radio.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.RadioTimer += Time.deltaTime;
					if (this.RadioTimer > 4f)
					{
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.ForgetRadio();
					}
					else if (this.RadioTimer > 2f)
					{
						this.Radio.Victim = null;
						this.Radio.TurnOff();
					}
				}
			}
			else
			{
				if (this.RadioPhase < 100)
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.RadioPhase = 100;
					this.RadioTimer = 0f;
				}
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, base.transform.position.y, this.Radio.transform.position.z) - base.transform.position);
				this.RadioTimer += Time.deltaTime;
				if (this.RadioTimer > 1f || this.Radio.transform.parent != null)
				{
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.ForgetRadio();
				}
			}
		}
	}

	private void UpdateVomiting()
	{
		if (this.Vomiting)
		{
			if (this.VomitPhase != 0 && this.VomitPhase != 4)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.CurrentDestination.position);
			}
			if (this.VomitPhase == 0)
			{
				if (this.DistanceToDestination < 0.5f)
				{
					if (this.StudentID == 33)
					{
						this.Prompt.Label[0].text = "     Drown";
						this.Drownable = true;
					}
					if (!this.Male)
					{
						this.StudentManager.FemaleVomitDoor.Prompt.enabled = false;
						this.StudentManager.FemaleVomitDoor.Prompt.Hide();
					}
					this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.CharacterAnimation.CrossFade(this.VomitAnim);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.VomitPhase++;
				}
			}
			else if (this.VomitPhase == 1)
			{
				if (this.CharacterAnimation[this.VomitAnim].time > 1f)
				{
					this.VomitEmitter.Play();
					this.VomitPhase++;
				}
			}
			else if (this.VomitPhase == 2)
			{
				if (this.CharacterAnimation[this.VomitAnim].time > 13f)
				{
					this.VomitEmitter.Stop();
					this.VomitPhase++;
				}
			}
			else if (this.VomitPhase == 3)
			{
				if (this.CharacterAnimation[this.VomitAnim].time >= this.CharacterAnimation[this.VomitAnim].length)
				{
					this.Prompt.Label[0].text = "     Talk";
					this.Drownable = false;
					this.WalkAnim = this.OriginalWalkAnim;
					this.CharacterAnimation.CrossFade(this.WalkAnim);
					if (this.Male)
					{
						this.Pathfinding.target = this.StudentManager.MaleWashSpot;
						this.CurrentDestination = this.StudentManager.MaleWashSpot;
					}
					else
					{
						this.Pathfinding.target = this.StudentManager.FemaleWashSpot;
						this.CurrentDestination = this.StudentManager.FemaleWashSpot;
					}
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = 1f;
					this.DistanceToDestination = 100f;
					this.VomitPhase++;
				}
			}
			else if (this.VomitPhase == 4)
			{
				if (this.DistanceToDestination < 0.5f)
				{
					this.CharacterAnimation.CrossFade(this.WashFaceAnim);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.VomitPhase++;
				}
			}
			else if (this.VomitPhase == 5 && this.CharacterAnimation[this.WashFaceAnim].time > this.CharacterAnimation[this.WashFaceAnim].length)
			{
				this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
				this.Prompt.Label[0].text = "     Talk";
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Distracted = false;
				this.Drownable = false;
				this.Vomiting = false;
				this.Private = false;
				this.CanTalk = true;
				this.Routine = true;
				this.Emetic = false;
				this.VomitPhase = 0;
				this.Pathfinding.target = this.Destinations[this.Phase];
				this.CurrentDestination = this.Destinations[this.Phase];
				this.DistanceToDestination = 100f;
				if (!this.Male)
				{
					this.StudentManager.FemaleVomitDoor.Prompt.enabled = false;
					this.StudentManager.FemaleVomitDoor.Prompt.Hide();
				}
			}
		}
	}

	private void UpdateConfessing()
	{
		if (this.Confessing)
		{
			if (!this.Male)
			{
				if (this.ConfessPhase == 1)
				{
					if (this.DistanceToDestination < 0.5f)
					{
						this.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
						this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						this.CharacterAnimation.CrossFade("f02_insertNote_00");
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Note.SetActive(true);
						this.ConfessPhase++;
					}
				}
				else if (this.ConfessPhase == 2)
				{
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
					this.MoveTowardsTarget(this.CurrentDestination.position);
					if (this.CharacterAnimation["f02_insertNote_00"].time >= 9f)
					{
						this.Note.SetActive(false);
						this.ConfessPhase++;
					}
				}
				else if (this.ConfessPhase == 3)
				{
					if (this.CharacterAnimation["f02_insertNote_00"].time >= this.CharacterAnimation["f02_insertNote_00"].length)
					{
						this.CurrentDestination = this.StudentManager.EdgeOfGrid;
						this.Pathfinding.target = this.StudentManager.EdgeOfGrid;
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Pathfinding.speed = 4f;
						this.StudentManager.LoveManager.LeftNote = true;
						this.CharacterAnimation.CrossFade(this.SprintAnim);
						this.ConfessPhase++;
					}
				}
				else if (this.ConfessPhase == 4)
				{
					if (this.DistanceToDestination < 0.5f)
					{
						this.CurrentDestination = this.StudentManager.ConfessionWaypoint;
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.ConfessPhase++;
					}
				}
				else if (this.ConfessPhase == 5)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.CurrentDestination.position.x, base.transform.position.y, this.CurrentDestination.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.MyController.Move(base.transform.forward * (4f * Time.deltaTime));
					if (this.DistanceToDestination < 1f)
					{
						this.CurrentDestination = this.StudentManager.ConfessionSpot;
						this.ConfessPhase++;
					}
				}
				else if (this.ConfessPhase == 6)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.CurrentDestination.position.x, base.transform.position.y, this.CurrentDestination.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.MyController.Move(base.transform.forward * (4f * Time.deltaTime));
					if (this.DistanceToDestination < 0.5f)
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.ConfessPhase++;
					}
				}
				else if (this.ConfessPhase == 7)
				{
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
					this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 1f, Time.deltaTime);
					this.MoveTowardsTarget(this.CurrentDestination.position);
				}
			}
			else if (this.ConfessPhase == 1)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.CurrentDestination.position);
				if (this.CharacterAnimation["keepNote_00"].time > 14f)
				{
					this.Note.SetActive(false);
				}
				else if ((double)this.CharacterAnimation["keepNote_00"].time > 4.5)
				{
					this.Note.SetActive(true);
				}
				if (this.CharacterAnimation["keepNote_00"].time >= this.CharacterAnimation["keepNote_00"].length)
				{
					this.CurrentDestination = this.StudentManager.EdgeOfGrid;
					this.Pathfinding.target = this.StudentManager.EdgeOfGrid;
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = 4f;
					this.CharacterAnimation.CrossFade(this.SprintAnim);
					this.ConfessPhase++;
				}
			}
			else if (this.ConfessPhase == 2)
			{
				if (this.DistanceToDestination < 0.5f)
				{
					this.CurrentDestination = this.StudentManager.SuitorConfessionSpot;
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.ConfessPhase++;
				}
			}
			else if (this.ConfessPhase == 3)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.CurrentDestination.position.x, base.transform.position.y, this.CurrentDestination.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				this.MyController.Move(base.transform.forward * (4f * Time.deltaTime));
				if (this.DistanceToDestination < 0.5f)
				{
					this.CharacterAnimation.CrossFade("exhausted_00");
					this.ConfessPhase++;
				}
			}
			else if (this.ConfessPhase == 4)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.CurrentDestination.position);
			}
		}
	}

	private void UpdateMisc()
	{
		if (this.IgnoreTimer > 0f)
		{
			this.IgnoreTimer -= Time.deltaTime;
		}
		if (!this.Fleeing)
		{
			if (base.transform.position.z < -100f)
			{
				if (base.transform.position.y < -2f && this.StudentID > 1)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
			else if (base.transform.position.y < -0f)
			{
				base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
			}
		}
		if (!this.Male)
		{
			if (!this.Splashed && this.Wet && !this.Burning && !this.Dying && Mathf.Abs(this.BathePhase) == 1)
			{
				if (this.CharacterAnimation[this.WetAnim].weight < 1f)
				{
					this.CharacterAnimation[this.WetAnim].weight = 1f;
				}
			}
			else if (this.CharacterAnimation[this.WetAnim].weight > 0f)
			{
				this.CharacterAnimation[this.WetAnim].weight = 0f;
			}
		}
		if (this.Dying)
		{
			this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		}
		if (this.Pathfinding.canMove && base.transform.position == this.LastPosition)
		{
			this.StuckTimer += Time.deltaTime;
			if (this.StuckTimer > 1f)
			{
				this.MyController.Move(base.transform.right * (Time.timeScale * 0.0001f));
				this.StuckTimer = 0f;
			}
		}
		this.LastPosition = base.transform.position;
	}

	private void LateUpdate()
	{
		this.CharacterAnimation.enabled = (this.CharacterAnimation.cullingType != AnimationCullingType.BasedOnRenderers || !this.StudentManager.DisableFarAnims || this.DistanceToPlayer <= 15f);
		if (this.EyeShrink > 1f)
		{
			this.EyeShrink = 1f;
		}
		this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
		this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
		this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
		this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
		this.PreviousEyeShrink = this.EyeShrink;
		if (!this.Male)
		{
			if (this.Shy)
			{
				if (this.Routine)
				{
					if ((this.Phase == 2 && this.DistanceToDestination < 1f) || (this.Phase == 4 && this.DistanceToDestination < 1f))
					{
						this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 0f, Time.deltaTime);
					}
					else
					{
						this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 1f, Time.deltaTime);
					}
				}
				else
				{
					this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 0f, Time.deltaTime);
				}
			}
			if (this.Routine && !this.InEvent && !this.Meeting)
			{
				if (this.DistanceToDestination < this.TargetDistance && this.Actions[this.Phase] == StudentActionType.SitAndSocialize)
				{
					this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 1f, Time.deltaTime * 10f);
				}
				else
				{
					this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 0f, Time.deltaTime * 10f);
				}
			}
			else
			{
				this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 0f, Time.deltaTime * 10f);
			}
			if (!this.BoobsResized)
			{
				this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				this.RightBreast.gameObject.name = "RightBreastRENAMED";
				this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
				this.BoobsResized = true;
			}
			if (this.Following)
			{
				if (this.Gush)
				{
					this.Neck.LookAt(this.GushTarget);
				}
				else
				{
					this.Neck.LookAt(this.DefaultTarget);
				}
			}
		}
		if (this.DK)
		{
			this.Arm[0].localScale = new Vector3(2f, 2f, 2f);
			this.Arm[1].localScale = new Vector3(2f, 2f, 2f);
			this.Head.localScale = new Vector3(2f, 2f, 2f);
		}
		if (this.StudentID == 32)
		{
			for (int i = 0; i < 4; i++)
			{
				Transform transform = this.Skirt[i].transform;
				transform.localScale = new Vector3(transform.localScale.x, 0.6666667f, transform.localScale.z);
			}
		}
	}

	private void CalculateReputationPenalty()
	{
		if ((this.Male && PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 2) || PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 4)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (PlayerGlobals.Reputation < -33.33333f)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (PlayerGlobals.Reputation > 33.33333f)
		{
			this.RepDeduction -= this.RepLoss * 0.2f;
		}
		if (PlayerGlobals.GetStudentFriend(this.StudentID))
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (PlayerGlobals.PantiesEquipped == 1)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (PlayerGlobals.SocialBonus > 0)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
	}

	public void MoveTowardsTarget(Vector3 target)
	{
		if (Time.timeScale > 0f && this.MyController.enabled)
		{
			Vector3 a = target - base.transform.position;
			float sqrMagnitude = a.sqrMagnitude;
			if (sqrMagnitude > 1E-06f)
			{
				this.MyController.Move(a * (Time.deltaTime * 5f / Time.timeScale));
			}
		}
	}

	private void LookTowardsTarget(Vector3 target)
	{
		if (Time.timeScale > 0f)
		{
		}
	}

	public void AttackReaction()
	{
		if (!this.WitnessedMurder)
		{
			float f = Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position);
			this.Yandere.AttackManager.Stealth = (Mathf.Abs(f) <= 45f);
		}
		this.StudentManager.TranqDetector.TranqCheck();
		if (!this.Male)
		{
			this.CharacterAnimation["f02_smile_00"].weight = 0f;
			this.SmartPhone.SetActive(false);
		}
		this.WitnessCamera.Show = false;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Yandere.CharacterAnimation["f02_idleShort_00"].time = 0f;
		this.Yandere.CharacterAnimation["f02_swingA_00"].time = 0f;
		this.Yandere.MyController.radius = 0f;
		this.Yandere.TargetStudent = this;
		this.Yandere.Obscurance.enabled = false;
		this.Yandere.YandereVision = false;
		this.Yandere.Attacking = true;
		this.Yandere.CanMove = false;
		if (this.Yandere.Equipped > 0 && this.Yandere.EquippedWeapon.AnimID == 2)
		{
			this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[2]].weight = 0f;
		}
		if (this.DetectionMarker != null)
		{
			this.DetectionMarker.Tex.enabled = false;
		}
		this.OccultBook.SetActive(false);
		this.MyController.radius = 0f;
		this.Investigating = false;
		this.Pen.SetActive(false);
		this.SpeechLines.Stop();
		this.Attacked = true;
		this.Alarmed = false;
		this.Fleeing = false;
		this.Routine = false;
		this.ReadPhase = 0;
		this.Dying = true;
		this.Wet = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		if (this.Following)
		{
			this.Hearts.emission.enabled = false;
			this.Yandere.Followers--;
			this.Following = false;
		}
		if (this.Distracting)
		{
			this.DistractionTarget.TargetedForDistraction = false;
			this.DistractionTarget.Distracted = false;
			this.Distracting = false;
		}
		if (this.Teacher)
		{
			if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus > 0 && this.Yandere.EquippedWeapon.Type == WeaponType.Knife)
			{
				Debug.Log("A teacher has entered the ''Fleeing'' protocol and called the ''BeginStruggle'' function.");
				this.Pathfinding.target = this.Yandere.transform;
				this.CurrentDestination = this.Yandere.transform;
				this.Yandere.Attacking = false;
				this.Attacked = false;
				this.Fleeing = true;
				this.Dying = false;
				this.Persona = PersonaType.Heroic;
				this.BeginStruggle();
			}
			else
			{
				this.Yandere.HeartRate.gameObject.SetActive(false);
				this.Yandere.ShoulderCamera.Counter = true;
				this.ShoulderCamera.OverShoulder = false;
				this.Yandere.RPGCamera.enabled = false;
				this.Yandere.Senpai = base.transform;
				this.Yandere.Attacking = true;
				this.Yandere.CanMove = false;
				this.Yandere.Talking = false;
				this.Yandere.Noticed = true;
				this.Yandere.HUD.alpha = 0f;
			}
		}
		else
		{
			if (!this.Yandere.AttackManager.Stealth)
			{
				this.Subtitle.UpdateLabel("Dying", 0, 1f);
				this.SpawnAlarmDisc();
			}
			if (this.Yandere.SanityBased)
			{
				this.Yandere.AttackManager.Attack(this.Character, this.Yandere.EquippedWeapon);
			}
		}
	}

	private void SenpaiNoticed()
	{
		Debug.Log("The ''SenpaiNoticed'' function has been called.");
		if (!this.Yandere.Attacking)
		{
			this.Yandere.EmptyHands();
		}
		this.Yandere.Senpai = base.transform;
		if (this.Yandere.Aiming)
		{
			this.Yandere.StopAiming();
		}
		this.Yandere.DetectionPanel.alpha = 0f;
		this.Yandere.RPGCamera.mouseSpeed = 0f;
		this.Yandere.LaughIntensity = 0f;
		this.Yandere.HUD.alpha = 0f;
		this.Yandere.EyeShrink = 0f;
		this.Yandere.Sanity = 100f;
		this.Yandere.HeartRate.gameObject.SetActive(false);
		this.ShoulderCamera.OverShoulder = false;
		this.Yandere.Obscurance.enabled = false;
		this.Yandere.YandereVision = false;
		this.Yandere.Police.Show = false;
		this.Yandere.Stance.Current = StanceType.Standing;
		this.Yandere.Rummaging = false;
		this.Yandere.Laughing = false;
		this.Yandere.CanMove = false;
		this.Yandere.Dipping = false;
		this.Yandere.Mopping = false;
		this.Yandere.Talking = false;
		this.Yandere.Noticed = true;
		this.Yandere.Jukebox.GameOver();
		this.Yandere.UpdateSanity();
		this.StudentManager.StopMoving();
		if (this.Teacher || this.StudentID == 1)
		{
			base.enabled = true;
			this.Stop = false;
		}
	}

	private void WitnessMurder()
	{
		if (!this.Male)
		{
			this.CharacterAnimation["f02_smile_00"].weight = 0f;
		}
		if (this.Yandere.Mask == null)
		{
			this.SawMask = false;
			this.Grudge = true;
		}
		else
		{
			this.SawMask = true;
		}
		if (this.Persona != this.OriginalPersona)
		{
			this.Persona = this.OriginalPersona;
			this.SwitchBack = false;
			this.PersonaReaction();
		}
		if (this.StudentID > 1 || this.Yandere.Mask != null)
		{
			this.ID = 0;
			while (this.ID < this.Outlines.Length)
			{
				this.Outlines[this.ID].color = new Color(1f, 0f, 0f, 1f);
				this.Outlines[this.ID].enabled = true;
				this.ID++;
			}
			this.WitnessCamera.transform.parent = this.WitnessPOV;
			this.WitnessCamera.transform.localPosition = Vector3.zero;
			this.WitnessCamera.transform.localEulerAngles = Vector3.zero;
			this.WitnessCamera.MyCamera.enabled = true;
			this.WitnessCamera.Show = true;
			this.CameraEffects.MurderWitnessed();
			this.Witnessed = "Murder";
			if (this.Persona != PersonaType.Evil)
			{
				this.Police.Witnesses++;
			}
			if (this.Teacher)
			{
				this.StudentManager.Reporter = this;
			}
			if (this.Talking)
			{
				this.DialogueWheel.End();
				this.Hearts.emission.enabled = false;
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Obstacle.enabled = false;
				this.Talking = false;
				this.Waiting = false;
				this.StudentManager.EnablePrompts();
			}
			if (this.Prompt.Label[0] != null)
			{
				this.Prompt.Label[0].text = "     Talk";
				this.Prompt.HideButton[0] = true;
			}
		}
		else
		{
			if (!this.Yandere.Attacking)
			{
				this.SenpaiNoticed();
			}
			this.Fleeing = false;
			this.EyeShrink = 0f;
			this.Yandere.Noticed = true;
			this.Yandere.Talking = false;
			this.CameraEffects.MurderWitnessed();
			this.ShoulderCamera.OverShoulder = false;
			this.CharacterAnimation.CrossFade(this.ScaredAnim);
			this.CharacterAnimation["scaredFace_00"].weight = 1f;
			if (this.StudentID == 1)
			{
				Debug.Log("Senpai entered his scared animation.");
			}
		}
		if (this.Persona == PersonaType.TeachersPet && this.StudentManager.Reporter == null && !this.Police.Called)
		{
			this.StudentManager.CorpseLocation.position = this.Yandere.transform.position;
			this.StudentManager.LowerCorpsePostion();
			this.StudentManager.Reporter = this;
			this.Reporting = true;
		}
		if (this.Following)
		{
			this.Hearts.emission.enabled = false;
			this.Yandere.Followers--;
			this.Following = false;
		}
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		if (this.SmartPhone != null)
		{
			this.SmartPhone.SetActive(false);
		}
		this.OccultBook.SetActive(false);
		this.Phone.SetActive(false);
		this.WitnessedMurder = true;
		this.Investigating = false;
		this.MurdersWitnessed++;
		this.SpeechLines.Stop();
		this.Reacted = false;
		this.Routine = false;
		this.Alarmed = true;
		this.Wet = false;
		if (this.Persona != PersonaType.Heroic)
		{
			this.AlarmTimer = 0f;
			this.Alarm = 0f;
		}
		if (this.Teacher)
		{
			if (!this.Yandere.Chased)
			{
				this.ChaseYandere();
			}
		}
		else
		{
			this.SpawnAlarmDisc();
		}
		if (!this.PinDownWitness)
		{
			this.StudentManager.Witnesses++;
			this.StudentManager.WitnessList[this.StudentManager.Witnesses] = this;
			this.StudentManager.PinDownCheck();
			this.PinDownWitness = true;
		}
		this.StudentManager.UpdateMe(this.StudentID);
	}

	private void ChaseYandere()
	{
		Debug.Log("A character has begun to chase Yandere-chan.");
		this.CurrentDestination = this.Yandere.transform;
		this.Pathfinding.target = this.Yandere.transform;
		this.Pathfinding.speed = 7.5f;
		this.StudentManager.Portal.SetActive(false);
		this.Yandere.Pursuer = this;
		this.TargetDistance = 0.5f;
		this.Fleeing = false;
		this.AlarmTimer = 0f;
		this.StudentManager.UpdateStudents();
	}

	private void PersonaReaction()
	{
		if (!this.Indoors && this.WitnessedMurder && this.Persona != PersonaType.Heroic)
		{
			this.Persona = PersonaType.Loner;
		}
		if (!this.WitnessedMurder)
		{
			if (this.Persona == PersonaType.Heroic)
			{
				this.SwitchBack = true;
				this.Persona = ((!(this.Corpse != null)) ? PersonaType.Loner : PersonaType.TeachersPet);
			}
			else if (this.Persona == PersonaType.Coward || this.Persona == PersonaType.Evil)
			{
				this.Persona = PersonaType.Loner;
			}
		}
		if (this.Persona == PersonaType.Loner)
		{
			if (this.WitnessedMurder)
			{
				this.Subtitle.UpdateLabel("Loner Murder Reaction", 1, 3f);
			}
			else
			{
				this.Subtitle.UpdateLabel("Loner Corpse Reaction", 1, 3f);
			}
			if (this.Schoolwear > 0)
			{
				if (!this.Bloody)
				{
					this.Pathfinding.target = this.StudentManager.Exit;
					this.TargetDistance = 0f;
					this.Routine = false;
					this.Fleeing = true;
				}
				else
				{
					this.FleeWhenClean = true;
					this.TargetDistance = 1f;
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
					this.TargetDistance = 1f;
					this.BatheFast = true;
				}
			}
		}
		else if (this.Persona == PersonaType.TeachersPet)
		{
			if (this.StudentManager.Reporter == this)
			{
				this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
				this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
				if (this.WitnessedMurder)
				{
					this.Subtitle.UpdateLabel("Pet Murder Report", 1, 3f);
				}
				else
				{
					this.Subtitle.UpdateLabel("Pet Corpse Report", 1, 3f);
				}
				this.TargetDistance = 2f;
			}
			else
			{
				this.Pathfinding.target = this.Seat;
				this.CurrentDestination = this.Seat;
				if (this.WitnessedMurder)
				{
					this.Subtitle.UpdateLabel("Pet Murder Reaction", 1, 3f);
				}
				else
				{
					this.Subtitle.UpdateLabel("Pet Corpse Reaction", 1, 3f);
				}
				this.TargetDistance = 1f;
			}
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == PersonaType.Heroic)
		{
			if (!this.Yandere.Chased)
			{
				Debug.Log("Began fleeing because Hero persona reaction was called.");
				this.Subtitle.UpdateLabel("Hero Murder Reaction", 3, 3f);
				this.Pathfinding.target = this.Yandere.transform;
				this.Pathfinding.speed = 7.5f;
				this.StudentManager.Portal.SetActive(false);
				this.Yandere.Chased = true;
				this.TargetDistance = 0.5f;
				this.StudentManager.UpdateStudents();
				this.Routine = false;
				this.Fleeing = true;
			}
		}
		else if (this.Persona == PersonaType.Coward)
		{
			this.CurrentDestination = base.transform;
			this.Pathfinding.target = base.transform;
			this.Subtitle.UpdateLabel("Coward Murder Reaction", 1, 5f);
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == PersonaType.Evil)
		{
			this.CurrentDestination = base.transform;
			this.Pathfinding.target = base.transform;
			this.Subtitle.UpdateLabel("Evil Murder Reaction", 1, 5f);
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == PersonaType.SocialButterfly)
		{
			this.CurrentDestination = this.StudentManager.HidingSpots.List[this.StudentID];
			this.Pathfinding.target = this.StudentManager.HidingSpots.List[this.StudentID];
			this.Subtitle.UpdateLabel("Social Death Reaction", 1, 5f);
			this.ReportPhase = 1;
			this.Routine = false;
			this.Fleeing = true;
			this.Halt = true;
		}
		else if (this.Persona == PersonaType.Strict)
		{
			if (this.WitnessedMurder)
			{
				if (this.Yandere.Pursuer == this)
				{
					Debug.Log("A teacher is now reacting to the sight of murder.");
					this.Subtitle.UpdateLabel("Teacher Murder Reaction", 3, 3f);
					this.Pathfinding.target = this.Yandere.transform;
					this.Pathfinding.speed = 7.5f;
					this.StudentManager.Portal.SetActive(false);
					this.Yandere.Chased = true;
					this.TargetDistance = 0.5f;
					this.StudentManager.UpdateStudents();
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
					this.Routine = false;
					this.Fleeing = true;
				}
				else if (!this.Yandere.Chased)
				{
					this.ChaseYandere();
				}
			}
			else if (this.WitnessedCorpse)
			{
				Debug.Log("A teacher is now reacting to the sight of a corpse.");
				if (this.ReportPhase == 0)
				{
					this.Subtitle.UpdateLabel("Teacher Corpse Reaction", 1, 3f);
				}
				this.Pathfinding.target = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z), Quaternion.identity).transform;
				this.TargetDistance = 1f;
				this.ReportPhase = 2;
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
				this.Routine = false;
				this.Fleeing = true;
			}
		}
	}

	private void BeginStruggle()
	{
		Debug.Log("My name is " + this.Name + " and now I am fighting Yandere-chan.");
		if (this.Yandere.Dragging)
		{
			this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
		}
		if (this.Yandere.Armed)
		{
			this.Yandere.EquippedWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
		}
		this.Yandere.StruggleBar.Strength = (float)this.Strength;
		this.Yandere.StruggleBar.Struggling = true;
		this.Yandere.StruggleBar.Student = this;
		this.Yandere.StruggleBar.gameObject.SetActive(true);
		this.CharacterAnimation.CrossFade(this.StruggleAnim);
		this.ShoulderCamera.LastPosition = this.ShoulderCamera.transform.position;
		this.ShoulderCamera.Struggle = true;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Obstacle.enabled = true;
		this.Struggling = true;
		this.Alarmed = false;
		this.Halt = true;
		if (!this.Teacher)
		{
			this.Yandere.CharacterAnimation["f02_struggleA_00"].time = 0f;
		}
		else
		{
			this.Yandere.CharacterAnimation["f02_teacherStruggleA_00"].time = 0f;
			base.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		if (this.Yandere.Aiming)
		{
			this.Yandere.StopAiming();
		}
		this.Yandere.StopLaughing();
		this.Yandere.TargetStudent = this;
		this.Yandere.Obscurance.enabled = false;
		this.Yandere.YandereVision = false;
		this.Yandere.NearSenpai = false;
		this.Yandere.Struggling = true;
		this.Yandere.CanMove = false;
		this.Yandere.EmptyHands();
		this.Yandere.MyController.enabled = false;
		this.Yandere.RPGCamera.enabled = false;
		this.MyController.radius = 0f;
		this.TargetDistance = 100f;
		this.AlarmTimer = 0f;
		this.SpawnAlarmDisc();
	}

	public void GetDestinations()
	{
		if (!this.Teacher)
		{
			this.MyLocker = this.StudentManager.LockerPositions[this.StudentID];
		}
		if (this.Slave)
		{
			foreach (ScheduleBlock scheduleBlock in this.ScheduleBlocks)
			{
				scheduleBlock.destination = "Slave";
				scheduleBlock.action = "Slave";
			}
		}
		this.ID = 1;
		while (this.ID < this.JSON.Students[this.StudentID].ScheduleBlocks.Length)
		{
			ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[this.ID];
			if (scheduleBlock2.destination == "Locker")
			{
				this.Destinations[this.ID] = this.MyLocker;
			}
			else if (scheduleBlock2.destination == "Seat")
			{
				this.Destinations[this.ID] = this.Seat;
			}
			else if (scheduleBlock2.destination == "Podium")
			{
				this.Destinations[this.ID] = this.StudentManager.Podiums.List[this.Class];
			}
			else if (scheduleBlock2.destination == "Exit")
			{
				this.Destinations[this.ID] = this.StudentManager.Hangouts.List[0];
			}
			else if (scheduleBlock2.destination == "Hangout")
			{
				this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
			}
			else if (scheduleBlock2.destination == "LunchSpot")
			{
				this.Destinations[this.ID] = this.StudentManager.LunchSpots.List[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Slave")
			{
				this.Destinations[this.ID] = this.StudentManager.SlaveSpot;
			}
			else if (scheduleBlock2.destination == "Patrol")
			{
				this.Destinations[this.ID] = this.StudentManager.Patrols.List[this.StudentID].GetChild(0);
			}
			else if (scheduleBlock2.destination == "Search Patrol")
			{
				this.Destinations[this.ID] = this.StudentManager.SearchPatrols.List[this.StudentID].GetChild(0);
			}
			else if (scheduleBlock2.destination == "Mourn")
			{
				this.Destinations[this.ID] = this.StudentManager.MournSpot;
			}
			else if (scheduleBlock2.destination == "Cuddle")
			{
				if (!this.Male)
				{
					this.Destinations[this.ID] = this.StudentManager.FemaleCoupleSpot;
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.MaleCoupleSpot;
				}
			}
			else if (scheduleBlock2.destination == "Stalk")
			{
				if (!this.Male)
				{
					this.Destinations[this.ID] = this.StudentManager.FemaleStalkSpot;
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.MaleStalkSpot;
				}
			}
			else if (scheduleBlock2.destination == "Club")
			{
				if (this.Club > ClubType.None)
				{
					this.Destinations[this.ID] = this.StudentManager.Clubs.List[this.StudentID];
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
				}
			}
			if (scheduleBlock2.action == "Stand")
			{
				this.Actions[this.ID] = StudentActionType.AtLocker;
			}
			else if (scheduleBlock2.action == "Socialize")
			{
				this.Actions[this.ID] = StudentActionType.Socializing;
			}
			else if (scheduleBlock2.action == "Game")
			{
				this.Actions[this.ID] = StudentActionType.Gaming;
			}
			else if (scheduleBlock2.action == "Slave")
			{
				this.Actions[this.ID] = StudentActionType.Slave;
			}
			else if (scheduleBlock2.action == "Relax")
			{
				this.Actions[this.ID] = StudentActionType.Relax;
			}
			else if (scheduleBlock2.action == "Sit")
			{
				this.Actions[this.ID] = StudentActionType.SitAndTakeNotes;
			}
			else if (scheduleBlock2.action == "Stalk")
			{
				this.Actions[this.ID] = StudentActionType.Stalk;
			}
			else if (scheduleBlock2.action == "SocialSit")
			{
				this.Actions[this.ID] = StudentActionType.SitAndSocialize;
			}
			else if (scheduleBlock2.action == "Eat")
			{
				this.Actions[this.ID] = StudentActionType.SitAndEatBento;
			}
			else if (scheduleBlock2.action == "Shoes")
			{
				this.Actions[this.ID] = StudentActionType.ChangeShoes;
			}
			else if (scheduleBlock2.action == "Grade")
			{
				this.Actions[this.ID] = StudentActionType.GradePapers;
			}
			else if (scheduleBlock2.action == "Patrol")
			{
				this.Actions[this.ID] = StudentActionType.Patrol;
			}
			else if (scheduleBlock2.destination == "Search Patrol")
			{
				this.Actions[this.ID] = StudentActionType.SearchPatrol;
			}
			else if (scheduleBlock2.action == "Read")
			{
				this.Actions[this.ID] = StudentActionType.Read;
			}
			else if (scheduleBlock2.action == "Text")
			{
				this.Actions[this.ID] = StudentActionType.Texting;
			}
			else if (scheduleBlock2.action == "Mourn")
			{
				this.Actions[this.ID] = StudentActionType.Mourn;
			}
			else if (scheduleBlock2.action == "Cuddle")
			{
				this.Actions[this.ID] = StudentActionType.Cuddle;
			}
			else if (scheduleBlock2.action == "Teach")
			{
				this.Actions[this.ID] = StudentActionType.Teaching;
			}
			else if (scheduleBlock2.action == "Club")
			{
				if (this.Club > ClubType.None)
				{
					if (this.Club == ClubType.MartialArts)
					{
						this.Actions[this.ID] = StudentActionType.ClubAction;
					}
					else if (this.Club == ClubType.Occult)
					{
						if (this.StudentID == 26)
						{
							this.Actions[this.ID] = StudentActionType.ClubAction;
						}
						else
						{
							this.Actions[this.ID] = StudentActionType.Read;
						}
					}
				}
				else
				{
					this.Actions[this.ID] = StudentActionType.Socializing;
				}
			}
			this.ID++;
		}
		if (this.StudentID == 7 && (float)StudentGlobals.GetStudentReputation(7) < -33.33333f)
		{
			this.Destinations[2] = this.StudentManager.ShameSpot;
			this.Destinations[4] = this.StudentManager.ShameSpot;
			this.Actions[2] = StudentActionType.Shamed;
			this.Actions[4] = StudentActionType.Shamed;
		}
		if (this.StudentID == 26 && ClubGlobals.GetClubClosed(ClubType.Occult) && StudentGlobals.GetStudentDead(17) && StudentGlobals.GetStudentDead(18))
		{
			this.Destinations[2] = this.StudentManager.Hangouts.List[this.StudentID];
			this.Actions[2] = StudentActionType.Socializing;
		}
		if (this.StudentID == 32 && StudentGlobals.GetStudentBroken(32))
		{
			this.Destinations[2] = this.StudentManager.BrokenSpot;
			this.Destinations[4] = this.StudentManager.BrokenSpot;
			this.Actions[2] = StudentActionType.Shamed;
			this.Actions[4] = StudentActionType.Shamed;
		}
	}

	private void UpdateOutlines()
	{
		this.ID = 0;
		while (this.ID < this.Outlines.Length)
		{
			this.Outlines[this.ID].color = new Color(1f, 0.5f, 0f, 1f);
			this.Outlines[this.ID].enabled = true;
			this.ID++;
		}
	}

	private void PickRandomAnim()
	{
		this.RandomAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		if (this.Actions[this.Phase] == StudentActionType.Socializing && this.DistanceToPlayer < 3f)
		{
			if (!ConversationGlobals.GetTopicDiscovered(11))
			{
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(11, true);
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(11, this.StudentID))
			{
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(11, this.StudentID, true);
			}
		}
	}

	private void BecomeTeacher()
	{
		this.LowPoly.MyMesh = this.LowPoly.TeacherMesh;
		this.GradingPaper = this.StudentManager.FacultyDesks[this.Class];
		this.GradingPaper.LeftHand = this.LeftHand.parent;
		this.GradingPaper.Character = this.Character;
		this.GradingPaper.Teacher = this;
		base.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
		this.StudentManager.Teachers[this.Class] = this;
		this.PantyCollider.enabled = false;
		this.SkirtCollider.gameObject.SetActive(false);
		if (this.Class > 0)
		{
			this.VisionCone.farClipPlane = 12f * this.Paranoia;
			base.name = "Teacher_" + this.Class.ToString();
		}
		else
		{
			this.VisionCone.farClipPlane = 16f * this.Paranoia;
			this.PatrolAnim = "f02_stretch_00";
			this.IdleAnim = "f02_tsunIdle_00";
			base.name = "Coach";
		}
		this.StruggleAnim = "f02_teacherStruggleB_00";
		this.StruggleWonAnim = "f02_teacherStruggleWinB_00";
		this.StruggleLostAnim = "f02_teacherStruggleLoseB_00";
		this.OriginallyTeacher = true;
		this.Spawned = true;
		this.Teacher = true;
	}

	public void RemoveShoes()
	{
		if (this.Schoolwear == 1)
		{
			this.MyRenderer.materials[0].mainTexture = this.SocksTextures[StudentGlobals.FemaleUniform];
			this.MyRenderer.materials[1].mainTexture = this.SocksTextures[StudentGlobals.FemaleUniform];
		}
		else if (this.Schoolwear == 3)
		{
			this.MyRenderer.materials[0].mainTexture = this.SocksTextures[0];
			this.MyRenderer.materials[1].mainTexture = this.SocksTextures[0];
		}
	}

	public void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		IEnumerator enumerator = obj.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj2 = enumerator.Current;
				Transform transform = (Transform)obj2;
				this.SetLayerRecursively(transform.gameObject, newLayer);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		IEnumerator enumerator = obj.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj2 = enumerator.Current;
				Transform transform = (Transform)obj2;
				this.SetTagRecursively(transform.gameObject, newTag);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	public void BecomeRagdoll()
	{
		ParticleSystem.EmissionModule emission = this.Hearts.emission;
		if (this.Following)
		{
			emission.enabled = false;
			this.Yandere.Followers--;
			this.Following = false;
		}
		if (this == this.StudentManager.Reporter)
		{
			this.StudentManager.Reporter = null;
		}
		if (this.Pushed)
		{
			this.Police.SuicideScene = true;
			this.Ragdoll.Suicide = true;
			this.Police.Suicide = true;
		}
		if (!this.Tranquil)
		{
			StudentGlobals.SetStudentDying(this.StudentID, true);
			if (!this.Ragdoll.Burning && !this.Ragdoll.Disturbing)
			{
				this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
				this.Police.Corpses++;
			}
		}
		if (!this.Male)
		{
			this.LiquidProjector.ignoreLayers = -2049;
			this.RightHandCollider.enabled = false;
			this.LeftHandCollider.enabled = false;
			this.PantyCollider.enabled = false;
			this.SkirtCollider.gameObject.SetActive(false);
		}
		this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		this.Ragdoll.AllColliders[10].isTrigger = false;
		this.NotFaceCollider.enabled = false;
		this.FaceCollider.enabled = false;
		this.MyController.enabled = false;
		emission.enabled = false;
		this.SpeechLines.Stop();
		if (this.MyRenderer.enabled)
		{
			this.MyRenderer.updateWhenOffscreen = true;
		}
		this.Pathfinding.enabled = false;
		this.HipCollider.enabled = true;
		base.enabled = false;
		this.UnWet();
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.Hide();
		this.Ragdoll.CharacterAnimation = this.CharacterAnimation;
		this.Ragdoll.DetectionMarker = this.DetectionMarker;
		this.Ragdoll.RightEyeOrigin = this.RightEyeOrigin;
		this.Ragdoll.LeftEyeOrigin = this.LeftEyeOrigin;
		this.Ragdoll.Electrocuted = this.Electrocuted;
		this.Ragdoll.BreastSize = this.BreastSize;
		this.Ragdoll.EyeShrink = this.EyeShrink;
		this.Ragdoll.StudentID = this.StudentID;
		this.Ragdoll.Tranquil = this.Tranquil;
		this.Ragdoll.Burning = this.Burning;
		this.Ragdoll.Drowned = this.Drowned;
		this.Ragdoll.Yandere = this.Yandere;
		this.Ragdoll.Police = this.Police;
		this.Ragdoll.Pushed = this.Pushed;
		this.Ragdoll.Male = this.Male;
		this.Police.Deaths++;
		this.Ragdoll.enabled = true;
		this.Reputation.PendingRep -= this.PendingRep;
		if (this.WitnessedMurder && this.Persona != PersonaType.Evil)
		{
			this.Police.Witnesses--;
		}
		this.UpdateOutlines();
		if (this.DetectionMarker != null)
		{
			this.DetectionMarker.Tex.enabled = false;
		}
		this.SetLayerRecursively(base.gameObject, 11);
		base.tag = "Blood";
	}

	public void GetWet()
	{
		this.LiquidProjector.enabled = true;
		if (this.Gas)
		{
			this.LiquidProjector.material.mainTexture = this.GasTexture;
		}
		else if (this.Bloody)
		{
			this.LiquidProjector.material.mainTexture = this.BloodTexture;
		}
		else
		{
			this.LiquidProjector.material.mainTexture = this.WaterTexture;
		}
		this.ID = 0;
		while (this.ID < this.LiquidEmitters.Length)
		{
			ParticleSystem particleSystem = this.LiquidEmitters[this.ID];
			particleSystem.gameObject.SetActive(true);
			ParticleSystem.MainModule main = particleSystem.main;
			if (this.Gas)
			{
				main.startColor = new Color(1f, 1f, 0f, 1f);
			}
			else if (this.Bloody)
			{
				main.startColor = new Color(1f, 0f, 0f, 1f);
			}
			else
			{
				main.startColor = new Color(0f, 1f, 1f, 1f);
			}
			this.ID++;
		}
		if (!this.Slave)
		{
			if (this.Yandere.Tripping && this.Yandere.Mask == null)
			{
				this.Witnessed = "Accident";
				this.Witness = true;
				this.RepLoss = 10f;
				this.RepDeduction = 0f;
				this.CalculateReputationPenalty();
				if (this.RepDeduction >= 0f)
				{
					this.RepLoss -= this.RepDeduction;
				}
				this.Reputation.PendingRep -= this.RepLoss * this.Paranoia;
				this.PendingRep -= this.RepLoss * this.Paranoia;
			}
			this.CharacterAnimation[this.SplashedAnim].speed = 1f;
			this.CharacterAnimation.CrossFade(this.SplashedAnim);
			this.Subtitle.UpdateLabel(this.RivalPrefix + "Splash Reaction", 0, 1f);
			this.SpeechLines.Stop();
			this.Hearts.Stop();
			this.StopMeeting();
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.SplashTimer = 0f;
			this.SplashPhase = 1;
			this.BathePhase = 1;
			this.ForgetRadio();
			if (this.Distracting)
			{
				this.DistractionTarget.TargetedForDistraction = false;
				this.DistractionTarget.Distracted = false;
				this.Distracting = false;
				this.CanTalk = true;
			}
			this.Distracted = false;
			this.Splashed = true;
			this.Routine = false;
			this.Wet = true;
			if (this.Following)
			{
				this.Yandere.Followers--;
				this.Following = false;
			}
			this.SpawnAlarmDisc();
		}
	}

	public void UnWet()
	{
		this.ID = 0;
		while (this.ID < this.LiquidEmitters.Length)
		{
			this.LiquidEmitters[this.ID].gameObject.SetActive(false);
			this.ID++;
		}
	}

	private void StopMeeting()
	{
		this.Prompt.Label[0].text = "     Talk";
		this.Pathfinding.canSearch = true;
		this.Pathfinding.canMove = true;
		this.StudentManager.OfferHelp.gameObject.SetActive(false);
		this.Drownable = false;
		this.Pushable = false;
		this.Meeting = false;
		this.MeetTimer = 0f;
		if (this.StudentID == 7)
		{
			this.StudentManager.LoveManager.RivalWaiting = false;
		}
	}

	public void Combust()
	{
		this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
		this.Police.Corpses++;
		this.SetLayerRecursively(base.gameObject, 11);
		base.tag = "Blood";
		this.Dying = true;
		this.SpawnAlarmDisc();
		this.Character.GetComponent<Animation>().CrossFade(this.BurningAnim);
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Ragdoll.Burning = true;
		this.WitnessedCorpse = false;
		this.Investigating = false;
		this.DiscCheck = false;
		this.WalkBack = false;
		this.Alarmed = false;
		this.CanTalk = false;
		this.Fleeing = false;
		this.Routine = false;
		this.Reacted = false;
		this.Burning = true;
		this.Wet = false;
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BurningClip;
		component.Play();
		this.LiquidProjector.enabled = false;
		this.UnWet();
		if (this.Following)
		{
			this.Yandere.Followers--;
			this.Following = false;
		}
		this.ID = 0;
		while (this.ID < this.FireEmitters.Length)
		{
			this.FireEmitters[this.ID].gameObject.SetActive(true);
			this.ID++;
		}
		if (this.Attacked)
		{
			this.BurnTarget = this.Yandere.transform.position + this.Yandere.transform.forward;
			this.Attacked = false;
		}
	}

	public void JojoReact()
	{
		UnityEngine.Object.Instantiate<GameObject>(this.JojoHitEffect, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
		if (!this.Dying)
		{
			this.Dying = true;
			this.SpawnAlarmDisc();
			this.Character.GetComponent<Animation>().CrossFade(this.JojoReactAnim);
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.WitnessedCorpse = false;
			this.Investigating = false;
			this.DiscCheck = false;
			this.WalkBack = false;
			this.Alarmed = false;
			this.CanTalk = false;
			this.Fleeing = false;
			this.Routine = false;
			this.Reacted = false;
			this.Wet = false;
			AudioSource component = base.GetComponent<AudioSource>();
			component.Play();
			if (this.Following)
			{
				this.Yandere.Followers--;
				this.Following = false;
			}
		}
	}

	private void Nude()
	{
		if (!this.Male)
		{
			this.PantyCollider.enabled = false;
			this.SkirtCollider.gameObject.SetActive(false);
		}
		this.MyRenderer.sharedMesh = this.BaldNudeMesh;
		if (!this.Male)
		{
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTexture;
			this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
			this.Cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		}
		else
		{
			this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
			this.MyRenderer.materials[1].mainTexture = null;
			this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
		}
		this.Cosmetic.RemoveCensor();
		if (!this.AoT)
		{
			this.ID = 0;
			while (this.ID < this.CensorSteam.Length)
			{
				this.CensorSteam[this.ID].SetActive(true);
				this.ID++;
			}
		}
	}

	public void ChangeSchoolwear()
	{
		this.ID = 0;
		while (this.ID < this.CensorSteam.Length)
		{
			this.CensorSteam[this.ID].SetActive(false);
			this.ID++;
		}
		if (this.Schoolwear == 0)
		{
			this.Nude();
		}
		else if (this.Schoolwear == 1)
		{
			if (!this.Male)
			{
				this.Cosmetic.SetFemaleUniform();
				this.SkirtCollider.gameObject.SetActive(true);
				this.PantyCollider.enabled = true;
			}
			else
			{
				this.Cosmetic.SetMaleUniform();
			}
		}
		else if (this.Schoolwear == 2)
		{
			this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
			this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
			this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
			this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
		}
		else if (this.Schoolwear == 3)
		{
			this.MyRenderer.sharedMesh = this.GymUniform;
			this.MyRenderer.materials[0].mainTexture = this.GymTexture;
			this.MyRenderer.materials[1].mainTexture = this.GymTexture;
			this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
		}
		if (!this.Male)
		{
			this.Cosmetic.Stockings = ((this.Schoolwear != 1) ? string.Empty : this.Cosmetic.OriginalStockings);
			base.StartCoroutine(this.Cosmetic.PutOnStockings());
			if (this.StudentManager.Censor)
			{
				this.Cosmetic.CensorPanties();
			}
		}
		while (this.ID < this.Outlines.Length)
		{
			if (this.Outlines[this.ID].h != null)
			{
				this.Outlines[this.ID].h.ReinitMaterials();
			}
			this.ID++;
		}
	}

	public void AttackOnTitan()
	{
		this.CharacterAnimation.CrossFade(this.WalkAnim);
		this.Phone.SetActive(false);
		this.OnPhone = false;
		this.AoT = true;
		this.MyController.center = new Vector3(this.MyController.center.x, 0.0825f, this.MyController.center.z);
		this.MyController.radius = 0.015f;
		this.MyController.height = 0.15f;
		if (!this.Male)
		{
			this.Cosmetic.FaceTexture = this.TitanFaceTexture;
		}
		else
		{
			this.Cosmetic.FaceTextures[this.SkinColor] = this.TitanFaceTexture;
		}
		this.NudeTexture = this.TitanBodyTexture;
		this.Nude();
		this.ID = 0;
		while (this.ID < this.Outlines.Length)
		{
			OutlineScript outlineScript = this.Outlines[this.ID];
			if (outlineScript.h == null)
			{
				outlineScript.Awake();
			}
			outlineScript.h.ReinitMaterials();
			this.ID++;
		}
		if (!this.Male && !this.Teacher)
		{
			this.PantyCollider.enabled = false;
			this.SkirtCollider.gameObject.SetActive(false);
		}
	}

	public void Spook()
	{
		if (!this.Male)
		{
			this.RightEye.gameObject.SetActive(false);
			this.LeftEye.gameObject.SetActive(false);
			this.MyRenderer.enabled = false;
			this.ID = 0;
			while (this.ID < this.Bones.Length)
			{
				this.Bones[this.ID].SetActive(true);
				this.ID++;
			}
		}
	}

	private void Unspook()
	{
		this.MyRenderer.enabled = true;
		this.ID = 0;
		while (this.ID < this.Bones.Length)
		{
			this.Bones[this.ID].SetActive(false);
			this.ID++;
		}
	}

	private void GoChange()
	{
		this.CurrentDestination = this.StudentManager.StripSpot;
		this.Pathfinding.target = this.StudentManager.StripSpot;
		this.Pathfinding.canSearch = true;
		this.Pathfinding.canMove = true;
		this.Distracted = false;
	}

	public void SpawnAlarmDisc()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity);
		gameObject.GetComponent<AlarmDiscScript>().Male = this.Male;
		gameObject.GetComponent<AlarmDiscScript>().Originator = this;
		if (this.Splashed)
		{
			gameObject.GetComponent<AlarmDiscScript>().Shocking = true;
			gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
		}
		if (this.Struggling)
		{
			gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
		}
		if (this.Dying && this.Yandere.Equipped > 0 && this.Yandere.EquippedWeapon.WeaponID == 7)
		{
			gameObject.GetComponent<AlarmDiscScript>().Long = true;
		}
	}

	public void ChangeClubwear()
	{
		if (!this.ClubAttire)
		{
			this.Cosmetic.RemoveCensor();
			this.ClubAttire = true;
			if (this.Club == ClubType.MartialArts)
			{
				this.MyRenderer.sharedMesh = this.JudoGiMesh;
				if (!this.Male)
				{
					this.MyRenderer.materials[0].mainTexture = this.JudoGiTexture;
					this.MyRenderer.materials[1].mainTexture = this.JudoGiTexture;
					this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
					this.SkirtCollider.gameObject.SetActive(false);
					this.PantyCollider.enabled = false;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.JudoGiTexture;
					this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
					this.MyRenderer.materials[2].mainTexture = this.JudoGiTexture;
				}
			}
			if (this.StudentID == 21)
			{
				this.Armband.transform.localPosition = new Vector3(this.Armband.transform.localPosition.x, this.Armband.transform.localPosition.y, 0.01f);
				this.Armband.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
			}
		}
		else
		{
			this.ClubAttire = false;
			this.ChangeSchoolwear();
			if (this.StudentID == 21)
			{
				this.Armband.transform.localPosition = new Vector3(this.Armband.transform.localPosition.x, this.Armband.transform.localPosition.y, 0.012f);
				this.Armband.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
			}
		}
	}

	public void AttachRiggedAccessory()
	{
		this.RiggedAccessory.GetComponent<RiggedAccessoryAttacher>().ID = this.StudentID;
		if (this.Cosmetic.Accessory > 0)
		{
			this.Cosmetic.FemaleAccessories[this.Cosmetic.Accessory].SetActive(false);
		}
		if (this.StudentID == 26)
		{
			this.MyRenderer.sharedMesh = this.NoArmsNoTorso;
		}
		else if (this.Cosmetic.EyeType == "Gentle")
		{
			this.MyRenderer.sharedMesh = null;
		}
		this.RiggedAccessory.SetActive(true);
	}

	public void CameraReact()
	{
		this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Obstacle.enabled = true;
		this.CameraReacting = true;
		this.CameraReactPhase = 1;
		this.SpeechLines.Stop();
		this.OccultBook.SetActive(false);
		this.SmartPhone.SetActive(false);
		this.Phone.SetActive(false);
		this.Pen.SetActive(false);
		this.Routine = false;
		if (!this.Yandere.ClubAccessories[7].activeInHierarchy)
		{
			this.CharacterAnimation.CrossFade(this.CameraAnims[1]);
		}
		else
		{
			this.CharacterAnimation.CrossFade(this.IdleAnim);
		}
	}

	private void LookForYandere()
	{
		if (!this.Yandere.Chased)
		{
			this.Planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
			if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.GetComponent<Collider>().bounds))
			{
				Debug.DrawLine(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), Color.green);
				RaycastHit raycastHit;
				if (Physics.Linecast(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), out raycastHit) && raycastHit.collider.gameObject == this.Yandere.gameObject)
				{
					this.ReportPhase++;
				}
			}
		}
	}

	public void UpdatePerception()
	{
		if (ClubGlobals.Club == ClubType.Occult || PlayerGlobals.StealthBonus > 0)
		{
			this.Perception = 0.5f;
		}
		else
		{
			this.Perception = 1f;
		}
	}

	public void StopInvestigating()
	{
		UnityEngine.Object.Destroy(this.Giggle);
		this.CurrentDestination = this.Destinations[this.Phase];
		this.Pathfinding.target = this.Destinations[this.Phase];
		this.InvestigationTimer = 0f;
		this.InvestigationPhase = 0;
		this.YandereInnocent = false;
		this.Investigating = false;
		this.DiscCheck = false;
		this.Routine = true;
	}

	public bool InCouple
	{
		get
		{
			return this.CoupleID > 0;
		}
	}

	private bool LovedOneIsTargeted(int yandereTargetID)
	{
		bool flag = this.InCouple && this.CoupleID == yandereTargetID;
		bool flag2 = this.StudentID == 14 && yandereTargetID == 15;
		bool flag3 = this.StudentID == 15 && yandereTargetID == 14;
		bool flag4 = this.StudentID == 17 && yandereTargetID == 18;
		bool flag5 = this.StudentID == 18 && yandereTargetID == 17;
		bool flag6 = this.StudentID == 6 && yandereTargetID == 7;
		bool flag7 = this.StudentID == 7 && yandereTargetID == 6;
		return flag || flag2 || flag3 || flag4 || flag5 || flag6 || flag7;
	}

	private void Pose()
	{
		this.StudentManager.PoseMode.Panel.enabled = true;
		this.StudentManager.PoseMode.Student = this;
		this.StudentManager.PoseMode.UpdateLabels();
		this.StudentManager.PoseMode.Show = true;
		this.DialogueWheel.PromptBar.ClearButtons();
		this.DialogueWheel.PromptBar.Label[0].text = "Confirm";
		this.DialogueWheel.PromptBar.Label[1].text = "Back";
		this.DialogueWheel.PromptBar.Label[4].text = "Change";
		this.DialogueWheel.PromptBar.Label[5].text = "Increase/Decrease";
		this.DialogueWheel.PromptBar.UpdateButtons();
		this.DialogueWheel.PromptBar.Show = true;
		this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
		this.Yandere.CanMove = false;
	}

	public void DisableEffects()
	{
		this.LiquidProjector.enabled = false;
		this.ElectroSteam[0].SetActive(false);
		this.ElectroSteam[1].SetActive(false);
		this.ElectroSteam[2].SetActive(false);
		this.ElectroSteam[3].SetActive(false);
		this.CensorSteam[0].SetActive(false);
		this.CensorSteam[1].SetActive(false);
		this.CensorSteam[2].SetActive(false);
		this.CensorSteam[3].SetActive(false);
		foreach (ParticleSystem particleSystem in this.LiquidEmitters)
		{
			particleSystem.gameObject.SetActive(false);
		}
		foreach (ParticleSystem particleSystem2 in this.FireEmitters)
		{
			particleSystem2.gameObject.SetActive(false);
		}
		this.ID = 0;
		while (this.ID < this.Bones.Length)
		{
			this.Bones[this.ID].SetActive(false);
			this.ID++;
		}
		this.SmartPhone.SetActive(false);
		this.Note.SetActive(false);
		if (!this.Slave)
		{
			this.RightEmptyEye.SetActive(false);
			this.LeftEmptyEye.SetActive(false);
			UnityEngine.Object.Destroy(this.Broken);
		}
	}

	public void DetermineSenpaiReaction()
	{
		Debug.Log("We are now determining Senpai's reaction to Yandere-chan's behavior.");
		if (this.Witnessed == "Weapon and Blood and Insanity")
		{
			this.Subtitle.UpdateLabel("Senpai Insanity Reaction", 1, 4.5f);
		}
		else if (this.Witnessed == "Weapon and Blood")
		{
			this.Subtitle.UpdateLabel("Senpai Weapon Reaction", 1, 4.5f);
		}
		else if (this.Witnessed == "Weapon and Insanity")
		{
			this.Subtitle.UpdateLabel("Senpai Insanity Reaction", 1, 4.5f);
		}
		else if (this.Witnessed == "Blood and Insanity")
		{
			this.Subtitle.UpdateLabel("Senpai Insanity Reaction", 1, 4.5f);
		}
		else if (this.Witnessed == "Weapon")
		{
			this.Subtitle.UpdateLabel("Senpai Weapon Reaction", 1, 4.5f);
		}
		else if (this.Witnessed == "Blood")
		{
			this.Subtitle.UpdateLabel("Senpai Blood Reaction", 1, 4.5f);
		}
		else if (this.Witnessed == "Insanity")
		{
			this.Subtitle.UpdateLabel("Senpai Insanity Reaction", 1, 4.5f);
		}
		else if (this.Witnessed == "Lewd")
		{
			this.Subtitle.UpdateLabel("Senpai Lewd Reaction", 1, 4.5f);
		}
		else if (this.GameOverCause == "Stalking")
		{
			this.Subtitle.UpdateLabel("Senpai Stalking Reaction", this.Concern, 4.5f);
		}
		else if (this.GameOverCause == "Murder")
		{
			this.Subtitle.UpdateLabel("Senpai Murder Reaction", this.MurderReaction, 4.5f);
		}
	}

	public void ForgetRadio()
	{
		this.TurnOffRadio = false;
		this.RadioTimer = 0f;
		this.RadioPhase = 1;
		this.Routine = true;
		this.Radio = null;
	}

	public void RealizePhoneIsMissing()
	{
		ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
		scheduleBlock.destination = "Search Patrol";
		scheduleBlock.action = "Search Patrol";
		this.GetDestinations();
		ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
		scheduleBlock2.destination = "Search Patrol";
		scheduleBlock2.action = "Search Patrol";
		this.GetDestinations();
		ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[6];
		scheduleBlock3.destination = "Search Patrol";
		scheduleBlock3.action = "Search Patrol";
		this.GetDestinations();
		this.Phoneless = true;
	}
}
