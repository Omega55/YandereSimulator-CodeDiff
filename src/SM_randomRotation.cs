using System;
using UnityEngine;

[Serializable]
public class SM_randomRotation : MonoBehaviour
{
	public float rotationMaxX;

	public float rotationMaxY;

	public float rotationMaxZ;

	public SM_randomRotation()
	{
		this.rotationMaxY = (float)360;
	}

	public virtual void Start()
	{
		float xAngle = UnityEngine.Random.Range(-this.rotationMaxX, this.rotationMaxX);
		float yAngle = UnityEngine.Random.Range(-this.rotationMaxY, this.rotationMaxY);
		float zAngle = UnityEngine.Random.Range(-this.rotationMaxZ, this.rotationMaxZ);
		this.transform.Rotate(xAngle, yAngle, zAngle);
	}

	public virtual void Main()
	{
	}
}
