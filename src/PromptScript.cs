using System;
using UnityEngine;

[Serializable]
public class PromptScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public YandereScript Yandere;

	public GameObject[] ButtonObject;

	public GameObject CircleObject;

	public GameObject LabelObject;

	public Transform PromptParent;

	public Collider MyCollider;

	public Camera UICamera;

	public bool[] AcceptingInput;

	public bool[] ButtonActive;

	public bool[] HideButton;

	public UISprite[] Button;

	public UISprite[] Circle;

	public UILabel[] Label;

	public float[] OffsetX;

	public float[] OffsetY;

	public string[] Text;

	public bool DisableAtStart;

	public bool Debugging;

	public bool Carried;

	public bool InSight;

	public bool Attack;

	public bool InView;

	public bool Weapon;

	public float MinimumDistance;

	public float Distance;

	public float Height;

	public int ButtonHeld;

	public int BloodMask;

	public int Priority;

	public int ID;

	public virtual void Start()
	{
		this.PauseScreen = (PauseScreenScript)GameObject.Find("PauseScreen").GetComponent(typeof(PauseScreenScript));
		this.PromptParent = (Transform)GameObject.Find("PromptParent").GetComponent(typeof(Transform));
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.UICamera = (Camera)GameObject.Find("UI Camera").GetComponent(typeof(Camera));
		while (this.ID < 4)
		{
			if (this.ButtonActive[this.ID])
			{
				this.Button[this.ID] = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.ButtonObject[this.ID], this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
				this.Button[this.ID].transform.parent = this.PromptParent;
				this.Button[this.ID].transform.localScale = new Vector3((float)1, (float)1, (float)1);
				this.Button[this.ID].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				int num = 0;
				Color color = this.Button[this.ID].color;
				float num2 = color.a = (float)num;
				Color color2 = this.Button[this.ID].color = color;
				this.Circle[this.ID] = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.CircleObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
				this.Circle[this.ID].transform.parent = this.PromptParent;
				this.Circle[this.ID].transform.localScale = new Vector3((float)1, (float)1, (float)1);
				this.Circle[this.ID].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				int num3 = 0;
				Color color3 = this.Circle[this.ID].color;
				float num4 = color3.a = (float)num3;
				Color color4 = this.Circle[this.ID].color = color3;
				this.Label[this.ID] = (UILabel)((GameObject)UnityEngine.Object.Instantiate(this.LabelObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UILabel));
				this.Label[this.ID].transform.parent = this.PromptParent;
				this.Label[this.ID].transform.localScale = new Vector3((float)1, (float)1, (float)1);
				this.Label[this.ID].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				int num5 = 0;
				Color color5 = this.Label[this.ID].color;
				float num6 = color5.a = (float)num5;
				Color color6 = this.Label[this.ID].color = color5;
				this.Label[this.ID].text = "     " + this.Text[this.ID];
			}
			this.AcceptingInput[this.ID] = true;
			this.ID++;
		}
		this.BloodMask = 4;
		this.BloodMask |= 512;
		this.BloodMask |= 8192;
		this.BloodMask |= 16384;
		this.BloodMask |= 65536;
		this.BloodMask = ~this.BloodMask;
		if (this.DisableAtStart)
		{
			this.Hide();
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (!this.PauseScreen.Show)
		{
			if (this.InView)
			{
				this.Distance = Vector3.Distance(this.Yandere.transform.position, new Vector3(this.transform.position.x, this.Yandere.transform.position.y, this.transform.position.z));
				if (this.Distance < (float)5)
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
									Vector2 vector = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.right * this.OffsetX[this.ID] + Vector3.up * this.OffsetY[this.ID]);
									this.Button[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
									this.Circle[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
									Vector2 vector2 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.right * this.OffsetX[this.ID] + Vector3.up * this.OffsetY[this.ID]);
									this.Label[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x + this.OffsetX[this.ID], vector2.y, 1f));
									if (!this.HideButton[this.ID])
									{
										this.Button[this.ID].color = new Color(0.5f, 0.5f, 0.5f, (float)1);
										int num = 0;
										Color color = this.Circle[this.ID].color;
										float num2 = color.a = (float)num;
										Color color2 = this.Circle[this.ID].color = color;
										float a = 0.5f;
										Color color3 = this.Label[this.ID].color;
										float num3 = color3.a = a;
										Color color4 = this.Label[this.ID].color = color3;
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
								else if (this.Priority == this.Yandere.NearestPrompt.Priority)
								{
									if (this.Distance < this.Yandere.NearestPrompt.Distance)
									{
										this.Yandere.NearestPrompt = this;
									}
								}
								else if (this.Priority > this.Yandere.NearestPrompt.Priority)
								{
									this.Yandere.NearestPrompt = this;
								}
								if (this.Yandere.NearestPrompt == this)
								{
									this.ID = 0;
									while (this.ID < 4)
									{
										if (this.ButtonActive[this.ID])
										{
											this.Button[this.ID].color = new Color((float)1, (float)1, (float)1, (float)1);
											this.Circle[this.ID].color = new Color(0.5f, 0.5f, 0.5f, (float)1);
											int num4 = 1;
											Color color5 = this.Label[this.ID].color;
											float num5 = color5.a = (float)num4;
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
											if ((this.ButtonActive[this.ID] && this.ID != this.ButtonHeld - 1) || this.HideButton[this.ID])
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
							}
							else
							{
								if (this.Yandere.NearestPrompt == this)
								{
									this.Yandere.NearestPrompt = null;
								}
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
							this.ID = 0;
							while (this.ID < 4)
							{
								if (this.ButtonActive[this.ID] && this.HideButton[this.ID])
								{
									int num6 = 0;
									Color color7 = this.Button[this.ID].color;
									float num7 = color7.a = (float)num6;
									Color color8 = this.Button[this.ID].color = color7;
									int num8 = 0;
									Color color9 = this.Circle[this.ID].color;
									float num9 = color9.a = (float)num8;
									Color color10 = this.Circle[this.ID].color = color9;
									int num10 = 0;
									Color color11 = this.Label[this.ID].color;
									float num11 = color11.a = (float)num10;
									Color color12 = this.Label[this.ID].color = color11;
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
		if (this.Yandere.NearestPrompt == this)
		{
			this.Yandere.NearestPrompt = null;
		}
		this.ID = 0;
		while (this.ID < 4)
		{
			if (this.ButtonActive[this.ID])
			{
				this.Circle[this.ID].fillAmount = (float)1;
				int num = 0;
				Color color = this.Button[this.ID].color;
				float num2 = color.a = (float)num;
				Color color2 = this.Button[this.ID].color = color;
				int num3 = 0;
				Color color3 = this.Circle[this.ID].color;
				float num4 = color3.a = (float)num3;
				Color color4 = this.Circle[this.ID].color = color3;
				int num5 = 0;
				Color color5 = this.Label[this.ID].color;
				float num6 = color5.a = (float)num5;
				Color color6 = this.Label[this.ID].color = color5;
			}
			this.ID++;
		}
	}

	public virtual void Main()
	{
	}
}
