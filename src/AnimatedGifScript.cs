using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AnimatedGifScript : MonoBehaviour
{
	public UITexture MyTexture;

	public Texture[] Frames;

	public int Frame;

	public virtual void Update()
	{
		this.MyTexture.mainTexture = this.Frames[this.Frame];
		this.Frame++;
		if (this.Frame > Extensions.get_length(this.Frames) - 1)
		{
			this.Frame = 0;
		}
	}

	public virtual void Main()
	{
	}
}
