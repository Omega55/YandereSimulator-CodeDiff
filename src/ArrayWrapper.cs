using System;
using System.Collections;
using UnityEngine;

public class ArrayWrapper<T> : IEnumerable
{
	[SerializeField]
	private T[] elements;

	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	public ArrayWrapper(T[] elements)
	{
		this.elements = elements;
	}

	public T this[int i]
	{
		get
		{
			return this.elements[i];
		}
		set
		{
			this.elements[i] = value;
		}
	}

	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	public T[] Get()
	{
		return this.elements;
	}

	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}
}
