using System;
using UnityEngine;

[Serializable]
public class CreepyArmScript : MonoBehaviour
{
	public virtual void Update()
	{
		float y = this.transform.position.y + Time.deltaTime * 0.1f;
		Vector3 position = this.transform.position;
		float num = position.y = y;
		Vector3 vector = this.transform.position = position;
	}

	public virtual void Main()
	{
	}
}
