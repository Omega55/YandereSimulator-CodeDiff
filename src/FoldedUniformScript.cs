using System;
using UnityEngine;

[Serializable]
public class FoldedUniformScript : MonoBehaviour
{
	public YandereScript Yandere;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Main()
	{
	}
}
