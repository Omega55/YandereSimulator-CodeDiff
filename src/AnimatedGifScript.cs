using System;
using UnityEngine;

[Serializable]
public class AnimatedGifScript : MonoBehaviour
{
	public UISprite Sprite;

	public string SpriteName;

	public int Start;

	public int Frame;

	public int Limit;

	public float Framerate;

	public float Timer;

	public AnimatedGifScript()
	{
		this.SpriteName = string.Empty;
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.Framerate)
		{
			this.Sprite.spriteName = this.SpriteName + this.Frame;
			this.Timer = (float)0;
			this.Frame++;
			if (this.Frame > this.Limit)
			{
				this.Frame = this.Start;
			}
		}
	}

	public virtual void Main()
	{
	}
}
