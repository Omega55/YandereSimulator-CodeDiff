using System;
using UnityEngine;

[Serializable]
public class RivalData
{
	[SerializeField]
	private int week;

	public RivalData(int week)
	{
		this.week = week;
	}

	public int Week
	{
		get
		{
			return this.week;
		}
	}
}
