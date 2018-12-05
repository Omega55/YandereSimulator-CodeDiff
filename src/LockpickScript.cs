using System;
using UnityEngine;

public class LockpickScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			InventoryScript inventory = this.Prompt.Yandere.Inventory;
			inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
