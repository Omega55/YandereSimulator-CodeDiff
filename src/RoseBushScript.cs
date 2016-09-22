using System;
using UnityEngine;

[Serializable]
public class RoseBushScript : MonoBehaviour
{
	public PromptScript Prompt;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Yandere.Inventory.Rose = true;
			this.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
