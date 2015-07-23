using System;
using UnityEngine;

[Serializable]
public class CautionScript : MonoBehaviour
{
	public YandereScript Yandere;

	public UISprite Sprite;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.Sprite.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Sprite.color = color;
	}

	public virtual void Update()
	{
		if ((this.Yandere.Armed && this.Yandere.Weapon[this.Yandere.Equipped].Suspicious) || this.Yandere.Bloodiness > (float)0 || this.Yandere.Sanity < 33.33333f || this.Yandere.NearBodies > 0)
		{
			float a = this.Sprite.color.a + Time.deltaTime;
			Color color = this.Sprite.color;
			float num = color.a = a;
			Color color2 = this.Sprite.color = color;
			if (this.Sprite.color.a > (float)1)
			{
				int num2 = 1;
				Color color3 = this.Sprite.color;
				float num3 = color3.a = (float)num2;
				Color color4 = this.Sprite.color = color3;
			}
		}
		else
		{
			float a2 = this.Sprite.color.a - Time.deltaTime;
			Color color5 = this.Sprite.color;
			float num4 = color5.a = a2;
			Color color6 = this.Sprite.color = color5;
			if (this.Sprite.color.a < (float)0)
			{
				int num5 = 0;
				Color color7 = this.Sprite.color;
				float num6 = color7.a = (float)num5;
				Color color8 = this.Sprite.color = color7;
			}
		}
	}

	public virtual void Main()
	{
	}
}
