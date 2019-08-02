using System;
using UnityEngine;

public class BusStopScript : MonoBehaviour
{
	public SkinnedMeshRenderer SenpaiRenderer;

	public CosmeticScript Cosmetic;

	public Texture CasualClothes;

	public Animation SenpaiAnim;

	public Mesh CasualMesh;

	public float Speed;

	public GameObject Amai;

	private void Start()
	{
		this.SenpaiAnim["sadFace_00"].layer = 1;
		this.SenpaiAnim.Play("sadFace_00");
	}

	private void Update()
	{
		if (this.SenpaiRenderer.sharedMesh != this.CasualMesh)
		{
			this.SenpaiRenderer.sharedMesh = this.CasualMesh;
			this.SenpaiRenderer.materials[0].mainTexture = this.CasualClothes;
			this.SenpaiRenderer.materials[1].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinID];
		}
		base.transform.position += new Vector3(0f, 0f, this.Speed * Time.deltaTime);
		this.Amai.transform.position -= new Vector3(1f * Time.deltaTime, 0f, 0f);
	}
}
