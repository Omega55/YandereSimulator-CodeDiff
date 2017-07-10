using System;
using UnityEngine;

public class ShowerStoolScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform StoolSpot;

	public ParticleSystem Water;

	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	private void Update()
	{
		if (this.Yandere.Schoolwear > 0 || this.Yandere.PickUp != null || this.Yandere.Dragging)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		else
		{
			this.Prompt.enabled = true;
			if (this.Prompt.Circle[0].fillAmount <= 0f)
			{
				this.Yandere.EmptyHands();
				this.Yandere.Stool = this.StoolSpot;
				this.Yandere.CanMove = false;
				this.Yandere.Bathing = true;
				this.Water.Play();
			}
		}
	}
}
