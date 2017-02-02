using System;
using UnityEngine;

[Serializable]
public class TestScript : MonoBehaviour
{
	public float Speed;

	public bool Go;

	public virtual void Update()
	{
		if (Input.GetKeyDown("e"))
		{
			this.Go = true;
		}
		if (this.Go)
		{
			float z = this.transform.position.z - Time.deltaTime * this.Speed;
			Vector3 position = this.transform.position;
			float num = position.z = z;
			Vector3 vector = this.transform.position = position;
			float y = this.transform.position.y + Time.deltaTime * this.Speed;
			Vector3 position2 = this.transform.position;
			float num2 = position2.y = y;
			Vector3 vector2 = this.transform.position = position2;
		}
	}

	public virtual void Main()
	{
	}
}
