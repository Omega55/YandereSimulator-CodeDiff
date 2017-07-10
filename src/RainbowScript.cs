using System;
using UnityEngine;

public class RainbowScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public Color[] Colors;

	public int ID;

	private void Start()
	{
		this.Colors[0] = new Color(1f, 0f, 0f, 1f);
		this.Colors[1] = new Color(1f, 1f, 0f, 1f);
		this.Colors[2] = new Color(0f, 1f, 0f, 1f);
		this.Colors[3] = new Color(0f, 1f, 1f, 1f);
		this.Colors[4] = new Color(0f, 0f, 1f, 1f);
		this.Colors[5] = new Color(1f, 0f, 1f, 1f);
		this.MyRenderer.material.color = this.Colors[0];
	}

	private void Update()
	{
		this.MyRenderer.material.color = Vector4.MoveTowards(this.MyRenderer.material.color, this.Colors[this.ID], Time.deltaTime);
		if (this.MyRenderer.material.color == this.Colors[this.ID])
		{
			this.ID++;
			if (this.ID > this.Colors.Length - 1)
			{
				this.ID = 0;
			}
		}
	}
}
