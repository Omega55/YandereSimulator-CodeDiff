using System;
using UnityEngine;

public class PoisonScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject Bottle;

	public void Start()
	{
		base.gameObject.SetActive(Globals.ChemistryGrade + Globals.ChemistryBonus >= 1);
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.PossessPoison = true;
			UnityEngine.Object.Destroy(base.gameObject);
			UnityEngine.Object.Destroy(this.Bottle);
		}
	}
}
