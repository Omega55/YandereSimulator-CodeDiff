using System;
using UnityEngine;

public class CheapFilmGrainScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public float Floor = 100f;

	public float Ceiling = 200f;

	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
	}
}
