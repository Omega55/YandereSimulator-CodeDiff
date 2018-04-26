using System;
using UnityEngine;

public class TranquilizerScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Inventory.Tranquilizer = true;
			this.Yandere.TheftTimer = 0.1f;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
