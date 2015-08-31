using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class FootprintScript : MonoBehaviour
{
	public Texture Footprint;

	public virtual void Start()
	{
		if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(GameObject.Find("YandereChan").GetComponent("YandereScript"), "Schoolwear"), 0))
		{
			this.renderer.material.mainTexture = this.Footprint;
		}
		UnityEngine.Object.Destroy(this);
	}

	public virtual void Main()
	{
	}
}
