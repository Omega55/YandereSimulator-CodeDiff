﻿using System;
using UnityEngine;

public class RivalPhoneScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public PromptScript Prompt;

	public bool LewdPhotos;

	public bool Stolen;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			SchemeGlobals.SetSchemeStage(4, 2);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.RivalPhoneTexture = this.MyRenderer.material.mainTexture;
			this.Prompt.Yandere.Inventory.RivalPhone = true;
			this.Prompt.enabled = false;
			base.enabled = false;
			base.gameObject.SetActive(false);
			this.Stolen = true;
		}
	}
}
