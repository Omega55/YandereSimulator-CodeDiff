using System;
using UnityEngine;

[Serializable]
public class HeadsetScript : MonoBehaviour
{
	public PromptScript Prompt;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			PlayerPrefs.SetInt("Headset", 1);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
