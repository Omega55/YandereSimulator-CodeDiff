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
	internal sealed class $ApplyCustomCostume$850 : GenericGenerator<WWW>
	{
		internal YandereScript $self_$857;

		public $ApplyCustomCostume$850(YandereScript self_)
		{
			this.$self_$857 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new YandereScript.$ApplyCustomCostume$850.$(this.$self_$857);
		}
	}

	private Quaternion targetRotation;

	private Vector3 targetDirection;

	private GameObject NewDumpChan;

	private GameObject NewTrail;

	private int ID;

	public FootprintSpawnerScript RightFootprintSpawner;

	public FootprintSpawnerScript LeftFootprintSpawner;

	public ColorCorrectionCurves YandereColorCorrection;

	public ColorCorrectionCurves ColorCorrection;

	public HighlightingRenderer HighlightingR;

	public HighlightingBlitter HighlightingB;

	public AmbientObscurance Obscurance;

	public DepthOfField34 DepthOfField;

	public Vignetting Vignette;

	public NotificationManagerScript NotificationManager;

	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public WeaponManagerScript WeaponManager;

	public SWP_HeartRateMonitor HeartRate;

	public IncineratorScript Incinerator;

	public PauseScreenScript PauseScreen;

	public StudentScript TargetStudent;

	public WeaponMenuScript WeaponMenu;

	public PromptScript NearestPrompt;

	public SubtitleScript Subtitle;

	public OutlineScript Outline;

	public RPG_Camera RPGCamera;

	public BucketScript Bucket;

	public PickUpScript PickUp;

	public PoliceScript Police;

	public MopScript Mop;

	public SpringJoint RagdollDragger;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform ItemParent;

	public Transform PelvisRoot;

	public Transform Homeroom;

	public Transform Ponytail;

	public Transform Senpai;

	public Transform HairR;

	public Transform HairL;

	public Transform Head;

	public Transform Eyes;

	public AudioSource HeartBeat;

	public AudioSource Jukebox;

	public GameObject Smartphone;

	public GameObject Character;

	public GameObject EyepatchL;

	public GameObject EyepatchR;

	public GameObject DumpChan;

	public GameObject Ragdoll;

	public GameObject Hearts;

	public GameObject Phone;

	public GameObject Trail;

	public GameObject Toast;

	public GameObject Toaster;

	public SkinnedMeshRenderer MyRenderer;

	public Projector MyProjector;

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

	public bool Crouching;

	public bool Attacking;

	public bool Crawling;

	public bool Dragging;

	public bool Laughing;

	public bool Throwing;

	public bool Dipping;

	public bool Dumping;

	public bool Mopping;

	public bool Talking;

	public bool Aiming;

	public bool UsingController;

	public bool YandereVision;

	public bool Heartbroken;

	public bool NearSenpai;

	public bool HidePony;

	public bool CanMove;

	public bool Armed;

	public bool Die;

	public Texture[] BloodTextures;

	public WeaponScript[] Weapon;

	public string[] CarryAnims;

	public Transform[] Spine;

	public Transform[] Arm;

	public Renderer RightYandereEye;

	public Renderer LeftYandereEye;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Transform RightEye;

	public Transform LeftEye;

	public float EyeShrink;

	public Vector3 Twitch;

	private AudioClip LaughClip;

	public string LaughAnim;

	public AudioClip Laugh1;

	public AudioClip Laugh2;

	public AudioClip Laugh3;

	public AudioClip Laugh4;

	public bool AoT;

	public Texture TitanTexture;

	public Texture FaceTexture;

	public Texture KONTexture;

	public Mesh KONMesh;

	public GameObject PunishedAccessories;

	public GameObject PunishedScarf;

	public Texture PunishedYandere;

	public YandereScript()
	{
		this.Sanity = 100f;
		this.CanMove = true;
		this.LaughAnim = string.Empty;
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
		this.PunishedAccessories.active = false;
		this.PunishedScarf.active = false;
		this.Smartphone.active = false;
		this.EyepatchL.active = false;
		this.EyepatchR.active = false;
		this.PigtailL.active = false;
		this.PigtailR.active = false;
		this.Toaster.active = false;
		this.Drills.active = false;
		this.Toast.active = false;
		this.UpdateHair();
	}

	public virtual void Update()
	{
		if (this.CanMove)
		{
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
							this.transform.Translate(Vector3.forward * this.RunSpeed * Time.deltaTime);
						}
						else
						{
							this.Character.animation.CrossFade("f02_dragWalk_00");
							this.transform.Translate(Vector3.forward * this.WalkSpeed * Time.deltaTime);
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
							this.transform.Translate(Vector3.forward * this.CrawlSpeed * Time.deltaTime);
						}
						else if (this.Crouching)
						{
							this.Character.animation.CrossFade("f02_crouchWalk_00");
							this.transform.Translate(Vector3.forward * this.CrouchSpeed * Time.deltaTime);
						}
						else
						{
							this.Character.animation.CrossFade("f02_walk_00");
							this.transform.Translate(Vector3.forward * this.WalkSpeed * Time.deltaTime);
						}
					}
					else
					{
						this.Character.animation.CrossFade("f02_dragWalk_00");
						this.transform.Translate(Vector3.forward * this.WalkSpeed * Time.deltaTime);
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
						this.Character.animation.CrossFade("f02_idleShort_00");
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
						this.transform.Translate(Vector3.forward * this.CrawlSpeed * Time.deltaTime * axis);
						this.transform.Translate(Vector3.right * this.CrawlSpeed * Time.deltaTime * axis2);
					}
					else if (this.Crouching)
					{
						this.Character.animation.CrossFade("f02_crouchWalk_00");
						this.transform.Translate(Vector3.forward * this.CrouchSpeed * Time.deltaTime * axis);
						this.transform.Translate(Vector3.right * this.CrouchSpeed * Time.deltaTime * axis2);
					}
					else
					{
						this.Character.animation.CrossFade("f02_walk_00");
						this.transform.Translate(Vector3.forward * this.WalkSpeed * Time.deltaTime * axis);
						this.transform.Translate(Vector3.right * this.WalkSpeed * Time.deltaTime * axis2);
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
					this.Character.animation.CrossFade("f02_idleShort_00");
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
						this.Character.animation.Play("f02_idleShort_00");
						this.ShoulderCamera.AimingCamera = true;
						this.Smartphone.active = true;
						this.Aiming = true;
						this.EmptyHands();
					}
				}
				if (Input.GetButton("RB"))
				{
					this.YandereTimer += Time.deltaTime;
					if (this.YandereTimer > 0.5f)
					{
						this.YandereVision = true;
					}
				}
				if (Input.GetButtonUp("RB"))
				{
					if (this.YandereTimer < 0.5f)
					{
						if (!this.Dragging && !this.Laughing)
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
					}
					else
					{
						this.Obscurance.enabled = false;
						this.YandereVision = false;
					}
					this.YandereTimer = (float)0;
				}
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
						this.Crouching = false;
						this.Crawling = true;
						this.CrawlTimer = (float)0;
					}
				}
			}
			if (this.Aiming)
			{
				this.Character.animation["f02_cameraPose_00"].weight = Mathf.Lerp(this.Character.animation["f02_cameraPose_00"].weight, (float)1, Time.deltaTime * (float)10);
				if ((this.UsingController && Input.GetAxis("LT") < 0.5f) || Input.GetMouseButtonUp(1))
				{
					if (this.Crawling)
					{
						this.Character.animation.Play("f02_crawl_10");
					}
					else if (this.Crouching)
					{
						this.Character.animation.Play("f02_crouchIdle_00");
					}
					this.Character.animation["f02_cameraPose_00"].weight = (float)0;
					int num2 = 0;
					Vector3 localPosition = this.PelvisRoot.transform.localPosition;
					float num3 = localPosition.y = (float)num2;
					Vector3 vector2 = this.PelvisRoot.transform.localPosition = localPosition;
					this.ShoulderCamera.AimingCamera = false;
					this.RPGCamera.UpdateRotation();
					this.RPGCamera.mouseSmoothingFactor = (float)0;
					this.RPGCamera.GetInput();
					this.RPGCamera.GetDesiredPosition();
					this.RPGCamera.PositionUpdate();
					this.RPGCamera.mouseSmoothingFactor = 0.08f;
					this.Smartphone.active = false;
					this.RPGCamera.enabled = true;
					this.UsingController = false;
					this.Aiming = false;
					this.Height = (float)0;
					this.Bend = (float)0;
				}
			}
		}
		else
		{
			if (this.Dumping)
			{
				this.targetRotation = Quaternion.LookRotation(this.Incinerator.transform.position + Vector3.fwd * (float)4 - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
				this.transform.position = Vector3.Lerp(this.transform.position, this.Incinerator.transform.position + Vector3.fwd * (float)3, Time.deltaTime * (float)10);
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
				this.Sanity += Time.deltaTime * 0.17f;
				this.UpdateSanity();
			}
			if (this.Heartbroken && this.Character.animation["f02_down_22"].time >= this.Character.animation["f02_down_22"].length)
			{
				this.Character.animation.CrossFade("f02_down_23");
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
			if (Input.GetButtonUp("A"))
			{
				this.Mopping = false;
			}
		}
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
		if (this.Die)
		{
			this.Character.animation.CrossFade("f02_down_22");
			this.Heartbroken = true;
			this.CanMove = false;
			this.Die = false;
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
		if (Vector3.Distance(this.transform.position, this.Senpai.position) < (float)2)
		{
			if (!this.NearSenpai)
			{
				this.DepthOfField.focalSize = (float)150;
				this.NearSenpai = true;
			}
			this.Obscurance.enabled = false;
			this.Obscurance.enabled = false;
			this.YandereVision = false;
			this.Mopping = false;
			this.Crouching = false;
			this.Crawling = false;
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
		}
		else
		{
			this.NearSenpai = false;
		}
		if (this.NearSenpai)
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
				Time.timeScale = Mathf.Lerp(Time.timeScale, (float)1, 0.166666672f);
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
		float num4 = color.a = a3;
		Color color2 = this.RightYandereEye.material.color = color;
		float a4 = (float)1 - this.YandereFade / (float)100;
		Color color3 = this.LeftYandereEye.material.color;
		float num5 = color3.a = a4;
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
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
			if (this.Interaction == 0)
			{
				this.Character.animation.CrossFade("f02_idleShort_00");
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
				}
				else
				{
					if (this.Character.animation["f02_greet_00"].time >= this.Character.animation["f02_greet_00"].length)
					{
						this.Character.animation.CrossFade("f02_idleShort_00");
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
						this.Character.animation.CrossFade("f02_idleShort_00");
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
		}
		if (this.Attacking)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
			if (this.AttackPhase == 1)
			{
				this.Character.animation.CrossFade("f02_stab_00");
				if (this.Character.animation["f02_stab_00"].time > this.Character.animation["f02_stab_00"].length * 0.4f)
				{
					this.Character.animation.CrossFade("f02_idleShort_00");
					this.TargetStudent.BloodSpray.active = true;
					this.TargetStudent.Dead = true;
					this.Police.Corpses = this.Police.Corpses + 1;
					this.Bloodiness += (float)20;
					this.AttackPhase = 2;
					this.Sanity -= (float)20;
					this.UpdateSanity();
					this.UpdateBlood();
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
					this.Attacking = false;
					this.AttackPhase = 1;
					this.AttackTimer = (float)0;
					this.CanMove = true;
				}
			}
		}
		if (!this.Attacking && !this.Dragging && this.PickUp == null && !this.Aiming && !this.Crawling)
		{
			this.Character.animation["f02_yanderePose_00"].weight = Mathf.Lerp(this.Character.animation["f02_yanderePose_00"].weight, (float)1 - this.Sanity / (float)100, Time.deltaTime * (float)10);
			this.Slouch = Mathf.Lerp(this.Slouch, (float)5 * ((float)1 - this.Sanity / (float)100), Time.deltaTime * (float)10);
		}
		else
		{
			this.Character.animation["f02_yanderePose_00"].weight = Mathf.Lerp(this.Character.animation["f02_yanderePose_00"].weight, (float)0, Time.deltaTime * (float)10);
			this.Slouch = Mathf.Lerp(this.Slouch, (float)0, Time.deltaTime * (float)10);
		}
		this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1 - this.Sanity / (float)100, Time.deltaTime * (float)10);
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
		if (this.transform.position.y < (float)-1 || Input.GetKeyDown("`"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown("escape"))
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
			if (!this.Toast.active && !this.Toaster.active)
			{
				this.Toast.active = true;
			}
			else if (this.Toast.active && !this.Toaster.active)
			{
				this.Toast.active = false;
				this.Toaster.active = true;
			}
			else
			{
				this.Toast.active = false;
				this.Toaster.active = false;
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
			if (this.BreastSize < (float)0)
			{
				this.BreastSize = (float)0;
			}
		}
		if (Input.GetKeyDown("l") && !this.AoT)
		{
			this.StudentManager.AttackOnTitan();
			this.AttackOnTitan();
		}
		if (Input.GetKeyDown("k"))
		{
			this.Punish();
		}
		if (this.transform.position.z < (float)-50)
		{
			int num6 = -50;
			Vector3 position = this.transform.position;
			float num7 = position.z = (float)num6;
			Vector3 vector3 = this.transform.position = position;
		}
		if (this.rigidbody.velocity.y > (float)0)
		{
			int num8 = 0;
			Vector3 velocity = this.rigidbody.velocity;
			float num9 = velocity.y = (float)num8;
			Vector3 vector4 = this.rigidbody.velocity = velocity;
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
		this.Head.localEulerAngles = this.Head.localEulerAngles + this.Twitch;
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
		((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).Dump();
	}

	public virtual void Unequip()
	{
		if (this.CanMove)
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
		this.Unequip();
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
		return new YandereScript.$ApplyCustomCostume$850(this).GetEnumerator();
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
		this.MyRenderer.materials[0].mainTexture = this.TitanTexture;
		this.AoT = true;
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
		this.PunishedAccessories.active = true;
		this.PunishedScarf.active = true;
		this.EyepatchL.active = false;
		this.EyepatchR.active = false;
		this.Toast.active = false;
		this.Toaster.active = false;
		this.MyRenderer.materials[1].mainTexture = this.PunishedYandere;
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
	}
}
