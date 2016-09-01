using System;
using UnityEngine;

[Serializable]
public class LookAtCamera : MonoBehaviour
{
	public Camera cameraToLookAt;

	public virtual void Update()
	{
		Vector3 b = this.cameraToLookAt.transform.position - this.transform.position;
		b.x = (b.z = (float)0);
		this.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	public virtual void Main()
	{
	}
}
