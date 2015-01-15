using System;
using UnityEngine;

[Serializable]
public class CartoonCreatures_rotateThis : MonoBehaviour
{
	public float rotationSpeedX;

	public float rotationSpeedY;

	public float rotationSpeedZ;

	public CartoonCreatures_rotateThis()
	{
		this.rotationSpeedX = (float)90;
	}

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
		this.transform.Rotate(new Vector3(this.rotationSpeedX, this.rotationSpeedY, this.rotationSpeedZ) * Time.deltaTime);
	}

	public virtual void Main()
	{
	}
}
