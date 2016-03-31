using System;
using UnityEngine;

[Serializable]
public class HidingSpotScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public PromptScript Prompt;

	public Transform Exit;

	public Transform Spot;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			float y = 0.3f;
			Vector3 center = this.Prompt.Yandere.MyController.center;
			float num = center.y = y;
			Vector3 vector = this.Prompt.Yandere.MyController.center = center;
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

	public virtual void Main()
	{
	}
}
