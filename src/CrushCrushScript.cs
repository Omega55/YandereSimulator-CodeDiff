using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class CrushCrushScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public Mesh[] Meshes;

	public int ID;

	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			if (this.ID == Extensions.get_length(this.Meshes))
			{
				this.ID = 1;
			}
			RuntimeServices.SetProperty(this.MyRenderer, "sharedMesh", this.Meshes[this.ID]);
		}
	}

	public virtual void Main()
	{
	}
}
