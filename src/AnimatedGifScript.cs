using System;
using UnityEngine;

public class AnimatedGifScript : MonoBehaviour
{
	[SerializeField]
	private UISprite Sprite;

	[SerializeField]
	private string SpriteName;

	[SerializeField]
	private int Start;

	[SerializeField]
	private int Frame;

	[SerializeField]
	private int Limit;

	[SerializeField]
	private float FramesPerSecond;

	[SerializeField]
	private float CurrentSeconds;

	private void Awake()
	{
	}

	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	private void Update()
	{
		this.CurrentSeconds += Time.unscaledDeltaTime;
		while (this.CurrentSeconds >= this.SecondsPerFrame)
		{
			this.CurrentSeconds -= this.SecondsPerFrame;
			this.Frame++;
			if (this.Frame > this.Limit)
			{
				this.Frame = this.Start;
			}
		}
		this.Sprite.spriteName = this.SpriteName + this.Frame.ToString();
	}
}
