using System;
using UnityEngine;

[Serializable]
public class ShutterScript : MonoBehaviour
{
	public FirstPersonYandereScript FirstPersonYandere;

	public UISprite ShutterSprite;

	public string[] SpriteName;

	public bool Animate;

	public int Frame;

	public virtual void Start()
	{
		this.ShutterSprite.enabled = false;
	}

	public virtual void Update()
	{
		if (this.Animate)
		{
			this.ShutterSprite.enabled = true;
			this.ShutterSprite.spriteName = this.SpriteName[this.Frame];
			this.Frame++;
			if (this.Frame == 8)
			{
				this.FirstPersonYandere.SnapPhoto();
			}
			if (this.Frame > 14)
			{
				this.ShutterSprite.enabled = false;
				this.Animate = false;
				this.Frame = 0;
			}
		}
	}

	public virtual void Main()
	{
	}
}
