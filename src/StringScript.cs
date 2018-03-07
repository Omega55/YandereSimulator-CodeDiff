using System;
using UnityEngine;

public class StringScript : MonoBehaviour
{
	public Transform Origin;

	public Transform Target;

	public Transform String;

	public int ArrayID;

	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}
}
