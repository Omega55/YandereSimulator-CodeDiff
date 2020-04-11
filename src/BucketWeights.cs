using System;
using UnityEngine;

[Serializable]
public class BucketWeights : BucketContents
{
	[SerializeField]
	private int count;

	public int Count
	{
		get
		{
			return this.count;
		}
		set
		{
			this.count = ((value < 0) ? 0 : value);
		}
	}

	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Weights;
		}
	}

	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	public override bool CanBeLifted(int strength)
	{
		return strength > 0;
	}
}
