using System;
using UnityEngine;

[Serializable]
public class SafeScript : MonoBehaviour
{
	public MissionModeScript MissionMode;

	public PromptScript ContentsPrompt;

	public PromptScript SafePrompt;

	public PromptScript KeyPrompt;

	public Transform Door;

	public GameObject Key;

	public float Rotation;

	public bool Open;

	public virtual void Start()
	{
		this.ContentsPrompt.MyCollider.enabled = false;
		this.SafePrompt.enabled = false;
	}

	public virtual void Update()
	{
		if (this.Key.active && this.KeyPrompt.Circle[0].fillAmount == (float)0)
		{
			this.KeyPrompt.Yandere.Inventory.SafeKey = true;
			this.SafePrompt.enabled = true;
			this.Key.active = false;
		}
		if (this.SafePrompt.Circle[0].fillAmount == (float)0)
		{
			this.KeyPrompt.Yandere.Inventory.SafeKey = false;
			this.ContentsPrompt.MyCollider.enabled = true;
			this.Open = true;
			this.SafePrompt.Hide();
			this.SafePrompt.enabled = false;
		}
		if (this.ContentsPrompt.Circle[0].fillAmount == (float)0)
		{
			this.MissionMode.DocumentsStolen = true;
			this.enabled = false;
			this.ContentsPrompt.Hide();
			this.ContentsPrompt.enabled = false;
			this.ContentsPrompt.gameObject.active = false;
		}
		if (this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)10);
			float rotation = this.Rotation;
			Vector3 localEulerAngles = this.Door.localEulerAngles;
			float num = localEulerAngles.y = rotation;
			Vector3 vector = this.Door.localEulerAngles = localEulerAngles;
			if (this.Rotation < (float)1)
			{
				this.Open = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
