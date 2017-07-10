using System;
using UnityEngine;

public class HidingSpotScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public PromptScript Prompt;

	public Transform Exit;

	public Transform Spot;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.MyController.center = new Vector3(this.Prompt.Yandere.MyController.center.x, 0.3f, this.Prompt.Yandere.MyController.center.z);
			this.Prompt.Yandere.MyController.height = 0.5f;
			this.Prompt.Yandere.HidingSpot = this.Spot;
			this.Prompt.Yandere.ExitSpot = this.Exit;
			this.Prompt.Yandere.CanMove = false;
			this.Prompt.Yandere.Hiding = true;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "Stop Hiding";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
		}
	}
}
