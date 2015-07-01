using System;
using UnityEngine;

[Serializable]
public class LightSwitchScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject BathroomLight;

	public Rigidbody Panel;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Update()
	{
		if (!this.Panel.useGravity)
		{
			if (this.Yandere.Armed)
			{
				if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 6)
				{
					this.Prompt.HideButton[3] = false;
				}
				else
				{
					this.Prompt.HideButton[3] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[3] = true;
			}
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (this.BathroomLight.active)
			{
				this.Prompt.Label[0].text = "     " + "Turn On";
				this.BathroomLight.active = false;
			}
			else
			{
				this.Prompt.Label[0].text = "     " + "Turn Off";
				this.BathroomLight.active = true;
			}
		}
		if (this.Prompt.Circle[3].fillAmount <= (float)0)
		{
			this.Prompt.HideButton[3] = true;
			this.Panel.useGravity = true;
			this.Panel.AddForce((float)0, (float)0, (float)10);
		}
	}

	public virtual void Main()
	{
	}
}
