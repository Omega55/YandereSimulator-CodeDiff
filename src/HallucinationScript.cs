using System;
using UnityEngine;

public class HallucinationScript : MonoBehaviour
{
	public SkinnedMeshRenderer YandereHairRenderer;

	public SkinnedMeshRenderer YandereRenderer;

	public SkinnedMeshRenderer RivalHairRenderer;

	public SkinnedMeshRenderer RivalRenderer;

	public Animation YandereAnimation;

	public Animation RivalAnimation;

	public YandereScript Yandere;

	public Material Black;

	public bool Hallucinate;

	public float Alpha;

	public float Timer;

	public int Weapon;

	public string[] WeaponName;

	private void Start()
	{
		this.YandereHairRenderer.material = this.Black;
		this.RivalHairRenderer.material = this.Black;
		this.YandereRenderer.materials[0] = this.Black;
		this.YandereRenderer.materials[1] = this.Black;
		this.YandereRenderer.materials[2] = this.Black;
		this.RivalRenderer.materials[0] = this.Black;
		this.RivalRenderer.materials[1] = this.Black;
		this.RivalRenderer.materials[2] = this.Black;
		this.MakeTransparent();
	}

	private void Update()
	{
		if (this.Yandere.Sanity < 33.33333f)
		{
			if (!this.Yandere.Aiming)
			{
				this.Timer += Time.deltaTime;
			}
			if (this.Timer > 6f)
			{
				this.Weapon = UnityEngine.Random.Range(1, 6);
				base.transform.position = this.Yandere.transform.position + this.Yandere.transform.forward;
				base.transform.eulerAngles = this.Yandere.transform.eulerAngles;
				this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].time = 0f;
				this.RivalAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityB_00"].time = 0f;
				this.YandereAnimation.Play("f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00");
				this.RivalAnimation.Play("f02_" + this.WeaponName[this.Weapon] + "LowSanityB_00");
				this.Hallucinate = true;
				this.Timer = 0f;
			}
		}
		if (this.Hallucinate)
		{
			if (this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].time < 3f)
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.33333f);
			}
			else
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.33333f);
			}
			this.YandereHairRenderer.material.color = new Color(0f, 0f, 0f, this.Alpha);
			this.RivalHairRenderer.material.color = new Color(0f, 0f, 0f, this.Alpha);
			this.YandereRenderer.materials[0].color = new Color(0f, 0f, 0f, this.Alpha);
			this.YandereRenderer.materials[1].color = new Color(0f, 0f, 0f, this.Alpha);
			this.YandereRenderer.materials[2].color = new Color(0f, 0f, 0f, this.Alpha);
			this.RivalRenderer.materials[0].color = new Color(0f, 0f, 0f, this.Alpha);
			this.RivalRenderer.materials[1].color = new Color(0f, 0f, 0f, this.Alpha);
			this.RivalRenderer.materials[2].color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].time == this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].length || this.Yandere.Aiming)
			{
				this.MakeTransparent();
				this.Hallucinate = false;
			}
		}
	}

	private void MakeTransparent()
	{
		this.Alpha = 0f;
		this.YandereHairRenderer.material.color = new Color(0f, 0f, 0f, this.Alpha);
		this.RivalHairRenderer.material.color = new Color(0f, 0f, 0f, this.Alpha);
		this.YandereRenderer.materials[0].color = new Color(0f, 0f, 0f, this.Alpha);
		this.YandereRenderer.materials[1].color = new Color(0f, 0f, 0f, this.Alpha);
		this.YandereRenderer.materials[2].color = new Color(0f, 0f, 0f, this.Alpha);
		this.RivalRenderer.materials[0].color = new Color(0f, 0f, 0f, this.Alpha);
		this.RivalRenderer.materials[1].color = new Color(0f, 0f, 0f, this.Alpha);
		this.RivalRenderer.materials[2].color = new Color(0f, 0f, 0f, this.Alpha);
	}
}
