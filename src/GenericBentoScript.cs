using System;
using UnityEngine;

public class GenericBentoScript : MonoBehaviour
{
	public GameObject EmptyGameObject;

	public Transform PoisonSpot;

	public PromptScript Prompt;

	public bool Emetic;

	public bool Tranquil;

	public bool Headache;

	public bool Lethal;

	public bool Tampered;

	public int StudentID;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
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
			this.Emetic = true;
			this.ShutOff();
			return;
		}
		if (this.Prompt.Circle[1].fillAmount == 0f)
		{
			if (this.Prompt.Yandere.Inventory.Sedative)
			{
				this.Prompt.Yandere.Inventory.Sedative = false;
			}
			else
			{
				this.Prompt.Yandere.Inventory.Tranquilizer = false;
			}
			this.Prompt.Yandere.PoisonType = 4;
			this.Tranquil = true;
			this.ShutOff();
			return;
		}
		if (this.Prompt.Circle[2].fillAmount == 0f)
		{
			if (this.Prompt.Yandere.Inventory.LethalPoison)
			{
				this.Prompt.Yandere.Inventory.LethalPoison = false;
				this.Prompt.Yandere.PoisonType = 2;
			}
			else
			{
				this.Prompt.Yandere.Inventory.ChemicalPoison = false;
				this.Prompt.Yandere.PoisonType = 2;
			}
			this.Lethal = true;
			this.ShutOff();
			return;
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.HeadachePoison = false;
			this.Prompt.Yandere.PoisonType = 5;
			this.Headache = true;
			this.ShutOff();
		}
	}

	private void ShutOff()
	{
		GameObject gameObject = Object.Instantiate<GameObject>(this.EmptyGameObject, base.transform.position, Quaternion.identity);
		this.PoisonSpot = gameObject.transform;
		this.PoisonSpot.position = new Vector3(this.PoisonSpot.position.x, this.Prompt.Yandere.transform.position.y, this.PoisonSpot.position.z);
		this.PoisonSpot.LookAt(this.Prompt.Yandere.transform.position);
		this.PoisonSpot.Translate(Vector3.forward * 0.25f);
		this.Prompt.Yandere.CharacterAnimation["f02_poisoning_00"].speed = 2f;
		this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
		this.Prompt.Yandere.StudentManager.UpdateAllBentos();
		this.Prompt.Yandere.TargetBento = this;
		this.Prompt.Yandere.Poisoning = true;
		this.Prompt.Yandere.CanMove = false;
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
		if (this.Prompt.Yandere.Inventory.Tranquilizer || this.Prompt.Yandere.Inventory.Sedative)
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
