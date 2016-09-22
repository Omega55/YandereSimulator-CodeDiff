using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class UniformSwapperScript : MonoBehaviour
{
	public Texture[] UniformTextures;

	public Mesh[] UniformMeshes;

	public Texture FaceTexture;

	public Renderer MyRenderer;

	public int UniformID;

	public int FaceID;

	public int SkinID;

	public Transform LookTarget;

	public Transform Head;

	public virtual void Start()
	{
		RuntimeServices.SetProperty(this.MyRenderer, "sharedMesh", this.UniformMeshes[PlayerPrefs.GetInt("MaleUniform")]);
		Texture mainTexture = this.UniformTextures[PlayerPrefs.GetInt("MaleUniform")];
		if (PlayerPrefs.GetInt("MaleUniform") == 1)
		{
			this.SkinID = 0;
			this.UniformID = 1;
			this.FaceID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 2)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 3)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 4)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 5)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 6)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[this.SkinID].mainTexture = mainTexture;
		this.MyRenderer.materials[this.UniformID].mainTexture = mainTexture;
	}

	public virtual void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	public virtual void Main()
	{
	}
}
