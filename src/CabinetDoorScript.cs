using System;
using UnityEngine;

public class CabinetDoorScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool Locked;

	public bool Open;

	private void Update()
	{
		if (this.Locked)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
		}
		else
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Yandere.TheftTimer = 0.1f;
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Open = !this.Open;
				this.UpdateLabel();
			}
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, (!this.Open) ? 0f : 0.41775f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
		}
	}

	private void UpdateLabel()
	{
		if (this.Open)
		{
			this.Prompt.Label[0].text = "     Close";
		}
		else
		{
			this.Prompt.Label[0].text = "     Open";
		}
	}
}
