using System;
using UnityEngine;

[Serializable]
public class IncineratorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform RightDoor;

	public Transform LeftDoor;

	public GameObject Smoke;

	public bool Occupied;

	public bool Open;

	public virtual void Update()
	{
		if (!this.Open)
		{
			float y = Mathf.Lerp(this.RightDoor.transform.localEulerAngles.y, (float)0, Time.deltaTime * (float)10);
			Vector3 localEulerAngles = this.RightDoor.transform.localEulerAngles;
			float num = localEulerAngles.y = y;
			Vector3 vector = this.RightDoor.transform.localEulerAngles = localEulerAngles;
			float y2 = Mathf.Lerp(this.LeftDoor.transform.localEulerAngles.y, (float)0, Time.deltaTime * (float)10);
			Vector3 localEulerAngles2 = this.LeftDoor.transform.localEulerAngles;
			float num2 = localEulerAngles2.y = y2;
			Vector3 vector2 = this.LeftDoor.transform.localEulerAngles = localEulerAngles2;
		}
		else
		{
			float y3 = Mathf.Lerp(this.RightDoor.transform.localEulerAngles.y, (float)135, Time.deltaTime * (float)10);
			Vector3 localEulerAngles3 = this.RightDoor.transform.localEulerAngles;
			float num3 = localEulerAngles3.y = y3;
			Vector3 vector3 = this.RightDoor.transform.localEulerAngles = localEulerAngles3;
			float y4 = Mathf.Lerp(this.LeftDoor.transform.localEulerAngles.y, (float)135, Time.deltaTime * (float)10);
			Vector3 localEulerAngles4 = this.LeftDoor.transform.localEulerAngles;
			float num4 = localEulerAngles4.y = y4;
			Vector3 vector4 = this.LeftDoor.transform.localEulerAngles = localEulerAngles4;
		}
		if (this.Yandere.Ragdoll == null)
		{
			if (!this.Occupied)
			{
				if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else
			{
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[3].fillAmount <= (float)0)
				{
					this.Prompt.Label[3].text = "     " + "Dump";
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Smoke.active = true;
					this.Occupied = false;
				}
			}
		}
		else if (!this.Occupied)
		{
			this.Prompt.enabled = true;
			if (this.Prompt.Circle[3].fillAmount <= (float)0)
			{
				if (!this.Occupied)
				{
					this.Yandere.CanMove = false;
					this.Yandere.Dumping = true;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Open = true;
				}
			}
			else
			{
				this.Prompt.enabled = true;
			}
		}
		else
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
