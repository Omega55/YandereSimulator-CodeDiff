using System;
using UnityEngine;

public class PromptScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public StudentScript MyStudent;

	public YandereScript Yandere;

	public GameObject[] ButtonObject;

	public GameObject SpeakerObject;

	public GameObject CircleObject;

	public GameObject LabelObject;

	public PromptParentScript PromptParent;

	public Collider MyCollider;

	public Camera MainCamera;

	public Camera UICamera;

	public bool[] AcceptingInput;

	public bool[] ButtonActive;

	public bool[] HideButton;

	public UISprite[] Button;

	public UISprite[] Circle;

	public UILabel[] Label;

	public UISprite Speaker;

	public UISprite Square;

	public float[] OffsetX;

	public float[] OffsetY;

	public float[] OffsetZ;

	public string[] Text;

	public PromptOwnerType OwnerType;

	public bool DisableAtStart;

	public bool Suspicious;

	public bool Debugging;

	public bool SquareSet;

	public bool Carried;

	[Tooltip("This means that the prompt's renderer is within the camera's cone of vision")]
	public bool InSight;

	[Tooltip("This means that a raycast can hit the prompt's collider.")]
	public bool InView;

	public bool NoCheck;

	public bool Attack;

	public bool Weapon;

	public bool Noisy;

	public bool Local = true;

	public float RelativePosition;

	public float MaximumDistance = 5f;

	public float MinimumDistance;

	public float DistanceSqr;

	public float Height;

	public int ButtonHeld;

	public int BloodMask;

	public int Priority;

	public int ID;

	public GameObject YandereObject;

	public Transform RaycastTarget;

	public float MinimumDistanceSqr;

	public float MaximumDistanceSqr;

	public float Timer;

	public bool Student;

	public bool Door;

	public bool Hidden;

	private void Awake()
	{
		this.MinimumDistanceSqr = this.MinimumDistance;
		this.MaximumDistanceSqr = this.MaximumDistance;
		this.DistanceSqr = float.PositiveInfinity;
		this.OwnerType = this.DecideOwnerType();
		if (this.RaycastTarget == null)
		{
			this.RaycastTarget = base.transform;
		}
		if (this.OffsetZ.Length == 0)
		{
			this.OffsetZ = new float[4];
		}
		if (this.Yandere == null)
		{
			this.YandereObject = GameObject.Find("YandereChan");
			if (this.YandereObject != null)
			{
				this.Yandere = this.YandereObject.GetComponent<YandereScript>();
			}
		}
		if (this.Yandere != null)
		{
			this.PauseScreen = GameObject.Find("PauseScreen").GetComponent<PauseScreenScript>();
			this.PromptParent = GameObject.Find("PromptParent").GetComponent<PromptParentScript>();
			this.UICamera = GameObject.Find("UI Camera").GetComponent<Camera>();
			this.MainCamera = Camera.main;
			if (this.Noisy)
			{
				this.Speaker = UnityEngine.Object.Instantiate<GameObject>(this.SpeakerObject, base.transform.position, Quaternion.identity).GetComponent<UISprite>();
				this.Speaker.transform.parent = this.PromptParent.transform;
				this.Speaker.transform.localScale = new Vector3(1f, 1f, 1f);
				this.Speaker.transform.localEulerAngles = Vector3.zero;
				this.Speaker.enabled = false;
			}
			this.Square = UnityEngine.Object.Instantiate<GameObject>(this.PromptParent.SquareObject, base.transform.position, Quaternion.identity).GetComponent<UISprite>();
			this.Square.transform.parent = this.PromptParent.transform;
			this.Square.transform.localScale = new Vector3(1f, 1f, 1f);
			this.Square.transform.localEulerAngles = Vector3.zero;
			Color color = this.Square.color;
			color.a = 0f;
			this.Square.color = color;
			this.Square.enabled = false;
			this.ID = 0;
			while (this.ID < 4)
			{
				if (this.ButtonActive[this.ID])
				{
					this.Button[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.ButtonObject[this.ID], base.transform.position, Quaternion.identity).GetComponent<UISprite>();
					UISprite uisprite = this.Button[this.ID];
					uisprite.transform.parent = this.PromptParent.transform;
					uisprite.transform.localScale = new Vector3(1f, 1f, 1f);
					uisprite.transform.localEulerAngles = Vector3.zero;
					uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0f);
					uisprite.enabled = false;
					this.Circle[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.CircleObject, base.transform.position, Quaternion.identity).GetComponent<UISprite>();
					UISprite uisprite2 = this.Circle[this.ID];
					uisprite2.transform.parent = this.PromptParent.transform;
					uisprite2.transform.localScale = new Vector3(1f, 1f, 1f);
					uisprite2.transform.localEulerAngles = Vector3.zero;
					uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0f);
					uisprite2.enabled = false;
					this.Label[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.LabelObject, base.transform.position, Quaternion.identity).GetComponent<UILabel>();
					UILabel uilabel = this.Label[this.ID];
					uilabel.transform.parent = this.PromptParent.transform;
					uilabel.transform.localScale = new Vector3(1f, 1f, 1f);
					uilabel.transform.localEulerAngles = Vector3.zero;
					uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
					uilabel.enabled = false;
					if (this.Suspicious)
					{
						uilabel.color = new Color(1f, 0f, 0f, 0f);
					}
					uilabel.text = "     " + this.Text[this.ID];
				}
				this.AcceptingInput[this.ID] = true;
				this.ID++;
			}
			this.BloodMask = 2;
			this.BloodMask |= 4;
			this.BloodMask |= 512;
			this.BloodMask |= 8192;
			this.BloodMask |= 16384;
			this.BloodMask |= 65536;
			this.BloodMask |= 2097152;
			this.BloodMask = ~this.BloodMask;
		}
	}

	private void Start()
	{
		if (this.DisableAtStart)
		{
			this.Hide();
			base.enabled = false;
		}
	}

	private PromptOwnerType DecideOwnerType()
	{
		if (base.GetComponent<DoorScript>() != null)
		{
			return PromptOwnerType.Door;
		}
		return PromptOwnerType.Unknown;
	}

	private bool AllowedWhenCrouching(PromptOwnerType ownerType)
	{
		return ownerType == PromptOwnerType.Door;
	}

	private bool AllowedWhenCrawling(PromptOwnerType ownerType)
	{
		return false;
	}

	private void Update()
	{
		if (!this.PauseScreen.Show)
		{
			if (this.InView)
			{
				if (this.MyStudent == null)
				{
					Vector3 a = new Vector3(base.transform.position.x, this.Yandere.transform.position.y, base.transform.position.z);
					this.DistanceSqr = (a - this.Yandere.transform.position).sqrMagnitude;
				}
				else
				{
					this.DistanceSqr = this.MyStudent.DistanceToPlayer;
				}
				if (this.DistanceSqr < this.MaximumDistanceSqr)
				{
					this.NoCheck = true;
					bool flag = this.Yandere.Stance.Current == StanceType.Crouching;
					bool flag2 = this.Yandere.Stance.Current == StanceType.Crawling;
					if (this.Yandere.CanMove && (!flag || this.AllowedWhenCrouching(this.OwnerType)) && (!flag2 || this.AllowedWhenCrawling(this.OwnerType)) && !this.Yandere.Aiming && !this.Yandere.Mopping && !this.Yandere.NearSenpai)
					{
						if (this.Debugging)
						{
							Debug.DrawLine(this.Yandere.Eyes.position + Vector3.down * this.Height, this.RaycastTarget.position, Color.green);
						}
						RaycastHit raycastHit;
						if (Physics.Linecast(this.Yandere.Eyes.position + Vector3.down * this.Height, this.RaycastTarget.position, out raycastHit, this.BloodMask))
						{
							if (this.Debugging)
							{
								Debug.Log("We hit a collider named " + raycastHit.collider.name);
							}
							this.InSight = (raycastHit.collider == this.MyCollider);
						}
						if (this.Carried || this.InSight)
						{
							this.SquareSet = false;
							this.Hidden = false;
							Vector2 vector = Vector2.zero;
							this.ID = 0;
							while (this.ID < 4)
							{
								if (this.ButtonActive[this.ID])
								{
									float num = Vector3.Angle(this.Yandere.MainCamera.transform.forward, this.Yandere.MainCamera.transform.position - base.transform.position);
									if (num > 90f)
									{
										if (this.Local)
										{
											Vector2 vector2 = this.MainCamera.WorldToScreenPoint(base.transform.position + base.transform.right * this.OffsetX[this.ID] + base.transform.up * this.OffsetY[this.ID] + base.transform.forward * this.OffsetZ[this.ID]);
											this.Button[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
											this.Circle[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
											if (!this.SquareSet)
											{
												this.Square.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
												this.SquareSet = true;
											}
											Vector2 vector3 = this.MainCamera.WorldToScreenPoint(base.transform.position + base.transform.right * this.OffsetX[this.ID] + base.transform.up * this.OffsetY[this.ID] + base.transform.forward * this.OffsetZ[this.ID]);
											this.Label[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector3.x + this.OffsetX[this.ID], vector3.y, 1f));
											this.RelativePosition = vector2.x;
										}
										else
										{
											vector = this.MainCamera.WorldToScreenPoint(base.transform.position + new Vector3(this.OffsetX[this.ID], this.OffsetY[this.ID], this.OffsetZ[this.ID]));
											this.Button[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
											this.Circle[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
											if (!this.SquareSet)
											{
												this.Square.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
												this.SquareSet = true;
											}
											Vector2 vector4 = this.MainCamera.WorldToScreenPoint(base.transform.position + new Vector3(this.OffsetX[this.ID], this.OffsetY[this.ID], this.OffsetZ[this.ID]));
											this.Label[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector4.x + this.OffsetX[this.ID], vector4.y, 1f));
											this.RelativePosition = vector.x;
										}
										if (!this.HideButton[this.ID])
										{
											this.Square.enabled = true;
											this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
										}
									}
								}
								this.ID++;
							}
							if (this.Noisy)
							{
								this.Speaker.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y + 40f, 1f));
							}
							if (this.DistanceSqr < this.MinimumDistanceSqr)
							{
								if (this.Yandere.NearestPrompt == null)
								{
									this.Yandere.NearestPrompt = this;
								}
								else if (Mathf.Abs(this.RelativePosition - (float)Screen.width * 0.5f) < Mathf.Abs(this.Yandere.NearestPrompt.RelativePosition - (float)Screen.width * 0.5f))
								{
									this.Yandere.NearestPrompt = this;
								}
								if (this.Yandere.NearestPrompt == this)
								{
									this.Square.enabled = false;
									this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 0f);
									this.ID = 0;
									while (this.ID < 4)
									{
										if (this.ButtonActive[this.ID])
										{
											if (!this.Button[this.ID].enabled)
											{
												this.Button[this.ID].enabled = true;
												this.Circle[this.ID].enabled = true;
												this.Label[this.ID].enabled = true;
											}
											this.Button[this.ID].color = new Color(1f, 1f, 1f, 1f);
											this.Circle[this.ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
											Color color = this.Label[this.ID].color;
											color.a = 1f;
											this.Label[this.ID].color = color;
											if (this.Speaker != null)
											{
												this.Speaker.enabled = true;
												Color color2 = this.Speaker.color;
												color2.a = 1f;
												this.Speaker.color = color2;
											}
										}
										this.ID++;
									}
									if (Input.GetButton("A"))
									{
										this.ButtonHeld = 1;
									}
									else if (Input.GetButton("B"))
									{
										this.ButtonHeld = 2;
									}
									else if (Input.GetButton("X"))
									{
										this.ButtonHeld = 3;
									}
									else if (Input.GetButton("Y"))
									{
										this.ButtonHeld = 4;
									}
									else
									{
										this.ButtonHeld = 0;
									}
									if (this.ButtonHeld > 0)
									{
										this.ID = 0;
										while (this.ID < 4)
										{
											if (((this.ButtonActive[this.ID] && this.ID != this.ButtonHeld - 1) || this.HideButton[this.ID]) && this.Circle[this.ID] != null)
											{
												this.Circle[this.ID].fillAmount = 1f;
											}
											this.ID++;
										}
										if (this.ButtonActive[this.ButtonHeld - 1] && !this.HideButton[this.ButtonHeld - 1] && this.AcceptingInput[this.ButtonHeld - 1] && !this.Yandere.Attacking)
										{
											this.Circle[this.ButtonHeld - 1].color = new Color(1f, 1f, 1f, 1f);
											if (!this.Attack)
											{
												this.Circle[this.ButtonHeld - 1].fillAmount -= Time.deltaTime * 2f;
											}
											else
											{
												this.Circle[this.ButtonHeld - 1].fillAmount = 0f;
											}
											this.ID = 0;
										}
									}
									else
									{
										this.ID = 0;
										while (this.ID < 4)
										{
											if (this.ButtonActive[this.ID])
											{
												this.Circle[this.ID].fillAmount = 1f;
											}
											this.ID++;
										}
									}
								}
								else
								{
									this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
									this.ID = 0;
									while (this.ID < 4)
									{
										if (this.ButtonActive[this.ID])
										{
											UISprite uisprite = this.Button[this.ID];
											UISprite uisprite2 = this.Circle[this.ID];
											UILabel uilabel = this.Label[this.ID];
											uisprite.enabled = false;
											uisprite2.enabled = false;
											uilabel.enabled = false;
											Color color3 = uisprite.color;
											Color color4 = uisprite2.color;
											Color color5 = uilabel.color;
											color3.a = 0f;
											color4.a = 0f;
											color5.a = 0f;
											uisprite.color = color3;
											uisprite2.color = color4;
											uilabel.color = color5;
										}
										this.ID++;
									}
									if (this.Speaker != null)
									{
										this.Speaker.enabled = false;
										Color color6 = this.Speaker.color;
										color6.a = 0f;
										this.Speaker.color = color6;
									}
								}
							}
							else
							{
								if (this.Yandere.NearestPrompt == this)
								{
									this.Yandere.NearestPrompt = null;
								}
								this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
								this.ID = 0;
								while (this.ID < 4)
								{
									if (this.ButtonActive[this.ID])
									{
										UISprite uisprite3 = this.Button[this.ID];
										UISprite uisprite4 = this.Circle[this.ID];
										UILabel uilabel2 = this.Label[this.ID];
										uisprite4.fillAmount = 1f;
										uisprite3.enabled = false;
										uisprite4.enabled = false;
										uilabel2.enabled = false;
										Color color7 = uisprite3.color;
										Color color8 = uisprite4.color;
										Color color9 = uilabel2.color;
										color7.a = 0f;
										color8.a = 0f;
										color9.a = 0f;
										uisprite3.color = color7;
										uisprite4.color = color8;
										uilabel2.color = color9;
									}
									this.ID++;
								}
								if (this.Speaker != null)
								{
									this.Speaker.enabled = false;
									Color color10 = this.Speaker.color;
									color10.a = 0f;
									this.Speaker.color = color10;
								}
							}
							Color color11 = this.Square.color;
							color11.a = 1f;
							this.Square.color = color11;
							this.ID = 0;
							while (this.ID < 4)
							{
								if (this.ButtonActive[this.ID] && this.HideButton[this.ID])
								{
									UISprite uisprite5 = this.Button[this.ID];
									UISprite uisprite6 = this.Circle[this.ID];
									UILabel uilabel3 = this.Label[this.ID];
									uisprite5.enabled = false;
									uisprite6.enabled = false;
									uilabel3.enabled = false;
									Color color12 = uisprite5.color;
									Color color13 = uisprite6.color;
									Color color14 = uilabel3.color;
									color12.a = 0f;
									color13.a = 0f;
									color14.a = 0f;
									uisprite5.color = color12;
									uisprite6.color = color13;
									uilabel3.color = color14;
									if (this.Speaker != null)
									{
										this.Speaker.enabled = false;
										Color color15 = this.Speaker.color;
										color15.a = 0f;
										this.Speaker.color = color15;
									}
								}
								this.ID++;
							}
						}
						else
						{
							this.Hide();
						}
					}
					else
					{
						this.Hide();
					}
				}
				else
				{
					if (this.Debugging)
					{
						Debug.Log("Yandere-chan is too far away.");
					}
					this.Hide();
				}
			}
			else
			{
				this.DistanceSqr = float.PositiveInfinity;
				this.Hide();
			}
		}
		else
		{
			this.Hide();
		}
	}

	private void OnBecameVisible()
	{
		this.InView = true;
	}

	private void OnBecameInvisible()
	{
		this.InView = false;
		this.Hide();
	}

	public void Hide()
	{
		if (!this.Hidden)
		{
			this.NoCheck = false;
			this.Hidden = true;
			if (this.Yandere != null)
			{
				if (this.Yandere.NearestPrompt == this)
				{
					this.Yandere.NearestPrompt = null;
				}
				if (this.Square.enabled)
				{
					this.Square.enabled = false;
					this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 0f);
				}
				this.ID = 0;
				while (this.ID < 4)
				{
					if (this.ButtonActive[this.ID])
					{
						UISprite uisprite = this.Button[this.ID];
						if (uisprite.enabled)
						{
							UISprite uisprite2 = this.Circle[this.ID];
							UILabel uilabel = this.Label[this.ID];
							uisprite2.fillAmount = 1f;
							uisprite.enabled = false;
							uisprite2.enabled = false;
							uilabel.enabled = false;
							uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0f);
							uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0f);
							uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
						}
					}
					this.ID++;
				}
				if (this.Speaker != null)
				{
					this.Speaker.enabled = false;
					this.Speaker.color = new Color(this.Speaker.color.r, this.Speaker.color.g, this.Speaker.color.b, 0f);
				}
			}
		}
	}
}
