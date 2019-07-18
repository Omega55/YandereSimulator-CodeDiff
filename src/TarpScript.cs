using System;
using UnityEngine;

public class TarpScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool Unwrap;

	public float PreviousSpeed;

	public float Speed;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Unwrap = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Unwrap)
		{
			this.Speed += Time.deltaTime;
			base.transform.localEulerAngles = Vector3.Lerp(base.transform.localEulerAngles, new Vector3(90f, 0f, 0f), Time.deltaTime * this.Speed);
			if (base.transform.localEulerAngles.x > 45f)
			{
				if (this.PreviousSpeed == 0f)
				{
					this.PreviousSpeed = this.Speed;
				}
				this.Speed += Time.deltaTime;
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(-1f, 1f, 0.0001f), (this.Speed - this.PreviousSpeed) * Time.deltaTime);
			}
		}
	}
}
