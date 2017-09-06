using System;
using System.Collections.Generic;
using UnityEngine;

public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver
{
	[SerializeField]
	private List<T> elements;

	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}
}
