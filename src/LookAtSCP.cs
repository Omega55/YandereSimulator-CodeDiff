using System;
using UnityEngine;

public class LookAtSCP : MonoBehaviour
{
	public Transform SCP;

	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}
}
