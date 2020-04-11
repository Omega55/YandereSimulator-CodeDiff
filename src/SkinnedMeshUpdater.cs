using System;
using UnityEngine;

public class SkinnedMeshUpdater : MonoBehaviour
{
	public SkinnedMeshRenderer MyRenderer;

	public GameObject TransformEffect;

	public GameObject[] Characters;

	public PromptScript Prompt;

	public GameObject BreastR;

	public GameObject BreastL;

	public GameObject FumiGlasses;

	public GameObject NinaGlasses;

	private SkinnedMeshRenderer TempRenderer;

	public Texture[] Bodies;

	public Texture[] Faces;

	public float Timer;

	public int ID;

	public void Start()
	{
		this.GlassesCheck();
	}

	public void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			Object.Instantiate<GameObject>(this.TransformEffect, this.Prompt.Yandere.Hips.position, Quaternion.identity);
			this.Prompt.Yandere.CharacterAnimation.Play(this.Prompt.Yandere.IdleAnim);
			this.Prompt.Yandere.CanMove = false;
			this.Prompt.Yandere.Egg = true;
			this.BreastR.name = "RightBreast";
			this.BreastL.name = "LeftBreast";
			this.Timer = 1f;
			this.ID++;
			if (this.ID == this.Characters.Length)
			{
				this.ID = 1;
			}
			this.Prompt.Yandere.Hairstyle = 120 + this.ID;
			this.Prompt.Yandere.UpdateHair();
			this.GlassesCheck();
			this.UpdateSkin();
		}
		if (this.Timer > 0f)
		{
			this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
			if (this.Timer == 0f)
			{
				this.Prompt.Yandere.CanMove = true;
			}
		}
	}

	public void UpdateSkin()
	{
		GameObject gameObject = Object.Instantiate<GameObject>(this.Characters[this.ID], Vector3.zero, Quaternion.identity);
		this.TempRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		this.UpdateMeshRenderer(this.TempRenderer);
		Object.Destroy(gameObject);
		this.MyRenderer.materials[0].mainTexture = this.Bodies[this.ID];
		this.MyRenderer.materials[1].mainTexture = this.Bodies[this.ID];
		this.MyRenderer.materials[2].mainTexture = this.Faces[this.ID];
	}

	private void UpdateMeshRenderer(SkinnedMeshRenderer newMeshRenderer)
	{
		SkinnedMeshUpdater.<>c__DisplayClass16_0 CS$<>8__locals1 = new SkinnedMeshUpdater.<>c__DisplayClass16_0();
		CS$<>8__locals1.newMeshRenderer = newMeshRenderer;
		SkinnedMeshRenderer myRenderer = this.Prompt.Yandere.MyRenderer;
		myRenderer.sharedMesh = CS$<>8__locals1.newMeshRenderer.sharedMesh;
		Transform[] componentsInChildren = this.Prompt.Yandere.transform.GetComponentsInChildren<Transform>(true);
		Transform[] array = new Transform[CS$<>8__locals1.newMeshRenderer.bones.Length];
		int boneOrder;
		int boneOrder2;
		for (boneOrder = 0; boneOrder < CS$<>8__locals1.newMeshRenderer.bones.Length; boneOrder = boneOrder2 + 1)
		{
			array[boneOrder] = Array.Find<Transform>(componentsInChildren, (Transform c) => c.name == CS$<>8__locals1.newMeshRenderer.bones[boneOrder].name);
			boneOrder2 = boneOrder;
		}
		myRenderer.bones = array;
	}

	private void GlassesCheck()
	{
		this.FumiGlasses.SetActive(false);
		this.NinaGlasses.SetActive(false);
		if (this.ID == 7)
		{
			this.FumiGlasses.SetActive(true);
			return;
		}
		if (this.ID == 8)
		{
			this.NinaGlasses.SetActive(true);
		}
	}
}
