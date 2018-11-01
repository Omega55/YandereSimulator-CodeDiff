using System;
using UnityEngine;

public class CameraDistanceDisableScript : MonoBehaviour
{
	public Transform RenderTarget;

	public Transform Yandere;

	public Camera MyCamera;

	private void Update()
	{
		if (Vector3.Distance(this.Yandere.position, this.RenderTarget.position) > 15f)
		{
			this.MyCamera.enabled = false;
		}
		else
		{
			this.MyCamera.enabled = true;
		}
	}
}
