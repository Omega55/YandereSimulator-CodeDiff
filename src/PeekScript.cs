using System;
using UnityEngine;

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

	private void Update()
	{
		if (this.InfoChanWindow.Drop)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.CanMove = false;
			this.PeekCamera.SetActive(true);
			this.Jukebox.Dip = 0.5f;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "Stop";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
		}
		if (this.PeekCamera.activeInHierarchy)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f && !this.Spoke)
			{
				this.Subtitle.UpdateLabel(ReactionType.InfoNotice, 0, 6.5f);
				this.Spoke = true;
				base.GetComponent<AudioSource>().Play();
			}
			if (Input.GetButtonDown("B"))
			{
				this.Prompt.Yandere.CanMove = true;
				this.PeekCamera.SetActive(false);
				this.Jukebox.Dip = 1f;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Timer = 0f;
			}
		}
	}
}
