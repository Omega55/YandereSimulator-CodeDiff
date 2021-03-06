﻿using System;
using UnityEngine;

public class RingScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			SchemeGlobals.SetSchemeStage(2, 2);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Ring = true;
			this.Prompt.Yandere.TheftTimer = 0.1f;
			base.gameObject.SetActive(false);
		}
	}
}
