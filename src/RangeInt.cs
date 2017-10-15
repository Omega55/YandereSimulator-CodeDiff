using System;
using UnityEngine;

[Serializable]
public class RangeInt
{
	[SerializeField]
	private int value;

	[SerializeField]
	private int min;

	[SerializeField]
	private int max;

	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	public int Value
	{
		get
		{
			return this.value;
		}
		set
		{
			this.value = value;
		}
	}

	public int Min
	{
		get
		{
			return this.min;
		}
	}

	public int Max
	{
		get
		{
			return this.max;
		}
	}

	public int Next
	{
		get
		{
			return (this.value != this.max) ? (this.value + 1) : this.min;
		}
	}

	public int Previous
	{
		get
		{
			return (this.value != this.min) ? (this.value - 1) : this.max;
		}
	}
}
