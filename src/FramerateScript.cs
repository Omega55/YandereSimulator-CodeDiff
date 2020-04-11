using System;
using UnityEngine;

public class FramerateScript : MonoBehaviour
{
	public float updateInterval = 0.5f;

	private float accum;

	private int frames;

	private float timeleft;

	public float FPS;

	public UILabel FPSLabel;

	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	private void Update()
	{
		this.timeleft -= Time.deltaTime;
		this.accum += Time.timeScale / Time.deltaTime;
		this.frames++;
		if (this.timeleft <= 0f)
		{
			this.FPS = this.accum / (float)this.frames;
			int num = Mathf.Clamp((int)this.FPS, 0, Application.targetFrameRate);
			if (num > 0)
			{
				this.FPSLabel.text = "FPS: " + num.ToString();
			}
			this.timeleft = this.updateInterval;
			this.accum = 0f;
			this.frames = 0;
		}
	}
}
