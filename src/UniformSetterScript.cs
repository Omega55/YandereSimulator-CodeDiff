using System;
using UnityEngine;

public class UniformSetterScript : MonoBehaviour
{
	public Texture[] FemaleUniformTextures;

	public Texture[] MaleUniformTextures;

	public SkinnedMeshRenderer MyRenderer;

	public Mesh[] FemaleUniforms;

	public Mesh[] MaleUniforms;

	public Texture SenpaiFace;

	public Texture SenpaiSkin;

	public Texture RyobaFace;

	public Texture AyanoFace;

	public Texture OsanaFace;

	public int FaceID;

	public int SkinID;

	public int UniformID;

	public int StudentID;

	public bool AttachHair;

	public bool Male;

	public Transform Head;

	public GameObject[] Hair;

	public int HairID;

	public void Start()
	{
		if (this.MyRenderer == null)
		{
			this.MyRenderer = base.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>();
		}
		if (this.Male)
		{
			this.SetMaleUniform();
		}
		else
		{
			this.SetFemaleUniform();
		}
		if (this.AttachHair)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Hair[this.HairID], base.transform.position, base.transform.rotation);
			this.Head = base.transform.Find("Character/PelvisRoot/Hips/Spine/Spine1/Spine2/Spine3/Neck/Head").transform;
			gameObject.transform.parent = this.Head;
		}
	}

	public void SetMaleUniform()
	{
		Debug.Log("StudentGlobals.MaleUniform is: " + StudentGlobals.MaleUniform);
		this.MyRenderer.sharedMesh = this.MaleUniforms[StudentGlobals.MaleUniform];
		if (StudentGlobals.MaleUniform == 1)
		{
			this.SkinID = 0;
			this.UniformID = 1;
			this.FaceID = 2;
		}
		else if (StudentGlobals.MaleUniform == 2 || StudentGlobals.MaleUniform == 3)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (StudentGlobals.MaleUniform == 4 || StudentGlobals.MaleUniform == 5 || StudentGlobals.MaleUniform == 6)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		this.MyRenderer.materials[this.FaceID].mainTexture = this.SenpaiFace;
		this.MyRenderer.materials[this.SkinID].mainTexture = this.SenpaiSkin;
		this.MyRenderer.materials[this.UniformID].mainTexture = this.MaleUniformTextures[StudentGlobals.MaleUniform];
	}

	public void SetFemaleUniform()
	{
		Debug.Log("StudentGlobals.FemaleUniform is: " + StudentGlobals.FemaleUniform);
		this.MyRenderer.sharedMesh = this.FemaleUniforms[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[StudentGlobals.FemaleUniform];
		if (this.StudentID == 0)
		{
			this.MyRenderer.materials[2].mainTexture = this.RyobaFace;
		}
		else if (this.StudentID == 1)
		{
			this.MyRenderer.materials[2].mainTexture = this.AyanoFace;
		}
		else
		{
			this.MyRenderer.materials[2].mainTexture = this.OsanaFace;
		}
	}
}
