using System;
using UnityEngine;

[Serializable]
public class YandereShoeLockerScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public int Label;

	public YandereShoeLockerScript()
	{
		this.Label = 1;
	}

	public virtual void Update()
	{
		if (this.Yandere.Schoolwear == 1)
		{
			if (this.Label == 2)
			{
				this.Prompt.Label[0].text = "     " + "Change Shoes";
				this.Label = 1;
			}
			if (this.Prompt.Circle[0].fillAmount == (float)0)
			{
				this.Prompt.Circle[0].fillAmount = (float)1;
				if (this.Yandere.Casual)
				{
					this.Yandere.Casual = false;
				}
				else
				{
					this.Yandere.Casual = true;
				}
				this.Yandere.ChangeSchoolwear();
				this.Yandere.CanMove = true;
			}
		}
		else
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (this.Label == 1)
			{
				this.Prompt.Label[0].text = "     " + "Not Available";
				this.Label = 2;
			}
		}
	}

	public virtual void Main()
	{
	}
}
