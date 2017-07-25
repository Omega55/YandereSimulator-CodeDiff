using System;
using UnityEngine;

public class RivalBagScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Yandere.Inventory.Cigs)
		{
			this.Prompt.HideButton[0] = false;
		}
		if (this.Prompt.Yandere.Inventory.Ring)
		{
			this.Prompt.HideButton[1] = false;
		}
		if (PlayerPrefs.GetInt("Scheme_3_Stage") == 3)
		{
			this.Prompt.HideButton[0] = (this.Clock.Period == 2 || this.Clock.Period == 4);
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				PlayerPrefs.SetInt("Scheme_3_Stage", 4);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.Cigs = false;
				this.Prompt.HideButton[0] = true;
				base.enabled = false;
			}
		}
		if (PlayerPrefs.GetInt("Scheme_2_Stage") == 2)
		{
			this.Prompt.HideButton[1] = (this.Clock.Period == 2 || this.Clock.Period == 4);
			if (this.Prompt.Circle[1].fillAmount == 0f)
			{
				PlayerPrefs.SetInt("Scheme_2_Stage", 3);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.Ring = false;
				this.Prompt.HideButton[1] = true;
				base.enabled = false;
			}
		}
	}
}
