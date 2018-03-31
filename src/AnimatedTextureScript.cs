using System;
using UnityEngine;

public class AnimatedTextureScript : MonoBehaviour
{
	[SerializeField]
	private Renderer MyRenderer;

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

	public Texture[] Image;

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
		this.MyRenderer.material.mainTexture = this.Image[this.Frame];
	}
}
