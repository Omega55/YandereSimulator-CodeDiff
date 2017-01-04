using System;
using UnityEngine;

[Serializable]
public class BentoScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public Transform PoisonSpot;

	public PromptScript Prompt;

	public int Poison;

	public int ID;

	public virtual void Update()
	{
		if (!this.Prompt.Yandere.Inventory.EmeticPoison && !this.Prompt.Yandere.Inventory.RatPoison)
		{
			this.Prompt.HideButton[0] = true;
		}
		else
		{
			this.Prompt.HideButton[0] = false;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			if (this.Prompt.Yandere.Inventory.EmeticPoison)
			{
				this.Prompt.Yandere.Inventory.EmeticPoison = false;
				this.Prompt.Yandere.PoisonType = 1;
			}
			else
			{
				this.Prompt.Yandere.Inventory.RatPoison = false;
				this.Prompt.Yandere.PoisonType = 3;
			}
			this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
			this.Prompt.Yandere.PoisonSpot = this.PoisonSpot;
			this.Prompt.Yandere.Poisoning = true;
			this.Prompt.Yandere.CanMove = false;
			this.enabled = false;
			this.Poison = 1;
			if (this.ID != 1)
			{
				this.StudentManager.Students[this.ID].Emetic = true;
			}
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.ID == 33)
		{
			if (this.Prompt.Yandere.Inventory.LethalPoison)
			{
				this.Prompt.HideButton[1] = false;
			}
			else
			{
				this.Prompt.HideButton[1] = true;
			}
			if (this.Prompt.Circle[1].fillAmount == (float)0)
			{
				this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
				this.Prompt.Yandere.Inventory.LethalPoison = false;
				this.StudentManager.Students[this.ID].Lethal = true;
				this.Prompt.Yandere.PoisonSpot = this.PoisonSpot;
				this.Prompt.Yandere.Poisoning = true;
				this.Prompt.Yandere.CanMove = false;
				this.Prompt.Yandere.PoisonType = 2;
				this.enabled = false;
				this.Poison = 2;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
