using System;
using UnityEngine;

[Serializable]
public class SM_destroyThisTimed : MonoBehaviour
{
	public float destroyTime;

	public SM_destroyThisTimed()
	{
		this.destroyTime = (float)5;
	}

	public virtual void Start()
	{
		UnityEngine.Object.Destroy(this.gameObject, this.destroyTime);
	}

	public virtual void Update()
	{
	}

	public virtual void Main()
	{
	}
}
