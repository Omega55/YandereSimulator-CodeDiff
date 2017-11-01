using System;
using UnityEngine;

public class PoisonBottleScript : MonoBehaviour
{
	public PromptScript Prompt;

	public int ID;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.TheftTimer = 1f;
			InventoryScript inventory = this.Prompt.Yandere.Inventory;
			if (this.ID == 1)
			{
				inventory.EmeticPoison = true;
			}
			else if (this.ID == 2)
			{
				inventory.LethalPoison = true;
			}
			else if (this.ID == 3)
			{
				inventory.RatPoison = true;
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
