using System;
using UnityEngine;

public class CrushCrushScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyRenderer;

	public Mesh[] Meshes;

	public int ID;

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			if (this.ID == this.Meshes.Length)
			{
				this.ID = 1;
			}
			this.MyRenderer.sharedMesh = this.Meshes[this.ID];
		}
	}
}
