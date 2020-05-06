﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class YanSaveIdentifier : MonoBehaviour
{
	public string ObjectID;

	[HideInInspector]
	public bool AutoGenerated;

	[HideInInspector]
	public List<Component> EnabledComponents = new List<Component>();

	[HideInInspector]
	public List<DisabledYanSaveMember> DisabledProperties = new List<DisabledYanSaveMember>();

	[HideInInspector]
	public List<DisabledYanSaveMember> DisabledFields = new List<DisabledYanSaveMember>();

	private static List<YanSaveIdentifier> Identifiers = new List<YanSaveIdentifier>();

	public static GameObject GetObject(string id)
	{
		foreach (YanSaveIdentifier yanSaveIdentifier in YanSaveIdentifier.Identifiers)
		{
			if (yanSaveIdentifier.ObjectID == id)
			{
				return yanSaveIdentifier.gameObject;
			}
		}
		return null;
	}

	public static GameObject GetObject(SerializedGameObject serializedGameObject)
	{
		foreach (YanSaveIdentifier yanSaveIdentifier in YanSaveIdentifier.Identifiers)
		{
			if (yanSaveIdentifier.ObjectID == serializedGameObject.ObjectID)
			{
				return yanSaveIdentifier.gameObject;
			}
		}
		return null;
	}

	public void OnEnable()
	{
		if (!YanSaveIdentifier.Identifiers.Contains(this))
		{
			YanSaveIdentifier.Identifiers.Add(this);
		}
	}

	public void OnDestroy()
	{
		YanSaveIdentifier.Identifiers.Remove(this);
	}
}
