﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class YanSaveIdentifier : MonoBehaviour
{
	public string ObjectID;

	[HideInInspector]
	public bool AutoGenerated;

	[HideInInspector]
	public List<Component> DisabledComponents = new List<Component>();

	[HideInInspector]
	public List<DisabledYanSaveMember> DisabledProperties = new List<DisabledYanSaveMember>();

	[HideInInspector]
	public List<DisabledYanSaveMember> DisabledFields = new List<DisabledYanSaveMember>();

	public static GameObject GetObject(string id)
	{
		foreach (YanSaveIdentifier yanSaveIdentifier in UnityEngine.Object.FindObjectsOfType<YanSaveIdentifier>())
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
		foreach (YanSaveIdentifier yanSaveIdentifier in UnityEngine.Object.FindObjectsOfType<YanSaveIdentifier>())
		{
			if (yanSaveIdentifier.ObjectID == serializedGameObject.ObjectID)
			{
				return yanSaveIdentifier.gameObject;
			}
		}
		return null;
	}
}
