using System;
using UnityEngine;

public class YandereShoverScript : MonoBehaviour
{
	public YandereScript Yandere;

	public bool PreventNudity;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			bool flag = false;
			if (this.PreventNudity)
			{
				if (this.Yandere.Schoolwear == 0)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				this.Yandere.CharacterAnimation["f02_shoveA_01"].time = 0f;
				this.Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
				this.Yandere.YandereVision = false;
				this.Yandere.NearSenpai = false;
				this.Yandere.Degloving = false;
				this.Yandere.Flicking = false;
				this.Yandere.Punching = false;
				this.Yandere.CanMove = false;
				this.Yandere.Shoved = true;
				this.Yandere.GloveTimer = 0f;
				this.Yandere.h = 0f;
				this.Yandere.v = 0f;
				this.Yandere.ShoveSpeed = 2f;
			}
		}
	}
}
