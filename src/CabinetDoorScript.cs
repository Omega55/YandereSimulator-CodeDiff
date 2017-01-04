using System;
using UnityEngine;

[Serializable]
public class CabinetDoorScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool Locked;

	public bool Open;

	public virtual void Update()
	{
		if (this.Locked)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
		}
		else
		{
			if (this.Prompt.Circle[0].fillAmount == (float)0)
			{
				this.Prompt.Circle[0].fillAmount = (float)1;
				if (!this.Open)
				{
					this.Open = true;
				}
				else
				{
					this.Open = false;
				}
			}
			if (this.Open)
			{
				float x = Mathf.Lerp(this.transform.localPosition.x, 0.41775f, Time.deltaTime * (float)10);
				Vector3 localPosition = this.transform.localPosition;
				float num = localPosition.x = x;
				Vector3 vector = this.transform.localPosition = localPosition;
			}
			else
			{
				float x2 = Mathf.Lerp(this.transform.localPosition.x, (float)0, Time.deltaTime * (float)10);
				Vector3 localPosition2 = this.transform.localPosition;
				float num2 = localPosition2.x = x2;
				Vector3 vector2 = this.transform.localPosition = localPosition2;
			}
		}
	}

	public virtual void Main()
	{
	}
}
