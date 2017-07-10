using System;
using UnityEngine;

public class LeaveGiftScript : MonoBehaviour
{
	public PromptScript Prompt;

	public GameObject Box;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Box.SetActive(true);
			base.enabled = false;
		}
	}
}
