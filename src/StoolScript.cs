using System;
using UnityEngine;

[Serializable]
public class StoolScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Update()
	{
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.Bucket != null)
			{
				if (this.Yandere.PickUp.Bucket.Full)
				{
					if (!this.Prompt.enabled)
					{
						this.Prompt.enabled = true;
					}
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.Stool = this.transform;
			this.Yandere.CanMove = false;
			this.Yandere.Pouring = true;
		}
	}

	public virtual void Main()
	{
	}
}
