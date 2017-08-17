using System;
using UnityEngine;

[Serializable]
public class Club
{
	[SerializeField]
	private ClubType type;

	public Club(ClubType type)
	{
		this.type = type;
	}

	public ClubType Type
	{
		get
		{
			return this.type;
		}
		set
		{
			this.type = value;
		}
	}
}
