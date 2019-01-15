using System;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
	public Renderer MyRenderer;

	public float Offset;

	public float Speed;

	private void Start()
	{
		this.MyRenderer = base.GetComponent<Renderer>();
	}

	private void Update()
	{
		this.Offset += Time.deltaTime * this.Speed;
		this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
	}
}
