﻿using System;
using UnityEngine;

public class SpyScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject SpyCamera;

	public Transform SpyTarget;

	public Transform SpySpot;

	public float Timer;

	public bool CanRecord;

	public bool Recording;

	public int Phase;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_spying_00");
			this.Yandere.CanMove = false;
			this.Phase++;
		}
		if (this.Phase == 1)
		{
			Quaternion b = Quaternion.LookRotation(this.SpyTarget.transform.position - this.Yandere.transform.position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, b, Time.deltaTime * 10f);
			this.Yandere.MoveTowardsTarget(this.SpySpot.position);
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				if (this.Yandere.Inventory.DirectionalMic)
				{
					this.PromptBar.Label[0].text = "Record";
					this.CanRecord = true;
				}
				this.PromptBar.Label[1].text = "Stop";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.Yandere.MainCamera.enabled = false;
				this.SpyCamera.SetActive(true);
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 2)
		{
			if (this.CanRecord && Input.GetButtonDown("A"))
			{
				this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_spyRecord_00");
				this.Yandere.Microphone.SetActive(true);
				this.Recording = true;
			}
			if (Input.GetButtonDown("B"))
			{
				this.End();
			}
		}
	}

	public void End()
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Yandere.Microphone.SetActive(false);
		this.Yandere.MainCamera.enabled = true;
		this.Yandere.CanMove = true;
		this.SpyCamera.SetActive(false);
		this.Timer = 0f;
		this.Phase = 0;
	}
}
