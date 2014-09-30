using System;
using UnityEngine;

[Serializable]
public class IncineratorScript : MonoBehaviour
{
	public Transform BodyPartDisposal;

	public Transform DumpingPoint;

	public Transform ArmsHinge;

	public Transform DoorHinge;

	public GameObject Smoke;

	public bool Occupied;

	public bool Open;

	public GameObject NewBodyPart;

	public YandereScript Yandere;

	public GameObject ButtonObject;

	public GameObject LabelObject;

	public Transform ButtonPanel;

	public Camera UICamera;

	public UISprite Button;

	public UILabel Label;

	public bool YHeldDown;

	public bool InView;

	public float OpenTimer;

	public float Distance;

	public virtual void LateUpdate()
	{
		if (this.Open)
		{
			if (this.ArmsHinge.localEulerAngles.z < (float)359)
			{
				float z = this.ArmsHinge.localEulerAngles.z + Time.deltaTime * 67.5f * (float)5;
				Vector3 localEulerAngles = this.ArmsHinge.localEulerAngles;
				float num = localEulerAngles.z = z;
				Vector3 vector = this.ArmsHinge.localEulerAngles = localEulerAngles;
				if (this.ArmsHinge.localEulerAngles.z < (float)180)
				{
					int num2 = 359;
					Vector3 localEulerAngles2 = this.ArmsHinge.localEulerAngles;
					float num3 = localEulerAngles2.z = (float)num2;
					Vector3 vector2 = this.ArmsHinge.localEulerAngles = localEulerAngles2;
				}
			}
			if (this.DoorHinge.localEulerAngles.z < (float)359)
			{
				float z2 = this.DoorHinge.localEulerAngles.z + Time.deltaTime * (float)102 * (float)5;
				Vector3 localEulerAngles3 = this.DoorHinge.localEulerAngles;
				float num4 = localEulerAngles3.z = z2;
				Vector3 vector3 = this.DoorHinge.localEulerAngles = localEulerAngles3;
				if (this.DoorHinge.localEulerAngles.z < (float)180)
				{
					int num5 = 359;
					Vector3 localEulerAngles4 = this.DoorHinge.localEulerAngles;
					float num6 = localEulerAngles4.z = (float)num5;
					Vector3 vector4 = this.DoorHinge.localEulerAngles = localEulerAngles4;
				}
			}
		}
		else
		{
			if (this.ArmsHinge.localEulerAngles.z > 292.5f)
			{
				float z3 = this.ArmsHinge.localEulerAngles.z - Time.deltaTime * 67.5f * (float)10;
				Vector3 localEulerAngles5 = this.ArmsHinge.localEulerAngles;
				float num7 = localEulerAngles5.z = z3;
				Vector3 vector5 = this.ArmsHinge.localEulerAngles = localEulerAngles5;
			}
			if (this.DoorHinge.localEulerAngles.z > (float)258)
			{
				float z4 = this.DoorHinge.localEulerAngles.z - Time.deltaTime * (float)102 * (float)10;
				Vector3 localEulerAngles6 = this.DoorHinge.localEulerAngles;
				float num8 = localEulerAngles6.z = z4;
				Vector3 vector6 = this.DoorHinge.localEulerAngles = localEulerAngles6;
			}
		}
	}

	public virtual void Start()
	{
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
		this.Label = (UILabel)((GameObject)UnityEngine.Object.Instantiate(this.LabelObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UILabel));
		this.Label.transform.parent = this.ButtonPanel;
		this.Label.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Label.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num3 = 0;
		Color color3 = this.Label.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Label.color = color3;
		this.Label.text = "     " + "Dump";
	}

	public virtual void Update()
	{
		if (this.Yandere.Dragging || this.Yandere.EquippedType == 3)
		{
			this.Label.text = "     " + "Dump";
		}
		else if (this.Occupied)
		{
			this.Label.text = "     " + "Activate";
		}
		if (this.InView)
		{
			this.Distance = Vector3.Distance(this.Yandere.transform.position, this.DumpingPoint.position);
			if (this.Distance < (float)5)
			{
				if (this.Yandere.Dragging || (!this.Yandere.Dumping && this.Occupied) || this.Yandere.EquippedType == 3)
				{
					Vector2 vector = this.UICamera.WorldToScreenPoint(this.DumpingPoint.position + Vector3.up * (float)1);
					this.Button.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
					Vector2 vector2 = this.UICamera.WorldToScreenPoint(this.DumpingPoint.position + Vector3.up * (float)1);
					this.Label.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
					this.Button.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
					float a = 0.5f;
					Color color = this.Label.color;
					float num = color.a = a;
					Color color2 = this.Label.color = color;
					if (this.Distance < (float)1)
					{
						if (this.Yandere.NearestPickupA == null)
						{
							this.Yandere.NearestPickupA = this.gameObject;
						}
						if (this.Yandere.NearestPickupA == this.gameObject)
						{
							this.Button.color = new Color((float)1, (float)1, (float)1, (float)1);
							int num2 = 1;
							Color color3 = this.Label.color;
							float num3 = color3.a = (float)num2;
							Color color4 = this.Label.color = color3;
							if (Input.GetButtonDown("A"))
							{
								if (this.Yandere.Dragging)
								{
									this.Open = true;
									this.Yandere.DumpingPoint = this.DumpingPoint;
									this.Yandere.Dumping = true;
									this.Yandere.Dragging = false;
									GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Yandere.DumpChan, this.DumpingPoint.position, Quaternion.identity);
									gameObject.transform.eulerAngles = this.DumpingPoint.localEulerAngles;
									UnityEngine.Object.Destroy(this.Yandere.NearestRagdoll.transform.parent.transform.parent.transform.parent.gameObject);
									this.Occupied = true;
								}
								else if (this.Yandere.EquippedType == 3)
								{
									this.Open = true;
									this.NewBodyPart = (GameObject)UnityEngine.Object.Instantiate(this.Yandere.BodyPartPickups[this.Yandere.EquippedID], this.BodyPartDisposal.position, Quaternion.identity);
									UnityEngine.Object.Destroy((BodyPartScript)this.NewBodyPart.GetComponent(typeof(BodyPartScript)));
									UnityEngine.Object.Destroy((BoxCollider)this.NewBodyPart.GetComponent(typeof(BoxCollider)));
									this.NewBodyPart.AddComponent(typeof(CapsuleCollider));
									this.NewBodyPart.rigidbody.constraints = RigidbodyConstraints.None;
									float y = (float)90 - this.transform.eulerAngles.y;
									Vector3 eulerAngles = this.NewBodyPart.transform.eulerAngles;
									float num4 = eulerAngles.y = y;
									Vector3 vector3 = this.NewBodyPart.transform.eulerAngles = eulerAngles;
									int num5 = 90;
									Vector3 eulerAngles2 = this.NewBodyPart.transform.eulerAngles;
									float num6 = eulerAngles2.z = (float)num5;
									Vector3 vector4 = this.NewBodyPart.transform.eulerAngles = eulerAngles2;
									this.Yandere.BodyParts[this.Yandere.EquippedID].active = false;
									this.Yandere.Armed = false;
									this.Yandere.EquippedID = 0;
									this.Yandere.EquippedType = 0;
									this.Yandere.EquippedSize = 0;
									this.Yandere.EquippedName = string.Empty;
									this.Occupied = true;
								}
								else if (this.Occupied)
								{
									this.Smoke.active = true;
									this.Occupied = false;
								}
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
				this.Deselect();
			}
		}
		else
		{
			this.Deselect();
		}
		if (this.Open)
		{
			this.OpenTimer += Time.deltaTime;
			if (this.OpenTimer > (float)1)
			{
				this.OpenTimer = (float)0;
				this.Open = false;
				if (this.NewBodyPart != null)
				{
					UnityEngine.Object.Destroy(this.NewBodyPart);
				}
			}
		}
	}

	public virtual void Deselect()
	{
		if (this.Yandere.NearestPickupA == this.gameObject)
		{
			this.Yandere.NearestPickupA = null;
		}
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		int num3 = 0;
		Color color3 = this.Label.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Label.color = color3;
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
	}

	public virtual void Main()
	{
	}
}
