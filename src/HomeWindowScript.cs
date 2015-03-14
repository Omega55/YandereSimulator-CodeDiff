using System;
using UnityEngine;

[Serializable]
public class HomeWindowScript : MonoBehaviour
{
	public UISprite Sprite;

	public bool Show;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.Sprite.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Sprite.color = color;
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			float a = Mathf.Lerp(this.Sprite.color.a, (float)0, Time.deltaTime * (float)10);
			Color color = this.Sprite.color;
			float num = color.a = a;
			Color color2 = this.Sprite.color = color;
		}
		else
		{
			float a2 = Mathf.Lerp(this.Sprite.color.a, (float)1, Time.deltaTime * (float)10);
			Color color3 = this.Sprite.color;
			float num2 = color3.a = a2;
			Color color4 = this.Sprite.color = color3;
		}
	}

	public virtual void Main()
	{
	}
}
