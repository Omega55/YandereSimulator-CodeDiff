using System;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
	public Transform SmartphoneCamera;

	public Transform Neck;

	public Transform GhostEyeLocation;

	public Transform GhostEye;

	public int Frame;

	public bool Move;

	private void Update()
	{
		if (Time.timeScale > 0f)
		{
			if (this.Frame > 0)
			{
				base.GetComponent<Animation>().enabled = false;
				base.gameObject.SetActive(false);
				this.Frame = 0;
			}
			this.Frame++;
		}
	}

	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}
}
