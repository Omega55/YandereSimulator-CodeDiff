using System;
using UnityEngine;

[Serializable]
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

	public int SelectionLimit;

	public int Selected;

	public Transform Highlight;

	public SettingsScript()
	{
		this.SelectionLimit = 2;
		this.Selected = 1;
	}

	public virtual void Update()
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
				if (PlayerPrefs.GetInt("DisableOutlines") == 1)
				{
					PlayerPrefs.SetInt("DisableOutlines", 0);
					this.UpdateText();
				}
				else
				{
					PlayerPrefs.SetInt("DisableOutlines", 1);
					this.UpdateText();
				}
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
				if (PlayerPrefs.GetInt("DisablePostAliasing") == 1)
				{
					PlayerPrefs.SetInt("DisablePostAliasing", 0);
					this.UpdateText();
				}
				else
				{
					PlayerPrefs.SetInt("DisablePostAliasing", 1);
					this.UpdateText();
				}
				this.QualityManager.UpdatePostAliasing();
			}
		}
		else if (this.Selected == 5)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				if (PlayerPrefs.GetInt("DisableBloom") == 1)
				{
					PlayerPrefs.SetInt("DisableBloom", 0);
					this.UpdateText();
				}
				else
				{
					PlayerPrefs.SetInt("DisableBloom", 1);
					this.UpdateText();
				}
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
				if (PlayerPrefs.GetInt("Fog") == 1)
				{
					PlayerPrefs.SetInt("Fog", 0);
					this.UpdateText();
				}
				else
				{
					PlayerPrefs.SetInt("Fog", 1);
					this.UpdateText();
				}
				this.QualityManager.UpdateFog();
			}
		}
		else if (this.Selected == 9)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				if (PlayerPrefs.GetInt("DisableShadows") == 1)
				{
					PlayerPrefs.SetInt("DisableShadows", 0);
					this.UpdateText();
				}
				else
				{
					PlayerPrefs.SetInt("DisableShadows", 1);
					this.UpdateText();
				}
				this.QualityManager.UpdateShadows();
			}
		}
		else if (this.Selected == 10 && (this.InputManager.TappedRight || this.InputManager.TappedLeft))
		{
			if (PlayerPrefs.GetInt("DisableFarAnimations") == 1)
			{
				PlayerPrefs.SetInt("DisableFarAnimations", 0);
				this.UpdateText();
			}
			else
			{
				PlayerPrefs.SetInt("DisableFarAnimations", 1);
				this.UpdateText();
			}
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
			this.PauseScreen.MainMenu.active = true;
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			this.active = false;
		}
	}

	public virtual void UpdateText()
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
		if (PlayerPrefs.GetInt("DisableOutlines") == 1)
		{
			this.OutlinesLabel.text = "Off";
		}
		else
		{
			this.OutlinesLabel.text = "On";
		}
		this.AliasingLabel.text = QualitySettings.antiAliasing + "x";
		if (PlayerPrefs.GetInt("DisablePostAliasing") == 1)
		{
			this.PostAliasingLabel.text = "Off";
		}
		else
		{
			this.PostAliasingLabel.text = "On";
		}
		if (PlayerPrefs.GetInt("DisableBloom") == 1)
		{
			this.BloomLabel.text = "Off";
		}
		else
		{
			this.BloomLabel.text = "On";
		}
		if (PlayerPrefs.GetInt("LowDetailStudents") == 0)
		{
			this.LowDetailLabel.text = "Off";
		}
		else
		{
			this.LowDetailLabel.text = PlayerPrefs.GetInt("LowDetailStudents") * 10 + "m";
		}
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

	public virtual void UpdateHighlight()
	{
		if (this.Selected == 0)
		{
			this.Selected = this.SelectionLimit;
		}
		else if (this.Selected > this.SelectionLimit)
		{
			this.Selected = 1;
		}
		int num = 445 - 80 * this.Selected;
		Vector3 localPosition = this.Highlight.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Highlight.localPosition = localPosition;
	}

	public virtual void Main()
	{
	}
}
