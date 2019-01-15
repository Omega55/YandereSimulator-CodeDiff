using System;
using UnityEngine;

public class AudioListenerScript : MonoBehaviour
{
	public Transform Target;

	public Camera mainCamera;

	private void Start()
	{
		this.mainCamera = Camera.main;
	}

	private void Update()
	{
		base.transform.position = this.Target.position;
		base.transform.eulerAngles = this.mainCamera.transform.eulerAngles;
	}
}
