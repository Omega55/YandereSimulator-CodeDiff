using System;
using UnityEngine;

public class YandereShowerScript : MonoBehaviour
{
	public SkinnedMeshRenderer Curtain;

	public GameObject CensorSteam;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform BatheSpot;

	public float OpenValue;

	public float Timer;

	public bool UpdateCurtain;

	public bool Open;

	public AudioSource MyAudio;

	public AudioClip CurtainClose;

	public AudioClip CurtainOpen;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Yandere.Schoolwear > 0 || this.Yandere.Chased || this.Yandere.Chasers > 0 || this.Yandere.Bloodiness == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
			}
			else
			{
				AudioSource.PlayClipAtPoint(this.CurtainOpen, base.transform.position);
				this.CensorSteam.SetActive(true);
				this.MyAudio.Play();
				this.Yandere.EmptyHands();
				this.Yandere.YandereShower = this;
				this.Yandere.CanMove = false;
				this.Yandere.Bathing = true;
				this.UpdateCurtain = true;
				this.Open = true;
				this.Timer = 6f;
			}
		}
		if (this.UpdateCurtain)
		{
			this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
			if (this.Timer < 1f)
			{
				if (this.Open)
				{
					AudioSource.PlayClipAtPoint(this.CurtainClose, base.transform.position);
				}
				this.Open = false;
				if (this.Timer == 0f)
				{
					this.CensorSteam.SetActive(false);
					this.UpdateCurtain = false;
				}
			}
			if (this.Open)
			{
				this.OpenValue = Mathf.Lerp(this.OpenValue, 0f, Time.deltaTime * 10f);
				this.Curtain.SetBlendShapeWeight(0, this.OpenValue);
			}
			else
			{
				this.OpenValue = Mathf.Lerp(this.OpenValue, 100f, Time.deltaTime * 10f);
				this.Curtain.SetBlendShapeWeight(0, this.OpenValue);
			}
		}
	}
}
