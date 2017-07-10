using System;
using UnityEngine;

public class StolenPhoneSpotScript : MonoBehaviour
{
	public PromptScript Prompt;

	public GameObject RivalPhone;

	private void Update()
	{
		if (PlayerPrefs.GetInt("Scheme_4_Stage") == 3)
		{
			this.Prompt.enabled = true;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				PlayerPrefs.SetInt("Scheme_4_Stage", 4);
				this.Prompt.Yandere.SmartphoneRenderer.material.mainTexture = this.Prompt.Yandere.YanderePhoneTexture;
				this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.RivalPhone = false;
				this.Prompt.Yandere.RivalPhone = false;
				this.RivalPhone.transform.position = base.transform.position;
				this.RivalPhone.transform.eulerAngles = base.transform.eulerAngles;
				this.RivalPhone.SetActive(true);
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}
}
