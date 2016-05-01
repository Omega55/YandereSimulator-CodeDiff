using System;
using UnityEngine;

[Serializable]
public class RivalDeskScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public PromptScript Prompt;

	public bool Cheating;

	public virtual void Update()
	{
		if (PlayerPrefs.GetInt("Scheme_5_Stage") == 5 && PlayerPrefs.GetInt("Weekday") == 5)
		{
			if (this.Clock.HourTime > (float)13)
			{
				this.Prompt.HideButton[0] = false;
				if (this.Clock.HourTime > 13.5f)
				{
					PlayerPrefs.SetInt("Scheme_5_Stage", 100);
					this.Schemes.UpdateInstructions();
					this.Prompt.HideButton[0] = true;
				}
			}
			if (this.Prompt.Circle[0].fillAmount == (float)0)
			{
				PlayerPrefs.SetInt("Scheme_5_Stage", 6);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.DuplicateSheet = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Cheating = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
