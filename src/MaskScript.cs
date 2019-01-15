using System;
using UnityEngine;

public class MaskScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public ClubManagerScript ClubManager;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public PickUpScript PickUp;

	public Projector Blood;

	public Renderer MyRenderer;

	public MeshFilter MyFilter;

	public Texture[] Textures;

	public Mesh[] Meshes;

	public int ID;

	private void Start()
	{
		if (GameGlobals.MasksBanned)
		{
			base.gameObject.SetActive(false);
		}
		else
		{
			this.MyFilter.mesh = this.Meshes[this.ID];
			this.MyRenderer.material.mainTexture = this.Textures[this.ID];
		}
		base.enabled = false;
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			Rigidbody component = base.GetComponent<Rigidbody>();
			component.useGravity = false;
			component.isKinematic = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Prompt.MyCollider.enabled = false;
			base.transform.parent = this.Yandere.Head;
			base.transform.localPosition = new Vector3(0f, 0.033333f, 0.1f);
			base.transform.localEulerAngles = Vector3.zero;
			this.Yandere.Mask = this;
			this.ClubManager.UpdateMasks();
			this.StudentManager.UpdateStudents(0);
		}
	}

	public void Drop()
	{
		this.Prompt.MyCollider.isTrigger = false;
		this.Prompt.MyCollider.enabled = true;
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.useGravity = true;
		component.isKinematic = false;
		this.Prompt.enabled = true;
		base.transform.parent = null;
		this.Yandere.Mask = null;
		this.ClubManager.UpdateMasks();
		this.StudentManager.UpdateStudents(0);
	}
}
