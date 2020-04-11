using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolutionScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public UILabel ResolutionLabel;

	public UILabel FullScreenLabel;

	public UILabel QualityLabel;

	public Transform Highlight;

	public UISprite Darkness;

	public float Alpha = 1f;

	public bool FadeOut;

	public Resolution[] Resolutions;

	public string[] Qualities;

	public int QualityID;

	public int ResID;

	public int ID = 1;

	private void Start()
	{
		this.Darkness.color = new Color(1f, 1f, 1f, 1f);
		this.Resolutions = Screen.resolutions;
		this.ResolutionLabel.text = this.Resolutions[this.ResID].width + " x " + this.Resolutions[this.ResID].height;
		this.QualityLabel.text = (this.Qualities[this.QualityID] ?? "");
		if (Screen.fullScreen)
		{
			this.FullScreenLabel.text = "No";
			return;
		}
		this.FullScreenLabel.text = "Yes";
	}

	private void Update()
	{
		if (this.FadeOut)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
			if (this.Alpha == 1f)
			{
				SceneManager.LoadScene("WelcomeScene");
			}
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
		}
		this.Darkness.color = new Color(1f, 1f, 1f, this.Alpha);
		if (this.Alpha == 0f)
		{
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				this.UpdateHighlight();
			}
			if (this.ID == 1)
			{
				if (this.InputManager.TappedLeft)
				{
					this.ResID++;
					if (this.ResID == this.Resolutions.Length)
					{
						this.ResID = 0;
					}
					this.UpdateRes();
				}
				else if (this.InputManager.TappedRight)
				{
					this.ResID--;
					if (this.ResID < 0)
					{
						this.ResID = this.Resolutions.Length - 1;
					}
					this.UpdateRes();
				}
			}
			else if (this.ID == 2)
			{
				if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
				{
					Screen.SetResolution(Screen.width, Screen.height, !Screen.fullScreen);
					if (Screen.fullScreen)
					{
						this.FullScreenLabel.text = "No";
					}
					else
					{
						this.FullScreenLabel.text = "Yes";
					}
				}
			}
			else if (this.ID == 3)
			{
				if (this.InputManager.TappedRight)
				{
					this.QualityID++;
					if (this.QualityID == this.Qualities.Length)
					{
						this.QualityID = 0;
					}
					this.UpdateQuality();
				}
				else if (this.InputManager.TappedLeft)
				{
					this.QualityID--;
					if (this.QualityID < 0)
					{
						this.QualityID = this.Qualities.Length - 1;
					}
					this.UpdateQuality();
				}
			}
			else if (this.ID == 4 && Input.GetButtonUp("A"))
			{
				this.FadeOut = true;
			}
		}
		this.Highlight.localPosition = Vector3.Lerp(this.Highlight.localPosition, new Vector3(-307.5f, (float)(250 - this.ID * 100), 0f), Time.deltaTime * 10f);
	}

	private void UpdateRes()
	{
		int width = Screen.width;
		int num = 0;
		Screen.SetResolution(this.Resolutions[this.ResID].width, this.Resolutions[this.ResID].height, Screen.fullScreen);
		while (Screen.width == width && num < 100)
		{
			if (this.InputManager.TappedLeft)
			{
				this.ResID++;
				if (this.ResID == this.Resolutions.Length)
				{
					this.ResID = 0;
				}
			}
			else if (this.InputManager.TappedRight)
			{
				this.ResID--;
				if (this.ResID < 0)
				{
					this.ResID = this.Resolutions.Length - 1;
				}
			}
			Screen.SetResolution(this.Resolutions[this.ResID].width, this.Resolutions[this.ResID].height, Screen.fullScreen);
			num++;
		}
		this.ResolutionLabel.text = this.Resolutions[this.ResID].width + " x " + this.Resolutions[this.ResID].height;
	}

	private void UpdateQuality()
	{
		QualitySettings.SetQualityLevel(this.QualityID, true);
		this.QualityLabel.text = (this.Qualities[this.QualityID] ?? "");
	}

	private void UpdateHighlight()
	{
		if (this.ID < 1)
		{
			this.ID = 4;
			return;
		}
		if (this.ID > 4)
		{
			this.ID = 1;
		}
	}
}
