using System;
using UnityEngine;

public class BusStopScript : MonoBehaviour
{
	public SkinnedMeshRenderer BakerSenpaiRenderer;

	public SkinnedMeshRenderer SenpaiRenderer;

	public CosmeticScript Cosmetic;

	public Texture CasualClothes;

	public MeshRenderer Renderer;

	public Animation SenpaiAnim;

	public AudioSource Jukebox;

	public GameObject Amai;

	public Mesh CasualMesh;

	public float Speed;

	public Animation BakerySenpai;

	public Animation BakeryAmai;

	public Animation InfoChan;

	public float ExtraTimer;

	public float Alpha;

	public float Timer;

	public int Phase = 1;

	private void Start()
	{
		this.Renderer.material.color = new Color(0f, 0f, 0f, 1f);
		base.transform.position = new Vector3(0f, 0.5f, 2f);
		base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
		this.SenpaiAnim["sadFace_00"].layer = 1;
		this.SenpaiAnim.Play("sadFace_00");
	}

	private void Update()
	{
		if (this.Phase == 1)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.5f);
			this.Renderer.material.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.SenpaiRenderer.sharedMesh != this.CasualMesh)
			{
				this.SenpaiRenderer.sharedMesh = this.CasualMesh;
				this.SenpaiRenderer.materials[0].mainTexture = this.CasualClothes;
				this.SenpaiRenderer.materials[1].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinID];
			}
			if (this.BakerSenpaiRenderer.sharedMesh != this.CasualMesh)
			{
				this.BakerSenpaiRenderer.sharedMesh = this.CasualMesh;
				this.BakerSenpaiRenderer.materials[0].mainTexture = this.CasualClothes;
				this.BakerSenpaiRenderer.materials[1].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinID];
			}
			base.transform.position += new Vector3(0f, 0f, this.Speed * Time.deltaTime);
			this.Amai.transform.position -= new Vector3(1f * Time.deltaTime, 0f, 0f);
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.5f);
			this.Renderer.material.color = new Color(0f, 0f, 0f, this.Alpha);
			this.Timer += Time.deltaTime;
			if (this.Timer > 15f)
			{
				this.Speed += Time.deltaTime * 0.1f;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-1.939f, 1.4f, 5.69f), this.Speed * Time.deltaTime);
			if (this.Speed > 1f)
			{
				this.InfoChan.CrossFade("f02_infoSnapPhoto_00", 1f);
			}
			if (this.Timer > 30.5f)
			{
				this.Alpha = 1f;
			}
			if (this.BakerySenpai["bakeryTalk_00"].time >= this.BakerySenpai["bakeryTalk_00"].length - 1f)
			{
				if (this.Alpha < 1f)
				{
					this.ExtraTimer += Time.deltaTime;
					Debug.Log(this.ExtraTimer);
				}
				this.BakerySenpai.CrossFade("carefreeTalk_02", 1f);
				this.BakeryAmai.CrossFade("f02_carefreeTalk_02", 1f);
			}
		}
		if (Input.GetKeyDown("space"))
		{
			base.transform.position = new Vector3(-0.75f, 1.1f, 7.75f);
			base.transform.eulerAngles = new Vector3(0f, 30f, 0f);
			this.Renderer.material.color = new Color(0f, 0f, 0f, 1f);
			this.Alpha = 1f;
			this.BakerySenpai.Play();
			this.BakeryAmai.Play();
			this.Jukebox.Play();
			this.Speed = 0f;
			this.Phase++;
		}
	}
}
