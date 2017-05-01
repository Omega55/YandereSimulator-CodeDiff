using System;
using UnityEngine;

[Serializable]
public class AccessoryScript : MonoBehaviour
{
	public PromptScript Prompt;

	public float X;

	public float Y;

	public float Z;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.transform.parent = this.Prompt.Yandere.Spine[3];
			this.transform.localPosition = new Vector3(this.X, this.Y, this.Z);
			this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
