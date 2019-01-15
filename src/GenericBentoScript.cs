using System;
using UnityEngine;

public class GenericBentoScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool Emetic;

	public bool Tranquil;

	public bool Headache;

	public bool Lethal;

	public bool Tampered;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Prompt.Yandere.Inventory.EmeticPoison)
			{
				this.Prompt.Yandere.Inventory.EmeticPoison = false;
			}
			else
			{
				this.Prompt.Yandere.Inventory.RatPoison = false;
			}
			this.Emetic = true;
			this.ShutOff();
		}
		else if (this.Prompt.Circle[1].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Tranquilizer = false;
			this.Tranquil = true;
			this.ShutOff();
		}
		else if (this.Prompt.Circle[2].fillAmount == 0f)
		{
			if (this.Prompt.Yandere.Inventory.LethalPoison)
			{
				this.Prompt.Yandere.Inventory.LethalPoison = false;
			}
			else
			{
				this.Prompt.Yandere.Inventory.ChemicalPoison = false;
			}
			this.Lethal = true;
			this.ShutOff();
		}
		else if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.HeadachePoison = false;
			this.Headache = true;
			this.ShutOff();
		}
	}

	private void ShutOff()
	{
		this.Prompt.Yandere.StudentManager.UpdateAllBentos();
		this.Tampered = true;
		base.enabled = false;
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	public void UpdatePrompts()
	{
		this.Prompt.HideButton[0] = true;
		this.Prompt.HideButton[1] = true;
		this.Prompt.HideButton[2] = true;
		this.Prompt.HideButton[3] = true;
		if (this.Prompt.Yandere.Inventory.EmeticPoison || this.Prompt.Yandere.Inventory.RatPoison)
		{
			this.Prompt.HideButton[0] = false;
		}
		if (this.Prompt.Yandere.Inventory.Tranquilizer)
		{
			this.Prompt.HideButton[1] = false;
		}
		if (this.Prompt.Yandere.Inventory.LethalPoison || this.Prompt.Yandere.Inventory.ChemicalPoison)
		{
			this.Prompt.HideButton[2] = false;
		}
		if (this.Prompt.Yandere.Inventory.HeadachePoison)
		{
			this.Prompt.HideButton[3] = false;
		}
	}
}
