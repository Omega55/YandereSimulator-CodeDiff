using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class YandereScript : MonoBehaviour
{
	public ControllerInventoryScript ControllerInventory;

	public FirstPersonYandereScript FirstPersonYandere;

	public StudentManagerScript StudentManager;

	public YandereVisionScript YandereVision;

	public CaseDropAreaScript CaseDropArea;

	public SenpaiPhotosScript SenpaiPhotos;

	public RPG_Camera MainCamera;

	public Transform CameraPivot;

	public Camera MainCameraCam;

	public Transform Eyes;

	public Transform DumpingPoint;

	public Transform CoverHitbox;

	public Transform BackPack;

	public GameObject CellPhoneGroup;

	public GameObject Character;

	public GameObject DumpChan;

	public Collider MyCollider;

	public float PivotHeight;

	public float EyeHeight;

	public float WalkSpeed;

	public float RunSpeed;

	public int InputNSFW;

	public int FacingNESW;

	public int SidleDirection;

	public bool Attacking;

	public bool Crouching;

	public bool Dragging;

	public bool Laughing;

	public bool Dumping;

	public bool Sidling;

	public bool FirstPersonMode;

	public bool AcceptingInput;

	public bool ResetHeight;

	public bool YandereMode;

	public bool ShortCover;

	public bool CanSidle;

	public bool SnapToZ;

	public Quaternion targetRotation;

	public bool Armed;

	public float ArmRotation;

	public Transform RightArm;

	public Transform RightArmRoll;

	public Transform RightForeArm;

	public Transform RightForeArmRoll;

	public Transform RightHand;

	public Transform Hips;

	public string EquippedName;

	public int EquippedSize;

	public int EquippedType;

	public int EquippedID;

	public string Item1Name;

	public int Item1Type;

	public int Item1ID;

	public string Item2Name;

	public int Item2Type;

	public int Item2ID;

	public string Item3Name;

	public int Item3Type;

	public int Item3ID;

	public GameObject Item3;

	public GameObject[] Weapons;

	public GameObject[] BodyParts;

	public GameObject[] WeaponPickups;

	public GameObject[] BodyPartPickups;

	public GameObject NearestRagdoll;

	public GameObject NearestPickup;

	public GameObject NearestPickupA;

	public StudentScript NearestStudent;

	public LimbScript GrabbedLimb;

	public MopScript Mop;

	private int ID;

	public Transform RightBreast;

	public Transform LeftBreast;

	public float BreastSize;

	public float AttackCooldownTimer;

	public float YandereTimer;

	public float AttackTimer;

	public float LaughTimer;

	public float LaughIntensity;

	public float YandereMeter;

	private AudioClip LaughClip;

	public string LaughAnim;

	public AudioClip Laugh1;

	public AudioClip Laugh2;

	public AudioClip Laugh3;

	public AudioClip Laugh4;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Transform RightEye;

	public Transform LeftEye;

	public Renderer Body;

	public Texture[] BloodyTextures;

	public int Bloodiness;

	public YandereScript()
	{
		this.PivotHeight = 1f;
		this.EyeHeight = 1.4825f;
		this.EquippedName = string.Empty;
		this.Item1Name = string.Empty;
		this.Item2Name = string.Empty;
		this.Item3Name = string.Empty;
		this.BreastSize = 1f;
		this.LaughAnim = string.Empty;
	}

	public virtual void Start()
	{
		this.MainCameraCam = Camera.main;
		this.CellPhoneGroup.active = false;
		Physics.IgnoreLayerCollision(this.gameObject.layer, 10);
		this.Character.animation["clenchFist"].layer = 1;
		this.Character.animation.Play("clenchFist");
		this.Character.animation["clenchFist"].weight = (float)0;
		this.Character.animation["straightenArm"].layer = 2;
		this.Character.animation.Play("straightenArm");
		this.Character.animation["straightenArm"].weight = (float)0;
		this.Character.animation["dragWalk"].layer = 3;
		this.Character.animation.Play("dragWalk");
		this.Character.animation["dragWalk"].weight = (float)0;
		this.Character.animation["dragWalk"].speed = (float)-1;
		this.Character.animation["turn"].layer = 4;
		this.Character.animation.Play("turn");
		this.Character.animation["turn"].weight = (float)0;
		this.Character.animation["Smile"].layer = 5;
		this.Character.animation.Play("Smile");
		this.Character.animation["Smile"].weight = (float)0;
		this.Character.animation["carryBig"].layer = 6;
		this.Character.animation.Play("carryBig");
		this.Character.animation["carryBig"].weight = (float)0;
		this.Character.animation["carryMop"].layer = 7;
		this.Character.animation.Play("carryMop");
		this.Character.animation["carryMop"].weight = (float)0;
		while (this.ID < 10)
		{
			if (this.Weapons[this.ID] != null)
			{
				this.Weapons[this.ID].active = false;
			}
			this.ID++;
		}
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
	}

	public virtual void Update()
	{
		if (this.AcceptingInput)
		{
			if (Input.GetButtonDown("Start"))
			{
				if (Time.timeScale > (float)0)
				{
					Time.timeScale = (float)0;
					this.MainCamera.enabled = false;
					Screen.lockCursor = false;
					Screen.showCursor = true;
				}
				else
				{
					Time.timeScale = (float)1;
					this.MainCamera.enabled = true;
					Screen.lockCursor = true;
					Screen.showCursor = false;
				}
			}
			if (Input.GetButtonDown("X") && this.NearestStudent != null && !this.NearestStudent.Dying && !this.Attacking && this.AttackCooldownTimer <= (float)0 && this.EquippedID > 0)
			{
				this.NearestStudent.StartDying();
				this.AttackCooldownTimer = (float)1;
				this.Attacking = true;
				this.YandereMeter += (float)20;
			}
			if (Input.GetButtonDown("A") && this.YandereMode && this.SenpaiPhotos.Photos > 0 && this.SenpaiPhotos.Used < 5 && this.YandereMeter > (float)0)
			{
				this.SenpaiPhotos.Used = this.SenpaiPhotos.Used + 1;
				this.SenpaiPhotos.UpdatePhotos();
				this.YandereMeter -= (float)20;
			}
			if (!this.Dumping)
			{
				if (!this.Attacking)
				{
					if (!this.Laughing)
					{
						this.audio.volume = this.audio.volume - Time.deltaTime;
						if (Input.GetAxis("LT") == (float)1 || Input.GetMouseButtonDown(1))
						{
							if (Input.GetAxis("LT") == (float)1)
							{
								PlayerPrefs.SetInt("UsingController", 1);
							}
							else
							{
								PlayerPrefs.SetInt("UsingController", 0);
							}
							this.MainCamera.distanceMin = (float)0;
							this.MainCamera.distanceMax = (float)0;
							this.MainCamera.cameraPivot = this.Eyes;
							this.FirstPersonYandere.active = true;
							this.active = false;
							this.CellPhoneGroup.animation.Play("tPose", PlayMode.StopAll);
							this.CellPhoneGroup.active = true;
							this.FirstPersonYandere.transform.position = this.transform.position + Vector3.up * 0.001f;
							this.FirstPersonYandere.transform.eulerAngles = this.transform.eulerAngles;
							this.FirstPersonYandere.Crouching = this.Crouching;
							if (this.Crouching)
							{
								this.FirstPersonYandere.EyeHeight = this.FirstPersonYandere.CrouchingHeight;
								this.FirstPersonYandere.Crouching = true;
							}
							else
							{
								this.FirstPersonYandere.EyeHeight = this.FirstPersonYandere.StandingHeight;
								this.FirstPersonYandere.Crouching = false;
							}
						}
						if (Input.GetButtonDown("RS"))
						{
							if (!this.Crouching)
							{
								this.Crouch();
							}
							else
							{
								this.StandUp();
							}
						}
						if (Input.GetButton("RB"))
						{
							this.YandereTimer += Time.deltaTime;
						}
						if (this.YandereTimer >= 0.5f && !this.YandereMode)
						{
							this.YandereVision.Activate();
							this.YandereMode = true;
						}
						if (Input.GetButtonUp("RB"))
						{
							if (this.YandereTimer < 0.5f)
							{
								if (!this.Laughing)
								{
									this.LaughAnim = "Laugh1";
									this.LaughClip = this.Laugh1;
									this.Laughing = true;
									this.LaughIntensity += (float)1;
									this.LaughTimer = 0.5f;
									this.audio.volume = (float)1;
									this.audio.time = (float)0;
								}
							}
							else
							{
								this.YandereVision.Deactivate();
								this.YandereMode = false;
							}
							this.YandereTimer = (float)0;
						}
						if (this.Sidling)
						{
							this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, this.CoverHitbox.eulerAngles, Time.deltaTime * (float)10);
							float y = Mathf.Lerp(this.transform.position.y, this.CoverHitbox.position.y - 0.1666667f, Time.deltaTime * (float)10);
							Vector3 position = this.transform.position;
							float num = position.y = y;
							Vector3 vector = this.transform.position = position;
							if (this.SnapToZ)
							{
								float z = Mathf.Lerp(this.transform.position.z, this.CoverHitbox.position.z, Time.deltaTime * (float)10);
								Vector3 position2 = this.transform.position;
								float num2 = position2.z = z;
								Vector3 vector2 = this.transform.position = position2;
							}
							else
							{
								float x = Mathf.Lerp(this.transform.position.x, this.CoverHitbox.position.x, Time.deltaTime * (float)10);
								Vector3 position3 = this.transform.position;
								float num3 = position3.x = x;
								Vector3 vector3 = this.transform.position = position3;
							}
							if (Input.GetButtonDown("B"))
							{
								this.StopSidling();
							}
							this.SidleInputCheck();
						}
						if (this.CanSidle && Input.GetButtonDown("B"))
						{
							if (this.CoverHitbox.eulerAngles.y < (float)1 || this.CoverHitbox.eulerAngles.y > (float)359)
							{
								this.SnapToZ = true;
								this.FacingNESW = 1;
							}
							if (this.CoverHitbox.eulerAngles.y > (float)89 && this.CoverHitbox.eulerAngles.y < (float)91)
							{
								this.SnapToZ = false;
								this.FacingNESW = 2;
							}
							if (this.CoverHitbox.eulerAngles.y > (float)179 && this.CoverHitbox.eulerAngles.y < (float)181)
							{
								this.SnapToZ = true;
								this.FacingNESW = 3;
							}
							else if (this.CoverHitbox.eulerAngles.y > (float)269 && this.CoverHitbox.eulerAngles.y < (float)271)
							{
								this.SnapToZ = false;
								this.FacingNESW = 4;
							}
							RuntimeServices.SetProperty(this.MyCollider, "radius", 0.1666667f);
							this.Character.animation["crouchwalk_10"].speed = (float)1;
							this.rigidbody.useGravity = false;
							this.Sidling = true;
							if (this.ShortCover)
							{
								float num4 = 0.5f;
								object property = UnityRuntimeServices.GetProperty(this.MyCollider, "center");
								RuntimeServices.SetProperty(property, "y", num4);
								UnityRuntimeServices.PropagateValueTypeChanges(new UnityRuntimeServices.ValueTypeChange[]
								{
									new UnityRuntimeServices.MemberValueTypeChange(this.MyCollider, "center", property)
								});
								RuntimeServices.SetProperty(this.MyCollider, "height", 1);
								this.PivotHeight = 0.5f;
								this.EyeHeight = (float)1;
								this.Crouching = true;
							}
						}
						float y2 = Mathf.Lerp(this.CameraPivot.localPosition.y, this.PivotHeight, Time.deltaTime * (float)10);
						Vector3 localPosition = this.CameraPivot.localPosition;
						float num5 = localPosition.y = y2;
						Vector3 vector4 = this.CameraPivot.localPosition = localPosition;
						float y3 = Mathf.Lerp(this.Eyes.localPosition.y, this.EyeHeight, Time.deltaTime * (float)10);
						Vector3 localPosition2 = this.Eyes.localPosition;
						float num6 = localPosition2.y = y3;
						Vector3 vector5 = this.Eyes.localPosition = localPosition2;
						Vector3 a = Camera.main.transform.TransformDirection(Vector3.forward);
						a.y = (float)0;
						a = a.normalized;
						Vector3 a2 = new Vector3(a.z, (float)0, -a.x);
						float axis = Input.GetAxis("Vertical");
						float axis2 = Input.GetAxis("Horizontal");
						Vector3 vector6 = axis2 * a2 + axis * a;
						if (vector6 != Vector3.zero)
						{
							this.targetRotation = Quaternion.LookRotation(vector6);
							if (!this.Sidling)
							{
								this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
							}
						}
						else
						{
							this.targetRotation = new Quaternion((float)0, (float)0, (float)0, (float)0);
						}
						if (axis != (float)0 || axis2 != (float)0)
						{
							if (!this.Sidling)
							{
								if (Input.GetButton("LB"))
								{
									if (!this.Crouching)
									{
										this.Character.animation.CrossFade("f02_sprint_00");
										this.transform.Translate(Vector3.forward * this.RunSpeed * Time.deltaTime);
									}
									else
									{
										this.Character.animation["f02_crawl_10"].speed = 2.5f;
										this.Character.animation.CrossFade("f02_crawl_10");
										this.transform.Translate(Vector3.forward * (this.RunSpeed / (float)2) * Time.deltaTime);
									}
									if (this.GrabbedLimb != null)
									{
										this.GrabbedLimb.Dragging = false;
									}
									this.Dragging = false;
								}
								else if (!this.Dragging)
								{
									if (!this.Crouching)
									{
										this.Character.animation.CrossFade("f02_walk_00");
										this.transform.Translate(Vector3.forward * this.WalkSpeed * Time.deltaTime);
									}
									else
									{
										this.Character.animation["f02_crawl_10"].speed = (float)1;
										this.Character.animation.CrossFade("f02_crawl_10");
										this.transform.Translate(Vector3.forward * (this.WalkSpeed / (float)2) * Time.deltaTime);
									}
								}
								else
								{
									this.Character.animation["dragging"].speed = (float)1;
									this.Character.animation.CrossFade("dragging");
									this.transform.Translate(Vector3.forward * this.WalkSpeed * Time.deltaTime);
									if (this.Character.animation["dragWalk"].weight < (float)1)
									{
										this.Character.animation["dragWalk"].weight = this.Character.animation["dragWalk"].weight + Time.deltaTime * (float)10;
									}
								}
							}
							else if (this.SidleDirection != 0)
							{
								this.transform.Translate(Vector3.right * (float)this.SidleDirection * this.WalkSpeed * Time.deltaTime);
								this.LimitSidleMovement();
								if (this.SidleDirection != 0)
								{
									if (!this.Crouching)
									{
										this.Character.animation.CrossFade("f02_walk_00");
										this.Character.animation.Blend("crouchwalk_10");
										if (this.SidleDirection == 1)
										{
											if (this.Character.transform.localEulerAngles.y != (float)90)
											{
												float y4 = this.Character.transform.localEulerAngles.y + Time.deltaTime * (float)360;
												Vector3 localEulerAngles = this.Character.transform.localEulerAngles;
												float num7 = localEulerAngles.y = y4;
												Vector3 vector7 = this.Character.transform.localEulerAngles = localEulerAngles;
												if (this.Character.transform.localEulerAngles.y > (float)80 && this.Character.transform.localEulerAngles.y < (float)100)
												{
													int num8 = 90;
													Vector3 localEulerAngles2 = this.Character.transform.localEulerAngles;
													float num9 = localEulerAngles2.y = (float)num8;
													Vector3 vector8 = this.Character.transform.localEulerAngles = localEulerAngles2;
												}
											}
										}
										else if (this.Character.transform.localEulerAngles.y != (float)270)
										{
											float y5 = this.Character.transform.localEulerAngles.y - Time.deltaTime * (float)360;
											Vector3 localEulerAngles3 = this.Character.transform.localEulerAngles;
											float num10 = localEulerAngles3.y = y5;
											Vector3 vector9 = this.Character.transform.localEulerAngles = localEulerAngles3;
											if (this.Character.transform.localEulerAngles.y > (float)260 && this.Character.transform.localEulerAngles.y < (float)280)
											{
												int num11 = 270;
												Vector3 localEulerAngles4 = this.Character.transform.localEulerAngles;
												float num12 = localEulerAngles4.y = (float)num11;
												Vector3 vector10 = this.Character.transform.localEulerAngles = localEulerAngles4;
											}
										}
									}
									else
									{
										this.Character.animation.CrossFade("crouchwalk_10");
										if (this.SidleDirection == 1)
										{
											if (this.Character.transform.localEulerAngles.y != (float)90)
											{
												float y6 = this.Character.transform.localEulerAngles.y + Time.deltaTime * (float)360;
												Vector3 localEulerAngles5 = this.Character.transform.localEulerAngles;
												float num13 = localEulerAngles5.y = y6;
												Vector3 vector11 = this.Character.transform.localEulerAngles = localEulerAngles5;
												if (this.Character.transform.localEulerAngles.y > (float)80 && this.Character.transform.localEulerAngles.y < (float)100)
												{
													int num14 = 90;
													Vector3 localEulerAngles6 = this.Character.transform.localEulerAngles;
													float num15 = localEulerAngles6.y = (float)num14;
													Vector3 vector12 = this.Character.transform.localEulerAngles = localEulerAngles6;
												}
											}
										}
										else if (this.Character.transform.localEulerAngles.y != (float)270)
										{
											float y7 = this.Character.transform.localEulerAngles.y - Time.deltaTime * (float)360;
											Vector3 localEulerAngles7 = this.Character.transform.localEulerAngles;
											float num16 = localEulerAngles7.y = y7;
											Vector3 vector13 = this.Character.transform.localEulerAngles = localEulerAngles7;
											if (this.Character.transform.localEulerAngles.y > (float)260 && this.Character.transform.localEulerAngles.y < (float)280)
											{
												int num17 = 270;
												Vector3 localEulerAngles8 = this.Character.transform.localEulerAngles;
												float num18 = localEulerAngles8.y = (float)num17;
												Vector3 vector14 = this.Character.transform.localEulerAngles = localEulerAngles8;
											}
										}
									}
								}
								else if (!this.Crouching)
								{
									this.Character.animation.CrossFade("crossarms_00");
								}
								else
								{
									this.Character.animation.CrossFade("crouchCover");
								}
							}
							else if (!this.Crouching)
							{
								this.Character.animation.CrossFade("crossarms_00");
							}
							else
							{
								this.Character.animation.CrossFade("crouchCover");
							}
						}
						else if (!this.Sidling)
						{
							if (!this.Dragging)
							{
								if (!this.Crouching)
								{
									this.Character.animation.CrossFade("f02_idle_10");
								}
								else
								{
									this.Character.animation.CrossFade("crouchidle_10");
								}
							}
							else
							{
								this.Character.animation.CrossFade("dragging");
								if (this.Character.animation["dragWalk"].weight > (float)0)
								{
									this.Character.animation["dragWalk"].weight = this.Character.animation["dragWalk"].weight - Time.deltaTime * (float)10;
								}
							}
						}
						else
						{
							this.ReturnToDefaultRotation();
							if (!this.Crouching)
							{
								this.Character.animation.CrossFade("crossarms_00");
							}
							else
							{
								this.Character.animation.CrossFade("crouchCover");
							}
						}
						if (this.Sidling)
						{
							this.LimitSidleMovement();
						}
						else
						{
							this.ReturnToDefaultRotation();
						}
						int num19 = 0;
						Vector3 velocity = this.rigidbody.velocity;
						float num20 = velocity.x = (float)num19;
						Vector3 vector15 = this.rigidbody.velocity = velocity;
						int num21 = 0;
						Vector3 velocity2 = this.rigidbody.velocity;
						float num22 = velocity2.z = (float)num21;
						Vector3 vector16 = this.rigidbody.velocity = velocity2;
						if (Input.GetKey("="))
						{
							Time.timeScale += 0.1f;
							this.BreastSize += Time.deltaTime;
							if (this.BreastSize > (float)5)
							{
								this.BreastSize = (float)5;
							}
						}
						if (Input.GetKey("-"))
						{
							Time.timeScale -= 0.1f;
							this.BreastSize -= Time.deltaTime;
							if (this.BreastSize < (float)0)
							{
								this.BreastSize = (float)0;
							}
						}
						if (Input.GetKeyDown("1"))
						{
							Application.LoadLevel(0);
						}
						if (Input.GetKeyDown("2"))
						{
							Application.LoadLevel(1);
						}
						if (Input.GetKeyDown("3"))
						{
							Application.LoadLevel(2);
						}
						if (this.Character.animation["straightenArm"].weight > (float)0)
						{
							this.Character.animation["straightenArm"].weight = this.Character.animation["straightenArm"].weight - Time.deltaTime * (float)5;
							if (this.Character.animation["straightenArm"].weight < (float)0)
							{
								this.Character.animation["straightenArm"].weight = (float)0;
							}
						}
					}
					else
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
								this.LaughAnim = "Laugh1";
								this.LaughClip = this.Laugh1;
								this.LaughTimer = 0.5f;
							}
							else if (this.LaughIntensity <= (float)10)
							{
								this.LaughAnim = "Laugh2";
								this.LaughClip = this.Laugh2;
								this.LaughTimer = (float)1;
							}
							else if (this.LaughIntensity <= (float)15)
							{
								this.LaughAnim = "Laugh3";
								this.LaughClip = this.Laugh3;
								this.LaughTimer = 1.5f;
							}
							else if (this.LaughIntensity <= (float)20)
							{
								this.LaughAnim = "Laugh4";
								this.LaughClip = this.Laugh4;
								this.LaughTimer = (float)2;
							}
							else
							{
								this.LaughAnim = "Laugh4";
								this.LaughIntensity = (float)20;
								this.LaughTimer = (float)2;
							}
						}
						if (this.LaughIntensity > (float)15)
						{
							this.YandereMeter -= Time.deltaTime * (float)10;
							if (this.YandereMeter < (float)0)
							{
								this.YandereMeter = (float)0;
							}
						}
						this.LaughTimer -= Time.deltaTime;
						if (this.LaughTimer <= (float)0)
						{
							this.LaughIntensity = (float)0;
							this.Laughing = false;
							this.LaughClip = null;
						}
					}
				}
				else
				{
					if (this.NearestStudent != null)
					{
						Quaternion to = Quaternion.LookRotation(this.NearestStudent.transform.position - this.transform.position);
						this.transform.rotation = Quaternion.Lerp(this.transform.rotation, to, Time.deltaTime * (float)10);
					}
					this.AttackTimer += Time.deltaTime;
					if (this.AttackTimer > 0.1f)
					{
						this.Character.animation.CrossFade("f02_punch_22");
						if (this.AttackTimer < 0.6f)
						{
							if (this.Character.animation["straightenArm"].weight < (float)1)
							{
								this.Character.animation["straightenArm"].weight = this.Character.animation["straightenArm"].weight + Time.deltaTime * (float)2;
								if (this.Character.animation["straightenArm"].weight > (float)1)
								{
									this.Character.animation["straightenArm"].weight = (float)1;
								}
							}
						}
						else
						{
							this.Attacking = false;
							this.AttackTimer = (float)0;
						}
					}
					else
					{
						this.Character.animation.CrossFade("f02_idle_20");
					}
				}
			}
			else
			{
				this.transform.position = Vector3.Lerp(this.transform.position, this.DumpingPoint.position, Time.deltaTime * (float)10);
				float y8 = Mathf.Lerp(this.transform.eulerAngles.y, this.DumpingPoint.localEulerAngles.y, Time.deltaTime * (float)10);
				Vector3 eulerAngles = this.transform.eulerAngles;
				float num23 = eulerAngles.y = y8;
				Vector3 vector17 = this.transform.eulerAngles = eulerAngles;
				this.Character.animation.CrossFade("f02_throw_20_p");
				if (this.Character.animation["f02_throw_20_p"].time >= this.Character.animation["f02_throw_20_p"].length)
				{
					this.Dumping = false;
					((IncineratorScript)this.DumpingPoint.transform.parent.gameObject.GetComponent(typeof(IncineratorScript))).Open = false;
				}
			}
			this.AttackCooldownTimer -= Time.deltaTime;
			if (this.AttackCooldownTimer <= (float)0 && this.NearestStudent != null && this.NearestStudent.Dying)
			{
				this.NearestStudent = null;
			}
			if (Input.GetKeyDown("r"))
			{
				PlayerPrefs.DeleteAll();
				Application.LoadLevel(Application.loadedLevel);
			}
			if (!this.Dragging && this.Character.animation["dragWalk"].weight > (float)0)
			{
				this.Character.animation["dragWalk"].weight = this.Character.animation["dragWalk"].weight - Time.deltaTime * (float)10;
			}
			if (this.YandereMeter > (float)100)
			{
				this.YandereMeter = (float)100;
			}
		}
		else
		{
			this.Character.animation.CrossFade("f02_idle_10");
		}
	}

	public virtual void LateUpdate()
	{
		if (this.ResetHeight)
		{
			float y = this.CoverHitbox.position.y - 0.1666667f;
			Vector3 position = this.transform.position;
			float num = position.y = y;
			Vector3 vector = this.transform.position = position;
			this.ResetHeight = false;
		}
		if (this.Armed)
		{
			if (this.EquippedSize < 3)
			{
				this.ArmRotation = Mathf.Lerp(this.ArmRotation, (float)5, Time.deltaTime * (float)10);
				float z = this.RightArm.localEulerAngles.z + this.ArmRotation;
				Vector3 localEulerAngles = this.RightArm.localEulerAngles;
				float num2 = localEulerAngles.z = z;
				Vector3 vector2 = this.RightArm.localEulerAngles = localEulerAngles;
				if (this.Character.animation["clenchFist"].weight < (float)1)
				{
					this.Character.animation["clenchFist"].weight = this.Character.animation["clenchFist"].weight + Time.deltaTime * (float)10;
				}
				if (this.Character.animation["carryBig"].weight > (float)0)
				{
					this.Character.animation["carryBig"].weight = this.Character.animation["carryBig"].weight - Time.deltaTime * (float)10;
				}
				if (this.Character.animation["carryMop"].weight > (float)0)
				{
					this.Character.animation["carryMop"].weight = this.Character.animation["carryMop"].weight - Time.deltaTime * (float)10;
				}
			}
			else if (this.EquippedID != 10)
			{
				if (this.Character.animation["carryBig"].weight < (float)1)
				{
					this.Character.animation["carryBig"].weight = this.Character.animation["carryBig"].weight + Time.deltaTime * (float)10;
				}
				if (this.Character.animation["carryMop"].weight > (float)0)
				{
					this.Character.animation["carryMop"].weight = this.Character.animation["carryMop"].weight - Time.deltaTime * (float)10;
				}
			}
			else if (this.Character.animation["carryMop"].weight < (float)1)
			{
				this.Character.animation["carryMop"].weight = this.Character.animation["carryMop"].weight + Time.deltaTime * (float)10;
			}
			if (!this.ControllerInventory.Show && Input.GetAxis("DpadY") == (float)-1 && this.EquippedID > 0)
			{
				if (this.EquippedSize > 1)
				{
					this.ControllerInventory.DropItem();
				}
				if (this.EquippedType != 3)
				{
					this.Weapons[this.EquippedID].active = false;
				}
				else
				{
					this.BodyParts[this.EquippedID].active = false;
				}
				this.EquippedName = string.Empty;
				this.EquippedType = 0;
				this.EquippedSize = 0;
				this.EquippedID = 0;
				this.Armed = false;
				if (this.EquippedID == 10)
				{
					int num3 = 0;
					Color color = this.Mop.Button.color;
					float num4 = color.a = (float)num3;
					Color color2 = this.Mop.Button.color = color;
					int num5 = 0;
					Color color3 = this.Mop.Label.color;
					float num6 = color3.a = (float)num5;
					Color color4 = this.Mop.Label.color = color3;
				}
			}
		}
		else
		{
			this.ArmRotation = Mathf.Lerp(this.ArmRotation, (float)0, Time.deltaTime * (float)10);
			float z2 = this.RightArm.localEulerAngles.z + this.ArmRotation;
			Vector3 localEulerAngles2 = this.RightArm.localEulerAngles;
			float num7 = localEulerAngles2.z = z2;
			Vector3 vector3 = this.RightArm.localEulerAngles = localEulerAngles2;
			if (this.Character.animation["clenchFist"].weight > (float)0)
			{
				this.Character.animation["clenchFist"].weight = this.Character.animation["clenchFist"].weight - Time.deltaTime * (float)10;
			}
			if (this.Character.animation["carryBig"].weight > (float)0)
			{
				this.Character.animation["carryBig"].weight = this.Character.animation["carryBig"].weight - Time.deltaTime * (float)10;
			}
			if (this.Character.animation["carryMop"].weight > (float)0)
			{
				this.Character.animation["carryMop"].weight = this.Character.animation["carryMop"].weight - Time.deltaTime * (float)10;
			}
		}
		if (this.Dragging)
		{
			if (this.Character.animation["turn"].weight < (float)1)
			{
				this.Character.animation["turn"].weight = this.Character.animation["turn"].weight + Time.deltaTime * (float)10;
			}
		}
		else if (this.Character.animation["turn"].weight > (float)0)
		{
			this.Character.animation["turn"].weight = this.Character.animation["turn"].weight - Time.deltaTime * (float)10;
		}
		this.Character.animation["Smile"].weight = this.YandereMeter * 0.01f;
		float z3 = this.LeftEyeOrigin.z - 0.01f * (this.YandereMeter * 0.01f);
		Vector3 localPosition = this.LeftEye.localPosition;
		float num8 = localPosition.z = z3;
		Vector3 vector4 = this.LeftEye.localPosition = localPosition;
		float z4 = this.RightEyeOrigin.z + 0.01f * (this.YandereMeter * 0.01f);
		Vector3 localPosition2 = this.RightEye.localPosition;
		float num9 = localPosition2.z = z4;
		Vector3 vector5 = this.RightEye.localPosition = localPosition2;
		float x = (float)1 - 0.5f * (this.YandereMeter * 0.01f);
		Vector3 localScale = this.LeftEye.localScale;
		float num10 = localScale.x = x;
		Vector3 vector6 = this.LeftEye.localScale = localScale;
		float y2 = (float)1 - 0.5f * (this.YandereMeter * 0.01f);
		Vector3 localScale2 = this.LeftEye.localScale;
		float num11 = localScale2.y = y2;
		Vector3 vector7 = this.LeftEye.localScale = localScale2;
		float x2 = (float)1 - 0.5f * (this.YandereMeter * 0.01f);
		Vector3 localScale3 = this.RightEye.localScale;
		float num12 = localScale3.x = x2;
		Vector3 vector8 = this.RightEye.localScale = localScale3;
		float y3 = (float)1 - 0.5f * (this.YandereMeter * 0.01f);
		Vector3 localScale4 = this.RightEye.localScale;
		float num13 = localScale4.y = y3;
		Vector3 vector9 = this.RightEye.localScale = localScale4;
		this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		int num14 = 0;
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num15 = eulerAngles.x = (float)num14;
		Vector3 vector10 = this.transform.eulerAngles = eulerAngles;
	}

	public virtual void OnTriggerStay(Collider other)
	{
		if (!this.Sidling)
		{
			if (other.gameObject.tag == "CoverHitbox")
			{
				this.CoverHitbox = other.gameObject.transform;
				this.ShortCover = false;
				this.CanSidle = true;
			}
			else if (other.gameObject.tag == "ShortCoverHitbox")
			{
				this.CoverHitbox = other.gameObject.transform;
				this.ShortCover = true;
				this.CanSidle = true;
			}
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "CoverHitbox" || !string.IsNullOrEmpty("ShortCoverHitbox"))
		{
			this.CanSidle = false;
		}
	}

	public virtual void SidleInputCheck()
	{
		int num;
		if (this.targetRotation.y > 0.5f && this.targetRotation.w > -0.5f && this.targetRotation.w < 0.5f)
		{
			num = 1;
		}
		if (this.targetRotation.y < -0.35f && this.targetRotation.w > 0.35f)
		{
			num = 2;
		}
		if (this.targetRotation.y > -0.5f && this.targetRotation.y < 0.5f && this.targetRotation.w > 0.5f)
		{
			num = 3;
		}
		if (this.targetRotation.y > 0.35f && this.targetRotation.w > 0.35f)
		{
			num = 4;
		}
		if (this.FacingNESW == 1)
		{
			if (num == 2)
			{
				this.SidleDirection = -1;
			}
			else if (num == 3)
			{
				this.StopSidling();
			}
			else if (num == 4)
			{
				this.SidleDirection = 1;
			}
			else
			{
				this.SidleDirection = 0;
			}
		}
		else if (this.FacingNESW == 2)
		{
			if (num == 3)
			{
				this.SidleDirection = -1;
			}
			else if (num == 4)
			{
				this.StopSidling();
			}
			else if (num == 1)
			{
				this.SidleDirection = 1;
			}
			else
			{
				this.SidleDirection = 0;
			}
		}
		else if (this.FacingNESW == 3)
		{
			if (num == 4)
			{
				this.SidleDirection = -1;
			}
			else if (num == 1)
			{
				this.StopSidling();
			}
			else if (num == 2)
			{
				this.SidleDirection = 1;
			}
			else
			{
				this.SidleDirection = 0;
			}
		}
		else if (num == 1)
		{
			this.SidleDirection = -1;
		}
		else if (num == 2)
		{
			this.StopSidling();
		}
		else if (num == 3)
		{
			this.SidleDirection = 1;
		}
		else
		{
			this.SidleDirection = 0;
		}
	}

	public virtual void LimitSidleMovement()
	{
		if (this.FacingNESW == 1 || this.FacingNESW == 3)
		{
			if (this.transform.position.x > this.CoverHitbox.transform.position.x + this.CoverHitbox.transform.localScale.x * 0.5f - 0.1666667f)
			{
				float x = this.CoverHitbox.transform.position.x + this.CoverHitbox.transform.localScale.x * 0.5f - 0.1666667f;
				Vector3 position = this.transform.position;
				float num = position.x = x;
				Vector3 vector = this.transform.position = position;
				this.SidleDirection = 0;
			}
			else if (this.transform.position.x < this.CoverHitbox.transform.position.x - this.CoverHitbox.transform.localScale.x * 0.5f + 0.1666667f)
			{
				float x2 = this.CoverHitbox.transform.position.x - this.CoverHitbox.transform.localScale.x * 0.5f + 0.1666667f;
				Vector3 position2 = this.transform.position;
				float num2 = position2.x = x2;
				Vector3 vector2 = this.transform.position = position2;
				this.SidleDirection = 0;
			}
		}
		else if (this.FacingNESW == 2 || this.FacingNESW == 4)
		{
			if (this.transform.position.z > this.CoverHitbox.transform.position.z + this.CoverHitbox.transform.localScale.x * 0.5f - 0.1666667f)
			{
				float z = this.CoverHitbox.transform.position.z + this.CoverHitbox.transform.localScale.x * 0.5f - 0.1666667f;
				Vector3 position3 = this.transform.position;
				float num3 = position3.z = z;
				Vector3 vector3 = this.transform.position = position3;
				this.SidleDirection = 0;
			}
			else if (this.transform.position.z < this.CoverHitbox.transform.position.z - this.CoverHitbox.transform.localScale.x * 0.5f + 0.1666667f)
			{
				float z2 = this.CoverHitbox.transform.position.z - this.CoverHitbox.transform.localScale.x * 0.5f + 0.1666667f;
				Vector3 position4 = this.transform.position;
				float num4 = position4.z = z2;
				Vector3 vector4 = this.transform.position = position4;
				this.SidleDirection = 0;
			}
		}
		if (this.SidleDirection == 0)
		{
			this.ReturnToDefaultRotation();
		}
	}

	public virtual void StopSidling()
	{
		this.rigidbody.useGravity = true;
		this.CanSidle = false;
		this.Sidling = false;
		this.ResetHeight = true;
	}

	public virtual void Crouch()
	{
		float num = 0.5f;
		object property = UnityRuntimeServices.GetProperty(this.MyCollider, "center");
		RuntimeServices.SetProperty(property, "y", num);
		UnityRuntimeServices.PropagateValueTypeChanges(new UnityRuntimeServices.ValueTypeChange[]
		{
			new UnityRuntimeServices.MemberValueTypeChange(this.MyCollider, "center", property)
		});
		RuntimeServices.SetProperty(this.MyCollider, "height", 1);
		this.PivotHeight = 0.5f;
		this.EyeHeight = 0.5f;
		this.Crouching = true;
	}

	public virtual void StandUp()
	{
		if (this.ShortCover)
		{
			this.StopSidling();
		}
		float num = 0.825f;
		object property = UnityRuntimeServices.GetProperty(this.MyCollider, "center");
		RuntimeServices.SetProperty(property, "y", num);
		UnityRuntimeServices.PropagateValueTypeChanges(new UnityRuntimeServices.ValueTypeChange[]
		{
			new UnityRuntimeServices.MemberValueTypeChange(this.MyCollider, "center", property)
		});
		RuntimeServices.SetProperty(this.MyCollider, "height", 1.65f);
		this.PivotHeight = (float)1;
		this.EyeHeight = 1.4825f;
		this.Crouching = false;
	}

	public virtual void ReturnToDefaultRotation()
	{
		if (this.Character.transform.localEulerAngles.y != (float)0)
		{
			if (this.Character.transform.localEulerAngles.y > (float)180)
			{
				float y = this.Character.transform.localEulerAngles.y + Time.deltaTime * (float)360;
				Vector3 localEulerAngles = this.Character.transform.localEulerAngles;
				float num = localEulerAngles.y = y;
				Vector3 vector = this.Character.transform.localEulerAngles = localEulerAngles;
				if (this.Character.transform.localEulerAngles.y > (float)350)
				{
					int num2 = 0;
					Vector3 localEulerAngles2 = this.Character.transform.localEulerAngles;
					float num3 = localEulerAngles2.y = (float)num2;
					Vector3 vector2 = this.Character.transform.localEulerAngles = localEulerAngles2;
				}
			}
			else
			{
				float y2 = this.Character.transform.localEulerAngles.y - Time.deltaTime * (float)360;
				Vector3 localEulerAngles3 = this.Character.transform.localEulerAngles;
				float num4 = localEulerAngles3.y = y2;
				Vector3 vector3 = this.Character.transform.localEulerAngles = localEulerAngles3;
				if (this.Character.transform.localEulerAngles.y < (float)10)
				{
					int num5 = 0;
					Vector3 localEulerAngles4 = this.Character.transform.localEulerAngles;
					float num6 = localEulerAngles4.y = (float)num5;
					Vector3 vector4 = this.Character.transform.localEulerAngles = localEulerAngles4;
				}
			}
		}
	}

	public virtual void UpdateBlood()
	{
		if (this.Bloodiness > 5)
		{
			this.Bloodiness = 5;
		}
		this.Body.material.mainTexture = this.BloodyTextures[this.Bloodiness];
	}

	public virtual void DropItem()
	{
		GameObject gameObject;
		if (this.Armed)
		{
			if (this.EquippedSize > 1)
			{
				if (this.EquippedType != 3)
				{
					gameObject = (GameObject)UnityEngine.Object.Instantiate(this.WeaponPickups[this.EquippedID], this.RightHand.position, Quaternion.identity);
					this.Weapons[this.EquippedID].active = false;
				}
				else
				{
					gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BodyPartPickups[this.EquippedID], this.RightHand.position, Quaternion.identity);
					this.BodyParts[this.EquippedID].active = false;
				}
			}
			else if (this.EquippedType < 3)
			{
				this.Weapons[this.EquippedID].active = false;
			}
			else
			{
				this.BodyParts[this.EquippedID].active = false;
			}
		}
		if (gameObject != null)
		{
			gameObject.transform.eulerAngles = this.RightHand.eulerAngles;
			float y = gameObject.transform.eulerAngles.y - (float)180;
			Vector3 eulerAngles = gameObject.transform.eulerAngles;
			float num = eulerAngles.y = y;
			Vector3 vector = gameObject.transform.eulerAngles = eulerAngles;
		}
	}

	public virtual void Main()
	{
		this.Character.animation["Laugh4"].speed = 0.5f;
	}
}
