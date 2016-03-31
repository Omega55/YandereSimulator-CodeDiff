using System;
using UnityEngine;

[Serializable]
public class FavorMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public ServicesMenuScript ServicesMenu;

	public PauseScreenScript PauseScreen;

	public SchemesScript SchemesMenu;

	public PromptBarScript PromptBar;

	public Transform Highlight;

	public int ID;

	public FavorMenuScript()
	{
		this.ID = 1;
	}

	public virtual void Update()
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
		if (Input.GetButtonDown("A"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			if (this.ID == 1)
			{
				this.SchemesMenu.UpdateSchemeList();
				this.SchemesMenu.UpdateSchemeInfo();
				this.SchemesMenu.active = true;
				this.active = false;
			}
			else if (this.ID == 2)
			{
				this.ServicesMenu.UpdatePantyShots();
				this.ServicesMenu.active = true;
				this.active = false;
			}
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

	public virtual void UpdateHighlight()
	{
		if (this.ID > 3)
		{
			this.ID = 1;
		}
		else if (this.ID < 1)
		{
			this.ID = 3;
		}
		int num = -500 + 250 * this.ID;
		Vector3 localPosition = this.Highlight.transform.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.Highlight.transform.localPosition = localPosition;
	}

	public virtual void Main()
	{
	}
}
