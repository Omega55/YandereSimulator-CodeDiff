using System;
using UnityEngine;

[Serializable]
public class Stance
{
	[SerializeField]
	private StanceType current;

	[SerializeField]
	private StanceType previous;

	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	public StanceType Current
	{
		get
		{
			return this.current;
		}
		set
		{
			this.previous = this.current;
			this.current = value;
		}
	}

	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}
}
