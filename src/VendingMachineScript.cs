using System;
using UnityEngine;

public class VendingMachineScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Transform CanSpawn;

	public GameObject[] Cans;

	public bool SnackMachine;

	public bool Sabotaged;

	private void Start()
	{
		if (this.SnackMachine)
		{
			this.Prompt.Text[0] = "Buy Snack for $1.00";
		}
		else
		{
			this.Prompt.Text[0] = "Buy Drink for $1.00";
		}
		this.Prompt.Label[0].text = "     " + this.Prompt.Text[0];
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (PlayerGlobals.Money >= 1f)
			{
				if (!this.Sabotaged)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Cans[UnityEngine.Random.Range(0, this.Cans.Length)], this.CanSpawn.position, this.CanSpawn.rotation);
					gameObject.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.9f, 1.1f);
				}
				if (this.SnackMachine && SchemeGlobals.GetSchemeStage(4) == 3)
				{
					SchemeGlobals.SetSchemeStage(4, 4);
					this.Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
				}
				PlayerGlobals.Money -= 1f;
				this.Prompt.Yandere.Inventory.UpdateMoney();
			}
		}
	}
}
