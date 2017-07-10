using System;
using UnityEngine;

public class KnifeDetectorScript : MonoBehaviour
{
	public BlowtorchScript[] Blowtorches;

	public Transform HeatingSpot;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public float Timer;

	private void Start()
	{
		this.Disable();
	}

	private void Update()
	{
		if (!this.Blowtorches[1].GetComponent<Rigidbody>().useGravity || !this.Blowtorches[2].GetComponent<Rigidbody>().useGravity || !this.Blowtorches[3].GetComponent<Rigidbody>().useGravity)
		{
			base.enabled = false;
		}
		if (this.Yandere.Armed)
		{
			if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 8)
			{
				this.Prompt.MyCollider.enabled = true;
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_heating_00");
					this.Yandere.CanMove = false;
					this.Timer = 5f;
					this.Blowtorches[1].enabled = true;
					this.Blowtorches[2].enabled = true;
					this.Blowtorches[3].enabled = true;
					this.Blowtorches[1].GetComponent<AudioSource>().Play();
					this.Blowtorches[2].GetComponent<AudioSource>().Play();
					this.Blowtorches[3].GetComponent<AudioSource>().Play();
				}
			}
			else
			{
				this.Disable();
			}
		}
		else
		{
			this.Disable();
		}
		if (this.Timer > 0f)
		{
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.HeatingSpot.rotation, Time.deltaTime * 10f);
			this.Yandere.MoveTowardsTarget(this.HeatingSpot.position);
			WeaponScript weaponScript = this.Yandere.Weapon[this.Yandere.Equipped];
			Material material = weaponScript.MyRenderer.material;
			material.color = new Color(material.color.r, Mathf.MoveTowards(material.color.g, 0.5f, Time.deltaTime * 0.2f), Mathf.MoveTowards(material.color.b, 0.5f, Time.deltaTime * 0.2f), material.color.a);
			this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
			if (this.Timer == 0f)
			{
				weaponScript.Heated = true;
				base.enabled = false;
				this.Disable();
			}
		}
	}

	private void Disable()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
	}
}
