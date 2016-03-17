using System;
using UnityEngine;

[Serializable]
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

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("MasksBanned") == 1)
		{
			this.active = false;
		}
		else
		{
			this.MyFilter.mesh = this.Meshes[this.ID];
			this.MyRenderer.material.mainTexture = this.Textures[this.ID];
		}
		this.enabled = false;
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.rigidbody.useGravity = false;
			this.rigidbody.isKinematic = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Prompt.MyCollider.enabled = false;
			this.transform.parent = this.Yandere.Head;
			this.transform.localPosition = new Vector3((float)0, 0.033333f, 0.1f);
			this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.Yandere.Mask = this;
			this.ClubManager.UpdateMasks();
			this.StudentManager.UpdateStudents();
		}
	}

	public virtual void Drop()
	{
		this.Prompt.MyCollider.isTrigger = false;
		this.Prompt.MyCollider.enabled = true;
		this.rigidbody.useGravity = true;
		this.rigidbody.isKinematic = false;
		this.Prompt.enabled = true;
		this.transform.parent = null;
		this.Yandere.Mask = null;
		this.ClubManager.UpdateMasks();
		this.StudentManager.UpdateStudents();
	}

	public virtual void Main()
	{
	}
}
