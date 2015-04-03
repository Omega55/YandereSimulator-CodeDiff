using System;
using UnityEngine;

[Serializable]
public class TranqCaseScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public DoorScript Door;

	public Transform Hinge;

	public bool Occupied;

	public bool Open;

	public virtual void Start()
	{
		this.Prompt.enabled = false;
	}

	public virtual void Update()
	{
		if (Vector3.Distance(this.transform.position, this.Yandere.transform.position) < (float)1)
		{
			if (this.Yandere.Dragging)
			{
				if (((RagdollScript)this.Yandere.Ragdoll.GetComponent(typeof(RagdollScript))).Tranquil)
				{
					if (!this.Prompt.enabled)
					{
						this.Prompt.enabled = true;
					}
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			this.Yandere.Ragdoll.transform.parent = this.transform;
			this.Yandere.Ragdoll.transform.localPosition = new Vector3(0.224f, 1.36f, (float)0);
			this.Yandere.Ragdoll.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)90);
			((RagdollScript)this.Yandere.Ragdoll.GetComponent(typeof(RagdollScript))).TranqCase = this;
			((RagdollScript)this.Yandere.Ragdoll.GetComponent(typeof(RagdollScript))).Dump(2);
			this.Yandere.EmptyHands();
			this.Door.Prompt.enabled = true;
			this.Occupied = true;
			this.Open = true;
		}
		if (this.Open)
		{
			float z = Mathf.Lerp(this.Hinge.localEulerAngles.z, (float)135, Time.deltaTime * (float)10);
			Vector3 localEulerAngles = this.Hinge.localEulerAngles;
			float num = localEulerAngles.z = z;
			Vector3 vector = this.Hinge.localEulerAngles = localEulerAngles;
		}
		else
		{
			float z2 = Mathf.Lerp(this.Hinge.localEulerAngles.z, (float)0, Time.deltaTime * (float)10);
			Vector3 localEulerAngles2 = this.Hinge.localEulerAngles;
			float num2 = localEulerAngles2.z = z2;
			Vector3 vector2 = this.Hinge.localEulerAngles = localEulerAngles2;
		}
	}

	public virtual void Main()
	{
	}
}
