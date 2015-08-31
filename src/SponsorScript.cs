using System;
using UnityEngine;

[Serializable]
public class SponsorScript : MonoBehaviour
{
	public GameObject[] Set;

	public UISprite Darkness;

	public float Timer;

	public virtual void Start()
	{
		this.Set[1].active = true;
		this.Set[2].active = false;
		int num = 1;
		Color color = this.Darkness.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Darkness.color = color;
		this.audio.Play();
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer < (float)6)
		{
			float a = this.Darkness.color.a - Time.deltaTime;
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Darkness.color.a < (float)0)
			{
				int num2 = 0;
				Color color3 = this.Darkness.color;
				float num3 = color3.a = (float)num2;
				Color color4 = this.Darkness.color = color3;
				if (Input.anyKeyDown)
				{
					this.Timer = (float)6;
				}
			}
		}
		else
		{
			float a2 = this.Darkness.color.a + Time.deltaTime;
			Color color5 = this.Darkness.color;
			float num4 = color5.a = a2;
			Color color6 = this.Darkness.color = color5;
			if (this.Darkness.color.a >= (float)1)
			{
				int num5 = 1;
				Color color7 = this.Darkness.color;
				float num6 = color7.a = (float)num5;
				Color color8 = this.Darkness.color = color7;
				if (this.Set[1].active)
				{
					this.Set[1].active = false;
					this.Set[2].active = true;
					this.Timer = (float)0;
				}
				else
				{
					Application.LoadLevel("TitleScene");
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
