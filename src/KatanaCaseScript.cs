using System;
using UnityEngine;

[Serializable]
public class KatanaCaseScript : MonoBehaviour
{
	public PromptScript CasePrompt;

	public PromptScript KeyPrompt;

	public Transform Door;

	public GameObject Key;

	public float Rotation;

	public bool Open;

	public virtual void Start()
	{
		this.CasePrompt.enabled = false;
	}

	public virtual void Update()
	{
		if (this.Key.active && this.KeyPrompt.Circle[0].fillAmount == (float)0)
		{
			this.KeyPrompt.Yandere.Inventory.CaseKey = true;
			this.CasePrompt.enabled = true;
			this.Key.active = false;
		}
		if (this.CasePrompt.Circle[0].fillAmount == (float)0)
		{
			this.KeyPrompt.Yandere.Inventory.CaseKey = false;
			this.Open = true;
			this.CasePrompt.Hide();
			this.CasePrompt.enabled = false;
		}
		if (this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, (float)-180, Time.deltaTime * (float)10);
			float rotation = this.Rotation;
			Vector3 eulerAngles = this.Door.eulerAngles;
			float num = eulerAngles.z = rotation;
			Vector3 vector = this.Door.eulerAngles = eulerAngles;
			if (this.Rotation < -179.9f)
			{
				this.enabled = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
