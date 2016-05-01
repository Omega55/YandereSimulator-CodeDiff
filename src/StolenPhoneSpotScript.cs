using System;
using UnityEngine;

[Serializable]
public class StolenPhoneSpotScript : MonoBehaviour
{
	public PromptScript Prompt;

	public GameObject RivalPhone;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			PlayerPrefs.SetInt("Scheme_4_Stage", 4);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.RivalPhone.transform.position = this.transform.position;
			this.RivalPhone.transform.eulerAngles = this.transform.eulerAngles;
			this.RivalPhone.active = true;
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
