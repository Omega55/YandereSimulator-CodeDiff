using System;
using UnityEngine;

[Serializable]
public class WitnessMemory
{
	[SerializeField]
	private float[] memories;

	[SerializeField]
	private float memorySpan;

	private const float LongMemorySpan = 28800f;

	private const float MediumMemorySpan = 7200f;

	private const float ShortMemorySpan = 1800f;

	private const float VeryShortMemorySpan = 120f;

	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}
}
