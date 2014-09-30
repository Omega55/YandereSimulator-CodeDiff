using System;
using UnityEngine;

[Serializable]
public class CaseScript : MonoBehaviour
{
	public bool Equipped;

	public bool Open;

	public Transform Lid;

	public Transform LidPivot;

	public Quaternion OpenRotation;

	public Quaternion ClosedRotation;

	public GameObject[] BodyParts;

	public int[] IDs;

	public Collider MyCollider;

	public ControllerInventoryScript ControllerInventory;

	public YandereScript Yandere;

	public GameObject ThirdButtonObject;

	public GameObject SecondButtonObject;

	public GameObject ButtonObject;

	public GameObject CircleObject;

	public GameObject LabelObject;

	public Transform ButtonPanel;

	public Camera UICamera;

	public UISprite Button;

	public UISprite Circle;

	public UILabel Label;

	public UISprite SecondButton;

	public UISprite SecondCircle;

	public UILabel SecondLabel;

	public UISprite ThirdButton;

	public UISprite ThirdCircle;

	public UILabel ThirdLabel;

	public bool YHeldDown;

	public bool BHeldDown;

	public bool AHeldDown;

	public bool InView;

	public float Distance;

	public int Carrying;

	public virtual void LateUpdate()
	{
		if (!this.Equipped)
		{
			if (this.Open)
			{
				this.Lid.transform.rotation = Quaternion.Lerp(this.Lid.transform.rotation, this.OpenRotation, Time.deltaTime * (float)10);
			}
			else
			{
				this.Lid.transform.rotation = Quaternion.Lerp(this.Lid.transform.rotation, this.ClosedRotation, Time.deltaTime * (float)10);
			}
		}
	}

	public virtual void Start()
	{
		this.OpenRotation = this.Lid.rotation;
		this.LidPivot.localEulerAngles = new Vector3((float)90, (float)90, (float)90);
		this.Lid.localEulerAngles = new Vector3((float)270, (float)0, (float)0);
		this.ClosedRotation = this.Lid.rotation;
		this.ControllerInventory = (ControllerInventoryScript)GameObject.Find("ControllerInventoryPanel").GetComponent(typeof(ControllerInventoryScript));
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.ButtonPanel = (Transform)GameObject.Find("ButtonPanel").GetComponent(typeof(Transform));
		this.UICamera = (Camera)GameObject.Find("UI Camera").GetComponent(typeof(Camera));
		this.Button = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.ButtonObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
		this.Button.transform.parent = this.ButtonPanel;
		this.Button.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Button.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		this.Circle = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.CircleObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
		this.Circle.transform.parent = this.ButtonPanel;
		this.Circle.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Circle.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num3 = 0;
		Color color3 = this.Circle.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Circle.color = color3;
		this.Label = (UILabel)((GameObject)UnityEngine.Object.Instantiate(this.LabelObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UILabel));
		this.Label.transform.parent = this.ButtonPanel;
		this.Label.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Label.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num5 = 0;
		Color color5 = this.Label.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.Label.color = color5;
		this.Label.text = "     " + "Carry";
		this.SecondButton = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.SecondButtonObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
		this.SecondButton.transform.parent = this.ButtonPanel;
		this.SecondButton.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.SecondButton.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num7 = 0;
		Color color7 = this.SecondButton.color;
		float num8 = color7.a = (float)num7;
		Color color8 = this.SecondButton.color = color7;
		this.SecondCircle = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.CircleObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
		this.SecondCircle.transform.parent = this.ButtonPanel;
		this.SecondCircle.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.SecondCircle.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num9 = 0;
		Color color9 = this.SecondCircle.color;
		float num10 = color9.a = (float)num9;
		Color color10 = this.SecondCircle.color = color9;
		this.SecondLabel = (UILabel)((GameObject)UnityEngine.Object.Instantiate(this.LabelObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UILabel));
		this.SecondLabel.transform.parent = this.ButtonPanel;
		this.SecondLabel.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.SecondLabel.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num11 = 0;
		Color color11 = this.SecondLabel.color;
		float num12 = color11.a = (float)num11;
		Color color12 = this.SecondLabel.color = color11;
		this.SecondLabel.text = "     " + "Equip";
		this.ThirdButton = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.ThirdButtonObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
		this.ThirdButton.transform.parent = this.ButtonPanel;
		this.ThirdButton.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.ThirdButton.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num13 = 0;
		Color color13 = this.ThirdButton.color;
		float num14 = color13.a = (float)num13;
		Color color14 = this.ThirdButton.color = color13;
		this.ThirdCircle = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.CircleObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
		this.ThirdCircle.transform.parent = this.ButtonPanel;
		this.ThirdCircle.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.ThirdCircle.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num15 = 0;
		Color color15 = this.ThirdCircle.color;
		float num16 = color15.a = (float)num15;
		Color color16 = this.ThirdCircle.color = color15;
		this.ThirdLabel = (UILabel)((GameObject)UnityEngine.Object.Instantiate(this.LabelObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UILabel));
		this.ThirdLabel.transform.parent = this.ButtonPanel;
		this.ThirdLabel.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.ThirdLabel.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num17 = 0;
		Color color17 = this.ThirdLabel.color;
		float num18 = color17.a = (float)num17;
		Color color18 = this.ThirdLabel.color = color17;
		this.ThirdLabel.text = "     " + "Open";
	}

	public virtual void Update()
	{
		if (!this.Equipped)
		{
			if (this.InView)
			{
				this.Distance = Vector3.Distance(this.Yandere.transform.position, this.transform.position);
				if (this.Distance < (float)5)
				{
					Vector2 vector = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.1f);
					this.Button.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y + (float)70, 1f));
					this.Circle.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y + (float)70, 1f));
					Vector2 vector2 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.1f);
					this.Label.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y + (float)70, 1f));
					Vector2 vector3 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.1f);
					this.SecondButton.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector3.x, vector3.y + (float)35, 1f));
					this.SecondCircle.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector3.x, vector3.y + (float)35, 1f));
					Vector2 vector4 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.1f);
					this.SecondLabel.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector4.x, vector4.y + (float)35, 1f));
					Vector2 vector5 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.1f);
					this.ThirdButton.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector5.x, vector5.y, 1f));
					this.ThirdCircle.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector5.x, vector5.y, 1f));
					Vector2 vector6 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.1f);
					this.ThirdLabel.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector6.x, vector6.y, 1f));
					if (this.Open)
					{
						if (this.Carrying > 0)
						{
							this.Button.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
							int num = 0;
							Color color = this.Circle.color;
							float num2 = color.a = (float)num;
							Color color2 = this.Circle.color = color;
							float a = 0.5f;
							Color color3 = this.Label.color;
							float num3 = color3.a = a;
							Color color4 = this.Label.color = color3;
						}
					}
					else
					{
						int num4 = 0;
						Color color5 = this.Button.color;
						float num5 = color5.a = (float)num4;
						Color color6 = this.Button.color = color5;
						int num6 = 0;
						Color color7 = this.Circle.color;
						float num7 = color7.a = (float)num6;
						Color color8 = this.Circle.color = color7;
						int num8 = 0;
						Color color9 = this.Label.color;
						float num9 = color9.a = (float)num8;
						Color color10 = this.Label.color = color9;
					}
					if (this.Open)
					{
						if (this.Yandere.Armed)
						{
							this.SecondButton.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
							int num10 = 0;
							Color color11 = this.SecondCircle.color;
							float num11 = color11.a = (float)num10;
							Color color12 = this.SecondCircle.color = color11;
							float a2 = 0.5f;
							Color color13 = this.SecondLabel.color;
							float num12 = color13.a = a2;
							Color color14 = this.SecondLabel.color = color13;
						}
						else
						{
							int num13 = 0;
							Color color15 = this.SecondButton.color;
							float num14 = color15.a = (float)num13;
							Color color16 = this.SecondButton.color = color15;
							int num15 = 0;
							Color color17 = this.SecondCircle.color;
							float num16 = color17.a = (float)num15;
							Color color18 = this.SecondCircle.color = color17;
							int num17 = 0;
							Color color19 = this.SecondLabel.color;
							float num18 = color19.a = (float)num17;
							Color color20 = this.SecondLabel.color = color19;
						}
					}
					else
					{
						this.SecondButton.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
						int num19 = 0;
						Color color21 = this.SecondCircle.color;
						float num20 = color21.a = (float)num19;
						Color color22 = this.SecondCircle.color = color21;
						float a3 = 0.5f;
						Color color23 = this.SecondLabel.color;
						float num21 = color23.a = a3;
						Color color24 = this.SecondLabel.color = color23;
					}
					this.ThirdButton.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
					int num22 = 0;
					Color color25 = this.ThirdCircle.color;
					float num23 = color25.a = (float)num22;
					Color color26 = this.ThirdCircle.color = color25;
					float a4 = 0.5f;
					Color color27 = this.ThirdLabel.color;
					float num24 = color27.a = a4;
					Color color28 = this.ThirdLabel.color = color27;
					if (this.Distance < (float)1)
					{
						if (this.Open && this.Carrying > 0)
						{
							if (this.Yandere.NearestPickup == null)
							{
								this.Yandere.NearestPickup = this.gameObject;
							}
							if (this.Yandere.NearestPickup == this.gameObject)
							{
								this.Button.color = new Color((float)1, (float)1, (float)1, (float)1);
								int num25 = 1;
								Color color29 = this.Label.color;
								float num26 = color29.a = (float)num25;
								Color color30 = this.Label.color = color29;
								this.Circle.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
								if (!this.YHeldDown)
								{
									if (Input.GetButton("Y"))
									{
										this.Circle.color = new Color((float)1, (float)1, (float)1, (float)1);
										this.Circle.fillAmount = this.Circle.fillAmount - Time.deltaTime * (float)2;
										if (this.Circle.fillAmount <= (float)0)
										{
											this.Circle.fillAmount = (float)1;
											this.RemoveBodyParts();
											this.UpdateText();
										}
									}
									else
									{
										this.Circle.fillAmount = (float)1;
									}
								}
							}
						}
						if (this.Yandere.NearestRagdoll == null && this.Yandere.NearestRagdoll == null)
						{
							this.Yandere.NearestRagdoll = this.gameObject;
						}
						if (this.Yandere.NearestRagdoll == this.gameObject && (!this.Open || (this.Open && this.Yandere.Armed)))
						{
							this.SecondButton.color = new Color((float)1, (float)1, (float)1, (float)1);
							int num27 = 1;
							Color color31 = this.SecondLabel.color;
							float num28 = color31.a = (float)num27;
							Color color32 = this.SecondLabel.color = color31;
							this.SecondCircle.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
							if (!this.YHeldDown)
							{
								if (Input.GetButton("B"))
								{
									this.SecondCircle.color = new Color((float)1, (float)1, (float)1, (float)1);
									this.SecondCircle.fillAmount = this.SecondCircle.fillAmount - Time.deltaTime * (float)2;
									if (this.SecondCircle.fillAmount <= (float)0)
									{
										if (!this.Open)
										{
											this.Yandere.Item3Name = "GuitarCase";
											this.Yandere.Item3Type = 1;
											this.Yandere.Item3ID = 1;
											this.Yandere.Item3 = this.gameObject;
											this.ControllerInventory.UpdateSprites();
											this.Equipped = true;
											this.transform.parent = this.Yandere.BackPack;
											this.MyCollider.enabled = false;
											this.Deselect();
										}
										else if (this.Yandere.EquippedType == 3)
										{
											if (!this.BodyParts[this.Yandere.EquippedID].active)
											{
												this.BodyParts[this.Yandere.EquippedID].active = true;
												this.Carrying++;
												this.IDs[this.Carrying] = this.Yandere.EquippedID;
												this.Yandere.BodyParts[this.Yandere.EquippedID].active = false;
												this.Yandere.Armed = false;
												this.Yandere.EquippedID = 0;
												this.Yandere.EquippedType = 0;
												this.Yandere.EquippedSize = 0;
												this.Yandere.EquippedName = string.Empty;
											}
											else
											{
												Debug.Log("This case is already carrying one of those body parts.");
											}
										}
										this.SecondCircle.fillAmount = (float)1;
										this.UpdateText();
									}
								}
								else
								{
									this.SecondCircle.fillAmount = (float)1;
								}
							}
						}
						if (this.Yandere.NearestPickupA == null && this.Yandere.NearestPickupA == null)
						{
							this.Yandere.NearestPickupA = this.gameObject;
						}
						if (this.Yandere.NearestPickupA == this.gameObject)
						{
							if (!this.Equipped)
							{
								this.ThirdButton.color = new Color((float)1, (float)1, (float)1, (float)1);
								int num29 = 1;
								Color color33 = this.ThirdLabel.color;
								float num30 = color33.a = (float)num29;
								Color color34 = this.ThirdLabel.color = color33;
								this.ThirdCircle.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
							}
							if (!this.YHeldDown)
							{
								if (Input.GetButton("A"))
								{
									this.ThirdCircle.color = new Color((float)1, (float)1, (float)1, (float)1);
									this.ThirdCircle.fillAmount = this.ThirdCircle.fillAmount - Time.deltaTime * (float)2;
									if (this.ThirdCircle.fillAmount <= (float)0)
									{
										if (!this.Open)
										{
											this.Open = true;
										}
										else
										{
											this.Open = false;
										}
										this.ThirdCircle.fillAmount = (float)1;
										this.UpdateText();
									}
								}
								else
								{
									this.ThirdCircle.fillAmount = (float)1;
								}
							}
						}
					}
					else
					{
						if (this.Yandere.NearestRagdoll == this.gameObject)
						{
							this.Yandere.NearestRagdoll = null;
						}
						if (this.Yandere.NearestPickup == this.gameObject)
						{
							this.Yandere.NearestPickup = null;
						}
						if (this.Yandere.NearestPickupA == this.gameObject)
						{
							this.Yandere.NearestPickupA = null;
						}
					}
				}
				else
				{
					this.Deselect();
				}
			}
			else
			{
				this.Deselect();
			}
		}
		else
		{
			if (this.Yandere.NearestRagdoll == this.gameObject)
			{
				this.Yandere.NearestRagdoll = null;
			}
			if (this.Yandere.NearestPickup == this.gameObject)
			{
				this.Yandere.NearestPickup = null;
			}
			if (this.Yandere.NearestPickupA == this.gameObject)
			{
				this.Yandere.NearestPickupA = null;
			}
			this.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
			this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		}
	}

	public virtual void Deselect()
	{
		if (this.Yandere.NearestRagdoll == this.gameObject)
		{
			this.Yandere.NearestRagdoll = null;
		}
		if (this.Yandere.NearestPickup == this.gameObject)
		{
			this.Yandere.NearestPickup = null;
		}
		if (this.Yandere.NearestPickupA == this.gameObject)
		{
			this.Yandere.NearestPickupA = null;
		}
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		int num3 = 0;
		Color color3 = this.Circle.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Circle.color = color3;
		int num5 = 0;
		Color color5 = this.Label.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.Label.color = color5;
		int num7 = 0;
		Color color7 = this.SecondButton.color;
		float num8 = color7.a = (float)num7;
		Color color8 = this.SecondButton.color = color7;
		int num9 = 0;
		Color color9 = this.SecondCircle.color;
		float num10 = color9.a = (float)num9;
		Color color10 = this.SecondCircle.color = color9;
		int num11 = 0;
		Color color11 = this.SecondLabel.color;
		float num12 = color11.a = (float)num11;
		Color color12 = this.SecondLabel.color = color11;
		int num13 = 0;
		Color color13 = this.ThirdButton.color;
		float num14 = color13.a = (float)num13;
		Color color14 = this.ThirdButton.color = color13;
		int num15 = 0;
		Color color15 = this.ThirdCircle.color;
		float num16 = color15.a = (float)num15;
		Color color16 = this.ThirdCircle.color = color15;
		int num17 = 0;
		Color color17 = this.ThirdLabel.color;
		float num18 = color17.a = (float)num17;
		Color color18 = this.ThirdLabel.color = color17;
	}

	public virtual void OnBecameVisible()
	{
		this.InView = true;
	}

	public virtual void OnBecameInvisible()
	{
		this.InView = false;
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		int num3 = 0;
		Color color3 = this.Circle.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Circle.color = color3;
		int num5 = 0;
		Color color5 = this.Label.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.Label.color = color5;
		int num7 = 0;
		Color color7 = this.SecondButton.color;
		float num8 = color7.a = (float)num7;
		Color color8 = this.SecondButton.color = color7;
		int num9 = 0;
		Color color9 = this.SecondCircle.color;
		float num10 = color9.a = (float)num9;
		Color color10 = this.SecondCircle.color = color9;
		int num11 = 0;
		Color color11 = this.SecondLabel.color;
		float num12 = color11.a = (float)num11;
		Color color12 = this.SecondLabel.color = color11;
		int num13 = 0;
		Color color13 = this.ThirdButton.color;
		float num14 = color13.a = (float)num13;
		Color color14 = this.ThirdButton.color = color13;
		int num15 = 0;
		Color color15 = this.ThirdCircle.color;
		float num16 = color15.a = (float)num15;
		Color color16 = this.ThirdCircle.color = color15;
		int num17 = 0;
		Color color17 = this.ThirdLabel.color;
		float num18 = color17.a = (float)num17;
		Color color18 = this.ThirdLabel.color = color17;
	}

	public virtual void UpdateText()
	{
		if (this.Open)
		{
			if (this.Carrying > 0)
			{
				this.Label.text = "     " + "Remove Body Part";
			}
			else
			{
				this.Label.text = string.Empty;
			}
			this.SecondLabel.text = "     " + "Store Body Part";
			this.ThirdLabel.text = "     " + "Close";
		}
		else
		{
			this.Label.text = string.Empty;
			this.SecondLabel.text = "     " + "Equip";
			this.ThirdLabel.text = "     " + "Open";
		}
		this.Deselect();
	}

	public virtual void Unequip()
	{
		this.Equipped = false;
		this.MyCollider.enabled = true;
		this.LidPivot.localEulerAngles = new Vector3(81.33333f, (float)90, 93.33333f);
		this.Lid.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		this.OpenRotation = this.Lid.rotation;
		this.LidPivot.localEulerAngles = new Vector3((float)90, (float)90, (float)90);
		this.Lid.localEulerAngles = new Vector3((float)270, (float)0, (float)0);
		this.ClosedRotation = this.Lid.rotation;
	}

	public virtual void RemoveBodyParts()
	{
		this.Yandere.DropItem();
		this.Yandere.BodyParts[this.IDs[this.Carrying]].active = true;
		this.BodyParts[this.IDs[this.Carrying]].active = false;
		this.Yandere.Armed = true;
		this.Yandere.EquippedID = this.IDs[this.Carrying];
		this.Yandere.EquippedType = 3;
		if (this.IDs[this.Carrying] == 1)
		{
			this.Yandere.EquippedSize = 2;
			this.Yandere.EquippedName = "Head";
		}
		else if (this.IDs[this.Carrying] == 2)
		{
			this.Yandere.EquippedSize = 3;
			this.Yandere.EquippedName = "Torso";
		}
		else if (this.IDs[this.Carrying] == 3)
		{
			this.Yandere.EquippedSize = 2;
			this.Yandere.EquippedName = "Left Arm";
		}
		else if (this.IDs[this.Carrying] == 4)
		{
			this.Yandere.EquippedSize = 2;
			this.Yandere.EquippedName = "Right Arm";
		}
		else if (this.IDs[this.Carrying] == 5)
		{
			this.Yandere.EquippedSize = 2;
			this.Yandere.EquippedName = "Left Leg";
		}
		else if (this.IDs[this.Carrying] == 6)
		{
			this.Yandere.EquippedSize = 2;
			this.Yandere.EquippedName = "Right Leg";
		}
		this.Carrying--;
	}

	public virtual void Main()
	{
	}
}
