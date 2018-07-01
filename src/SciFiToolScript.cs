using System;
using UnityEngine;

public class SciFiToolScript : MonoBehaviour
{
	public StudentScript Student;

	public ParticleSystem Sparks;

	public Transform Target;

	public Transform Tip;

	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
		}
		else
		{
			this.Sparks.Stop();
		}
	}
}
