using System;
using UnityEngine;

public class ChangeTextureScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public Texture[] Textures;

	public int ID = 1;

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			if (this.ID == this.Textures.Length)
			{
				this.ID = 1;
			}
			this.MyRenderer.material.mainTexture = this.Textures[this.ID];
		}
	}
}
