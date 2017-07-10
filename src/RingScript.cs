using System;
using UnityEngine;

public class RingScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			PlayerPrefs.SetInt("Scheme_2_Stage", 2);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Ring = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
