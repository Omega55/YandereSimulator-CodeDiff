using System;
using UnityEngine;

[Serializable]
public class LocationScript : MonoBehaviour
{
	public UILabel Label;

	public UISprite BG;

	public bool Show;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.Label.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Label.color = color;
		int num3 = 0;
		Color color3 = this.BG.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.BG.color = color3;
	}

	public virtual void Update()
	{
		if (this.Show)
		{
			float a = this.BG.color.a + Time.deltaTime * (float)10;
			Color color = this.BG.color;
			float num = color.a = a;
			Color color2 = this.BG.color = color;
			if (this.BG.color.a > (float)1)
			{
				int num2 = 1;
				Color color3 = this.BG.color;
				float num3 = color3.a = (float)num2;
				Color color4 = this.BG.color = color3;
			}
			float a2 = this.BG.color.a;
			Color color5 = this.Label.color;
			float num4 = color5.a = a2;
			Color color6 = this.Label.color = color5;
		}
		else
		{
			float a3 = this.BG.color.a - Time.deltaTime * (float)10;
			Color color7 = this.BG.color;
			float num5 = color7.a = a3;
			Color color8 = this.BG.color = color7;
			if (this.BG.color.a < (float)0)
			{
				int num6 = 0;
				Color color9 = this.BG.color;
				float num7 = color9.a = (float)num6;
				Color color10 = this.BG.color = color9;
			}
			float a4 = this.BG.color.a;
			Color color11 = this.Label.color;
			float num8 = color11.a = a4;
			Color color12 = this.Label.color = color11;
		}
	}

	public virtual void Main()
	{
	}
}
