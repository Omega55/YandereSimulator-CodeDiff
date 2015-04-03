using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class KuudereScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyRenderer;

	public GameObject Character;

	public AudioClip[] TsunLines;

	public string[] TsunText;

	public AudioClip[] KuuLines;

	public string[] KuuText;

	public UISprite Darkness;

	public UILabel Subtitle;

	public Transform Bone;

	public bool Tsundere;

	public bool FadeOut;

	public float Timer;

	public int PreviousID;

	public int ID;

	public Texture TsunUniform;

	public Texture TsunFace;

	public Texture KuuUniform;

	public Texture KuuFace;

	public GameObject TwinTailR;

	public GameObject TwinTailL;

	public virtual void Start()
	{
		this.Switch();
		this.Subtitle.active = false;
		int num = 1;
		Color color = this.Darkness.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Darkness.color = color;
	}

	public virtual void Update()
	{
		if (this.Darkness.color.a > (float)0)
		{
			if (!this.FadeOut)
			{
				float a = this.Darkness.color.a - Time.deltaTime;
				Color color = this.Darkness.color;
				float num = color.a = a;
				Color color2 = this.Darkness.color = color;
			}
			else
			{
				float a2 = this.Darkness.color.a + Time.deltaTime;
				Color color3 = this.Darkness.color;
				float num2 = color3.a = a2;
				Color color4 = this.Darkness.color = color3;
				if (this.Darkness.color.a >= (float)1)
				{
					Application.Quit();
				}
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.audio.clip != null && this.Timer > this.audio.clip.length + 0.5f && this.Subtitle.active)
			{
				this.Subtitle.active = false;
			}
			if (this.Timer > (float)10)
			{
				if (!this.Tsundere)
				{
					while (this.ID == this.PreviousID)
					{
						this.ID = UnityEngine.Random.Range(0, Extensions.get_length(this.KuuLines));
					}
					this.audio.clip = this.KuuLines[this.ID];
					this.Subtitle.active = true;
					this.Subtitle.text = this.KuuText[this.ID];
				}
				else
				{
					while (this.ID == this.PreviousID)
					{
						this.ID = UnityEngine.Random.Range(0, Extensions.get_length(this.TsunLines));
					}
					this.audio.clip = this.TsunLines[this.ID];
					this.Subtitle.active = true;
					this.Subtitle.text = this.TsunText[this.ID];
				}
				this.PreviousID = this.ID;
				this.audio.Play();
				this.Timer = (float)0;
			}
			if (Input.GetKeyDown("t"))
			{
				if (!this.Tsundere)
				{
					this.Tsundere = true;
					this.Switch();
				}
				else
				{
					this.Tsundere = false;
					this.Switch();
				}
				this.Timer = (float)10;
			}
			if (Input.GetKeyDown("b") && this.Tsundere)
			{
				this.audio.clip = this.TsunLines[5];
				this.audio.Play();
				this.Subtitle.active = true;
				this.Subtitle.text = this.TsunText[5];
				this.Timer = (float)0;
			}
			if (Input.GetKeyDown("escape"))
			{
				float a3 = 1E-06f;
				Color color5 = this.Darkness.color;
				float num3 = color5.a = a3;
				Color color6 = this.Darkness.color = color5;
				this.FadeOut = true;
			}
		}
	}

	public virtual void LateUpdate()
	{
		this.Bone.localPosition = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void Switch()
	{
		if (this.Tsundere)
		{
			this.Character.animation.CrossFade("f02_tsunPose_00");
			this.MyRenderer.materials[0].mainTexture = this.TsunUniform;
			this.MyRenderer.materials[1].mainTexture = this.TsunUniform;
			this.MyRenderer.materials[2].mainTexture = this.TsunFace;
			this.MyRenderer.materials[3].mainTexture = this.TsunFace;
			this.TwinTailR.active = true;
			this.TwinTailL.active = true;
			this.Subtitle.color = new Color((float)1, 0.5f, (float)0, (float)1);
		}
		else
		{
			this.Character.animation.CrossFade("f02_sit_00");
			this.MyRenderer.materials[0].mainTexture = this.KuuUniform;
			this.MyRenderer.materials[1].mainTexture = this.KuuUniform;
			this.MyRenderer.materials[2].mainTexture = this.KuuFace;
			this.MyRenderer.materials[3].mainTexture = this.KuuFace;
			this.TwinTailR.active = false;
			this.TwinTailL.active = false;
			this.Subtitle.color = new Color((float)0, 0.5f, (float)1, (float)1);
		}
	}

	public virtual void Main()
	{
	}
}
