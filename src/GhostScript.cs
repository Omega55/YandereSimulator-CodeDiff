using System;
using UnityEngine;

[Serializable]
public class GhostScript : MonoBehaviour
{
	public Transform SmartphoneCamera;

	public Transform Neck;

	public virtual void Start()
	{
		this.active = false;
	}

	public virtual void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	public virtual void Main()
	{
	}
}
