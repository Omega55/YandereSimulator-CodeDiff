using System;
using UnityEngine;

[Serializable]
public class PianoScript : MonoBehaviour
{
	public PromptScript Prompt;

	public AudioSource[] Notes;

	public int ID;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount < (float)1 && this.Prompt.Circle[0].fillAmount > (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)0;
			this.Notes[this.ID].Play();
			this.ID++;
			if (this.ID == this.Notes.Length)
			{
				this.ID = 0;
			}
		}
	}

	public virtual void Main()
	{
	}
}
