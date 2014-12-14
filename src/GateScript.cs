using System;
using UnityEngine;

[Serializable]
public class GateScript : MonoBehaviour
{
	public bool UpdateGates;

	public bool Closed;

	public Transform RightGate;

	public Transform LeftGate;

	public virtual void Start()
	{
		if (!this.Closed)
		{
			int num = 7;
			Vector3 localPosition = this.RightGate.localPosition;
			float num2 = localPosition.x = (float)num;
			Vector3 vector = this.RightGate.localPosition = localPosition;
			int num3 = -7;
			Vector3 localPosition2 = this.LeftGate.localPosition;
			float num4 = localPosition2.x = (float)num3;
			Vector3 vector2 = this.LeftGate.localPosition = localPosition2;
		}
		else
		{
			float x = 2.325f;
			Vector3 localPosition3 = this.RightGate.localPosition;
			float num5 = localPosition3.x = x;
			Vector3 vector3 = this.RightGate.localPosition = localPosition3;
			float x2 = -2.325f;
			Vector3 localPosition4 = this.LeftGate.localPosition;
			float num6 = localPosition4.x = x2;
			Vector3 vector4 = this.LeftGate.localPosition = localPosition4;
		}
	}

	public virtual void Update()
	{
		if (this.UpdateGates)
		{
			this.Start();
			this.UpdateGates = false;
		}
	}

	public virtual void Main()
	{
	}
}
