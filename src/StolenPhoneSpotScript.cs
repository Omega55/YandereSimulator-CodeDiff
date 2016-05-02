﻿using System;
using UnityEngine;

[Serializable]
public class StolenPhoneSpotScript : MonoBehaviour
{
	public PromptScript Prompt;

	public GameObject RivalPhone;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			PlayerPrefs.SetInt("Scheme_4_Stage", 4);
			this.Prompt.Yandere.SmartphoneRenderer.material.color = new Color(0.125f, 0.125f, 0.125f, (float)1);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.RivalPhone = false;
			this.Prompt.Yandere.RivalPhone = false;
			this.RivalPhone.transform.position = this.transform.position;
			this.RivalPhone.transform.eulerAngles = this.transform.eulerAngles;
			this.RivalPhone.active = true;
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
