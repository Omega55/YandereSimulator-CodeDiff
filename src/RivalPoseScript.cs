using System;
using UnityEngine;

public class RivalPoseScript : MonoBehaviour
{
	public GameObject Character;

	public SkinnedMeshRenderer MyRenderer;

	public Texture[] FemaleUniformTextures;

	public Mesh[] FemaleUniforms;

	public Texture[] TestTextures;

	public Texture HairTexture;

	public string[] AnimNames;

	public int ID = -1;

	private void Start()
	{
		int femaleUniform = StudentGlobals.FemaleUniform;
		this.MyRenderer.sharedMesh = this.FemaleUniforms[femaleUniform];
		if (femaleUniform == 1)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
			return;
		}
		if (femaleUniform == 2)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.HairTexture;
			return;
		}
		if (femaleUniform == 3)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
			return;
		}
		if (femaleUniform == 4)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
			return;
		}
		if (femaleUniform == 5)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
			return;
		}
		if (femaleUniform == 6)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.HairTexture;
		}
	}
}
