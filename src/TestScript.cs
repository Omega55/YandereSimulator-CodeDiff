using System;
using UnityEngine;

[Serializable]
public class TestScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyMesh;

	public Mesh Mesh1;

	public Mesh Mesh2;

	public Texture[] Mesh1Textures;

	public Texture[] Mesh2Textures;

	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			if (this.MyMesh.sharedMesh == this.Mesh1)
			{
				this.MyMesh.sharedMesh = this.Mesh2;
				this.MyMesh.materials[0].mainTexture = this.Mesh2Textures[0];
				this.MyMesh.materials[1].mainTexture = this.Mesh2Textures[1];
				this.MyMesh.materials[2].mainTexture = this.Mesh2Textures[2];
				this.MyMesh.materials[3].mainTexture = this.Mesh2Textures[3];
			}
			else
			{
				this.MyMesh.sharedMesh = this.Mesh1;
				this.MyMesh.materials[0].mainTexture = this.Mesh1Textures[0];
				this.MyMesh.materials[1].mainTexture = this.Mesh1Textures[1];
				this.MyMesh.materials[2].mainTexture = this.Mesh1Textures[2];
				this.MyMesh.materials[3].mainTexture = this.Mesh1Textures[3];
			}
		}
	}

	public virtual void Main()
	{
	}
}
