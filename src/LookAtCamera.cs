using System;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
	public Camera cameraToLookAt;

	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}
}
