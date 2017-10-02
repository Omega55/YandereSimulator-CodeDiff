using System;
using UnityEngine;

public class RivalDeskScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public PromptScript Prompt;

	public bool Cheating;

	private void Update()
	{
		if (SchemeGlobals.GetSchemeStage(5) == 5 && DateGlobals.Weekday == DayOfWeek.Friday)
		{
			if (this.Clock.HourTime > 13f)
			{
				this.Prompt.HideButton[0] = false;
				if (this.Clock.HourTime > 13.5f)
				{
					SchemeGlobals.SetSchemeStage(5, 100);
					this.Schemes.UpdateInstructions();
					this.Prompt.HideButton[0] = true;
				}
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				SchemeGlobals.SetSchemeStage(5, 6);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.DuplicateSheet = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Cheating = true;
			}
		}
	}
}
