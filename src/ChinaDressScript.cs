using System;
using UnityEngine;

public class ChinaDressScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.WearChinaDress();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}
}
