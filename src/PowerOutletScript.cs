﻿using System;
using UnityEngine;

public class PowerOutletScript : MonoBehaviour
{
	public PromptScript Prompt;

	public PowerSwitchScript PowerSwitch;

	public GameObject PowerStrip;

	public GameObject PluggedOutlet;

	public GameObject SabotagedOutlet;

	public bool Sabotaged;

	private void Update()
	{
		if (this.PowerStrip == null)
		{
			if (this.Prompt.Yandere.PickUp != null)
			{
				if (this.Prompt.Yandere.PickUp.Electronic)
				{
					this.Prompt.enabled = true;
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					this.PowerStrip = this.Prompt.Yandere.PickUp.gameObject;
					this.Prompt.Yandere.EmptyHands();
					this.PowerStrip.transform.parent = base.transform;
					this.PowerStrip.transform.localPosition = new Vector3(0f, 0f, 0f);
					this.PowerStrip.SetActive(false);
					this.PluggedOutlet.SetActive(true);
					this.Prompt.HideButton[0] = true;
					return;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				return;
			}
		}
		else if (this.Prompt.Yandere.EquippedWeapon != null)
		{
			if (this.Prompt.Yandere.EquippedWeapon.WeaponID == 6)
			{
				this.Prompt.HideButton[1] = false;
				this.Prompt.enabled = true;
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			if (this.Prompt.Circle[1].fillAmount == 0f)
			{
				this.Prompt.Circle[1].fillAmount = 1f;
				this.SabotagedOutlet.SetActive(true);
				this.PluggedOutlet.SetActive(false);
				this.PowerSwitch.CheckPuddle();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.enabled = false;
				return;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}
}
