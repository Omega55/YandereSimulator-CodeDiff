using System;
using UnityEngine;

[Serializable]
public class FramerateScript : MonoBehaviour
{
	public float updateInterval;

	private float accum;

	private int frames;

	private float timeleft;

	public float FPS;

	public FramerateScript()
	{
		this.updateInterval = 0.5f;
	}

	public virtual void Start()
	{
		if (!this.guiText)
		{
			MonoBehaviour.print("FramesPerSecond needs a GUIText component!");
			this.enabled = false;
		}
		else
		{
			this.timeleft = this.updateInterval;
		}
	}

	public virtual void Update()
	{
		this.timeleft -= Time.deltaTime;
		this.accum += Time.timeScale / Time.deltaTime;
		this.frames++;
		if (this.timeleft <= (float)0)
		{
			this.FPS = this.accum / (float)this.frames;
			this.guiText.text = "FPS: " + (this.accum / (float)this.frames).ToString("f0");
			this.timeleft = this.updateInterval;
			this.accum = (float)0;
			this.frames = 0;
		}
	}

	public virtual void Main()
	{
	}
}
