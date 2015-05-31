using System;
using UnityEngine;

[Serializable]
public class PoliceWalk : MonoBehaviour
{
	public virtual void Update()
	{
		float z = this.transform.position.z + Time.deltaTime;
		Vector3 position = this.transform.position;
		float num = position.z = z;
		Vector3 vector = this.transform.position = position;
	}

	public virtual void Main()
	{
	}
}
