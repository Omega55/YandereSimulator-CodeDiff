using System;
using UnityEngine;

[Serializable]
public class PoisonScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject Bottle;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("ChemistryGrade") + PlayerPrefs.GetInt("ChemistryBonus") < 1)
		{
			this.gameObject.active = false;
		}
		else
		{
			this.gameObject.active = true;
		}
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Yandere.PossessPoison = true;
			UnityEngine.Object.Destroy(this.gameObject);
			UnityEngine.Object.Destroy(this.Bottle);
		}
	}

	public virtual void Main()
	{
	}
}
