﻿using System;
using System.Collections;
using HighlightingSystem;
using Pathfinding;
using UnityEngine;
using XInputDotNetPure;

public class YandereScript : MonoBehaviour
{
	public Quaternion targetRotation;

	private Vector3 targetDirection;

	private GameObject NewTrail;

	public int AccessoryID;

	private int ID;

	public FootprintSpawnerScript RightFootprintSpawner;

	public FootprintSpawnerScript LeftFootprintSpawner;

	public ColorCorrectionCurves YandereColorCorrection;

	public ColorCorrectionCurves ColorCorrection;

	public SelectiveGrayscale SelectGrayscale;

	public HighlightingRenderer HighlightingR;

	public HighlightingBlitter HighlightingB;

	public AmbientObscurance Obscurance;

	public DepthOfField34 DepthOfField;

	public Vignetting Vignette;

	public Blur Blur;

	public NotificationManagerScript NotificationManager;

	public ObstacleDetectorScript ObstacleDetector;

	public RiggedAccessoryAttacher GloveAttacher;

	public RiggedAccessoryAttacher PantyAttacher;

	public AccessoryGroupScript AccessoryGroup;

	public DumpsterHandleScript DumpsterHandle;

	public PhonePromptBarScript PhonePromptBar;

	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public AttackManagerScript AttackManager;

	public CameraEffectsScript CameraEffects;

	public WeaponManagerScript WeaponManager;

	public YandereShowerScript YandereShower;

	public PromptParentScript PromptParent;

	public SplashCameraScript SplashCamera;

	public SWP_HeartRateMonitor HeartRate;

	public GenericBentoScript TargetBento;

	public LoveManagerScript LoveManager;

	public StruggleBarScript StruggleBar;

	public RummageSpotScript RummageSpot;

	public IncineratorScript Incinerator;

	public InputDeviceScript InputDevice;

	public MusicCreditScript MusicCredit;

	public PauseScreenScript PauseScreen;

	public SmartphoneScript PhoneToCrush;

	public WoodChipperScript WoodChipper;

	public RagdollScript CurrentRagdoll;

	public StudentScript TargetStudent;

	public WeaponMenuScript WeaponMenu;

	public PromptScript NearestPrompt;

	public ContainerScript Container;

	public InventoryScript Inventory;

	public TallLockerScript MyLocker;

	public PromptBarScript PromptBar;

	public TranqCaseScript TranqCase;

	public LocationScript Location;

	public SubtitleScript Subtitle;

	public UITexture SanitySmudges;

	public StudentScript Follower;

	public DemonScript EmptyDemon;

	public UIPanel DetectionPanel;

	public JukeboxScript Jukebox;

	public OutlineScript Outline;

	public StudentScript Pursuer;

	public ShutterScript Shutter;

	public Collider HipCollider;

	public UISprite ProgressBar;

	public RPG_Camera RPGCamera;

	public BucketScript Bucket;

	public LookAtTarget LookAt;

	public PickUpScript PickUp;

	public PoliceScript Police;

	public UILabel SanityLabel;

	public GloveScript Gloves;

	public ClassScript Class;

	public Camera UICamera;

	public UILabel PowerUp;

	public MaskScript Mask;

	public MopScript Mop;

	public UIPanel HUD;

	public CharacterController MyController;

	public Transform LeftItemParent;

	public Transform DismemberSpot;

	public Transform CameraTarget;

	public Transform InvertSphere;

	public Transform RightArmRoll;

	public Transform LeftArmRoll;

	public Transform CameraFocus;

	public Transform RightBreast;

	public Transform HidingSpot;

	public Transform ItemParent;

	public Transform LeftBreast;

	public Transform LimbParent;

	public Transform PelvisRoot;

	public Transform PoisonSpot;

	public Transform CameraPOV;

	public Transform RightHand;

	public Transform RightKnee;

	public Transform RightFoot;

	public Transform ExitSpot;

	public Transform LeftHand;

	public Transform Backpack;

	public Transform DropSpot;

	public Transform Homeroom;

	public Transform DigSpot;

	public Transform Senpai;

	public Transform Target;

	public Transform Stool;

	public Transform Eyes;

	public Transform Head;

	public Transform Hips;

	public AudioSource HeartBeat;

	public AudioSource MyAudio;

	public GameObject[] Accessories;

	public GameObject[] Hairstyles;

	public GameObject[] Poisons;

	public GameObject[] Shoes;

	public float[] DropTimer;

	public GameObject CinematicCamera;

	public GameObject FloatingShovel;

	public GameObject EasterEggMenu;

	public GameObject StolenObject;

	public GameObject SelfieGuide;

	public GameObject MemeGlasses;

	public GameObject GiggleDisc;

	public GameObject KONGlasses;

	public GameObject Microphone;

	public GameObject SpiderLegs;

	public GameObject AlarmDisc;

	public GameObject Character;

	public GameObject DebugMenu;

	public GameObject EyepatchL;

	public GameObject EyepatchR;

	public GameObject EmptyHusk;

	public GameObject Handcuffs;

	public GameObject ShoePair;

	public GameObject Barcode;

	public GameObject Headset;

	public GameObject Ragdoll;

	public GameObject Hearts;

	public GameObject Teeth;

	public GameObject Phone;

	public GameObject Trail;

	public GameObject Match;

	public GameObject Arc;

	public SkinnedMeshRenderer MyRenderer;

	public Animation CharacterAnimation;

	public ParticleSystem GiggleLines;

	public ParticleSystem InsaneLines;

	public SpringJoint RagdollDragger;

	public SpringJoint RagdollPK;

	public Projector MyProjector;

	public Camera HeartCamera;

	public Camera MainCamera;

	public Camera Smartphone;

	public Camera HandCamera;

	public Renderer SmartphoneRenderer;

	public Renderer LongHairRenderer;

	public Renderer PonytailRenderer;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public float MurderousActionTimer;

	public float CinematicTimer;

	public float ClothingTimer;

	public float BreakUpTimer;

	public float CanMoveTimer;

	public float RummageTimer;

	public float YandereTimer;

	public float AttackTimer;

	public float CaughtTimer;

	public float GiggleTimer;

	public float SenpaiTimer;

	public float WeaponTimer;

	public float CrawlTimer;

	public float GloveTimer;

	public float LaughTimer;

	public float SprayTimer;

	public float TheftTimer;

	public float BeatTimer;

	public float BoneTimer;

	public float DumpTimer;

	public float ExitTimer;

	public float TalkTimer;

	[SerializeField]
	private float bloodiness;

	public float PreviousSanity = 100f;

	[SerializeField]
	private float sanity;

	public float TwitchTimer;

	public float NextTwitch;

	public float LaughIntensity;

	public float TimeSkipHeight;

	public float PourDistance;

	public float TargetHeight;

	public float PermitLaugh;

	public float ReachWeight;

	public float BreastSize;

	public float Numbness;

	public float PourTime;

	public float RunSpeed;

	public float Height;

	public float Slouch;

	public float Bend;

	public float CrouchWalkSpeed;

	public float CrouchRunSpeed;

	public float ShoveSpeed = 2f;

	public float CrawlSpeed;

	public float FlapSpeed;

	public float WalkSpeed;

	public float YandereFade;

	public float YandereTint;

	public float SenpaiFade;

	public float SenpaiTint;

	public float GreyTarget;

	public int CurrentUniformOrigin = 1;

	public int PreviousSchoolwear;

	public int NearestCorpseID;

	public int StrugglePhase;

	public int PhysicalGrade;

	public int CarryAnimID;

	public int AttackPhase;

	public int Creepiness = 1;

	public int GloveBlood;

	public int NearBodies;

	public int PoisonType;

	public int Schoolwear;

	public int SpeedBonus;

	public int SprayPhase;

	public int DragState;

	public int EggBypass;

	public int EyewearID;

	public int Followers;

	public int Hairstyle;

	public int PersonaID;

	public int DigPhase;

	public int Equipped;

	public int Chasers;

	public int Costume;

	public int Alerts;

	public int Health = 5;

	public YandereInteractionType Interaction;

	public YanderePersonaType Persona;

	public ClubType Club;

	public bool EavesdropWarning;

	public bool ClothingWarning;

	public bool BloodyWarning;

	public bool CorpseWarning;

	public bool SanityWarning;

	public bool WeaponWarning;

	public bool DelinquentFighting;

	public bool DumpsterGrabbing;

	public bool BucketDropping;

	public bool CleaningWeapon;

	public bool SubtleStabbing;

	public bool TranquilHiding;

	public bool CrushingPhone;

	public bool Eavesdropping;

	public bool Pickpocketing;

	public bool Dismembering;

	public bool ShootingBeam;

	public bool StoppingTime;

	public bool TimeSkipping;

	public bool Cauterizing;

	public bool HeavyWeight;

	public bool Trespassing;

	public bool WritingName;

	public bool Struggling;

	public bool Attacking;

	public bool Degloving;

	public bool Poisoning;

	public bool Rummaging;

	public bool Stripping;

	public bool Blasting;

	public bool Carrying;

	public bool Chipping;

	public bool Dragging;

	public bool Dropping;

	public bool Flicking;

	public bool Freezing;

	public bool Laughing;

	public bool Punching;

	public bool Throwing;

	public bool Tripping;

	public bool Bathing;

	public bool Burying;

	public bool Cooking;

	public bool Digging;

	public bool Dipping;

	public bool Dumping;

	public bool Exiting;

	public bool Lifting;

	public bool Mopping;

	public bool Pouring;

	public bool Resting;

	public bool Running;

	public bool Talking;

	public bool Testing;

	public bool Aiming;

	public bool Eating;

	public bool Hiding;

	public bool Riding;

	public Stance Stance = new Stance(StanceType.Standing);

	public bool PreparedForStruggle;

	public bool CrouchButtonDown;

	public bool FightHasBrokenUp;

	public bool UsingController;

	public bool SeenByAuthority;

	public bool CameFromCrouch;

	public bool CannotRecover;

	public bool NoStainGloves;

	public bool YandereVision;

	public bool ClubActivity;

	public bool FlameDemonic;

	public bool SanityBased;

	public bool SummonBones;

	public bool ClubAttire;

	public bool FollowHips;

	public bool NearSenpai;

	public bool RivalPhone;

	public bool SpiderGrow;

	public bool Possessed;

	public bool ToggleRun;

	public bool WitchMode;

	public bool Attacked;

	public bool CanTranq;

	public bool Collapse;

	public bool Unmasked;

	public bool RedPaint;

	public bool RoofPush;

	public bool Demonic;

	public bool FlapOut;

	public bool NoDebug;

	public bool Noticed;

	public bool InClass;

	public bool Slender;

	public bool Sprayed;

	public bool Caught;

	public bool CanMove = true;

	public bool Chased;

	public bool Gloved;

	public bool Selfie;

	public bool Shoved;

	public bool Drown;

	public bool Xtan;

	public bool Lewd;

	public bool Lost;

	public bool Sans;

	public bool Egg;

	public bool Won;

	public bool AR;

	public bool DK;

	public bool PK;

	public Texture[] UniformTextures;

	public Texture[] CasualTextures;

	public Texture[] FlowerTextures;

	public Texture[] BloodTextures;

	public AudioClip[] CreepyGiggles;

	public AudioClip[] Stabs;

	public WeaponScript[] Weapon;

	public GameObject[] ZipTie;

	public string[] ArmedAnims;

	public string[] CarryAnims;

	public Transform[] Spine;

	public Transform[] Foot;

	public Transform[] Hand;

	public Transform[] Arm;

	public Transform[] Leg;

	public Mesh[] Uniforms;

	public Renderer RightYandereEye;

	public Renderer LeftYandereEye;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Renderer RightRedEye;

	public Renderer LeftRedEye;

	public Transform RightEye;

	public Transform LeftEye;

	public float EyeShrink;

	public Vector3 Twitch;

	private AudioClip LaughClip;

	public string PourHeight = string.Empty;

	public string DrownAnim = string.Empty;

	public string LaughAnim = string.Empty;

	public string HideAnim = string.Empty;

	public string IdleAnim = string.Empty;

	public string TalkAnim = string.Empty;

	public string WalkAnim = string.Empty;

	public string RunAnim = string.Empty;

	public string CrouchIdleAnim = string.Empty;

	public string CrouchWalkAnim = string.Empty;

	public string CrouchRunAnim = string.Empty;

	public string CrawlIdleAnim = string.Empty;

	public string CrawlWalkAnim = string.Empty;

	public string HeavyIdleAnim = string.Empty;

	public string HeavyWalkAnim = string.Empty;

	public string CarryIdleAnim = string.Empty;

	public string CarryWalkAnim = string.Empty;

	public string CarryRunAnim = string.Empty;

	public string[] CreepyIdles;

	public string[] CreepyWalks;

	public AudioClip DramaticWriting;

	public AudioClip ChargeUp;

	public AudioClip Laugh0;

	public AudioClip Laugh1;

	public AudioClip Laugh2;

	public AudioClip Laugh3;

	public AudioClip Laugh4;

	public AudioClip Thud;

	public AudioClip Dig;

	public Vector3 PreviousPosition;

	public string OriginalIdleAnim = string.Empty;

	public string OriginalWalkAnim = string.Empty;

	public string OriginalRunAnim = string.Empty;

	public Texture YanderePhoneTexture;

	public Texture BloodyGloveTexture;

	public Texture RivalPhoneTexture;

	public Texture BlondePony;

	public float VibrationIntensity;

	public float VibrationTimer;

	public bool VibrationCheck;

	public float v;

	public float h;

	private int DebugInt;

	public GameObject CreepyArms;

	public Texture[] GloveTextures;

	public Texture TitanTexture;

	public Texture KONTexture;

	public GameObject PunishedAccessories;

	public GameObject PunishedScarf;

	public GameObject[] PunishedArm;

	public Texture[] PunishedTextures;

	public Shader PunishedShader;

	public Mesh PunishedMesh;

	public Material HatefulSkybox;

	public Texture HatefulUniform;

	public GameObject SukebanAccessories;

	public Texture SukebanBandages;

	public Texture SukebanUniform;

	public FalconPunchScript BanchoFinisher;

	public StandPunchScript BanchoFlurry;

	public GameObject BanchoPants;

	public Mesh BanchoMesh;

	public Texture BanchoBody;

	public Texture BanchoFace;

	public GameObject[] BanchoAccessories;

	public bool BanchoActive;

	public bool Finisher;

	public AudioClip BanchoYanYan;

	public AudioClip BanchoFinalYan;

	public AmplifyMotionObject MotionObject;

	public AmplifyMotionEffect MotionBlur;

	public GameObject BanchoCamera;

	public GameObject[] SlenderHair;

	public Texture SlenderUniform;

	public Material SlenderSkybox;

	public Texture SlenderSkin;

	public Transform[] LongHair;

	public GameObject BlackEyePatch;

	public GameObject XSclera;

	public GameObject XEye;

	public Texture XBody;

	public Texture XFace;

	public GameObject[] GaloAccessories;

	public Texture GaloArms;

	public Texture GaloFace;

	public AudioClip SummonStand;

	public StandScript Stand;

	public AudioClip YanYan;

	public Texture AgentFace;

	public Texture AgentSuit;

	public GameObject CirnoIceAttack;

	public AudioClip CirnoIceClip;

	public GameObject CirnoWings;

	public GameObject CirnoHair;

	public Texture CirnoUniform;

	public Texture CirnoFace;

	public Transform[] CirnoWing;

	public float CirnoRotation;

	public float CirnoTimer;

	public AudioClip FalconPunchVoice;

	public Texture FalconBody;

	public Texture FalconFace;

	public float FalconSpeed;

	public GameObject NewFalconPunch;

	public GameObject FalconWindUp;

	public GameObject FalconPunch;

	public GameObject FalconShoulderpad;

	public GameObject FalconKneepad1;

	public GameObject FalconKneepad2;

	public GameObject FalconBuckle;

	public GameObject FalconHelmet;

	public AudioClip[] OnePunchVoices;

	public GameObject NewOnePunch;

	public GameObject OnePunch;

	public Texture SaitamaSuit;

	public GameObject Cape;

	public ParticleSystem GlowEffect;

	public GameObject[] BlasterSet;

	public GameObject[] SansEyes;

	public AudioClip BlasterClip;

	public Texture SansTexture;

	public Texture SansFace;

	public GameObject Bone;

	public AudioClip Slam;

	public Mesh Jersey;

	public int BlasterStage;

	public PKDirType PKDir;

	public Texture CyborgBody;

	public Texture CyborgFace;

	public GameObject[] CyborgParts;

	public GameObject EnergySword;

	public bool Ninja;

	public GameObject EbolaEffect;

	public GameObject EbolaWings;

	public GameObject EbolaHair;

	public Texture EbolaFace;

	public Texture EbolaUniform;

	public Mesh LongUniform;

	public Texture NewFace;

	public Mesh NewMesh;

	public GameObject[] CensorSteam;

	public Texture NudePanties;

	public Texture NudeTexture;

	public Mesh NudeMesh;

	public Texture SamusBody;

	public Texture SamusFace;

	public GlobalKnifeArrayScript GlobalKnifeArray;

	public GameObject PlayerOnlyCamera;

	public GameObject KnifeArray;

	public AudioClip ClockStart;

	public AudioClip ClockStop;

	public AudioClip ClockTick;

	public AudioClip StartShout;

	public AudioClip StopShout;

	public Texture WitchBody;

	public Texture WitchFace;

	public Collider BladeHairCollider1;

	public Collider BladeHairCollider2;

	public GameObject BladeHair;

	public DebugMenuScript TheDebugMenuScript;

	public GameObject RiggedAccessory;

	public GameObject TornadoAttack;

	public GameObject TornadoDress;

	public GameObject TornadoHair;

	public Renderer TornadoRenderer;

	public Mesh NoTorsoMesh;

	public GameObject KunHair;

	public GameObject Kun;

	public GameObject Man;

	public GameObject BlackHoleEffects;

	public Texture BlackHoleFace;

	public Texture Black;

	public bool BlackHole;

	public Transform RightLeg;

	public Transform LeftLeg;

	public GameObject Bandages;

	public GameObject LucyHelmet;

	public GameObject[] Vectors;

	public GameObject[] Kagune;

	public Texture GhoulFace;

	public Texture GhoulBody;

	public bool ReturnKagune;

	public bool SwingKagune;

	public Vector3[] KaguneRotation;

	public AudioClip KaguneSwoosh;

	public GameObject DemonSlash;

	public int KagunePhase;

	public GameObject[] Armor;

	public Texture Chainmail;

	public Texture Scarface;

	public Material Metal;

	public Material Trans;

	public GameObject BlackRobe;

	public Mesh NoUpperBodyMesh;

	public ParticleSystem[] Beam;

	public SithBeamScript[] SithBeam;

	public bool SithRecovering;

	public bool SithAttacking;

	public bool SithLord;

	public string SithPrefix;

	public int SithComboLength;

	public int SithAttacks;

	public int SithSounds;

	public int SithCombo;

	public GameObject SithHardHitbox;

	public GameObject SithHitbox;

	public GameObject SithTrail1;

	public GameObject SithTrail2;

	public Transform SithTrailEnd1;

	public Transform SithTrailEnd2;

	public ZoomScript Zoom;

	public AudioClip SithOn;

	public AudioClip SithOff;

	public AudioClip SithSwing;

	public AudioClip SithStrike;

	public AudioSource SithAudio;

	public float[] SithHardSpawnTime1;

	public float[] SithHardSpawnTime2;

	public float[] SithSpawnTime;

	public Texture SnakeFace;

	public Texture SnakeBody;

	public Texture Stone;

	public AudioClip Petrify;

	public GameObject Pebbles;

	public bool Medusa;

	public Texture GazerFace;

	public Texture GazerBody;

	public GazerEyesScript GazerEyes;

	public AudioClip FingerSnap;

	public AudioClip Zap;

	public bool GazeAttacking;

	public bool Snapping;

	public bool Gazing;

	public int SnapPhase;

	public GameObject SixRaincoat;

	public GameObject RisingSmoke;

	public GameObject DarkHelix;

	public Texture SixFaceTexture;

	public AudioClip SixTakedown;

	public Transform SixTarget;

	public Mesh SixBodyMesh;

	public Transform Mouth;

	public int EatPhase;

	public bool Hungry;

	public int Hunger;

	public float[] BloodTimes;

	public AudioClip[] Snarls;

	public Texture KLKBody;

	public Texture KLKFace;

	public GameObject[] KLKParts;

	public GameObject KLKSword;

	public AudioClip LoveLoveBeamVoice;

	public GameObject MiyukiCostume;

	public GameObject LoveLoveBeam;

	public GameObject MiyukiWings;

	public Texture MiyukiSkin;

	public Texture MiyukiFace;

	public bool MagicalGirl;

	public int BeamPhase;

	public GameObject AzurGuns;

	public GameObject AzurWater;

	public GameObject AzurMist;

	public GameObject Shell;

	public Transform[] Guns;

	public int ShotsFired;

	public bool Shipgirl;

	public BlacklightEffect BlacklightShader;

	public GameObject BlacklightOutfit;

	public Mesh BlacklightBodyMesh;

	public GameObject Raincoat;

	public GameObject Rain;

	public Material HorrorSkybox;

	public Texture YamikoFaceTexture;

	public Texture YamikoSkinTexture;

	public Texture YamikoAccessoryTexture;

	public GameObject LifeNotebook;

	public GameObject LifeNotePen;

	public Mesh YamikoMesh;

	public GameObject GroundImpact;

	public GameObject NierCostume;

	public GameObject HeavySword;

	public GameObject LightSword;

	public GameObject Pod;

	public Transform LightSwordParent;

	public Transform HeavySwordParent;

	public ParticleSystem LightSwordParticles;

	public ParticleSystem HeavySwordParticles;

	public string AttackPrefix;

	public float NierDamage;

	public float[] NierSpawnTime;

	public float[] NierHardSpawnTime;

	public AudioClip NierSwoosh;

	public GameObject ChinaDress;

	public NormalBufferView VaporwaveVisuals;

	public Material VaporwaveSkybox;

	public GameObject PalmTrees;

	public GameObject[] Trees;

	public Mesh SchoolSwimsuit;

	public Mesh GymUniform;

	public Mesh Towel;

	public Texture FaceTexture;

	public Texture SwimsuitTexture;

	public Texture GymTexture;

	public Texture TextureToUse;

	public Texture TowelTexture;

	public bool Casual = true;

	public Mesh JudoGiMesh;

	public Texture JudoGiTexture;

	public Mesh ApronMesh;

	public Texture ApronTexture;

	public Mesh LabCoatMesh;

	public Mesh HeadAndHands;

	public Texture LabCoatTexture;

	public RiggedAccessoryAttacher LabcoatAttacher;

	public bool Paint;

	public GameObject[] ClubAccessories;

	public GameObject Fireball;

	public bool LiftOff;

	public GameObject LiftOffParticles;

	public float LiftOffSpeed;

	public SkinnedMeshUpdater SkinUpdater;

	public Mesh RivalChanMesh;

	public Mesh TestMesh;

	public bool BullyPhoto;

	public CameraFilterScript CinematicCameraFilters;

	public CameraFilterScript CameraFilters;

	private void Start()
	{
		Application.runInBackground = false;
		this.PhysicalGrade = ClassGlobals.PhysicalGrade;
		this.SpeedBonus = PlayerGlobals.SpeedBonus;
		this.Club = ClubGlobals.Club;
		this.SanitySmudges.color = new Color(1f, 1f, 1f, 0f);
		this.SpiderLegs.SetActive(GameGlobals.EmptyDemon);
		this.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
		this.SetAnimationLayers();
		this.UpdateNumbness();
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		this.CharacterAnimation["f02_yanderePose_00"].weight = 0f;
		this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
		this.CharacterAnimation["f02_selfie_00"].weight = 0f;
		this.CharacterAnimation["f02_shipGirlSnap_00"].speed = 2f;
		this.CharacterAnimation["f02_gazerSnap_00"].speed = 2f;
		this.CharacterAnimation["f02_performing_00"].speed = 0.9f;
		this.CharacterAnimation["f02_sithAttack_00"].speed = 1.5f;
		this.CharacterAnimation["f02_sithAttack_01"].speed = 1.5f;
		this.CharacterAnimation["f02_sithAttack_02"].speed = 1.5f;
		this.CharacterAnimation["f02_sithAttackHard_00"].speed = 1.5f;
		this.CharacterAnimation["f02_sithAttackHard_01"].speed = 1.5f;
		this.CharacterAnimation["f02_sithAttackHard_02"].speed = 1.5f;
		this.CharacterAnimation["f02_nierRun_00"].speed = 1.5f;
		ColorCorrectionCurves[] components = Camera.main.GetComponents<ColorCorrectionCurves>();
		Vignetting[] components2 = Camera.main.GetComponents<Vignetting>();
		this.YandereColorCorrection = components[1];
		this.Vignette = components2[1];
		this.ResetYandereEffects();
		this.ResetSenpaiEffects();
		this.Sanity = 100f;
		this.Bloodiness = 0f;
		this.SetUniform();
		this.EasterEggMenu.transform.localPosition = new Vector3(this.EasterEggMenu.transform.localPosition.x, 0f, this.EasterEggMenu.transform.localPosition.z);
		this.ProgressBar.transform.parent.gameObject.SetActive(false);
		this.Smartphone.transform.parent.gameObject.SetActive(false);
		this.ObstacleDetector.gameObject.SetActive(false);
		this.SithBeam[1].gameObject.SetActive(false);
		this.SithBeam[2].gameObject.SetActive(false);
		this.PunishedAccessories.SetActive(false);
		this.SukebanAccessories.SetActive(false);
		this.FalconShoulderpad.SetActive(false);
		this.CensorSteam[0].SetActive(false);
		this.CensorSteam[1].SetActive(false);
		this.CensorSteam[2].SetActive(false);
		this.CensorSteam[3].SetActive(false);
		this.FloatingShovel.SetActive(false);
		this.BlackEyePatch.SetActive(false);
		this.EasterEggMenu.SetActive(false);
		this.FalconKneepad1.SetActive(false);
		this.FalconKneepad2.SetActive(false);
		this.PunishedScarf.SetActive(false);
		this.FalconBuckle.SetActive(false);
		this.FalconHelmet.SetActive(false);
		this.TornadoDress.SetActive(false);
		this.Stand.Stand.SetActive(false);
		this.TornadoHair.SetActive(false);
		this.MemeGlasses.SetActive(false);
		this.CirnoWings.SetActive(false);
		this.KONGlasses.SetActive(false);
		this.EbolaWings.SetActive(false);
		this.Microphone.SetActive(false);
		this.Poisons[1].SetActive(false);
		this.Poisons[2].SetActive(false);
		this.Poisons[3].SetActive(false);
		this.BladeHair.SetActive(false);
		this.CirnoHair.SetActive(false);
		this.EbolaHair.SetActive(false);
		this.EyepatchL.SetActive(false);
		this.EyepatchR.SetActive(false);
		this.Handcuffs.SetActive(false);
		this.ZipTie[0].SetActive(false);
		this.ZipTie[1].SetActive(false);
		this.Shoes[0].SetActive(false);
		this.Shoes[1].SetActive(false);
		this.Phone.SetActive(false);
		this.Cape.SetActive(false);
		this.HeavySwordParent.gameObject.SetActive(false);
		this.LightSwordParent.gameObject.SetActive(false);
		this.Pod.SetActive(false);
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		GameObject[] array = this.Armor;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		this.ID = 1;
		while (this.ID < this.Accessories.Length)
		{
			this.Accessories[this.ID].SetActive(false);
			this.ID++;
		}
		array = this.PunishedArm;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		array = this.GaloAccessories;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		array = this.Vectors;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		this.ID = 1;
		while (this.ID < this.CyborgParts.Length)
		{
			this.CyborgParts[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.KLKParts.Length)
		{
			this.KLKParts[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.BanchoAccessories.Length)
		{
			this.BanchoAccessories[this.ID].SetActive(false);
			this.ID++;
		}
		if (PlayerGlobals.PantiesEquipped == 5)
		{
			this.RunSpeed += 1f;
		}
		if (PlayerGlobals.Headset)
		{
			this.Inventory.Headset = true;
		}
		this.UpdateHair();
		this.ClubAccessory();
		if (MissionModeGlobals.MissionMode || GameGlobals.LoveSick)
		{
			this.NoDebug = true;
		}
		if (GameGlobals.BlondeHair)
		{
			this.PonytailRenderer.material.mainTexture = this.BlondePony;
		}
		if (this.StudentManager.Students[11] != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
		this.CharacterAnimation.Sample();
	}

	public float Sanity
	{
		get
		{
			return this.sanity;
		}
		set
		{
			this.sanity = Mathf.Clamp(value, 0f, 100f);
			if (this.sanity > 66.66666f)
			{
				this.HeartRate.SetHeartRateColour(this.HeartRate.NormalColour);
				this.SanityWarning = false;
			}
			else if (this.sanity > 33.33333f)
			{
				this.HeartRate.SetHeartRateColour(this.HeartRate.MediumColour);
				this.SanityWarning = false;
				if (this.PreviousSanity < 33.33333f)
				{
					this.StudentManager.UpdateStudents(0);
				}
			}
			else
			{
				this.HeartRate.SetHeartRateColour(this.HeartRate.BadColour);
				if (!this.SanityWarning)
				{
					this.NotificationManager.DisplayNotification(NotificationType.Insane);
					this.StudentManager.TutorialWindow.ShowSanityMessage = true;
					this.SanityWarning = true;
				}
			}
			this.HeartRate.BeatsPerMinute = (int)(240f - this.sanity * 1.8f);
			if (!this.Laughing)
			{
				this.Teeth.SetActive(this.SanityWarning);
			}
			if (this.MyRenderer.sharedMesh != this.NudeMesh)
			{
				if (!this.Slender)
				{
					this.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f - this.sanity / 100f);
				}
				else
				{
					this.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
				}
			}
			else
			{
				this.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			}
			this.PreviousSanity = this.sanity;
			this.Hairstyles[2].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, this.Sanity);
		}
	}

	public float Bloodiness
	{
		get
		{
			return this.bloodiness;
		}
		set
		{
			this.bloodiness = Mathf.Clamp(value, 0f, 100f);
			if (this.Bloodiness > 0f)
			{
				this.StudentManager.TutorialWindow.ShowBloodMessage = true;
			}
			if (!this.BloodyWarning && this.Bloodiness > 0f)
			{
				this.NotificationManager.DisplayNotification(NotificationType.Bloody);
				this.BloodyWarning = true;
				if (this.Schoolwear > 0 && this.ClubAttire)
				{
					this.Police.BloodyClothing++;
					if (this.CurrentUniformOrigin == 1)
					{
						this.StudentManager.OriginalUniforms--;
						Debug.Log("One of the original uniforms has become bloody. There are now " + this.StudentManager.OriginalUniforms + " clean original uniforms in the school.");
					}
					else
					{
						this.StudentManager.NewUniforms--;
						Debug.Log("One of the new uniforms has become bloody. There are now " + this.StudentManager.NewUniforms + " clean original uniforms in the school.");
					}
				}
			}
			this.MyProjector.enabled = true;
			this.RedPaint = false;
			if (!GameGlobals.CensorBlood)
			{
				this.MyProjector.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 0.5f));
				if (this.Bloodiness == 100f)
				{
					this.MyProjector.material.mainTexture = this.BloodTextures[5];
				}
				else if (this.Bloodiness >= 80f)
				{
					this.MyProjector.material.mainTexture = this.BloodTextures[4];
				}
				else if (this.Bloodiness >= 60f)
				{
					this.MyProjector.material.mainTexture = this.BloodTextures[3];
				}
				else if (this.Bloodiness >= 40f)
				{
					this.MyProjector.material.mainTexture = this.BloodTextures[2];
				}
				else if (this.Bloodiness >= 20f)
				{
					this.MyProjector.material.mainTexture = this.BloodTextures[1];
				}
				else
				{
					this.MyProjector.enabled = false;
					this.BloodyWarning = false;
				}
			}
			else
			{
				this.MyProjector.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.5f));
				if (this.Bloodiness == 100f)
				{
					this.MyProjector.material.mainTexture = this.FlowerTextures[5];
				}
				else if (this.Bloodiness >= 80f)
				{
					this.MyProjector.material.mainTexture = this.FlowerTextures[4];
				}
				else if (this.Bloodiness >= 60f)
				{
					this.MyProjector.material.mainTexture = this.FlowerTextures[3];
				}
				else if (this.Bloodiness >= 40f)
				{
					this.MyProjector.material.mainTexture = this.FlowerTextures[2];
				}
				else if (this.Bloodiness >= 20f)
				{
					this.MyProjector.material.mainTexture = this.FlowerTextures[1];
				}
				else
				{
					this.MyProjector.enabled = false;
					this.BloodyWarning = false;
				}
			}
			this.StudentManager.UpdateBooths();
			this.MyLocker.UpdateButtons();
			this.Outline.h.ReinitMaterials();
		}
	}

	public WeaponScript EquippedWeapon
	{
		get
		{
			return this.Weapon[this.Equipped];
		}
		set
		{
			this.Weapon[this.Equipped] = value;
		}
	}

	public bool Armed
	{
		get
		{
			return this.EquippedWeapon != null;
		}
	}

	public SanityType SanityType
	{
		get
		{
			if (this.Sanity / 100f > 0.6666667f)
			{
				return SanityType.High;
			}
			if (this.Sanity / 100f > 0.333333343f)
			{
				return SanityType.Medium;
			}
			return SanityType.Low;
		}
	}

	public string GetSanityString(SanityType sanityType)
	{
		if (sanityType == SanityType.High)
		{
			return "High";
		}
		if (sanityType == SanityType.Medium)
		{
			return "Med";
		}
		return "Low";
	}

	public Vector3 HeadPosition
	{
		get
		{
			return new Vector3(base.transform.position.x, this.Hips.position.y + 0.2f, base.transform.position.z);
		}
	}

	public void SetAnimationLayers()
	{
		this.CharacterAnimation["f02_yanderePose_00"].layer = 1;
		this.CharacterAnimation.Play("f02_yanderePose_00");
		this.CharacterAnimation["f02_yanderePose_00"].weight = 0f;
		this.CharacterAnimation["f02_shy_00"].layer = 2;
		this.CharacterAnimation.Play("f02_shy_00");
		this.CharacterAnimation["f02_shy_00"].weight = 0f;
		this.CharacterAnimation["f02_singleSaw_00"].layer = 3;
		this.CharacterAnimation.Play("f02_singleSaw_00");
		this.CharacterAnimation["f02_singleSaw_00"].weight = 0f;
		this.CharacterAnimation["f02_fist_00"].layer = 4;
		this.CharacterAnimation.Play("f02_fist_00");
		this.CharacterAnimation["f02_fist_00"].weight = 0f;
		this.CharacterAnimation["f02_mopping_00"].layer = 5;
		this.CharacterAnimation["f02_mopping_00"].speed = 2f;
		this.CharacterAnimation.Play("f02_mopping_00");
		this.CharacterAnimation["f02_mopping_00"].weight = 0f;
		this.CharacterAnimation["f02_carry_00"].layer = 6;
		this.CharacterAnimation.Play("f02_carry_00");
		this.CharacterAnimation["f02_carry_00"].weight = 0f;
		this.CharacterAnimation["f02_mopCarry_00"].layer = 7;
		this.CharacterAnimation.Play("f02_mopCarry_00");
		this.CharacterAnimation["f02_mopCarry_00"].weight = 0f;
		this.CharacterAnimation["f02_bucketCarry_00"].layer = 8;
		this.CharacterAnimation.Play("f02_bucketCarry_00");
		this.CharacterAnimation["f02_bucketCarry_00"].weight = 0f;
		this.CharacterAnimation["f02_cameraPose_00"].layer = 9;
		this.CharacterAnimation.Play("f02_cameraPose_00");
		this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
		this.CharacterAnimation["f02_grip_00"].layer = 10;
		this.CharacterAnimation.Play("f02_grip_00");
		this.CharacterAnimation["f02_grip_00"].weight = 0f;
		this.CharacterAnimation["f02_holdHead_00"].layer = 11;
		this.CharacterAnimation.Play("f02_holdHead_00");
		this.CharacterAnimation["f02_holdHead_00"].weight = 0f;
		this.CharacterAnimation["f02_holdTorso_00"].layer = 12;
		this.CharacterAnimation.Play("f02_holdTorso_00");
		this.CharacterAnimation["f02_holdTorso_00"].weight = 0f;
		this.CharacterAnimation["f02_carryCan_00"].layer = 13;
		this.CharacterAnimation.Play("f02_carryCan_00");
		this.CharacterAnimation["f02_carryCan_00"].weight = 0f;
		this.CharacterAnimation["f02_leftGrip_00"].layer = 14;
		this.CharacterAnimation.Play("f02_leftGrip_00");
		this.CharacterAnimation["f02_leftGrip_00"].weight = 0f;
		this.CharacterAnimation["f02_carryShoulder_00"].layer = 15;
		this.CharacterAnimation.Play("f02_carryShoulder_00");
		this.CharacterAnimation["f02_carryShoulder_00"].weight = 0f;
		this.CharacterAnimation["f02_carryFlashlight_00"].layer = 16;
		this.CharacterAnimation.Play("f02_carryFlashlight_00");
		this.CharacterAnimation["f02_carryFlashlight_00"].weight = 0f;
		this.CharacterAnimation["f02_carryBox_00"].layer = 17;
		this.CharacterAnimation.Play("f02_carryBox_00");
		this.CharacterAnimation["f02_carryBox_00"].weight = 0f;
		this.CharacterAnimation["f02_holdBook_00"].layer = 18;
		this.CharacterAnimation.Play("f02_holdBook_00");
		this.CharacterAnimation["f02_holdBook_00"].weight = 0f;
		this.CharacterAnimation["f02_holdBook_00"].speed = 0.5f;
		this.CharacterAnimation[this.CreepyIdles[1]].layer = 19;
		this.CharacterAnimation.Play(this.CreepyIdles[1]);
		this.CharacterAnimation[this.CreepyIdles[1]].weight = 0f;
		this.CharacterAnimation[this.CreepyIdles[2]].layer = 20;
		this.CharacterAnimation.Play(this.CreepyIdles[2]);
		this.CharacterAnimation[this.CreepyIdles[2]].weight = 0f;
		this.CharacterAnimation[this.CreepyIdles[3]].layer = 21;
		this.CharacterAnimation.Play(this.CreepyIdles[3]);
		this.CharacterAnimation[this.CreepyIdles[3]].weight = 0f;
		this.CharacterAnimation[this.CreepyIdles[4]].layer = 22;
		this.CharacterAnimation.Play(this.CreepyIdles[4]);
		this.CharacterAnimation[this.CreepyIdles[4]].weight = 0f;
		this.CharacterAnimation[this.CreepyIdles[5]].layer = 23;
		this.CharacterAnimation.Play(this.CreepyIdles[5]);
		this.CharacterAnimation[this.CreepyIdles[5]].weight = 0f;
		this.CharacterAnimation[this.CreepyWalks[1]].layer = 24;
		this.CharacterAnimation.Play(this.CreepyWalks[1]);
		this.CharacterAnimation[this.CreepyWalks[1]].weight = 0f;
		this.CharacterAnimation[this.CreepyWalks[2]].layer = 25;
		this.CharacterAnimation.Play(this.CreepyWalks[2]);
		this.CharacterAnimation[this.CreepyWalks[2]].weight = 0f;
		this.CharacterAnimation[this.CreepyWalks[3]].layer = 26;
		this.CharacterAnimation.Play(this.CreepyWalks[3]);
		this.CharacterAnimation[this.CreepyWalks[3]].weight = 0f;
		this.CharacterAnimation[this.CreepyWalks[4]].layer = 27;
		this.CharacterAnimation.Play(this.CreepyWalks[4]);
		this.CharacterAnimation[this.CreepyWalks[4]].weight = 0f;
		this.CharacterAnimation[this.CreepyWalks[5]].layer = 28;
		this.CharacterAnimation.Play(this.CreepyWalks[5]);
		this.CharacterAnimation[this.CreepyWalks[5]].weight = 0f;
		this.CharacterAnimation["f02_carryDramatic_00"].layer = 29;
		this.CharacterAnimation.Play("f02_carryDramatic_00");
		this.CharacterAnimation["f02_carryDramatic_00"].weight = 0f;
		this.CharacterAnimation["f02_selfie_00"].layer = 30;
		this.CharacterAnimation.Play("f02_selfie_00");
		this.CharacterAnimation["f02_selfie_00"].weight = 0f;
		this.CharacterAnimation["f02_dramaticWriting_00"].layer = 31;
		this.CharacterAnimation.Play("f02_dramaticWriting_00");
		this.CharacterAnimation["f02_dramaticWriting_00"].weight = 0f;
		this.CharacterAnimation["f02_reachForWeapon_00"].layer = 32;
		this.CharacterAnimation.Play("f02_reachForWeapon_00");
		this.CharacterAnimation["f02_reachForWeapon_00"].weight = 0f;
		this.CharacterAnimation["f02_reachForWeapon_00"].speed = 2f;
		this.CharacterAnimation["f02_gutsEye_00"].layer = 33;
		this.CharacterAnimation.Play("f02_gutsEye_00");
		this.CharacterAnimation["f02_gutsEye_00"].weight = 0f;
		this.CharacterAnimation["f02_fingerSnap_00"].layer = 34;
		this.CharacterAnimation.Play("f02_fingerSnap_00");
		this.CharacterAnimation["f02_fingerSnap_00"].weight = 0f;
		this.CharacterAnimation["f02_sadEyebrows_00"].layer = 35;
		this.CharacterAnimation.Play("f02_sadEyebrows_00");
		this.CharacterAnimation["f02_sadEyebrows_00"].weight = 0f;
		this.CharacterAnimation["f02_dipping_00"].speed = 2f;
		this.CharacterAnimation["f02_stripping_00"].speed = 1.5f;
		this.CharacterAnimation["f02_falconIdle_00"].speed = 2f;
		this.CharacterAnimation["f02_carryIdleA_00"].speed = 1.75f;
		this.CharacterAnimation["CyborgNinja_Run_Armed"].speed = 2f;
		this.CharacterAnimation["CyborgNinja_Run_Unarmed"].speed = 2f;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			this.CinematicCamera.SetActive(false);
		}
		if (!this.PauseScreen.Show)
		{
			this.UpdateMovement();
			this.UpdatePoisoning();
			if (!this.Laughing)
			{
				this.MyAudio.volume -= Time.deltaTime * 2f;
			}
			else if (this.PickUp != null && !this.PickUp.Clothing)
			{
				this.CharacterAnimation[this.CarryAnims[1]].weight = Mathf.Lerp(this.CharacterAnimation[this.CarryAnims[1]].weight, 1f, Time.deltaTime * 10f);
			}
			if (!this.Mopping)
			{
				this.CharacterAnimation["f02_mopping_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopping_00"].weight, 0f, Time.deltaTime * 10f);
			}
			else
			{
				this.CharacterAnimation["f02_mopping_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopping_00"].weight, 1f, Time.deltaTime * 10f);
				if (Input.GetButtonUp("A") || Input.GetKeyDown(KeyCode.Escape))
				{
					this.Mopping = false;
				}
			}
			if (this.LaughIntensity == 0f)
			{
				this.ID = 0;
				while (this.ID < this.CarryAnims.Length)
				{
					string name = this.CarryAnims[this.ID];
					if (this.PickUp != null && this.CarryAnimID == this.ID && !this.Mopping && !this.Dipping && !this.Pouring && !this.BucketDropping && !this.Digging && !this.Burying && !this.WritingName)
					{
						this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, 1f, Time.deltaTime * 10f);
					}
					else
					{
						this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, 0f, Time.deltaTime * 10f);
					}
					this.ID++;
				}
			}
			else if (this.Armed)
			{
				this.CharacterAnimation["f02_mopCarry_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopCarry_00"].weight, 1f, Time.deltaTime * 10f);
			}
			if (this.Noticed && !this.Attacking && !this.Struggling && !this.Collapse)
			{
				if (this.ShoulderCamera.NoticedTimer < 1f)
				{
					this.CharacterAnimation.CrossFade("f02_scaredIdle_00");
				}
				this.targetRotation = Quaternion.LookRotation(this.Senpai.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				base.transform.localEulerAngles = new Vector3(0f, base.transform.localEulerAngles.y, base.transform.localEulerAngles.z);
				if (Vector3.Distance(base.transform.position, this.Senpai.position) < 1.25f)
				{
					this.MyController.Move(base.transform.forward * (Time.deltaTime * -2f));
				}
			}
			this.UpdateEffects();
			this.UpdateTalking();
			this.UpdateAttacking();
			this.UpdateSlouch();
			if (!this.Noticed)
			{
				this.RightYandereEye.material.color = new Color(this.RightYandereEye.material.color.r, this.RightYandereEye.material.color.g, this.RightYandereEye.material.color.b, 1f - this.Sanity / 100f);
				this.LeftYandereEye.material.color = new Color(this.LeftYandereEye.material.color.r, this.LeftYandereEye.material.color.g, this.LeftYandereEye.material.color.b, 1f - this.Sanity / 100f);
				this.EyeShrink = Mathf.Lerp(this.EyeShrink, 0.5f * (1f - this.Sanity / 100f), Time.deltaTime * 10f);
			}
			this.UpdateTwitch();
			this.UpdateWarnings();
			this.UpdateDebugFunctionality();
			if (base.transform.position.y < 0f)
			{
				base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
			}
			if (base.transform.position.z < -99.5f)
			{
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, -99.5f);
			}
			base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, 0f);
			return;
		}
		this.MyAudio.volume -= 0.333333343f;
	}

	private void GoToPKDir(PKDirType pkDir, string sansAnim, Vector3 ragdollLocalPos)
	{
		this.CharacterAnimation.CrossFade(sansAnim);
		this.RagdollPK.transform.localPosition = ragdollLocalPos;
		if (this.PKDir != pkDir)
		{
			AudioSource.PlayClipAtPoint(this.Slam, base.transform.position + Vector3.up);
		}
		this.PKDir = pkDir;
	}

	private void UpdateMovement()
	{
		if (this.CanMove)
		{
			if (!this.ToggleRun)
			{
				this.Running = false;
				if (Input.GetButton("LB"))
				{
					this.Running = true;
				}
			}
			else if (Input.GetButtonDown("LB"))
			{
				this.Running = !this.Running;
			}
			this.MyController.Move(Physics.gravity * Time.deltaTime);
			this.v = Input.GetAxis("Vertical");
			this.h = Input.GetAxis("Horizontal");
			this.FlapSpeed = Mathf.Abs(this.v) + Mathf.Abs(this.h);
			if (this.Selfie)
			{
				this.v = -1f * this.v;
				this.h = -1f * this.h;
			}
			if (!this.Aiming)
			{
				Vector3 vector = this.MainCamera.transform.TransformDirection(Vector3.forward);
				vector.y = 0f;
				vector = vector.normalized;
				Vector3 a = new Vector3(vector.z, 0f, -vector.x);
				this.targetDirection = this.h * a + this.v * vector;
				if (this.targetDirection != Vector3.zero)
				{
					this.targetRotation = Quaternion.LookRotation(this.targetDirection);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				}
				else
				{
					this.targetRotation = new Quaternion(0f, 0f, 0f, 0f);
				}
				if (this.v != 0f || this.h != 0f)
				{
					if (this.Running && Vector3.Distance(base.transform.position, this.Senpai.position) > 1f)
					{
						if (this.Stance.Current == StanceType.Crouching)
						{
							this.CharacterAnimation.CrossFade(this.CrouchRunAnim);
							this.MyController.Move(base.transform.forward * (this.CrouchRunSpeed + (float)(this.PhysicalGrade + this.SpeedBonus) * 0.25f) * Time.deltaTime);
						}
						else if (!this.Dragging && !this.Mopping)
						{
							this.CharacterAnimation.CrossFade(this.RunAnim);
							this.MyController.Move(base.transform.forward * (this.RunSpeed + (float)(this.PhysicalGrade + this.SpeedBonus) * 0.25f) * Time.deltaTime);
						}
						else if (this.Mopping)
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
							this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime));
						}
						StanceType stanceType = this.Stance.Current;
						if (this.Stance.Current == StanceType.Crawling)
						{
							this.Stance.Current = StanceType.Crouching;
							this.Crouch();
						}
					}
					else if (!this.Dragging)
					{
						if (this.Stance.Current == StanceType.Crawling)
						{
							this.CharacterAnimation.CrossFade(this.CrawlWalkAnim);
							this.MyController.Move(base.transform.forward * (this.CrawlSpeed * Time.deltaTime));
						}
						else if (this.Stance.Current == StanceType.Crouching)
						{
							this.CharacterAnimation[this.CrouchWalkAnim].speed = 1f;
							this.CharacterAnimation.CrossFade(this.CrouchWalkAnim);
							this.MyController.Move(base.transform.forward * (this.CrouchWalkSpeed * Time.deltaTime));
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
							if (this.NearSenpai)
							{
								for (int i = 1; i < 6; i++)
								{
									if (i != this.Creepiness)
									{
										this.CharacterAnimation[this.CreepyIdles[i]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[i]].weight, 0f, Time.deltaTime);
										this.CharacterAnimation[this.CreepyWalks[i]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[i]].weight, 0f, Time.deltaTime);
									}
								}
								this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight, 0f, Time.deltaTime);
								this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight, 1f, Time.deltaTime);
							}
							this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime));
						}
					}
					else
					{
						this.CharacterAnimation.CrossFade("f02_dragWalk_01");
						this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime));
					}
				}
				else if (!this.Dragging)
				{
					if (this.Stance.Current == StanceType.Crawling)
					{
						this.CharacterAnimation.CrossFade(this.CrawlIdleAnim);
					}
					else if (this.Stance.Current == StanceType.Crouching)
					{
						this.CharacterAnimation.CrossFade(this.CrouchIdleAnim);
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						if (this.NearSenpai)
						{
							for (int j = 1; j < 6; j++)
							{
								if (j != this.Creepiness)
								{
									this.CharacterAnimation[this.CreepyIdles[j]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[j]].weight, 0f, Time.deltaTime);
									this.CharacterAnimation[this.CreepyWalks[j]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[j]].weight, 0f, Time.deltaTime);
								}
							}
							this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight, 1f, Time.deltaTime);
							this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight, 0f, Time.deltaTime);
						}
					}
				}
				else
				{
					this.CharacterAnimation.CrossFade("f02_dragIdle_02");
				}
			}
			else
			{
				if (this.v != 0f || this.h != 0f)
				{
					if (this.Stance.Current == StanceType.Crawling)
					{
						this.CharacterAnimation.CrossFade(this.CrawlWalkAnim);
						this.MyController.Move(base.transform.forward * (this.CrawlSpeed * Time.deltaTime * this.v));
						this.MyController.Move(base.transform.right * (this.CrawlSpeed * Time.deltaTime * this.h));
					}
					else if (this.Stance.Current == StanceType.Crouching)
					{
						this.CharacterAnimation.CrossFade(this.CrouchWalkAnim);
						this.MyController.Move(base.transform.forward * (this.CrouchWalkSpeed * Time.deltaTime * this.v));
						this.MyController.Move(base.transform.right * (this.CrouchWalkSpeed * Time.deltaTime * this.h));
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime * this.v));
						this.MyController.Move(base.transform.right * (this.WalkSpeed * Time.deltaTime * this.h));
					}
				}
				else if (this.Stance.Current == StanceType.Crawling)
				{
					this.CharacterAnimation.CrossFade(this.CrawlIdleAnim);
				}
				else if (this.Stance.Current == StanceType.Crouching)
				{
					this.CharacterAnimation.CrossFade(this.CrouchIdleAnim);
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
				}
				if (!this.RPGCamera.invertAxis)
				{
					this.Bend += Input.GetAxis("Mouse Y") * 8f;
				}
				else
				{
					this.Bend -= Input.GetAxis("Mouse Y") * 8f;
				}
				if (this.Stance.Current == StanceType.Crawling)
				{
					if (this.Bend < 0f)
					{
						this.Bend = 0f;
					}
				}
				else if (this.Stance.Current == StanceType.Crouching)
				{
					if (this.Bend < -45f)
					{
						this.Bend = -45f;
					}
				}
				else if (this.Bend < -85f)
				{
					this.Bend = -85f;
				}
				if (this.Bend > 85f)
				{
					this.Bend = 85f;
				}
				base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * 8f, base.transform.localEulerAngles.z);
			}
			if (!this.NearSenpai)
			{
				if (!Input.GetButton("A") && !Input.GetButton("B") && !Input.GetButton("X") && !Input.GetButton("Y") && !this.StudentManager.Clock.UpdateBloom && (Input.GetAxis("LT") > 0.5f || Input.GetMouseButton(1)))
				{
					if (this.Inventory.RivalPhone)
					{
						if (Input.GetButtonDown("LB"))
						{
							this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
							this.CharacterAnimation["f02_selfie_00"].weight = 0f;
							if (!this.RivalPhone)
							{
								this.SmartphoneRenderer.material.mainTexture = this.RivalPhoneTexture;
								this.PhonePromptBar.Label.text = "SWITCH TO YOUR PHONE";
								this.RivalPhone = true;
							}
							else
							{
								this.SmartphoneRenderer.material.mainTexture = this.YanderePhoneTexture;
								this.PhonePromptBar.Label.text = "SWITCH TO STOLEN PHONE";
								this.RivalPhone = false;
							}
						}
					}
					else if (!this.Selfie && Input.GetButtonDown("LB"))
					{
						if (!this.AR)
						{
							this.Smartphone.cullingMask |= 1 << LayerMask.NameToLayer("Miyuki");
							this.AR = true;
						}
						else
						{
							this.Smartphone.cullingMask &= ~(1 << LayerMask.NameToLayer("Miyuki"));
							this.AR = false;
						}
					}
					if (Input.GetAxis("LT") > 0.5f)
					{
						this.UsingController = true;
					}
					if (!this.Aiming)
					{
						if (this.CameraEffects.OneCamera)
						{
							this.MainCamera.clearFlags = CameraClearFlags.Color;
							this.MainCamera.farClipPlane = 0.02f;
							this.HandCamera.clearFlags = CameraClearFlags.Color;
						}
						else
						{
							this.MainCamera.clearFlags = CameraClearFlags.Skybox;
							this.MainCamera.farClipPlane = (float)OptionGlobals.DrawDistance;
							this.HandCamera.clearFlags = CameraClearFlags.Depth;
						}
						base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, this.MainCamera.transform.eulerAngles.y, base.transform.eulerAngles.z);
						this.CharacterAnimation.Play(this.IdleAnim);
						this.Smartphone.transform.parent.gameObject.SetActive(true);
						if (!this.CinematicCamera.activeInHierarchy)
						{
							this.DisableHairAndAccessories();
						}
						this.HandCamera.gameObject.SetActive(true);
						this.ShoulderCamera.AimingCamera = true;
						this.Obscurance.enabled = false;
						this.YandereVision = false;
						this.Blur.enabled = true;
						this.Mopping = false;
						this.Selfie = false;
						this.Aiming = true;
						this.EmptyHands();
						this.PhonePromptBar.Panel.enabled = true;
						this.PhonePromptBar.Show = true;
						if (this.Inventory.RivalPhone)
						{
							if (!this.RivalPhone)
							{
								this.PhonePromptBar.Label.text = "SWITCH TO STOLEN PHONE";
							}
							else
							{
								this.PhonePromptBar.Label.text = "SWITCH TO YOUR PHONE";
							}
						}
						else
						{
							this.PhonePromptBar.Label.text = "AR GAME ON/OFF";
						}
						Time.timeScale = 1f;
						this.UpdateSelfieStatus();
						this.StudentManager.UpdatePanties(true);
					}
				}
				this.PermitLaugh += Time.deltaTime;
				if (!this.Aiming && !this.Accessories[9].activeInHierarchy && !this.Accessories[16].activeInHierarchy && !this.Pod.activeInHierarchy && this.PermitLaugh > 1f)
				{
					if (Input.GetButton("RB"))
					{
						if (this.MagicalGirl)
						{
							if (this.Armed && this.EquippedWeapon.WeaponID == 14 && Input.GetButtonDown("RB") && !this.ShootingBeam)
							{
								AudioSource.PlayClipAtPoint(this.LoveLoveBeamVoice, base.transform.position);
								this.CharacterAnimation["f02_LoveLoveBeam_00"].time = 0f;
								this.CharacterAnimation.CrossFade("f02_LoveLoveBeam_00");
								this.ShootingBeam = true;
								this.CanMove = false;
							}
						}
						else if (this.BlackRobe.activeInHierarchy)
						{
							if (Input.GetButtonDown("RB"))
							{
								AudioSource.PlayClipAtPoint(this.SithOn, base.transform.position);
							}
							this.SithTrailEnd1.localPosition = new Vector3(-1f, 0f, 0f);
							this.SithTrailEnd2.localPosition = new Vector3(1f, 0f, 0f);
							this.Beam[0].Play();
							this.Beam[1].Play();
							this.Beam[2].Play();
							this.Beam[3].Play();
							if (Input.GetButtonDown("X"))
							{
								this.CharacterAnimation["f02_sithAttack_00"].time = 0f;
								this.CharacterAnimation.Play("f02_sithAttack_00");
								this.SithBeam[1].Damage = 10f;
								this.SithBeam[2].Damage = 10f;
								this.SithAttacking = true;
								this.CanMove = false;
								this.SithPrefix = "";
								this.AttackPrefix = "sith";
							}
							if (Input.GetButtonDown("Y"))
							{
								this.CharacterAnimation["f02_sithAttackHard_00"].time = 0f;
								this.CharacterAnimation.Play("f02_sithAttackHard_00");
								this.SithBeam[1].Damage = 20f;
								this.SithBeam[2].Damage = 20f;
								this.SithAttacking = true;
								this.CanMove = false;
								this.SithPrefix = "Hard";
								this.AttackPrefix = "sith";
							}
						}
						else if (Input.GetButtonDown("RB") && this.SpiderLegs.activeInHierarchy)
						{
							this.SpiderGrow = !this.SpiderGrow;
							if (this.SpiderGrow)
							{
								AudioSource.PlayClipAtPoint(this.EmptyDemon.MouthOpen, base.transform.position);
							}
							else
							{
								AudioSource.PlayClipAtPoint(this.EmptyDemon.MouthClose, base.transform.position);
							}
							this.StudentManager.UpdateStudents(0);
						}
						this.YandereTimer += Time.deltaTime;
						if (this.YandereTimer > 0.5f)
						{
							if (!this.Sans && !this.BlackRobe.activeInHierarchy)
							{
								this.YandereVision = true;
							}
							else if (this.Sans)
							{
								this.SansEyes[0].SetActive(true);
								this.SansEyes[1].SetActive(true);
								this.GlowEffect.Play();
								this.SummonBones = true;
								this.YandereTimer = 0f;
								this.CanMove = false;
							}
						}
					}
					else
					{
						if (this.BlackRobe.activeInHierarchy)
						{
							this.SithTrailEnd1.localPosition = new Vector3(0f, 0f, 0f);
							this.SithTrailEnd2.localPosition = new Vector3(0f, 0f, 0f);
							if (Input.GetButtonUp("RB"))
							{
								AudioSource.PlayClipAtPoint(this.SithOff, base.transform.position);
							}
							this.Beam[0].Stop();
							this.Beam[1].Stop();
							this.Beam[2].Stop();
							this.Beam[3].Stop();
						}
						if (this.YandereVision)
						{
							this.Obscurance.enabled = false;
							this.YandereVision = false;
						}
					}
					if (Input.GetButtonUp("RB"))
					{
						if (this.Stance.Current != StanceType.Crouching && this.Stance.Current != StanceType.Crawling && this.YandereTimer < 0.5f && !this.Dragging && !this.Carrying && !this.Pod.activeInHierarchy && !this.Laughing)
						{
							if (this.Sans)
							{
								this.BlasterStage++;
								if (this.BlasterStage > 5)
								{
									this.BlasterStage = 1;
								}
								GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BlasterSet[this.BlasterStage], base.transform.position, Quaternion.identity);
								gameObject.transform.position = base.transform.position;
								gameObject.transform.rotation = base.transform.rotation;
								AudioSource.PlayClipAtPoint(this.BlasterClip, base.transform.position + Vector3.up);
								this.CharacterAnimation["f02_sansBlaster_00"].time = 0f;
								this.CharacterAnimation.Play("f02_sansBlaster_00");
								this.SansEyes[0].SetActive(true);
								this.SansEyes[1].SetActive(true);
								this.GlowEffect.Play();
								this.Blasting = true;
								this.CanMove = false;
							}
							else if (!this.BlackRobe.activeInHierarchy)
							{
								if (this.Kagune[0].activeInHierarchy)
								{
									if (!this.SwingKagune)
									{
										AudioSource.PlayClipAtPoint(this.KaguneSwoosh, base.transform.position + Vector3.up);
										this.SwingKagune = true;
									}
								}
								else if (this.Gazing || this.Shipgirl)
								{
									if (this.Gazing)
									{
										this.CharacterAnimation["f02_gazerSnap_00"].time = 0f;
										this.CharacterAnimation.CrossFade("f02_gazerSnap_00");
									}
									else
									{
										this.CharacterAnimation["f02_shipGirlSnap_00"].time = 0f;
										this.CharacterAnimation.CrossFade("f02_shipGirlSnap_00");
									}
									this.Snapping = true;
									this.CanMove = false;
								}
								else if (this.WitchMode)
								{
									if (!this.StoppingTime)
									{
										this.CharacterAnimation["f02_summonStand_00"].time = 0f;
										if (this.Freezing)
										{
											AudioSource.PlayClipAtPoint(this.StartShout, base.transform.position);
										}
										else
										{
											AudioSource.PlayClipAtPoint(this.StopShout, base.transform.position);
										}
										this.Freezing = !this.InvertSphere.gameObject.activeInHierarchy;
										this.StoppingTime = true;
										this.CanMove = false;
										this.MyAudio.Stop();
										this.Egg = true;
									}
								}
								else if (this.PickUp != null && this.PickUp.CarryAnimID == 10)
								{
									this.StudentManager.NoteWindow.gameObject.SetActive(true);
									this.StudentManager.NoteWindow.Show = true;
									this.PromptBar.Show = true;
									this.Blur.enabled = true;
									this.CanMove = false;
									Time.timeScale = 0.0001f;
									this.HUD.alpha = 0f;
									this.PromptBar.Label[0].text = "Confirm";
									this.PromptBar.Label[1].text = "Cancel";
									this.PromptBar.Label[4].text = "Select";
									this.PromptBar.UpdateButtons();
								}
								else if (!this.FalconHelmet.activeInHierarchy && !this.Cape.activeInHierarchy && !this.MagicalGirl)
								{
									if (!this.Xtan)
									{
										if (!this.CirnoHair.activeInHierarchy && !this.TornadoHair.activeInHierarchy && !this.BladeHair.activeInHierarchy)
										{
											this.LaughAnim = "f02_laugh_01";
											this.LaughClip = this.Laugh1;
											this.LaughIntensity += 1f;
											this.MyAudio.clip = this.LaughClip;
											this.MyAudio.time = 0f;
											this.MyAudio.Play();
										}
										this.GiggleLines.Play();
										UnityEngine.Object.Instantiate<GameObject>(this.GiggleDisc, base.transform.position + Vector3.up, Quaternion.identity);
										this.MyAudio.volume = 1f;
										this.LaughTimer = 0.5f;
										this.Laughing = true;
										this.Mopping = false;
										this.CanMove = false;
										this.Teeth.SetActive(false);
									}
									else if (this.LongHair[0].gameObject.activeInHierarchy)
									{
										this.LongHair[0].gameObject.SetActive(false);
										this.BlackEyePatch.SetActive(false);
										this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
										this.SlenderHair[0].SetActive(true);
										this.SlenderHair[1].SetActive(true);
									}
									else
									{
										this.LongHair[0].gameObject.SetActive(true);
										this.BlackEyePatch.SetActive(true);
										this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
										this.SlenderHair[0].SetActive(false);
										this.SlenderHair[1].SetActive(false);
									}
								}
								else if (!this.Punching)
								{
									if (this.FalconHelmet.activeInHierarchy)
									{
										GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.FalconWindUp);
										gameObject2.transform.parent = this.ItemParent;
										gameObject2.transform.localPosition = Vector3.zero;
										AudioClipPlayer.PlayAttached(this.FalconPunchVoice, this.MainCamera.transform, 5f, 10f);
										this.CharacterAnimation["f02_falconPunch_00"].time = 0f;
										this.CharacterAnimation.Play("f02_falconPunch_00");
										this.FalconSpeed = 0f;
									}
									else
									{
										GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.FalconWindUp);
										gameObject3.transform.parent = this.ItemParent;
										gameObject3.transform.localPosition = Vector3.zero;
										AudioSource.PlayClipAtPoint(this.OnePunchVoices[UnityEngine.Random.Range(0, this.OnePunchVoices.Length)], base.transform.position + Vector3.up);
										this.CharacterAnimation["f02_onePunch_00"].time = 0f;
										this.CharacterAnimation.CrossFade("f02_onePunch_00", 0.15f);
									}
									this.Punching = true;
									this.CanMove = false;
								}
							}
						}
						this.YandereTimer = 0f;
					}
				}
				if (this.Stance.Current != StanceType.Crouching && this.Stance.Current != StanceType.Crawling)
				{
					if (Input.GetButtonDown("RS"))
					{
						this.Obscurance.enabled = false;
						this.CrouchButtonDown = true;
						this.YandereVision = false;
						this.Stance.Current = StanceType.Crouching;
						this.Crouch();
						this.EmptyHands();
					}
				}
				else
				{
					if (this.Stance.Current == StanceType.Crouching)
					{
						if (Input.GetButton("RS") && !this.CameFromCrouch)
						{
							this.CrawlTimer += Time.deltaTime;
						}
						if (this.CrawlTimer > 0.5f)
						{
							if (!this.Selfie)
							{
								this.EmptyHands();
								this.Obscurance.enabled = false;
								this.YandereVision = false;
								this.Stance.Current = StanceType.Crawling;
								this.CrawlTimer = 0f;
								this.Crawl();
							}
						}
						else if (Input.GetButtonUp("RS") && !this.CrouchButtonDown && !this.CameFromCrouch)
						{
							this.Stance.Current = StanceType.Standing;
							this.CrawlTimer = 0f;
							this.Uncrouch();
						}
					}
					else if (Input.GetButtonDown("RS"))
					{
						this.CameFromCrouch = true;
						this.Stance.Current = StanceType.Crouching;
						this.Crouch();
					}
					if (Input.GetButtonUp("RS"))
					{
						this.CrouchButtonDown = false;
						this.CameFromCrouch = false;
						this.CrawlTimer = 0f;
					}
				}
			}
			if (this.Aiming)
			{
				if (!this.RivalPhone && Input.GetButtonDown("A"))
				{
					this.Selfie = !this.Selfie;
					this.UpdateSelfieStatus();
				}
				if (!this.Selfie)
				{
					this.CharacterAnimation["f02_cameraPose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_cameraPose_00"].weight, 1f, Time.deltaTime * 10f);
					this.CharacterAnimation["f02_selfie_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_selfie_00"].weight, 0f, Time.deltaTime * 10f);
				}
				else
				{
					this.CharacterAnimation["f02_cameraPose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_cameraPose_00"].weight, 0f, Time.deltaTime * 10f);
					this.CharacterAnimation["f02_selfie_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_selfie_00"].weight, 1f, Time.deltaTime * 10f);
					if (Input.GetButtonDown("B"))
					{
						if (!this.SelfieGuide.activeInHierarchy)
						{
							this.SelfieGuide.SetActive(true);
						}
						else
						{
							this.SelfieGuide.SetActive(false);
						}
					}
				}
				if (this.ClubAccessories[7].activeInHierarchy && (Input.GetAxis("DpadY") != 0f || Input.GetAxis("Mouse ScrollWheel") != 0f || Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.LeftShift)))
				{
					if (Input.GetKey(KeyCode.Tab))
					{
						this.Smartphone.fieldOfView -= Time.deltaTime * 100f;
					}
					if (Input.GetKey(KeyCode.LeftShift))
					{
						this.Smartphone.fieldOfView += Time.deltaTime * 100f;
					}
					this.Smartphone.fieldOfView -= Input.GetAxis("DpadY");
					this.Smartphone.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 10f;
					if (this.Smartphone.fieldOfView > 60f)
					{
						this.Smartphone.fieldOfView = 60f;
					}
					if (this.Smartphone.fieldOfView < 30f)
					{
						this.Smartphone.fieldOfView = 30f;
					}
				}
				if (Input.GetAxis("RT") == 1f || Input.GetMouseButtonDown(0) || Input.GetButtonDown("RB"))
				{
					this.FixCamera();
					this.PauseScreen.CorrectingTime = false;
					Time.timeScale = 0.0001f;
					this.CanMove = false;
					this.Shutter.Snap();
				}
				if (Time.timeScale > 0.0001f && ((this.UsingController && Input.GetAxis("LT") < 0.5f) || (!this.UsingController && !Input.GetMouseButton(1))))
				{
					this.StopAiming();
				}
				if (Input.GetKey(KeyCode.LeftAlt))
				{
					if (!this.CinematicCamera.activeInHierarchy)
					{
						if (this.CinematicTimer > 0f)
						{
							this.CinematicCamera.transform.eulerAngles = this.Smartphone.transform.eulerAngles;
							this.CinematicCamera.transform.position = this.Smartphone.transform.position;
							this.CinematicCamera.SetActive(true);
							this.CinematicTimer = 0f;
							this.UpdateHair();
							this.StopAiming();
						}
						this.CinematicTimer += 1f;
					}
				}
				else
				{
					this.CinematicTimer = 0f;
				}
			}
			if (this.Gloved)
			{
				if (!this.Chased && this.Chasers == 0)
				{
					if (this.InputDevice.Type == InputDeviceType.Gamepad)
					{
						if (Input.GetAxis("DpadY") < -0.5f)
						{
							this.GloveTimer += Time.deltaTime;
							if (this.GloveTimer > 0.5f)
							{
								this.CharacterAnimation.CrossFade("f02_removeGloves_00");
								this.Degloving = true;
								this.CanMove = false;
							}
						}
						else
						{
							this.GloveTimer = 0f;
						}
					}
					else if (Input.GetKey(KeyCode.Alpha1))
					{
						this.GloveTimer += Time.deltaTime;
						if (this.GloveTimer > 0.1f)
						{
							this.CharacterAnimation.CrossFade("f02_removeGloves_00");
							this.Degloving = true;
							this.CanMove = false;
						}
					}
					else
					{
						this.GloveTimer = 0f;
					}
				}
				else
				{
					this.GloveTimer = 0f;
				}
			}
			if (this.Weapon[1] != null && this.DropTimer[2] == 0f)
			{
				if (this.InputDevice.Type == InputDeviceType.Gamepad)
				{
					if (Input.GetAxis("DpadX") < -0.5f)
					{
						this.DropWeapon(1);
					}
					else
					{
						this.DropTimer[1] = 0f;
					}
				}
				else if (Input.GetKey(KeyCode.Alpha2))
				{
					this.DropWeapon(1);
				}
				else
				{
					this.DropTimer[1] = 0f;
				}
			}
			if (this.Weapon[2] != null && this.DropTimer[1] == 0f)
			{
				if (this.InputDevice.Type == InputDeviceType.Gamepad)
				{
					if (Input.GetAxis("DpadX") > 0.5f)
					{
						this.DropWeapon(2);
					}
					else
					{
						this.DropTimer[2] = 0f;
					}
				}
				else if (Input.GetKey(KeyCode.Alpha3))
				{
					this.DropWeapon(2);
				}
				else
				{
					this.DropTimer[2] = 0f;
				}
			}
			if (Input.GetButtonDown("LS") || Input.GetKeyDown(KeyCode.T))
			{
				if (this.NewTrail != null)
				{
					UnityEngine.Object.Destroy(this.NewTrail);
				}
				this.NewTrail = UnityEngine.Object.Instantiate<GameObject>(this.Trail, base.transform.position + base.transform.forward * 0.5f + Vector3.up * 0.1f, Quaternion.identity);
				if (SchemeGlobals.CurrentScheme == 0)
				{
					this.NewTrail.GetComponent<AIPath>().target = this.Homeroom;
				}
				else if (this.PauseScreen.Schemes.SchemeDestinations[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme)] != null)
				{
					this.NewTrail.GetComponent<AIPath>().target = this.PauseScreen.Schemes.SchemeDestinations[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme)];
				}
				else
				{
					UnityEngine.Object.Destroy(this.NewTrail);
				}
			}
			if (this.Armed)
			{
				this.ID = 0;
				while (this.ID < this.ArmedAnims.Length)
				{
					string name = this.ArmedAnims[this.ID];
					this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, (this.EquippedWeapon.AnimID == this.ID) ? 1f : 0f, Time.deltaTime * 10f);
					this.ID++;
				}
			}
			else
			{
				this.StopArmedAnim();
			}
			if (this.TheftTimer > 0f)
			{
				this.TheftTimer = Mathf.MoveTowards(this.TheftTimer, 0f, Time.deltaTime);
			}
			if (this.WeaponTimer > 0f)
			{
				this.WeaponTimer = Mathf.MoveTowards(this.WeaponTimer, 0f, Time.deltaTime);
			}
			if (this.MurderousActionTimer > 0f)
			{
				this.MurderousActionTimer = Mathf.MoveTowards(this.MurderousActionTimer, 0f, Time.deltaTime);
				if (this.MurderousActionTimer == 0f)
				{
					this.TargetStudent = null;
				}
			}
			if (this.Chased)
			{
				this.PreparedForStruggle = true;
				this.CanMove = false;
			}
			if (this.Egg)
			{
				if (this.Eating)
				{
					this.FollowHips = false;
					this.Attacking = false;
					this.CanMove = true;
					this.Eating = false;
					this.EatPhase = 0;
				}
				if (this.Pod.activeInHierarchy)
				{
					if (!this.SithAttacking)
					{
						if (this.LightSword.transform.parent != this.LightSwordParent)
						{
							this.LightSword.transform.parent = this.LightSwordParent;
							this.LightSword.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.LightSword.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							this.LightSwordParticles.Play();
						}
						if (this.HeavySword.transform.parent != this.HeavySwordParent)
						{
							this.HeavySword.transform.parent = this.HeavySwordParent;
							this.HeavySword.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.HeavySword.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							this.HeavySwordParticles.Play();
						}
					}
					if (Input.GetButtonDown("X"))
					{
						this.LightSword.transform.parent = this.LeftItemParent;
						this.LightSword.transform.localPosition = new Vector3(-0.015f, 0f, 0f);
						this.LightSword.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
						this.LightSword.GetComponent<WeaponTrail>().enabled = true;
						this.LightSword.GetComponent<WeaponTrail>().Start();
						this.CharacterAnimation["f02_nierAttack_00"].time = 0f;
						this.CharacterAnimation.Play("f02_nierAttack_00");
						this.SithAttacking = true;
						this.CanMove = false;
						this.SithBeam[1].Damage = 10f;
						this.NierDamage = 10f;
						this.SithPrefix = "";
						this.AttackPrefix = "nier";
					}
					if (Input.GetButtonDown("Y"))
					{
						this.HeavySword.transform.parent = this.ItemParent;
						this.HeavySword.transform.localPosition = new Vector3(-0.015f, 0f, 0f);
						this.HeavySword.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
						this.HeavySword.GetComponent<WeaponTrail>().enabled = true;
						this.HeavySword.GetComponent<WeaponTrail>().Start();
						this.CharacterAnimation["f02_nierAttackHard_00"].time = 0f;
						this.CharacterAnimation.Play("f02_nierAttackHard_00");
						this.SithAttacking = true;
						this.CanMove = false;
						this.SithBeam[1].Damage = 20f;
						this.NierDamage = 20f;
						this.SithPrefix = "Hard";
						this.AttackPrefix = "nier";
					}
				}
				if (this.WitchMode && Input.GetButtonDown("X") && this.InvertSphere.gameObject.activeInHierarchy)
				{
					this.CharacterAnimation["f02_fingerSnap_00"].time = 0f;
					this.CharacterAnimation.Play("f02_fingerSnap_00");
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.Snapping = true;
					this.CanMove = false;
				}
				if (this.Armor[20].activeInHierarchy && this.Armor[20].transform.parent == this.ItemParent && (Input.GetButtonDown("X") || Input.GetButtonDown("Y")))
				{
					this.CharacterAnimation["f02_nierAttackHard_00"].time = 0f;
					this.CharacterAnimation.Play("f02_nierAttackHard_00");
					this.SithAttacking = true;
					this.CanMove = false;
					this.SithBeam[1].Damage = 20f;
					this.NierDamage = 20f;
					this.SithPrefix = "Hard";
					this.AttackPrefix = "nier";
					return;
				}
			}
		}
		else
		{
			if (this.Chased && !this.Sprayed && !this.Attacking && !this.Dumping && !this.StudentManager.PinningDown && !this.DelinquentFighting && !this.ShoulderCamera.HeartbrokenCamera.activeInHierarchy)
			{
				if (this.Pursuer != null)
				{
					this.targetRotation = Quaternion.LookRotation(this.Pursuer.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					this.CharacterAnimation.CrossFade("f02_readyToFight_00");
					if (this.Dragging || this.Carrying)
					{
						this.EmptyHands();
					}
				}
				else
				{
					this.PreparedForStruggle = false;
					this.CanMove = true;
					this.Chased = false;
				}
			}
			this.StopArmedAnim();
			if (this.Dumping)
			{
				this.targetRotation = Quaternion.LookRotation(this.Incinerator.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.Incinerator.transform.position + Vector3.right * -2f);
				if (this.DumpTimer == 0f && this.Carrying)
				{
					this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
				}
				this.DumpTimer += Time.deltaTime;
				if (this.DumpTimer > 1f)
				{
					if (this.Ragdoll != null && !this.Ragdoll.GetComponent<RagdollScript>().Dumped)
					{
						this.DumpRagdoll(RagdollDumpType.Incinerator);
					}
					this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
					if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length)
					{
						this.Incinerator.Prompt.enabled = true;
						this.Incinerator.Ready = true;
						this.Incinerator.Open = false;
						this.Dragging = false;
						this.Dumping = false;
						this.CanMove = true;
						this.Ragdoll = null;
						this.StopCarrying();
						this.DumpTimer = 0f;
					}
				}
			}
			if (this.Chipping)
			{
				this.targetRotation = Quaternion.LookRotation(this.WoodChipper.gameObject.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.WoodChipper.DumpPoint.position);
				if (this.DumpTimer == 0f && this.Carrying)
				{
					this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
				}
				this.DumpTimer += Time.deltaTime;
				if (this.DumpTimer > 1f)
				{
					if (!this.Ragdoll.GetComponent<RagdollScript>().Dumped)
					{
						this.DumpRagdoll(RagdollDumpType.WoodChipper);
					}
					this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
					if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length)
					{
						this.WoodChipper.Prompt.HideButton[0] = false;
						this.WoodChipper.Prompt.HideButton[3] = true;
						this.WoodChipper.Occupied = true;
						this.WoodChipper.Open = false;
						this.Dragging = false;
						this.Chipping = false;
						this.CanMove = true;
						this.Ragdoll = null;
						this.StopCarrying();
						this.DumpTimer = 0f;
					}
				}
			}
			if (this.TranquilHiding)
			{
				this.targetRotation = Quaternion.LookRotation(this.TranqCase.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.TranqCase.transform.position + Vector3.right * 1.4f);
				if (this.DumpTimer == 0f && this.Carrying)
				{
					this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
				}
				this.DumpTimer += Time.deltaTime;
				if (this.DumpTimer > 1f)
				{
					if (!this.Ragdoll.GetComponent<RagdollScript>().Dumped)
					{
						this.DumpRagdoll(RagdollDumpType.TranqCase);
					}
					this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
					if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length)
					{
						this.TranquilHiding = false;
						this.Dragging = false;
						this.Dumping = false;
						this.CanMove = true;
						this.Ragdoll = null;
						this.StopCarrying();
						this.DumpTimer = 0f;
					}
				}
			}
			if (this.Dipping)
			{
				if (this.Bucket != null)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Bucket.transform.position.x, base.transform.position.y, this.Bucket.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				}
				this.CharacterAnimation.CrossFade("f02_dipping_00");
				if (this.CharacterAnimation["f02_dipping_00"].time >= this.CharacterAnimation["f02_dipping_00"].length * 0.5f)
				{
					this.Mop.Bleached = true;
					this.Mop.Sparkles.Play();
					if (this.Mop.Bloodiness > 0f)
					{
						if (this.Bucket != null)
						{
							this.Bucket.Bloodiness += this.Mop.Bloodiness / 2f;
							this.Bucket.UpdateAppearance = true;
						}
						this.Mop.Bloodiness = 0f;
						this.Mop.UpdateBlood();
					}
				}
				if (this.CharacterAnimation["f02_dipping_00"].time >= this.CharacterAnimation["f02_dipping_00"].length)
				{
					this.CharacterAnimation["f02_dipping_00"].time = 0f;
					this.Mop.Prompt.enabled = true;
					this.Dipping = false;
					this.CanMove = true;
				}
			}
			if (this.Pouring)
			{
				this.MoveTowardsTarget(this.Stool.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Stool.rotation, 10f * Time.deltaTime);
				string text = "f02_bucketDump" + this.PourHeight + "_00";
				AnimationState animationState = this.CharacterAnimation[text];
				this.CharacterAnimation.CrossFade(text, 0f);
				if (animationState.time >= this.PourTime && !this.PickUp.Bucket.Poured)
				{
					if (this.PickUp.Bucket.Gasoline)
					{
						this.PickUp.Bucket.PourEffect.main.startColor = new Color(1f, 1f, 0f, 0.5f);
						UnityEngine.Object.Instantiate<GameObject>(this.PickUp.Bucket.GasCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * base.transform.forward, Quaternion.identity);
					}
					else if (this.PickUp.Bucket.Bloodiness < 50f)
					{
						this.PickUp.Bucket.PourEffect.main.startColor = new Color(0f, 1f, 1f, 0.5f);
						UnityEngine.Object.Instantiate<GameObject>(this.PickUp.Bucket.WaterCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * base.transform.forward, Quaternion.identity);
					}
					else
					{
						this.PickUp.Bucket.PourEffect.main.startColor = new Color(0.5f, 0f, 0f, 0.5f);
						UnityEngine.Object.Instantiate<GameObject>(this.PickUp.Bucket.BloodCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * base.transform.forward, Quaternion.identity);
					}
					this.PickUp.Bucket.PourEffect.Play();
					this.PickUp.Bucket.Poured = true;
					this.PickUp.Bucket.Empty();
				}
				if (animationState.time >= animationState.length)
				{
					animationState.time = 0f;
					this.PickUp.Bucket.Poured = false;
					this.Pouring = false;
					this.CanMove = true;
				}
			}
			if (this.Laughing)
			{
				if (this.Hairstyles[14].activeInHierarchy)
				{
					this.LaughAnim = "storepower_20";
					this.LaughClip = this.ChargeUp;
				}
				if (this.Stand.Stand.activeInHierarchy)
				{
					this.LaughAnim = "f02_jojoAttack_00";
					this.LaughClip = this.YanYan;
				}
				else if (this.FlameDemonic)
				{
					float axis = Input.GetAxis("Vertical");
					float axis2 = Input.GetAxis("Horizontal");
					Vector3 vector2 = this.MainCamera.transform.TransformDirection(Vector3.forward);
					vector2.y = 0f;
					vector2 = vector2.normalized;
					Vector3 a2 = new Vector3(vector2.z, 0f, -vector2.x);
					Vector3 vector3 = axis2 * a2 + axis * vector2;
					if (vector3 != Vector3.zero)
					{
						this.targetRotation = Quaternion.LookRotation(vector3);
						base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					}
					this.LaughAnim = "f02_demonAttack_00";
					this.CirnoTimer -= Time.deltaTime;
					if (this.CirnoTimer < 0f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.Fireball, this.RightHand.position, base.transform.rotation).transform.localEulerAngles += new Vector3(UnityEngine.Random.Range(0f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f));
						UnityEngine.Object.Instantiate<GameObject>(this.Fireball, this.LeftHand.position, base.transform.rotation).transform.localEulerAngles += new Vector3(UnityEngine.Random.Range(0f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f));
						this.CirnoTimer = 0.1f;
					}
				}
				else if (this.CirnoHair.activeInHierarchy)
				{
					float axis3 = Input.GetAxis("Vertical");
					float axis4 = Input.GetAxis("Horizontal");
					Vector3 vector4 = this.MainCamera.transform.TransformDirection(Vector3.forward);
					vector4.y = 0f;
					vector4 = vector4.normalized;
					Vector3 a3 = new Vector3(vector4.z, 0f, -vector4.x);
					Vector3 vector5 = axis4 * a3 + axis3 * vector4;
					if (vector5 != Vector3.zero)
					{
						this.targetRotation = Quaternion.LookRotation(vector5);
						base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					}
					this.LaughAnim = "f02_cirnoAttack_00";
					this.CirnoTimer -= Time.deltaTime;
					if (this.CirnoTimer < 0f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.CirnoIceAttack, base.transform.position + base.transform.up * 1.4f, base.transform.rotation).transform.localEulerAngles += new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
						this.MyAudio.PlayOneShot(this.CirnoIceClip);
						this.CirnoTimer = 0.1f;
					}
				}
				else if (this.TornadoHair.activeInHierarchy)
				{
					this.LaughAnim = "f02_tornadoAttack_00";
					this.CirnoTimer -= Time.deltaTime;
					if (this.CirnoTimer < 0f)
					{
						GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.TornadoAttack, base.transform.forward * 5f + new Vector3(base.transform.position.x + UnityEngine.Random.Range(-5f, 5f), base.transform.position.y, base.transform.position.z + UnityEngine.Random.Range(-5f, 5f)), base.transform.rotation);
						while (Vector3.Distance(base.transform.position, gameObject4.transform.position) < 1f)
						{
							gameObject4.transform.position = base.transform.forward * 5f + new Vector3(base.transform.position.x + UnityEngine.Random.Range(-5f, 5f), base.transform.position.y, base.transform.position.z + UnityEngine.Random.Range(-5f, 5f));
						}
						this.CirnoTimer = 0.1f;
					}
				}
				else if (this.BladeHair.activeInHierarchy)
				{
					this.LaughAnim = "f02_spin_00";
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y + Time.deltaTime * 360f * 2f, base.transform.localEulerAngles.z);
					this.BladeHairCollider1.enabled = true;
					this.BladeHairCollider2.enabled = true;
				}
				else if (this.BanchoActive)
				{
					this.BanchoFlurry.MyCollider.enabled = true;
					this.LaughAnim = "f02_banchoFlurry_00";
				}
				else if (this.MyAudio.clip != this.LaughClip)
				{
					this.MyAudio.clip = this.LaughClip;
					this.MyAudio.time = 0f;
					this.MyAudio.Play();
				}
				this.CharacterAnimation.CrossFade(this.LaughAnim);
				if (Input.GetButtonDown("RB"))
				{
					this.LaughIntensity += 1f;
					if (this.LaughIntensity <= 5f)
					{
						this.LaughAnim = "f02_laugh_01";
						this.LaughClip = this.Laugh1;
						this.LaughTimer = 0.5f;
					}
					else if (this.LaughIntensity <= 10f)
					{
						this.LaughAnim = "f02_laugh_02";
						this.LaughClip = this.Laugh2;
						this.LaughTimer = 1f;
					}
					else if (this.LaughIntensity <= 15f)
					{
						this.LaughAnim = "f02_laugh_03";
						this.LaughClip = this.Laugh3;
						this.LaughTimer = 1.5f;
					}
					else if (this.LaughIntensity <= 20f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
						this.LaughAnim = "f02_laugh_04";
						this.LaughClip = this.Laugh4;
						this.LaughTimer = 2f;
					}
					else
					{
						UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
						this.LaughAnim = "f02_laugh_04";
						this.LaughIntensity = 20f;
						this.LaughTimer = 2f;
					}
				}
				if (this.LaughIntensity > 15f)
				{
					this.Sanity += Time.deltaTime * 10f;
				}
				this.LaughTimer -= Time.deltaTime;
				if (this.LaughTimer <= 0f)
				{
					this.StopLaughing();
				}
			}
			if (this.TimeSkipping)
			{
				base.transform.position = new Vector3(base.transform.position.x, this.TimeSkipHeight, base.transform.position.z);
				this.CharacterAnimation.CrossFade("f02_timeSkip_00");
				this.MyController.Move(base.transform.up * 0.0001f);
				this.Sanity += Time.deltaTime * 0.17f;
			}
			if (this.DumpsterGrabbing)
			{
				if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetKey("right"))
				{
					this.CharacterAnimation.CrossFade((this.DumpsterHandle.Direction == -1f) ? "f02_dumpsterPull_00" : "f02_dumpsterPush_00");
				}
				else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetKey("left"))
				{
					this.CharacterAnimation.CrossFade((this.DumpsterHandle.Direction == -1f) ? "f02_dumpsterPush_00" : "f02_dumpsterPull_00");
				}
				else
				{
					this.CharacterAnimation.CrossFade("f02_dumpsterGrab_00");
				}
			}
			if (this.Stripping)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.StudentManager.YandereStripSpot.rotation, 10f * Time.deltaTime);
				if (this.CharacterAnimation["f02_stripping_00"].time >= this.CharacterAnimation["f02_stripping_00"].length)
				{
					this.Stripping = false;
					this.CanMove = true;
					this.MyLocker.UpdateSchoolwear();
				}
			}
			if (this.Bathing)
			{
				this.MoveTowardsTarget(this.YandereShower.BatheSpot.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.YandereShower.BatheSpot.rotation, 10f * Time.deltaTime);
				this.CharacterAnimation.CrossFade(this.IdleAnim);
				if (this.YandereShower.Timer < 1f)
				{
					this.Bloodiness = 0f;
					this.Bathing = false;
					this.CanMove = true;
				}
			}
			if (this.Degloving)
			{
				this.CharacterAnimation.CrossFade("f02_removeGloves_00");
				if (this.CharacterAnimation["f02_removeGloves_00"].time >= this.CharacterAnimation["f02_removeGloves_00"].length)
				{
					this.Gloves.GetComponent<Rigidbody>().isKinematic = false;
					this.Gloves.transform.parent = null;
					this.GloveAttacher.newRenderer.enabled = false;
					this.Gloves.gameObject.SetActive(true);
					this.Degloving = false;
					this.CanMove = true;
					this.Gloved = false;
					this.Gloves = null;
					this.SetUniform();
					this.GloveBlood = 0;
					Debug.Log("Gloves removed.");
				}
				else if (this.Chased || this.Chasers > 0 || this.Noticed)
				{
					this.Degloving = false;
					this.GloveTimer = 0f;
					if (!this.Noticed)
					{
						this.CanMove = true;
					}
				}
				else if (this.InputDevice.Type == InputDeviceType.Gamepad)
				{
					if (Input.GetAxis("DpadY") > -0.5f)
					{
						this.Degloving = false;
						this.CanMove = true;
						this.GloveTimer = 0f;
					}
				}
				else if (Input.GetKeyUp(KeyCode.Alpha1))
				{
					this.Degloving = false;
					this.CanMove = true;
					this.GloveTimer = 0f;
				}
			}
			if (this.Struggling)
			{
				if (!this.Won && !this.Lost)
				{
					this.CharacterAnimation.CrossFade(this.TargetStudent.Teacher ? "f02_teacherStruggleA_00" : "f02_struggleA_00");
					this.targetRotation = Quaternion.LookRotation(this.TargetStudent.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				}
				else if (this.Won)
				{
					if (!this.TargetStudent.Teacher)
					{
						this.CharacterAnimation.CrossFade("f02_struggleWinA_00");
						if (this.CharacterAnimation["f02_struggleWinA_00"].time > this.CharacterAnimation["f02_struggleWinA_00"].length - 1f)
						{
							this.EquippedWeapon.transform.localEulerAngles = Vector3.Lerp(this.EquippedWeapon.transform.localEulerAngles, Vector3.zero, Time.deltaTime * 3.33333f);
						}
					}
					else
					{
						Debug.Log(this.TargetStudent.Name + " is being instructed to perform their ''losing struggle'' animation.");
						this.CharacterAnimation.CrossFade("f02_teacherStruggleWinA_00");
						this.TargetStudent.CharacterAnimation.CrossFade(this.TargetStudent.StruggleWonAnim);
						this.EquippedWeapon.transform.localEulerAngles = Vector3.Lerp(this.EquippedWeapon.transform.localEulerAngles, Vector3.zero, Time.deltaTime);
					}
					if (this.StrugglePhase == 0)
					{
						if ((!this.TargetStudent.Teacher && this.CharacterAnimation["f02_struggleWinA_00"].time > 1.3f) || (this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 0.8f))
						{
							Debug.Log("Yandere-chan just killed " + this.TargetStudent.Name + " as a result of winning a struggling against them.");
							this.TargetStudent.DeathCause = this.EquippedWeapon.WeaponID;
							UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.TargetStudent.Teacher ? this.EquippedWeapon.transform.position : this.TargetStudent.Head.position, Quaternion.identity);
							this.Bloodiness += 20f;
							this.Sanity -= 20f * this.Numbness;
							this.StainWeapon();
							this.StrugglePhase++;
						}
					}
					else if (this.StrugglePhase == 1)
					{
						if (this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 1.3f)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.EquippedWeapon.transform.position, Quaternion.identity);
							this.StrugglePhase++;
						}
					}
					else if (this.StrugglePhase == 2 && this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 2.1f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.EquippedWeapon.transform.position, Quaternion.identity);
						this.StrugglePhase++;
					}
					if ((!this.TargetStudent.Teacher && this.CharacterAnimation["f02_struggleWinA_00"].time > this.CharacterAnimation["f02_struggleWinA_00"].length) || (this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > this.CharacterAnimation["f02_teacherStruggleWinA_00"].length))
					{
						this.MyController.radius = 0.2f;
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.ShoulderCamera.Struggle = false;
						this.Struggling = false;
						this.StrugglePhase = 0;
						if (this.TargetStudent == this.Pursuer)
						{
							this.Pursuer = null;
							this.Chased = false;
						}
						this.TargetStudent.BecomeRagdoll();
						this.TargetStudent.DeathType = DeathType.Weapon;
						this.SeenByAuthority = false;
					}
				}
				else if (this.Lost)
				{
					this.CharacterAnimation.CrossFade(this.TargetStudent.Teacher ? "f02_teacherStruggleLoseA_00" : "f02_struggleLoseA_00");
				}
			}
			if (this.ClubActivity)
			{
				if (this.Club == ClubType.Drama)
				{
					this.CharacterAnimation.Play("f02_performing_00");
				}
				else if (this.Club == ClubType.Art)
				{
					this.CharacterAnimation.Play("f02_painting_00");
				}
				else if (this.Club == ClubType.MartialArts)
				{
					this.CharacterAnimation.Play("f02_kick_23");
					if (this.CharacterAnimation["f02_kick_23"].time >= this.CharacterAnimation["f02_kick_23"].length)
					{
						this.CharacterAnimation["f02_kick_23"].time = 0f;
					}
				}
				else if (this.Club == ClubType.Photography)
				{
					this.CharacterAnimation.Play("f02_sit_00");
				}
				else if (this.Club == ClubType.Gaming)
				{
					this.CharacterAnimation.Play("f02_playingGames_00");
				}
			}
			if (this.Possessed)
			{
				this.CharacterAnimation.CrossFade("f02_possessionPose_00");
			}
			if (this.Lifting)
			{
				if (!this.HeavyWeight)
				{
					if (this.CharacterAnimation["f02_carryLiftA_00"].time >= this.CharacterAnimation["f02_carryLiftA_00"].length)
					{
						this.IdleAnim = this.CarryIdleAnim;
						this.WalkAnim = this.CarryWalkAnim;
						this.RunAnim = this.CarryRunAnim;
						this.CanMove = true;
						this.Carrying = true;
						this.Lifting = false;
					}
				}
				else if (this.CharacterAnimation["f02_heavyWeightLift_00"].time >= this.CharacterAnimation["f02_heavyWeightLift_00"].length)
				{
					this.CharacterAnimation[this.CarryAnims[0]].weight = 1f;
					this.IdleAnim = this.HeavyIdleAnim;
					this.WalkAnim = this.HeavyWalkAnim;
					this.RunAnim = this.CarryRunAnim;
					this.CanMove = true;
					this.Lifting = false;
				}
			}
			if (this.Dropping)
			{
				this.targetRotation = Quaternion.LookRotation(this.DropSpot.position + this.DropSpot.forward - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.DropSpot.position);
				if (this.Ragdoll != null && this.CurrentRagdoll == null)
				{
					this.CurrentRagdoll = this.Ragdoll.GetComponent<RagdollScript>();
				}
				if (this.DumpTimer == 0f && this.Carrying)
				{
					this.CurrentRagdoll.CharacterAnimation[this.CurrentRagdoll.DumpedAnim].time = 2.5f;
					this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
				}
				this.DumpTimer += Time.deltaTime;
				if (this.DumpTimer > 1f)
				{
					this.FollowHips = true;
					if (this.Ragdoll != null)
					{
						this.CurrentRagdoll.PelvisRoot.localEulerAngles = new Vector3(this.CurrentRagdoll.PelvisRoot.localEulerAngles.x, 0f, this.CurrentRagdoll.PelvisRoot.localEulerAngles.z);
						this.CurrentRagdoll.PelvisRoot.localPosition = new Vector3(this.CurrentRagdoll.PelvisRoot.localPosition.x, this.CurrentRagdoll.PelvisRoot.localPosition.y, 0f);
					}
					this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(this.Hips.position.x, base.transform.position.y + 1f, this.Hips.position.z), Time.deltaTime * 10f);
					if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= 4.5f)
					{
						this.StopCarrying();
					}
					else
					{
						if (this.CurrentRagdoll.StopAnimation)
						{
							this.CurrentRagdoll.StopAnimation = false;
							this.ID = 0;
							while (this.ID < this.CurrentRagdoll.AllRigidbodies.Length)
							{
								this.CurrentRagdoll.AllRigidbodies[this.ID].isKinematic = true;
								this.ID++;
							}
						}
						this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
						this.CurrentRagdoll.CharacterAnimation.CrossFade(this.CurrentRagdoll.DumpedAnim);
						this.Ragdoll.transform.position = base.transform.position;
						this.Ragdoll.transform.eulerAngles = base.transform.eulerAngles;
					}
					if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length)
					{
						this.CameraTarget.localPosition = new Vector3(0f, 1f, 0f);
						this.FollowHips = false;
						this.Dropping = false;
						this.CanMove = true;
						this.DumpTimer = 0f;
					}
				}
			}
			if (this.Dismembering && this.CharacterAnimation["f02_dismember_00"].time >= this.CharacterAnimation["f02_dismember_00"].length)
			{
				this.Ragdoll.GetComponent<RagdollScript>().Dismember();
				this.RPGCamera.enabled = true;
				this.TargetStudent = null;
				this.Dismembering = false;
				this.CanMove = true;
				this.Ragdoll = null;
			}
			if (this.Shoved)
			{
				if (this.CharacterAnimation["f02_shoveA_01"].time >= this.CharacterAnimation["f02_shoveA_01"].length)
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.Shoved = false;
					if (!this.CannotRecover)
					{
						this.CanMove = true;
					}
				}
				else if (this.CharacterAnimation["f02_shoveA_01"].time < 0.66666f)
				{
					this.MyController.Move(base.transform.forward * -1f * this.ShoveSpeed * Time.deltaTime);
					this.MyController.Move(Physics.gravity * 0.1f);
					if (this.ShoveSpeed > 0f)
					{
						this.ShoveSpeed = Mathf.MoveTowards(this.ShoveSpeed, 0f, Time.deltaTime * 3f);
					}
				}
			}
			if (this.Attacked && this.CharacterAnimation["f02_swingB_00"].time >= this.CharacterAnimation["f02_swingB_00"].length)
			{
				this.ShoulderCamera.HeartbrokenCamera.SetActive(true);
				base.enabled = false;
			}
			if (this.Hiding)
			{
				if (!this.Exiting)
				{
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.HidingSpot.rotation, Time.deltaTime * 10f);
					this.MoveTowardsTarget(this.HidingSpot.position);
					this.CharacterAnimation.CrossFade(this.HideAnim);
					if (Input.GetButtonDown("B"))
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
						this.Exiting = true;
					}
				}
				else
				{
					this.MoveTowardsTarget(this.ExitSpot.position);
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.ExitTimer += Time.deltaTime;
					if (this.ExitTimer > 1f || Vector3.Distance(base.transform.position, this.ExitSpot.position) < 0.1f)
					{
						this.MyController.center = new Vector3(this.MyController.center.x, 0.875f, this.MyController.center.z);
						this.MyController.radius = 0.2f;
						this.MyController.height = 1.55f;
						this.ExitTimer = 0f;
						this.Exiting = false;
						this.CanMove = true;
						this.Hiding = false;
					}
				}
			}
			if (this.BucketDropping)
			{
				this.targetRotation = Quaternion.LookRotation(this.DropSpot.position + this.DropSpot.forward - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.DropSpot.position);
				if (this.CharacterAnimation["f02_bucketDrop_00"].time >= this.CharacterAnimation["f02_bucketDrop_00"].length)
				{
					this.MyController.radius = 0.2f;
					this.BucketDropping = false;
					this.CanMove = true;
				}
				else if (this.CharacterAnimation["f02_bucketDrop_00"].time >= 1f && this.PickUp != null)
				{
					GameObjectUtils.SetLayerRecursively(this.PickUp.Bucket.gameObject, 0);
					this.PickUp.Bucket.UpdateAppearance = true;
					this.PickUp.Bucket.Dropped = true;
					this.EmptyHands();
				}
			}
			if (this.Flicking)
			{
				if (this.CharacterAnimation["f02_flickingMatch_00"].time >= this.CharacterAnimation["f02_flickingMatch_00"].length)
				{
					this.PickUp.GetComponent<MatchboxScript>().Prompt.enabled = true;
					this.Arc.SetActive(true);
					this.Flicking = false;
					this.CanMove = true;
				}
				else if (this.CharacterAnimation["f02_flickingMatch_00"].time > 1f && this.Match != null)
				{
					Rigidbody component = this.Match.GetComponent<Rigidbody>();
					component.isKinematic = false;
					component.useGravity = true;
					component.AddRelativeForce(Vector3.right * 250f);
					this.Match.transform.parent = null;
					this.Match = null;
				}
			}
			if (this.Rummaging)
			{
				this.MoveTowardsTarget(this.RummageSpot.Target.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.RummageSpot.Target.rotation, Time.deltaTime * 10f);
				this.RummageTimer += Time.deltaTime;
				this.ProgressBar.transform.localScale = new Vector3(this.RummageTimer / 10f, this.ProgressBar.transform.localScale.y, this.ProgressBar.transform.localScale.z);
				if (this.RummageTimer > 10f)
				{
					this.RummageSpot.GetReward();
					this.ProgressBar.transform.parent.gameObject.SetActive(false);
					this.RummageSpot = null;
					this.Rummaging = false;
					this.RummageTimer = 0f;
					this.CanMove = true;
				}
			}
			if (this.Digging)
			{
				if (this.DigPhase == 1)
				{
					if (this.CharacterAnimation["f02_shovelDig_00"].time >= 1.66666663f)
					{
						this.MyAudio.volume = 1f;
						this.MyAudio.clip = this.Dig;
						this.MyAudio.Play();
						this.DigPhase++;
					}
				}
				else if (this.DigPhase == 2)
				{
					if (this.CharacterAnimation["f02_shovelDig_00"].time >= 3.5f)
					{
						this.MyAudio.volume = 1f;
						this.MyAudio.Play();
						this.DigPhase++;
					}
				}
				else if (this.DigPhase == 3)
				{
					if (this.CharacterAnimation["f02_shovelDig_00"].time >= 5.66666651f)
					{
						this.MyAudio.volume = 1f;
						this.MyAudio.Play();
						this.DigPhase++;
					}
				}
				else if (this.DigPhase == 4 && this.CharacterAnimation["f02_shovelDig_00"].time >= this.CharacterAnimation["f02_shovelDig_00"].length)
				{
					this.EquippedWeapon.gameObject.SetActive(true);
					this.FloatingShovel.SetActive(false);
					this.RPGCamera.enabled = true;
					this.Digging = false;
					this.CanMove = true;
				}
			}
			if (this.Burying)
			{
				if (this.DigPhase == 1)
				{
					if (this.CharacterAnimation["f02_shovelBury_00"].time >= 2.16666675f)
					{
						this.MyAudio.volume = 1f;
						this.MyAudio.clip = this.Dig;
						this.MyAudio.Play();
						this.DigPhase++;
					}
				}
				else if (this.DigPhase == 2)
				{
					if (this.CharacterAnimation["f02_shovelBury_00"].time >= 4.66666651f)
					{
						this.MyAudio.volume = 1f;
						this.MyAudio.Play();
						this.DigPhase++;
					}
				}
				else if (this.CharacterAnimation["f02_shovelBury_00"].time >= this.CharacterAnimation["f02_shovelBury_00"].length)
				{
					this.EquippedWeapon.gameObject.SetActive(true);
					this.FloatingShovel.SetActive(false);
					this.RPGCamera.enabled = true;
					this.Burying = false;
					this.CanMove = true;
				}
			}
			if (this.Pickpocketing && !this.Noticed && this.Caught)
			{
				this.CaughtTimer += Time.deltaTime;
				if (this.CaughtTimer > 1f)
				{
					if (!this.CannotRecover)
					{
						this.CanMove = true;
					}
					this.Pickpocketing = false;
					this.CaughtTimer = 0f;
					this.Caught = false;
				}
			}
			if (this.Sprayed)
			{
				if (this.SprayPhase == 0)
				{
					if ((double)this.CharacterAnimation["f02_sprayed_00"].time > 0.66666)
					{
						this.Blur.enabled = true;
						this.Blur.blurSize += Time.deltaTime;
						if (this.Blur.blurSize > (float)this.Blur.blurIterations)
						{
							this.Blur.blurIterations++;
						}
					}
					if (this.CharacterAnimation["f02_sprayed_00"].time > 5f)
					{
						this.Police.Darkness.enabled = true;
						this.Police.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Police.Darkness.color.a, 1f, Time.deltaTime));
						if (this.Police.Darkness.color.a == 1f)
						{
							this.SprayTimer += Time.deltaTime;
							if (this.SprayTimer > 1f)
							{
								this.CharacterAnimation.Play("f02_tied_00");
								this.RPGCamera.enabled = false;
								this.ZipTie[0].SetActive(true);
								this.ZipTie[1].SetActive(true);
								this.Blur.enabled = false;
								this.SprayTimer = 0f;
								this.SprayPhase++;
							}
						}
					}
				}
				else if (this.SprayPhase == 1)
				{
					this.Police.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Police.Darkness.color.a, 0f, Time.deltaTime));
					if (this.Police.Darkness.color.a == 0f)
					{
						this.SprayTimer += Time.deltaTime;
						if (this.SprayTimer > 1f)
						{
							this.ShoulderCamera.HeartbrokenCamera.SetActive(true);
							this.HeartCamera.gameObject.SetActive(false);
							this.HUD.alpha = 0f;
							this.SprayPhase++;
						}
					}
				}
			}
			if (this.CleaningWeapon)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Target.rotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.Target.position);
				if (this.CharacterAnimation["f02_cleaningWeapon_00"].time >= this.CharacterAnimation["f02_cleaningWeapon_00"].length)
				{
					this.EquippedWeapon.Blood.enabled = false;
					this.EquippedWeapon.Bloody = false;
					this.EquippedWeapon.SuspicionCheck();
					if (this.Gloved)
					{
						this.EquippedWeapon.FingerprintID = 0;
					}
					this.CleaningWeapon = false;
					this.Police.MurderWeapons--;
					this.CanMove = true;
				}
			}
			if (this.CrushingPhone)
			{
				this.CharacterAnimation.CrossFade("f02_phoneCrush_00");
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.PhoneToCrush.transform.position.x, base.transform.position.y, this.PhoneToCrush.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.PhoneToCrush.PhoneCrushingSpot.position);
				if (this.CharacterAnimation["f02_phoneCrush_00"].time >= 0.5f && this.PhoneToCrush.enabled)
				{
					this.PhoneToCrush.transform.localEulerAngles = new Vector3(this.PhoneToCrush.transform.localEulerAngles.x, this.PhoneToCrush.transform.localEulerAngles.y, 0f);
					UnityEngine.Object.Instantiate<GameObject>(this.PhoneToCrush.PhoneSmash, this.PhoneToCrush.transform.position, Quaternion.identity);
					this.Police.PhotoEvidence--;
					this.PhoneToCrush.MyRenderer.material.mainTexture = this.PhoneToCrush.SmashedTexture;
					this.PhoneToCrush.MyMesh.mesh = this.PhoneToCrush.SmashedMesh;
					this.PhoneToCrush.Prompt.Hide();
					this.PhoneToCrush.Prompt.enabled = false;
					this.PhoneToCrush.enabled = false;
				}
				if (this.CharacterAnimation["f02_phoneCrush_00"].time >= this.CharacterAnimation["f02_phoneCrush_00"].length)
				{
					this.CrushingPhone = false;
					this.CanMove = true;
				}
			}
			if (this.SubtleStabbing)
			{
				if (this.CharacterAnimation["f02_subtleStab_00"].time < 0.5f)
				{
					this.CharacterAnimation.CrossFade("f02_subtleStab_00");
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					this.MoveTowardsTarget(this.TargetStudent.transform.position + this.TargetStudent.transform.forward * -1f);
				}
				else if (this.TargetStudent.Strength > 0)
				{
					this.TargetStudent.Strength = 0;
					this.TargetStudent.Hunter.MurderSuicidePhase = 0;
					this.TargetStudent.Hunter.AttackWillFail = false;
					this.TargetStudent.Hunter.Pathfinding.canMove = true;
					this.TargetStudent.CharacterAnimation["f02_murderSuicide_01"].time = 1.5f;
					this.TargetStudent.Hunter.CharacterAnimation["f02_murderSuicide_00"].time = 1.5f;
					Debug.Log("Making the hunter's attack a success!");
				}
				if (this.CharacterAnimation["f02_subtleStab_00"].time >= this.CharacterAnimation["f02_subtleStab_00"].length)
				{
					this.SubtleStabbing = false;
					this.CanMove = true;
				}
			}
			if (this.CanMoveTimer > 0f)
			{
				this.CanMoveTimer = Mathf.MoveTowards(this.CanMoveTimer, 0f, Time.deltaTime);
				if (this.CanMoveTimer == 0f)
				{
					this.CanMove = true;
				}
			}
			if (this.Egg)
			{
				if (this.Punching)
				{
					if (this.FalconHelmet.activeInHierarchy)
					{
						if (this.CharacterAnimation["f02_falconPunch_00"].time >= 1f && this.CharacterAnimation["f02_falconPunch_00"].time <= 1.25f)
						{
							this.FalconSpeed = Mathf.MoveTowards(this.FalconSpeed, 2.5f, Time.deltaTime * 2.5f);
						}
						else if (this.CharacterAnimation["f02_falconPunch_00"].time >= 1.25f && this.CharacterAnimation["f02_falconPunch_00"].time <= 1.5f)
						{
							this.FalconSpeed = Mathf.MoveTowards(this.FalconSpeed, 0f, Time.deltaTime * 2.5f);
						}
						if (this.CharacterAnimation["f02_falconPunch_00"].time >= 1f && this.CharacterAnimation["f02_falconPunch_00"].time <= 1.5f)
						{
							if (this.NewFalconPunch == null)
							{
								this.NewFalconPunch = UnityEngine.Object.Instantiate<GameObject>(this.FalconPunch);
								this.NewFalconPunch.transform.parent = this.ItemParent;
								this.NewFalconPunch.transform.localPosition = Vector3.zero;
							}
							this.MyController.Move(base.transform.forward * this.FalconSpeed);
						}
						if (this.CharacterAnimation["f02_falconPunch_00"].time >= this.CharacterAnimation["f02_falconPunch_00"].length)
						{
							this.NewFalconPunch = null;
							this.Punching = false;
							this.CanMove = true;
						}
					}
					else
					{
						if (this.CharacterAnimation["f02_onePunch_00"].time >= 0.833333f && this.CharacterAnimation["f02_onePunch_00"].time <= 1f && this.NewOnePunch == null)
						{
							this.NewOnePunch = UnityEngine.Object.Instantiate<GameObject>(this.OnePunch);
							this.NewOnePunch.transform.parent = this.ItemParent;
							this.NewOnePunch.transform.localPosition = Vector3.zero;
						}
						if (this.CharacterAnimation["f02_onePunch_00"].time >= 2f)
						{
							this.NewOnePunch = null;
							this.Punching = false;
							this.CanMove = true;
						}
					}
				}
				if (this.PK)
				{
					if (Input.GetAxis("Vertical") > 0.5f)
					{
						this.GoToPKDir(PKDirType.Up, "f02_sansUp_00", new Vector3(0f, 3f, 2f));
					}
					else if (Input.GetAxis("Vertical") < -0.5f)
					{
						this.GoToPKDir(PKDirType.Down, "f02_sansDown_00", new Vector3(0f, 0f, 2f));
					}
					else if (Input.GetAxis("Horizontal") > 0.5f)
					{
						this.GoToPKDir(PKDirType.Right, "f02_sansRight_00", new Vector3(1.5f, 1.5f, 2f));
					}
					else if (Input.GetAxis("Horizontal") < -0.5f)
					{
						this.GoToPKDir(PKDirType.Left, "f02_sansLeft_00", new Vector3(-1.5f, 1.5f, 2f));
					}
					else
					{
						this.CharacterAnimation.CrossFade("f02_sansHold_00");
						this.RagdollPK.transform.localPosition = new Vector3(0f, 1.5f, 2f);
						this.PKDir = PKDirType.None;
					}
					if (Input.GetButtonDown("B"))
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = false;
						this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
						this.SansEyes[0].SetActive(false);
						this.SansEyes[1].SetActive(false);
						this.GlowEffect.Stop();
						this.CanMove = true;
						this.PK = false;
					}
				}
				if (this.SummonBones)
				{
					this.CharacterAnimation.CrossFade("f02_sansBones_00");
					if (this.BoneTimer == 0f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.Bone, base.transform.position + base.transform.right * UnityEngine.Random.Range(-2.5f, 2.5f) + base.transform.up * -2f + base.transform.forward * UnityEngine.Random.Range(1f, 6f), Quaternion.identity);
					}
					this.BoneTimer += Time.deltaTime;
					if (this.BoneTimer > 0.1f)
					{
						this.BoneTimer = 0f;
					}
					if (Input.GetButtonUp("RB"))
					{
						this.SansEyes[0].SetActive(false);
						this.SansEyes[1].SetActive(false);
						this.GlowEffect.Stop();
						this.SummonBones = false;
						this.CanMove = true;
					}
					if (this.PK)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = false;
						this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
						this.SansEyes[0].SetActive(false);
						this.SansEyes[1].SetActive(false);
						this.GlowEffect.Stop();
						this.CanMove = true;
						this.PK = false;
					}
				}
				if (this.Blasting)
				{
					if (this.CharacterAnimation["f02_sansBlaster_00"].time >= this.CharacterAnimation["f02_sansBlaster_00"].length - 0.25f)
					{
						this.SansEyes[0].SetActive(false);
						this.SansEyes[1].SetActive(false);
						this.GlowEffect.Stop();
						this.Blasting = false;
						this.CanMove = true;
					}
					if (this.PK)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = false;
						this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
						this.SansEyes[0].SetActive(false);
						this.SansEyes[1].SetActive(false);
						this.GlowEffect.Stop();
						this.CanMove = true;
						this.PK = false;
					}
				}
				if (this.SithAttacking)
				{
					if (!this.SithRecovering)
					{
						if (this.SithBeam[1].Damage == 10f || this.NierDamage == 10f)
						{
							if (this.SithAttacks == 0 && this.CharacterAnimation[string.Concat(new object[]
							{
								"f02_",
								this.AttackPrefix,
								"Attack",
								this.SithPrefix,
								"_0",
								this.SithCombo
							})].time >= this.SithSpawnTime[this.SithCombo])
							{
								UnityEngine.Object.Instantiate<GameObject>(this.SithHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
								this.SithAttacks++;
							}
						}
						else if (this.Pod.activeInHierarchy || this.Armor[20].activeInHierarchy)
						{
							if (this.CharacterAnimation[string.Concat(new object[]
							{
								"f02_",
								this.AttackPrefix,
								"Attack",
								this.SithPrefix,
								"_0",
								this.SithCombo
							})].time >= this.SithHardSpawnTime1[this.SithCombo] && this.SithAttacks == 0)
							{
								UnityEngine.Object.Instantiate<GameObject>(this.SithHitbox, base.transform.position + base.transform.forward * 1.5f + base.transform.up, base.transform.rotation).GetComponent<SithBeamScript>().Damage = 20f;
								this.SithAttacks++;
								if (this.SithCombo < 2)
								{
									UnityEngine.Object.Instantiate<GameObject>(this.GroundImpact, base.transform.position + base.transform.forward * 1.5f, base.transform.rotation).transform.localScale = new Vector3(2f, 2f, 2f);
								}
							}
						}
						else if (this.SithAttacks == 0)
						{
							if (this.CharacterAnimation[string.Concat(new object[]
							{
								"f02_",
								this.AttackPrefix,
								"Attack",
								this.SithPrefix,
								"_0",
								this.SithCombo
							})].time >= this.SithHardSpawnTime1[this.SithCombo])
							{
								UnityEngine.Object.Instantiate<GameObject>(this.SithHardHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
								this.SithAttacks++;
							}
						}
						else if (this.SithAttacks == 1)
						{
							if (this.CharacterAnimation[string.Concat(new object[]
							{
								"f02_",
								this.AttackPrefix,
								"Attack",
								this.SithPrefix,
								"_0",
								this.SithCombo
							})].time >= this.SithHardSpawnTime2[this.SithCombo])
							{
								UnityEngine.Object.Instantiate<GameObject>(this.SithHardHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
								this.SithAttacks++;
							}
						}
						else if (this.SithAttacks == 2 && this.SithCombo == 1 && this.CharacterAnimation[string.Concat(new object[]
						{
							"f02_",
							this.AttackPrefix,
							"Attack",
							this.SithPrefix,
							"_0",
							this.SithCombo
						})].time >= 0.933333337f)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.SithHardHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
							this.SithAttacks++;
						}
						this.SithSoundCheck();
						if (this.CharacterAnimation[string.Concat(new object[]
						{
							"f02_",
							this.AttackPrefix,
							"Attack",
							this.SithPrefix,
							"_0",
							this.SithCombo
						})].time >= this.CharacterAnimation[string.Concat(new object[]
						{
							"f02_",
							this.AttackPrefix,
							"Attack",
							this.SithPrefix,
							"_0",
							this.SithCombo
						})].length)
						{
							if (this.SithCombo < this.SithComboLength)
							{
								this.SithCombo++;
								this.SithSounds = 0;
								this.SithAttacks = 0;
								this.CharacterAnimation.Play(string.Concat(new object[]
								{
									"f02_",
									this.AttackPrefix,
									"Attack",
									this.SithPrefix,
									"_0",
									this.SithCombo
								}));
							}
							else
							{
								this.CharacterAnimation.Play(string.Concat(new object[]
								{
									"f02_",
									this.AttackPrefix,
									"Recover",
									this.SithPrefix,
									"_0",
									this.SithCombo
								}));
								if (!this.Pod.activeInHierarchy)
								{
									this.CharacterAnimation[string.Concat(new object[]
									{
										"f02_",
										this.AttackPrefix,
										"Recover",
										this.SithPrefix,
										"_0",
										this.SithCombo
									})].speed = 2f;
								}
								else
								{
									this.CharacterAnimation[string.Concat(new object[]
									{
										"f02_",
										this.AttackPrefix,
										"Recover",
										this.SithPrefix,
										"_0",
										this.SithCombo
									})].speed = 0.5f;
								}
								this.SithRecovering = true;
							}
						}
						else
						{
							if (Input.GetButtonDown("X") && this.SithComboLength < this.SithCombo + 1 && this.SithComboLength < 2)
							{
								this.SithComboLength++;
							}
							if (Input.GetButtonDown("Y") && this.SithComboLength < this.SithCombo + 1 && this.SithComboLength < 2)
							{
								this.SithComboLength++;
							}
						}
					}
					else if (this.CharacterAnimation[string.Concat(new object[]
					{
						"f02_",
						this.AttackPrefix,
						"Recover",
						this.SithPrefix,
						"_0",
						this.SithCombo
					})].time >= this.CharacterAnimation[string.Concat(new object[]
					{
						"f02_",
						this.AttackPrefix,
						"Recover",
						this.SithPrefix,
						"_0",
						this.SithCombo
					})].length || this.h + this.v != 0f)
					{
						if (this.SithPrefix == "")
						{
							this.LightSwordParticles.Play();
						}
						else
						{
							this.HeavySwordParticles.Play();
						}
						this.HeavySword.GetComponent<WeaponTrail>().enabled = false;
						this.LightSword.GetComponent<WeaponTrail>().enabled = false;
						this.SithRecovering = false;
						this.SithAttacking = false;
						this.SithComboLength = 0;
						this.SithAttacks = 0;
						this.SithSounds = 0;
						this.SithCombo = 0;
						this.CanMove = true;
					}
				}
				if (this.Eating)
				{
					if (Vector3.Distance(base.transform.position, this.TargetStudent.transform.position) > 0.5f)
					{
						base.transform.Translate(Vector3.forward * Time.deltaTime);
					}
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					if (this.CharacterAnimation["f02_sixEat_00"].time > this.BloodTimes[this.EatPhase])
					{
						UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.Mouth.position, Quaternion.identity).GetComponent<RandomStabScript>().Biting = true;
						this.Bloodiness += 20f;
						this.EatPhase++;
					}
					if (this.CharacterAnimation["f02_sixEat_00"].time >= this.CharacterAnimation["f02_sixEat_00"].length)
					{
						if (!this.Kagune[0].activeInHierarchy && this.Hunger < 5)
						{
							this.CharacterAnimation["f02_sixRun_00"].speed += 0.1f;
							this.RunSpeed += 1f;
							this.Hunger++;
							if (this.Hunger == 5)
							{
								this.RisingSmoke.SetActive(true);
								this.RunAnim = "f02_sixFastRun_00";
							}
						}
						Debug.Log("Finished eating.");
						this.FollowHips = false;
						this.Attacking = false;
						this.CanMove = true;
						this.Eating = false;
						this.EatPhase = 0;
					}
				}
				if (this.Snapping)
				{
					if (this.SnapPhase == 0)
					{
						if (this.Gazing)
						{
							if (this.CharacterAnimation["f02_gazerSnap_00"].time >= 0.8f)
							{
								AudioSource.PlayClipAtPoint(this.FingerSnap, base.transform.position + Vector3.up);
								this.GazerEyes.ChangeEffect();
								this.SnapPhase++;
							}
						}
						else if (this.WitchMode)
						{
							if (this.CharacterAnimation["f02_fingerSnap_00"].time >= 1f)
							{
								AudioSource.PlayClipAtPoint(this.FingerSnap, base.transform.position + Vector3.up);
								UnityEngine.Object.Instantiate<GameObject>(this.KnifeArray, base.transform.position, base.transform.rotation).GetComponent<KnifeArrayScript>().GlobalKnifeArray = this.GlobalKnifeArray;
								this.SnapPhase++;
							}
						}
						else if (this.ShotsFired < 1)
						{
							if (this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1f)
							{
								UnityEngine.Object.Instantiate<GameObject>(this.Shell, this.Guns[1].position, base.transform.rotation);
								this.ShotsFired++;
							}
						}
						else if (this.ShotsFired < 2)
						{
							if (this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.2f)
							{
								UnityEngine.Object.Instantiate<GameObject>(this.Shell, this.Guns[2].position, base.transform.rotation);
								this.ShotsFired++;
							}
						}
						else if (this.ShotsFired < 3)
						{
							if (this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.4f)
							{
								UnityEngine.Object.Instantiate<GameObject>(this.Shell, this.Guns[3].position, base.transform.rotation);
								this.ShotsFired++;
							}
						}
						else if (this.ShotsFired < 4 && this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.6f)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.Shell, this.Guns[4].position, base.transform.rotation);
							this.ShotsFired++;
							this.SnapPhase++;
						}
					}
					else if (this.Gazing)
					{
						if (this.CharacterAnimation["f02_gazerSnap_00"].time >= this.CharacterAnimation["f02_gazerSnap_00"].length)
						{
							this.Snapping = false;
							this.CanMove = true;
							this.SnapPhase = 0;
						}
					}
					else if (this.WitchMode)
					{
						if (this.CharacterAnimation["f02_fingerSnap_00"].time >= this.CharacterAnimation["f02_fingerSnap_00"].length)
						{
							this.CharacterAnimation.Stop("f02_fingerSnap_00");
							this.Snapping = false;
							this.CanMove = true;
							this.SnapPhase = 0;
						}
					}
					else if (this.CharacterAnimation["f02_shipGirlSnap_00"].time >= this.CharacterAnimation["f02_shipGirlSnap_00"].length)
					{
						this.Snapping = false;
						this.CanMove = true;
						this.ShotsFired = 0;
						this.SnapPhase = 0;
					}
				}
				if (this.GazeAttacking)
				{
					if (this.TargetStudent != null)
					{
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					}
					if (this.SnapPhase == 0)
					{
						if (this.CharacterAnimation["f02_gazerPoint_00"].time >= 1f)
						{
							AudioSource.PlayClipAtPoint(this.Zap, base.transform.position + Vector3.up);
							this.GazerEyes.Attack();
							this.SnapPhase++;
						}
					}
					else if (this.CharacterAnimation["f02_gazerPoint_00"].time >= this.CharacterAnimation["f02_gazerPoint_00"].length)
					{
						this.GazerEyes.Attacking = false;
						this.GazeAttacking = false;
						this.CanMove = true;
						this.SnapPhase = 0;
					}
				}
				if (this.Finisher)
				{
					if (this.CharacterAnimation["f02_banchoFinisher_00"].time >= this.CharacterAnimation["f02_banchoFinisher_00"].length)
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Finisher = false;
						this.CanMove = true;
					}
					else if (this.CharacterAnimation["f02_banchoFinisher_00"].time >= 1.66666663f)
					{
						this.BanchoFinisher.MyCollider.enabled = false;
					}
					else if (this.CharacterAnimation["f02_banchoFinisher_00"].time >= 0.8333333f)
					{
						this.BanchoFinisher.MyCollider.enabled = true;
					}
				}
				if (this.ShootingBeam)
				{
					this.CharacterAnimation.CrossFade("f02_LoveLoveBeam_00");
					if (this.CharacterAnimation["f02_LoveLoveBeam_00"].time >= 1.5f && this.BeamPhase == 0)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.LoveLoveBeam, base.transform.position, base.transform.rotation);
						this.BeamPhase++;
					}
					if (this.CharacterAnimation["f02_LoveLoveBeam_00"].time >= this.CharacterAnimation["f02_LoveLoveBeam_00"].length - 1f)
					{
						this.ShootingBeam = false;
						this.YandereTimer = 0f;
						this.CanMove = true;
						this.BeamPhase = 0;
					}
				}
				if (this.WritingName)
				{
					this.CharacterAnimation.CrossFade("f02_dramaticWriting_00");
					if (this.CharacterAnimation["f02_dramaticWriting_00"].time == 0f)
					{
						AudioSource.PlayClipAtPoint(this.DramaticWriting, base.transform.position);
					}
					if (this.CharacterAnimation["f02_dramaticWriting_00"].time >= 5f && this.StudentManager.NoteWindow.TargetStudent > 0)
					{
						this.StudentManager.Students[this.StudentManager.NoteWindow.TargetStudent].Fate = this.StudentManager.NoteWindow.MeetID;
						this.StudentManager.Students[this.StudentManager.NoteWindow.TargetStudent].TimeOfDeath = this.StudentManager.NoteWindow.TimeID;
						this.StudentManager.NoteWindow.TargetStudent = 0;
					}
					if (this.CharacterAnimation["f02_dramaticWriting_00"].time >= this.CharacterAnimation["f02_dramaticWriting_00"].length)
					{
						this.CharacterAnimation[this.CarryAnims[10]].weight = 1f;
						this.CharacterAnimation["f02_dramaticWriting_00"].time = 0f;
						this.CharacterAnimation.Stop("f02_dramaticWriting_00");
						this.WritingName = false;
						this.CanMove = true;
					}
				}
				if (this.StoppingTime)
				{
					this.CharacterAnimation.CrossFade("f02_summonStand_00");
					if (this.CharacterAnimation["f02_summonStand_00"].time >= 1f)
					{
						if (this.Freezing)
						{
							if (!this.InvertSphere.gameObject.activeInHierarchy)
							{
								if (this.MyAudio.clip != this.ClockStop)
								{
									this.MyAudio.clip = this.ClockStop;
									this.MyAudio.volume = 1f;
									this.MyAudio.Play();
								}
								this.InvertSphere.gameObject.SetActive(true);
								this.PlayerOnlyCamera.SetActive(true);
								this.StudentManager.TimeFreeze();
							}
							this.InvertSphere.transform.localScale = Vector3.MoveTowards(this.InvertSphere.transform.localScale, new Vector3(0.2375f, 0.2375f, 0f), Time.deltaTime);
							this.MyAudio.volume = 1f;
							this.Jukebox.Ebola.pitch = Mathf.MoveTowards(this.Jukebox.Ebola.pitch, 0.2f, Time.deltaTime);
						}
						else
						{
							if (this.MyAudio.clip != this.ClockStart)
							{
								this.MyAudio.clip = this.ClockStart;
								this.MyAudio.volume = 1f;
								this.MyAudio.Play();
								this.StudentManager.TimeUnfreeze();
							}
							this.InvertSphere.transform.localScale = Vector3.MoveTowards(this.InvertSphere.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime);
							this.MyAudio.volume = 1f;
							this.Jukebox.Ebola.pitch = Mathf.MoveTowards(this.Jukebox.Ebola.pitch, 1f, Time.deltaTime);
							this.GlobalKnifeArray.ActivateKnives();
						}
					}
					if (this.CharacterAnimation["f02_summonStand_00"].time >= this.CharacterAnimation["f02_summonStand_00"].length)
					{
						this.StoppingTime = false;
						this.CanMove = true;
						this.InvertSphere.gameObject.SetActive(this.Freezing);
						this.PlayerOnlyCamera.SetActive(this.Freezing);
					}
				}
			}
		}
	}

	private void UpdatePoisoning()
	{
		if (this.Poisoning)
		{
			if (this.PoisonSpot != null)
			{
				this.MoveTowardsTarget(this.PoisonSpot.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.PoisonSpot.rotation, Time.deltaTime * 10f);
			}
			else
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetBento.transform.position.x, base.transform.position.y, this.TargetBento.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.TargetBento.PoisonSpot.position);
			}
			if (this.CharacterAnimation["f02_poisoning_00"].time >= this.CharacterAnimation["f02_poisoning_00"].length)
			{
				this.CharacterAnimation["f02_poisoning_00"].speed = 1f;
				this.PoisonSpot = null;
				this.Poisoning = false;
				this.CanMove = true;
				return;
			}
			if (this.CharacterAnimation["f02_poisoning_00"].time >= 5.25f)
			{
				this.Poisons[this.PoisonType].SetActive(false);
				return;
			}
			if ((double)this.CharacterAnimation["f02_poisoning_00"].time >= 0.75)
			{
				this.Poisons[this.PoisonType].SetActive(true);
			}
		}
	}

	private void UpdateEffects()
	{
		if (!this.Attacking && !this.DelinquentFighting && !this.Lost && this.CanMove)
		{
			if (Vector3.Distance(base.transform.position, this.Senpai.position) < 1f)
			{
				if (!this.Talking)
				{
					if (!this.NearSenpai && this.StudentManager.Students[1].Pathfinding.speed < 7.5f)
					{
						this.StudentManager.TutorialWindow.ShowSenpaiMessage = true;
						this.DepthOfField.focalSize = 150f;
						this.NearSenpai = true;
					}
					if (this.Laughing)
					{
						Debug.Log("Yandere-chan was laughing, and is being told to stop laughing because UpdateEffects() was called.");
						this.StopLaughing();
						if (this.Pursuer != null)
						{
							this.CanMove = false;
						}
					}
					this.Stance.Current = StanceType.Standing;
					this.Obscurance.enabled = false;
					this.YandereVision = false;
					this.Mopping = false;
					this.Uncrouch();
					this.YandereTimer = 0f;
					this.EmptyHands();
					if (this.Aiming)
					{
						this.StopAiming();
					}
				}
			}
			else
			{
				this.NearSenpai = false;
			}
		}
		if (this.NearSenpai && !this.Noticed)
		{
			this.DepthOfField.enabled = true;
			this.DepthOfField.focalSize = Mathf.Lerp(this.DepthOfField.focalSize, 0f, Time.deltaTime * 10f);
			this.DepthOfField.focalZStartCurve = Mathf.Lerp(this.DepthOfField.focalZStartCurve, 20f, Time.deltaTime * 10f);
			this.DepthOfField.focalZEndCurve = Mathf.Lerp(this.DepthOfField.focalZEndCurve, 20f, Time.deltaTime * 10f);
			this.DepthOfField.objectFocus = this.Senpai.transform;
			this.ColorCorrection.enabled = true;
			this.SenpaiFade = Mathf.Lerp(this.SenpaiFade, 0f, Time.deltaTime * 10f);
			this.SenpaiTint = 1f - this.SenpaiFade / 100f;
			this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.SenpaiTint * 0.5f));
			this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 1f - this.SenpaiTint * 0.5f));
			this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.SenpaiTint * 0.5f));
			this.ColorCorrection.redChannel.SmoothTangents(1, 0f);
			this.ColorCorrection.greenChannel.SmoothTangents(1, 0f);
			this.ColorCorrection.blueChannel.SmoothTangents(1, 0f);
			this.ColorCorrection.UpdateTextures();
			bool attacking = this.Attacking;
			this.SelectGrayscale.desaturation = Mathf.Lerp(this.SelectGrayscale.desaturation, 0f, Time.deltaTime * 10f);
			this.HeartBeat.volume = this.SenpaiTint;
			this.Sanity += Time.deltaTime * 10f;
			this.SenpaiTimer += Time.deltaTime;
			this.BeatTimer += Time.deltaTime;
			if (this.BeatTimer > 60f / (float)this.HeartRate.BeatsPerMinute)
			{
				GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
				this.VibrationCheck = true;
				this.VibrationTimer = 0.1f;
				this.BeatTimer = 0f;
			}
			if (this.SenpaiTimer > 10f && this.Creepiness < 5)
			{
				this.SenpaiTimer = 0f;
				this.Creepiness++;
			}
		}
		else if (this.SenpaiFade < 99f)
		{
			this.DepthOfField.focalSize = Mathf.Lerp(this.DepthOfField.focalSize, 150f, Time.deltaTime * 10f);
			this.DepthOfField.focalZStartCurve = Mathf.Lerp(this.DepthOfField.focalZStartCurve, 0f, Time.deltaTime * 10f);
			this.DepthOfField.focalZEndCurve = Mathf.Lerp(this.DepthOfField.focalZEndCurve, 0f, Time.deltaTime * 10f);
			this.SenpaiFade = Mathf.Lerp(this.SenpaiFade, 100f, Time.deltaTime * 10f);
			this.SenpaiTint = this.SenpaiFade / 100f;
			this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 1f - this.SenpaiTint * 0.5f));
			this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, this.SenpaiTint * 0.5f));
			this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 1f - this.SenpaiTint * 0.5f));
			this.ColorCorrection.redChannel.SmoothTangents(1, 0f);
			this.ColorCorrection.greenChannel.SmoothTangents(1, 0f);
			this.ColorCorrection.blueChannel.SmoothTangents(1, 0f);
			this.ColorCorrection.UpdateTextures();
			this.SelectGrayscale.desaturation = Mathf.Lerp(this.SelectGrayscale.desaturation, this.GreyTarget, Time.deltaTime * 10f);
			this.CharacterAnimation["f02_shy_00"].weight = 1f - this.SenpaiTint;
			for (int i = 1; i < 6; i++)
			{
				this.CharacterAnimation[this.CreepyIdles[i]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[i]].weight, 0f, Time.deltaTime * 10f);
				this.CharacterAnimation[this.CreepyWalks[i]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[i]].weight, 0f, Time.deltaTime * 10f);
			}
			this.HeartBeat.volume = 1f - this.SenpaiTint;
		}
		else if (this.SenpaiFade < 100f)
		{
			this.ResetSenpaiEffects();
		}
		if (this.YandereVision)
		{
			if (!this.HighlightingR.enabled)
			{
				this.YandereColorCorrection.enabled = true;
				this.HighlightingR.enabled = true;
				this.HighlightingB.enabled = true;
				this.Obscurance.enabled = true;
				this.Vignette.enabled = true;
			}
			Time.timeScale = Mathf.Lerp(Time.timeScale, 0.5f, Time.unscaledDeltaTime * 10f);
			this.YandereFade = Mathf.Lerp(this.YandereFade, 0f, Time.deltaTime * 10f);
			this.YandereTint = 1f - this.YandereFade / 100f;
			this.YandereColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f - this.YandereTint * 0.25f));
			this.YandereColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f - this.YandereTint * 0.25f));
			this.YandereColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.YandereTint * 0.25f));
			this.YandereColorCorrection.redChannel.SmoothTangents(1, 0f);
			this.YandereColorCorrection.greenChannel.SmoothTangents(1, 0f);
			this.YandereColorCorrection.blueChannel.SmoothTangents(1, 0f);
			this.YandereColorCorrection.UpdateTextures();
			this.Vignette.intensity = Mathf.Lerp(this.Vignette.intensity, this.YandereTint * 5f, Time.deltaTime * 10f);
			this.Vignette.blur = Mathf.Lerp(this.Vignette.blur, this.YandereTint, Time.deltaTime * 10f);
			this.Vignette.chromaticAberration = Mathf.Lerp(this.Vignette.chromaticAberration, this.YandereTint * 5f, Time.deltaTime * 10f);
			if (this.StudentManager.Tag.Target != null)
			{
				this.StudentManager.Tag.Sprite.color = new Color(1f, 0f, 0f, Mathf.Lerp(this.StudentManager.Tag.Sprite.color.a, 1f, Time.unscaledDeltaTime * 10f));
			}
			if (this.StudentManager.Students[this.StudentManager.RivalID] != null)
			{
				this.StudentManager.RedString.gameObject.SetActive(true);
			}
		}
		else
		{
			if (this.HighlightingR.enabled)
			{
				this.HighlightingR.enabled = false;
				this.HighlightingB.enabled = false;
				this.Obscurance.enabled = false;
			}
			if (this.YandereFade < 99f)
			{
				if (!this.Aiming)
				{
					Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.unscaledDeltaTime * 10f);
				}
				this.YandereFade = Mathf.Lerp(this.YandereFade, 100f, Time.deltaTime * 10f);
				this.YandereTint = this.YandereFade / 100f;
				this.YandereColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, this.YandereTint * 0.5f));
				this.YandereColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, this.YandereTint * 0.5f));
				this.YandereColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 1f - this.YandereTint * 0.5f));
				this.YandereColorCorrection.redChannel.SmoothTangents(1, 0f);
				this.YandereColorCorrection.greenChannel.SmoothTangents(1, 0f);
				this.YandereColorCorrection.blueChannel.SmoothTangents(1, 0f);
				this.YandereColorCorrection.UpdateTextures();
				this.Vignette.intensity = Mathf.Lerp(this.Vignette.intensity, 0f, Time.deltaTime * 10f);
				this.Vignette.blur = Mathf.Lerp(this.Vignette.blur, 0f, Time.deltaTime * 10f);
				this.Vignette.chromaticAberration = Mathf.Lerp(this.Vignette.chromaticAberration, 0f, Time.deltaTime * 10f);
				this.StudentManager.Tag.Sprite.color = new Color(1f, 0f, 0f, Mathf.Lerp(this.StudentManager.Tag.Sprite.color.a, 0f, Time.unscaledDeltaTime * 10f));
				this.StudentManager.RedString.gameObject.SetActive(false);
			}
			else if (this.YandereFade < 100f)
			{
				this.ResetYandereEffects();
			}
		}
		this.RightRedEye.material.color = new Color(this.RightRedEye.material.color.r, this.RightRedEye.material.color.g, this.RightRedEye.material.color.b, 1f - this.YandereFade / 100f);
		this.LeftRedEye.material.color = new Color(this.LeftRedEye.material.color.r, this.LeftRedEye.material.color.g, this.LeftRedEye.material.color.b, 1f - this.YandereFade / 100f);
		this.RightYandereEye.material.color = new Color(this.RightYandereEye.material.color.r, this.YandereFade / 100f, this.YandereFade / 100f, this.RightYandereEye.material.color.a);
		this.LeftYandereEye.material.color = new Color(this.LeftYandereEye.material.color.r, this.YandereFade / 100f, this.YandereFade / 100f, this.LeftYandereEye.material.color.a);
	}

	private void UpdateTalking()
	{
		if (this.Talking)
		{
			if (this.TargetStudent != null)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				if (Vector3.Distance(base.transform.position, this.TargetStudent.transform.position) < 0.75f)
				{
					this.MyController.Move(base.transform.forward * Time.deltaTime * -1f);
				}
			}
			if (this.Interaction == YandereInteractionType.Idle)
			{
				if (this.TargetStudent != null && !this.TargetStudent.Counselor)
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					return;
				}
			}
			else
			{
				if (this.Interaction == YandereInteractionType.Apologizing)
				{
					if (this.TalkTimer == 3f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_00");
						if (this.TargetStudent.Witnessed == StudentWitnessType.Insanity || this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity || this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndInsanity || this.TargetStudent.Witnessed == StudentWitnessType.BloodAndInsanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.InsanityApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndBlood)
						{
							this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Weapon)
						{
							this.Subtitle.UpdateLabel(SubtitleType.WeaponApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Blood)
						{
							this.Subtitle.UpdateLabel(SubtitleType.BloodApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Lewd)
						{
							this.Subtitle.UpdateLabel(SubtitleType.LewdApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Accident)
						{
							this.Subtitle.UpdateLabel(SubtitleType.AccidentApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Suspicious)
						{
							this.Subtitle.UpdateLabel(SubtitleType.SuspiciousApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Eavesdropping)
						{
							this.Subtitle.UpdateLabel(SubtitleType.EavesdropApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Theft)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TheftApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Violence)
						{
							this.Subtitle.UpdateLabel(SubtitleType.ViolenceApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Pickpocketing)
						{
							this.Subtitle.UpdateLabel(SubtitleType.PickpocketApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.CleaningItem)
						{
							this.Subtitle.UpdateLabel(SubtitleType.CleaningApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Poisoning)
						{
							this.Subtitle.UpdateLabel(SubtitleType.PoisonApology, 0, 3f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.HoldingBloodyClothing)
						{
							this.Subtitle.UpdateLabel(SubtitleType.HoldingBloodyClothingApology, 0, 3f);
						}
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_00"].time >= this.CharacterAnimation["f02_greet_00"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.Forgiving;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.Compliment)
				{
					if (this.TalkTimer == 3f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						if (!this.TargetStudent.Male)
						{
							this.Subtitle.UpdateLabel(SubtitleType.PlayerCompliment, 0, 3f);
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.PlayerCompliment, 1, 3f);
						}
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.ReceivingCompliment;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.Gossip)
				{
					if (this.TalkTimer == 3f)
					{
						this.CharacterAnimation.CrossFade("f02_lookdown_00");
						this.Subtitle.UpdateLabel(SubtitleType.PlayerGossip, 0, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_lookdown_00"].time >= this.CharacterAnimation["f02_lookdown_00"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.Gossiping;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.Bye)
				{
					if (this.TalkTimer == 2f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_00");
						this.Subtitle.UpdateLabel(SubtitleType.PlayerFarewell, 0, 2f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_00"].time >= this.CharacterAnimation["f02_greet_00"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.Bye;
							this.TargetStudent.TalkTimer = 2f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.FollowMe)
				{
					int num = 0;
					if (this.Club == ClubType.Delinquent)
					{
						num++;
					}
					if (this.TalkTimer == 3f)
					{
						if (this.Club == ClubType.Delinquent)
						{
							this.TalkAnim = "f02_delinquentGesture_01";
						}
						else
						{
							this.TalkAnim = "f02_greet_01";
						}
						this.CharacterAnimation.CrossFade(this.TalkAnim);
						this.Subtitle.UpdateLabel(SubtitleType.PlayerFollow, num, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation[this.TalkAnim].time >= this.CharacterAnimation[this.TalkAnim].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.FollowingPlayer;
							this.TargetStudent.TalkTimer = 2f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.GoAway)
				{
					int num2 = 0;
					if (this.Club == ClubType.Delinquent)
					{
						num2++;
					}
					if (this.TalkTimer == 3f)
					{
						if (this.Club == ClubType.Delinquent)
						{
							this.TalkAnim = "f02_delinquentGesture_01";
						}
						else
						{
							this.TalkAnim = "f02_lookdown_00";
						}
						this.CharacterAnimation.CrossFade(this.TalkAnim);
						this.Subtitle.UpdateLabel(SubtitleType.PlayerLeave, num2, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation[this.TalkAnim].time >= this.CharacterAnimation[this.TalkAnim].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.GoingAway;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.DistractThem)
				{
					int num3 = 0;
					if (this.Club == ClubType.Delinquent)
					{
						num3++;
					}
					if (this.TalkTimer == 3f)
					{
						if (this.Club == ClubType.Delinquent)
						{
							this.TalkAnim = "f02_delinquentGesture_01";
						}
						else
						{
							this.TalkAnim = "f02_lookdown_00";
						}
						this.CharacterAnimation.CrossFade(this.TalkAnim);
						this.Subtitle.UpdateLabel(SubtitleType.PlayerDistract, num3, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation[this.TalkAnim].time >= this.CharacterAnimation[this.TalkAnim].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.DistractingTarget;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.NamingCrush)
				{
					if (this.TalkTimer == 3f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 0, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.NamingCrush;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.ChangingAppearance)
				{
					if (this.TalkTimer == 3f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 2, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.ChangingAppearance;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.Court)
				{
					if (this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						if (!this.TargetStudent.Male)
						{
							this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 3, 5f);
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 4, 5f);
						}
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.Court;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.Confess)
				{
					if (this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 5, 5f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.Gift;
							this.TargetStudent.TalkTimer = 5f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.TaskInquiry)
				{
					if (this.TalkTimer == 3f || this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						if (this.TargetStudent.Club == ClubType.Bully)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 0, 5f);
						}
						else if (this.TargetStudent.StudentID == 10)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 6, 5f);
						}
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							Debug.Log("Telling student to respond to task inquiry.");
							this.TargetStudent.Interaction = StudentInteractionType.TaskInquiry;
							this.TargetStudent.TalkTimer = 10f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.GivingSnack)
				{
					if (this.TalkTimer == 3f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel(SubtitleType.OfferSnack, 0, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.TakingSnack;
							this.TargetStudent.TalkTimer = 5f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.AskingForHelp)
				{
					if (this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Subtitle.UpdateLabel(SubtitleType.AskForHelp, 0, 5f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.GivingHelp;
							this.TargetStudent.TalkTimer = 4f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.SendingToLocker)
				{
					if (this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 0, 5f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.SentToLocker;
							this.TargetStudent.TalkTimer = 5f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
				}
			}
		}
	}

	private void UpdateAttacking()
	{
		if (this.Attacking)
		{
			if (this.TargetStudent != null)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
			}
			if (this.Drown)
			{
				this.MoveTowardsTarget(this.TargetStudent.transform.position + this.TargetStudent.transform.forward * -0.0001f);
				this.CharacterAnimation.CrossFade(this.DrownAnim);
				if (this.CharacterAnimation[this.DrownAnim].time > this.CharacterAnimation[this.DrownAnim].length)
				{
					this.TargetStudent.DeathType = DeathType.Drowning;
					this.Attacking = false;
					this.CanMove = true;
					this.Drown = false;
					this.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * this.Numbness;
					return;
				}
			}
			else if (this.RoofPush)
			{
				this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(this.Hips.position.x, base.transform.position.y + 1f, this.Hips.position.z), Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.TargetStudent.transform.position - this.TargetStudent.transform.forward);
				this.CharacterAnimation.CrossFade("f02_roofPushA_00");
				if (this.CharacterAnimation["f02_roofPushA_00"].time > 4.33333349f)
				{
					if (this.Shoes[0].activeInHierarchy)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.ShoePair, base.transform.position + new Vector3(0f, 0.045f, 0f) + base.transform.forward * 1.6f, Quaternion.identity).transform.eulerAngles = base.transform.eulerAngles;
						this.Shoes[0].SetActive(false);
						this.Shoes[1].SetActive(false);
					}
				}
				else if (this.CharacterAnimation["f02_roofPushA_00"].time > 2.16666675f && this.TargetStudent.Schoolwear == 1 && !this.TargetStudent.ClubAttire && !this.Shoes[0].activeInHierarchy)
				{
					this.TargetStudent.RemoveShoes();
					this.Shoes[0].SetActive(true);
					this.Shoes[1].SetActive(true);
				}
				float num;
				if (this.TargetStudent.Schoolwear == 1 && !this.TargetStudent.ClubAttire)
				{
					num = this.CharacterAnimation["f02_roofPushA_00"].length;
				}
				else
				{
					num = 3.5f;
				}
				if (this.CharacterAnimation["f02_roofPushA_00"].time > num)
				{
					this.CameraTarget.localPosition = new Vector3(0f, 1f, 0f);
					this.TargetStudent.DeathType = DeathType.Falling;
					this.SplashCamera.transform.parent = null;
					this.Attacking = false;
					this.RoofPush = false;
					this.CanMove = true;
					this.Sanity -= 20f * this.Numbness;
				}
				if (Input.GetButtonDown("B"))
				{
					this.SplashCamera.transform.parent = base.transform;
					this.SplashCamera.transform.localPosition = new Vector3(2f, -10.65f, 4.775f);
					this.SplashCamera.transform.localEulerAngles = new Vector3(0f, -135f, 0f);
					this.SplashCamera.Show = true;
					this.SplashCamera.MyCamera.enabled = true;
					return;
				}
			}
			else
			{
				if (this.TargetStudent.Teacher)
				{
					this.CharacterAnimation.CrossFade("f02_teacherCounterA_00");
					if (this.EquippedWeapon != null)
					{
						this.EquippedWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
					}
					this.Character.transform.position = new Vector3(this.Character.transform.position.x, this.TargetStudent.transform.position.y, this.Character.transform.position.z);
					return;
				}
				if (!this.SanityBased)
				{
					if (this.EquippedWeapon.WeaponID == 27)
					{
						Debug.Log("Well, uh, we're killing with a garrote...");
						return;
					}
					if (this.EquippedWeapon.WeaponID == 11)
					{
						this.CharacterAnimation.CrossFade("CyborgNinja_Slash");
						if (this.CharacterAnimation["CyborgNinja_Slash"].time == 0f)
						{
							this.TargetStudent.CharacterAnimation[this.TargetStudent.PhoneAnim].weight = 0f;
							this.EquippedWeapon.gameObject.GetComponent<AudioSource>().Play();
						}
						if (this.CharacterAnimation["CyborgNinja_Slash"].time >= this.CharacterAnimation["CyborgNinja_Slash"].length)
						{
							this.Bloodiness += 20f;
							this.StainWeapon();
							this.CharacterAnimation["CyborgNinja_Slash"].time = 0f;
							this.CharacterAnimation.Stop("CyborgNinja_Slash");
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.Attacking = false;
							if (!this.Noticed)
							{
								this.CanMove = true;
								return;
							}
							this.EquippedWeapon.Drop();
							return;
						}
					}
					else if (this.EquippedWeapon.WeaponID == 7)
					{
						this.CharacterAnimation.CrossFade("f02_buzzSawKill_A_00");
						if (this.CharacterAnimation["f02_buzzSawKill_A_00"].time == 0f)
						{
							this.TargetStudent.CharacterAnimation[this.TargetStudent.PhoneAnim].weight = 0f;
							this.EquippedWeapon.gameObject.GetComponent<AudioSource>().Play();
						}
						if (this.AttackPhase == 1)
						{
							if (this.CharacterAnimation["f02_buzzSawKill_A_00"].time > 0.333333343f)
							{
								this.TargetStudent.LiquidProjector.enabled = true;
								this.EquippedWeapon.Effect();
								this.StainWeapon();
								this.TargetStudent.LiquidProjector.material.mainTexture = this.BloodTextures[1];
								this.Bloodiness += 20f;
								this.AttackPhase++;
							}
						}
						else if (this.AttackPhase < 6 && this.CharacterAnimation["f02_buzzSawKill_A_00"].time > 0.333333343f * (float)this.AttackPhase)
						{
							this.TargetStudent.LiquidProjector.material.mainTexture = this.BloodTextures[this.AttackPhase];
							this.Bloodiness += 20f;
							this.AttackPhase++;
						}
						if (this.CharacterAnimation["f02_buzzSawKill_A_00"].time > this.CharacterAnimation["f02_buzzSawKill_A_00"].length)
						{
							if (this.TargetStudent == this.StudentManager.Reporter)
							{
								this.StudentManager.Reporter = null;
							}
							this.CharacterAnimation["f02_buzzSawKill_A_00"].time = 0f;
							this.CharacterAnimation.Stop("f02_buzzSawKill_A_00");
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.MyController.radius = 0.2f;
							this.Attacking = false;
							this.AttackPhase = 1;
							this.Sanity -= 20f * this.Numbness;
							this.TargetStudent.DeathType = DeathType.Weapon;
							this.TargetStudent.BecomeRagdoll();
							if (!this.Noticed)
							{
								this.CanMove = true;
								return;
							}
							this.EquippedWeapon.Drop();
							return;
						}
					}
					else if (!this.EquippedWeapon.Concealable)
					{
						if (this.AttackPhase == 1)
						{
							this.CharacterAnimation.CrossFade("f02_swingA_00");
							if (this.CharacterAnimation["f02_swingA_00"].time > this.CharacterAnimation["f02_swingA_00"].length * 0.3f)
							{
								if (this.TargetStudent == this.StudentManager.Reporter)
								{
									this.StudentManager.Reporter = null;
								}
								UnityEngine.Object.Destroy(this.TargetStudent.DeathScream);
								this.EquippedWeapon.Effect();
								this.AttackPhase = 2;
								this.Bloodiness += 20f;
								this.StainWeapon();
								this.Sanity -= 20f * this.Numbness;
								return;
							}
						}
						else if (this.CharacterAnimation["f02_swingA_00"].time >= this.CharacterAnimation["f02_swingA_00"].length * 0.9f)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.TargetStudent.DeathType = DeathType.Weapon;
							this.TargetStudent.BecomeRagdoll();
							this.MyController.radius = 0.2f;
							this.Attacking = false;
							this.AttackPhase = 1;
							this.AttackTimer = 0f;
							if (!this.Noticed)
							{
								this.CanMove = true;
								return;
							}
							this.EquippedWeapon.Drop();
							return;
						}
					}
					else if (this.AttackPhase == 1)
					{
						this.CharacterAnimation.CrossFade("f02_stab_00");
						if (this.CharacterAnimation["f02_stab_00"].time > this.CharacterAnimation["f02_stab_00"].length * 0.35f)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							if (this.EquippedWeapon.Flaming)
							{
								this.Egg = true;
								this.TargetStudent.Combust();
							}
							else if (this.CanTranq && !this.TargetStudent.Male && this.TargetStudent.Club != ClubType.Council)
							{
								this.TargetStudent.Tranquil = true;
								this.CanTranq = false;
								this.Follower = null;
								this.Followers--;
							}
							else
							{
								this.TargetStudent.BloodSpray.SetActive(true);
								this.TargetStudent.DeathType = DeathType.Weapon;
								this.Bloodiness += 20f;
							}
							if (this.TargetStudent == this.StudentManager.Reporter)
							{
								this.StudentManager.Reporter = null;
							}
							AudioSource.PlayClipAtPoint(this.Stabs[UnityEngine.Random.Range(0, this.Stabs.Length)], base.transform.position + Vector3.up);
							UnityEngine.Object.Destroy(this.TargetStudent.DeathScream);
							this.AttackPhase = 2;
							this.Sanity -= 20f * this.Numbness;
							if (this.EquippedWeapon.WeaponID == 8)
							{
								this.TargetStudent.Ragdoll.Sacrifice = true;
								if (GameGlobals.Paranormal)
								{
									this.EquippedWeapon.Effect();
									return;
								}
							}
						}
					}
					else
					{
						this.AttackTimer += Time.deltaTime;
						if (this.AttackTimer > 0.3f)
						{
							if (!this.CanTranq)
							{
								this.StainWeapon();
							}
							this.MyController.radius = 0.2f;
							this.SanityBased = true;
							this.Attacking = false;
							this.AttackPhase = 1;
							this.AttackTimer = 0f;
							if (!this.Noticed)
							{
								this.CanMove = true;
								return;
							}
							this.EquippedWeapon.Drop();
						}
					}
				}
			}
		}
	}

	public void UpdateSlouch()
	{
		if (!this.CanMove || this.Attacking || this.Dragging || !(this.PickUp == null) || this.Aiming || this.Stance.Current == StanceType.Crawling || this.Possessed || this.Carrying || this.CirnoWings.activeInHierarchy || this.LaughIntensity >= 16f)
		{
			this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, 0f, Time.deltaTime * 10f);
			this.Slouch = Mathf.Lerp(this.Slouch, 0f, Time.deltaTime * 10f);
			return;
		}
		this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, 1f - this.Sanity / 100f, Time.deltaTime * 10f);
		if (this.Hairstyle == 2 && this.Stance.Current == StanceType.Crouching)
		{
			this.Slouch = Mathf.Lerp(this.Slouch, 0f, Time.deltaTime * 20f);
			return;
		}
		this.Slouch = Mathf.Lerp(this.Slouch, 5f * (1f - this.Sanity / 100f), Time.deltaTime * 10f);
	}

	private void UpdateTwitch()
	{
		if (this.Sanity < 100f)
		{
			this.TwitchTimer += Time.deltaTime;
			if (this.TwitchTimer > this.NextTwitch)
			{
				this.Twitch = new Vector3((1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f));
				this.NextTwitch = UnityEngine.Random.Range(0f, 1f);
				this.TwitchTimer = 0f;
			}
			this.Twitch = Vector3.Lerp(this.Twitch, Vector3.zero, Time.deltaTime * 10f);
		}
	}

	private void UpdateWarnings()
	{
		if (this.NearBodies > 0)
		{
			if (!this.CorpseWarning)
			{
				this.NotificationManager.DisplayNotification(NotificationType.Body);
				this.StudentManager.UpdateStudents(0);
				this.CorpseWarning = true;
			}
		}
		else if (this.CorpseWarning)
		{
			this.StudentManager.UpdateStudents(0);
			this.CorpseWarning = false;
		}
		if (this.Eavesdropping)
		{
			if (!this.EavesdropWarning)
			{
				this.NotificationManager.DisplayNotification(NotificationType.Eavesdropping);
				this.EavesdropWarning = true;
			}
		}
		else if (this.EavesdropWarning)
		{
			this.EavesdropWarning = false;
		}
		if (this.ClothingWarning)
		{
			this.ClothingTimer += Time.deltaTime;
			if (this.ClothingTimer > 1f)
			{
				this.ClothingWarning = false;
				this.ClothingTimer = 0f;
			}
		}
	}

	private void UpdateDebugFunctionality()
	{
		if (!this.EasterEggMenu.activeInHierarchy && !this.DebugMenu.activeInHierarchy)
		{
			if (!this.Aiming && this.CanMove && Time.timeScale > 0f && Input.GetKeyDown(KeyCode.Escape))
			{
				this.PauseScreen.JumpToQuit();
			}
			if (Input.GetKeyDown(KeyCode.P))
			{
				this.CyborgParts[1].SetActive(false);
				this.MemeGlasses.SetActive(false);
				this.KONGlasses.SetActive(false);
				this.EyepatchR.SetActive(false);
				this.EyepatchL.SetActive(false);
				this.EyewearID++;
				if (this.EyewearID == 1)
				{
					this.EyepatchR.SetActive(true);
				}
				else if (this.EyewearID == 2)
				{
					this.EyepatchL.SetActive(true);
				}
				else if (this.EyewearID == 3)
				{
					this.EyepatchR.SetActive(true);
					this.EyepatchL.SetActive(true);
				}
				else if (this.EyewearID == 4)
				{
					this.KONGlasses.SetActive(true);
				}
				else if (this.EyewearID == 5)
				{
					this.MemeGlasses.SetActive(true);
				}
				else if (this.EyewearID == 6)
				{
					if (this.CyborgParts[2].activeInHierarchy)
					{
						this.CyborgParts[1].SetActive(true);
					}
					else
					{
						this.EyewearID = 0;
					}
				}
				else
				{
					this.EyewearID = 0;
				}
			}
			if (Input.GetKeyDown(KeyCode.H))
			{
				if (Input.GetButton("LB"))
				{
					this.Hairstyle += 10;
				}
				else
				{
					this.Hairstyle++;
				}
				this.UpdateHair();
			}
			if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				this.Hairstyle--;
				this.UpdateHair();
			}
			if (Input.GetKeyDown(KeyCode.O) && !this.EasterEggMenu.activeInHierarchy)
			{
				if (this.AccessoryID > 0)
				{
					this.Accessories[this.AccessoryID].SetActive(false);
				}
				if (Input.GetButton("LB"))
				{
					this.AccessoryID += 10;
				}
				else
				{
					this.AccessoryID++;
				}
				this.UpdateAccessory();
			}
			if (Input.GetKey(KeyCode.O) && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (this.AccessoryID > 0)
				{
					this.Accessories[this.AccessoryID].SetActive(false);
				}
				this.AccessoryID--;
				this.UpdateAccessory();
			}
			if (!this.NoDebug && !this.DebugMenu.activeInHierarchy && this.CanMove && !this.DebugMenu.activeInHierarchy)
			{
				if (Input.GetKeyDown("-"))
				{
					if (Time.timeScale < 6f)
					{
						Time.timeScale = 1f;
					}
					else
					{
						Time.timeScale -= 5f;
					}
				}
				if (Input.GetKeyDown("="))
				{
					if (Time.timeScale < 5f)
					{
						Time.timeScale = 5f;
					}
					else
					{
						Time.timeScale += 5f;
						if (Time.timeScale > 25f)
						{
							Time.timeScale = 25f;
						}
					}
				}
			}
			if (Input.GetKey(KeyCode.Period))
			{
				this.BreastSize += Time.deltaTime;
				if (this.BreastSize > 2f)
				{
					this.BreastSize = 2f;
				}
				this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			}
			if (Input.GetKey(KeyCode.Comma))
			{
				this.BreastSize -= Time.deltaTime;
				if (this.BreastSize < 0.5f)
				{
					this.BreastSize = 0.5f;
				}
				this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			}
		}
		if (!this.NoDebug)
		{
			if (this.CanMove)
			{
				if (!this.Egg || this.EggBypass > 8)
				{
					if (base.transform.position.y < 1000f)
					{
						if (Input.GetKeyDown(KeyCode.Slash))
						{
							this.DebugMenu.SetActive(false);
							this.EasterEggMenu.SetActive(!this.EasterEggMenu.activeInHierarchy);
						}
						if (this.EasterEggMenu.activeInHierarchy)
						{
							if (Input.GetKeyDown(KeyCode.P))
							{
								this.Punish();
								return;
							}
							if (Input.GetKeyDown(KeyCode.Z))
							{
								this.Slend();
								return;
							}
							if (Input.GetKeyDown(KeyCode.B))
							{
								this.Bancho();
								return;
							}
							if (Input.GetKeyDown(KeyCode.C))
							{
								this.Cirno();
								return;
							}
							if (Input.GetKeyDown(KeyCode.H))
							{
								this.EmptyHands();
								this.Hate();
								return;
							}
							if (Input.GetKeyDown(KeyCode.T))
							{
								this.StudentManager.AttackOnTitan();
								this.AttackOnTitan();
								return;
							}
							if (Input.GetKeyDown(KeyCode.G))
							{
								this.GaloSengen();
								return;
							}
							if (!Input.GetKeyDown(KeyCode.J))
							{
								if (Input.GetKeyDown(KeyCode.K))
								{
									this.EasterEggMenu.SetActive(false);
									this.StudentManager.Kong();
									this.DK = true;
									return;
								}
								if (Input.GetKeyDown(KeyCode.L))
								{
									this.Agent();
									return;
								}
								if (!Input.GetKeyDown(KeyCode.N))
								{
									if (Input.GetKeyDown(KeyCode.S))
									{
										this.EasterEggMenu.SetActive(false);
										this.Egg = true;
										this.StudentManager.Spook();
										return;
									}
									if (Input.GetKeyDown(KeyCode.F))
									{
										this.EasterEggMenu.SetActive(false);
										this.Falcon();
										return;
									}
									if (Input.GetKeyDown(KeyCode.X))
									{
										this.EasterEggMenu.SetActive(false);
										this.X();
										return;
									}
									if (Input.GetKeyDown(KeyCode.O))
									{
										this.EasterEggMenu.SetActive(false);
										this.Punch();
										return;
									}
									if (Input.GetKeyDown(KeyCode.U))
									{
										this.EasterEggMenu.SetActive(false);
										this.BadTime();
										return;
									}
									if (Input.GetKeyDown(KeyCode.Y))
									{
										this.EasterEggMenu.SetActive(false);
										this.CyborgNinja();
										return;
									}
									if (Input.GetKeyDown(KeyCode.E))
									{
										this.EasterEggMenu.SetActive(false);
										this.Ebola();
										return;
									}
									if (Input.GetKeyDown(KeyCode.Q))
									{
										this.EasterEggMenu.SetActive(false);
										this.Samus();
										return;
									}
									if (Input.GetKeyDown(KeyCode.W))
									{
										this.EasterEggMenu.SetActive(false);
										this.Witch();
										return;
									}
									if (Input.GetKeyDown(KeyCode.R))
									{
										this.EasterEggMenu.SetActive(false);
										this.Pose();
										return;
									}
									if (Input.GetKeyDown(KeyCode.V))
									{
										this.EasterEggMenu.SetActive(false);
										this.Vaporwave();
										return;
									}
									if (Input.GetKeyDown(KeyCode.Alpha2))
									{
										this.EasterEggMenu.SetActive(false);
										this.HairBlades();
										return;
									}
									if (Input.GetKeyDown(KeyCode.Alpha7))
									{
										this.EasterEggMenu.SetActive(false);
										this.Tornado();
										return;
									}
									if (Input.GetKeyDown(KeyCode.Alpha8))
									{
										this.EasterEggMenu.SetActive(false);
										this.GenderSwap();
										return;
									}
									if (Input.GetKeyDown("[5]"))
									{
										this.EasterEggMenu.SetActive(false);
										this.SwapMesh();
										return;
									}
									if (Input.GetKeyDown(KeyCode.A))
									{
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.I))
									{
										this.StudentManager.NoGravity = true;
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.D))
									{
										this.EasterEggMenu.SetActive(false);
										this.Sith();
										return;
									}
									if (Input.GetKeyDown(KeyCode.M))
									{
										this.EasterEggMenu.SetActive(false);
										this.Snake();
										return;
									}
									if (Input.GetKeyDown(KeyCode.Alpha1))
									{
										this.EasterEggMenu.SetActive(false);
										this.Gazer();
										return;
									}
									if (Input.GetKeyDown(KeyCode.Alpha3))
									{
										this.StudentManager.SecurityCameras();
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.Alpha4))
									{
										this.KLK();
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.Alpha6))
									{
										this.EasterEggMenu.SetActive(false);
										this.Six();
										return;
									}
									if (Input.GetKeyDown(KeyCode.F1))
									{
										this.Weather();
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.F2))
									{
										this.Horror();
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.F3))
									{
										this.LifeNote();
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.F4))
									{
										this.Mandere();
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.F5))
									{
										this.BlackHoleChan();
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.F6))
									{
										this.ElfenLied();
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.F7))
									{
										this.Berserk();
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.F8))
									{
										this.Nier();
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.F9))
									{
										this.Ghoul();
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (Input.GetKeyDown(KeyCode.F10))
									{
										this.CinematicCameraFilters.enabled = true;
										this.CameraFilters.enabled = true;
										this.EasterEggMenu.SetActive(false);
										return;
									}
									if (!Input.GetKeyDown(KeyCode.F11) && Input.GetKeyDown(KeyCode.Space))
									{
										this.EasterEggMenu.SetActive(false);
										return;
									}
								}
							}
						}
					}
				}
				else if (Input.GetKeyDown(KeyCode.Slash))
				{
					this.EggBypass++;
					return;
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.Z))
		{
			this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().Censor();
		}
	}

	private void LateUpdate()
	{
		if (this.VibrationCheck)
		{
			this.VibrationTimer = Mathf.MoveTowards(this.VibrationTimer, 0f, Time.deltaTime);
			if (this.VibrationTimer == 0f)
			{
				GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
				this.VibrationCheck = false;
			}
		}
		this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.02f);
		this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.02f);
		this.LeftEye.localScale = new Vector3(1f - this.EyeShrink, 1f - this.EyeShrink, this.LeftEye.localScale.z);
		this.RightEye.localScale = new Vector3(1f - this.EyeShrink, 1f - this.EyeShrink, this.RightEye.localScale.z);
		this.ID = 0;
		while (this.ID < this.Spine.Length)
		{
			Transform transform = this.Spine[this.ID].transform;
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + this.Slouch, transform.localEulerAngles.y, transform.localEulerAngles.z);
			this.ID++;
		}
		if (this.Aiming)
		{
			float num = 1f;
			if (this.Selfie)
			{
				num = -1f;
			}
			Transform transform2 = this.Spine[3].transform;
			transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x - this.Bend * num, transform2.localEulerAngles.y, transform2.localEulerAngles.z);
		}
		float num2 = 1f;
		if (this.Stance.Current == StanceType.Crouching)
		{
			num2 = 3.66666f;
		}
		Transform transform3 = this.Arm[0].transform;
		transform3.localEulerAngles = new Vector3(transform3.localEulerAngles.x, transform3.localEulerAngles.y, transform3.localEulerAngles.z - this.Slouch * (3f + num2));
		Transform transform4 = this.Arm[1].transform;
		transform4.localEulerAngles = new Vector3(transform4.localEulerAngles.x, transform4.localEulerAngles.y, transform4.localEulerAngles.z + this.Slouch * (3f + num2));
		if (!this.Aiming)
		{
			this.Head.localEulerAngles += this.Twitch;
		}
		if (this.Aiming)
		{
			if (this.Stance.Current == StanceType.Crawling)
			{
				this.TargetHeight = -1.4f;
			}
			else if (this.Stance.Current == StanceType.Crouching)
			{
				this.TargetHeight = -0.6f;
			}
			else
			{
				this.TargetHeight = 0f;
			}
			this.Height = Mathf.Lerp(this.Height, this.TargetHeight, Time.deltaTime * 10f);
			this.PelvisRoot.transform.localPosition = new Vector3(this.PelvisRoot.transform.localPosition.x, this.Height, this.PelvisRoot.transform.localPosition.z);
		}
		if (this.Egg)
		{
			if (this.Slender)
			{
				Transform transform5 = this.Leg[0];
				transform5.localScale = new Vector3(transform5.localScale.x, 2f, transform5.localScale.z);
				Transform transform6 = this.Foot[0];
				transform6.localScale = new Vector3(transform6.localScale.x, 0.5f, transform6.localScale.z);
				Transform transform7 = this.Leg[1];
				transform7.localScale = new Vector3(transform7.localScale.x, 2f, transform7.localScale.z);
				Transform transform8 = this.Foot[1];
				transform8.localScale = new Vector3(transform8.localScale.x, 0.5f, transform8.localScale.z);
				Transform transform9 = this.Arm[0];
				transform9.localScale = new Vector3(2f, transform9.localScale.y, transform9.localScale.z);
				Transform transform10 = this.Arm[1];
				transform10.localScale = new Vector3(2f, transform10.localScale.y, transform10.localScale.z);
			}
			if (this.DK)
			{
				this.Arm[0].localScale = new Vector3(2f, 2f, 2f);
				this.Arm[1].localScale = new Vector3(2f, 2f, 2f);
				this.Head.localScale = new Vector3(2f, 2f, 2f);
			}
			if (this.CirnoWings.activeInHierarchy)
			{
				if (this.Running)
				{
					this.FlapSpeed = 5f;
				}
				else if (this.FlapSpeed == 0f)
				{
					this.FlapSpeed = 1f;
				}
				else
				{
					this.FlapSpeed = 3f;
				}
				Transform transform11 = this.CirnoWing[0];
				Transform transform12 = this.CirnoWing[1];
				if (!this.FlapOut)
				{
					this.CirnoRotation += Time.deltaTime * 100f * this.FlapSpeed;
					transform11.localEulerAngles = new Vector3(transform11.localEulerAngles.x, this.CirnoRotation, transform11.localEulerAngles.z);
					transform12.localEulerAngles = new Vector3(transform12.localEulerAngles.x, -this.CirnoRotation, transform12.localEulerAngles.z);
					if (this.CirnoRotation > 15f)
					{
						this.FlapOut = true;
					}
				}
				else
				{
					this.CirnoRotation -= Time.deltaTime * 100f * this.FlapSpeed;
					transform11.localEulerAngles = new Vector3(transform11.localEulerAngles.x, this.CirnoRotation, transform11.localEulerAngles.z);
					transform12.localEulerAngles = new Vector3(transform12.localEulerAngles.x, -this.CirnoRotation, transform12.localEulerAngles.z);
					if (this.CirnoRotation < -15f)
					{
						this.FlapOut = false;
					}
				}
			}
			if (this.SpiderLegs.activeInHierarchy)
			{
				if (this.SpiderGrow)
				{
					if (this.SpiderLegs.transform.localScale.x < 0.49f)
					{
						this.SpiderLegs.transform.localScale = Vector3.Lerp(this.SpiderLegs.transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), Time.deltaTime * 5f);
						SchoolGlobals.SchoolAtmosphere = 1f - this.SpiderLegs.transform.localScale.x;
						this.StudentManager.SetAtmosphere();
					}
				}
				else if (this.SpiderLegs.transform.localScale.x > 0.001f)
				{
					this.SpiderLegs.transform.localScale = Vector3.Lerp(this.SpiderLegs.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 5f);
					SchoolGlobals.SchoolAtmosphere = 1f - this.SpiderLegs.transform.localScale.x;
					this.StudentManager.SetAtmosphere();
				}
			}
			if (this.BlackHole)
			{
				this.RightLeg.transform.Rotate(-60f, 0f, 0f, Space.Self);
				this.LeftLeg.transform.Rotate(-60f, 0f, 0f, Space.Self);
			}
			if (this.SwingKagune)
			{
				if (!this.ReturnKagune)
				{
					for (int i = 0; i < this.Kagune.Length; i++)
					{
						if (i < 2)
						{
							this.KaguneRotation[i] = new Vector3(Mathf.MoveTowards(this.KaguneRotation[i].x, 15f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[i].y, 180f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[i].z, 500f, Time.deltaTime * 1000f));
							this.Kagune[i].transform.localEulerAngles = this.KaguneRotation[i];
						}
						else
						{
							this.KaguneRotation[i] = new Vector3(Mathf.MoveTowards(this.KaguneRotation[i].x, 15f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[i].y, -180f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[i].z, -500f, Time.deltaTime * 1000f));
							this.Kagune[i].transform.localEulerAngles = this.KaguneRotation[i];
						}
					}
					if (this.KagunePhase == 0 && this.KaguneRotation[0].y == 180f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.DemonSlash, base.transform.position + base.transform.up + base.transform.forward, Quaternion.identity);
						this.KagunePhase = 1;
					}
					if (this.KaguneRotation[0] == new Vector3(15f, 180f, 500f))
					{
						this.ReturnKagune = true;
					}
				}
				else
				{
					for (int j = 0; j < this.Kagune.Length; j++)
					{
						if (j == 0)
						{
							this.KaguneRotation[j] = new Vector3(Mathf.Lerp(this.KaguneRotation[j].x, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].y, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
						}
						else if (j == 1)
						{
							this.KaguneRotation[j] = new Vector3(Mathf.Lerp(this.KaguneRotation[j].x, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].y, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
						}
						else if (j == 2)
						{
							this.KaguneRotation[j] = new Vector3(Mathf.Lerp(this.KaguneRotation[j].x, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].y, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
						}
						else if (j == 3)
						{
							this.KaguneRotation[j] = new Vector3(Mathf.Lerp(this.KaguneRotation[j].x, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].y, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
						}
						this.Kagune[j].transform.localEulerAngles = this.KaguneRotation[j];
					}
					if (Vector3.Distance(this.KaguneRotation[0], new Vector3(22.5f, 22.5f, 0f)) < 10f)
					{
						this.SwingKagune = false;
						this.ReturnKagune = false;
						this.KagunePhase = 0;
					}
				}
			}
		}
		if (this.PickUp != null && this.PickUp.Flashlight)
		{
			this.RightHand.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
		}
		if (this.ReachWeight > 0f)
		{
			this.CharacterAnimation["f02_reachForWeapon_00"].weight = this.ReachWeight;
			this.ReachWeight = Mathf.MoveTowards(this.ReachWeight, 0f, Time.deltaTime * 2f);
			if (this.ReachWeight < 0.01f)
			{
				this.ReachWeight = 0f;
				this.CharacterAnimation["f02_reachForWeapon_00"].weight = 0f;
			}
		}
		if (this.SanitySmudges.color.a > 1f - this.sanity / 100f + 0.0001f || this.SanitySmudges.color.a < 1f - this.sanity / 100f - 0.0001f)
		{
			float num3 = this.SanitySmudges.color.a;
			num3 = Mathf.MoveTowards(num3, 1f - this.sanity / 100f, Time.deltaTime);
			this.SanitySmudges.color = new Color(1f, 1f, 1f, num3);
			this.StudentManager.SelectiveGreyscale.desaturation = 1f - this.StudentManager.Atmosphere + num3;
			if (num3 > 0.66666f)
			{
				float faces = 1f - (1f - num3) / 0.33333f;
				this.StudentManager.SetFaces(faces);
			}
			else
			{
				this.StudentManager.SetFaces(0f);
			}
			float num4 = 100f - num3 * 100f;
			this.SanityLabel.text = num4.ToString("0") + "%";
		}
		if (this.CanMove && this.sanity < 33.333f && !this.NearSenpai)
		{
			this.GiggleTimer += Time.deltaTime * (1f - this.sanity / 33.333f);
			if (this.GiggleTimer > 10f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.GiggleDisc, base.transform.position + Vector3.up, Quaternion.identity);
				AudioSource.PlayClipAtPoint(this.CreepyGiggles[UnityEngine.Random.Range(0, this.CreepyGiggles.Length)], base.transform.position);
				this.InsaneLines.Play();
				this.GiggleTimer = 0f;
			}
		}
		if (this.FightHasBrokenUp)
		{
			this.BreakUpTimer = Mathf.MoveTowards(this.BreakUpTimer, 0f, Time.deltaTime);
			if (this.BreakUpTimer == 0f)
			{
				this.FightHasBrokenUp = false;
				this.SeenByAuthority = false;
			}
		}
	}

	public void StainWeapon()
	{
		if (this.EquippedWeapon != null)
		{
			if (this.TargetStudent != null && this.TargetStudent.StudentID < this.EquippedWeapon.Victims.Length)
			{
				this.EquippedWeapon.Victims[this.TargetStudent.StudentID] = true;
			}
			this.EquippedWeapon.Blood.enabled = true;
			this.EquippedWeapon.MurderWeapon = true;
			if (!this.NoStainGloves && this.Gloved && !this.Gloves.Blood.enabled)
			{
				this.GloveAttacher.newRenderer.material.mainTexture = this.BloodyGloveTexture;
				this.Gloves.PickUp.Evidence = true;
				this.Gloves.Blood.enabled = true;
				this.GloveBlood = 1;
				this.Police.BloodyClothing++;
			}
			this.NoStainGloves = false;
			if (this.Mask != null && !this.Mask.Blood.enabled)
			{
				this.Mask.PickUp.Evidence = true;
				this.Mask.Blood.enabled = true;
				this.Police.BloodyClothing++;
			}
			if (!this.EquippedWeapon.Evidence)
			{
				this.EquippedWeapon.Evidence = true;
				this.Police.MurderWeapons++;
			}
		}
	}

	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		this.MyController.Move(a * (Time.deltaTime * 10f));
	}

	public void StopAiming()
	{
		this.UpdateAccessory();
		this.UpdateHair();
		this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
		this.CharacterAnimation["f02_selfie_00"].weight = 0f;
		this.PelvisRoot.transform.localPosition = new Vector3(this.PelvisRoot.transform.localPosition.x, 0f, this.PelvisRoot.transform.localPosition.z);
		this.ShoulderCamera.AimingCamera = false;
		if (!Input.GetButtonDown("Start") && !Input.GetKeyDown(KeyCode.Escape))
		{
			this.FixCamera();
		}
		if (this.ShoulderCamera.Timer == 0f)
		{
			this.RPGCamera.enabled = true;
		}
		if (!OptionGlobals.Fog)
		{
			this.MainCamera.clearFlags = CameraClearFlags.Skybox;
		}
		else
		{
			this.MainCamera.clearFlags = CameraClearFlags.Color;
		}
		this.MainCamera.farClipPlane = (float)OptionGlobals.DrawDistance;
		this.Smartphone.transform.parent.gameObject.SetActive(false);
		this.Smartphone.targetTexture = this.Shutter.SmartphoneScreen;
		this.Smartphone.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		this.Smartphone.fieldOfView = 60f;
		this.Shutter.TargetStudent = 0;
		this.Height = 0f;
		this.Bend = 0f;
		this.HandCamera.gameObject.SetActive(false);
		this.SelfieGuide.SetActive(false);
		this.PhonePromptBar.Show = false;
		this.MainCamera.enabled = true;
		this.UsingController = false;
		this.Aiming = false;
		this.Selfie = false;
		this.Lewd = false;
		this.StudentManager.UpdatePanties(false);
	}

	public void FixCamera()
	{
		this.RPGCamera.enabled = true;
		this.RPGCamera.UpdateRotation();
		this.RPGCamera.mouseSmoothingFactor = 0f;
		this.RPGCamera.GetInput();
		this.RPGCamera.GetDesiredPosition();
		this.RPGCamera.PositionUpdate();
		this.RPGCamera.mouseSmoothingFactor = 0.08f;
		this.Blur.enabled = false;
	}

	private void ResetSenpaiEffects()
	{
		this.DepthOfField.focalSize = 150f;
		this.DepthOfField.focalZStartCurve = 0f;
		this.DepthOfField.focalZEndCurve = 0f;
		this.DepthOfField.enabled = false;
		this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.redChannel.SmoothTangents(1, 0f);
		this.ColorCorrection.greenChannel.SmoothTangents(1, 0f);
		this.ColorCorrection.blueChannel.SmoothTangents(1, 0f);
		this.ColorCorrection.UpdateTextures();
		this.ColorCorrection.enabled = false;
		for (int i = 1; i < 6; i++)
		{
			this.CharacterAnimation[this.CreepyIdles[i]].weight = 0f;
			this.CharacterAnimation[this.CreepyWalks[i]].weight = 0f;
		}
		this.CharacterAnimation["f02_shy_00"].weight = 0f;
		this.HeartBeat.volume = 0f;
		this.SelectGrayscale.desaturation = this.GreyTarget;
		this.SenpaiFade = 100f;
		this.SenpaiTint = 0f;
	}

	public void ResetYandereEffects()
	{
		this.Obscurance.enabled = false;
		this.Vignette.intensity = 0f;
		this.Vignette.blur = 0f;
		this.Vignette.chromaticAberration = 0f;
		this.Vignette.enabled = false;
		this.YandereColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.YandereColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.YandereColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.YandereColorCorrection.redChannel.SmoothTangents(1, 0f);
		this.YandereColorCorrection.greenChannel.SmoothTangents(1, 0f);
		this.YandereColorCorrection.blueChannel.SmoothTangents(1, 0f);
		this.YandereColorCorrection.UpdateTextures();
		this.YandereColorCorrection.enabled = false;
		Time.timeScale = 1f;
		this.YandereFade = 100f;
		this.StudentManager.Tag.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.StudentManager.RedString.gameObject.SetActive(false);
	}

	private void DumpRagdoll(RagdollDumpType Type)
	{
		this.Ragdoll.transform.position = base.transform.position;
		if (Type == RagdollDumpType.Incinerator)
		{
			this.Ragdoll.transform.LookAt(this.Incinerator.transform.position);
			this.Ragdoll.transform.eulerAngles = new Vector3(this.Ragdoll.transform.eulerAngles.x, this.Ragdoll.transform.eulerAngles.y + 180f, this.Ragdoll.transform.eulerAngles.z);
		}
		else if (Type == RagdollDumpType.TranqCase)
		{
			this.Ragdoll.transform.LookAt(this.TranqCase.transform.position);
		}
		else if (Type == RagdollDumpType.WoodChipper)
		{
			this.Ragdoll.transform.LookAt(this.WoodChipper.transform.position);
		}
		RagdollScript component = this.Ragdoll.GetComponent<RagdollScript>();
		component.DumpType = Type;
		component.Dump();
	}

	public void Unequip()
	{
		if (this.CanMove || this.Noticed)
		{
			if (this.Equipped < 3)
			{
				this.CharacterAnimation["f02_reachForWeapon_00"].time = 0f;
				this.ReachWeight = 1f;
				if (this.EquippedWeapon != null)
				{
					this.EquippedWeapon.gameObject.SetActive(false);
				}
			}
			else if (this.Weapon[3] != null)
			{
				this.Weapon[3].Drop();
			}
			this.Equipped = 0;
			this.Mopping = false;
			this.StudentManager.UpdateStudents(0);
			this.WeaponManager.UpdateLabels();
			this.WeaponMenu.UpdateSprites();
			this.WeaponWarning = false;
		}
	}

	public void DropWeapon(int ID)
	{
		this.DropTimer[ID] += Time.deltaTime;
		if (this.DropTimer[ID] > 0.5f)
		{
			this.Weapon[ID].Drop();
			this.Weapon[ID] = null;
			this.Unequip();
			this.DropTimer[ID] = 0f;
		}
	}

	public void EmptyHands()
	{
		if (this.Carrying || this.HeavyWeight)
		{
			this.StopCarrying();
		}
		if (this.Armed)
		{
			this.Unequip();
		}
		if (this.PickUp != null)
		{
			this.PickUp.Drop();
		}
		if (this.Dragging)
		{
			this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
		}
		this.ID = 1;
		while (this.ID < this.Poisons.Length)
		{
			this.Poisons[this.ID].SetActive(false);
			this.ID++;
		}
		this.Mopping = false;
	}

	public void UpdateNumbness()
	{
		this.Numbness = 1f - 0.1f * (float)(this.Class.Numbness + this.Class.NumbnessBonus);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)" && other.transform.localScale.x > 0.3f)
		{
			if (PlayerGlobals.PantiesEquipped == 8)
			{
				this.RightFootprintSpawner.Bloodiness = 5;
				this.LeftFootprintSpawner.Bloodiness = 5;
				return;
			}
			this.RightFootprintSpawner.Bloodiness = 10;
			this.LeftFootprintSpawner.Bloodiness = 10;
		}
	}

	public void UpdateHair()
	{
		if (this.Hairstyle > this.Hairstyles.Length - 1)
		{
			this.Hairstyle = 0;
		}
		if (this.Hairstyle < 0)
		{
			this.Hairstyle = this.Hairstyles.Length - 1;
		}
		this.ID = 1;
		while (this.ID < this.Hairstyles.Length)
		{
			this.Hairstyles[this.ID].SetActive(false);
			this.ID++;
		}
		if (this.Hairstyle > 0)
		{
			this.Hairstyles[this.Hairstyle].SetActive(true);
		}
	}

	public void StopLaughing()
	{
		Debug.Log("Yandere-chan has been instructed to stop laughing.");
		this.BladeHairCollider1.enabled = false;
		this.BladeHairCollider2.enabled = false;
		if (this.Sanity < 33.33333f)
		{
			this.Teeth.SetActive(true);
		}
		this.LaughIntensity = 0f;
		this.Laughing = false;
		this.LaughClip = null;
		this.Twitch = Vector3.zero;
		if (!this.Stand.Stand.activeInHierarchy)
		{
			this.CanMove = true;
		}
		if (this.BanchoActive)
		{
			AudioSource.PlayClipAtPoint(this.BanchoFinalYan, base.transform.position);
			this.CharacterAnimation.CrossFade("f02_banchoFinisher_00");
			this.BanchoFlurry.MyCollider.enabled = false;
			this.Finisher = true;
			this.CanMove = false;
		}
	}

	private void SetUniform()
	{
		if (StudentGlobals.FemaleUniform == 0)
		{
			StudentGlobals.FemaleUniform = 1;
		}
		this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
		if (this.Casual)
		{
			this.TextureToUse = this.UniformTextures[StudentGlobals.FemaleUniform];
		}
		else
		{
			this.TextureToUse = this.CasualTextures[StudentGlobals.FemaleUniform];
		}
		this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
		this.MyRenderer.materials[1].mainTexture = this.TextureToUse;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		base.StartCoroutine(this.ApplyCustomCostume());
	}

	private IEnumerator ApplyCustomCostume()
	{
		if (StudentGlobals.FemaleUniform == 1)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 2)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 3)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 4 || StudentGlobals.FemaleUniform == 5)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
		yield return CustomFace;
		if (CustomFace.error == null)
		{
			this.MyRenderer.materials[2].mainTexture = CustomFace.texture;
			this.FaceTexture = CustomFace.texture;
		}
		WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
		yield return CustomHair;
		if (CustomHair.error == null)
		{
			this.PonytailRenderer.material.mainTexture = CustomHair.texture;
			this.PigtailR.material.mainTexture = CustomHair.texture;
			this.PigtailL.material.mainTexture = CustomHair.texture;
		}
		WWW CustomDrills = new WWW("file:///" + Application.streamingAssetsPath + "/CustomDrills.png");
		yield return CustomDrills;
		if (CustomDrills.error == null)
		{
			this.Drills.materials[0].mainTexture = CustomDrills.texture;
			this.Drills.material.mainTexture = CustomDrills.texture;
		}
		WWW CustomSwimsuit = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSwimsuit.png");
		yield return CustomSwimsuit;
		if (CustomSwimsuit.error == null)
		{
			this.SwimsuitTexture = CustomSwimsuit.texture;
		}
		WWW CustomGym = new WWW("file:///" + Application.streamingAssetsPath + "/CustomGym.png");
		yield return CustomGym;
		if (CustomGym.error == null)
		{
			this.GymTexture = CustomGym.texture;
		}
		WWW CustomNude = new WWW("file:///" + Application.streamingAssetsPath + "/CustomNude.png");
		yield return CustomNude;
		if (CustomNude.error == null)
		{
			this.NudeTexture = CustomNude.texture;
		}
		WWW CustomLongHairA = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairA.png");
		yield return CustomDrills;
		WWW CustomLongHairB = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairB.png");
		yield return CustomDrills;
		WWW CustomLongHairC = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairC.png");
		yield return CustomDrills;
		if (CustomLongHairA.error == null && CustomLongHairB.error == null && CustomLongHairC.error == null)
		{
			this.LongHairRenderer.materials[0].mainTexture = CustomLongHairA.texture;
			this.LongHairRenderer.materials[1].mainTexture = CustomLongHairB.texture;
			this.LongHairRenderer.materials[2].mainTexture = CustomLongHairC.texture;
		}
		yield break;
	}

	public void WearGloves()
	{
		if (this.Bloodiness > 0f && !this.Gloves.Blood.enabled)
		{
			this.Gloves.PickUp.Evidence = true;
			this.Gloves.Blood.enabled = true;
			this.Police.BloodyClothing++;
		}
		if (this.Gloves.Blood.enabled)
		{
			this.GloveBlood = 1;
		}
		this.Gloved = true;
		this.GloveAttacher.newRenderer.enabled = true;
	}

	private void AttackOnTitan()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MusicCredit.SongLabel.text = "Now Playing: This Is My Choice";
		this.MusicCredit.BandLabel.text = "By: The Kira Justice";
		this.MusicCredit.Panel.enabled = true;
		this.MusicCredit.Slide = true;
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.TitanTexture;
		this.MyRenderer.materials[1].mainTexture = this.TitanTexture;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.Outline.h.ReinitMaterials();
	}

	private void KON()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[4];
		this.MyRenderer.materials[0].mainTexture = this.KONTexture;
		this.MyRenderer.materials[1].mainTexture = this.KONTexture;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.Outline.h.ReinitMaterials();
	}

	private void Punish()
	{
		this.PunishedShader = Shader.Find("Toon/Cutoff");
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
		this.PunishedAccessories.SetActive(true);
		this.PunishedScarf.SetActive(true);
		this.EyepatchL.SetActive(false);
		this.EyepatchR.SetActive(false);
		this.ID = 0;
		while (this.ID < this.PunishedArm.Length)
		{
			this.PunishedArm[this.ID].SetActive(true);
			this.ID++;
		}
		this.MyRenderer.sharedMesh = this.PunishedMesh;
		this.MyRenderer.materials[0].mainTexture = this.PunishedTextures[1];
		this.MyRenderer.materials[1].mainTexture = this.PunishedTextures[1];
		this.MyRenderer.materials[2].mainTexture = this.PunishedTextures[0];
		this.MyRenderer.materials[1].shader = this.PunishedShader;
		this.MyRenderer.materials[1].SetFloat("_Shininess", 1f);
		this.MyRenderer.materials[1].SetFloat("_ShadowThreshold", 0f);
		this.MyRenderer.materials[1].SetFloat("_Cutoff", 0.9f);
		this.MyRenderer.materials[1].color = new Color(1f, 1f, 1f, 1f);
		this.Outline.h.ReinitMaterials();
	}

	private void Hate()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.HatefulUniform;
		this.MyRenderer.materials[1].mainTexture = this.HatefulUniform;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		RenderSettings.skybox = this.HatefulSkybox;
		this.SelectGrayscale.desaturation = 1f;
		this.HeartRate.gameObject.SetActive(false);
		this.Sanity = 0f;
		this.Hairstyle = 15;
		this.UpdateHair();
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
	}

	private void Sukeban()
	{
		this.IdleAnim = "f02_idle_00";
		this.SukebanAccessories.SetActive(true);
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[1].mainTexture = this.SukebanBandages;
		this.MyRenderer.materials[0].mainTexture = this.SukebanUniform;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
	}

	private void Bancho()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.BanchoCamera.SetActive(true);
		this.MotionObject.enabled = true;
		this.MotionBlur.enabled = true;
		this.BanchoAccessories[0].SetActive(true);
		this.BanchoAccessories[1].SetActive(true);
		this.BanchoAccessories[2].SetActive(true);
		this.BanchoAccessories[3].SetActive(true);
		this.BanchoAccessories[4].SetActive(true);
		this.BanchoAccessories[5].SetActive(true);
		this.BanchoAccessories[6].SetActive(true);
		this.BanchoAccessories[7].SetActive(true);
		this.BanchoAccessories[8].SetActive(true);
		this.Laugh1 = this.BanchoYanYan;
		this.Laugh2 = this.BanchoYanYan;
		this.Laugh3 = this.BanchoYanYan;
		this.Laugh4 = this.BanchoYanYan;
		this.IdleAnim = "f02_banchoIdle_00";
		this.WalkAnim = "f02_banchoWalk_00";
		this.RunAnim = "f02_banchoSprint_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.RunSpeed *= 2f;
		this.BanchoPants.SetActive(true);
		this.MyRenderer.sharedMesh = this.BanchoMesh;
		this.MyRenderer.materials[0].mainTexture = this.BanchoFace;
		this.MyRenderer.materials[1].mainTexture = this.BanchoBody;
		this.MyRenderer.materials[2].mainTexture = this.BanchoBody;
		this.BanchoActive = true;
		this.TheDebugMenuScript.UpdateCensor();
		this.Character.transform.localPosition = new Vector3(0f, 0.04f, 0f);
		this.Hairstyle = 0;
		this.UpdateHair();
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
	}

	private void Slend()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		RenderSettings.skybox = this.SlenderSkybox;
		this.SelectGrayscale.desaturation = 0.5f;
		this.SelectGrayscale.enabled = true;
		this.EasterEggMenu.SetActive(false);
		this.Slender = true;
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
		this.SlenderHair[0].SetActive(true);
		this.SlenderHair[1].SetActive(true);
		this.RightYandereEye.gameObject.SetActive(false);
		this.LeftYandereEye.gameObject.SetActive(false);
		this.Character.transform.localPosition = new Vector3(this.Character.transform.localPosition.x, 0.822f, this.Character.transform.localPosition.z);
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.SlenderUniform;
		this.MyRenderer.materials[1].mainTexture = this.SlenderUniform;
		this.MyRenderer.materials[2].mainTexture = this.SlenderSkin;
		this.Sanity = 0f;
	}

	private void X()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.Xtan = true;
		this.Egg = true;
		this.Hairstyle = 9;
		this.UpdateHair();
		this.BlackEyePatch.SetActive(true);
		this.XSclera.SetActive(true);
		this.XEye.SetActive(true);
		this.Schoolwear = 2;
		this.ChangeSchoolwear();
		this.CanMove = true;
		this.MyRenderer.materials[0].mainTexture = this.XBody;
		this.MyRenderer.materials[1].mainTexture = this.XBody;
		this.MyRenderer.materials[2].mainTexture = this.XFace;
	}

	private void GaloSengen()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.IdleAnim = "f02_gruntIdle_00";
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
		this.ID = 0;
		while (this.ID < this.GaloAccessories.Length)
		{
			this.GaloAccessories[this.ID].SetActive(true);
			this.ID++;
		}
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.UniformTextures[1];
		this.MyRenderer.materials[1].mainTexture = this.GaloArms;
		this.MyRenderer.materials[2].mainTexture = this.GaloFace;
		this.Hairstyle = 14;
		this.UpdateHair();
	}

	public void Jojo()
	{
		this.ShoulderCamera.LastPosition = this.ShoulderCamera.transform.position;
		this.ShoulderCamera.Summoning = true;
		this.RPGCamera.enabled = false;
		AudioSource.PlayClipAtPoint(this.SummonStand, base.transform.position);
		this.IdleAnim = "f02_jojoPose_00";
		this.WalkAnim = "f02_jojoWalk_00";
		this.EasterEggMenu.SetActive(false);
		this.CanMove = false;
		this.Egg = true;
		this.CharacterAnimation.CrossFade("f02_summonStand_00");
		this.Laugh1 = this.YanYan;
		this.Laugh2 = this.YanYan;
		this.Laugh3 = this.YanYan;
		this.Laugh4 = this.YanYan;
	}

	private void Agent()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.Uniforms[4];
		this.MyRenderer.materials[0].mainTexture = this.AgentSuit;
		this.MyRenderer.materials[1].mainTexture = this.AgentSuit;
		this.MyRenderer.materials[2].mainTexture = this.AgentFace;
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	private void Cirno()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.Uniforms[3];
		this.MyRenderer.materials[0].mainTexture = this.CirnoUniform;
		this.MyRenderer.materials[1].mainTexture = this.CirnoUniform;
		this.MyRenderer.materials[2].mainTexture = this.CirnoFace;
		this.CirnoWings.SetActive(true);
		this.CirnoHair.SetActive(true);
		this.IdleAnim = "f02_cirnoIdle_00";
		this.WalkAnim = "f02_cirnoWalk_00";
		this.RunAnim = "f02_cirnoRun_00";
		this.EasterEggMenu.SetActive(false);
		this.Stance.Current = StanceType.Standing;
		this.Uncrouch();
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	private void Falcon()
	{
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.FalconFace;
		this.MyRenderer.materials[1].mainTexture = this.FalconBody;
		this.MyRenderer.materials[2].mainTexture = this.FalconBody;
		this.FalconShoulderpad.SetActive(true);
		this.FalconKneepad1.SetActive(true);
		this.FalconKneepad2.SetActive(true);
		this.FalconBuckle.SetActive(true);
		this.FalconHelmet.SetActive(true);
		this.CharacterAnimation[this.RunAnim].speed = 5f;
		this.IdleAnim = "f02_falconIdle_00";
		this.RunSpeed *= 5f;
		this.Egg = true;
		this.Hairstyle = 3;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Punch()
	{
		this.MusicCredit.SongLabel.text = "Now Playing: Unknown Hero";
		this.MusicCredit.BandLabel.text = "By: The Kira Justice";
		this.MusicCredit.Panel.enabled = true;
		this.MusicCredit.Slide = true;
		this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.SaitamaSuit;
		this.MyRenderer.materials[1].mainTexture = this.SaitamaSuit;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.EasterEggMenu.SetActive(false);
		this.Barcode.SetActive(false);
		this.Cape.SetActive(true);
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void BadTime()
	{
		this.MyRenderer.sharedMesh = this.Jersey;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.SansFace;
		this.MyRenderer.materials[1].mainTexture = this.SansTexture;
		this.MyRenderer.materials[2].mainTexture = this.SansTexture;
		this.EasterEggMenu.SetActive(false);
		this.IdleAnim = "f02_sansIdle_00";
		this.WalkAnim = "f02_sansWalk_00";
		this.RunAnim = "f02_sansRun_00";
		this.StudentManager.BadTime();
		this.Barcode.SetActive(false);
		this.Sans = true;
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().EasterEggCheck();
	}

	private void CyborgNinja()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.EnergySword.SetActive(true);
		this.IdleAnim = "CyborgNinja_Idle_Unarmed";
		this.RunAnim = "CyborgNinja_Run_Unarmed";
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.CyborgFace;
		this.MyRenderer.materials[1].mainTexture = this.CyborgBody;
		this.MyRenderer.materials[2].mainTexture = this.CyborgBody;
		this.Schoolwear = 0;
		this.ID = 1;
		while (this.ID < this.CyborgParts.Length)
		{
			this.CyborgParts[this.ID].SetActive(true);
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < this.StudentManager.Students.Length)
		{
			StudentScript studentScript = this.StudentManager.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Teacher = false;
			}
			this.ID++;
		}
		this.RunSpeed *= 2f;
		this.EyewearID = 6;
		this.Hairstyle = 45;
		this.UpdateHair();
		this.Ninja = true;
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Ebola()
	{
		this.StudentManager.Ebola = true;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.IdleAnim = "f02_ebolaIdle_00";
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.EbolaUniform;
		this.MyRenderer.materials[1].mainTexture = this.EbolaUniform;
		this.MyRenderer.materials[2].mainTexture = this.EbolaFace;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.EbolaWings.SetActive(true);
		this.EbolaHair.SetActive(true);
		this.Egg = true;
	}

	private void Long()
	{
		this.MyRenderer.sharedMesh = this.LongUniform;
	}

	private void SwapMesh()
	{
		this.MyRenderer.sharedMesh = this.NewMesh;
		this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
		this.MyRenderer.materials[1].mainTexture = this.NewFace;
		this.MyRenderer.materials[2].mainTexture = this.TextureToUse;
		this.RightYandereEye.gameObject.SetActive(false);
		this.LeftYandereEye.gameObject.SetActive(false);
	}

	private void Nude()
	{
		Debug.Log("Making Yandere-chan nude.");
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.ID = 0;
		while (this.ID < this.CensorSteam.Length)
		{
			this.ID++;
		}
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
		this.EasterEggMenu.SetActive(false);
		this.ClubAttire = false;
		this.Schoolwear = 0;
		this.ClubAccessory();
	}

	private void Samus()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.SamusFace;
		this.MyRenderer.materials[1].mainTexture = this.SamusBody;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.PonytailRenderer.material.mainTexture = this.SamusFace;
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Witch()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.WitchFace;
		this.MyRenderer.materials[1].mainTexture = this.WitchBody;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.IdleAnim = "f02_idleElegant_00";
		this.WalkAnim = "f02_jojoWalk_00";
		this.WitchMode = true;
		this.Egg = true;
		this.Hairstyle = 100;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Pose()
	{
		if (!this.StudentManager.Pose)
		{
			this.StudentManager.Pose = true;
		}
		else
		{
			this.StudentManager.Pose = false;
		}
		this.StudentManager.UpdateStudents(0);
	}

	private void HairBlades()
	{
		this.Hairstyle = 0;
		this.UpdateHair();
		this.BladeHair.SetActive(true);
		this.Egg = true;
	}

	private void Tornado()
	{
		this.Hairstyle = 0;
		this.UpdateHair();
		this.IdleAnim = "f02_tornadoIdle_00";
		this.WalkAnim = "f02_tornadoWalk_00";
		this.RunAnim = "f02_tornadoRun_00";
		this.TornadoHair.SetActive(true);
		this.TornadoDress.SetActive(true);
		this.RiggedAccessory.SetActive(true);
		this.MyRenderer.sharedMesh = this.NoTorsoMesh;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.Sanity = 100f;
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudePanties;
		this.MyRenderer.materials[2].mainTexture = this.NudePanties;
		this.TheDebugMenuScript.UpdateCensor();
		this.Stance.Current = StanceType.Standing;
		this.Egg = true;
	}

	private void GenderSwap()
	{
		this.Kun.SetActive(true);
		this.KunHair.SetActive(true);
		this.MyRenderer.enabled = false;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.IdleAnim = "idleShort_00";
		this.WalkAnim = "walk_00";
		this.RunAnim = "newSprint_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	private void Mandere()
	{
		this.Man.SetActive(true);
		this.Barcode.SetActive(false);
		this.MyRenderer.enabled = false;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.RightYandereEye.gameObject.SetActive(false);
		this.LeftYandereEye.gameObject.SetActive(false);
		this.IdleAnim = "idleShort_00";
		this.WalkAnim = "walk_00";
		this.RunAnim = "newSprint_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	private void BlackHoleChan()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.BlackHoleFace;
		this.MyRenderer.materials[1].mainTexture = this.Black;
		this.MyRenderer.materials[2].mainTexture = this.Black;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.IdleAnim = "f02_gazerIdle_00";
		this.WalkAnim = "f02_gazerWalk_00";
		this.RunAnim = "f02_gazerRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.Hairstyle = 182;
		this.UpdateHair();
		this.BlackHoleEffects.SetActive(true);
		this.BlackHole = true;
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void ElfenLied()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		GameObject[] vectors = this.Vectors;
		for (int i = 0; i < vectors.Length; i++)
		{
			vectors[i].SetActive(true);
		}
		this.IdleAnim = "f02_sixIdle_00";
		this.WalkAnim = "f02_sixWalk_00";
		this.RunAnim = "f02_sixRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.LucyHelmet.SetActive(true);
		this.Bandages.SetActive(true);
		this.Egg = true;
		this.WalkSpeed = 0.75f;
		this.RunSpeed = 2f;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Ghoul()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.GhoulFace;
		this.MyRenderer.materials[1].mainTexture = this.GhoulBody;
		this.MyRenderer.materials[2].mainTexture = this.GhoulBody;
		GameObject[] kagune = this.Kagune;
		for (int i = 0; i < kagune.Length; i++)
		{
			kagune[i].SetActive(true);
		}
		this.IdleAnim = "f02_sixIdle_00";
		this.WalkAnim = "f02_sixWalk_00";
		this.RunAnim = "f02_psychoRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.StudentManager.Six = true;
		this.StudentManager.UpdateStudents(0);
		this.Egg = true;
		this.WalkSpeed = 0.75f;
		this.RunSpeed = 10f;
		this.Hairstyle = 15;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Berserk()
	{
		SchoolGlobals.SchoolAtmosphere = 0.5f;
		this.StudentManager.SetAtmosphere();
		GameObject[] armor = this.Armor;
		for (int i = 0; i < armor.Length; i++)
		{
			armor[i].SetActive(true);
		}
		Renderer[] trees = this.StudentManager.Trees;
		for (int i = 0; i < trees.Length; i++)
		{
			trees[i].materials[1] = this.Trans;
		}
		this.SithSpawnTime = this.NierSpawnTime;
		this.SithHardSpawnTime1 = this.NierHardSpawnTime;
		this.SithHardSpawnTime2 = this.NierHardSpawnTime;
		this.SithAudio.clip = this.NierSwoosh;
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.Scarface;
		this.MyRenderer.materials[1].mainTexture = this.Chainmail;
		this.MyRenderer.materials[2].mainTexture = this.Chainmail;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.TheDebugMenuScript.UpdateCensor();
		this.IdleAnim = "f02_heroicIdle_00";
		this.WalkAnim = "f02_walkConfident_00";
		this.RunAnim = "f02_nierRun_00";
		this.CharacterAnimation["f02_nierRun_00"].speed = 1f;
		this.CharacterAnimation["f02_gutsEye_00"].weight = 1f;
		this.RunSpeed = 7.5f;
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.Hairstyle = 188;
		this.UpdateHair();
		this.Egg = true;
	}

	private void Sith()
	{
		this.Hairstyle = 67;
		this.UpdateHair();
		this.SithTrail1.SetActive(true);
		this.SithTrail2.SetActive(true);
		this.IdleAnim = "f02_sithIdle_00";
		this.WalkAnim = "f02_sithWalk_00";
		this.RunAnim = "f02_sithRun_00";
		this.BlackRobe.SetActive(true);
		this.MyRenderer.sharedMesh = this.NoUpperBodyMesh;
		this.MyRenderer.materials[0].mainTexture = this.NudePanties;
		this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudePanties;
		this.Stance.Current = StanceType.Standing;
		this.FollowHips = true;
		this.SithLord = true;
		this.Egg = true;
		this.TheDebugMenuScript.UpdateCensor();
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.RunSpeed *= 2f;
		this.Zoom.TargetZoom = 0.4f;
	}

	private void Snake()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.SnakeBody;
		this.MyRenderer.materials[1].mainTexture = this.SnakeBody;
		this.MyRenderer.materials[2].mainTexture = this.SnakeFace;
		this.Hairstyle = 161;
		this.UpdateHair();
		this.Medusa = true;
		this.Egg = true;
	}

	private void Gazer()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.GazerEyes.gameObject.SetActive(true);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.GazerFace;
		this.MyRenderer.materials[1].mainTexture = this.GazerBody;
		this.MyRenderer.materials[2].mainTexture = this.GazerBody;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.IdleAnim = "f02_gazerIdle_00";
		this.WalkAnim = "f02_gazerWalk_00";
		this.RunAnim = "f02_gazerRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.Hairstyle = 158;
		this.UpdateHair();
		this.StudentManager.Gaze = true;
		this.StudentManager.UpdateStudents(0);
		this.Gazing = true;
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Six()
	{
		RenderSettings.skybox = this.HatefulSkybox;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.IdleAnim = "f02_sixIdle_00";
		this.WalkAnim = "f02_sixWalk_00";
		this.RunAnim = "f02_sixRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.SixRaincoat.SetActive(true);
		this.MyRenderer.sharedMesh = this.SixBodyMesh;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.SixFaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		this.TheDebugMenuScript.UpdateCensor();
		SchoolGlobals.SchoolAtmosphere = 0f;
		this.StudentManager.SetAtmosphere();
		this.StudentManager.Six = true;
		this.StudentManager.UpdateStudents(0);
		this.WalkSpeed = 0.75f;
		this.RunSpeed = 2f;
		this.Hungry = true;
		this.Egg = true;
	}

	private void KLK()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.KLKSword.SetActive(true);
		this.IdleAnim = "f02_heroicIdle_00";
		this.WalkAnim = "f02_walkConfident_00";
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.KLKFace;
		this.MyRenderer.materials[1].mainTexture = this.KLKBody;
		this.MyRenderer.materials[2].mainTexture = this.KLKBody;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.ID = 0;
		while (this.ID < this.KLKParts.Length)
		{
			this.KLKParts[this.ID].SetActive(true);
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < this.StudentManager.Students.Length)
		{
			StudentScript studentScript = this.StudentManager.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Teacher = false;
			}
			this.ID++;
		}
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	public void Miyuki()
	{
		this.MiyukiCostume.SetActive(true);
		this.MiyukiWings.SetActive(true);
		this.IdleAnim = "f02_idleGirly_00";
		this.WalkAnim = "f02_walkGirly_00";
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.MiyukiFace;
		this.MyRenderer.materials[1].mainTexture = this.MiyukiSkin;
		this.MyRenderer.materials[2].mainTexture = this.MiyukiSkin;
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.TheDebugMenuScript.UpdateCensor();
		this.Jukebox.MiyukiMusic();
		this.Hairstyle = 171;
		this.UpdateHair();
		this.MagicalGirl = true;
		this.Egg = true;
	}

	public void AzurLane()
	{
		this.Schoolwear = 2;
		this.ChangeSchoolwear();
		this.PantyAttacher.newRenderer.enabled = false;
		this.IdleAnim = "f02_gazerIdle_00";
		this.WalkAnim = "f02_gazerWalk_00";
		this.RunAnim = "f02_gazerRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.AzurGuns.SetActive(true);
		this.AzurWater.SetActive(true);
		this.AzurMist.SetActive(true);
		this.Shipgirl = true;
		this.CanMove = true;
		this.Egg = true;
		this.Jukebox.Shipgirl();
	}

	private void Blacklight()
	{
		this.BlacklightShader.enabled = true;
		this.Hairstyle = 196;
		this.UpdateHair();
		this.IdleAnim = "f02_idleElegant_00";
		this.WalkAnim = "f02_jojoWalk_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.BlacklightOutfit.SetActive(true);
		this.MyRenderer.sharedMesh = this.BlacklightBodyMesh;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		this.Egg = true;
	}

	public void Weather()
	{
		if (!this.Rain.activeInHierarchy)
		{
			this.StudentManager.Clock.BloomEffect.bloomIntensity = 10f;
			this.StudentManager.Clock.BloomEffect.bloomThreshhold = 0f;
			this.StudentManager.Clock.UpdateBloom = true;
			SchoolGlobals.SchoolAtmosphere = 0f;
			this.StudentManager.SetAtmosphere();
			this.Rain.SetActive(true);
			this.Jukebox.Start();
			return;
		}
		this.Hairstyle = 67;
		this.UpdateHair();
		this.Raincoat.SetActive(true);
		this.MyRenderer.sharedMesh = this.SixBodyMesh;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		this.TheDebugMenuScript.UpdateCensor();
	}

	private void Horror()
	{
		this.Rain.SetActive(false);
		RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
		RenderSettings.skybox = this.HorrorSkybox;
		SchoolGlobals.SchoolAtmosphere = 0f;
		this.StudentManager.SetAtmosphere();
		this.RPGCamera.desiredDistance = 0.33333f;
		this.Zoom.OverShoulder = true;
		this.Zoom.TargetZoom = 0.2f;
		this.PauseScreen.MissionMode.FPS.transform.localPosition = new Vector3(1020f, -465f, 0f);
		this.PauseScreen.MissionMode.Watermark.gameObject.SetActive(false);
		this.PauseScreen.MissionMode.Nemesis.SetActive(true);
		this.StudentManager.Clock.MainLight.color = new Color(0.5f, 0.5f, 0.5f, 1f);
		this.StudentManager.Clock.gameObject.SetActive(false);
		this.StudentManager.Clock.SunFlare.SetActive(false);
		this.StudentManager.Clock.Horror = true;
		this.StudentManager.Students[1].transform.position = new Vector3(0f, 0f, 0f);
		this.StudentManager.Headmaster.gameObject.SetActive(false);
		this.StudentManager.Reputation.gameObject.SetActive(false);
		this.StudentManager.Flashlight.gameObject.SetActive(true);
		this.StudentManager.Flashlight.BePickedUp();
		this.StudentManager.DelinquentRadio.SetActive(false);
		this.StudentManager.CounselorDoor[0].enabled = false;
		this.StudentManager.CounselorDoor[1].enabled = false;
		this.StudentManager.CounselorDoor[0].Prompt.enabled = false;
		this.StudentManager.CounselorDoor[1].Prompt.enabled = false;
		this.StudentManager.Portal.SetActive(false);
		RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
		this.ID = 1;
		while (this.ID < 101)
		{
			if (this.StudentManager.Students[this.ID] != null && this.StudentManager.Students[this.ID].gameObject.activeInHierarchy)
			{
				this.StudentManager.DisableStudent(this.ID);
			}
			this.ID++;
		}
		this.Egg = true;
	}

	private void LifeNote()
	{
		this.ID = 1;
		while (this.ID < 101)
		{
			StudentGlobals.SetStudentPhotographed(this.ID, true);
			this.ID++;
		}
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.LifeNotebook.transform.position = base.transform.position + base.transform.forward + new Vector3(0f, 2.5f, 0f);
		this.LifeNotebook.GetComponent<Rigidbody>().useGravity = true;
		this.LifeNotebook.GetComponent<Rigidbody>().isKinematic = false;
		this.LifeNotebook.gameObject.SetActive(true);
		this.MyRenderer.sharedMesh = this.YamikoMesh;
		this.MyRenderer.materials[0].mainTexture = this.YamikoSkinTexture;
		this.MyRenderer.materials[1].mainTexture = this.YamikoAccessoryTexture;
		this.MyRenderer.materials[2].mainTexture = this.YamikoFaceTexture;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.Hairstyle = 180;
		this.UpdateHair();
		this.StudentManager.NoteWindow.BecomeLifeNote();
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Nier()
	{
		this.NierCostume.SetActive(true);
		this.HeavySwordParent.gameObject.SetActive(true);
		this.LightSwordParent.gameObject.SetActive(true);
		this.HeavySword.GetComponent<WeaponTrail>().Start();
		this.LightSword.GetComponent<WeaponTrail>().Start();
		this.HeavySword.GetComponent<WeaponTrail>().enabled = false;
		this.LightSword.GetComponent<WeaponTrail>().enabled = false;
		this.Pod.SetActive(true);
		this.SithSpawnTime = this.NierSpawnTime;
		this.SithHardSpawnTime1 = this.NierHardSpawnTime;
		this.SithHardSpawnTime2 = this.NierHardSpawnTime;
		this.SithAudio.clip = this.NierSwoosh;
		this.Pod.transform.parent = null;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = null;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.Hairstyle = 181;
		this.UpdateHair();
		this.Egg = true;
		this.IdleAnim = "f02_heroicIdle_00";
		this.WalkAnim = "f02_walkGraceful_00";
		this.RunAnim = "f02_nierRun_00";
		this.RunSpeed = 10f;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	public void WearChinaDress()
	{
		this.EbolaHair.SetActive(false);
		this.EbolaWings.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
		this.EbolaWings.GetComponent<Renderer>().material.SetColor("_OutlineColor", new Color(0f, 0f, 0f));
		this.Hairstyle = 1;
		this.UpdateHair();
		this.ChinaDress.SetActive(true);
		this.Nude();
		this.PantyAttacher.newRenderer.enabled = true;
	}

	private void Vaporwave()
	{
		this.VaporwaveVisuals.ApplyNormalView();
		RenderSettings.skybox = this.VaporwaveSkybox;
		this.PauseScreen.Settings.QualityManager.Obscurance.enabled = false;
		this.PalmTrees.SetActive(true);
		for (int i = 1; i < this.Trees.Length; i++)
		{
			this.Trees[i].SetActive(false);
		}
	}

	public void ChangeSchoolwear()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.RightFootprintSpawner.Bloodiness = 0;
		this.LeftFootprintSpawner.Bloodiness = 0;
		if (this.ClubAttire && this.Bloodiness == 0f)
		{
			this.Schoolwear = this.PreviousSchoolwear;
		}
		this.LabcoatAttacher.RemoveAccessory();
		this.Paint = false;
		this.ID = 0;
		while (this.ID < this.CensorSteam.Length)
		{
			this.CensorSteam[this.ID].SetActive(false);
			this.ID++;
		}
		if (this.Casual)
		{
			this.TextureToUse = this.UniformTextures[StudentGlobals.FemaleUniform];
		}
		else
		{
			this.TextureToUse = this.CasualTextures[StudentGlobals.FemaleUniform];
		}
		if ((this.ClubAttire && this.Bloodiness > 0f) || this.Schoolwear == 0)
		{
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.sharedMesh = this.Towel;
			this.MyRenderer.materials[0].mainTexture = this.TowelTexture;
			this.MyRenderer.materials[1].mainTexture = this.TowelTexture;
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
			this.ClubAttire = false;
			this.Schoolwear = 0;
		}
		else if (this.Schoolwear == 1)
		{
			this.PantyAttacher.newRenderer.enabled = true;
			this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
			if (this.StudentManager.Censor)
			{
				Debug.Log("Activating shadows on Yandere-chan.");
				this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
				this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
				this.PantyAttacher.newRenderer.enabled = false;
			}
			this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
			this.MyRenderer.materials[1].mainTexture = this.TextureToUse;
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
			base.StartCoroutine(this.ApplyCustomCostume());
		}
		else if (this.Schoolwear == 2)
		{
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
			this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
			this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		}
		else if (this.Schoolwear == 3)
		{
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.sharedMesh = this.GymUniform;
			this.MyRenderer.materials[0].mainTexture = this.GymTexture;
			this.MyRenderer.materials[1].mainTexture = this.GymTexture;
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		}
		this.CanMove = false;
		this.Outline.h.ReinitMaterials();
		this.ClubAccessory();
	}

	public void ChangeClubwear()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
		this.Paint = false;
		if (!this.ClubAttire)
		{
			this.ClubAttire = true;
			if (this.Club == ClubType.Art)
			{
				this.MyRenderer.sharedMesh = this.ApronMesh;
				this.MyRenderer.materials[0].mainTexture = this.ApronTexture;
				this.MyRenderer.materials[1].mainTexture = this.ApronTexture;
				this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				this.Schoolwear = 4;
				this.Paint = true;
			}
			else if (this.Club == ClubType.MartialArts)
			{
				this.MyRenderer.sharedMesh = this.JudoGiMesh;
				this.MyRenderer.materials[0].mainTexture = this.JudoGiTexture;
				this.MyRenderer.materials[1].mainTexture = this.JudoGiTexture;
				this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				this.Schoolwear = 5;
			}
			else if (this.Club == ClubType.Science)
			{
				this.LabcoatAttacher.enabled = true;
				this.MyRenderer.sharedMesh = this.HeadAndHands;
				if (this.LabcoatAttacher.Initialized)
				{
					this.LabcoatAttacher.AttachAccessory();
				}
				this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
				this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
				this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
				this.Schoolwear = 6;
			}
		}
		else
		{
			this.ChangeSchoolwear();
			this.ClubAttire = false;
		}
		this.MyLocker.UpdateButtons();
	}

	public void ClubAccessory()
	{
		this.ID = 0;
		while (this.ID < this.ClubAccessories.Length)
		{
			GameObject gameObject = this.ClubAccessories[this.ID];
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
			this.ID++;
		}
		if (!this.CensorSteam[0].activeInHierarchy && this.Club > ClubType.None && this.ClubAccessories[(int)this.Club] != null)
		{
			this.ClubAccessories[(int)this.Club].SetActive(true);
		}
	}

	public void StopCarrying()
	{
		this.CurrentRagdoll = null;
		if (this.Ragdoll != null)
		{
			this.Ragdoll.GetComponent<RagdollScript>().Fall();
		}
		this.HeavyWeight = false;
		this.Carrying = false;
		this.IdleAnim = this.OriginalIdleAnim;
		this.WalkAnim = this.OriginalWalkAnim;
		this.RunAnim = this.OriginalRunAnim;
	}

	private void Crouch()
	{
		this.MyController.center = new Vector3(this.MyController.center.x, 0.55f, this.MyController.center.z);
		this.MyController.height = 0.9f;
	}

	private void Crawl()
	{
		this.MyController.center = new Vector3(this.MyController.center.x, 0.25f, this.MyController.center.z);
		this.MyController.height = 0.1f;
	}

	public void Uncrouch()
	{
		this.MyController.center = new Vector3(this.MyController.center.x, 0.875f, this.MyController.center.z);
		this.MyController.height = 1.55f;
	}

	private void StopArmedAnim()
	{
		this.ID = 0;
		while (this.ID < this.ArmedAnims.Length)
		{
			string name = this.ArmedAnims[this.ID];
			this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, 0f, Time.deltaTime * 10f);
			this.ID++;
		}
	}

	public void UpdateAccessory()
	{
		if (this.AccessoryGroup != null)
		{
			this.AccessoryGroup.SetPartsActive(false);
		}
		if (this.AccessoryID > this.Accessories.Length - 1)
		{
			this.AccessoryID = 0;
		}
		if (this.AccessoryID < 0)
		{
			this.AccessoryID = this.Accessories.Length - 1;
		}
		if (this.AccessoryID > 0)
		{
			this.Accessories[this.AccessoryID].SetActive(true);
			this.AccessoryGroup = this.Accessories[this.AccessoryID].GetComponent<AccessoryGroupScript>();
			if (this.AccessoryGroup != null)
			{
				this.AccessoryGroup.SetPartsActive(true);
			}
		}
	}

	private void DisableHairAndAccessories()
	{
		this.ID = 1;
		while (this.ID < this.Accessories.Length)
		{
			this.Accessories[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < this.Hairstyles.Length)
		{
			this.Hairstyles[this.ID].SetActive(false);
			this.ID++;
		}
	}

	public void BullyPhotoCheck()
	{
		Debug.Log("We are now going to perform a bully photo check.");
		for (int i = 1; i < 26; i++)
		{
			if (PlayerGlobals.GetBullyPhoto(i) > 0)
			{
				Debug.Log("Yandere-chan has a bully photo in her photo gallery!");
				this.BullyPhoto = true;
			}
		}
	}

	public void UpdatePersona(int NewPersona)
	{
		switch (NewPersona)
		{
		case 0:
			this.Persona = YanderePersonaType.Default;
			return;
		case 1:
			this.Persona = YanderePersonaType.Chill;
			return;
		case 2:
			this.Persona = YanderePersonaType.Confident;
			return;
		case 3:
			this.Persona = YanderePersonaType.Elegant;
			return;
		case 4:
			this.Persona = YanderePersonaType.Girly;
			return;
		case 5:
			this.Persona = YanderePersonaType.Graceful;
			return;
		case 6:
			this.Persona = YanderePersonaType.Haughty;
			return;
		case 7:
			this.Persona = YanderePersonaType.Lively;
			return;
		case 8:
			this.Persona = YanderePersonaType.Scholarly;
			return;
		case 9:
			this.Persona = YanderePersonaType.Shy;
			return;
		case 10:
			this.Persona = YanderePersonaType.Tough;
			return;
		case 11:
			this.Persona = YanderePersonaType.Aggressive;
			return;
		case 12:
			this.Persona = YanderePersonaType.Grunt;
			return;
		default:
			return;
		}
	}

	private void SithSoundCheck()
	{
		if (this.SithBeam[1].Damage == 10f || this.NierDamage == 10f)
		{
			if (this.SithSounds == 0 && this.CharacterAnimation[string.Concat(new object[]
			{
				"f02_",
				this.AttackPrefix,
				"Attack",
				this.SithPrefix,
				"_0",
				this.SithCombo
			})].time >= this.SithSpawnTime[this.SithCombo] - 0.1f)
			{
				this.SithAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
				this.SithAudio.Play();
				this.SithSounds++;
				return;
			}
		}
		else if (this.SithSounds == 0)
		{
			if (this.CharacterAnimation[string.Concat(new object[]
			{
				"f02_",
				this.AttackPrefix,
				"Attack",
				this.SithPrefix,
				"_0",
				this.SithCombo
			})].time >= this.SithHardSpawnTime1[this.SithCombo] - 0.1f)
			{
				this.SithAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
				this.SithAudio.Play();
				this.SithSounds++;
				return;
			}
		}
		else if (this.SithSounds == 1)
		{
			if (this.CharacterAnimation[string.Concat(new object[]
			{
				"f02_",
				this.AttackPrefix,
				"Attack",
				this.SithPrefix,
				"_0",
				this.SithCombo
			})].time >= this.SithHardSpawnTime2[this.SithCombo] - 0.1f)
			{
				this.SithAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
				this.SithAudio.Play();
				this.SithSounds++;
				return;
			}
		}
		else if (this.SithSounds == 2 && this.SithCombo == 1 && this.CharacterAnimation[string.Concat(new object[]
		{
			"f02_",
			this.AttackPrefix,
			"Attack",
			this.SithPrefix,
			"_0",
			this.SithCombo
		})].time >= 0.8333333f)
		{
			this.SithAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
			this.SithAudio.Play();
			this.SithSounds++;
		}
	}

	public void UpdateSelfieStatus()
	{
		if (!this.Selfie)
		{
			this.Smartphone.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			this.Smartphone.targetTexture = this.Shutter.SmartphoneScreen;
			this.HandCamera.gameObject.SetActive(true);
			this.SelfieGuide.SetActive(false);
			this.MainCamera.enabled = true;
			this.Blur.enabled = true;
			return;
		}
		if (this.Stance.Current == StanceType.Crawling)
		{
			this.Stance.Current = StanceType.Crouching;
		}
		this.Smartphone.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
		this.UpdateAccessory();
		this.UpdateHair();
		this.HandCamera.gameObject.SetActive(false);
		this.Smartphone.targetTexture = null;
		this.MainCamera.enabled = false;
		this.Smartphone.cullingMask &= ~(1 << LayerMask.NameToLayer("Miyuki"));
		this.AR = false;
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		Cursor.lockState = CursorLockMode.None;
	}
}
