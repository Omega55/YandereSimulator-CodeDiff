using System;
using UnityEngine;

public class MGPMWaterScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public Texture[] Sprite;

	public float Speed;

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
				this.Frame = 0;
			}
			this.MyRenderer.material.mainTexture = this.Sprite[this.Frame];
		}
		base.transform.localPosition = new Vector3(0f, base.transform.localPosition.y - this.Speed * Time.deltaTime, 3f);
		if (base.transform.localPosition.y < -640f)
		{
			base.transform.localPosition = new Vector3(0f, base.transform.localPosition.y + 1280f, 3f);
		}
	}
}
