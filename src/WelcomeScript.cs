using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScript : MonoBehaviour
{
	[SerializeField]
	private JsonScript JSON;

	[SerializeField]
	private GameObject WelcomePanel;

	[SerializeField]
	private UILabel[] FlashingLabels;

	[SerializeField]
	private UILabel AltBeginLabel;

	[SerializeField]
	private UILabel BeginLabel;

	[SerializeField]
	private UISprite Darkness;

	[SerializeField]
	private bool Continue;

	[SerializeField]
	private bool FlashRed;

	[SerializeField]
	private float VersionNumber;

	[SerializeField]
	private float Timer;

	private string Text;

	private int ID;

	private void Start()
	{
		Time.timeScale = 1f;
		this.BeginLabel.color = new Color(this.BeginLabel.color.r, this.BeginLabel.color.g, this.BeginLabel.color.b, 0f);
		this.AltBeginLabel.color = this.BeginLabel.color;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 2f);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (ApplicationGlobals.VersionNumber != this.VersionNumber)
		{
			ApplicationGlobals.VersionNumber = this.VersionNumber;
		}
		if (File.Exists(Application.streamingAssetsPath + "/Fun.txt"))
		{
			this.Text = File.ReadAllText(Application.streamingAssetsPath + "/Fun.txt");
		}
		if (this.Text == "0" || this.Text == "1" || this.Text == "2" || this.Text == "3" || this.Text == "4" || this.Text == "5" || this.Text == "6" || this.Text == "7" || this.Text == "8" || this.Text == "9" || this.Text == "10" || this.Text == "69" || this.Text == "666")
		{
			SceneManager.LoadScene("VeryFunScene");
		}
		this.ID = 0;
		while (this.ID < 100)
		{
			if (this.ID != 10 && (this.JSON.Students[this.ID].Hairstyle == "21" || this.JSON.Students[this.ID].Persona == PersonaType.Protective))
			{
				Debug.Log("Player is cheating!");
				if (Application.CanStreamedLevelBeLoaded("FunScene"))
				{
					SceneManager.LoadScene("FunScene");
				}
			}
			this.ID++;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
		}
		if (!this.Continue)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
			if (this.Darkness.color.a <= 0f)
			{
				if (Input.GetKeyDown(KeyCode.W))
				{
				}
				if (Input.anyKeyDown)
				{
					this.Timer = 5f;
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > 5f)
				{
					this.BeginLabel.color = new Color(this.BeginLabel.color.r, this.BeginLabel.color.g, this.BeginLabel.color.b, this.BeginLabel.color.a + Time.deltaTime);
					this.AltBeginLabel.color = this.BeginLabel.color;
					if (this.BeginLabel.color.a >= 1f && Input.anyKeyDown)
					{
						this.Darkness.color = new Color(1f, 1f, 1f, 0f);
						this.Continue = true;
					}
				}
			}
		}
		else
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				SceneManager.LoadScene("SponsorScene");
			}
		}
		if (!this.FlashRed)
		{
			this.ID = 0;
			while (this.ID < 3)
			{
				this.ID++;
				this.FlashingLabels[this.ID].color = new Color(this.FlashingLabels[this.ID].color.r + Time.deltaTime * 10f, this.FlashingLabels[this.ID].color.g, this.FlashingLabels[this.ID].color.b, this.FlashingLabels[this.ID].color.a);
				if (this.FlashingLabels[this.ID].color.r > 1f)
				{
					this.FlashRed = true;
				}
			}
		}
		else
		{
			this.ID = 0;
			while (this.ID < 3)
			{
				this.ID++;
				this.FlashingLabels[this.ID].color = new Color(this.FlashingLabels[this.ID].color.r - Time.deltaTime * 10f, this.FlashingLabels[this.ID].color.g, this.FlashingLabels[this.ID].color.b, this.FlashingLabels[this.ID].color.a);
				if (this.FlashingLabels[this.ID].color.r < 0f)
				{
					this.FlashRed = false;
				}
			}
		}
	}
}
