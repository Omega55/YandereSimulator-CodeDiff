using System;
using UnityEngine;

public class RivalBagScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public PromptScript Prompt;

	private void Update()
	{
		if (PlayerPrefs.GetInt("Scheme_3_Stage") == 3 && this.Prompt.Circle[0].fillAmount == 0f)
		{
			PlayerPrefs.SetInt("Scheme_3_Stage", 4);
			this.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Cigs = false;
			this.Prompt.HideButton[0] = true;
		}
		if (PlayerPrefs.GetInt("Scheme_2_Stage") == 2 && this.Prompt.Circle[1].fillAmount == 0f)
		{
			PlayerPrefs.SetInt("Scheme_2_Stage", 3);
			this.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Ring = false;
			this.Prompt.HideButton[1] = true;
		}
	}
}
