using System;
using UnityEngine;

[Serializable]
public class PianoScript : MonoBehaviour
{
	public PromptScript Prompt;

	public AudioClip[] Notes;

	public int ID;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount < (float)1 && this.Prompt.Circle[0].fillAmount > (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)0;
			this.ID++;
			if (this.ID == this.Notes.Length)
			{
				this.ID = 1;
			}
			this.audio.clip = this.Notes[this.ID];
			this.audio.Play();
		}
	}

	public virtual void Main()
	{
	}
}
