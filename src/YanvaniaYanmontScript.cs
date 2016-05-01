using System;
using UnityEngine;
using UnityScript.Lang;

[RequireComponent(typeof(CharacterController))]
[Serializable]
public class YanvaniaYanmontScript : MonoBehaviour
{
	private GameObject NewBlood;

	public YanvaniaCameraScript YanvaniaCamera;

	public InputManagerScript InputManager;

	public YanvaniaDraculaScript Dracula;

	public CharacterController MyController;

	public GameObject BossHealthBar;

	public GameObject LevelUpEffect;

	public GameObject DeathBlood;

	public GameObject Character;

	public GameObject BlackBG;

	public GameObject TextBox;

	public Renderer MyRenderer;

	public Transform TryAgainWindow;

	public Transform HealthBar;

	public Transform EXPBar;

	public Transform Hips;

	public Transform TrailStart;

	public Transform TrailEnd;

	public UITexture Photograph;

	public UILabel LevelLabel;

	public UISprite Darkness;

	public Transform[] WhipChain;

	public AudioClip[] Voices;

	public AudioClip[] Injuries;

	public AudioClip DeathSound;

	public AudioClip LandSound;

	public AudioClip WhipSound;

	public bool Attacking;

	public bool Crouching;

	public bool Dangling;

	public bool EnterCutscene;

	public bool Cutscene;

	public bool CanMove;

	public bool Injured;

	public bool Red;

	public bool SpunUp;

	public bool SpunDown;

	public bool SpunRight;

	public bool SpunLeft;

	public float TargetRotation;

	public float Rotation;

	public float RecoveryTimer;

	public float DeathTimer;

	public float FlashTimer;

	public float IdleTimer;

	public float TapTimer;

	public float PreviousY;

	public float MaxHealth;

	public float Health;

	public float EXP;

	public int Frames;

	public int Level;

	public int Taps;

	public float walkSpeed;

	public float runSpeed;

	public bool limitDiagonalSpeed;

	public bool toggleRun;

	public float jumpSpeed;

	public float gravity;

	public float fallingDamageThreshold;

	public bool slideWhenOverSlopeLimit;

	public bool slideOnTaggedObjects;

	public float slideSpeed;

	public bool airControl;

	public float antiBumpFactor;

	public int antiBunnyHopFactor;

	private Vector3 moveDirection;

	public bool grounded;

	private CharacterController controller;

	private Transform myTransform;

	private float speed;

	private RaycastHit hit;

	private float fallStartLevel;

	private bool falling;

	private float slideLimit;

	private float rayDistance;

	private Vector3 contactPoint;

	private bool playerControl;

	private int jumpTimer;

	private float originalThreshold;

	public float inputX;

	public YanvaniaYanmontScript()
	{
		this.MaxHealth = 100f;
		this.Health = 100f;
		this.walkSpeed = 6f;
		this.runSpeed = 11f;
		this.limitDiagonalSpeed = true;
		this.jumpSpeed = 8f;
		this.gravity = 20f;
		this.fallingDamageThreshold = 10f;
		this.slideSpeed = 12f;
		this.antiBumpFactor = 0.75f;
		this.antiBunnyHopFactor = 1;
		this.moveDirection = Vector3.zero;
	}

	public virtual void Start()
	{
		this.WhipChain[0].transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Character.animation.Play("f02_yanvaniaIdle_00");
		this.controller = (CharacterController)this.GetComponent(typeof(CharacterController));
		this.myTransform = this.transform;
		this.speed = this.walkSpeed;
		this.rayDistance = this.controller.height * 0.5f + this.controller.radius;
		this.slideLimit = this.controller.slopeLimit - 0.1f;
		this.jumpTimer = this.antiBunnyHopFactor;
		Vector3 position = this.transform.position;
		this.originalThreshold = this.fallingDamageThreshold;
	}

	public virtual void FixedUpdate()
	{
		if (this.CanMove)
		{
			if (!this.Injured)
			{
				if (!this.Cutscene)
				{
					if (this.grounded)
					{
						if (!this.Attacking)
						{
							if (!this.Crouching)
							{
								if (Input.GetAxis("VaniaHorizontal") > (float)0)
								{
									this.inputX = (float)1;
								}
								else if (Input.GetAxis("VaniaHorizontal") < (float)0)
								{
									this.inputX = (float)-1;
								}
								else
								{
									this.inputX = (float)0;
								}
							}
						}
						else if (this.grounded)
						{
							this.fallingDamageThreshold = (float)100;
							this.moveDirection.x = (float)0;
							this.inputX = (float)0;
							this.speed = (float)0;
						}
					}
					else if (Input.GetAxis("VaniaHorizontal") != (float)0)
					{
						if (Input.GetAxis("VaniaHorizontal") > (float)0)
						{
							this.inputX = (float)1;
						}
						else if (Input.GetAxis("VaniaHorizontal") < (float)0)
						{
							this.inputX = (float)-1;
						}
						else
						{
							this.inputX = (float)0;
						}
					}
					else
					{
						this.inputX = Mathf.MoveTowards(this.inputX, (float)0, Time.deltaTime * (float)10);
					}
					int num = 0;
					float num2 = (this.inputX == (float)0 || num == 0 || !this.limitDiagonalSpeed) ? 1f : 0.7071f;
					if (!this.Attacking)
					{
						if (Input.GetAxis("VaniaHorizontal") < (float)0)
						{
							int num3 = -90;
							Vector3 localEulerAngles = this.Character.transform.localEulerAngles;
							float num4 = localEulerAngles.y = (float)num3;
							Vector3 vector = this.Character.transform.localEulerAngles = localEulerAngles;
							int num5 = 1;
							Vector3 localScale = this.Character.transform.localScale;
							float num6 = localScale.x = (float)num5;
							Vector3 vector2 = this.Character.transform.localScale = localScale;
						}
						else if (Input.GetAxis("VaniaHorizontal") > (float)0)
						{
							int num7 = 90;
							Vector3 localEulerAngles2 = this.Character.transform.localEulerAngles;
							float num8 = localEulerAngles2.y = (float)num7;
							Vector3 vector3 = this.Character.transform.localEulerAngles = localEulerAngles2;
							int num9 = -1;
							Vector3 localScale2 = this.Character.transform.localScale;
							float num10 = localScale2.x = (float)num9;
							Vector3 vector4 = this.Character.transform.localScale = localScale2;
						}
					}
					if (this.grounded)
					{
						if (!this.Attacking && !this.Dangling)
						{
							if (Input.GetAxis("VaniaVertical") < -0.5f)
							{
								float y = 0.5f;
								Vector3 center = this.MyController.center;
								float num11 = center.y = y;
								Vector3 vector5 = this.MyController.center = center;
								this.MyController.height = (float)1;
								this.Crouching = true;
								this.IdleTimer = (float)10;
								this.inputX = (float)0;
							}
							if (this.Crouching)
							{
								this.Character.animation.CrossFade("f02_yanvaniaCrouch_00", 0.1f);
								if (!this.Attacking)
								{
									if (!this.Dangling)
									{
										if (Input.GetAxis("VaniaVertical") > -0.5f)
										{
											this.Character.animation["f02_yanvaniaCrouchPose_00"].weight = (float)0;
											float y2 = 0.75f;
											Vector3 center2 = this.MyController.center;
											float num12 = center2.y = y2;
											Vector3 vector6 = this.MyController.center = center2;
											this.MyController.height = 1.5f;
											this.Crouching = false;
										}
									}
									else if (Input.GetAxis("VaniaVertical") > -0.5f && Input.GetButton("X"))
									{
										this.Character.animation["f02_yanvaniaCrouchPose_00"].weight = (float)0;
										float y3 = 0.75f;
										Vector3 center3 = this.MyController.center;
										float num13 = center3.y = y3;
										Vector3 vector7 = this.MyController.center = center3;
										this.MyController.height = 1.5f;
										this.Crouching = false;
									}
								}
							}
							else if (this.inputX == (float)0)
							{
								if (this.IdleTimer > (float)0)
								{
									this.Character.animation.CrossFade("f02_yanvaniaIdle_00", 0.1f);
									this.Character.animation["f02_yanvaniaIdle_00"].speed = this.IdleTimer / (float)10;
								}
								else
								{
									this.Character.animation.CrossFade("f02_yanvaniaDramaticIdle_00", (float)1);
								}
								this.IdleTimer -= Time.deltaTime;
							}
							else
							{
								this.IdleTimer = (float)10;
								if (this.speed == this.walkSpeed)
								{
									this.Character.animation.CrossFade("f02_yanvaniaWalk_00", 0.1f);
								}
								else
								{
									this.Character.animation.CrossFade("f02_yanvaniaRun_00", 0.1f);
								}
							}
						}
						bool flag = false;
						if (Physics.Raycast(this.myTransform.position, -Vector3.up, out this.hit, this.rayDistance))
						{
							if (Vector3.Angle(this.hit.normal, Vector3.up) > this.slideLimit)
							{
								flag = true;
							}
						}
						else
						{
							Physics.Raycast(this.contactPoint + Vector3.up, -Vector3.up, out this.hit);
							if (Vector3.Angle(this.hit.normal, Vector3.up) > this.slideLimit)
							{
								flag = true;
							}
						}
						if (this.falling)
						{
							this.falling = false;
							if (this.myTransform.position.y < this.fallStartLevel - this.fallingDamageThreshold)
							{
								this.FallingDamageAlert(this.fallStartLevel - this.myTransform.position.y);
							}
							this.fallingDamageThreshold = this.originalThreshold;
						}
						if (!this.toggleRun)
						{
							this.speed = ((!Input.GetKey("left shift")) ? this.walkSpeed : this.runSpeed);
						}
						if ((flag && this.slideWhenOverSlopeLimit) || (this.slideOnTaggedObjects && this.hit.collider.tag == "Slide"))
						{
							Vector3 normal = this.hit.normal;
							this.moveDirection = new Vector3(normal.x, -normal.y, normal.z);
							Vector3.OrthoNormalize(ref normal, ref this.moveDirection);
							this.moveDirection *= this.slideSpeed;
							this.playerControl = false;
						}
						else
						{
							this.moveDirection = new Vector3(this.inputX * num2, -this.antiBumpFactor, (float)num * num2);
							this.moveDirection = this.myTransform.TransformDirection(this.moveDirection) * this.speed;
							this.playerControl = true;
						}
						if (!Input.GetButton("VaniaJump"))
						{
							this.jumpTimer++;
						}
						else if (this.jumpTimer >= this.antiBunnyHopFactor && !this.Attacking)
						{
							this.Crouching = false;
							this.fallingDamageThreshold = (float)0;
							this.moveDirection.y = this.jumpSpeed;
							this.IdleTimer = (float)10;
							this.jumpTimer = 0;
							this.audio.clip = this.Voices[UnityEngine.Random.Range(0, Extensions.get_length(this.Voices))];
							this.audio.Play();
						}
					}
					else
					{
						if (!this.Attacking)
						{
							if (this.transform.position.y > this.PreviousY)
							{
								this.Character.animation.CrossFade("f02_yanvaniaJump_00", 0.4f);
							}
							else
							{
								this.Character.animation.CrossFade("f02_yanvaniaFall_00", 0.4f);
							}
						}
						this.PreviousY = this.transform.position.y;
						if (!this.falling)
						{
							this.falling = true;
							this.fallStartLevel = this.myTransform.position.y;
						}
						if (this.airControl && this.playerControl)
						{
							this.moveDirection.x = this.inputX * this.speed * num2;
							this.moveDirection.z = (float)num * this.speed * num2;
							this.moveDirection = this.myTransform.TransformDirection(this.moveDirection);
						}
					}
				}
				else
				{
					this.moveDirection.x = (float)0;
					if (this.grounded)
					{
						if (this.transform.position.x > (float)-34)
						{
							int num14 = -90;
							Vector3 localEulerAngles3 = this.Character.transform.localEulerAngles;
							float num15 = localEulerAngles3.y = (float)num14;
							Vector3 vector8 = this.Character.transform.localEulerAngles = localEulerAngles3;
							int num16 = 1;
							Vector3 localScale3 = this.Character.transform.localScale;
							float num17 = localScale3.x = (float)num16;
							Vector3 vector9 = this.Character.transform.localScale = localScale3;
							float x = Mathf.MoveTowards(this.transform.position.x, (float)-34, Time.deltaTime * this.walkSpeed);
							Vector3 position = this.transform.position;
							float num18 = position.x = x;
							Vector3 vector10 = this.transform.position = position;
							this.Character.animation.CrossFade("f02_yanvaniaWalk_00");
						}
						else if (this.transform.position.x < (float)-34)
						{
							int num19 = 90;
							Vector3 localEulerAngles4 = this.Character.transform.localEulerAngles;
							float num20 = localEulerAngles4.y = (float)num19;
							Vector3 vector11 = this.Character.transform.localEulerAngles = localEulerAngles4;
							int num21 = -1;
							Vector3 localScale4 = this.Character.transform.localScale;
							float num22 = localScale4.x = (float)num21;
							Vector3 vector12 = this.Character.transform.localScale = localScale4;
							float x2 = Mathf.MoveTowards(this.transform.position.x, (float)-34, Time.deltaTime * this.walkSpeed);
							Vector3 position2 = this.transform.position;
							float num23 = position2.x = x2;
							Vector3 vector13 = this.transform.position = position2;
							this.Character.animation.CrossFade("f02_yanvaniaWalk_00");
						}
						else
						{
							this.Character.animation.CrossFade("f02_yanvaniaDramaticIdle_00", (float)1);
							int num24 = -90;
							Vector3 localEulerAngles5 = this.Character.transform.localEulerAngles;
							float num25 = localEulerAngles5.y = (float)num24;
							Vector3 vector14 = this.Character.transform.localEulerAngles = localEulerAngles5;
							int num26 = 1;
							Vector3 localScale5 = this.Character.transform.localScale;
							float num27 = localScale5.x = (float)num26;
							Vector3 vector15 = this.Character.transform.localScale = localScale5;
							this.WhipChain[0].transform.localScale = new Vector3((float)0, (float)0, (float)0);
							this.fallingDamageThreshold = (float)100;
							this.TextBox.active = true;
							this.Attacking = false;
							this.enabled = false;
						}
					}
				}
			}
			else
			{
				this.Character.animation.CrossFade("f02_damage_25");
				this.RecoveryTimer += Time.deltaTime;
				if (this.RecoveryTimer > (float)1)
				{
					this.RecoveryTimer = (float)0;
					this.Injured = false;
				}
			}
			this.moveDirection.y = this.moveDirection.y - this.gravity * Time.deltaTime;
			this.grounded = ((this.controller.Move(this.moveDirection * Time.deltaTime) & CollisionFlags.Below) != CollisionFlags.None);
			if (this.grounded && this.EnterCutscene)
			{
				this.YanvaniaCamera.Cutscene = true;
				this.Cutscene = true;
			}
			if ((this.controller.collisionFlags & CollisionFlags.Above) != CollisionFlags.None && this.moveDirection.y > (float)0)
			{
				this.moveDirection.y = (float)0;
			}
		}
		else if (this.Health == (float)0)
		{
			this.DeathTimer += Time.deltaTime;
			if (this.DeathTimer > (float)5)
			{
				float a = this.Darkness.color.a + Time.deltaTime * 0.2f;
				Color color = this.Darkness.color;
				float num28 = color.a = a;
				Color color2 = this.Darkness.color = color;
				if (this.Darkness.color.a >= (float)1)
				{
					if (this.Darkness.gameObject.active)
					{
						this.HealthBar.parent.gameObject.active = false;
						this.EXPBar.parent.gameObject.active = false;
						this.Darkness.gameObject.active = false;
						this.BossHealthBar.active = false;
						this.BlackBG.active = true;
					}
					this.TryAgainWindow.transform.localScale = Vector3.Lerp(this.TryAgainWindow.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				}
			}
		}
	}

	public virtual void Update()
	{
		if (!this.Injured && this.CanMove && !this.Cutscene)
		{
			if (this.grounded)
			{
				if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
				{
					this.TapTimer = 0.25f;
					this.Taps++;
				}
				if (this.Taps > 1)
				{
					this.speed = this.runSpeed;
				}
			}
			if (this.inputX == (float)0)
			{
				this.speed = this.walkSpeed;
			}
			this.TapTimer -= Time.deltaTime;
			if (this.TapTimer < (float)0)
			{
				this.Taps = 0;
			}
			if (Input.GetButtonDown("VaniaAttack") && !this.Attacking)
			{
				AudioSource.PlayClipAtPoint(this.WhipSound, this.transform.position);
				this.audio.clip = this.Voices[UnityEngine.Random.Range(0, Extensions.get_length(this.Voices))];
				this.audio.Play();
				this.WhipChain[0].transform.localScale = new Vector3((float)0, (float)0, (float)0);
				this.Attacking = true;
				this.IdleTimer = (float)10;
				if (this.Crouching)
				{
					this.Character.animation["f02_yanvaniaCrouchAttack_00"].time = (float)0;
					this.Character.animation.Play("f02_yanvaniaCrouchAttack_00");
				}
				else
				{
					this.Character.animation["f02_yanvaniaAttack_00"].time = (float)0;
					this.Character.animation.Play("f02_yanvaniaAttack_00");
				}
				if (this.grounded)
				{
					this.moveDirection.x = (float)0;
					this.inputX = (float)0;
					this.speed = (float)0;
				}
			}
			if (this.Attacking)
			{
				if (!this.Dangling)
				{
					this.WhipChain[0].transform.localScale = Vector3.MoveTowards(this.WhipChain[0].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)5);
					this.StraightenWhip();
				}
				else
				{
					if (Input.GetAxis("VaniaHorizontal") > -0.5f && Input.GetAxis("VaniaHorizontal") < 0.5f && Input.GetAxis("VaniaVertical") > -0.5f && Input.GetAxis("VaniaVertical") < 0.5f)
					{
						this.Character.animation.CrossFade("f02_yanvaniaWhip_Neutral");
						if (this.Crouching)
						{
							this.Character.animation["f02_yanvaniaCrouchPose_00"].weight = (float)1;
						}
						this.SpunUp = false;
						this.SpunDown = false;
						this.SpunRight = false;
						this.SpunLeft = false;
					}
					else
					{
						if (Input.GetAxis("VaniaVertical") > 0.5f)
						{
							if (!this.SpunUp)
							{
								this.PlayClip(this.WhipSound, this.transform.position);
								this.StraightenWhip();
								this.TargetRotation = (float)-360;
								this.Rotation = (float)0;
								this.SpunUp = true;
							}
							this.Character.animation.CrossFade("f02_yanvaniaWhip_Up", 0.1f);
						}
						else
						{
							this.SpunUp = false;
						}
						if (Input.GetAxis("VaniaVertical") < -0.5f)
						{
							if (!this.SpunDown)
							{
								this.PlayClip(this.WhipSound, this.transform.position);
								this.StraightenWhip();
								this.TargetRotation = (float)360;
								this.Rotation = (float)0;
								this.SpunDown = true;
							}
							this.Character.animation.CrossFade("f02_yanvaniaWhip_Down", 0.1f);
						}
						else
						{
							this.SpunDown = false;
						}
						if (Input.GetAxis("VaniaHorizontal") > 0.5f)
						{
							if (this.Character.transform.localScale.x == (float)1)
							{
								this.SpinRight();
							}
							else
							{
								this.SpinLeft();
							}
						}
						else if (this.Character.transform.localScale.x == (float)1)
						{
							this.SpunRight = false;
						}
						else
						{
							this.SpunLeft = false;
						}
						if (Input.GetAxis("VaniaHorizontal") < -0.5f)
						{
							if (this.Character.transform.localScale.x == (float)1)
							{
								this.SpinLeft();
							}
							else
							{
								this.SpinRight();
							}
						}
						else if (this.Character.transform.localScale.x == (float)1)
						{
							this.SpunLeft = false;
						}
						else
						{
							this.SpunRight = false;
						}
					}
					this.Rotation = Mathf.MoveTowards(this.Rotation, this.TargetRotation, Time.deltaTime * (float)3600 * 0.5f);
					this.WhipChain[1].transform.localEulerAngles = new Vector3((float)0, (float)0, this.Rotation);
					if (!Input.GetButton("VaniaAttack"))
					{
						this.StopAttacking();
					}
				}
			}
			else
			{
				this.WhipChain[0].transform.localScale = Vector3.MoveTowards(this.WhipChain[0].transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			if ((!this.Crouching && this.Character.animation["f02_yanvaniaAttack_00"].time >= this.Character.animation["f02_yanvaniaAttack_00"].length) || (this.Crouching && this.Character.animation["f02_yanvaniaCrouchAttack_00"].time >= this.Character.animation["f02_yanvaniaCrouchAttack_00"].length))
			{
				if (Input.GetButton("VaniaAttack"))
				{
					if (this.Crouching)
					{
						this.Character.animation["f02_yanvaniaCrouchPose_00"].weight = (float)1;
					}
					this.Dangling = true;
				}
				else
				{
					this.StopAttacking();
				}
			}
		}
		if (this.FlashTimer > (float)0)
		{
			this.FlashTimer -= Time.deltaTime;
			int i = 0;
			if (!this.Red)
			{
				while (i < Extensions.get_length(this.MyRenderer.materials))
				{
					this.MyRenderer.materials[i].color = new Color((float)1, (float)0, (float)0, (float)1);
					i++;
				}
				this.Frames++;
				if (this.Frames == 5)
				{
					this.Frames = 0;
					this.Red = true;
				}
			}
			else
			{
				while (i < Extensions.get_length(this.MyRenderer.materials))
				{
					this.MyRenderer.materials[i].color = new Color((float)1, (float)1, (float)1, (float)1);
					i++;
				}
				this.Frames++;
				if (this.Frames == 5)
				{
					this.Frames = 0;
					this.Red = false;
				}
			}
		}
		else
		{
			this.FlashTimer = (float)0;
			if (this.MyRenderer.materials[0].color != new Color((float)1, (float)1, (float)1, (float)1))
			{
				for (int i = 0; i < Extensions.get_length(this.MyRenderer.materials); i++)
				{
					this.MyRenderer.materials[i].color = new Color((float)1, (float)1, (float)1, (float)1);
				}
			}
		}
		float y = Mathf.Lerp(this.HealthBar.localScale.y, this.Health / this.MaxHealth, Time.deltaTime * (float)10);
		Vector3 localScale = this.HealthBar.localScale;
		float num = localScale.y = y;
		Vector3 vector = this.HealthBar.localScale = localScale;
		if (this.EXP >= (float)100)
		{
			this.Level++;
			if (this.Level >= 99)
			{
				this.Level = 99;
			}
			else
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.LevelUpEffect, this.LevelLabel.transform.position, Quaternion.identity);
				gameObject.transform.parent = this.LevelLabel.transform;
				this.MaxHealth += (float)20;
				this.Health = this.MaxHealth;
				this.EXP -= (float)100;
			}
			this.LevelLabel.text = string.Empty + this.Level;
		}
		float y2 = Mathf.Lerp(this.EXPBar.localScale.y, this.EXP / 100f, Time.deltaTime * (float)10);
		Vector3 localScale2 = this.EXPBar.localScale;
		float num2 = localScale2.y = y2;
		Vector3 vector2 = this.EXPBar.localScale = localScale2;
		int num3 = 0;
		Vector3 position = this.transform.position;
		float num4 = position.z = (float)num3;
		Vector3 vector3 = this.transform.position = position;
		if (Input.GetKeyDown("`"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown("2"))
		{
			this.transform.position = new Vector3(-31.75f, 6.51f, (float)0);
		}
		if (Input.GetKeyDown("5"))
		{
			this.Level = 5;
			this.LevelLabel.text = string.Empty + this.Level;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += (float)10;
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= (float)10;
			if (Time.timeScale < (float)0)
			{
				Time.timeScale = (float)1;
			}
		}
	}

	public virtual void LateUpdate()
	{
	}

	public virtual void OnControllerColliderHit(ControllerColliderHit hit)
	{
		this.contactPoint = hit.point;
	}

	public virtual void FallingDamageAlert(float fallDistance)
	{
		this.PlayClip(this.LandSound, this.transform.position);
		this.Character.animation.Play("f02_yanvaniaCrouch_00");
		this.fallingDamageThreshold = this.originalThreshold;
	}

	public virtual void SpinRight()
	{
		if (!this.SpunRight)
		{
			this.PlayClip(this.WhipSound, this.transform.position);
			this.StraightenWhip();
			this.TargetRotation = (float)360;
			this.Rotation = (float)0;
			this.SpunRight = true;
		}
		this.Character.animation.CrossFade("f02_yanvaniaWhip_Right", 0.1f);
	}

	public virtual void SpinLeft()
	{
		if (!this.SpunLeft)
		{
			this.PlayClip(this.WhipSound, this.transform.position);
			this.StraightenWhip();
			this.TargetRotation = (float)-360;
			this.Rotation = (float)0;
			this.SpunLeft = true;
		}
		this.Character.animation.CrossFade("f02_yanvaniaWhip_Left", 0.1f);
	}

	public virtual void StraightenWhip()
	{
		for (int i = 1; i < Extensions.get_length(this.WhipChain); i++)
		{
			this.WhipChain[i].transform.localPosition = new Vector3((float)0, -0.03f, (float)0);
			this.WhipChain[i].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		}
		this.WhipChain[1].transform.localPosition = new Vector3((float)0, -0.1f, (float)0);
	}

	public virtual void StopAttacking()
	{
		this.Character.animation["f02_yanvaniaCrouchPose_00"].weight = (float)0;
		this.TargetRotation = (float)0;
		this.Rotation = (float)0;
		this.Attacking = false;
		this.Dangling = false;
		this.SpunUp = false;
		this.SpunDown = false;
		this.SpunRight = false;
		this.SpunLeft = false;
	}

	public virtual void TakeDamage(int Damage)
	{
		this.audio.clip = this.Injuries[UnityEngine.Random.Range(0, Extensions.get_length(this.Injuries))];
		this.audio.Play();
		this.WhipChain[0].transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Character.animation["f02_damage_25"].time = (float)0;
		this.fallingDamageThreshold = (float)100;
		this.moveDirection.x = (float)0;
		this.RecoveryTimer = (float)0;
		this.FlashTimer = (float)2;
		this.Injured = true;
		this.StopAttacking();
		this.Health -= (float)Damage;
		if (this.Dracula.Health <= (float)0)
		{
			this.Health = (float)1;
		}
		if (this.Dracula.Health > (float)0 && this.Health <= (float)0)
		{
			if (this.NewBlood == null)
			{
				this.MyController.enabled = false;
				this.YanvaniaCamera.StopMusic = true;
				this.audio.clip = this.DeathSound;
				this.audio.Play();
				this.NewBlood = (GameObject)UnityEngine.Object.Instantiate(this.DeathBlood, this.transform.position, Quaternion.identity);
				this.NewBlood.transform.parent = this.Hips;
				this.NewBlood.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
				this.Character.animation.CrossFade("f02_yanvaniaDeath_00");
				this.CanMove = false;
			}
			this.Health = (float)0;
		}
	}

	public virtual void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
	}

	public virtual void Main()
	{
		this.Character.animation["f02_yanvaniaDeath_00"].speed = 0.25f;
		this.Character.animation["f02_yanvaniaAttack_00"].speed = (float)2;
		this.Character.animation["f02_yanvaniaCrouchAttack_00"].speed = (float)2;
		this.Character.animation["f02_yanvaniaWalk_00"].speed = 0.66666f;
		this.Character.animation["f02_yanvaniaWhip_Neutral"].speed = (float)0;
		this.Character.animation["f02_yanvaniaWhip_Up"].speed = (float)0;
		this.Character.animation["f02_yanvaniaWhip_Right"].speed = (float)0;
		this.Character.animation["f02_yanvaniaWhip_Down"].speed = (float)0;
		this.Character.animation["f02_yanvaniaWhip_Left"].speed = (float)0;
		this.Character.animation["f02_yanvaniaCrouchPose_00"].layer = 1;
		this.Character.animation.Play("f02_yanvaniaCrouchPose_00");
		this.Character.animation["f02_yanvaniaCrouchPose_00"].weight = (float)0;
		Physics.IgnoreLayerCollision(19, 13, true);
		Physics.IgnoreLayerCollision(19, 19, true);
	}
}
