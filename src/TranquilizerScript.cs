using System;
using UnityEngine;

public class TranquilizerScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Tranquilizer = true;
			this.Prompt.Yandere.StudentManager.UpdateAllBentos();
			this.Prompt.Yandere.TheftTimer = 0.1f;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
