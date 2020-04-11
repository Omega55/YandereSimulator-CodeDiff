using System;
using UnityEngine;

public class MaskingTapeScript : MonoBehaviour
{
	public CarryableCardboardBoxScript Box;

	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.MaskingTape = true;
			this.Box.Prompt.enabled = true;
			this.Box.enabled = true;
			Object.Destroy(base.gameObject);
		}
	}
}
