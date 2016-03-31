using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PromptScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public YandereScript Yandere;

	public GameObject[] ButtonObject;

	public GameObject CircleObject;

	public GameObject LabelObject;

	public PromptParentScript PromptParent;

	public Collider MyCollider;

	public Camera UICamera;

	public bool[] AcceptingInput;

	public bool[] ButtonActive;

	public bool[] HideButton;

	public UISprite[] Button;

	public UISprite[] Circle;

	public UILabel[] Label;

	public UISprite Square;

	public float[] OffsetX;

	public float[] OffsetY;

	public float[] OffsetZ;

	public string[] Text;

	public bool DisableAtStart;

	public bool Initialized;

	public bool Debugging;

	public bool Carried;

	public bool InSight;

	public bool Attack;

	public bool InView;

	public bool Weapon;

	public bool Local;

	public float RelativePosition;

	public float MaximumDistance;

	public float MinimumDistance;

	public float Distance;

	public float Height;

	public int ButtonHeld;

	public int BloodMask;

	public int Priority;

	public int ID;

	public GameObject YandereObject;

	public PromptScript()
	{
		this.Local = true;
		this.MaximumDistance = 5f;
	}

	public virtual void OnApplicationQuit()
	{
		this.Initialized = true;
	}

	public virtual void Start()
	{
		this.Distance = (float)99999;
		if (!this.Initialized)
		{
			if (Extensions.get_length(this.OffsetZ) == 0)
			{
				this.OffsetZ = new float[4];
			}
			if (this.Yandere == null)
			{
				this.YandereObject = GameObject.Find("YandereChan");
				if (this.YandereObject != null)
				{
					this.Yandere = (YandereScript)this.YandereObject.GetComponent(typeof(YandereScript));
				}
			}
			if (this.Yandere != null)
			{
				this.PauseScreen = (PauseScreenScript)GameObject.Find("PauseScreen").GetComponent(typeof(PauseScreenScript));
				this.PromptParent = (PromptParentScript)GameObject.Find("PromptParent").GetComponent(typeof(PromptParentScript));
				this.UICamera = (Camera)GameObject.Find("UI Camera").GetComponent(typeof(Camera));
				this.Square = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.PromptParent.SquareObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
				this.Square.transform.parent = this.PromptParent.transform;
				this.Square.transform.localScale = new Vector3((float)1, (float)1, (float)1);
				this.Square.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				int num = 0;
				Color color = this.Square.color;
				float num2 = color.a = (float)num;
				Color color2 = this.Square.color = color;
				this.ID = 0;
				while (this.ID < 4)
				{
					if (this.ButtonActive[this.ID])
					{
						this.Button[this.ID] = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.ButtonObject[this.ID], this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
						this.Button[this.ID].transform.parent = this.PromptParent.transform;
						this.Button[this.ID].transform.localScale = new Vector3((float)1, (float)1, (float)1);
						this.Button[this.ID].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
						int num3 = 0;
						Color color3 = this.Button[this.ID].color;
						float num4 = color3.a = (float)num3;
						Color color4 = this.Button[this.ID].color = color3;
						this.Circle[this.ID] = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.CircleObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
						this.Circle[this.ID].transform.parent = this.PromptParent.transform;
						this.Circle[this.ID].transform.localScale = new Vector3((float)1, (float)1, (float)1);
						this.Circle[this.ID].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
						int num5 = 0;
						Color color5 = this.Circle[this.ID].color;
						float num6 = color5.a = (float)num5;
						Color color6 = this.Circle[this.ID].color = color5;
						this.Label[this.ID] = (UILabel)((GameObject)UnityEngine.Object.Instantiate(this.LabelObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UILabel));
						this.Label[this.ID].transform.parent = this.PromptParent.transform;
						this.Label[this.ID].transform.localScale = new Vector3((float)1, (float)1, (float)1);
						this.Label[this.ID].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
						int num7 = 0;
						Color color7 = this.Label[this.ID].color;
						float num8 = color7.a = (float)num7;
						Color color8 = this.Label[this.ID].color = color7;
						this.Label[this.ID].text = "     " + this.Text[this.ID];
					}
					this.AcceptingInput[this.ID] = true;
					this.ID++;
				}
				this.BloodMask = 2;
				this.BloodMask |= 512;
				this.BloodMask |= 8192;
				this.BloodMask |= 16384;
				this.BloodMask |= 65536;
				this.BloodMask = ~this.BloodMask;
				this.Initialized = true;
				if (this.DisableAtStart)
				{
					this.Hide();
					this.enabled = false;
				}
			}
		}
	}

	public virtual void Update()
	{
		if (!this.PauseScreen.Show)
		{
			if (this.InView)
			{
				this.Distance = Vector3.Distance(this.Yandere.transform.position, new Vector3(this.transform.position.x, this.Yandere.transform.position.y, this.transform.position.z));
				if (this.Distance < this.MaximumDistance)
				{
					if (this.Yandere.CanMove && !this.Yandere.Crouching && !this.Yandere.Crawling && !this.Yandere.Aiming && !this.Yandere.Mopping && !this.Yandere.NearSenpai)
					{
						RaycastHit raycastHit = default(RaycastHit);
						Debug.DrawLine(this.Yandere.Eyes.position + Vector3.down * this.Height, this.transform.position, Color.green);
						if (Physics.Linecast(this.Yandere.Eyes.position + Vector3.down * this.Height, this.transform.position, out raycastHit, this.BloodMask))
						{
							if (raycastHit.collider == this.MyCollider)
							{
								this.InSight = true;
							}
							else
							{
								this.InSight = false;
							}
						}
						if (this.Carried || this.InSight)
						{
							this.ID = 0;
							while (this.ID < 4)
							{
								if (this.ButtonActive[this.ID])
								{
									if (this.Local)
									{
										Vector2 vector = this.UICamera.WorldToScreenPoint(this.transform.position + this.transform.right * this.OffsetX[this.ID] + this.transform.up * this.OffsetY[this.ID] + this.transform.forward * this.OffsetZ[this.ID]);
										this.Button[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
										this.Circle[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
										this.Square.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
										Vector2 vector2 = this.UICamera.WorldToScreenPoint(this.transform.position + this.transform.right * this.OffsetX[this.ID] + this.transform.up * this.OffsetY[this.ID] + this.transform.forward * this.OffsetZ[this.ID]);
										this.Label[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x + this.OffsetX[this.ID], vector2.y, 1f));
										this.RelativePosition = vector.x;
									}
									else
									{
										Vector2 vector3 = this.UICamera.WorldToScreenPoint(this.transform.position + new Vector3(this.OffsetX[this.ID], this.OffsetY[this.ID], this.OffsetZ[this.ID]));
										this.Button[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector3.x, vector3.y, 1f));
										this.Circle[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector3.x, vector3.y, 1f));
										this.Square.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector3.x, vector3.y, 1f));
										Vector2 vector4 = this.UICamera.WorldToScreenPoint(this.transform.position + new Vector3(this.OffsetX[this.ID], this.OffsetY[this.ID], this.OffsetZ[this.ID]));
										this.Label[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector4.x + this.OffsetX[this.ID], vector4.y, 1f));
										this.RelativePosition = vector3.x;
									}
									if (!this.HideButton[this.ID])
									{
										int num = 1;
										Color color = this.Square.color;
										float num2 = color.a = (float)num;
										Color color2 = this.Square.color = color;
									}
								}
								this.ID++;
							}
							if (this.Distance < this.MinimumDistance)
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
									int num3 = 0;
									Color color3 = this.Square.color;
									float num4 = color3.a = (float)num3;
									Color color4 = this.Square.color = color3;
									this.ID = 0;
									while (this.ID < 4)
									{
										if (this.ButtonActive[this.ID])
										{
											this.Button[this.ID].color = new Color((float)1, (float)1, (float)1, (float)1);
											this.Circle[this.ID].color = new Color(0.5f, 0.5f, 0.5f, (float)1);
											int num5 = 1;
											Color color5 = this.Label[this.ID].color;
											float num6 = color5.a = (float)num5;
											Color color6 = this.Label[this.ID].color = color5;
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
												this.Circle[this.ID].fillAmount = (float)1;
											}
											this.ID++;
										}
										if (this.ButtonActive[this.ButtonHeld - 1] && !this.HideButton[this.ButtonHeld - 1] && this.AcceptingInput[this.ButtonHeld - 1] && !this.Yandere.Attacking)
										{
											this.Circle[this.ButtonHeld - 1].color = new Color((float)1, (float)1, (float)1, (float)1);
											if (!this.Attack)
											{
												this.Circle[this.ButtonHeld - 1].fillAmount = this.Circle[this.ButtonHeld - 1].fillAmount - Time.deltaTime * (float)2;
											}
											else
											{
												this.Circle[this.ButtonHeld - 1].fillAmount = (float)0;
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
												this.Circle[this.ID].fillAmount = (float)1;
											}
											this.ID++;
										}
									}
								}
								else
								{
									int num7 = 1;
									Color color7 = this.Square.color;
									float num8 = color7.a = (float)num7;
									Color color8 = this.Square.color = color7;
									this.ID = 0;
									while (this.ID < 4)
									{
										if (this.ButtonActive[this.ID])
										{
											int num9 = 0;
											Color color9 = this.Button[this.ID].color;
											float num10 = color9.a = (float)num9;
											Color color10 = this.Button[this.ID].color = color9;
											int num11 = 0;
											Color color11 = this.Circle[this.ID].color;
											float num12 = color11.a = (float)num11;
											Color color12 = this.Circle[this.ID].color = color11;
											int num13 = 0;
											Color color13 = this.Label[this.ID].color;
											float num14 = color13.a = (float)num13;
											Color color14 = this.Label[this.ID].color = color13;
										}
										this.ID++;
									}
								}
							}
							else
							{
								if (this.Yandere.NearestPrompt == this)
								{
									this.Yandere.NearestPrompt = null;
								}
								int num15 = 1;
								Color color15 = this.Square.color;
								float num16 = color15.a = (float)num15;
								Color color16 = this.Square.color = color15;
								this.ID = 0;
								while (this.ID < 4)
								{
									if (this.ButtonActive[this.ID])
									{
										this.Circle[this.ID].fillAmount = (float)1;
										int num17 = 0;
										Color color17 = this.Button[this.ID].color;
										float num18 = color17.a = (float)num17;
										Color color18 = this.Button[this.ID].color = color17;
										int num19 = 0;
										Color color19 = this.Circle[this.ID].color;
										float num20 = color19.a = (float)num19;
										Color color20 = this.Circle[this.ID].color = color19;
										int num21 = 0;
										Color color21 = this.Label[this.ID].color;
										float num22 = color21.a = (float)num21;
										Color color22 = this.Label[this.ID].color = color21;
									}
									this.ID++;
								}
							}
							int num23 = 1;
							Color color23 = this.Square.color;
							float num24 = color23.a = (float)num23;
							Color color24 = this.Square.color = color23;
							this.ID = 0;
							while (this.ID < 4)
							{
								if (this.ButtonActive[this.ID] && this.HideButton[this.ID])
								{
									int num25 = 0;
									Color color25 = this.Button[this.ID].color;
									float num26 = color25.a = (float)num25;
									Color color26 = this.Button[this.ID].color = color25;
									int num27 = 0;
									Color color27 = this.Circle[this.ID].color;
									float num28 = color27.a = (float)num27;
									Color color28 = this.Circle[this.ID].color = color27;
									int num29 = 0;
									Color color29 = this.Label[this.ID].color;
									float num30 = color29.a = (float)num29;
									Color color30 = this.Label[this.ID].color = color29;
								}
								this.ID++;
							}
						}
						else
						{
							if (this.Debugging)
							{
								Debug.Log("1.");
							}
							this.Hide();
						}
					}
					else
					{
						if (this.Debugging)
						{
							Debug.Log("2.");
						}
						this.Hide();
					}
				}
				else
				{
					if (this.Debugging)
					{
						Debug.Log("3.");
					}
					this.Hide();
				}
			}
			else
			{
				if (this.Debugging)
				{
					Debug.Log("4.");
				}
				this.Distance = (float)99999;
				this.Hide();
			}
		}
		else
		{
			if (this.Debugging)
			{
				Debug.Log("4.");
			}
			this.Hide();
		}
	}

	public virtual void OnBecameVisible()
	{
		this.InView = true;
	}

	public virtual void OnBecameInvisible()
	{
		this.InView = false;
		if (this.Debugging)
		{
			Debug.Log("5.");
		}
		this.Hide();
	}

	public virtual void Hide()
	{
		if (!this.Initialized)
		{
			this.Start();
		}
		if (this.YandereObject != null)
		{
			if (this.Yandere.NearestPrompt == this)
			{
				this.Yandere.NearestPrompt = null;
			}
			int num = 0;
			Color color = this.Square.color;
			float num2 = color.a = (float)num;
			Color color2 = this.Square.color = color;
			this.ID = 0;
			while (this.ID < 4)
			{
				if (this.ButtonActive[this.ID] && this.Button[this.ID].color.a > (float)0)
				{
					this.Circle[this.ID].fillAmount = (float)1;
					int num3 = 0;
					Color color3 = this.Button[this.ID].color;
					float num4 = color3.a = (float)num3;
					Color color4 = this.Button[this.ID].color = color3;
					int num5 = 0;
					Color color5 = this.Circle[this.ID].color;
					float num6 = color5.a = (float)num5;
					Color color6 = this.Circle[this.ID].color = color5;
					int num7 = 0;
					Color color7 = this.Label[this.ID].color;
					float num8 = color7.a = (float)num7;
					Color color8 = this.Label[this.ID].color = color7;
				}
				this.ID++;
			}
		}
	}

	public virtual void Main()
	{
	}
}
