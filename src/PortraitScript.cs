using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PortraitScript : MonoBehaviour
{
	public GameObject[] StudentObject;

	public Renderer Renderer1;

	public Renderer Renderer2;

	public Renderer Renderer3;

	public Texture[] HairSet1;

	public Texture[] HairSet2;

	public Texture[] HairSet3;

	public int Selected;

	public int CurrentHair;

	public virtual void Start()
	{
		this.StudentObject[1].active = false;
		this.StudentObject[2].active = false;
		this.Selected = 1;
		this.UpdateHair();
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("1"))
		{
			this.StudentObject[0].active = true;
			this.StudentObject[1].active = false;
			this.StudentObject[2].active = false;
			this.Selected = 1;
		}
		else if (Input.GetKeyDown("2"))
		{
			this.StudentObject[0].active = false;
			this.StudentObject[1].active = true;
			this.StudentObject[2].active = false;
			this.Selected = 2;
		}
		else if (Input.GetKeyDown("3"))
		{
			this.StudentObject[0].active = false;
			this.StudentObject[1].active = false;
			this.StudentObject[2].active = true;
			this.Selected = 3;
		}
		if (Input.GetKeyDown("space"))
		{
			this.CurrentHair++;
			if (this.CurrentHair > Extensions.get_length(this.HairSet1) - 1)
			{
				this.CurrentHair = 0;
			}
			this.UpdateHair();
		}
	}

	public virtual void UpdateHair()
	{
		this.Renderer1.materials[0].mainTexture = this.HairSet2[this.CurrentHair];
		this.Renderer1.materials[3].mainTexture = this.HairSet2[this.CurrentHair];
		this.Renderer2.materials[2].mainTexture = this.HairSet2[this.CurrentHair];
		this.Renderer2.materials[3].mainTexture = this.HairSet2[this.CurrentHair];
		this.Renderer3.materials[0].mainTexture = this.HairSet2[this.CurrentHair];
		this.Renderer3.materials[1].mainTexture = this.HairSet2[this.CurrentHair];
	}

	public virtual void Main()
	{
	}
}
