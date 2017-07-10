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
				PlayerPrefs.SetInt("ParticleCount", PlayerPrefs.GetInt("ParticleCount") + 1);
				this.QualityManager.UpdateParticles();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				PlayerPrefs.SetInt("ParticleCount", PlayerPrefs.GetInt("ParticleCount") - 1);
				this.QualityManager.UpdateParticles();
				this.UpdateText();
			}
		}
		else if (this.Selected == 2)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				PlayerPrefs.SetInt("DisableOutlines", (PlayerPrefs.GetInt("DisableOutlines") != 1) ? 1 : 0);
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
				PlayerPrefs.SetInt("DisablePostAliasing", (PlayerPrefs.GetInt("DisablePostAliasing") != 1) ? 1 : 0);
				this.UpdateText();
				this.QualityManager.UpdatePostAliasing();
			}
		}
		else if (this.Selected == 5)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				PlayerPrefs.SetInt("DisableBloom", (PlayerPrefs.GetInt("DisableBloom") != 1) ? 1 : 0);
				this.UpdateText();
				this.QualityManager.UpdateBloom();
			}
		}
		else if (this.Selected == 6)
		{
			if (this.InputManager.TappedRight)
			{
				PlayerPrefs.SetInt("LowDetailStudents", PlayerPrefs.GetInt("LowDetailStudents") - 1);
				this.QualityManager.UpdateLowDetailStudents();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				PlayerPrefs.SetInt("LowDetailStudents", PlayerPrefs.GetInt("LowDetailStudents") + 1);
				this.QualityManager.UpdateLowDetailStudents();
				this.UpdateText();
			}
		}
		else if (this.Selected == 7)
		{
			if (this.InputManager.TappedRight)
			{
				PlayerPrefs.SetInt("DrawDistance", PlayerPrefs.GetInt("DrawDistance") + 10);
				this.QualityManager.UpdateDrawDistance();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				PlayerPrefs.SetInt("DrawDistance", PlayerPrefs.GetInt("DrawDistance") - 10);
				this.QualityManager.UpdateDrawDistance();
				this.UpdateText();
			}
		}
		else if (this.Selected == 8)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				PlayerPrefs.SetInt("Fog", (PlayerPrefs.GetInt("Fog") != 1) ? 1 : 0);
				this.UpdateText();
				this.QualityManager.UpdateFog();
			}
		}
		else if (this.Selected == 9)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				PlayerPrefs.SetInt("DisableShadows", (PlayerPrefs.GetInt("DisableShadows") != 1) ? 1 : 0);
				this.UpdateText();
				this.QualityManager.UpdateShadows();
			}
		}
		else if (this.Selected == 10 && (this.InputManager.TappedRight || this.InputManager.TappedLeft))
		{
			PlayerPrefs.SetInt("DisableFarAnimations", (PlayerPrefs.GetInt("DisableFarAnimations") != 1) ? 1 : 0);
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
		if (PlayerPrefs.GetInt("ParticleCount") == 3)
		{
			this.ParticleLabel.text = "High";
		}
		else if (PlayerPrefs.GetInt("ParticleCount") == 2)
		{
			this.ParticleLabel.text = "Low";
		}
		else if (PlayerPrefs.GetInt("ParticleCount") == 1)
		{
			this.ParticleLabel.text = "None";
		}
		this.OutlinesLabel.text = ((PlayerPrefs.GetInt("DisableOutlines") != 1) ? "On" : "Off");
		this.AliasingLabel.text = QualitySettings.antiAliasing + "x";
		this.PostAliasingLabel.text = ((PlayerPrefs.GetInt("DisablePostAliasing") != 1) ? "On" : "Off");
		this.BloomLabel.text = ((PlayerPrefs.GetInt("DisableBloom") != 1) ? "On" : "Off");
		this.LowDetailLabel.text = ((PlayerPrefs.GetInt("LowDetailStudents") != 0) ? ((PlayerPrefs.GetInt("LowDetailStudents") * 10).ToString() + "m") : "Off");
		this.DrawDistanceLabel.text = PlayerPrefs.GetInt("DrawDistance") + "m";
		if (PlayerPrefs.GetInt("Fog") == 0)
		{
			this.FogLabel.text = "Off";
		}
		else if (PlayerPrefs.GetInt("Fog") == 1)
		{
			this.FogLabel.text = "On";
		}
		if (PlayerPrefs.GetInt("DisableShadows") == 0)
		{
			this.ShadowsLabel.text = "On";
		}
		else if (PlayerPrefs.GetInt("DisableShadows") == 1)
		{
			this.ShadowsLabel.text = "Off";
		}
		if (PlayerPrefs.GetInt("DisableFarAnimations") == 0)
		{
			this.FarAnimsLabel.text = "On";
		}
		else if (PlayerPrefs.GetInt("DisableFarAnimations") == 1)
		{
			this.FarAnimsLabel.text = "Off";
		}
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
