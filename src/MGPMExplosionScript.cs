using System;
using UnityEngine;

public class MGPMExplosionScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public Texture[] Sprite;

	public float Timer;

	public float FPS;

	public int Frame;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.FPS)
		{
			this.Timer = 0f;
			this.Frame++;
			if (this.Frame == this.Sprite.Length)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else
			{
				this.MyRenderer.material.mainTexture = this.Sprite[this.Frame];
			}
		}
	}
}
