using System;
using UnityEngine;

[Serializable]
public class PeekScript : MonoBehaviour
{
	public InfoChanWindowScript InfoChanWindow;

	public PromptBarScript PromptBar;

	public SubtitleScript Subtitle;

	public JukeboxScript Jukebox;

	public PromptScript Prompt;

	public GameObject PeekCamera;

	public bool Spoke;

	public float Timer;

	public virtual void Update()
	{
		if (this.InfoChanWindow.Drop)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Yandere.CanMove = false;
			this.PeekCamera.active = true;
			this.Jukebox.Dip = 0.5f;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "Stop";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
		}
		if (this.PeekCamera.active)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)5 && !this.Spoke)
			{
				this.Subtitle.UpdateLabel("Info Notice", 0, 6.5f);
				this.Spoke = true;
				this.audio.Play();
			}
			if (Input.GetButtonDown("B"))
			{
				this.Prompt.Yandere.CanMove = true;
				this.PeekCamera.active = false;
				this.Jukebox.Dip = (float)1;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Timer = (float)0;
			}
		}
	}

	public virtual void Main()
	{
	}
}
