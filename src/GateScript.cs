using System;
using UnityEngine;

public class GateScript : MonoBehaviour
{
	public Collider EmergencyDoor;

	public ClockScript Clock;

	public Collider GateCollider;

	public Transform RightGate;

	public Transform LeftGate;

	public bool UpdateGates;

	public bool Closed;

	private void Update()
	{
		if (this.Clock.PresentTime / 60f > 8.5f && this.Clock.PresentTime / 60f < 15.5f)
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
			this.RightGate.localPosition = new Vector3(Mathf.Lerp(this.RightGate.localPosition.x, 7f, Time.deltaTime), this.RightGate.localPosition.y, this.RightGate.localPosition.z);
			this.LeftGate.localPosition = new Vector3(Mathf.Lerp(this.LeftGate.localPosition.x, -7f, Time.deltaTime), this.LeftGate.localPosition.y, this.LeftGate.localPosition.z);
		}
		else
		{
			this.RightGate.localPosition = new Vector3(Mathf.Lerp(this.RightGate.localPosition.x, 2.325f, Time.deltaTime), this.RightGate.localPosition.y, this.RightGate.localPosition.z);
			this.LeftGate.localPosition = new Vector3(Mathf.Lerp(this.LeftGate.localPosition.x, -2.325f, Time.deltaTime), this.LeftGate.localPosition.y, this.LeftGate.localPosition.z);
		}
	}
}
