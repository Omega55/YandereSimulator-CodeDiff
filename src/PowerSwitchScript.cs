﻿using System;
using UnityEngine;

public class PowerSwitchScript : MonoBehaviour
{
	public DrinkingFountainScript DrinkingFountain;

	public PowerOutletScript PowerOutlet;

	public GameObject Electricity;

	public Light BathroomLight;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public AudioClip[] Flick;

	public bool On;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.On = !this.On;
			if (this.On)
			{
				this.Prompt.Label[0].text = "     Turn Off";
				this.MyAudio.clip = this.Flick[1];
			}
			else
			{
				this.Prompt.Label[0].text = "     Turn On";
				this.MyAudio.clip = this.Flick[0];
			}
			if (this.BathroomLight != null)
			{
				this.BathroomLight.enabled = !this.BathroomLight.enabled;
			}
			this.CheckPuddle();
			this.MyAudio.Play();
		}
	}

	public void CheckPuddle()
	{
		if (this.On)
		{
			if (this.DrinkingFountain.Puddle != null && this.DrinkingFountain.Puddle.gameObject.activeInHierarchy && this.PowerOutlet.SabotagedOutlet.activeInHierarchy)
			{
				this.Electricity.SetActive(true);
				return;
			}
		}
		else
		{
			this.Electricity.SetActive(false);
		}
	}
}
