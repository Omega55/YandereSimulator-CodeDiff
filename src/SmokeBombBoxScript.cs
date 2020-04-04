using System;
using UnityEngine;

public class SmokeBombBoxScript : MonoBehaviour
{
	public PromptScript Prompt;

	public AudioSource MyAudio;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.Inventory.SmokeBomb = true;
			this.MyAudio.Play();
		}
	}
}
