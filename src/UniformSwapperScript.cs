using System;
using UnityEngine;

public class UniformSwapperScript : MonoBehaviour
{
	public Texture[] UniformTextures;

	public Mesh[] UniformMeshes;

	public Texture FaceTexture;

	public SkinnedMeshRenderer MyRenderer;

	public int UniformID;

	public int FaceID;

	public int SkinID;

	public Transform LookTarget;

	public Transform Head;

	private void Start()
	{
		int @int = PlayerPrefs.GetInt("MaleUniform");
		this.MyRenderer.sharedMesh = this.UniformMeshes[@int];
		Texture mainTexture = this.UniformTextures[@int];
		if (@int == 1)
		{
			this.SkinID = 0;
			this.UniformID = 1;
			this.FaceID = 2;
		}
		else if (@int == 2)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (@int == 3)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (@int == 4)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (@int == 5)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (@int == 6)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[this.SkinID].mainTexture = mainTexture;
		this.MyRenderer.materials[this.UniformID].mainTexture = mainTexture;
	}

	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}
}
