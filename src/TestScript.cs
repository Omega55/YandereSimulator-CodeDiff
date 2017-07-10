using System;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	public float Speed;

	public bool Go;

	private void Update()
	{
		if (Input.GetKeyDown("e"))
		{
			this.Go = true;
		}
		if (this.Go)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime * this.Speed, base.transform.position.z - Time.deltaTime * this.Speed);
		}
	}
}
