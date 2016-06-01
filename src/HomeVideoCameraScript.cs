using System;
using UnityEngine;

[Serializable]
public class HomeVideoCameraScript : MonoBehaviour
{
	public HomePrisonerChanScript HomePrisonerChan;

	public HomeDarknessScript HomeDarkness;

	public HomePrisonerScript HomePrisoner;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public PromptScript Prompt;

	public UILabel Subtitle;

	public bool AudioPlayed;

	public bool TextSet;

	public float Timer;

	public virtual void Update()
	{
		if (!this.TextSet && PlayerPrefs.GetInt("Night") == 0)
		{
			this.Prompt.Label[0].text = "     " + "Only Available At Night";
		}
		if (PlayerPrefs.GetInt("Night") == 0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.HomeCamera.Destination = this.HomeCamera.Destinations[11];
			this.HomeCamera.Target = this.HomeCamera.Targets[11];
			this.HomeCamera.ID = 11;
			this.HomePrisonerChan.LookAhead = true;
			this.HomeYandere.CanMove = false;
			this.HomeYandere.active = false;
		}
		if (this.HomeCamera.ID == 11 && !this.HomePrisoner.Bantering)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)2 && !this.AudioPlayed)
			{
				this.Subtitle.text = "...daddy...please...help...I'm scared...I don't wanna die...";
				this.AudioPlayed = true;
				this.audio.Play();
			}
			if (this.Timer > (float)2 + this.audio.clip.length)
			{
				this.Subtitle.text = string.Empty;
			}
			if (this.Timer > (float)3 + this.audio.clip.length)
			{
				this.HomeDarkness.FadeSlow = true;
				this.HomeDarkness.FadeOut = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
