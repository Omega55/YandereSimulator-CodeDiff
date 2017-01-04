using System;
using UnityEngine;

[Serializable]
public class PoisonBottleScript : MonoBehaviour
{
	public PromptScript Prompt;

	public int ID;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
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
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
