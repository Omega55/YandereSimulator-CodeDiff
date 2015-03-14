using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DemoWarningScript : MonoBehaviour
{
	public UILabel[] Label;

	public UISprite LeftShadow;

	public UISprite RightShadow;

	public UISprite CenterShadow;

	public float Timer;

	public bool Continue;

	public virtual void Start()
	{
		for (int i = 0; i < Extensions.get_length(this.Label); i++)
		{
			int num = 0;
			Color color = this.Label[i].color;
			float num2 = color.a = (float)num;
			Color color2 = this.Label[i].color = color;
		}
		int num3 = 1;
		Color color3 = this.LeftShadow.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.LeftShadow.color = color3;
		int num5 = 1;
		Color color5 = this.RightShadow.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.RightShadow.color = color5;
		int num7 = 0;
		Color color7 = this.CenterShadow.color;
		float num8 = color7.a = (float)num7;
		Color color8 = this.CenterShadow.color = color7;
	}

	public virtual void Update()
	{
		if (Input.anyKeyDown)
		{
			this.Timer += (float)1;
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1)
		{
			float a = this.Label[0].color.a + Time.deltaTime;
			Color color = this.Label[0].color;
			float num = color.a = a;
			Color color2 = this.Label[0].color = color;
		}
		if (this.Timer > (float)3)
		{
			float a2 = this.Label[1].color.a + Time.deltaTime;
			Color color3 = this.Label[1].color;
			float num2 = color3.a = a2;
			Color color4 = this.Label[1].color = color3;
		}
		if (this.Timer > (float)5)
		{
			float a3 = this.Label[2].color.a + Time.deltaTime;
			Color color5 = this.Label[2].color;
			float num3 = color5.a = a3;
			Color color6 = this.Label[2].color = color5;
		}
		if (this.Timer > (float)7)
		{
			float a4 = this.Label[3].color.a + Time.deltaTime;
			Color color7 = this.Label[3].color;
			float num4 = color7.a = a4;
			Color color8 = this.Label[3].color = color7;
		}
		if (this.Timer > (float)9)
		{
			float a5 = this.Label[4].color.a + Time.deltaTime;
			Color color9 = this.Label[4].color;
			float num5 = color9.a = a5;
			Color color10 = this.Label[4].color = color9;
		}
		if (this.Timer > (float)11)
		{
			float a6 = this.LeftShadow.color.a - Time.deltaTime;
			Color color11 = this.LeftShadow.color;
			float num6 = color11.a = a6;
			Color color12 = this.LeftShadow.color = color11;
		}
		if (this.Timer > (float)13)
		{
			float a7 = this.Label[5].color.a + Time.deltaTime;
			Color color13 = this.Label[5].color;
			float num7 = color13.a = a7;
			Color color14 = this.Label[5].color = color13;
		}
		if (this.Timer > (float)15)
		{
			float a8 = this.RightShadow.color.a - Time.deltaTime;
			Color color15 = this.RightShadow.color;
			float num8 = color15.a = a8;
			Color color16 = this.RightShadow.color = color15;
		}
		if (this.Timer > (float)17)
		{
			float a9 = this.Label[6].color.a + Time.deltaTime;
			Color color17 = this.Label[6].color;
			float num9 = color17.a = a9;
			Color color18 = this.Label[6].color = color17;
		}
		if (this.Timer > (float)19)
		{
			if (Input.anyKeyDown && !this.Continue)
			{
				this.CenterShadow.color = new Color((float)0, (float)0, (float)0, (float)0);
				this.Continue = true;
			}
			if (this.Continue)
			{
				float a10 = this.CenterShadow.color.a + Time.deltaTime;
				Color color19 = this.CenterShadow.color;
				float num10 = color19.a = a10;
				Color color20 = this.CenterShadow.color = color19;
				if (this.CenterShadow.color.a >= (float)1)
				{
					Application.LoadLevel("CalendarScene");
				}
			}
		}
		if (Input.GetKeyDown("space"))
		{
			this.Timer = (float)20;
			if (!this.Continue)
			{
				this.CenterShadow.color = new Color((float)0, (float)0, (float)0, (float)0);
				this.Continue = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
