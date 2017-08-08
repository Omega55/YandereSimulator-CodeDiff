using System;
using System.Collections.Generic;
using UnityEngine;

public class SerializableDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver
{
	[SerializeField]
	private List<K> keys;

	[SerializeField]
	private List<V> values;

	public SerializableDictionary()
	{
		this.keys = new List<K>();
		this.values = new List<V>();
	}

	public void OnBeforeSerialize()
	{
		this.keys.Clear();
		this.values.Clear();
		foreach (KeyValuePair<K, V> keyValuePair in this)
		{
			this.keys.Add(keyValuePair.Key);
			this.values.Add(keyValuePair.Value);
		}
	}

	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.keys.Count; i++)
		{
			base.Add(this.keys[i], this.values[i]);
		}
	}
}
