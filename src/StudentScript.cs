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

	public ClubManagerScript ClubManager;

	public LightSwitchScript LightSwitch;

	public MovingEventScript MovingEvent;

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

	public JsonScript JSON;

	public CharacterController MyController;

	public Projector LiquidProjector;

	public ParticleSystem Hearts;

	public Texture BloodTexture;

	public Texture WaterTexture;

	public Camera VisionCone;

	public SkinnedMeshRenderer MyRenderer;

	public Transform CurrentDestination;

	public Transform TeacherTalkPoint;

	public Transform Distraction;

	public Transform ItemParent;

	public Transform MyReporter;

	public Transform WitnessPOV;

	public Transform RightDrill;

	public Transform LeftDrill;

	public Transform RightHand;

	public Transform LeftHand;

	public Transform MeetSpot;

	public Transform Eyes;

	public Transform Head;

	public ParticleSystem[] LiquidEmitters;

	public string[] DestinationNames;

	public Transform[] Destinations;

	public OutlineScript[] Outlines;

	public GameObject[] Chopsticks;

	public string[] AnimationNames;

	public string[] ActionNames;

	public float[] PhaseTimes;

	public GameObject[] Bones;

	public Transform[] Arm;

	public LayerMask Mask;

	public Plane[] Planes;

	public int[] Actions;

	public AudioClip[] FemaleAttacks;

	public AudioClip[] MaleAttacks;

	public SphereCollider HipCollider;

	public Collider NotFaceCollider;

	public Collider PantyCollider;

	public Collider SkirtCollider;

	public Collider FaceCollider;

	public GameObject RightEmptyEye;

	public GameObject LeftEmptyEye;

	public GameObject DeathScream;

	public GameObject BloodSpray;

	public GameObject MainCamera;

	public GameObject OccultBook;

	public GameObject AlarmDisc;

	public GameObject Character;

	public GameObject Armband;

	public GameObject Marker;

	public GameObject Bento;

	public GameObject Phone;

	public bool WitnessedCorpse;

	public bool WitnessedMurder;

	public bool RepeatReaction;

	public bool WitnessedBlood;

	public bool YandereVisible;

	public bool FleeWhenClean;

	public bool MurderSuicide;

	public bool ClubActivity;

	public bool Complimented;

	public bool Electrocuted;

	public bool PlayingAudio;

	public bool ClubAttire;

	public bool Distracted;

	public bool InDarkness;

	public bool SwitchBack;

	public bool BatheFast;

	public bool DiscCheck;

	public bool DressCode;

	public bool Drownable;

	public bool Gossiped;

	public bool Pushable;

	public bool Splashed;

	public bool Tranquil;

	public bool Alarmed;

	public bool BadTime;

	public bool Drowned;

	public bool Forgave;

	public bool InEvent;

	public bool OnPhone;

	public bool Private;

	public bool Reacted;

	public bool SawMask;

	public bool Teacher;

	public bool Witness;

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

	public bool Emo;

	public bool Fed;

	public bool Shy;

	public bool Wet;

	public bool Won;

	public bool DK;

	public bool CameraReacting;

	public bool Distracting;

	public bool Following;

	public bool Reporting;

	public bool Fleeing;

	public bool Hunting;

	public bool Meeting;

	public bool Talking;

	public bool Waiting;

	public bool Dying;

	public float DistanceToDestination;

	public float DistanceToPlayer;

	public float TargetDistance;

	public float CameraPoseTimer;

	public float DistractTimer;

	public float ReactionTimer;

	public float ElectroTimer;

	public float GoAwayTimer;

	public float IgnoreTimer;

	public float ReportTimer;

	public float SplashTimer;

	public float AlarmTimer;

	public float StuckTimer;

	public float MeetTimer;

	public float TalkTimer;

	public float WaitTimer;

	public float PreviousAlarm;

	public float RepDeduction;

	public float BreastSize;

	public float PendingRep;

	public float Perception;

	public float EyeShrink;

	public float MeetTime;

	public float Paranoia;

	public float RepLoss;

	public float Alarm;

	public int CameraReactPhase;

	public int SplashPhase;

	public int BathePhase;

	public int ClubPhase;

	public int TaskPhase;

	public int Phase;

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

	public string[] CameraAnims;

	public string[] SocialAnims;

	public string[] CowardAnims;

	public string[] EvilAnims;

	public string[] HeroAnims;

	public string[] TaskAnims;

	public int ClubMemberID;

	public int ReportPhase;

	public int StudentID;

	public int Persona;

	public int Class;

	public int Club;

	public int ID;

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
		this.MaxSpeed = 10f;
	}

	public virtual void Start()
	{
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
		this.OriginalPersona = this.Persona;
		if (this.Persona == 1 || this.Persona == 4)
		{
			this.CameraAnims = this.CowardAnims;
		}
		if (this.Persona == 2 || this.Persona == 3 || this.Persona == 9)
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
		if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Slave") == 1)
		{
			this.Phone.active = false;
			this.OnPhone = false;
			this.Slave = true;
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.PhaseTimes))
			{
				this.PhaseTimes[this.ID] = (float)0;
				this.ID++;
			}
		}
		if (PlayerPrefs.GetInt("Club_" + this.Club + "_Closed") == 1)
		{
			this.Club = 0;
		}
		this.GetDestinations();
		this.DialogueWheel = (DialogueWheelScript)GameObject.Find("DialogueWheel").GetComponent(typeof(DialogueWheelScript));
		this.ClubManager = (ClubManagerScript)GameObject.Find("ClubManager").GetComponent(typeof(ClubManagerScript));
		this.StruggleBar = (StruggleBarScript)GameObject.Find("StruggleBar").GetComponent(typeof(StruggleBarScript));
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
			this.Character.animation[this.StripAnim].speed = 1.5f;
			this.Character.animation[this.GameAnim].speed = (float)2;
			if (this.Club == 100)
			{
				this.BecomeTeacher();
			}
			this.Character.animation[this.CarryAnim].layer = 9;
			this.Character.animation.Play(this.CarryAnim);
			this.Character.animation[this.CarryAnim].weight = (float)0;
			this.Character.animation[this.SocialSitAnim].layer = 8;
			this.Character.animation.Play(this.SocialSitAnim);
			this.Character.animation[this.SocialSitAnim].weight = (float)0;
			this.Character.animation[this.ShyAnim].layer = 7;
			this.Character.animation.Play(this.ShyAnim);
			this.Character.animation[this.ShyAnim].weight = (float)0;
			this.Character.animation[this.FistAnim].layer = 6;
			this.Character.animation[this.FistAnim].weight = (float)0;
			this.Character.animation[this.BrokenWalkAnim].layer = 5;
			this.Character.animation[this.BrokenWalkAnim].weight = (float)0;
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
			if (!this.Slave)
			{
				this.Character.animation.Play(this.PhoneAnim);
				UnityEngine.Object.Destroy(this.RightEmptyEye);
				UnityEngine.Object.Destroy(this.LeftEmptyEye);
				UnityEngine.Object.Destroy(this.Broken);
			}
			this.Character.animation["f02_wetIdle_00"].speed = 1.25f;
			if (!this.Teacher)
			{
				if (this.Persona == 5)
				{
					this.ScaredAnim = this.EvilWitnessAnim;
				}
				this.Character.animation[this.CameraAnims[1]].speed = (float)2;
				this.Character.animation[this.CameraAnims[3]].speed = (float)2;
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
			while (this.ID < Extensions.get_length(this.Bones))
			{
				this.Bones[this.ID].active = false;
				this.ID++;
			}
		}
		else
		{
			this.Character.animation["scaredFace_00"].layer = 4;
			this.Character.animation.Play("scaredFace_00");
			this.Character.animation["scaredFace_00"].weight = (float)0;
			this.Character.animation[this.SadFaceAnim].layer = 3;
			this.Character.animation.Play(this.SadFaceAnim);
			this.Character.animation[this.SadFaceAnim].weight = (float)0;
			this.Character.animation[this.AngryFaceAnim].layer = 2;
			this.Character.animation.Play(this.AngryFaceAnim);
			this.Character.animation[this.AngryFaceAnim].weight = (float)0;
			this.Character.animation[this.PhoneAnim].layer = 1;
			this.Character.animation.Play(this.PhoneAnim);
			this.Character.animation[this.PhoneAnim].weight = (float)0;
		}
		if (this.Club == 3)
		{
			if (this.StudentID == 26)
			{
				this.ClubAnim = this.IdleAnim;
			}
			else
			{
				if (this.Male)
				{
					this.Character.animation[this.SadFaceAnim].weight = (float)1;
				}
				if (this.StudentID == 27)
				{
					this.ClubAnim = "sitRead_00";
				}
				else if (this.StudentID == 28)
				{
					this.ClubAnim = "f02_sitRead_00";
				}
				else if (this.StudentID == 29)
				{
					this.ClubAnim = "sitRead_00";
				}
				else if (this.StudentID == 30)
				{
					this.ClubAnim = "f02_sitRead_00";
				}
				else if (this.StudentID == 31)
				{
					this.ClubAnim = "sitRead_00";
				}
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
		if (this.AoT)
		{
			this.AttackOnTitan();
		}
		else
		{
			this.OnPhone = true;
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
		}
		if (this.Club != 0 && (this.StudentID == 21 || this.StudentID == 26))
		{
			this.Armband.active = true;
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
					if (this.Clock.HourTime >= this.PhaseTimes[this.Phase] && !this.InEvent && !this.Meeting)
					{
						this.Phase++;
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.GoAway = false;
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
								this.CurrentDestination = this.ChangingBooth.transform;
								this.Pathfinding.target = this.ChangingBooth.transform;
							}
							else
							{
								this.CurrentDestination = this.ChangingBooth.WaitSpots[this.ClubMemberID];
								this.Pathfinding.target = this.ChangingBooth.WaitSpots[this.ClubMemberID];
							}
						}
						else
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
						this.Character.animation.CrossFade(this.WalkAnim);
						this.Character.animation[this.WalkAnim].speed = this.Pathfinding.currentSpeed;
					}
					else
					{
						this.Character.animation.CrossFade(this.SprintAnim);
					}
					if (this.Club == 3 && this.Actions[this.Phase] != 8)
					{
						this.OccultBook.active = false;
					}
				}
				else
				{
					this.MoveTowardsTarget(this.CurrentDestination.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, (float)10 * Time.deltaTime);
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
									this.Character.animation.CrossFade(this.IdleAnim);
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
								this.Character.animation.CrossFade(this.IdleAnim);
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
									this.Character.animation.CrossFade(this.IdleAnim);
								}
								else if (this.Actions[this.Phase] == 1)
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
								else if (this.Actions[this.Phase] == 2)
								{
									this.Character.animation.CrossFade(this.GameAnim);
								}
								else if (this.Actions[this.Phase] == 3)
								{
									this.Character.animation.CrossFade(this.SadSitAnim);
								}
								else if (this.Actions[this.Phase] == 4)
								{
									this.Character.animation.CrossFade(this.BrokenAnim);
								}
								else if (this.Actions[this.Phase] == 5)
								{
									this.Character.animation.CrossFade(this.RelaxAnim);
								}
								else if (this.Actions[this.Phase] == 6)
								{
									if (this.DressCode && this.ClubAttire)
									{
										this.Character.animation.CrossFade(this.IdleAnim);
									}
									else
									{
										this.Character.animation.CrossFade(this.SitAnim);
									}
								}
								else if (this.Actions[this.Phase] == 7)
								{
									this.Character.animation.CrossFade(this.StalkAnim);
								}
								else if (this.Actions[this.Phase] == 8)
								{
									if (this.DressCode && !this.ClubAttire)
									{
										this.Character.animation.CrossFade(this.IdleAnim);
									}
									else
									{
										this.Character.animation.CrossFade(this.ClubAnim);
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
								this.Character.animation.CrossFade(this.IdleAnim);
								this.GoAwayTimer += Time.deltaTime;
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
			}
			else
			{
				if (this.CurrentDestination != null)
				{
					this.DistanceToDestination = Vector3.Distance(this.transform.position, this.CurrentDestination.position);
				}
				if (this.Fleeing)
				{
					this.DistanceToDestination = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
					if (this.AlarmTimer > (float)0)
					{
						this.AlarmTimer = Mathf.MoveTowards(this.AlarmTimer, (float)0, Time.deltaTime);
						if (this.AlarmTimer == (float)0)
						{
							this.Alarmed = false;
						}
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
					else
					{
						if (this.Persona == 2 && this.StudentManager.Reporter == null && !this.Police.Called)
						{
							this.Pathfinding.target = this.StudentManager.Teachers[this.Class].TeacherTalkPoint;
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
						if (this.transform.position.z < (float)-49)
						{
							this.Prompt.Hide();
							this.Prompt.enabled = false;
							this.Safe = true;
						}
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
											this.ID = 0;
											while (this.ID < Extensions.get_length(this.Outlines))
											{
												this.Outlines[this.ID].color = new Color((float)1, (float)1, (float)0, (float)1);
												this.ID++;
											}
										}
									}
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
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Yandere.transform.rotation, (float)10 * Time.deltaTime);
									this.transform.position = Vector3.Lerp(this.transform.position, this.Yandere.transform.position + this.Yandere.transform.forward * 0.0001f, Time.deltaTime * (float)10);
									if (!this.Yandere.Armed || !this.Yandere.Weapon[this.Yandere.Equipped].Concealable)
									{
										this.StruggleBar.HeroWins();
									}
									if (this.Lost)
									{
										this.Character.animation.CrossFade(this.StruggleWonAnim);
										if (this.Character.animation[this.StruggleWonAnim].time > (float)1)
										{
											this.EyeShrink = (float)1;
										}
										if (this.Character.animation[this.StruggleWonAnim].time >= this.Character.animation[this.StruggleWonAnim].length)
										{
											this.BecomeRagdoll();
											this.Dead = true;
										}
									}
									else if (this.Won)
									{
										this.Character.animation.CrossFade(this.StruggleLostAnim);
									}
								}
							}
							else if (this.Persona == 4)
							{
								this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
								this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
								this.Character.animation.CrossFade(this.CowardAnim);
								this.ReactionTimer += Time.deltaTime;
								if (this.ReactionTimer > (float)5)
								{
									this.CurrentDestination = this.StudentManager.Exit;
									this.Pathfinding.target = this.StudentManager.Exit;
								}
							}
							else if (this.Persona == 5)
							{
								this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
								this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
								this.Character.animation.CrossFade(this.EvilAnim);
								this.ReactionTimer += Time.deltaTime;
								if (this.ReactionTimer > (float)5)
								{
									this.CurrentDestination = this.StudentManager.Exit;
									this.Pathfinding.target = this.StudentManager.Exit;
								}
							}
							else if (this.Persona == 6)
							{
								if (this.ReportPhase == 1)
								{
									this.targetRotation = Quaternion.LookRotation(this.Pathfinding.target.position - this.Pathfinding.target.forward - this.transform.position);
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
									if (!this.Phone.active)
									{
										if (this.StudentManager.Reporter == null && !this.Police.Called)
										{
											this.Character.animation.CrossFade(this.SocialReportAnim);
											this.Subtitle.UpdateLabel("Social Report", 1, (float)5);
											this.StudentManager.Reporter = this;
											this.Phone.active = true;
										}
										else
										{
											this.ReportTimer = (float)5;
										}
									}
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer > (float)5)
									{
										if (this.StudentManager.Reporter == this)
										{
											this.Police.Called = true;
											this.Police.Show = true;
										}
										this.Character.animation.CrossFade(this.ParanoidAnim);
										this.Phone.active = false;
										this.ReportPhase++;
									}
								}
								else if (this.ReportPhase == 2)
								{
									if (this.WitnessedMurder)
									{
										this.LookForYandere();
									}
								}
								else if (this.ReportPhase == 3)
								{
									this.Character.animation.CrossFade(this.SocialFearAnim);
									this.Subtitle.UpdateLabel("Social Fear", 1, (float)5);
									this.SpawnAlarmDisc();
									this.ReportPhase++;
								}
								else if (this.ReportPhase == 4)
								{
									this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
									this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
									if (this.Yandere.Attacking)
									{
										this.LookForYandere();
									}
								}
								else if (this.ReportPhase == 5)
								{
									this.Character.animation.CrossFade(this.SocialTerrorAnim);
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
										this.Character.animation.CrossFade(this.IdleAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= (float)3)
										{
											if (this.StudentManager.CorpseLocation.position == new Vector3((float)0, (float)0, (float)0))
											{
												this.StudentManager.CorpseLocation.position = this.StudentManager.Reporter.Corpse.AllColliders[0].transform.position;
											}
											if (!this.StudentManager.Reporter.Teacher)
											{
												this.StudentManager.Reporter.Pathfinding.target = this.StudentManager.CorpseLocation;
											}
											this.Pathfinding.target = this.StudentManager.CorpseLocation;
											this.StudentManager.Reporter.TargetDistance = (float)2;
											this.StudentManager.Reporter.Halt = true;
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
											if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.Corpse, "Natural"), true))
											{
												this.Police.Timer = 1E-06f;
											}
											this.Character.animation.CrossFade(this.KneelScanAnim);
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
									this.Yandere.Mopping = false;
									this.Yandere.EmptyHands();
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
								this.Distracted = true;
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
										this.InDarkness = false;
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
										this.RightDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
										this.LeftDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
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
										this.RightDrill.localEulerAngles = new Vector3((float)0, (float)0, 68.30447f);
										this.LeftDrill.localEulerAngles = new Vector3((float)0, (float)-180, -159.417f);
										this.LightSwitch.Flicker = false;
										this.Unspook();
										this.UnWet();
									}
								}
								else if (this.Character.animation["f02_electrocution_00"].time >= this.Character.animation["f02_electrocution_00"].length)
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
				if (this.Distracting)
				{
					if (this.DistanceToDestination < this.TargetDistance)
					{
						if (!this.DistractionTarget.Distracted)
						{
							this.DistractionTarget.Pathfinding.canSearch = false;
							this.DistractionTarget.Pathfinding.canMove = false;
							this.DistractionTarget.Distraction = this.transform;
							this.DistractionTarget.Pathfinding.speed = (float)0;
							this.DistractionTarget.Distracted = true;
							this.DistractionTarget.Routine = false;
							this.DistractionTarget.InEvent = true;
							this.Pathfinding.speed = (float)0;
							this.Distracted = true;
						}
						this.targetRotation = Quaternion.LookRotation(this.DistractionTarget.transform.position - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
						this.Character.animation.CrossFade(this.RandomAnim);
						if (this.Character.animation[this.RandomAnim].time >= this.Character.animation[this.RandomAnim].length)
						{
							this.PickRandomAnim();
						}
						this.DistractTimer -= Time.deltaTime;
						if (this.DistractTimer <= (float)0)
						{
							this.CurrentDestination = this.Destinations[this.Phase];
							this.Pathfinding.target = this.Destinations[this.Phase];
							this.DistractionTarget.Pathfinding.canSearch = true;
							this.DistractionTarget.Pathfinding.canMove = true;
							this.DistractionTarget.Pathfinding.speed = (float)1;
							this.DistractionTarget.Distraction = null;
							this.DistractionTarget.Distracted = false;
							this.DistractionTarget.InEvent = false;
							this.DistractionTarget.Routine = true;
							this.Pathfinding.speed = (float)1;
							this.Distracting = false;
							this.Distracted = false;
							this.InEvent = false;
							this.Routine = true;
						}
					}
					else
					{
						this.Character.animation.CrossFade(this.RunAnim);
					}
				}
				if (this.Hunting && this.StudentManager.Students[7] != null)
				{
					if (this.StudentManager.Students[7].Prompt.enabled)
					{
						this.StudentManager.Students[7].Prompt.Hide();
						this.StudentManager.Students[7].Prompt.enabled = false;
					}
					this.Pathfinding.target = this.StudentManager.Students[7].transform;
					this.CurrentDestination = this.StudentManager.Students[7].transform;
					if (!this.StudentManager.Students[7].Safe)
					{
						if (!this.StudentManager.Students[7].Dead)
						{
							if (this.DistanceToDestination > this.TargetDistance)
							{
								if (!this.Pathfinding.canMove)
								{
									this.Pathfinding.canSearch = true;
									this.Pathfinding.canMove = true;
									this.Pathfinding.speed = 1.1f;
									this.Character.animation[this.WalkAnim].weight = this.Pathfinding.speed;
									this.Character.animation.CrossFade(this.WalkAnim);
									this.Character.animation[this.BrokenWalkAnim].weight = (float)1;
									this.Character.animation.Blend(this.BrokenWalkAnim);
								}
							}
							else if (this.Pathfinding.canMove)
							{
								this.Character.animation.CrossFade(this.AttackAnim);
								this.Pathfinding.canSearch = false;
								this.Pathfinding.canMove = false;
								this.Broken.Done = true;
								this.StudentManager.Students[7].WitnessCamera.Show = false;
								this.StudentManager.Students[7].Pathfinding.canSearch = false;
								this.StudentManager.Students[7].Pathfinding.canMove = false;
								this.StudentManager.Students[7].DetectionMarker.Tex.enabled = false;
								this.StudentManager.Students[7].MyController.radius = (float)0;
								this.StudentManager.Students[7].Alarmed = false;
								this.StudentManager.Students[7].Fleeing = false;
								this.StudentManager.Students[7].Routine = false;
								this.StudentManager.Students[7].Prompt.Hide();
								this.StudentManager.Students[7].Prompt.enabled = false;
								this.StudentManager.Students[7].Distracting = false;
								this.StudentManager.Students[7].EyeShrink = (float)1;
								this.StudentManager.Students[7].Character.animation.CrossFade(this.StudentManager.Students[7].DefendAnim);
								this.StudentManager.Students[7].Subtitle.UpdateLabel("Dying", 0, (float)1);
								this.StudentManager.Students[7].SpawnAlarmDisc();
								if (this.StudentManager.Students[7].Following)
								{
									this.Yandere.Followers = this.Yandere.Followers - 1;
									this.Hearts.enableEmission = false;
									this.StudentManager.Students[7].Following = false;
								}
							}
							else if (this.Character.animation["f02_stab_00"].time > this.Character.animation["f02_stab_00"].length * 0.35f)
							{
								this.Character.animation.CrossFade(this.BrokenAnim);
								this.StudentManager.Students[7].BloodSpray.active = true;
								this.MyWeapon.Blood.enabled = true;
								this.MyWeapon.Victims[7] = true;
								this.LiquidProjector.enabled = true;
								this.LiquidProjector.material.mainTexture = this.BloodTexture;
								this.Broken.PlayClip(this.Broken.Stab, this.Broken.transform.position);
								UnityEngine.Object.Destroy(this.StudentManager.Students[7].DeathScream);
								this.StudentManager.Students[7].Dying = true;
								this.StudentManager.Students[7].Dead = true;
							}
							else
							{
								this.Character.animation[this.BrokenWalkAnim].weight = this.Character.animation[this.BrokenWalkAnim].weight - Time.deltaTime * 3.33333f;
								this.targetRotation = Quaternion.LookRotation(this.StudentManager.Students[7].transform.position - this.transform.position);
								this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
								this.StudentManager.Students[7].targetRotation = Quaternion.LookRotation(this.transform.position - this.StudentManager.Students[7].transform.position);
								this.StudentManager.Students[7].transform.rotation = Quaternion.Slerp(this.StudentManager.Students[7].transform.rotation, this.StudentManager.Students[7].targetRotation, Time.deltaTime * (float)10);
								this.StudentManager.Students[7].MoveTowardsTarget(this.transform.position + this.transform.forward * 0.1f);
							}
						}
						else
						{
							this.Broken.SuicideTimer = this.Broken.SuicideTimer + Time.deltaTime;
							if (this.Broken.SuicideTimer > (float)5)
							{
								this.Character.animation.CrossFade(this.SuicideAnim);
								if (this.Broken.SuicideTimer > 16.1f && !this.Broken.Stabbed)
								{
									this.Broken.PlayClip(this.Broken.Stab, this.Broken.transform.position);
									this.Broken.Stabbed = true;
									this.MyWeapon.Victims[this.StudentID] = true;
								}
								if (this.Character.animation[this.SuicideAnim].time >= this.Character.animation[this.SuicideAnim].length)
								{
									this.Police.MurderSuicideScene = true;
									this.StudentManager.MurderTakingPlace = false;
									this.MyWeapon.transform.parent = this.Head;
									UnityEngine.Object.Destroy(this.MyWeapon.gameObject.rigidbody);
									this.Broken.enabled = false;
									this.Broken.Subtitle.text = string.Empty;
									this.BecomeRagdoll();
									this.MurderSuicide = true;
									this.Dead = true;
								}
							}
						}
					}
				}
				if (this.CameraReacting)
				{
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
					if (!this.Yandere.ClubAccessories[7].active)
					{
						if (this.CameraReactPhase == 1)
						{
							if (this.Character.animation[this.CameraAnims[1]].time >= this.Character.animation[this.CameraAnims[1]].length)
							{
								this.Character.animation.CrossFade(this.CameraAnims[2]);
								this.CameraReactPhase = 2;
								this.CameraPoseTimer = (float)1;
							}
						}
						else if (this.CameraReactPhase == 2)
						{
							this.CameraPoseTimer -= Time.deltaTime;
							if (this.CameraPoseTimer <= (float)0)
							{
								this.Character.animation.CrossFade(this.CameraAnims[3]);
								this.CameraReactPhase = 3;
							}
						}
						else if (this.CameraReactPhase == 3)
						{
							if (this.CameraPoseTimer == (float)1)
							{
								this.Character.animation.CrossFade(this.CameraAnims[2]);
								this.CameraReactPhase = 2;
							}
							if (this.Character.animation[this.CameraAnims[3]].time >= this.Character.animation[this.CameraAnims[3]].length)
							{
								this.Obstacle.enabled = false;
								this.CameraReacting = false;
								this.Routine = true;
							}
						}
					}
					else if (this.Yandere.Shutter.TargetStudent != this.StudentID)
					{
						this.CameraPoseTimer -= Time.deltaTime;
						if (this.CameraPoseTimer <= (float)0)
						{
							this.Obstacle.enabled = false;
							this.CameraReacting = false;
							this.Routine = true;
						}
					}
					else
					{
						this.CameraPoseTimer = (float)1;
					}
					if (this.InEvent)
					{
						this.CameraReacting = false;
					}
				}
			}
			if (!this.Dying)
			{
				if (!this.Distracted)
				{
					if (this.Character.animation[this.PhoneAnim].weight > (float)0)
					{
						if (this.Character.animation[this.PhoneAnim].weight > 0.1f)
						{
							this.Character.animation[this.PhoneAnim].weight = Mathf.Lerp(this.Character.animation[this.PhoneAnim].weight, (float)0, Time.deltaTime * (float)10);
						}
						else
						{
							this.Character.animation[this.PhoneAnim].weight = (float)0;
						}
					}
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
										if ((this.Yandere.Armed && this.Yandere.Weapon[this.Yandere.Equipped].Suspicious) || (this.Yandere.Bloodiness > (float)0 && !this.Yandere.Paint) || (this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Dragging || this.Yandere.Lewd || (this.Yandere.Laughing && this.Yandere.LaughIntensity > (float)15)) || (this.Private && this.Yandere.Trespassing) || (this.Teacher && this.Yandere.Trespassing) || (this.StudentID == 1 && this.Yandere.NearSenpai && !this.Yandere.Talking))
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
														if (this.Yandere.Attacking || this.Yandere.Struggling || (this.Yandere.NearBodies > 0 && this.Yandere.Bloodiness > (float)0 && !this.Yandere.Paint) || (this.Yandere.NearBodies > 0 && this.Yandere.Armed) || (this.Yandere.NearBodies > 0 && this.Yandere.Sanity < 66.66666f) || this.Yandere.Dragging)
														{
															this.WitnessMurder();
														}
														else if (!this.Fleeing)
														{
															if (!this.Alarmed && this.IgnoreTimer <= (float)0)
															{
																this.Alarm += Time.deltaTime * ((float)100 / this.DistanceToPlayer) * this.Paranoia * this.Perception;
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
							if (this.StudentID > 1)
							{
								this.ID = 0;
								while (this.ID < Extensions.get_length(this.Outlines))
								{
									this.Outlines[this.ID].color = new Color((float)1, (float)1, (float)0, (float)1);
									this.ID++;
								}
							}
							this.Character.animation.CrossFade(this.IdleAnim);
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.CameraReacting = false;
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
								this.WitnessedBlood = false;
								if (this.Yandere.Bloodiness > (float)0 && !this.Yandere.Paint)
								{
									this.WitnessedBlood = true;
								}
								if (flag && this.WitnessedBlood && this.Yandere.Sanity < 33.333f)
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
								if (this.StudentID == 1 && this.Yandere.Mask == null)
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
								if (this.Yandere.Mask == null)
								{
									this.RepDeduction = (float)0;
									if ((this.Male && PlayerPrefs.GetInt("Seduction") > 2) || PlayerPrefs.GetInt("Seduction") == 5)
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
									this.RepLoss -= this.RepDeduction;
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
					if (this.Distraction != null)
					{
						this.targetRotation = Quaternion.LookRotation(this.Distraction.position - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
						this.Character.animation.CrossFade(this.RandomAnim);
						if (this.Character.animation[this.RandomAnim].time >= this.Character.animation[this.RandomAnim].length)
						{
							this.PickRandomAnim();
						}
					}
					if (this.OnPhone)
					{
						this.Character.animation[this.PhoneAnim].weight = Mathf.Lerp(this.Character.animation[this.PhoneAnim].weight, (float)1, Time.deltaTime * (float)10);
						if (this.transform.position.z > (float)-49)
						{
							this.Phone.active = false;
							this.Distracted = false;
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
						this.Yandere.Weapon[this.Yandere.Equipped].transform.parent = this.ItemParent;
						this.Yandere.Weapon[this.Yandere.Equipped].transform.localPosition = new Vector3((float)0, (float)0, (float)0);
						this.Yandere.Weapon[this.Yandere.Equipped].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
						this.MyWeapon = this.Yandere.Weapon[this.Yandere.Equipped];
						this.MyWeapon.FingerprintID = this.StudentID;
						this.Character.animation.Play(this.FistAnim);
						this.Yandere.Weapon[this.Yandere.Equipped] = null;
						this.Yandere.Equipped = 0;
						this.Yandere.Armed = false;
						this.StudentManager.UpdateStudents();
						this.Yandere.WeaponManager.UpdateLabels();
						this.Yandere.WeaponMenu.UpdateSprites();
						this.Yandere.WeaponWarning = false;
						this.Broken.Hunting = true;
						this.TargetDistance = (float)1;
						this.Routine = false;
						this.Hunting = true;
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
						this.Character.animation.CrossFade(this.DrownAnim);
					}
					else if (this.Clock.Period == 2 || this.Clock.Period == 4)
					{
						this.Subtitle.UpdateLabel("Class Apology", 0, (float)3);
						this.Prompt.Circle[0].fillAmount = (float)1;
					}
					else if (this.InEvent || (this.Meeting && !this.Drownable) || this.Wet)
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
									if ((this.Male && PlayerPrefs.GetInt("Seduction") > 0) || PlayerPrefs.GetInt("Seduction") == 5)
									{
										this.Hearts.enableEmission = true;
									}
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
									if (this.Gossiped)
									{
										float a4 = 0.75f;
										Color color7 = this.DialogueWheel.Shadow[3].color;
										float num8 = color7.a = a4;
										Color color8 = this.DialogueWheel.Shadow[3].color = color7;
									}
									this.StudentManager.DisablePrompts();
									this.DialogueWheel.HideShadows();
									this.DialogueWheel.Show = true;
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
							this.Reacted = false;
							this.Talking = true;
							this.Routine = false;
						}
					}
				}
				if (this.Prompt.Circle[2].fillAmount <= (float)0 && !this.Yandere.NearSenpai && !this.Yandere.Attacking && !this.Yandere.Crouching)
				{
					this.AttackReaction();
				}
			}
			if (this.Dying)
			{
				if (this.Distracting)
				{
					this.DistractionTarget.Distracted = false;
					this.Distracting = false;
				}
				if (this.EventManager != null)
				{
					this.EventManager.EndEvent();
				}
				this.Alarm -= Time.deltaTime * (float)100 * ((float)1 / this.Paranoia);
				if (!this.Teacher)
				{
					this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1, Time.deltaTime * (float)10);
					if (!this.Dead && !this.Tranquil)
					{
						if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 7)
						{
							this.Character.animation.CrossFade(this.BuzzSawDeathAnim);
							this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
						}
						else if (!this.Yandere.Weapon[this.Yandere.Equipped].Concealable)
						{
							this.Character.animation.CrossFade(this.SwingDeathAnim);
							this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
						}
						else
						{
							this.Character.animation.CrossFade(this.DefendAnim);
							this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.1f);
						}
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
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
					if (!this.StudentManager.Stop)
					{
						this.StudentManager.StopMoving();
						this.Yandere.Laughing = false;
						this.Yandere.Dipping = false;
						this.Yandere.RPGCamera.enabled = false;
						this.Phone.active = false;
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
					if (this.StudentID > 1 && this.Persona != 5)
					{
						this.EyeShrink += Time.deltaTime * 0.2f;
					}
					this.Character.animation.CrossFade(this.ScaredAnim);
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
					if (!this.Yandere.Struggling)
					{
						if (this.Persona != 3)
						{
							this.AlarmTimer += Time.deltaTime;
						}
						else
						{
							this.AlarmTimer += Time.deltaTime * (float)5;
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
							this.Character.animation.CrossFade(this.ScaredAnim);
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
				if (this.WitnessedCorpse)
				{
					this.Character.animation.CrossFade(this.ScaredAnim);
				}
				else if (this.StudentID > 1)
				{
					this.Character.animation.CrossFade(this.IdleAnim);
				}
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
				else if (!this.DiscCheck)
				{
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
				}
				else
				{
					this.targetRotation = Quaternion.LookRotation(this.DistractionSpot - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
				}
				if (!this.Fleeing)
				{
					this.AlarmTimer += Time.deltaTime;
				}
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
							if (this.WitnessedMurder)
							{
								this.ChaseYandere();
							}
						}
						if (this.Concern == 5)
						{
							this.Character.animation[this.AngryFaceAnim].weight = (float)1;
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
					int num9 = 0;
					Vector3 position = this.transform.position;
					float num10 = position.y = (float)num9;
					Vector3 vector3 = this.transform.position = position;
				}
			}
			int num11 = 0;
			Vector3 eulerAngles = this.transform.eulerAngles;
			float num12 = eulerAngles.x = (float)num11;
			Vector3 vector4 = this.transform.eulerAngles = eulerAngles;
			int num13 = 0;
			Vector3 eulerAngles2 = this.transform.eulerAngles;
			float num14 = eulerAngles2.z = (float)num13;
			Vector3 vector5 = this.transform.eulerAngles = eulerAngles2;
			if (!this.Male)
			{
				if (!this.Splashed && this.Wet && !this.Dying && Mathf.Abs(this.BathePhase) == 1)
				{
					if (this.Character.animation[this.WetAnim].weight < (float)1)
					{
						this.Character.animation[this.WetAnim].weight = (float)1;
					}
				}
				else if (this.Character.animation[this.WetAnim].weight > (float)0)
				{
					this.Character.animation[this.WetAnim].weight = (float)0;
				}
			}
			if (this.Dying)
			{
				this.Character.animation.cullingType = AnimationCullingType.AlwaysAnimate;
			}
			if (this.Pathfinding.canMove && this.Pathfinding.currentSpeed > (float)0 && this.transform.position == this.LastPosition)
			{
				this.StuckTimer += Time.deltaTime;
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
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
		}
		else if (this.Police.Darkness.color.a < (float)1)
		{
			this.Character.animation.Play(this.ActivityAnim);
			if (this.Club == 6)
			{
				if (!this.Male)
				{
					if (this.Character.animation["f02_kick_23"].time > (float)1)
					{
						if (!this.PlayingAudio)
						{
							this.audio.clip = this.FemaleAttacks[UnityEngine.Random.Range(0, Extensions.get_length(this.FemaleAttacks))];
							this.audio.Play();
							this.PlayingAudio = true;
						}
						if (this.Character.animation["f02_kick_23"].time >= this.Character.animation["f02_kick_23"].length)
						{
							this.Character.animation["f02_kick_23"].time = (float)0;
							this.PlayingAudio = false;
						}
					}
				}
				else if (this.Character.animation["kick_24"].time > (float)1)
				{
					if (!this.PlayingAudio)
					{
						this.audio.clip = this.MaleAttacks[UnityEngine.Random.Range(0, Extensions.get_length(this.MaleAttacks))];
						this.audio.Play();
						this.PlayingAudio = true;
					}
					if (this.Character.animation["kick_24"].time >= this.Character.animation["kick_24"].length)
					{
						this.Character.animation["kick_24"].time = (float)0;
						this.PlayingAudio = false;
					}
				}
			}
		}
		if (this.AoT)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)10, (float)10, (float)10), Time.deltaTime);
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
		if (!this.Male)
		{
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			if (this.Emo)
			{
				if (this.Routine)
				{
					if ((this.Phase == 2 && this.DistanceToDestination < (float)1) || (this.Phase == 4 && this.DistanceToDestination < (float)1))
					{
						this.Character.animation[this.ShyAnim].weight = Mathf.Lerp(this.Character.animation[this.ShyAnim].weight, (float)0, Time.deltaTime);
					}
					else
					{
						this.Character.animation[this.ShyAnim].weight = Mathf.Lerp(this.Character.animation[this.ShyAnim].weight, (float)1, Time.deltaTime);
					}
				}
				else
				{
					this.Character.animation[this.ShyAnim].weight = Mathf.Lerp(this.Character.animation[this.ShyAnim].weight, (float)0, Time.deltaTime);
				}
			}
			if (this.Routine && !this.InEvent && !this.Meeting)
			{
				if (this.DistanceToDestination < this.TargetDistance && this.Actions[this.Phase] == 9)
				{
					this.Character.animation[this.SocialSitAnim].weight = Mathf.Lerp(this.Character.animation[this.SocialSitAnim].weight, (float)1, Time.deltaTime * (float)10);
				}
				else
				{
					this.Character.animation[this.SocialSitAnim].weight = Mathf.Lerp(this.Character.animation[this.SocialSitAnim].weight, (float)0, Time.deltaTime * (float)10);
				}
			}
			else
			{
				this.Character.animation[this.SocialSitAnim].weight = Mathf.Lerp(this.Character.animation[this.SocialSitAnim].weight, (float)0, Time.deltaTime * (float)10);
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
			if (this.MyController.enabled)
			{
				this.MyController.Move(a * (Time.deltaTime * (float)10 / Time.timeScale));
			}
		}
	}

	public virtual void AttackReaction()
	{
		this.WitnessCamera.Show = false;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Yandere.Character.animation["f02_idleShort_00"].time = (float)0;
		this.Yandere.Character.animation["f02_swingA_00"].time = (float)0;
		this.Yandere.MyController.radius = (float)0;
		this.Yandere.TargetStudent = this;
		this.Yandere.Obscurance.enabled = false;
		this.Yandere.YandereVision = false;
		this.Yandere.Attacking = true;
		this.Yandere.CanMove = false;
		this.DetectionMarker.Tex.enabled = false;
		this.OccultBook.active = false;
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
			this.Hearts.enableEmission = false;
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
		if (this.Yandere.Mask == null)
		{
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
			this.Hearts.enableEmission = false;
			this.Yandere.Followers = this.Yandere.Followers - 1;
			this.Following = false;
		}
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.WitnessedMurder = true;
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
			this.ChaseYandere();
		}
		else
		{
			this.SpawnAlarmDisc();
		}
		this.StudentManager.UpdateMe(this.StudentID);
	}

	public virtual void ChaseYandere()
	{
		this.CurrentDestination = this.Yandere.transform;
		this.Pathfinding.target = this.Yandere.transform;
		this.Pathfinding.speed = 7.5f;
		this.StudentManager.Portal.active = false;
		this.Yandere.Chased = true;
		this.TargetDistance = 0.5f;
		this.Fleeing = false;
		this.AlarmTimer = (float)0;
		this.StudentManager.UpdateStudents();
	}

	public virtual void PersonaReaction()
	{
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
		else if (this.Persona == 3)
		{
			if (!this.Yandere.Chased)
			{
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
			this.CurrentDestination = this.Destinations[this.Phase];
			this.Pathfinding.target = this.Destinations[this.Phase];
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

	public virtual void BeginStruggle()
	{
		Debug.Log("My name is " + this.Name + " and now I am fighting Yandere-chan.");
		if (this.Yandere.Dragging)
		{
			((RagdollScript)this.Yandere.Ragdoll.GetComponent(typeof(RagdollScript))).StopDragging();
		}
		this.StruggleBar.Strength = (float)this.Strength;
		this.StruggleBar.Struggling = true;
		this.StruggleBar.Student = this;
		this.Character.animation.CrossFade(this.StruggleAnim);
		this.ShoulderCamera.LastPosition = this.ShoulderCamera.transform.position;
		this.ShoulderCamera.Struggle = true;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Obstacle.enabled = true;
		this.Yandere.Character.animation["f02_struggleA_00"].time = (float)0;
		this.Yandere.StopLaughing();
		this.Yandere.StopAiming();
		this.Yandere.TargetStudent = this;
		this.Yandere.Obscurance.enabled = false;
		this.Yandere.YandereVision = false;
		this.Yandere.Struggling = true;
		this.Yandere.CanMove = false;
		this.Yandere.EmptyHands();
		this.Yandere.MyController.enabled = false;
		this.Yandere.RPGCamera.enabled = false;
		this.MyController.enabled = false;
	}

	public virtual void GetDestinations()
	{
		if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Slave") == 0)
		{
			this.DestinationNames = (string[])this.JSON.StudentDestinations[this.StudentID].ToBuiltin(typeof(string));
			this.ActionNames = (string[])this.JSON.StudentActions[this.StudentID].ToBuiltin(typeof(string));
		}
		else
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
			else if (this.DestinationNames[this.ID] == "Slave")
			{
				this.Destinations[this.ID] = this.StudentManager.SlaveSpot;
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
			else if (this.ActionNames[this.ID] == "Club")
			{
				if (this.Club > 0)
				{
					this.Actions[this.ID] = 8;
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
		this.VisionCone.farClipPlane = (float)12 * this.Paranoia;
		this.StudentManager.Teachers[this.Class] = this;
		this.PantyCollider.enabled = false;
		this.SkirtCollider.enabled = false;
		this.name = "Teacher_" + this.Class;
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
		this.Hearts.enableEmission = false;
		this.FaceCollider.enabled = false;
		this.MyController.enabled = false;
		this.Pathfinding.enabled = false;
		this.HipCollider.enabled = true;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.enabled = false;
		this.UnWet();
		this.Ragdoll.DetectionMarker = this.DetectionMarker;
		this.Ragdoll.RightEyeOrigin = this.RightEyeOrigin;
		this.Ragdoll.LeftEyeOrigin = this.LeftEyeOrigin;
		this.Ragdoll.Electrocuted = this.Electrocuted;
		this.Ragdoll.BreastSize = this.BreastSize;
		this.Ragdoll.EyeShrink = this.EyeShrink;
		this.Ragdoll.StudentID = this.StudentID;
		this.Ragdoll.Tranquil = this.Tranquil;
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

	public virtual void Nude()
	{
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
		this.Character.animation[this.PhoneAnim].weight = (float)0;
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
		if (this.Dying && this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 7)
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
			this.Character.animation.CrossFade(this.CameraAnims[1]);
		}
		else
		{
			this.Character.animation.CrossFade(this.IdleAnim);
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
				Debug.DrawLine(this.Eyes.transform.position, this.Yandere.transform.position + Vector3.up * (float)1, Color.green);
				if (Physics.Linecast(this.Eyes.transform.position, this.Yandere.transform.position + Vector3.up * (float)1, out raycastHit) && raycastHit.collider.gameObject == this.Yandere.gameObject)
				{
					this.ReportPhase++;
				}
			}
		}
	}

	public virtual void UpdatePerception()
	{
		if (PlayerPrefs.GetInt("Club") == 3)
		{
			this.Perception = 0.5f;
		}
		else
		{
			this.Perception = (float)1;
		}
	}

	public virtual void Main()
	{
	}
}
