using System;
using UnityEngine;

[Serializable]
public class SpyScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject SpyCamera;

	public Transform SpyTarget;

	public Transform SpySpot;

	public float Timer;

	public int Phase;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Yandere.Character.animation.CrossFade("f02_spying_00");
			this.Yandere.CanMove = false;
			this.Phase++;
		}
		if (this.Phase == 1)
		{
			Quaternion to = Quaternion.LookRotation(this.SpyTarget.transform.position - this.Yandere.transform.position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, to, Time.deltaTime * (float)10);
			this.Yandere.MoveTowardsTarget(this.SpySpot.position);
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)1)
			{
				this.PromptBar.Label[1].text = "Stop";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.Yandere.MainCamera.enabled = false;
				this.SpyCamera.active = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 2 && Input.GetButtonDown("B"))
		{
			this.End();
		}
	}

	public virtual void End()
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Yandere.MainCamera.enabled = true;
		this.Yandere.CanMove = true;
		this.SpyCamera.active = false;
		this.Timer = (float)0;
		this.Phase = 0;
	}

	public virtual void Main()
	{
	}
}
