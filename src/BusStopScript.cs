using System;
using UnityEngine;

public class BusStopScript : MonoBehaviour
{
	public SkinnedMeshRenderer SenpaiRenderer;

	public CosmeticScript Cosmetic;

	public Texture CasualClothes;

	public Animation SenpaiAnim;

	public GameObject Amai;

	public Mesh CasualMesh;

	public float Speed;

	public Animation BakerySenpai;

	public Animation BakeryAmai;

	public Animation InfoChan;

	public int Phase = 1;

	private void Start()
	{
		base.transform.position = new Vector3(0f, 0.5f, 2f);
		base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
		this.SenpaiAnim["sadFace_00"].layer = 1;
		this.SenpaiAnim.Play("sadFace_00");
	}

	private void Update()
	{
		if (this.Phase == 1)
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
		else
		{
			this.Speed += Time.deltaTime * 0.1f;
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-1.939f, 1.4f, 5.69f), this.Speed * Time.deltaTime);
			if (this.Speed > 1f)
			{
				this.InfoChan.CrossFade("f02_infoSnapPhoto_00", 1f);
			}
		}
		if (Input.GetKeyDown("space"))
		{
			base.transform.position = new Vector3(-0.75f, 1.4f, 7.75f);
			base.transform.eulerAngles = new Vector3(0f, 30f, 0f);
			this.BakerySenpai.Play();
			this.BakeryAmai.Play();
			this.Speed = 0f;
			this.Phase++;
		}
	}
}
