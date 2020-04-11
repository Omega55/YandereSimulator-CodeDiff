using System;
using UnityEngine;

public class SciFiTabletScript : MonoBehaviour
{
	public StudentScript Student;

	public HologramScript Holograms;

	public Transform Finger;

	public bool Updated;

	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	private void Update()
	{
		if ((double)Vector3.Distance(this.Finger.position, base.transform.position) < 0.1)
		{
			if (!this.Updated)
			{
				this.Holograms.UpdateHolograms();
				this.Updated = true;
				return;
			}
		}
		else
		{
			this.Updated = false;
		}
	}
}
