using System;
using UnityEngine;

[Serializable]
public class CardboardBoxScript : MonoBehaviour
{
	public PromptScript Prompt;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.MyCollider.enabled = false;
			this.Prompt.Circle[0].fillAmount = (float)1;
			this.rigidbody.isKinematic = true;
			this.rigidbody.useGravity = false;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			this.transform.parent = this.Prompt.Yandere.Hips;
			this.transform.localPosition = new Vector3((float)0, -0.3f, 0.21f);
			this.transform.localEulerAngles = new Vector3(-13.333f, (float)0, (float)0);
		}
		if (this.transform.parent == this.Prompt.Yandere.Hips)
		{
			this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			if (!this.Prompt.Yandere.Crawling)
			{
				int num = 0;
				Vector3 eulerAngles = this.transform.eulerAngles;
				float num2 = eulerAngles.x = (float)num;
				Vector3 vector = this.transform.eulerAngles = eulerAngles;
			}
			if (Input.GetButtonDown("RB"))
			{
				this.Prompt.MyCollider.enabled = true;
				this.rigidbody.isKinematic = false;
				this.rigidbody.useGravity = true;
				this.transform.parent = null;
				this.Prompt.enabled = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
