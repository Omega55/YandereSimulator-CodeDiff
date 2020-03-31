using System;
using UnityEngine;

public class FavorMenuScript : MonoBehaviour
{
	public TutorialWindowScript TutorialWindow;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public ServicesScript ServicesMenu;

	public SchemesScript SchemesMenu;

	public DropsScript DropsMenu;

	public PromptBarScript PromptBar;

	public Transform Highlight;

	public int ID = 1;

	private void Update()
	{
		if (this.InputManager.TappedRight)
		{
			this.ID++;
			this.UpdateHighlight();
		}
		else if (this.InputManager.TappedLeft)
		{
			this.ID--;
			this.UpdateHighlight();
		}
		if (!this.TutorialWindow.Hide && !this.TutorialWindow.Show)
		{
			if (Input.GetButtonDown("A"))
			{
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[1].text = "Exit";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				if (this.ID != 1)
				{
					if (this.ID == 2)
					{
						this.ServicesMenu.UpdatePantyCount();
						this.ServicesMenu.UpdateList();
						this.ServicesMenu.UpdateDesc();
						this.ServicesMenu.gameObject.SetActive(true);
						base.gameObject.SetActive(false);
					}
					else if (this.ID == 3)
					{
						this.DropsMenu.UpdatePantyCount();
						this.DropsMenu.UpdateList();
						this.DropsMenu.UpdateDesc();
						this.DropsMenu.gameObject.SetActive(true);
						base.gameObject.SetActive(false);
					}
				}
			}
			if (Input.GetButtonDown("X"))
			{
				TutorialGlobals.IgnoreClothing = true;
				this.TutorialWindow.IgnoreClothing = true;
				this.TutorialWindow.TitleLabel.text = "Info Points";
				this.TutorialWindow.TutorialLabel.text = this.TutorialWindow.PointsString;
				this.TutorialWindow.TutorialLabel.text = this.TutorialWindow.TutorialLabel.text.Replace('@', '\n');
				this.TutorialWindow.TutorialImage.mainTexture = this.TutorialWindow.InfoTexture;
				this.TutorialWindow.enabled = true;
				this.TutorialWindow.SummonWindow();
			}
			if (Input.GetButtonDown("B"))
			{
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[1].text = "Exit";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.PressedB = true;
				base.gameObject.SetActive(false);
			}
		}
	}

	private void UpdateHighlight()
	{
		if (this.ID > 3)
		{
			this.ID = 1;
		}
		else if (this.ID < 1)
		{
			this.ID = 3;
		}
		this.Highlight.transform.localPosition = new Vector3(-500f + 250f * (float)this.ID, this.Highlight.transform.localPosition.y, this.Highlight.transform.localPosition.z);
	}
}
