using System;
using UnityEngine;

public class GrandfatherScript : MonoBehaviour
{
	public ClockScript Clock;

	public Transform MinuteHand;

	public Transform HourHand;

	public Transform Pendulum;

	public float Rotation;

	public float Force;

	public float Speed;

	public bool Flip;

	private void Update()
	{
		if (!this.Flip)
		{
			if ((double)this.Force < 0.1)
			{
				this.Force += Time.deltaTime * 0.1f * this.Speed;
			}
		}
		else if ((double)this.Force > -0.1)
		{
			this.Force -= Time.deltaTime * 0.1f * this.Speed;
		}
		this.Rotation += this.Force;
		if (this.Rotation > 1f)
		{
			this.Flip = true;
		}
		else if (this.Rotation < -1f)
		{
			this.Flip = false;
		}
		if (this.Rotation > 5f)
		{
			this.Rotation = 5f;
		}
		else if (this.Rotation < -5f)
		{
			this.Rotation = -5f;
		}
		this.Pendulum.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
		this.MinuteHand.localEulerAngles = new Vector3(this.MinuteHand.localEulerAngles.x, this.MinuteHand.localEulerAngles.y, this.Clock.Minute * 6f);
		this.HourHand.localEulerAngles = new Vector3(this.HourHand.localEulerAngles.x, this.HourHand.localEulerAngles.y, this.Clock.Hour * 30f);
	}
}
