using System;
using UnityEngine;

public class AnimatedGifScript : MonoBehaviour
{
	public UISprite Sprite;

	public string SpriteName = string.Empty;

	public int Start;

	public int Frame;

	public int Limit;

	public float Framerate;

	public float Timer;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.Framerate)
		{
			this.Sprite.spriteName = this.SpriteName + this.Frame.ToString();
			this.Timer = 0f;
			this.Frame++;
			if (this.Frame > this.Limit)
			{
				this.Frame = this.Start;
			}
		}
	}
}
