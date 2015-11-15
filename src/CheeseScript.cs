using System;
using UnityEngine;

[Serializable]
public class CheeseScript : MonoBehaviour
{
	public PromptScript Prompt;

	public UILabel Subtitle;

	public float Timer;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Subtitle.text = "Knowing the mouse might one day leave its hole and get the cheese...It fills you with determination.";
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Timer = (float)5;
		}
		if (this.Timer > (float)0)
		{
			this.Timer -= Time.deltaTime;
			if (this.Timer <= (float)0)
			{
				this.Prompt.enabled = true;
				this.Subtitle.text = string.Empty;
			}
		}
	}

	public virtual void Main()
	{
	}
}
