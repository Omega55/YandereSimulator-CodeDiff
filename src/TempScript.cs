using System;
using UnityEngine;

[Serializable]
public class TempScript : MonoBehaviour
{
	public int ID;

	public virtual void Start()
	{
		if (this.ID == 1)
		{
			this.animation["f02_delinquentStance_00"].speed = 0.5f;
		}
	}

	public virtual void Update()
	{
		if (this.ID == 2)
		{
			float z = this.transform.position.z - Time.deltaTime * 0.1f;
			Vector3 position = this.transform.position;
			float num = position.z = z;
			Vector3 vector = this.transform.position = position;
		}
	}

	public virtual void Main()
	{
	}
}
