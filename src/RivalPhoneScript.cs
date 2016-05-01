using System;
using UnityEngine;

[Serializable]
public class RivalPhoneScript : MonoBehaviour
{
	public PromptScript Prompt;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			PlayerPrefs.SetInt("Scheme_4_Stage", 2);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.RivalPhone = true;
			this.Prompt.enabled = false;
			this.enabled = false;
			this.active = false;
		}
	}

	public virtual void Main()
	{
	}
}
