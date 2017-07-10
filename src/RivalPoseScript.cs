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
		int @int = PlayerPrefs.GetInt("FemaleUniform");
		this.MyRenderer.sharedMesh = this.FemaleUniforms[@int];
		if (@int == 1)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[@int];
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[@int];
		}
		else if (@int == 2)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[@int];
			this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[@int];
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.HairTexture;
		}
		else if (@int == 3)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[@int];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[@int];
		}
		else if (@int == 4)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[@int];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[@int];
		}
		else if (@int == 5)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[@int];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[@int];
		}
		else if (@int == 6)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[@int];
			this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[@int];
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.HairTexture;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			if (this.ID > this.AnimNames.Length - 1)
			{
				this.ID = 0;
			}
			this.Character.GetComponent<Animation>().Play(this.AnimNames[this.ID]);
		}
	}
}
