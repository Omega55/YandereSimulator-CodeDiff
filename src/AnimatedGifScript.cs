using System;
using UnityEngine;

[Serializable]
public class AnimatedGifScript : MonoBehaviour
{
	public UISprite Sprite;

	public int Frame;

	public int Limit;

	public virtual void Update()
	{
		this.Sprite.spriteName = string.Empty + this.Frame;
		this.Frame++;
		if (this.Frame > this.Limit)
		{
			this.Frame = 0;
		}
	}

	public virtual void Main()
	{
	}
}
