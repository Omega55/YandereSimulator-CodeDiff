using System;
using UnityEngine;

public class MoneyWadScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Money += 100f;
			this.Prompt.Yandere.Inventory.UpdateMoney();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
