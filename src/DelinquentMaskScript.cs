using System;
using UnityEngine;

public class DelinquentMaskScript : MonoBehaviour
{
	public MeshFilter MyRenderer;

	public Mesh[] Meshes;

	public int ID;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			this.ID++;
			if (this.ID > 4)
			{
				this.ID = 0;
			}
			this.MyRenderer.mesh = this.Meshes[this.ID];
		}
	}
}
