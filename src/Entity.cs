using System;
using UnityEngine;

[Serializable]
public abstract class Entity
{
	[SerializeField]
	private GenderType gender;

	[SerializeField]
	private DeathType deathType;

	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	public DeathType DeathType
	{
		get
		{
			return this.deathType;
		}
		set
		{
			this.deathType = value;
		}
	}

	public abstract EntityType EntityType { get; }
}
