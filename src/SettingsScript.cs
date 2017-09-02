using System;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
	public QualityManagerScript QualityManager;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public UILabel DrawDistanceLabel;

	public UILabel PostAliasingLabel;

	public UILabel LowDetailLabel;

	public UILabel AliasingLabel;

	public UILabel OutlinesLabel;

	public UILabel ParticleLabel;

	public UILabel BloomLabel;

	public UILabel FogLabel;

	public UILabel ShadowsLabel;

	public UILabel FarAnimsLabel;

	public int SelectionLimit = 2;

	public int Selected = 1;

	public Transform Highlight;

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.QualityManager.ToggleExperiment();
		}
		if (Input.GetKeyDown("r"))
		{
			this.QualityManager.RimLight();
		}
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
		if (this.Selected == 1)
		{
			if (this.InputManager.TappedRight)
			{
				Globals.ParticleCount++;
				this.QualityManager.UpdateParticles();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				Globals.ParticleCount--;
				this.QualityManager.UpdateParticles();
				this.UpdateText();
			}
		}
		else if (this.Selected == 2)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				Globals.DisableOutlines = !Globals.DisableOutlines;
				this.UpdateText();
				this.QualityManager.UpdateOutlines();
			}
		}
		else if (this.Selected == 3)
		{
			if (this.InputManager.TappedRight)
			{
				if (QualitySettings.antiAliasing > 0)
				{
					QualitySettings.antiAliasing *= 2;
				}
				else
				{
					QualitySettings.antiAliasing = 2;
				}
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				if (QualitySettings.antiAliasing > 0)
				{
					QualitySettings.antiAliasing /= 2;
				}
				else
				{
					QualitySettings.antiAliasing = 0;
				}
				this.UpdateText();
			}
		}
		else if (this.Selected == 4)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				Globals.DisablePostAliasing = !Globals.DisablePostAliasing;
				this.UpdateText();
				this.QualityManager.UpdatePostAliasing();
			}
		}
		else if (this.Selected == 5)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				Globals.DisableBloom = !Globals.DisableBloom;
				this.UpdateText();
				this.QualityManager.UpdateBloom();
			}
		}
		else if (this.Selected == 6)
		{
			if (this.InputManager.TappedRight)
			{
				Globals.LowDetailStudents--;
				this.QualityManager.UpdateLowDetailStudents();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				Globals.LowDetailStudents++;
				this.QualityManager.UpdateLowDetailStudents();
				this.UpdateText();
			}
		}
		else if (this.Selected == 7)
		{
			if (this.InputManager.TappedRight)
			{
				Globals.DrawDistance += 10;
				this.QualityManager.UpdateDrawDistance();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				Globals.DrawDistance -= 10;
				this.QualityManager.UpdateDrawDistance();
				this.UpdateText();
			}
		}
		else if (this.Selected == 8)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				Globals.Fog = !Globals.Fog;
				this.UpdateText();
				this.QualityManager.UpdateFog();
			}
		}
		else if (this.Selected == 9)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				Globals.DisableShadows = !Globals.DisableShadows;
				this.UpdateText();
				this.QualityManager.UpdateShadows();
			}
		}
		else if (this.Selected == 10 && (this.InputManager.TappedRight || this.InputManager.TappedLeft))
		{
			Globals.DisableFarAnimations = !Globals.DisableFarAnimations;
			this.UpdateText();
			this.QualityManager.UpdateAnims();
		}
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.ScreenBlur.enabled = true;
			this.PauseScreen.MainMenu.SetActive(true);
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			base.gameObject.SetActive(false);
		}
	}

	public void UpdateText()
	{
		if (Globals.ParticleCount == 3)
		{
			this.ParticleLabel.text = "High";
		}
		else if (Globals.ParticleCount == 2)
		{
			this.ParticleLabel.text = "Low";
		}
		else if (Globals.ParticleCount == 1)
		{
			this.ParticleLabel.text = "None";
		}
		this.OutlinesLabel.text = ((!Globals.DisableOutlines) ? "On" : "Off");
		this.AliasingLabel.text = QualitySettings.antiAliasing + "x";
		this.PostAliasingLabel.text = ((!Globals.DisablePostAliasing) ? "On" : "Off");
		this.BloomLabel.text = ((!Globals.DisableBloom) ? "On" : "Off");
		this.LowDetailLabel.text = ((Globals.LowDetailStudents != 0) ? ((Globals.LowDetailStudents * 10).ToString() + "m") : "Off");
		this.DrawDistanceLabel.text = Globals.DrawDistance + "m";
		this.FogLabel.text = ((!Globals.Fog) ? "Off" : "On");
		this.ShadowsLabel.text = ((!Globals.DisableShadows) ? "On" : "Off");
		this.FarAnimsLabel.text = ((!Globals.DisableFarAnimations) ? "On" : "Off");
	}

	private void UpdateHighlight()
	{
		if (this.Selected == 0)
		{
			this.Selected = this.SelectionLimit;
		}
		else if (this.Selected > this.SelectionLimit)
		{
			this.Selected = 1;
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 445f - 80f * (float)this.Selected, this.Highlight.localPosition.z);
	}
}
