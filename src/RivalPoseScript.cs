using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RivalPoseScript : MonoBehaviour
{
	public GameObject Character;

	public SkinnedMeshRenderer MyRenderer;

	public Texture[] FemaleUniformTextures;

	public Mesh[] FemaleUniforms;

	public Texture[] TestTextures;

	public Texture HairTexture;

	public string[] AnimNames;

	public int ID;

	public RivalPoseScript()
	{
		this.ID = -1;
	}

	public virtual void Start()
	{
		this.MyRenderer.sharedMesh = this.FemaleUniforms[PlayerPrefs.GetInt("FemaleUniform")];
		if (PlayerPrefs.GetInt("FemaleUniform") == 1)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
		else if (PlayerPrefs.GetInt("FemaleUniform") == 2)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.HairTexture;
		}
		else if (PlayerPrefs.GetInt("FemaleUniform") == 3)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
		else if (PlayerPrefs.GetInt("FemaleUniform") == 4)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
		else if (PlayerPrefs.GetInt("FemaleUniform") == 5)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
		else if (PlayerPrefs.GetInt("FemaleUniform") == 6)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.HairTexture;
		}
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			if (this.ID > Extensions.get_length(this.AnimNames) - 1)
			{
				this.ID = 0;
			}
			this.Character.animation.Play(this.AnimNames[this.ID]);
		}
	}

	public virtual void Main()
	{
	}
}
