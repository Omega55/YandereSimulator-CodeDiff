using System;
using UnityEngine;

public class HidingSpotScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public PromptScript Prompt;

	public Transform Exit;

	public Transform Spot;

	public string AnimName;

	private void Update()
	{
		if (this.Prompt.Yandere.Chased || this.Prompt.Yandere.StudentManager.PinningDown)
		{
			if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (!this.Prompt.enabled)
		{
			this.Prompt.enabled = true;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.MyController.center = new Vector3(this.Prompt.Yandere.MyController.center.x, 0.3f, this.Prompt.Yandere.MyController.center.z);
			this.Prompt.Yandere.MyController.radius = 0f;
			this.Prompt.Yandere.MyController.height = 0.5f;
			this.Prompt.Yandere.HideAnim = this.AnimName;
			this.Prompt.Yandere.HidingSpot = this.Spot;
			this.Prompt.Yandere.ExitSpot = this.Exit;
			this.Prompt.Yandere.CanMove = false;
			this.Prompt.Yandere.Hiding = true;
			this.Prompt.Yandere.EmptyHands();
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "Stop";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
		}
	}
}
