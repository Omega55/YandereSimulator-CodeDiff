using System;
using UnityEngine;

[Serializable]
public class ShadowScript : MonoBehaviour
{
	public Transform Hips;

	public virtual void Update()
	{
		float x = this.Hips.position.x;
		Vector3 position = this.transform.position;
		float num = position.x = x;
		Vector3 vector = this.transform.position = position;
		float z = this.Hips.position.z;
		Vector3 position2 = this.transform.position;
		float num2 = position2.z = z;
		Vector3 vector2 = this.transform.position = position2;
	}

	public virtual void Main()
	{
	}
}
