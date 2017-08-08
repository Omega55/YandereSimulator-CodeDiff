using System;
using UnityEngine;

[Serializable]
public class Persona
{
	[SerializeField]
	private PersonaType type;

	public Persona(PersonaType type)
	{
		this.type = type;
	}

	public PersonaType Type
	{
		get
		{
			return this.type;
		}
	}
}
