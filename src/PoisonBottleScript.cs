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
			this.Prompt.Yandere.TheftTimer = 0.1f;
			if (this.ID == 1)
			{
				this.Prompt.Yandere.Inventory.EmeticPoison = true;
			}
			else if (this.ID == 2)
			{
				this.Prompt.Yandere.Inventory.LethalPoison = true;
			}
			else if (this.ID == 3)
			{
				this.Prompt.Yandere.Inventory.RatPoison = true;
			}
			else if (this.ID == 4)
			{
				this.Prompt.Yandere.Inventory.HeadachePoison = true;
			}
			else if (this.ID == 5)
			{
				this.Prompt.Yandere.Inventory.Tranquilizer = true;
			}
			else if (this.ID == 6)
			{
				this.Prompt.Yandere.Inventory.Sedative = true;
			}
			this.Prompt.Yandere.StudentManager.UpdateAllBentos();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
