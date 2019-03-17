using System;
using UnityEngine;

public class IDCardScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.StolenObject = base.gameObject;
			this.Prompt.Yandere.Inventory.IDCard = true;
			this.Prompt.Yandere.TheftTimer = 1f;
			this.Prompt.Hide();
			base.gameObject.SetActive(false);
		}
	}
}
