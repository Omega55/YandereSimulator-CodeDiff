using System;
using UnityEngine;
using XInputDotNetPure;

public class VibrationScript : MonoBehaviour
{
	public float Strength1;

	public float Strength2;

	public float TimeLimit;

	public float Timer;

	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);
	}

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}
}
