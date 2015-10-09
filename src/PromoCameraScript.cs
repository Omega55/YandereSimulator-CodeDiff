using System;
using UnityEngine;

[Serializable]
public class PromoCameraScript : MonoBehaviour
{
	public PortraitChanScript PromoCharacter;

	public Vector3[] StartPositions;

	public Vector3[] StartRotations;

	public Renderer PromoBlack;

	public Renderer Noose;

	public Renderer Rope;

	public Camera MyCamera;

	public Transform Drills;

	public float Timer;

	public int ID;

	public virtual void Start()
	{
		this.transform.eulerAngles = this.StartRotations[this.ID];
		this.transform.position = this.StartPositions[this.ID];
		this.PromoCharacter.gameObject.active = false;
		int num = 0;
		Color color = this.PromoBlack.material.color;
		float num2 = color.a = (float)num;
		Color color2 = this.PromoBlack.material.color = color;
		int num3 = 0;
		Color color3 = this.Noose.material.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Noose.material.color = color3;
		int num5 = 0;
		Color color5 = this.Rope.material.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.Rope.material.color = color5;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("space") && this.ID < 3)
		{
			this.ID++;
			this.UpdatePosition();
		}
		if (this.ID == 0)
		{
			this.transform.Translate(Vector3.back * Time.deltaTime * 0.01f);
		}
		else if (this.ID == 1)
		{
			this.transform.Translate(Vector3.back * Time.deltaTime * 0.01f);
		}
		else if (this.ID == 2)
		{
			this.transform.Translate(Vector3.forward * Time.deltaTime * 0.01f);
			this.PromoCharacter.gameObject.active = true;
		}
		else if (this.ID == 1 || this.ID == 3)
		{
			this.transform.Translate(Vector3.back * Time.deltaTime * 0.1f);
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)20)
		{
			float a = this.Noose.material.color.a + Time.deltaTime * 0.2f;
			Color color = this.Noose.material.color;
			float num = color.a = a;
			Color color2 = this.Noose.material.color = color;
			float a2 = this.Rope.material.color.a + Time.deltaTime * 0.2f;
			Color color3 = this.Rope.material.color;
			float num2 = color3.a = a2;
			Color color4 = this.Rope.material.color = color3;
		}
		else if (this.Timer > (float)15)
		{
			float a3 = this.PromoBlack.material.color.a + Time.deltaTime * 0.2f;
			Color color5 = this.PromoBlack.material.color;
			float num3 = color5.a = a3;
			Color color6 = this.PromoBlack.material.color = color5;
		}
		if (this.Timer > (float)10)
		{
			this.Drills.LookAt(this.Drills.position - Vector3.right * (float)1);
			if (this.ID == 2)
			{
				this.ID = 3;
				this.UpdatePosition();
			}
		}
		else if (this.Timer > (float)5)
		{
			this.PromoCharacter.EyeShrink = this.PromoCharacter.EyeShrink + Time.deltaTime * 0.1f;
			if (this.ID == 1)
			{
				this.ID = 2;
				this.UpdatePosition();
			}
		}
	}

	public virtual void UpdatePosition()
	{
		this.transform.position = this.StartPositions[this.ID];
		this.transform.eulerAngles = this.StartRotations[this.ID];
		if (this.ID == 2)
		{
			this.MyCamera.farClipPlane = (float)3;
			this.Timer = (float)5;
		}
		if (this.ID == 3)
		{
			this.MyCamera.farClipPlane = (float)5;
			this.Timer = (float)10;
		}
	}

	public virtual void Main()
	{
	}
}
