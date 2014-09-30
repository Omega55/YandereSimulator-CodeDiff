using System;
using UnityEngine;

[Serializable]
public class SM_rotateThis : MonoBehaviour
{
	public float rotationSpeedX;

	public float rotationSpeedY;

	public float rotationSpeedZ;

	private Vector3 rotationVector;

	public SM_rotateThis()
	{
		this.rotationSpeedX = (float)90;
		this.rotationVector = new Vector3(this.rotationSpeedX, this.rotationSpeedY, this.rotationSpeedZ);
	}

	public virtual void Update()
	{
		this.transform.Rotate(new Vector3(this.rotationSpeedX, this.rotationSpeedY, this.rotationSpeedZ) * Time.deltaTime);
	}

	public virtual void Main()
	{
	}
}
