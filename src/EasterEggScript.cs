using System;
using UnityEngine;

[Serializable]
public class EasterEggScript : MonoBehaviour
{
	public Renderer YandereRenderer;

	public Texture DarkSeifuku;

	public virtual void OnTriggerEnter()
	{
		this.YandereRenderer.materials[0].mainTexture = this.DarkSeifuku;
	}

	public virtual void Main()
	{
	}
}
