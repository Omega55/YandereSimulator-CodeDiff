using System;
using UnityEngine;

[Serializable]
public class LeaveGiftScript : MonoBehaviour
{
	public PromptScript Prompt;

	public GameObject Box;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Box.active = true;
			this.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
