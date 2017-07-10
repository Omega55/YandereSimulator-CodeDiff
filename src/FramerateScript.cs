using System;
using UnityEngine;

public class FramerateScript : MonoBehaviour
{
	public float updateInterval = 0.5f;

	private float accum;

	private int frames;

	private float timeleft;

	public float FPS;

	private void Start()
	{
		if (base.GetComponent<GUIText>() == null)
		{
			Debug.Log("FramerateScript: FramesPerSecond needs a GUIText component!");
			base.enabled = false;
			return;
		}
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
			base.GetComponent<GUIText>().text = "FPS: " + this.FPS.ToString("f0");
			this.timeleft = this.updateInterval;
			this.accum = 0f;
			this.frames = 0;
		}
	}
}
