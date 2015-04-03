using System;
using UnityEngine;

[Serializable]
public class TestScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyRenderer;

	public Texture BlueShirt;

	public Texture RedShirt;

	public virtual void Update()
	{
		if (Input.GetKeyDown("1"))
		{
			this.MyRenderer.material.mainTexture = this.BlueShirt;
		}
		if (Input.GetKeyDown("2"))
		{
			this.MyRenderer.material.mainTexture = this.RedShirt;
		}
	}

	public virtual void Main()
	{
	}
}
