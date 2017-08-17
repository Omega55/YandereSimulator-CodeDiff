using System;
using UnityEngine;

public class CheapFilmGrainScript : MonoBehaviour
{
	public Renderer MyRenderer;

	private void Update()
	{
		this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(100f, 200f), UnityEngine.Random.Range(100f, 200f));
	}
}
