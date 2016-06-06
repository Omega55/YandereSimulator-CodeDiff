using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using HighlightingSystem;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class YandereScript : MonoBehaviour
{
	[CompilerGenerated]
	[Serializable]
	internal sealed class $ApplyCustomCostume$2641 : GenericGenerator<WWW>
	{
		internal YandereScript $self_$2656;

		public $ApplyCustomCostume$2641(YandereScript self_)
		{
			this.$self_$2656 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new YandereScript.$ApplyCustomCostume$2641.$(this.$self_$2656);
		}
	}

	private Quaternion targetRotation;

	private Vector3 targetDirection;

	private GameObject NewTrail;

	private int AccessoryID;

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

	public AccessoryGroupScript AccessoryGroup;

	public DumpsterHandleScript DumpsterHandle;

	public PhonePromptBarScript PhonePromptBar;

	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public WeaponManagerScript WeaponManager;

	public SplashCameraScript SplashCamera;

	public SWP_HeartRateMonitor HeartRate;

	public IncineratorScript Incinerator;

	public InputDeviceScript InputDevice;

	public MusicCreditScript MusicCredit;

	public PauseScreenScript PauseScreen;

	public WoodChipperScript WoodChipper;

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

	public UIPanel DetectionPanel;

	public StudentScript Follower;

	public JukeboxScript Jukebox;

	public OutlineScript Outline;

	public ShutterScript Shutter;

	public RPG_Camera RPGCamera;

	public BucketScript Bucket;

	public PickUpScript PickUp;

	public PoliceScript Police;

	public GloveScript Gloves;

	public UILabel PowerUp;

	public MaskScript Mask;

	public MopScript Mop;

	public UIPanel HUD;

	public CharacterController MyController;

	public Transform DismemberSpot;

	public Transform CameraTarget;

	public Transform CameraFocus;

	public Transform RightBreast;

	public Transform HidingSpot;

	public Transform LeftBreast;

	public Transform ItemParent;

	public Transform PelvisRoot;

	public Transform CameraPOV;

	public Transform RightHand;

	public Transform ExitSpot;

	public Transform LeftHand;

	public Transform Backpack;

	public Transform DropSpot;

	public Transform Homeroom;

	public Transform Senpai;

	public Transform Stool;

	public Transform Eyes;

	public Transform Head;

	public Transform Hips;

	public AudioSource HeartBeat;

	public GameObject[] Accessories;

	public GameObject[] Hairstyles;

	public GameObject[] Shoes;

	public float[] DropTimer;

	public GameObject CinematicCamera;

	public GameObject EasterEggMenu;

	public GameObject Copyrights;

	public GameObject GiggleDisc;

	public GameObject HandCamera;

	public GameObject KONGlasses;

	public GameObject AlarmDisc;

	public GameObject Character;

	public GameObject DebugMenu;

	public GameObject EyepatchL;

	public GameObject EyepatchR;

	public GameObject ShoePair;

	public GameObject Barcode;

	public GameObject Ragdoll;

	public GameObject Hearts;

	public GameObject Phone;

	public GameObject Trail;

	public SkinnedMeshRenderer MyRenderer;

	public SpringJoint RagdollDragger;

	public SpringJoint RagdollPK;

	public Projector MyProjector;

	public Camera HeartCamera;

	public Camera MainCamera;

	public Camera Smartphone;

	public Renderer SmartphoneRenderer;

	public Renderer LongHairRenderer;

	public Renderer PonytailRenderer;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public float CinematicTimer;

	public float YandereTimer;

	public float AttackTimer;

	public float CrawlTimer;

	public float GloveTimer;

	public float LaughTimer;

	public float BoneTimer;

	public float DumpTimer;

	public float TalkTimer;

	public float Bloodiness;

	public float PreviousSanity;

	public float Sanity;

	public float TwitchTimer;

	public float NextTwitch;

	public float LaughIntensity;

	public float TimeSkipHeight;

	public float PourDistance;

	public float TargetHeight;

	public float BreastSize;

	public float Numbness;

	public float PourTime;

	public float RunSpeed;

	public float Height;

	public float Slouch;

	public float Bend;

	public float CrouchSpeed;

	public float CrawlSpeed;

	public float FlapSpeed;

	public float WalkSpeed;

	public float YandereFade;

	public float YandereTint;

	public float SenpaiFade;

	public float SenpaiTint;

	public int PreviousSchoolwear;

	public int CarryAnimID;

	public int AttackPhase;

	public int Interaction;

	public int NearBodies;

	public int Schoolwear;

	public int EyewearID;

	public int Followers;

	public int Hairstyle;

	public int Equipped;

	public int Costume;

	public bool BloodyWarning;

	public bool CorpseWarning;

	public bool SanityWarning;

	public bool WeaponWarning;

	public bool DumpsterGrabbing;

	public bool Dismembering;

	public bool TimeSkipping;

	public bool Trespassing;

	public bool Struggling;

	public bool Attacking;

	public bool Crouching;

	public bool Degloving;

	public bool Stripping;

	public bool Blasting;

	public bool Carrying;

	public bool Chipping;

	public bool Crawling;

	public bool Dragging;

	public bool Dropping;

	public bool Laughing;

	public bool Punching;

	public bool Throwing;

	public bool Bathing;

	public bool Cooking;

	public bool Dipping;

	public bool Dumping;

	public bool Exiting;

	public bool Lifting;

	public bool Mopping;

	public bool Pouring;

	public bool Talking;

	public bool Aiming;

	public bool Hiding;

	public bool CrouchButtonDown;

	public bool UsingController;

	public bool CameFromCrouch;

	public bool PossessPoison;

	public bool YandereVision;

	public bool ClubActivity;

	public bool PossessTranq;

	public bool PlayedSound;

	public bool SummonBones;

	public bool ClubAttire;

	public bool NearSenpai;

	public bool RivalPhone;

	public bool Possessed;

	public bool Attacked;

	public bool CanTranq;

	public bool Collapse;

	public bool RoofPush;

	public bool Demonic;

	public bool FlapOut;

	public bool Noticed;

	public bool InClass;

	public bool Slender;

	public bool CanMove;

	public bool Chased;

	public bool Gloved;

	public bool Shoved;

	public bool Armed;

	public bool Drown;

	public bool Xtan;

	public bool Lewd;

	public bool Lost;

	public bool Sans;

	public bool Egg;

	public bool Won;

	public bool DK;

	public bool PK;

	public Texture[] UniformTextures;

	public Texture[] BloodTextures;

	public WeaponScript[] Weapon;

	public string[] ArmedAnims;

	public string[] CarryAnims;

	public Transform[] Spine;

	public AudioClip[] Stabs;

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

	public Transform AntennaeR;

	public Transform AntennaeL;

	public Transform RightEye;

	public Transform LeftEye;

	public float EyeShrink;

	public Vector3 Twitch;

	private AudioClip LaughClip;

	public string PourHeight;

	public string DrownAnim;

	public string LaughAnim;

	public string IdleAnim;

	public string WalkAnim;

	public string RunAnim;

	public string CarryIdleAnim;

	public string CarryWalkAnim;

	public string CarryRunAnim;

	public AudioClip ChargeUp;

	public AudioClip Laugh1;

	public AudioClip Laugh2;

	public AudioClip Laugh3;

	public AudioClip Laugh4;

	public Vector3 PreviousPosition;

	public string OriginalIdleAnim;

	public string OriginalWalkAnim;

	public string OriginalRunAnim;

	public Texture YanderePhoneTexture;

	public Texture KokonaPhoneTexture;

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

	public Transform SlenderAntennaeR;

	public Transform SlenderAntennaeL;

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

	public GameObject Stand;

	public Texture AgentFace;

	public Texture AgentSuit;

	public GameObject CirnoIceAttack;

	public AudioClip CirnoIceClip;

	public GameObject CirnoRibbon;

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

	public GameObject FalconNipple1;

	public GameObject FalconNipple2;

	public GameObject FalconBuckle;

	public GameObject FalconHelmet;

	public GameObject FalconGun;

	public AudioClip OnePunchVoice;

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

	public int PKDir;

	public Texture CyborgBody;

	public Texture CyborgFace;

	public GameObject[] CyborgParts;

	public GameObject EnergySword;

	public GameObject EbolaEffect;

	public GameObject EbolaWings;

	public GameObject EbolaHair;

	public Texture EbolaFace;

	public Texture EbolaUniform;

	public Mesh LongUniform;

	public GameObject[] CensorSteam;

	public Texture NudeTexture;

	public Mesh NudeMesh;

	public Texture SamusBody;

	public Texture SamusFace;

	public Mesh SchoolSwimsuit;

	public Mesh GymUniform;

	public Texture FaceTexture;

	public Texture SwimsuitTexture;

	public Texture GymTexture;

	public Mesh JudoGiMesh;

	public Texture JudoGiTexture;

	public Mesh ApronMesh;

	public Texture ApronTexture;

	public bool Paint;

	public GameObject[] ClubAccessories;

	public bool LiftOff;

	public GameObject LiftOffParticles;

	public float LiftOffSpeed;

	public YandereScript()
	{
		this.PreviousSanity = 100f;
		this.Sanity = 100f;
		this.CanMove = true;
		this.PourHeight = string.Empty;
		this.DrownAnim = string.Empty;
		this.LaughAnim = string.Empty;
		this.IdleAnim = string.Empty;
		this.WalkAnim = string.Empty;
		this.RunAnim = string.Empty;
		this.CarryIdleAnim = string.Empty;
		this.CarryWalkAnim = string.Empty;
		this.CarryRunAnim = string.Empty;
		this.OriginalIdleAnim = string.Empty;
		this.OriginalWalkAnim = string.Empty;
		this.OriginalRunAnim = string.Empty;
	}

	public virtual void Start()
	{
		this.SetAnimationLayers();
		this.UpdateNumbness();
		Application.targetFrameRate = 60;
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		this.Character.animation["f02_yanderePose_00"].weight = (float)0;
		this.Character.animation["f02_cameraPose_00"].weight = (float)0;
		ColorCorrectionCurves[] components = Camera.main.GetComponents<ColorCorrectionCurves>();
		Vignetting[] components2 = Camera.main.GetComponents<Vignetting>();
		this.YandereColorCorrection = components[1];
		this.Vignette = components2[1];
		this.ResetYandereEffects();
		this.ResetSenpaiEffects();
		this.UpdateSanity();
		this.UpdateBlood();
		this.SetUniform();
		int num = 0;
		Vector3 localPosition = this.EasterEggMenu.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.EasterEggMenu.transform.localPosition = localPosition;
		this.Smartphone.transform.parent.active = false;
		this.ObstacleDetector.gameObject.active = false;
		this.PunishedAccessories.active = false;
		this.SukebanAccessories.active = false;
		this.FalconShoulderpad.active = false;
		this.CensorSteam[0].active = false;
		this.CensorSteam[1].active = false;
		this.CensorSteam[2].active = false;
		this.CensorSteam[3].active = false;
		this.BlackEyePatch.active = false;
		this.EasterEggMenu.active = false;
		this.FalconNipple1.active = false;
		this.FalconNipple2.active = false;
		this.PunishedScarf.active = false;
		this.FalconBuckle.active = false;
		this.FalconHelmet.active = false;
		this.CirnoRibbon.active = false;
		this.CirnoWings.active = false;
		this.KONGlasses.active = false;
		this.EbolaWings.active = false;
		this.EbolaHair.active = false;
		this.FalconGun.active = false;
		this.EyepatchL.active = false;
		this.EyepatchR.active = false;
		this.Shoes[0].active = false;
		this.Shoes[1].active = false;
		this.Stand.active = false;
		this.Cape.active = false;
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.Accessories))
		{
			this.Accessories[this.ID].active = false;
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.PunishedArm))
		{
			this.PunishedArm[this.ID].active = false;
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.GaloAccessories))
		{
			this.GaloAccessories[this.ID].active = false;
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.CyborgParts))
		{
			this.CyborgParts[this.ID].active = false;
			this.ID++;
		}
		if (PlayerPrefs.GetInt("PantiesEquipped") == 5)
		{
			this.RunSpeed += (float)1;
		}
		this.UpdateHair();
		this.ClubAccessory();
	}

	public virtual void SetAnimationLayers()
	{
		this.Character.animation["f02_yanderePose_00"].layer = 1;
		this.Character.animation.Play("f02_yanderePose_00");
		this.Character.animation["f02_yanderePose_00"].weight = (float)0;
		this.Character.animation["f02_shy_00"].layer = 2;
		this.Character.animation.Play("f02_shy_00");
		this.Character.animation["f02_shy_00"].weight = (float)0;
		this.Character.animation["f02_singleSaw_00"].layer = 3;
		this.Character.animation.Play("f02_singleSaw_00");
		this.Character.animation["f02_singleSaw_00"].weight = (float)0;
		this.Character.animation["f02_fist_00"].layer = 4;
		this.Character.animation.Play("f02_fist_00");
		this.Character.animation["f02_fist_00"].weight = (float)0;
		this.Character.animation["f02_mopping_00"].layer = 5;
		this.Character.animation["f02_mopping_00"].speed = (float)2;
		this.Character.animation.Play("f02_mopping_00");
		this.Character.animation["f02_mopping_00"].weight = (float)0;
		this.Character.animation["f02_carry_00"].layer = 6;
		this.Character.animation.Play("f02_carry_00");
		this.Character.animation["f02_carry_00"].weight = (float)0;
		this.Character.animation["f02_mopCarry_00"].layer = 7;
		this.Character.animation.Play("f02_mopCarry_00");
		this.Character.animation["f02_mopCarry_00"].weight = (float)0;
		this.Character.animation["f02_bucketCarry_00"].layer = 8;
		this.Character.animation.Play("f02_bucketCarry_00");
		this.Character.animation["f02_bucketCarry_00"].weight = (float)0;
		this.Character.animation["f02_cameraPose_00"].layer = 9;
		this.Character.animation.Play("f02_cameraPose_00");
		this.Character.animation["f02_cameraPose_00"].weight = (float)0;
		this.Character.animation["f02_grip_00"].layer = 10;
		this.Character.animation.Play("f02_grip_00");
		this.Character.animation["f02_grip_00"].weight = (float)0;
		this.Character.animation["f02_holdHead_00"].layer = 11;
		this.Character.animation.Play("f02_holdHead_00");
		this.Character.animation["f02_holdHead_00"].weight = (float)0;
		this.Character.animation["f02_holdTorso_00"].layer = 12;
		this.Character.animation.Play("f02_holdTorso_00");
		this.Character.animation["f02_holdTorso_00"].weight = (float)0;
		this.Character.animation["f02_carryCan_00"].layer = 13;
		this.Character.animation.Play("f02_carryCan_00");
		this.Character.animation["f02_carryCan_00"].weight = (float)0;
		this.Character.animation["f02_carryShoulder_00"].layer = 14;
		this.Character.animation.Play("f02_carryShoulder_00");
		this.Character.animation["f02_carryShoulder_00"].weight = (float)0;
		this.Character.animation["f02_dipping_00"].speed = (float)2;
		this.Character.animation["f02_stripping_00"].speed = 1.5f;
		this.Character.animation["f02_falconIdle_00"].speed = (float)2;
		this.Character.animation["f02_carryIdleA_00"].speed = 1.75f;
		this.Character.animation["CyborgNinja_Run_Armed"].speed = (float)2;
		this.Character.animation["CyborgNinja_Run_Unarmed"].speed = (float)2;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("left alt"))
		{
			this.CinematicCamera.active = false;
		}
		if (!this.PauseScreen.Show)
		{
			if (this.CanMove)
			{
				this.MyController.Move(Physics.gravity * 0.1f);
				float axis = Input.GetAxis("Vertical");
				float axis2 = Input.GetAxis("Horizontal");
				this.FlapSpeed = Mathf.Abs(axis) + Mathf.Abs(axis2);
				if (!this.Aiming)
				{
					Vector3 a = this.MainCamera.transform.TransformDirection(Vector3.forward);
					a.y = (float)0;
					a = a.normalized;
					Vector3 a2 = new Vector3(a.z, (float)0, -a.x);
					this.targetDirection = axis2 * a2 + axis * a;
					if (this.targetDirection != Vector3.zero)
					{
						this.targetRotation = Quaternion.LookRotation(this.targetDirection);
						this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
					}
					else
					{
						this.targetRotation = new Quaternion((float)0, (float)0, (float)0, (float)0);
					}
					if (axis != (float)0 || axis2 != (float)0)
					{
						if (Input.GetButton("LB") && Vector3.Distance(this.transform.position, this.Senpai.position) > (float)2)
						{
							if (this.Crouching)
							{
								this.Character.animation["f02_crouchWalk_00"].speed = (float)2;
								this.Character.animation.CrossFade("f02_crouchWalk_00");
								this.MyController.Move(this.transform.forward * ((float)2 + (float)(PlayerPrefs.GetInt("PhysicalGrade") + PlayerPrefs.GetInt("SpeedBonus")) * 0.25f) * Time.deltaTime);
							}
							else if (!this.Dragging && !this.Mopping)
							{
								this.Character.animation.CrossFade(this.RunAnim);
								this.MyController.Move(this.transform.forward * (this.RunSpeed + (float)(PlayerPrefs.GetInt("PhysicalGrade") + PlayerPrefs.GetInt("SpeedBonus")) * 0.25f) * Time.deltaTime);
							}
							else
							{
								this.Character.animation.CrossFade("f02_dragWalk_00");
								this.MyController.Move(this.transform.forward * this.WalkSpeed * Time.deltaTime);
							}
							if (this.Crouching)
							{
							}
							if (this.Crawling)
							{
								this.Crawling = false;
								this.Crouching = true;
							}
						}
						else if (!this.Dragging)
						{
							if (this.Crawling)
							{
								this.Character.animation.CrossFade("f02_crawl_10");
								this.MyController.Move(this.transform.forward * this.CrawlSpeed * Time.deltaTime);
							}
							else if (this.Crouching)
							{
								this.Character.animation["f02_crouchWalk_00"].speed = (float)1;
								this.Character.animation.CrossFade("f02_crouchWalk_00");
								this.MyController.Move(this.transform.forward * this.CrouchSpeed * Time.deltaTime);
							}
							else
							{
								this.Character.animation.CrossFade(this.WalkAnim);
								this.MyController.Move(this.transform.forward * this.WalkSpeed * Time.deltaTime);
							}
						}
						else
						{
							this.Character.animation.CrossFade("f02_dragWalk_00");
							this.MyController.Move(this.transform.forward * this.WalkSpeed * Time.deltaTime);
						}
					}
					else if (!this.Dragging)
					{
						if (this.Crawling)
						{
							this.Character.animation.CrossFade("f02_crawlIdle_00");
						}
						else if (this.Crouching)
						{
							this.Character.animation.CrossFade("f02_crouchIdle_00");
						}
						else
						{
							this.Character.animation.CrossFade(this.IdleAnim);
						}
					}
					else
					{
						this.Character.animation.CrossFade("f02_dragIdle_00");
					}
				}
				else
				{
					if (axis != (float)0 || axis2 != (float)0)
					{
						if (this.Crawling)
						{
							this.Character.animation.CrossFade("f02_crawl_10");
							this.MyController.Move(this.transform.forward * this.CrawlSpeed * Time.deltaTime * axis);
							this.MyController.Move(this.transform.right * this.CrawlSpeed * Time.deltaTime * axis2);
						}
						else if (this.Crouching)
						{
							this.Character.animation.CrossFade("f02_crouchWalk_00");
							this.MyController.Move(this.transform.forward * this.CrouchSpeed * Time.deltaTime * axis);
							this.MyController.Move(this.transform.right * this.CrouchSpeed * Time.deltaTime * axis2);
						}
						else
						{
							this.Character.animation.CrossFade(this.WalkAnim);
							this.MyController.Move(this.transform.forward * this.WalkSpeed * Time.deltaTime * axis);
							this.MyController.Move(this.transform.right * this.WalkSpeed * Time.deltaTime * axis2);
						}
					}
					else if (this.Crawling)
					{
						this.Character.animation.CrossFade("f02_crawlIdle_00");
					}
					else if (this.Crouching)
					{
						this.Character.animation.CrossFade("f02_crouchIdle_00");
					}
					else
					{
						this.Character.animation.CrossFade(this.IdleAnim);
					}
					this.Bend += Input.GetAxis("Mouse Y") * (float)8;
					if (this.Crawling)
					{
						if (this.Bend < (float)0)
						{
							this.Bend = (float)0;
						}
					}
					else if (this.Crouching)
					{
						if (this.Bend < (float)-45)
						{
							this.Bend = (float)-45;
						}
					}
					else if (this.Bend < (float)-85)
					{
						this.Bend = (float)-85;
					}
					if (this.Bend > (float)85)
					{
						this.Bend = (float)85;
					}
					float y = this.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * (float)8;
					Vector3 localEulerAngles = this.transform.localEulerAngles;
					float num = localEulerAngles.y = y;
					Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
				}
				if (!this.NearSenpai)
				{
					if (!Input.GetButton("A") && !Input.GetButton("B") && !Input.GetButton("X") && !Input.GetButton("Y") && (Input.GetAxis("LT") > 0.5f || Input.GetMouseButtonDown(1)))
					{
						if (this.Inventory.RivalPhone && Input.GetButtonDown("LB"))
						{
							this.Character.animation["f02_cameraPose_00"].weight = (float)0;
							if (!this.RivalPhone)
							{
								this.SmartphoneRenderer.material.mainTexture = this.KokonaPhoneTexture;
								this.RivalPhone = true;
							}
							else
							{
								this.SmartphoneRenderer.material.mainTexture = this.YanderePhoneTexture;
								this.RivalPhone = false;
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
							}
							float y2 = this.MainCamera.transform.eulerAngles.y;
							Vector3 eulerAngles = this.transform.eulerAngles;
							float num2 = eulerAngles.y = y2;
							Vector3 vector2 = this.transform.eulerAngles = eulerAngles;
							this.Character.animation.Play(this.IdleAnim);
							this.Smartphone.transform.parent.active = true;
							this.ShoulderCamera.AimingCamera = true;
							this.Obscurance.enabled = false;
							this.HandCamera.active = true;
							this.YandereVision = false;
							this.Blur.enabled = true;
							this.Mopping = false;
							this.Aiming = true;
							this.EmptyHands();
							if (this.Inventory.RivalPhone)
							{
								this.PhonePromptBar.Show = true;
							}
							Time.timeScale = (float)1;
						}
					}
					if (!this.Aiming && !this.Crouching && !this.Crawling && !this.Accessories[9].active && !this.Accessories[16].active)
					{
						if (Input.GetButton("RB"))
						{
							this.YandereTimer += Time.deltaTime;
							if (this.YandereTimer > 0.5f)
							{
								if (!this.Sans)
								{
									this.YandereVision = true;
								}
								else
								{
									this.SansEyes[0].active = true;
									this.SansEyes[1].active = true;
									this.GlowEffect.Play();
									this.SummonBones = true;
									this.YandereTimer = (float)0;
									this.CanMove = false;
								}
							}
						}
						else if (this.YandereVision)
						{
							this.Obscurance.enabled = false;
							this.YandereVision = false;
						}
						if (Input.GetButtonUp("RB"))
						{
							if (this.YandereTimer < 0.5f && !this.Dragging && !this.Carrying && !this.Laughing)
							{
								if (this.Sans)
								{
									this.BlasterStage++;
									if (this.BlasterStage > 5)
									{
										this.BlasterStage = 1;
									}
									GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BlasterSet[this.BlasterStage], this.transform.position, Quaternion.identity);
									gameObject.transform.position = this.transform.position;
									gameObject.transform.rotation = this.transform.rotation;
									AudioSource.PlayClipAtPoint(this.BlasterClip, this.transform.position + Vector3.up);
									this.Character.animation["f02_sansBlaster_00"].time = (float)0;
									this.Character.animation.Play("f02_sansBlaster_00");
									this.SansEyes[0].active = true;
									this.SansEyes[1].active = true;
									this.GlowEffect.Play();
									this.Blasting = true;
									this.CanMove = false;
								}
								else if (!this.FalconHelmet.active && this.Barcode.active)
								{
									if (!this.Xtan)
									{
										if (!this.CirnoHair.active)
										{
											this.LaughAnim = "f02_laugh_01";
											this.LaughClip = this.Laugh1;
											this.LaughIntensity += (float)1;
											this.audio.time = (float)0;
											this.audio.Play();
										}
										UnityEngine.Object.Instantiate(this.GiggleDisc, this.transform.position + Vector3.up, Quaternion.identity);
										this.audio.volume = (float)1;
										this.LaughTimer = 0.5f;
										this.Laughing = true;
										this.CanMove = false;
									}
									else if (this.LongHair[0].gameObject.active)
									{
										this.LongHair[0].gameObject.active = false;
										this.SlenderHair[0].active = true;
										this.SlenderHair[1].active = true;
										this.BlackEyePatch.active = false;
									}
									else
									{
										this.LongHair[0].gameObject.active = true;
										this.SlenderHair[0].active = false;
										this.SlenderHair[1].active = false;
										this.BlackEyePatch.active = true;
									}
								}
								else if (!this.Punching)
								{
									if (this.FalconHelmet.active)
									{
										GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(this.FalconWindUp);
										gameObject2.transform.parent = this.ItemParent;
										gameObject2.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
										AudioSource.PlayClipAtPoint(this.FalconPunchVoice, this.transform.position + Vector3.up);
										this.Character.animation["f02_falconPunch_00"].time = (float)0;
										this.Character.animation.Play("f02_falconPunch_00");
										this.FalconSpeed = (float)0;
									}
									else
									{
										AudioSource.PlayClipAtPoint(this.OnePunchVoice, this.transform.position + Vector3.up);
										this.Character.animation["f02_punch_21"].time = (float)0;
										this.Character.animation.CrossFade("f02_punch_21", 0.15f);
									}
									this.Punching = true;
									this.CanMove = false;
								}
							}
							this.YandereTimer = (float)0;
						}
					}
					if (!Input.GetButton("LB"))
					{
						if (!this.Crouching && !this.Crawling)
						{
							if (Input.GetButtonDown("RS"))
							{
								this.Obscurance.enabled = false;
								this.CrouchButtonDown = true;
								this.YandereVision = false;
								this.Crouching = true;
								this.EmptyHands();
							}
						}
						else
						{
							if (this.Crouching)
							{
								if (Input.GetButton("RS") && !this.CameFromCrouch)
								{
									this.CrawlTimer += Time.deltaTime;
								}
								if (this.CrawlTimer > 0.5f)
								{
									this.EmptyHands();
									this.Obscurance.enabled = false;
									this.YandereVision = false;
									this.Crouching = false;
									this.Crawling = true;
									this.CrawlTimer = (float)0;
								}
								else if (Input.GetButtonUp("RS") && !this.CrouchButtonDown && !this.CameFromCrouch)
								{
									this.Crouching = false;
									this.CrawlTimer = (float)0;
								}
							}
							else if (Input.GetButtonDown("RS"))
							{
								this.CameFromCrouch = true;
								this.Crouching = true;
								this.Crawling = false;
							}
							if (Input.GetButtonUp("RS"))
							{
								this.CrouchButtonDown = false;
								this.CameFromCrouch = false;
								this.CrawlTimer = (float)0;
							}
						}
					}
				}
				if (this.Aiming)
				{
					this.Character.animation["f02_cameraPose_00"].weight = Mathf.Lerp(this.Character.animation["f02_cameraPose_00"].weight, (float)1, Time.deltaTime * (float)10);
					if (this.ClubAccessories[7].active && (Input.GetAxis("DpadY") != (float)0 || Input.GetAxis("Mouse ScrollWheel") != (float)0))
					{
						this.Smartphone.fieldOfView = this.Smartphone.fieldOfView - Input.GetAxis("DpadY");
						this.Smartphone.fieldOfView = this.Smartphone.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * (float)10;
						if (this.Smartphone.fieldOfView > (float)60)
						{
							this.Smartphone.fieldOfView = (float)60;
						}
						if (this.Smartphone.fieldOfView < (float)30)
						{
							this.Smartphone.fieldOfView = (float)30;
						}
					}
					if (Input.GetAxis("RT") != (float)0 || Input.GetMouseButtonDown(0) || Input.GetButtonDown("RB"))
					{
						this.FixCamera();
						this.PauseScreen.CorrectingTime = false;
						Time.timeScale = (float)0;
						this.CanMove = false;
						this.Shutter.Snap();
					}
					if (Time.timeScale > (float)0 && ((this.UsingController && Input.GetAxis("LT") < 0.5f) || (!this.UsingController && !Input.GetMouseButton(1))))
					{
						this.StopAiming();
					}
					if (Input.GetKey("left alt"))
					{
						if (!this.CinematicCamera.active)
						{
							if (this.CinematicTimer > (float)0)
							{
								this.CinematicCamera.transform.eulerAngles = this.Smartphone.transform.eulerAngles;
								this.CinematicCamera.transform.position = this.Smartphone.transform.position;
								this.CinematicCamera.active = true;
								this.CinematicTimer = (float)0;
								this.StopAiming();
							}
							this.CinematicTimer += (float)1;
						}
					}
					else
					{
						this.CinematicTimer = (float)0;
					}
				}
				if (this.Gloved)
				{
					if (this.InputDevice.Type == 1)
					{
						if (Input.GetAxis("DpadY") < -0.5f)
						{
							this.GloveTimer += Time.deltaTime;
							if (this.GloveTimer > 0.5f)
							{
								this.Character.animation.CrossFade("f02_removeGloves_00");
								this.Degloving = true;
								this.CanMove = false;
							}
						}
						else
						{
							this.GloveTimer = (float)0;
						}
					}
					else if (Input.GetKey("1"))
					{
						this.GloveTimer += Time.deltaTime;
						if (this.GloveTimer > 0.1f)
						{
							this.Character.animation.CrossFade("f02_removeGloves_00");
							this.Degloving = true;
							this.CanMove = false;
						}
					}
					else
					{
						this.GloveTimer = (float)0;
					}
				}
				if (this.Weapon[1] != null && this.DropTimer[2] == (float)0)
				{
					if (this.InputDevice.Type == 1)
					{
						if (Input.GetAxis("DpadX") < -0.5f)
						{
							this.DropWeapon(1);
						}
						else
						{
							this.DropTimer[1] = (float)0;
						}
					}
					else if (Input.GetKey("2"))
					{
						this.DropWeapon(1);
					}
					else
					{
						this.DropTimer[1] = (float)0;
					}
				}
				if (this.Weapon[2] != null && this.DropTimer[1] == (float)0)
				{
					if (this.InputDevice.Type == 1)
					{
						if (Input.GetAxis("DpadX") > 0.5f)
						{
							this.DropWeapon(2);
						}
						else
						{
							this.DropTimer[2] = (float)0;
						}
					}
					else if (Input.GetKey("3"))
					{
						this.DropWeapon(2);
					}
					else
					{
						this.DropTimer[2] = (float)0;
					}
				}
				if (Input.GetButtonDown("LS") || Input.GetKeyDown("t"))
				{
					if (this.NewTrail != null)
					{
						UnityEngine.Object.Destroy(this.NewTrail);
					}
					this.NewTrail = (GameObject)UnityEngine.Object.Instantiate(this.Trail, this.transform.position + Vector3.fwd * 0.5f + Vector3.up * 0.1f, Quaternion.identity);
					((AIPath)this.NewTrail.GetComponent(typeof(AIPath))).target = this.Homeroom;
				}
			}
			else
			{
				if (this.Dumping)
				{
					this.targetRotation = Quaternion.LookRotation(this.Incinerator.transform.position - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
					this.MoveTowardsTarget(this.Incinerator.transform.position + Vector3.right * (float)-2);
					if (this.DumpTimer == (float)0 && this.Carrying)
					{
						this.Character.animation["f02_carryDisposeA_00"].time = 2.5f;
					}
					this.DumpTimer += Time.deltaTime;
					if (this.DumpTimer > (float)1)
					{
						if (!((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).Dumped)
						{
							this.DumpRagdoll(1);
						}
						this.Character.animation.CrossFade("f02_carryDisposeA_00");
						if (this.Character.animation["f02_carryDisposeA_00"].time >= this.Character.animation["f02_carryDisposeA_00"].length)
						{
							this.Incinerator.Prompt.enabled = true;
							this.Incinerator.Ready = true;
							this.Incinerator.Open = false;
							this.Dragging = false;
							this.Dumping = false;
							this.CanMove = true;
							this.Ragdoll = null;
							this.StopCarrying();
							this.DumpTimer = (float)0;
						}
					}
				}
				if (this.Chipping)
				{
					this.targetRotation = Quaternion.LookRotation(this.WoodChipper.gameObject.transform.position - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
					this.MoveTowardsTarget(this.WoodChipper.DumpPoint.position);
					if (this.DumpTimer == (float)0 && this.Carrying)
					{
						this.Character.animation["f02_carryDisposeA_00"].time = 2.5f;
					}
					this.DumpTimer += Time.deltaTime;
					if (this.DumpTimer > (float)1)
					{
						if (!((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).Dumped)
						{
							this.DumpRagdoll(3);
						}
						this.Character.animation.CrossFade("f02_carryDisposeA_00");
						if (this.Character.animation["f02_carryDisposeA_00"].time >= this.Character.animation["f02_carryDisposeA_00"].length)
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
							this.DumpTimer = (float)0;
						}
					}
				}
				if (this.Dipping)
				{
					if (this.Bucket != null)
					{
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Bucket.transform.position.x, this.transform.position.y, this.Bucket.transform.position.z) - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
					}
					this.Character.animation.CrossFade("f02_dipping_00");
					if (this.Character.animation["f02_dipping_00"].time >= this.Character.animation["f02_dipping_00"].length * 0.5f && this.Mop.Bloodiness > (float)0)
					{
						if (this.Bucket != null)
						{
							this.Bucket.Bloodiness = this.Bucket.Bloodiness + this.Mop.Bloodiness / (float)2;
						}
						this.Mop.Bloodiness = (float)0;
						this.Mop.UpdateBlood();
					}
					if (this.Character.animation["f02_dipping_00"].time >= this.Character.animation["f02_dipping_00"].length)
					{
						this.Character.animation["f02_dipping_00"].time = (float)0;
						this.Mop.Prompt.enabled = true;
						this.Dipping = false;
						this.CanMove = true;
					}
				}
				if (this.Pouring)
				{
					this.MoveTowardsTarget(this.Stool.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Stool.rotation, (float)10 * Time.deltaTime);
					this.Character.animation.CrossFade("f02_bucketDump" + this.PourHeight + "_00", (float)0);
					if (this.Character.animation["f02_bucketDump" + this.PourHeight + "_00"].time >= this.PourTime && !this.PickUp.Bucket.Poured)
					{
						if (this.PickUp.Bucket.Bloodiness < (float)50)
						{
							this.PickUp.Bucket.PourEffect.startColor = new Color((float)0, (float)1, (float)1, 0.5f);
							UnityEngine.Object.Instantiate(this.PickUp.Bucket.WaterCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * this.transform.forward, Quaternion.identity);
						}
						else
						{
							this.PickUp.Bucket.PourEffect.startColor = new Color(0.5f, (float)0, (float)0, 0.5f);
							UnityEngine.Object.Instantiate(this.PickUp.Bucket.BloodCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * this.transform.forward, Quaternion.identity);
						}
						this.PickUp.Bucket.PourEffect.Play();
						this.PickUp.Bucket.Poured = true;
						this.PickUp.Bucket.Empty();
					}
					if (this.Character.animation["f02_bucketDump" + this.PourHeight + "_00"].time >= this.Character.animation["f02_bucketDump" + this.PourHeight + "_00"].length)
					{
						this.Character.animation["f02_bucketDump" + this.PourHeight + "_00"].time = (float)0;
						this.PickUp.Bucket.Poured = false;
						this.Pouring = false;
						this.CanMove = true;
					}
				}
				if (this.Laughing)
				{
					if (this.Hairstyles[14].active)
					{
						this.LaughAnim = "storepower_20";
						this.LaughClip = this.ChargeUp;
					}
					if (this.CirnoHair.active)
					{
						float axis3 = Input.GetAxis("Vertical");
						float axis4 = Input.GetAxis("Horizontal");
						Vector3 a3 = this.MainCamera.transform.TransformDirection(Vector3.forward);
						a3.y = (float)0;
						a3 = a3.normalized;
						Vector3 a4 = new Vector3(a3.z, (float)0, -a3.x);
						Vector3 vector3 = axis4 * a4 + axis3 * a3;
						if (vector3 != Vector3.zero)
						{
							this.targetRotation = Quaternion.LookRotation(vector3);
							this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
						}
						this.LaughAnim = "f02_cirnoAttack_00";
						this.CirnoTimer -= Time.deltaTime;
						if (this.CirnoTimer < (float)0)
						{
							GameObject gameObject3 = (GameObject)UnityEngine.Object.Instantiate(this.CirnoIceAttack, this.transform.position + this.transform.up * 1.4f, this.transform.rotation);
							gameObject3.transform.localEulerAngles = gameObject3.transform.localEulerAngles + new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
							this.audio.PlayOneShot(this.CirnoIceClip);
							this.CirnoTimer = 0.1f;
						}
					}
					else if (this.audio.clip != this.LaughClip)
					{
						this.audio.clip = this.LaughClip;
						this.audio.time = (float)0;
						this.audio.Play();
					}
					this.Character.animation.CrossFade(this.LaughAnim);
					if (Input.GetButtonDown("RB"))
					{
						this.LaughIntensity += (float)1;
						if (this.LaughIntensity <= (float)5)
						{
							this.LaughAnim = "f02_laugh_01";
							this.LaughClip = this.Laugh1;
							this.LaughTimer = 0.5f;
						}
						else if (this.LaughIntensity <= (float)10)
						{
							this.LaughAnim = "f02_laugh_02";
							this.LaughClip = this.Laugh2;
							this.LaughTimer = (float)1;
						}
						else if (this.LaughIntensity <= (float)15)
						{
							this.LaughAnim = "f02_laugh_03";
							this.LaughClip = this.Laugh3;
							this.LaughTimer = 1.5f;
						}
						else if (this.LaughIntensity <= (float)20)
						{
							GameObject gameObject4 = (GameObject)UnityEngine.Object.Instantiate(this.AlarmDisc, this.transform.position + Vector3.up, Quaternion.identity);
							((AlarmDiscScript)gameObject4.GetComponent(typeof(AlarmDiscScript))).NoScream = true;
							this.LaughAnim = "f02_laugh_04";
							this.LaughClip = this.Laugh4;
							this.LaughTimer = (float)2;
						}
						else
						{
							GameObject gameObject4 = (GameObject)UnityEngine.Object.Instantiate(this.AlarmDisc, this.transform.position + Vector3.up, Quaternion.identity);
							((AlarmDiscScript)gameObject4.GetComponent(typeof(AlarmDiscScript))).NoScream = true;
							this.LaughAnim = "f02_laugh_04";
							this.LaughIntensity = (float)20;
							this.LaughTimer = (float)2;
						}
					}
					if (this.LaughIntensity > (float)15)
					{
						this.Sanity += Time.deltaTime * (float)10;
						this.UpdateSanity();
					}
					this.LaughTimer -= Time.deltaTime;
					if (this.LaughTimer <= (float)0)
					{
						this.StopLaughing();
					}
				}
				if (this.TimeSkipping)
				{
					float timeSkipHeight = this.TimeSkipHeight;
					Vector3 position = this.transform.position;
					float num3 = position.y = timeSkipHeight;
					Vector3 vector4 = this.transform.position = position;
					this.Character.animation.CrossFade("f02_timeSkip_00");
					this.MyController.Move(this.transform.up * 0.0001f);
					this.Sanity += Time.deltaTime * 0.17f;
					this.UpdateSanity();
				}
				if (this.DumpsterGrabbing)
				{
					if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("DpadX") > 0.5f)
					{
						if (this.DumpsterHandle.Direction == (float)-1)
						{
							this.Character.animation.CrossFade("f02_dumpsterPull_00");
						}
						else
						{
							this.Character.animation.CrossFade("f02_dumpsterPush_00");
						}
					}
					else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") < -0.5f)
					{
						if (this.DumpsterHandle.Direction == (float)-1)
						{
							this.Character.animation.CrossFade("f02_dumpsterPush_00");
						}
						else
						{
							this.Character.animation.CrossFade("f02_dumpsterPull_00");
						}
					}
					else
					{
						this.Character.animation.CrossFade("f02_dumpsterGrab_00");
					}
				}
				if (this.Stripping && this.Character.animation["f02_stripping_00"].time >= this.Character.animation["f02_stripping_00"].length)
				{
					this.Stripping = false;
					this.CanMove = true;
					this.MyLocker.UpdateSchoolwear();
				}
				if (this.Bathing)
				{
					this.MoveTowardsTarget(this.Stool.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Stool.rotation, (float)10 * Time.deltaTime);
					this.Character.animation.CrossFade("f02_stoolBathing_00");
					if (this.Character.animation["f02_stoolBathing_00"].time >= this.Character.animation["f02_stoolBathing_00"].length)
					{
						this.Bloodiness = (float)0;
						this.UpdateBlood();
						this.Bathing = false;
						this.CanMove = true;
					}
				}
				if (this.Degloving)
				{
					this.Character.animation.CrossFade("f02_removeGloves_00");
					if (this.Character.animation["f02_removeGloves_00"].time >= this.Character.animation["f02_removeGloves_00"].length)
					{
						this.Gloves.transform.parent = null;
						this.Gloves.active = true;
						this.Degloving = false;
						this.CanMove = true;
						this.Gloved = false;
						this.Gloves = null;
						this.SetUniform();
					}
					else if (this.InputDevice.Type == 1)
					{
						if (Input.GetAxis("DpadY") > -0.5f)
						{
							this.Degloving = false;
							this.CanMove = true;
							this.GloveTimer = (float)0;
						}
					}
					else if (Input.GetKeyUp("1"))
					{
						this.Degloving = false;
						this.CanMove = true;
						this.GloveTimer = (float)0;
					}
				}
				if (this.Struggling)
				{
					if (!this.Won && !this.Lost)
					{
						this.Character.animation.CrossFade("f02_struggleA_00");
						this.targetRotation = Quaternion.LookRotation(this.TargetStudent.transform.position - this.transform.position);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
					}
					else if (this.Won)
					{
						this.Character.animation.CrossFade("f02_struggleWinA_00");
						if (!this.PlayedSound && this.Character.animation["f02_struggleWinA_00"].time > 0.9f)
						{
							AudioSource.PlayClipAtPoint(this.Stabs[UnityEngine.Random.Range(0, Extensions.get_length(this.Stabs))], this.transform.position + Vector3.up);
							this.Bloodiness += (float)20;
							this.UpdateBlood();
							this.Sanity -= (float)20 * this.Numbness;
							this.UpdateSanity();
							this.StainWeapon();
							this.PlayedSound = true;
						}
						if (this.Character.animation["f02_struggleWinA_00"].time > this.Character.animation["f02_struggleWinA_00"].length)
						{
							this.ShoulderCamera.Struggle = false;
							this.PlayedSound = false;
							this.Struggling = false;
						}
					}
					else if (this.Lost)
					{
						this.Character.animation.CrossFade("f02_struggleLoseA_00");
					}
				}
				if (this.ClubActivity && PlayerPrefs.GetInt("Club") == 6)
				{
					this.Character.animation.Play("f02_kick_23");
					if (this.Character.animation["f02_kick_23"].time >= this.Character.animation["f02_kick_23"].length)
					{
						this.Character.animation["f02_kick_23"].time = (float)0;
					}
				}
				if (this.Possessed)
				{
					this.Character.animation.CrossFade("f02_possessionPose_00");
				}
				if (this.Punching)
				{
					if (this.FalconHelmet.active)
					{
						if (this.Character.animation["f02_falconPunch_00"].time >= (float)1 && this.Character.animation["f02_falconPunch_00"].time <= 1.25f)
						{
							this.FalconSpeed = Mathf.MoveTowards(this.FalconSpeed, 2.5f, Time.deltaTime * 2.5f);
						}
						else if (this.Character.animation["f02_falconPunch_00"].time >= 1.25f && this.Character.animation["f02_falconPunch_00"].time <= 1.5f)
						{
							this.FalconSpeed = Mathf.MoveTowards(this.FalconSpeed, (float)0, Time.deltaTime * 2.5f);
						}
						if (this.Character.animation["f02_falconPunch_00"].time >= (float)1 && this.Character.animation["f02_falconPunch_00"].time <= 1.5f)
						{
							if (this.NewFalconPunch == null)
							{
								this.NewFalconPunch = (GameObject)UnityEngine.Object.Instantiate(this.FalconPunch);
								this.NewFalconPunch.transform.parent = this.ItemParent;
								this.NewFalconPunch.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
							}
							this.MyController.Move(this.transform.forward * this.FalconSpeed);
						}
						if (this.Character.animation["f02_falconPunch_00"].time >= this.Character.animation["f02_falconPunch_00"].length)
						{
							this.NewFalconPunch = null;
							this.Punching = false;
							this.CanMove = true;
						}
					}
					else
					{
						if (this.Character.animation["f02_punch_21"].time >= 0.15f && this.Character.animation["f02_punch_21"].time <= 0.2f && this.NewOnePunch == null)
						{
							this.NewOnePunch = (GameObject)UnityEngine.Object.Instantiate(this.OnePunch);
							this.NewOnePunch.transform.parent = this.ItemParent;
							this.NewOnePunch.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
						}
						if (this.Character.animation["f02_punch_21"].time >= this.Character.animation["f02_punch_21"].length - 0.1f)
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
						this.Character.animation.CrossFade("f02_sansUp_00");
						this.RagdollPK.transform.localPosition = new Vector3((float)0, (float)3, (float)2);
						if (this.PKDir != 1)
						{
							AudioSource.PlayClipAtPoint(this.Slam, this.transform.position + Vector3.up);
						}
						this.PKDir = 1;
					}
					else if (Input.GetAxis("Vertical") < -0.5f)
					{
						this.Character.animation.CrossFade("f02_sansDown_00");
						this.RagdollPK.transform.localPosition = new Vector3((float)0, (float)0, (float)2);
						if (this.PKDir != 2)
						{
							AudioSource.PlayClipAtPoint(this.Slam, this.transform.position + Vector3.up);
						}
						this.PKDir = 2;
					}
					else if (Input.GetAxis("Horizontal") > 0.5f)
					{
						this.Character.animation.CrossFade("f02_sansRight_00");
						this.RagdollPK.transform.localPosition = new Vector3(1.5f, 1.5f, (float)2);
						if (this.PKDir != 3)
						{
							AudioSource.PlayClipAtPoint(this.Slam, this.transform.position + Vector3.up);
						}
						this.PKDir = 3;
					}
					else if (Input.GetAxis("Horizontal") < -0.5f)
					{
						this.Character.animation.CrossFade("f02_sansLeft_00");
						this.RagdollPK.transform.localPosition = new Vector3(-1.5f, 1.5f, (float)2);
						if (this.PKDir != 4)
						{
							AudioSource.PlayClipAtPoint(this.Slam, this.transform.position + Vector3.up);
						}
						this.PKDir = 4;
					}
					else
					{
						this.Character.animation.CrossFade("f02_sansHold_00");
						this.RagdollPK.transform.localPosition = new Vector3((float)0, 1.5f, (float)2);
						this.PKDir = 0;
					}
					if (Input.GetButtonDown("B"))
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = false;
						((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).StopDragging();
						this.SansEyes[0].active = false;
						this.SansEyes[1].active = false;
						this.GlowEffect.Stop();
						this.CanMove = true;
						this.PK = false;
					}
				}
				if (this.SummonBones)
				{
					this.Character.animation.CrossFade("f02_sansBones_00");
					if (this.BoneTimer == (float)0)
					{
						UnityEngine.Object.Instantiate(this.Bone, this.transform.position + this.transform.right * UnityEngine.Random.Range(-2.5f, 2.5f) + this.transform.up * (float)-2 + this.transform.forward * UnityEngine.Random.Range(1f, 6f), Quaternion.identity);
					}
					this.BoneTimer += Time.deltaTime;
					if (this.BoneTimer > 0.1f)
					{
						this.BoneTimer = (float)0;
					}
					if (Input.GetButtonUp("RB"))
					{
						this.SansEyes[0].active = false;
						this.SansEyes[1].active = false;
						this.GlowEffect.Stop();
						this.SummonBones = false;
						this.CanMove = true;
					}
				}
				if (this.Blasting && this.Character.animation["f02_sansBlaster_00"].time >= this.Character.animation["f02_sansBlaster_00"].length - 0.25f)
				{
					this.SansEyes[0].active = false;
					this.SansEyes[1].active = false;
					this.GlowEffect.Stop();
					this.Blasting = false;
					this.CanMove = true;
				}
				if (this.Lifting && this.Character.animation["f02_carryLiftA_00"].time >= this.Character.animation["f02_carryLiftA_00"].length)
				{
					this.IdleAnim = this.CarryIdleAnim;
					this.WalkAnim = this.CarryWalkAnim;
					this.RunAnim = this.CarryRunAnim;
					this.CanMove = true;
					this.Carrying = true;
					this.Lifting = false;
				}
				if (this.Dropping)
				{
					this.targetRotation = Quaternion.LookRotation(this.DropSpot.position + this.DropSpot.forward - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
					this.MoveTowardsTarget(this.DropSpot.position);
					if (this.DumpTimer == (float)0 && this.Carrying)
					{
						((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).Character.animation[((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).DumpedAnim].time = 2.5f;
						this.Character.animation["f02_carryDisposeA_00"].time = 2.5f;
					}
					this.DumpTimer += Time.deltaTime;
					if (this.DumpTimer > (float)1)
					{
						if (this.Ragdoll != null)
						{
							int num4 = 0;
							Vector3 localEulerAngles2 = ((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).PelvisRoot.localEulerAngles;
							float num5 = localEulerAngles2.y = (float)num4;
							Vector3 vector5 = ((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).PelvisRoot.localEulerAngles = localEulerAngles2;
							int num6 = 0;
							Vector3 localPosition = ((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).PelvisRoot.localPosition;
							float num7 = localPosition.z = (float)num6;
							Vector3 vector6 = ((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).PelvisRoot.localPosition = localPosition;
						}
						this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(this.Hips.position.x, this.transform.position.y + (float)1, this.Hips.position.z), Time.deltaTime * (float)10);
						if (this.Character.animation["f02_carryDisposeA_00"].time >= 4.5f)
						{
							this.StopCarrying();
						}
						else
						{
							if (((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).StopAnimation)
							{
								((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).StopAnimation = false;
								this.ID = 0;
								while (this.ID < ((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).AllRigidbodies.Length)
								{
									((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).AllRigidbodies[this.ID].isKinematic = true;
									this.ID++;
								}
							}
							this.Character.animation.CrossFade("f02_carryDisposeA_00");
							((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).Character.animation.CrossFade(((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).DumpedAnim);
							this.Ragdoll.transform.position = this.transform.position;
							this.Ragdoll.transform.eulerAngles = this.transform.eulerAngles;
						}
						if (this.Character.animation["f02_carryDisposeA_00"].time >= this.Character.animation["f02_carryDisposeA_00"].length)
						{
							this.CameraTarget.localPosition = new Vector3((float)0, (float)1, (float)0);
							this.Dropping = false;
							this.CanMove = true;
							this.DumpTimer = (float)0;
						}
					}
				}
				if (this.Dismembering && this.Character.animation["f02_dismember_00"].time >= this.Character.animation["f02_dismember_00"].length)
				{
					((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).Dismember();
					this.RPGCamera.enabled = true;
					this.TargetStudent = null;
					this.Dismembering = false;
					this.CanMove = true;
				}
				if (this.Shoved)
				{
					if (this.Character.animation["f02_shoveA_00"].time >= this.Character.animation["f02_shoveA_00"].length)
					{
						float x = this.Hips.transform.position.x;
						Vector3 position2 = this.transform.position;
						float num8 = position2.x = x;
						Vector3 vector7 = this.transform.position = position2;
						float z = this.Hips.transform.position.z;
						Vector3 position3 = this.transform.position;
						float num9 = position3.z = z;
						Vector3 vector8 = this.transform.position = position3;
						this.CameraTarget.localPosition = new Vector3((float)0, (float)1, (float)0);
						this.Character.animation.Play(this.IdleAnim);
						this.Shoved = false;
						this.CanMove = true;
					}
					else
					{
						this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(this.Hips.position.x, this.transform.position.y + (float)1, this.Hips.position.z), Time.deltaTime * (float)10);
					}
				}
				if (this.Attacked && this.Character.animation["f02_swingB_00"].time >= this.Character.animation["f02_swingB_00"].length)
				{
					this.ShoulderCamera.HeartbrokenCamera.active = true;
				}
				if (this.Hiding)
				{
					if (!this.Exiting)
					{
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.HidingSpot.rotation, Time.deltaTime * (float)10);
						this.MoveTowardsTarget(this.HidingSpot.position);
						this.Character.animation.CrossFade("f02_hiding_00");
					}
					else
					{
						this.MoveTowardsTarget(this.ExitSpot.position);
						this.Character.animation.CrossFade(this.IdleAnim);
						if (Vector3.Distance(this.transform.position, this.ExitSpot.position) < 0.1f)
						{
							float y3 = 0.825f;
							Vector3 center = this.MyController.center;
							float num10 = center.y = y3;
							Vector3 vector9 = this.MyController.center = center;
							this.MyController.height = 1.45f;
							this.Exiting = false;
							this.CanMove = true;
							this.Hiding = false;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
						this.Exiting = true;
					}
				}
			}
			if (!this.Laughing)
			{
				this.audio.volume = this.audio.volume - Time.deltaTime * (float)2;
			}
			if (!this.Mopping)
			{
				this.Character.animation["f02_mopping_00"].weight = Mathf.Lerp(this.Character.animation["f02_mopping_00"].weight, (float)0, Time.deltaTime * (float)10);
			}
			else
			{
				this.Character.animation["f02_mopping_00"].weight = Mathf.Lerp(this.Character.animation["f02_mopping_00"].weight, (float)1, Time.deltaTime * (float)10);
				if (Input.GetButtonUp("A") || Input.GetKeyDown("escape"))
				{
					this.Mopping = false;
				}
			}
			if (this.LaughIntensity < (float)10)
			{
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.CarryAnims))
				{
					if (this.PickUp != null && this.CarryAnimID == this.ID && !this.Mopping && !this.Dipping && !this.Pouring)
					{
						this.Character.animation[this.CarryAnims[this.ID]].weight = Mathf.Lerp(this.Character.animation[this.CarryAnims[this.ID]].weight, (float)1, Time.deltaTime * (float)10);
					}
					else
					{
						this.Character.animation[this.CarryAnims[this.ID]].weight = Mathf.Lerp(this.Character.animation[this.CarryAnims[this.ID]].weight, (float)0, Time.deltaTime * (float)10);
					}
					this.ID++;
				}
			}
			else if (this.Armed)
			{
				this.Character.animation["f02_mopCarry_00"].weight = Mathf.Lerp(this.Character.animation["f02_mopCarry_00"].weight, (float)1, Time.deltaTime * (float)10);
			}
			if (this.Noticed && !this.Attacking)
			{
				if (!this.Collapse)
				{
					this.Character.animation.CrossFade("f02_scaredIdle_00");
					this.targetRotation = Quaternion.LookRotation(this.Senpai.position - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
					int num11 = 0;
					Vector3 localEulerAngles3 = this.transform.localEulerAngles;
					float num12 = localEulerAngles3.x = (float)num11;
					Vector3 vector10 = this.transform.localEulerAngles = localEulerAngles3;
				}
				else if (this.Character.animation["f02_down_22"].time >= this.Character.animation["f02_down_22"].length)
				{
					this.Character.animation.CrossFade("f02_down_23");
				}
			}
			if (!this.Attacking && !this.Lost)
			{
				if (Vector3.Distance(this.transform.position, this.Senpai.position) < (float)2)
				{
					if (!this.Talking)
					{
						if (!this.NearSenpai)
						{
							this.DepthOfField.focalSize = (float)150;
							this.NearSenpai = true;
						}
						if (this.Laughing)
						{
							this.StopLaughing();
						}
						this.Obscurance.enabled = false;
						this.YandereVision = false;
						this.Crouching = false;
						this.Crawling = false;
						this.Mopping = false;
						this.YandereTimer = (float)0;
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
				this.DepthOfField.focalSize = Mathf.Lerp(this.DepthOfField.focalSize, (float)0, Time.deltaTime * (float)10);
				this.DepthOfField.focalZStartCurve = Mathf.Lerp(this.DepthOfField.focalZStartCurve, (float)20, Time.deltaTime * (float)10);
				this.DepthOfField.focalZEndCurve = Mathf.Lerp(this.DepthOfField.focalZEndCurve, (float)20, Time.deltaTime * (float)10);
				this.DepthOfField.objectFocus = this.Senpai.transform;
				this.ColorCorrection.enabled = true;
				this.SenpaiFade = Mathf.Lerp(this.SenpaiFade, (float)0, Time.deltaTime * (float)10);
				this.SenpaiTint = (float)1 - this.SenpaiFade / (float)100;
				this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.SenpaiTint * 0.5f));
				this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f - this.SenpaiTint * 0.5f));
				this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.SenpaiTint * 0.5f));
				this.ColorCorrection.redChannel.SmoothTangents(1, (float)0);
				this.ColorCorrection.greenChannel.SmoothTangents(1, (float)0);
				this.ColorCorrection.blueChannel.SmoothTangents(1, (float)0);
				this.ColorCorrection.UpdateTextures();
				if (!this.Attacking)
				{
					this.Character.animation["f02_shy_00"].weight = this.SenpaiTint;
				}
				this.HeartBeat.volume = this.SenpaiTint;
				this.Sanity += Time.deltaTime * (float)10;
				this.UpdateSanity();
			}
			else if (this.SenpaiFade < (float)99)
			{
				this.DepthOfField.focalSize = Mathf.Lerp(this.DepthOfField.focalSize, (float)150, Time.deltaTime * (float)10);
				this.DepthOfField.focalZStartCurve = Mathf.Lerp(this.DepthOfField.focalZStartCurve, (float)0, Time.deltaTime * (float)10);
				this.DepthOfField.focalZEndCurve = Mathf.Lerp(this.DepthOfField.focalZEndCurve, (float)0, Time.deltaTime * (float)10);
				this.SenpaiFade = Mathf.Lerp(this.SenpaiFade, (float)100, Time.deltaTime * (float)10);
				this.SenpaiTint = this.SenpaiFade / (float)100;
				this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, (float)1 - this.SenpaiTint * 0.5f));
				this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, this.SenpaiTint * 0.5f));
				this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, (float)1 - this.SenpaiTint * 0.5f));
				this.ColorCorrection.redChannel.SmoothTangents(1, (float)0);
				this.ColorCorrection.greenChannel.SmoothTangents(1, (float)0);
				this.ColorCorrection.blueChannel.SmoothTangents(1, (float)0);
				this.ColorCorrection.UpdateTextures();
				this.Character.animation["f02_shy_00"].weight = (float)1 - this.SenpaiTint;
				this.HeartBeat.volume = (float)1 - this.SenpaiTint;
			}
			else if (this.SenpaiFade < (float)100)
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
				Time.timeScale = Mathf.Lerp(Time.timeScale, 0.5f, 0.166666672f);
				this.YandereFade = Mathf.Lerp(this.YandereFade, (float)0, Time.deltaTime * (float)10);
				this.YandereTint = (float)1 - this.YandereFade / (float)100;
				this.YandereColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f - this.YandereTint * 0.25f));
				this.YandereColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f - this.YandereTint * 0.25f));
				this.YandereColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.YandereTint * 0.25f));
				this.YandereColorCorrection.redChannel.SmoothTangents(1, (float)0);
				this.YandereColorCorrection.greenChannel.SmoothTangents(1, (float)0);
				this.YandereColorCorrection.blueChannel.SmoothTangents(1, (float)0);
				this.YandereColorCorrection.UpdateTextures();
				this.Vignette.intensity = Mathf.Lerp(this.Vignette.intensity, this.YandereTint * (float)5, Time.deltaTime * (float)10);
				this.Vignette.blur = Mathf.Lerp(this.Vignette.blur, this.YandereTint, Time.deltaTime * (float)10);
				this.Vignette.chromaticAberration = Mathf.Lerp(this.Vignette.chromaticAberration, this.YandereTint * (float)5, Time.deltaTime * (float)10);
			}
			else
			{
				if (this.HighlightingR.enabled)
				{
					this.HighlightingR.enabled = false;
					this.HighlightingB.enabled = false;
				}
				if (this.YandereFade < (float)99)
				{
					if (!this.Aiming)
					{
						Time.timeScale = Mathf.Lerp(Time.timeScale, (float)1, 0.166666672f);
					}
					this.YandereFade = Mathf.Lerp(this.YandereFade, (float)100, Time.deltaTime * (float)10);
					this.YandereTint = this.YandereFade / (float)100;
					this.YandereColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, this.YandereTint * 0.5f));
					this.YandereColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, this.YandereTint * 0.5f));
					this.YandereColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, (float)1 - this.YandereTint * 0.5f));
					this.YandereColorCorrection.redChannel.SmoothTangents(1, (float)0);
					this.YandereColorCorrection.greenChannel.SmoothTangents(1, (float)0);
					this.YandereColorCorrection.blueChannel.SmoothTangents(1, (float)0);
					this.YandereColorCorrection.UpdateTextures();
					this.Vignette.intensity = Mathf.Lerp(this.Vignette.intensity, (float)0, Time.deltaTime * (float)10);
					this.Vignette.blur = Mathf.Lerp(this.Vignette.blur, (float)0, Time.deltaTime * (float)10);
					this.Vignette.chromaticAberration = Mathf.Lerp(this.Vignette.chromaticAberration, (float)0, Time.deltaTime * (float)10);
				}
				else if (this.YandereFade < (float)100)
				{
					this.ResetYandereEffects();
				}
			}
			float a5 = (float)1 - this.YandereFade / (float)100;
			Color color = this.RightRedEye.material.color;
			float num13 = color.a = a5;
			Color color2 = this.RightRedEye.material.color = color;
			float a6 = (float)1 - this.YandereFade / (float)100;
			Color color3 = this.LeftRedEye.material.color;
			float num14 = color3.a = a6;
			Color color4 = this.LeftRedEye.material.color = color3;
			float g = this.YandereFade / (float)100;
			Color color5 = this.RightYandereEye.material.color;
			float num15 = color5.g = g;
			Color color6 = this.RightYandereEye.material.color = color5;
			float b = this.YandereFade / (float)100;
			Color color7 = this.RightYandereEye.material.color;
			float num16 = color7.b = b;
			Color color8 = this.RightYandereEye.material.color = color7;
			float g2 = this.YandereFade / (float)100;
			Color color9 = this.LeftYandereEye.material.color;
			float num17 = color9.g = g2;
			Color color10 = this.LeftYandereEye.material.color = color9;
			float b2 = this.YandereFade / (float)100;
			Color color11 = this.LeftYandereEye.material.color;
			float num18 = color11.b = b2;
			Color color12 = this.LeftYandereEye.material.color = color11;
			if (this.Armed)
			{
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.ArmedAnims))
				{
					if (this.Weapon[this.Equipped].AnimID == this.ID)
					{
						this.Character.animation[this.ArmedAnims[this.ID]].weight = Mathf.Lerp(this.Character.animation[this.ArmedAnims[this.ID]].weight, (float)1, Time.deltaTime * (float)10);
					}
					else
					{
						this.Character.animation[this.ArmedAnims[this.ID]].weight = Mathf.Lerp(this.Character.animation[this.ArmedAnims[this.ID]].weight, (float)0, Time.deltaTime * (float)10);
					}
					if (this.Attacking && this.ID == 2)
					{
						this.Character.animation[this.ArmedAnims[2]].weight = (float)0;
					}
					this.ID++;
				}
			}
			else
			{
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.ArmedAnims))
				{
					this.Character.animation[this.ArmedAnims[this.ID]].weight = Mathf.Lerp(this.Character.animation[this.ArmedAnims[this.ID]].weight, (float)0, Time.deltaTime * (float)10);
					this.ID++;
				}
			}
			if (this.Talking)
			{
				if (this.TargetStudent != null)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
				}
				if (this.Interaction == 0)
				{
					this.Character.animation.CrossFade(this.IdleAnim);
				}
				else if (this.Interaction == 1)
				{
					if (this.TalkTimer == (float)3)
					{
						this.Character.animation.CrossFade("f02_greet_00");
						if (this.TargetStudent.Witnessed == "Insanity" || this.TargetStudent.Witnessed == "Weapon and Blood and Insanity" || this.TargetStudent.Witnessed == "Weapon and Insanity" || this.TargetStudent.Witnessed == "Blood and Insanity")
						{
							this.Subtitle.UpdateLabel("Insanity Apology", 0, (float)3);
						}
						else if (this.TargetStudent.Witnessed == "Weapon and Blood")
						{
							this.Subtitle.UpdateLabel("Weapon and Blood Apology", 0, (float)3);
						}
						else if (this.TargetStudent.Witnessed == "Weapon")
						{
							this.Subtitle.UpdateLabel("Weapon Apology", 0, (float)3);
						}
						else if (this.TargetStudent.Witnessed == "Blood")
						{
							this.Subtitle.UpdateLabel("Blood Apology", 0, (float)3);
						}
						else if (this.TargetStudent.Witnessed == "Lewd")
						{
							this.Subtitle.UpdateLabel("Lewd Apology", 0, (float)3);
						}
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = (float)0;
						}
						if (this.Character.animation["f02_greet_00"].time >= this.Character.animation["f02_greet_00"].length)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= (float)0)
						{
							this.TargetStudent.Interaction = 1;
							this.TargetStudent.TalkTimer = (float)3;
							this.Interaction = 0;
						}
					}
					this.TalkTimer -= Time.deltaTime;
				}
				else if (this.Interaction == 2)
				{
					if (this.TalkTimer == (float)3)
					{
						this.Character.animation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel("Player Compliment", 0, (float)3);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = (float)0;
						}
						if (this.Character.animation["f02_greet_01"].time >= this.Character.animation["f02_greet_01"].length)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= (float)0)
						{
							this.TargetStudent.Interaction = 2;
							this.TargetStudent.TalkTimer = (float)3;
							this.Interaction = 0;
						}
					}
					this.TalkTimer -= Time.deltaTime;
				}
				else if (this.Interaction == 3)
				{
					if (this.TalkTimer == (float)3)
					{
						this.Character.animation.CrossFade("f02_lookdown_00");
						this.Subtitle.UpdateLabel("Player Gossip", 0, (float)3);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = (float)0;
						}
						if (this.Character.animation["f02_lookdown_00"].time >= this.Character.animation["f02_lookdown_00"].length)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= (float)0)
						{
							this.TargetStudent.Interaction = 3;
							this.TargetStudent.TalkTimer = (float)3;
							this.Interaction = 0;
						}
					}
					this.TalkTimer -= Time.deltaTime;
				}
				else if (this.Interaction == 4)
				{
					if (this.TalkTimer == (float)2)
					{
						this.Character.animation.CrossFade("f02_greet_00");
						this.Subtitle.UpdateLabel("Player Farewell", 0, (float)2);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = (float)0;
						}
						if (this.Character.animation["f02_greet_00"].time >= this.Character.animation["f02_greet_00"].length)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= (float)0)
						{
							this.TargetStudent.Interaction = 4;
							this.TargetStudent.TalkTimer = (float)2;
							this.Interaction = 0;
						}
					}
					this.TalkTimer -= Time.deltaTime;
				}
				else if (this.Interaction == 6)
				{
					if (this.TalkTimer == (float)3)
					{
						this.Character.animation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel("Player Follow", 0, (float)3);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = (float)0;
						}
						if (this.Character.animation["f02_greet_01"].time >= this.Character.animation["f02_greet_01"].length)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= (float)0)
						{
							this.TargetStudent.Interaction = 6;
							this.TargetStudent.TalkTimer = (float)2;
							this.Interaction = 0;
						}
					}
					this.TalkTimer -= Time.deltaTime;
				}
				else if (this.Interaction == 7)
				{
					if (this.TalkTimer == (float)3)
					{
						this.Character.animation.CrossFade("f02_lookdown_00");
						this.Subtitle.UpdateLabel("Player Leave", 0, (float)3);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = (float)0;
						}
						if (this.Character.animation["f02_lookdown_00"].time >= this.Character.animation["f02_lookdown_00"].length)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= (float)0)
						{
							this.TargetStudent.Interaction = 7;
							this.TargetStudent.TalkTimer = (float)3;
							this.Interaction = 0;
						}
					}
					this.TalkTimer -= Time.deltaTime;
				}
				else if (this.Interaction == 8)
				{
					if (this.TalkTimer == (float)3)
					{
						this.Character.animation.CrossFade("f02_lookdown_00");
						this.Subtitle.UpdateLabel("Player Distract", 0, (float)3);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = (float)0;
						}
						if (this.Character.animation["f02_lookdown_00"].time >= this.Character.animation["f02_lookdown_00"].length)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= (float)0)
						{
							this.TargetStudent.Interaction = 8;
							this.TargetStudent.TalkTimer = (float)3;
							this.Interaction = 0;
						}
					}
					this.TalkTimer -= Time.deltaTime;
				}
			}
			if (this.Attacking)
			{
				if (this.TargetStudent != null)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
				}
				if (this.Drown)
				{
					this.MoveTowardsTarget(this.TargetStudent.transform.position + this.TargetStudent.transform.forward * -0.0001f);
					this.Character.animation.CrossFade(this.DrownAnim);
					if (this.Character.animation[this.DrownAnim].time > this.Character.animation[this.DrownAnim].length)
					{
						this.TargetStudent.Dead = true;
						this.Attacking = false;
						this.CanMove = true;
						this.Drown = false;
						if (PlayerPrefs.GetInt("PantiesEquipped") == 10)
						{
							this.Sanity -= (float)10 * this.Numbness;
						}
						else
						{
							this.Sanity -= (float)20 * this.Numbness;
						}
					}
				}
				else if (this.RoofPush)
				{
					this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(this.Hips.position.x, this.transform.position.y + (float)1, this.Hips.position.z), Time.deltaTime * (float)10);
					this.MoveTowardsTarget(this.TargetStudent.transform.position + this.TargetStudent.transform.forward * (float)-1);
					this.Character.animation.CrossFade("f02_roofPushA_00");
					if (this.Character.animation["f02_roofPushA_00"].time > 4.33333349f)
					{
						if (this.Shoes[0].active)
						{
							GameObject gameObject5 = (GameObject)UnityEngine.Object.Instantiate(this.ShoePair, this.transform.position + new Vector3(-1.6f, 0.045f, (float)0), Quaternion.identity);
							int num19 = -90;
							Vector3 eulerAngles2 = gameObject5.transform.eulerAngles;
							float num20 = eulerAngles2.y = (float)num19;
							Vector3 vector11 = gameObject5.transform.eulerAngles = eulerAngles2;
							this.Shoes[0].active = false;
							this.Shoes[1].active = false;
						}
					}
					else if (this.Character.animation["f02_roofPushA_00"].time > 2.16666675f && !this.Shoes[0].active)
					{
						this.TargetStudent.RemoveShoes();
						this.Shoes[0].active = true;
						this.Shoes[1].active = true;
					}
					if (this.Character.animation["f02_roofPushA_00"].time > this.Character.animation["f02_roofPushA_00"].length)
					{
						this.CameraTarget.localPosition = new Vector3((float)0, (float)1, (float)0);
						this.TargetStudent.Dead = true;
						this.Attacking = false;
						this.RoofPush = false;
						this.CanMove = true;
						this.Sanity -= (float)20 * this.Numbness;
					}
					if (Input.GetButtonDown("B"))
					{
						this.SplashCamera.Show = true;
						this.SplashCamera.MyCamera.enabled = true;
						this.SplashCamera.transform.position = new Vector3(-33.3f, 1.35f, 30.5f);
						this.SplashCamera.transform.eulerAngles = new Vector3((float)0, (float)135, (float)0);
					}
				}
				else if (!this.TargetStudent.Teacher)
				{
					if (this.Weapon[this.Equipped].WeaponID == 11)
					{
						this.Character.animation.CrossFade("CyborgNinja_Slash");
						if (this.Character.animation["CyborgNinja_Slash"].time == (float)0)
						{
							this.TargetStudent.Character.animation[this.TargetStudent.PhoneAnim].weight = (float)0;
							this.Weapon[this.Equipped].gameObject.audio.Play();
						}
						if (this.Character.animation["CyborgNinja_Slash"].time >= this.Character.animation["CyborgNinja_Slash"].length)
						{
							this.Bloodiness += (float)20;
							this.UpdateBlood();
							this.StainWeapon();
							this.Character.animation["CyborgNinja_Slash"].time = (float)0;
							this.Character.animation.Stop("CyborgNinja_Slash");
							this.Character.animation.CrossFade(this.IdleAnim);
							this.Attacking = false;
							if (!this.Noticed)
							{
								this.CanMove = true;
							}
							else
							{
								this.Weapon[this.Equipped].Drop();
							}
						}
					}
					else if (this.Weapon[this.Equipped].WeaponID == 7)
					{
						this.Character.animation.CrossFade("f02_buzzSawKill_A_00");
						if (this.Character.animation["f02_buzzSawKill_A_00"].time == (float)0)
						{
							this.TargetStudent.Character.animation[this.TargetStudent.PhoneAnim].weight = (float)0;
							this.Weapon[this.Equipped].gameObject.audio.Play();
						}
						if (this.AttackPhase == 1)
						{
							if (this.Character.animation["f02_buzzSawKill_A_00"].time > 0.33333f)
							{
								this.TargetStudent.LiquidProjector.enabled = true;
								this.Weapon[this.Equipped].Effect();
								this.StainWeapon();
								this.TargetStudent.LiquidProjector.material.mainTexture = this.BloodTextures[1];
								this.Bloodiness += (float)20;
								this.UpdateBlood();
								this.AttackPhase++;
							}
						}
						else if (this.AttackPhase < 6 && this.Character.animation["f02_buzzSawKill_A_00"].time > 0.33333f * (float)this.AttackPhase)
						{
							this.TargetStudent.LiquidProjector.material.mainTexture = this.BloodTextures[this.AttackPhase];
							this.Bloodiness += (float)20;
							this.UpdateBlood();
							this.AttackPhase++;
						}
						if (this.Character.animation["f02_buzzSawKill_A_00"].time > this.Character.animation["f02_buzzSawKill_A_00"].length)
						{
							if (this.TargetStudent == this.StudentManager.Reporter)
							{
								this.StudentManager.Reporter = null;
							}
							this.Character.animation["f02_buzzSawKill_A_00"].time = (float)0;
							this.Character.animation.Stop("f02_buzzSawKill_A_00");
							this.Character.animation.CrossFade(this.IdleAnim);
							this.MyController.radius = 0.2f;
							this.Attacking = false;
							this.AttackPhase = 1;
							this.Sanity -= (float)20 * this.Numbness;
							this.UpdateSanity();
							this.TargetStudent.Dead = true;
							this.TargetStudent.BecomeRagdoll();
							if (!this.Noticed)
							{
								this.CanMove = true;
							}
							else
							{
								this.Weapon[this.Equipped].Drop();
							}
						}
					}
					else if (!this.Weapon[this.Equipped].Concealable)
					{
						if (this.AttackPhase == 1)
						{
							this.Character.animation.CrossFade("f02_swingA_00");
							if (this.Character.animation["f02_swingA_00"].time > this.Character.animation["f02_swingA_00"].length * 0.3f)
							{
								if (this.TargetStudent == this.StudentManager.Reporter)
								{
									this.StudentManager.Reporter = null;
								}
								UnityEngine.Object.Destroy(this.TargetStudent.DeathScream);
								this.Weapon[this.Equipped].Effect();
								this.AttackPhase = 2;
								this.Bloodiness += (float)20;
								this.UpdateBlood();
								this.StainWeapon();
								this.Sanity -= (float)20 * this.Numbness;
								this.UpdateSanity();
							}
						}
						else if (this.Character.animation["f02_swingA_00"].time >= this.Character.animation["f02_swingA_00"].length * 0.9f)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
							this.TargetStudent.Dead = true;
							this.TargetStudent.BecomeRagdoll();
							this.MyController.radius = 0.2f;
							this.Attacking = false;
							this.AttackPhase = 1;
							this.AttackTimer = (float)0;
							if (!this.Noticed)
							{
								this.CanMove = true;
							}
							else
							{
								this.Weapon[this.Equipped].Drop();
							}
						}
					}
					else if (this.AttackPhase == 1)
					{
						this.Character.animation.CrossFade("f02_stab_00");
						if (this.Character.animation["f02_stab_00"].time > this.Character.animation["f02_stab_00"].length * 0.35f)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
							if (this.CanTranq)
							{
								this.TargetStudent.Tranquil = true;
								this.CanTranq = false;
								this.Followers--;
							}
							else
							{
								this.TargetStudent.BloodSpray.active = true;
								this.TargetStudent.Dead = true;
								this.Bloodiness += (float)20;
								this.UpdateBlood();
							}
							if (this.TargetStudent == this.StudentManager.Reporter)
							{
								this.StudentManager.Reporter = null;
							}
							AudioSource.PlayClipAtPoint(this.Stabs[UnityEngine.Random.Range(0, Extensions.get_length(this.Stabs))], this.transform.position + Vector3.up);
							UnityEngine.Object.Destroy(this.TargetStudent.DeathScream);
							this.AttackPhase = 2;
							this.Sanity -= (float)20 * this.Numbness;
							this.UpdateSanity();
							if (this.Weapon[this.Equipped].WeaponID == 8)
							{
								this.TargetStudent.Ragdoll.Sacrifice = true;
								if (PlayerPrefs.GetInt("Paranormal") == 1)
								{
									this.Weapon[this.Equipped].Effect();
								}
							}
						}
					}
					else
					{
						this.AttackTimer += Time.deltaTime;
						if (this.AttackTimer > 0.3f)
						{
							this.StainWeapon();
							this.MyController.radius = 0.2f;
							this.Attacking = false;
							this.AttackPhase = 1;
							this.AttackTimer = (float)0;
							if (!this.Noticed)
							{
								this.CanMove = true;
							}
							else
							{
								this.Weapon[this.Equipped].Drop();
							}
						}
					}
				}
				else
				{
					this.Character.animation.CrossFade("f02_counterA_00");
					float y4 = this.TargetStudent.transform.position.y;
					Vector3 position4 = this.Character.transform.position;
					float num21 = position4.y = y4;
					Vector3 vector12 = this.Character.transform.position = position4;
				}
			}
			if (!this.Attacking && !this.Dragging && this.PickUp == null && !this.Aiming && !this.Crawling && !this.Pouring && !this.DumpsterGrabbing && !this.Stripping && !this.Bathing && !this.Struggling && !this.Degloving && !this.Possessed && !this.Carrying && !this.Dismembering && !this.CirnoWings.active && this.LaughIntensity < (float)16)
			{
				this.Character.animation["f02_yanderePose_00"].weight = Mathf.Lerp(this.Character.animation["f02_yanderePose_00"].weight, (float)1 - this.Sanity / (float)100, Time.deltaTime * (float)10);
				if (this.Hairstyle == 2 && this.Crouching)
				{
					this.Slouch = Mathf.Lerp(this.Slouch, (float)0, Time.deltaTime * (float)20);
				}
				else
				{
					this.Slouch = Mathf.Lerp(this.Slouch, (float)5 * ((float)1 - this.Sanity / (float)100), Time.deltaTime * (float)10);
				}
			}
			else
			{
				this.Character.animation["f02_yanderePose_00"].weight = Mathf.Lerp(this.Character.animation["f02_yanderePose_00"].weight, (float)0, Time.deltaTime * (float)10);
				this.Slouch = Mathf.Lerp(this.Slouch, (float)0, Time.deltaTime * (float)10);
			}
			if (!this.Noticed)
			{
				float a7 = (float)1 - this.Sanity / (float)100;
				Color color13 = this.RightYandereEye.material.color;
				float num22 = color13.a = a7;
				Color color14 = this.RightYandereEye.material.color = color13;
				float a8 = (float)1 - this.Sanity / (float)100;
				Color color15 = this.LeftYandereEye.material.color;
				float num23 = color15.a = a8;
				Color color16 = this.LeftYandereEye.material.color = color15;
				this.EyeShrink = Mathf.Lerp(this.EyeShrink, 0.5f * ((float)1 - this.Sanity / (float)100), Time.deltaTime * (float)10);
			}
			if (this.Sanity < (float)100)
			{
				this.TwitchTimer += Time.deltaTime;
				if (this.TwitchTimer > this.NextTwitch)
				{
					this.Twitch.x = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
					this.Twitch.y = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
					this.Twitch.z = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
					this.NextTwitch = UnityEngine.Random.Range((float)0, 1f);
					this.TwitchTimer = (float)0;
				}
				this.Twitch = Vector3.Lerp(this.Twitch, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			if (this.NearBodies > 0)
			{
				if (!this.CorpseWarning)
				{
					this.NotificationManager.DisplayNotification("Body");
					this.StudentManager.UpdateStudents();
					this.CorpseWarning = true;
				}
			}
			else if (this.CorpseWarning)
			{
				this.StudentManager.UpdateStudents();
				this.CorpseWarning = false;
			}
			if (!this.Aiming && Time.timeScale > (float)0 && Input.GetKeyDown("escape"))
			{
				this.PauseScreen.JumpToQuit();
			}
			if (Input.GetKeyDown("p"))
			{
				this.CyborgParts[1].active = false;
				this.KONGlasses.active = false;
				this.EyepatchR.active = false;
				this.EyepatchL.active = false;
				this.EyewearID++;
				if (this.EyewearID == 1)
				{
					this.EyepatchR.active = true;
				}
				else if (this.EyewearID == 2)
				{
					this.EyepatchL.active = true;
				}
				else if (this.EyewearID == 3)
				{
					this.EyepatchR.active = true;
					this.EyepatchL.active = true;
				}
				else if (this.EyewearID == 4)
				{
					this.KONGlasses.active = true;
				}
				else if (this.EyewearID == 5)
				{
					if (this.CyborgParts[2].active)
					{
						this.CyborgParts[1].active = true;
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
			if (Input.GetKeyDown("h"))
			{
				this.Hairstyle++;
				this.UpdateHair();
			}
			if (Input.GetKeyDown("o") && !this.EasterEggMenu.active)
			{
				if (this.AccessoryGroup != null)
				{
					this.AccessoryGroup.DeactivateParts();
				}
				if (this.AccessoryID > 0)
				{
					this.Accessories[this.AccessoryID].active = false;
				}
				this.AccessoryID++;
				if (this.AccessoryID > this.Accessories.Length - 1)
				{
					this.AccessoryID = 0;
				}
				if (this.AccessoryID > 0)
				{
					this.Accessories[this.AccessoryID].active = true;
					this.AccessoryGroup = (AccessoryGroupScript)this.Accessories[this.AccessoryID].GetComponent(typeof(AccessoryGroupScript));
					if (this.AccessoryGroup != null)
					{
						this.AccessoryGroup.ActivateParts();
					}
				}
			}
			if (Input.GetKeyDown("-"))
			{
				if (Time.timeScale < (float)6)
				{
					Time.timeScale = (float)1;
				}
				else
				{
					Time.timeScale -= (float)5;
				}
			}
			if (Input.GetKeyDown("="))
			{
				if (Time.timeScale < (float)5)
				{
					Time.timeScale = (float)5;
				}
				else
				{
					Time.timeScale += (float)5;
					if (Time.timeScale > (float)25)
					{
						Time.timeScale = (float)25;
					}
				}
			}
			if (Input.GetKey("."))
			{
				this.BreastSize += Time.deltaTime;
				if (this.BreastSize > (float)2)
				{
					this.BreastSize = (float)2;
				}
			}
			if (Input.GetKey(","))
			{
				this.BreastSize -= Time.deltaTime;
				if (this.BreastSize < 0.5f)
				{
					this.BreastSize = 0.5f;
				}
			}
			if (this.CanMove && !this.Egg && this.transform.position.y < (float)1000)
			{
				if (Input.GetKeyDown("/"))
				{
					this.DebugMenu.active = false;
					if (!this.EasterEggMenu.active)
					{
						this.EasterEggMenu.active = true;
					}
					else
					{
						this.EasterEggMenu.active = false;
					}
				}
				if (this.EasterEggMenu.active && !this.Egg)
				{
					if (Input.GetKeyDown("p"))
					{
						this.Punish();
					}
					else if (Input.GetKeyDown("z"))
					{
						this.Slend();
					}
					else if (Input.GetKeyDown("b"))
					{
						this.Sukeban();
					}
					else if (Input.GetKeyDown("c"))
					{
						this.Cirno();
					}
					else if (Input.GetKeyDown("h"))
					{
						this.EmptyHands();
						this.Hate();
					}
					else if (Input.GetKeyDown("t"))
					{
						this.StudentManager.AttackOnTitan();
						this.AttackOnTitan();
					}
					else if (Input.GetKeyDown("g"))
					{
						this.GaloSengen();
					}
					else if (Input.GetKeyDown("j"))
					{
						this.Jojo();
					}
					else if (Input.GetKeyDown("k"))
					{
						this.EasterEggMenu.active = false;
						this.StudentManager.Kong();
						this.DK = true;
					}
					else if (Input.GetKeyDown("l"))
					{
						this.Agent();
					}
					else if (Input.GetKeyDown("n"))
					{
						this.Nude();
					}
					else if (Input.GetKeyDown("s"))
					{
						this.EasterEggMenu.active = false;
						this.Egg = true;
						this.StudentManager.Spook();
					}
					else if (Input.GetKeyDown("f"))
					{
						this.EasterEggMenu.active = false;
						this.Falcon();
					}
					else if (Input.GetKeyDown("x"))
					{
						this.EasterEggMenu.active = false;
						this.X();
					}
					else if (Input.GetKeyDown("o"))
					{
						this.EasterEggMenu.active = false;
						this.Punch();
					}
					else if (Input.GetKeyDown("v"))
					{
						this.EasterEggMenu.active = false;
						this.Long();
					}
					else if (Input.GetKeyDown("u"))
					{
						this.EasterEggMenu.active = false;
						this.BadTime();
					}
					else if (Input.GetKeyDown("y"))
					{
						this.EasterEggMenu.active = false;
						this.CyborgNinja();
					}
					else if (Input.GetKeyDown("e"))
					{
						this.EasterEggMenu.active = false;
						this.Ebola();
					}
					else if (Input.GetKeyDown("q"))
					{
						this.EasterEggMenu.active = false;
						this.Samus();
					}
					if (Input.GetKeyDown("d"))
					{
						if (this.Copyrights.active)
						{
							this.Jukebox.MuteCopyrights = true;
							this.Copyrights.active = false;
						}
						else
						{
							this.Jukebox.MuteCopyrights = false;
							this.Copyrights.active = true;
						}
					}
				}
			}
			if (this.transform.position.y < (float)0)
			{
				int num24 = 0;
				Vector3 position5 = this.transform.position;
				float num25 = position5.y = (float)num24;
				Vector3 vector13 = this.transform.position = position5;
			}
			if (this.transform.position.z < -49.5f)
			{
				float z2 = -49.5f;
				Vector3 position6 = this.transform.position;
				float num26 = position6.z = z2;
				Vector3 vector14 = this.transform.position = position6;
			}
			int num27 = 0;
			Vector3 eulerAngles3 = this.transform.eulerAngles;
			float num28 = eulerAngles3.x = (float)num27;
			Vector3 vector15 = this.transform.eulerAngles = eulerAngles3;
			int num29 = 0;
			Vector3 eulerAngles4 = this.transform.eulerAngles;
			float num30 = eulerAngles4.z = (float)num29;
			Vector3 vector16 = this.transform.eulerAngles = eulerAngles4;
		}
		else
		{
			this.audio.volume = this.audio.volume - 0.333333343f;
		}
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
		this.ID = 0;
		while (this.ID < this.Spine.Length)
		{
			float x3 = this.Spine[this.ID].transform.localEulerAngles.x + this.Slouch;
			Vector3 localEulerAngles = this.Spine[this.ID].transform.localEulerAngles;
			float num7 = localEulerAngles.x = x3;
			Vector3 vector7 = this.Spine[this.ID].transform.localEulerAngles = localEulerAngles;
			this.ID++;
		}
		if (this.Aiming)
		{
			float x4 = this.Spine[3].transform.localEulerAngles.x - this.Bend;
			Vector3 localEulerAngles2 = this.Spine[3].transform.localEulerAngles;
			float num8 = localEulerAngles2.x = x4;
			Vector3 vector8 = this.Spine[3].transform.localEulerAngles = localEulerAngles2;
		}
		float z3 = this.Arm[0].transform.localEulerAngles.z - this.Slouch * (float)3;
		Vector3 localEulerAngles3 = this.Arm[0].transform.localEulerAngles;
		float num9 = localEulerAngles3.z = z3;
		Vector3 vector9 = this.Arm[0].transform.localEulerAngles = localEulerAngles3;
		float z4 = this.Arm[1].transform.localEulerAngles.z + this.Slouch * (float)3;
		Vector3 localEulerAngles4 = this.Arm[1].transform.localEulerAngles;
		float num10 = localEulerAngles4.z = z4;
		Vector3 vector10 = this.Arm[1].transform.localEulerAngles = localEulerAngles4;
		this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		if (!this.Aiming)
		{
			this.Head.localEulerAngles = this.Head.localEulerAngles + this.Twitch;
		}
		if (this.Aiming)
		{
			if (this.Crawling)
			{
				this.TargetHeight = -1.4f;
			}
			else if (this.Crouching)
			{
				this.TargetHeight = -0.6f;
			}
			else
			{
				this.TargetHeight = (float)0;
			}
			this.Height = Mathf.Lerp(this.Height, this.TargetHeight, Time.deltaTime * (float)10);
			float height = this.Height;
			Vector3 localPosition3 = this.PelvisRoot.transform.localPosition;
			float num11 = localPosition3.y = height;
			Vector3 vector11 = this.PelvisRoot.transform.localPosition = localPosition3;
		}
		if (this.Hairstyles[15].active)
		{
			this.AntennaeR.localScale = new Vector3((float)0, (float)0, (float)0);
			this.AntennaeL.localScale = new Vector3((float)0, (float)0, (float)0);
			float y3 = this.Spine[3].localEulerAngles.y;
			Vector3 localEulerAngles5 = this.Spine[4].localEulerAngles;
			float num12 = localEulerAngles5.x = y3;
			Vector3 vector12 = this.Spine[4].localEulerAngles = localEulerAngles5;
			float y4 = this.Spine[3].localEulerAngles.y;
			Vector3 localEulerAngles6 = this.Spine[5].localEulerAngles;
			float num13 = localEulerAngles6.x = y4;
			Vector3 vector13 = this.Spine[5].localEulerAngles = localEulerAngles6;
		}
		if (this.SlenderHair[0].active)
		{
			this.SlenderAntennaeR.localScale = new Vector3((float)0, (float)0, (float)0);
			this.SlenderAntennaeL.localScale = new Vector3((float)0, (float)0, (float)0);
		}
		if (this.Slender)
		{
			int num14 = 2;
			Vector3 localScale5 = this.Leg[0].localScale;
			float num15 = localScale5.y = (float)num14;
			Vector3 vector14 = this.Leg[0].localScale = localScale5;
			float y5 = 0.5f;
			Vector3 localScale6 = this.Foot[0].localScale;
			float num16 = localScale6.y = y5;
			Vector3 vector15 = this.Foot[0].localScale = localScale6;
			int num17 = 2;
			Vector3 localScale7 = this.Leg[1].localScale;
			float num18 = localScale7.y = (float)num17;
			Vector3 vector16 = this.Leg[1].localScale = localScale7;
			float y6 = 0.5f;
			Vector3 localScale8 = this.Foot[1].localScale;
			float num19 = localScale8.y = y6;
			Vector3 vector17 = this.Foot[1].localScale = localScale8;
			int num20 = 2;
			Vector3 localScale9 = this.Arm[0].localScale;
			float num21 = localScale9.x = (float)num20;
			Vector3 vector18 = this.Arm[0].localScale = localScale9;
			int num22 = 2;
			Vector3 localScale10 = this.Arm[1].localScale;
			float num23 = localScale10.x = (float)num22;
			Vector3 vector19 = this.Arm[1].localScale = localScale10;
		}
		if (this.DK)
		{
			this.Arm[0].localScale = new Vector3((float)2, (float)2, (float)2);
			this.Arm[1].localScale = new Vector3((float)2, (float)2, (float)2);
			this.Head.localScale = new Vector3((float)2, (float)2, (float)2);
		}
		if (this.CirnoWings.active)
		{
			if (Input.GetButton("LB"))
			{
				this.FlapSpeed = (float)5;
			}
			else if (this.FlapSpeed == (float)0)
			{
				this.FlapSpeed = (float)1;
			}
			else
			{
				this.FlapSpeed = (float)3;
			}
			if (!this.FlapOut)
			{
				this.CirnoRotation += Time.deltaTime * (float)100 * this.FlapSpeed;
				float cirnoRotation = this.CirnoRotation;
				Vector3 localEulerAngles7 = this.CirnoWing[0].localEulerAngles;
				float num24 = localEulerAngles7.y = cirnoRotation;
				Vector3 vector20 = this.CirnoWing[0].localEulerAngles = localEulerAngles7;
				float y7 = (float)-1 * this.CirnoRotation;
				Vector3 localEulerAngles8 = this.CirnoWing[1].localEulerAngles;
				float num25 = localEulerAngles8.y = y7;
				Vector3 vector21 = this.CirnoWing[1].localEulerAngles = localEulerAngles8;
				if (this.CirnoRotation > (float)15)
				{
					this.FlapOut = true;
				}
			}
			else
			{
				this.CirnoRotation -= Time.deltaTime * (float)100 * this.FlapSpeed;
				float cirnoRotation2 = this.CirnoRotation;
				Vector3 localEulerAngles9 = this.CirnoWing[0].localEulerAngles;
				float num26 = localEulerAngles9.y = cirnoRotation2;
				Vector3 vector22 = this.CirnoWing[0].localEulerAngles = localEulerAngles9;
				float y8 = (float)-1 * this.CirnoRotation;
				Vector3 localEulerAngles10 = this.CirnoWing[1].localEulerAngles;
				float num27 = localEulerAngles10.y = y8;
				Vector3 vector23 = this.CirnoWing[1].localEulerAngles = localEulerAngles10;
				if (this.CirnoRotation < (float)-15)
				{
					this.FlapOut = false;
				}
			}
		}
	}

	public virtual void StainWeapon()
	{
		if (this.Weapon[this.Equipped] != null)
		{
			if (this.TargetStudent != null && this.TargetStudent.StudentID < Extensions.get_length(this.Weapon[this.Equipped].Victims))
			{
				this.Weapon[this.Equipped].Victims[this.TargetStudent.StudentID] = true;
			}
			this.Weapon[this.Equipped].Blood.enabled = true;
			if (this.Gloved && !this.Gloves.Blood.enabled)
			{
				this.Gloves.PickUp.Evidence = true;
				this.Gloves.Blood.enabled = true;
				this.Police.BloodyClothing = this.Police.BloodyClothing + 1;
			}
			if (this.Mask != null && !this.Mask.Blood.enabled)
			{
				this.Mask.PickUp.Evidence = true;
				this.Mask.Blood.enabled = true;
				this.Police.BloodyClothing = this.Police.BloodyClothing + 1;
			}
			if (!this.Weapon[this.Equipped].Evidence)
			{
				this.Weapon[this.Equipped].Evidence = true;
				this.Police.MurderWeapons = this.Police.MurderWeapons + 1;
			}
		}
	}

	public virtual void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - this.transform.position;
		float d = Vector3.Distance(this.transform.position, target);
		a = a.normalized * d;
		this.MyController.Move(a * Time.deltaTime * (float)10);
	}

	public virtual void StopAiming()
	{
		this.Character.animation["f02_cameraPose_00"].weight = (float)0;
		int num = 0;
		Vector3 localPosition = this.PelvisRoot.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.PelvisRoot.transform.localPosition = localPosition;
		this.ShoulderCamera.AimingCamera = false;
		if (!Input.GetButtonDown("Start") && !Input.GetKeyDown("escape"))
		{
			this.FixCamera();
		}
		if (this.ShoulderCamera.Timer == (float)0)
		{
			this.RPGCamera.enabled = true;
		}
		this.MainCamera.clearFlags = CameraClearFlags.Skybox;
		this.MainCamera.farClipPlane = 325f;
		this.Smartphone.transform.parent.active = false;
		this.PhonePromptBar.Show = false;
		this.Smartphone.fieldOfView = (float)60;
		this.Shutter.TargetStudent = 0;
		this.HandCamera.active = false;
		this.UsingController = false;
		this.Aiming = false;
		this.Lewd = false;
		this.Height = (float)0;
		this.Bend = (float)0;
	}

	public virtual void FixCamera()
	{
		this.RPGCamera.enabled = true;
		this.RPGCamera.UpdateRotation();
		this.RPGCamera.mouseSmoothingFactor = (float)0;
		this.RPGCamera.GetInput();
		this.RPGCamera.GetDesiredPosition();
		this.RPGCamera.PositionUpdate();
		this.RPGCamera.mouseSmoothingFactor = 0.08f;
		this.Blur.enabled = false;
	}

	public virtual void ResetSenpaiEffects()
	{
		this.DepthOfField.focalSize = (float)150;
		this.DepthOfField.focalZStartCurve = (float)0;
		this.DepthOfField.focalZEndCurve = (float)0;
		this.DepthOfField.enabled = false;
		this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.redChannel.SmoothTangents(1, (float)0);
		this.ColorCorrection.greenChannel.SmoothTangents(1, (float)0);
		this.ColorCorrection.blueChannel.SmoothTangents(1, (float)0);
		this.ColorCorrection.UpdateTextures();
		this.ColorCorrection.enabled = false;
		this.Character.animation["f02_shy_00"].weight = (float)0;
		this.HeartBeat.volume = (float)0;
		this.SenpaiFade = (float)100;
	}

	public virtual void ResetYandereEffects()
	{
		this.Vignette.intensity = (float)0;
		this.Vignette.blur = (float)0;
		this.Vignette.chromaticAberration = (float)0;
		this.Vignette.enabled = false;
		this.YandereColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.YandereColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.YandereColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.YandereColorCorrection.redChannel.SmoothTangents(1, (float)0);
		this.YandereColorCorrection.greenChannel.SmoothTangents(1, (float)0);
		this.YandereColorCorrection.blueChannel.SmoothTangents(1, (float)0);
		this.YandereColorCorrection.UpdateTextures();
		this.YandereColorCorrection.enabled = false;
		Time.timeScale = (float)1;
		this.YandereFade = (float)100;
	}

	public virtual void DumpRagdoll(int Type)
	{
		this.Ragdoll.transform.position = this.transform.position;
		if (Type == 1)
		{
			this.Ragdoll.transform.LookAt(this.Incinerator.transform.position);
			float y = this.Ragdoll.transform.eulerAngles.y + (float)180;
			Vector3 eulerAngles = this.Ragdoll.transform.eulerAngles;
			float num = eulerAngles.y = y;
			Vector3 vector = this.Ragdoll.transform.eulerAngles = eulerAngles;
		}
		else
		{
			this.Ragdoll.transform.LookAt(this.WoodChipper.transform.position);
		}
		((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).DumpType = Type;
		((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).Dump();
	}

	public virtual void Unequip()
	{
		if (this.CanMove || this.Noticed)
		{
			if (this.Equipped < 3)
			{
				if (this.Weapon[this.Equipped] != null)
				{
					this.Weapon[this.Equipped].active = false;
				}
			}
			else
			{
				this.Weapon[3].Drop();
			}
			this.Equipped = 0;
			this.Mopping = false;
			this.Armed = false;
			this.StudentManager.UpdateStudents();
			this.WeaponManager.UpdateLabels();
			this.WeaponMenu.UpdateSprites();
			this.WeaponWarning = false;
		}
	}

	public virtual void DropWeapon(int ID)
	{
		this.DropTimer[ID] = this.DropTimer[ID] + Time.deltaTime;
		if (this.DropTimer[ID] > 0.5f)
		{
			this.Weapon[ID].Drop();
			this.Weapon[ID] = null;
			this.Unequip();
			this.DropTimer[ID] = (float)0;
		}
	}

	public virtual void EmptyHands()
	{
		if (this.Carrying)
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
			((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).StopDragging();
		}
		this.Mopping = false;
	}

	public virtual void UpdateSanity()
	{
		if (this.Sanity > (float)100)
		{
			this.Sanity = (float)100;
		}
		else if (this.Sanity < (float)0)
		{
			this.Sanity = (float)0;
		}
		if (this.Sanity > 66.66666f)
		{
			this.HeartRate.SetHeartRateColour(this.HeartRate.NormalColour);
			this.SanityWarning = false;
		}
		else if (this.Sanity > 33.33333f)
		{
			this.HeartRate.SetHeartRateColour(this.HeartRate.MediumColour);
			this.SanityWarning = false;
			if (this.PreviousSanity < 33.33333f)
			{
				this.StudentManager.UpdateStudents();
			}
		}
		else
		{
			this.HeartRate.SetHeartRateColour(this.HeartRate.BadColour);
			if (!this.SanityWarning)
			{
				this.NotificationManager.DisplayNotification("Insane");
				this.SanityWarning = true;
			}
		}
		this.HeartRate.BeatsPerMinute = (int)((float)240 - this.Sanity * 1.8f);
		if (!this.CensorSteam[0].active)
		{
			float a = (float)1 - this.Sanity / (float)100;
			Color color = this.MyRenderer.materials[3].color;
			float num = color.a = a;
			Color color2 = this.MyRenderer.materials[3].color = color;
		}
		this.PreviousSanity = this.Sanity;
		((SkinnedMeshRenderer)this.Hairstyles[2].GetComponent(typeof(SkinnedMeshRenderer))).SetBlendShapeWeight(0, this.Sanity);
	}

	public virtual void UpdateBlood()
	{
		if (!this.BloodyWarning && this.Bloodiness > (float)0)
		{
			this.NotificationManager.DisplayNotification("Bloody");
			this.BloodyWarning = true;
			if (this.Schoolwear > 0)
			{
				this.Police.BloodyClothing = this.Police.BloodyClothing + 1;
			}
		}
		if (this.Bloodiness > (float)100)
		{
			this.Bloodiness = (float)100;
		}
		this.MyProjector.enabled = true;
		if (this.Bloodiness == (float)100)
		{
			this.MyProjector.material.mainTexture = this.BloodTextures[5];
		}
		else if (this.Bloodiness >= (float)80)
		{
			this.MyProjector.material.mainTexture = this.BloodTextures[4];
		}
		else if (this.Bloodiness >= (float)60)
		{
			this.MyProjector.material.mainTexture = this.BloodTextures[3];
		}
		else if (this.Bloodiness >= (float)40)
		{
			this.MyProjector.material.mainTexture = this.BloodTextures[2];
		}
		else if (this.Bloodiness >= (float)20)
		{
			this.MyProjector.material.mainTexture = this.BloodTextures[1];
		}
		else
		{
			this.MyProjector.enabled = false;
			this.BloodyWarning = false;
		}
		this.StudentManager.UpdateBooths();
		this.MyLocker.UpdateButtons();
		this.Outline.h.ReinitMaterials();
	}

	public virtual void UpdateNumbness()
	{
		this.Numbness = (float)1 - 0.1f * (float)(PlayerPrefs.GetInt("Numbness") + PlayerPrefs.GetInt("NumbnessBonus"));
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)" && other.transform.localScale.x > 0.3f)
		{
			if (PlayerPrefs.GetInt("PantiesEquipped") == 8)
			{
				this.RightFootprintSpawner.Bloodiness = 5;
				this.LeftFootprintSpawner.Bloodiness = 5;
			}
			else
			{
				this.RightFootprintSpawner.Bloodiness = 10;
				this.LeftFootprintSpawner.Bloodiness = 10;
			}
		}
	}

	public virtual void UpdateHair()
	{
		if (this.Hairstyle == Extensions.get_length(this.Hairstyles))
		{
			this.Hairstyle = 0;
		}
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.Hairstyles))
		{
			this.Hairstyles[this.ID].active = false;
			this.ID++;
		}
		if (this.Hairstyle > 0)
		{
			this.Hairstyles[this.Hairstyle].active = true;
		}
	}

	public virtual void StopLaughing()
	{
		this.LaughIntensity = (float)0;
		this.Laughing = false;
		this.LaughClip = null;
		this.CanMove = true;
	}

	public virtual void SetUniform()
	{
		if (PlayerPrefs.GetInt("FemaleUniform") == 0)
		{
			PlayerPrefs.SetInt("FemaleUniform", 1);
		}
		this.MyRenderer.sharedMesh = this.Uniforms[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[0].mainTexture = this.UniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[1].mainTexture = this.UniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.StartCoroutine_Auto(this.ApplyCustomCostume());
	}

	public virtual IEnumerator ApplyCustomCostume()
	{
		return new YandereScript.$ApplyCustomCostume$2641(this).GetEnumerator();
	}

	public virtual void WearGloves()
	{
		if (this.Bloodiness > (float)0 && !this.Gloves.Blood.enabled)
		{
			this.Gloves.PickUp.Evidence = true;
			this.Gloves.Blood.enabled = true;
			this.Police.BloodyClothing = this.Police.BloodyClothing + 1;
		}
		this.Gloved = true;
		if (PlayerPrefs.GetInt("FemaleUniform") == 1)
		{
			this.MyRenderer.materials[1].mainTexture = this.GloveTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
		else
		{
			this.MyRenderer.materials[0].mainTexture = this.GloveTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
	}

	public virtual void AttackOnTitan()
	{
		this.MusicCredit.SongLabel.text = "Now Playing: This Is My Choice";
		this.MusicCredit.BandLabel.text = "By: The Kira Justice";
		this.MusicCredit.Slide = true;
		this.EasterEggMenu.active = false;
		this.Egg = true;
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.TitanTexture;
		this.MyRenderer.materials[1].mainTexture = this.TitanTexture;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.Outline.h.ReinitMaterials();
	}

	public virtual void KON()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[4];
		this.MyRenderer.materials[0].mainTexture = this.KONTexture;
		this.MyRenderer.materials[1].mainTexture = this.KONTexture;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.Outline.h.ReinitMaterials();
	}

	public virtual void Punish()
	{
		this.PunishedShader = Shader.Find("Toon/Cutoff");
		this.EasterEggMenu.active = false;
		this.Egg = true;
		this.PunishedAccessories.active = true;
		this.PunishedScarf.active = true;
		this.EyepatchL.active = false;
		this.EyepatchR.active = false;
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.PunishedArm))
		{
			this.PunishedArm[this.ID].active = true;
			this.ID++;
		}
		this.MyRenderer.sharedMesh = this.PunishedMesh;
		this.MyRenderer.materials[0].mainTexture = this.PunishedTextures[1];
		this.MyRenderer.materials[1].mainTexture = this.PunishedTextures[1];
		this.MyRenderer.materials[2].mainTexture = this.PunishedTextures[0];
		this.MyRenderer.materials[1].shader = this.PunishedShader;
		this.MyRenderer.materials[1].SetFloat("_Shininess", (float)2);
		this.MyRenderer.materials[1].SetFloat("_ShadowThreshold", (float)0);
		this.Outline.h.ReinitMaterials();
	}

	public virtual void Hate()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.HatefulUniform;
		this.MyRenderer.materials[1].mainTexture = this.HatefulUniform;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		RenderSettings.skybox = this.HatefulSkybox;
		this.SelectGrayscale.desaturation = (float)1;
		this.HeartRate.active = false;
		this.Sanity = (float)0;
		this.Hairstyle = 15;
		this.UpdateHair();
		this.EasterEggMenu.active = false;
		this.Egg = true;
	}

	public virtual void Sukeban()
	{
		this.IdleAnim = "f02_idle_00";
		this.SukebanAccessories.active = true;
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[1].mainTexture = this.SukebanBandages;
		this.MyRenderer.materials[0].mainTexture = this.SukebanUniform;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.EasterEggMenu.active = false;
		this.Egg = true;
	}

	public virtual void Slend()
	{
		RenderSettings.skybox = this.SlenderSkybox;
		this.SelectGrayscale.desaturation = 0.5f;
		this.SelectGrayscale.enabled = true;
		this.EasterEggMenu.active = false;
		this.Slender = true;
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.SlenderHair[0].active = true;
		this.SlenderHair[1].active = true;
		float y = 0.822f;
		Vector3 localPosition = this.Character.transform.localPosition;
		float num = localPosition.y = y;
		Vector3 vector = this.Character.transform.localPosition = localPosition;
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.SlenderUniform;
		this.MyRenderer.materials[1].mainTexture = this.SlenderUniform;
		this.MyRenderer.materials[2].mainTexture = this.SlenderSkin;
		this.Sanity = (float)0;
		this.UpdateSanity();
	}

	public virtual void X()
	{
		this.Xtan = true;
		this.Egg = true;
		this.Hairstyle = 9;
		this.UpdateHair();
		this.BlackEyePatch.active = true;
		this.XSclera.active = true;
		this.XEye.active = true;
		this.Schoolwear = 2;
		this.ChangeSchoolwear();
		this.CanMove = true;
		this.MyRenderer.materials[0].mainTexture = this.XBody;
		this.MyRenderer.materials[1].mainTexture = this.XBody;
		this.MyRenderer.materials[2].mainTexture = this.XFace;
	}

	public virtual void GaloSengen()
	{
		this.EasterEggMenu.active = false;
		this.Egg = true;
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.GaloAccessories))
		{
			this.GaloAccessories[this.ID].active = true;
			this.ID++;
		}
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.UniformTextures[1];
		this.MyRenderer.materials[1].mainTexture = this.GaloArms;
		this.MyRenderer.materials[2].mainTexture = this.GaloFace;
		this.Hairstyle = 14;
		this.UpdateHair();
	}

	public virtual void Jojo()
	{
		this.EasterEggMenu.active = false;
		this.Egg = true;
		this.Stand.active = true;
	}

	public virtual void Agent()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[4];
		this.MyRenderer.materials[0].mainTexture = this.AgentSuit;
		this.MyRenderer.materials[1].mainTexture = this.AgentSuit;
		this.MyRenderer.materials[2].mainTexture = this.AgentFace;
		this.EasterEggMenu.active = false;
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	public virtual void Cirno()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[3];
		this.MyRenderer.materials[0].mainTexture = this.CirnoUniform;
		this.MyRenderer.materials[1].mainTexture = this.CirnoUniform;
		this.MyRenderer.materials[2].mainTexture = this.CirnoFace;
		this.CirnoRibbon.active = true;
		this.CirnoWings.active = true;
		this.CirnoHair.active = true;
		this.IdleAnim = "f02_cirnoIdle_00";
		this.WalkAnim = "f02_cirnoWalk_00";
		this.RunAnim = "f02_cirnoRun_00";
		this.EasterEggMenu.active = false;
		this.Crouching = false;
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	public virtual void Falcon()
	{
		this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
		this.MyRenderer.materials[0].mainTexture = this.FalconBody;
		this.MyRenderer.materials[1].mainTexture = this.FalconBody;
		this.MyRenderer.materials[2].mainTexture = this.FalconFace;
		this.FalconShoulderpad.active = true;
		this.FalconNipple1.active = true;
		this.FalconNipple2.active = true;
		this.FalconBuckle.active = true;
		this.FalconHelmet.active = true;
		this.FalconGun.active = true;
		this.Character.animation[this.RunAnim].speed = (float)5;
		this.IdleAnim = "f02_falconIdle_00";
		this.RunSpeed *= (float)5;
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	public virtual void Punch()
	{
		this.MusicCredit.SongLabel.text = "Now Playing: Unknown Hero";
		this.MusicCredit.BandLabel.text = "By: The Kira Justice";
		this.MusicCredit.Slide = true;
		this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
		this.MyRenderer.materials[0].mainTexture = this.SaitamaSuit;
		this.MyRenderer.materials[1].mainTexture = this.SaitamaSuit;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.EasterEggMenu.active = false;
		this.Barcode.active = false;
		this.Cape.active = true;
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	public virtual void BadTime()
	{
		this.MyRenderer.sharedMesh = this.Jersey;
		this.MyRenderer.materials[0].mainTexture = this.SansFace;
		this.MyRenderer.materials[1].mainTexture = this.SansTexture;
		this.MyRenderer.materials[2].mainTexture = this.SansTexture;
		this.EasterEggMenu.active = false;
		this.IdleAnim = "f02_sansIdle_00";
		this.StudentManager.BadTime();
		this.Barcode.active = false;
		this.Sans = true;
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	public virtual void CyborgNinja()
	{
		this.EnergySword.active = true;
		this.IdleAnim = "CyborgNinja_Idle_Unarmed";
		this.RunAnim = "CyborgNinja_Run_Unarmed";
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.CyborgFace;
		this.MyRenderer.materials[1].mainTexture = this.CyborgBody;
		this.MyRenderer.materials[2].mainTexture = this.CyborgBody;
		int num = 0;
		Color color = this.MyRenderer.materials[3].color;
		float num2 = color.a = (float)num;
		Color color2 = this.MyRenderer.materials[3].color = color;
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.CyborgParts))
		{
			this.CyborgParts[this.ID].active = true;
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.StudentManager.Students))
		{
			if (this.StudentManager.Students[this.ID] != null)
			{
				this.StudentManager.Students[this.ID].Teacher = false;
			}
			this.ID++;
		}
		this.RunSpeed *= (float)2;
		this.EyewearID = 5;
		this.Hairstyle = 45;
		this.UpdateHair();
		this.Egg = true;
	}

	public virtual void Ebola()
	{
		this.IdleAnim = "f02_ebolaIdle_00";
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.EbolaUniform;
		this.MyRenderer.materials[1].mainTexture = this.EbolaUniform;
		this.MyRenderer.materials[2].mainTexture = this.EbolaFace;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.EbolaWings.active = true;
		this.EbolaHair.active = true;
		this.Egg = true;
	}

	public virtual void Long()
	{
		this.MyRenderer.sharedMesh = this.LongUniform;
	}

	public virtual void Nude()
	{
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.CensorSteam))
		{
			this.CensorSteam[this.ID].active = true;
			this.ID++;
		}
		int num = 0;
		Color color = this.MyRenderer.materials[3].color;
		float num2 = color.a = (float)num;
		Color color2 = this.MyRenderer.materials[3].color = color;
		this.EasterEggMenu.active = false;
		this.ClubAttire = false;
		this.ClubAccessory();
	}

	public virtual void Samus()
	{
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.SamusFace;
		this.MyRenderer.materials[2].mainTexture = this.SamusBody;
		int num = 0;
		Color color = this.MyRenderer.materials[3].color;
		float num2 = color.a = (float)num;
		Color color2 = this.MyRenderer.materials[3].color = color;
		this.PonytailRenderer.material.mainTexture = this.SamusFace;
		this.Egg = true;
	}

	public virtual void ChangeSchoolwear()
	{
		this.Paint = false;
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
			this.MyRenderer.sharedMesh = this.Uniforms[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[0].mainTexture = this.UniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[1].mainTexture = this.UniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
			this.StartCoroutine_Auto(this.ApplyCustomCostume());
		}
		else if (this.Schoolwear == 2)
		{
			this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
			this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
			this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		}
		else if (this.Schoolwear == 3)
		{
			this.MyRenderer.sharedMesh = this.GymUniform;
			this.MyRenderer.materials[0].mainTexture = this.GymTexture;
			this.MyRenderer.materials[1].mainTexture = this.GymTexture;
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		}
		this.CanMove = false;
		int num = 0;
		Color color = this.MyRenderer.materials[3].color;
		float num2 = color.a = (float)num;
		Color color2 = this.MyRenderer.materials[3].color = color;
		this.Outline.h.ReinitMaterials();
		this.ClubAccessory();
	}

	public virtual void ChangeClubwear()
	{
		this.Paint = false;
		if (!this.ClubAttire)
		{
			this.ClubAttire = true;
			if (PlayerPrefs.GetInt("Club") == 4)
			{
				this.MyRenderer.sharedMesh = this.ApronMesh;
				this.MyRenderer.materials[0].mainTexture = this.ApronTexture;
				this.MyRenderer.materials[1].mainTexture = this.ApronTexture;
				this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				this.Paint = true;
			}
			else if (PlayerPrefs.GetInt("Club") == 6)
			{
				this.MyRenderer.sharedMesh = this.JudoGiMesh;
				this.MyRenderer.materials[0].mainTexture = this.JudoGiTexture;
				this.MyRenderer.materials[1].mainTexture = this.JudoGiTexture;
				this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
			}
		}
		else
		{
			this.ChangeSchoolwear();
			this.ClubAttire = false;
		}
		this.MyLocker.UpdateButtons();
	}

	public virtual void ClubAccessory()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.ClubAccessories))
		{
			if (this.ClubAccessories[this.ID] != null)
			{
				this.ClubAccessories[this.ID].active = false;
			}
			this.ID++;
		}
		if (!this.CensorSteam[0].active && PlayerPrefs.GetInt("Club") > 0 && this.ClubAccessories[PlayerPrefs.GetInt("Club")] != null)
		{
			this.ClubAccessories[PlayerPrefs.GetInt("Club")].active = true;
		}
	}

	public virtual void StopCarrying()
	{
		if (this.Ragdoll != null)
		{
			((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).Fall();
		}
		this.Carrying = false;
		this.IdleAnim = this.OriginalIdleAnim;
		this.WalkAnim = this.OriginalWalkAnim;
		this.RunAnim = this.OriginalRunAnim;
	}

	public virtual void Main()
	{
	}
}
