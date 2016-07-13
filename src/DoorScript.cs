using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DoorScript : MonoBehaviour
{
	public Transform RelativeCharacter;

	public HideColliderScript HideCollider;

	public StudentScript Student;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public float[] ClosedPositions;

	public float[] OpenPositions;

	public Transform[] Doors;

	public Texture[] Plates;

	public UILabel[] Labels;

	public float[] OriginX;

	public bool HidingSpot;

	public bool Swinging;

	public bool Locked;

	public bool North;

	public bool Open;

	public bool Near;

	public float ShiftNorth;

	public float ShiftSouth;

	public float Rotation;

	public float Swing;

	public float Timer;

	public Renderer Sign;

	public string RoomName;

	public string Facing;

	public int RoomID;

	public int Club;

	public DoorScript()
	{
		this.ShiftNorth = -0.1f;
		this.ShiftSouth = 0.1f;
		this.Swing = 150f;
		this.RoomName = string.Empty;
		this.Facing = string.Empty;
	}

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		if (this.Swinging)
		{
			this.OriginX[0] = this.Doors[0].transform.localPosition.z;
			if (Extensions.get_length(this.OriginX) > 1)
			{
				this.OriginX[1] = this.Doors[1].transform.localPosition.z;
			}
		}
		if (Extensions.get_length(this.Labels) > 0)
		{
			this.Labels[0].text = this.RoomName;
			this.Labels[1].text = this.RoomName;
			this.UpdatePlate();
		}
		if (this.Club != 0 && PlayerPrefs.GetInt("Club_" + this.Club + "_Closed") == 1)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (Vector3.Distance(this.Yandere.transform.position + Vector3.up * (float)1, this.transform.position) < (float)1)
		{
			if (!this.Near)
			{
				this.Yandere.Location.Label.text = this.RoomName;
				this.Yandere.Location.Show = true;
				this.Near = true;
			}
		}
		else if (this.Near)
		{
			this.Yandere.Location.Show = false;
			this.Near = false;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (!this.Open)
			{
				this.OpenDoor();
			}
			else
			{
				this.CloseDoor();
			}
		}
		if (this.Timer < (float)1)
		{
			this.Timer += Time.deltaTime;
			if (!this.Open)
			{
				for (int i = 0; i < Extensions.get_length(this.Doors); i++)
				{
					if (!this.Swinging)
					{
						float x = Mathf.Lerp(this.Doors[i].localPosition.x, this.ClosedPositions[i], Time.deltaTime * (float)10);
						Vector3 localPosition = this.Doors[i].localPosition;
						float num = localPosition.x = x;
						Vector3 vector = this.Doors[i].localPosition = localPosition;
					}
					else
					{
						this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)10);
						float z = Mathf.Lerp(this.Doors[i].localPosition.z, this.OriginX[i], Time.deltaTime * (float)10);
						Vector3 localPosition2 = this.Doors[i].localPosition;
						float num2 = localPosition2.z = z;
						Vector3 vector2 = this.Doors[i].localPosition = localPosition2;
						if (i == 0)
						{
							float rotation = this.Rotation;
							Vector3 localEulerAngles = this.Doors[i].localEulerAngles;
							float num3 = localEulerAngles.y = rotation;
							Vector3 vector3 = this.Doors[i].localEulerAngles = localEulerAngles;
						}
						else
						{
							float y = this.Rotation * (float)-1;
							Vector3 localEulerAngles2 = this.Doors[i].localEulerAngles;
							float num4 = localEulerAngles2.y = y;
							Vector3 vector4 = this.Doors[i].localEulerAngles = localEulerAngles2;
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < Extensions.get_length(this.Doors); i++)
				{
					if (!this.Swinging)
					{
						float x2 = Mathf.Lerp(this.Doors[i].localPosition.x, this.OpenPositions[i], Time.deltaTime * (float)10);
						Vector3 localPosition3 = this.Doors[i].localPosition;
						float num5 = localPosition3.x = x2;
						Vector3 vector5 = this.Doors[i].localPosition = localPosition3;
					}
					else
					{
						if (this.North)
						{
							float z2 = Mathf.Lerp(this.Doors[i].localPosition.z, this.OriginX[i] + this.ShiftNorth, Time.deltaTime * (float)10);
							Vector3 localPosition4 = this.Doors[i].localPosition;
							float num6 = localPosition4.z = z2;
							Vector3 vector6 = this.Doors[i].localPosition = localPosition4;
						}
						else
						{
							float z3 = Mathf.Lerp(this.Doors[i].localPosition.z, this.OriginX[i] + this.ShiftSouth, Time.deltaTime * (float)10);
							Vector3 localPosition5 = this.Doors[i].localPosition;
							float num7 = localPosition5.z = z3;
							Vector3 vector7 = this.Doors[i].localPosition = localPosition5;
						}
						if (this.North)
						{
							this.Rotation = Mathf.Lerp(this.Rotation, this.Swing, Time.deltaTime * (float)10);
						}
						else
						{
							this.Rotation = Mathf.Lerp(this.Rotation, this.Swing * (float)-1, Time.deltaTime * (float)10);
						}
						if (i == 0)
						{
							float rotation2 = this.Rotation;
							Vector3 localEulerAngles3 = this.Doors[i].localEulerAngles;
							float num8 = localEulerAngles3.y = rotation2;
							Vector3 vector8 = this.Doors[i].localEulerAngles = localEulerAngles3;
						}
						else
						{
							float y2 = this.Rotation * (float)-1;
							Vector3 localEulerAngles4 = this.Doors[i].localEulerAngles;
							float num9 = localEulerAngles4.y = y2;
							Vector3 vector9 = this.Doors[i].localEulerAngles = localEulerAngles4;
						}
					}
				}
			}
		}
		else if (this.Locked)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.active = false;
		}
		if (Input.GetKeyDown("space"))
		{
			this.UpdatePlate();
		}
	}

	public virtual void OpenDoor()
	{
		this.Prompt.Label[0].text = "     " + "Close";
		this.Open = true;
		this.Timer = (float)0;
		if (this.HidingSpot)
		{
			UnityEngine.Object.Destroy(this.HideCollider.GetComponent("BoxCollider"));
		}
		this.CheckDirection();
	}

	public virtual void LockDoor()
	{
		this.Open = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	public virtual void CheckDirection()
	{
		this.North = false;
		if (this.Student != null)
		{
			this.RelativeCharacter = this.Student.transform;
		}
		else
		{
			this.RelativeCharacter = this.Yandere.transform;
		}
		if (this.Facing == "North")
		{
			if (this.RelativeCharacter.position.z < this.transform.position.z)
			{
				this.North = true;
			}
		}
		else if (this.Facing == "South")
		{
			if (this.RelativeCharacter.position.z > this.transform.position.z)
			{
				this.North = true;
			}
		}
		else if (this.Facing == "East")
		{
			if (this.RelativeCharacter.position.x < this.transform.position.x)
			{
				this.North = true;
			}
		}
		else if (this.Facing == "West" && this.RelativeCharacter.position.x > this.transform.position.x)
		{
			this.North = true;
		}
		this.Student = null;
	}

	public virtual void CloseDoor()
	{
		this.Prompt.Label[0].text = "     " + "Open";
		this.Open = false;
		this.Timer = (float)0;
		if (this.HidingSpot)
		{
			this.HideCollider.gameObject.AddComponent("BoxCollider");
			int num = 2;
			Component component = this.HideCollider.GetComponent("BoxCollider");
			object property = UnityRuntimeServices.GetProperty(component, "size");
			RuntimeServices.SetProperty(property, "z", num);
			UnityRuntimeServices.PropagateValueTypeChanges(new UnityRuntimeServices.ValueTypeChange[]
			{
				new UnityRuntimeServices.MemberValueTypeChange(component, "size", property)
			});
			RuntimeServices.SetProperty(this.HideCollider.GetComponent("BoxCollider"), "isTrigger", true);
			this.HideCollider.MyCollider = (Collider)this.HideCollider.GetComponent("BoxCollider");
		}
	}

	public virtual void UpdatePlate()
	{
		int roomID = this.RoomID;
		if (roomID == 1)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.75f);
		}
		else if (roomID == 2)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.5f);
		}
		else if (roomID == 3)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.25f);
		}
		else if (roomID == 4)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, (float)0);
		}
		else if (roomID == 5)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
		}
		else if (roomID == 6)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
		}
		else if (roomID == 7)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
		}
		else if (roomID == 8)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, (float)0);
		}
		else if (roomID == 9)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
		}
		else if (roomID == 10)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
		}
		else if (roomID == 11)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
		}
		else if (roomID == 12)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, (float)0);
		}
		else if (roomID == 13)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
		}
		else if (roomID == 14)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
		}
		else if (roomID == 15)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
		}
		else if (roomID == 16)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, (float)0);
		}
		else if (roomID == 17)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.75f);
		}
		else if (roomID == 18)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.5f);
		}
		else if (roomID == 19)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.25f);
		}
		else if (roomID == 20)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, (float)0);
		}
		else if (roomID == 21)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
		}
		else if (roomID == 22)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
		}
		else if (roomID == 23)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
		}
		else if (roomID == 24)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, (float)0);
		}
		else if (roomID == 25)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
		}
		else if (roomID == 26)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
		}
		else if (roomID == 27)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
		}
		else if (roomID == 28)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, (float)0);
		}
		else if (roomID == 29)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
		}
		else if (roomID == 30)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
		}
		else if (roomID == 31)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
		}
		else if (roomID == 32)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, (float)0);
		}
		else if (roomID == 33)
		{
			this.Sign.material.mainTexture = this.Plates[3];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.75f);
		}
		else if (roomID == 34)
		{
			this.Sign.material.mainTexture = this.Plates[3];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.5f);
		}
	}

	public virtual void Main()
	{
	}
}
