using System;
using UnityEngine;

public class RivalBagScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public PromptScript Prompt;

	private void Update()
	{
		if (this.Clock.Period == 2 || this.Clock.Period == 4)
		{
			this.Prompt.HideButton[0] = true;
		}
		else if (this.Prompt.Yandere.Inventory.Cigs)
		{
			this.Prompt.HideButton[0] = false;
		}
		else
		{
			this.Prompt.HideButton[0] = true;
		}
		if (SchemeGlobals.GetSchemeStage(3) == 3 && this.Prompt.Circle[0].fillAmount == 0f)
		{
			SchemeGlobals.SetSchemeStage(3, 4);
			this.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Cigs = false;
			this.Prompt.HideButton[0] = true;
			base.enabled = false;
		}
		if (this.Clock.Period == 2 || this.Clock.Period == 4)
		{
			this.Prompt.HideButton[1] = true;
		}
		else if (this.Prompt.Yandere.Inventory.Ring)
		{
			this.Prompt.HideButton[1] = false;
		}
		else
		{
			this.Prompt.HideButton[1] = true;
		}
		if (SchemeGlobals.GetSchemeStage(2) == 2 && this.Prompt.Circle[1].fillAmount == 0f)
		{
			SchemeGlobals.SetSchemeStage(2, 3);
			this.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Ring = false;
			this.Prompt.HideButton[1] = true;
			base.enabled = false;
		}
	}
}
