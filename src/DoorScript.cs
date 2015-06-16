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

	public bool HidingSpot;

	public bool Swinging;

	public bool Locked;

	public bool North;

	public bool Open;

	public bool Near;

	public float Rotation;

	public float OriginX;

	public float Shift;

	public float Swing;

	public float Timer;

	public string RoomName;

	public string Facing;

	public DoorScript()
	{
		this.Shift = 0.065f;
		this.Swing = 150f;
		this.RoomName = string.Empty;
		this.Facing = string.Empty;
	}

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.OriginX = this.Doors[0].transform.localPosition.x;
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
						float x2 = Mathf.Lerp(this.Doors[i].localPosition.x, this.OriginX, Time.deltaTime * (float)10);
						Vector3 localPosition2 = this.Doors[i].localPosition;
						float num2 = localPosition2.x = x2;
						Vector3 vector2 = this.Doors[i].localPosition = localPosition2;
						this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)10);
						if (i == 0)
						{
							float rotation = this.Rotation;
							Vector3 localEulerAngles = this.Doors[i].localEulerAngles;
							float num3 = localEulerAngles.y = rotation;
							Vector3 vector3 = this.Doors[i].localEulerAngles = localEulerAngles;
						}
						else
						{
							float y = this.Rotation * (float)-1 + (float)180;
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
						float x3 = Mathf.Lerp(this.Doors[i].localPosition.x, this.OpenPositions[i], Time.deltaTime * (float)10);
						Vector3 localPosition3 = this.Doors[i].localPosition;
						float num5 = localPosition3.x = x3;
						Vector3 vector5 = this.Doors[i].localPosition = localPosition3;
					}
					else
					{
						if (this.North)
						{
							float x4 = Mathf.Lerp(this.Doors[i].localPosition.x, this.OriginX + this.Shift, Time.deltaTime * (float)10);
							Vector3 localPosition4 = this.Doors[i].localPosition;
							float num6 = localPosition4.x = x4;
							Vector3 vector6 = this.Doors[i].localPosition = localPosition4;
						}
						else
						{
							float x5 = Mathf.Lerp(this.Doors[i].localPosition.x, this.OriginX + this.Shift * (float)-1, Time.deltaTime * (float)10);
							Vector3 localPosition5 = this.Doors[i].localPosition;
							float num7 = localPosition5.x = x5;
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
							float y2 = this.Rotation * (float)-1 + (float)180;
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
		if (this.Facing == "South")
		{
			if (this.RelativeCharacter.position.z < this.transform.position.z)
			{
				this.North = true;
			}
		}
		else if (this.Facing == "East")
		{
			if (this.RelativeCharacter.position.x > this.transform.position.x)
			{
				this.North = true;
			}
		}
		else if (this.Facing == "West" && this.RelativeCharacter.position.x < this.transform.position.x)
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

	public virtual void Main()
	{
	}
}
