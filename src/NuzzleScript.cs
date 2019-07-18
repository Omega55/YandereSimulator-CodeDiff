using System;
using UnityEngine;

public class NuzzleScript : MonoBehaviour
{
	public Vector3 OriginalRotation;

	public float Rotate;

	public float Limit;

	public float Speed;

	private bool Down;

	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	private void Update()
	{
		if (!this.Down)
		{
			this.Rotate += Time.deltaTime * this.Speed;
			if (this.Rotate > this.Limit)
			{
				this.Down = true;
			}
		}
		else
		{
			this.Rotate -= Time.deltaTime * this.Speed;
			if (this.Rotate < -1f * this.Limit)
			{
				this.Down = false;
			}
		}
		base.transform.localEulerAngles = this.OriginalRotation + new Vector3(this.Rotate, 0f, 0f);
	}
}
