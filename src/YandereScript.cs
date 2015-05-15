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
	internal sealed class $ApplyCustomCostume$1272 : GenericGenerator<WWW>
	{
		internal YandereScript $self_$1279;

		public $ApplyCustomCostume$1272(YandereScript self_)
		{
			this.$self_$1279 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new YandereScript.$ApplyCustomCostume$1272.$(this.$self_$1279);
		}
	}

	private Quaternion targetRotation;

	private Vector3 targetDirection;

	private GameObject NewDumpChan;

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

	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public WeaponManagerScript WeaponManager;

	public CharacterScript BaldSchoolgirl;

	public SWP_HeartRateMonitor HeartRate;

	public IncineratorScript Incinerator;

	public PauseScreenScript PauseScreen;

	public StudentScript TargetStudent;

	public WeaponMenuScript WeaponMenu;

	public PromptScript NearestPrompt;

	public TranqCaseScript TranqCase;

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

	public Transform Eyes;

	public Transform Head;

	public Transform Hips;

	public AudioSource HeartBeat;

	public GameObject CinematicCamera;

	public GameObject HandCamera;

	public GameObject Character;

	public GameObject EyepatchL;

	public GameObject EyepatchR;

	public GameObject DumpChan;

	public GameObject ShoePair;

	public GameObject Ragdoll;

	public GameObject Hearts;

	public GameObject Phone;

	public GameObject Trail;

	public GameObject[] Accessories;

	public GameObject[] Shoes;

	public SkinnedMeshRenderer MyRenderer;

	public SpringJoint RagdollDragger;

	public Projector MyProjector;

	public Camera MainCamera;

	public Camera Smartphone;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public float YandereTimer;

	public float AttackTimer;

	public float CrawlTimer;

	public float LaughTimer;

	public float DumpTimer;

	public float TalkTimer;

	public float Bloodiness;

	public float Sanity;

	public float TwitchFactor;

	public float TwitchTimer;

	public float NextTwitch;

	public float CinematicTimer;

	public float LaughIntensity;

	public float TargetHeight;

	public float BreastSize;

	public float RunSpeed;

	public float Height;

	public float Slouch;

	public float Bend;

	public float CrouchSpeed;

	public float CrawlSpeed;

	public float WalkSpeed;

	public float YandereFade;

	public float YandereTint;

	public float SenpaiFade;

	public float SenpaiTint;

	public int CarryAnimID;

	public int AttackPhase;

	public int Interaction;

	public int NearBodies;

	public int Hairstyle;

	public int Equipped;

	public int Costume;

	public bool BloodyWarning;

	public bool CorpseWarning;

	public bool SanityWarning;

	public bool WeaponWarning;

	public bool TimeSkipping;

	public bool Trespassing;

	public bool Crouching;

	public bool Attacking;

	public bool Crawling;

	public bool Dragging;

	public bool Laughing;

	public bool RoofPush;

	public bool Throwing;

	public bool Dipping;

	public bool Dumping;

	public bool Mopping;

	public bool Talking;

	public bool Aiming;

	public bool UsingController;

	public bool YandereVision;

	public bool PossessTranq;

	public bool NearSenpai;

	public bool CanTranq;

	public bool Collapse;

	public bool HidePony;

	public bool Noticed;

	public bool InClass;

	public bool CanMove;

	public bool Chased;

	public bool Armed;

	public bool Lewd;

	public bool Egg;

	public Texture[] BloodTextures;

	public WeaponScript[] Weapon;

	public string[] CarryAnims;

	public Transform[] Spine;

	public Transform[] Arm;

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

	public string LaughAnim;

	public string IdleAnim;

	public AudioClip Laugh1;

	public AudioClip Laugh2;

	public AudioClip Laugh3;

	public AudioClip Laugh4;

	public Texture TitanTexture;

	public Texture FaceTexture;

	public Texture KONTexture;

	public Mesh KONMesh;

	public GameObject PunishedAccessories;

	public GameObject PunishedScarf;

	public Texture[] PunishedTextures;

	public Shader PunishedShader;

	public Mesh PunishedMesh;

	public Material HatefulSkybox;

	public GameObject SukebanAccessories;

	public Texture SukebanBandages;

	public Texture SukebanUniform;

	public YandereScript()
	{
		this.Sanity = 100f;
		this.CanMove = true;
		this.LaughAnim = string.Empty;
		this.IdleAnim = string.Empty;
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
		this.StartCoroutine_Auto(this.ApplyCustomCostume());
		this.Smartphone.transform.parent.active = false;
		this.PunishedAccessories.active = false;
		this.SukebanAccessories.active = false;
		this.BaldSchoolgirl.active = false;
		this.PunishedScarf.active = false;
		this.EyepatchL.active = false;
		this.EyepatchR.active = false;
		this.PigtailL.active = false;
		this.PigtailR.active = false;
		this.Shoes[0].active = false;
		this.Shoes[1].active = false;
		this.Drills.active = false;
		this.IdleAnim = "f02_idleShort_00";
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.Accessories))
		{
			this.Accessories[this.ID].active = false;
			this.ID++;
		}
		this.UpdateHair();
	}

	public virtual void Update()
	{
		if (!this.PauseScreen.Show)
		{
			if (this.CanMove)
			{
				this.MyController.Move(Physics.gravity * 0.1f);
				float axis = Input.GetAxis("Vertical");
				float axis2 = Input.GetAxis("Horizontal");
				if (!this.Aiming)
				{
					Vector3 a = Camera.main.transform.TransformDirection(Vector3.forward);
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
								this.Character.animation.CrossFade("f02_sprint_00");
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
								this.Character.animation.CrossFade("f02_walk_00");
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
							this.Character.animation.CrossFade("f02_walk_00");
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
					if (Input.GetAxis("LT") > 0.5f || Input.GetMouseButtonDown(1))
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
							this.Aiming = true;
							this.EmptyHands();
							Time.timeScale = (float)1;
						}
					}
					if (!this.Aiming && !this.Crouching && !this.Crawling)
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
								this.LaughAnim = "f02_laugh_01";
								this.LaughClip = this.Laugh1;
								this.Laughing = true;
								this.LaughIntensity += (float)1;
								this.LaughTimer = 0.5f;
								this.audio.volume = (float)1;
								this.audio.time = (float)0;
								this.audio.Play();
								this.CanMove = false;
							}
							this.YandereTimer = (float)0;
						}
					}
					if (!Input.GetButton("LB"))
					{
						if (Input.GetButtonDown("RS"))
						{
							this.CrawlTimer = (float)0;
							if (this.Crawling)
							{
								this.Crawling = false;
							}
							else if (this.Crouching)
							{
								this.Crouching = false;
							}
							else
							{
								this.Obscurance.enabled = false;
								this.YandereVision = false;
								this.Crouching = true;
								this.EmptyHands();
							}
						}
						if (Input.GetButton("RS"))
						{
							this.CrawlTimer += Time.deltaTime;
							if (this.CrawlTimer > 0.5f)
							{
								this.EmptyHands();
								this.Obscurance.enabled = false;
								this.YandereVision = false;
								this.Crouching = false;
								this.Crawling = true;
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
					if (Input.GetAxis("RT") != (float)0 || Input.GetMouseButtonDown(0))
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
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Bucket.transform.position.x, this.transform.position.y, this.Bucket.transform.position.z) - this.transform.position);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
					this.Character.animation.CrossFade("f02_dipping_00");
					if (this.Character.animation["f02_dipping_00"].time >= this.Character.animation["f02_dipping_00"].length * 0.5f && this.Mop.Bloodiness > (float)0)
					{
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
				if (this.Laughing)
				{
					if (this.audio.clip != this.LaughClip)
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
							this.LaughAnim = "f02_laugh_04";
							this.LaughClip = this.Laugh4;
							this.LaughTimer = (float)2;
						}
						else
						{
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
						this.LaughIntensity = (float)0;
						this.Laughing = false;
						this.LaughClip = null;
						this.CanMove = true;
					}
				}
				if (this.TimeSkipping)
				{
					this.Character.animation.CrossFade("f02_timeSkip_00");
					this.MyController.Move(this.transform.up * 0.0001f);
					this.Sanity += Time.deltaTime * 0.17f;
					this.UpdateSanity();
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
					if (this.PickUp != null && this.CarryAnimID == this.ID && !this.Mopping && !this.Dipping)
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
				this.Character.animation["f02_shy_00"].weight = this.SenpaiTint;
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
			float a3 = (float)1 - this.YandereFade / (float)100;
			Color color = this.RightYandereEye.material.color;
			float num3 = color.a = a3;
			Color color2 = this.RightYandereEye.material.color = color;
			float a4 = (float)1 - this.YandereFade / (float)100;
			Color color3 = this.LeftYandereEye.material.color;
			float num4 = color3.a = a4;
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
				else if (this.Interaction == 4)
				{
					if (this.TalkTimer == (float)2)
					{
						this.Character.animation.CrossFade("f02_greet_00");
						this.Subtitle.UpdateLabel("Player Farewell", 0, (float)2);
					}
					else
					{
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
				else if (this.Interaction == 9)
				{
					if (this.TalkTimer == (float)3)
					{
						this.Character.animation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel("Player Follow", 0, (float)3);
					}
					else
					{
						if (this.Character.animation["f02_greet_00"].time >= this.Character.animation["f02_greet_01"].length)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= (float)0)
						{
							this.TargetStudent.Interaction = 9;
							this.TargetStudent.TalkTimer = (float)2;
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
				if (this.RoofPush)
				{
					this.MoveTowardsTarget(this.TargetStudent.transform.position + this.TargetStudent.transform.forward * (float)-1);
					this.Character.animation.CrossFade("f02_roofPushA_00");
					if (this.Character.animation["f02_roofPushA_00"].time > 4.33333349f)
					{
						if (this.Shoes[0].active)
						{
							GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.ShoePair, this.transform.position + new Vector3((float)0, 0.045f, -1.6f), Quaternion.identity);
							float y3 = gameObject.transform.eulerAngles.y + (float)180;
							Vector3 eulerAngles2 = gameObject.transform.eulerAngles;
							float num5 = eulerAngles2.y = y3;
							Vector3 vector3 = gameObject.transform.eulerAngles = eulerAngles2;
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
						this.Police.CorpseList[this.Police.Corpses] = this.TargetStudent.Ragdoll;
						this.Police.Corpses = this.Police.Corpses + 1;
						this.Attacking = false;
						this.RoofPush = false;
						this.CanMove = true;
						this.Sanity -= (float)20;
					}
				}
				else if (!this.TargetStudent.Teacher)
				{
					if (this.AttackPhase == 1)
					{
						this.Character.animation.CrossFade("f02_stab_00");
						if (this.Character.animation["f02_stab_00"].time > this.Character.animation["f02_stab_00"].length * 0.4f)
						{
							this.Character.animation.CrossFade(this.IdleAnim);
							if (this.CanTranq && this.Weapon[this.Equipped].WeaponID == 3 && this.PossessTranq && PlayerPrefs.GetInt("BiologyGrade") > 1)
							{
								this.TargetStudent.Tranquil = true;
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
							this.Police.CorpseList[this.Police.Corpses] = this.TargetStudent.Ragdoll;
							this.TargetStudent.Dead = true;
							this.Police.Corpses = this.Police.Corpses + 1;
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
							this.CanMove = true;
						}
					}
				}
				else
				{
					this.Character.animation.CrossFade("f02_counterA_00");
					float y4 = this.TargetStudent.transform.position.y;
					Vector3 position = this.Character.transform.position;
					float num6 = position.y = y4;
					Vector3 vector4 = this.Character.transform.position = position;
				}
			}
			if (!this.Attacking && !this.Dragging && this.PickUp == null && !this.Aiming && !this.Crawling && this.LaughIntensity < (float)16)
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
			if (Input.GetKeyDown("`"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			if (!this.Aiming && Input.GetKeyDown("escape"))
			{
				this.PauseScreen.JumpToQuit();
			}
			if (Input.GetKeyDown("p"))
			{
				if (!this.EyepatchL.active)
				{
					if (!this.EyepatchR.active && !this.EyepatchL.active)
					{
						this.EyepatchR.active = true;
					}
					else if (this.EyepatchR.active && !this.EyepatchL.active)
					{
						this.EyepatchR.active = false;
						this.EyepatchL.active = true;
					}
				}
				else if (!this.EyepatchR.active)
				{
					this.EyepatchR.active = true;
				}
				else
				{
					this.EyepatchR.active = false;
					this.EyepatchL.active = false;
				}
			}
			if (Input.GetKeyDown("h"))
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
				Time.timeScale -= (float)10;
			}
			if (Input.GetKeyDown("="))
			{
				Time.timeScale += (float)10;
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
			if (this.CanMove)
			{
				if (Input.GetKeyDown("l") && !this.Egg)
				{
					this.StudentManager.AttackOnTitan();
					this.AttackOnTitan();
				}
				if (Input.GetKeyDown("k") && !this.Egg)
				{
					this.Punish();
				}
				if (Input.GetKeyDown("j") && !this.Egg)
				{
					this.EmptyHands();
					this.Hate();
				}
				if (Input.GetKeyDown("g") && !this.Egg)
				{
					this.Sukeban();
				}
			}
			if (Input.GetKeyDown("left alt"))
			{
				this.CinematicCamera.active = false;
			}
			if (this.transform.position.x < (float)-50)
			{
				int num7 = -50;
				Vector3 position2 = this.transform.position;
				float num8 = position2.x = (float)num7;
				Vector3 vector5 = this.transform.position = position2;
			}
			if (this.transform.position.x > (float)100)
			{
				int num9 = 100;
				Vector3 position3 = this.transform.position;
				float num10 = position3.x = (float)num9;
				Vector3 vector6 = this.transform.position = position3;
			}
			if (this.transform.position.y < (float)0)
			{
				int num11 = 0;
				Vector3 position4 = this.transform.position;
				float num12 = position4.y = (float)num11;
				Vector3 vector7 = this.transform.position = position4;
			}
			if (this.transform.position.z < -49.5f)
			{
				float z = -49.5f;
				Vector3 position5 = this.transform.position;
				float num13 = position5.z = z;
				Vector3 vector8 = this.transform.position = position5;
			}
			if (this.transform.position.z > (float)50)
			{
				int num14 = 50;
				Vector3 position6 = this.transform.position;
				float num15 = position6.z = (float)num14;
				Vector3 vector9 = this.transform.position = position6;
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
		if (this.HidePony)
		{
			this.Ponytail.parent.transform.localScale = new Vector3((float)1, (float)1, 0.93f);
			this.Ponytail.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairR.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairL.localScale = new Vector3((float)0, (float)0, (float)0);
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
		if (this.BaldSchoolgirl.active)
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
		}
		else
		{
			this.HeartRate.SetHeartRateColour(this.HeartRate.BadColour);
			if (!this.SanityWarning)
			{
				this.NotificationManager.DisplayNotification("Insane");
				this.SanityWarning = true;
			}
			this.StudentManager.UpdateStudents();
		}
		this.HeartRate.BeatsPerMinute = (int)((float)240 - this.Sanity * 1.8f);
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
		this.Outline.h.ReinitMaterials();
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)" && other.transform.localScale.x > 0.3f)
		{
			this.RightFootprintSpawner.Bloodiness = 5;
			this.LeftFootprintSpawner.Bloodiness = 5;
		}
	}

	public virtual void ChangeCostume()
	{
		if (this.Costume == 0)
		{
			this.Costume = 1;
		}
		else
		{
			this.Costume = 0;
		}
	}

	public virtual IEnumerator ApplyCustomCostume()
	{
		return new YandereScript.$ApplyCustomCostume$1272(this).GetEnumerator();
	}

	public virtual void UpdateHair()
	{
		this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailR.active = false;
		this.PigtailL.active = false;
		this.Drills.active = false;
		this.HidePony = true;
		this.Hairstyle++;
		if (this.Hairstyle > 7)
		{
			this.Hairstyle = 1;
		}
		if (this.Hairstyle == 1)
		{
			this.HidePony = false;
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
	}

	public virtual void AttackOnTitan()
	{
		this.Egg = true;
		this.MyRenderer.materials[0].mainTexture = this.TitanTexture;
		this.Outline.h.ReinitMaterials();
	}

	public virtual void KON()
	{
		this.MyRenderer.sharedMesh = this.KONMesh;
		this.MyRenderer.materials[0].mainTexture = this.KONTexture;
		this.MyRenderer.materials[1].mainTexture = this.KONTexture;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.Outline.h.ReinitMaterials();
	}

	public virtual void Punish()
	{
		this.PunishedShader = Shader.Find("Toon/Cutoff");
		this.Egg = true;
		this.PunishedAccessories.active = true;
		this.PunishedScarf.active = true;
		this.EyepatchL.active = false;
		this.EyepatchR.active = false;
		this.ID = 1;
		while (this.ID < this.Accessories.Length)
		{
			this.Accessories[this.ID].active = false;
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
		this.Sanity = (float)0;
		this.BaldSchoolgirl.active = true;
		this.Character.active = false;
		this.HeartRate.active = false;
		this.SelectGrayscale.enabled = true;
		this.Egg = true;
		this.Character = this.BaldSchoolgirl.gameObject;
		this.RightBreast = this.BaldSchoolgirl.RightBreast;
		this.LeftBreast = this.BaldSchoolgirl.LeftBreast;
		this.ItemParent = this.BaldSchoolgirl.ItemParent;
		this.PelvisRoot = this.BaldSchoolgirl.PelvisRoot;
		this.RightEye = this.BaldSchoolgirl.RightEye;
		this.LeftEye = this.BaldSchoolgirl.LeftEye;
		this.Head = this.BaldSchoolgirl.Head;
		this.Spine = this.BaldSchoolgirl.Spine;
		this.Arm = this.BaldSchoolgirl.Arm;
		this.MyRenderer = this.BaldSchoolgirl.MyRenderer;
		this.RightYandereEye = this.BaldSchoolgirl.RightYandereEye;
		this.LeftYandereEye = this.BaldSchoolgirl.LeftYandereEye;
		this.BaldSchoolgirl.SetAnimations();
		this.RagdollDragger.transform.parent = this.ItemParent;
		this.RagdollDragger.transform.localPosition = new Vector3((float)0, -0.05f, (float)0);
		this.RagdollDragger.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		this.Phone.transform.parent = this.ItemParent;
		this.Phone.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
		this.Phone.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		this.Smartphone.transform.parent.transform.parent = this.ItemParent;
		this.Smartphone.transform.parent.transform.localPosition = new Vector3(0.0674861f, -0.05341353f, 0.02418186f);
		this.Smartphone.transform.parent.transform.localEulerAngles = new Vector3(5.147979f, -179.7696f, 47.9222f);
		this.CameraFocus.parent = this.Spine[3];
		this.CameraPOV.parent = this.Spine[3];
	}

	public virtual void Sukeban()
	{
		this.IdleAnim = "f02_idle_00";
		this.SukebanAccessories.active = true;
		this.MyRenderer.materials[2].mainTexture = this.SukebanBandages;
		this.MyRenderer.materials[0].mainTexture = this.SukebanUniform;
		this.Egg = true;
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
	}
}
