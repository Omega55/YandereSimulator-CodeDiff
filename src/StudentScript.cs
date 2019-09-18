using System;
using System.Collections.Generic;
using FIMSpace.FLook;
using Pathfinding;
using UnityEngine;

public class StudentScript : MonoBehaviour
{
	public Quaternion targetRotation;

	public Quaternion OriginalRotation;

	public Quaternion OriginalPlateRotation;

	public SelectiveGrayscale ChaseSelectiveGrayscale;

	public DrinkingFountainScript DrinkingFountain;

	public DetectionMarkerScript DetectionMarker;

	public ChemistScannerScript ChemistScanner;

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

	public WeaponScript WeaponToTakeAway;

	public DynamicGridObstacle Obstacle;

	public PhoneEventScript PhoneEvent;

	public PickpocketScript PickPocket;

	public ReputationScript Reputation;

	public StudentScript TargetStudent;

	public GenericBentoScript MyBento;

	public StudentScript FollowTarget;

	public CountdownScript Countdown;

	public Renderer SmartPhoneScreen;

	public StudentScript Distractor;

	public StudentScript HuntTarget;

	public StudentScript MyReporter;

	public StudentScript MyTeacher;

	public BoneSetsScript BoneSets;

	public CosmeticScript Cosmetic;

	public SaveLoadScript SaveLoad;

	public SubtitleScript Subtitle;

	public StudentScript Follower;

	public DynamicBone OsanaHairL;

	public DynamicBone OsanaHairR;

	public ARMiyukiScript Miyuki;

	public WeaponScript MyWeapon;

	public StudentScript Partner;

	public RagdollScript Ragdoll;

	public YandereScript Yandere;

	public Camera DramaticCamera;

	public RagdollScript Corpse;

	public StudentScript Hunter;

	public DoorScript VomitDoor;

	public BrokenScript Broken;

	public PoliceScript Police;

	public PromptScript Prompt;

	public AIPath Pathfinding;

	public TalkingScript Talk;

	public CheerScript Cheer;

	public ClockScript Clock;

	public RadioScript Radio;

	public Renderer Painting;

	public JsonScript JSON;

	public SuckScript Suck;

	public Renderer Tears;

	public Rigidbody MyRigidbody;

	public Collider HorudaCollider;

	public Collider MyCollider;

	public CharacterController MyController;

	public Animation CharacterAnimation;

	public Projector LiquidProjector;

	public float VisionFOV;

	public float VisionDistance;

	public ParticleSystem DelinquentSpeechLines;

	public ParticleSystem PepperSprayEffect;

	public ParticleSystem DrowningSplashes;

	public ParticleSystem BloodFountain;

	public ParticleSystem VomitEmitter;

	public ParticleSystem SpeechLines;

	public ParticleSystem BullyDust;

	public ParticleSystem ChalkDust;

	public ParticleSystem Hearts;

	public Texture KokonaPhoneTexture;

	public Texture MidoriPhoneTexture;

	public Texture OsanaPhoneTexture;

	public Texture RedBookTexture;

	public Texture BloodTexture;

	public Texture WaterTexture;

	public Texture GasTexture;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer BookRenderer;

	public Transform LastSuspiciousObject2;

	public Transform LastSuspiciousObject;

	public Transform CurrentDestination;

	public Transform LeftMiddleFinger;

	public Transform WeaponBagParent;

	public Transform LeftItemParent;

	public Transform PetDestination;

	public Transform SketchPosition;

	public Transform CleaningSpot;

	public Transform SleuthTarget;

	public Transform Distraction;

	public Transform StalkTarget;

	public Transform ItemParent;

	public Transform WitnessPOV;

	public Transform RightDrill;

	public Transform BloodPool;

	public Transform LeftDrill;

	public Transform LeftPinky;

	public Transform MapMarker;

	public Transform RightHand;

	public Transform LeftHand;

	public Transform MeetSpot;

	public Transform MyLocker;

	public Transform MyPlate;

	public Transform Spine;

	public Transform Eyes;

	public Transform Head;

	public Transform Hips;

	public Transform Neck;

	public Transform Seat;

	public ParticleSystem[] LiquidEmitters;

	public ParticleSystem[] SplashEmitters;

	public ParticleSystem[] FireEmitters;

	public ScheduleBlock[] ScheduleBlocks;

	public Transform[] Destinations;

	public Transform[] Skirt;

	public Transform[] Arm;

	public DynamicBone[] BlackHoleEffect;

	public OutlineScript[] Outlines;

	public GameObject[] InstrumentBag;

	public GameObject[] ScienceProps;

	public GameObject[] Instruments;

	public GameObject[] Chopsticks;

	public GameObject[] Drumsticks;

	public GameObject[] Fingerfood;

	public GameObject[] Bones;

	public string[] DelinquentAnims;

	public string[] AnimationNames;

	public string[] GossipAnims;

	public string[] SleuthAnims;

	public string[] CheerAnims;

	[SerializeField]
	private List<int> VisibleCorpses = new List<int>();

	[SerializeField]
	private int[] CorpseLayers = new int[]
	{
		11,
		14
	};

	[SerializeField]
	private LayerMask Mask;

	public StudentActionType CurrentAction;

	public StudentActionType[] Actions;

	public StudentActionType[] OriginalActions;

	public AudioClip MurderSuicideKiller;

	public AudioClip MurderSuicideVictim;

	public AudioClip MurderSuicideSounds;

	public AudioClip PoisonDeathClip;

	public AudioClip PepperSpraySFX;

	public AudioClip BurningClip;

	public AudioSource AirGuitar;

	public AudioClip[] FemaleAttacks;

	public AudioClip[] BullyGiggles;

	public AudioClip[] BullyLaughs;

	public AudioClip[] MaleAttacks;

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

	public GameObject BullyPhotoCollider;

	public GameObject SquishyBloodEffect;

	public GameObject WhiteQuestionMark;

	public GameObject MiyukiGameScreen;

	public GameObject EmptyGameObject;

	public GameObject StabBloodEffect;

	public GameObject BigWaterSplash;

	public GameObject SecurityCamera;

	public GameObject RightEmptyEye;

	public GameObject Handkerchief;

	public GameObject LeftEmptyEye;

	public GameObject AnimatedBook;

	public GameObject BloodyScream;

	public GameObject BloodEffect;

	public GameObject CameraFlash;

	public GameObject ChaseCamera;

	public GameObject DeathScream;

	public GameObject PepperSpray;

	public GameObject PinkSeifuku;

	public GameObject WateringCan;

	public GameObject BagOfChips;

	public GameObject BloodSpray;

	public GameObject Sketchbook;

	public GameObject SmartPhone;

	public GameObject OccultBook;

	public GameObject Paintbrush;

	public GameObject AlarmDisc;

	public GameObject Character;

	public GameObject Cigarette;

	public GameObject EventBook;

	public GameObject Handcuffs;

	public GameObject HealthBar;

	public GameObject OsanaHair;

	public GameObject WeaponBag;

	public GameObject CandyBar;

	public GameObject Earpiece;

	public GameObject Scrubber;

	public GameObject Armband;

	public GameObject BookBag;

	public GameObject Lighter;

	public GameObject MyPaper;

	public GameObject Octodog;

	public GameObject Palette;

	public GameObject Eraser;

	public GameObject Giggle;

	public GameObject Marker;

	public GameObject Pencil;

	public GameObject Weapon;

	public GameObject Bento;

	public GameObject Paper;

	public GameObject Note;

	public GameObject Pen;

	public GameObject Lid;

	public bool InvestigatingPossibleDeath;

	public bool InvestigatingPossibleLimb;

	public bool WitnessedMindBrokenMurder;

	public bool ReturningMisplacedWeapon;

	public bool TargetedForDistraction;

	public bool SchoolwearUnavailable;

	public bool WitnessedBloodyWeapon;

	public bool ReturnToRoutineAfter;

	public bool MustChangeClothing;

	public bool WitnessedBloodPool;

	public bool WitnessedSomething;

	public bool FoundFriendCorpse;

	public bool OriginallyTeacher;

	public bool DramaticReaction;

	public bool EventInterrupted;

	public bool FoundEnemyCorpse;

	public bool LostTeacherTrust;

	public bool WitnessedCoverUp;

	public bool WitnessedCorpse;

	public bool WitnessedMurder;

	public bool WitnessedWeapon;

	public bool YandereInnocent;

	public bool AttackWillFail;

	public bool CanStillNotice;

	public bool GetNewAnimation = true;

	public bool FocusOnYandere;

	public bool PinDownWitness;

	public bool RepeatReaction;

	public bool StalkerFleeing;

	public bool YandereVisible;

	public bool CrimeReported;

	public bool FleeWhenClean;

	public bool MurderSuicide;

	public bool PhotoEvidence;

	public bool RespectEarned;

	public bool WitnessedLimb;

	public bool BeenSplashed;

	public bool BoobsResized;

	public bool CheckingNote;

	public bool ClubActivity;

	public bool Complimented;

	public bool Electrocuted;

	public bool FragileSlave;

	public bool HoldingHands;

	public bool PlayingAudio;

	public bool StopRotating;

	public bool SawFriendDie;

	public bool SentToLocker;

	public bool TurnOffRadio;

	public bool BusyAtLunch;

	public bool Electrified;

	public bool IgnoreBlood;

	public bool MusumeRight;

	public bool UpdateSkirt;

	public bool ClubAttire;

	public bool Confessing;

	public bool Distracted;

	public bool KilledMood;

	public bool LewdPhotos;

	public bool InDarkness;

	public bool SwitchBack;

	public bool Threatened;

	public bool BatheFast;

	public bool Counselor;

	public bool Depressed;

	public bool DiscCheck;

	public bool DressCode;

	public bool Drownable;

	public bool EndSearch;

	public bool KnifeDown;

	public bool LongSkirt;

	public bool NoBreakUp;

	public bool Phoneless;

	public bool TrueAlone;

	public bool WillChase;

	public bool Attacked;

	public bool Headache;

	public bool Gossiped;

	public bool Pushable;

	public bool Replaced;

	public bool Restless;

	public bool SentHome;

	public bool Splashed;

	public bool Tranquil;

	public bool WalkBack;

	public bool Alarmed;

	public bool BadTime;

	public bool Bullied;

	public bool Drowned;

	public bool Forgave;

	public bool Indoors;

	public bool InEvent;

	public bool Injured;

	public bool Nemesis;

	public bool Private;

	public bool Reacted;

	public bool SawMask;

	public bool Sedated;

	public bool SlideIn;

	public bool Spawned;

	public bool Started;

	public bool Suicide;

	public bool Teacher;

	public bool Tripped;

	public bool Witness;

	public bool Bloody;

	public bool CanTalk = true;

	public bool Emetic;

	public bool Lethal;

	public bool Routine = true;

	public bool GoAway;

	public bool Grudge;

	public bool NoTalk;

	public bool Paired;

	public bool Pushed;

	public bool Warned;

	public bool Alone;

	public bool Blind;

	public bool Eaten;

	public bool Hurry;

	public bool Rival;

	public bool Slave;

	public bool Halt;

	public bool Lost;

	public bool Male;

	public bool Rose;

	public bool Safe;

	public bool Stop;

	public bool AoT;

	public bool Fed;

	public bool Gas;

	public bool Shy;

	public bool Wet;

	public bool Won;

	public bool DK;

	public bool InvestigatingBloodPool;

	public bool RetreivingMedicine;

	public bool ResumeDistracting;

	public bool BreakingUpFight;

	public bool SeekingMedicine;

	public bool ReportingMurder;

	public bool CameraReacting;

	public bool UsingRigidbody;

	public bool ReportingBlood;

	public bool FightingSlave;

	public bool Investigating;

	public bool Distracting;

	public bool EatingSnack;

	public bool HitReacting;

	public bool PinningDown;

	public bool Struggling;

	public bool Following;

	public bool Sleuthing;

	public bool Stripping;

	public bool Fighting;

	public bool Guarding;

	public bool Ignoring;

	public bool Spraying;

	public bool Tripping;

	public bool Vomiting;

	public bool Burning;

	public bool Chasing;

	public bool Curious;

	public bool Fleeing;

	public bool Hunting;

	public bool Leaving;

	public bool Meeting;

	public bool Shoving;

	public bool Talking;

	public bool Waiting;

	public bool Dodging;

	public bool Posing;

	public bool Dying;

	public float DistanceToDestination;

	public float FollowTargetDistance;

	public float DistanceToPlayer;

	public float TargetDistance;

	public float ThreatDistance;

	public float WitnessCooldownTimer;

	public float InvestigationTimer;

	public float CameraPoseTimer;

	public float CuriosityTimer;

	public float DistractTimer;

	public float DramaticTimer;

	public float MedicineTimer;

	public float ReactionTimer;

	public float WalkBackTimer;

	public float ElectroTimer;

	public float ThreatTimer;

	public float GiggleTimer;

	public float GoAwayTimer;

	public float IgnoreTimer;

	public float LyricsTimer;

	public float MiyukiTimer;

	public float MusumeTimer;

	public float PatrolTimer;

	public float ReportTimer;

	public float SplashTimer;

	public float UpdateTimer;

	public float AlarmTimer;

	public float BatheTimer;

	public float CheerTimer;

	public float CleanTimer;

	public float LaughTimer;

	public float RadioTimer;

	public float SnackTimer;

	public float SprayTimer;

	public float StuckTimer;

	public float ClubTimer;

	public float MeetTimer;

	public float SulkTimer;

	public float TalkTimer;

	public float WaitTimer;

	public float SewTimer;

	public float OriginalYPosition;

	public float PreviousEyeShrink;

	public float PhotoPatience;

	public float PreviousAlarm;

	public float ClubThreshold = 6f;

	public float RepDeduction;

	public float RepRecovery;

	public float BreastSize;

	public float DodgeSpeed = 2f;

	public float Hesitation;

	public float PendingRep;

	public float Perception = 1f;

	public float EyeShrink;

	public float MeetTime;

	public float Paranoia;

	public float RepLoss;

	public float Health = 100f;

	public float Alarm;

	public int ReturningMisplacedWeaponPhase;

	public int RetrieveMedicinePhase;

	public int ChangeClothingPhase;

	public int InvestigationPhase;

	public int MurderSuicidePhase;

	public int ClubActivityPhase;

	public int SeekMedicinePhase;

	public int CameraReactPhase;

	public int CuriosityPhase;

	public int DramaticPhase;

	public int GraffitiPhase;

	public int SentHomePhase;

	public int SunbathePhase;

	public int ConfessPhase = 1;

	public int SciencePhase;

	public int LyricsPhase;

	public int ReportPhase;

	public int SplashPhase;

	public int ThreatPhase = 1;

	public int BathePhase;

	public int BullyPhase;

	public int RadioPhase = 1;

	public int SnackPhase;

	public int VomitPhase;

	public int ClubPhase;

	public int SulkPhase;

	public int TaskPhase;

	public int ReadPhase;

	public int PinPhase;

	public int Phase;

	public PersonaType OriginalPersona;

	public StudentInteractionType Interaction;

	public int LovestruckTarget;

	public int MurdersWitnessed;

	public int WeaponWitnessed;

	public int MurderReaction;

	public int GossipBonus;

	public int CleaningRole;

	public int TimesAnnoyed;

	public int DeathCause;

	public int Schoolwear;

	public int SkinColor = 3;

	public int Attempts;

	public int Patience = 5;

	public int Pestered;

	public int RepBonus;

	public int Strength;

	public int Concern;

	public int Defeats;

	public int Crush;

	public StudentWitnessType PreviouslyWitnessed;

	public StudentWitnessType Witnessed;

	public GameOverType GameOverCause;

	public DeathType DeathType;

	public string CurrentAnim = string.Empty;

	public string RivalPrefix = string.Empty;

	public string RandomAnim = string.Empty;

	public string Accessory = string.Empty;

	public string Hairstyle = string.Empty;

	public string Suffix = string.Empty;

	public string Name = string.Empty;

	public string OriginalOriginalWalkAnim = string.Empty;

	public string OriginalIdleAnim = string.Empty;

	public string OriginalWalkAnim = string.Empty;

	public string OriginalSprintAnim = string.Empty;

	public string OriginalLeanAnim = string.Empty;

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

	public string ToughFaceAnim = string.Empty;

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

	public string PeekAnim = string.Empty;

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

	public string WaitAnim = string.Empty;

	public string ShoveAnim = string.Empty;

	public string SprayAnim = string.Empty;

	public string SithReactAnim = string.Empty;

	public string EatVictimAnim = string.Empty;

	public string RandomGossipAnim = string.Empty;

	public string CuteAnim = string.Empty;

	public string BulliedIdleAnim = string.Empty;

	public string BulliedWalkAnim = string.Empty;

	public string BullyVictimAnim = string.Empty;

	public string SadDeskSitAnim = string.Empty;

	public string ConfusedSitAnim = string.Empty;

	public string SentHomeAnim = string.Empty;

	public string RandomCheerAnim = string.Empty;

	public string ParanoidWalkAnim = string.Empty;

	public string SleuthIdleAnim = string.Empty;

	public string SleuthWalkAnim = string.Empty;

	public string SleuthCalmAnim = string.Empty;

	public string SleuthScanAnim = string.Empty;

	public string SleuthReactAnim = string.Empty;

	public string SleuthSprintAnim = string.Empty;

	public string SleuthReportAnim = string.Empty;

	public string RandomSleuthAnim = string.Empty;

	public string BreakUpAnim = string.Empty;

	public string PaintAnim = string.Empty;

	public string SketchAnim = string.Empty;

	public string RummageAnim = string.Empty;

	public string ThinkAnim = string.Empty;

	public string ActAnim = string.Empty;

	public string OriginalClubAnim = string.Empty;

	public string MiyukiAnim = string.Empty;

	public string VictoryAnim = string.Empty;

	public string PlateIdleAnim = string.Empty;

	public string PlateWalkAnim = string.Empty;

	public string PlateEatAnim = string.Empty;

	public string PrepareFoodAnim = string.Empty;

	public string PoisonDeathAnim = string.Empty;

	public string HeadacheAnim = string.Empty;

	public string HeadacheSitAnim = string.Empty;

	public string ElectroAnim = string.Empty;

	public string EatChipsAnim = string.Empty;

	public string DrinkFountainAnim = string.Empty;

	public string PullBoxCutterAnim = string.Empty;

	public string TossNoteAnim = string.Empty;

	public string KeepNoteAnim = string.Empty;

	public string BathingAnim = string.Empty;

	public string DodgeAnim = string.Empty;

	public string InspectBloodAnim = string.Empty;

	public string PickUpAnim = string.Empty;

	public string[] CleanAnims;

	public string[] CameraAnims;

	public string[] SocialAnims;

	public string[] CowardAnims;

	public string[] EvilAnims;

	public string[] HeroAnims;

	public string[] TaskAnims;

	public string[] PhoneAnims;

	public int ClubMemberID;

	public int StudentID;

	public int PatrolID;

	public int SleuthID;

	public int BullyID;

	public int CleanID;

	public int Class;

	public int ID;

	public PersonaType Persona;

	public ClubType OriginalClub;

	public ClubType Club;

	public Vector3 OriginalPlatePosition;

	public Vector3 OriginalPosition;

	public Vector3 LastKnownCorpse;

	public Vector3 DistractionSpot;

	public Vector3 LastKnownBlood;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Vector3 PreviousSkirt;

	public Vector3 LastPosition;

	public Vector3 BurnTarget;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform RightEye;

	public Transform LeftEye;

	public int Frame;

	private float MaxSpeed = 10f;

	private const string RIVAL_PREFIX = "Rival ";

	public Vector3[] SkirtPositions;

	public Vector3[] SkirtRotations;

	public Vector3[] SkirtOrigins;

	public Transform DefaultTarget;

	public Transform GushTarget;

	public bool Gush;

	public float LookSpeed = 2f;

	public float TimeOfDeath;

	public int Fate;

	public LowPolyStudentScript LowPoly;

	public GameObject JojoHitEffect;

	public GameObject[] ElectroSteam;

	public GameObject[] CensorSteam;

	public Texture NudeTexture;

	public Mesh BaldNudeMesh;

	public Mesh NudeMesh;

	public Texture TowelTexture;

	public Mesh TowelMesh;

	public Mesh SwimmingTrunks;

	public Mesh SchoolSwimsuit;

	public Mesh GymUniform;

	public Texture UniformTexture;

	public Texture SwimsuitTexture;

	public Texture GyaruSwimsuitTexture;

	public Texture GymTexture;

	public Texture TitanBodyTexture;

	public Texture TitanFaceTexture;

	public bool Spooky;

	public Mesh JudoGiMesh;

	public Texture JudoGiTexture;

	public RiggedAccessoryAttacher Attacher;

	public Mesh NoArmsNoTorso;

	public GameObject RiggedAccessory;

	public int CoupleID;

	public float ChameleonBonus;

	public bool Chameleon;

	public RiggedAccessoryAttacher LabcoatAttacher;

	public RiggedAccessoryAttacher ApronAttacher;

	public Mesh HeadAndHands;

	public bool Alive
	{
		get
		{
			return this.DeathType == DeathType.None;
		}
	}

	public void Start()
	{
		this.CounterAnim = "f02_teacherCounterB_00";
		if (!this.Started)
		{
			this.CharacterAnimation = this.Character.GetComponent<Animation>();
			this.MyBento = this.Bento.GetComponent<GenericBentoScript>();
			this.Pathfinding.repathRate += (float)this.StudentID * 0.01f;
			this.OriginalIdleAnim = this.IdleAnim;
			this.OriginalLeanAnim = this.LeanAnim;
			if (!this.StudentManager.LoveSick && SchoolAtmosphere.Type == SchoolAtmosphereType.Low && this.Club <= ClubType.Gaming)
			{
				this.IdleAnim = this.ParanoidAnim;
			}
			if (ClubGlobals.Club == ClubType.Occult)
			{
				this.Perception = 0.5f;
			}
			this.Hearts.emission.enabled = false;
			this.Prompt.OwnerType = PromptOwnerType.Person;
			this.Paranoia = 2f - SchoolGlobals.SchoolAtmosphere;
			this.VisionDistance = ((PlayerGlobals.PantiesEquipped != 4) ? 10f : 5f) * this.Paranoia;
			if (GameObject.Find("DetectionCamera") != null)
			{
				this.SpawnDetectionMarker();
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
			this.OriginalClub = this.Club;
			if (StudentGlobals.GetStudentBroken(this.StudentID))
			{
				this.Cosmetic.RightEyeRenderer.gameObject.SetActive(false);
				this.Cosmetic.LeftEyeRenderer.gameObject.SetActive(false);
				this.Cosmetic.RightIrisLight.SetActive(false);
				this.Cosmetic.LeftIrisLight.SetActive(false);
				this.RightEmptyEye.SetActive(true);
				this.LeftEmptyEye.SetActive(true);
				this.Shy = true;
				this.Persona = PersonaType.Coward;
			}
			if (this.Name == "Random")
			{
				this.Persona = (PersonaType)UnityEngine.Random.Range(1, 8);
				if (this.Persona == PersonaType.Lovestruck)
				{
					this.Persona = PersonaType.PhoneAddict;
				}
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
			if (this.StudentID == 81 && StudentGlobals.GetStudentBroken(81))
			{
				this.Persona = PersonaType.Coward;
			}
			if (this.Persona == PersonaType.Loner || this.Persona == PersonaType.Coward || this.Persona == PersonaType.Fragile)
			{
				this.CameraAnims = this.CowardAnims;
			}
			else if (this.Persona == PersonaType.TeachersPet || this.Persona == PersonaType.Heroic || this.Persona == PersonaType.Strict)
			{
				this.CameraAnims = this.HeroAnims;
			}
			else if (this.Persona == PersonaType.Evil || this.Persona == PersonaType.Spiteful || this.Persona == PersonaType.Violent)
			{
				this.CameraAnims = this.EvilAnims;
			}
			else if (this.Persona == PersonaType.SocialButterfly || this.Persona == PersonaType.Lovestruck || this.Persona == PersonaType.PhoneAddict || this.Persona == PersonaType.Sleuth)
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
			this.Subtitle = this.Yandere.Subtitle;
			this.CameraEffects = this.Yandere.MainCamera.GetComponent<CameraEffectsScript>();
			this.RightEyeOrigin = this.RightEye.localPosition;
			this.LeftEyeOrigin = this.LeftEye.localPosition;
			this.Bento.GetComponent<GenericBentoScript>().StudentID = this.StudentID;
			this.HealthBar.transform.parent.gameObject.SetActive(false);
			this.VomitEmitter.gameObject.SetActive(false);
			this.ChaseCamera.gameObject.SetActive(false);
			this.Countdown.gameObject.SetActive(false);
			this.MiyukiGameScreen.SetActive(false);
			this.Chopsticks[0].SetActive(false);
			this.Chopsticks[1].SetActive(false);
			this.Sketchbook.SetActive(false);
			this.SmartPhone.SetActive(false);
			this.OccultBook.SetActive(false);
			this.Paintbrush.SetActive(false);
			this.EventBook.SetActive(false);
			this.Handcuffs.SetActive(false);
			this.Scrubber.SetActive(false);
			this.Octodog.SetActive(false);
			this.Palette.SetActive(false);
			this.Eraser.SetActive(false);
			this.Pencil.SetActive(false);
			this.Bento.SetActive(false);
			this.Pen.SetActive(false);
			this.SpeechLines.Stop();
			foreach (GameObject gameObject in this.ScienceProps)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(false);
				}
			}
			foreach (GameObject gameObject2 in this.Fingerfood)
			{
				if (gameObject2 != null)
				{
					gameObject2.SetActive(false);
				}
			}
			this.OriginalOriginalWalkAnim = this.WalkAnim;
			this.OriginalSprintAnim = this.SprintAnim;
			this.OriginalWalkAnim = this.WalkAnim;
			if (this.Persona == PersonaType.Evil)
			{
				this.ScaredAnim = this.EvilWitnessAnim;
			}
			if (this.Persona == PersonaType.PhoneAddict)
			{
				this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
				this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
				this.Countdown.Speed = 0.1f;
				this.SprintAnim = this.PhoneAnims[2];
				this.PatrolAnim = this.PhoneAnims[3];
			}
			if (this.Club == ClubType.Bully)
			{
				if (!StudentGlobals.GetStudentBroken(this.StudentID))
				{
					this.IdleAnim = this.PhoneAnims[0];
					this.BullyID = this.StudentID - 80;
				}
				if (TaskGlobals.GetTaskStatus(36) == 3 && !SchoolGlobals.ReactedToGameLeader)
				{
					this.StudentManager.ReactedToGameLeader = true;
					ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
					scheduleBlock.destination = "Shock";
					scheduleBlock.action = "Shock";
				}
			}
			if (!this.Male)
			{
				this.SkirtOrigins[0] = this.Skirt[0].transform.localPosition;
				this.SkirtOrigins[1] = this.Skirt[1].transform.localPosition;
				this.SkirtOrigins[2] = this.Skirt[2].transform.localPosition;
				this.SkirtOrigins[3] = this.Skirt[3].transform.localPosition;
				this.InstrumentBag[1].SetActive(false);
				this.InstrumentBag[2].SetActive(false);
				this.InstrumentBag[3].SetActive(false);
				this.InstrumentBag[4].SetActive(false);
				this.InstrumentBag[5].SetActive(false);
				this.PickRandomGossipAnim();
				this.DramaticCamera.gameObject.SetActive(false);
				this.AnimatedBook.SetActive(false);
				this.Handkerchief.SetActive(false);
				this.PepperSpray.SetActive(false);
				this.WateringCan.SetActive(false);
				this.Sketchbook.SetActive(false);
				this.Cigarette.SetActive(false);
				this.CandyBar.SetActive(false);
				this.Lighter.SetActive(false);
				foreach (GameObject gameObject3 in this.Instruments)
				{
					if (gameObject3 != null)
					{
						gameObject3.SetActive(false);
					}
				}
				this.Drumsticks[0].SetActive(false);
				this.Drumsticks[1].SetActive(false);
				if (this.Club >= ClubType.Teacher)
				{
					this.BecomeTeacher();
				}
				if (this.StudentManager.Censor && !this.Teacher)
				{
					this.Cosmetic.CensorPanties();
				}
				this.DisableEffects();
			}
			else
			{
				this.RandomCheerAnim = this.CheerAnims[UnityEngine.Random.Range(0, this.CheerAnims.Length)];
				this.MapMarker.gameObject.SetActive(false);
				this.DelinquentSpeechLines.Stop();
				this.PinkSeifuku.SetActive(false);
				this.WeaponBag.SetActive(false);
				this.Earpiece.SetActive(false);
				this.SetSplashes(false);
				foreach (ParticleSystem particleSystem in this.LiquidEmitters)
				{
					particleSystem.gameObject.SetActive(false);
				}
			}
			if (this.StudentID == 1)
			{
				this.MapMarker.gameObject.SetActive(true);
			}
			else if (this.StudentID == 2)
			{
				if (StudentGlobals.GetStudentDead(3) || StudentGlobals.GetStudentKidnapped(3) || this.StudentManager.Students[3].Slave)
				{
					ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[2];
					scheduleBlock2.destination = "Mourn";
					scheduleBlock2.action = "Mourn";
					this.IdleAnim = this.BulliedIdleAnim;
					this.WalkAnim = this.BulliedWalkAnim;
				}
			}
			else if (this.StudentID == 3)
			{
				if (StudentGlobals.GetStudentDead(2) || StudentGlobals.GetStudentKidnapped(2) || this.StudentManager.Students[2] == null || (this.StudentManager.Students[2] != null && this.StudentManager.Students[2].Slave))
				{
					ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[2];
					scheduleBlock3.destination = "Mourn";
					scheduleBlock3.action = "Mourn";
					this.IdleAnim = this.BulliedIdleAnim;
					this.WalkAnim = this.BulliedWalkAnim;
				}
			}
			else if (this.StudentID == 4)
			{
				this.IdleAnim = "f02_idleShort_00";
				this.WalkAnim = "f02_newWalk_00";
			}
			else if (this.StudentID == 5)
			{
				this.LongSkirt = true;
				this.Shy = true;
			}
			else if (this.StudentID == 6)
			{
				this.RelaxAnim = "crossarms_00";
				this.CameraAnims = this.HeroAnims;
			}
			else if (this.StudentID == 7)
			{
				this.RunAnim = "runFeminine_00";
				this.SprintAnim = "runFeminine_00";
				this.RelaxAnim = "infirmaryRest_00";
				this.OriginalSprintAnim = this.SprintAnim;
				this.Cosmetic.Start();
				base.gameObject.SetActive(false);
			}
			else if (this.StudentID == 8)
			{
				this.IdleAnim = this.BulliedIdleAnim;
				this.WalkAnim = this.BulliedWalkAnim;
			}
			else if (this.StudentID == 9)
			{
				this.IdleAnim = "idleScholarly_00";
				this.WalkAnim = "walkScholarly_00";
				this.CameraAnims = this.HeroAnims;
			}
			else if (this.StudentID == 10)
			{
				if (this.StudentManager.Students[11] != null)
				{
					this.StudentManager.Patrols.List[this.StudentID].parent = this.StudentManager.Students[11].transform;
					this.StudentManager.Patrols.List[this.StudentID].localEulerAngles = new Vector3(0f, 0f, 0f);
					this.StudentManager.Patrols.List[this.StudentID].localPosition = new Vector3(0f, 0f, 0f);
					this.LovestruckTarget = 11;
					this.Indoors = true;
					this.Spawned = true;
					if (this.ShoeRemoval.Locker == null)
					{
						this.ShoeRemoval.Start();
					}
					this.ShoeRemoval.PutOnShoes();
					this.FollowTarget = this.StudentManager.Students[11];
					this.FollowTarget.Follower = this;
					this.IdleAnim = "f02_idleGirly_00";
					this.WalkAnim = "f02_walkGirly_00";
					this.PatrolAnim = "f02_stretch_00";
					this.OriginalIdleAnim = this.IdleAnim;
				}
				else
				{
					Debug.Log("Osana is gone, so we're changing this student's destinations.");
					ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[2];
					scheduleBlock4.destination = "Mourn";
					scheduleBlock4.action = "Mourn";
					ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[3];
					scheduleBlock5.destination = "Seat";
					scheduleBlock5.action = "Sit";
					ScheduleBlock scheduleBlock6 = this.ScheduleBlocks[4];
					scheduleBlock6.destination = "Mourn";
					scheduleBlock6.action = "Mourn";
					ScheduleBlock scheduleBlock7 = this.ScheduleBlocks[5];
					scheduleBlock7.destination = "Seat";
					scheduleBlock7.action = "Sit";
					ScheduleBlock scheduleBlock8 = this.ScheduleBlocks[6];
					scheduleBlock8.destination = "Locker";
					scheduleBlock8.action = "Shoes";
					ScheduleBlock scheduleBlock9 = this.ScheduleBlocks[7];
					scheduleBlock9.destination = "Exit";
					scheduleBlock9.action = "Exit";
					ScheduleBlock scheduleBlock10 = this.ScheduleBlocks[9];
					scheduleBlock10.destination = "Exit";
					scheduleBlock10.action = "Exit";
					this.IdleAnim = this.BulliedIdleAnim;
					this.WalkAnim = this.BulliedWalkAnim;
					this.TargetDistance = 0.5f;
					this.Persona = PersonaType.Heroic;
				}
				this.PhotoPatience = 0f;
				this.OriginalWalkAnim = this.WalkAnim;
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else if (this.StudentID == 11)
			{
				this.LovestruckTarget = 1;
				this.PhotoPatience = 0f;
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else if (this.StudentID == 24 && this.StudentID == 25)
			{
				this.IdleAnim = "f02_idleGirly_00";
				this.WalkAnim = "f02_walkGirly_00";
			}
			else if (this.StudentID == 26)
			{
				this.IdleAnim = "idleHaughty_00";
				this.WalkAnim = "walkHaughty_00";
			}
			else if (this.StudentID == 28 || this.StudentID == 30)
			{
				if (this.StudentID == 30)
				{
					this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.KokonaPhoneTexture;
				}
				if (DatingGlobals.SuitorProgress == 2)
				{
					this.Partner = ((this.StudentID != 30) ? this.StudentManager.Students[30] : this.StudentManager.Students[28]);
					ScheduleBlock scheduleBlock11 = this.ScheduleBlocks[4];
					scheduleBlock11.destination = "Cuddle";
					scheduleBlock11.action = "Cuddle";
				}
			}
			else if (this.StudentID == 31)
			{
				this.IdleAnim = this.BulliedIdleAnim;
				this.WalkAnim = this.BulliedWalkAnim;
			}
			else if (this.StudentID == 34 || this.StudentID == 35)
			{
				this.IdleAnim = "f02_idleShort_00";
				this.WalkAnim = "f02_newWalk_00";
				if (this.Paranoia > 1.66666f)
				{
					this.IdleAnim = this.ParanoidAnim;
					this.WalkAnim = this.ParanoidWalkAnim;
				}
			}
			else if (this.StudentID == 36)
			{
				if (TaskGlobals.GetTaskStatus(36) < 3)
				{
					this.IdleAnim = "slouchIdle_00";
					this.WalkAnim = "slouchWalk_00";
					this.ClubAnim = "slouchGaming_00";
				}
				else
				{
					this.IdleAnim = "properIdle_00";
					this.WalkAnim = "properWalk_00";
					this.ClubAnim = "properGaming_00";
				}
				if (this.Paranoia > 1.66666f)
				{
					this.IdleAnim = this.ParanoidAnim;
					this.WalkAnim = this.ParanoidWalkAnim;
				}
			}
			else if (this.StudentID == 39)
			{
				this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.MidoriPhoneTexture;
				this.PatrolAnim = "f02_midoriTexting_00";
			}
			else if (this.StudentID == 51)
			{
				this.IdleAnim = "f02_idleConfident_01";
				this.WalkAnim = "f02_walkConfident_01";
				if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
				{
					this.IdleAnim = this.BulliedIdleAnim;
					this.WalkAnim = this.BulliedWalkAnim;
					this.CameraAnims = this.CowardAnims;
					this.Persona = PersonaType.Loner;
					if (!SchoolGlobals.RoofFence)
					{
						ScheduleBlock scheduleBlock12 = this.ScheduleBlocks[2];
						scheduleBlock12.destination = "Sulk";
						scheduleBlock12.action = "Sulk";
						ScheduleBlock scheduleBlock13 = this.ScheduleBlocks[4];
						scheduleBlock13.destination = "Sulk";
						scheduleBlock13.action = "Sulk";
						ScheduleBlock scheduleBlock14 = this.ScheduleBlocks[7];
						scheduleBlock14.destination = "Sulk";
						scheduleBlock14.action = "Sulk";
						ScheduleBlock scheduleBlock15 = this.ScheduleBlocks[8];
						scheduleBlock15.destination = "Sulk";
						scheduleBlock15.action = "Sulk";
					}
					else
					{
						ScheduleBlock scheduleBlock16 = this.ScheduleBlocks[2];
						scheduleBlock16.destination = "Seat";
						scheduleBlock16.action = "Sit";
						ScheduleBlock scheduleBlock17 = this.ScheduleBlocks[4];
						scheduleBlock17.destination = "Seat";
						scheduleBlock17.action = "Sit";
						ScheduleBlock scheduleBlock18 = this.ScheduleBlocks[7];
						scheduleBlock18.destination = "Seat";
						scheduleBlock18.action = "Sit";
						ScheduleBlock scheduleBlock19 = this.ScheduleBlocks[8];
						scheduleBlock19.destination = "Seat";
						scheduleBlock19.action = "Sit";
					}
				}
			}
			else if (this.StudentID == 56)
			{
				this.IdleAnim = "idleConfident_00";
				this.WalkAnim = "walkConfident_00";
				this.SleuthID = 0;
			}
			else if (this.StudentID == 57)
			{
				this.IdleAnim = "idleChill_01";
				this.WalkAnim = "walkChill_01";
				this.SleuthID = 20;
			}
			else if (this.StudentID == 58)
			{
				this.IdleAnim = "idleChill_00";
				this.WalkAnim = "walkChill_00";
				this.SleuthID = 40;
			}
			else if (this.StudentID == 59)
			{
				this.IdleAnim = "f02_idleGraceful_00";
				this.WalkAnim = "f02_walkGraceful_00";
				this.SleuthID = 60;
			}
			else if (this.StudentID == 60)
			{
				this.IdleAnim = "f02_idleScholarly_00";
				this.WalkAnim = "f02_walkScholarly_00";
				this.CameraAnims = this.HeroAnims;
				this.SleuthID = 80;
			}
			else if (this.StudentID == 61)
			{
				this.IdleAnim = "scienceIdle_00";
				this.WalkAnim = "scienceWalk_00";
				this.OriginalWalkAnim = "scienceWalk_00";
			}
			else if (this.StudentID == 62)
			{
				this.IdleAnim = "idleFrown_00";
				this.WalkAnim = "walkFrown_00";
				if (this.Paranoia > 1.66666f)
				{
					this.IdleAnim = this.ParanoidAnim;
					this.WalkAnim = this.ParanoidWalkAnim;
				}
			}
			else if (this.StudentID == 64 || this.StudentID == 65)
			{
				this.IdleAnim = "f02_idleShort_00";
				this.WalkAnim = "f02_newWalk_00";
				if (this.Paranoia > 1.66666f)
				{
					this.IdleAnim = this.ParanoidAnim;
					this.WalkAnim = this.ParanoidWalkAnim;
				}
			}
			else if (this.StudentID == 66)
			{
				this.IdleAnim = "pose_03";
				this.OriginalWalkAnim = "walkConfident_00";
				this.WalkAnim = "walkConfident_00";
				this.ClubThreshold = 100f;
			}
			else if (this.StudentID == 69)
			{
				this.IdleAnim = "idleFrown_00";
				this.WalkAnim = "walkFrown_00";
				if (this.Paranoia > 1.66666f)
				{
					this.IdleAnim = this.ParanoidAnim;
					this.WalkAnim = this.ParanoidWalkAnim;
				}
			}
			else if (this.StudentID == 71)
			{
				this.IdleAnim = "f02_idleGirly_00";
				this.WalkAnim = "f02_walkGirly_00";
			}
			this.OriginalWalkAnim = this.WalkAnim;
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
			if (this.Persona == PersonaType.Sleuth)
			{
				if (SchoolGlobals.SchoolAtmosphere <= 0.8f || this.Grudge)
				{
					this.Indoors = true;
					this.Spawned = true;
					if (this.ShoeRemoval.Locker == null)
					{
						this.ShoeRemoval.Start();
					}
					this.ShoeRemoval.PutOnShoes();
					this.SprintAnim = this.SleuthSprintAnim;
					this.IdleAnim = this.SleuthIdleAnim;
					this.WalkAnim = this.SleuthWalkAnim;
					this.CameraAnims = this.HeroAnims;
					this.SmartPhone.SetActive(true);
					this.Countdown.Speed = 0.075f;
					this.Sleuthing = true;
					if (this.Male)
					{
						this.SmartPhone.transform.localPosition = new Vector3(0.06f, -0.02f, -0.02f);
					}
					else
					{
						this.SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.015f, -0.015f);
					}
					this.SmartPhone.transform.localEulerAngles = new Vector3(12.5f, 120f, 180f);
					if (this.Club == ClubType.None)
					{
						this.StudentManager.SleuthPhase = 3;
						this.GetSleuthTarget();
					}
					else
					{
						this.SleuthTarget = this.StudentManager.Clubs.List[this.StudentID];
					}
					if (!this.Grudge)
					{
						ScheduleBlock scheduleBlock20 = this.ScheduleBlocks[2];
						scheduleBlock20.destination = "Sleuth";
						scheduleBlock20.action = "Sleuth";
						ScheduleBlock scheduleBlock21 = this.ScheduleBlocks[4];
						scheduleBlock21.destination = "Sleuth";
						scheduleBlock21.action = "Sleuth";
						ScheduleBlock scheduleBlock22 = this.ScheduleBlocks[7];
						scheduleBlock22.destination = "Sleuth";
						scheduleBlock22.action = "Sleuth";
					}
					else
					{
						this.StalkTarget = this.Yandere.transform;
						this.SleuthTarget = this.Yandere.transform;
						ScheduleBlock scheduleBlock23 = this.ScheduleBlocks[2];
						scheduleBlock23.destination = "Stalk";
						scheduleBlock23.action = "Stalk";
						ScheduleBlock scheduleBlock24 = this.ScheduleBlocks[4];
						scheduleBlock24.destination = "Stalk";
						scheduleBlock24.action = "Stalk";
						ScheduleBlock scheduleBlock25 = this.ScheduleBlocks[7];
						scheduleBlock25.destination = "Stalk";
						scheduleBlock25.action = "Stalk";
					}
				}
				else if (SchoolGlobals.SchoolAtmosphere <= 0.9f)
				{
					this.WalkAnim = this.ParanoidWalkAnim;
					this.CameraAnims = this.HeroAnims;
				}
			}
			if (!this.Slave)
			{
				if (this.StudentManager.Bullies > 1)
				{
					if (this.StudentID == 81 || this.StudentID == 83 || this.StudentID == 85)
					{
						if (this.Persona != PersonaType.Coward)
						{
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.Paired = true;
							this.CharacterAnimation["f02_walkTalk_00"].time += (float)(this.StudentID - 81);
							this.WalkAnim = "f02_walkTalk_00";
							this.SpeechLines.Play();
						}
					}
					else if (this.StudentID == 82 || this.StudentID == 84)
					{
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Paired = true;
						this.CharacterAnimation["f02_walkTalk_01"].time += (float)(this.StudentID - 81);
						this.WalkAnim = "f02_walkTalk_01";
						this.SpeechLines.Play();
					}
				}
				if (this.Club == ClubType.Delinquent)
				{
					if (PlayerGlobals.GetStudentFriend(this.StudentID))
					{
						this.RespectEarned = true;
					}
					if (CounselorGlobals.WeaponsBanned == 0)
					{
						this.MyWeapon = this.Yandere.WeaponManager.DelinquentWeapons[this.StudentID - 75];
						this.MyWeapon.transform.parent = this.WeaponBagParent;
						this.MyWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						this.MyWeapon.transform.localPosition = new Vector3(0f, 0f, 0f);
						this.MyWeapon.FingerprintID = this.StudentID;
						this.MyWeapon.MyCollider.enabled = false;
						this.WeaponBag.SetActive(true);
					}
					else
					{
						this.OriginalPersona = PersonaType.Heroic;
						this.Persona = PersonaType.Heroic;
					}
					this.ScaredAnim = "delinquentCombatIdle_00";
					this.LeanAnim = "delinquentConcern_00";
					this.ShoveAnim = "pushTough_00";
					this.WalkAnim = "walkTough_00";
					this.IdleAnim = "idleTough_00";
					this.SpeechLines = this.DelinquentSpeechLines;
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.Paired = true;
					this.TaskAnims[0] = "delinquentTalk_04";
					this.TaskAnims[1] = "delinquentTalk_01";
					this.TaskAnims[2] = "delinquentTalk_02";
					this.TaskAnims[3] = "delinquentTalk_03";
					this.TaskAnims[4] = "delinquentTalk_00";
					this.TaskAnims[5] = "delinquentTalk_03";
				}
			}
			if (this.StudentID == this.StudentManager.RivalID)
			{
				this.RivalPrefix = "Rival ";
				if (DateGlobals.Weekday == DayOfWeek.Friday)
				{
					Debug.Log("It's Friday, and " + this.Name + " should leave a note in Senpai's locker ar 5:00 PM.");
					ScheduleBlock scheduleBlock26 = this.ScheduleBlocks[7];
					scheduleBlock26.time = 17f;
				}
			}
			if (!this.Teacher && this.Name != "Random")
			{
				this.StudentManager.CleaningManager.GetRole(this.StudentID);
				this.CleaningSpot = this.StudentManager.CleaningManager.Spot;
				this.CleaningRole = this.StudentManager.CleaningManager.Role;
			}
			if (this.Club == ClubType.None)
			{
				if (this.StudentID == 11)
				{
					this.SmartPhone.transform.localPosition = new Vector3(-0.0075f, -0.0025f, -0.0075f);
					this.SmartPhone.transform.localEulerAngles = new Vector3(5f, -150f, 170f);
					this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.OsanaPhoneTexture;
					this.IdleAnim = "f02_tsunIdle_00";
					this.WalkAnim = "f02_tsunWalk_00";
					this.OriginalWalkAnim = this.WalkAnim;
					this.TaskAnims[0] = "f02_Task33_Line0";
					this.TaskAnims[1] = "f02_Task33_Line1";
					this.TaskAnims[2] = "f02_Task33_Line2";
					this.TaskAnims[3] = "f02_Task33_Line3";
					this.TaskAnims[4] = "f02_Task33_Line4";
					this.TaskAnims[5] = "f02_Task33_Line5";
				}
			}
			else if (this.Club == ClubType.Cooking)
			{
				this.SleuthID = (this.StudentID - 21) * 20;
				this.ClubAnim = this.PrepareFoodAnim;
				this.ClubMemberID = this.StudentID - 20;
				this.MyPlate = this.StudentManager.Plates[this.ClubMemberID];
				this.OriginalPlatePosition = this.MyPlate.position;
				this.OriginalPlateRotation = this.MyPlate.rotation;
				if (!GameGlobals.EmptyDemon)
				{
					this.ApronAttacher.enabled = true;
				}
			}
			else if (this.Club == ClubType.Drama)
			{
				if (this.StudentID == 26)
				{
					this.ClubAnim = "teaching_00";
				}
				else if (this.StudentID == 27 || this.StudentID == 28)
				{
					this.ClubAnim = "sit_00";
				}
				else if (this.StudentID == 29 || this.StudentID == 30)
				{
					this.ClubAnim = "f02_sit_00";
				}
				this.OriginalClubAnim = this.ClubAnim;
			}
			else if (this.Club == ClubType.Occult)
			{
				this.PatrolAnim = this.ThinkAnim;
				this.CharacterAnimation[this.PatrolAnim].speed = 0.2f;
			}
			else if (this.Club == ClubType.Gaming)
			{
				this.MiyukiGameScreen.SetActive(true);
				this.ClubMemberID = this.StudentID - 35;
				if (this.StudentID > 36)
				{
					this.ClubAnim = this.GameAnim;
				}
				this.ActivityAnim = this.GameAnim;
			}
			else if (this.Club == ClubType.Art)
			{
				this.ChangingBooth = this.StudentManager.ChangingBooths[4];
				this.ActivityAnim = this.PaintAnim;
				this.Attacher.ArtClub = true;
				this.ClubAnim = this.PaintAnim;
				this.DressCode = true;
				if (DateGlobals.Weekday == DayOfWeek.Friday)
				{
					Debug.Log("It's Friday, so the art club is changing their club activity to painting the cherry tree.");
					ScheduleBlock scheduleBlock27 = this.ScheduleBlocks[7];
					scheduleBlock27.destination = "Paint";
					scheduleBlock27.action = "Paint";
				}
				this.ClubMemberID = this.StudentID - 40;
				this.Painting = this.StudentManager.FridayPaintings[this.ClubMemberID];
				this.GetDestinations();
			}
			else if (this.Club == ClubType.LightMusic)
			{
				this.ClubMemberID = this.StudentID - 50;
				this.InstrumentBag[this.ClubMemberID].SetActive(true);
				if (this.StudentID == 51)
				{
					this.ClubAnim = "f02_practiceGuitar_01";
				}
				else if (this.StudentID == 52 || this.StudentID == 53)
				{
					this.ClubAnim = "f02_practiceGuitar_00";
				}
				else if (this.StudentID == 54)
				{
					this.ClubAnim = "f02_practiceDrums_00";
					this.Instruments[4] = this.StudentManager.DrumSet;
				}
				else if (this.StudentID == 55)
				{
					this.ClubAnim = "f02_practiceKeytar_00";
				}
			}
			else if (this.Club == ClubType.MartialArts)
			{
				this.ChangingBooth = this.StudentManager.ChangingBooths[6];
				this.DressCode = true;
				if (this.StudentID == 46)
				{
					this.IdleAnim = "pose_03";
					this.ClubAnim = "pose_03";
				}
				else if (this.StudentID == 47)
				{
					this.GetNewAnimation = true;
					this.ClubAnim = "idle_20";
					this.ActivityAnim = "kick_24";
				}
				else if (this.StudentID == 48)
				{
					this.ClubAnim = "sit_04";
					this.ActivityAnim = "kick_24";
				}
				else if (this.StudentID == 49)
				{
					this.GetNewAnimation = true;
					this.ClubAnim = "f02_idle_20";
					this.ActivityAnim = "f02_kick_23";
				}
				else if (this.StudentID == 50)
				{
					this.ClubAnim = "f02_sit_05";
					this.ActivityAnim = "f02_kick_23";
				}
				this.ClubMemberID = this.StudentID - 45;
			}
			else if (this.Club == ClubType.Science)
			{
				this.ChangingBooth = this.StudentManager.ChangingBooths[8];
				this.Attacher.ScienceClub = true;
				this.DressCode = true;
				if (this.StudentID == 61)
				{
					this.ClubAnim = "scienceMad_00";
				}
				else if (this.StudentID == 62)
				{
					this.ClubAnim = "scienceTablet_00";
				}
				else if (this.StudentID == 63)
				{
					this.ClubAnim = "scienceChemistry_00";
				}
				else if (this.StudentID == 64)
				{
					this.ClubAnim = "f02_scienceLeg_00";
				}
				else if (this.StudentID == 65)
				{
					this.ClubAnim = "f02_scienceConsole_00";
				}
				this.ClubMemberID = this.StudentID - 60;
			}
			else if (this.Club == ClubType.Sports)
			{
				this.ChangingBooth = this.StudentManager.ChangingBooths[9];
				this.DressCode = true;
				this.ClubAnim = "stretch_00";
				this.ClubMemberID = this.StudentID - 65;
			}
			else if (this.Club == ClubType.Gardening)
			{
				if (this.StudentID == 71)
				{
					this.PatrolAnim = "f02_thinking_00";
					this.ClubAnim = "f02_thinking_00";
					this.CharacterAnimation[this.PatrolAnim].speed = 0.9f;
				}
				else
				{
					this.ClubAnim = "f02_waterPlant_00";
					this.WateringCan.SetActive(true);
				}
			}
			if (this.OriginalClub != ClubType.Gaming)
			{
				this.Miyuki.gameObject.SetActive(false);
			}
			if (this.Cosmetic.Hairstyle == 20)
			{
				this.IdleAnim = "f02_tsunIdle_00";
			}
			this.GetDestinations();
			this.OriginalActions = new StudentActionType[this.Actions.Length];
			Array.Copy(this.Actions, this.OriginalActions, this.Actions.Length);
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
				this.RightEmptyEye.SetActive(true);
				this.LeftEmptyEye.SetActive(true);
				this.SmartPhone.SetActive(false);
				this.Distracted = true;
				this.Indoors = true;
				this.Safe = false;
				this.Shy = false;
				this.ID = 0;
				while (this.ID < this.ScheduleBlocks.Length)
				{
					this.ScheduleBlocks[this.ID].time = 0f;
					this.ID++;
				}
				if (this.FragileSlave)
				{
					this.HuntTarget = this.StudentManager.Students[StudentGlobals.GetFragileTarget()];
				}
				else
				{
					SchoolGlobals.KidnapVictim = 0;
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
				this.Yandere.LookAt.target = this.Head;
				this.ID = 0;
				while (this.ID < this.Outlines.Length)
				{
					if (this.Outlines[this.ID] != null)
					{
						this.Outlines[this.ID].enabled = true;
						this.Outlines[this.ID].color = new Color(1f, 0f, 1f);
					}
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
					if (this.Outlines[this.ID] != null)
					{
						this.Outlines[this.ID].enabled = false;
						this.Outlines[this.ID].color = new Color(0f, 1f, 0f);
					}
					this.ID++;
				}
			}
			this.PickRandomAnim();
			this.PickRandomSleuthAnim();
			Renderer component = this.Armband.GetComponent<Renderer>();
			this.Armband.SetActive(false);
			if (this.Club != ClubType.None && (this.StudentID == 21 || this.StudentID == 26 || this.StudentID == 31 || this.StudentID == 36 || this.StudentID == 41 || this.StudentID == 46 || this.StudentID == 51 || this.StudentID == 56 || this.StudentID == 61 || this.StudentID == 66 || this.StudentID == 71))
			{
				this.Armband.SetActive(true);
				if (GameGlobals.EmptyDemon)
				{
					this.IdleAnim = this.OriginalIdleAnim;
					this.WalkAnim = this.OriginalOriginalWalkAnim;
					this.OriginalPersona = PersonaType.Evil;
					this.Persona = PersonaType.Evil;
					this.ScaredAnim = this.EvilWitnessAnim;
				}
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
			if (this.StudentID == 1 || this.StudentID == 4 || this.StudentID == 5 || this.StudentID == 11)
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
			if (this.Club == ClubType.Council)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(-0.64375f, 0f));
				this.Armband.SetActive(true);
				this.Indoors = true;
				this.Spawned = true;
				if (this.ShoeRemoval.Locker == null)
				{
					this.ShoeRemoval.Start();
				}
				this.ShoeRemoval.PutOnShoes();
				if (this.StudentID == 86)
				{
					this.Suffix = "Strict";
				}
				else if (this.StudentID == 87)
				{
					this.Suffix = "Casual";
				}
				else if (this.StudentID == 88)
				{
					this.Suffix = "Grace";
				}
				else if (this.StudentID == 89)
				{
					this.Suffix = "Edgy";
				}
				this.IdleAnim = "f02_idleCouncil" + this.Suffix + "_00";
				this.WalkAnim = "f02_walkCouncil" + this.Suffix + "_00";
				this.ShoveAnim = "f02_pushCouncil" + this.Suffix + "_00";
				this.PatrolAnim = "f02_scanCouncil" + this.Suffix + "_00";
				this.RelaxAnim = "f02_relaxCouncil" + this.Suffix + "_00";
				this.SprayAnim = "f02_sprayCouncil" + this.Suffix + "_00";
				this.BreakUpAnim = "f02_stopCouncil" + this.Suffix + "_00";
				this.PickUpAnim = "f02_teacherPickUp_00";
				this.ScaredAnim = this.ReadyToFightAnim;
				this.ParanoidAnim = this.GuardAnim;
				this.CameraAnims[1] = this.IdleAnim;
				this.CameraAnims[2] = this.IdleAnim;
				this.CameraAnims[3] = this.IdleAnim;
				this.ClubMemberID = this.StudentID - 85;
				this.VisionDistance *= 2f;
			}
			if (!this.StudentManager.NoClubMeeting && this.Armband.activeInHierarchy && this.Clock.Weekday == 5)
			{
				if (this.StudentID < 86)
				{
					ScheduleBlock scheduleBlock28 = this.ScheduleBlocks[6];
					scheduleBlock28.destination = "Meeting";
					scheduleBlock28.action = "Meeting";
				}
				else
				{
					ScheduleBlock scheduleBlock29 = this.ScheduleBlocks[5];
					scheduleBlock29.destination = "Meeting";
					scheduleBlock29.action = "Meeting";
				}
				this.GetDestinations();
			}
			if (this.StudentID == 81 && StudentGlobals.GetStudentBroken(81))
			{
				this.Destinations[2] = this.StudentManager.BrokenSpot;
				this.Destinations[4] = this.StudentManager.BrokenSpot;
				this.Actions[2] = StudentActionType.Shamed;
				this.Actions[4] = StudentActionType.Shamed;
			}
		}
		this.UpdateAnimLayers();
		if (!this.Male)
		{
			base.GetComponent<FLookAnimatorWEyes>().ObjectToFollow = this.Yandere.Head;
			base.GetComponent<FLookAnimatorWEyes>().EyesTarget = this.Yandere.Head;
		}
		if (this.StudentID > 9 && this.StudentID < 21)
		{
			Debug.Log("Destroying a character who should not exist.");
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private float GetPerceptionPercent(float distance)
	{
		float num = Mathf.Clamp01(distance / this.VisionDistance);
		return 1f - num * num;
	}

	private SubtitleType LostPhoneSubtitleType
	{
		get
		{
			if (this.RivalPrefix == string.Empty)
			{
				return SubtitleType.LostPhone;
			}
			if (this.RivalPrefix == "Rival ")
			{
				return SubtitleType.RivalLostPhone;
			}
			throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
		}
	}

	private SubtitleType PickpocketSubtitleType
	{
		get
		{
			if (this.RivalPrefix == string.Empty)
			{
				return SubtitleType.PickpocketReaction;
			}
			if (this.RivalPrefix == "Rival ")
			{
				return SubtitleType.RivalPickpocketReaction;
			}
			throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
		}
	}

	private SubtitleType SplashSubtitleType
	{
		get
		{
			if (this.RivalPrefix == string.Empty)
			{
				if (!this.Male)
				{
					return SubtitleType.SplashReaction;
				}
				return SubtitleType.SplashReactionMale;
			}
			else
			{
				if (this.RivalPrefix == "Rival ")
				{
					return SubtitleType.RivalSplashReaction;
				}
				throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
			}
		}
	}

	public SubtitleType TaskLineResponseType
	{
		get
		{
			if (this.StudentID == 8)
			{
				return SubtitleType.Task8Line;
			}
			if (this.StudentID == 11)
			{
				return SubtitleType.Task11Line;
			}
			if (this.StudentID == 13)
			{
				return SubtitleType.Task13Line;
			}
			if (this.StudentID == 14)
			{
				return SubtitleType.Task14Line;
			}
			if (this.StudentID == 15)
			{
				return SubtitleType.Task15Line;
			}
			if (this.StudentID == 25)
			{
				return SubtitleType.Task25Line;
			}
			if (this.StudentID == 28)
			{
				return SubtitleType.Task28Line;
			}
			if (this.StudentID == 30)
			{
				return SubtitleType.Task30Line;
			}
			if (this.StudentID == 36)
			{
				return SubtitleType.Task36Line;
			}
			if (this.StudentID == 37)
			{
				return SubtitleType.Task37Line;
			}
			if (this.StudentID == 38)
			{
				return SubtitleType.Task38Line;
			}
			if (this.StudentID == 52)
			{
				return SubtitleType.Task52Line;
			}
			if (this.StudentID == 76)
			{
				return SubtitleType.Task76Line;
			}
			if (this.StudentID == 77)
			{
				return SubtitleType.Task77Line;
			}
			if (this.StudentID == 78)
			{
				return SubtitleType.Task78Line;
			}
			if (this.StudentID == 79)
			{
				return SubtitleType.Task79Line;
			}
			if (this.StudentID == 80)
			{
				return SubtitleType.Task80Line;
			}
			if (this.StudentID == 81)
			{
				return SubtitleType.Task81Line;
			}
			return SubtitleType.TaskGenericLine;
		}
	}

	public SubtitleType ClubInfoResponseType
	{
		get
		{
			if (GameGlobals.EmptyDemon)
			{
				return SubtitleType.ClubPlaceholderInfo;
			}
			if (this.Club == ClubType.Cooking)
			{
				return SubtitleType.ClubCookingInfo;
			}
			if (this.Club == ClubType.Drama)
			{
				return SubtitleType.ClubDramaInfo;
			}
			if (this.Club == ClubType.Occult)
			{
				return SubtitleType.ClubOccultInfo;
			}
			if (this.Club == ClubType.Art)
			{
				return SubtitleType.ClubArtInfo;
			}
			if (this.Club == ClubType.LightMusic)
			{
				return SubtitleType.ClubLightMusicInfo;
			}
			if (this.Club == ClubType.MartialArts)
			{
				return SubtitleType.ClubMartialArtsInfo;
			}
			if (this.Club == ClubType.Photography)
			{
				if (this.Sleuthing)
				{
					return SubtitleType.ClubPhotoInfoDark;
				}
				return SubtitleType.ClubPhotoInfoLight;
			}
			else
			{
				if (this.Club == ClubType.Science)
				{
					return SubtitleType.ClubScienceInfo;
				}
				if (this.Club == ClubType.Sports)
				{
					return SubtitleType.ClubSportsInfo;
				}
				if (this.Club == ClubType.Gardening)
				{
					return SubtitleType.ClubGardenInfo;
				}
				if (this.Club == ClubType.Gaming)
				{
					return SubtitleType.ClubGamingInfo;
				}
				if (this.Club == ClubType.Delinquent)
				{
					return SubtitleType.ClubDelinquentInfo;
				}
				return SubtitleType.ClubPlaceholderInfo;
			}
		}
	}

	private bool PointIsInFOV(Vector3 point)
	{
		Vector3 position = this.Eyes.transform.position;
		Vector3 to = point - position;
		float num = 90f;
		return Vector3.Angle(this.Head.transform.forward, to) <= num;
	}

	public bool CanSeeObject(GameObject obj, Vector3 targetPoint, int[] layers, int mask)
	{
		Vector3 position = this.Eyes.transform.position;
		Vector3 vector = targetPoint - position;
		bool flag = this.PointIsInFOV(targetPoint);
		if (flag)
		{
			float num = this.VisionDistance * this.VisionDistance;
			bool flag2 = vector.sqrMagnitude <= num;
			if (flag2)
			{
				Debug.DrawLine(position, targetPoint, Color.green);
				RaycastHit raycastHit;
				bool flag3 = Physics.Linecast(position, targetPoint, out raycastHit, mask);
				if (flag3)
				{
					foreach (int num2 in layers)
					{
						bool flag4 = raycastHit.collider.gameObject.layer == num2;
						if (flag4)
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	public bool CanSeeObject(GameObject obj, Vector3 targetPoint)
	{
		if (!this.Blind)
		{
			Debug.DrawLine(this.Eyes.position, targetPoint, Color.green);
			Vector3 position = this.Eyes.transform.position;
			Vector3 vector = targetPoint - position;
			float num = this.VisionDistance * this.VisionDistance;
			bool flag = this.PointIsInFOV(targetPoint);
			bool flag2 = vector.sqrMagnitude <= num;
			if (flag && flag2)
			{
				RaycastHit raycastHit;
				bool flag3 = Physics.Linecast(position, targetPoint, out raycastHit, this.Mask);
				if (flag3)
				{
					bool flag4 = raycastHit.collider.gameObject == obj;
					if (flag4)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool CanSeeObject(GameObject obj)
	{
		return this.CanSeeObject(obj, obj.transform.position);
	}

	private void Update()
	{
		if (!this.Stop)
		{
			this.DistanceToPlayer = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
			if (this.Yandere.Egg && this.StudentID > 1)
			{
				if (this.DistanceToPlayer < 1f && this.Yandere.EbolaHair.activeInHierarchy)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.Yandere.EbolaEffect, base.transform.position + Vector3.up, Quaternion.identity);
					this.SpawnAlarmDisc();
					this.BecomeRagdoll();
					this.DeathType = DeathType.EasterEgg;
				}
				if (this.DistanceToPlayer < 5f && this.Yandere.Hunger >= 5)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.Yandere.DarkHelix, base.transform.position + Vector3.up, Quaternion.identity);
					this.SpawnAlarmDisc();
					this.BecomeRagdoll();
					this.DeathType = DeathType.EasterEgg;
				}
			}
			this.UpdateRoutine();
			this.UpdateDetectionMarker();
			if (this.Dying)
			{
				this.UpdateDying();
				if (this.Burning)
				{
					this.UpdateBurning();
				}
			}
			else
			{
				if (this.DistanceToPlayer <= 2f)
				{
					this.UpdateTalkInput();
				}
				this.UpdateVision();
				if (this.Pushed)
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
				else if (this.TurnOffRadio)
				{
					this.UpdateTurningOffRadio();
				}
				else if (this.Confessing)
				{
					this.UpdateConfessing();
				}
				else if (this.Vomiting)
				{
					this.UpdateVomiting();
				}
				else if (this.Splashed)
				{
					this.UpdateSplashed();
				}
			}
			this.UpdateMisc();
		}
		else
		{
			if (this.StudentManager.Pose)
			{
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Pose();
				}
			}
			else if (!this.ClubActivity)
			{
				if (!this.Yandere.Talking)
				{
					if (this.Yandere.Sprayed)
					{
						this.CharacterAnimation.CrossFade(this.ScaredAnim);
					}
					if (this.Yandere.Noticed || this.StudentManager.YandereDying)
					{
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					}
				}
			}
			else if (this.Police.Darkness.color.a < 1f)
			{
				if (this.Club == ClubType.Cooking)
				{
					this.CharacterAnimation[this.SocialSitAnim].layer = 99;
					this.CharacterAnimation.Play(this.SocialSitAnim);
					this.CharacterAnimation[this.SocialSitAnim].weight = 1f;
					this.SmartPhone.SetActive(false);
					this.SpeechLines.Play();
					this.CharacterAnimation.CrossFade(this.RandomAnim);
					if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
					{
						this.PickRandomAnim();
					}
				}
				else if (this.Club == ClubType.MartialArts)
				{
					this.CharacterAnimation.Play(this.ActivityAnim);
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
				else if (this.Club == ClubType.Drama)
				{
					this.Stop = false;
				}
				else if (this.Club == ClubType.Photography)
				{
					this.CharacterAnimation.CrossFade(this.RandomSleuthAnim);
					if (this.CharacterAnimation[this.RandomSleuthAnim].time >= this.CharacterAnimation[this.RandomSleuthAnim].length)
					{
						this.PickRandomSleuthAnim();
					}
				}
				else if (this.Club == ClubType.Art)
				{
					this.CharacterAnimation.Play(this.ActivityAnim);
					this.Paintbrush.SetActive(true);
					this.Palette.SetActive(true);
				}
				else if (this.Club == ClubType.Science)
				{
					this.CharacterAnimation.Play(this.ClubAnim);
					if (this.StudentID == 62)
					{
						this.ScienceProps[0].SetActive(true);
					}
					else if (this.StudentID == 63)
					{
						this.ScienceProps[1].SetActive(true);
						this.ScienceProps[2].SetActive(true);
					}
					else if (this.StudentID == 64)
					{
						this.ScienceProps[0].SetActive(true);
					}
				}
				else if (this.Club == ClubType.Sports)
				{
					this.Stop = false;
				}
				else if (this.Club == ClubType.Gardening)
				{
					this.CharacterAnimation.Play(this.ClubAnim);
					this.Stop = false;
				}
				else if (this.Club == ClubType.Gaming)
				{
					this.CharacterAnimation.CrossFade(this.ClubAnim);
				}
			}
			this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime);
			this.UpdateDetectionMarker();
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
			if (this.StalkerFleeing)
			{
				if (this.Actions[this.Phase] == StudentActionType.Stalk && this.DistanceToPlayer > 10f)
				{
					this.Pathfinding.target = this.Yandere.transform;
					this.CurrentDestination = this.Yandere.transform;
					this.StalkerFleeing = false;
					this.Pathfinding.speed = 1f;
				}
			}
			else if (this.Actions[this.Phase] == StudentActionType.Stalk)
			{
				this.TargetDistance = 10f;
				if (this.DistanceToPlayer > 20f)
				{
					this.Pathfinding.speed = 4f;
				}
				else if (this.DistanceToPlayer < 10f)
				{
					this.Pathfinding.speed = 1f;
				}
			}
			if (!this.Indoors)
			{
				if (this.Hurry && !this.Tripped && base.transform.position.z > -50.5f && base.transform.position.x < 6f)
				{
					this.CharacterAnimation.CrossFade("trip_00");
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.Tripping = true;
					this.Routine = false;
				}
				if (this.Paired)
				{
					if (base.transform.position.z < -50f)
					{
						if (base.transform.localEulerAngles != Vector3.zero)
						{
							base.transform.localEulerAngles = Vector3.zero;
						}
						this.MyController.Move(base.transform.forward * Time.deltaTime);
						if (this.StudentID == 81)
						{
							this.MusumeTimer += Time.deltaTime;
							if (this.MusumeTimer > 5f)
							{
								this.MusumeTimer = 0f;
								this.MusumeRight = !this.MusumeRight;
								this.WalkAnim = ((!this.MusumeRight) ? "f02_walkTalk_01" : "f02_walkTalk_00");
							}
						}
					}
					else
					{
						if (this.Persona == PersonaType.PhoneAddict)
						{
							this.SpeechLines.Stop();
							this.SmartPhone.SetActive(true);
						}
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.StopPairing();
					}
				}
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
					this.SmartPhone.SetActive(false);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.ShoeRemoval.StartChangingShoes();
					this.ShoeRemoval.enabled = true;
					this.CanTalk = false;
					this.Routine = false;
				}
			}
			else if (this.Phase < this.ScheduleBlocks.Length - 1)
			{
				if (this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time && !this.InEvent && !this.Meeting && this.ClubActivityPhase < 16)
				{
					this.MyRenderer.updateWhenOffscreen = false;
					this.SprintAnim = this.OriginalSprintAnim;
					if (this.Headache)
					{
						this.SprintAnim = this.OriginalSprintAnim;
						this.WalkAnim = this.OriginalWalkAnim;
					}
					this.Headache = false;
					this.Sedated = false;
					this.Hurry = false;
					this.Phase++;
					if (this.Drownable)
					{
						this.Drownable = false;
						this.StudentManager.UpdateMe(this.StudentID);
					}
					if (this.StudentID == 11)
					{
						Debug.Log("Osana's phase has increased to " + this.Phase.ToString() + ".");
					}
					if (this.Schoolwear > 1 && this.Destinations[this.Phase] == this.MyLocker)
					{
						this.Phase++;
					}
					if (this.Actions[this.Phase] == StudentActionType.Graffiti && !this.StudentManager.Bully)
					{
						ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
						scheduleBlock.destination = "Patrol";
						scheduleBlock.action = "Patrol";
						this.GetDestinations();
					}
					if (!this.StudentManager.ReactedToGameLeader && this.Actions[this.Phase] == StudentActionType.Bully && !this.StudentManager.Bully)
					{
						ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
						scheduleBlock2.destination = "Sunbathe";
						scheduleBlock2.action = "Sunbathe";
						this.GetDestinations();
					}
					if (this.Sedated)
					{
						this.SprintAnim = this.OriginalSprintAnim;
						this.Sedated = false;
					}
					this.CurrentAction = this.Actions[this.Phase];
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					if ((this.StudentID == 30 && this.StudentManager.DatingMinigame.Affection == 100f) || (this.StudentID == this.StudentManager.RivalID && DateGlobals.Weekday == DayOfWeek.Friday && !this.InCouple))
					{
						if (this.StudentID == this.StudentManager.RivalID && DateGlobals.Weekday == DayOfWeek.Friday)
						{
							Debug.Log("This is the part where Osana should go put a note in Senpai's locker.");
						}
						if (this.Actions[this.Phase] == StudentActionType.ChangeShoes)
						{
							if (this.StudentID == 30)
							{
								this.CurrentDestination = this.StudentManager.SuitorLocker;
								this.Pathfinding.target = this.StudentManager.SuitorLocker;
							}
							else
							{
								this.CurrentDestination = this.StudentManager.SenpaiLocker;
								this.Pathfinding.target = this.StudentManager.SenpaiLocker;
							}
							this.Confessing = true;
							this.Routine = false;
							this.CanTalk = false;
						}
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
						this.PinkSeifuku.SetActive(false);
					}
					else
					{
						this.HorudaCollider.gameObject.SetActive(false);
					}
					if (this.StudentID == 81)
					{
						this.Cigarette.SetActive(false);
						this.Lighter.SetActive(false);
					}
					if (!this.Paired)
					{
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
					}
					if (this.Persona != PersonaType.PhoneAddict && !this.Sleuthing)
					{
						this.SmartPhone.SetActive(false);
					}
					else if (!this.Slave)
					{
						this.IdleAnim = this.PhoneAnims[0];
						this.SmartPhone.SetActive(true);
					}
					this.Paintbrush.SetActive(false);
					this.Sketchbook.SetActive(false);
					this.Palette.SetActive(false);
					this.Pencil.SetActive(false);
					this.OccultBook.SetActive(false);
					this.Scrubber.SetActive(false);
					this.Eraser.SetActive(false);
					this.Pen.SetActive(false);
					foreach (GameObject gameObject in this.ScienceProps)
					{
						if (gameObject != null)
						{
							gameObject.SetActive(false);
						}
					}
					foreach (GameObject gameObject2 in this.Fingerfood)
					{
						if (gameObject2 != null)
						{
							gameObject2.SetActive(false);
						}
					}
					this.SpeechLines.Stop();
					this.GoAway = false;
					this.ReadPhase = 0;
					this.PatrolID = 0;
					if (this.Actions[this.Phase] == StudentActionType.Clean)
					{
						this.EquipCleaningItems();
					}
					else if (!this.Slave)
					{
						if (this.Persona == PersonaType.PhoneAddict)
						{
							this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
							this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
							this.WalkAnim = this.PhoneAnims[1];
						}
						else if (this.Sleuthing)
						{
							this.WalkAnim = this.SleuthWalkAnim;
						}
					}
					if (this.Actions[this.Phase] == StudentActionType.Sleuth && this.StudentManager.SleuthPhase == 3)
					{
						this.GetSleuthTarget();
					}
					if (this.Actions[this.Phase] == StudentActionType.Stalk)
					{
						this.TargetDistance = 10f;
					}
					else if (this.Actions[this.Phase] == StudentActionType.Follow)
					{
						this.TargetDistance = 1f;
					}
					else
					{
						this.TargetDistance = 0.5f;
					}
					if (this.Club == ClubType.Gardening && this.StudentID != 71)
					{
						this.WateringCan.transform.parent = this.Hips;
						this.WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
						this.WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
						if (this.Clock.Period == 6)
						{
							this.StudentManager.Patrols.List[this.StudentID] = this.StudentManager.GardeningPatrols[this.StudentID - 71];
							this.ClubAnim = "f02_waterPlantLow_00";
							this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
							this.Pathfinding.target = this.CurrentDestination;
						}
					}
					if (this.Club == ClubType.LightMusic)
					{
						if (this.StudentID == 51)
						{
							if (this.InstrumentBag[this.ClubMemberID].transform.parent == null)
							{
								this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
								this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
								this.Instruments[this.ClubMemberID].transform.parent = null;
								this.Instruments[this.ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
								this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
							}
							else
							{
								this.Instruments[this.ClubMemberID].SetActive(false);
							}
						}
						else
						{
							this.Instruments[this.ClubMemberID].SetActive(false);
						}
						this.Drumsticks[0].SetActive(false);
						this.Drumsticks[1].SetActive(false);
						this.AirGuitar.Stop();
					}
					if (this.Phase == 8 && this.StudentID == 36)
					{
						this.StudentManager.Clubs.List[this.StudentID].position = this.StudentManager.Clubs.List[71].position;
						this.StudentManager.Clubs.List[this.StudentID].rotation = this.StudentManager.Clubs.List[71].rotation;
						this.ClubAnim = this.GameAnim;
					}
					if (this.MyPlate != null && this.MyPlate.parent == this.RightHand)
					{
						this.CurrentDestination = this.StudentManager.Clubs.List[this.StudentID];
						this.Pathfinding.target = this.StudentManager.Clubs.List[this.StudentID];
					}
					if (this.Persona == PersonaType.Sleuth)
					{
						if (this.Male)
						{
							this.SmartPhone.transform.localPosition = new Vector3(0.06f, -0.02f, -0.02f);
						}
						else
						{
							this.SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.015f, -0.015f);
						}
						this.SmartPhone.transform.localEulerAngles = new Vector3(12.5f, 120f, 180f);
					}
				}
				if (!this.Teacher && this.Club != ClubType.Delinquent && (this.Clock.Period == 2 || this.Clock.Period == 4) && this.ClubActivityPhase < 16)
				{
					this.Pathfinding.speed = 4f;
				}
			}
			if (this.MeetTime > 0f && this.Clock.HourTime > this.MeetTime)
			{
				this.CurrentDestination = this.MeetSpot;
				this.Pathfinding.target = this.MeetSpot;
				this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Pathfinding.speed = 4f;
				this.SpeechLines.Stop();
				this.Meeting = true;
				this.MeetTime = 0f;
			}
			if (this.DistanceToDestination > this.TargetDistance)
			{
				if (this.CurrentDestination == null && this.Actions[this.Phase] == StudentActionType.Sleuth)
				{
					this.GetSleuthTarget();
				}
				if (this.Actions[this.Phase] == StudentActionType.Follow)
				{
					if (this.FollowTarget.Wet && this.FollowTarget.DistanceToDestination < 5f)
					{
						Debug.Log("Raibaru shouldn't get too close.");
						this.TargetDistance = 5f;
					}
					else
					{
						this.TargetDistance = 1f;
					}
					if (this.DistanceToDestination > 2f)
					{
						this.Pathfinding.speed = 5f;
						this.SpeechLines.Stop();
					}
					else
					{
						this.Pathfinding.speed = 1f;
					}
				}
				if (this.Actions[this.Phase] != StudentActionType.Follow || (this.Actions[this.Phase] == StudentActionType.Follow && this.DistanceToDestination > this.TargetDistance + 0.1f))
				{
					if (((this.Clock.Period == 1 && this.Clock.HourTime > 8.483334f) || (this.Clock.Period == 3 && this.Clock.HourTime > 13.4833336f)) && !this.Teacher)
					{
						this.Pathfinding.speed = 4f;
					}
					if (!this.InEvent && !this.Meeting && !this.GoAway)
					{
						if (this.DressCode)
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
								else if (this.Indoors && !this.GoAway)
								{
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
									this.DistanceToDestination = 100f;
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
							else if (this.Indoors && this.Actions[this.Phase] != StudentActionType.Clean && this.Actions[this.Phase] != StudentActionType.Sketch)
							{
								this.CurrentDestination = this.Destinations[this.Phase];
								this.Pathfinding.target = this.Destinations[this.Phase];
							}
						}
						else if (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes && this.Schoolwear > 1 && !this.SchoolwearUnavailable)
						{
							this.CurrentDestination = this.StudentManager.FemaleStripSpot;
							this.Pathfinding.target = this.StudentManager.FemaleStripSpot;
						}
					}
					if (!this.Pathfinding.canMove)
					{
						if (!this.Spawned)
						{
							base.transform.position = this.StudentManager.SpawnPositions[this.StudentID].position;
							this.Spawned = true;
							if (this.StudentID == 10 && this.StudentManager.Students[11] == null)
							{
								base.transform.position = new Vector3(-4f, 0f, -96f);
								Physics.SyncTransforms();
							}
						}
						if (!this.Paired && !this.Alarmed)
						{
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
							this.Obstacle.enabled = false;
						}
					}
					if (this.Pathfinding.speed > 0f)
					{
						if (this.Pathfinding.speed == 1f)
						{
							if (!this.CharacterAnimation.IsPlaying(this.WalkAnim))
							{
								if (this.Persona == PersonaType.PhoneAddict && this.Actions[this.Phase] == StudentActionType.Clean)
								{
									this.CharacterAnimation.CrossFade(this.OriginalWalkAnim);
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.WalkAnim);
								}
							}
						}
						else if (!this.Dying)
						{
							this.CharacterAnimation.CrossFade(this.SprintAnim);
						}
					}
					if (this.Club == ClubType.Occult && this.Actions[this.Phase] != StudentActionType.ClubAction)
					{
						this.OccultBook.SetActive(false);
					}
					if (!this.Meeting && !this.GoAway && !this.InEvent)
					{
						if (this.Actions[this.Phase] == StudentActionType.Clean)
						{
							if (this.SmartPhone.activeInHierarchy)
							{
								this.SmartPhone.SetActive(false);
							}
							if (this.CurrentDestination != this.CleaningSpot.GetChild(this.CleanID))
							{
								this.CurrentDestination = this.CleaningSpot.GetChild(this.CleanID);
								this.Pathfinding.target = this.CurrentDestination;
							}
						}
						if (this.Actions[this.Phase] == StudentActionType.Patrol && this.CurrentDestination != this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID))
						{
							this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
							this.Pathfinding.target = this.CurrentDestination;
						}
					}
				}
			}
			else
			{
				if (this.CurrentDestination != null)
				{
					bool flag = false;
					if ((this.Actions[this.Phase] == StudentActionType.Sleuth && this.StudentManager.SleuthPhase == 3) || this.Actions[this.Phase] == StudentActionType.Stalk || (this.Actions[this.Phase] == StudentActionType.Relax && this.CuriosityPhase == 1))
					{
						flag = true;
					}
					if (this.Actions[this.Phase] == StudentActionType.Follow)
					{
						this.FollowTargetDistance = Vector3.Distance(this.FollowTarget.transform.position, this.StudentManager.Hangouts.List[this.StudentID].transform.position);
						if (this.FollowTargetDistance < 1.1f && !this.FollowTarget.Alone)
						{
							this.MoveTowardsTarget(this.StudentManager.Hangouts.List[this.StudentID].position);
							float num = Quaternion.Angle(base.transform.rotation, this.StudentManager.Hangouts.List[this.StudentID].rotation);
							if (num > 1f && !this.StopRotating)
							{
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.StudentManager.Hangouts.List[this.StudentID].rotation, 10f * Time.deltaTime);
							}
						}
						else
						{
							this.targetRotation = Quaternion.LookRotation(this.FollowTarget.transform.position - base.transform.position);
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
						}
					}
					else if (!flag)
					{
						this.MoveTowardsTarget(this.CurrentDestination.position);
						float num2 = Quaternion.Angle(base.transform.rotation, this.CurrentDestination.rotation);
						if (num2 > 1f && !this.StopRotating)
						{
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, 10f * Time.deltaTime);
						}
					}
					else
					{
						if (this.Actions[this.Phase] == StudentActionType.Sleuth || this.Actions[this.Phase] == StudentActionType.Stalk)
						{
							this.targetRotation = Quaternion.LookRotation(this.SleuthTarget.position - base.transform.position);
						}
						else if (this.Crush > 0)
						{
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Students[this.Crush].transform.position.x, base.transform.position.y, this.StudentManager.Students[this.Crush].transform.position.z) - base.transform.position);
						}
						float num3 = Quaternion.Angle(base.transform.rotation, this.targetRotation);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
						if (num3 > 1f)
						{
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
						}
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
									this.Obstacle.enabled = false;
								}
								this.CurrentDestination = this.ChangingBooth.transform;
								this.Pathfinding.target = this.ChangingBooth.transform;
							}
							else
							{
								this.CharacterAnimation.CrossFade(this.IdleAnim);
							}
						}
						else if (!this.GoAway)
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
					else if (this.Actions[this.Phase] != StudentActionType.Clean)
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
								this.Pathfinding.canSearch = false;
								this.Pathfinding.canMove = false;
							}
							else if (this.Actions[this.Phase] == StudentActionType.Socializing || (this.Actions[this.Phase] == StudentActionType.Follow && this.FollowTargetDistance < 1f && !this.FollowTarget.Alone && !this.FollowTarget.InEvent && !this.FollowTarget.Talking))
							{
								if (this.MyPlate != null && this.MyPlate.parent == this.RightHand)
								{
									this.MyPlate.parent = null;
									this.MyPlate.position = this.OriginalPlatePosition;
									this.MyPlate.rotation = this.OriginalPlateRotation;
									this.IdleAnim = this.OriginalIdleAnim;
									this.WalkAnim = this.OriginalWalkAnim;
									this.LeanAnim = this.OriginalLeanAnim;
									this.ResumeDistracting = false;
									this.Distracting = false;
									this.Distracted = false;
									this.CanTalk = true;
								}
								if (this.Paranoia > 1.66666f && !this.StudentManager.LoveSick && this.Club != ClubType.Delinquent)
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
								}
								else
								{
									this.StudentManager.ConvoManager.CheckMe(this.StudentID);
									if (this.Club == ClubType.Delinquent)
									{
										if (this.Alone)
										{
											if (this.TrueAlone)
											{
												if (!this.SmartPhone.activeInHierarchy)
												{
													this.CharacterAnimation.CrossFade("delinquentTexting_00");
													this.SmartPhone.SetActive(true);
													this.SpeechLines.Stop();
												}
											}
											else
											{
												this.CharacterAnimation.CrossFade(this.IdleAnim);
												this.SpeechLines.Stop();
											}
										}
										else
										{
											if (!this.InEvent)
											{
												if (!this.Grudge)
												{
													if (!this.SpeechLines.isPlaying)
													{
														this.SmartPhone.SetActive(false);
														this.SpeechLines.Play();
													}
												}
												else
												{
													this.SmartPhone.SetActive(false);
												}
											}
											this.CharacterAnimation.CrossFade(this.RandomAnim);
											if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
											{
												this.PickRandomAnim();
											}
										}
									}
									else if (this.Alone)
									{
										if (!this.Male)
										{
											this.CharacterAnimation.CrossFade("f02_standTexting_00");
										}
										else if (this.StudentID == 36)
										{
											this.CharacterAnimation.CrossFade(this.ClubAnim);
										}
										else if (this.StudentID == 66)
										{
											this.CharacterAnimation.CrossFade("delinquentTexting_00");
										}
										else
										{
											this.CharacterAnimation.CrossFade("standTexting_00");
										}
										if (!this.SmartPhone.activeInHierarchy && !this.Shy)
										{
											if (this.StudentID == 36)
											{
												this.SmartPhone.transform.localPosition = new Vector3(0.0566666f, -0.02f, 0f);
												this.SmartPhone.transform.localEulerAngles = new Vector3(10f, 115f, 180f);
											}
											else
											{
												this.SmartPhone.transform.localPosition = new Vector3(0.015f, 0.01f, 0.025f);
												this.SmartPhone.transform.localEulerAngles = new Vector3(10f, -160f, 165f);
											}
											this.SmartPhone.SetActive(true);
											this.SpeechLines.Stop();
										}
									}
									else
									{
										if (!this.InEvent)
										{
											if (!this.Grudge)
											{
												if (!this.SpeechLines.isPlaying)
												{
													this.SmartPhone.SetActive(false);
													this.SpeechLines.Play();
												}
											}
											else
											{
												this.SmartPhone.SetActive(false);
											}
										}
										if (this.Club != ClubType.Photography)
										{
											this.CharacterAnimation.CrossFade(this.RandomAnim);
											if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
											{
												this.PickRandomAnim();
											}
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.RandomSleuthAnim);
											if (this.CharacterAnimation[this.RandomSleuthAnim].time >= this.CharacterAnimation[this.RandomSleuthAnim].length)
											{
												this.PickRandomSleuthAnim();
											}
										}
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Gossip)
							{
								if (this.Paranoia > 1.66666f && !this.StudentManager.LoveSick)
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
								}
								else
								{
									this.StudentManager.ConvoManager.CheckMe(this.StudentID);
									if (this.Alone)
									{
										if (!this.Shy)
										{
											this.CharacterAnimation.CrossFade("f02_standTexting_00");
											if (!this.SmartPhone.activeInHierarchy)
											{
												this.SmartPhone.SetActive(true);
												this.SpeechLines.Stop();
											}
										}
									}
									else
									{
										if (!this.SpeechLines.isPlaying)
										{
											this.SmartPhone.SetActive(false);
											this.SpeechLines.Play();
										}
										this.CharacterAnimation.CrossFade(this.RandomGossipAnim);
										if (this.CharacterAnimation[this.RandomGossipAnim].time >= this.CharacterAnimation[this.RandomGossipAnim].length)
										{
											this.PickRandomGossipAnim();
										}
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
								if (this.FragileSlave)
								{
									if (this.HuntTarget == null)
									{
										this.HuntTarget = this;
										this.GoCommitMurder();
									}
									else if (this.HuntTarget.Indoors)
									{
										this.GoCommitMurder();
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Relax)
							{
								if (this.CuriosityPhase == 0)
								{
									this.CharacterAnimation.CrossFade(this.RelaxAnim);
									if (this.Curious)
									{
										this.CuriosityTimer += Time.deltaTime;
										if (this.CuriosityTimer > 30f)
										{
											this.Pathfinding.target = this.StudentManager.Students[this.Crush].transform;
											this.CurrentDestination = this.StudentManager.Students[this.Crush].transform;
											this.TargetDistance = 5f;
											this.CuriosityTimer = 0f;
											this.CuriosityPhase++;
										}
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.LeanAnim);
									this.CuriosityTimer += Time.deltaTime;
									if (this.CuriosityTimer > 10f)
									{
										this.Pathfinding.target = this.Destinations[this.Phase];
										this.CurrentDestination = this.Destinations[this.Phase];
										this.TargetDistance = 0.5f;
										this.CuriosityTimer = 0f;
										this.CuriosityPhase--;
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes)
							{
								if (this.MyPlate != null && this.MyPlate.parent == this.RightHand)
								{
									this.MyPlate.parent = null;
									this.MyPlate.position = this.OriginalPlatePosition;
									this.MyPlate.rotation = this.OriginalPlateRotation;
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
									this.IdleAnim = this.OriginalIdleAnim;
									this.WalkAnim = this.OriginalWalkAnim;
									this.LeanAnim = this.OriginalLeanAnim;
									this.ResumeDistracting = false;
									this.Distracting = false;
									this.Distracted = false;
									this.CanTalk = true;
								}
								if (this.MustChangeClothing)
								{
									if (this.ChangeClothingPhase == 0)
									{
										if (this.StudentManager.CommunalLocker.Student == null)
										{
											this.StudentManager.CommunalLocker.Open = true;
											this.StudentManager.CommunalLocker.Student = this;
											this.StudentManager.CommunalLocker.SpawnSteam();
											this.Schoolwear = 1;
											this.ChangeClothingPhase++;
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
										}
									}
									else if (this.ChangeClothingPhase == 1 && !this.StudentManager.CommunalLocker.SteamCountdown)
									{
										this.Pathfinding.target = this.Seat;
										this.CurrentDestination = this.Seat;
										this.StudentManager.CommunalLocker.Student = null;
										this.ChangeClothingPhase++;
										this.MustChangeClothing = false;
									}
								}
								else if (this.Bullied)
								{
									if (this.SmartPhone.activeInHierarchy)
									{
										this.SmartPhone.SetActive(false);
									}
									this.CharacterAnimation.CrossFade(this.SadDeskSitAnim, 1f);
								}
								else
								{
									if (this.Rival && this.Phoneless && this.StudentManager.CommunalLocker.RivalPhone.gameObject.activeInHierarchy && !this.EndSearch && this.Yandere.CanMove)
									{
										this.CharacterAnimation.CrossFade(this.DiscoverPhoneAnim);
										this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 2, 5f);
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
											else if ((double)Vector3.Distance(base.transform.position, this.Seat.position) < 0.5)
											{
												if (!this.Phoneless)
												{
													if (this.Club != ClubType.Delinquent)
													{
														if (!this.SmartPhone.activeInHierarchy)
														{
															if (this.Male)
															{
																this.SmartPhone.transform.localPosition = new Vector3(0.025f, 0.0025f, 0.025f);
																this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 180f);
															}
															else
															{
																this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.01f, 0.01f);
																this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
															}
															this.SmartPhone.SetActive(true);
														}
														this.CharacterAnimation.CrossFade(this.DeskTextAnim);
													}
													else
													{
														this.CharacterAnimation.CrossFade("delinquentSit_00");
													}
												}
												else
												{
													this.CharacterAnimation.CrossFade(this.SadDeskSitAnim);
												}
											}
										}
										else if (this.StudentManager.Teachers[this.Class].SpeechLines.isPlaying && !this.StudentManager.Teachers[this.Class].Alarmed)
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
												if (this.SmartPhone.activeInHierarchy)
												{
													this.SmartPhone.SetActive(false);
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
										else if (this.Club != ClubType.Delinquent)
										{
											this.CharacterAnimation.CrossFade(this.ConfusedSitAnim);
										}
										else
										{
											this.CharacterAnimation.CrossFade("delinquentSit_00");
										}
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Peek)
							{
								this.CharacterAnimation.CrossFade(this.PeekAnim);
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
									if (this.StudentID == 47 || this.StudentID == 49)
									{
										if (this.GetNewAnimation)
										{
											this.StudentManager.ConvoManager.MartialArtsCheck();
										}
										if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
										{
											this.GetNewAnimation = true;
										}
									}
									if (this.Club != ClubType.Occult)
									{
										this.CharacterAnimation.CrossFade(this.ClubAnim);
									}
								}
								if (this.Club == ClubType.Cooking)
								{
									if (this.ClubActivityPhase == 0)
									{
										this.ClubTimer += Time.deltaTime;
										if (this.ClubTimer > 60f)
										{
											this.MyPlate.parent = this.RightHand;
											this.MyPlate.localPosition = new Vector3(0.02f, -0.02f, -0.15f);
											this.MyPlate.localEulerAngles = new Vector3(-5f, -90f, 172.5f);
											this.IdleAnim = this.PlateIdleAnim;
											this.WalkAnim = this.PlateWalkAnim;
											this.LeanAnim = this.PlateIdleAnim;
											this.GetFoodTarget();
											this.ClubTimer = 0f;
											this.ClubActivityPhase++;
										}
									}
									else
									{
										this.GetFoodTarget();
									}
								}
								else if (this.Club == ClubType.Drama)
								{
									this.StudentManager.DramaTimer += Time.deltaTime;
									if (this.StudentManager.DramaPhase == 1)
									{
										this.StudentManager.ConvoManager.CheckMe(this.StudentID);
										if (this.Alone)
										{
											if (this.Phoneless)
											{
												this.CharacterAnimation.CrossFade("f02_sit_01");
											}
											else
											{
												if (this.Male)
												{
													this.CharacterAnimation.CrossFade("standTexting_00");
												}
												else
												{
													this.CharacterAnimation.CrossFade("f02_standTexting_00");
												}
												if (!this.SmartPhone.activeInHierarchy)
												{
													this.SmartPhone.transform.localPosition = new Vector3(0.02f, 0.01f, 0.03f);
													this.SmartPhone.transform.localEulerAngles = new Vector3(5f, -160f, 180f);
													this.SmartPhone.SetActive(true);
													this.SpeechLines.Stop();
												}
											}
										}
										else if (this.StudentID == 26 && !this.SpeechLines.isPlaying)
										{
											this.SmartPhone.SetActive(false);
											this.SpeechLines.Play();
										}
										if (this.StudentManager.DramaTimer > 100f)
										{
											this.StudentManager.DramaTimer = 0f;
											this.StudentManager.UpdateDrama();
										}
									}
									else if (this.StudentManager.DramaPhase == 2)
									{
										if (this.StudentManager.DramaTimer > 300f)
										{
											this.StudentManager.DramaTimer = 0f;
											this.StudentManager.UpdateDrama();
										}
									}
									else if (this.StudentManager.DramaPhase == 3)
									{
										this.SpeechLines.Play();
										this.CharacterAnimation.CrossFade(this.RandomAnim);
										if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
										{
											this.PickRandomAnim();
										}
										if (this.StudentManager.DramaTimer > 100f)
										{
											this.StudentManager.DramaTimer = 0f;
											this.StudentManager.UpdateDrama();
										}
									}
								}
								else if (this.Club == ClubType.Occult)
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
								else if (this.Club == ClubType.Art)
								{
									if (this.ClubAttire && !this.Paintbrush.activeInHierarchy && (double)Vector3.Distance(base.transform.position, this.CurrentDestination.position) < 0.5)
									{
										this.Paintbrush.SetActive(true);
										this.Palette.SetActive(true);
									}
								}
								else if (this.Club == ClubType.LightMusic)
								{
									if ((double)this.Clock.HourTime < 16.9)
									{
										this.Instruments[this.ClubMemberID].SetActive(true);
										this.CharacterAnimation.CrossFade(this.ClubAnim);
										if (this.StudentID == 51)
										{
											if (this.InstrumentBag[this.ClubMemberID].transform.parent != null)
											{
												this.InstrumentBag[this.ClubMemberID].transform.parent = null;
												this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(0.5f, 4.5f, 22.45666f);
												this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
											}
											if (this.Instruments[this.ClubMemberID].transform.parent == null)
											{
												this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Play();
												this.Instruments[this.ClubMemberID].transform.parent = base.transform;
												this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.340493f, 0.653502f, -0.286104f);
												this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-13.6139f, 16.16775f, 72.5293f);
											}
										}
										else if (this.StudentID == 54 && !this.Drumsticks[0].activeInHierarchy)
										{
											this.Drumsticks[0].SetActive(true);
											this.Drumsticks[1].SetActive(true);
										}
									}
									else if (this.StudentID == 51)
									{
										this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(0.5f, 4.5f, 22.45666f);
										this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
										this.InstrumentBag[this.ClubMemberID].transform.parent = null;
										if (!this.StudentManager.PracticeMusic.isPlaying)
										{
											this.CharacterAnimation.CrossFade("f02_vocalIdle_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 114.5f)
										{
											this.CharacterAnimation.CrossFade("f02_vocalCelebrate_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 104f)
										{
											this.CharacterAnimation.CrossFade("f02_vocalWait_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 32f)
										{
											this.CharacterAnimation.CrossFade("f02_vocalSingB_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 24f)
										{
											this.CharacterAnimation.CrossFade("f02_vocalSingB_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 17f)
										{
											this.CharacterAnimation.CrossFade("f02_vocalSingB_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 14f)
										{
											this.CharacterAnimation.CrossFade("f02_vocalWait_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 8f)
										{
											this.CharacterAnimation.CrossFade("f02_vocalSingA_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 0f)
										{
											this.CharacterAnimation.CrossFade("f02_vocalWait_00");
										}
									}
									else if (this.StudentID == 52)
									{
										if (!this.Instruments[this.ClubMemberID].activeInHierarchy)
										{
											this.Instruments[this.ClubMemberID].SetActive(true);
											this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
											this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
											this.Instruments[this.ClubMemberID].transform.parent = this.Spine;
											this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
											this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
											this.InstrumentBag[this.ClubMemberID].transform.parent = null;
											this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 25f);
											this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
										}
										if (!this.StudentManager.PracticeMusic.isPlaying)
										{
											this.CharacterAnimation.CrossFade("f02_guitarIdle_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 114.5f)
										{
											this.CharacterAnimation.CrossFade("f02_guitarCelebrate_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 112f)
										{
											this.CharacterAnimation.CrossFade("f02_guitarWait_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 64f)
										{
											this.CharacterAnimation.CrossFade("f02_guitarPlayA_01");
										}
										else if (this.StudentManager.PracticeMusic.time > 8f)
										{
											this.CharacterAnimation.CrossFade("f02_guitarPlayA_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 0f)
										{
											this.CharacterAnimation.CrossFade("f02_guitarWait_00");
										}
									}
									else if (this.StudentID == 53)
									{
										if (!this.Instruments[this.ClubMemberID].activeInHierarchy)
										{
											this.Instruments[this.ClubMemberID].SetActive(true);
											this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
											this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
											this.Instruments[this.ClubMemberID].transform.parent = this.Spine;
											this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
											this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
											this.InstrumentBag[this.ClubMemberID].transform.parent = null;
											this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 26f);
											this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
										}
										if (!this.StudentManager.PracticeMusic.isPlaying)
										{
											this.CharacterAnimation.CrossFade("f02_guitarIdle_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 114.5f)
										{
											this.CharacterAnimation.CrossFade("f02_guitarCelebrate_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 112f)
										{
											this.CharacterAnimation.CrossFade("f02_guitarWait_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 88f)
										{
											this.CharacterAnimation.CrossFade("f02_guitarPlayA_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 80f)
										{
											this.CharacterAnimation.CrossFade("f02_guitarWait_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 64f)
										{
											this.CharacterAnimation.CrossFade("f02_guitarPlayB_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 0f)
										{
											this.CharacterAnimation.CrossFade("f02_guitarPlaySlowA_01");
										}
									}
									else if (this.StudentID == 54)
									{
										if (this.InstrumentBag[this.ClubMemberID].transform.parent != null)
										{
											this.InstrumentBag[this.ClubMemberID].transform.parent = null;
											this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 23f);
											this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
										}
										this.Drumsticks[0].SetActive(true);
										this.Drumsticks[1].SetActive(true);
										if (!this.StudentManager.PracticeMusic.isPlaying)
										{
											this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 114.5f)
										{
											this.CharacterAnimation.CrossFade("f02_drumsCelebrate_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 108f)
										{
											this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 96f)
										{
											this.CharacterAnimation.CrossFade("f02_drumsPlaySlow_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 80f)
										{
											this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 38f)
										{
											this.CharacterAnimation.CrossFade("f02_drumsPlay_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 46f)
										{
											this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 16f)
										{
											this.CharacterAnimation.CrossFade("f02_drumsPlay_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 0f)
										{
											this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
										}
									}
									else if (this.StudentID == 55)
									{
										if (this.InstrumentBag[this.ClubMemberID].transform.parent != null)
										{
											this.InstrumentBag[this.ClubMemberID].transform.parent = null;
											this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 24f);
											this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
										}
										if (!this.StudentManager.PracticeMusic.isPlaying)
										{
											this.CharacterAnimation.CrossFade("f02_keysIdle_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 114.5f)
										{
											this.CharacterAnimation.CrossFade("f02_keysCelebrate_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 80f)
										{
											this.CharacterAnimation.CrossFade("f02_keysWait_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 24f)
										{
											this.CharacterAnimation.CrossFade("f02_keysPlay_00");
										}
										else if (this.StudentManager.PracticeMusic.time > 0f)
										{
											this.CharacterAnimation.CrossFade("f02_keysWait_00");
										}
									}
								}
								else if (this.Club == ClubType.Science)
								{
									if (this.ClubAttire && !this.GoAway)
									{
										if (this.SciencePhase == 0)
										{
											this.CharacterAnimation.CrossFade(this.ClubAnim);
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.RummageAnim);
										}
										if ((double)Vector3.Distance(base.transform.position, this.CurrentDestination.position) < 0.5)
										{
											if (this.SciencePhase == 0)
											{
												if (this.StudentID == 62)
												{
													this.ScienceProps[0].SetActive(true);
												}
												else if (this.StudentID == 63)
												{
													this.ScienceProps[1].SetActive(true);
													this.ScienceProps[2].SetActive(true);
												}
												else if (this.StudentID == 64)
												{
													this.ScienceProps[0].SetActive(true);
												}
											}
											if (this.StudentID > 61)
											{
												this.ClubTimer += Time.deltaTime;
												if (this.ClubTimer > 60f)
												{
													this.ClubTimer = 0f;
													this.SciencePhase++;
													if (this.SciencePhase == 1)
													{
														this.ClubTimer = 50f;
														this.OriginalPosition = this.CurrentDestination.transform.position;
														this.OriginalRotation = this.CurrentDestination.transform.rotation;
														this.CurrentDestination.transform.position = this.StudentManager.SupplySpots[this.StudentID - 61].position;
														this.Pathfinding.target.position = this.StudentManager.SupplySpots[this.StudentID - 61].position;
														this.CurrentDestination.transform.rotation = this.StudentManager.SupplySpots[this.StudentID - 61].rotation;
														this.Pathfinding.target.rotation = this.StudentManager.SupplySpots[this.StudentID - 61].rotation;
														foreach (GameObject gameObject3 in this.ScienceProps)
														{
															if (gameObject3 != null)
															{
																gameObject3.SetActive(false);
															}
														}
													}
													else
													{
														this.SciencePhase = 0;
														this.ClubTimer = 0f;
														this.CurrentDestination.transform.position = this.OriginalPosition;
														this.Pathfinding.target.position = this.OriginalPosition;
														this.CurrentDestination.transform.rotation = this.OriginalRotation;
														this.Pathfinding.target.rotation = this.OriginalRotation;
													}
												}
											}
										}
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
									}
								}
								else if (this.Club == ClubType.Sports)
								{
									this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
									if (this.ClubActivityPhase == 0)
									{
										if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
										{
											this.ClubActivityPhase++;
											this.ClubAnim = "stretch_01";
											this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
										}
									}
									else if (this.ClubActivityPhase == 1)
									{
										if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
										{
											this.ClubActivityPhase++;
											this.ClubAnim = "stretch_02";
											this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
										}
									}
									else if (this.ClubActivityPhase == 2)
									{
										if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
										{
											this.WalkAnim = "trackJog_00";
											this.Hurry = true;
											this.ClubActivityPhase++;
											this.CharacterAnimation[this.ClubAnim].time = 0f;
											this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
										}
									}
									else if (this.ClubActivityPhase < 14)
									{
										if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
										{
											this.ClubActivityPhase++;
											this.CharacterAnimation[this.ClubAnim].time = 0f;
											this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
										}
									}
									else if (this.ClubActivityPhase == 14)
									{
										if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
										{
											this.WalkAnim = this.OriginalWalkAnim;
											this.Hurry = false;
											this.ClubActivityPhase = 0;
											this.ClubAnim = "stretch_00";
											this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
										}
									}
									else if (this.ClubActivityPhase == 15)
									{
										if (this.CharacterAnimation[this.ClubAnim].time >= 1f && this.MyController.radius > 0f)
										{
											this.MyRenderer.updateWhenOffscreen = true;
											this.Obstacle.enabled = false;
											this.MyController.radius = 0f;
											this.Distracted = true;
										}
										if (this.CharacterAnimation[this.ClubAnim].time >= 2f)
										{
											float value = this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) + Time.deltaTime * 200f;
											this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, value);
										}
										if (this.CharacterAnimation[this.ClubAnim].time >= 5f)
										{
											this.ClubActivityPhase++;
										}
									}
									else if (this.ClubActivityPhase == 16)
									{
										if ((double)this.CharacterAnimation[this.ClubAnim].time >= 6.1)
										{
											this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100f);
											this.Cosmetic.MaleHair[this.Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100f);
											GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.BigWaterSplash, this.RightHand.transform.position, Quaternion.identity);
											gameObject4.transform.eulerAngles = new Vector3(-90f, gameObject4.transform.eulerAngles.y, gameObject4.transform.eulerAngles.z);
											this.SetSplashes(true);
											this.ClubActivityPhase++;
										}
									}
									else if (this.ClubActivityPhase == 17)
									{
										if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
										{
											this.WalkAnim = "poolSwim_00";
											this.ClubAnim = "poolSwim_00";
											this.ClubActivityPhase++;
											this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase - 2);
											base.transform.position = this.Hips.transform.position;
											this.Character.transform.localPosition = new Vector3(0f, -0.25f, 0f);
											Physics.SyncTransforms();
											this.CharacterAnimation.Play(this.WalkAnim);
										}
									}
									else if (this.ClubActivityPhase == 18)
									{
										this.ClubActivityPhase++;
										this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase - 2);
										this.DistanceToDestination = 100f;
									}
									else if (this.ClubActivityPhase == 19)
									{
										this.ClubAnim = "poolExit_00";
										if (this.CharacterAnimation[this.ClubAnim].time >= 0.1f)
										{
											this.SetSplashes(false);
										}
										if (this.CharacterAnimation[this.ClubAnim].time >= 4.66666f)
										{
											float value2 = this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) - Time.deltaTime * 200f;
											this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, value2);
										}
										if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
										{
											this.ClubActivityPhase = 15;
											this.ClubAnim = "poolDive_00";
											this.MyController.radius = 0.1f;
											this.WalkAnim = this.OriginalWalkAnim;
											this.MyRenderer.updateWhenOffscreen = false;
											this.Character.transform.localPosition = new Vector3(0f, 0f, 0f);
											this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0f);
											this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
											base.transform.position = new Vector3(this.Hips.position.x, 4f, this.Hips.position.z);
											Physics.SyncTransforms();
											this.CharacterAnimation.Play(this.IdleAnim);
											this.Distracted = false;
											if (this.Clock.Period == 2 || this.Clock.Period == 4)
											{
												this.Pathfinding.speed = 4f;
											}
										}
									}
								}
								else if (this.Club == ClubType.Gardening)
								{
									if (this.WateringCan.transform.parent != this.RightHand)
									{
										this.WateringCan.transform.parent = this.RightHand;
										this.WateringCan.transform.localPosition = new Vector3(0.14f, -0.15f, -0.05f);
										this.WateringCan.transform.localEulerAngles = new Vector3(10f, 15f, 45f);
									}
									this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
									if (this.PatrolTimer >= this.CharacterAnimation[this.ClubAnim].length)
									{
										this.PatrolID++;
										if (this.PatrolID == this.StudentManager.Patrols.List[this.StudentID].childCount)
										{
											this.PatrolID = 0;
										}
										this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
										this.Pathfinding.target = this.CurrentDestination;
										this.PatrolTimer = 0f;
										this.WateringCan.transform.parent = this.Hips;
										this.WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
										this.WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
									}
								}
								else if (this.Club == ClubType.Gaming)
								{
									if (this.Phase < 8)
									{
										if (this.StudentID == 36 && !this.SmartPhone.activeInHierarchy)
										{
											this.SmartPhone.SetActive(true);
											this.SmartPhone.transform.localPosition = new Vector3(0.0566666f, -0.02f, 0f);
											this.SmartPhone.transform.localEulerAngles = new Vector3(10f, 115f, 180f);
										}
									}
									else
									{
										if (!this.ClubManager.GameScreens[this.ClubMemberID].activeInHierarchy)
										{
											this.ClubManager.GameScreens[this.ClubMemberID].SetActive(true);
										}
										if (this.SmartPhone.activeInHierarchy)
										{
											this.SmartPhone.SetActive(false);
										}
									}
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
									this.StudentManager.ConvoManager.CheckMe(this.StudentID);
									if (this.Alone)
									{
										if (!this.Male)
										{
											this.CharacterAnimation.CrossFade("f02_standTexting_00");
										}
										else
										{
											this.CharacterAnimation.CrossFade("standTexting_00");
										}
										if (!this.SmartPhone.activeInHierarchy)
										{
											this.SmartPhone.SetActive(true);
											this.SpeechLines.Stop();
										}
									}
									else
									{
										if (!this.InEvent && !this.SpeechLines.isPlaying)
										{
											this.SmartPhone.SetActive(false);
											this.SpeechLines.Play();
										}
										if (this.Club != ClubType.Photography)
										{
											this.CharacterAnimation.CrossFade(this.RandomAnim);
											if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
											{
												this.PickRandomAnim();
											}
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.RandomSleuthAnim);
											if (this.CharacterAnimation[this.RandomSleuthAnim].time >= this.CharacterAnimation[this.RandomSleuthAnim].length)
											{
												this.PickRandomSleuthAnim();
											}
										}
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.SitAndEatBento)
							{
								if (!this.Ragdoll.Poisoned && (!this.Bento.activeInHierarchy || this.Bento.transform.parent == null))
								{
									this.SmartPhone.SetActive(false);
									if (!this.Male)
									{
										this.Bento.transform.parent = this.LeftItemParent;
										this.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
										this.Bento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
									}
									else
									{
										this.Bento.transform.parent = this.LeftItemParent;
										this.Bento.transform.localPosition = new Vector3(-0.05f, -0.085f, 0f);
										this.Bento.transform.localEulerAngles = new Vector3(-3.2f, -24.4f, -94f);
									}
									this.Chopsticks[0].SetActive(true);
									this.Chopsticks[1].SetActive(true);
									this.Bento.SetActive(true);
									this.Lid.SetActive(false);
									this.MyBento.Prompt.Hide();
									this.MyBento.Prompt.enabled = false;
									if (this.MyBento.Tampered)
									{
										if (this.MyBento.Emetic)
										{
											this.Emetic = true;
										}
										else if (this.MyBento.Lethal)
										{
											this.Lethal = true;
										}
										else if (this.MyBento.Tranquil)
										{
											this.Sedated = true;
										}
										else if (this.MyBento.Headache)
										{
											this.Headache = true;
										}
									}
								}
								if (!this.Emetic && !this.Lethal && !this.Sedated && !this.Headache)
								{
									this.CharacterAnimation.CrossFade(this.EatAnim);
									if (this.FollowTarget != null && this.FollowTarget.CurrentAction != StudentActionType.SitAndEatBento)
									{
										this.EmptyHands();
										this.Pathfinding.canSearch = true;
										this.Pathfinding.canMove = true;
										ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[4];
										scheduleBlock3.destination = "Follow";
										scheduleBlock3.action = "Follow";
										this.GetDestinations();
										this.Pathfinding.target = this.FollowTarget.transform;
										this.CurrentDestination = this.FollowTarget.transform;
									}
								}
								else if (this.Emetic)
								{
									if (!this.Private)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										this.CharacterAnimation.CrossFade(this.EmeticAnim);
										this.Private = true;
										this.CanTalk = false;
									}
									if (this.CharacterAnimation[this.EmeticAnim].time >= 16f && this.StudentID == 10 && !this.Vomiting)
									{
										this.Subtitle.UpdateLabel(SubtitleType.ObstaclePoisonReaction, 0, 9f);
										this.Vomiting = true;
									}
									if (this.CharacterAnimation[this.EmeticAnim].time >= this.CharacterAnimation[this.EmeticAnim].length)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
										if (this.Male)
										{
											this.WalkAnim = "stomachPainWalk_00";
											this.StudentManager.GetMaleVomitSpot(this);
											this.Pathfinding.target = this.StudentManager.MaleVomitSpot;
											this.CurrentDestination = this.StudentManager.MaleVomitSpot;
										}
										else
										{
											this.WalkAnim = "f02_stomachPainWalk_00";
											this.StudentManager.GetFemaleVomitSpot(this);
											this.Pathfinding.target = this.StudentManager.FemaleVomitSpot;
											this.CurrentDestination = this.StudentManager.FemaleVomitSpot;
										}
										if (this.StudentID == 10)
										{
											this.Pathfinding.target = this.StudentManager.AltFemaleVomitSpot;
											this.CurrentDestination = this.StudentManager.AltFemaleVomitSpot;
										}
										this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
										this.CharacterAnimation.CrossFade(this.WalkAnim);
										this.DistanceToDestination = 100f;
										this.Pathfinding.canSearch = true;
										this.Pathfinding.canMove = true;
										this.Pathfinding.speed = 2f;
										this.MyBento.Tampered = false;
										this.Vomiting = true;
										this.Routine = false;
										this.Chopsticks[0].SetActive(false);
										this.Chopsticks[1].SetActive(false);
										this.Bento.SetActive(false);
									}
								}
								else if (this.Lethal)
								{
									if (!this.Private)
									{
										AudioSource component = base.GetComponent<AudioSource>();
										component.clip = this.PoisonDeathClip;
										component.Play();
										if (this.StudentManager.Students[11] != null)
										{
											this.StudentManager.Students[1].CharacterAnimation.CrossFade("witnessPoisoning_00");
											this.StudentManager.Students[1].Distracted = true;
											this.StudentManager.Students[1].Routine = false;
										}
										if (this.Male)
										{
											this.CharacterAnimation.CrossFade("poisonDeath_00");
											this.PoisonDeathAnim = "poisonDeath_00";
										}
										else
										{
											this.CharacterAnimation.CrossFade("f02_poisonDeath_00");
											this.PoisonDeathAnim = "f02_poisonDeath_00";
										}
										this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										this.Ragdoll.Poisoned = true;
										this.Private = true;
										this.Prompt.Hide();
										this.Prompt.enabled = false;
									}
									if (!this.Distracted && this.CharacterAnimation[this.PoisonDeathAnim].time >= 2.5f)
									{
										this.Distracted = true;
									}
									if (this.CharacterAnimation[this.PoisonDeathAnim].time >= 17.5f && this.Bento.activeInHierarchy)
									{
										this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
										this.Police.Corpses++;
										GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
										base.tag = "Blood";
										this.Ragdoll.ChokingAnimation = true;
										this.Ragdoll.Disturbing = true;
										this.Ragdoll.Choking = true;
										this.Dying = true;
										this.MurderSuicidePhase = 100;
										this.SpawnAlarmDisc();
										if (this.StudentManager.Students[11] != null)
										{
											this.StudentManager.Students[1].Chopsticks[0].SetActive(false);
											this.StudentManager.Students[1].Chopsticks[1].SetActive(false);
											this.StudentManager.Students[1].Bento.SetActive(false);
										}
										this.Chopsticks[0].SetActive(false);
										this.Chopsticks[1].SetActive(false);
										this.Bento.SetActive(false);
									}
									if (this.CharacterAnimation[this.PoisonDeathAnim].time >= this.CharacterAnimation[this.PoisonDeathAnim].length)
									{
										this.BecomeRagdoll();
										this.DeathType = DeathType.Poison;
										this.Ragdoll.Choking = false;
									}
								}
								else if (this.Sedated)
								{
									if (!this.Private)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										this.CharacterAnimation.CrossFade(this.HeadacheAnim);
										this.CanTalk = false;
										this.Private = true;
									}
									if (this.CharacterAnimation[this.HeadacheAnim].time >= this.CharacterAnimation[this.HeadacheAnim].length)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
										if (this.Male)
										{
											this.SprintAnim = "headacheWalk_00";
											this.RelaxAnim = "infirmaryRest_00";
										}
										else
										{
											this.SprintAnim = "f02_headacheWalk_00";
											this.RelaxAnim = "f02_infirmaryRest_00";
										}
										this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
										this.CharacterAnimation.CrossFade(this.SprintAnim);
										this.DistanceToDestination = 100f;
										this.Pathfinding.canSearch = true;
										this.Pathfinding.canMove = true;
										this.Pathfinding.speed = 2f;
										this.MyBento.Tampered = false;
										this.Distracted = true;
										this.Private = true;
										ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[4];
										scheduleBlock4.destination = "InfirmaryBed";
										scheduleBlock4.action = "Relax";
										this.GetDestinations();
										this.CurrentDestination = this.Destinations[this.Phase];
										this.Pathfinding.target = this.Destinations[this.Phase];
										this.Chopsticks[0].SetActive(false);
										this.Chopsticks[1].SetActive(false);
										this.Bento.SetActive(false);
									}
								}
								else if (this.Headache)
								{
									if (!this.Private)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										this.CharacterAnimation.CrossFade(this.HeadacheAnim);
										this.CanTalk = false;
										this.Private = true;
									}
									if (this.CharacterAnimation[this.HeadacheAnim].time >= this.CharacterAnimation[this.HeadacheAnim].length)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
										if (this.Male)
										{
											this.SprintAnim = "headacheWalk_00";
											this.IdleAnim = "headacheIdle_00";
										}
										else
										{
											this.SprintAnim = "f02_headacheWalk_00";
											this.IdleAnim = "f02_headacheIdle_00";
										}
										this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
										this.CharacterAnimation.CrossFade(this.SprintAnim);
										this.DistanceToDestination = 100f;
										this.Pathfinding.canSearch = true;
										this.Pathfinding.canMove = true;
										this.Pathfinding.speed = 2f;
										this.MyBento.Tampered = false;
										this.SeekingMedicine = true;
										this.Routine = false;
										this.Private = true;
										this.Chopsticks[0].SetActive(false);
										this.Chopsticks[1].SetActive(false);
										this.Bento.SetActive(false);
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.ChangeShoes)
							{
								if (this.MeetTime == 0f)
								{
									if (this.StudentManager.LoveManager.Suitor == this && this.StudentManager.LoveManager.LeftNote)
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
										this.SmartPhone.SetActive(false);
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
								this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
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
									if (this.StudentID == 39)
									{
										this.CharacterAnimation["f02_topHalfTexting_00"].weight = 1f;
									}
									this.PatrolTimer = 0f;
								}
								if (this.Restless)
								{
									this.SewTimer += Time.deltaTime;
									if (this.SewTimer > 20f)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
										ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[this.Phase];
										scheduleBlock5.destination = "Sketch";
										scheduleBlock5.action = "Sketch";
										this.GetDestinations();
										this.CurrentDestination = this.SketchPosition;
										this.Pathfinding.target = this.SketchPosition;
										this.SewTimer = 0f;
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Read)
							{
								if (this.ReadPhase == 0)
								{
									if (this.StudentID == 5)
									{
										this.HorudaCollider.gameObject.SetActive(true);
									}
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
								this.CharacterAnimation.CrossFade("f02_midoriTexting_00");
								if (this.SmartPhone.transform.localPosition.x != 0.02f)
								{
									this.SmartPhone.transform.localPosition = new Vector3(0.02f, -0.0075f, 0f);
									this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, -164f);
								}
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
									this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 2, 5f);
									this.EndSearch = true;
									this.Routine = false;
								}
								if (!this.EndSearch)
								{
									this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
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
										if (this.StudentID == 39)
										{
											this.CharacterAnimation["f02_topHalfTexting_00"].weight = 1f;
										}
										this.PatrolTimer = 0f;
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Wait)
							{
								if (!this.Cigarette.active && TaskGlobals.GetTaskStatus(81) == 3)
								{
									this.WaitAnim = "f02_smokeAttempt_00";
									this.SmartPhone.SetActive(false);
									this.Cigarette.SetActive(true);
									this.Lighter.SetActive(true);
								}
								this.CharacterAnimation.CrossFade(this.WaitAnim);
							}
							else if (this.Actions[this.Phase] == StudentActionType.Clean)
							{
								this.CleanTimer += Time.deltaTime;
								if (this.CleaningRole == 5)
								{
									if (this.CleanID == 0)
									{
										this.CharacterAnimation.CrossFade(this.CleanAnims[1]);
									}
									else
									{
										if (!this.StudentManager.RoofFenceUp)
										{
											this.Prompt.Label[0].text = "     Push";
											this.Prompt.HideButton[0] = false;
											this.Pushable = true;
										}
										this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
										if ((double)this.CleanTimer >= 1.166666 && (double)this.CleanTimer <= 6.166666 && !this.ChalkDust.isPlaying)
										{
											this.ChalkDust.Play();
										}
									}
								}
								else if (this.CleaningRole == 4)
								{
									this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
									if (!this.Drownable)
									{
										this.Prompt.Label[0].text = "     Drown";
										this.Prompt.HideButton[0] = false;
										this.Drownable = true;
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
								}
								if (this.CleanTimer >= this.CharacterAnimation[this.CleanAnims[this.CleaningRole]].length)
								{
									this.CleanID++;
									if (this.CleanID == this.CleaningSpot.childCount)
									{
										this.CleanID = 0;
									}
									this.CurrentDestination = this.CleaningSpot.GetChild(this.CleanID);
									this.Pathfinding.target = this.CurrentDestination;
									this.DistanceToDestination = 100f;
									this.CleanTimer = 0f;
									if (this.Pushable)
									{
										this.Prompt.Label[0].text = "     Talk";
										this.Pushable = false;
									}
									if (this.Drownable)
									{
										this.Drownable = false;
										this.StudentManager.UpdateMe(this.StudentID);
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Graffiti)
							{
								if (this.KilledMood)
								{
									this.Subtitle.UpdateLabel(SubtitleType.KilledMood, 0, 5f);
									this.GraffitiPhase = 4;
									this.KilledMood = false;
								}
								if (this.GraffitiPhase == 0)
								{
									AudioSource.PlayClipAtPoint(this.BullyGiggles[UnityEngine.Random.Range(0, this.BullyGiggles.Length)], this.Head.position);
									this.CharacterAnimation.CrossFade("f02_bullyDesk_00");
									this.SmartPhone.SetActive(false);
									this.GraffitiPhase++;
								}
								else if (this.GraffitiPhase == 1)
								{
									if (this.CharacterAnimation["f02_bullyDesk_00"].time >= 8f)
									{
										this.StudentManager.Graffiti[this.BullyID].SetActive(true);
										this.GraffitiPhase++;
									}
								}
								else if (this.GraffitiPhase == 2)
								{
									if (this.CharacterAnimation["f02_bullyDesk_00"].time >= 9.66666f)
									{
										AudioSource.PlayClipAtPoint(this.BullyGiggles[UnityEngine.Random.Range(0, this.BullyGiggles.Length)], this.Head.position);
										this.GraffitiPhase++;
									}
								}
								else if (this.GraffitiPhase == 3)
								{
									if (this.CharacterAnimation["f02_bullyDesk_00"].time >= this.CharacterAnimation["f02_bullyDesk_00"].length)
									{
										this.GraffitiPhase++;
									}
								}
								else if (this.GraffitiPhase == 4)
								{
									this.DistanceToDestination = 100f;
									ScheduleBlock scheduleBlock6 = this.ScheduleBlocks[2];
									scheduleBlock6.destination = "Patrol";
									scheduleBlock6.action = "Patrol";
									this.GetDestinations();
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
									this.SmartPhone.SetActive(true);
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Bully)
							{
								if (this.StudentManager.Students[this.StudentManager.VictimID] != null)
								{
									if (this.StudentManager.Students[this.StudentManager.VictimID].Distracted || this.StudentManager.Students[this.StudentManager.VictimID].Tranquil)
									{
										this.StudentManager.NoBully[this.BullyID] = true;
										this.KilledMood = true;
									}
									if (this.KilledMood)
									{
										this.Subtitle.UpdateLabel(SubtitleType.KilledMood, 0, 5f);
										this.BullyPhase = 4;
										this.KilledMood = false;
										this.BullyDust.Stop();
									}
									if (this.StudentManager.Students[81] == null)
									{
										ScheduleBlock scheduleBlock7 = this.ScheduleBlocks[4];
										scheduleBlock7.destination = "Patrol";
										scheduleBlock7.action = "Patrol";
										this.GetDestinations();
										this.CurrentDestination = this.Destinations[this.Phase];
										this.Pathfinding.target = this.Destinations[this.Phase];
									}
									else
									{
										this.SmartPhone.SetActive(false);
										if (this.BullyID == 1)
										{
											if (this.BullyPhase == 0)
											{
												this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
												this.Scrubber.SetActive(true);
												this.Eraser.SetActive(true);
												this.StudentManager.Students[this.StudentManager.VictimID].CharacterAnimation.CrossFade(this.StudentManager.Students[this.StudentManager.VictimID].BullyVictimAnim);
												this.StudentManager.Students[this.StudentManager.VictimID].Routine = false;
												this.CharacterAnimation.CrossFade("f02_bullyEraser_00");
												this.BullyPhase++;
											}
											else if (this.BullyPhase == 1)
											{
												if (this.CharacterAnimation["f02_bullyEraser_00"].time >= 0.833333f)
												{
													this.BullyDust.Play();
													this.BullyPhase++;
												}
											}
											else if (this.BullyPhase == 2)
											{
												if (this.CharacterAnimation["f02_bullyEraser_00"].time >= this.CharacterAnimation["f02_bullyEraser_00"].length)
												{
													AudioSource.PlayClipAtPoint(this.BullyLaughs[this.BullyID], this.Head.position);
													this.CharacterAnimation.CrossFade("f02_bullyLaugh_00");
													this.Scrubber.SetActive(false);
													this.Eraser.SetActive(false);
													this.BullyPhase++;
												}
											}
											else if (this.BullyPhase == 3)
											{
												if (this.CharacterAnimation["f02_bullyLaugh_00"].time >= this.CharacterAnimation["f02_bullyLaugh_00"].length)
												{
													this.BullyPhase++;
												}
											}
											else if (this.BullyPhase == 4)
											{
												this.StudentManager.Students[this.StudentManager.VictimID].Routine = true;
												ScheduleBlock scheduleBlock8 = this.ScheduleBlocks[4];
												scheduleBlock8.destination = "LunchSpot";
												scheduleBlock8.action = "Wait";
												this.GetDestinations();
												this.CurrentDestination = this.Destinations[this.Phase];
												this.Pathfinding.target = this.Destinations[this.Phase];
												this.SmartPhone.SetActive(true);
												this.Scrubber.SetActive(false);
												this.Eraser.SetActive(false);
											}
										}
										else
										{
											if (this.StudentManager.Students[81].BullyPhase < 2)
											{
												if (this.GiggleTimer == 0f)
												{
													AudioSource.PlayClipAtPoint(this.BullyGiggles[UnityEngine.Random.Range(0, this.BullyGiggles.Length)], this.Head.position);
													this.GiggleTimer = 5f;
												}
												this.GiggleTimer = Mathf.MoveTowards(this.GiggleTimer, 0f, Time.deltaTime);
												this.CharacterAnimation.CrossFade("f02_bullyGiggle_00");
											}
											else if (this.StudentManager.Students[81].BullyPhase < 4)
											{
												if (this.LaughTimer == 0f)
												{
													AudioSource.PlayClipAtPoint(this.BullyLaughs[this.BullyID], this.Head.position);
													this.LaughTimer = 5f;
												}
												this.LaughTimer = Mathf.MoveTowards(this.LaughTimer, 0f, Time.deltaTime);
												this.CharacterAnimation.CrossFade("f02_bullyLaugh_00");
											}
											if (this.CharacterAnimation["f02_bullyLaugh_00"].time >= this.CharacterAnimation["f02_bullyLaugh_00"].length || this.StudentManager.Students[81].BullyPhase == 4 || this.BullyPhase == 4)
											{
												this.DistanceToDestination = 100f;
												ScheduleBlock scheduleBlock9 = this.ScheduleBlocks[4];
												scheduleBlock9.destination = "Patrol";
												scheduleBlock9.action = "Patrol";
												this.GetDestinations();
												this.CurrentDestination = this.Destinations[this.Phase];
												this.Pathfinding.target = this.Destinations[this.Phase];
												this.SmartPhone.SetActive(true);
											}
										}
									}
								}
								else
								{
									this.DistanceToDestination = 100f;
									ScheduleBlock scheduleBlock10 = this.ScheduleBlocks[4];
									scheduleBlock10.destination = "Patrol";
									scheduleBlock10.action = "Patrol";
									this.GetDestinations();
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
									this.SmartPhone.SetActive(true);
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Follow)
							{
								if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && this.FollowTarget.CurrentAction == StudentActionType.Clean && this.FollowTarget.DistanceToDestination < 1f)
								{
									this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
									this.Scrubber.SetActive(true);
								}
								else if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && this.FollowTarget.CurrentAction == StudentActionType.Socializing && this.FollowTarget.DistanceToDestination < 1f)
								{
									if (this.FollowTarget.Alone)
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
										this.SpeechLines.Stop();
									}
									else
									{
										this.SpeechLines.Play();
										this.CharacterAnimation.CrossFade(this.RandomAnim);
										if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
										{
											this.PickRandomAnim();
										}
									}
								}
								else if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && this.FollowTarget.CurrentAction == StudentActionType.SitAndTakeNotes && this.FollowTarget.DistanceToDestination < 1f)
								{
									Debug.Log("Raibaru just changed her destination to class.");
									ScheduleBlock scheduleBlock11 = this.ScheduleBlocks[this.Phase];
									scheduleBlock11.destination = "Seat";
									scheduleBlock11.action = "SitAndTakeNotes";
									this.Actions[this.Phase] = StudentActionType.SitAndTakeNotes;
									this.CurrentAction = StudentActionType.SitAndTakeNotes;
									this.GetDestinations();
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
								}
								else if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && this.FollowTarget.CurrentAction == StudentActionType.SitAndEatBento && this.FollowTarget.DistanceToDestination < 1f)
								{
									Debug.Log("Raibaru just changed her destination to lunch.");
									ScheduleBlock scheduleBlock12 = this.ScheduleBlocks[this.Phase];
									scheduleBlock12.destination = "LunchSpot";
									scheduleBlock12.action = "SitAndEatBento";
									this.Actions[this.Phase] = StudentActionType.SitAndEatBento;
									this.CurrentAction = StudentActionType.SitAndEatBento;
									this.GetDestinations();
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
								}
								else if (this.FollowTarget.ConfessPhase == 5)
								{
									Debug.Log("Raibaru just changed her action to Sketch and her destination to Paint.");
									ScheduleBlock scheduleBlock13 = this.ScheduleBlocks[this.Phase];
									scheduleBlock13.destination = "Paint";
									scheduleBlock13.action = "Sketch";
									scheduleBlock13.time = 99f;
									this.GetDestinations();
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
									this.SpeechLines.Stop();
									if (this.SlideIn)
									{
										this.MoveTowardsTarget(this.CurrentDestination.position);
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Sulk)
							{
								if (this.Male)
								{
									this.CharacterAnimation.CrossFade("delinquentSulk_00");
								}
								else
								{
									this.CharacterAnimation.CrossFade("f02_railingSulk_0" + this.SulkPhase, 1f);
									this.SulkTimer += Time.deltaTime;
									if (this.SulkTimer > 7.66666f)
									{
										this.SulkTimer = 0f;
										this.SulkPhase++;
										if (this.SulkPhase == 3)
										{
											this.SulkPhase = 0;
										}
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Sleuth)
							{
								if (this.StudentManager.SleuthPhase != 3)
								{
									this.StudentManager.ConvoManager.CheckMe(this.StudentID);
									if (this.Alone)
									{
										if (this.Male)
										{
											this.CharacterAnimation.CrossFade("standTexting_00");
										}
										else
										{
											this.CharacterAnimation.CrossFade("f02_standTexting_00");
										}
										if (this.Male)
										{
											this.SmartPhone.transform.localPosition = new Vector3(0.025f, 0.0025f, 0.025f);
											this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 180f);
										}
										else
										{
											this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.01f, 0.01f);
											this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
										}
										this.SmartPhone.SetActive(true);
										this.SpeechLines.Stop();
									}
									else
									{
										if (!this.SpeechLines.isPlaying)
										{
											this.SmartPhone.SetActive(false);
											this.SpeechLines.Play();
										}
										this.CharacterAnimation.CrossFade(this.RandomSleuthAnim, 1f);
										if (this.CharacterAnimation[this.RandomSleuthAnim].time >= this.CharacterAnimation[this.RandomSleuthAnim].length)
										{
											this.PickRandomSleuthAnim();
										}
										this.StudentManager.SleuthTimer += Time.deltaTime;
										if (this.StudentManager.SleuthTimer > 100f)
										{
											this.StudentManager.SleuthTimer = 0f;
											this.StudentManager.UpdateSleuths();
										}
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.SleuthScanAnim);
									if (this.CharacterAnimation[this.SleuthScanAnim].time >= this.CharacterAnimation[this.SleuthScanAnim].length)
									{
										this.GetSleuthTarget();
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Stalk)
							{
								this.CharacterAnimation.CrossFade(this.SleuthIdleAnim);
								if (this.DistanceToPlayer < 5f)
								{
									if (Vector3.Distance(base.transform.position, this.StudentManager.FleeSpots[0].position) > 10f)
									{
										this.Pathfinding.target = this.StudentManager.FleeSpots[0];
										this.CurrentDestination = this.StudentManager.FleeSpots[0];
									}
									else
									{
										this.Pathfinding.target = this.StudentManager.FleeSpots[1];
										this.CurrentDestination = this.StudentManager.FleeSpots[1];
									}
									this.Pathfinding.speed = 4f;
									this.StalkerFleeing = true;
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Sketch)
							{
								this.CharacterAnimation.CrossFade(this.SketchAnim);
								this.Sketchbook.SetActive(true);
								this.Pencil.SetActive(true);
								if (this.Restless)
								{
									this.SewTimer += Time.deltaTime;
									if (this.SewTimer > 20f)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										ScheduleBlock scheduleBlock14 = this.ScheduleBlocks[this.Phase];
										scheduleBlock14.destination = "Patrol";
										scheduleBlock14.action = "Patrol";
										this.GetDestinations();
										this.EmptyHands();
										this.PatrolID = 1;
										this.PatrolTimer = 0f;
										this.CharacterAnimation[this.PatrolAnim].time = 0f;
										this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
										this.Pathfinding.target = this.CurrentDestination;
										this.SewTimer = 0f;
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Sunbathe)
							{
								if (this.SunbathePhase == 0)
								{
									if (this.StudentManager.CommunalLocker.Student == null)
									{
										this.StudentManager.CommunalLocker.Open = true;
										this.StudentManager.CommunalLocker.Student = this;
										this.StudentManager.CommunalLocker.SpawnSteam();
										this.MustChangeClothing = true;
										this.Schoolwear = 2;
										this.SunbathePhase++;
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
									}
								}
								else if (this.SunbathePhase == 1)
								{
									if (!this.StudentManager.CommunalLocker.SteamCountdown)
									{
										this.Pathfinding.target = this.StudentManager.SunbatheSpots[this.StudentID];
										this.CurrentDestination = this.StudentManager.SunbatheSpots[this.StudentID];
										this.StudentManager.CommunalLocker.Student = null;
										this.SunbathePhase++;
									}
								}
								else if (this.SunbathePhase == 2)
								{
									this.MyRenderer.updateWhenOffscreen = true;
									this.CharacterAnimation.CrossFade("f02_sunbatheStart_00");
									this.SmartPhone.SetActive(false);
									if (this.CharacterAnimation["f02_sunbatheStart_00"].time >= this.CharacterAnimation["f02_sunbatheStart_00"].length)
									{
										this.MyController.radius = 0f;
										this.SunbathePhase++;
									}
								}
								else if (this.SunbathePhase == 3)
								{
									this.CharacterAnimation.CrossFade("f02_sunbatheLoop_00");
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Shock)
							{
								if (this.StudentManager.Students[36] == null)
								{
									this.Phase++;
								}
								else if (this.StudentManager.Students[36].Routine && this.StudentManager.Students[36].DistanceToDestination < 1f)
								{
									if (!this.StudentManager.GamingDoor.Open)
									{
										this.StudentManager.GamingDoor.OpenDoor();
									}
									ParticleSystem.EmissionModule emission2 = this.Hearts.emission;
									if (this.SmartPhone.activeInHierarchy)
									{
										this.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
										this.SmartPhone.SetActive(false);
										this.MyController.radius = 0f;
										emission2.rateOverTime = 5f;
										emission2.enabled = true;
										this.Hearts.Play();
									}
									this.CharacterAnimation.CrossFade("f02_peeking_0" + (this.StudentID - 80));
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.PatrolAnim);
									if (!this.SmartPhone.activeInHierarchy)
									{
										this.SmartPhone.SetActive(true);
										this.MyController.radius = 0.1f;
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Miyuki)
							{
								if (this.StudentManager.MiyukiEnemy.Enemy.activeInHierarchy)
								{
									this.CharacterAnimation.CrossFade(this.MiyukiAnim);
									this.MiyukiTimer += Time.deltaTime;
									if (this.MiyukiTimer > 1f)
									{
										this.MiyukiTimer = 0f;
										this.Miyuki.Shoot();
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.VictoryAnim);
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Meeting)
							{
								if (this.StudentID != 36)
								{
									this.StudentManager.Meeting = true;
									if (this.StudentManager.Speaker == this.StudentID)
									{
										if (!this.SpeechLines.isPlaying)
										{
											this.CharacterAnimation.CrossFade(this.RandomAnim);
											this.SpeechLines.Play();
										}
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
										if (this.SpeechLines.isPlaying)
										{
											this.SpeechLines.Stop();
										}
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.PeekAnim);
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Lyrics)
							{
								this.LyricsTimer += Time.deltaTime;
								if (this.LyricsPhase == 0)
								{
									this.CharacterAnimation.CrossFade("f02_writingLyrics_00");
									if (!this.Pencil.activeInHierarchy)
									{
										this.Pencil.SetActive(true);
									}
									if (this.LyricsTimer > 18f)
									{
										this.StudentManager.LyricsSpot.position = this.StudentManager.AirGuitarSpot.position;
										this.StudentManager.LyricsSpot.eulerAngles = this.StudentManager.AirGuitarSpot.eulerAngles;
										this.Pencil.SetActive(false);
										this.LyricsPhase = 1;
										this.LyricsTimer = 0f;
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade("f02_airGuitar_00");
									if (!this.AirGuitar.isPlaying)
									{
										this.AirGuitar.Play();
									}
									if (this.LyricsTimer > 18f)
									{
										this.StudentManager.LyricsSpot.position = this.StudentManager.OriginalLyricsSpot.position;
										this.StudentManager.LyricsSpot.eulerAngles = this.StudentManager.OriginalLyricsSpot.eulerAngles;
										this.AirGuitar.Stop();
										this.LyricsPhase = 0;
										this.LyricsTimer = 0f;
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Sew)
							{
								this.CharacterAnimation.CrossFade("sewing_00");
								this.PinkSeifuku.SetActive(true);
								if (this.SewTimer < 10f && TaskGlobals.GetTaskStatus(8) == 3)
								{
									this.SewTimer += Time.deltaTime;
									if (this.SewTimer > 10f)
									{
										UnityEngine.Object.Instantiate<GameObject>(this.Yandere.PauseScreen.DropsMenu.GetComponent<DropsScript>().InfoChanWindow.Drops[1], new Vector3(28.289f, 0.7718928f, 5.196f), Quaternion.identity);
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Paint)
							{
								this.Painting.material.color += new Color(0f, 0f, 0f, Time.deltaTime * 0.00066666f);
								this.CharacterAnimation.CrossFade(this.PaintAnim);
								this.Paintbrush.SetActive(true);
								this.Palette.SetActive(true);
							}
						}
						else
						{
							this.CurrentDestination = this.StudentManager.GoAwaySpots.List[this.StudentID];
							this.Pathfinding.target = this.StudentManager.GoAwaySpots.List[this.StudentID];
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.GoAwayTimer += Time.deltaTime;
							if (this.GoAwayTimer > 10f)
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
							if (this.Yandere.Bloodiness == 0f && (double)this.Yandere.Sanity >= 66.66666 && (this.CurrentDestination == this.StudentManager.MeetSpots.List[8] || this.CurrentDestination == this.StudentManager.MeetSpots.List[9] || this.CurrentDestination == this.StudentManager.MeetSpots.List[10]))
							{
								if (this.StudentID == 30)
								{
									this.StudentManager.OfferHelp.UpdateLocation();
									this.StudentManager.OfferHelp.enabled = true;
								}
								else if (this.StudentID == 5)
								{
									this.Yandere.BullyPhotoCheck();
									if (this.Yandere.BullyPhoto)
									{
										this.StudentManager.FragileOfferHelp.UpdateLocation();
										this.StudentManager.FragileOfferHelp.enabled = true;
									}
								}
							}
							if (!SchoolGlobals.RoofFence && base.transform.position.y > 11f)
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
								this.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 4, 3f);
							}
							else if (this.StudentID == 28)
							{
								this.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 6, 3f);
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 4, 3f);
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
			if (this.Fleeing && !this.Dying)
			{
				if (!this.PinningDown)
				{
					if (this.Persona == PersonaType.Dangerous)
					{
						this.Yandere.Pursuer = this;
						Debug.Log("This student council member is running to pepper spray Yandere-chan.");
						if (this.StudentManager.CombatMinigame.Path > 3 && this.StudentManager.CombatMinigame.Path < 7)
						{
							this.ReturnToRoutine();
						}
					}
					if (this.Pathfinding.target != null)
					{
						this.DistanceToDestination = Vector3.Distance(base.transform.position, this.Pathfinding.target.position);
					}
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
						if (this.Persona == PersonaType.TeachersPet && this.WitnessedMurder && this.ReportPhase == 0 && this.StudentManager.Reporter == null && !this.Police.Called)
						{
							Debug.Log("Setting teacher as destination at beginning of Flee protocol.");
							this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
							this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
							this.StudentManager.Reporter = this;
							this.ReportingMurder = true;
							this.DetermineCorpseLocation();
						}
						if (base.transform.position.y < -11f)
						{
							if (this.Persona != PersonaType.Coward && this.Persona != PersonaType.Evil && this.Persona != PersonaType.Fragile && this.OriginalPersona != PersonaType.Evil)
							{
								this.Police.Witnesses--;
								this.Police.Show = true;
								if (this.Countdown.gameObject.activeInHierarchy)
								{
									this.PhoneAddictGameOver();
								}
							}
							base.transform.position = new Vector3(base.transform.position.x, -100f, base.transform.position.z);
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
								this.Pathfinding.speed = 5f;
							}
							else
							{
								this.Pathfinding.speed = 4f;
							}
							if (this.Persona == PersonaType.PhoneAddict && !this.CrimeReported)
							{
								if (this.Countdown.Sprite.fillAmount == 0f)
								{
									this.Countdown.Sprite.fillAmount = 1f;
									this.CrimeReported = true;
									if (this.WitnessedMurder && !this.Countdown.MaskedPhoto)
									{
										this.PhoneAddictGameOver();
									}
									else
									{
										if (this.StudentManager.ChaseCamera == this.ChaseCamera)
										{
											this.StudentManager.ChaseCamera = null;
										}
										this.SprintAnim = this.OriginalSprintAnim;
										this.Countdown.gameObject.SetActive(false);
										this.ChaseCamera.SetActive(false);
										this.Police.Called = true;
										this.Police.Show = true;
									}
								}
								else
								{
									this.SprintAnim = this.PhoneAnims[2];
									if (this.StudentManager.ChaseCamera == null)
									{
										this.StudentManager.ChaseCamera = this.ChaseCamera;
										this.ChaseCamera.SetActive(true);
									}
								}
							}
						}
						else
						{
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							if (!this.Halt)
							{
								if (this.StudentID > 1)
								{
									this.MoveTowardsTarget(this.Pathfinding.target.position);
									if (!this.Teacher)
									{
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
									}
								}
							}
							else if (this.Persona == PersonaType.TeachersPet)
							{
								this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Teachers[this.Class].transform.position.x, base.transform.position.y, this.StudentManager.Teachers[this.Class].transform.position.z) - base.transform.position);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
							}
							else if (this.Persona == PersonaType.Dangerous && !this.BreakingUpFight)
							{
								this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
							}
							if (this.Persona == PersonaType.TeachersPet)
							{
								if (this.ReportingMurder || this.ReportingBlood)
								{
									if (this.StudentManager.Teachers[this.Class].Alarmed)
									{
										if (this.Club == ClubType.Council)
										{
											this.Pathfinding.target = this.StudentManager.CorpseLocation;
											this.CurrentDestination = this.StudentManager.CorpseLocation;
										}
										else
										{
											if (this.PetDestination == null)
											{
												this.PetDestination = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, this.Seat.position + this.Seat.forward * -0.5f, Quaternion.identity).transform;
											}
											this.Pathfinding.target = this.PetDestination;
											this.CurrentDestination = this.PetDestination;
										}
										this.ReportPhase = 3;
									}
									if (this.ReportPhase == 0)
									{
										if (this.WitnessedMurder)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.PetMurderReport, 2, 3f);
											this.CharacterAnimation.CrossFade(this.ScaredAnim);
										}
										else if (this.WitnessedCorpse)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReport, 2, 3f);
											this.CharacterAnimation.CrossFade(this.ScaredAnim);
										}
										else if (this.WitnessedLimb)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.PetLimbReport, 2, 3f);
											this.CharacterAnimation.CrossFade(this.ScaredAnim);
										}
										else if (this.WitnessedBloodyWeapon)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.PetBloodyWeaponReport, 2, 3f);
											this.CharacterAnimation.CrossFade(this.ScaredAnim);
										}
										else if (this.WitnessedBloodPool)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.PetBloodReport, 2, 3f);
											this.CharacterAnimation.CrossFade(this.IdleAnim);
										}
										else if (this.WitnessedWeapon)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReport, 2, 3f);
											this.CharacterAnimation.CrossFade(this.ScaredAnim);
										}
										this.StudentManager.Teachers[this.Class].CharacterAnimation.CrossFade(this.StudentManager.Teachers[this.Class].IdleAnim);
										this.StudentManager.Teachers[this.Class].Routine = false;
										if (this.StudentManager.Teachers[this.Class].Investigating)
										{
											this.StudentManager.Teachers[this.Class].StopInvestigating();
										}
										this.Halt = true;
										this.ReportPhase++;
									}
									else if (this.ReportPhase == 1)
									{
										this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
										this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
										if (this.WitnessedBloodPool || (this.WitnessedWeapon && !this.WitnessedBloodyWeapon))
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
										}
										else if (this.WitnessedMurder || this.WitnessedCorpse || this.WitnessedLimb || this.WitnessedBloodyWeapon)
										{
											this.CharacterAnimation.CrossFade(this.ScaredAnim);
										}
										this.StudentManager.Teachers[this.Class].targetRotation = Quaternion.LookRotation(base.transform.position - this.StudentManager.Teachers[this.Class].transform.position);
										this.StudentManager.Teachers[this.Class].transform.rotation = Quaternion.Slerp(this.StudentManager.Teachers[this.Class].transform.rotation, this.StudentManager.Teachers[this.Class].targetRotation, 10f * Time.deltaTime);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 3f)
										{
											base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
											this.StudentManager.Teachers[this.Class].MyReporter = this;
											this.StudentManager.Teachers[this.Class].Routine = false;
											this.StudentManager.Teachers[this.Class].Fleeing = true;
											this.ReportTimer = 0f;
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase == 2)
									{
										this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
										this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
										if (this.WitnessedBloodPool || (this.WitnessedWeapon && !this.WitnessedBloodyWeapon))
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
										}
										else if (this.WitnessedMurder || this.WitnessedCorpse || this.WitnessedLimb || this.WitnessedBloodyWeapon)
										{
											this.CharacterAnimation.CrossFade(this.ScaredAnim);
										}
									}
									else if (this.ReportPhase == 3)
									{
										Debug.Log("This character just set their destination to themself.");
										this.Pathfinding.target = base.transform;
										this.CurrentDestination = base.transform;
										if (this.WitnessedBloodPool || (this.WitnessedWeapon && !this.WitnessedBloodyWeapon))
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
										}
										else if (this.WitnessedMurder || this.WitnessedCorpse || this.WitnessedLimb || this.WitnessedBloodyWeapon)
										{
											this.CharacterAnimation.CrossFade(this.ParanoidAnim);
										}
									}
									else if (this.ReportPhase < 100)
									{
										this.CharacterAnimation.CrossFade(this.ParanoidAnim);
									}
									else
									{
										Debug.Log("This character just set their destination to themself.");
										this.Pathfinding.target = base.transform;
										this.CurrentDestination = base.transform;
										this.CharacterAnimation.CrossFade(this.ScaredAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 5f)
										{
											if (this.StudentManager.Reporter == this)
											{
												this.StudentManager.CorpseLocation.position = Vector3.zero;
												this.StudentManager.Reporter = null;
											}
											else if (this.StudentManager.BloodReporter == this)
											{
												this.StudentManager.BloodLocation.position = Vector3.zero;
												this.StudentManager.BloodReporter = null;
											}
											this.StudentManager.UpdateStudents(0);
											this.CurrentDestination = this.Destinations[this.Phase];
											this.Pathfinding.target = this.Destinations[this.Phase];
											this.Pathfinding.speed = 1f;
											this.TargetDistance = 1f;
											this.ReportPhase = 0;
											this.ReportTimer = 0f;
											this.AlarmTimer = 0f;
											this.RandomAnim = this.BulliedIdleAnim;
											this.IdleAnim = this.BulliedIdleAnim;
											this.WalkAnim = this.BulliedWalkAnim;
											if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
											{
												this.Persona = this.OriginalPersona;
											}
											Debug.Log("WitnessedMurder is being set to false.");
											this.BloodPool = null;
											this.WitnessedBloodyWeapon = false;
											this.WitnessedBloodPool = false;
											this.WitnessedSomething = false;
											this.WitnessedCorpse = false;
											this.WitnessedMurder = false;
											this.WitnessedWeapon = false;
											this.WitnessedLimb = false;
											this.SmartPhone.SetActive(false);
											this.LostTeacherTrust = true;
											this.ReportingMurder = false;
											this.ReportingBlood = false;
											this.Reacted = false;
											this.Alarmed = false;
											this.Fleeing = false;
											this.Routine = true;
											this.Halt = false;
											if (this.Club == ClubType.Council)
											{
												this.Persona = PersonaType.Dangerous;
											}
											this.ID = 0;
											while (this.ID < this.Outlines.Length)
											{
												this.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
												this.ID++;
											}
										}
									}
								}
								else if (this.Club == ClubType.Council)
								{
									this.CharacterAnimation.CrossFade(this.GuardAnim);
									this.Persona = PersonaType.Dangerous;
									this.Guarding = true;
									this.Fleeing = false;
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ParanoidAnim);
									this.ReportPhase = 100;
								}
							}
							else if (this.Persona == PersonaType.Heroic)
							{
								if (!this.Yandere.Attacking && !this.StudentManager.PinningDown && !this.Yandere.Shoved)
								{
									if (this.StudentID == 1)
									{
										this.Yandere.EmptyHands();
										this.Pathfinding.canSearch = false;
										this.Pathfinding.canMove = false;
										this.TargetDistance = 1f;
										this.Yandere.CharacterAnimation.CrossFade("f02_unmasking_00");
										this.CharacterAnimation.CrossFade("unmasking_00");
										this.Yandere.CanMove = false;
										this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
										this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 1f);
										if (this.CharacterAnimation["unmasking_00"].time == 0f)
										{
											this.Yandere.ShoulderCamera.YandereNo();
											this.Yandere.Jukebox.GameOver();
										}
										if (this.CharacterAnimation["unmasking_00"].time >= 0.66666f && this.Yandere.Mask.transform.parent != this.LeftHand)
										{
											this.Yandere.Mask.transform.parent = this.LeftHand;
											this.Yandere.Mask.transform.localPosition = new Vector3(-0.1f, -0.05f, 0f);
											this.Yandere.Mask.transform.localEulerAngles = new Vector3(-90f, 90f, 0f);
											this.Yandere.Mask.transform.localScale = new Vector3(1f, 1f, 1f);
										}
										if (this.CharacterAnimation["unmasking_00"].time >= this.CharacterAnimation["unmasking_00"].length)
										{
											this.Yandere.Unmasked = true;
											this.Yandere.ShoulderCamera.GameOver();
										}
									}
									else
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
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
								}
							}
							else if (this.Persona == PersonaType.Coward || this.Persona == PersonaType.Fragile)
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
									if (!this.SmartPhone.activeInHierarchy)
									{
										if (this.StudentManager.Reporter == null && !this.Police.Called)
										{
											this.CharacterAnimation.CrossFade(this.SocialReportAnim);
											this.Subtitle.UpdateLabel(SubtitleType.SocialReport, 1, 5f);
											this.StudentManager.Reporter = this;
											this.SmartPhone.SetActive(true);
											this.SmartPhone.transform.localPosition = new Vector3(-0.015f, -0.01f, 0f);
											this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -170f, 165f);
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
										this.SmartPhone.SetActive(false);
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
									this.Subtitle.UpdateLabel(SubtitleType.SocialFear, 1, 5f);
									this.SpawnAlarmDisc();
									this.ReportPhase++;
									this.Halt = true;
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
									this.Subtitle.UpdateLabel(SubtitleType.SocialTerror, 1, 5f);
									this.VisionDistance = 0f;
									this.SpawnAlarmDisc();
									this.ReportPhase++;
								}
							}
							else if (this.Persona == PersonaType.Lovestruck)
							{
								if (this.ReportPhase < 3 && this.StudentManager.Students[this.LovestruckTarget].Fleeing)
								{
									Debug.Log("Lovestruck Target is fleeing, so destination is being set to Exit.");
									this.Pathfinding.target = this.StudentManager.Exit;
									this.CurrentDestination = this.StudentManager.Exit;
									this.ReportPhase = 3;
								}
								if (this.ReportPhase == 1)
								{
									if (this.StudentManager.Students[this.LovestruckTarget].Male)
									{
										this.StudentManager.Students[this.LovestruckTarget].CharacterAnimation.CrossFade("surprised_00");
									}
									else
									{
										this.StudentManager.Students[this.LovestruckTarget].CharacterAnimation.CrossFade("f02_surprise_00");
									}
									this.StudentManager.Students[this.LovestruckTarget].EmptyHands();
									this.CharacterAnimation.CrossFade(this.ScaredAnim);
									this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canSearch = false;
									this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canMove = false;
									this.StudentManager.Students[this.LovestruckTarget].Pathfinding.enabled = false;
									this.StudentManager.Students[this.LovestruckTarget].Routine = false;
									this.Pathfinding.enabled = false;
									if (this.WitnessedMurder && !this.SawMask)
									{
										this.Yandere.Jukebox.gameObject.active = false;
										this.Yandere.MainCamera.enabled = false;
										this.Yandere.RPGCamera.enabled = false;
										this.Yandere.Jukebox.Volume = 0f;
										this.Yandere.CanMove = false;
										this.StudentManager.LovestruckCamera.transform.parent = base.transform;
										this.StudentManager.LovestruckCamera.transform.localPosition = new Vector3(1f, 1f, -1f);
										this.StudentManager.LovestruckCamera.transform.localEulerAngles = new Vector3(0f, -30f, 0f);
										this.StudentManager.LovestruckCamera.active = true;
									}
									if (this.WitnessedMurder && !this.SawMask)
									{
										this.Subtitle.UpdateLabel(SubtitleType.LovestruckMurderReport, 0, 5f);
									}
									else if (this.LovestruckTarget == 1)
									{
										this.Subtitle.UpdateLabel(SubtitleType.LovestruckCorpseReport, 0, 5f);
									}
									else
									{
										this.Subtitle.UpdateLabel(SubtitleType.LovestruckCorpseReport, 1, 5f);
									}
									this.ReportPhase++;
								}
								else if (this.ReportPhase == 2)
								{
									this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Students[this.LovestruckTarget].transform.position.x, base.transform.position.y, this.StudentManager.Students[this.LovestruckTarget].transform.position.z) - base.transform.position);
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
									this.targetRotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, this.StudentManager.Students[this.LovestruckTarget].transform.position.y, base.transform.position.z) - this.StudentManager.Students[this.LovestruckTarget].transform.position);
									this.StudentManager.Students[this.LovestruckTarget].transform.rotation = Quaternion.Slerp(this.StudentManager.Students[this.LovestruckTarget].transform.rotation, this.targetRotation, 10f * Time.deltaTime);
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer > 5f)
									{
										if (this.WitnessedMurder && !this.SawMask)
										{
											this.Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(true);
											this.Yandere.Police.EndOfDay.Heartbroken.Exposed = true;
											this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_down_22");
											this.Yandere.Collapse = true;
											this.StudentManager.StopMoving();
											this.ReportPhase++;
										}
										else
										{
											Debug.Log("Both reporter and Lovestruck Target should be heading to the Exit.");
											this.StudentManager.Students[this.LovestruckTarget].Pathfinding.target = this.StudentManager.Exit;
											this.StudentManager.Students[this.LovestruckTarget].CurrentDestination = this.StudentManager.Exit;
											Debug.Log("Sprinting 3");
											this.StudentManager.Students[this.LovestruckTarget].CharacterAnimation.CrossFade(this.StudentManager.Students[1].SprintAnim);
											this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canSearch = true;
											this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canMove = true;
											this.StudentManager.Students[this.LovestruckTarget].Pathfinding.enabled = true;
											this.StudentManager.Students[this.LovestruckTarget].Pathfinding.speed = 4f;
											this.Pathfinding.target = this.StudentManager.Exit;
											this.CurrentDestination = this.StudentManager.Exit;
											this.Pathfinding.enabled = true;
											this.ReportPhase++;
										}
									}
								}
							}
							else if (this.Persona == PersonaType.Dangerous)
							{
								if (!this.Yandere.Attacking && !this.StudentManager.PinningDown && !this.Yandere.Struggling)
								{
									this.Spray();
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
								}
							}
							else if (this.Persona == PersonaType.Protective)
							{
								if (!this.Yandere.Dumping && !this.Yandere.Attacking)
								{
									Debug.Log("A protective student is taking down Yandere-chan.");
									if (this.Yandere.Aiming)
									{
										this.Yandere.StopAiming();
									}
									this.Yandere.Mopping = false;
									this.Yandere.EmptyHands();
									this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 4, 0f);
									this.AttackReaction();
									this.CharacterAnimation["f02_moCounterB_00"].time = 6f;
									this.Yandere.CharacterAnimation["f02_moCounterA_00"].time = 6f;
									this.Yandere.ShoulderCamera.ObstacleCounter = true;
									this.Yandere.ShoulderCamera.Timer = 6f;
									this.Police.Show = false;
									this.Yandere.CameraEffects.MurderWitnessed();
									this.Yandere.Jukebox.GameOver();
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
								}
							}
							else if (this.Persona == PersonaType.Violent)
							{
								if (!this.Yandere.Attacking && !this.Yandere.Struggling && !this.StudentManager.PinningDown && !this.RespectEarned)
								{
									if (!this.Yandere.DelinquentFighting)
									{
										Debug.Log(this.Name + " is supposed to begin the combat minigame now.");
										this.SmartPhone.SetActive(false);
										this.Threatened = true;
										this.Fleeing = false;
										this.Alarmed = true;
										this.NoTalk = false;
										this.Patience = 0;
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
								}
							}
							else if (this.Persona == PersonaType.Strict)
							{
								if (!this.WitnessedMurder)
								{
									if (this.ReportPhase == 0)
									{
										if (this.MyReporter.WitnessedMurder || this.MyReporter.WitnessedCorpse)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 0, 3f);
											this.InvestigatingPossibleDeath = true;
										}
										else if (this.MyReporter.WitnessedLimb)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 2, 3f);
										}
										else if (this.MyReporter.WitnessedBloodyWeapon)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 3, 3f);
										}
										else if (this.MyReporter.WitnessedBloodPool)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 1, 3f);
										}
										else if (this.MyReporter.WitnessedWeapon)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 4, 3f);
										}
										this.ReportPhase++;
									}
									else if (this.ReportPhase == 1)
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 3f)
										{
											base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
											StudentScript studentScript = null;
											if (this.MyReporter.WitnessedMurder || this.MyReporter.WitnessedCorpse)
											{
												studentScript = this.StudentManager.Reporter;
											}
											else if (this.MyReporter.WitnessedBloodPool || this.MyReporter.WitnessedLimb || this.MyReporter.WitnessedWeapon)
											{
												studentScript = this.StudentManager.BloodReporter;
											}
											if (this.MyReporter.WitnessedLimb)
											{
												this.InvestigatingPossibleLimb = true;
											}
											if (!studentScript.Teacher)
											{
												if (this.MyReporter.WitnessedMurder || this.MyReporter.WitnessedCorpse)
												{
													this.StudentManager.Reporter.CurrentDestination = this.StudentManager.CorpseLocation;
													this.StudentManager.Reporter.Pathfinding.target = this.StudentManager.CorpseLocation;
													this.CurrentDestination = this.StudentManager.CorpseLocation;
													this.Pathfinding.target = this.StudentManager.CorpseLocation;
													this.StudentManager.Reporter.TargetDistance = 2f;
												}
												else if (this.MyReporter.WitnessedBloodPool || this.MyReporter.WitnessedLimb || this.MyReporter.WitnessedWeapon)
												{
													this.StudentManager.BloodReporter.CurrentDestination = this.StudentManager.BloodLocation;
													this.StudentManager.BloodReporter.Pathfinding.target = this.StudentManager.BloodLocation;
													this.CurrentDestination = this.StudentManager.BloodLocation;
													this.Pathfinding.target = this.StudentManager.BloodLocation;
													this.StudentManager.BloodReporter.TargetDistance = 2f;
												}
											}
											this.TargetDistance = 1f;
											this.ReportTimer = 0f;
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase == 2)
									{
										if (this.WitnessedCorpse)
										{
											Debug.Log("A teacher has just witnessed a corpse while on their way to investigate a student's report of a corpse.");
											this.DetermineCorpseLocation();
											if (!this.Corpse.Poisoned)
											{
												this.Subtitle.Speaker = this;
												this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 1, 5f);
											}
											else
											{
												this.Subtitle.Speaker = this;
												this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 2, 2f);
											}
											this.ReportPhase++;
										}
										else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
										{
											Debug.Log("A teacher has just witnessed an alarming object while on their way to investigate a student's report.");
											this.DetermineBloodLocation();
											if (this.WitnessedLimb)
											{
												this.Subtitle.Speaker = this;
												this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 4, 5f);
											}
											else if (this.WitnessedBloodPool || this.WitnessedBloodyWeapon)
											{
												this.Subtitle.Speaker = this;
												this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 3, 5f);
											}
											else if (this.WitnessedWeapon)
											{
												this.Subtitle.Speaker = this;
												this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 5, 5f);
											}
											this.ReportPhase++;
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.GuardAnim);
											this.ReportTimer += Time.deltaTime;
											if (this.ReportTimer > 5f)
											{
												this.Subtitle.UpdateLabel(SubtitleType.TeacherPrankReaction, 1, 7f);
												this.ReportPhase = 98;
												this.ReportTimer = 0f;
											}
										}
									}
									else if (this.ReportPhase == 3)
									{
										if (this.WitnessedCorpse)
										{
											this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - base.transform.position);
											base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
											this.CharacterAnimation.CrossFade(this.InspectAnim);
										}
										else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
										{
											this.targetRotation = Quaternion.LookRotation(new Vector3(this.BloodPool.transform.position.x, base.transform.position.y, this.BloodPool.transform.position.z) - base.transform.position);
											base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
											this.CharacterAnimation[this.InspectBloodAnim].speed = 0.66666f;
											this.CharacterAnimation.CrossFade(this.InspectBloodAnim);
										}
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 6f)
										{
											this.ReportTimer = 0f;
											if (this.WitnessedWeapon && !this.WitnessedBloodyWeapon)
											{
												this.ReportPhase = 7;
											}
											else
											{
												this.ReportPhase++;
											}
										}
									}
									else if (this.ReportPhase == 4)
									{
										if (this.WitnessedCorpse)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherPoliceReport, 0, 5f);
										}
										else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherPoliceReport, 1, 5f);
										}
										this.SmartPhone.transform.localPosition = new Vector3(-0.01f, -0.005f, -0.02f);
										this.SmartPhone.transform.localEulerAngles = new Vector3(-10f, -145f, 170f);
										this.SmartPhone.SetActive(true);
										this.ReportPhase++;
									}
									else if (this.ReportPhase == 5)
									{
										this.CharacterAnimation.CrossFade(this.CallAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 5f)
										{
											this.CharacterAnimation.CrossFade(this.GuardAnim);
											this.SmartPhone.SetActive(false);
											this.WitnessedBloodyWeapon = false;
											this.WitnessedBloodPool = false;
											this.WitnessedSomething = false;
											this.WitnessedWeapon = false;
											this.WitnessedLimb = false;
											this.Police.Called = true;
											this.Police.Show = true;
											this.ReportTimer = 0f;
											this.Guarding = true;
											this.Alarmed = false;
											this.Fleeing = false;
											this.Reacted = false;
											this.ReportPhase++;
											if (this.MyReporter != null && this.MyReporter.ReportingBlood)
											{
												Debug.Log("The blood reporter has just been instructed to stop following the teacher.");
												this.MyReporter.ReportPhase++;
											}
										}
									}
									else if (this.ReportPhase != 6)
									{
										if (this.ReportPhase == 7)
										{
											Debug.Log("Telling reporter to go back to their normal routine.");
											this.StudentManager.BloodReporter = null;
											this.StudentManager.UpdateStudents(0);
											if (this.MyReporter != null)
											{
												this.MyReporter.CurrentDestination = this.MyReporter.Destinations[this.MyReporter.Phase];
												this.MyReporter.Pathfinding.target = this.MyReporter.Destinations[this.MyReporter.Phase];
												this.MyReporter.Pathfinding.speed = 1f;
												this.MyReporter.ReportTimer = 0f;
												this.MyReporter.AlarmTimer = 0f;
												this.MyReporter.TargetDistance = 1f;
												this.MyReporter.ReportPhase = 0;
												this.MyReporter.WitnessedSomething = false;
												this.MyReporter.WitnessedWeapon = false;
												this.MyReporter.Reacted = false;
												this.MyReporter.Alarmed = false;
												this.MyReporter.Fleeing = false;
												this.MyReporter.Routine = true;
												this.MyReporter.Halt = false;
												this.MyReporter.Persona = this.OriginalPersona;
												if (this.MyReporter.Club == ClubType.Council)
												{
													this.MyReporter.Persona = PersonaType.Dangerous;
												}
												this.ID = 0;
												while (this.ID < this.MyReporter.Outlines.Length)
												{
													this.MyReporter.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
													this.ID++;
												}
											}
											this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = false;
											this.BloodPool.GetComponent<WeaponScript>().Prompt.Hide();
											this.BloodPool.GetComponent<WeaponScript>().enabled = false;
											this.ReportPhase++;
										}
										else if (this.ReportPhase == 8)
										{
											this.CharacterAnimation.CrossFade("f02_teacherPickUp_00");
											if (this.CharacterAnimation["f02_teacherPickUp_00"].time >= 0.33333f)
											{
												this.Handkerchief.SetActive(true);
											}
											if (this.CharacterAnimation["f02_teacherPickUp_00"].time >= 2f)
											{
												this.BloodPool.parent = this.RightHand;
												this.BloodPool.localPosition = new Vector3(0f, 0f, 0f);
												this.BloodPool.localEulerAngles = new Vector3(0f, 0f, 0f);
											}
											if (this.CharacterAnimation["f02_teacherPickUp_00"].time >= this.CharacterAnimation["f02_teacherPickUp_00"].length)
											{
												this.CurrentDestination = this.StudentManager.WeaponBoxSpot;
												this.Pathfinding.target = this.StudentManager.WeaponBoxSpot;
												this.Pathfinding.speed = 1f;
												this.Hurry = false;
												this.ReportPhase++;
											}
										}
										else if (this.ReportPhase == 9)
										{
											this.StudentManager.BloodLocation.position = Vector3.zero;
											this.BloodPool.parent = null;
											this.BloodPool.position = this.StudentManager.WeaponBoxSpot.parent.position + new Vector3(0f, 1f, 0f);
											this.BloodPool.eulerAngles = new Vector3(0f, 90f, 0f);
											this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = true;
											this.BloodPool.GetComponent<WeaponScript>().enabled = true;
											this.BloodPool.GetComponent<WeaponScript>().Drop();
											this.BloodPool = null;
											this.CharacterAnimation.CrossFade(this.RunAnim);
											this.CurrentDestination = this.Destinations[this.Phase];
											this.Pathfinding.target = this.Destinations[this.Phase];
											this.Handkerchief.SetActive(false);
											this.Pathfinding.canSearch = true;
											this.Pathfinding.canMove = true;
											this.Pathfinding.speed = 1f;
											this.WitnessedSomething = false;
											this.Alarmed = false;
											this.Fleeing = false;
											this.Routine = true;
											this.ReportTimer = 0f;
											this.ReportPhase = 0;
										}
										else if (this.ReportPhase == 98)
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
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
											this.Subtitle.UpdateLabel(SubtitleType.PrankReaction, 1, 5f);
											this.CharacterAnimation.CrossFade(this.RunAnim);
											this.CurrentDestination = this.Destinations[this.Phase];
											this.Pathfinding.target = this.Destinations[this.Phase];
											this.Pathfinding.canSearch = true;
											this.Pathfinding.canMove = true;
											this.MyReporter.Persona = PersonaType.TeachersPet;
											this.MyReporter.ReportPhase = 100;
											this.MyReporter.Fleeing = true;
											this.ReportTimer = 0f;
											this.ReportPhase = 0;
											this.InvestigatingPossibleDeath = false;
											this.InvestigatingPossibleLimb = false;
											this.Alarmed = false;
											this.Fleeing = false;
											this.Routine = true;
										}
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
										this.Yandere.CharacterAnimation["f02_teacherCounterA_00"].time = 5f;
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
						if (this.Persona == PersonaType.Strict && this.BloodPool != null && this.BloodPool.parent == this.Yandere.RightHand)
						{
							Debug.Log("Yandere-chan picked up the weapon that the teacher was investigating!");
							this.WitnessedBloodyWeapon = false;
							this.WitnessedBloodPool = false;
							this.WitnessedSomething = false;
							this.WitnessedCorpse = false;
							this.WitnessedMurder = false;
							this.WitnessedWeapon = false;
							this.WitnessedLimb = false;
							this.YandereVisible = true;
							this.ReportTimer = 0f;
							this.BloodPool = null;
							this.ReportPhase = 0;
							this.Alarmed = false;
							this.Fleeing = false;
							this.Routine = true;
							this.Reacted = false;
							this.AlarmTimer = 0f;
							this.Alarm = 200f;
							this.BecomeAlarmed();
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
						Debug.Log("Sprinting 4");
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
					this.CharacterAnimation.CrossFade(this.OriginalWalkAnim);
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
				if (this.Phase < this.ScheduleBlocks.Length - 1 && (this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time || this.StudentManager.LockerRoomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.EastBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.IncineratorArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.HeadmasterArea.bounds.Contains(this.Yandere.transform.position)))
				{
					if (this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time)
					{
						this.Phase++;
					}
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.Hearts.emission.enabled = false;
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = 1f;
					this.Yandere.Followers--;
					this.Following = false;
					this.Routine = true;
					if (this.StudentManager.LockerRoomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.EastBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.IncineratorArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.HeadmasterArea.bounds.Contains(this.Yandere.transform.position))
					{
						this.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 1, 3f);
					}
					else
					{
						this.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
					}
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
									if (!this.Male)
									{
										this.CurrentDestination = this.StudentManager.FemaleBatheSpot;
										this.Pathfinding.target = this.StudentManager.FemaleBatheSpot;
									}
									else
									{
										this.CurrentDestination = this.StudentManager.MaleBatheSpot;
										this.Pathfinding.target = this.StudentManager.MaleBatheSpot;
									}
								}
								else if (!this.Male)
								{
									this.CurrentDestination = this.StudentManager.FastBatheSpot;
									this.Pathfinding.target = this.StudentManager.FastBatheSpot;
								}
								else
								{
									this.CurrentDestination = this.StudentManager.MaleBatheSpot;
									this.Pathfinding.target = this.StudentManager.MaleBatheSpot;
								}
								this.Pathfinding.canSearch = true;
								this.Pathfinding.canMove = true;
								this.BathePhase++;
							}
							else if (this.BathePhase == 4)
							{
								this.StudentManager.OpenValue = Mathf.Lerp(this.StudentManager.OpenValue, 0f, Time.deltaTime * 10f);
								this.StudentManager.FemaleShowerCurtain.SetBlendShapeWeight(0, this.StudentManager.OpenValue);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
								this.MoveTowardsTarget(this.CurrentDestination.position);
								this.CharacterAnimation.CrossFade(this.BathingAnim);
								if (this.CharacterAnimation[this.BathingAnim].time >= this.CharacterAnimation[this.BathingAnim].length)
								{
									this.StudentManager.OpenCurtain = true;
									this.LiquidProjector.enabled = false;
									this.Bloody = false;
									this.BathePhase++;
									this.Gas = false;
									this.GoChange();
									this.UnWet();
								}
							}
							else if (this.BathePhase == 5)
							{
								this.StudentManager.CommunalLocker.Open = true;
								this.StudentManager.CommunalLocker.Student = this;
								this.StudentManager.CommunalLocker.SpawnSteam();
								this.Schoolwear = ((!this.InEvent) ? 3 : 1);
								this.BathePhase++;
							}
							else if (this.BathePhase == 6)
							{
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
								this.MoveTowardsTarget(this.CurrentDestination.position);
							}
							else if (this.BathePhase == 7)
							{
								if (this.StudentID == 30 || this.StudentID == this.StudentManager.RivalID)
								{
									if (this.StudentManager.CommunalLocker.RivalPhone.Stolen)
									{
										this.CharacterAnimation.CrossFade("f02_losingPhone_00");
										this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 1, 5f);
										if (this.StudentID == this.StudentManager.RivalID)
										{
											this.RealizePhoneIsMissing();
										}
										this.Phoneless = true;
										this.BatheTimer = 6f;
										this.BathePhase++;
									}
									else
									{
										this.StudentManager.CommunalLocker.RivalPhone.gameObject.SetActive(false);
										this.BathePhase++;
									}
								}
								else
								{
									this.BathePhase += 2;
								}
							}
							else if (this.BathePhase == 8)
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
							else if (this.BathePhase == 9)
							{
								this.StudentManager.CommunalLocker.Student = null;
								this.StudentManager.CommunalLocker.Open = false;
								if (this.Phase == 1)
								{
									this.Phase++;
								}
								Debug.Log("Finished bathing. Returning to normal routine.");
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
							this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 2, 5f);
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
										this.Subtitle.Speaker = this;
										this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
									}
									else
									{
										this.Subtitle.Speaker = this;
										this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
									}
									this.CurrentDestination = this.StudentManager.FemaleStripSpot;
									this.Pathfinding.target = this.StudentManager.FemaleStripSpot;
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
										GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.LightSwitch.Electricity, base.transform.position, Quaternion.identity);
										gameObject5.transform.parent = this.Bones[1].transform;
										gameObject5.transform.localPosition = Vector3.zero;
										this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 3, 0f);
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
				if (this.DistractionTarget == null)
				{
					this.Distracting = false;
				}
				else if (this.DistractionTarget.Dying)
				{
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.DistractionTarget.TargetedForDistraction = false;
					this.DistractionTarget.Distracted = false;
					this.DistractionTarget.EmptyHands();
					this.Pathfinding.speed = 1f;
					this.Distracting = false;
					this.Distracted = false;
					this.CanTalk = true;
					this.Routine = true;
				}
				else
				{
					if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.DistractionTarget.InEvent)
					{
						this.GetFoodTarget();
					}
					if (this.DistanceToDestination < 5f || this.DistractionTarget.Leaving)
					{
						if (this.DistractionTarget.InEvent || this.DistractionTarget.Talking || this.DistractionTarget.Following || this.DistractionTarget.TurnOffRadio || this.DistractionTarget.Splashed || this.DistractionTarget.Shoving || this.DistractionTarget.Spraying || this.DistractionTarget.FocusOnYandere || this.DistractionTarget.ShoeRemoval.enabled || this.DistractionTarget.Posing || this.DistractionTarget.ClubActivityPhase >= 16 || !this.DistractionTarget.enabled || this.DistractionTarget.Alarmed || this.DistractionTarget.Fleeing || this.DistractionTarget.Wet || this.DistractionTarget.EatingSnack || this.DistractionTarget.MyBento.Tampered || this.DistractionTarget.Meeting || this.DistractionTarget.InvestigatingBloodPool || this.DistractionTarget.ReturningMisplacedWeapon || this.StudentManager.LockerRoomArea.bounds.Contains(this.DistractionTarget.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(this.DistractionTarget.transform.position) || this.StudentManager.EastBathroomArea.bounds.Contains(this.DistractionTarget.transform.position) || this.StudentManager.HeadmasterArea.bounds.Contains(this.DistractionTarget.transform.position) || (this.DistractionTarget.Actions[this.DistractionTarget.Phase] == StudentActionType.Bully && this.DistractionTarget.DistanceToDestination < 1f) || this.DistractionTarget.Leaving)
						{
							this.CurrentDestination = this.Destinations[this.Phase];
							this.Pathfinding.target = this.Destinations[this.Phase];
							this.DistractionTarget.TargetedForDistraction = false;
							this.Pathfinding.speed = 1f;
							this.Distracting = false;
							this.Distracted = false;
							this.SpeechLines.Stop();
							this.CanTalk = true;
							this.Routine = true;
							if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking)
							{
								this.GetFoodTarget();
							}
						}
						else if (this.DistanceToDestination < this.TargetDistance)
						{
							if (!this.DistractionTarget.Distracted)
							{
								if (this.StudentID > 1 && this.DistractionTarget.StudentID > 1 && this.Persona != PersonaType.Fragile && this.DistractionTarget.Persona != PersonaType.Fragile && ((this.Club != ClubType.Bully && this.DistractionTarget.Club == ClubType.Bully) || (this.Club == ClubType.Bully && this.DistractionTarget.Club != ClubType.Bully)))
								{
									this.BullyPhotoCollider.SetActive(true);
								}
								if (this.DistractionTarget.Investigating)
								{
									this.DistractionTarget.StopInvestigating();
								}
								this.StudentManager.UpdateStudents(this.DistractionTarget.StudentID);
								this.DistractionTarget.Pathfinding.canSearch = false;
								this.DistractionTarget.Pathfinding.canMove = false;
								this.DistractionTarget.OccultBook.SetActive(false);
								this.DistractionTarget.SmartPhone.SetActive(false);
								this.DistractionTarget.Distraction = base.transform;
								this.DistractionTarget.CameraReacting = false;
								this.DistractionTarget.Pathfinding.speed = 0f;
								this.DistractionTarget.Pen.SetActive(false);
								this.DistractionTarget.Drownable = false;
								this.DistractionTarget.Distracted = true;
								this.DistractionTarget.Pushable = false;
								this.DistractionTarget.Routine = false;
								this.DistractionTarget.CanTalk = false;
								this.DistractionTarget.ReadPhase = 0;
								this.DistractionTarget.SpeechLines.Stop();
								this.DistractionTarget.ChalkDust.Stop();
								this.DistractionTarget.CleanTimer = 0f;
								this.DistractionTarget.EmptyHands();
								this.DistractionTarget.Distractor = this;
								this.Pathfinding.speed = 0f;
								this.Distracted = true;
							}
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.DistractionTarget.transform.position.x, base.transform.position.y, this.DistractionTarget.transform.position.z) - base.transform.position);
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
							if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking)
							{
								this.CharacterAnimation.CrossFade(this.IdleAnim);
							}
							else
							{
								this.DistractionTarget.SpeechLines.Play();
								this.SpeechLines.Play();
								this.CharacterAnimation.CrossFade(this.RandomAnim);
								if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
								{
									this.PickRandomAnim();
								}
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
								this.DistractionTarget.Octodog.SetActive(false);
								this.DistractionTarget.Distraction = null;
								this.DistractionTarget.Distracted = false;
								this.DistractionTarget.CanTalk = true;
								this.DistractionTarget.Routine = true;
								this.DistractionTarget.EquipCleaningItems();
								this.DistractionTarget.EatingSnack = false;
								this.Private = false;
								this.DistractionTarget.CurrentDestination = this.DistractionTarget.Destinations[this.Phase];
								this.DistractionTarget.Pathfinding.target = this.DistractionTarget.Destinations[this.Phase];
								if (this.DistractionTarget.Persona == PersonaType.PhoneAddict)
								{
									this.DistractionTarget.SmartPhone.SetActive(true);
								}
								this.DistractionTarget.Distractor = null;
								this.DistractionTarget.SpeechLines.Stop();
								this.SpeechLines.Stop();
								this.BullyPhotoCollider.SetActive(false);
								this.Pathfinding.speed = 1f;
								this.Distracting = false;
								this.Distracted = false;
								this.CanTalk = true;
								this.Routine = true;
								if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking)
								{
									this.GetFoodTarget();
								}
							}
						}
						else if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking)
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
						}
						else if (this.Pathfinding.speed == 1f)
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.SprintAnim);
						}
					}
					else if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						if (this.Phase < this.ScheduleBlocks.Length - 1 && this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time)
						{
							this.Routine = true;
						}
					}
					else if (this.Pathfinding.speed == 1f)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.SprintAnim);
					}
				}
			}
			if (this.Hunting)
			{
				if (this.HuntTarget != null)
				{
					if (this.HuntTarget.Prompt.enabled && !this.HuntTarget.FightingSlave)
					{
						this.HuntTarget.Prompt.Hide();
						this.HuntTarget.Prompt.enabled = false;
					}
					this.Pathfinding.target = this.HuntTarget.transform;
					this.CurrentDestination = this.HuntTarget.transform;
					if (this.HuntTarget.Alive && !this.HuntTarget.Tranquil && !this.HuntTarget.PinningDown)
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
									this.Pathfinding.speed = 1.15f;
								}
							}
							else if (this.MurderSuicidePhase > 1)
							{
								this.CharacterAnimation.CrossFade(this.WalkAnim);
								this.HuntTarget.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.01f);
							}
							if (this.HuntTarget.Dying || this.HuntTarget.Ragdoll.enabled)
							{
								this.Hunting = false;
								this.Suicide = true;
							}
						}
						else if (this.HuntTarget.ClubActivityPhase >= 16)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						else if (!this.NEStairs.bounds.Contains(base.transform.position) && !this.NWStairs.bounds.Contains(base.transform.position) && !this.SEStairs.bounds.Contains(base.transform.position) && !this.SWStairs.bounds.Contains(base.transform.position))
						{
							if (!this.NEStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.NWStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.SEStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.SWStairs.bounds.Contains(this.HuntTarget.transform.position))
							{
								if (this.Pathfinding.canMove)
								{
									Debug.Log("Slave is attacking target!");
									if (this.HuntTarget.Strength == 9)
									{
										this.AttackWillFail = true;
									}
									if (!this.AttackWillFail)
									{
										this.CharacterAnimation.CrossFade("f02_murderSuicide_00");
									}
									else
									{
										this.CharacterAnimation.CrossFade("f02_brokenAttackFailA_00");
										this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
										this.Police.Corpses++;
										GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
										base.tag = "Blood";
										this.Ragdoll.MurderSuicideAnimation = true;
										this.Ragdoll.Disturbing = true;
										this.Dying = true;
										this.HipCollider.enabled = true;
										this.HipCollider.radius = 1f;
										this.MurderSuicidePhase = 9;
									}
									this.Pathfinding.canSearch = false;
									this.Pathfinding.canMove = false;
									this.Broken.Subtitle.text = string.Empty;
									this.MyController.radius = 0f;
									this.Broken.Done = true;
									if (!this.AttackWillFail)
									{
										AudioSource.PlayClipAtPoint(this.MurderSuicideSounds, base.transform.position + new Vector3(0f, 1f, 0f));
										AudioSource component2 = base.GetComponent<AudioSource>();
										component2.clip = this.MurderSuicideKiller;
										component2.Play();
									}
									if (this.HuntTarget.Shoving)
									{
										this.Yandere.CannotRecover = false;
									}
									if (this.StudentManager.CombatMinigame.Delinquent == this.HuntTarget)
									{
										this.StudentManager.CombatMinigame.Stop();
										this.StudentManager.CombatMinigame.ReleaseYandere();
									}
									if (!this.AttackWillFail)
									{
										this.HuntTarget.HipCollider.enabled = true;
										this.HuntTarget.HipCollider.radius = 1f;
										this.HuntTarget.DetectionMarker.Tex.enabled = false;
									}
									this.HuntTarget.TargetedForDistraction = false;
									this.HuntTarget.Pathfinding.canSearch = false;
									this.HuntTarget.Pathfinding.canMove = false;
									this.HuntTarget.WitnessCamera.Show = false;
									this.HuntTarget.CameraReacting = false;
									this.HuntTarget.Investigating = false;
									this.HuntTarget.Distracting = false;
									this.HuntTarget.Splashed = false;
									this.HuntTarget.Alarmed = false;
									this.HuntTarget.Burning = false;
									this.HuntTarget.Fleeing = false;
									this.HuntTarget.Routine = false;
									this.HuntTarget.Shoving = false;
									this.HuntTarget.Tripped = false;
									this.HuntTarget.Wet = false;
									this.HuntTarget.Hunter = this;
									this.HuntTarget.Prompt.Hide();
									this.HuntTarget.Prompt.enabled = false;
									if (this.Yandere.Pursuer == this.HuntTarget)
									{
										this.Yandere.Chased = false;
										this.Yandere.Pursuer = null;
									}
									if (!this.AttackWillFail)
									{
										if (!this.HuntTarget.Male)
										{
											this.HuntTarget.CharacterAnimation.CrossFade("f02_murderSuicide_01");
										}
										else
										{
											this.HuntTarget.CharacterAnimation.CrossFade("murderSuicide_01");
										}
										this.HuntTarget.Subtitle.UpdateLabel(SubtitleType.Dying, 0, 1f);
										this.HuntTarget.GetComponent<AudioSource>().clip = this.HuntTarget.MurderSuicideVictim;
										this.HuntTarget.GetComponent<AudioSource>().Play();
										this.Police.CorpseList[this.Police.Corpses] = this.HuntTarget.Ragdoll;
										this.Police.Corpses++;
										GameObjectUtils.SetLayerRecursively(this.HuntTarget.gameObject, 11);
										this.HuntTarget.tag = "Blood";
										this.HuntTarget.Ragdoll.MurderSuicideAnimation = true;
										this.HuntTarget.Ragdoll.Disturbing = true;
										this.HuntTarget.Dying = true;
										this.HuntTarget.MurderSuicidePhase = 100;
									}
									else
									{
										this.HuntTarget.CharacterAnimation.CrossFade("f02_brokenAttackFailB_00");
										this.HuntTarget.FightingSlave = true;
										this.HuntTarget.Distracted = true;
										this.StudentManager.UpdateMe(this.HuntTarget.StudentID);
									}
									this.HuntTarget.MyController.radius = 0f;
									this.HuntTarget.SpeechLines.Stop();
									this.HuntTarget.EyeShrink = 1f;
									this.HuntTarget.SpawnAlarmDisc();
									if (this.HuntTarget.Following)
									{
										this.Yandere.Followers--;
										this.Hearts.emission.enabled = false;
										this.HuntTarget.Following = false;
									}
									this.OriginalYPosition = this.HuntTarget.transform.position.y;
									if (this.MurderSuicidePhase == 0)
									{
										this.MurderSuicidePhase++;
									}
								}
								else
								{
									if (this.MurderSuicidePhase == 0 && this.CharacterAnimation["f02_brokenStandUp_00"].time >= this.CharacterAnimation["f02_brokenStandUp_00"].length)
									{
										this.Pathfinding.canSearch = true;
										this.Pathfinding.canMove = true;
									}
									if (this.MurderSuicidePhase > 0)
									{
										if (!this.AttackWillFail)
										{
											this.HuntTarget.targetRotation = Quaternion.LookRotation(this.HuntTarget.transform.position - base.transform.position);
											this.HuntTarget.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.01f);
										}
										else
										{
											this.HuntTarget.targetRotation = Quaternion.LookRotation(base.transform.position - this.HuntTarget.transform.position);
											this.HuntTarget.MoveTowardsTarget(base.transform.position + base.transform.forward * 1f);
										}
										this.HuntTarget.transform.rotation = Quaternion.Slerp(this.HuntTarget.transform.rotation, this.HuntTarget.targetRotation, Time.deltaTime * 10f);
										this.HuntTarget.transform.position = new Vector3(this.HuntTarget.transform.position.x, this.OriginalYPosition, this.HuntTarget.transform.position.z);
										this.targetRotation = Quaternion.LookRotation(this.HuntTarget.transform.position - base.transform.position);
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
											GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.Ragdoll.BloodPoolSpawner.BloodPool, base.transform.position + base.transform.up * 0.012f + base.transform.forward, Quaternion.identity);
											gameObject6.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
											gameObject6.transform.parent = this.Police.BloodParent;
											this.MyWeapon.Victims[this.HuntTarget.StudentID] = true;
											this.MyWeapon.Blood.enabled = true;
											if (!this.MyWeapon.Evidence)
											{
												this.MyWeapon.MurderWeapon = true;
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
									else if (this.MurderSuicidePhase == 8)
									{
										if (this.CharacterAnimation["f02_murderSuicide_00"].time >= this.CharacterAnimation["f02_murderSuicide_00"].length)
										{
											this.MyWeapon.transform.parent = null;
											this.MyWeapon.Drop();
											this.MyWeapon = null;
											this.StudentManager.StopHesitating();
											this.HuntTarget.HipCollider.radius = 0.5f;
											this.HuntTarget.BecomeRagdoll();
											this.HuntTarget.Ragdoll.Disturbing = false;
											this.HuntTarget.Ragdoll.MurderSuicide = true;
											this.HuntTarget.DeathType = DeathType.Weapon;
											if (this.BloodSprayCollider != null)
											{
												this.BloodSprayCollider.SetActive(false);
											}
											this.BecomeRagdoll();
											this.DeathType = DeathType.Weapon;
											this.StudentManager.MurderTakingPlace = false;
											this.Police.MurderSuicideScene = true;
											this.Ragdoll.MurderSuicide = true;
											this.MurderSuicide = true;
											this.Broken.HairPhysics[0].enabled = true;
											this.Broken.HairPhysics[1].enabled = true;
											this.Broken.enabled = false;
										}
									}
									else if (this.MurderSuicidePhase == 9)
									{
										this.CharacterAnimation.CrossFade("f02_brokenAttackFailA_00");
										if (this.CharacterAnimation["f02_brokenAttackFailA_00"].time >= this.CharacterAnimation["f02_brokenAttackFailA_00"].length)
										{
											this.MurderSuicidePhase = 1;
											this.Hunting = false;
											this.Suicide = true;
											this.HuntTarget.MyController.radius = 0.1f;
											this.HuntTarget.Distracted = false;
											this.HuntTarget.Routine = true;
										}
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
					this.Broken.HairPhysics[0].enabled = true;
					this.Broken.HairPhysics[1].enabled = true;
					this.Broken.enabled = false;
				}
			}
			if (this.CameraReacting)
			{
				this.PhotoPatience = Mathf.MoveTowards(this.PhotoPatience, 0f, Time.deltaTime);
				this.Prompt.Circle[0].fillAmount = 1f;
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				if (!this.Yandere.ClubAccessories[7].activeInHierarchy || this.Club == ClubType.Delinquent)
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
							if (this.Persona == PersonaType.PhoneAddict || this.Sleuthing)
							{
								this.SmartPhone.SetActive(true);
							}
							if (!this.Male && this.Cigarette.activeInHierarchy)
							{
								this.SmartPhone.SetActive(false);
							}
							this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
							this.Obstacle.enabled = false;
							this.CameraReacting = false;
							this.Routine = true;
							this.ReadPhase = 0;
							if (this.Actions[this.Phase] == StudentActionType.Clean)
							{
								this.Scrubber.SetActive(true);
								if (this.CleaningRole == 5)
								{
									this.Eraser.SetActive(true);
								}
							}
						}
					}
				}
				else if (this.Yandere.Shutter.TargetStudent != this.StudentID)
				{
					this.CameraPoseTimer = Mathf.MoveTowards(this.CameraPoseTimer, 0f, Time.deltaTime);
					if (this.CameraPoseTimer == 0f)
					{
						if (this.Persona == PersonaType.PhoneAddict || this.Sleuthing)
						{
							this.SmartPhone.SetActive(true);
						}
						this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
						this.Obstacle.enabled = false;
						this.CameraReacting = false;
						this.Routine = true;
						this.ReadPhase = 0;
						if (this.Actions[this.Phase] == StudentActionType.Clean)
						{
							this.Scrubber.SetActive(true);
							if (this.CleaningRole == 5)
							{
								this.Eraser.SetActive(true);
							}
						}
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
				if (!this.YandereInnocent && this.InvestigationPhase < 100 && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition))
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
				if (this.InvestigationPhase == 0)
				{
					if (this.InvestigationTimer < 5f)
					{
						if (this.Persona == PersonaType.Heroic)
						{
							this.InvestigationTimer += Time.deltaTime * 5f;
						}
						else
						{
							this.InvestigationTimer += Time.deltaTime;
						}
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
						if (this.Persona == PersonaType.Heroic)
						{
							this.Pathfinding.speed = 4f;
						}
						else
						{
							this.Pathfinding.speed = 1f;
						}
						this.InvestigationPhase++;
					}
				}
				else if (this.InvestigationPhase == 1)
				{
					if (this.DistanceToDestination > 1f)
					{
						if (this.Persona == PersonaType.Heroic)
						{
							this.CharacterAnimation.CrossFade(this.SprintAnim);
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
						}
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
				this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
				if (this.PatrolTimer > 5f)
				{
					this.StudentManager.CommunalLocker.RivalPhone.gameObject.SetActive(false);
					ScheduleBlock scheduleBlock15 = this.ScheduleBlocks[2];
					scheduleBlock15.destination = "Hangout";
					scheduleBlock15.action = "Hangout";
					ScheduleBlock scheduleBlock16 = this.ScheduleBlocks[4];
					scheduleBlock16.destination = "LunchSpot";
					scheduleBlock16.action = "Eat";
					ScheduleBlock scheduleBlock17 = this.ScheduleBlocks[7];
					scheduleBlock17.destination = "Hangout";
					scheduleBlock17.action = "Hangout";
					this.GetDestinations();
					Array.Copy(this.OriginalActions, this.Actions, this.OriginalActions.Length);
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.DistanceToDestination = 100f;
					this.LewdPhotos = this.StudentManager.CommunalLocker.RivalPhone.LewdPhotos;
					this.EndSearch = false;
					this.Phoneless = false;
					this.Routine = true;
				}
			}
			if (this.Shoving)
			{
				this.CharacterAnimation.CrossFade(this.ShoveAnim);
				if (this.CharacterAnimation[this.ShoveAnim].time > this.CharacterAnimation[this.ShoveAnim].length)
				{
					if ((this.Club != ClubType.Council && this.Persona != PersonaType.Violent) || this.RespectEarned)
					{
						this.Patience = 999;
					}
					if (this.Patience > 0)
					{
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Distracted = false;
						this.Shoving = false;
						this.Routine = true;
						this.Paired = false;
					}
					else if (this.Club == ClubType.Council)
					{
						this.Shoving = false;
						this.Spray();
					}
					else
					{
						this.SpawnAlarmDisc();
						this.SmartPhone.SetActive(false);
						this.Distracted = true;
						this.Threatened = true;
						this.Shoving = false;
						this.Alarmed = true;
					}
				}
			}
			if (this.Spraying && (double)this.CharacterAnimation[this.SprayAnim].time > 0.66666)
			{
				if (this.Yandere.Armed)
				{
					this.Yandere.EquippedWeapon.Drop();
				}
				this.Yandere.EmptyHands();
				this.PepperSprayEffect.Play();
				this.Spraying = false;
			}
			if (this.SentHome)
			{
				if (this.SentHomePhase == 0)
				{
					if (this.Shy)
					{
						this.CharacterAnimation[this.ShyAnim].weight = 0f;
					}
					this.CharacterAnimation.CrossFade(this.SentHomeAnim);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.SentHomePhase++;
					if (this.SmartPhone.activeInHierarchy)
					{
						this.CharacterAnimation[this.SentHomeAnim].time = 1.5f;
						this.SentHomePhase++;
					}
				}
				else if (this.SentHomePhase == 1)
				{
					if (this.CharacterAnimation[this.SentHomeAnim].time > 0.66666f)
					{
						this.SmartPhone.SetActive(true);
						this.SentHomePhase++;
					}
				}
				else if (this.SentHomePhase == 2 && this.CharacterAnimation[this.SentHomeAnim].time > this.CharacterAnimation[this.SentHomeAnim].length)
				{
					this.SprintAnim = this.OriginalSprintAnim;
					Debug.Log("Sprinting 7");
					this.CharacterAnimation.CrossFade(this.SprintAnim);
					this.CurrentDestination = this.StudentManager.Exit;
					this.Pathfinding.target = this.StudentManager.Exit;
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.SmartPhone.SetActive(false);
					this.Pathfinding.speed = 4f;
					this.SentHomePhase++;
				}
			}
			if (this.DramaticReaction)
			{
				this.DramaticCamera.transform.Translate(Vector3.forward * Time.deltaTime * 0.01f);
				if (this.DramaticPhase == 0)
				{
					this.DramaticCamera.rect = new Rect(0f, Mathf.Lerp(this.DramaticCamera.rect.y, 0.25f, Time.deltaTime * 10f), 1f, Mathf.Lerp(this.DramaticCamera.rect.height, 0.5f, Time.deltaTime * 10f));
					this.DramaticTimer += Time.deltaTime;
					if (this.DramaticTimer > 1f)
					{
						this.DramaticTimer = 0f;
						this.DramaticPhase++;
					}
				}
				else if (this.DramaticPhase == 1)
				{
					this.DramaticCamera.rect = new Rect(0f, Mathf.Lerp(this.DramaticCamera.rect.y, 0.5f, Time.deltaTime * 10f), 1f, Mathf.Lerp(this.DramaticCamera.rect.height, 0f, Time.deltaTime * 10f));
					this.DramaticTimer += Time.deltaTime;
					if (this.DramaticCamera.rect.height < 0.01f || this.DramaticTimer > 0.5f)
					{
						Debug.Log("Disabling Dramatic Camera.");
						this.DramaticCamera.gameObject.SetActive(false);
						this.AttackReaction();
						this.DramaticPhase++;
					}
				}
			}
			if (this.HitReacting && this.CharacterAnimation[this.SithReactAnim].time >= this.CharacterAnimation[this.SithReactAnim].length)
			{
				this.Persona = PersonaType.SocialButterfly;
				this.PersonaReaction();
				this.HitReacting = false;
			}
			if (this.Eaten)
			{
				if (this.Yandere.Eating)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				}
				if (this.CharacterAnimation[this.EatVictimAnim].time >= this.CharacterAnimation[this.EatVictimAnim].length)
				{
					this.BecomeRagdoll();
				}
			}
			if (this.Electrified && this.CharacterAnimation[this.ElectroAnim].time >= this.CharacterAnimation[this.ElectroAnim].length)
			{
				this.Electrocuted = true;
				this.BecomeRagdoll();
				this.DeathType = DeathType.Electrocution;
			}
			if (this.BreakingUpFight)
			{
				this.targetRotation = this.Yandere.transform.rotation * Quaternion.Euler(0f, 90f, 0f);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.5f);
				if (this.StudentID == 87)
				{
					if (this.CharacterAnimation[this.BreakUpAnim].time >= 4f)
					{
						this.CandyBar.SetActive(false);
					}
					else if ((double)this.CharacterAnimation[this.BreakUpAnim].time >= 0.16666666666)
					{
						this.CandyBar.SetActive(true);
					}
				}
				if (this.CharacterAnimation[this.BreakUpAnim].time >= this.CharacterAnimation[this.BreakUpAnim].length)
				{
					this.ReturnToRoutine();
				}
			}
			if (this.Tripping)
			{
				this.MoveTowardsTarget(new Vector3(0f, 0f, base.transform.position.z));
				this.CharacterAnimation.CrossFade("trip_00");
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				if (this.CharacterAnimation["trip_00"].time >= 0.5f && this.CharacterAnimation["trip_00"].time <= 5.5f && this.StudentManager.Gate.Crushing)
				{
					this.BecomeRagdoll();
					this.Ragdoll.Decapitated = true;
					UnityEngine.Object.Instantiate<GameObject>(this.SquishyBloodEffect, this.Head.position, Quaternion.identity);
				}
				if (this.CharacterAnimation["trip_00"].time >= this.CharacterAnimation["trip_00"].length)
				{
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Distracted = true;
					this.Tripping = false;
					this.Routine = true;
					this.Tripped = true;
				}
			}
			if (this.SeekingMedicine)
			{
				if (this.StudentManager.Students[90] == null)
				{
					if (this.SeekMedicinePhase < 5)
					{
						this.SeekMedicinePhase = 5;
					}
				}
				else if ((!this.StudentManager.Students[90].gameObject.activeInHierarchy || this.StudentManager.Students[90].Dying) && this.SeekMedicinePhase < 5)
				{
					this.SeekMedicinePhase = 5;
				}
				if (this.SeekMedicinePhase == 0)
				{
					this.CurrentDestination = this.StudentManager.Students[90].transform;
					this.Pathfinding.target = this.StudentManager.Students[90].transform;
					this.SeekMedicinePhase++;
				}
				else if (this.SeekMedicinePhase == 1)
				{
					this.CharacterAnimation.CrossFade(this.SprintAnim);
					if (this.DistanceToDestination < 1f)
					{
						StudentScript studentScript2 = this.StudentManager.Students[90];
						if (studentScript2.Investigating)
						{
							studentScript2.StopInvestigating();
						}
						this.StudentManager.UpdateStudents(studentScript2.StudentID);
						studentScript2.Pathfinding.canSearch = false;
						studentScript2.Pathfinding.canMove = false;
						studentScript2.RetreivingMedicine = true;
						studentScript2.Pathfinding.speed = 0f;
						studentScript2.CameraReacting = false;
						studentScript2.TargetStudent = this;
						studentScript2.Routine = false;
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Pathfinding.speed = 0f;
						this.Subtitle.UpdateLabel(SubtitleType.RequestMedicine, 0, 5f);
						this.SeekMedicinePhase++;
					}
				}
				else if (this.SeekMedicinePhase == 2)
				{
					StudentScript studentScript3 = this.StudentManager.Students[90];
					this.targetRotation = Quaternion.LookRotation(new Vector3(studentScript3.transform.position.x, base.transform.position.y, studentScript3.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.MedicineTimer += Time.deltaTime;
					if (this.MedicineTimer > 5f)
					{
						this.SeekMedicinePhase++;
						this.MedicineTimer = 0f;
						studentScript3.Pathfinding.canSearch = true;
						studentScript3.Pathfinding.canMove = true;
						studentScript3.RetrieveMedicinePhase++;
					}
				}
				else if (this.SeekMedicinePhase != 3)
				{
					if (this.SeekMedicinePhase == 4)
					{
						StudentScript studentScript4 = this.StudentManager.Students[90];
						this.targetRotation = Quaternion.LookRotation(new Vector3(studentScript4.transform.position.x, base.transform.position.y, studentScript4.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					}
					else if (this.SeekMedicinePhase == 5)
					{
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						ScheduleBlock scheduleBlock18 = this.ScheduleBlocks[this.Phase];
						scheduleBlock18.destination = "InfirmarySeat";
						scheduleBlock18.action = "Relax";
						this.GetDestinations();
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
						this.Pathfinding.speed = 2f;
						this.RelaxAnim = this.HeadacheSitAnim;
						this.SeekingMedicine = false;
						this.Routine = true;
					}
				}
			}
			if (this.RetreivingMedicine)
			{
				if (this.RetrieveMedicinePhase == 0)
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				}
				else if (this.RetrieveMedicinePhase == 1)
				{
					this.CharacterAnimation.CrossFade(this.WalkAnim);
					this.CurrentDestination = this.StudentManager.MedicineCabinet;
					this.Pathfinding.target = this.StudentManager.MedicineCabinet;
					this.Pathfinding.speed = 1f;
					this.RetrieveMedicinePhase++;
				}
				else if (this.RetrieveMedicinePhase == 2)
				{
					if (this.DistanceToDestination < 1f)
					{
						this.StudentManager.CabinetDoor.Locked = false;
						this.StudentManager.CabinetDoor.Open = true;
						this.StudentManager.CabinetDoor.Timer = 0f;
						this.CurrentDestination = this.TargetStudent.transform;
						this.Pathfinding.target = this.TargetStudent.transform;
						this.RetrieveMedicinePhase++;
					}
				}
				else if (this.RetrieveMedicinePhase == 3)
				{
					if (this.DistanceToDestination < 1f)
					{
						this.CurrentDestination = this.TargetStudent.transform;
						this.Pathfinding.target = this.TargetStudent.transform;
						this.RetrieveMedicinePhase++;
					}
				}
				else if (this.RetrieveMedicinePhase == 4)
				{
					if (this.DistanceToDestination < 1f)
					{
						this.CharacterAnimation.CrossFade("f02_giveItem_00");
						if (this.TargetStudent.Male)
						{
							this.TargetStudent.CharacterAnimation.CrossFade("eatItem_00");
						}
						else
						{
							this.TargetStudent.CharacterAnimation.CrossFade("f02_eatItem_00");
						}
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.TargetStudent.SeekMedicinePhase++;
						this.RetrieveMedicinePhase++;
					}
				}
				else if (this.RetrieveMedicinePhase == 5)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.MedicineTimer += Time.deltaTime;
					if (this.MedicineTimer > 3f)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.CurrentDestination = this.StudentManager.MedicineCabinet;
						this.Pathfinding.target = this.StudentManager.MedicineCabinet;
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.TargetStudent.SeekMedicinePhase++;
						this.RetrieveMedicinePhase++;
					}
				}
				else if (this.RetrieveMedicinePhase == 6 && this.DistanceToDestination < 1f)
				{
					this.StudentManager.CabinetDoor.Locked = true;
					this.StudentManager.CabinetDoor.Open = false;
					this.StudentManager.CabinetDoor.Timer = 0f;
					this.RetreivingMedicine = false;
					this.Routine = true;
				}
			}
			if (this.EatingSnack)
			{
				if (this.SnackPhase == 0)
				{
					this.CharacterAnimation.CrossFade(this.EatChipsAnim);
					this.SmartPhone.SetActive(false);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.SnackTimer += Time.deltaTime;
					if (this.SnackTimer > 10f)
					{
						UnityEngine.Object.Destroy(this.BagOfChips);
						this.StudentManager.GetNearestFountain(this);
						this.Pathfinding.target = this.DrinkingFountain.DrinkPosition;
						this.CurrentDestination = this.DrinkingFountain.DrinkPosition;
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.SnackTimer = 0f;
						this.SnackPhase++;
					}
				}
				else if (this.SnackPhase == 1)
				{
					this.CharacterAnimation.CrossFade(this.WalkAnim);
					if (this.Persona == PersonaType.PhoneAddict)
					{
						this.SmartPhone.SetActive(true);
					}
					if (this.DistanceToDestination < 1f)
					{
						this.SmartPhone.SetActive(false);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.SnackPhase++;
					}
				}
				else if (this.SnackPhase == 2)
				{
					this.CharacterAnimation.CrossFade(this.DrinkFountainAnim);
					this.MoveTowardsTarget(this.DrinkingFountain.DrinkPosition.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.DrinkingFountain.DrinkPosition.rotation, 10f * Time.deltaTime);
					if (this.CharacterAnimation[this.DrinkFountainAnim].time >= this.CharacterAnimation[this.DrinkFountainAnim].length)
					{
						this.DrinkingFountain.Occupied = false;
						this.EquipCleaningItems();
						this.EatingSnack = false;
						this.Private = false;
						this.Routine = true;
						this.StudentManager.UpdateMe(this.StudentID);
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
					}
					else if (this.CharacterAnimation[this.DrinkFountainAnim].time > 0.5f && this.CharacterAnimation[this.DrinkFountainAnim].time < 1.5f)
					{
						this.DrinkingFountain.WaterStream.Play();
					}
				}
			}
			if (this.Dodging)
			{
				if (this.CharacterAnimation[this.DodgeAnim].time >= this.CharacterAnimation[this.DodgeAnim].length)
				{
					this.Routine = true;
					this.Dodging = false;
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
				}
				else if (this.CharacterAnimation[this.DodgeAnim].time < 0.66666f)
				{
					this.MyController.Move(base.transform.forward * -1f * this.DodgeSpeed * Time.deltaTime);
					this.MyController.Move(Physics.gravity * 0.1f);
					if (this.DodgeSpeed > 0f)
					{
						this.DodgeSpeed = Mathf.MoveTowards(this.DodgeSpeed, 0f, Time.deltaTime * 3f);
					}
				}
			}
			if (!this.Guarding && this.InvestigatingBloodPool)
			{
				if (this.DistanceToDestination < 1f)
				{
					this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.CharacterAnimation[this.InspectBloodAnim].speed = 1f;
					this.CharacterAnimation.CrossFade(this.InspectBloodAnim);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					if (this.CharacterAnimation[this.InspectBloodAnim].time >= this.CharacterAnimation[this.InspectBloodAnim].length || this.Persona == PersonaType.Strict)
					{
						bool flag2 = false;
						if (this.Club == ClubType.Cooking && this.CurrentAction == StudentActionType.ClubAction)
						{
							flag2 = true;
						}
						if (this.WitnessedWeapon)
						{
							bool flag3 = false;
							if (!this.Teacher && this.BloodPool.GetComponent<WeaponScript>().Metal && this.StudentManager.MetalDetectors)
							{
								flag3 = true;
							}
							if (!this.WitnessedBloodyWeapon && this.StudentID > 1 && !flag3 && this.CurrentAction != StudentActionType.SitAndTakeNotes && this.Indoors && !flag2 && this.Club != ClubType.Delinquent && !this.BloodPool.GetComponent<WeaponScript>().Dangerous && this.BloodPool.GetComponent<WeaponScript>().Returner == null)
							{
								this.CharacterAnimation[this.PickUpAnim].time = 0f;
								this.BloodPool.GetComponent<WeaponScript>().Prompt.Hide();
								this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = false;
								this.BloodPool.GetComponent<WeaponScript>().enabled = false;
								this.BloodPool.GetComponent<WeaponScript>().Returner = this;
								if (this.StudentID == 41)
								{
									this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
								}
								else
								{
									this.Subtitle.UpdateLabel(SubtitleType.ReturningWeapon, 0, 5f);
								}
								this.ReturningMisplacedWeapon = true;
								this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
							}
						}
						this.InvestigatingBloodPool = false;
						this.WitnessCooldownTimer = 5f;
						if (this.WitnessedLimb)
						{
							this.SpawnAlarmDisc();
						}
						if (!this.ReturningMisplacedWeapon)
						{
							if (this.StudentManager.BloodReporter == this && this.WitnessedWeapon && !this.BloodPool.GetComponent<WeaponScript>().Dangerous)
							{
								this.StudentManager.BloodReporter = null;
							}
							if (this.StudentManager.BloodReporter == this && this.StudentID > 1)
							{
								if (this.Persona != PersonaType.Strict)
								{
									this.Persona = PersonaType.TeachersPet;
								}
								this.PersonaReaction();
							}
							else if (this.WitnessedWeapon && !this.WitnessedBloodyWeapon)
							{
								this.CurrentDestination = this.Destinations[this.Phase];
								this.Pathfinding.target = this.Destinations[this.Phase];
								this.LastSuspiciousObject2 = this.LastSuspiciousObject;
								this.LastSuspiciousObject = this.BloodPool;
								this.Pathfinding.canSearch = true;
								this.Pathfinding.canMove = true;
								this.Pathfinding.speed = 1f;
								if (this.StudentID == 41)
								{
									this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
								}
								else if (this.Club == ClubType.Delinquent)
								{
									this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 2, 3f);
								}
								else if (this.BloodPool.GetComponent<WeaponScript>().Dangerous)
								{
									this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 0, 3f);
								}
								else
								{
									this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 1, 3f);
								}
								this.WitnessedSomething = false;
								this.WitnessedWeapon = false;
								this.Routine = true;
								this.BloodPool = null;
								if (this.StudentManager.BloodReporter == this)
								{
									if (this.Persona != PersonaType.Strict)
									{
										this.Persona = PersonaType.TeachersPet;
									}
									this.PersonaReaction();
								}
							}
							else
							{
								if (this.Persona != PersonaType.Strict)
								{
									this.Persona = PersonaType.TeachersPet;
								}
								this.PersonaReaction();
							}
							this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
						}
					}
				}
				else if (this.Persona == PersonaType.Strict)
				{
					if (this.WitnessedWeapon && this.BloodPool.GetComponent<WeaponScript>().Returner)
					{
						this.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
						this.InvestigatingBloodPool = false;
						this.WitnessedBloodyWeapon = false;
						this.WitnessedBloodPool = false;
						this.WitnessedSomething = false;
						this.WitnessedWeapon = false;
						this.Routine = true;
						this.BloodPool = null;
						this.WitnessCooldownTimer = 5f;
					}
					else if (this.BloodPool.parent == this.Yandere.RightHand)
					{
						this.InvestigatingBloodPool = false;
						this.WitnessedBloodyWeapon = false;
						this.WitnessedBloodPool = false;
						this.WitnessedSomething = false;
						this.WitnessedWeapon = false;
						this.Routine = true;
						this.BloodPool = null;
						this.WitnessCooldownTimer = 5f;
						this.AlarmTimer = 0f;
						this.Alarm = 200f;
					}
				}
				else if (this.BloodPool == null || (this.WitnessedWeapon && this.BloodPool.parent != null) || (this.WitnessedBloodPool && this.BloodPool.parent == this.Yandere.RightHand) || (this.WitnessedWeapon && this.BloodPool.GetComponent<WeaponScript>().Returner))
				{
					this.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
					if (this.Club == ClubType.Cooking && this.CurrentAction == StudentActionType.ClubAction)
					{
						this.GetFoodTarget();
					}
					else
					{
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
					}
					this.InvestigatingBloodPool = false;
					this.WitnessedBloodyWeapon = false;
					this.WitnessedBloodPool = false;
					this.WitnessedSomething = false;
					this.WitnessedWeapon = false;
					this.Routine = true;
					this.BloodPool = null;
					this.WitnessCooldownTimer = 5f;
				}
			}
			if (this.ReturningMisplacedWeapon)
			{
				if (this.ReturningMisplacedWeaponPhase == 0)
				{
					this.CharacterAnimation.CrossFade(this.PickUpAnim);
					if ((this.Club == ClubType.Council || this.Teacher) && this.CharacterAnimation[this.PickUpAnim].time >= 0.33333f)
					{
						this.Handkerchief.SetActive(true);
					}
					if (this.CharacterAnimation[this.PickUpAnim].time >= 2f)
					{
						this.BloodPool.parent = this.RightHand;
						this.BloodPool.localPosition = new Vector3(0f, 0f, 0f);
						this.BloodPool.localEulerAngles = new Vector3(0f, 0f, 0f);
						if (this.Club != ClubType.Council && !this.Teacher)
						{
							this.BloodPool.GetComponent<WeaponScript>().FingerprintID = this.StudentID;
						}
					}
					if (this.CharacterAnimation[this.PickUpAnim].time >= this.CharacterAnimation[this.PickUpAnim].length)
					{
						this.CurrentDestination = this.BloodPool.GetComponent<WeaponScript>().Origin;
						this.Pathfinding.target = this.BloodPool.GetComponent<WeaponScript>().Origin;
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Pathfinding.speed = 1f;
						this.Hurry = false;
						this.ReturningMisplacedWeaponPhase++;
					}
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.WalkAnim);
					if (this.DistanceToDestination < 1.1f)
					{
						this.BloodPool.parent = null;
						this.BloodPool.position = this.BloodPool.GetComponent<WeaponScript>().StartingPosition;
						this.BloodPool.eulerAngles = this.BloodPool.GetComponent<WeaponScript>().StartingRotation;
						this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = true;
						this.BloodPool.GetComponent<WeaponScript>().enabled = true;
						this.BloodPool.GetComponent<WeaponScript>().Drop();
						this.BloodPool.GetComponent<WeaponScript>().MyRigidbody.useGravity = false;
						this.BloodPool.GetComponent<WeaponScript>().MyRigidbody.isKinematic = true;
						this.BloodPool.GetComponent<WeaponScript>().Returner = null;
						this.BloodPool = null;
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
						if (this.Club == ClubType.Council || this.Teacher)
						{
							this.Handkerchief.SetActive(false);
						}
						this.Pathfinding.speed = 1f;
						this.ReturningMisplacedWeapon = false;
						this.WitnessedSomething = false;
						this.WitnessedWeapon = false;
						this.ReportingBlood = false;
						this.Routine = true;
						this.ReturningMisplacedWeaponPhase = 0;
						this.WitnessCooldownTimer = 0f;
					}
				}
			}
			if (this.SentToLocker && !this.CheckingNote)
			{
				this.CharacterAnimation.CrossFade(this.RunAnim);
			}
			if (this.Stripping)
			{
				this.CharacterAnimation.CrossFade(this.StripAnim);
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				if (this.CharacterAnimation[this.StripAnim].time >= 1.5f)
				{
					if (this.Schoolwear != 1)
					{
						this.Schoolwear = 1;
						this.ChangeSchoolwear();
					}
					if (this.CharacterAnimation[this.StripAnim].time > this.CharacterAnimation[this.StripAnim].length)
					{
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Stripping = false;
						this.Routine = true;
					}
				}
			}
		}
	}

	private void UpdateVisibleCorpses()
	{
		this.VisibleCorpses.Clear();
		this.ID = 0;
		while (this.ID < this.Police.Corpses)
		{
			RagdollScript ragdollScript = this.Police.CorpseList[this.ID];
			if (ragdollScript != null && !ragdollScript.Hidden)
			{
				Collider collider = ragdollScript.AllColliders[0];
				if (this.CanSeeObject(collider.gameObject, collider.transform.position, this.CorpseLayers, this.Mask))
				{
					this.VisibleCorpses.Add(ragdollScript.StudentID);
					this.Corpse = ragdollScript;
					if (this.Club == ClubType.Delinquent && this.Corpse.Student.Club == ClubType.Bully)
					{
						this.ScaredAnim = this.EvilWitnessAnim;
						this.Persona = PersonaType.Evil;
					}
					if (this.Persona == PersonaType.TeachersPet && this.StudentManager.Reporter == null && !this.Police.Called)
					{
						this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
						this.StudentManager.CorpseLocation.LookAt(base.transform.position);
						this.StudentManager.CorpseLocation.Translate(this.StudentManager.CorpseLocation.forward * -1f);
						this.StudentManager.LowerCorpsePosition();
						this.StudentManager.Reporter = this;
						this.ReportingMurder = true;
						this.DetermineCorpseLocation();
					}
				}
			}
			this.ID++;
		}
	}

	private void UpdateVisibleBlood()
	{
		this.ID = 0;
		while (this.ID < this.StudentManager.Blood.Length)
		{
			if (!(this.BloodPool == null))
			{
				break;
			}
			Collider collider = this.StudentManager.Blood[this.ID];
			if (collider != null && this.CanSeeObject(collider.gameObject, collider.transform.position))
			{
				this.BloodPool = collider.transform;
				this.WitnessedBloodPool = true;
				if (this.Club != ClubType.Delinquent && this.StudentManager.BloodReporter == null && !this.Police.Called && !this.LostTeacherTrust)
				{
					this.StudentManager.BloodLocation.position = this.BloodPool.position;
					this.StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, this.StudentManager.BloodLocation.position.y, base.transform.position.z));
					this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward * -1f);
					this.StudentManager.LowerBloodPosition();
					this.StudentManager.BloodReporter = this;
					this.ReportingBlood = true;
					this.DetermineBloodLocation();
				}
			}
			this.ID++;
		}
	}

	private void UpdateVisibleLimbs()
	{
		this.ID = 0;
		while (this.ID < this.StudentManager.Limbs.Length)
		{
			if (!(this.BloodPool == null))
			{
				break;
			}
			Collider collider = this.StudentManager.Limbs[this.ID];
			if (collider != null && this.CanSeeObject(collider.gameObject, collider.transform.position))
			{
				this.BloodPool = collider.transform;
				this.WitnessedLimb = true;
				if (this.Club != ClubType.Delinquent && this.StudentManager.BloodReporter == null && !this.Police.Called && !this.LostTeacherTrust)
				{
					this.StudentManager.BloodLocation.position = this.BloodPool.position;
					this.StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, this.StudentManager.BloodLocation.position.y, base.transform.position.z));
					this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward * -1f);
					this.StudentManager.LowerBloodPosition();
					this.StudentManager.BloodReporter = this;
					this.ReportingBlood = true;
					this.DetermineBloodLocation();
				}
			}
			this.ID++;
		}
	}

	private void UpdateVisibleWeapons()
	{
		this.ID = 0;
		while (this.ID < this.Yandere.WeaponManager.Weapons.Length)
		{
			if (this.Yandere.WeaponManager.Weapons[this.ID] != null && (this.Yandere.WeaponManager.Weapons[this.ID].Blood.enabled || (this.Yandere.WeaponManager.Weapons[this.ID].Misplaced && this.Yandere.WeaponManager.Weapons[this.ID].transform.parent == null)))
			{
				if (!(this.BloodPool == null))
				{
					break;
				}
				if (this.Yandere.WeaponManager.Weapons[this.ID].transform != this.LastSuspiciousObject && this.Yandere.WeaponManager.Weapons[this.ID].transform != this.LastSuspiciousObject2 && this.Yandere.WeaponManager.Weapons[this.ID].enabled)
				{
					Collider myCollider = this.Yandere.WeaponManager.Weapons[this.ID].MyCollider;
					if (myCollider != null && this.CanSeeObject(myCollider.gameObject, myCollider.transform.position))
					{
						Debug.Log(this.Name + " has seen a weapon.");
						this.BloodPool = myCollider.transform;
						if (this.Yandere.WeaponManager.Weapons[this.ID].Blood.enabled)
						{
							this.WitnessedBloodyWeapon = true;
						}
						this.WitnessedWeapon = true;
						if (this.Club != ClubType.Delinquent && this.StudentManager.BloodReporter == null && !this.Police.Called && !this.LostTeacherTrust)
						{
							this.StudentManager.BloodLocation.position = this.BloodPool.position;
							this.StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, this.StudentManager.BloodLocation.position.y, base.transform.position.z));
							this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward * -1f);
							this.StudentManager.LowerBloodPosition();
							this.StudentManager.BloodReporter = this;
							this.ReportingBlood = true;
							this.DetermineBloodLocation();
						}
					}
				}
			}
			this.ID++;
		}
	}

	private void UpdateVision()
	{
		bool flag = false;
		if (this.Distracted)
		{
			flag = true;
			if (this.Yandere.Attacking || this.Yandere.Dragging || this.Yandere.Carrying)
			{
				flag = false;
			}
		}
		if (!flag)
		{
			bool flag2 = true;
			if (this.Yandere.Pursuer == null && this.Yandere.Pursuer == this)
			{
				flag2 = false;
			}
			if (!this.WitnessedMurder && !this.CheckingNote && !this.Shoving && !this.Struggling && flag2)
			{
				if (this.Police.Corpses > 0)
				{
					this.UpdateVisibleCorpses();
					if (this.VisibleCorpses.Count > 0)
					{
						if (!this.WitnessedCorpse)
						{
							if (this.Club == ClubType.Delinquent && this.Corpse.Student.Club == ClubType.Bully)
							{
								this.FoundEnemyCorpse = true;
							}
							if (this.Persona == PersonaType.Sleuth)
							{
								if (this.Sleuthing)
								{
									this.Persona = PersonaType.PhoneAddict;
									this.SmartPhone.SetActive(true);
								}
								else
								{
									this.Persona = PersonaType.SocialButterfly;
								}
							}
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							if (!this.Male)
							{
								this.CharacterAnimation["f02_smile_00"].weight = 0f;
							}
							this.AlarmTimer = 0f;
							this.Alarm = 200f;
							this.LastKnownCorpse = this.Corpse.AllColliders[0].transform.position;
							this.WitnessedBloodyWeapon = false;
							this.WitnessedBloodPool = false;
							this.WitnessedSomething = false;
							this.WitnessedWeapon = false;
							this.WitnessedCorpse = true;
							this.WitnessedLimb = false;
							if (this.ReturningMisplacedWeapon && this.ReturningMisplacedWeapon)
							{
								this.DropMisplacedWeapon();
							}
							this.InvestigatingBloodPool = false;
							this.Investigating = false;
							this.EatingSnack = false;
							this.Threatened = false;
							this.SentHome = false;
							this.Routine = false;
							if (this.Persona == PersonaType.Spiteful && ((this.Bullied && this.Corpse.Student.Club == ClubType.Bully) || this.Corpse.Student.Bullied))
							{
								this.ScaredAnim = this.EvilWitnessAnim;
								this.Persona = PersonaType.Evil;
							}
							this.ForgetRadio();
							if (this.Wet)
							{
								this.Persona = PersonaType.Loner;
							}
							if (this.Corpse.Disturbing)
							{
								if (this.Corpse.BurningAnimation)
								{
									this.WalkBackTimer = 5f;
									this.WalkBack = true;
									this.Hesitation = 0.5f;
								}
								if (this.Corpse.MurderSuicideAnimation)
								{
									this.WitnessedMindBrokenMurder = true;
									this.WalkBackTimer = 5f;
									this.WalkBack = true;
									this.Hesitation = 1f;
								}
								if (this.Corpse.ChokingAnimation)
								{
									this.WalkBackTimer = 0f;
									this.WalkBack = true;
									this.Hesitation = 0.6f;
								}
								if (this.Corpse.ElectrocutionAnimation)
								{
									this.WalkBackTimer = 0f;
									this.WalkBack = true;
									this.Hesitation = 0.5f;
								}
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
								this.Talk.enabled = false;
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
								this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, UnityEngine.Random.Range(1, 3), 3f);
								this.StudentManager.Portal.SetActive(false);
							}
							if (!this.Yandere.Egg)
							{
								this.WitnessMurder();
							}
						}
					}
				}
				if (this.VisibleCorpses.Count == 0 && !this.WitnessedCorpse)
				{
					if (this.WitnessCooldownTimer > 0f)
					{
						this.WitnessCooldownTimer = Mathf.MoveTowards(this.WitnessCooldownTimer, 0f, Time.deltaTime);
					}
					else if ((this.StudentID == this.StudentManager.CurrentID || (this.Persona == PersonaType.Strict && this.Fleeing)) && !this.Wet && !this.Guarding && !this.IgnoreBlood && !this.InvestigatingPossibleDeath && !this.Emetic && !this.Sedated && !this.Headache && !this.SentHome)
					{
						if (this.BloodPool == null && this.StudentManager.Police.LimbParent.childCount > 0)
						{
							this.UpdateVisibleLimbs();
						}
						if (this.BloodPool == null && (this.Police.BloodyWeapons > 0 || this.Yandere.WeaponManager.MisplacedWeapons > 0) && !this.InvestigatingPossibleLimb)
						{
							this.UpdateVisibleWeapons();
						}
						if (this.BloodPool == null && this.StudentManager.Police.BloodParent.childCount > 0 && !this.InvestigatingPossibleLimb)
						{
							this.UpdateVisibleBlood();
						}
						if (this.BloodPool != null && !this.WitnessedSomething)
						{
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							if (!this.Male)
							{
								this.CharacterAnimation["f02_smile_00"].weight = 0f;
							}
							this.AlarmTimer = 0f;
							this.Alarm = 200f;
							this.LastKnownBlood = this.BloodPool.transform.position;
							this.WitnessedSomething = true;
							this.Investigating = false;
							this.EatingSnack = false;
							this.Threatened = false;
							this.SentHome = false;
							this.Routine = false;
							this.ForgetRadio();
							this.StudentManager.UpdateMe(this.StudentID);
							if (this.Teacher)
							{
								this.AlarmTimer = 3f;
							}
							ParticleSystem.EmissionModule emission2 = this.Hearts.emission;
							if (this.Talking)
							{
								this.DialogueWheel.End();
								emission2.enabled = false;
								this.Pathfinding.canSearch = true;
								this.Pathfinding.canMove = true;
								this.Obstacle.enabled = false;
								this.Talk.enabled = false;
								this.Talking = false;
								this.Waiting = false;
								this.StudentManager.EnablePrompts();
							}
							if (this.Following)
							{
								emission2.enabled = false;
								this.Yandere.Followers--;
								this.Following = false;
							}
						}
					}
				}
				this.PreviousAlarm = this.Alarm;
				if (this.DistanceToPlayer < this.VisionDistance - this.ChameleonBonus)
				{
					if (!this.Talking && !this.Spraying && !this.SentHome)
					{
						if (!this.Yandere.Noticed)
						{
							bool flag3 = false;
							if (this.Guarding || this.Fleeing || this.InvestigatingBloodPool)
							{
								flag3 = true;
							}
							if ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious) || (!this.Teacher && this.StudentID > 1 && !this.Teacher && this.Yandere.PickUp != null && this.Yandere.PickUp.Suspicious) || (this.Teacher && this.Yandere.PickUp != null && this.Yandere.PickUp.Suspicious && !this.Yandere.PickUp.CleaningProduct) || (this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) || (this.Yandere.Sanity < 33.333f || this.Yandere.Pickpocketing || this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Dragging || this.Yandere.Lewd || this.Yandere.Carrying || this.Yandere.Medusa || this.Yandere.Poisoning || this.Yandere.Pickpocketing || this.Yandere.WeaponTimer > 0f || this.Yandere.MurderousActionTimer > 0f || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null)) || (this.Yandere.Laughing && this.Yandere.LaughIntensity > 15f) || (this.Yandere.Stance.Current == StanceType.Crouching || this.Yandere.Stance.Current == StanceType.Crawling || (this.Private && this.Yandere.Trespassing)) || (this.Private && this.Yandere.Eavesdropping) || (this.Teacher && !this.WitnessedCorpse && this.Yandere.Trespassing) || (this.Teacher && this.Yandere.Rummaging) || (this.Teacher && this.Yandere.TheftTimer > 0f) || (this.StudentID == 1 && this.Yandere.NearSenpai && !this.Yandere.Talking) || (this.Yandere.Eavesdropping && this.Private) || (!this.StudentManager.CombatMinigame.Practice && this.Yandere.DelinquentFighting && this.StudentManager.CombatMinigame.Path < 4) || (flag3 && this.Yandere.PickUp != null && this.Yandere.PickUp.Mop != null && this.Yandere.PickUp.Mop.Bloodiness > 0f) || (flag3 && this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null) || (this.Yandere.PickUp != null && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence))
							{
								if (this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition))
								{
									this.YandereVisible = true;
									if (this.Yandere.Attacking || this.Yandere.Struggling || (this.WitnessedCorpse && this.Yandere.NearBodies > 0 && this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) || (this.WitnessedCorpse && this.Yandere.NearBodies > 0 && this.Yandere.Armed) || (this.WitnessedCorpse && this.Yandere.NearBodies > 0 && this.Yandere.Sanity < 66.66666f) || (this.Yandere.Carrying || this.Yandere.Dragging || this.Yandere.MurderousActionTimer > 0f || (this.Guarding && this.Yandere.Bloodiness > 0f && !this.Yandere.Paint)) || (this.Guarding && this.Yandere.Armed) || (this.Guarding && this.Yandere.Sanity < 66.66666f) || (!this.StudentManager.CombatMinigame.Practice && this.Club == ClubType.Council && this.Yandere.DelinquentFighting && this.StudentManager.CombatMinigame.Path < 4 && !this.StudentManager.CombatMinigame.Practice) || (!this.StudentManager.CombatMinigame.Practice && this.Teacher && this.Yandere.DelinquentFighting && this.StudentManager.CombatMinigame.Path < 4 && !this.StudentManager.CombatMinigame.Practice) || (flag3 && this.Yandere.PickUp != null && this.Yandere.PickUp.Mop != null && this.Yandere.PickUp.Mop.Bloodiness > 0f) || (flag3 && this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null) || (this.Yandere.PickUp != null && this.Teacher && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence) || (this.StudentManager.Atmosphere < 0.33333f && this.Yandere.Bloodiness > 0f && this.Yandere.Armed))
									{
										Debug.Log(this.Name + " is aware that Yandere-chan is misbehaving.");
										if (this.Yandere.Hungry || !this.Yandere.Egg)
										{
											Debug.Log(this.Name + " has just witnessed a murder!");
											if (this.Yandere.PickUp != null)
											{
												if (flag3)
												{
													if (this.Yandere.PickUp.Mop != null)
													{
														if (this.Yandere.PickUp.Mop.Bloodiness > 0f)
														{
															Debug.Log("This character witnessed Yandere-chan trying to cover up a crime.");
															this.WitnessedCoverUp = true;
														}
													}
													else if (this.Yandere.PickUp.BodyPart != null)
													{
														Debug.Log("This character witnessed Yandere-chan trying to cover up a crime.");
														this.WitnessedCoverUp = true;
													}
												}
												if (this.Teacher && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence)
												{
													Debug.Log("This character witnessed Yandere-chan trying to cover up a crime.");
													this.WitnessedCoverUp = true;
												}
											}
											if (this.Persona == PersonaType.PhoneAddict && this.CrimeReported)
											{
												this.CrimeReported = false;
												this.Fleeing = false;
											}
											if (!this.Yandere.DelinquentFighting)
											{
												this.NoBreakUp = true;
											}
											this.WitnessMurder();
										}
									}
									else if (!this.Fleeing && (!this.Alarmed || this.CanStillNotice))
									{
										if (this.Teacher && (this.Yandere.Rummaging || this.Yandere.TheftTimer > 0f))
										{
											this.Alarm = 200f;
										}
										if (this.Yandere.WeaponTimer > 0f)
										{
											this.Alarm = 200f;
										}
										if (this.IgnoreTimer == 0f || this.CanStillNotice)
										{
											if (this.Teacher)
											{
												this.StudentManager.TutorialWindow.ShowTeacherMessage = true;
											}
											this.Alarm += Time.deltaTime * (100f / this.DistanceToPlayer) * this.Paranoia * this.Perception * 2f;
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
				if (this.Teacher && !this.Yandere.Medusa && this.Yandere.Egg)
				{
					this.Alarm = 0f;
				}
				if (this.Alarm > 100f)
				{
					this.BecomeAlarmed();
				}
			}
			else
			{
				this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
			}
		}
		else if (this.Distraction != null)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Distraction.position.x, base.transform.position.y, this.Distraction.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			if (this.Distractor != null)
			{
				if (this.Distractor.Club == ClubType.Cooking && this.Distractor.Actions[this.Distractor.Phase] == StudentActionType.ClubAction)
				{
					this.CharacterAnimation.CrossFade(this.PlateEatAnim);
					if ((double)this.CharacterAnimation[this.PlateEatAnim].time > 6.83333)
					{
						this.Fingerfood[this.Distractor.StudentID - 20].SetActive(false);
					}
					else if ((double)this.CharacterAnimation[this.PlateEatAnim].time > 2.66666)
					{
						this.Fingerfood[this.Distractor.StudentID - 20].SetActive(true);
					}
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
		}
	}

	private void BecomeAlarmed()
	{
		if (this.Yandere.Medusa && this.YandereVisible)
		{
			this.TurnToStone();
			return;
		}
		if (!this.Alarmed || this.DiscCheck)
		{
			if (this.Persona == PersonaType.PhoneAddict)
			{
				this.SmartPhone.SetActive(true);
			}
			this.Yandere.Alerts++;
			if (this.ReturningMisplacedWeapon)
			{
				this.DropMisplacedWeapon();
			}
			if (this.StudentID > 1)
			{
				this.ID = 0;
				while (this.ID < this.Outlines.Length)
				{
					if (this.Outlines[this.ID] != null)
					{
						this.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
					}
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
			this.CanStillNotice = false;
			this.Distracting = false;
			this.Distracted = false;
			this.DiscCheck = false;
			this.Reacted = false;
			this.Routine = false;
			this.Alarmed = true;
			this.ReadPhase = 0;
			if (!this.Male)
			{
				this.HorudaCollider.gameObject.SetActive(false);
			}
			if (this.YandereVisible && this.Yandere.Mask == null)
			{
				this.Witness = true;
			}
			this.EmptyHands();
			if (this.Club == ClubType.Cooking && this.Actions[this.Phase] == StudentActionType.ClubAction && this.ClubActivityPhase == 1 && !this.WitnessedCorpse)
			{
				this.ResumeDistracting = true;
			}
			this.SpeechLines.Stop();
			this.StopPairing();
			if (this.Witnessed != StudentWitnessType.Weapon && this.Witnessed != StudentWitnessType.Eavesdropping)
			{
				this.PreviouslyWitnessed = this.Witnessed;
			}
			if (this.DistanceToDestination < 5f && (this.Actions[this.Phase] == StudentActionType.Graffiti || this.Actions[this.Phase] == StudentActionType.Bully))
			{
				this.StudentManager.NoBully[this.BullyID] = true;
				this.KilledMood = true;
			}
			if (this.WitnessedCorpse && !this.WitnessedMurder)
			{
				this.Witnessed = StudentWitnessType.Corpse;
				this.EyeShrink = 0.9f;
			}
			else if (this.WitnessedLimb)
			{
				this.Witnessed = StudentWitnessType.SeveredLimb;
			}
			else if (this.WitnessedBloodyWeapon)
			{
				this.Witnessed = StudentWitnessType.BloodyWeapon;
			}
			else if (this.WitnessedBloodPool)
			{
				this.Witnessed = StudentWitnessType.BloodPool;
			}
			else if (this.WitnessedWeapon)
			{
				this.Witnessed = StudentWitnessType.DroppedWeapon;
			}
			if (this.YandereVisible)
			{
				if ((!this.Injured && this.Persona == PersonaType.Violent && this.Yandere.Armed && !this.WitnessedCorpse && !this.RespectEarned) || (this.Persona == PersonaType.Violent && this.Yandere.DelinquentFighting))
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentWeaponReaction, 0, 3f);
					this.ThreatDistance = this.DistanceToPlayer;
					this.CheerTimer = UnityEngine.Random.Range(1f, 2f);
					this.SmartPhone.SetActive(false);
					this.Threatened = true;
					this.ThreatPhase = 1;
					this.ForgetGiggle();
				}
				Debug.Log(this.Name + " saw Yandere-chan doing something bad.");
				if (this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Carrying || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart))
				{
					if (!this.Yandere.Egg)
					{
						this.WitnessMurder();
					}
				}
				else if (this.Witnessed != StudentWitnessType.Corpse)
				{
					this.DetermineWhatWasWitnessed();
				}
				if (this.Teacher && this.WitnessedCorpse)
				{
					this.Concern = 1;
				}
				if (this.StudentID == 1 && this.Yandere.Mask == null && !this.Yandere.Egg)
				{
					if (this.Concern == 5)
					{
						Debug.Log("Senpai noticed stalking or lewdness.");
						this.SenpaiNoticed();
						if (this.Witnessed == StudentWitnessType.Stalking || this.Witnessed == StudentWitnessType.Lewd)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
						}
						else
						{
							Debug.Log("Senpai entered his scared animation.");
							this.CharacterAnimation.CrossFade(this.ScaredAnim);
							this.CharacterAnimation["scaredFace_00"].weight = 1f;
						}
						this.CameraEffects.MurderWitnessed();
					}
					else
					{
						this.CharacterAnimation.CrossFade("suspicious_00");
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
						else if (!this.Yandere.Struggling && !this.StudentManager.PinningDown)
						{
							this.SenpaiNoticed();
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
				if (!this.Teacher && this.Club != ClubType.Delinquent && this.Witnessed == this.PreviouslyWitnessed)
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
				if (this.ToiletEvent != null && this.ToiletEvent.EventDay == DayOfWeek.Monday)
				{
					this.ToiletEvent.EndEvent();
				}
			}
			else if (!this.WitnessedCorpse)
			{
				if (this.Yandere.Caught)
				{
					if (this.Yandere.Mask == null)
					{
						if (this.Yandere.Pickpocketing)
						{
							this.Witnessed = StudentWitnessType.Pickpocketing;
							this.RepLoss += 10f;
						}
						else
						{
							this.Witnessed = StudentWitnessType.Theft;
						}
						this.RepDeduction = 0f;
						this.CalculateReputationPenalty();
						if (this.RepDeduction >= 0f)
						{
							this.RepLoss -= this.RepDeduction;
						}
						this.Reputation.PendingRep -= this.RepLoss * this.Paranoia;
						this.PendingRep -= this.RepLoss * this.Paranoia;
					}
				}
				else if (this.WitnessedLimb)
				{
					this.Witnessed = StudentWitnessType.SeveredLimb;
				}
				else if (this.WitnessedBloodyWeapon)
				{
					this.Witnessed = StudentWitnessType.BloodyWeapon;
				}
				else if (this.WitnessedBloodPool)
				{
					this.Witnessed = StudentWitnessType.BloodPool;
				}
				else if (this.WitnessedWeapon)
				{
					this.Witnessed = StudentWitnessType.DroppedWeapon;
				}
				else
				{
					Debug.Log(this.Name + " was alarmed by something, but didn't see what it was.");
					this.Witnessed = StudentWitnessType.None;
					this.DiscCheck = true;
					this.Witness = false;
				}
			}
			else
			{
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
			}
		}
	}

	private void UpdateDetectionMarker()
	{
		if (this.Alarm < 0f)
		{
			this.Alarm = 0f;
			if (this.Club == ClubType.Council && !this.Yandere.Noticed)
			{
				this.CanStillNotice = true;
			}
		}
		if (this.DetectionMarker != null)
		{
			if (this.Alarm > 0f)
			{
				if (!this.DetectionMarker.Tex.enabled)
				{
					this.DetectionMarker.Tex.enabled = true;
				}
				this.DetectionMarker.Tex.transform.localScale = new Vector3(this.DetectionMarker.Tex.transform.localScale.x, (this.Alarm > 100f) ? 1f : (this.Alarm / 100f), this.DetectionMarker.Tex.transform.localScale.z);
				this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, this.Alarm / 100f);
			}
			else if (this.DetectionMarker.Tex.color.a != 0f)
			{
				this.DetectionMarker.Tex.enabled = false;
				this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0f);
			}
		}
		else
		{
			this.SpawnDetectionMarker();
		}
	}

	private void UpdateTalkInput()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (!GameGlobals.EmptyDemon && (this.Alarm > 0f || this.AlarmTimer > 0f || this.Yandere.Armed || this.Yandere.Shoved || this.Waiting || this.InEvent || this.SentHome || this.Threatened || (this.Distracted && !this.Drownable) || this.StudentID == 1) && !this.Slave && !this.BadTime && !this.Yandere.Gazing && !this.FightingSlave)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				bool flag = false;
				if (this.StudentID < 86 && this.Armband.activeInHierarchy && (this.Actions[this.Phase] == StudentActionType.ClubAction || this.Actions[this.Phase] == StudentActionType.SitAndSocialize || this.Actions[this.Phase] == StudentActionType.Socializing || this.Actions[this.Phase] == StudentActionType.Sleuth || this.Actions[this.Phase] == StudentActionType.Lyrics || this.Actions[this.Phase] == StudentActionType.Patrol || this.Actions[this.Phase] == StudentActionType.SitAndEatBento) && (this.DistanceToDestination < 1f || (base.transform.position.y > this.StudentManager.ClubZones[(int)this.Club].position.y - 1f && base.transform.position.y < this.StudentManager.ClubZones[(int)this.Club].position.y + 1f && Vector3.Distance(base.transform.position, this.StudentManager.ClubZones[(int)this.Club].position) < this.ClubThreshold) || Vector3.Distance(base.transform.position, this.StudentManager.DramaSpots[1].position) < 12f))
				{
					flag = true;
					this.Warned = false;
				}
				if (this.StudentID == 76 && GameGlobals.BlondeHair && this.Reputation.Reputation < -33.33333f && this.Yandere.Persona == YanderePersonaType.Tough && PlayerGlobals.GetStudentFriend(76) && PlayerGlobals.GetStudentFriend(77) && PlayerGlobals.GetStudentFriend(78) && PlayerGlobals.GetStudentFriend(79) && PlayerGlobals.GetStudentFriend(80))
				{
					flag = true;
					this.Warned = false;
				}
				if (this.StudentManager.Pose)
				{
					this.MyController.enabled = false;
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
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
				else if (this.StudentManager.Six)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
					gameObject.GetComponent<AlarmDiscScript>().Originator = this;
					AudioSource.PlayClipAtPoint(this.Yandere.SixTakedown, base.transform.position);
					AudioSource.PlayClipAtPoint(this.Yandere.Snarls[UnityEngine.Random.Range(0, this.Yandere.Snarls.Length)], base.transform.position);
					this.Yandere.CharacterAnimation.CrossFade("f02_sixEat_00");
					this.Yandere.TargetStudent = this;
					this.Yandere.FollowHips = true;
					this.Yandere.Attacking = true;
					this.Yandere.CanMove = false;
					this.Yandere.Eating = true;
					this.CharacterAnimation.CrossFade(this.EatVictimAnim);
					this.Pathfinding.enabled = false;
					this.Routine = false;
					this.Dying = true;
					this.Eaten = true;
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, base.transform.position, Quaternion.identity);
					this.Yandere.SixTarget = gameObject2.transform;
					this.Yandere.SixTarget.LookAt(this.Yandere.transform.position);
					this.Yandere.SixTarget.Translate(this.Yandere.SixTarget.forward);
				}
				else if (this.Yandere.SpiderGrow)
				{
					if (!this.Eaten && !this.Cosmetic.Empty)
					{
						AudioSource.PlayClipAtPoint(this.Yandere.SixTakedown, base.transform.position);
						AudioSource.PlayClipAtPoint(this.Yandere.Snarls[UnityEngine.Random.Range(0, this.Yandere.Snarls.Length)], base.transform.position);
						GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.Yandere.EmptyHusk, base.transform.position + base.transform.forward * 0.5f, Quaternion.identity);
						gameObject3.GetComponent<EmptyHuskScript>().TargetStudent = this;
						gameObject3.transform.LookAt(base.transform.position);
						this.CharacterAnimation.CrossFade(this.EatVictimAnim);
						this.Pathfinding.enabled = false;
						this.Distracted = false;
						this.Routine = false;
						this.Dying = true;
						this.Eaten = true;
						if (this.Investigating)
						{
							this.StopInvestigating();
						}
						if (this.Following)
						{
							this.Yandere.Followers--;
							this.Following = false;
						}
						GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, base.transform.position, Quaternion.identity);
					}
				}
				else if (this.StudentManager.Gaze)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_gazerPoint_00");
					this.Yandere.GazerEyes.Attacking = true;
					this.Yandere.TargetStudent = this;
					this.Yandere.GazeAttacking = true;
					this.Yandere.CanMove = false;
					this.Routine = false;
				}
				else if (this.Slave)
				{
					this.Yandere.TargetStudent = this;
					this.Yandere.PauseScreen.StudentInfoMenu.Targeting = true;
					this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
					this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
					this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
					this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
					base.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
					this.Yandere.PauseScreen.MainMenu.SetActive(false);
					this.Yandere.PauseScreen.Panel.enabled = true;
					this.Yandere.PauseScreen.Sideways = true;
					this.Yandere.PauseScreen.Show = true;
					Time.timeScale = 0.0001f;
					this.Yandere.PromptBar.ClearButtons();
					this.Yandere.PromptBar.Label[1].text = "Cancel";
					this.Yandere.PromptBar.UpdateButtons();
					this.Yandere.PromptBar.Show = true;
				}
				else if (this.FightingSlave)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_subtleStab_00");
					this.Yandere.SubtleStabbing = true;
					this.Yandere.TargetStudent = this;
					this.Yandere.CanMove = false;
				}
				else if (this.Following)
				{
					this.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
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
					if (!this.Male)
					{
						this.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 5, 3f);
					}
					else
					{
						this.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 5, 3f);
					}
					this.Prompt.Label[0].text = "     Talk";
					this.Prompt.Circle[0].fillAmount = 1f;
					this.Yandere.TargetStudent = this;
					this.Yandere.Attacking = true;
					this.Yandere.RoofPush = true;
					this.Yandere.CanMove = false;
					this.Yandere.EmptyHands();
					this.Distracted = true;
					this.Routine = false;
					this.Pushed = true;
					this.CharacterAnimation.CrossFade(this.PushedAnim);
				}
				else if (this.Drownable)
				{
					Debug.Log("Just began to drown someone.");
					if (this.VomitDoor != null)
					{
						this.VomitDoor.Prompt.enabled = true;
						this.VomitDoor.enabled = true;
					}
					this.Yandere.EmptyHands();
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Prompt.Circle[0].fillAmount = 1f;
					this.VomitEmitter.gameObject.SetActive(false);
					this.Police.DrownedStudentName = this.Name;
					this.MyController.enabled = false;
					this.VomitEmitter.gameObject.SetActive(false);
					this.SmartPhone.SetActive(false);
					this.Police.DrownVictims++;
					this.Distracted = true;
					this.Drownable = false;
					this.Routine = false;
					this.Drowned = true;
					this.Subtitle.UpdateLabel(SubtitleType.DrownReaction, 0, 3f);
					this.Yandere.TargetStudent = this;
					this.Yandere.Attacking = true;
					this.Yandere.CanMove = false;
					this.Yandere.Drown = true;
					this.Yandere.DrownAnim = "f02_fountainDrownA_00";
					if (this.Male)
					{
						if (Vector3.Distance(base.transform.position, this.StudentManager.transform.position) < 5f)
						{
							this.DrownAnim = "fountainDrown_00_B";
						}
						else
						{
							this.DrownAnim = "toiletDrown_00_B";
						}
					}
					else if (Vector3.Distance(base.transform.position, this.StudentManager.transform.position) < 5f)
					{
						this.DrownAnim = "f02_fountainDrownB_00";
					}
					else
					{
						this.DrownAnim = "f02_toiletDrownB_00";
					}
					this.CharacterAnimation.CrossFade(this.DrownAnim);
				}
				else if (this.Clock.Period == 2 || this.Clock.Period == 4 || this.CurrentDestination == this.Seat)
				{
					this.Subtitle.UpdateLabel(SubtitleType.ClassApology, 0, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
				}
				else if (this.InEvent || !this.CanTalk || this.GoAway || this.Fleeing || (this.Meeting && !this.Drownable) || (this.Wet || this.TurnOffRadio || this.InvestigatingBloodPool || (this.MyPlate != null && this.MyPlate.parent == this.RightHand)) || this.ReturningMisplacedWeapon || this.FollowTarget != null || this.Actions[this.Phase] == StudentActionType.Bully || this.Actions[this.Phase] == StudentActionType.Graffiti)
				{
					this.Subtitle.UpdateLabel(SubtitleType.EventApology, 1, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
				}
				else if (this.Clock.Period == 3 && this.BusyAtLunch)
				{
					this.Subtitle.UpdateLabel(SubtitleType.SadApology, 1, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
				}
				else if (this.Warned)
				{
					Debug.Log("This character refuses to speak to Yandere-chan because of a grudge.");
					this.Subtitle.UpdateLabel(SubtitleType.GrudgeRefusal, 0, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
				}
				else if (this.Ignoring)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PhotoAnnoyance, 0, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
				}
				else
				{
					bool flag2 = false;
					if (this.Yandere.Bloodiness > 0f && !this.Yandere.Paint)
					{
						flag2 = true;
					}
					if (!this.Witness && flag2)
					{
						this.Prompt.Circle[0].fillAmount = 1f;
						this.YandereVisible = true;
						this.Alarm = 200f;
					}
					else
					{
						this.SpeechLines.Stop();
						this.Yandere.TargetStudent = this;
						if (!this.Grudge)
						{
							this.ClubManager.CheckGrudge(this.Club);
							if (ClubGlobals.GetClubKicked(this.Club) && flag)
							{
								Debug.Log("Here, specifically.");
								this.Interaction = StudentInteractionType.ClubGrudge;
								this.TalkTimer = 5f;
								this.Warned = true;
							}
							else if (ClubGlobals.Club == this.Club && flag && this.ClubManager.ClubGrudge)
							{
								this.Interaction = StudentInteractionType.ClubKick;
								ClubGlobals.SetClubKicked(this.Club, true);
								this.TalkTimer = 5f;
								this.Warned = true;
							}
							else if (this.Prompt.Label[0].text == "     Feed")
							{
								this.Interaction = StudentInteractionType.Feeding;
								this.TalkTimer = 10f;
							}
							else if (this.Prompt.Label[0].text == "     Give Snack")
							{
								this.Yandere.Interaction = YandereInteractionType.GivingSnack;
								this.Yandere.TalkTimer = 3f;
								this.Interaction = StudentInteractionType.Idle;
							}
							else if (this.Prompt.Label[0].text == "     Ask For Help")
							{
								this.Yandere.Interaction = YandereInteractionType.AskingForHelp;
								this.Yandere.TalkTimer = 5f;
								this.Interaction = StudentInteractionType.Idle;
							}
							else
							{
								this.DistanceToDestination = Vector3.Distance(base.transform.position, this.Destinations[this.Phase].position);
								if (this.Sleuthing)
								{
									this.DistanceToDestination = Vector3.Distance(base.transform.position, this.SleuthTarget.position);
								}
								if (flag)
								{
									int num;
									if (this.Sleuthing)
									{
										num = 5;
									}
									else
									{
										num = 0;
									}
									if (GameGlobals.EmptyDemon)
									{
										num = (int)(this.Club * (ClubType)(-1));
									}
									this.Subtitle.UpdateLabel(SubtitleType.ClubGreeting, (int)(this.Club + num), 4f);
									this.DialogueWheel.ClubLeader = true;
								}
								else
								{
									this.Subtitle.UpdateLabel(SubtitleType.Greeting, 0, 3f);
								}
								if (this.Club != ClubType.Council && this.Club != ClubType.Delinquent && ((this.Male && PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 0) || PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 4))
								{
									ParticleSystem.EmissionModule emission = this.Hearts.emission;
									emission.rateOverTime = (float)(PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus);
									emission.enabled = true;
									this.Hearts.Play();
								}
								this.StudentManager.DisablePrompts();
								this.StudentManager.VolumeDown();
								this.DialogueWheel.HideShadows();
								this.DialogueWheel.Show = true;
								this.DialogueWheel.Panel.enabled = true;
								this.TalkTimer = 0f;
								if (!ConversationGlobals.GetTopicDiscovered(20))
								{
									this.Yandere.NotificationManager.TopicName = "Socializing";
									this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
									ConversationGlobals.SetTopicDiscovered(20, true);
								}
								if (!ConversationGlobals.GetTopicLearnedByStudent(20, this.StudentID))
								{
									this.Yandere.NotificationManager.TopicName = "Socializing";
									this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
									ConversationGlobals.SetTopicLearnedByStudent(20, this.StudentID, true);
								}
								if (!ConversationGlobals.GetTopicDiscovered(21))
								{
									this.Yandere.NotificationManager.TopicName = "Solitude";
									this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
									ConversationGlobals.SetTopicDiscovered(21, true);
								}
								if (!ConversationGlobals.GetTopicLearnedByStudent(21, this.StudentID))
								{
									this.Yandere.NotificationManager.TopicName = "Solitude";
									this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
									ConversationGlobals.SetTopicLearnedByStudent(21, this.StudentID, true);
								}
							}
						}
						else if (flag)
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
						this.Yandere.ShoulderCamera.OverShoulder = true;
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
						this.Talk.enabled = true;
						this.Reacted = false;
						this.Routine = false;
						this.Talking = true;
						this.ReadPhase = 0;
						this.EmptyHands();
						bool flag3 = false;
						if (this.CurrentAction == StudentActionType.Sunbathe && this.SunbathePhase > 2)
						{
							this.SunbathePhase = 2;
							flag3 = true;
						}
						if (this.Sleuthing)
						{
							if (!this.Scrubber.activeInHierarchy)
							{
								this.SmartPhone.SetActive(true);
							}
							else
							{
								this.SmartPhone.SetActive(false);
							}
						}
						else if (this.Persona != PersonaType.PhoneAddict)
						{
							this.SmartPhone.SetActive(false);
						}
						else if (!this.Scrubber.activeInHierarchy && !flag3)
						{
							this.SmartPhone.SetActive(true);
						}
						this.ChalkDust.Stop();
						this.StopPairing();
					}
				}
			}
		}
		if (this.Prompt.Circle[2].fillAmount == 0f || (this.Yandere.Sanity < 33.33333f && !this.Prompt.HideButton[2] && this.Prompt.InSight && this.Club != ClubType.Council && !this.Struggling))
		{
			if (this.StudentManager.OriginalUniforms + this.StudentManager.NewUniforms > 1)
			{
				if (this.ClubActivityPhase < 16)
				{
					float f = Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position);
					this.Yandere.AttackManager.Stealth = (Mathf.Abs(f) <= 45f);
					bool flag4 = false;
					if (this.Club == ClubType.Delinquent && !this.Injured && !this.Yandere.AttackManager.Stealth && !this.RespectEarned)
					{
						Debug.Log(this.Name + " knows that Yandere-chan is tyring to attack him.");
						flag4 = true;
						this.Fleeing = false;
						this.Patience = 1;
						this.Shove();
						this.SpawnAlarmDisc();
					}
					if (!flag4 && !this.Yandere.NearSenpai && !this.Yandere.Attacking && this.Yandere.Stance.Current != StanceType.Crouching)
					{
						if (this.Yandere.EquippedWeapon.Flaming || this.Yandere.CyborgParts[1].activeInHierarchy)
						{
							this.Yandere.SanityBased = false;
						}
						if (this.Strength == 9)
						{
							if (!this.Yandere.AttackManager.Stealth)
							{
								this.CharacterAnimation.CrossFade("f02_dramaticFrontal_00");
							}
							else
							{
								this.CharacterAnimation.CrossFade("f02_dramaticStealth_00");
							}
							this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
							this.Yandere.CanMove = false;
							this.DramaticCamera.enabled = true;
							this.DramaticCamera.rect = new Rect(0f, 0.5f, 1f, 0f);
							this.DramaticCamera.gameObject.SetActive(true);
							this.DramaticCamera.gameObject.GetComponent<AudioSource>().Play();
							this.DramaticReaction = true;
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.Routine = false;
						}
						else
						{
							this.AttackReaction();
						}
					}
				}
			}
			else if (!this.Yandere.ClothingWarning)
			{
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Clothing);
				this.StudentManager.TutorialWindow.ShowClothingMessage = true;
				this.Yandere.ClothingWarning = true;
			}
		}
	}

	private void UpdateDying()
	{
		this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
		if (this.Attacked)
		{
			if (this.Follower != null)
			{
				this.Follower.DistractionSpot = this.Yandere.transform.position;
				this.Follower.BecomeAlarmed();
			}
			if (!this.Teacher)
			{
				if (this.Strength == 9)
				{
					if (!this.StudentManager.Stop)
					{
						this.StudentManager.StopMoving();
						this.Yandere.RPGCamera.enabled = false;
						this.SmartPhone.SetActive(false);
						this.Police.Show = false;
					}
					Debug.Log("The mysterious obstacle is counter-attacking!");
					this.CharacterAnimation.CrossFade("f02_moCounterB_00");
					if (!this.WitnessedMurder && this.CharacterAnimation["f02_moLipSync_00"].weight == 0f)
					{
						this.CharacterAnimation["f02_moLipSync_00"].weight = 1f;
						this.CharacterAnimation["f02_moLipSync_00"].time = 0f;
						this.CharacterAnimation.Play("f02_moLipSync_00");
					}
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
				}
				else
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
							Debug.Log("Reloaded from save, calling BecomeRagdoll()");
							this.BecomeRagdoll();
						}
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
					this.SmartPhone.SetActive(false);
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
		this.SplashTimer += Time.deltaTime;
		if (this.SplashTimer > 3f && this.SplashTimer < 100f)
		{
			this.DrowningSplashes.Play();
			this.SplashTimer += 100f;
		}
		this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
		this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
		if (this.CharacterAnimation[this.DrownAnim].time >= this.CharacterAnimation[this.DrownAnim].length)
		{
			this.BecomeRagdoll();
		}
	}

	private void UpdateWitnessedMurder()
	{
		if (this.Threatened)
		{
			this.UpdateAlarmed();
		}
		else if (!this.Fleeing && !this.Shoving)
		{
			if (this.StudentID > 1 && this.Persona != PersonaType.Evil)
			{
				this.EyeShrink += Time.deltaTime * 0.2f;
			}
			if (this.Yandere.TargetStudent != null && this.LovedOneIsTargeted(this.Yandere.TargetStudent.StudentID))
			{
				this.Strength = 5;
				this.Persona = PersonaType.Heroic;
				this.SmartPhone.SetActive(false);
				this.SprintAnim = this.OriginalSprintAnim;
			}
			if ((this.Club != ClubType.Delinquent || (this.Club == ClubType.Delinquent && this.Injured)) && this.Yandere.TargetStudent == null && this.LovedOneIsTargeted(this.Yandere.NearestCorpseID))
			{
				this.Strength = 5;
				if (this.Injured)
				{
					this.Strength = 1;
				}
				this.Persona = PersonaType.Heroic;
			}
			if (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null && this.Yandere.PickUp.BodyPart.Type == 1 && this.LovedOneIsTargeted(this.Yandere.PickUp.BodyPart.StudentID))
			{
				this.Strength = 5;
				this.Persona = PersonaType.Heroic;
				this.SmartPhone.SetActive(false);
				this.SprintAnim = this.OriginalSprintAnim;
			}
			if (this.Persona != PersonaType.PhoneAddict)
			{
				this.CharacterAnimation.CrossFade(this.ScaredAnim);
			}
			else if (!this.Attacked)
			{
				this.PhoneAddictCameraUpdate();
			}
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.position.x, base.transform.position.y, this.Yandere.Hips.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			if (!this.Yandere.Struggling)
			{
				if (this.Persona != PersonaType.Heroic && this.Persona != PersonaType.Dangerous && this.Persona != PersonaType.Violent)
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
					if (this.StudentID == 1)
					{
						Debug.Log("Senpai saw a mask.");
						this.Persona = PersonaType.Heroic;
						this.PersonaReaction();
					}
					if (!this.Teacher)
					{
						if (this.Persona != PersonaType.Evil)
						{
							if (this.Club == ClubType.Delinquent)
							{
								this.SmartPhone.SetActive(false);
							}
							else if (this.StudentID == 10)
							{
								this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 1, 3f);
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.MurderReaction, 1, 3f);
							}
						}
					}
					else
					{
						if (this.WitnessedCoverUp)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherCoverUpHostile, 1, 5f);
						}
						else
						{
							this.DetermineWhatWasWitnessed();
							this.DetermineTeacherSubtitle();
						}
						this.StudentManager.Portal.SetActive(false);
					}
				}
				else
				{
					Debug.Log("Senpai witnessed murder, and entered a specific murder reaction animation.");
					this.MurderReaction = UnityEngine.Random.Range(1, 6);
					this.CharacterAnimation.CrossFade("senpaiMurderReaction_0" + this.MurderReaction);
					this.GameOverCause = GameOverType.Murder;
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
		if (!this.Threatened)
		{
			if (this.Yandere.Medusa && this.YandereVisible)
			{
				this.TurnToStone();
				return;
			}
			if (this.Persona != PersonaType.PhoneAddict && !this.Sleuthing)
			{
				this.SmartPhone.SetActive(false);
			}
			this.OccultBook.SetActive(false);
			this.Pen.SetActive(false);
			this.SpeechLines.Stop();
			this.ReadPhase = 0;
			if (this.WitnessedCorpse)
			{
				if (!this.WalkBack)
				{
					if (this.StudentID == 1)
					{
					}
					if (this.Persona != PersonaType.PhoneAddict)
					{
						this.CharacterAnimation.CrossFade(this.ScaredAnim);
					}
					else if (!this.Attacked)
					{
						this.PhoneAddictCameraUpdate();
					}
				}
				else
				{
					Debug.Log(this.Name + " is walking backwards");
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.MyController.Move(base.transform.forward * (-0.5f * Time.deltaTime));
					this.CharacterAnimation.CrossFade(this.WalkBackAnim);
					this.WalkBackTimer -= Time.deltaTime;
					if (this.WalkBackTimer <= 0f)
					{
						this.WalkBack = false;
					}
				}
			}
			else if (!this.WitnessedLimb)
			{
				if (!this.WitnessedBloodyWeapon)
				{
					if (!this.WitnessedBloodPool)
					{
						if (!this.WitnessedWeapon)
						{
							if (this.StudentID > 1)
							{
								if (this.Witness)
								{
									this.CharacterAnimation.CrossFade(this.LeanAnim);
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
									if (this.FocusOnYandere)
									{
										if (this.DistanceToPlayer < 1f && !this.Injured)
										{
											this.AlarmTimer = 0f;
											if (this.Club == ClubType.Council || (this.Club == ClubType.Delinquent && !this.Injured))
											{
												this.ThreatTimer += Time.deltaTime;
												if (this.ThreatTimer > 5f && !this.Yandere.Struggling && !this.Yandere.DelinquentFighting && this.Prompt.InSight)
												{
													this.ThreatTimer = 0f;
													this.Shove();
												}
											}
										}
										this.DistractionSpot = new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z);
									}
								}
							}
						}
					}
				}
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
			else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
			{
				if (this.BloodPool != null)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.BloodPool.transform.position.x, base.transform.position.y, this.BloodPool.transform.position.z) - base.transform.position);
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
				if (!this.FocusOnYandere)
				{
					this.targetRotation = Quaternion.LookRotation(this.DistractionSpot - base.transform.position);
				}
				else
				{
					this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
				}
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			}
			if (!this.Fleeing && !this.Yandere.DelinquentFighting)
			{
				this.AlarmTimer += Time.deltaTime * (1f - this.Hesitation);
			}
			if (!this.CanStillNotice)
			{
				this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia) * 5f;
			}
			if (this.AlarmTimer > 5f)
			{
				this.EndAlarm();
			}
			else if (this.AlarmTimer > 1f && !this.Reacted)
			{
				if (this.Teacher)
				{
					if (!this.WitnessedCorpse)
					{
						Debug.Log("A teacher's reaction is now being determined.");
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
							this.GameOverCause = GameOverType.Insanity;
						}
						else if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponReaction, 1, 6f);
							this.GameOverCause = GameOverType.Weapon;
						}
						else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
							this.GameOverCause = GameOverType.Insanity;
						}
						else if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
							this.GameOverCause = GameOverType.Insanity;
						}
						else if (this.Witnessed == StudentWitnessType.Weapon)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponReaction, 1, 6f);
							this.GameOverCause = GameOverType.Weapon;
						}
						else if (this.Witnessed == StudentWitnessType.Blood)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherBloodReaction, 1, 6f);
							this.GameOverCause = GameOverType.Blood;
						}
						else if (this.Witnessed == StudentWitnessType.Insanity || this.Witnessed == StudentWitnessType.Poisoning)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
							this.GameOverCause = GameOverType.Insanity;
						}
						else if (this.Witnessed == StudentWitnessType.Lewd)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherLewdReaction, 1, 6f);
							this.GameOverCause = GameOverType.Lewd;
						}
						else if (this.Witnessed == StudentWitnessType.Violence)
						{
							Debug.Log("A teacher witnessed violence.");
							this.Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, 5, 5f);
							this.GameOverCause = GameOverType.Violence;
							this.Concern = 5;
						}
						else if (this.Witnessed == StudentWitnessType.Trespassing)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, this.Concern, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.Theft || this.Witnessed == StudentWitnessType.Pickpocketing)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherTheftReaction, 1, 6f);
						}
						else if (this.Witnessed == StudentWitnessType.CleaningItem)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
							this.GameOverCause = GameOverType.Insanity;
						}
						if (this.Club == ClubType.Council)
						{
							UnityEngine.Object.Destroy(this.Subtitle.CurrentClip);
							this.Subtitle.UpdateLabel(SubtitleType.CouncilToCounselor, this.ClubMemberID, 5f);
						}
					}
					else
					{
						Debug.Log("A teacher found a corpse.");
						this.Concern = 1;
						this.DetermineWhatWasWitnessed();
						this.DetermineTeacherSubtitle();
						if (this.WitnessedMurder)
						{
							this.MurdersWitnessed++;
							if (!this.Yandere.Chased)
							{
								Debug.Log("A teacher has reached ChaseYandere() through UpdateAlarm().");
								this.ChaseYandere();
							}
						}
					}
					if (!this.Guarding && !this.Chasing && ((this.YandereVisible && this.Concern == 5) || this.Yandere.Noticed))
					{
						Debug.Log("Yandere-chan is getting sent to the guidance counselor.");
						if (this.Witnessed == StudentWitnessType.Theft && this.Yandere.StolenObject != null)
						{
							this.Yandere.StolenObject.SetActive(true);
							this.Yandere.StolenObject = null;
							this.Yandere.Inventory.IDCard = false;
						}
						this.StudentManager.CombatMinigame.Stop();
						this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
						this.Yandere.ShoulderCamera.enabled = true;
						this.Yandere.ShoulderCamera.Noticed = true;
						this.Yandere.RPGCamera.enabled = false;
						this.Stop = true;
					}
				}
				else if (this.StudentID > 1 || this.Yandere.Mask != null)
				{
					if (this.StudentID == 41)
					{
						this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
					}
					else if (this.RepeatReaction)
					{
						this.Subtitle.UpdateLabel(SubtitleType.RepeatReaction, 1, 3f);
						this.RepeatReaction = false;
					}
					else if (this.Club != ClubType.Delinquent)
					{
						if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodAndInsanityReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
						{
							this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.WeaponAndInsanityReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.BloodAndInsanityReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.Weapon)
						{
							this.Subtitle.StudentID = this.StudentID;
							this.Subtitle.UpdateLabel(SubtitleType.WeaponReaction, this.WeaponWitnessed, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.Blood)
						{
							if (!this.Bloody)
							{
								this.Subtitle.UpdateLabel(SubtitleType.BloodReaction, 1, 3f);
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.WetBloodReaction, 1, 3f);
								this.Witnessed = StudentWitnessType.None;
								this.Witness = false;
							}
						}
						else if (this.Witnessed == StudentWitnessType.Insanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.InsanityReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.Lewd)
						{
							this.Subtitle.UpdateLabel(SubtitleType.LewdReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.CleaningItem)
						{
							this.Subtitle.UpdateLabel(SubtitleType.SuspiciousReaction, 0, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.Suspicious)
						{
							this.Subtitle.UpdateLabel(SubtitleType.SuspiciousReaction, 1, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.Corpse)
						{
							if (this.Club == ClubType.Council)
							{
								if (this.StudentID == 86)
								{
									this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 1, 5f);
								}
								else if (this.StudentID == 87)
								{
									this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 2, 5f);
								}
								else if (this.StudentID == 88)
								{
									this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 3, 5f);
								}
								else if (this.StudentID == 89)
								{
									this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 4, 5f);
								}
							}
							else if (this.Persona == PersonaType.Evil)
							{
								this.Subtitle.UpdateLabel(SubtitleType.EvilCorpseReaction, 1, 5f);
							}
							else if (!this.Corpse.Choking)
							{
								this.Subtitle.UpdateLabel(SubtitleType.CorpseReaction, 0, 5f);
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.CorpseReaction, 1, 5f);
							}
						}
						else if (this.Witnessed == StudentWitnessType.Interruption)
						{
							this.Subtitle.UpdateLabel(SubtitleType.InterruptionReaction, 1, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.Eavesdropping)
						{
							if (this.StudentID == this.StudentManager.RivalID)
							{
								this.Subtitle.UpdateLabel(SubtitleType.RivalEavesdropReaction, 1, 9f);
								this.Hesitation = 0.6f;
							}
							else if (this.EventInterrupted)
							{
								this.Subtitle.UpdateLabel(SubtitleType.EventEavesdropReaction, 1, 5f);
								this.EventInterrupted = false;
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.EavesdropReaction, 1, 5f);
							}
						}
						else if (this.Witnessed == StudentWitnessType.Pickpocketing)
						{
							this.Subtitle.UpdateLabel(this.PickpocketSubtitleType, 1, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.Violence)
						{
							this.Subtitle.UpdateLabel(SubtitleType.ViolenceReaction, 5, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.Poisoning)
						{
							if (this.Yandere.TargetBento.StudentID != this.StudentID)
							{
								this.Subtitle.UpdateLabel(SubtitleType.PoisonReaction, 1, 5f);
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.PoisonReaction, 2, 5f);
								this.Phase++;
								this.Pathfinding.target = this.Destinations[this.Phase];
								this.CurrentDestination = this.Destinations[this.Phase];
							}
						}
						else if (this.Witnessed == StudentWitnessType.SeveredLimb)
						{
							this.Subtitle.UpdateLabel(SubtitleType.LimbReaction, 0, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.BloodyWeapon)
						{
							this.Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 0, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.DroppedWeapon)
						{
							this.Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 0, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.BloodPool)
						{
							this.Subtitle.UpdateLabel(SubtitleType.BloodPoolReaction, 0, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.HoldingBloodyClothing)
						{
							this.Subtitle.UpdateLabel(SubtitleType.HoldingBloodyClothingReaction, 0, 5f);
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.HmmReaction, 1, 3f);
						}
					}
					else if (this.Witnessed == StudentWitnessType.None)
					{
						this.Subtitle.Speaker = this;
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentHmm, 0, 5f);
					}
					else if (this.Witnessed == StudentWitnessType.Corpse)
					{
						if (this.FoundEnemyCorpse)
						{
							this.Subtitle.UpdateLabel(SubtitleType.EvilDelinquentCorpseReaction, 1, 5f);
						}
						else if (this.Corpse.Student.Club == ClubType.Delinquent)
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentFriendCorpseReaction, 1, 5f);
							this.FoundFriendCorpse = true;
						}
						else
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentCorpseReaction, 1, 5f);
						}
					}
					else if (this.Witnessed == StudentWitnessType.Weapon && !this.Injured)
					{
						this.Subtitle.Speaker = this;
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentWeaponReaction, 0, 3f);
					}
					else
					{
						this.Subtitle.Speaker = this;
						if (!this.WitnessedWeapon)
						{
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentReaction, 0, 5f);
							Debug.Log("Calling this subtitle.");
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.LimbReaction, 0, 5f);
						}
					}
				}
				else if (!this.Yandere.Egg)
				{
					Debug.Log("We are now determining what Senpai saw...");
					if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
					{
						this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						this.GameOverCause = GameOverType.Insanity;
					}
					else if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
					{
						this.CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
						this.GameOverCause = GameOverType.Weapon;
					}
					else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
					{
						this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						this.GameOverCause = GameOverType.Insanity;
					}
					else if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
					{
						this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						this.GameOverCause = GameOverType.Insanity;
					}
					else if (this.Witnessed == StudentWitnessType.Weapon)
					{
						this.CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
						this.GameOverCause = GameOverType.Weapon;
					}
					else if (this.Witnessed == StudentWitnessType.Blood)
					{
						this.CharacterAnimation.CrossFade("senpaiBloodReaction_00");
						this.GameOverCause = GameOverType.Blood;
					}
					else if (this.Witnessed == StudentWitnessType.Insanity)
					{
						this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						this.GameOverCause = GameOverType.Insanity;
					}
					else if (this.Witnessed == StudentWitnessType.Lewd)
					{
						this.CharacterAnimation.CrossFade("senpaiLewdReaction_00");
						this.GameOverCause = GameOverType.Lewd;
					}
					else if (this.Witnessed == StudentWitnessType.Stalking)
					{
						if (this.Concern < 5)
						{
							this.Subtitle.UpdateLabel(SubtitleType.SenpaiStalkingReaction, this.Concern, 4.5f);
						}
						else
						{
							this.CharacterAnimation.CrossFade("senpaiCreepyReaction_00");
							this.GameOverCause = GameOverType.Stalking;
						}
						this.Witnessed = StudentWitnessType.None;
					}
					else if (this.Witnessed == StudentWitnessType.Corpse)
					{
						this.Subtitle.UpdateLabel(SubtitleType.SenpaiCorpseReaction, 1, 5f);
					}
					else if (this.Witnessed == StudentWitnessType.Violence)
					{
						this.CharacterAnimation.CrossFade("senpaiFightReaction_00");
						this.GameOverCause = GameOverType.Violence;
						this.Concern = 5;
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
			if (this.Club == ClubType.Council && this.DistanceToPlayer < 1.1f && (this.Yandere.Armed || this.Yandere.Carrying || this.Yandere.Dragging) && this.Prompt.InSight)
			{
				this.Spray();
			}
		}
		else
		{
			this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
			if (this.StudentManager.CombatMinigame.Delinquent == null || this.StudentManager.CombatMinigame.Delinquent == this)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
			}
			else
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.CombatMinigame.Midpoint.position.x, base.transform.position.y, this.StudentManager.CombatMinigame.Midpoint.position.z) - base.transform.position);
			}
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			if (this.Yandere.DelinquentFighting && this.StudentManager.CombatMinigame.Delinquent != this)
			{
				if (this.StudentManager.CombatMinigame.Path < 4)
				{
					if (this.DistanceToPlayer < 1f)
					{
						this.MyController.Move(base.transform.forward * Time.deltaTime * -1f);
					}
					if (Vector3.Distance(base.transform.position, this.StudentManager.CombatMinigame.Delinquent.transform.position) < 1f)
					{
						this.MyController.Move(base.transform.forward * Time.deltaTime * -1f);
					}
					if (this.Yandere.enabled)
					{
						this.CheerTimer = Mathf.MoveTowards(this.CheerTimer, 0f, Time.deltaTime);
						if (this.CheerTimer == 0f)
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentCheer, 0, 5f);
							this.CheerTimer = UnityEngine.Random.Range(2f, 3f);
						}
					}
					this.CharacterAnimation.CrossFade(this.RandomCheerAnim);
					if (this.CharacterAnimation[this.RandomCheerAnim].time >= this.CharacterAnimation[this.RandomCheerAnim].length)
					{
						this.RandomCheerAnim = this.CheerAnims[UnityEngine.Random.Range(0, this.CheerAnims.Length)];
					}
					this.ThreatPhase = 3;
					this.ThreatTimer = 0f;
					if (this.WitnessedMurder)
					{
						this.Injured = true;
					}
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim, 5f);
					this.NoTalk = true;
				}
			}
			else if (!this.Injured)
			{
				if (this.DistanceToPlayer > 5f + this.ThreatDistance && this.ThreatPhase < 4)
				{
					this.ThreatPhase = 3;
					this.ThreatTimer = 0f;
				}
				if (!this.Yandere.Shoved && !this.Yandere.Dumping)
				{
					if (this.DistanceToPlayer > 1f && this.Patience > 0)
					{
						if (this.ThreatPhase == 1)
						{
							this.CharacterAnimation.CrossFade("delinquentShock_00");
							if (this.CharacterAnimation["delinquentShock_00"].time >= this.CharacterAnimation["delinquentShock_00"].length)
							{
								this.Subtitle.Speaker = this;
								this.Subtitle.UpdateLabel(SubtitleType.DelinquentThreatened, 0, 3f);
								this.CharacterAnimation.CrossFade("delinquentCombatIdle_00");
								this.ThreatTimer = 5f;
								this.ThreatPhase++;
							}
						}
						else if (this.ThreatPhase == 2)
						{
							this.ThreatTimer -= Time.deltaTime;
							if (this.ThreatTimer < 0f)
							{
								this.Subtitle.Speaker = this;
								this.Subtitle.UpdateLabel(SubtitleType.DelinquentTaunt, 0, 5f);
								this.ThreatTimer = 5f;
								this.ThreatPhase++;
							}
						}
						else if (this.ThreatPhase == 3)
						{
							this.ThreatTimer -= Time.deltaTime;
							if (this.ThreatTimer < 0f)
							{
								if (!this.NoTalk)
								{
									this.Subtitle.Speaker = this;
									this.Subtitle.UpdateLabel(SubtitleType.DelinquentCalm, 0, 5f);
								}
								this.CharacterAnimation.CrossFade(this.IdleAnim, 5f);
								this.ThreatTimer = 5f;
								this.ThreatPhase++;
							}
						}
						else if (this.ThreatPhase == 4)
						{
							this.ThreatTimer -= Time.deltaTime;
							if (this.ThreatTimer < 0f)
							{
								if (this.CurrentDestination != this.Destinations[this.Phase])
								{
									this.StopInvestigating();
								}
								this.Distracted = false;
								this.Threatened = false;
								this.Alarmed = false;
								this.Routine = true;
								this.NoTalk = false;
								this.IgnoreTimer = 5f;
								this.AlarmTimer = 0f;
							}
						}
					}
					else if (!this.NoTalk)
					{
						string str = string.Empty;
						if (!this.Male)
						{
							str = "Female_";
						}
						if (this.StudentID == 46)
						{
							this.CharacterAnimation.CrossFade("delinquentDrawWeapon_00");
						}
						if (this.StudentManager.CombatMinigame.Delinquent == null)
						{
							this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatIdle");
							if (this.MyWeapon.transform.parent != this.ItemParent)
							{
								Debug.Log("This character should be drawing a weapon.");
								this.CharacterAnimation.CrossFade(str + "delinquentDrawWeapon_00");
							}
							else
							{
								this.CharacterAnimation.CrossFade("delinquentCombatIdle_00");
							}
							if (this.Yandere.Carrying || this.Yandere.Dragging)
							{
								this.Yandere.EmptyHands();
							}
							if (this.Yandere.Pickpocketing)
							{
								this.Yandere.Caught = true;
								this.PickPocket.PickpocketMinigame.End();
							}
							this.Yandere.StopLaughing();
							this.Yandere.StopAiming();
							this.Yandere.Unequip();
							if (this.Yandere.PickUp != null)
							{
								this.Yandere.EmptyHands();
							}
							this.Yandere.DelinquentFighting = true;
							this.Yandere.NearSenpai = false;
							this.Yandere.Degloving = false;
							this.Yandere.CanMove = false;
							this.Yandere.GloveTimer = 0f;
							this.Distracted = true;
							this.Fighting = true;
							this.ThreatTimer = 0f;
							this.StudentManager.CombatMinigame.Delinquent = this;
							this.StudentManager.CombatMinigame.enabled = true;
							this.StudentManager.CombatMinigame.StartCombat();
							this.SpeechLines.Stop();
							this.SpawnAlarmDisc();
							if (this.WitnessedMurder)
							{
								this.Subtitle.Speaker = this;
								this.Subtitle.UpdateLabel(SubtitleType.DelinquentAvenge, 0, 5f);
							}
							else if (!this.StudentManager.CombatMinigame.Practice)
							{
								this.Subtitle.Speaker = this;
								this.Subtitle.UpdateLabel(SubtitleType.DelinquentFight, 0, 5f);
							}
						}
						this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
						if (this.CharacterAnimation[str + "delinquentDrawWeapon_00"].time >= 0.5f)
						{
							this.MyWeapon.transform.parent = this.ItemParent;
							this.MyWeapon.transform.localEulerAngles = new Vector3(0f, 15f, 0f);
							this.MyWeapon.transform.localPosition = new Vector3(0.01f, 0f, 0f);
						}
						if (this.CharacterAnimation[str + "delinquentDrawWeapon_00"].time >= this.CharacterAnimation[str + "delinquentDrawWeapon_00"].length)
						{
							this.Threatened = false;
							this.Alarmed = false;
							base.enabled = false;
						}
					}
					else
					{
						this.ThreatTimer -= Time.deltaTime;
						if (this.ThreatTimer < 0f)
						{
							if (this.CurrentDestination != this.Destinations[this.Phase])
							{
								this.StopInvestigating();
							}
							this.Distracted = false;
							this.Threatened = false;
							this.Alarmed = false;
							this.Routine = true;
							this.NoTalk = false;
							this.IgnoreTimer = 5f;
							this.AlarmTimer = 0f;
						}
					}
				}
			}
			else
			{
				this.ThreatTimer += Time.deltaTime;
				if (this.ThreatTimer > 5f)
				{
					this.DistanceToDestination = 100f;
					if (!this.WitnessedMurder)
					{
						this.Distracted = false;
						this.Threatened = false;
						this.EndAlarm();
					}
					else
					{
						this.Threatened = false;
						this.Alarmed = false;
						this.Injured = false;
						this.PersonaReaction();
					}
				}
			}
		}
	}

	private void UpdateBurning()
	{
		if (this.DistanceToPlayer < 1f && !this.Yandere.Shoved)
		{
			this.PushYandereAway();
		}
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
		this.CharacterAnimation.CrossFade(this.SplashedAnim);
		if (this.Yandere.Tripping)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
		}
		this.SplashTimer += Time.deltaTime;
		if (this.SplashTimer > 2f && this.SplashPhase == 1)
		{
			if (this.Gas)
			{
				this.Subtitle.Speaker = this;
				this.Subtitle.UpdateLabel(this.SplashSubtitleType, 5, 5f);
			}
			else if (this.Bloody)
			{
				this.Subtitle.Speaker = this;
				this.Subtitle.UpdateLabel(this.SplashSubtitleType, 3, 5f);
			}
			else if (this.Yandere.Tripping)
			{
				this.Subtitle.Speaker = this;
				this.Subtitle.UpdateLabel(this.SplashSubtitleType, 7, 5f);
			}
			else
			{
				this.Subtitle.Speaker = this;
				this.Subtitle.UpdateLabel(this.SplashSubtitleType, 1, 5f);
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
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(this.SplashSubtitleType, 6, 5f);
				}
				else if (this.Bloody)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
				}
				else
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
				}
				this.SplashPhase++;
				if (!this.Male)
				{
					this.CurrentDestination = this.StudentManager.FemaleStripSpot;
					this.Pathfinding.target = this.StudentManager.FemaleStripSpot;
				}
				else
				{
					this.CurrentDestination = this.StudentManager.MaleStripSpot;
					this.Pathfinding.target = this.StudentManager.MaleStripSpot;
				}
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
				this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 1, 5f);
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
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
				}
				else
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
				}
				this.SplashPhase++;
				this.CurrentDestination = this.StudentManager.FemaleStripSpot;
				this.Pathfinding.target = this.StudentManager.FemaleStripSpot;
			}
			this.Pathfinding.canSearch = true;
			this.Pathfinding.canMove = true;
			this.Splashed = false;
		}
	}

	private void UpdateTurningOffRadio()
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
					if (this.Persona == PersonaType.PhoneAddict)
					{
						this.SmartPhone.SetActive(true);
					}
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
					this.SmartPhone.SetActive(false);
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
					if (this.Persona == PersonaType.PhoneAddict)
					{
						this.SmartPhone.SetActive(true);
					}
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

	private void UpdateVomiting()
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
				Debug.Log("Character is now drownable.");
				this.Prompt.Label[0].text = "     Drown";
				this.Prompt.enabled = true;
				this.Drownable = true;
				this.VomitDoor.Prompt.enabled = false;
				this.VomitDoor.Prompt.Hide();
				this.VomitDoor.enabled = false;
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
				this.VomitEmitter.gameObject.SetActive(true);
				this.VomitPhase++;
			}
		}
		else if (this.VomitPhase == 2)
		{
			if (this.CharacterAnimation[this.VomitAnim].time > 13f)
			{
				this.VomitEmitter.gameObject.SetActive(false);
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
					this.StudentManager.GetMaleWashSpot(this);
					this.Pathfinding.target = this.StudentManager.MaleWashSpot;
					this.CurrentDestination = this.StudentManager.MaleWashSpot;
				}
				else
				{
					this.StudentManager.GetFemaleWashSpot(this);
					this.Pathfinding.target = this.StudentManager.FemaleWashSpot;
					this.CurrentDestination = this.StudentManager.FemaleWashSpot;
				}
				this.VomitDoor.Prompt.enabled = true;
				this.VomitDoor.enabled = true;
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
			this.WalkAnim = this.OriginalWalkAnim;
			this.Phase++;
			this.Pathfinding.target = this.Destinations[this.Phase];
			this.CurrentDestination = this.Destinations[this.Phase];
			this.DistanceToDestination = 100f;
		}
	}

	private void UpdateConfessing()
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
					this.CurrentDestination = this.StudentManager.RivalConfessionSpot;
					this.Pathfinding.target = this.StudentManager.RivalConfessionSpot;
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = 4f;
					this.StudentManager.LoveManager.LeftNote = true;
					Debug.Log("Sprinting 8");
					this.CharacterAnimation.CrossFade(this.SprintAnim);
					this.ConfessPhase++;
				}
			}
			else if (this.ConfessPhase == 4)
			{
				if (this.DistanceToDestination < 0.5f)
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.ConfessPhase++;
				}
			}
			else if (this.ConfessPhase == 5)
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
				this.CurrentDestination = this.StudentManager.SuitorConfessionSpot;
				this.Pathfinding.target = this.StudentManager.SuitorConfessionSpot;
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Pathfinding.speed = 4f;
				Debug.Log("Sprinting 9");
				this.CharacterAnimation.CrossFade(this.SprintAnim);
				this.ConfessPhase++;
			}
		}
		else if (this.ConfessPhase == 2)
		{
			if (this.DistanceToDestination < 0.5f)
			{
				this.CharacterAnimation.CrossFade("exhausted_00");
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				this.ConfessPhase++;
			}
		}
		else if (this.ConfessPhase == 3)
		{
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
			this.MoveTowardsTarget(this.CurrentDestination.position);
		}
	}

	private void UpdateMisc()
	{
		if (this.IgnoreTimer > 0f)
		{
			this.IgnoreTimer = Mathf.MoveTowards(this.IgnoreTimer, 0f, Time.deltaTime);
		}
		if (!this.Fleeing)
		{
			if (base.transform.position.z < -100f)
			{
				if (base.transform.position.y < -11f && this.StudentID > 1)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
			else
			{
				if (base.transform.position.y < -0f)
				{
					base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
				}
				if (!this.Dying && !this.Distracted && !this.WalkBack && !this.Waiting && !this.Guarding && !this.WitnessedMurder && !this.WitnessedCorpse && !this.Blind && !this.SentHome && !this.TurnOffRadio && !this.Wet && !this.InvestigatingBloodPool && !this.ReturningMisplacedWeapon && !this.Yandere.Egg && !this.StudentManager.Pose && !this.ShoeRemoval.enabled)
				{
					if (this.StudentManager.MissionMode && (double)this.DistanceToPlayer < 0.5)
					{
						this.Yandere.Shutter.FaceStudent = this;
						this.Yandere.Shutter.Penalize();
					}
					if (this.Club == ClubType.Council)
					{
						if (this.DistanceToPlayer < 5f)
						{
							if (this.DistanceToPlayer < 2f)
							{
								this.StudentManager.TutorialWindow.ShowCouncilMessage = true;
							}
							float f = Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position);
							if (Mathf.Abs(f) <= 45f && this.Yandere.Stance.Current != StanceType.Crouching && this.Yandere.Stance.Current != StanceType.Crawling && (this.Yandere.h != 0f || this.Yandere.v != 0f) && (Input.GetButton("LB") || this.DistanceToPlayer < 2f))
							{
								this.DistractionSpot = this.Yandere.transform.position;
								this.Alarm = 100f + Time.deltaTime * 100f * (1f / this.Paranoia);
								this.FocusOnYandere = true;
								this.Pathfinding.canSearch = false;
								this.Pathfinding.canMove = false;
								this.StopInvestigating();
							}
						}
						if (this.DistanceToPlayer < 1.1f)
						{
							float f2 = Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position);
							if (Mathf.Abs(f2) > 45f && (this.Yandere.Armed || this.Yandere.Carrying || this.Yandere.Dragging) && this.Prompt.InSight)
							{
								this.Spray();
							}
						}
					}
					if (((this.Club == ClubType.Council && !this.Spraying) || (this.Club == ClubType.Delinquent && !this.Injured && !this.RespectEarned)) && (double)this.DistanceToPlayer < 0.5 && this.Yandere.CanMove && (this.Yandere.h != 0f || this.Yandere.v != 0f))
					{
						if (this.Club == ClubType.Delinquent)
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentShove, 0, 3f);
						}
						this.Shove();
					}
				}
			}
		}
		if (this.Wet && !this.Splashed && this.BathePhase == 1 && !this.Burning && !this.Dying)
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

	private void LateUpdate()
	{
		if (this.StudentManager.DisableFarAnims && this.DistanceToPlayer >= (float)this.StudentManager.FarAnimThreshold && this.CharacterAnimation.cullingType != AnimationCullingType.AlwaysAnimate && !this.WitnessCamera.Show)
		{
			this.CharacterAnimation.enabled = false;
		}
		else
		{
			this.CharacterAnimation.enabled = true;
		}
		if (this.EyeShrink > 0f)
		{
			if (this.EyeShrink > 1f)
			{
				this.EyeShrink = 1f;
			}
			this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
			this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
			this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
			this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
			this.PreviousEyeShrink = this.EyeShrink;
		}
		if (!this.Male)
		{
			if (this.Shy)
			{
				if (this.Routine)
				{
					if ((this.Phase == 2 && this.DistanceToDestination < 1f) || (this.Phase == 4 && this.DistanceToDestination < 1f) || (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes && this.DistanceToDestination < 1f) || (this.Actions[this.Phase] == StudentActionType.Clean && this.DistanceToDestination < 1f) || (this.Actions[this.Phase] == StudentActionType.Read && this.DistanceToDestination < 1f))
					{
						this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 0f, Time.deltaTime);
					}
					else
					{
						this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 1f, Time.deltaTime);
					}
				}
				else if (!this.Headache)
				{
					this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 0f, Time.deltaTime);
				}
			}
			if (!this.BoobsResized)
			{
				this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				if (!this.Cosmetic.CustomEyes)
				{
					this.RightBreast.gameObject.name = "RightBreastRENAMED";
					this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
				}
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
			if (this.StudentManager.Egg && this.SecurityCamera.activeInHierarchy)
			{
				this.Head.localScale = new Vector3(0f, 0f, 0f);
			}
			if (this.Club == ClubType.Bully)
			{
				for (int i = 0; i < 4; i++)
				{
					if (this.Skirt[i] != null)
					{
						Transform transform = this.Skirt[i].transform;
						transform.localScale = new Vector3(transform.localScale.x, 0.6666667f, transform.localScale.z);
					}
				}
			}
		}
		if (this.Routine && !this.InEvent && !this.Meeting && !this.GoAway)
		{
			if ((this.DistanceToDestination < this.TargetDistance && this.Actions[this.Phase] == StudentActionType.SitAndSocialize) || (this.DistanceToDestination < this.TargetDistance && this.StudentID != 36 && this.Actions[this.Phase] == StudentActionType.Meeting) || (this.DistanceToDestination < this.TargetDistance && this.Actions[this.Phase] == StudentActionType.Sleuth && this.StudentManager.SleuthPhase != 2 && this.StudentManager.SleuthPhase != 3) || (this.Club == ClubType.Photography && this.ClubActivity))
			{
				if (this.CharacterAnimation[this.SocialSitAnim].weight != 1f)
				{
					this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 1f, Time.deltaTime * 10f);
					if ((double)this.CharacterAnimation[this.SocialSitAnim].weight > 0.99)
					{
						this.CharacterAnimation[this.SocialSitAnim].weight = 1f;
					}
				}
			}
			else if (this.CharacterAnimation[this.SocialSitAnim].weight != 0f)
			{
				this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 0f, Time.deltaTime * 10f);
				if ((double)this.CharacterAnimation[this.SocialSitAnim].weight < 0.01)
				{
					this.CharacterAnimation[this.SocialSitAnim].weight = 0f;
				}
			}
		}
		else if (this.CharacterAnimation[this.SocialSitAnim].weight != 0f)
		{
			this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 0f, Time.deltaTime * 10f);
			if ((double)this.CharacterAnimation[this.SocialSitAnim].weight < 0.01)
			{
				this.CharacterAnimation[this.SocialSitAnim].weight = 0f;
			}
		}
		if (this.DK)
		{
			this.Arm[0].localScale = new Vector3(2f, 2f, 2f);
			this.Arm[1].localScale = new Vector3(2f, 2f, 2f);
			this.Head.localScale = new Vector3(2f, 2f, 2f);
		}
		if (this.Fate > 0 && this.Clock.HourTime > this.TimeOfDeath)
		{
			this.Yandere.TargetStudent = this;
			this.StudentManager.Shinigami.Effect = this.Fate - 1;
			this.StudentManager.Shinigami.Attack();
			this.Yandere.TargetStudent = null;
			this.Fate = 0;
		}
		if (this.Yandere.BlackHole && this.DistanceToPlayer < 2.5f)
		{
			if (this.DeathScream != null)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.DeathScream, base.transform.position + Vector3.up, Quaternion.identity);
			}
			this.BlackHoleEffect[0].enabled = true;
			this.BlackHoleEffect[1].enabled = true;
			this.BlackHoleEffect[2].enabled = true;
			this.DeathType = DeathType.EasterEgg;
			this.CharacterAnimation.Stop();
			this.Suck.enabled = true;
			this.BecomeRagdoll();
			this.Dying = true;
		}
		if (this.CameraReacting && (this.StudentManager.NEStairs.bounds.Contains(base.transform.position) || this.StudentManager.NWStairs.bounds.Contains(base.transform.position) || this.StudentManager.SEStairs.bounds.Contains(base.transform.position) || this.StudentManager.SWStairs.bounds.Contains(base.transform.position)))
		{
			this.Spine.LookAt(this.Yandere.Spine[0]);
			this.Head.LookAt(this.Yandere.Head);
		}
	}

	public void CalculateReputationPenalty()
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
		this.ChameleonCheck();
		if (this.Chameleon)
		{
			Debug.Log("Chopping reputation loss in half!");
			this.RepLoss *= 0.5f;
		}
		if (this.Yandere.Persona == YanderePersonaType.Aggressive)
		{
			this.RepLoss *= 2f;
		}
		if (this.Club == ClubType.Bully)
		{
			this.RepLoss *= 2f;
		}
		if (this.Club == ClubType.Delinquent)
		{
			this.RepDeduction = 0f;
			this.RepLoss = 0f;
		}
	}

	public void MoveTowardsTarget(Vector3 target)
	{
		if (Time.timeScale > 0.0001f && this.MyController.enabled)
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
		if (Time.timeScale > 0.0001f)
		{
		}
	}

	public void AttackReaction()
	{
		Debug.Log(this.Name + " is being attacked.");
		if (this.PhotoEvidence)
		{
			this.SmartPhone.GetComponent<SmartphoneScript>().enabled = true;
			this.SmartPhone.GetComponent<PromptScript>().enabled = true;
			this.SmartPhone.GetComponent<Rigidbody>().useGravity = true;
			this.SmartPhone.GetComponent<Collider>().enabled = true;
			this.SmartPhone.transform.parent = null;
			this.SmartPhone.layer = 15;
		}
		else
		{
			this.SmartPhone.SetActive(false);
		}
		if (!this.WitnessedMurder)
		{
			float f = Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position);
			this.Yandere.AttackManager.Stealth = (Mathf.Abs(f) <= 45f);
		}
		if (this.ReturningMisplacedWeapon)
		{
			this.DropMisplacedWeapon();
		}
		if (!this.Male)
		{
			if (this.Club != ClubType.Council)
			{
				this.StudentManager.TranqDetector.TranqCheck();
			}
			this.CharacterAnimation["f02_smile_00"].weight = 0f;
			this.SmartPhone.SetActive(false);
			this.CharacterAnimation[this.ShyAnim].weight = 0f;
			this.Shy = false;
		}
		this.WitnessCamera.Show = false;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Yandere.CharacterAnimation["f02_idleShort_00"].time = 0f;
		this.Yandere.CharacterAnimation["f02_swingA_00"].time = 0f;
		this.Yandere.HipCollider.enabled = true;
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
		this.EmptyHands();
		this.DropPlate();
		this.MyController.radius = 0f;
		if (this.Persona == PersonaType.PhoneAddict)
		{
			this.Countdown.gameObject.SetActive(false);
			this.ChaseCamera.SetActive(false);
			if (this.StudentManager.ChaseCamera == this.ChaseCamera)
			{
				this.StudentManager.ChaseCamera = null;
			}
		}
		this.InvestigatingBloodPool = false;
		this.Investigating = false;
		this.Pen.SetActive(false);
		this.EatingSnack = false;
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
			this.DistractionTarget.Octodog.SetActive(false);
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
				this.Yandere.ShoulderCamera.OverShoulder = false;
				this.Yandere.RPGCamera.enabled = false;
				this.Yandere.Senpai = base.transform;
				this.Yandere.Attacking = true;
				this.Yandere.CanMove = false;
				this.Yandere.Talking = false;
				this.Yandere.Noticed = true;
				this.Yandere.HUD.alpha = 0f;
			}
		}
		else if (this.Strength == 9)
		{
			if (!this.WitnessedMurder)
			{
				this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 3, 11f);
			}
			this.Yandere.CharacterAnimation.CrossFade("f02_moCounterA_00");
			this.Yandere.HeartRate.gameObject.SetActive(false);
			this.Yandere.ShoulderCamera.ObstacleCounter = true;
			this.Yandere.ShoulderCamera.OverShoulder = false;
			this.Yandere.RPGCamera.enabled = false;
			this.Yandere.Senpai = base.transform;
			this.Yandere.Attacking = true;
			this.Yandere.CanMove = false;
			this.Yandere.Talking = false;
			this.Yandere.Noticed = true;
			this.Yandere.HUD.alpha = 0f;
		}
		else
		{
			if (!this.Yandere.AttackManager.Stealth)
			{
				this.Subtitle.UpdateLabel(SubtitleType.Dying, 0, 1f);
				this.SpawnAlarmDisc();
			}
			if (this.Yandere.SanityBased)
			{
				this.Yandere.AttackManager.Attack(this.Character, this.Yandere.EquippedWeapon);
			}
		}
		if (this.StudentManager.Reporter == this)
		{
			this.StudentManager.Reporter = null;
			if (this.ReportPhase == 0)
			{
				Debug.Log("A reporter died before being able to report a corpse. Corpse position reset.");
				this.StudentManager.CorpseLocation.position = Vector3.zero;
			}
		}
		if (this.Club == ClubType.Delinquent && this.MyWeapon != null && this.MyWeapon.transform.parent == this.ItemParent)
		{
			this.MyWeapon.transform.parent = null;
			this.MyWeapon.MyCollider.enabled = true;
			this.MyWeapon.Prompt.enabled = true;
			Rigidbody component = this.MyWeapon.GetComponent<Rigidbody>();
			component.constraints = RigidbodyConstraints.None;
			component.isKinematic = false;
			component.useGravity = true;
		}
		if (this.PhotoEvidence)
		{
			this.CameraFlash.SetActive(false);
			this.SmartPhone.SetActive(true);
		}
	}

	public void DropPlate()
	{
		if (this.MyPlate != null && this.MyPlate.parent == this.RightHand)
		{
			this.MyPlate.GetComponent<Rigidbody>().isKinematic = false;
			this.MyPlate.GetComponent<Rigidbody>().useGravity = true;
			this.MyPlate.GetComponent<Collider>().enabled = true;
			this.MyPlate.parent = null;
			this.MyPlate.gameObject.SetActive(true);
		}
	}

	public void SenpaiNoticed()
	{
		Debug.Log("The ''SenpaiNoticed'' function has been called.");
		if (this.Yandere.Shutter.Snapping)
		{
			this.Yandere.Shutter.ResumeGameplay();
			this.Yandere.StopAiming();
		}
		this.Yandere.Noticed = true;
		if (this.WeaponToTakeAway != null && this.Teacher && !this.Yandere.Attacking)
		{
			Debug.Log("Taking away Yandere-chan's weapon.");
			this.Yandere.EquippedWeapon.Drop();
			this.WeaponToTakeAway.transform.position = this.StudentManager.WeaponBoxSpot.parent.position + new Vector3(0f, 1f, 0f);
			this.WeaponToTakeAway.transform.eulerAngles = new Vector3(0f, 90f, 0f);
		}
		this.WeaponToTakeAway = null;
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
		this.Yandere.ProgressBar.transform.parent.gameObject.SetActive(false);
		this.Yandere.HeartRate.gameObject.SetActive(false);
		this.Yandere.Stance.Current = StanceType.Standing;
		this.Yandere.ShoulderCamera.OverShoulder = false;
		this.Yandere.Obscurance.enabled = false;
		this.Yandere.DelinquentFighting = false;
		this.Yandere.YandereVision = false;
		this.Yandere.CannotRecover = true;
		this.Yandere.Police.Show = false;
		this.Yandere.Poisoning = false;
		this.Yandere.Rummaging = false;
		this.Yandere.Laughing = false;
		this.Yandere.CanMove = false;
		this.Yandere.Dipping = false;
		this.Yandere.Mopping = false;
		this.Yandere.Talking = false;
		this.Yandere.Jukebox.GameOver();
		this.StudentManager.StopMoving();
		if (this.Teacher || this.StudentID == 1)
		{
			if (this.Club != ClubType.Council)
			{
				this.IdleAnim = this.OriginalIdleAnim;
			}
			this.AlarmTimer = 0f;
			base.enabled = true;
			this.Stop = false;
		}
	}

	private void WitnessMurder()
	{
		this.RespectEarned = false;
		if ((this.Fleeing && this.WitnessedBloodPool) || this.ReportPhase == 2)
		{
			this.WitnessedBloodyWeapon = false;
			this.WitnessedBloodPool = false;
			this.WitnessedSomething = false;
			this.WitnessedWeapon = false;
			this.WitnessedLimb = false;
			this.Fleeing = false;
			this.ReportPhase = 0;
		}
		this.CharacterAnimation[this.ScaredAnim].time = 0f;
		this.CameraFlash.SetActive(false);
		if (!this.Male)
		{
			this.CharacterAnimation["f02_smile_00"].weight = 0f;
			this.WateringCan.SetActive(false);
		}
		if (this.MyPlate != null && this.MyPlate.parent == this.RightHand)
		{
			this.MyPlate.GetComponent<Rigidbody>().isKinematic = false;
			this.MyPlate.GetComponent<Rigidbody>().useGravity = true;
			this.MyPlate.GetComponent<Collider>().enabled = true;
			this.MyPlate.parent = null;
		}
		this.EmptyHands();
		this.MurdersWitnessed++;
		this.SpeechLines.Stop();
		this.WitnessedBloodyWeapon = false;
		this.WitnessedBloodPool = false;
		this.WitnessedSomething = false;
		this.WitnessedWeapon = false;
		this.WitnessedLimb = false;
		if (this.ReturningMisplacedWeapon)
		{
			this.DropMisplacedWeapon();
		}
		this.ReturningMisplacedWeapon = false;
		this.InvestigatingBloodPool = false;
		this.CameraReacting = false;
		this.WitnessedMurder = true;
		this.Investigating = false;
		this.Distracting = false;
		this.EatingSnack = false;
		this.Threatened = false;
		this.Distracted = false;
		this.Reacted = false;
		this.Routine = false;
		this.Alarmed = true;
		this.NoTalk = false;
		this.Wet = false;
		if (this.OriginalPersona != PersonaType.Violent && this.Persona != this.OriginalPersona)
		{
			Debug.Log(this.Name + " is reverting back into their original Persona.");
			this.Persona = this.OriginalPersona;
			this.SwitchBack = false;
		}
		if (this.Persona == PersonaType.Spiteful && this.Yandere.TargetStudent != null)
		{
			Debug.Log("A Spiteful student witnessed a murder.");
			if ((this.Bullied && this.Yandere.TargetStudent.Club == ClubType.Bully) || this.Yandere.TargetStudent.Bullied)
			{
				this.ScaredAnim = this.EvilWitnessAnim;
				this.Persona = PersonaType.Evil;
			}
		}
		if (this.Club == ClubType.Delinquent)
		{
			Debug.Log("A Delinquent witnessed a murder.");
			if (this.Yandere.TargetStudent != null && this.Yandere.TargetStudent.Club == ClubType.Bully)
			{
				this.ScaredAnim = this.EvilWitnessAnim;
				this.Persona = PersonaType.Evil;
			}
			if ((this.Yandere.Lifting || this.Yandere.Carrying || this.Yandere.Dragging) && this.Yandere.CurrentRagdoll.Student.Club == ClubType.Bully)
			{
				this.ScaredAnim = this.EvilWitnessAnim;
				this.Persona = PersonaType.Evil;
			}
		}
		if (this.Persona == PersonaType.Sleuth)
		{
			Debug.Log("A Sleuth is witnessing a murder.");
			if (this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Carrying || this.Yandere.Lifting || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart))
			{
				if (!this.Sleuthing)
				{
					Debug.Log("A Sleuth is changing their Persona.");
					if (this.StudentID == 56)
					{
						this.Persona = PersonaType.Heroic;
					}
					else
					{
						this.Persona = PersonaType.SocialButterfly;
					}
				}
				else
				{
					this.Persona = PersonaType.SocialButterfly;
				}
			}
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
			this.Witnessed = StudentWitnessType.Murder;
			Debug.Log("''Witnessed'' is being set to ''StudentWitnessType.Murder''.");
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
				this.Talk.enabled = false;
				this.Talking = false;
				this.Waiting = false;
				this.StudentManager.EnablePrompts();
			}
			if (this.Prompt.Label[0] != null && !GameGlobals.EmptyDemon)
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
			this.Yandere.ShoulderCamera.OverShoulder = false;
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
			this.StudentManager.LowerCorpsePosition();
			this.StudentManager.Reporter = this;
			this.ReportingMurder = true;
		}
		if (this.Following)
		{
			this.Hearts.emission.enabled = false;
			this.Yandere.Followers--;
			this.Following = false;
		}
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		if (this.Persona == PersonaType.PhoneAddict || this.Sleuthing)
		{
			this.SmartPhone.SetActive(true);
		}
		if (this.SmartPhone.activeInHierarchy)
		{
			if (this.Persona != PersonaType.Heroic && this.Persona != PersonaType.Dangerous && this.Persona != PersonaType.Evil && this.Persona != PersonaType.Violent && this.Persona != PersonaType.Coward && !this.Teacher)
			{
				this.Persona = PersonaType.PhoneAddict;
				if (!this.Sleuthing)
				{
					this.SprintAnim = this.PhoneAnims[2];
				}
				else
				{
					this.SprintAnim = this.SleuthReportAnim;
				}
			}
			else
			{
				this.SmartPhone.SetActive(false);
			}
		}
		this.StopPairing();
		if (this.Persona != PersonaType.Heroic)
		{
			this.AlarmTimer = 0f;
			this.Alarm = 0f;
		}
		if (this.Teacher)
		{
			if (!this.Yandere.Chased)
			{
				Debug.Log("A teacher has reached ChaseYandere through WitnessMurder.");
				this.ChaseYandere();
			}
		}
		else
		{
			this.SpawnAlarmDisc();
		}
		if (!this.PinDownWitness && this.Persona != PersonaType.Evil)
		{
			this.StudentManager.Witnesses++;
			this.StudentManager.WitnessList[this.StudentManager.Witnesses] = this;
			this.StudentManager.PinDownCheck();
			this.PinDownWitness = true;
		}
		if (this.Persona == PersonaType.Violent)
		{
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
		}
		if (this.Yandere.Mask == null)
		{
			this.SawMask = false;
			if (this.Persona != PersonaType.Evil)
			{
				this.Grudge = true;
			}
		}
		else
		{
			this.SawMask = true;
		}
		this.StudentManager.UpdateMe(this.StudentID);
	}

	private void DropMisplacedWeapon()
	{
		this.InvestigatingBloodPool = false;
		this.ReturningMisplacedWeaponPhase = 0;
		this.ReturningMisplacedWeapon = false;
		this.BloodPool.GetComponent<WeaponScript>().Returner = null;
		this.BloodPool.GetComponent<WeaponScript>().Drop();
		this.BloodPool.GetComponent<WeaponScript>().enabled = true;
		this.BloodPool = null;
	}

	private void ChaseYandere()
	{
		Debug.Log("A character has begun to chase Yandere-chan.");
		this.CurrentDestination = this.Yandere.transform;
		this.Pathfinding.target = this.Yandere.transform;
		this.Pathfinding.speed = 5f;
		this.StudentManager.Portal.SetActive(false);
		if (this.Yandere.Pursuer == null)
		{
			this.Yandere.Pursuer = this;
		}
		this.TargetDistance = 1f;
		this.AlarmTimer = 0f;
		this.Chasing = false;
		this.Fleeing = false;
		this.StudentManager.UpdateStudents(0);
	}

	private void PersonaReaction()
	{
		Debug.Log("PersonaReaction() is being called.");
		if (this.Persona == PersonaType.Sleuth)
		{
			if (this.Sleuthing)
			{
				this.Persona = PersonaType.PhoneAddict;
				this.SmartPhone.SetActive(true);
			}
			else
			{
				this.Persona = PersonaType.SocialButterfly;
			}
		}
		if (!this.Indoors && this.WitnessedMurder && this.StudentID != this.StudentManager.RivalID)
		{
			Debug.Log(this.Name + "'s current Persona is: " + this.Persona);
			if ((this.Persona != PersonaType.Evil && this.Persona != PersonaType.Heroic && this.Persona != PersonaType.Coward && this.Persona != PersonaType.PhoneAddict && this.Persona != PersonaType.Protective && this.Persona != PersonaType.Violent) || this.Injured)
			{
				Debug.Log(this.Name + " is switching to the Loner Persona.");
				this.Persona = PersonaType.Loner;
			}
		}
		if (!this.WitnessedMurder)
		{
			if (this.Persona == PersonaType.Heroic)
			{
				this.SwitchBack = true;
				this.Persona = ((!(this.Corpse != null)) ? PersonaType.Loner : PersonaType.TeachersPet);
			}
			else if (this.Persona == PersonaType.Coward || this.Persona == PersonaType.Evil || this.Persona == PersonaType.Fragile)
			{
				this.Persona = PersonaType.Loner;
			}
			else if (this.Persona == PersonaType.Protective)
			{
				Debug.Log("Raibaru witnessed a corpse, and should be running to tell Osana about it.");
				this.Persona = PersonaType.Lovestruck;
			}
		}
		if (this.Persona == PersonaType.Loner || this.Persona == PersonaType.Spiteful)
		{
			if (this.Club == ClubType.Delinquent)
			{
				Debug.Log("A delinquent turned into a loner, and now he is fleeing.");
				if (this.Injured)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentInjuredFlee, 1, 3f);
				}
				else if (this.FoundFriendCorpse)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentFriendFlee, 1, 3f);
				}
				else if (this.FoundEnemyCorpse)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentEnemyFlee, 1, 3f);
				}
				else
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentFlee, 1, 3f);
				}
			}
			else if (this.WitnessedMurder)
			{
				this.Subtitle.UpdateLabel(SubtitleType.LonerMurderReaction, 1, 3f);
			}
			else
			{
				this.Subtitle.UpdateLabel(SubtitleType.LonerCorpseReaction, 1, 3f);
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
					this.BathePhase = 5;
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
			if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
			{
				if (this.StudentManager.BloodReporter == null)
				{
					if (this.Club != ClubType.Delinquent && !this.Police.Called && !this.LostTeacherTrust)
					{
						this.StudentManager.BloodLocation.position = this.BloodPool.transform.position;
						this.StudentManager.LowerBloodPosition();
						Debug.Log(this.Name + " has become a ''blood reporter''.");
						this.StudentManager.BloodReporter = this;
						this.ReportingBlood = true;
						this.DetermineBloodLocation();
					}
					else
					{
						this.ReportingBlood = false;
					}
				}
			}
			else if (this.StudentManager.Reporter == null && !this.Police.Called)
			{
				this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
				this.StudentManager.LowerCorpsePosition();
				Debug.Log("A student has become a ''reporter''.");
				this.StudentManager.Reporter = this;
				this.ReportingMurder = true;
				this.DetermineCorpseLocation();
			}
			if (this.StudentManager.Reporter == this)
			{
				Debug.Log(this.Name + " is running to a teacher to report murder.");
				this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
				this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
				this.TargetDistance = 2f;
				if (this.WitnessedMurder)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetMurderReport, 1, 3f);
				}
				else if (this.WitnessedCorpse)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReport, 1, 3f);
				}
			}
			else if (this.StudentManager.BloodReporter == this)
			{
				Debug.Log(this.Name + " is running to a teacher to report something.");
				this.DropPlate();
				this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
				this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
				this.TargetDistance = 2f;
				if (this.WitnessedLimb)
				{
					this.Subtitle.UpdateLabel(SubtitleType.LimbReaction, 1, 3f);
				}
				else if (this.WitnessedBloodyWeapon)
				{
					this.Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 1, 3f);
				}
				else if (this.WitnessedBloodPool)
				{
					this.Subtitle.UpdateLabel(SubtitleType.BloodPoolReaction, 1, 3f);
				}
				else if (this.WitnessedWeapon)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReport, 1, 3f);
				}
			}
			else
			{
				if (this.Club == ClubType.Council)
				{
					if (this.WitnessedCorpse)
					{
						if (this.StudentManager.CorpseLocation.position == Vector3.zero)
						{
							this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
							this.AssignCorpseGuardLocations();
						}
						if (this.StudentID == 86)
						{
							this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[1];
						}
						else if (this.StudentID == 87)
						{
							this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[2];
						}
						else if (this.StudentID == 88)
						{
							this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[3];
						}
						else if (this.StudentID == 89)
						{
							this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[4];
						}
						this.CurrentDestination = this.Pathfinding.target;
					}
					else
					{
						Debug.Log("A student council member is being told to travel to ''BloodGuardLocation''.");
						if (this.StudentManager.BloodLocation.position == Vector3.zero)
						{
							this.StudentManager.BloodLocation.position = this.BloodPool.transform.position;
							this.AssignBloodGuardLocations();
						}
						if (this.StudentManager.BloodGuardLocation[1].position == Vector3.zero)
						{
							this.AssignBloodGuardLocations();
						}
						if (this.StudentID == 86)
						{
							this.Pathfinding.target = this.StudentManager.BloodGuardLocation[1];
						}
						else if (this.StudentID == 87)
						{
							this.Pathfinding.target = this.StudentManager.BloodGuardLocation[2];
						}
						else if (this.StudentID == 88)
						{
							this.Pathfinding.target = this.StudentManager.BloodGuardLocation[3];
						}
						else if (this.StudentID == 89)
						{
							this.Pathfinding.target = this.StudentManager.BloodGuardLocation[4];
						}
						this.CurrentDestination = this.Pathfinding.target;
						this.Guarding = true;
					}
				}
				else
				{
					this.PetDestination = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, this.Seat.position + this.Seat.forward * -0.5f, Quaternion.identity).transform;
					this.Pathfinding.target = this.PetDestination;
					this.CurrentDestination = this.PetDestination;
					this.Distracting = false;
					this.DropPlate();
				}
				if (this.WitnessedMurder)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetMurderReaction, 1, 3f);
				}
				else if (this.WitnessedCorpse)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReaction, 1, 3f);
				}
				else if (this.WitnessedLimb)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetLimbReaction, 1, 3f);
				}
				else if (this.WitnessedBloodyWeapon)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetBloodyWeaponReaction, 1, 3f);
				}
				else if (this.WitnessedBloodPool)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetBloodReaction, 1, 3f);
				}
				else if (this.WitnessedWeapon)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 1, 3f);
				}
				this.TargetDistance = 1f;
				this.ReportingMurder = false;
				this.ReportingBlood = false;
			}
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == PersonaType.Heroic || this.Persona == PersonaType.Protective)
		{
			if (!this.Yandere.Chased)
			{
				this.StudentManager.PinDownCheck();
				if (!this.StudentManager.PinningDown)
				{
					Debug.Log("Began fleeing because Hero persona reaction was called.");
					if (this.Persona == PersonaType.Protective)
					{
						this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 2, 3f);
					}
					else if (this.Persona != PersonaType.Violent)
					{
						this.Subtitle.UpdateLabel(SubtitleType.HeroMurderReaction, 3, 3f);
					}
					else if (this.Defeats > 0)
					{
						this.Subtitle.Speaker = this;
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentResume, 3, 3f);
					}
					else
					{
						this.Subtitle.Speaker = this;
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentMurderReaction, 3, 3f);
					}
					this.Pathfinding.target = this.Yandere.transform;
					this.Pathfinding.speed = 5f;
					this.StudentManager.Portal.SetActive(false);
					this.Yandere.Pursuer = this;
					this.Yandere.Chased = true;
					this.TargetDistance = 1f;
					this.StudentManager.UpdateStudents(0);
					this.Routine = false;
					this.Fleeing = true;
				}
			}
		}
		else if (this.Persona == PersonaType.Coward || this.Persona == PersonaType.Fragile)
		{
			Debug.Log("This character just set their destination to themself.");
			this.CurrentDestination = base.transform;
			this.Pathfinding.target = base.transform;
			this.Subtitle.UpdateLabel(SubtitleType.CowardMurderReaction, 1, 5f);
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == PersonaType.Evil)
		{
			Debug.Log("This character just set their destination to themself.");
			this.CurrentDestination = base.transform;
			this.Pathfinding.target = base.transform;
			this.Subtitle.UpdateLabel(SubtitleType.EvilMurderReaction, 1, 5f);
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == PersonaType.SocialButterfly)
		{
			this.StudentManager.HidingSpots.List[this.StudentID].position = this.StudentManager.PopulationManager.GetCrowdedLocation();
			this.CurrentDestination = this.StudentManager.HidingSpots.List[this.StudentID];
			this.Pathfinding.target = this.StudentManager.HidingSpots.List[this.StudentID];
			this.Subtitle.UpdateLabel(SubtitleType.SocialDeathReaction, 1, 5f);
			this.TargetDistance = 2f;
			this.ReportPhase = 1;
			this.Routine = false;
			this.Fleeing = true;
			this.Halt = true;
		}
		else if (this.Persona == PersonaType.Lovestruck)
		{
			if (!this.StudentManager.Students[this.LovestruckTarget].WitnessedMurder)
			{
				Debug.Log("Destination should be set to Lovestruck Target.");
				this.CurrentDestination = this.StudentManager.Students[this.LovestruckTarget].transform;
				this.Pathfinding.target = this.StudentManager.Students[this.LovestruckTarget].transform;
				this.StudentManager.Students[this.LovestruckTarget].TargetedForDistraction = true;
				this.TargetDistance = 1f;
				this.ReportPhase = 1;
			}
			else
			{
				Debug.Log("Destination should be set to Exit.");
				this.CurrentDestination = this.StudentManager.Exit;
				this.Pathfinding.target = this.StudentManager.Exit;
				this.TargetDistance = 0f;
				this.ReportPhase = 3;
			}
			if (this.LovestruckTarget == 1)
			{
				this.Subtitle.UpdateLabel(SubtitleType.LovestruckDeathReaction, 0, 5f);
			}
			else
			{
				this.Subtitle.UpdateLabel(SubtitleType.LovestruckDeathReaction, 1, 5f);
			}
			this.DistanceToDestination = 100f;
			this.Pathfinding.canSearch = true;
			this.Pathfinding.canMove = true;
			this.Routine = false;
			this.Fleeing = true;
			this.Halt = true;
		}
		else if (this.Persona == PersonaType.Dangerous)
		{
			if (this.WitnessedMurder)
			{
				if (this.StudentID == 86)
				{
					this.Subtitle.UpdateLabel(SubtitleType.Chasing, 1, 5f);
				}
				else if (this.StudentID == 87)
				{
					this.Subtitle.UpdateLabel(SubtitleType.Chasing, 2, 5f);
				}
				else if (this.StudentID == 88)
				{
					this.Subtitle.UpdateLabel(SubtitleType.Chasing, 3, 5f);
				}
				else if (this.StudentID == 89)
				{
					this.Subtitle.UpdateLabel(SubtitleType.Chasing, 4, 5f);
				}
				this.Pathfinding.target = this.Yandere.transform;
				this.Pathfinding.speed = 5f;
				this.StudentManager.Portal.SetActive(false);
				this.Yandere.Chased = true;
				this.TargetDistance = 1f;
				this.StudentManager.UpdateStudents(0);
				Debug.Log("Sprinting 10");
				this.CharacterAnimation.CrossFade(this.SprintAnim);
				this.Routine = false;
				this.Fleeing = true;
				this.Halt = true;
			}
			else
			{
				Debug.Log("A student council member has transformed into a Teacher's Pet.");
				this.Persona = PersonaType.TeachersPet;
				this.PersonaReaction();
			}
		}
		else if (this.Persona == PersonaType.PhoneAddict)
		{
			this.CurrentDestination = this.StudentManager.Exit;
			this.Pathfinding.target = this.StudentManager.Exit;
			this.Countdown.gameObject.SetActive(true);
			this.Routine = false;
			this.Fleeing = true;
			if (this.StudentManager.ChaseCamera == null)
			{
				this.StudentManager.ChaseCamera = this.ChaseCamera;
				this.ChaseCamera.SetActive(true);
			}
		}
		else if (this.Persona == PersonaType.Violent)
		{
			if (this.WitnessedMurder)
			{
				if (!this.Yandere.Chased)
				{
					this.StudentManager.PinDownCheck();
					if (!this.StudentManager.PinningDown)
					{
						Debug.Log(this.Name + " began fleeing because Violent persona reaction was called.");
						if (this.Defeats > 0)
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentResume, 3, 3f);
						}
						else
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentMurderReaction, 3, 3f);
						}
						this.Pathfinding.target = this.Yandere.transform;
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Pathfinding.speed = 5f;
						this.StudentManager.Portal.SetActive(false);
						this.Yandere.Pursuer = this;
						this.Yandere.Chased = true;
						this.TargetDistance = 1f;
						this.StudentManager.UpdateStudents(0);
						this.Routine = false;
						this.Fleeing = true;
					}
				}
			}
			else
			{
				if (this.FoundFriendCorpse)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentFriendFlee, 1, 3f);
				}
				else
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentFlee, 1, 3f);
				}
				this.Pathfinding.target = this.StudentManager.Exit;
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.TargetDistance = 0f;
				this.Routine = false;
				this.Fleeing = true;
			}
		}
		else if (this.Persona == PersonaType.Strict)
		{
			if (this.Yandere.Pursuer == this)
			{
				Debug.Log("This teacher is now pursuing Yandere-chan.");
			}
			if (this.WitnessedMurder)
			{
				if (this.Yandere.Pursuer == this)
				{
					Debug.Log("A teacher is now reacting to the sight of murder.");
					this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 3, 3f);
					this.Pathfinding.target = this.Yandere.transform;
					this.Pathfinding.speed = 5f;
					this.StudentManager.Portal.SetActive(false);
					this.Yandere.Chased = true;
					this.TargetDistance = 1f;
					this.StudentManager.UpdateStudents(0);
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
					this.Routine = false;
					this.Fleeing = true;
				}
				else if (!this.Yandere.Chased)
				{
					Debug.Log("A teacher has reached ChaseYandere through PersonaReaction.");
					this.ChaseYandere();
				}
			}
			else if (this.WitnessedCorpse)
			{
				Debug.Log("A teacher is now reacting to the sight of a corpse.");
				if (this.ReportPhase == 0)
				{
					this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseReaction, 1, 3f);
				}
				this.Pathfinding.target = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z), Quaternion.identity).transform;
				this.TargetDistance = 1f;
				this.ReportPhase = 2;
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
				this.Routine = false;
				this.Fleeing = true;
			}
			else
			{
				Debug.Log("A teacher is now reacting to the sight of a severed limb, blood pool, or weapon.");
				if (this.ReportPhase == 0)
				{
					if (this.WitnessedBloodPool || this.WitnessedBloodyWeapon)
					{
						this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 3, 3f);
					}
					else if (this.WitnessedLimb)
					{
						this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 4, 3f);
					}
					else if (this.WitnessedWeapon)
					{
						this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 5, 3f);
					}
				}
				this.TargetDistance = 1f;
				this.ReportPhase = 2;
				this.Routine = false;
				this.Fleeing = true;
				this.Halt = true;
			}
		}
		if (this.StudentID == 41)
		{
			this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
		}
	}

	private void BeginStruggle()
	{
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
		this.Yandere.ShoulderCamera.LastPosition = this.Yandere.ShoulderCamera.transform.position;
		this.Yandere.ShoulderCamera.Struggle = true;
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
		if (this.Yandere.DelinquentFighting)
		{
			this.StudentManager.CombatMinigame.Stop();
		}
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
			else if (scheduleBlock2.destination == "SocialSeat")
			{
				this.Destinations[this.ID] = this.StudentManager.SocialSeats[this.StudentID];
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
				if (!this.FragileSlave)
				{
					this.Destinations[this.ID] = this.StudentManager.SlaveSpot;
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.FragileSlaveSpot;
				}
			}
			else if (scheduleBlock2.destination == "Patrol")
			{
				this.Destinations[this.ID] = this.StudentManager.Patrols.List[this.StudentID].GetChild(0);
				if ((this.OriginalClub == ClubType.Gardening || this.OriginalClub == ClubType.Occult) && this.Club == ClubType.None)
				{
					Debug.Log("This student's club disbanded, so their destination has been set to ''Hangout''.");
					this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
				}
			}
			else if (scheduleBlock2.destination == "Search Patrol")
			{
				this.Destinations[this.ID] = this.StudentManager.SearchPatrols.List[this.StudentID].GetChild(0);
			}
			else if (scheduleBlock2.destination == "Graffiti")
			{
				this.Destinations[this.ID] = this.StudentManager.GraffitiSpots[this.BullyID];
			}
			else if (scheduleBlock2.destination == "Bully")
			{
				this.Destinations[this.ID] = this.StudentManager.BullySpots[this.BullyID];
			}
			else if (scheduleBlock2.destination == "Mourn")
			{
				this.Destinations[this.ID] = this.StudentManager.MournSpots[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Clean")
			{
				this.Destinations[this.ID] = this.CleaningSpot.GetChild(0);
			}
			else if (scheduleBlock2.destination == "ShameSpot")
			{
				this.Destinations[this.ID] = this.StudentManager.ShameSpot;
			}
			else if (scheduleBlock2.destination == "Follow")
			{
				Debug.Log("Currently setting destination for block #" + this.ID);
				this.Destinations[this.ID] = this.StudentManager.Students[11].transform;
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
			else if (scheduleBlock2.destination == "Peek")
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
					if (this.Club == ClubType.Sports)
					{
						this.Destinations[this.ID] = this.StudentManager.Clubs.List[this.StudentID].GetChild(0);
					}
					else
					{
						this.Destinations[this.ID] = this.StudentManager.Clubs.List[this.StudentID];
					}
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
				}
			}
			else if (scheduleBlock2.destination == "Sulk")
			{
				this.Destinations[this.ID] = this.StudentManager.SulkSpots[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Sleuth")
			{
				this.Destinations[this.ID] = this.SleuthTarget;
			}
			else if (scheduleBlock2.destination == "Stalk")
			{
				this.Destinations[this.ID] = this.StalkTarget;
			}
			else if (scheduleBlock2.destination == "Sunbathe")
			{
				this.Destinations[this.ID] = this.StudentManager.FemaleStripSpot;
			}
			else if (scheduleBlock2.destination == "Shock")
			{
				this.Destinations[this.ID] = this.StudentManager.ShockedSpots[this.StudentID - 80];
			}
			else if (scheduleBlock2.destination == "Miyuki")
			{
				this.ClubMemberID = this.StudentID - 35;
				this.Destinations[this.ID] = this.StudentManager.MiyukiSpots[this.ClubMemberID].transform;
			}
			else if (scheduleBlock2.destination == "Practice")
			{
				if (this.Club > ClubType.None)
				{
					this.Destinations[this.ID] = this.StudentManager.PracticeSpots[this.ClubMemberID];
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
				}
			}
			else if (scheduleBlock2.destination == "Lyrics")
			{
				this.Destinations[this.ID] = this.StudentManager.LyricsSpot;
			}
			else if (scheduleBlock2.destination == "Meeting")
			{
				this.Destinations[this.ID] = this.StudentManager.MeetingSpots[this.StudentID].transform;
			}
			else if (scheduleBlock2.destination == "InfirmaryBed")
			{
				if (this.StudentManager.SedatedStudents == 0)
				{
					this.Destinations[this.ID] = this.StudentManager.MaleRestSpot;
					this.StudentManager.SedatedStudents++;
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.FemaleRestSpot;
				}
			}
			else if (scheduleBlock2.destination == "InfirmarySeat")
			{
				this.Destinations[this.ID] = this.StudentManager.InfirmarySeat;
			}
			else if (scheduleBlock2.destination == "Paint")
			{
				this.Destinations[this.ID] = this.StudentManager.FridaySpots[this.StudentID];
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
			else if (scheduleBlock2.action == "Peek")
			{
				this.Actions[this.ID] = StudentActionType.Peek;
			}
			else if (scheduleBlock2.action == "SocialSit")
			{
				this.Actions[this.ID] = StudentActionType.SitAndSocialize;
				if (this.Persona == PersonaType.Sleuth && this.Club == ClubType.None)
				{
					this.Actions[this.ID] = StudentActionType.Socializing;
				}
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
				if (this.OriginalClub == ClubType.Occult && this.Club == ClubType.None)
				{
					Debug.Log("This student's club disbanded, so their action has been set to ''Socialize''.");
					this.Actions[this.ID] = StudentActionType.Socializing;
				}
			}
			else if (scheduleBlock2.action == "Search Patrol")
			{
				this.Actions[this.ID] = StudentActionType.SearchPatrol;
			}
			else if (scheduleBlock2.action == "Gossip")
			{
				this.Actions[this.ID] = StudentActionType.Gossip;
			}
			else if (scheduleBlock2.action == "Graffiti")
			{
				this.Actions[this.ID] = StudentActionType.Graffiti;
			}
			else if (scheduleBlock2.action == "Bully")
			{
				this.Actions[this.ID] = StudentActionType.Bully;
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
			else if (scheduleBlock2.action == "Wait")
			{
				this.Actions[this.ID] = StudentActionType.Wait;
			}
			else if (scheduleBlock2.action == "Clean")
			{
				this.Actions[this.ID] = StudentActionType.Clean;
			}
			else if (scheduleBlock2.action == "Shamed")
			{
				this.Actions[this.ID] = StudentActionType.Shamed;
			}
			else if (scheduleBlock2.action == "Follow")
			{
				this.Actions[this.ID] = StudentActionType.Follow;
			}
			else if (scheduleBlock2.action == "Sulk")
			{
				this.Actions[this.ID] = StudentActionType.Sulk;
			}
			else if (scheduleBlock2.action == "Sleuth")
			{
				this.Actions[this.ID] = StudentActionType.Sleuth;
			}
			else if (scheduleBlock2.action == "Stalk")
			{
				this.Actions[this.ID] = StudentActionType.Stalk;
			}
			else if (scheduleBlock2.action == "Sketch")
			{
				this.Actions[this.ID] = StudentActionType.Sketch;
			}
			else if (scheduleBlock2.action == "Sunbathe")
			{
				this.Actions[this.ID] = StudentActionType.Sunbathe;
			}
			else if (scheduleBlock2.action == "Shock")
			{
				this.Actions[this.ID] = StudentActionType.Shock;
			}
			else if (scheduleBlock2.action == "Miyuki")
			{
				this.Actions[this.ID] = StudentActionType.Miyuki;
			}
			else if (scheduleBlock2.action == "Meeting")
			{
				this.Actions[this.ID] = StudentActionType.Meeting;
			}
			else if (scheduleBlock2.action == "Lyrics")
			{
				this.Actions[this.ID] = StudentActionType.Lyrics;
			}
			else if (scheduleBlock2.action == "Practice")
			{
				this.Actions[this.ID] = StudentActionType.Practice;
			}
			else if (scheduleBlock2.action == "Sew")
			{
				this.Actions[this.ID] = StudentActionType.Sew;
			}
			else if (scheduleBlock2.action == "Paint")
			{
				this.Actions[this.ID] = StudentActionType.Paint;
			}
			else if (scheduleBlock2.action == "Club")
			{
				if (this.Club > ClubType.None)
				{
					this.Actions[this.ID] = StudentActionType.ClubAction;
				}
				else if (this.OriginalClub == ClubType.Art)
				{
					this.Actions[this.ID] = StudentActionType.Sketch;
				}
				else
				{
					this.Actions[this.ID] = StudentActionType.Socializing;
				}
			}
			this.ID++;
		}
	}

	private void UpdateOutlines()
	{
		this.ID = 0;
		while (this.ID < this.Outlines.Length)
		{
			if (this.Outlines[this.ID] != null)
			{
				this.Outlines[this.ID].color = new Color(1f, 0.5f, 0f, 1f);
				this.Outlines[this.ID].enabled = true;
			}
			this.ID++;
		}
	}

	public void PickRandomAnim()
	{
		if (this.Grudge)
		{
			this.RandomAnim = this.BulliedIdleAnim;
		}
		else if (this.Club != ClubType.Delinquent)
		{
			this.RandomAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		}
		else
		{
			this.RandomAnim = this.DelinquentAnims[UnityEngine.Random.Range(0, this.DelinquentAnims.Length)];
		}
	}

	private void PickRandomGossipAnim()
	{
		if (this.Grudge)
		{
			this.RandomAnim = this.BulliedIdleAnim;
		}
		else
		{
			this.RandomGossipAnim = this.GossipAnims[UnityEngine.Random.Range(0, this.GossipAnims.Length)];
			if (this.Actions[this.Phase] == StudentActionType.Gossip && this.DistanceToPlayer < 3f)
			{
				if (!ConversationGlobals.GetTopicDiscovered(19))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(19, true);
				}
				if (!ConversationGlobals.GetTopicLearnedByStudent(19, this.StudentID))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
					ConversationGlobals.SetTopicLearnedByStudent(19, this.StudentID, true);
				}
			}
		}
	}

	private void PickRandomSleuthAnim()
	{
		if (!this.Sleuthing)
		{
			this.RandomSleuthAnim = this.SleuthAnims[UnityEngine.Random.Range(0, 3)];
		}
		else
		{
			this.RandomSleuthAnim = this.SleuthAnims[UnityEngine.Random.Range(3, 6)];
		}
	}

	private void BecomeTeacher()
	{
		base.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
		this.StudentManager.Teachers[this.Class] = this;
		if (this.Class != 1)
		{
			this.GradingPaper = this.StudentManager.FacultyDesks[this.Class];
			this.GradingPaper.LeftHand = this.LeftHand.parent;
			this.GradingPaper.Character = this.Character;
			this.GradingPaper.Teacher = this;
			this.SkirtCollider.gameObject.SetActive(false);
			this.LowPoly.MyMesh = this.LowPoly.TeacherMesh;
			this.PantyCollider.enabled = false;
		}
		if (this.Class > 1)
		{
			this.VisionDistance = 12f * this.Paranoia;
			base.name = "Teacher_" + this.Class.ToString();
			this.OriginalIdleAnim = "f02_idleShort_00";
			this.IdleAnim = "f02_idleShort_00";
		}
		else if (this.Class == 1)
		{
			this.VisionDistance = 12f * this.Paranoia;
			this.PatrolAnim = "f02_idle_00";
			base.name = "Nurse";
		}
		else
		{
			this.VisionDistance = 16f * this.Paranoia;
			this.PatrolAnim = "f02_stretch_00";
			base.name = "Coach";
			this.OriginalIdleAnim = "f02_tsunIdle_00";
			this.IdleAnim = "f02_tsunIdle_00";
		}
		this.StruggleAnim = "f02_teacherStruggleB_00";
		this.StruggleWonAnim = "f02_teacherStruggleWinB_00";
		this.StruggleLostAnim = "f02_teacherStruggleLoseB_00";
		this.OriginallyTeacher = true;
		this.Spawned = true;
		this.Teacher = true;
		base.gameObject.tag = "Untagged";
	}

	public void RemoveShoes()
	{
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.Cosmetic.SocksTexture;
			this.MyRenderer.materials[1].mainTexture = this.Cosmetic.SocksTexture;
		}
		else
		{
			this.MyRenderer.materials[this.Cosmetic.UniformID].mainTexture = this.Cosmetic.SocksTexture;
		}
	}

	public void BecomeRagdoll()
	{
		if (this.DrinkingFountain != null)
		{
			this.DrinkingFountain.Occupied = false;
		}
		if (!this.Ragdoll.enabled)
		{
			this.EmptyHands();
			if (this.Broken != null)
			{
				this.Broken.enabled = false;
				this.Broken.MyAudio.Stop();
			}
			if (this.Club == ClubType.Delinquent && this.MyWeapon != null)
			{
				this.MyWeapon.transform.parent = null;
				this.MyWeapon.MyCollider.enabled = true;
				this.MyWeapon.Prompt.enabled = true;
				Rigidbody component = this.MyWeapon.GetComponent<Rigidbody>();
				component.constraints = RigidbodyConstraints.None;
				component.isKinematic = false;
				component.useGravity = true;
				this.MyWeapon = null;
			}
			if (this.StudentManager.ChaseCamera == this.ChaseCamera)
			{
				this.StudentManager.ChaseCamera = null;
			}
			this.Countdown.gameObject.SetActive(false);
			this.ChaseCamera.SetActive(false);
			if (this.Club == ClubType.Council)
			{
				this.Police.CouncilDeath = true;
			}
			if (this.WillChase)
			{
				this.Yandere.Chasers--;
			}
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
				this.Police.SuicideStudent = base.gameObject;
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
			GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
			base.tag = "Blood";
			this.LowPoly.transform.parent = this.Hips;
			this.LowPoly.transform.localPosition = new Vector3(0f, -1f, 0f);
			this.LowPoly.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
	}

	public void GetWet()
	{
		this.TargetDistance = 1f;
		this.BeenSplashed = true;
		this.BatheFast = true;
		this.LiquidProjector.enabled = true;
		this.Emetic = false;
		this.Sedated = false;
		this.Headache = false;
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
			this.CharacterAnimation[this.SplashedAnim].speed = 1f;
			this.CharacterAnimation.CrossFade(this.SplashedAnim);
			this.Subtitle.UpdateLabel(this.SplashSubtitleType, 0, 1f);
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
				this.DistractionTarget.Octodog.SetActive(false);
				this.DistractionTarget.Distracted = false;
				this.Distracting = false;
				this.CanTalk = true;
			}
			if (this.Investigating)
			{
				this.Investigating = false;
			}
			this.SchoolwearUnavailable = true;
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

	public void SetSplashes(bool Bool)
	{
		this.ID = 0;
		while (this.ID < this.SplashEmitters.Length)
		{
			this.SplashEmitters[this.ID].gameObject.SetActive(Bool);
			this.ID++;
		}
	}

	private void StopMeeting()
	{
		this.Prompt.Label[0].text = "     Talk";
		this.Pathfinding.canSearch = true;
		this.Pathfinding.canMove = true;
		this.Drownable = false;
		this.Pushable = false;
		this.Meeting = false;
		this.MeetTimer = 0f;
		if (this.StudentID == 30)
		{
			this.StudentManager.OfferHelp.gameObject.SetActive(false);
			this.StudentManager.LoveManager.RivalWaiting = false;
		}
		else if (this.StudentID == 5)
		{
			this.StudentManager.FragileOfferHelp.gameObject.SetActive(false);
		}
	}

	public void Combust()
	{
		this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
		this.Police.Corpses++;
		GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
		base.tag = "Blood";
		this.Dying = true;
		this.SpawnAlarmDisc();
		this.Character.GetComponent<Animation>().CrossFade(this.BurningAnim);
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Ragdoll.BurningAnimation = true;
		this.Ragdoll.Disturbing = true;
		this.Ragdoll.Burning = true;
		this.WitnessedCorpse = false;
		this.Investigating = false;
		this.EatingSnack = false;
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
			this.EatingSnack = false;
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
		if (!this.Male)
		{
			this.MyRenderer.sharedMesh = this.TowelMesh;
			if (this.Club == ClubType.Bully)
			{
				this.Cosmetic.DeactivateBullyAccessories();
			}
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[0].mainTexture = this.TowelTexture;
			this.MyRenderer.materials[1].mainTexture = this.TowelTexture;
			this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
			this.Cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		}
		else
		{
			this.MyRenderer.sharedMesh = this.BaldNudeMesh;
			this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
			this.MyRenderer.materials[1].mainTexture = null;
			this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
		}
		this.Cosmetic.RemoveCensor();
		if (!this.AoT)
		{
			if (this.Male)
			{
				this.ID = 0;
				while (this.ID < this.CensorSteam.Length)
				{
					this.CensorSteam[this.ID].SetActive(true);
					this.ID++;
				}
			}
		}
		else if (!this.Male)
		{
			this.MyRenderer.sharedMesh = this.BaldNudeMesh;
			this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTexture;
			this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
			this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		}
		else
		{
			this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
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
		if (this.Attacher.gameObject.activeInHierarchy)
		{
			this.Attacher.RemoveAccessory();
		}
		if (this.LabcoatAttacher.enabled)
		{
			UnityEngine.Object.Destroy(this.LabcoatAttacher.newRenderer);
			this.LabcoatAttacher.enabled = false;
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
				if (this.Club == ClubType.Bully)
				{
					this.Cosmetic.RightWristband.SetActive(true);
					this.Cosmetic.LeftWristband.SetActive(true);
					this.Cosmetic.Bookbag.SetActive(true);
					this.Cosmetic.Hoodie.SetActive(true);
				}
			}
			else
			{
				this.Cosmetic.SetMaleUniform();
			}
		}
		else if (this.Schoolwear == 2)
		{
			if (this.Club == ClubType.Sports)
			{
				this.MyRenderer.sharedMesh = this.SwimmingTrunks;
				this.MyRenderer.SetBlendShapeWeight(0, (float)(20 * (6 - this.ClubMemberID)));
				this.MyRenderer.SetBlendShapeWeight(1, (float)(20 * (6 - this.ClubMemberID)));
				this.MyRenderer.materials[0].mainTexture = this.Cosmetic.Trunks[this.StudentID];
				this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
				this.MyRenderer.materials[2].mainTexture = this.Cosmetic.Trunks[this.StudentID];
			}
			else
			{
				this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
				if (!this.Male)
				{
					if (this.Club == ClubType.Bully)
					{
						this.MyRenderer.materials[0].mainTexture = this.Cosmetic.GanguroSwimsuitTextures[this.BullyID];
						this.MyRenderer.materials[1].mainTexture = this.Cosmetic.GanguroSwimsuitTextures[this.BullyID];
						this.Cosmetic.RightWristband.SetActive(false);
						this.Cosmetic.LeftWristband.SetActive(false);
						this.Cosmetic.Bookbag.SetActive(false);
						this.Cosmetic.Hoodie.SetActive(false);
					}
					else
					{
						this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
						this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
					}
					this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
					this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
					this.MyRenderer.materials[2].mainTexture = this.SwimsuitTexture;
				}
			}
		}
		else if (this.Schoolwear == 3)
		{
			this.MyRenderer.sharedMesh = this.GymUniform;
			if (!this.Male)
			{
				this.MyRenderer.materials[0].mainTexture = this.GymTexture;
				this.MyRenderer.materials[1].mainTexture = this.GymTexture;
				this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
				if (this.Club == ClubType.Bully)
				{
					this.Cosmetic.ActivateBullyAccessories();
				}
			}
			else
			{
				Debug.Log("A male is putting on a gym uniform.");
				this.MyRenderer.materials[0].mainTexture = this.GymTexture;
				this.MyRenderer.materials[1].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinColor];
				this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
			}
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
			if (this.Outlines[this.ID] != null && this.Outlines[this.ID].h != null)
			{
				this.Outlines[this.ID].h.ReinitMaterials();
			}
			this.ID++;
		}
	}

	public void AttackOnTitan()
	{
		this.CharacterAnimation.CrossFade(this.WalkAnim);
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
		if (!this.Male)
		{
			this.CurrentDestination = this.StudentManager.FemaleStripSpot;
			this.Pathfinding.target = this.StudentManager.FemaleStripSpot;
		}
		else
		{
			this.CurrentDestination = this.StudentManager.MaleStripSpot;
			this.Pathfinding.target = this.StudentManager.MaleStripSpot;
		}
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
		if (this.Struggling || this.Shoving || this.MurderSuicidePhase == 100 || this.StudentManager.CombatMinigame.Delinquent == this)
		{
			gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
		}
		if (this.Club == ClubType.Delinquent)
		{
			gameObject.GetComponent<AlarmDiscScript>().Delinquent = true;
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
			this.DistanceToDestination = 100f;
			this.ClubAttire = true;
			if (this.Club == ClubType.Art)
			{
				if (!this.Attacher.gameObject.activeInHierarchy)
				{
					this.Attacher.gameObject.SetActive(true);
				}
				else
				{
					this.Attacher.Start();
				}
			}
			else if (this.Club == ClubType.MartialArts)
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
			else if (this.Club == ClubType.Science)
			{
				this.WearLabCoat();
			}
			else if (this.Club == ClubType.Sports)
			{
				if (this.Clock.Period < 3)
				{
					this.MyRenderer.sharedMesh = this.GymUniform;
					this.MyRenderer.materials[0].mainTexture = this.GymTexture;
					this.MyRenderer.materials[1].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinID];
					this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
				}
				else
				{
					this.MyRenderer.sharedMesh = this.SwimmingTrunks;
					this.MyRenderer.SetBlendShapeWeight(0, (float)(20 * (6 - this.ClubMemberID)));
					this.MyRenderer.SetBlendShapeWeight(1, (float)(20 * (6 - this.ClubMemberID)));
					this.MyRenderer.materials[0].mainTexture = this.Cosmetic.Trunks[this.StudentID];
					this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
					this.MyRenderer.materials[2].mainTexture = this.Cosmetic.Trunks[this.StudentID];
					this.ClubAnim = "poolDive_00";
					this.ClubActivityPhase = 15;
					this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
				}
			}
			if (this.StudentID == 46)
			{
				this.Armband.transform.localPosition = new Vector3(this.Armband.transform.localPosition.x, this.Armband.transform.localPosition.y, 0.01f);
				this.Armband.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
			}
		}
		else
		{
			this.ClubAttire = false;
			if (this.Club == ClubType.Art)
			{
				this.Attacher.RemoveAccessory();
			}
			else if (this.Club == ClubType.Science)
			{
				this.WearLabCoat();
			}
			else
			{
				this.ChangeSchoolwear();
				if (this.StudentID == 46)
				{
					this.Armband.transform.localPosition = new Vector3(this.Armband.transform.localPosition.x, this.Armband.transform.localPosition.y, 0.012f);
					this.Armband.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
				}
				else if (this.StudentID == 47)
				{
					this.StudentManager.ConvoManager.Confirmed = false;
					this.ClubAnim = "idle_20";
				}
				else if (this.StudentID == 49)
				{
					this.StudentManager.ConvoManager.Confirmed = false;
					this.ClubAnim = "f02_idle_20";
				}
			}
		}
	}

	private void WearLabCoat()
	{
		if (!this.LabcoatAttacher.enabled)
		{
			this.MyRenderer.sharedMesh = this.HeadAndHands;
			this.LabcoatAttacher.enabled = true;
			if (!this.Male)
			{
				this.RightBreast.gameObject.name = "RightBreastRENAMED";
				this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
			}
			if (this.LabcoatAttacher.Initialized)
			{
				this.LabcoatAttacher.AttachAccessory();
			}
			if (!this.Male)
			{
				this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
				this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTexture;
				this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
				this.MyRenderer.materials[2].mainTexture = null;
				this.Cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
				this.SkirtCollider.gameObject.SetActive(false);
				this.PantyCollider.enabled = false;
			}
			else
			{
				this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
				this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
				this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
			}
		}
		else
		{
			if (!this.Male)
			{
				this.RightBreast.gameObject.name = "RightBreastRENAMED";
				this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
				this.SkirtCollider.gameObject.SetActive(true);
				this.PantyCollider.enabled = true;
			}
			UnityEngine.Object.Destroy(this.LabcoatAttacher.newRenderer);
			this.LabcoatAttacher.enabled = false;
			this.ChangeSchoolwear();
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
		this.Routine = false;
		this.StopPairing();
		if (!this.Sleuthing)
		{
			this.SmartPhone.SetActive(false);
		}
		this.OccultBook.SetActive(false);
		this.Scrubber.SetActive(false);
		this.Eraser.SetActive(false);
		this.Pen.SetActive(false);
		this.Pencil.SetActive(false);
		this.Sketchbook.SetActive(false);
		if (this.Club == ClubType.Gardening)
		{
			this.WateringCan.transform.parent = this.Hips;
			this.WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
			this.WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
		}
		else if (this.Club == ClubType.LightMusic)
		{
			if (this.StudentID == 51)
			{
				if (this.InstrumentBag[this.ClubMemberID].transform.parent == null)
				{
					this.Instruments[this.ClubMemberID].transform.parent = null;
					this.Instruments[this.ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
					this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
					this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
					this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
				}
				else
				{
					this.Instruments[this.ClubMemberID].SetActive(false);
				}
			}
			else
			{
				this.Instruments[this.ClubMemberID].SetActive(false);
			}
			this.Drumsticks[0].SetActive(false);
			this.Drumsticks[1].SetActive(false);
		}
		foreach (GameObject gameObject in this.ScienceProps)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
		foreach (GameObject gameObject2 in this.Fingerfood)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
		}
		if (!this.Yandere.ClubAccessories[7].activeInHierarchy || this.Club == ClubType.Delinquent)
		{
			this.CharacterAnimation.CrossFade(this.CameraAnims[1]);
		}
		else
		{
			if (this.Club == ClubType.Bully)
			{
				this.SmartPhone.SetActive(true);
			}
			this.CharacterAnimation.CrossFade(this.IdleAnim);
		}
	}

	private void LookForYandere()
	{
		if (!this.Yandere.Chased && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition))
		{
			this.ReportPhase++;
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
		this.ChameleonCheck();
		if (this.Chameleon)
		{
			this.Perception *= 0.5f;
		}
	}

	public void StopInvestigating()
	{
		this.Giggle = null;
		if (!this.Sleuthing)
		{
			this.CurrentDestination = this.Destinations[this.Phase];
			this.Pathfinding.target = this.Destinations[this.Phase];
			if (this.Actions[this.Phase] == StudentActionType.Sunbathe && this.SunbathePhase > 1)
			{
				this.CurrentDestination = this.StudentManager.SunbatheSpots[this.StudentID];
				this.Pathfinding.target = this.StudentManager.SunbatheSpots[this.StudentID];
			}
		}
		else
		{
			this.CurrentDestination = this.SleuthTarget;
			this.Pathfinding.target = this.SleuthTarget;
		}
		this.InvestigationTimer = 0f;
		this.InvestigationPhase = 0;
		if (!this.Hurry)
		{
			this.Pathfinding.speed = 1f;
		}
		else
		{
			this.Pathfinding.speed = 4f;
		}
		if (this.CurrentAction == StudentActionType.Clean)
		{
			this.SmartPhone.SetActive(false);
			this.Scrubber.SetActive(true);
			if (this.CleaningRole == 5)
			{
				this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
				this.Eraser.SetActive(true);
			}
		}
		this.YandereInnocent = false;
		this.Investigating = false;
		this.EatingSnack = false;
		this.DiscCheck = false;
		this.Routine = true;
	}

	public void ForgetGiggle()
	{
		this.Giggle = null;
		this.InvestigationTimer = 0f;
		this.InvestigationPhase = 0;
		this.YandereInnocent = false;
		this.Investigating = false;
		this.DiscCheck = false;
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
		bool flag2 = this.StudentID == 3 && yandereTargetID == 2;
		bool flag3 = this.StudentID == 2 && yandereTargetID == 3;
		bool flag4 = this.StudentID == 38 && yandereTargetID == 37;
		bool flag5 = this.StudentID == 37 && yandereTargetID == 38;
		bool flag6 = this.StudentID == 30 && yandereTargetID == 25;
		bool flag7 = this.StudentID == 25 && yandereTargetID == 30;
		bool flag8 = this.StudentID == 28 && yandereTargetID == 30;
		bool flag9 = false;
		bool flag10 = this.StudentID > 55 && this.StudentID < 61 && yandereTargetID > 55 && yandereTargetID < 61;
		if (this.Injured)
		{
			flag9 = (this.Club == ClubType.Delinquent && this.StudentManager.Students[yandereTargetID].Club == ClubType.Delinquent);
		}
		return flag || flag2 || flag3 || flag4 || flag5 || flag6 || flag7 || flag8 || flag9 || flag10;
	}

	private void Pose()
	{
		this.StudentManager.PoseMode.ChoosingAction = true;
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
		this.Posing = true;
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
			if (this.Bones[this.ID] != null)
			{
				this.Bones[this.ID].SetActive(false);
			}
			this.ID++;
		}
		if (this.Persona != PersonaType.PhoneAddict)
		{
			this.SmartPhone.SetActive(false);
		}
		this.Note.SetActive(false);
		if (!this.Slave)
		{
			UnityEngine.Object.Destroy(this.Broken);
		}
	}

	public void DetermineSenpaiReaction()
	{
		Debug.Log("We are now determining Senpai's reaction to Yandere-chan's behavior.");
		if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
		}
		else if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiWeaponReaction, 1, 4.5f);
		}
		else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
		}
		else if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
		}
		else if (this.Witnessed == StudentWitnessType.Weapon)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiWeaponReaction, 1, 4.5f);
		}
		else if (this.Witnessed == StudentWitnessType.Blood)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiBloodReaction, 1, 4.5f);
		}
		else if (this.Witnessed == StudentWitnessType.Insanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
		}
		else if (this.Witnessed == StudentWitnessType.Lewd)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiLewdReaction, 1, 4.5f);
		}
		else if (this.GameOverCause == GameOverType.Stalking)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiStalkingReaction, this.Concern, 4.5f);
		}
		else if (this.GameOverCause == GameOverType.Murder)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiMurderReaction, this.MurderReaction, 4.5f);
		}
		else if (this.GameOverCause == GameOverType.Violence)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiViolenceReaction, 1, 4.5f);
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
		ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[7];
		scheduleBlock3.destination = "Search Patrol";
		scheduleBlock3.action = "Search Patrol";
		this.GetDestinations();
	}

	public void TeleportToDestination()
	{
		if (this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time)
		{
			this.Phase++;
			if (this.Actions[this.Phase] == StudentActionType.Patrol)
			{
				this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
				this.Pathfinding.target = this.CurrentDestination;
			}
			else
			{
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.Destinations[this.Phase];
			}
			base.transform.position = this.CurrentDestination.position;
		}
	}

	public void GoCommitMurder()
	{
		this.StudentManager.MurderTakingPlace = true;
		if (!this.FragileSlave)
		{
			this.Yandere.EquippedWeapon.transform.parent = this.HipCollider.transform;
			this.Yandere.EquippedWeapon.transform.localPosition = Vector3.zero;
			this.Yandere.EquippedWeapon.transform.localScale = Vector3.zero;
			this.MyWeapon = this.Yandere.EquippedWeapon;
			this.MyWeapon.FingerprintID = this.StudentID;
			this.Yandere.EquippedWeapon = null;
			this.Yandere.Equipped = 0;
			this.StudentManager.UpdateStudents(0);
			this.Yandere.WeaponManager.UpdateLabels();
			this.Yandere.WeaponMenu.UpdateSprites();
			this.Yandere.WeaponWarning = false;
		}
		else
		{
			this.StudentManager.FragileWeapon.transform.parent = this.HipCollider.transform;
			this.StudentManager.FragileWeapon.transform.localPosition = Vector3.zero;
			this.StudentManager.FragileWeapon.transform.localScale = Vector3.zero;
			this.MyWeapon = this.StudentManager.FragileWeapon;
			this.MyWeapon.FingerprintID = this.StudentID;
			this.MyWeapon.MyCollider.enabled = false;
		}
		this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		this.CharacterAnimation.CrossFade("f02_brokenStandUp_00");
		if (this.HuntTarget != this)
		{
			this.DistanceToDestination = 100f;
			this.Broken.Hunting = true;
			this.TargetDistance = 1f;
			this.Routine = false;
			this.Hunting = true;
		}
		else
		{
			this.Broken.Done = true;
			this.Routine = false;
			this.Suicide = true;
		}
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	public void Shove()
	{
		if (!this.Yandere.Shoved && !this.Dying && !this.Yandere.Egg && !this.ShoeRemoval.enabled && !this.Yandere.Talking)
		{
			this.ForgetRadio();
			Debug.Log(this.Name + " is shoving Yandere-chan.");
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.StudentID == 86)
			{
				this.Subtitle.UpdateLabel(SubtitleType.Shoving, 1, 5f);
			}
			else if (this.StudentID == 87)
			{
				this.Subtitle.UpdateLabel(SubtitleType.Shoving, 2, 5f);
			}
			else if (this.StudentID == 88)
			{
				this.Subtitle.UpdateLabel(SubtitleType.Shoving, 3, 5f);
			}
			else if (this.StudentID == 89)
			{
				this.Subtitle.UpdateLabel(SubtitleType.Shoving, 4, 5f);
			}
			if (this.Yandere.Aiming)
			{
				this.Yandere.StopAiming();
			}
			if (this.Yandere.Laughing)
			{
				this.Yandere.StopLaughing();
			}
			base.transform.rotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
			this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
			this.CharacterAnimation[this.ShoveAnim].time = 0f;
			this.CharacterAnimation.CrossFade(this.ShoveAnim);
			this.FocusOnYandere = false;
			this.Investigating = false;
			this.Distracted = true;
			this.Alarmed = false;
			this.Routine = false;
			this.Shoving = true;
			this.NoTalk = false;
			this.Patience--;
			if (this.Club != ClubType.Council && this.Persona != PersonaType.Violent)
			{
				this.Patience = 999;
			}
			if (this.Patience < 1)
			{
				this.Yandere.CannotRecover = true;
			}
			if (this.ReturningMisplacedWeapon)
			{
				this.DropMisplacedWeapon();
			}
			this.Yandere.CharacterAnimation["f02_shoveA_01"].time = 0f;
			this.Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
			this.Yandere.YandereVision = false;
			this.Yandere.NearSenpai = false;
			this.Yandere.Degloving = false;
			this.Yandere.Flicking = false;
			this.Yandere.Punching = false;
			this.Yandere.CanMove = false;
			this.Yandere.Shoved = true;
			this.Yandere.EmptyHands();
			this.Yandere.GloveTimer = 0f;
			this.Yandere.h = 0f;
			this.Yandere.v = 0f;
			this.Yandere.ShoveSpeed = 2f;
			if (this.Distraction != null)
			{
				this.TargetedForDistraction = false;
				this.Pathfinding.speed = 1f;
				this.SpeechLines.Stop();
				this.Distraction = null;
				this.CanTalk = true;
			}
			if (this.Actions[this.Phase] != StudentActionType.Patrol)
			{
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.CurrentDestination;
			}
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
		}
	}

	public void PushYandereAway()
	{
		if (this.Yandere.Aiming)
		{
			this.Yandere.StopAiming();
		}
		if (this.Yandere.Laughing)
		{
			this.Yandere.StopLaughing();
		}
		this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
		this.Yandere.CharacterAnimation["f02_shoveA_01"].time = 0f;
		this.Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
		this.Yandere.YandereVision = false;
		this.Yandere.NearSenpai = false;
		this.Yandere.Degloving = false;
		this.Yandere.Flicking = false;
		this.Yandere.Punching = false;
		this.Yandere.CanMove = false;
		this.Yandere.Shoved = true;
		this.Yandere.EmptyHands();
		this.Yandere.GloveTimer = 0f;
		this.Yandere.h = 0f;
		this.Yandere.v = 0f;
		this.Yandere.ShoveSpeed = 2f;
	}

	public void Spray()
	{
		bool flag = false;
		if (this.Yandere.DelinquentFighting && !this.NoBreakUp && !this.StudentManager.CombatMinigame.Delinquent.WitnessedMurder)
		{
			flag = true;
		}
		if (!flag)
		{
			if (!this.Yandere.Sprayed && !this.Dying && !this.Yandere.Egg && !this.Yandere.Dumping && !this.Yandere.Bathing)
			{
				if (this.SprayTimer > 0f)
				{
					this.SprayTimer = Mathf.MoveTowards(this.SprayTimer, 0f, Time.deltaTime);
				}
				else
				{
					AudioSource.PlayClipAtPoint(this.PepperSpraySFX, base.transform.position);
					if (this.StudentID == 86)
					{
						this.Subtitle.UpdateLabel(SubtitleType.Spraying, 1, 5f);
					}
					else if (this.StudentID == 87)
					{
						this.Subtitle.UpdateLabel(SubtitleType.Spraying, 2, 5f);
					}
					else if (this.StudentID == 88)
					{
						this.Subtitle.UpdateLabel(SubtitleType.Spraying, 3, 5f);
					}
					else if (this.StudentID == 89)
					{
						this.Subtitle.UpdateLabel(SubtitleType.Spraying, 4, 5f);
					}
					if (this.Yandere.Aiming)
					{
						this.Yandere.StopAiming();
					}
					if (this.Yandere.Laughing)
					{
						this.Yandere.StopLaughing();
					}
					base.transform.rotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
					this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
					this.CharacterAnimation.CrossFade(this.SprayAnim);
					this.PepperSpray.SetActive(true);
					this.Distracted = true;
					this.Spraying = true;
					this.Alarmed = false;
					this.Routine = false;
					this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
					this.Yandere.YandereVision = false;
					this.Yandere.NearSenpai = false;
					this.Yandere.FollowHips = true;
					this.Yandere.Punching = false;
					this.Yandere.CanMove = false;
					this.Yandere.Sprayed = true;
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.StudentManager.YandereDying = true;
					this.StudentManager.StopMoving();
					this.Yandere.Blur.blurIterations = 1;
					this.Yandere.Jukebox.Volume = 0f;
					if (this.Yandere.DelinquentFighting)
					{
						this.StudentManager.CombatMinigame.Stop();
					}
				}
			}
			else if (!this.Yandere.Sprayed)
			{
				this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
			}
		}
		else
		{
			this.StudentManager.CombatMinigame.Delinquent.CharacterAnimation.Play("stopFighting_00");
			this.Yandere.CharacterAnimation.Play("f02_stopFighting_00");
			this.StudentManager.CombatMinigame.Path = 7;
			this.CharacterAnimation.Play(this.BreakUpAnim);
			this.BreakingUpFight = true;
			this.SprayTimer = 1f;
		}
		this.StudentManager.CombatMinigame.DisablePrompts();
		this.StudentManager.CombatMinigame.MyVocals.Stop();
		this.StudentManager.CombatMinigame.MyAudio.Stop();
		Time.timeScale = 1f;
	}

	private void DetermineCorpseLocation()
	{
		if (this.StudentManager.Reporter == null)
		{
			this.StudentManager.Reporter = this;
		}
		if (this.Teacher)
		{
			this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
			this.StudentManager.CorpseLocation.LookAt(new Vector3(base.transform.position.x, this.StudentManager.CorpseLocation.position.y, base.transform.position.z));
			this.StudentManager.CorpseLocation.Translate(this.StudentManager.CorpseLocation.forward);
			this.StudentManager.LowerCorpsePosition();
		}
		this.AssignCorpseGuardLocations();
	}

	private void DetermineBloodLocation()
	{
		if (this.StudentManager.BloodReporter == null)
		{
			this.StudentManager.BloodReporter = this;
		}
		if (this.Teacher)
		{
			this.StudentManager.BloodLocation.position = this.BloodPool.transform.position;
			this.StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, this.StudentManager.BloodLocation.position.y, base.transform.position.z));
			this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward);
			this.StudentManager.LowerBloodPosition();
		}
	}

	private void AssignCorpseGuardLocations()
	{
		this.StudentManager.CorpseGuardLocation[1].position = this.StudentManager.CorpseLocation.position + new Vector3(0f, 0f, 1f);
		this.LookAway(this.StudentManager.CorpseGuardLocation[1], this.StudentManager.CorpseLocation);
		this.StudentManager.CorpseGuardLocation[2].position = this.StudentManager.CorpseLocation.position + new Vector3(1f, 0f, 0f);
		this.LookAway(this.StudentManager.CorpseGuardLocation[2], this.StudentManager.CorpseLocation);
		this.StudentManager.CorpseGuardLocation[3].position = this.StudentManager.CorpseLocation.position + new Vector3(0f, 0f, -1f);
		this.LookAway(this.StudentManager.CorpseGuardLocation[3], this.StudentManager.CorpseLocation);
		this.StudentManager.CorpseGuardLocation[4].position = this.StudentManager.CorpseLocation.position + new Vector3(-1f, 0f, 0f);
		this.LookAway(this.StudentManager.CorpseGuardLocation[4], this.StudentManager.CorpseLocation);
	}

	private void AssignBloodGuardLocations()
	{
		this.StudentManager.BloodGuardLocation[1].position = this.StudentManager.BloodLocation.position + new Vector3(0f, 0f, 1f);
		this.LookAway(this.StudentManager.BloodGuardLocation[1], this.StudentManager.BloodLocation);
		this.StudentManager.BloodGuardLocation[2].position = this.StudentManager.BloodLocation.position + new Vector3(1f, 0f, 0f);
		this.LookAway(this.StudentManager.BloodGuardLocation[2], this.StudentManager.BloodLocation);
		this.StudentManager.BloodGuardLocation[3].position = this.StudentManager.BloodLocation.position + new Vector3(0f, 0f, -1f);
		this.LookAway(this.StudentManager.BloodGuardLocation[3], this.StudentManager.BloodLocation);
		this.StudentManager.BloodGuardLocation[4].position = this.StudentManager.BloodLocation.position + new Vector3(-1f, 0f, 0f);
		this.LookAway(this.StudentManager.BloodGuardLocation[4], this.StudentManager.BloodLocation);
	}

	private void AssignTeacherGuardLocations()
	{
		this.StudentManager.TeacherGuardLocation[1].position = this.StudentManager.CorpseLocation.position + new Vector3(0.75f, 0f, 0.75f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[1], this.StudentManager.CorpseLocation);
		this.StudentManager.TeacherGuardLocation[2].position = this.StudentManager.CorpseLocation.position + new Vector3(0.75f, 0f, -0.75f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[2], this.StudentManager.CorpseLocation);
		this.StudentManager.TeacherGuardLocation[3].position = this.StudentManager.CorpseLocation.position + new Vector3(-0.75f, 0f, -0.75f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[3], this.StudentManager.CorpseLocation);
		this.StudentManager.TeacherGuardLocation[4].position = this.StudentManager.CorpseLocation.position + new Vector3(-0.75f, 0f, 0.75f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[4], this.StudentManager.CorpseLocation);
		this.StudentManager.TeacherGuardLocation[5].position = this.StudentManager.CorpseLocation.position + new Vector3(0f, 0f, 0.5f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[5], this.StudentManager.CorpseLocation);
		this.StudentManager.TeacherGuardLocation[6].position = this.StudentManager.CorpseLocation.position + new Vector3(0f, 0f, -0.5f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[6], this.StudentManager.CorpseLocation);
	}

	private void LookAway(Transform T1, Transform T2)
	{
		T1.LookAt(T2);
		float y = T1.eulerAngles.y + 180f;
		T1.eulerAngles = new Vector3(T1.eulerAngles.x, y, T1.eulerAngles.z);
	}

	public void TurnToStone()
	{
		this.Cosmetic.RightEyeRenderer.material.mainTexture = this.Yandere.Stone;
		this.Cosmetic.LeftEyeRenderer.material.mainTexture = this.Yandere.Stone;
		this.Cosmetic.HairRenderer.material.mainTexture = this.Yandere.Stone;
		if (this.Cosmetic.HairRenderer.materials.Length > 1)
		{
			this.Cosmetic.HairRenderer.materials[1].mainTexture = this.Yandere.Stone;
		}
		this.Cosmetic.RightEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
		this.Cosmetic.LeftEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
		this.Cosmetic.HairRenderer.material.color = new Color(1f, 1f, 1f, 1f);
		this.MyRenderer.materials[0].mainTexture = this.Yandere.Stone;
		this.MyRenderer.materials[1].mainTexture = this.Yandere.Stone;
		this.MyRenderer.materials[2].mainTexture = this.Yandere.Stone;
		if (this.Teacher && this.Cosmetic.TeacherAccessories[8].activeInHierarchy)
		{
			this.MyRenderer.materials[3].mainTexture = this.Yandere.Stone;
		}
		if (this.PickPocket != null)
		{
			this.PickPocket.enabled = false;
			this.PickPocket.Prompt.Hide();
			this.PickPocket.Prompt.enabled = false;
		}
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		UnityEngine.Object.Destroy(this.DetectionMarker.gameObject);
		AudioSource.PlayClipAtPoint(this.Yandere.Petrify, base.transform.position + new Vector3(0f, 1f, 0f));
		UnityEngine.Object.Instantiate<GameObject>(this.Yandere.Pebbles, this.Hips.position, Quaternion.identity);
		this.Pathfinding.enabled = false;
		this.ShoeRemoval.enabled = false;
		this.CharacterAnimation.Stop();
		this.Prompt.enabled = false;
		this.SpeechLines.Stop();
		this.Prompt.Hide();
		base.enabled = false;
	}

	public void StopPairing()
	{
		if (this.Actions[this.Phase] != StudentActionType.Clean && this.Persona == PersonaType.PhoneAddict && !this.LostTeacherTrust)
		{
			this.WalkAnim = this.PhoneAnims[1];
		}
		this.Paired = false;
	}

	public void ChameleonCheck()
	{
		this.ChameleonBonus = 0f;
		this.Chameleon = false;
		if (this.Yandere != null && ((this.Yandere.Persona == YanderePersonaType.Scholarly && this.Persona == PersonaType.TeachersPet) || (this.Yandere.Persona == YanderePersonaType.Scholarly && this.Club == ClubType.Science) || (this.Yandere.Persona == YanderePersonaType.Scholarly && this.Club == ClubType.Art) || (this.Yandere.Persona == YanderePersonaType.Chill && this.Persona == PersonaType.SocialButterfly) || (this.Yandere.Persona == YanderePersonaType.Chill && this.Club == ClubType.Photography) || (this.Yandere.Persona == YanderePersonaType.Chill && this.Club == ClubType.Gaming) || (this.Yandere.Persona == YanderePersonaType.Confident && this.Persona == PersonaType.Heroic) || (this.Yandere.Persona == YanderePersonaType.Confident && this.Club == ClubType.MartialArts) || (this.Yandere.Persona == YanderePersonaType.Elegant && this.Club == ClubType.Drama) || (this.Yandere.Persona == YanderePersonaType.Girly && this.Persona == PersonaType.SocialButterfly) || (this.Yandere.Persona == YanderePersonaType.Girly && this.Club == ClubType.Cooking) || (this.Yandere.Persona == YanderePersonaType.Graceful && this.Club == ClubType.Gardening) || (this.Yandere.Persona == YanderePersonaType.Haughty && this.Club == ClubType.Bully) || (this.Yandere.Persona == YanderePersonaType.Lively && this.Persona == PersonaType.SocialButterfly) || (this.Yandere.Persona == YanderePersonaType.Lively && this.Club == ClubType.LightMusic) || (this.Yandere.Persona == YanderePersonaType.Lively && this.Club == ClubType.Sports) || (this.Yandere.Persona == YanderePersonaType.Shy && this.Persona == PersonaType.Loner) || (this.Yandere.Persona == YanderePersonaType.Shy && this.Club == ClubType.Occult) || (this.Yandere.Persona == YanderePersonaType.Tough && this.Persona == PersonaType.Spiteful) || (this.Yandere.Persona == YanderePersonaType.Tough && this.Club == ClubType.Delinquent)))
		{
			Debug.Log("Chameleon is true!");
			this.ChameleonBonus = this.VisionDistance * 0.5f;
			this.Chameleon = true;
		}
	}

	private void PhoneAddictGameOver()
	{
		if (!this.Yandere.Lost)
		{
			this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_down_22");
			this.Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(true);
			this.Yandere.RPGCamera.enabled = false;
			this.Yandere.Jukebox.GameOver();
			this.Yandere.enabled = false;
			this.Yandere.EmptyHands();
			this.Countdown.gameObject.SetActive(false);
			this.ChaseCamera.SetActive(false);
			this.Police.Heartbroken.Exposed = true;
			this.StudentManager.StopMoving();
			this.Fleeing = false;
		}
	}

	private void EndAlarm()
	{
		if (this.ReturnToRoutineAfter)
		{
			this.CurrentDestination = this.Destinations[this.Phase];
			this.Pathfinding.target = this.Destinations[this.Phase];
			this.ReturnToRoutineAfter = false;
		}
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
		if (this.Persona == PersonaType.PhoneAddict)
		{
			this.SmartPhone.SetActive(true);
		}
		this.FocusOnYandere = false;
		this.DiscCheck = false;
		this.Alarmed = false;
		this.Reacted = false;
		this.Hesitation = 0f;
		this.AlarmTimer = 0f;
		if (this.WitnessedCorpse)
		{
			this.PersonaReaction();
		}
		else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
		{
			if (this.Following)
			{
				this.Hearts.emission.enabled = false;
				this.Yandere.Followers--;
				this.Following = false;
			}
			this.CharacterAnimation.CrossFade(this.WalkAnim);
			this.CurrentDestination = this.BloodPool;
			this.Pathfinding.target = this.BloodPool;
			this.Pathfinding.canSearch = true;
			this.Pathfinding.canMove = true;
			this.Pathfinding.speed = 1f;
			this.InvestigatingBloodPool = true;
			this.Routine = false;
		}
		else if (!this.Following && !this.Wet && !this.Investigating)
		{
			this.Routine = true;
		}
		if (this.ResumeDistracting)
		{
			this.CharacterAnimation.CrossFade(this.WalkAnim);
			this.Distracting = true;
			this.Routine = false;
		}
		if (this.CurrentAction == StudentActionType.Clean)
		{
			this.SmartPhone.SetActive(false);
			this.Scrubber.SetActive(true);
			if (this.CleaningRole == 5)
			{
				this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
				this.Eraser.SetActive(true);
			}
		}
	}

	public void GetSleuthTarget()
	{
		this.TargetDistance = 2f;
		this.SleuthID++;
		if (this.SleuthID < 98)
		{
			if (this.StudentManager.Students[this.SleuthID] == null)
			{
				this.GetSleuthTarget();
			}
			else if (!this.StudentManager.Students[this.SleuthID].gameObject.activeInHierarchy)
			{
				this.GetSleuthTarget();
			}
			else
			{
				this.SleuthTarget = this.StudentManager.Students[this.SleuthID].transform;
				this.Pathfinding.target = this.SleuthTarget;
				this.CurrentDestination = this.SleuthTarget;
			}
		}
		else if (this.SleuthID == 98)
		{
			if (ClubGlobals.Club == ClubType.Photography)
			{
				this.SleuthID = 0;
				this.GetSleuthTarget();
			}
			else
			{
				this.SleuthTarget = this.Yandere.transform;
				this.Pathfinding.target = this.SleuthTarget;
				this.CurrentDestination = this.SleuthTarget;
			}
		}
		else
		{
			this.SleuthID = 0;
			this.GetSleuthTarget();
		}
	}

	public void GetFoodTarget()
	{
		this.Attempts++;
		if (this.Attempts >= 100)
		{
			this.Phase++;
		}
		else
		{
			this.SleuthID++;
			if (this.SleuthID < 90)
			{
				if (this.SleuthID == this.StudentID)
				{
					this.GetFoodTarget();
				}
				else if (this.StudentManager.Students[this.SleuthID] == null)
				{
					this.GetFoodTarget();
				}
				else if (!this.StudentManager.Students[this.SleuthID].gameObject.activeInHierarchy)
				{
					this.GetFoodTarget();
				}
				else if (this.StudentManager.Students[this.SleuthID].CurrentAction == StudentActionType.SitAndEatBento || this.StudentManager.Students[this.SleuthID].Club == ClubType.Cooking || this.StudentManager.Students[this.SleuthID].Club == ClubType.Delinquent || this.StudentManager.Students[this.SleuthID].Club == ClubType.Sports || this.StudentManager.Students[this.SleuthID].TargetedForDistraction || this.StudentManager.Students[this.SleuthID].ClubActivityPhase >= 16 || this.StudentManager.Students[this.SleuthID].InEvent || !this.StudentManager.Students[this.SleuthID].Routine || this.StudentManager.Students[this.SleuthID].Posing || this.StudentManager.Students[this.SleuthID].Slave || this.StudentManager.Students[this.SleuthID].Wet || (this.StudentManager.Students[this.SleuthID].Club == ClubType.LightMusic && this.StudentManager.PracticeMusic.isPlaying))
				{
					this.GetFoodTarget();
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.WalkAnim);
					this.DistractionTarget = this.StudentManager.Students[this.SleuthID];
					this.DistractionTarget.TargetedForDistraction = true;
					this.SleuthTarget = this.StudentManager.Students[this.SleuthID].transform;
					this.Pathfinding.target = this.SleuthTarget;
					this.CurrentDestination = this.SleuthTarget;
					this.TargetDistance = 0.75f;
					this.DistractTimer = 8f;
					this.Distracting = true;
					this.CanTalk = false;
					this.Routine = false;
					this.Attempts = 0;
				}
			}
			else
			{
				this.SleuthID = 0;
				this.GetFoodTarget();
			}
		}
	}

	private void PhoneAddictCameraUpdate()
	{
		if (this.SmartPhone.transform.parent != null)
		{
			this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			this.SmartPhone.transform.localPosition = new Vector3(0f, 0.005f, -0.01f);
			this.SmartPhone.transform.localEulerAngles = new Vector3(7.33333f, -154f, 173.666656f);
			this.SmartPhone.SetActive(true);
			if (this.Sleuthing)
			{
				if (this.AlarmTimer < 2f)
				{
					this.AlarmTimer = 2f;
					this.ScaredAnim = this.SleuthReactAnim;
					this.SprintAnim = this.SleuthReportAnim;
					this.CharacterAnimation.CrossFade(this.ScaredAnim);
				}
				if (!this.CameraFlash.activeInHierarchy && this.CharacterAnimation[this.ScaredAnim].time > 2f)
				{
					this.CameraFlash.SetActive(true);
					if (this.Yandere.Mask != null)
					{
						this.Countdown.MaskedPhoto = true;
					}
				}
			}
			else
			{
				this.ScaredAnim = this.PhoneAnims[4];
				this.CharacterAnimation.CrossFade(this.ScaredAnim);
				if (!this.CameraFlash.activeInHierarchy && (double)this.CharacterAnimation[this.ScaredAnim].time > 3.66666)
				{
					this.CameraFlash.SetActive(true);
					if (this.Yandere.Mask != null)
					{
						this.Countdown.MaskedPhoto = true;
					}
					else if (this.Grudge)
					{
						this.Police.PhotoEvidence++;
						this.PhotoEvidence = true;
					}
				}
			}
		}
	}

	private void ReturnToRoutine()
	{
		if (this.Actions[this.Phase] == StudentActionType.Patrol)
		{
			this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
			this.Pathfinding.target = this.CurrentDestination;
		}
		else
		{
			this.CurrentDestination = this.Destinations[this.Phase];
			this.Pathfinding.target = this.Destinations[this.Phase];
		}
		this.BreakingUpFight = false;
		this.WitnessedMurder = false;
		this.Pathfinding.speed = 1f;
		this.Prompt.enabled = true;
		this.Alarmed = false;
		this.Fleeing = false;
		this.Routine = true;
		this.Grudge = false;
	}

	public void EmptyHands()
	{
		bool flag = false;
		if ((this.SentHome && this.SmartPhone.activeInHierarchy) || this.PhotoEvidence || (this.Persona == PersonaType.PhoneAddict && !this.Dying))
		{
			flag = true;
		}
		if ((this.WitnessedMurder || this.WitnessedCorpse) && this.MyPlate != null)
		{
			this.MyPlate.gameObject.SetActive(false);
		}
		if (this.Club == ClubType.Gardening)
		{
			this.WateringCan.transform.parent = this.Hips;
			this.WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
			this.WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
		}
		if (this.Club == ClubType.LightMusic)
		{
			if (this.StudentID == 51)
			{
				if (this.InstrumentBag[this.ClubMemberID].transform.parent == null)
				{
					this.Instruments[this.ClubMemberID].transform.parent = null;
					this.Instruments[this.ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
					this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
					this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
					this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
				}
				else
				{
					this.Instruments[this.ClubMemberID].SetActive(false);
				}
			}
			else
			{
				this.Instruments[this.ClubMemberID].SetActive(false);
			}
			this.Drumsticks[0].SetActive(false);
			this.Drumsticks[1].SetActive(false);
			this.AirGuitar.Stop();
		}
		if (!this.Male)
		{
			this.Handkerchief.SetActive(false);
			this.Cigarette.SetActive(false);
			this.Lighter.SetActive(false);
		}
		else
		{
			this.PinkSeifuku.SetActive(false);
		}
		if (!flag)
		{
			this.SmartPhone.SetActive(false);
		}
		if (this.BagOfChips != null)
		{
			this.BagOfChips.SetActive(false);
		}
		this.Chopsticks[0].SetActive(false);
		this.Chopsticks[1].SetActive(false);
		this.Sketchbook.SetActive(false);
		this.OccultBook.SetActive(false);
		this.Paintbrush.SetActive(false);
		this.EventBook.SetActive(false);
		this.Scrubber.SetActive(false);
		this.Octodog.SetActive(false);
		this.Palette.SetActive(false);
		this.Eraser.SetActive(false);
		this.Pencil.SetActive(false);
		this.Bento.SetActive(false);
		this.Pen.SetActive(false);
		foreach (GameObject gameObject in this.ScienceProps)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
		foreach (GameObject gameObject2 in this.Fingerfood)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
		}
	}

	public void UpdateAnimLayers()
	{
		this.CharacterAnimation[this.LeanAnim].speed += (float)this.StudentID * 0.01f;
		this.CharacterAnimation[this.ConfusedSitAnim].speed += (float)this.StudentID * 0.01f;
		this.CharacterAnimation[this.WalkAnim].time = UnityEngine.Random.Range(0f, this.CharacterAnimation[this.WalkAnim].length);
		this.CharacterAnimation[this.WetAnim].layer = 9;
		this.CharacterAnimation.Play(this.WetAnim);
		this.CharacterAnimation[this.WetAnim].weight = 0f;
		if (!this.Male)
		{
			this.CharacterAnimation[this.StripAnim].speed = 1.5f;
			this.CharacterAnimation[this.GameAnim].speed = 2f;
			this.CharacterAnimation["f02_moLipSync_00"].layer = 9;
			this.CharacterAnimation.Play("f02_moLipSync_00");
			this.CharacterAnimation["f02_moLipSync_00"].weight = 0f;
			this.CharacterAnimation["f02_topHalfTexting_00"].layer = 8;
			this.CharacterAnimation.Play("f02_topHalfTexting_00");
			this.CharacterAnimation["f02_topHalfTexting_00"].weight = 0f;
			this.CharacterAnimation[this.CarryAnim].layer = 7;
			this.CharacterAnimation.Play(this.CarryAnim);
			this.CharacterAnimation[this.CarryAnim].weight = 0f;
			this.CharacterAnimation[this.SocialSitAnim].layer = 6;
			this.CharacterAnimation.Play(this.SocialSitAnim);
			this.CharacterAnimation[this.SocialSitAnim].weight = 0f;
			this.CharacterAnimation[this.ShyAnim].layer = 5;
			this.CharacterAnimation.Play(this.ShyAnim);
			this.CharacterAnimation[this.ShyAnim].weight = 0f;
			this.CharacterAnimation[this.FistAnim].layer = 4;
			this.CharacterAnimation[this.FistAnim].weight = 0f;
			this.CharacterAnimation[this.BentoAnim].layer = 3;
			this.CharacterAnimation.Play(this.BentoAnim);
			this.CharacterAnimation[this.BentoAnim].weight = 0f;
			this.CharacterAnimation[this.AngryFaceAnim].layer = 2;
			this.CharacterAnimation.Play(this.AngryFaceAnim);
			this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
			this.CharacterAnimation["f02_wetIdle_00"].speed = 1.25f;
			this.CharacterAnimation["f02_sleuthScan_00"].speed = 1.4f;
		}
		else
		{
			this.CharacterAnimation[this.ConfusedSitAnim].speed *= -1f;
			this.CharacterAnimation[this.ToughFaceAnim].layer = 7;
			this.CharacterAnimation.Play(this.ToughFaceAnim);
			this.CharacterAnimation[this.ToughFaceAnim].weight = 0f;
			this.CharacterAnimation[this.SocialSitAnim].layer = 6;
			this.CharacterAnimation.Play(this.SocialSitAnim);
			this.CharacterAnimation[this.SocialSitAnim].weight = 0f;
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
			this.CharacterAnimation["sleuthScan_00"].speed = 1.4f;
		}
		if (this.Persona == PersonaType.Sleuth)
		{
			this.CharacterAnimation[this.WalkAnim].time = UnityEngine.Random.Range(0f, this.CharacterAnimation[this.WalkAnim].length);
		}
		if (this.Club == ClubType.Bully)
		{
			if (!StudentGlobals.GetStudentBroken(this.StudentID) && this.BullyID > 1)
			{
				this.CharacterAnimation["f02_bullyLaugh_00"].speed = 0.9f + (float)this.BullyID * 0.1f;
			}
		}
		else if (this.Club == ClubType.Delinquent)
		{
			this.CharacterAnimation[this.WalkAnim].time = UnityEngine.Random.Range(0f, this.CharacterAnimation[this.WalkAnim].length);
			this.CharacterAnimation[this.LeanAnim].speed = 0.5f;
		}
		else if (this.Club == ClubType.Council)
		{
			this.CharacterAnimation["f02_faceCouncil" + this.Suffix + "_00"].layer = 10;
			this.CharacterAnimation.Play("f02_faceCouncil" + this.Suffix + "_00");
		}
		else if (this.Club == ClubType.Gaming)
		{
			this.CharacterAnimation[this.VictoryAnim].speed -= 0.1f * (float)(this.StudentID - 36);
			this.CharacterAnimation[this.VictoryAnim].speed = 0.866666f;
		}
		else if (this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
		{
			Debug.Log("This is a cooking club member, and they should be performing the ''PlateWalkAnim''.");
			this.WalkAnim = this.PlateWalkAnim;
		}
		if (this.StudentID == 36)
		{
			this.CharacterAnimation[this.ToughFaceAnim].weight = 1f;
		}
		else if (this.StudentID == 66)
		{
			this.CharacterAnimation[this.ToughFaceAnim].weight = 1f;
		}
	}

	private void SpawnDetectionMarker()
	{
		this.DetectionMarker = UnityEngine.Object.Instantiate<GameObject>(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
		this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
		this.DetectionMarker.Target = base.transform;
	}

	public void EquipCleaningItems()
	{
		if (this.CurrentAction == StudentActionType.Clean)
		{
			if (this.Persona == PersonaType.PhoneAddict || this.Persona == PersonaType.Sleuth)
			{
				this.WalkAnim = this.OriginalWalkAnim;
			}
			this.SmartPhone.SetActive(false);
			this.Scrubber.SetActive(true);
			if (this.CleaningRole == 5)
			{
				this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
				this.Eraser.SetActive(true);
			}
			if (this.StudentID == 9 || this.StudentID == 60)
			{
				this.WalkAnim = this.OriginalOriginalWalkAnim;
			}
		}
	}

	public void DetermineWhatWasWitnessed()
	{
		Debug.Log("We are now determining what " + this.Name + " witnessed.");
		if (this.Witnessed == StudentWitnessType.Murder)
		{
			Debug.Log("No need to go through the entire chain. We already know that this character witnessed murder.");
			this.Concern = 5;
		}
		else if (this.YandereVisible)
		{
			bool flag = false;
			if (this.Yandere.Bloodiness > 0f && !this.Yandere.Paint)
			{
				flag = true;
			}
			bool flag2 = this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious;
			bool flag3 = this.Yandere.PickUp != null && this.Yandere.PickUp.Suspicious;
			bool flag4 = this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null;
			bool flag5 = this.Yandere.PickUp != null && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence;
			int concern = this.Concern;
			if (flag2)
			{
				this.WeaponToTakeAway = this.Yandere.EquippedWeapon;
			}
			if (this.Yandere.Rummaging || this.Yandere.TheftTimer > 0f)
			{
				Debug.Log("Saw Yandere-chan stealing.");
				this.Witnessed = StudentWitnessType.Theft;
				this.Concern = 5;
			}
			else if (this.Yandere.Pickpocketing || this.Yandere.Caught)
			{
				Debug.Log("Saw Yandere-chan pickpocketing.");
				this.Yandere.Pickpocketing = false;
				this.Witnessed = StudentWitnessType.Pickpocketing;
				this.Concern = 5;
				if (this.Teacher)
				{
					this.Witnessed = StudentWitnessType.Theft;
				}
			}
			else if (flag2 && flag && this.Yandere.Sanity < 33.333f)
			{
				this.Witnessed = StudentWitnessType.WeaponAndBloodAndInsanity;
				this.RepLoss = 30f;
				this.Concern = 5;
			}
			else if (flag2 && this.Yandere.Sanity < 33.333f)
			{
				this.Witnessed = StudentWitnessType.WeaponAndInsanity;
				this.RepLoss = 20f;
				this.Concern = 5;
			}
			else if (flag && this.Yandere.Sanity < 33.333f)
			{
				this.Witnessed = StudentWitnessType.BloodAndInsanity;
				this.RepLoss = 20f;
				this.Concern = 5;
			}
			else if (flag2 && flag)
			{
				this.Witnessed = StudentWitnessType.WeaponAndBlood;
				this.RepLoss = 20f;
				this.Concern = 5;
			}
			else if (flag2)
			{
				Debug.Log("Saw Yandere-chan with a weapon.");
				this.WeaponWitnessed = this.Yandere.EquippedWeapon.WeaponID;
				this.Witnessed = StudentWitnessType.Weapon;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (flag3)
			{
				if (this.Yandere.PickUp.CleaningProduct)
				{
					this.Witnessed = StudentWitnessType.CleaningItem;
				}
				else if (this.Teacher)
				{
					this.Witnessed = StudentWitnessType.Suspicious;
				}
				else
				{
					this.Witnessed = StudentWitnessType.Weapon;
				}
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (flag)
			{
				this.Witnessed = StudentWitnessType.Blood;
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
				this.Witnessed = StudentWitnessType.Insanity;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (this.Yandere.Lewd)
			{
				this.Witnessed = StudentWitnessType.Lewd;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if ((this.Yandere.Laughing && this.Yandere.LaughIntensity > 15f) || this.Yandere.Stance.Current == StanceType.Crouching || this.Yandere.Stance.Current == StanceType.Crawling)
			{
				this.Witnessed = StudentWitnessType.Insanity;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (this.Yandere.Poisoning)
			{
				this.Witnessed = StudentWitnessType.Poisoning;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (this.Yandere.Trespassing && this.StudentID > 1)
			{
				this.Witnessed = ((!this.Private) ? StudentWitnessType.Trespassing : StudentWitnessType.Interruption);
				this.Witness = false;
				this.Concern++;
			}
			else if (this.Yandere.NearSenpai)
			{
				this.Witnessed = StudentWitnessType.Stalking;
				this.Concern++;
			}
			else if (this.Yandere.Eavesdropping)
			{
				if (this.StudentID == 1)
				{
					this.Witnessed = StudentWitnessType.Stalking;
					this.Concern++;
				}
				else
				{
					if (this.InEvent)
					{
						this.EventInterrupted = true;
					}
					this.Witnessed = StudentWitnessType.Eavesdropping;
					this.RepLoss = 10f;
					this.Concern = 5;
				}
			}
			else if (this.Yandere.Aiming)
			{
				this.Witnessed = StudentWitnessType.Stalking;
				this.Concern++;
			}
			else if (this.Yandere.DelinquentFighting)
			{
				this.Witnessed = StudentWitnessType.Violence;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (this.Yandere.PickUp != null && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence)
			{
				this.Witnessed = StudentWitnessType.HoldingBloodyClothing;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (flag4 || flag5)
			{
				this.Witnessed = StudentWitnessType.CoverUp;
			}
			if (this.StudentID == 1 && this.Witnessed == StudentWitnessType.Insanity && (this.Yandere.Stance.Current == StanceType.Crouching || this.Yandere.Stance.Current == StanceType.Crawling))
			{
				this.Witnessed = StudentWitnessType.Stalking;
				this.Concern = concern;
				this.Concern++;
			}
		}
		else
		{
			Debug.Log(this.Name + " is reacting to something other than Yandere-chan.");
			if (this.WitnessedLimb)
			{
				this.Witnessed = StudentWitnessType.SeveredLimb;
			}
			else if (this.WitnessedBloodyWeapon)
			{
				this.Witnessed = StudentWitnessType.BloodyWeapon;
			}
			else if (this.WitnessedBloodPool)
			{
				this.Witnessed = StudentWitnessType.BloodPool;
			}
			else if (this.WitnessedWeapon)
			{
				this.Witnessed = StudentWitnessType.DroppedWeapon;
			}
			else if (this.WitnessedCorpse)
			{
				this.Witnessed = StudentWitnessType.Corpse;
			}
			else
			{
				Debug.Log("Apparently, we didn't even see anything! 1");
				this.Witnessed = StudentWitnessType.None;
				this.DiscCheck = true;
				this.Witness = false;
			}
		}
		if (this.Concern == 5 && this.Club == ClubType.Council)
		{
			Debug.Log("A member of the student council is being transformed into a teacher.");
			this.Teacher = true;
		}
	}

	public void DetermineTeacherSubtitle()
	{
		Debug.Log("We are now determining what line of dialogue the teacher should say.");
		if (this.Witnessed == StudentWitnessType.Murder)
		{
			if (this.WitnessedMindBrokenMurder)
			{
				this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 4, 6f);
			}
			else
			{
				this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 1, 6f);
			}
			this.GameOverCause = GameOverType.Murder;
			this.WitnessedMurder = true;
		}
		else if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			this.GameOverCause = GameOverType.Insanity;
			this.WitnessedMurder = true;
		}
		else if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponHostile, 1, 6f);
			this.GameOverCause = GameOverType.Weapon;
			this.WitnessedMurder = true;
		}
		else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			this.GameOverCause = GameOverType.Insanity;
			this.WitnessedMurder = true;
		}
		else if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			this.GameOverCause = GameOverType.Insanity;
			this.WitnessedMurder = true;
		}
		else if (this.Witnessed == StudentWitnessType.Weapon)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponHostile, 1, 6f);
			this.GameOverCause = GameOverType.Weapon;
			this.WitnessedMurder = true;
		}
		else if (this.Witnessed == StudentWitnessType.Blood)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherBloodHostile, 1, 6f);
			this.GameOverCause = GameOverType.Blood;
			this.WitnessedMurder = true;
		}
		else if (this.Witnessed == StudentWitnessType.Insanity || this.Witnessed == StudentWitnessType.Poisoning)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			this.GameOverCause = GameOverType.Insanity;
			this.WitnessedMurder = true;
		}
		else if (this.Witnessed == StudentWitnessType.Lewd)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherLewdReaction, 1, 6f);
			this.GameOverCause = GameOverType.Lewd;
		}
		else if (this.Witnessed == StudentWitnessType.Trespassing)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, this.Concern, 5f);
		}
		else if (this.Witnessed == StudentWitnessType.Corpse)
		{
			Debug.Log("A teacher just discovered a corpse.");
			this.DetermineCorpseLocation();
			this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseReaction, 1, 3f);
			this.Police.Called = true;
		}
		else if (this.Witnessed == StudentWitnessType.CoverUp)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherCoverUpHostile, 1, 6f);
			this.GameOverCause = GameOverType.Blood;
			this.WitnessedMurder = true;
		}
		else if (this.Witnessed == StudentWitnessType.CleaningItem)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
			this.GameOverCause = GameOverType.Insanity;
		}
	}
}
