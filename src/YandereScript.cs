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
	internal sealed class $ApplyCustomCostume$2139 : GenericGenerator<WWW>
	{
		internal YandereScript $self_$2154;

		public $ApplyCustomCostume$2139(YandereScript self_)
		{
			this.$self_$2154 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new YandereScript.$ApplyCustomCostume$2139.$(this.$self_$2154);
		}
	}

	private Quaternion targetRotation;

	private Vector3 targetDirection;

	private GameObject NewTrail;

	private int AccessoryID;

	private int ID;

	public Mesh TestMesh;

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

	public AccessoryGroupScript AccessoryGroup;

	public DumpsterHandleScript DumpsterHandle;

	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public WeaponManagerScript WeaponManager;

	public SplashCameraScript SplashCamera;

	public CharacterScript BaldSchoolgirl;

	public SWP_HeartRateMonitor HeartRate;

	public IncineratorScript Incinerator;

	public PauseScreenScript PauseScreen;

	public StudentScript TargetStudent;

	public WeaponMenuScript WeaponMenu;

	public PromptScript NearestPrompt;

	public TallLockerScript MyLocker;

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

	public MopScript Mop;

	public UIPanel HUD;

	public CharacterController MyController;

	public Transform CameraFocus;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform ItemParent;

	public Transform PelvisRoot;

	public Transform CameraPOV;

	public Transform Homeroom;

	public Transform Ponytail;

	public Transform Senpai;

	public Transform HairR;

	public Transform HairL;

	public Transform Stool;

	public Transform Eyes;

	public Transform Head;

	public Transform Hips;

	public AudioSource HeartBeat;

	public GameObject[] Accessories;

	public Transform[] LongHair;

	public GameObject[] Shoes;

	public GameObject CinematicCamera;

	public GameObject BlackEyePatch;

	public GameObject EasterEggMenu;

	public GameObject PonytailWig;

	public GameObject Copyrights;

	public GameObject HandCamera;

	public GameObject HatredHair;

	public GameObject KONGlasses;

	public GameObject AlarmDisc;

	public GameObject Character;

	public GameObject EyepatchL;

	public GameObject EyepatchR;

	public GameObject PippiHair;

	public GameObject CuteHair;

	public GameObject InfoHair;

	public GameObject ShoePair;

	public GameObject Ragdoll;

	public GameObject Hearts;

	public GameObject Phone;

	public GameObject Trail;

	public GameObject Korra;

	public GameObject Galo;

	public GameObject Yuno;

	public GameObject Rei;

	public SkinnedMeshRenderer MyRenderer;

	public SpringJoint RagdollDragger;

	public Projector MyProjector;

	public Camera HeartCamera;

	public Camera MainCamera;

	public Camera Smartphone;

	public Renderer LongHairRenderer;

	public Renderer PonytailRenderer;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public float CinematicTimer;

	public float YandereTimer;

	public float AttackTimer;

	public float CrawlTimer;

	public float LaughTimer;

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

	public bool TimeSkipping;

	public bool Trespassing;

	public bool Crouching;

	public bool Attacking;

	public bool Stripping;

	public bool Crawling;

	public bool Dragging;

	public bool Laughing;

	public bool Throwing;

	public bool Bathing;

	public bool Dipping;

	public bool Dumping;

	public bool FlapOut;

	public bool Mopping;

	public bool Pouring;

	public bool Slender;

	public bool Talking;

	public bool Aiming;

	public bool CrouchButtonDown;

	public bool UsingController;

	public bool CameFromCrouch;

	public bool PossessPoison;

	public bool YandereVision;

	public bool PossessTranq;

	public bool NearSenpai;

	public bool CanTranq;

	public bool Collapse;

	public bool HidePony;

	public bool RoofPush;

	public bool Noticed;

	public bool InClass;

	public bool CanMove;

	public bool Chased;

	public bool Armed;

	public bool Drown;

	public bool Xtan;

	public bool Lewd;

	public bool Egg;

	public bool DK;

	public Texture[] UniformTextures;

	public Texture[] BloodTextures;

	public WeaponScript[] Weapon;

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

	public AudioClip PowerUp;

	public AudioClip Laugh1;

	public AudioClip Laugh2;

	public AudioClip Laugh3;

	public AudioClip Laugh4;

	public Vector3 PreviousPosition;

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

	public GameObject[] SlenderHair;

	public Texture SlenderUniform;

	public Material SlenderSkybox;

	public Texture SlenderSkin;

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

	public GameObject[] CensorSteam;

	public Texture NudeTexture;

	public Mesh NudeMesh;

	public Mesh SchoolSwimsuit;

	public Mesh GymUniform;

	public Texture FaceTexture;

	public Texture SwimsuitTexture;

	public Texture GymTexture;

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
	}

	public virtual void Start()
	{
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
		this.LongHair[0].gameObject.active = false;
		this.PunishedAccessories.active = false;
		this.SukebanAccessories.active = false;
		this.CensorSteam[0].active = false;
		this.CensorSteam[1].active = false;
		this.CensorSteam[2].active = false;
		this.CensorSteam[3].active = false;
		this.BlackEyePatch.active = false;
		this.EasterEggMenu.active = false;
		this.PunishedScarf.active = false;
		this.HatredHair.active = false;
		this.KONGlasses.active = false;
		this.CirnoRibbon.active = false;
		this.CirnoWings.active = false;
		this.CirnoHair.active = false;
		this.EyepatchL.active = false;
		this.EyepatchR.active = false;
		this.PippiHair.active = false;
		this.CuteHair.active = false;
		this.InfoHair.active = false;
		this.PigtailL.active = false;
		this.PigtailR.active = false;
		this.Shoes[0].active = false;
		this.Shoes[1].active = false;
		this.Drills.active = false;
		this.Korra.active = false;
		this.Stand.active = false;
		this.Galo.active = false;
		this.Yuno.active = false;
		this.Rei.active = false;
		this.IdleAnim = "f02_idleShort_00";
		this.WalkAnim = "f02_walk_00";
		this.RunAnim = "f02_sprint_00";
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
		if (PlayerPrefs.GetInt("PantiesEquipped") == 5)
		{
			this.RunSpeed += (float)1;
		}
		this.UpdateHair();
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
							if (!this.Dragging && !this.Mopping)
							{
								this.Character.animation.CrossFade(this.RunAnim);
								this.MyController.Move(this.transform.forward * this.RunSpeed * Time.deltaTime);
							}
							else
							{
								this.Character.animation.CrossFade("f02_dragWalk_00");
								this.MyController.Move(this.transform.forward * this.WalkSpeed * Time.deltaTime);
							}
							if (this.Crouching)
							{
								this.Crouching = false;
							}
							if (this.Crawling)
							{
								this.Crawling = false;
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
					if (!Input.GetButton("X") && (Input.GetAxis("LT") > 0.5f || Input.GetMouseButtonDown(1)))
					{
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
								this.YandereVision = true;
							}
						}
						else if (this.YandereVision)
						{
							this.Obscurance.enabled = false;
							this.YandereVision = false;
						}
						if (Input.GetButtonUp("RB"))
						{
							if (this.YandereTimer < 0.5f && !this.Dragging && !this.Laughing)
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
					if (Input.GetAxis("DpadY") != (float)0 || Input.GetAxis("Mouse ScrollWheel") != (float)0)
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
			}
			else
			{
				if (this.Dumping)
				{
					this.targetRotation = Quaternion.LookRotation(this.Incinerator.transform.position + Vector3.fwd * (float)4 - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
					this.MoveTowardsTarget(this.Incinerator.transform.position + Vector3.fwd * (float)3);
					this.DumpTimer += Time.deltaTime;
					if (this.DumpTimer > (float)1)
					{
						if (!((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).Dumped)
						{
							this.DumpRagdoll();
						}
						this.Character.animation.CrossFade("f02_throw_20_p");
						if (this.Character.animation["f02_throw_20_p"].time >= this.Character.animation["f02_throw_20_p"].length)
						{
							this.Incinerator.Prompt.enabled = true;
							this.Incinerator.Ready = true;
							this.Incinerator.Open = false;
							this.Dragging = false;
							this.Dumping = false;
							this.CanMove = true;
							this.Ragdoll = null;
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
					if (this.Galo.active)
					{
						this.LaughAnim = "storepower_20";
						this.LaughClip = this.PowerUp;
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
							GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.CirnoIceAttack, this.transform.position + this.transform.up * 1.4f, this.transform.rotation);
							gameObject.transform.localEulerAngles = gameObject.transform.localEulerAngles + new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
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
							GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(this.AlarmDisc, this.transform.position + Vector3.up, Quaternion.identity);
							((AlarmDiscScript)gameObject2.GetComponent(typeof(AlarmDiscScript))).NoScream = true;
							this.LaughAnim = "f02_laugh_04";
							this.LaughClip = this.Laugh4;
							this.LaughTimer = (float)2;
						}
						else
						{
							GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(this.AlarmDisc, this.transform.position + Vector3.up, Quaternion.identity);
							((AlarmDiscScript)gameObject2.GetComponent(typeof(AlarmDiscScript))).NoScream = true;
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
			if (this.Noticed)
			{
				if (!this.Collapse)
				{
					this.Character.animation.CrossFade("f02_scaredIdle_00");
					this.targetRotation = Quaternion.LookRotation(this.Senpai.position - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
					int num4 = 0;
					Vector3 localEulerAngles2 = this.transform.localEulerAngles;
					float num5 = localEulerAngles2.x = (float)num4;
					Vector3 vector5 = this.transform.localEulerAngles = localEulerAngles2;
				}
				else if (this.Character.animation["f02_down_22"].time >= this.Character.animation["f02_down_22"].length)
				{
					this.Character.animation.CrossFade("f02_down_23");
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
			if (!this.Attacking)
			{
				if (Vector3.Distance(this.transform.position, this.Senpai.position) < (float)2)
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
					if (this.Dragging)
					{
						((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).StopDragging();
					}
					if (this.Armed)
					{
						this.Weapon[this.Equipped].Drop();
						this.Unequip();
					}
					if (this.PickUp != null)
					{
						this.PickUp.Drop();
					}
					if (this.Aiming)
					{
						this.StopAiming();
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
			Color color = this.RightYandereEye.material.color;
			float num6 = color.a = a5;
			Color color2 = this.RightYandereEye.material.color = color;
			float a6 = (float)1 - this.YandereFade / (float)100;
			Color color3 = this.LeftYandereEye.material.color;
			float num7 = color3.a = a6;
			Color color4 = this.LeftYandereEye.material.color = color3;
			if (this.Armed)
			{
				this.Character.animation["f02_fist_00"].weight = Mathf.Lerp(this.Character.animation["f02_fist_00"].weight, (float)1, Time.deltaTime * (float)10);
			}
			else
			{
				this.Character.animation["f02_fist_00"].weight = Mathf.Lerp(this.Character.animation["f02_fist_00"].weight, (float)0, Time.deltaTime * (float)10);
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
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
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
							this.Sanity -= (float)10;
						}
						else
						{
							this.Sanity -= (float)20;
						}
					}
				}
				else if (this.RoofPush)
				{
					this.MoveTowardsTarget(this.TargetStudent.transform.position + this.TargetStudent.transform.forward * (float)-1);
					this.Character.animation.CrossFade("f02_roofPushA_00");
					if (this.Character.animation["f02_roofPushA_00"].time > 4.33333349f)
					{
						if (this.Shoes[0].active)
						{
							GameObject gameObject3 = (GameObject)UnityEngine.Object.Instantiate(this.ShoePair, this.transform.position + new Vector3((float)0, 0.045f, 1.6f), Quaternion.identity);
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
						this.TargetStudent.Dead = true;
						this.Attacking = false;
						this.RoofPush = false;
						this.CanMove = true;
						this.Sanity -= (float)20;
					}
					if (Input.GetButtonDown("B"))
					{
						this.SplashCamera.Show = true;
						this.SplashCamera.MyCamera.enabled = true;
						this.SplashCamera.transform.position = new Vector3(-23.5f, 1.35f, (float)27);
						this.SplashCamera.transform.eulerAngles = new Vector3((float)0, (float)-135, (float)0);
					}
				}
				else if (!this.TargetStudent.Teacher)
				{
					if (this.AttackPhase == 1)
					{
						this.Character.animation.CrossFade("f02_stab_00");
						if (this.Character.animation["f02_stab_00"].time > this.Character.animation["f02_stab_00"].length * 0.35f)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
							if (this.CanTranq && this.Weapon[this.Equipped].WeaponID == 3 && this.PossessTranq && PlayerPrefs.GetInt("BiologyGrade") > 1)
							{
								this.TargetStudent.Tranquil = true;
								this.Followers--;
							}
							else
							{
								this.TargetStudent.BloodSpray.active = true;
								this.Bloodiness += (float)20;
								this.UpdateBlood();
							}
							if (this.TargetStudent == this.StudentManager.Reporter)
							{
								this.StudentManager.Reporter = null;
							}
							AudioSource.PlayClipAtPoint(this.Stabs[UnityEngine.Random.Range(0, Extensions.get_length(this.Stabs))], this.transform.position + Vector3.up);
							UnityEngine.Object.Destroy(this.TargetStudent.DeathScream);
							this.TargetStudent.Dead = true;
							this.AttackPhase = 2;
							this.Sanity -= (float)20;
							this.UpdateSanity();
						}
					}
					else
					{
						this.AttackTimer += Time.deltaTime;
						if (this.AttackTimer > 0.3f)
						{
							if (!this.Weapon[this.Equipped].Evidence)
							{
								this.Weapon[this.Equipped].Evidence = true;
								this.Police.MurderWeapons = this.Police.MurderWeapons + 1;
							}
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
					float y3 = this.TargetStudent.transform.position.y;
					Vector3 position2 = this.Character.transform.position;
					float num8 = position2.y = y3;
					Vector3 vector6 = this.Character.transform.position = position2;
				}
			}
			if (!this.Attacking && !this.Dragging && this.PickUp == null && !this.Aiming && !this.Crawling && !this.Pouring && !this.DumpsterGrabbing && !this.Stripping && !this.Bathing && this.LaughIntensity < (float)16)
			{
				this.Character.animation["f02_yanderePose_00"].weight = Mathf.Lerp(this.Character.animation["f02_yanderePose_00"].weight, (float)1 - this.Sanity / (float)100, Time.deltaTime * (float)10);
				this.Slouch = Mathf.Lerp(this.Slouch, (float)5 * ((float)1 - this.Sanity / (float)100), Time.deltaTime * (float)10);
			}
			else
			{
				this.Character.animation["f02_yanderePose_00"].weight = Mathf.Lerp(this.Character.animation["f02_yanderePose_00"].weight, (float)0, Time.deltaTime * (float)10);
				this.Slouch = Mathf.Lerp(this.Slouch, (float)0, Time.deltaTime * (float)10);
			}
			if (!this.Noticed)
			{
				this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1 - this.Sanity / (float)100, Time.deltaTime * (float)10);
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
					this.EyewearID = 0;
				}
			}
			if (Input.GetKeyDown("h") && !this.Slender)
			{
				this.UpdateHair();
			}
			if (Input.GetKeyDown("o"))
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
			if (this.CanMove && !this.Egg)
			{
				if (Input.GetKeyDown("/"))
				{
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
					else if (Input.GetKeyDown("x"))
					{
						this.X();
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
			if (this.transform.position.x < (float)-75)
			{
				int num9 = -75;
				Vector3 position3 = this.transform.position;
				float num10 = position3.x = (float)num9;
				Vector3 vector7 = this.transform.position = position3;
			}
			if (this.transform.position.x > (float)75)
			{
				int num11 = 75;
				Vector3 position4 = this.transform.position;
				float num12 = position4.x = (float)num11;
				Vector3 vector8 = this.transform.position = position4;
			}
			if (this.transform.position.y < (float)0)
			{
				int num13 = 0;
				Vector3 position5 = this.transform.position;
				float num14 = position5.y = (float)num13;
				Vector3 vector9 = this.transform.position = position5;
			}
			if (this.transform.position.z < -49.5f)
			{
				float z = -49.5f;
				Vector3 position6 = this.transform.position;
				float num15 = position6.z = z;
				Vector3 vector10 = this.transform.position = position6;
			}
			if (this.transform.position.z > (float)50)
			{
				int num16 = 50;
				Vector3 position7 = this.transform.position;
				float num17 = position7.z = (float)num16;
				Vector3 vector11 = this.transform.position = position7;
			}
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
		if (this.HatredHair.active)
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
		this.MainCamera.farClipPlane = 200f;
		this.Smartphone.transform.parent.active = false;
		this.Smartphone.fieldOfView = (float)60;
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

	public virtual void DumpRagdoll()
	{
		this.Ragdoll.transform.position = this.transform.position;
		this.Ragdoll.transform.LookAt(this.Incinerator.transform.position);
		float y = this.Ragdoll.transform.eulerAngles.y + (float)180;
		Vector3 eulerAngles = this.Ragdoll.transform.eulerAngles;
		float num = eulerAngles.y = y;
		Vector3 vector = this.Ragdoll.transform.eulerAngles = eulerAngles;
		((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).Dump(1);
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

	public virtual void EmptyHands()
	{
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
		this.PreviousSanity = this.Sanity;
	}

	public virtual void UpdateBlood()
	{
		if (!this.BloodyWarning && this.Bloodiness > (float)0)
		{
			this.NotificationManager.DisplayNotification("Bloody");
			this.BloodyWarning = true;
			this.Police.BloodyUniforms = this.Police.BloodyUniforms + 1;
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
		this.MyLocker.UpdateButtons();
		this.Outline.h.ReinitMaterials();
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
		this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.LongHair[0].gameObject.active = false;
		this.HatredHair.active = false;
		this.PippiHair.active = false;
		this.CuteHair.active = false;
		this.InfoHair.active = false;
		this.PigtailR.active = false;
		this.PigtailL.active = false;
		this.Drills.active = false;
		this.Korra.active = false;
		this.Galo.active = false;
		this.Yuno.active = false;
		this.Rei.active = false;
		this.HidePony = true;
		this.Hairstyle++;
		if (this.Hairstyle > 17)
		{
			this.Hairstyle = 0;
		}
		if (this.Hairstyle == 0)
		{
			this.PonytailWig.active = false;
		}
		else if (this.Hairstyle == 1)
		{
			this.HidePony = false;
			this.PonytailWig.active = true;
			this.Ponytail.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairR.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairL.localScale = new Vector3((float)1, (float)1, (float)1);
		}
		else if (this.Hairstyle == 2)
		{
			this.PigtailR.active = true;
		}
		else if (this.Hairstyle == 3)
		{
			this.PigtailL.active = true;
		}
		else if (this.Hairstyle == 4)
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
		}
		else if (this.Hairstyle == 5)
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
			this.HidePony = false;
			this.Ponytail.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairR.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairL.localScale = new Vector3((float)1, (float)1, (float)1);
		}
		else if (this.Hairstyle == 6)
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
			this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
			this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
		}
		else if (this.Hairstyle == 7)
		{
			this.Drills.active = true;
		}
		else if (this.Hairstyle == 8)
		{
			this.PonytailWig.active = false;
			this.LongHair[0].gameObject.active = true;
			this.LongHair[1].localScale = new Vector3(0.933333f, 0.933333f, 0.933333f);
			this.LongHair[2].localScale = new Vector3(0.875f, 0.875f, 0.875f);
			this.LongHair[3].localScale = new Vector3(0.875f, 0.875f, 0.875f);
			this.LongHair[4].localScale = new Vector3(0.8f, 0.8f, 0.8f);
			this.LongHair[5].localScale = new Vector3((float)1, 0.5f, 0.5f);
			this.LongHair[6].localScale = new Vector3((float)1, 0.5f, 0.5f);
			this.LongHair[7].localScale = new Vector3((float)1, 0.5f, 0.5f);
		}
		else if (this.Hairstyle == 9)
		{
			this.PonytailWig.active = false;
			this.LongHair[0].gameObject.active = true;
			this.ID = 1;
			while (this.ID < Extensions.get_length(this.LongHair))
			{
				this.LongHair[this.ID].localScale = new Vector3((float)1, (float)1, (float)1);
				this.ID++;
			}
		}
		else if (this.Hairstyle == 10)
		{
			this.PonytailWig.active = false;
			this.Rei.active = true;
		}
		else if (this.Hairstyle == 11)
		{
			this.PonytailWig.active = false;
			this.Yuno.active = true;
		}
		else if (this.Hairstyle == 12)
		{
			this.PonytailWig.active = false;
			this.Korra.active = true;
		}
		else if (this.Hairstyle == 13)
		{
			this.PonytailWig.active = false;
			this.Galo.active = true;
		}
		else if (this.Hairstyle == 14)
		{
			this.PonytailWig.active = false;
			this.HatredHair.active = true;
			this.Galo.active = false;
		}
		else if (this.Hairstyle == 15)
		{
			this.PonytailWig.active = false;
			this.HatredHair.active = false;
			this.CuteHair.active = true;
		}
		else if (this.Hairstyle == 16)
		{
			this.PonytailWig.active = false;
			this.PippiHair.active = true;
			this.CuteHair.active = false;
		}
		else if (this.Hairstyle == 17)
		{
			this.PonytailWig.active = false;
			this.CuteHair.active = false;
			this.InfoHair.active = true;
		}
		if (this.HidePony)
		{
			this.Ponytail.parent.transform.localScale = new Vector3((float)1, (float)1, 0.9f);
			this.Ponytail.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairR.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairL.localScale = new Vector3((float)0, (float)0, (float)0);
		}
		else
		{
			this.Ponytail.parent.transform.localScale = new Vector3((float)1, (float)1, (float)1);
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
		return new YandereScript.$ApplyCustomCostume$2139(this).GetEnumerator();
	}

	public virtual void AttackOnTitan()
	{
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
		this.Hairstyle = 13;
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
		this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.EasterEggMenu.active = false;
		this.PonytailWig.active = false;
		this.PigtailR.active = false;
		this.PigtailL.active = false;
		this.Drills.active = false;
		this.Korra.active = false;
		this.Yuno.active = false;
		this.Rei.active = false;
		this.Slender = true;
		this.Egg = true;
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
		this.LongHair[0].gameObject.active = true;
		this.BlackEyePatch.active = true;
		this.XSclera.active = true;
		this.XEye.active = true;
		this.Schoolwear = 2;
		this.ChangeSchoolwear();
		this.MyRenderer.materials[0].mainTexture = this.XBody;
		this.MyRenderer.materials[1].mainTexture = this.XBody;
		this.MyRenderer.materials[2].mainTexture = this.XFace;
		this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.EasterEggMenu.active = false;
		this.PonytailWig.active = false;
		this.PigtailR.active = false;
		this.PigtailL.active = false;
		this.Drills.active = false;
		this.Korra.active = false;
		this.Yuno.active = false;
		this.Rei.active = false;
		this.CanMove = true;
		this.Xtan = true;
		this.Egg = true;
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
		this.Hairstyle = 12;
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
		this.Hairstyle = 100;
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
		this.Hairstyle = 100;
		this.UpdateHair();
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
		this.EasterEggMenu.active = false;
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
		this.Outline.h.ReinitMaterials();
	}

	public virtual void Main()
	{
		this.Character.animation["f02_yanderePose_00"].layer = 1;
		this.Character.animation["f02_yanderePose_00"].weight = (float)0;
		this.Character.animation.Play("f02_yanderePose_00");
		this.Character.animation["f02_shy_00"].layer = 2;
		this.Character.animation["f02_shy_00"].weight = (float)0;
		this.Character.animation.Play("f02_shy_00");
		this.Character.animation["f02_fist_00"].layer = 3;
		this.Character.animation["f02_fist_00"].weight = (float)0;
		this.Character.animation.Play("f02_fist_00");
		this.Character.animation["f02_mopping_00"].layer = 4;
		this.Character.animation["f02_mopping_00"].weight = (float)0;
		this.Character.animation["f02_mopping_00"].speed = (float)2;
		this.Character.animation.Play("f02_mopping_00");
		this.Character.animation["f02_carry_00"].layer = 5;
		this.Character.animation["f02_carry_00"].weight = (float)0;
		this.Character.animation.Play("f02_carry_00");
		this.Character.animation["f02_mopCarry_00"].layer = 6;
		this.Character.animation["f02_mopCarry_00"].weight = (float)0;
		this.Character.animation.Play("f02_mopCarry_00");
		this.Character.animation["f02_bucketCarry_00"].layer = 7;
		this.Character.animation["f02_bucketCarry_00"].weight = (float)0;
		this.Character.animation.Play("f02_bucketCarry_00");
		this.Character.animation["f02_cameraPose_00"].layer = 8;
		this.Character.animation["f02_cameraPose_00"].weight = (float)0;
		this.Character.animation.Play("f02_cameraPose_00");
		this.Character.animation["f02_dipping_00"].speed = (float)2;
		this.Character.animation["f02_stripping_00"].speed = 1.5f;
	}
}
