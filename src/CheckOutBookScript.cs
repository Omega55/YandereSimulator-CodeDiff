using System;
using UnityEngine;

public class CheckOutBookScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Book = true;
			this.UpdatePrompt();
		}
	}

	public void UpdatePrompt()
	{
		if (this.Prompt.Yandere.Inventory.Book)
		{
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
		else
		{
			this.Prompt.enabled = true;
			this.Prompt.Hide();
		}
	}
}
