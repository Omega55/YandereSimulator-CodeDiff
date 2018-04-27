using System;
using UnityEngine;

public class RestScript : MonoBehaviour
{
	public PortalScript Portal;

	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Prompt.Yandere.Chased)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
			}
			else
			{
				this.Portal.Reputation.PendingRep -= 10f;
				this.Portal.Reputation.UpdateRep();
				this.Portal.ClassDarkness.enabled = true;
				this.Portal.Clock.StopTime = true;
				this.Portal.Transition = true;
				this.Portal.FadeOut = true;
				this.Prompt.Yandere.Character.GetComponent<Animation>().CrossFade(this.Prompt.Yandere.IdleAnim);
				this.Prompt.Yandere.YandereVision = false;
				this.Prompt.Yandere.CanMove = false;
				this.Prompt.Yandere.Resting = true;
				this.Portal.EndEvents();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
	}
}
