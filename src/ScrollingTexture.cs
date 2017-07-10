using System;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
	public float Offset;

	public float Speed;

	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		base.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}
}
