using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RivalBagScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public PromptScript Prompt;

	public virtual void Update()
	{
		if (PlayerPrefs.GetInt("Scheme_3_Stage") == 3)
		{
			if (!RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.Clock, "Phase"), 2) && !RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.Clock, "Phase"), 4))
			{
				this.Prompt.HideButton[0] = false;
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
			if (this.Prompt.Circle[0].fillAmount == (float)0)
			{
				PlayerPrefs.SetInt("Scheme_3_Stage", 4);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.Cigs = false;
				this.Prompt.HideButton[0] = true;
			}
		}
		if (PlayerPrefs.GetInt("Scheme_2_Stage") == 2)
		{
			if (!RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.Clock, "Phase"), 2) && !RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.Clock, "Phase"), 4))
			{
				this.Prompt.HideButton[1] = false;
			}
			else
			{
				this.Prompt.HideButton[1] = true;
			}
			if (this.Prompt.Circle[1].fillAmount == (float)0)
			{
				PlayerPrefs.SetInt("Scheme_2_Stage", 3);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.Ring = false;
				this.Prompt.HideButton[1] = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
