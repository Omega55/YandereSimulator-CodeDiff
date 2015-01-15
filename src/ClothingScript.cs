using System;
using UnityEngine;

[Serializable]
public class ClothingScript : MonoBehaviour
{
	public PromptScript Prompt;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Yandere.Bloodiness = (float)0;
			this.Prompt.Yandere.UpdateBlood();
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
