using System;
using UnityEngine;

[Serializable]
public class RagdollDragScript : MonoBehaviour
{
	public ControllerInventoryScript ControllerInventoryPanel;

	public RagdollScript Ragdoll;

	public YandereScript Yandere;

	public UISprite Black;

	public GameObject SecondButtonObject;

	public GameObject ButtonObject;

	public GameObject LabelObject;

	public Transform ButtonPanel;

	public Camera UICamera;

	public UISprite Button;

	public UILabel Label;

	public UISprite SecondButton;

	public UILabel SecondLabel;

	public bool InView;

	public LimbScript ClosestLimb;

	public LimbScript[] Limbs;

	public float DistanceToPlayer;

	public float ShortestDistance;

	public int DragTimer;

	public bool FadeOut;

	public virtual void Start()
	{
		this.ControllerInventoryPanel = (ControllerInventoryScript)GameObject.Find("ControllerInventoryPanel").GetComponent(typeof(ControllerInventoryScript));
		this.Yandere = ((StudentManagerScript)GameObject.Find("StudentManager").GetComponent(typeof(StudentManagerScript))).YandereChan;
		this.ButtonPanel = (Transform)GameObject.Find("ButtonPanel").GetComponent(typeof(Transform));
		this.UICamera = (Camera)GameObject.Find("UI Camera").GetComponent(typeof(Camera));
		this.Black = (UISprite)GameObject.Find("ChopUpBlack").GetComponent(typeof(UISprite));
		this.Button = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.ButtonObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
		this.Button.transform.parent = this.ButtonPanel;
		this.Button.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Button.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		this.Label = (UILabel)((GameObject)UnityEngine.Object.Instantiate(this.LabelObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UILabel));
		this.Label.transform.parent = this.ButtonPanel;
		this.Label.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Label.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num3 = 0;
		Color color3 = this.Label.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Label.color = color3;
		this.Label.text = "     " + "Drag";
		this.SecondButton = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.SecondButtonObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
		this.SecondButton.transform.parent = this.ButtonPanel;
		this.SecondButton.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.SecondButton.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num5 = 0;
		Color color5 = this.SecondButton.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.SecondButton.color = color5;
		this.SecondLabel = (UILabel)((GameObject)UnityEngine.Object.Instantiate(this.LabelObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UILabel));
		this.SecondLabel.transform.parent = this.ButtonPanel;
		this.SecondLabel.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.SecondLabel.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num7 = 0;
		Color color7 = this.SecondLabel.color;
		float num8 = color7.a = (float)num7;
		Color color8 = this.SecondLabel.color = color7;
		this.SecondLabel.text = "     " + "Chop Up";
	}

	public virtual void Update()
	{
		if (this.InView)
		{
			this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
			int num = 0;
			Color color = this.Button.color;
			float num2 = color.a = (float)num;
			Color color2 = this.Button.color = color;
			int num3 = 0;
			Color color3 = this.Label.color;
			float num4 = color3.a = (float)num3;
			Color color4 = this.Label.color = color3;
			int num5 = 0;
			Color color5 = this.SecondButton.color;
			float num6 = color5.a = (float)num5;
			Color color6 = this.SecondButton.color = color5;
			int num7 = 0;
			Color color7 = this.SecondLabel.color;
			float num8 = color7.a = (float)num7;
			Color color8 = this.SecondLabel.color = color7;
			this.UpdateButton();
			if (!this.Yandere.Dragging)
			{
				if (this.DistanceToPlayer < (float)2)
				{
					if (this.DistanceToPlayer <= (float)1)
					{
						if (this.Yandere.NearestRagdoll == null)
						{
							this.Yandere.NearestRagdoll = this.gameObject;
						}
						if (this.Yandere.NearestPickup == null)
						{
							this.Yandere.NearestPickup = this.gameObject;
						}
						if (this.Yandere.NearestRagdoll == this.gameObject && this.Yandere.NearestPickup == this.gameObject)
						{
							this.SecondButton.color = new Color((float)1, (float)1, (float)1, (float)1);
							int num9 = 1;
							Color color9 = this.SecondLabel.color;
							float num10 = color9.a = (float)num9;
							Color color10 = this.SecondLabel.color = color9;
							if (Input.GetButtonDown("B"))
							{
								this.ShortestDistance = (float)1;
								for (int i = 0; i < 4; i++)
								{
									if (Vector3.Distance(this.Limbs[i].transform.position, this.Yandere.transform.position) < this.ShortestDistance)
									{
										this.ShortestDistance = Vector3.Distance(this.Limbs[i].transform.position, this.Yandere.transform.position);
										this.ClosestLimb = this.Limbs[i];
									}
								}
								this.ClosestLimb.Dragging = true;
								this.Yandere.GrabbedLimb = this.ClosestLimb;
								this.Yandere.Dragging = true;
								GameObject gameObject;
								if (this.Yandere.Armed)
								{
									if (this.Yandere.EquippedSize > 1)
									{
										if (this.Yandere.EquippedType != 3)
										{
											gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Yandere.WeaponPickups[this.Yandere.EquippedID], this.Yandere.RightHand.position, Quaternion.identity);
											this.Yandere.Weapons[this.Yandere.EquippedID].active = false;
										}
										else
										{
											gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Yandere.BodyPartPickups[this.Yandere.EquippedID], this.Yandere.RightHand.position, Quaternion.identity);
											this.Yandere.BodyParts[this.Yandere.EquippedID].active = false;
										}
									}
									else if (this.Yandere.EquippedType == 2)
									{
										this.Yandere.Weapons[this.Yandere.EquippedID].active = false;
									}
									else
									{
										this.Yandere.BodyParts[this.Yandere.EquippedID].active = false;
									}
								}
								if (gameObject != null)
								{
									gameObject.transform.eulerAngles = this.Yandere.RightHand.eulerAngles;
									float y = gameObject.transform.eulerAngles.y - (float)180;
									Vector3 eulerAngles = gameObject.transform.eulerAngles;
									float num11 = eulerAngles.y = y;
									Vector3 vector = gameObject.transform.eulerAngles = eulerAngles;
								}
								this.Yandere.EquippedName = string.Empty;
								this.Yandere.EquippedSize = 0;
								this.Yandere.EquippedType = 0;
								this.Yandere.EquippedID = 0;
								this.Yandere.Armed = false;
								this.UpdateLabel();
							}
							if (this.Yandere.NearestPickup == this.gameObject)
							{
								this.Button.color = new Color((float)1, (float)1, (float)1, (float)1);
								int num12 = 1;
								Color color11 = this.Label.color;
								float num13 = color11.a = (float)num12;
								Color color12 = this.Label.color = color11;
								if (Input.GetButtonDown("Y") && this.Black.color.a <= (float)0)
								{
									this.Yandere.Character.animation.CrossFade("f02_idle_10");
									this.Yandere.AcceptingInput = false;
									this.FadeOut = true;
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
					}
				}
				else
				{
					int num14 = 0;
					Color color13 = this.Button.color;
					float num15 = color13.a = (float)num14;
					Color color14 = this.Button.color = color13;
					int num16 = 0;
					Color color15 = this.Label.color;
					float num17 = color15.a = (float)num16;
					Color color16 = this.Label.color = color15;
					int num18 = 0;
					Color color17 = this.SecondButton.color;
					float num19 = color17.a = (float)num18;
					Color color18 = this.SecondButton.color = color17;
					int num20 = 0;
					Color color19 = this.SecondLabel.color;
					float num21 = color19.a = (float)num20;
					Color color20 = this.SecondLabel.color = color19;
				}
			}
			else
			{
				if (this.DistanceToPlayer > (float)2)
				{
					int num22 = 0;
					Color color21 = this.Button.color;
					float num23 = color21.a = (float)num22;
					Color color22 = this.Button.color = color21;
					int num24 = 0;
					Color color23 = this.Label.color;
					float num25 = color23.a = (float)num24;
					Color color24 = this.Label.color = color23;
					int num26 = 0;
					Color color25 = this.SecondButton.color;
					float num27 = color25.a = (float)num26;
					Color color26 = this.SecondButton.color = color25;
					int num28 = 0;
					Color color27 = this.SecondLabel.color;
					float num29 = color27.a = (float)num28;
					Color color28 = this.SecondLabel.color = color27;
				}
				if (this.Yandere.NearestRagdoll == this.gameObject)
				{
					this.Button.color = new Color((float)1, (float)1, (float)1, (float)1);
					int num30 = 1;
					Color color29 = this.Label.color;
					float num31 = color29.a = (float)num30;
					Color color30 = this.Label.color = color29;
					this.SecondButton.color = new Color((float)1, (float)1, (float)1, (float)1);
					int num32 = 1;
					Color color31 = this.SecondLabel.color;
					float num33 = color31.a = (float)num32;
					Color color32 = this.SecondLabel.color = color31;
					this.DragTimer++;
					if (this.DragTimer > 1 && Input.GetButtonDown("B"))
					{
						this.Yandere.Dragging = false;
						this.Limbs[0].Dragging = false;
						this.Limbs[1].Dragging = false;
						this.Limbs[2].Dragging = false;
						this.Limbs[3].Dragging = false;
						this.UpdateLabel();
						this.DragTimer = 0;
					}
				}
			}
		}
		if (this.FadeOut)
		{
			float a = this.Black.color.a + Time.deltaTime;
			Color color33 = this.Black.color;
			float num34 = color33.a = a;
			Color color34 = this.Black.color = color33;
			if (this.Black.color.a >= (float)1)
			{
				this.Yandere.YandereMeter = this.Yandere.YandereMeter + (float)20;
				this.Ragdoll.ChopUp();
			}
		}
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
		Color color3 = this.Label.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Label.color = color3;
		int num5 = 0;
		Color color5 = this.SecondButton.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.SecondButton.color = color5;
		int num7 = 0;
		Color color7 = this.SecondLabel.color;
		float num8 = color7.a = (float)num7;
		Color color8 = this.SecondLabel.color = color7;
	}

	public virtual void UpdateButton()
	{
		Vector2 vector = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.25f);
		this.Button.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		Vector2 vector2 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.25f);
		this.Label.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
		this.Button.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
		float a = 0.5f;
		Color color = this.Label.color;
		float num = color.a = a;
		Color color2 = this.Label.color = color;
		Vector2 vector3 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.25f);
		this.SecondButton.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector3.x, vector3.y + (float)35, 1f));
		Vector2 vector4 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.25f);
		this.SecondLabel.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector4.x, vector4.y + (float)35, 1f));
		this.SecondButton.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
		float a2 = 0.5f;
		Color color3 = this.SecondLabel.color;
		float num2 = color3.a = a2;
		Color color4 = this.SecondLabel.color = color3;
	}

	public virtual void UpdateLabel()
	{
		if (this.Yandere.Dragging)
		{
			this.Label.text = "     " + "Drop";
		}
		else
		{
			this.Label.text = "     " + "Drag";
		}
	}

	public virtual void Main()
	{
	}
}
