using System;
using UnityEngine;

[Serializable]
public class MopScript : MonoBehaviour
{
	public Transform MopParent;

	public Transform Head;

	public Transform Bucket;

	public Vector3 StartingPosition;

	public YandereScript Yandere;

	public MopHeadScript MopHead;

	public GameObject ButtonObject;

	public GameObject LabelObject;

	public Transform ButtonPanel;

	public Camera UICamera;

	public UISprite Button;

	public UILabel Label;

	public int Destination;

	public float Distance;

	public bool NearBucket;

	public bool Mopping;

	public bool Dipping;

	public MopScript()
	{
		this.Destination = 1;
	}

	public virtual void Start()
	{
		this.StartingPosition = this.Head.transform.localPosition;
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
		this.Label.text = "     " + "Sweep";
	}

	public virtual void LateUpdate()
	{
		this.Head.transform.localPosition = this.StartingPosition;
		if (this.Yandere.EquippedID == 10)
		{
			Vector2 vector = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.1f);
			this.Button.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
			Vector2 vector2 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 0.1f);
			this.Label.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
			int num = 1;
			Color color = this.Button.color;
			float num2 = color.a = (float)num;
			Color color2 = this.Button.color = color;
			int num3 = 1;
			Color color3 = this.Label.color;
			float num4 = color3.a = (float)num3;
			Color color4 = this.Label.color = color3;
			if (this.Yandere.NearestPickupA != this.gameObject)
			{
				this.Yandere.NearestPickupA = null;
				this.Yandere.NearestPickupA = this.gameObject;
			}
			if (!this.NearBucket)
			{
				if (Input.GetButton("A"))
				{
					this.MopHead.Mopping = true;
					this.Mopping = true;
				}
				else
				{
					this.MopHead.Mopping = false;
					this.Mopping = false;
				}
			}
			else if (Input.GetButtonDown("A"))
			{
				this.Destination = 1;
				this.Dipping = true;
			}
		}
		else
		{
			int num5 = 0;
			Color color5 = this.Button.color;
			float num6 = color5.a = (float)num5;
			Color color6 = this.Button.color = color5;
			int num7 = 0;
			Color color7 = this.Label.color;
			float num8 = color7.a = (float)num7;
			Color color8 = this.Label.color = color7;
		}
		if (!this.Dipping)
		{
			if (this.Mopping)
			{
				this.transform.position = Vector3.Lerp(this.transform.position, this.MopParent.position, Time.deltaTime * (float)10);
				if (this.transform.localEulerAngles.y < (float)325)
				{
					float y = this.transform.localEulerAngles.y + Time.deltaTime * (float)360;
					Vector3 localEulerAngles = this.transform.localEulerAngles;
					float num9 = localEulerAngles.y = y;
					Vector3 vector3 = this.transform.localEulerAngles = localEulerAngles;
					if (this.transform.localEulerAngles.y > (float)305)
					{
						int num10 = 305;
						Vector3 localEulerAngles2 = this.transform.localEulerAngles;
						float num11 = localEulerAngles2.y = (float)num10;
						Vector3 vector4 = this.transform.localEulerAngles = localEulerAngles2;
					}
				}
				float x = Mathf.Lerp(this.Head.localEulerAngles.x, 33.5f, Time.deltaTime * (float)10);
				Vector3 localEulerAngles3 = this.Head.localEulerAngles;
				float num12 = localEulerAngles3.x = x;
				Vector3 vector5 = this.Head.localEulerAngles = localEulerAngles3;
				if (this.Destination == 1)
				{
					this.MopParent.localPosition = Vector3.MoveTowards(this.MopParent.localPosition, new Vector3(-0.21f, 0.6466666f, 0.05f), Time.deltaTime);
					if (this.MopParent.localPosition == new Vector3(-0.21f, 0.6466666f, 0.05f))
					{
						this.Destination = 2;
					}
				}
				else
				{
					this.MopParent.localPosition = Vector3.MoveTowards(this.MopParent.localPosition, new Vector3(0.21f, 0.6466666f, 0.47f), Time.deltaTime);
					if (this.MopParent.localPosition == new Vector3(0.21f, 0.6466666f, 0.47f))
					{
						this.Destination = 1;
					}
				}
			}
			else
			{
				this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)0, (float)0, -0.15f), Time.deltaTime * (float)10);
				if (this.transform.localEulerAngles.y > (float)270)
				{
					float y2 = this.transform.localEulerAngles.y - Time.deltaTime * (float)360;
					Vector3 localEulerAngles4 = this.transform.localEulerAngles;
					float num13 = localEulerAngles4.y = y2;
					Vector3 vector6 = this.transform.localEulerAngles = localEulerAngles4;
					if (this.transform.localEulerAngles.y < (float)270)
					{
						int num14 = 270;
						Vector3 localEulerAngles5 = this.transform.localEulerAngles;
						float num15 = localEulerAngles5.y = (float)num14;
						Vector3 vector7 = this.transform.localEulerAngles = localEulerAngles5;
					}
				}
				float x2 = Mathf.Lerp(this.Head.localEulerAngles.x, (float)0, Time.deltaTime * (float)10);
				Vector3 localEulerAngles6 = this.Head.localEulerAngles;
				float num16 = localEulerAngles6.x = x2;
				Vector3 vector8 = this.Head.localEulerAngles = localEulerAngles6;
			}
		}
		else if (this.Destination == 1)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.Bucket.position + Vector3.up * 1.366667f, Time.deltaTime * 2.5f);
			if (this.transform.position == this.Bucket.position + Vector3.up * 1.366667f)
			{
				this.Destination = 2;
			}
		}
		else if (this.Destination == 2)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.Bucket.position + Vector3.up * (float)1, Time.deltaTime * 2.5f);
			if (this.transform.position.y < this.Bucket.position.y + 1.0001f)
			{
				this.MopHead.Bloodiness = (float)0;
				int num17 = 0;
				Color color9 = this.MopHead.Blood.material.color;
				float num18 = color9.a = (float)num17;
				Color color10 = this.MopHead.Blood.material.color = color9;
				this.Destination = 3;
			}
		}
		else if (this.Destination == 3)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.Bucket.position + Vector3.up * 1.366667f, Time.deltaTime * 2.5f);
			if (this.transform.position == this.Bucket.position + Vector3.up * 1.366667f)
			{
				this.Label.text = "     " + "Sweep";
				this.Destination = 1;
				this.Dipping = false;
			}
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.name == "MopBucket" && !this.Mopping && this.MopHead.Bloodiness > (float)0)
		{
			this.Bucket = other.gameObject.transform;
			this.Label.text = "     " + "Dip";
			this.NearBucket = true;
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (other.name == "MopBucket")
		{
			this.Label.text = "     " + "Sweep";
			this.NearBucket = false;
		}
	}

	public virtual void Main()
	{
	}
}
