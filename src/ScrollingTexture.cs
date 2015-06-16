using System;
using UnityEngine;

[Serializable]
public class ScrollingTexture : MonoBehaviour
{
	public float Offset;

	public float Speed;

	public virtual void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.renderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}

	public virtual void Main()
	{
	}
}
