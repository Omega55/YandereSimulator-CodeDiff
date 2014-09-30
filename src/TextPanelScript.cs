using System;
using UnityEngine;

[Serializable]
public class TextPanelScript : MonoBehaviour
{
	public UILabel[] Text;

	public bool[] TextShow;

	public float[] TextTimer;

	private int RB;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.Text[1].color;
		float num2 = color.a = (float)num;
		Color color2 = this.Text[1].color = color;
		int num3 = 0;
		Color color3 = this.Text[2].color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Text[2].color = color3;
		int num5 = 0;
		Color color5 = this.Text[3].color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.Text[3].color = color5;
		int num7 = 0;
		Color color7 = this.Text[4].color;
		float num8 = color7.a = (float)num7;
		Color color8 = this.Text[4].color = color7;
		int num9 = 0;
		Color color9 = this.Text[5].color;
		float num10 = color9.a = (float)num9;
		Color color10 = this.Text[5].color = color9;
		int num11 = 0;
		Color color11 = this.Text[6].color;
		float num12 = color11.a = (float)num11;
		Color color12 = this.Text[6].color = color11;
		int num13 = 0;
		Color color13 = this.Text[7].color;
		float num14 = color13.a = (float)num13;
		Color color14 = this.Text[7].color = color13;
	}

	public virtual void Update()
	{
		for (int i = 1; i < 8; i++)
		{
			if (this.TextShow[i])
			{
				this.TextTimer[i] = this.TextTimer[i] + Time.deltaTime;
				if (this.TextTimer[i] < (float)6)
				{
					if (this.Text[i].color.a < (float)1)
					{
						float a = this.Text[i].color.a + Time.deltaTime;
						Color color = this.Text[i].color;
						float num = color.a = a;
						Color color2 = this.Text[i].color = color;
					}
				}
				else
				{
					float a2 = this.Text[i].color.a - Time.deltaTime;
					Color color3 = this.Text[i].color;
					float num2 = color3.a = a2;
					Color color4 = this.Text[i].color = color3;
				}
			}
		}
		if (Input.GetButtonDown("Y"))
		{
			this.TextShow[1] = true;
		}
		if (Input.GetButtonDown("X"))
		{
			this.TextShow[2] = true;
		}
		if (Input.GetButtonDown("A"))
		{
			this.TextShow[3] = true;
		}
		if (Input.GetButtonDown("RB"))
		{
			this.TextShow[4] = true;
			this.RB++;
			if (this.RB > 15)
			{
				this.TextShow[5] = true;
			}
			if (this.RB > 50)
			{
				this.TextShow[6] = true;
			}
			if (this.RB > 100)
			{
				this.TextShow[7] = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
