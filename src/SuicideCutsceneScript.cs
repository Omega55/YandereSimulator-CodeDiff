using System;
using UnityEngine;

public class SuicideCutsceneScript : MonoBehaviour
{
	public Light PointLight;

	public Transform Door;

	public float Timer;

	public float Rotation;

	public float Speed;

	private void Start()
	{
		this.PointLight.color = new Color(0.1f, 0.1f, 0.1f, 1f);
		this.Door.eulerAngles = new Vector3(0f, 0f, 0f);
	}

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 2f)
		{
			this.Speed += Time.deltaTime;
			this.Rotation = Mathf.Lerp(this.Rotation, -45f, Time.deltaTime * this.Speed);
			this.PointLight.color = new Color(0.1f + this.Rotation / -45f * 0.9f, 0.1f + this.Rotation / -45f * 0.9f, 0.1f + this.Rotation / -45f * 0.9f, 1f);
			this.Door.eulerAngles = new Vector3(0f, this.Rotation, 0f);
		}
	}
}
