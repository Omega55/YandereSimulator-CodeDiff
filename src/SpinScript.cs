using System;
using UnityEngine;

[Serializable]
public class SpinScript : MonoBehaviour
{
	public float X;

	public float Y;

	public float Z;

	private float RotationX;

	private float RotationY;

	private float RotationZ;

	public virtual void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		float rotationX = this.RotationX;
		Vector3 localEulerAngles = this.transform.localEulerAngles;
		float num = localEulerAngles.x = rotationX;
		Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
		float rotationY = this.RotationY;
		Vector3 localEulerAngles2 = this.transform.localEulerAngles;
		float num2 = localEulerAngles2.y = rotationY;
		Vector3 vector2 = this.transform.localEulerAngles = localEulerAngles2;
		float rotationZ = this.RotationZ;
		Vector3 localEulerAngles3 = this.transform.localEulerAngles;
		float num3 = localEulerAngles3.z = rotationZ;
		Vector3 vector3 = this.transform.localEulerAngles = localEulerAngles3;
	}

	public virtual void Main()
	{
	}
}
