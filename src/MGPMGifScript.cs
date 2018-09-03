using System;
using UnityEngine;

public class MGPMGifScript : MonoBehaviour
{
	public Texture[] Frames;

	public Renderer MyRenderer;

	public float Timer;

	public float FPS;

	public int ID;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.FPS)
		{
			this.ID++;
			if (this.ID == this.Frames.Length)
			{
				this.ID = 0;
			}
			this.MyRenderer.material.mainTexture = this.Frames[this.ID];
			this.Timer = 0f;
		}
	}
}
