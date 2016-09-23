using System;
using UnityEngine;

[Serializable]
public class GhostScript : MonoBehaviour
{
	public Transform SmartphoneCamera;

	public Transform Neck;

	public Transform GhostEyeLocation;

	public Transform GhostEye;

	public int Frame;

	public virtual void Update()
	{
		if (Time.timeScale > (float)0)
		{
			if (this.Frame > 0)
			{
				((Animation)this.GetComponent(typeof(Animation))).enabled = false;
				this.active = false;
				this.Frame = 0;
			}
			this.Frame++;
		}
	}

	public virtual void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	public virtual void Main()
	{
	}
}
