using System;
using UnityEngine;

[Serializable]
public class HomeDarknessScript : MonoBehaviour
{
	public UISprite Sprite;

	public bool FadeOut;

	public virtual void Start()
	{
		int num = 1;
		Color color = this.Sprite.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Sprite.color = color;
	}

	public virtual void Update()
	{
		if (this.FadeOut)
		{
			if (this.Sprite.color.a == (float)0)
			{
				this.Sprite.color = new Color((float)1, (float)1, (float)1, (float)0);
			}
			float a = this.Sprite.color.a + Time.deltaTime;
			Color color = this.Sprite.color;
			float num = color.a = a;
			Color color2 = this.Sprite.color = color;
			if (this.Sprite.color.a >= (float)1)
			{
				Application.LoadLevel("SchoolScene");
			}
		}
		else
		{
			float a2 = this.Sprite.color.a - Time.deltaTime;
			Color color3 = this.Sprite.color;
			float num2 = color3.a = a2;
			Color color4 = this.Sprite.color = color3;
			if (this.Sprite.color.a < (float)0)
			{
				int num3 = 0;
				Color color5 = this.Sprite.color;
				float num4 = color5.a = (float)num3;
				Color color6 = this.Sprite.color = color5;
			}
		}
	}

	public virtual void Main()
	{
	}
}
