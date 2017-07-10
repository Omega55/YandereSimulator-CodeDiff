using System;
using UnityEngine;

public class AccessoryScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Transform Target;

	public float X;

	public float Y;

	public float Z;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Prompt.MyCollider.enabled = false;
			base.transform.parent = this.Target;
			base.transform.localPosition = new Vector3(this.X, this.Y, this.Z);
			base.transform.localEulerAngles = Vector3.zero;
			base.enabled = false;
		}
	}
}
