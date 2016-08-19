using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
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

	public CosmeticScript Cosmetic;

	public SubtitleScript Subtitle;

	public WeaponScript MyWeapon;

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

	public CharacterController MyController;

	public ParticleSystem BloodFountain;

	public Animation CharacterAnimation;

	public Projector LiquidProjector;

	public ParticleSystem Hearts;

	public Camera VisionCone;

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

	public ParticleSystem[] LiquidEmitters;

	public ParticleSystem[] FireEmitters;

	public string[] DestinationNames;

	public Transform[] Destinations;

	public OutlineScript[] Outlines;

	public GameObject[] Chopsticks;

	public string[] AnimationNames;

	public string[] ActionNames;

	public float[] PhaseTimes;

	public GameObject[] Bones;

	public Transform[] Skirt;

	public Transform[] Arm;

	public LayerMask Mask;

	public Plane[] Planes;

	public int[] Actions;

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

	public GameObject BloodyScream;

	public GameObject DeathScream;

	public GameObject BloodEffect;

	public GameObject BloodSpray;

	public GameObject GreenPhone;

	public GameObject MainCamera;

	public GameObject OccultBook;

	public GameObject AlarmDisc;

	public GameObject Character;

	public GameObject Armband;

	public GameObject Giggle;

	public GameObject Marker;

	public GameObject Bento;

	public GameObject Phone;

	public GameObject Pen;

	public bool OriginallyTeacher;

	public bool WitnessedCorpse;

	public bool WitnessedMurder;

	public bool YandereInnocent;

	public bool RepeatReaction;

	public bool WitnessedBlood;

	public bool YandereVisible;

	public bool FleeWhenClean;

	public bool MurderSuicide;

	public bool BoobsResized;

	public bool ClubActivity;

	public bool Complimented;

	public bool Electrocuted;

	public bool PlayingAudio;

	public bool TurnOffRadio;

	public bool ClubAttire;

	public bool Distracted;

	public bool InDarkness;

	public bool SwitchBack;

	public bool BatheFast;

	public bool DiscCheck;

	public bool DressCode;

	public bool Drownable;

	public bool KnifeDown;

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

	public bool OnPhone;

	public bool Private;

	public bool Reacted;

	public bool SawMask;

	public bool Started;

	public bool Suicide;

	public bool Teacher;

	public bool Witness;

	public bool CanTalk;

	public bool Bloody;

	public bool Routine;

	public bool GoAway;

	public bool Grudge;

	public bool Pushed;

	public bool Warned;

	public bool Slave;

	public bool Dead;

	public bool Halt;

	public bool Lost;

	public bool Male;

	public bool Safe;

	public bool Stop;

	public bool Fed;

	public bool Gas;

	public bool Shy;

	public bool Wet;

	public bool Won;

	public bool DK;

	public bool CameraReacting;

	public bool Investigating;

	public bool Distracting;

	public bool Following;

	public bool Reporting;

	public bool Burning;

	public bool Fleeing;

	public bool Hunting;

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

	public float IgnoreTimer;

	public float ReportTimer;

	public float SplashTimer;

	public float AlarmTimer;

	public float RadioTimer;

	public float StuckTimer;

	public float MeetTimer;

	public float TalkTimer;

	public float WaitTimer;

	public float PreviousEyeShrink;

	public float PreviousAlarm;

	public float RepDeduction;

	public float BreastSize;

	public float Hesitation;

	public float PendingRep;

	public float Perception;

	public float DeltaTime;

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

	public int ClubPhase;

	public int TaskPhase;

	public int ReadPhase;

	public int Phase;

	public int MurdersWitnessed;

	public int OriginalPersona;

	public int WeaponWitnessed;

	public int GossipBonus;

	public int Interaction;

	public int RepRecovery;

	public int Schoolwear;

	public int SkinColor;

	public int RepBonus;

	public int Strength;

	public int Concern;

	public string GameOverCause;

	public string CurrentAnim;

	public string RandomAnim;

	public string Accessory;

	public string Hairstyle;

	public string Witnessed;

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

	public string EvilWitnessAnim;

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

	public string GossipAnim;

	public string SadSitAnim;

	public string BrokenAnim;

	public string BrokenSitAnim;

	public string BrokenWalkAnim;

	public string FistAnim;

	public string AttackAnim;

	public string SuicideAnim;

	public string RelaxAnim;

	public string SitAnim;

	public string ShyAnim;

	public string StalkAnim;

	public string ClubAnim;

	public string StruggleAnim;

	public string StruggleWonAnim;

	public string StruggleLostAnim;

	public string SocialSitAnim;

	public string CarryAnim;

	public string ActivityAnim;

	public string GrudgeAnim;

	public string SadFaceAnim;

	public string CowardAnim;

	public string EvilAnim;

	public string SocialReportAnim;

	public string SocialFearAnim;

	public string SocialTerrorAnim;

	public string BuzzSawDeathAnim;

	public string SwingDeathAnim;

	public string CyborgDeathAnim;

	public string WalkBackAnim;

	public string PatrolAnim;

	public string RadioAnim;

	public string BookSitAnim;

	public string BookReadAnim;

	public string LovedOneAnim;

	public string[] CameraAnims;

	public string[] SocialAnims;

	public string[] CowardAnims;

	public string[] EvilAnims;

	public string[] HeroAnims;

	public string[] TaskAnims;

	public int ClubMemberID;

	public int ReportPhase;

	public int RadioPhase;

	public int StudentID;

	public int PatrolID;

	public int Persona;

	public int Class;

	public int Club;

	public int ID;

	public Vector3 LastKnownCorpse;

	public Vector3 DistractionSpot;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Vector3 LastPosition;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform RightEye;

	public Transform LeftEye;

	private float MaxSpeed;

	public Texture[] SocksTextures;

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

	public StudentScript()
	{
		this.CanTalk = true;
		this.Routine = true;
		this.Perception = 1f;
		this.SkinColor = 3;
		this.GameOverCause = string.Empty;
		this.CurrentAnim = string.Empty;
		this.RandomAnim = string.Empty;
		this.Accessory = string.Empty;
		this.Hairstyle = string.Empty;
		this.Witnessed = string.Empty;
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
		this.EvilWitnessAnim = string.Empty;
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
		this.GossipAnim = string.Empty;
		this.SadSitAnim = string.Empty;
		this.BrokenAnim = string.Empty;
		this.BrokenSitAnim = string.Empty;
		this.BrokenWalkAnim = string.Empty;
		this.FistAnim = string.Empty;
		this.AttackAnim = string.Empty;
		this.SuicideAnim = string.Empty;
		this.RelaxAnim = string.Empty;
		this.SitAnim = string.Empty;
		this.ShyAnim = string.Empty;
		this.StalkAnim = string.Empty;
		this.ClubAnim = string.Empty;
		this.StruggleAnim = string.Empty;
		this.StruggleWonAnim = string.Empty;
		this.StruggleLostAnim = string.Empty;
		this.SocialSitAnim = string.Empty;
		this.CarryAnim = string.Empty;
		this.ActivityAnim = string.Empty;
		this.GrudgeAnim = string.Empty;
		this.SadFaceAnim = string.Empty;
		this.CowardAnim = string.Empty;
		this.EvilAnim = string.Empty;
		this.SocialReportAnim = string.Empty;
		this.SocialFearAnim = string.Empty;
		this.SocialTerrorAnim = string.Empty;
		this.BuzzSawDeathAnim = string.Empty;
		this.SwingDeathAnim = string.Empty;
		this.CyborgDeathAnim = string.Empty;
		this.WalkBackAnim = string.Empty;
		this.PatrolAnim = string.Empty;
		this.RadioAnim = string.Empty;
		this.BookSitAnim = string.Empty;
		this.BookReadAnim = string.Empty;
		this.LovedOneAnim = string.Empty;
		this.RadioPhase = 1;
		this.MaxSpeed = 10f;
	}

	public virtual void Start()
	{
		if (!this.Started)
		{
			this.CharacterAnimation = this.Character.animation;
			if (PlayerPrefs.GetFloat("SchoolAtmosphere") <= 33.33333f)
			{
				this.IdleAnim = this.ParanoidAnim;
			}
			if (PlayerPrefs.GetInt("Club") == 3)
			{
				this.Perception = 0.5f;
			}
			this.Hearts.emissionRate = (float)PlayerPrefs.GetInt("Seduction");
			this.Hearts.enableEmission = false;
			this.Paranoia = (float)2 - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f;
			if (PlayerPrefs.GetInt("PantiesEquipped") == 4)
			{
				this.VisionCone.farClipPlane = (float)5 * this.Paranoia;
			}
			else
			{
				this.VisionCone.farClipPlane = (float)10 * this.Paranoia;
			}
			if (GameObject.Find("DetectionCamera") != null)
			{
				this.DetectionMarker = (DetectionMarkerScript)((GameObject)UnityEngine.Object.Instantiate(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity)).GetComponent(typeof(DetectionMarkerScript));
				this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
				this.DetectionMarker.Target = this.transform;
			}
			this.PhaseTimes = (float[])this.JSON.StudentTimes[this.StudentID].ToBuiltin(typeof(float));
			this.Persona = this.JSON.StudentPersonas[this.StudentID];
			this.Class = this.JSON.StudentClasses[this.StudentID];
			this.Club = this.JSON.StudentClubs[this.StudentID];
			this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
			this.Strength = this.JSON.StudentStrengths[this.StudentID];
			this.Hairstyle = this.JSON.StudentHairstyles[this.StudentID];
			this.Accessory = this.JSON.StudentAccessories[this.StudentID];
			this.Name = this.JSON.StudentNames[this.StudentID];
			this.DestinationNames = (string[])this.JSON.StudentDestinations[this.StudentID].ToBuiltin(typeof(string));
			this.ActionNames = (string[])this.JSON.StudentActions[this.StudentID].ToBuiltin(typeof(string));
			this.gameObject.name = "Student_" + this.StudentID + " (" + this.Name + ")";
			this.OriginalPersona = this.Persona;
			if (this.Persona == 1 || this.Persona == 4)
			{
				this.CameraAnims = this.CowardAnims;
			}
			else if (this.Persona == 2 || this.Persona == 3 || this.Persona == 9)
			{
				this.CameraAnims = this.HeroAnims;
			}
			else if (this.Persona == 5)
			{
				this.CameraAnims = this.EvilAnims;
			}
			else if (this.Persona == 6)
			{
				this.CameraAnims = this.SocialAnims;
			}
			this.Phone.active = true;
			if (PlayerPrefs.GetInt("Club_" + this.Club + "_Closed") == 1)
			{
				this.Club = 0;
			}
			this.DialogueWheel = (DialogueWheelScript)GameObject.Find("DialogueWheel").GetComponent(typeof(DialogueWheelScript));
			this.ClubManager = (ClubManagerScript)GameObject.Find("ClubManager").GetComponent(typeof(ClubManagerScript));
			this.Reputation = (ReputationScript)GameObject.Find("Reputation").GetComponent(typeof(ReputationScript));
			this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
			this.Police = (PoliceScript)GameObject.Find("Police").GetComponent(typeof(PoliceScript));
			this.Clock = (ClockScript)GameObject.Find("Clock").GetComponent(typeof(ClockScript));
			this.MainCamera = GameObject.Find("MainCamera");
			this.Subtitle = this.Yandere.Subtitle;
			this.ShoulderCamera = (ShoulderCameraScript)this.MainCamera.GetComponent(typeof(ShoulderCameraScript));
			this.CameraEffects = (CameraEffectsScript)this.MainCamera.GetComponent(typeof(CameraEffectsScript));
			this.RightEyeOrigin = this.RightEye.localPosition;
			this.LeftEyeOrigin = this.LeftEye.localPosition;
			this.PickRandomAnim();
			this.OccultBook.active = false;
			if (!this.Male)
			{
				this.CharacterAnimation[this.StripAnim].speed = 1.5f;
				this.CharacterAnimation[this.GameAnim].speed = (float)2;
				if (this.Club > 99)
				{
					this.BecomeTeacher();
				}
				this.CharacterAnimation[this.CarryAnim].layer = 9;
				this.CharacterAnimation.Play(this.CarryAnim);
				this.CharacterAnimation[this.CarryAnim].weight = (float)0;
				this.CharacterAnimation[this.SocialSitAnim].layer = 8;
				this.CharacterAnimation.Play(this.SocialSitAnim);
				this.CharacterAnimation[this.SocialSitAnim].weight = (float)0;
				this.CharacterAnimation[this.ShyAnim].layer = 7;
				this.CharacterAnimation.Play(this.ShyAnim);
				this.CharacterAnimation[this.ShyAnim].weight = (float)0;
				this.CharacterAnimation[this.FistAnim].layer = 6;
				this.CharacterAnimation[this.FistAnim].weight = (float)0;
				this.CharacterAnimation[this.WetAnim].layer = 4;
				this.CharacterAnimation.Play(this.WetAnim);
				this.CharacterAnimation[this.WetAnim].weight = (float)0;
				this.CharacterAnimation[this.BentoAnim].layer = 3;
				this.CharacterAnimation.Play(this.BentoAnim);
				this.CharacterAnimation[this.BentoAnim].weight = (float)0;
				this.CharacterAnimation[this.AngryFaceAnim].layer = 2;
				this.CharacterAnimation.Play(this.AngryFaceAnim);
				this.CharacterAnimation[this.AngryFaceAnim].weight = (float)0;
				if (!this.Slave)
				{
					this.CharacterAnimation.Play(this.PhoneAnim);
					this.RightEmptyEye.active = false;
					this.LeftEmptyEye.active = false;
					UnityEngine.Object.Destroy(this.Broken);
				}
				this.CharacterAnimation["f02_wetIdle_00"].speed = 1.25f;
				if (!this.Teacher)
				{
					if (this.Persona == 5)
					{
						this.ScaredAnim = this.EvilWitnessAnim;
					}
					this.CharacterAnimation[this.CameraAnims[1]].speed = (float)2;
					this.CharacterAnimation[this.CameraAnims[3]].speed = (float)2;
				}
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
				while (this.ID < Extensions.get_length(this.FireEmitters))
				{
					this.FireEmitters[this.ID].gameObject.active = false;
					this.ID++;
				}
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.Bones))
				{
					this.Bones[this.ID].active = false;
					this.ID++;
				}
				this.GreenPhone.active = false;
			}
			else
			{
				this.CharacterAnimation["scaredFace_00"].layer = 4;
				this.CharacterAnimation.Play("scaredFace_00");
				this.CharacterAnimation["scaredFace_00"].weight = (float)0;
				this.CharacterAnimation[this.SadFaceAnim].layer = 3;
				this.CharacterAnimation.Play(this.SadFaceAnim);
				this.CharacterAnimation[this.SadFaceAnim].weight = (float)0;
				this.CharacterAnimation[this.AngryFaceAnim].layer = 2;
				this.CharacterAnimation.Play(this.AngryFaceAnim);
				this.CharacterAnimation[this.AngryFaceAnim].weight = (float)0;
			}
			if (this.StudentID == 17)
			{
				if (PlayerPrefs.GetInt("Student_18_Dead") == 1)
				{
					this.DestinationNames[2] = "Mourn";
					this.ActionNames[2] = "Mourn";
				}
			}
			else if (this.StudentID == 18 && PlayerPrefs.GetInt("Student_17_Dead") == 1)
			{
				this.DestinationNames[2] = "Mourn";
				this.ActionNames[2] = "Mourn";
			}
			if (this.Club == 3)
			{
				if (this.StudentID == 26)
				{
					if (PlayerPrefs.GetInt("Student_17_Dead") == 1 && PlayerPrefs.GetInt("Student_18_Dead") == 1)
					{
						this.DestinationNames[2] = "Club";
						this.ActionNames[2] = "Club";
					}
					this.ClubAnim = this.IdleAnim;
					this.Shy = true;
				}
				else if (this.Male)
				{
					this.CharacterAnimation[this.SadFaceAnim].weight = (float)1;
				}
			}
			else if (this.Club == 6)
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
			this.GetDestinations();
			if (this.AoT)
			{
				this.AttackOnTitan();
			}
			else
			{
				this.OnPhone = true;
			}
			if (this.Slave)
			{
				this.NEStairs = (Collider)GameObject.Find("NEStairs").GetComponent(typeof(Collider));
				this.NWStairs = (Collider)GameObject.Find("NWStairs").GetComponent(typeof(Collider));
				this.SEStairs = (Collider)GameObject.Find("SEStairs").GetComponent(typeof(Collider));
				this.SWStairs = (Collider)GameObject.Find("SWStairs").GetComponent(typeof(Collider));
				this.IdleAnim = this.BrokenAnim;
				this.WalkAnim = this.BrokenWalkAnim;
				this.Phone.active = false;
				this.OnPhone = false;
				this.Indoors = true;
				this.Safe = false;
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.PhaseTimes))
				{
					this.PhaseTimes[this.ID] = (float)0;
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
			if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Grudge") == 1)
			{
				if (this.Persona != 4 && this.Persona != 5)
				{
					this.CameraAnims = this.EvilAnims;
					this.Reputation.PendingRep = this.Reputation.PendingRep - (float)10;
					this.PendingRep -= (float)10;
					this.ID = 0;
					while (this.ID < Extensions.get_length(this.Outlines))
					{
						this.Outlines[this.ID].color = new Color((float)1, (float)1, (float)0, (float)1);
						this.ID++;
					}
				}
				this.Grudge = true;
				this.CameraAnims = this.EvilAnims;
			}
			if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Broken") == 1)
			{
				this.Cosmetic.RightEyeRenderer.gameObject.active = false;
				this.Cosmetic.LeftEyeRenderer.gameObject.active = false;
				this.Cosmetic.RightIrisLight.active = false;
				this.Cosmetic.LeftIrisLight.active = false;
				this.RightEmptyEye.active = true;
				this.LeftEmptyEye.active = true;
				this.Shy = true;
			}
			if (this.Club != 0 && (this.StudentID == 21 || this.StudentID == 26))
			{
				this.Armband.active = true;
			}
			if (!this.Teacher)
			{
				this.CurrentDestination = this.StudentManager.EntranceVectors.List[this.StudentID];
				this.Pathfinding.target = this.StudentManager.EntranceVectors.List[this.StudentID];
			}
			else
			{
				this.Indoors = true;
			}
			if (this.StudentID == 1 || this.StudentID == 19)
			{
				this.BookRenderer.material.mainTexture = this.RedBookTexture;
			}
			this.Started = true;
		}
	}

	public virtual void Update()
	{
		this.DeltaTime = Time.deltaTime;
		if (!this.Stop)
		{
			this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
			if (this.DistanceToPlayer < (float)1 && this.Yandere.EbolaHair.active && !this.Dead)
			{
				UnityEngine.Object.Instantiate(this.Yandere.EbolaEffect, this.transform.position + Vector3.up, Quaternion.identity);
				this.SpawnAlarmDisc();
				this.BecomeRagdoll();
				this.Dead = true;
			}
			if (this.Routine)
			{
				if (this.CurrentDestination != null)
				{
					this.DistanceToDestination = Vector3.Distance(this.transform.position, this.CurrentDestination.position);
				}
				if (!this.Indoors)
				{
					if (this.Phase == 0)
					{
						if (this.DistanceToDestination < (float)1)
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
				else if (this.Phase < Extensions.get_length(this.PhaseTimes) - 1 && this.Clock.HourTime >= this.PhaseTimes[this.Phase] && !this.InEvent && !this.Meeting)
				{
					this.Phase++;
					if (this.Schoolwear > 1 && this.Destinations[this.Phase] == this.MyLocker)
					{
						this.Phase++;
					}
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					if (this.CurrentDestination != null)
					{
						this.DistanceToDestination = Vector3.Distance(this.transform.position, this.CurrentDestination.position);
					}
					if (this.Bento != null && this.Bento.active)
					{
						this.Bento.active = false;
						this.Chopsticks[0].active = false;
						this.Chopsticks[1].active = false;
					}
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.GoAway = false;
					this.ReadPhase = 0;
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
				if (this.DistanceToDestination > this.TargetDistance)
				{
					if (!this.InEvent && !this.Meeting && this.DressCode)
					{
						if (this.Actions[this.Phase] == 8)
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
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Obstacle.enabled = false;
					}
					if (this.Pathfinding.speed == (float)1)
					{
						if (!this.OnPhone)
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
							this.CharacterAnimation[this.WalkAnim].speed = this.Pathfinding.currentSpeed;
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.PhoneAnim);
							this.CharacterAnimation[this.PhoneAnim].speed = this.Pathfinding.currentSpeed;
						}
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.SprintAnim);
					}
					if (this.Club == 3 && this.Actions[this.Phase] != 8)
					{
						this.OccultBook.active = false;
					}
				}
				else
				{
					if (this.CurrentDestination != null)
					{
						this.MoveTowardsTarget(this.CurrentDestination.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, (float)10 * this.DeltaTime);
					}
					if (this.Pathfinding.canMove)
					{
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
					}
					if (!this.InEvent && !this.Meeting && this.DressCode)
					{
						if (this.Actions[this.Phase] == 8)
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
								if (this.Actions[this.Phase] == 0)
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
								}
								else if (this.Actions[this.Phase] == 1)
								{
									if (PlayerPrefs.GetFloat("SchoolAtmosphere") < 33.33333f)
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.RandomAnim);
										if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
										{
											this.PickRandomAnim();
										}
									}
								}
								else if (this.Actions[this.Phase] == 2)
								{
									this.CharacterAnimation.CrossFade(this.GameAnim);
								}
								else if (this.Actions[this.Phase] == 3)
								{
									this.CharacterAnimation.CrossFade(this.SadSitAnim);
								}
								else if (this.Actions[this.Phase] == 4)
								{
									this.CharacterAnimation.CrossFade(this.BrokenSitAnim);
								}
								else if (this.Actions[this.Phase] == 5)
								{
									this.CharacterAnimation.CrossFade(this.RelaxAnim);
								}
								else if (this.Actions[this.Phase] == 6)
								{
									if (this.DressCode && this.ClubAttire)
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.SitAnim);
									}
								}
								else if (this.Actions[this.Phase] == 7)
								{
									this.CharacterAnimation.CrossFade(this.StalkAnim);
								}
								else if (this.Actions[this.Phase] == 8)
								{
									if (this.DressCode && !this.ClubAttire)
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.ClubAnim);
									}
									if (this.Club == 3 && this.StudentID != 26)
									{
										this.OccultBook.active = true;
									}
								}
								else if (this.Actions[this.Phase] == 9)
								{
									if (PlayerPrefs.GetFloat("SchoolAtmosphere") < 33.33333f)
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.RandomAnim);
										if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
										{
											this.PickRandomAnim();
										}
									}
								}
								else if (this.Actions[this.Phase] == 10)
								{
									this.CharacterAnimation.CrossFade(this.EatAnim);
									if (!this.Bento.active)
									{
										this.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, (float)0);
										this.Bento.transform.localEulerAngles = new Vector3((float)0, (float)165, 82.5f);
										this.Chopsticks[0].active = true;
										this.Chopsticks[1].active = true;
										this.Bento.active = true;
									}
								}
								else if (this.Actions[this.Phase] == 11)
								{
									if (this.MeetTime == (float)0)
									{
										this.Pathfinding.canSearch = false;
										this.Pathfinding.canMove = false;
										this.ShoeRemoval.enabled = true;
										this.Routine = false;
										this.ShoeRemoval.LeavingSchool();
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
									}
								}
								else if (this.Actions[this.Phase] == 12)
								{
									this.CharacterAnimation.CrossFade("f02_deskWrite");
									this.GradingPaper.Writing = true;
									this.Obstacle.enabled = true;
									this.Pen.active = true;
								}
								else if (this.Actions[this.Phase] == 13)
								{
									this.CharacterAnimation.CrossFade(this.PatrolAnim);
									if (this.CharacterAnimation[this.PatrolAnim].time >= this.CharacterAnimation[this.PatrolAnim].length)
									{
										this.PatrolID++;
										if (this.PatrolID == this.StudentManager.Patrols.List[this.StudentID].childCount)
										{
											this.PatrolID = 0;
										}
										this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
										this.Pathfinding.target = this.CurrentDestination;
									}
								}
								else if (this.Actions[this.Phase] == 14)
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
										else if (this.CharacterAnimation[this.BookSitAnim].time > (float)1)
										{
											this.OccultBook.active = true;
										}
									}
								}
								else if (this.Actions[this.Phase] == 15)
								{
									this.CharacterAnimation.CrossFade("f02_texting_00");
									if (!this.GreenPhone.active && this.transform.position.y > (float)11)
									{
										this.GreenPhone.active = true;
									}
								}
								else if (this.Actions[this.Phase] == 16)
								{
									this.CharacterAnimation.CrossFade("f02_brokenSit_00");
								}
							}
							else
							{
								this.CharacterAnimation.CrossFade(this.IdleAnim);
								this.GoAwayTimer += this.DeltaTime;
								if (this.GoAwayTimer > (float)60)
								{
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
									this.GoAwayTimer = (float)0;
									this.GoAway = false;
								}
							}
						}
						else
						{
							if (this.MeetTimer == (float)0)
							{
								if (PlayerPrefs.GetInt("7_Friend") == 1 && (this.CurrentDestination == this.StudentManager.MeetSpots.List[8] || this.CurrentDestination == this.StudentManager.MeetSpots.List[9] || this.CurrentDestination == this.StudentManager.MeetSpots.List[10]))
								{
									this.StudentManager.OfferHelp.UpdateLocation();
									this.StudentManager.OfferHelp.enabled = true;
								}
								if (this.transform.position.y > (float)11)
								{
									this.Prompt.Label[0].text = "     " + "Push";
									this.Pushable = true;
								}
								if (this.CurrentDestination == this.StudentManager.FountainSpot)
								{
									this.Prompt.Label[0].text = "     " + "Drown";
									this.Drownable = true;
								}
							}
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.MeetTimer += this.DeltaTime;
							if (this.MeetTimer > (float)60)
							{
								this.Subtitle.UpdateLabel("Note Reaction", 4, (float)3);
								while (this.Clock.HourTime >= this.PhaseTimes[this.Phase])
								{
									this.Phase++;
								}
								this.CurrentDestination = this.Destinations[this.Phase];
								this.Pathfinding.target = this.Destinations[this.Phase];
								this.Prompt.Label[0].text = "     Talk";
								this.Pathfinding.canSearch = true;
								this.Pathfinding.canMove = true;
								this.StudentManager.OfferHelp.active = false;
								this.Drownable = false;
								this.Pushable = false;
								this.Meeting = false;
								this.MeetTimer = (float)0;
							}
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
				if (this.Fleeing)
				{
					if (this.Yandere.Chased)
					{
						this.Pathfinding.speed = this.Pathfinding.speed + this.DeltaTime;
					}
					this.DistanceToDestination = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
					if (this.AlarmTimer > (float)0)
					{
						this.AlarmTimer = Mathf.MoveTowards(this.AlarmTimer, (float)0, this.DeltaTime);
						this.CharacterAnimation.CrossFade(this.ScaredAnim);
						if (this.AlarmTimer == (float)0)
						{
							this.WalkBack = false;
							this.Alarmed = false;
						}
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						if (this.WitnessedMurder)
						{
							this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
							this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
						}
						else if (this.WitnessedCorpse)
						{
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, this.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - this.transform.position);
							this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
						}
					}
					else
					{
						if (this.Persona == 2 && this.StudentManager.Reporter == null && !this.Police.Called)
						{
							this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
							this.StudentManager.Reporter = this;
							this.Reporting = true;
						}
						if (this.transform.position.y < (float)-2)
						{
							if (this.Persona != 4 && this.Persona != 5)
							{
								this.Police.Witnesses = this.Police.Witnesses - 1;
								this.Police.Show = true;
							}
							this.active = false;
						}
						if (this.transform.position.z < -49.335f)
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
								if (!this.Teacher)
								{
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Pathfinding.target.rotation, (float)10 * this.DeltaTime);
								}
							}
							else if (this.Persona == 2)
							{
								this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Teachers[this.Class].transform.position.x, this.transform.position.y, this.StudentManager.Teachers[this.Class].transform.position.z) - this.transform.position);
								this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
							}
							if (this.Persona == 2)
							{
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
										this.CharacterAnimation.CrossFade(this.ScaredAnim);
										if (this.WitnessedCorpse)
										{
											this.Subtitle.UpdateLabel("Pet Corpse Report", 2, (float)3);
										}
										else
										{
											this.Subtitle.UpdateLabel("Pet Murder Report", 2, (float)3);
										}
										this.StudentManager.Teachers[this.Class].CharacterAnimation.CrossFade(this.StudentManager.Teachers[this.Class].IdleAnim);
										this.StudentManager.Teachers[this.Class].Routine = false;
										this.Halt = true;
										this.ReportPhase++;
									}
									else if (this.ReportPhase == 1)
									{
										this.CharacterAnimation.CrossFade(this.ScaredAnim);
										this.StudentManager.Teachers[this.Class].targetRotation = Quaternion.LookRotation(this.transform.position - this.StudentManager.Teachers[this.Class].transform.position);
										this.StudentManager.Teachers[this.Class].transform.rotation = Quaternion.Slerp(this.StudentManager.Teachers[this.Class].transform.rotation, this.StudentManager.Teachers[this.Class].targetRotation, (float)10 * this.DeltaTime);
										this.ReportTimer += this.DeltaTime;
										if (this.ReportTimer >= (float)3)
										{
											float y = this.transform.position.y + 0.1f;
											Vector3 position = this.transform.position;
											float num = position.y = y;
											Vector3 vector = this.transform.position = position;
											this.StudentManager.Teachers[this.Class].MyReporter = this.transform;
											this.StudentManager.Teachers[this.Class].Routine = false;
											this.StudentManager.Teachers[this.Class].Fleeing = true;
											this.ReportTimer = (float)0;
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
										this.ReportTimer += this.DeltaTime;
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
											this.ID = 0;
											while (this.ID < Extensions.get_length(this.Outlines))
											{
												this.Outlines[this.ID].color = new Color((float)1, (float)1, (float)0, (float)1);
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
							else if (this.Persona == 3)
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
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Yandere.transform.rotation, (float)10 * this.DeltaTime);
									this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.425f);
									if (!this.Yandere.Armed || !this.Yandere.Weapon[this.Yandere.Equipped].Concealable)
									{
										this.Yandere.StruggleBar.HeroWins();
									}
									if (this.Lost)
									{
										this.CharacterAnimation.CrossFade(this.StruggleWonAnim);
										if (this.CharacterAnimation[this.StruggleWonAnim].time > (float)1)
										{
											this.EyeShrink = (float)1;
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
							}
							else if (this.Persona == 4)
							{
								this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
								this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
								this.CharacterAnimation.CrossFade(this.CowardAnim);
								this.ReactionTimer += this.DeltaTime;
								if (this.ReactionTimer > (float)5)
								{
									this.CurrentDestination = this.StudentManager.Exit;
									this.Pathfinding.target = this.StudentManager.Exit;
								}
							}
							else if (this.Persona == 5)
							{
								this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
								this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
								this.CharacterAnimation.CrossFade(this.EvilAnim);
								this.ReactionTimer += this.DeltaTime;
								if (this.ReactionTimer > (float)5)
								{
									this.CurrentDestination = this.StudentManager.Exit;
									this.Pathfinding.target = this.StudentManager.Exit;
								}
							}
							else if (this.Persona == 6)
							{
								if (this.ReportPhase < 4)
								{
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Pathfinding.target.rotation, (float)10 * this.DeltaTime);
								}
								if (this.ReportPhase == 1)
								{
									if (!this.Phone.active)
									{
										if (this.StudentManager.Reporter == null && !this.Police.Called)
										{
											this.CharacterAnimation.CrossFade(this.SocialReportAnim);
											this.Subtitle.UpdateLabel("Social Report", 1, (float)5);
											this.StudentManager.Reporter = this;
											this.Phone.active = true;
										}
										else
										{
											this.ReportTimer = (float)5;
										}
									}
									this.ReportTimer += this.DeltaTime;
									if (this.ReportTimer > (float)5)
									{
										if (this.StudentManager.Reporter == this)
										{
											this.Police.Called = true;
											this.Police.Show = true;
										}
										this.CharacterAnimation.CrossFade(this.ParanoidAnim);
										this.Phone.active = false;
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
									this.Subtitle.UpdateLabel("Social Fear", 1, (float)5);
									this.SpawnAlarmDisc();
									this.ReportPhase++;
								}
								else if (this.ReportPhase == 4)
								{
									this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
									if (this.Yandere.Attacking)
									{
										this.LookForYandere();
									}
								}
								else if (this.ReportPhase == 5)
								{
									this.CharacterAnimation.CrossFade(this.SocialTerrorAnim);
									this.Subtitle.UpdateLabel("Social Terror", 1, (float)5);
									this.VisionCone.farClipPlane = (float)0;
									this.SpawnAlarmDisc();
									this.ReportPhase++;
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
										this.CharacterAnimation.CrossFade(this.IdleAnim);
										this.ReportTimer += this.DeltaTime;
										if (this.ReportTimer >= (float)3)
										{
											float y2 = this.transform.position.y + 0.1f;
											Vector3 position2 = this.transform.position;
											float num2 = position2.y = y2;
											Vector3 vector2 = this.transform.position = position2;
											if (this.StudentManager.CorpseLocation.position == new Vector3((float)0, (float)0, (float)0))
											{
												this.StudentManager.CorpseLocation.position = this.StudentManager.Reporter.LastKnownCorpse;
												this.StudentManager.LowerCorpsePostion();
											}
											if (!this.StudentManager.Reporter.Teacher)
											{
												this.StudentManager.Reporter.Pathfinding.target = this.StudentManager.CorpseLocation;
											}
											this.Pathfinding.target = this.StudentManager.CorpseLocation;
											this.StudentManager.Reporter.TargetDistance = (float)2;
											this.TargetDistance = (float)1;
											this.ReportTimer = (float)0;
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase == 2)
									{
										if (this.WitnessedCorpse)
										{
											if (!this.Corpse.Poisoned)
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
											this.CharacterAnimation.CrossFade(this.IdleAnim);
											this.ReportTimer += this.DeltaTime;
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
										this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, this.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - this.transform.position);
										this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
										this.CharacterAnimation.CrossFade(this.KneelAnim);
										this.ReportTimer += this.DeltaTime;
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
										this.CharacterAnimation.CrossFade(this.CallAnim);
										this.ReportTimer += this.DeltaTime;
										if (this.ReportTimer >= (float)5)
										{
											if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.Corpse, "Natural"), true))
											{
												this.Police.Timer = 1E-06f;
											}
											this.CharacterAnimation.CrossFade(this.KneelScanAnim);
											this.Phone.active = false;
											this.Police.Called = true;
											this.Police.Show = true;
											this.Fleeing = false;
											this.Reacted = false;
											this.ReportTimer = (float)0;
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase == 98)
									{
										this.targetRotation = Quaternion.LookRotation(this.MyReporter.transform.position - this.transform.position);
										this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
										this.ReportTimer += this.DeltaTime;
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
									if (PlayerPrefs.GetInt("PhysicalGrade") + PlayerPrefs.GetInt("PhysicalBonus") == 0)
									{
										Debug.Log("A teacher is taking down Yandere-chan.");
										if (this.Yandere.Aiming)
										{
											this.Yandere.StopAiming();
										}
										this.Yandere.Mopping = false;
										this.Yandere.EmptyHands();
										this.AttackReaction();
										this.CharacterAnimation[this.CounterAnim].time = (float)5;
										this.Yandere.CharacterAnimation["f02_counterA_00"].time = (float)5;
										this.Yandere.ShoulderCamera.DoNotMove = true;
										this.Yandere.ShoulderCamera.Timer = (float)5;
										this.Yandere.ShoulderCamera.Phase = 3;
										this.Police.Show = false;
										this.Yandere.CameraEffects.MurderWitnessed();
										this.Yandere.Jukebox.GameOver();
									}
									else
									{
										this.Persona = 3;
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
								}
							}
						}
					}
				}
				if (this.Following && !this.Waiting)
				{
					this.DistanceToDestination = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
					if (this.DistanceToDestination > (float)2)
					{
						this.CharacterAnimation.CrossFade(this.RunAnim);
						this.Pathfinding.speed = (float)4;
						this.Obstacle.enabled = false;
					}
					else if (this.DistanceToDestination > (float)1)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.Pathfinding.canMove = true;
						this.Pathfinding.speed = (float)1;
						this.Obstacle.enabled = false;
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Pathfinding.canMove = false;
						this.Obstacle.enabled = true;
					}
					if (this.Phase < Extensions.get_length(this.PhaseTimes) - 1 && this.Clock.HourTime >= this.PhaseTimes[this.Phase])
					{
						this.Phase++;
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
						this.Hearts.enableEmission = false;
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
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, this.DeltaTime * (float)10);
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
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, this.DeltaTime * (float)10);
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
										this.MyController.radius = (float)0;
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
									if (!this.InEvent)
									{
										this.Schoolwear = 3;
									}
									else
									{
										this.Schoolwear = 1;
									}
									this.BathePhase++;
								}
								else if (this.BathePhase == 8)
								{
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, this.DeltaTime * (float)10);
									this.MoveTowardsTarget(this.CurrentDestination.position);
								}
								else if (this.BathePhase == 9)
								{
									this.StudentManager.CommunalLocker.Open = false;
									if (this.Phase == 1)
									{
										this.Phase++;
									}
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
									this.Routine = true;
									this.Wet = false;
									if (this.FleeWhenClean)
									{
										this.CurrentDestination = this.StudentManager.Exit;
										this.Pathfinding.target = this.StudentManager.Exit;
										this.TargetDistance = (float)0;
										this.Routine = false;
										this.Fleeing = true;
									}
								}
							}
							else if (this.BathePhase == -1)
							{
								this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
								this.Subtitle.UpdateLabel("Light Switch Reaction", 2, (float)5);
								this.CharacterAnimation.CrossFade("f02_electrocution_00");
								this.Pathfinding.canSearch = false;
								this.Pathfinding.canMove = false;
								this.Distracted = true;
								this.BathePhase++;
							}
							else if (this.BathePhase == 0)
							{
								this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, this.DeltaTime * (float)10);
								this.MoveTowardsTarget(this.CurrentDestination.position);
								if (this.CharacterAnimation["f02_electrocution_00"].time > (float)2 && this.CharacterAnimation["f02_electrocution_00"].time < 5.95f)
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
										this.CharacterAnimation.CrossFade(this.WalkAnim);
										this.BathePhase++;
										this.LightSwitch.Prompt.Label[0].text = "     " + "Turn Off";
										this.LightSwitch.BathroomLight.active = true;
										this.LightSwitch.audio.clip = this.LightSwitch.Flick[0];
										this.LightSwitch.audio.Play();
										this.InDarkness = false;
									}
									else
									{
										if (!this.LightSwitch.Flicker)
										{
											this.CharacterAnimation["f02_electrocution_00"].speed = 0.85f;
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
										this.RightDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
										this.LeftDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
										this.ElectroTimer += this.DeltaTime;
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
								else if (this.CharacterAnimation["f02_electrocution_00"].time > 5.95f && this.CharacterAnimation["f02_electrocution_00"].time < this.CharacterAnimation["f02_electrocution_00"].length)
								{
									if (this.LightSwitch.Flicker)
									{
										this.CharacterAnimation["f02_electrocution_00"].speed = (float)1;
										this.Prompt.Label[0].text = "     " + "Turn Off";
										this.LightSwitch.BathroomLight.active = true;
										this.RightDrill.localEulerAngles = new Vector3((float)0, (float)0, 68.30447f);
										this.LeftDrill.localEulerAngles = new Vector3((float)0, (float)-180, -159.417f);
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
									this.Dead = true;
								}
							}
						}
					}
					else if (this.Pathfinding.canMove)
					{
						if (this.BathePhase == 1 || this.FleeWhenClean)
						{
							this.CharacterAnimation.CrossFade(this.SprintAnim);
							this.Pathfinding.speed = (float)4;
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
							this.Pathfinding.speed = (float)1;
						}
					}
				}
				if (this.Distracting)
				{
					if (this.DistractionTarget.InEvent)
					{
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
						this.Pathfinding.speed = (float)1;
						this.Distracting = false;
						this.Distracted = false;
						this.CanTalk = true;
						this.Routine = true;
					}
					if (this.DistanceToDestination < this.TargetDistance)
					{
						if (!this.DistractionTarget.Distracted)
						{
							this.DistractionTarget.Pathfinding.canSearch = false;
							this.DistractionTarget.Pathfinding.canMove = false;
							this.DistractionTarget.OccultBook.active = false;
							this.DistractionTarget.Distraction = this.transform;
							this.DistractionTarget.CameraReacting = false;
							this.DistractionTarget.Pathfinding.speed = (float)0;
							this.DistractionTarget.Distracted = true;
							this.DistractionTarget.Routine = false;
							this.DistractionTarget.CanTalk = false;
							this.DistractionTarget.ReadPhase = 0;
							this.Pathfinding.speed = (float)0;
							this.Distracted = true;
						}
						this.targetRotation = Quaternion.LookRotation(this.DistractionTarget.transform.position - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
						this.CharacterAnimation.CrossFade(this.RandomAnim);
						if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
						{
							this.PickRandomAnim();
						}
						this.DistractTimer -= this.DeltaTime;
						if (this.DistractTimer <= (float)0)
						{
							this.CurrentDestination = this.Destinations[this.Phase];
							this.Pathfinding.target = this.Destinations[this.Phase];
							this.DistractionTarget.Pathfinding.canSearch = true;
							this.DistractionTarget.Pathfinding.canMove = true;
							this.DistractionTarget.Pathfinding.speed = (float)1;
							this.DistractionTarget.Distraction = null;
							this.DistractionTarget.Distracted = false;
							this.DistractionTarget.CanTalk = true;
							this.DistractionTarget.Routine = true;
							this.Pathfinding.speed = (float)1;
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
					if (this.StudentManager.Students[7] != null)
					{
						if (this.StudentManager.Students[7].Prompt.enabled)
						{
							this.StudentManager.Students[7].Prompt.Hide();
							this.StudentManager.Students[7].Prompt.enabled = false;
						}
						this.Pathfinding.target = this.StudentManager.Students[7].transform;
						this.CurrentDestination = this.StudentManager.Students[7].transform;
						if (!this.StudentManager.Students[7].Dead)
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
										this.Pathfinding.speed = (float)1;
										this.CharacterAnimation.CrossFade(this.WalkAnim);
									}
								}
								else if (this.MurderSuicidePhase > 1)
								{
									this.StudentManager.Students[7].MoveTowardsTarget(this.transform.position + this.transform.forward * 0.01f);
								}
							}
							else if (!this.NEStairs.bounds.Contains(this.transform.position) && !this.NWStairs.bounds.Contains(this.transform.position) && !this.SEStairs.bounds.Contains(this.transform.position) && !this.SWStairs.bounds.Contains(this.transform.position))
							{
								if (!this.NEStairs.bounds.Contains(this.StudentManager.Students[7].transform.position) && !this.NWStairs.bounds.Contains(this.StudentManager.Students[7].transform.position) && !this.SEStairs.bounds.Contains(this.StudentManager.Students[7].transform.position) && !this.SWStairs.bounds.Contains(this.StudentManager.Students[7].transform.position))
								{
									if (this.Pathfinding.canMove)
									{
										this.CharacterAnimation.CrossFade("f02_murderSuicide_00");
										this.Pathfinding.canSearch = false;
										this.Pathfinding.canMove = false;
										this.Broken.Subtitle.text = string.Empty;
										this.MyController.radius = (float)0;
										this.Broken.Done = true;
										AudioSource.PlayClipAtPoint(this.MurderSuicideSounds, this.transform.position + new Vector3((float)0, (float)1, (float)0));
										this.audio.clip = this.MurderSuicideKiller;
										this.audio.Play();
										this.StudentManager.Students[7].DetectionMarker.Tex.enabled = false;
										this.StudentManager.Students[7].Pathfinding.canSearch = false;
										this.StudentManager.Students[7].Pathfinding.canMove = false;
										this.StudentManager.Students[7].WitnessCamera.Show = false;
										this.StudentManager.Students[7].CameraReacting = false;
										this.StudentManager.Students[7].Investigating = false;
										this.StudentManager.Students[7].Distracting = false;
										this.StudentManager.Students[7].Splashed = false;
										this.StudentManager.Students[7].Alarmed = false;
										this.StudentManager.Students[7].Burning = false;
										this.StudentManager.Students[7].Fleeing = false;
										this.StudentManager.Students[7].Routine = false;
										this.StudentManager.Students[7].Prompt.Hide();
										this.StudentManager.Students[7].Prompt.enabled = false;
										this.StudentManager.Students[7].CharacterAnimation.CrossFade("f02_murderSuicide_01");
										this.StudentManager.Students[7].Subtitle.UpdateLabel("Dying", 0, (float)1);
										this.StudentManager.Students[7].MyController.radius = (float)0;
										this.StudentManager.Students[7].EyeShrink = (float)1;
										this.StudentManager.Students[7].audio.clip = this.MurderSuicideVictim;
										this.StudentManager.Students[7].audio.Play();
										this.Police.CorpseList[this.Police.Corpses] = this.StudentManager.Students[7].Ragdoll;
										this.Police.Corpses = this.Police.Corpses + 1;
										this.StudentManager.Students[7].SetLayerRecursively(this.StudentManager.Students[7].gameObject, 11);
										this.StudentManager.Students[7].tag = "Blood";
										this.StudentManager.Students[7].Ragdoll.Disturbing = true;
										this.StudentManager.Students[7].Dying = true;
										this.StudentManager.Students[7].SpawnAlarmDisc();
										if (this.StudentManager.Students[7].Following)
										{
											this.Yandere.Followers = this.Yandere.Followers - 1;
											this.Hearts.enableEmission = false;
											this.StudentManager.Students[7].Following = false;
										}
									}
									else
									{
										if (this.MurderSuicidePhase > 0)
										{
											this.targetRotation = Quaternion.LookRotation(this.StudentManager.Students[7].transform.position - this.transform.position);
											this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, this.DeltaTime * (float)10);
											this.StudentManager.Students[7].targetRotation = Quaternion.LookRotation(this.StudentManager.Students[7].transform.position - this.transform.position);
											this.StudentManager.Students[7].transform.rotation = Quaternion.Slerp(this.StudentManager.Students[7].transform.rotation, this.StudentManager.Students[7].targetRotation, this.DeltaTime * (float)10);
											this.StudentManager.Students[7].MoveTowardsTarget(this.transform.position + this.transform.forward * 0.01f);
										}
										if (this.MurderSuicidePhase == 1)
										{
											if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 2.4f)
											{
												this.MyWeapon.transform.parent = this.ItemParent;
												this.MyWeapon.transform.localScale = new Vector3((float)1, (float)1, (float)1);
												this.MyWeapon.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
												this.MyWeapon.transform.localEulerAngles = new Vector3((float)0, (float)180, (float)0);
												this.MurderSuicidePhase++;
											}
										}
										else if (this.MurderSuicidePhase == 2)
										{
											if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 3.3f)
											{
												GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(this.Ragdoll.BloodPoolSpawner.BloodPool, this.transform.position + this.transform.forward, Quaternion.identity);
												gameObject2.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
												gameObject2.transform.parent = this.Ragdoll.BloodPoolSpawner.BloodParent;
												this.MyWeapon.Victims[7] = true;
												this.MyWeapon.Blood.enabled = true;
												if (!this.MyWeapon.Evidence)
												{
													this.MyWeapon.Evidence = true;
													this.Police.MurderWeapons = this.Police.MurderWeapons + 1;
												}
												UnityEngine.Object.Instantiate(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
												this.KnifeDown = true;
												this.MurderSuicidePhase++;
											}
										}
										else if (this.MurderSuicidePhase == 3)
										{
											if (!this.KnifeDown)
											{
												if (this.MyWeapon.transform.position.y < this.transform.position.y + 0.33333f)
												{
													UnityEngine.Object.Instantiate(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
													this.KnifeDown = true;
													Debug.Log("Stab!");
												}
											}
											else if (this.MyWeapon.transform.position.y > this.transform.position.y + 0.33333f)
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
												UnityEngine.Object.Instantiate(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
												this.MyWeapon.transform.parent = this.ItemParent;
												this.MyWeapon.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
												this.MyWeapon.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
												this.MurderSuicidePhase++;
											}
										}
										else if (this.MurderSuicidePhase == 5)
										{
											if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 26.166666f)
											{
												Debug.Log("Stabbed neck!");
												UnityEngine.Object.Instantiate(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
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
												this.BloodSprayCollider.active = true;
												this.MurderSuicidePhase++;
											}
										}
										else if (this.CharacterAnimation["f02_murderSuicide_00"].time >= this.CharacterAnimation["f02_murderSuicide_00"].length)
										{
											this.MyWeapon.transform.parent = null;
											this.MyWeapon.Drop();
											this.MyWeapon = null;
											this.StudentManager.StopHesitating();
											this.StudentManager.Students[7].BecomeRagdoll();
											this.StudentManager.Students[7].Ragdoll.MurderSuicide = true;
											this.StudentManager.Students[7].Dead = true;
											if (this.BloodSprayCollider != null)
											{
												this.BloodSprayCollider.active = false;
											}
											this.BecomeRagdoll();
											this.Dead = true;
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
							this.Pathfinding.speed = (float)0;
							this.CharacterAnimation.CrossFade("f02_suicide_00");
						}
					}
					else if (this.MurderSuicidePhase == 1)
					{
						if (this.Pathfinding.speed > (float)0)
						{
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.Pathfinding.speed = (float)0;
							this.CharacterAnimation.CrossFade("f02_suicide_00");
						}
						if (this.CharacterAnimation["f02_suicide_00"].time >= 0.733333349f)
						{
							this.MyWeapon.transform.parent = this.ItemParent;
							this.MyWeapon.transform.localScale = new Vector3((float)1, (float)1, (float)1);
							this.MyWeapon.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
							this.MyWeapon.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
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
							UnityEngine.Object.Instantiate(this.StabBloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
							this.MurderSuicidePhase++;
						}
					}
					else if (this.MurderSuicidePhase == 3)
					{
						if (this.CharacterAnimation["f02_suicide_00"].time >= 6.16666651f)
						{
							Debug.Log("BLOOD FOUNTAIN!");
							this.BloodFountain.gameObject.audio.Play();
							this.BloodFountain.Play();
							this.MurderSuicidePhase++;
						}
					}
					else if (this.MurderSuicidePhase == 4)
					{
						if (this.CharacterAnimation["f02_suicide_00"].time >= 7f)
						{
							this.Ragdoll.BloodPoolSpawner.SpawnPool(this.transform);
							this.BloodSprayCollider.active = true;
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
							this.BloodSprayCollider.active = false;
						}
						this.BecomeRagdoll();
						this.Dead = true;
					}
				}
				if (this.CameraReacting)
				{
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
					if (!this.Yandere.ClubAccessories[7].active)
					{
						if (this.CameraReactPhase == 1)
						{
							if (this.CharacterAnimation[this.CameraAnims[1]].time >= this.CharacterAnimation[this.CameraAnims[1]].length)
							{
								this.CharacterAnimation.CrossFade(this.CameraAnims[2]);
								this.CameraReactPhase = 2;
								this.CameraPoseTimer = (float)1;
							}
						}
						else if (this.CameraReactPhase == 2)
						{
							this.CameraPoseTimer -= this.DeltaTime;
							if (this.CameraPoseTimer <= (float)0)
							{
								this.CharacterAnimation.CrossFade(this.CameraAnims[3]);
								this.CameraReactPhase = 3;
							}
						}
						else if (this.CameraReactPhase == 3)
						{
							if (this.CameraPoseTimer == (float)1)
							{
								this.CharacterAnimation.CrossFade(this.CameraAnims[2]);
								this.CameraReactPhase = 2;
							}
							if (this.CharacterAnimation[this.CameraAnims[3]].time >= this.CharacterAnimation[this.CameraAnims[3]].length)
							{
								this.Obstacle.enabled = false;
								this.CameraReacting = false;
								this.Routine = true;
								this.ReadPhase = 0;
							}
						}
					}
					else if (this.Yandere.Shutter.TargetStudent != this.StudentID)
					{
						this.CameraPoseTimer -= this.DeltaTime;
						if (this.CameraPoseTimer <= (float)0)
						{
							this.Obstacle.enabled = false;
							this.CameraReacting = false;
							this.Routine = true;
							this.ReadPhase = 0;
						}
					}
					else
					{
						this.CameraPoseTimer = (float)1;
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
						if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.collider.bounds))
						{
							RaycastHit raycastHit = default(RaycastHit);
							if (Physics.Linecast(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), out raycastHit) && raycastHit.collider.gameObject == this.Yandere.gameObject)
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
									this.InvestigationTimer = (float)0;
								}
							}
						}
					}
					if (this.InvestigationPhase == 0)
					{
						if (this.InvestigationTimer < (float)5)
						{
							this.InvestigationTimer += this.DeltaTime;
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.Giggle.transform.position.x, this.transform.position.y, this.Giggle.transform.position.z) - this.transform.position);
							this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.Pathfinding.target = this.Giggle.transform;
							this.CurrentDestination = this.Giggle.transform;
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
							this.Pathfinding.speed = (float)1;
							this.InvestigationPhase++;
						}
					}
					else if (this.InvestigationPhase == 1)
					{
						if (this.DistanceToDestination > (float)1)
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
						this.InvestigationTimer += this.DeltaTime;
						if (this.InvestigationTimer > (float)10)
						{
							this.StopInvestigating();
						}
					}
					else if (this.InvestigationPhase == 100)
					{
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
						this.InvestigationTimer += this.DeltaTime;
						if (this.InvestigationTimer > (float)2)
						{
							this.StopInvestigating();
						}
					}
				}
			}
			if (!this.Dying)
			{
				if (!this.Distracted)
				{
					if (!this.WitnessedMurder)
					{
						int num3 = 0;
						this.ID = 0;
						while (this.ID < this.Police.Corpses)
						{
							if (this.Police.CorpseList[this.ID] != null && !this.Police.CorpseList[this.ID].Hidden)
							{
								this.Planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
								if (GeometryUtility.TestPlanesAABB(this.Planes, this.Police.CorpseList[this.ID].AllColliders[0].bounds))
								{
									RaycastHit raycastHit2 = default(RaycastHit);
									Debug.DrawLine(this.Eyes.transform.position, this.Police.CorpseList[this.ID].AllColliders[0].transform.position, Color.green);
									if (Physics.Linecast(this.Eyes.transform.position, this.Police.CorpseList[this.ID].AllColliders[0].transform.position, out raycastHit2, this.Mask) && (raycastHit2.collider.gameObject.layer == 11 || raycastHit2.collider.gameObject.layer == 14))
									{
										num3++;
										this.Corpse = this.Police.CorpseList[this.ID];
										if (this.Persona == 2 && this.StudentManager.Reporter == null && !this.Police.Called)
										{
											this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
											this.StudentManager.LowerCorpsePostion();
											this.StudentManager.Reporter = this;
											this.Reporting = true;
										}
									}
								}
							}
							this.ID++;
						}
						if (num3 > 0)
						{
							if (!this.WitnessedCorpse)
							{
								if (!this.Male)
								{
									this.CharacterAnimation["f02_smile_00"].weight = (float)0;
								}
								this.AlarmTimer = (float)0;
								this.Alarm = (float)200;
								this.LastKnownCorpse = this.Corpse.AllColliders[0].transform.position;
								this.WitnessedCorpse = true;
								this.Investigating = false;
								if (this.Wet)
								{
									this.Persona = 1;
								}
								if (this.Corpse.Burning)
								{
									this.WalkBackTimer = (float)5;
									this.WalkBack = true;
									this.Hesitation = 0.5f;
								}
								if (this.Corpse.Disturbing)
								{
									this.WalkBackTimer = (float)5;
									this.WalkBack = true;
									this.Hesitation = (float)1;
								}
								this.StudentManager.UpdateMe(this.StudentID);
								if (!this.Teacher)
								{
									this.SpawnAlarmDisc();
									if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.Corpse, "Natural"), true))
									{
										this.SwitchBack = true;
										if (this.Corpse != null)
										{
											this.Persona = 2;
										}
										else
										{
											this.Persona = 1;
										}
									}
								}
								else
								{
									this.AlarmTimer = (float)3;
								}
								if (this.Talking)
								{
									this.DialogueWheel.End();
									this.Hearts.enableEmission = false;
									this.Pathfinding.canSearch = true;
									this.Pathfinding.canMove = true;
									this.Obstacle.enabled = false;
									this.Talking = false;
									this.Waiting = false;
									this.StudentManager.EnablePrompts();
								}
								if (this.Following)
								{
									this.Hearts.enableEmission = false;
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
										if ((this.Yandere.Armed && this.Yandere.Weapon[this.Yandere.Equipped].Suspicious) || (this.Yandere.Bloodiness > (float)0 && !this.Yandere.Paint) || (this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Dragging || this.Yandere.Lewd || (this.Yandere.Laughing && this.Yandere.LaughIntensity > (float)15)) || (this.Private && this.Yandere.Trespassing) || (this.Teacher && this.Yandere.Trespassing) || (this.Teacher && this.Yandere.Rummaging) || (this.StudentID == 1 && this.Yandere.NearSenpai && !this.Yandere.Talking))
										{
											this.Planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
											if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.collider.bounds))
											{
												RaycastHit raycastHit3 = default(RaycastHit);
												Debug.DrawLine(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), Color.green);
												if (Physics.Linecast(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), out raycastHit3))
												{
													if (raycastHit3.collider.gameObject == this.Yandere.gameObject)
													{
														this.YandereVisible = true;
														if (this.Yandere.Attacking || this.Yandere.Struggling || (this.Yandere.NearBodies > 0 && this.Yandere.Bloodiness > (float)0 && !this.Yandere.Paint) || (this.Yandere.NearBodies > 0 && this.Yandere.Armed) || (this.Yandere.NearBodies > 0 && this.Yandere.Sanity < 66.66666f) || this.Yandere.Carrying || this.Yandere.Dragging)
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
																	this.Alarm = (float)200;
																}
																if (this.IgnoreTimer <= (float)0)
																{
																	this.Alarm += this.DeltaTime * ((float)100 / this.DistanceToPlayer) * this.Paranoia * this.Perception;
																	if (this.StudentID == 1 && this.Yandere.TimeSkipping)
																	{
																		this.Clock.EndTimeSkip();
																	}
																}
															}
														}
														else
														{
															this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
														}
													}
													else
													{
														this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
													}
												}
											}
											else
											{
												this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
											}
										}
										else
										{
											this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
										}
									}
									else
									{
										this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
									}
								}
								else
								{
									this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
								}
							}
							else
							{
								this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
							}
						}
						else
						{
							this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
						}
						if (this.PreviousAlarm > this.Alarm && this.Alarm < (float)100)
						{
							this.YandereVisible = false;
						}
						if (this.Teacher && this.Yandere.Egg)
						{
							this.Alarm = (float)0;
						}
						if (this.Alarm > (float)100 && (!this.Alarmed || this.DiscCheck))
						{
							if (this.StudentID > 1)
							{
								this.ID = 0;
								while (this.ID < Extensions.get_length(this.Outlines))
								{
									this.Outlines[this.ID].color = new Color((float)1, (float)1, (float)0, (float)1);
									this.ID++;
								}
							}
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.CameraReacting = false;
							this.DiscCheck = false;
							this.Routine = false;
							this.Alarmed = true;
							this.Witness = true;
							this.ReadPhase = 0;
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
								if (this.Yandere.Attacking || this.Yandere.Struggling)
								{
									this.WitnessMurder();
								}
								else
								{
									this.WitnessedBlood = false;
									if (this.Yandere.Bloodiness > (float)0 && !this.Yandere.Paint)
									{
										this.WitnessedBlood = true;
									}
									if (this.Yandere.Rummaging)
									{
										this.Witnessed = "Theft";
										this.Concern = 5;
									}
									else if (flag && this.WitnessedBlood && this.Yandere.Sanity < 33.333f)
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
									else if (this.WitnessedBlood && this.Yandere.Sanity < 33.333f)
									{
										this.Witnessed = "Blood and Insanity";
										this.RepLoss = (float)20;
										this.Concern = 5;
									}
									else if (flag && this.WitnessedBlood)
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
									else if (this.WitnessedBlood)
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
										Debug.Log("Apparently, we didn't even see anything! 1");
										this.DiscCheck = true;
										this.Witness = false;
									}
								}
								if (this.EventManager != null)
								{
									this.EventManager.EndEvent();
								}
								if (this.Teacher && this.WitnessedCorpse)
								{
									this.Concern = 1;
								}
								if (this.StudentID == 1 && this.Yandere.Mask == null)
								{
									if (this.Concern == 5)
									{
										Debug.Log("Senpai noticed because of this code.");
										this.SenpaiNoticed();
										if (this.Witnessed == "Stalking" || this.Witnessed == "Lewd")
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
											this.CharacterAnimation[this.AngryFaceAnim].weight = (float)1;
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.ScaredAnim);
											this.CharacterAnimation["scaredFace_00"].weight = (float)1;
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
									Debug.Log("A teacher has just witnessed Yandere-chan doing something bad..");
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
										this.AlarmTimer = (float)0;
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
								if (!this.Teacher && this.Witnessed == b)
								{
									this.RepeatReaction = true;
								}
								if (this.Yandere.Mask == null)
								{
									this.RepDeduction = (float)0;
									this.CalculateReputationPenalty();
									if (this.RepDeduction >= (float)0)
									{
										this.RepLoss -= this.RepDeduction;
									}
									this.Reputation.PendingRep = this.Reputation.PendingRep - this.RepLoss * this.Paranoia;
									this.PendingRep -= this.RepLoss * this.Paranoia;
								}
								if (this.ToiletEvent != null && this.ToiletEvent.EventDay == 1)
								{
									this.ToiletEvent.EndEvent();
								}
							}
							else
							{
								this.DiscCheck = true;
								this.Witness = false;
							}
						}
					}
					else
					{
						this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
					}
				}
				else
				{
					if (this.Distraction != null)
					{
						this.targetRotation = Quaternion.LookRotation(this.Distraction.position - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
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
						if (this.transform.position.z > -49.3351f)
						{
							if (!this.Slave)
							{
								this.CharacterAnimation.CrossFade(this.WalkAnim);
								this.Distracted = false;
							}
							this.Phone.active = false;
							this.OnPhone = false;
							this.Safe = false;
							this.StudentManager.UpdateStudents();
						}
					}
				}
			}
			if (this.Alarm < (float)0)
			{
				this.Alarm = (float)0;
			}
			if (this.DetectionMarker != null)
			{
				if (this.Alarm <= (float)100)
				{
					float y3 = this.Alarm / (float)100;
					Vector3 localScale = this.DetectionMarker.Tex.transform.localScale;
					float num4 = localScale.y = y3;
					Vector3 vector3 = this.DetectionMarker.Tex.transform.localScale = localScale;
				}
				else
				{
					int num5 = 1;
					Vector3 localScale2 = this.DetectionMarker.Tex.transform.localScale;
					float num6 = localScale2.y = (float)num5;
					Vector3 vector4 = this.DetectionMarker.Tex.transform.localScale = localScale2;
				}
				float a = this.Alarm / (float)100;
				Color color = this.DetectionMarker.Tex.color;
				float num7 = color.a = a;
				Color color2 = this.DetectionMarker.Tex.color = color;
			}
			if (this.StudentID > 1)
			{
				if (!this.Pathfinding.canMove && this.Actions[this.Phase] == 8 && this.Armband.active)
				{
					this.Warned = false;
				}
				if ((this.Alarm > (float)0 || this.AlarmTimer > (float)0 || this.Yandere.Armed) && !this.Slave && !this.BadTime)
				{
					this.Prompt.Circle[0].fillAmount = (float)1;
				}
				if (this.Prompt.Circle[0].fillAmount <= (float)0)
				{
					this.OccultBook.active = false;
					if (this.BadTime)
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
						this.Yandere.SansEyes[0].active = true;
						this.Yandere.SansEyes[1].active = true;
						this.Yandere.GlowEffect.Play();
						this.Yandere.CanMove = false;
						this.Yandere.PK = true;
					}
					else if (this.Slave)
					{
						this.StudentManager.MurderTakingPlace = true;
						this.Yandere.Weapon[this.Yandere.Equipped].transform.parent = this.HipCollider.transform;
						this.Yandere.Weapon[this.Yandere.Equipped].transform.localPosition = new Vector3((float)0, (float)0, (float)0);
						this.Yandere.Weapon[this.Yandere.Equipped].transform.localScale = new Vector3((float)0, (float)0, (float)0);
						this.MyWeapon = this.Yandere.Weapon[this.Yandere.Equipped];
						this.MyWeapon.FingerprintID = this.StudentID;
						this.Yandere.Weapon[this.Yandere.Equipped] = null;
						this.Yandere.Equipped = 0;
						this.Yandere.Armed = false;
						this.StudentManager.UpdateStudents();
						this.Yandere.WeaponManager.UpdateLabels();
						this.Yandere.WeaponMenu.UpdateSprites();
						this.Yandere.WeaponWarning = false;
						this.CharacterAnimation["f02_brokenStandUp_00"].speed = 0.5f;
						this.CharacterAnimation.CrossFade("f02_brokenStandUp_00");
						if (this.StudentID != 7)
						{
							this.DistanceToDestination = (float)100;
							this.Broken.Hunting = true;
							this.TargetDistance = (float)1;
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
						this.Subtitle.UpdateLabel("Student Farewell", 0, (float)3);
						this.Prompt.Label[0].text = "     " + "Talk";
						this.Prompt.Circle[0].fillAmount = (float)1;
						this.Hearts.enableEmission = false;
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
						this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						this.Subtitle.UpdateLabel("Note Reaction", 5, (float)3);
						this.Prompt.Label[0].text = "     " + "Talk";
						this.Prompt.Circle[0].fillAmount = (float)1;
						this.Yandere.TargetStudent = this;
						this.Yandere.Attacking = true;
						this.Yandere.RoofPush = true;
						this.Yandere.CanMove = false;
						this.Routine = false;
						this.Pushed = true;
						this.CharacterAnimation.CrossFade(this.PushedAnim);
					}
					else if (this.Drownable)
					{
						this.Yandere.EmptyHands();
						this.Prompt.Hide();
						this.Prompt.enabled = false;
						this.StudentManager.Fountain.Drowning = true;
						this.Police.DrownedStudentName = this.Name;
						this.MyController.enabled = false;
						this.Police.DrownScene = true;
						this.Distracted = true;
						this.Routine = false;
						this.Drowned = true;
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
						this.Subtitle.UpdateLabel("Class Apology", 0, (float)3);
						this.Prompt.Circle[0].fillAmount = (float)1;
					}
					else if (this.InEvent || !this.CanTalk || (this.Meeting && !this.Drownable) || this.Wet)
					{
						this.Subtitle.UpdateLabel("Event Apology", 1, (float)3);
						this.Prompt.Circle[0].fillAmount = (float)1;
					}
					else if (this.Warned)
					{
						this.Subtitle.UpdateLabel("Grudge Refusal", 0, (float)3);
						this.Prompt.Circle[0].fillAmount = (float)1;
					}
					else
					{
						this.WitnessedBlood = false;
						if (this.Yandere.Bloodiness > (float)0 && !this.Yandere.Paint)
						{
							this.WitnessedBlood = true;
						}
						if (!this.Witness && this.WitnessedBlood)
						{
							this.Prompt.Circle[0].fillAmount = (float)1;
							this.YandereVisible = true;
							this.Alarm = (float)200;
						}
						else
						{
							this.Yandere.TargetStudent = this;
							if (!this.Grudge)
							{
								this.ClubManager.CheckGrudge(this.Club);
								if (PlayerPrefs.GetInt("Club_" + this.Club + "_Kicked") == 1 && !this.Pathfinding.canMove && this.Actions[this.Phase] == 8 && this.Armband.active)
								{
									this.Interaction = 15;
									this.TalkTimer = (float)5;
									this.Warned = true;
								}
								else if (PlayerPrefs.GetInt("Club") == this.Club && !this.Pathfinding.canMove && this.Actions[this.Phase] == 8 && this.Armband.active && this.ClubManager.ClubGrudge)
								{
									this.Interaction = 16;
									this.TalkTimer = (float)5;
									this.Warned = true;
								}
								else if (this.Prompt.Label[0].text == "     " + "Feed")
								{
									this.Interaction = 20;
									this.TalkTimer = (float)3;
								}
								else
								{
									if (!this.Pathfinding.canMove && this.Actions[this.Phase] == 8 && this.Armband.active)
									{
										this.Subtitle.UpdateLabel("Club Greeting", this.Club, (float)4);
										this.DialogueWheel.ClubLeader = true;
									}
									else
									{
										this.Subtitle.UpdateLabel("Greeting", 0, (float)3);
									}
									if ((this.Male && PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus") > 0) || PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus") > 4)
									{
										this.Hearts.enableEmission = true;
									}
									this.StudentManager.DisablePrompts();
									this.DialogueWheel.HideShadows();
									this.DialogueWheel.Show = true;
									this.DialogueWheel.Panel.enabled = true;
									this.TalkTimer = (float)0;
								}
							}
							else if (!this.Pathfinding.canMove && this.Actions[this.Phase] == 8 && this.Armband.active)
							{
								this.Interaction = 15;
								this.TalkTimer = (float)5;
								this.Warned = true;
							}
							else
							{
								this.Interaction = 9;
								this.TalkTimer = (float)5;
								this.Warned = true;
							}
							this.ShoulderCamera.OverShoulder = true;
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.Obstacle.enabled = true;
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
								this.GreenPhone.active = false;
							}
						}
					}
				}
				if (this.Prompt.Circle[2].fillAmount <= (float)0 && !this.Yandere.NearSenpai && !this.Yandere.Attacking && !this.Yandere.Crouching)
				{
					if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 3)
					{
						this.Yandere.SanityBased = false;
					}
					this.AttackReaction();
				}
			}
			if (this.Dying)
			{
				this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
				if (this.Attacked)
				{
					if (!this.Teacher)
					{
						this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1, this.DeltaTime * (float)10);
						if (!this.Dead && !this.Tranquil)
						{
							if (!this.Yandere.SanityBased)
							{
								this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
								this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, this.DeltaTime * (float)10);
								if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 11)
								{
									this.CharacterAnimation.CrossFade(this.CyborgDeathAnim);
									this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
									if (this.CharacterAnimation[this.CyborgDeathAnim].time >= this.CharacterAnimation[this.CyborgDeathAnim].length - 0.25f && this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 11)
									{
										UnityEngine.Object.Instantiate(this.BloodyScream, this.transform.position + Vector3.up, Quaternion.identity);
										this.Dead = true;
										this.BecomeRagdoll();
										this.Ragdoll.Dismember();
									}
								}
								else if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 7)
								{
									this.CharacterAnimation.CrossFade(this.BuzzSawDeathAnim);
									this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
								}
								else if (!this.Yandere.Weapon[this.Yandere.Equipped].Concealable)
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
									this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
								}
								else
								{
									this.targetRotation = Quaternion.LookRotation(this.transform.position - new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z));
								}
								this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, this.DeltaTime * (float)10);
							}
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.DeathAnim);
							if (this.CharacterAnimation[this.DeathAnim].time < (float)1)
							{
								this.transform.Translate(Vector3.back * this.DeltaTime);
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
							this.Phone.active = false;
							this.Police.Show = false;
						}
						this.CharacterAnimation.CrossFade(this.CounterAnim);
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, this.DeltaTime * (float)10);
						this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * (float)1);
						this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), this.DeltaTime * (float)10);
					}
				}
			}
			else if (this.Pushed)
			{
				this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
				this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1, this.DeltaTime * (float)10);
				if (this.CharacterAnimation[this.PushedAnim].time >= this.CharacterAnimation[this.PushedAnim].length)
				{
					this.BecomeRagdoll();
				}
			}
			else if (this.Drowned)
			{
				this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
				this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1, this.DeltaTime * (float)10);
				if (this.CharacterAnimation[this.DrownAnim].time >= this.CharacterAnimation[this.DrownAnim].length)
				{
					this.BecomeRagdoll();
				}
			}
			else if (this.WitnessedMurder)
			{
				if (!this.Fleeing)
				{
					if (this.StudentID > 1 && this.Persona != 5)
					{
						this.EyeShrink += this.DeltaTime * 0.2f;
					}
					this.LovedOneCheck();
					this.CharacterAnimation.CrossFade(this.ScaredAnim);
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.position.x, this.transform.position.y, this.Yandere.Hips.position.z) - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
					if (!this.Yandere.Struggling)
					{
						if (this.Persona != 3)
						{
							this.AlarmTimer += this.DeltaTime * (float)this.MurdersWitnessed;
						}
						else
						{
							this.AlarmTimer += this.DeltaTime * (float)this.MurdersWitnessed * (float)5;
						}
					}
					if (this.AlarmTimer > (float)5)
					{
						this.PersonaReaction();
						this.AlarmTimer = (float)0;
					}
					else if (this.AlarmTimer > (float)1 && !this.Reacted)
					{
						if (this.StudentID > 1 || this.Yandere.Mask != null)
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
							this.CharacterAnimation.CrossFade(this.ScaredAnim);
							this.Yandere.ShoulderCamera.enabled = true;
							this.Yandere.ShoulderCamera.Noticed = true;
							this.Yandere.RPGCamera.enabled = false;
							this.Stop = true;
						}
						this.Reacted = true;
					}
				}
			}
			else if (this.Alarmed)
			{
				this.OccultBook.active = false;
				this.ReadPhase = 0;
				if (this.WitnessedCorpse)
				{
					if (!this.WalkBack)
					{
						this.CharacterAnimation.CrossFade(this.ScaredAnim);
					}
					else
					{
						this.MyController.Move(this.transform.forward * -0.5f * Time.deltaTime);
						this.CharacterAnimation.CrossFade(this.WalkBackAnim);
						this.WalkBackTimer -= this.DeltaTime;
						if (this.WalkBackTimer <= (float)0)
						{
							this.WalkBack = false;
						}
					}
				}
				else if (this.StudentID > 1)
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
				}
				if (this.WitnessedMurder)
				{
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
				}
				else if (this.WitnessedCorpse)
				{
					if (this.Corpse != null && this.Corpse.AllColliders[0] != null)
					{
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, this.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
					}
				}
				else if (!this.DiscCheck)
				{
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
				}
				else
				{
					this.targetRotation = Quaternion.LookRotation(this.DistractionSpot - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
				}
				if (!this.Fleeing)
				{
					this.AlarmTimer += this.DeltaTime * ((float)1 - this.Hesitation);
				}
				this.Alarm -= this.DeltaTime * (float)100 * ((float)1 / this.Paranoia);
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
					this.DiscCheck = false;
					this.Alarmed = false;
					this.Reacted = false;
					this.Hesitation = (float)0;
					this.AlarmTimer = (float)0;
					if (this.WitnessedCorpse)
					{
						this.PersonaReaction();
					}
					else if (!this.Following && !this.Wet && !this.Investigating)
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
							Debug.Log("A teacher's reaction is now being determined.");
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
							else if (this.Witnessed == "Theft")
							{
								this.Subtitle.UpdateLabel("Teacher Theft Reaction", 1, (float)6);
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
							if (this.WitnessedMurder && !this.Yandere.Chased)
							{
								this.ChaseYandere();
							}
						}
						if (this.Concern == 5)
						{
							Debug.Log("A Game Over will now occur.");
							this.CharacterAnimation[this.AngryFaceAnim].weight = (float)1;
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
							this.Witnessed = string.Empty;
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
							this.Stop = true;
						}
					}
					this.Reacted = true;
				}
			}
			if (this.Burning)
			{
				if (this.CharacterAnimation["f02_burning_00"].time > this.CharacterAnimation["f02_burning_00"].length)
				{
					this.Dead = true;
					this.BecomeRagdoll();
				}
			}
			else if (this.Splashed)
			{
				if (this.Yandere.Tripping)
				{
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
				}
				if (!this.Alarmed)
				{
					this.SplashTimer += this.DeltaTime;
					if (this.SplashTimer > (float)2 && this.SplashPhase == 1)
					{
						if (this.Gas)
						{
							this.Subtitle.UpdateLabel("Splash Reaction", 5, (float)5);
						}
						else if (this.Bloody)
						{
							this.Subtitle.UpdateLabel("Splash Reaction", 3, (float)5);
						}
						else if (this.Yandere.Tripping)
						{
							this.Subtitle.UpdateLabel("Splash Reaction", 7, (float)5);
						}
						else
						{
							this.Subtitle.UpdateLabel("Splash Reaction", 1, (float)5);
						}
						this.CharacterAnimation[this.SplashedAnim].speed = 0.5f;
						this.SplashPhase++;
					}
					if (this.SplashTimer > (float)12 && this.SplashPhase == 2)
					{
						if (this.LightSwitch == null)
						{
							if (this.Gas)
							{
								this.Subtitle.UpdateLabel("Splash Reaction", 6, (float)5);
							}
							else if (this.Bloody)
							{
								this.Subtitle.UpdateLabel("Splash Reaction", 4, (float)5);
							}
							else
							{
								this.Subtitle.UpdateLabel("Splash Reaction", 2, (float)5);
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
			}
			if (this.TurnOffRadio)
			{
				if (this.Radio.On || this.RadioPhase == 3)
				{
					if (this.RadioPhase == 1)
					{
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, this.transform.position.y, this.Radio.transform.position.z) - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
						this.RadioTimer += this.DeltaTime;
						if (this.RadioTimer > (float)3)
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
							this.CurrentDestination = this.Radio.transform;
							this.Pathfinding.target = this.Radio.transform;
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
							this.RadioTimer = (float)0;
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
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, this.transform.position.y, this.Radio.transform.position.z) - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
						this.RadioTimer += this.DeltaTime;
						if (this.RadioTimer > (float)4)
						{
							this.CurrentDestination = this.Destinations[this.Phase];
							this.Pathfinding.target = this.Destinations[this.Phase];
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
							this.TurnOffRadio = false;
							this.RadioTimer = (float)0;
							this.RadioPhase = 1;
							this.Routine = true;
							this.Radio = null;
						}
						else if (this.RadioTimer > (float)2)
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
						this.RadioTimer = (float)0;
					}
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, this.transform.position.y, this.Radio.transform.position.z) - this.transform.position);
					this.RadioTimer += this.DeltaTime;
					if (this.RadioTimer > (float)1)
					{
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.TurnOffRadio = false;
						this.RadioTimer = (float)0;
						this.RadioPhase = 1;
						this.Routine = true;
						this.Radio = null;
					}
				}
			}
			if (this.IgnoreTimer > (float)0)
			{
				this.IgnoreTimer -= this.DeltaTime;
			}
			if (!this.Fleeing)
			{
				if (this.transform.position.z < (float)-50 && this.Clock.HourTime > 15.5f)
				{
					if (this.transform.position.y < (float)0 && this.StudentID > 1)
					{
						UnityEngine.Object.Destroy(this.gameObject);
					}
				}
				else if (this.transform.position.y < (float)0)
				{
					int num8 = 0;
					Vector3 position3 = this.transform.position;
					float num9 = position3.y = (float)num8;
					Vector3 vector5 = this.transform.position = position3;
				}
			}
			if (!this.Male)
			{
				if (!this.Splashed && this.Wet && !this.Burning && !this.Dying && Mathf.Abs(this.BathePhase) == 1)
				{
					if (this.CharacterAnimation[this.WetAnim].weight < (float)1)
					{
						this.CharacterAnimation[this.WetAnim].weight = (float)1;
					}
				}
				else if (this.CharacterAnimation[this.WetAnim].weight > (float)0)
				{
					this.CharacterAnimation[this.WetAnim].weight = (float)0;
				}
			}
			if (this.Dying)
			{
				this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			}
			if (this.Pathfinding.canMove && this.Pathfinding.currentSpeed > (float)0 && this.transform.position == this.LastPosition)
			{
				this.StuckTimer += this.DeltaTime;
				if (this.StuckTimer > (float)1)
				{
					this.MyController.Move(this.transform.right * Time.timeScale * 0.0001f);
					this.StuckTimer = (float)0;
				}
			}
			this.LastPosition = this.transform.position;
		}
		else if (!this.ClubActivity)
		{
			this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * this.DeltaTime);
		}
		else if (this.Police.Darkness.color.a < (float)1)
		{
			this.CharacterAnimation.Play(this.ActivityAnim);
			if (this.Club == 6)
			{
				if (!this.Male)
				{
					if (this.CharacterAnimation["f02_kick_23"].time > (float)1)
					{
						if (!this.PlayingAudio)
						{
							this.audio.clip = this.FemaleAttacks[UnityEngine.Random.Range(0, Extensions.get_length(this.FemaleAttacks))];
							this.audio.Play();
							this.PlayingAudio = true;
						}
						if (this.CharacterAnimation["f02_kick_23"].time >= this.CharacterAnimation["f02_kick_23"].length)
						{
							this.CharacterAnimation["f02_kick_23"].time = (float)0;
							this.PlayingAudio = false;
						}
					}
				}
				else if (this.CharacterAnimation["kick_24"].time > (float)1)
				{
					if (!this.PlayingAudio)
					{
						this.audio.clip = this.MaleAttacks[UnityEngine.Random.Range(0, Extensions.get_length(this.MaleAttacks))];
						this.audio.Play();
						this.PlayingAudio = true;
					}
					if (this.CharacterAnimation["kick_24"].time >= this.CharacterAnimation["kick_24"].length)
					{
						this.CharacterAnimation["kick_24"].time = (float)0;
						this.PlayingAudio = false;
					}
				}
			}
		}
		if (this.AoT)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)10, (float)10, (float)10), this.DeltaTime);
		}
		if (this.BadTime)
		{
			this.Prompt.Label[0].text = "     " + "Psychokinesis";
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
		this.PreviousEyeShrink = this.EyeShrink;
		if (!this.Male)
		{
			if (this.Shy)
			{
				if (this.Routine)
				{
					if ((this.Phase == 2 && this.DistanceToDestination < (float)1) || (this.Phase == 4 && this.DistanceToDestination < (float)1))
					{
						this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, (float)0, this.DeltaTime);
					}
					else
					{
						this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, (float)1, this.DeltaTime);
					}
				}
				else
				{
					this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, (float)0, this.DeltaTime);
				}
			}
			if (this.Routine && !this.InEvent && !this.Meeting)
			{
				if (this.DistanceToDestination < this.TargetDistance && this.Actions[this.Phase] == 9)
				{
					this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, (float)1, this.DeltaTime * (float)10);
				}
				else
				{
					this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, (float)0, this.DeltaTime * (float)10);
				}
			}
			else
			{
				this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, (float)0, this.DeltaTime * (float)10);
			}
			if (!this.BoobsResized)
			{
				this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				this.RightBreast.gameObject.name = "RightBreastRENAMED";
				this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
				this.BoobsResized = true;
			}
		}
		if (this.DK)
		{
			this.Arm[0].localScale = new Vector3((float)2, (float)2, (float)2);
			this.Arm[1].localScale = new Vector3((float)2, (float)2, (float)2);
			this.Head.localScale = new Vector3((float)2, (float)2, (float)2);
		}
		if (this.StudentID == 32)
		{
			float y3 = 0.66666f;
			Vector3 localScale5 = this.Skirt[0].transform.localScale;
			float num7 = localScale5.y = y3;
			Vector3 vector7 = this.Skirt[0].transform.localScale = localScale5;
			float y4 = 0.66666f;
			Vector3 localScale6 = this.Skirt[1].transform.localScale;
			float num8 = localScale6.y = y4;
			Vector3 vector8 = this.Skirt[1].transform.localScale = localScale6;
			float y5 = 0.66666f;
			Vector3 localScale7 = this.Skirt[2].transform.localScale;
			float num9 = localScale7.y = y5;
			Vector3 vector9 = this.Skirt[2].transform.localScale = localScale7;
			float y6 = 0.66666f;
			Vector3 localScale8 = this.Skirt[3].transform.localScale;
			float num10 = localScale8.y = y6;
			Vector3 vector10 = this.Skirt[3].transform.localScale = localScale8;
		}
	}

	public virtual void CalculateReputationPenalty()
	{
		if ((this.Male && PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus") > 2) || PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus") > 4)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (PlayerPrefs.GetFloat("Reputation") < -33.33333f)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (PlayerPrefs.GetFloat("Reputation") > 33.33333f)
		{
			this.RepDeduction -= this.RepLoss * 0.2f;
		}
		if (PlayerPrefs.GetInt(this.StudentID + "_Friend") == 1)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (PlayerPrefs.GetInt("PantiesEquipped") == 1)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (PlayerPrefs.GetInt("SocialBonus") > 0)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
	}

	public virtual void MoveTowardsTarget(Vector3 target)
	{
		if (Time.timeScale > (float)0)
		{
			Vector3 a = target - this.transform.position;
			float num = Vector3.Distance(this.transform.position, target);
			a = a.normalized * num;
			if (this.MyController.enabled && num > 0.001f)
			{
				this.MyController.Move(a * (this.DeltaTime * (float)5 / Time.timeScale));
			}
		}
	}

	public virtual void AttackReaction()
	{
		if (!this.WitnessedMurder)
		{
			float f = Vector3.Angle(this.transform.forward * (float)-1, this.Yandere.transform.position - this.transform.position);
			if (Mathf.Abs(f) > (float)45)
			{
				this.Yandere.AttackManager.Stealth = false;
			}
			else
			{
				this.Yandere.AttackManager.Stealth = true;
			}
		}
		this.StudentManager.TranqDetector.TranqCheck();
		if (!this.Male)
		{
			this.CharacterAnimation["f02_smile_00"].weight = (float)0;
			this.GreenPhone.active = false;
		}
		this.WitnessCamera.Show = false;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Yandere.CharacterAnimation["f02_idleShort_00"].time = (float)0;
		this.Yandere.CharacterAnimation["f02_swingA_00"].time = (float)0;
		this.Yandere.MyController.radius = (float)0;
		this.Yandere.TargetStudent = this;
		this.Yandere.Obscurance.enabled = false;
		this.Yandere.YandereVision = false;
		this.Yandere.Attacking = true;
		this.Yandere.CanMove = false;
		if (this.Yandere.Equipped > 0 && this.Yandere.Weapon[this.Yandere.Equipped].AnimID == 2)
		{
			this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[2]].weight = (float)0;
		}
		this.DetectionMarker.Tex.enabled = false;
		this.OccultBook.active = false;
		this.MyController.radius = (float)0;
		this.Investigating = false;
		this.Attacked = true;
		this.Alarmed = false;
		this.Fleeing = false;
		this.Routine = false;
		this.ReadPhase = 0;
		this.Dying = true;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		if (this.Following)
		{
			this.Hearts.enableEmission = false;
			this.Yandere.Followers = this.Yandere.Followers - 1;
			this.Following = false;
		}
		if (this.Distracting)
		{
			this.DistractionTarget.Distracted = false;
			this.Distracting = false;
		}
		if (this.Teacher)
		{
			if (PlayerPrefs.GetInt("PhysicalGrade") + PlayerPrefs.GetInt("PhysicalBonus") > 0 && this.Yandere.Weapon[this.Yandere.Equipped].Type == 1)
			{
				Debug.Log("A teacher has entered the ''Fleeing'' protocol and called the ''BeginStruggle'' function.");
				this.Pathfinding.target = this.Yandere.transform;
				this.CurrentDestination = this.Yandere.transform;
				this.Yandere.Attacking = false;
				this.Attacked = false;
				this.Fleeing = true;
				this.Dying = false;
				this.Persona = 3;
				this.BeginStruggle();
			}
			else
			{
				this.Yandere.HeartRate.gameObject.active = false;
				this.Yandere.ShoulderCamera.Counter = true;
				this.ShoulderCamera.OverShoulder = false;
				this.Yandere.RPGCamera.enabled = false;
				this.Yandere.Senpai = this.transform;
				this.Yandere.Attacking = true;
				this.Yandere.CanMove = false;
				this.Yandere.Talking = false;
				this.Yandere.Noticed = true;
				this.Yandere.HUD.alpha = (float)0;
			}
		}
		else
		{
			if (!this.Yandere.AttackManager.Stealth)
			{
				this.Subtitle.UpdateLabel("Dying", 0, (float)1);
				this.SpawnAlarmDisc();
			}
			if (this.Yandere.SanityBased)
			{
				this.Yandere.AttackManager.Victim = this.Character;
				this.Yandere.AttackManager.Attack();
			}
		}
	}

	public virtual void SenpaiNoticed()
	{
		Debug.Log("The ''SenpaiNoticed'' function has been called.");
		if (!this.Yandere.Attacking)
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
		this.Yandere.Rummaging = false;
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
		if (this.Teacher || this.StudentID == 1)
		{
			this.enabled = true;
			this.Stop = false;
		}
	}

	public virtual void WitnessMurder()
	{
		if (!this.Male)
		{
			this.CharacterAnimation["f02_smile_00"].weight = (float)0;
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
			if (this.Persona != 5)
			{
				this.Police.Witnesses = this.Police.Witnesses + 1;
			}
			if (this.Teacher)
			{
				this.StudentManager.Reporter = this;
			}
			if (this.Talking)
			{
				this.DialogueWheel.End();
				this.Hearts.enableEmission = false;
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Obstacle.enabled = false;
				this.Talking = false;
				this.Waiting = false;
				this.StudentManager.EnablePrompts();
			}
			if (this.Prompt.Label[0] != null)
			{
				this.Prompt.Label[0].text = "     " + "Talk";
				this.Prompt.HideButton[0] = true;
			}
		}
		else
		{
			if (!this.Yandere.Attacking)
			{
				Debug.Log("Here?");
				this.SenpaiNoticed();
			}
			this.EyeShrink = (float)0;
			this.Fleeing = false;
			this.Yandere.Noticed = true;
			this.Yandere.Talking = false;
			this.CameraEffects.MurderWitnessed();
			this.ShoulderCamera.OverShoulder = false;
			this.CharacterAnimation.CrossFade(this.ScaredAnim);
			this.CharacterAnimation["scaredFace_00"].weight = (float)1;
		}
		if (this.Persona == 2 && this.StudentManager.Reporter == null && !this.Police.Called)
		{
			this.StudentManager.CorpseLocation.position = this.Yandere.transform.position;
			this.StudentManager.LowerCorpsePostion();
			this.StudentManager.Reporter = this;
			this.Reporting = true;
		}
		if (this.Following)
		{
			this.Hearts.enableEmission = false;
			this.Yandere.Followers = this.Yandere.Followers - 1;
			this.Following = false;
		}
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.WitnessedMurder = true;
		this.Investigating = false;
		this.MurdersWitnessed++;
		this.Reacted = false;
		this.Routine = false;
		this.Alarmed = true;
		if (this.Persona != 3)
		{
			this.AlarmTimer = (float)0;
			this.Alarm = (float)0;
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
		this.StudentManager.UpdateMe(this.StudentID);
	}

	public virtual void ChaseYandere()
	{
		Debug.Log("A character has begun to chase Yandere-chan.");
		this.CurrentDestination = this.Yandere.transform;
		this.Pathfinding.target = this.Yandere.transform;
		this.Pathfinding.speed = 7.5f;
		this.StudentManager.Portal.active = false;
		this.Yandere.Pursuer = this;
		this.Yandere.Chased = true;
		this.TargetDistance = 0.5f;
		this.Fleeing = false;
		this.AlarmTimer = (float)0;
		this.StudentManager.UpdateStudents();
	}

	public virtual void PersonaReaction()
	{
		if (!this.Indoors)
		{
			this.Persona = 1;
		}
		if (!this.WitnessedMurder)
		{
			if (this.Persona == 3)
			{
				this.SwitchBack = true;
				if (this.Corpse != null)
				{
					this.Persona = 2;
				}
				else
				{
					this.Persona = 1;
				}
			}
			else if (this.Persona == 4 || this.Persona == 5)
			{
				this.Persona = 1;
			}
		}
		if (this.Persona == 1)
		{
			if (this.WitnessedMurder)
			{
				this.Subtitle.UpdateLabel("Loner Murder Reaction", 1, (float)3);
			}
			else
			{
				this.Subtitle.UpdateLabel("Loner Corpse Reaction", 1, (float)3);
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
				this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
				this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
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
		else if (this.Persona == 3)
		{
			if (!this.Yandere.Chased)
			{
				Debug.Log("Began fleeing because Hero persona reaction was called.");
				this.Subtitle.UpdateLabel("Hero Murder Reaction", 3, (float)3);
				this.Pathfinding.target = this.Yandere.transform;
				this.Pathfinding.speed = 7.5f;
				this.StudentManager.Portal.active = false;
				this.Yandere.Chased = true;
				this.TargetDistance = 0.5f;
				this.StudentManager.UpdateStudents();
				this.Routine = false;
				this.Fleeing = true;
			}
		}
		else if (this.Persona == 4)
		{
			this.CurrentDestination = this.transform;
			this.Pathfinding.target = this.transform;
			this.Subtitle.UpdateLabel("Coward Murder Reaction", 1, (float)5);
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == 5)
		{
			this.CurrentDestination = this.transform;
			this.Pathfinding.target = this.transform;
			this.Subtitle.UpdateLabel("Evil Murder Reaction", 1, (float)5);
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == 6)
		{
			this.CurrentDestination = this.StudentManager.HidingSpots.List[this.StudentID];
			this.Pathfinding.target = this.StudentManager.HidingSpots.List[this.StudentID];
			this.Subtitle.UpdateLabel("Social Death Reaction", 1, (float)5);
			this.ReportPhase = 1;
			this.Routine = false;
			this.Fleeing = true;
			this.Halt = true;
		}
		else if (this.Persona == 9)
		{
			if (this.WitnessedMurder)
			{
				if (this.Yandere.Pursuer == this)
				{
					Debug.Log("A teacher is now reacting to the sight of murder.");
					this.Subtitle.UpdateLabel("Teacher Murder Reaction", 3, (float)3);
					this.Pathfinding.target = this.Yandere.transform;
					this.Pathfinding.speed = 7.5f;
					this.StudentManager.Portal.active = false;
					this.Yandere.Chased = true;
					this.TargetDistance = 0.5f;
					this.StudentManager.UpdateStudents();
					float y = this.transform.position.y + 0.1f;
					Vector3 position = this.transform.position;
					float num = position.y = y;
					Vector3 vector = this.transform.position = position;
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
					this.Subtitle.UpdateLabel("Teacher Corpse Reaction", 1, (float)3);
				}
				this.Pathfinding.target = ((GameObject)UnityEngine.Object.Instantiate(this.EmptyGameObject, new Vector3(this.Corpse.AllColliders[0].transform.position.x, this.transform.position.y, this.Corpse.AllColliders[0].transform.position.z), Quaternion.identity)).transform;
				this.TargetDistance = (float)1;
				this.ReportPhase = 2;
				float y2 = this.transform.position.y + 0.1f;
				Vector3 position2 = this.transform.position;
				float num2 = position2.y = y2;
				Vector3 vector2 = this.transform.position = position2;
				this.Routine = false;
				this.Fleeing = true;
			}
		}
	}

	public virtual void BeginStruggle()
	{
		Debug.Log("My name is " + this.Name + " and now I am fighting Yandere-chan.");
		if (this.Yandere.Dragging)
		{
			((RagdollScript)this.Yandere.Ragdoll.GetComponent(typeof(RagdollScript))).StopDragging();
		}
		if (this.Yandere.Armed)
		{
			this.Yandere.Weapon[this.Yandere.Equipped].transform.localEulerAngles = new Vector3((float)0, (float)180, (float)0);
		}
		this.Yandere.StruggleBar.Strength = (float)this.Strength;
		this.Yandere.StruggleBar.Struggling = true;
		this.Yandere.StruggleBar.Student = this;
		this.Yandere.StruggleBar.active = true;
		this.CharacterAnimation.CrossFade(this.StruggleAnim);
		this.ShoulderCamera.LastPosition = this.ShoulderCamera.transform.position;
		this.ShoulderCamera.Struggle = true;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Obstacle.enabled = true;
		this.Alarmed = false;
		this.Halt = true;
		if (!this.Teacher)
		{
			this.Yandere.CharacterAnimation["f02_struggleA_00"].time = (float)0;
		}
		else
		{
			this.Yandere.CharacterAnimation["f02_teacherStruggleA_00"].time = (float)0;
			this.transform.localScale = new Vector3((float)1, (float)1, (float)1);
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
		this.MyController.radius = (float)0;
		this.TargetDistance = (float)100;
		this.AlarmTimer = (float)0;
		this.SpawnAlarmDisc();
	}

	public virtual void GetDestinations()
	{
		if (!this.Teacher)
		{
			this.MyLocker = this.StudentManager.LockerPositions[this.StudentID];
		}
		if (this.Slave)
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.DestinationNames))
			{
				this.DestinationNames[this.ID] = "Slave";
				this.ActionNames[this.ID] = "Slave";
				this.ID++;
			}
		}
		this.ID = 1;
		while (this.ID < this.JSON.StudentDestinations[this.StudentID].length)
		{
			if (this.DestinationNames[this.ID] == "Locker")
			{
				this.Destinations[this.ID] = this.MyLocker;
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
			else if (this.DestinationNames[this.ID] == "Slave")
			{
				this.Destinations[this.ID] = this.StudentManager.SlaveSpot;
			}
			else if (this.DestinationNames[this.ID] == "Patrol")
			{
				this.Destinations[this.ID] = this.StudentManager.Patrols.List[this.StudentID].GetChild(0);
			}
			else if (this.DestinationNames[this.ID] == "Mourn")
			{
				this.Destinations[this.ID] = this.StudentManager.MournSpot;
			}
			else if (this.DestinationNames[this.ID] == "Stalk")
			{
				this.Destinations[this.ID] = this.StudentManager.StalkSpot;
			}
			else if (this.DestinationNames[this.ID] == "Club")
			{
				if (this.Club > 0)
				{
					this.Destinations[this.ID] = this.StudentManager.Clubs.List[this.StudentID];
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
				}
			}
			this.ID++;
		}
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
			else if (this.ActionNames[this.ID] == "Slave")
			{
				this.Actions[this.ID] = 4;
			}
			else if (this.ActionNames[this.ID] == "Relax")
			{
				this.Actions[this.ID] = 5;
			}
			else if (this.ActionNames[this.ID] == "Sit")
			{
				this.Actions[this.ID] = 6;
			}
			else if (this.ActionNames[this.ID] == "Stalk")
			{
				this.Actions[this.ID] = 7;
			}
			else if (this.ActionNames[this.ID] == "SocialSit")
			{
				this.Actions[this.ID] = 9;
			}
			else if (this.ActionNames[this.ID] == "Eat")
			{
				this.Actions[this.ID] = 10;
			}
			else if (this.ActionNames[this.ID] == "Shoes")
			{
				this.Actions[this.ID] = 11;
			}
			else if (this.ActionNames[this.ID] == "Grade")
			{
				this.Actions[this.ID] = 12;
			}
			else if (this.ActionNames[this.ID] == "Patrol")
			{
				this.Actions[this.ID] = 13;
			}
			else if (this.ActionNames[this.ID] == "Read")
			{
				this.Actions[this.ID] = 14;
			}
			else if (this.ActionNames[this.ID] == "Text")
			{
				this.Actions[this.ID] = 15;
			}
			else if (this.ActionNames[this.ID] == "Mourn")
			{
				this.Actions[this.ID] = 16;
			}
			else if (this.ActionNames[this.ID] == "Club")
			{
				if (this.Club > 0)
				{
					if (this.Club == 6)
					{
						this.Actions[this.ID] = 8;
					}
					else if (this.Club == 3)
					{
						if (this.StudentID == 26)
						{
							this.Actions[this.ID] = 8;
						}
						else
						{
							this.Actions[this.ID] = 14;
						}
					}
				}
				else
				{
					this.Actions[this.ID] = 1;
				}
			}
			this.ID++;
		}
		if (this.StudentID == 7 && (float)PlayerPrefs.GetInt("Student_7_Reputation") < -33.33333f)
		{
			this.Destinations[2] = this.StudentManager.ShameSpot;
			this.Destinations[4] = this.StudentManager.ShameSpot;
			this.Actions[2] = 3;
			this.Actions[4] = 3;
		}
		if (this.StudentID == 26 && PlayerPrefs.GetInt("Club_3_Closed") == 1 && PlayerPrefs.GetInt("Student_17_Dead") == 1 && PlayerPrefs.GetInt("Student_18_Dead") == 1)
		{
			this.Destinations[2] = this.StudentManager.Hangouts.List[this.StudentID];
			this.Actions[2] = 1;
		}
		if (this.StudentID == 32 && PlayerPrefs.GetInt("Student_32_Broken") == 1)
		{
			this.Destinations[2] = this.StudentManager.BrokenSpot;
			this.Destinations[4] = this.StudentManager.BrokenSpot;
			this.Actions[2] = 3;
			this.Actions[4] = 3;
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
		this.GradingPaper = this.StudentManager.FacultyDesks[this.Class];
		this.GradingPaper.LeftHand = this.LeftHand.parent;
		this.GradingPaper.Character = this.Character;
		this.GradingPaper.Teacher = this;
		this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
		this.StudentManager.Teachers[this.Class] = this;
		this.PantyCollider.enabled = false;
		this.SkirtCollider.enabled = false;
		if (this.Class > 0)
		{
			this.VisionCone.farClipPlane = (float)12 * this.Paranoia;
			this.name = "Teacher_" + this.Class;
		}
		else
		{
			this.VisionCone.farClipPlane = (float)16 * this.Paranoia;
			this.IdleAnim = "f02_tsunIdle_00";
			this.name = "Coach";
		}
		this.StruggleAnim = "f02_teacherStruggleB_00";
		this.StruggleWonAnim = "f02_teacherStruggleWinB_00";
		this.StruggleLostAnim = "f02_teacherStruggleLoseB_00";
		this.OriginallyTeacher = true;
		this.Teacher = true;
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
		if (this.Following)
		{
			this.Hearts.enableEmission = false;
			this.Yandere.Followers = this.Yandere.Followers - 1;
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
		else if (!this.Tranquil && RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.Ragdoll, "Natural"), false))
		{
			this.Police.MurderScene = true;
		}
		if (!this.Tranquil)
		{
			PlayerPrefs.SetInt("Student_" + this.StudentID + "_Dying", 1);
			if (!this.Ragdoll.Burning && !this.Ragdoll.Disturbing)
			{
				this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
				this.Police.Corpses = this.Police.Corpses + 1;
			}
		}
		if (!this.Male)
		{
			this.LiquidProjector.ignoreLayers = -2049;
			this.RightHandCollider.enabled = false;
			this.LeftHandCollider.enabled = false;
			this.PantyCollider.enabled = false;
			this.SkirtCollider.enabled = false;
		}
		this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		this.Ragdoll.AllColliders[10].isTrigger = false;
		this.NotFaceCollider.enabled = false;
		this.Hearts.enableEmission = false;
		this.FaceCollider.enabled = false;
		this.MyController.enabled = false;
		this.Pathfinding.enabled = false;
		this.HipCollider.enabled = true;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.enabled = false;
		this.UnWet();
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
		this.Police.Deaths = this.Police.Deaths + 1;
		this.Ragdoll.enabled = true;
		this.Reputation.PendingRep = this.Reputation.PendingRep + this.PendingRep * (float)-1;
		if (this.WitnessedMurder && this.Persona != 5)
		{
			this.Police.Witnesses = this.Police.Witnesses - 1;
		}
		this.UpdateOutlines();
		this.DetectionMarker.Tex.enabled = false;
		this.SetLayerRecursively(this.gameObject, 11);
		this.tag = "Blood";
	}

	public virtual void GetWet()
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
		while (this.ID < Extensions.get_length(this.LiquidEmitters))
		{
			this.LiquidEmitters[this.ID].gameObject.active = true;
			if (this.Gas)
			{
				this.LiquidEmitters[this.ID].startColor = new Color((float)1, (float)1, (float)0, (float)1);
			}
			else if (this.Bloody)
			{
				this.LiquidEmitters[this.ID].startColor = new Color((float)1, (float)0, (float)0, (float)1);
			}
			else
			{
				this.LiquidEmitters[this.ID].startColor = new Color((float)0, (float)1, (float)1, (float)1);
			}
			this.ID++;
		}
		if (!this.Slave)
		{
			if (this.Yandere.Tripping && this.Yandere.Mask == null)
			{
				this.Witnessed = "Accident";
				this.Witness = true;
				this.RepLoss = (float)10;
				this.RepDeduction = (float)0;
				this.CalculateReputationPenalty();
				if (this.RepDeduction >= (float)0)
				{
					this.RepLoss -= this.RepDeduction;
				}
				this.Reputation.PendingRep = this.Reputation.PendingRep - this.RepLoss * this.Paranoia;
				this.PendingRep -= this.RepLoss * this.Paranoia;
			}
			this.CharacterAnimation[this.SplashedAnim].speed = (float)1;
			this.CharacterAnimation.CrossFade(this.SplashedAnim);
			this.Subtitle.UpdateLabel("Splash Reaction", 0, (float)1);
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.SplashTimer = (float)0;
			this.SplashPhase = 1;
			this.BathePhase = 1;
			this.Splashed = true;
			this.Routine = false;
			this.Wet = true;
			this.SpawnAlarmDisc();
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

	public virtual void Combust()
	{
		this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
		this.Police.Corpses = this.Police.Corpses + 1;
		this.SetLayerRecursively(this.gameObject, 11);
		this.tag = "Blood";
		this.Dying = true;
		this.SpawnAlarmDisc();
		this.Character.animation.CrossFade("f02_burning_00");
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Ragdoll.Burning = true;
		this.Routine = false;
		this.Burning = true;
		this.audio.clip = this.BurningClip;
		this.audio.Play();
		this.LiquidProjector.enabled = false;
		this.UnWet();
		this.ID = 0;
		if (this.Following)
		{
			this.Yandere.Followers = this.Yandere.Followers - 1;
			this.Following = false;
		}
		while (this.ID < Extensions.get_length(this.FireEmitters))
		{
			this.FireEmitters[this.ID].gameObject.active = true;
			this.ID++;
		}
	}

	public virtual void Nude()
	{
		if (!this.Male)
		{
			this.PantyCollider.enabled = false;
			this.SkirtCollider.enabled = false;
		}
		this.MyRenderer.sharedMesh = this.BaldNudeMesh;
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTexture;
			this.MyRenderer.materials[1].mainTexture = null;
			this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		}
		else
		{
			this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
			this.MyRenderer.materials[1].mainTexture = null;
			this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
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
			if (!this.Male)
			{
				this.Cosmetic.SetFemaleUniform();
			}
			else
			{
				this.Cosmetic.SetMaleUniform();
			}
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
			this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
		}
		while (this.ID < Extensions.get_length(this.Outlines))
		{
			if (this.Outlines[this.ID].h != null)
			{
				this.Outlines[this.ID].h.ReinitMaterials();
			}
			this.ID++;
		}
		if (!this.Male)
		{
			this.SkirtCollider.enabled = true;
			this.PantyCollider.enabled = true;
		}
	}

	public virtual void AttackOnTitan()
	{
		this.CharacterAnimation.CrossFade(this.WalkAnim);
		this.Phone.active = false;
		this.OnPhone = false;
		this.AoT = true;
		float y = 0.0825f;
		Vector3 center = this.MyController.center;
		float num = center.y = y;
		Vector3 vector = this.MyController.center = center;
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
		((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).Originator = this;
		if (this.Splashed)
		{
			((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).Shocking = true;
			((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).NoScream = true;
		}
		if (this.Dying && this.Yandere.Equipped > 0 && this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 7)
		{
			((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).Long = true;
		}
	}

	public virtual void ChangeClubwear()
	{
		if (!this.ClubAttire)
		{
			this.ClubAttire = true;
			if (this.Club == 6)
			{
				this.MyRenderer.sharedMesh = this.JudoGiMesh;
				if (!this.Male)
				{
					this.MyRenderer.materials[0].mainTexture = this.JudoGiTexture;
					this.MyRenderer.materials[1].mainTexture = this.JudoGiTexture;
					this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
					this.SkirtCollider.enabled = false;
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
				float z = 0.01f;
				Vector3 localPosition = this.Armband.transform.localPosition;
				float num = localPosition.z = z;
				Vector3 vector = this.Armband.transform.localPosition = localPosition;
				this.Armband.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
			}
		}
		else
		{
			this.ChangeSchoolwear();
			this.ClubAttire = false;
			if (this.StudentID == 21)
			{
				float z2 = 0.012f;
				Vector3 localPosition2 = this.Armband.transform.localPosition;
				float num2 = localPosition2.z = z2;
				Vector3 vector2 = this.Armband.transform.localPosition = localPosition2;
				this.Armband.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
			}
		}
	}

	public virtual void CameraReact()
	{
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Obstacle.enabled = true;
		this.CameraReacting = true;
		this.CameraReactPhase = 1;
		this.Routine = false;
		if (!this.Yandere.ClubAccessories[7].active)
		{
			this.CharacterAnimation.CrossFade(this.CameraAnims[1]);
		}
		else
		{
			this.CharacterAnimation.CrossFade(this.IdleAnim);
		}
	}

	public virtual void LookForYandere()
	{
		if (!this.Yandere.Chased)
		{
			this.Planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
			if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.collider.bounds))
			{
				RaycastHit raycastHit = default(RaycastHit);
				Debug.DrawLine(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), Color.green);
				if (Physics.Linecast(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), out raycastHit) && raycastHit.collider.gameObject == this.Yandere.gameObject)
				{
					this.ReportPhase++;
				}
			}
		}
	}

	public virtual void UpdatePerception()
	{
		if (PlayerPrefs.GetInt("Club") == 3 || PlayerPrefs.GetInt("StealthBonus") > 0)
		{
			this.Perception = 0.5f;
		}
		else
		{
			this.Perception = (float)1;
		}
	}

	public virtual void StopInvestigating()
	{
		UnityEngine.Object.Destroy(this.Giggle);
		this.CurrentDestination = this.Destinations[this.Phase];
		this.Pathfinding.target = this.Destinations[this.Phase];
		this.InvestigationTimer = (float)0;
		this.InvestigationPhase = 0;
		this.YandereInnocent = false;
		this.Investigating = false;
		this.DiscCheck = false;
		this.Routine = true;
	}

	public virtual void LovedOneCheck()
	{
		if (this.Yandere.TargetStudent != null)
		{
			if (this.StudentID == 14 && this.Yandere.TargetStudent.StudentID == 15)
			{
				this.Strength = 5;
				this.Persona = 3;
			}
			else if (this.StudentID == 15 && this.Yandere.TargetStudent.StudentID == 14)
			{
				this.Strength = 5;
				this.Persona = 3;
			}
			else if (this.StudentID == 17 && this.Yandere.TargetStudent.StudentID == 18)
			{
				this.Strength = 5;
				this.Persona = 3;
			}
			else if (this.StudentID == 18 && this.Yandere.TargetStudent.StudentID == 17)
			{
				this.Strength = 5;
				this.Persona = 3;
			}
		}
	}

	public virtual void Main()
	{
	}
}
