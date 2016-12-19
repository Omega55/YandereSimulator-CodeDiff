using System;
using UnityEngine;

[Serializable]
public class MetalDetectorScript : MonoBehaviour
{
	public MissionModeScript MissionMode;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Collider MyCollider;

	public virtual void Update()
	{
		if (this.Yandere.Armed)
		{
			if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 6)
			{
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == (float)0)
				{
					this.MyCollider.enabled = false;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.enabled = false;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	public virtual void OnTriggerStay(Collider other)
	{
		bool flag = false;
		if (this.MissionMode.GameOverID == 0 && other.gameObject.layer == 13)
		{
			if (this.Yandere.Weapon[1] != null && this.Yandere.Weapon[1].Metal)
			{
				flag = true;
			}
			if (this.Yandere.Weapon[2] != null && this.Yandere.Weapon[2].Metal)
			{
				flag = true;
			}
			if (this.Yandere.Weapon[3] != null && this.Yandere.Weapon[3].Metal)
			{
				flag = true;
			}
			if (flag)
			{
				this.MissionMode.GameOverID = 16;
				this.MissionMode.GameOver();
				this.MissionMode.Phase = 4;
				this.enabled = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
