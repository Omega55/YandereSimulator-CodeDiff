using System;
using UnityEngine;

public class DirectionalMicScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			Object.Destroy(base.gameObject);
		}
	}
}
