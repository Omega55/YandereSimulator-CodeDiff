using System;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
	public float X;

	public float Y;

	public float Z;

	private float RotationX;

	private float RotationY;

	private float RotationZ;

	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}
}
