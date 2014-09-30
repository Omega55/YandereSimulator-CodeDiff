using System;
using UnityEngine;

[Serializable]
public class SM_randomScale : MonoBehaviour
{
	public float minScale;

	public float maxScale;

	public SM_randomScale()
	{
		this.minScale = (float)1;
		this.maxScale = (float)2;
	}

	public virtual void Start()
	{
		float num = UnityEngine.Random.Range(this.minScale, this.maxScale);
		this.transform.localScale = new Vector3(num, num, num);
	}

	public virtual void Update()
	{
	}

	public virtual void Main()
	{
	}
}
