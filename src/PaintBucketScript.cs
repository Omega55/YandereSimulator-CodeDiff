using System;
using UnityEngine;

public class PaintBucketScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Yandere.Bloodiness == 0f)
			{
				this.Prompt.Yandere.Bloodiness += 100f;
				this.Prompt.Yandere.RedPaint = true;
			}
		}
	}
}
