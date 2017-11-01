﻿using System;
using UnityEngine;

[Serializable]
public class Persona
{
	[SerializeField]
	private PersonaType type;

	public static readonly PersonaTypeAndStringDictionary PersonaNames = new PersonaTypeAndStringDictionary
	{
		{
			PersonaType.None,
			"None"
		},
		{
			PersonaType.Loner,
			"Loner"
		},
		{
			PersonaType.TeachersPet,
			"Teacher's Pet"
		},
		{
			PersonaType.Heroic,
			"Heroic"
		},
		{
			PersonaType.Coward,
			"Coward"
		},
		{
			PersonaType.Evil,
			"Evil"
		},
		{
			PersonaType.SocialButterfly,
			"Social Butterfly"
		},
		{
			PersonaType.Lovestruck,
			"Lovestruck"
		},
		{
			PersonaType.Strict,
			"Strict"
		},
		{
			PersonaType.Nemesis,
			"?????"
		}
	};

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
