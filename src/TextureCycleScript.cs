using System;
using UnityEngine;

public class TextureCycleScript : MonoBehaviour
{
	public UITexture Sprite;

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

	[SerializeField]
	private Texture[] Textures;

	public int ID;

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
		this.ID++;
		if (this.ID > 1)
		{
			this.ID = 0;
			this.Frame++;
			if (this.Frame > this.Limit)
			{
				this.Frame = this.Start;
			}
		}
		this.Sprite.mainTexture = this.Textures[this.Frame];
	}
}
