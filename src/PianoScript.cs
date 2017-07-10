using System;
using UnityEngine;

public class PianoScript : MonoBehaviour
{
	public PromptScript Prompt;

	public AudioSource[] Notes;

	public int ID;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount < 1f && this.Prompt.Circle[0].fillAmount > 0f)
		{
			this.Prompt.Circle[0].fillAmount = 0f;
			this.Notes[this.ID].Play();
			this.ID++;
			if (this.ID == this.Notes.Length)
			{
				this.ID = 0;
			}
		}
	}
}
