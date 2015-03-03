using System;
using UnityEngine;

[Serializable]
public class ShutterScript : MonoBehaviour
{
	public UISprite Sprite;

	public bool Snapping;

	public bool Close;

	public bool Test;

	public int Frame;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.Sprite.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Sprite.color = color;
	}

	public virtual void Update()
	{
		if (this.Test)
		{
			this.Test = false;
			this.Snap();
		}
		if (this.Snapping)
		{
			if (this.Close)
			{
				this.Frame++;
				this.Sprite.spriteName = "Shutter" + this.Frame;
				if (this.Frame == 8)
				{
					this.Close = false;
				}
			}
			else
			{
				this.Frame--;
				this.Sprite.spriteName = "Shutter" + this.Frame;
				if (this.Frame == 1)
				{
					int num = 0;
					Color color = this.Sprite.color;
					float num2 = color.a = (float)num;
					Color color2 = this.Sprite.color = color;
					this.Snapping = false;
				}
			}
		}
	}

	public virtual void Snap()
	{
		int num = 1;
		Color color = this.Sprite.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Sprite.color = color;
		this.Snapping = true;
		this.Close = true;
		this.Frame = 0;
	}

	public virtual void Main()
	{
	}
}
