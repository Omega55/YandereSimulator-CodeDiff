using System;
using UnityEngine;

[Serializable]
public class DrillScript : MonoBehaviour
{
	public virtual void LateUpdate()
	{
		this.transform.Rotate(Vector3.up * Time.deltaTime * (float)3600);
	}

	public virtual void Main()
	{
	}
}
