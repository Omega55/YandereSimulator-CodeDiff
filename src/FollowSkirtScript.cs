using System;
using UnityEngine;

public class FollowSkirtScript : MonoBehaviour
{
	public Transform[] TargetSkirtFront;

	public Transform[] TargetSkirtBack;

	public Transform[] TargetSkirtRight;

	public Transform[] TargetSkirtLeft;

	public Transform[] SkirtFront;

	public Transform[] SkirtBack;

	public Transform[] SkirtRight;

	public Transform[] SkirtLeft;

	public Transform TargetSkirtHips;

	public Transform SkirtHips;

	private void LateUpdate()
	{
		this.SkirtHips.position = this.TargetSkirtHips.position;
		for (int i = 0; i < 3; i++)
		{
			this.SkirtFront[i].position = this.TargetSkirtFront[i].position;
			this.SkirtFront[i].rotation = this.TargetSkirtFront[i].rotation;
			this.SkirtBack[i].position = this.TargetSkirtBack[i].position;
			this.SkirtBack[i].rotation = this.TargetSkirtBack[i].rotation;
			this.SkirtRight[i].position = this.TargetSkirtRight[i].position;
			this.SkirtRight[i].rotation = this.TargetSkirtRight[i].rotation;
			this.SkirtLeft[i].position = this.TargetSkirtLeft[i].position;
			this.SkirtLeft[i].rotation = this.TargetSkirtLeft[i].rotation;
		}
	}
}
