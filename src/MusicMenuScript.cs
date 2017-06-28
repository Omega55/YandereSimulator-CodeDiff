using System;
using UnityEngine;

[Serializable]
public class MusicMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public JukeboxScript Jukebox;

	public int SelectionLimit;

	public int Selected;

	public Transform Highlight;

	public string path;

	public AudioClip[] CustomMusic;

	public MusicMenuScript()
	{
		this.SelectionLimit = 9;
		this.path = string.Empty;
	}

	public virtual void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.Selected--;
			this.UpdateHighlight();
		}
		else if (this.InputManager.TappedDown)
		{
			this.Selected++;
			this.UpdateHighlight();
		}
		if (Input.GetButtonDown("A"))
		{
			this.PlayMusic();
		}
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.MainMenu.active = true;
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			this.active = false;
		}
	}

	public virtual void PlayMusic()
	{
		this.Jukebox.Custom.clip = this.CustomMusic[this.Selected];
		this.Jukebox.PlayCustom();
	}

	public virtual void UpdateHighlight()
	{
		if (this.Selected < 0)
		{
			this.Selected = this.SelectionLimit;
		}
		else if (this.Selected > this.SelectionLimit)
		{
			this.Selected = 0;
		}
		int num = 365 - 80 * this.Selected;
		Vector3 localPosition = this.Highlight.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Highlight.localPosition = localPosition;
	}

	public virtual void Main()
	{
	}
}
