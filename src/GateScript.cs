using System;
using UnityEngine;

[Serializable]
public class GateScript : MonoBehaviour
{
	public Collider EmergencyDoor;

	public ClockScript Clock;

	public Transform GateCollider;

	public Transform RightGate;

	public Transform LeftGate;

	public bool UpdateGates;

	public bool Closed;

	public virtual void Update()
	{
		if (this.Clock.PresentTime / (float)60 > 8.5f && this.Clock.PresentTime / (float)60 < 15.5f)
		{
			this.Closed = true;
			if (this.EmergencyDoor.enabled)
			{
				this.EmergencyDoor.enabled = false;
			}
		}
		else
		{
			this.Closed = false;
			if (!this.EmergencyDoor.enabled)
			{
				this.EmergencyDoor.enabled = true;
			}
		}
		if (!this.Closed)
		{
			this.GateCollider.localScale = Vector3.Lerp(this.GateCollider.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime);
			float x = Mathf.Lerp(this.RightGate.localPosition.x, (float)7, Time.deltaTime);
			Vector3 localPosition = this.RightGate.localPosition;
			float num = localPosition.x = x;
			Vector3 vector = this.RightGate.localPosition = localPosition;
			float x2 = Mathf.Lerp(this.LeftGate.localPosition.x, (float)-7, Time.deltaTime);
			Vector3 localPosition2 = this.LeftGate.localPosition;
			float num2 = localPosition2.x = x2;
			Vector3 vector2 = this.LeftGate.localPosition = localPosition2;
		}
		else
		{
			this.GateCollider.localScale = Vector3.Lerp(this.GateCollider.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime);
			float x3 = Mathf.Lerp(this.RightGate.localPosition.x, 2.325f, Time.deltaTime);
			Vector3 localPosition3 = this.RightGate.localPosition;
			float num3 = localPosition3.x = x3;
			Vector3 vector3 = this.RightGate.localPosition = localPosition3;
			float x4 = Mathf.Lerp(this.LeftGate.localPosition.x, -2.325f, Time.deltaTime);
			Vector3 localPosition4 = this.LeftGate.localPosition;
			float num4 = localPosition4.x = x4;
			Vector3 vector4 = this.LeftGate.localPosition = localPosition4;
		}
	}

	public virtual void Main()
	{
	}
}
