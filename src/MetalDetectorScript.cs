using System;
using UnityEngine;

public class MetalDetectorScript : MonoBehaviour
{
	public MissionModeScript MissionMode;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Collider MyCollider;

	private void Update()
	{
		if (this.Yandere.Armed)
		{
			if (this.Yandere.EquippedWeapon.WeaponID == 6)
			{
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					base.GetComponent<AudioSource>().Play();
					this.MyCollider.enabled = false;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					base.enabled = false;
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

	private void OnTriggerStay(Collider other)
	{
		bool flag = false;
		if (this.MissionMode.GameOverID == 0 && other.gameObject.layer == 13)
		{
			for (int i = 1; i < 4; i++)
			{
				WeaponScript weaponScript = this.Yandere.Weapon[i];
				flag |= (weaponScript != null && weaponScript.Metal);
			}
			if (flag)
			{
				this.MissionMode.GameOverID = 16;
				this.MissionMode.GameOver();
				this.MissionMode.Phase = 4;
				base.enabled = false;
			}
		}
	}
}
