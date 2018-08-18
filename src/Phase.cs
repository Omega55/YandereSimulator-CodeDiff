using System;
using UnityEngine;

[Serializable]
public class Phase
{
	[SerializeField]
	private PhaseOfDay type;

	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}
}
