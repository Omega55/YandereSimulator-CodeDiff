using System;
using UnityEngine;

public class LocationScript : MonoBehaviour
{
	public UILabel Label;

	public UISprite BG;

	public bool Show;

	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0f);
	}

	private void Update()
	{
		if (this.Show)
		{
			this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, this.BG.color.a + Time.deltaTime * 10f);
			if (this.BG.color.a > 1f)
			{
				this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 1f);
			}
			this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, this.BG.color.a);
			return;
		}
		this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, this.BG.color.a - Time.deltaTime * 10f);
		if (this.BG.color.a < 0f)
		{
			this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0f);
		}
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, this.BG.color.a);
	}
}
