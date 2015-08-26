using System;
using UnityEngine;

[Serializable]
public class ShowerStoolScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform StoolSpot;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Update()
	{
		if (this.Yandere.Schoolwear > 0 || this.Yandere.PickUp != null || this.Yandere.Dragging)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		else
		{
			this.Prompt.enabled = true;
			if (this.Prompt.Circle[0].fillAmount <= (float)0)
			{
				this.Yandere.Stool = this.StoolSpot;
				this.Yandere.CanMove = false;
				this.Yandere.Bathing = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
