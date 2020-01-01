using System;
using UnityEngine;

public class BentoScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public Transform PoisonSpot;

	public PromptScript Prompt;

	public int Poison;

	public int ID;

	private void Start()
	{
		if (this.Prompt.Yandere != null)
		{
			this.Yandere = this.Prompt.Yandere;
		}
	}

	private void Update()
	{
		if (this.Yandere == null)
		{
			if (this.Prompt.Yandere != null)
			{
				this.Yandere = this.Prompt.Yandere;
			}
		}
		else if (this.Yandere.Inventory.EmeticPoison || this.Yandere.Inventory.RatPoison || this.Yandere.Inventory.LethalPoison)
		{
			this.Prompt.enabled = true;
			if (!this.Yandere.Inventory.EmeticPoison && !this.Yandere.Inventory.RatPoison)
			{
				this.Prompt.HideButton[0] = true;
			}
			else
			{
				this.Prompt.HideButton[0] = false;
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				if (this.Yandere.Inventory.EmeticPoison)
				{
					this.Yandere.Inventory.EmeticPoison = false;
					this.Yandere.PoisonType = 1;
				}
				else
				{
					this.Yandere.Inventory.RatPoison = false;
					this.Yandere.PoisonType = 3;
				}
				this.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
				this.Yandere.PoisonSpot = this.PoisonSpot;
				this.Yandere.Poisoning = true;
				this.Yandere.CanMove = false;
				base.enabled = false;
				this.Poison = 1;
				if (this.ID != 1)
				{
					this.StudentManager.Students[this.ID].Emetic = true;
				}
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			if (this.ID == 11 || this.ID == 6)
			{
				this.Prompt.HideButton[1] = !this.Prompt.Yandere.Inventory.LethalPoison;
				if (this.Prompt.Circle[1].fillAmount == 0f)
				{
					this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
					this.Prompt.Yandere.Inventory.LethalPoison = false;
					this.StudentManager.Students[this.ID].Lethal = true;
					this.Prompt.Yandere.PoisonSpot = this.PoisonSpot;
					this.Prompt.Yandere.Poisoning = true;
					this.Prompt.Yandere.CanMove = false;
					this.Prompt.Yandere.PoisonType = 2;
					base.enabled = false;
					this.Poison = 2;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
		}
		else
		{
			this.Prompt.enabled = false;
		}
	}
}
