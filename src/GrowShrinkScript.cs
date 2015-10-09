using System;
using UnityEngine;

[Serializable]
public class GrowShrinkScript : MonoBehaviour
{
	public float FallSpeed;

	public float Threshold;

	public float Slowdown;

	public float Strength;

	public float Target;

	public float Scale;

	public float Speed;

	public float Timer;

	public bool Shrink;

	public GrowShrinkScript()
	{
		this.Threshold = 1f;
		this.Slowdown = 0.75f;
		this.Strength = 1f;
		this.Target = 1f;
		this.Speed = 5f;
	}

	public virtual void Start()
	{
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		this.Scale += Time.deltaTime * this.Strength * this.Speed;
		if (!this.Shrink)
		{
			this.Strength += Time.deltaTime * this.Speed;
			if (this.Strength > this.Threshold)
			{
				this.Strength = this.Threshold;
			}
			if (this.Scale > this.Target)
			{
				this.Threshold *= this.Slowdown;
				this.Shrink = true;
			}
		}
		else
		{
			this.Strength -= Time.deltaTime * this.Speed;
			if (this.Strength < this.Threshold * (float)-1)
			{
				this.Strength = this.Threshold * (float)-1;
			}
			if (this.Scale < this.Target)
			{
				this.Threshold *= this.Slowdown;
				this.Shrink = false;
			}
		}
		if (this.Timer > 3.33333f)
		{
			this.FallSpeed += Time.deltaTime * (float)10;
			float y = this.transform.localPosition.y - this.FallSpeed * this.FallSpeed;
			Vector3 localPosition = this.transform.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.transform.localPosition = localPosition;
		}
		this.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
	}

	public virtual void Main()
	{
	}
}
