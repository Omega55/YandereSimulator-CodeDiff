using System;
using UnityEngine;

[Serializable]
public class Timer
{
	[SerializeField]
	private float currentSeconds;

	[SerializeField]
	private float targetSeconds;

	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}
}
