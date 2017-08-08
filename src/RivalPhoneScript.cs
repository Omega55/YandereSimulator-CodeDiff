using System;
using UnityEngine;

public class RivalPhoneScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			PlayerPrefs.SetInt("Scheme_4_Stage", 2);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.RivalPhone = true;
			this.Prompt.enabled = false;
			base.enabled = false;
			base.gameObject.SetActive(false);
		}
	}
}
