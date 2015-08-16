using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class IntroScript : MonoBehaviour
{
	public UISprite FadeOutDarkness;

	public UIPanel SkipPanel;

	public UISprite Darkness;

	public UISprite Circle;

	public UITexture Logo;

	public UILabel Label;

	public AudioSource Narration;

	public string[] Lines;

	public float[] Cue;

	public bool Narrating;

	public bool Musicing;

	public bool FadeOut;

	public float SkipTimer;

	public float Timer;

	public int ID;

	public virtual void Start()
	{
		this.Circle.fillAmount = (float)0;
		int num = 1;
		Color color = this.Darkness.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Darkness.color = color;
		this.Label.text = string.Empty;
		this.SkipTimer = (float)15;
	}

	public virtual void Update()
	{
		if (Input.GetButton("X"))
		{
			this.Circle.fillAmount = Mathf.MoveTowards(this.Circle.fillAmount, (float)1, Time.deltaTime);
			this.SkipTimer = (float)15;
			if (this.Circle.fillAmount == (float)1)
			{
				this.FadeOut = true;
			}
			this.SkipPanel.alpha = (float)1;
		}
		else
		{
			this.Circle.fillAmount = Mathf.MoveTowards(this.Circle.fillAmount, (float)0, Time.deltaTime);
			this.SkipTimer -= Time.deltaTime;
			this.SkipPanel.alpha = this.SkipTimer / (float)10;
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1 && !this.Narrating)
		{
			this.Narration.Play();
			this.Narrating = true;
		}
		if (this.ID < Extensions.get_length(this.Cue) && this.Narration.time > this.Cue[this.ID])
		{
			this.Label.text = this.Lines[this.ID];
			this.ID++;
		}
		if (this.FadeOut)
		{
			float a = Mathf.MoveTowards(this.FadeOutDarkness.color.a, (float)1, Time.deltaTime);
			Color color = this.FadeOutDarkness.color;
			float num = color.a = a;
			Color color2 = this.FadeOutDarkness.color = color;
			this.Circle.fillAmount = (float)1;
			this.Narration.volume = this.FadeOutDarkness.color.a;
			if (this.FadeOutDarkness.color.a == (float)1)
			{
				Application.LoadLevel("PhoneScene");
			}
		}
		if (this.Narration.time > 39.75f && this.Narration.time < (float)73)
		{
			float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime * 0.5f);
			Color color3 = this.Darkness.color;
			float num2 = color3.a = a2;
			Color color4 = this.Darkness.color = color3;
		}
		if (this.Narration.time > (float)73 && this.Narration.time < 105.5f)
		{
			float a3 = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
			Color color5 = this.Darkness.color;
			float num3 = color5.a = a3;
			Color color6 = this.Darkness.color = color5;
		}
		if (this.Narration.time > 105.5f && this.Narration.time < (float)134)
		{
			this.Darkness.color = new Color((float)1, (float)0, (float)0, (float)1);
		}
		if (this.Narration.time > (float)134 && this.Narration.time < (float)147)
		{
			this.Darkness.color = new Color((float)0, (float)0, (float)0, (float)1);
		}
		if (this.Narration.time > (float)147 && this.Narration.time < (float)152)
		{
			float x = this.Logo.transform.localScale.x + Time.deltaTime * 0.1f;
			Vector3 localScale = this.Logo.transform.localScale;
			float num4 = localScale.x = x;
			Vector3 vector = this.Logo.transform.localScale = localScale;
			float y = this.Logo.transform.localScale.y + Time.deltaTime * 0.1f;
			Vector3 localScale2 = this.Logo.transform.localScale;
			float num5 = localScale2.y = y;
			Vector3 vector2 = this.Logo.transform.localScale = localScale2;
			float z = this.Logo.transform.localScale.z + Time.deltaTime * 0.1f;
			Vector3 localScale3 = this.Logo.transform.localScale;
			float num6 = localScale3.z = z;
			Vector3 vector3 = this.Logo.transform.localScale = localScale3;
			int num7 = 1;
			Color color7 = this.Logo.color;
			float num8 = color7.a = (float)num7;
			Color color8 = this.Logo.color = color7;
		}
		if (this.Narration.time > (float)152)
		{
			int num9 = 0;
			Color color9 = this.Logo.color;
			float num10 = color9.a = (float)num9;
			Color color10 = this.Logo.color = color9;
		}
		if (this.Narration.time > (float)156)
		{
			Application.LoadLevel("PhoneScene");
		}
	}

	public virtual void Main()
	{
	}
}
