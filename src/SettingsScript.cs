﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

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

	public UILabel ToggleRunLabel;

	public UILabel FarAnimsLabel;

	public UILabel FPSCapLabel;

	public UILabel SensitivityLabel;

	public UILabel InvertAxisLabel;

	public UILabel DisableTutorialsLabel;

	public UILabel WindowedMode;

	public UILabel AmbientObscurance;

	public UILabel ShadowsLabel;

	public int SelectionLimit = 2;

	public int Selected = 1;

	public Transform CloudSystem;

	public Transform Highlight;

	public GameObject Background;

	public GameObject WarningMessage;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			OptionGlobals.DepthOfField = !OptionGlobals.DepthOfField;
			this.QualityManager.ToggleExperiment();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			OptionGlobals.RimLight = !OptionGlobals.RimLight;
			this.QualityManager.RimLight();
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			this.StudentManager.OpaqueWindows = !this.StudentManager.OpaqueWindows;
			this.StudentManager.LateUpdate();
			if (!this.StudentManager.OpaqueWindows && !this.StudentManager.WindowOccluder.open)
			{
				this.StudentManager.SetWindowsOpaque();
			}
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			this.ToggleBackground();
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
				OptionGlobals.ParticleCount++;
				this.QualityManager.UpdateParticles();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				OptionGlobals.ParticleCount--;
				this.QualityManager.UpdateParticles();
				this.UpdateText();
			}
		}
		else if (this.Selected == 2)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.DisableOutlines = !OptionGlobals.DisableOutlines;
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
				OptionGlobals.DisablePostAliasing = !OptionGlobals.DisablePostAliasing;
				this.UpdateText();
				this.QualityManager.UpdatePostAliasing();
			}
		}
		else if (this.Selected == 5)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.DisableBloom = !OptionGlobals.DisableBloom;
				this.UpdateText();
				this.QualityManager.UpdateBloom();
			}
		}
		else if (this.Selected == 6)
		{
			if (this.InputManager.TappedRight)
			{
				OptionGlobals.LowDetailStudents--;
				this.QualityManager.UpdateLowDetailStudents();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				OptionGlobals.LowDetailStudents++;
				this.QualityManager.UpdateLowDetailStudents();
				this.UpdateText();
			}
		}
		else if (this.Selected == 7)
		{
			if (this.InputManager.TappedRight)
			{
				OptionGlobals.DrawDistance += 10;
				this.QualityManager.UpdateDrawDistance();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				OptionGlobals.DrawDistance -= 10;
				this.QualityManager.UpdateDrawDistance();
				this.UpdateText();
			}
		}
		else if (this.Selected == 8)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.Fog = !OptionGlobals.Fog;
				this.UpdateText();
				this.QualityManager.UpdateFog();
			}
		}
		else if (this.Selected == 9)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.ToggleRun = !OptionGlobals.ToggleRun;
				this.UpdateText();
				this.QualityManager.ToggleRun();
			}
		}
		else if (this.Selected == 10)
		{
			if (this.InputManager.TappedRight)
			{
				OptionGlobals.DisableFarAnimations++;
				this.QualityManager.UpdateAnims();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				OptionGlobals.DisableFarAnimations--;
				this.QualityManager.UpdateAnims();
				this.UpdateText();
			}
		}
		else if (this.Selected == 11)
		{
			if (this.InputManager.TappedRight)
			{
				OptionGlobals.FPSIndex++;
				this.QualityManager.UpdateFPSIndex();
			}
			else if (this.InputManager.TappedLeft)
			{
				OptionGlobals.FPSIndex--;
				this.QualityManager.UpdateFPSIndex();
			}
			this.UpdateText();
		}
		else if (this.Selected == 12)
		{
			if (this.InputManager.TappedRight)
			{
				if (OptionGlobals.Sensitivity < 10)
				{
					OptionGlobals.Sensitivity++;
				}
			}
			else if (this.InputManager.TappedLeft && OptionGlobals.Sensitivity > 1)
			{
				OptionGlobals.Sensitivity--;
			}
			if (this.PauseScreen.RPGCamera != null)
			{
				this.PauseScreen.RPGCamera.sensitivity = (float)OptionGlobals.Sensitivity;
			}
			this.UpdateText();
		}
		else if (this.Selected == 13)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.InvertAxis = !OptionGlobals.InvertAxis;
				if (this.PauseScreen.RPGCamera != null)
				{
					this.PauseScreen.RPGCamera.invertAxis = OptionGlobals.InvertAxis;
				}
				this.UpdateText();
			}
			this.UpdateText();
		}
		else if (this.Selected == 14)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.TutorialsOff = !OptionGlobals.TutorialsOff;
				if (SceneManager.GetActiveScene().name == "SchoolScene")
				{
					this.StudentManager.TutorialWindow.enabled = !OptionGlobals.TutorialsOff;
				}
				this.UpdateText();
			}
			this.UpdateText();
		}
		else if (this.Selected == 15)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				Screen.SetResolution(Screen.width, Screen.height, !Screen.fullScreen);
				this.UpdateText();
			}
			this.UpdateText();
		}
		else if (this.Selected == 16)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.DisableObscurance = !OptionGlobals.DisableObscurance;
				this.QualityManager.UpdateObscurance();
				this.UpdateText();
			}
			this.UpdateText();
		}
		else if (this.Selected == 17)
		{
			this.WarningMessage.SetActive(true);
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.EnableShadows = !OptionGlobals.EnableShadows;
				this.QualityManager.UpdateShadows();
				this.UpdateText();
			}
			this.UpdateText();
		}
		if (this.Selected != 17)
		{
			this.WarningMessage.SetActive(false);
		}
		if (Input.GetKeyDown("l"))
		{
			OptionGlobals.ParticleCount = 1;
			OptionGlobals.DisableOutlines = true;
			QualitySettings.antiAliasing = 0;
			OptionGlobals.DisablePostAliasing = true;
			OptionGlobals.DisableBloom = true;
			OptionGlobals.LowDetailStudents = 1;
			OptionGlobals.DrawDistance = 50;
			OptionGlobals.EnableShadows = false;
			OptionGlobals.DisableFarAnimations = 1;
			OptionGlobals.RimLight = false;
			OptionGlobals.DepthOfField = false;
			this.QualityManager.UpdateFog();
			this.QualityManager.UpdateAnims();
			this.QualityManager.UpdateBloom();
			this.QualityManager.UpdateFPSIndex();
			this.QualityManager.UpdateShadows();
			this.QualityManager.UpdateParticles();
			this.QualityManager.UpdatePostAliasing();
			this.QualityManager.UpdateDrawDistance();
			this.QualityManager.UpdateLowDetailStudents();
			this.QualityManager.UpdateOutlines();
			this.UpdateText();
		}
		if (Input.GetButtonDown("B"))
		{
			this.WarningMessage.SetActive(false);
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			if (this.PauseScreen.ScreenBlur != null)
			{
				this.PauseScreen.ScreenBlur.enabled = true;
			}
			this.PauseScreen.MainMenu.SetActive(true);
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			base.gameObject.SetActive(false);
		}
	}

	public void UpdateText()
	{
		if (OptionGlobals.ParticleCount == 3)
		{
			this.ParticleLabel.text = "High";
		}
		else if (OptionGlobals.ParticleCount == 2)
		{
			this.ParticleLabel.text = "Low";
		}
		else if (OptionGlobals.ParticleCount == 1)
		{
			this.ParticleLabel.text = "None";
		}
		this.FPSCapLabel.text = QualityManagerScript.FPSStrings[OptionGlobals.FPSIndex];
		this.OutlinesLabel.text = (OptionGlobals.DisableOutlines ? "Off" : "On");
		this.AliasingLabel.text = QualitySettings.antiAliasing + "x";
		this.PostAliasingLabel.text = (OptionGlobals.DisablePostAliasing ? "Off" : "On");
		this.BloomLabel.text = (OptionGlobals.DisableBloom ? "Off" : "On");
		this.LowDetailLabel.text = ((OptionGlobals.LowDetailStudents == 0) ? "Off" : ((OptionGlobals.LowDetailStudents * 10).ToString() + "m"));
		this.FarAnimsLabel.text = ((OptionGlobals.DisableFarAnimations == 0) ? "Off" : ((OptionGlobals.DisableFarAnimations * 5).ToString() + "m"));
		this.DrawDistanceLabel.text = OptionGlobals.DrawDistance + "m";
		this.FogLabel.text = (OptionGlobals.Fog ? "On" : "Off");
		this.ToggleRunLabel.text = (OptionGlobals.ToggleRun ? "Toggle" : "Hold");
		this.SensitivityLabel.text = string.Concat(OptionGlobals.Sensitivity);
		this.InvertAxisLabel.text = (OptionGlobals.InvertAxis ? "Yes" : "No");
		this.DisableTutorialsLabel.text = (OptionGlobals.TutorialsOff ? "Yes" : "No");
		this.WindowedMode.text = (Screen.fullScreen ? "No" : "Yes");
		this.AmbientObscurance.text = (OptionGlobals.DisableObscurance ? "Off" : "On");
		this.ShadowsLabel.text = (OptionGlobals.EnableShadows ? "Yes" : "No");
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
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 430f - 50f * (float)this.Selected, this.Highlight.localPosition.z);
	}

	public void ToggleBackground()
	{
		OptionGlobals.DrawDistanceLimit = 350;
		OptionGlobals.DrawDistance = 350;
		this.QualityManager.UpdateDrawDistance();
		this.Background.SetActive(false);
	}
}
