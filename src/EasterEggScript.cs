using System;
using UnityEngine;

[Serializable]
public class EasterEggScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Texture DarkSeifuku;

	public virtual void OnTriggerEnter()
	{
		this.Yandere.MyRenderer.materials[0].mainTexture = this.DarkSeifuku;
		this.Yandere.Outline.h.ReinitMaterials();
	}

	public virtual void Main()
	{
	}
}
