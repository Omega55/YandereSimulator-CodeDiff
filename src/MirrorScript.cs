using System;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
	public PromptScript Prompt;

	public string[] Idles;

	public int ID;

	public int Limit;

	private void Start()
	{
		this.Limit = this.Idles.Length - 1;
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.ID++;
			if (this.ID == this.Limit)
			{
				this.ID = 0;
			}
			if (!this.Prompt.Yandere.Carrying)
			{
				this.Prompt.Yandere.IdleAnim = this.Idles[this.ID];
			}
			this.Prompt.Yandere.OriginalIdleAnim = this.Idles[this.ID];
		}
	}
}
