using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WarningScript : MonoBehaviour
{
	public float[] Triggers;

	public string[] Text;

	public UILabel WarningLabel;

	public UISprite Darkness;

	public UILabel Label;

	public bool FadeOut;

	public float Timer;

	public int ID;

	public virtual void Start()
	{
		this.WarningLabel.active = false;
		this.Label.text = string.Empty;
		int num = 1;
		Color color = this.Darkness.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Darkness.color = color;
	}

	public virtual void Update()
	{
		if (!this.FadeOut)
		{
			float a = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Darkness.color.a == (float)0)
			{
				if (this.Timer == (float)0)
				{
					this.WarningLabel.active = true;
					this.audio.Play();
				}
				this.Timer += Time.deltaTime;
				if (this.ID < Extensions.get_length(this.Triggers) && this.Timer > this.Triggers[this.ID])
				{
					this.Label.text = this.Text[this.ID];
					this.ID++;
				}
			}
		}
		else
		{
			this.audio.volume = Mathf.MoveTowards(this.audio.volume, (float)0, Time.deltaTime);
			float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
			Color color3 = this.Darkness.color;
			float num2 = color3.a = a2;
			Color color4 = this.Darkness.color = color3;
			if (this.Darkness.color.a == (float)1)
			{
				Application.LoadLevel("SponsorScene");
			}
		}
		if (Input.anyKey)
		{
			this.FadeOut = true;
		}
	}

	public virtual void Main()
	{
	}
}
