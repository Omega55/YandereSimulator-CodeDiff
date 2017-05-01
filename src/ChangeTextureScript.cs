using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ChangeTextureScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public Texture[] Textures;

	public int ID;

	public ChangeTextureScript()
	{
		this.ID = 1;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			if (this.ID == Extensions.get_length(this.Textures))
			{
				this.ID = 1;
			}
			this.MyRenderer.material.mainTexture = this.Textures[this.ID];
		}
	}

	public virtual void Main()
	{
	}
}
