using System;
using UnityEngine;

[Serializable]
public class TranquilizerScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Yandere.PossessTranq = true;
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
