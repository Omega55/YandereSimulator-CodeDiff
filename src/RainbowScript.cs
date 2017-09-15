using System;
using UnityEngine;

public class RainbowScript : MonoBehaviour
{
	[SerializeField]
	private Renderer MyRenderer;

	[SerializeField]
	private float cyclesPerSecond;

	[SerializeField]
	private float percent;

	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}
}
