using System;
using UnityEngine;

[Serializable]
public class BlackScript : MonoBehaviour
{
	public YandereScript Yandere;

	public bool FadeIn;

	public UISprite Sprite;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Update()
	{
		if (this.FadeIn)
		{
			float a = this.Sprite.color.a - Time.deltaTime;
			Color color = this.Sprite.color;
			float num = color.a = a;
			Color color2 = this.Sprite.color = color;
			if (this.Sprite.color.a < (float)0)
			{
				this.Yandere.AcceptingInput = true;
				int num2 = 0;
				Color color3 = this.Sprite.color;
				float num3 = color3.a = (float)num2;
				Color color4 = this.Sprite.color = color3;
				this.FadeIn = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
