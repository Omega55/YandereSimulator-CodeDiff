using System;
using UnityEngine;

public class LeaveGiftScript : MonoBehaviour
{
	public EndOfDayScript EndOfDay;

	public PromptScript Prompt;

	public GameObject Box;

	private void Start()
	{
		this.Box.SetActive(false);
		this.EndOfDay.SenpaiGifts = CollectibleGlobals.SenpaiGifts;
		if (this.EndOfDay.SenpaiGifts == 0)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	private void Update()
	{
		Debug.Log(Vector3.Distance(this.Prompt.Yandere.transform.position, this.Prompt.Yandere.Senpai.position));
		if (this.Prompt.InView)
		{
			if (Vector3.Distance(this.Prompt.Yandere.transform.position, this.Prompt.Yandere.Senpai.position) > 10f)
			{
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.EndOfDay.SenpaiGifts--;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Box.SetActive(true);
					base.enabled = false;
					return;
				}
			}
			else
			{
				this.Prompt.Hide();
			}
		}
	}
}
