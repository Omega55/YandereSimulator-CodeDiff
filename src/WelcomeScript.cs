using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScript : MonoBehaviour
{
	[SerializeField]
	private JsonScript JSON;

	[SerializeField]
	private GameObject WelcomePanel;

	[SerializeField]
	private GameObject WarningPanel;

	[SerializeField]
	private UILabel FlashingLabel;

	[SerializeField]
	private UILabel BeginLabel;

	[SerializeField]
	private UISprite Darkness;

	[SerializeField]
	private AudioSource Music;

	[SerializeField]
	private bool Continue;

	[SerializeField]
	private bool FlashRed;

	[SerializeField]
	private float VersionNumber;

	[SerializeField]
	private float Timer;

	private void Start()
	{
		this.BeginLabel.color = new Color(this.BeginLabel.color.r, this.BeginLabel.color.g, this.BeginLabel.color.b, 0f);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 2f);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (ApplicationGlobals.VersionNumber != this.VersionNumber)
		{
			Globals.DeleteAll();
			ApplicationGlobals.VersionNumber = this.VersionNumber;
		}
		if (this.JSON.Students[33].Name != "Reserved")
		{
			if (Application.CanStreamedLevelBeLoaded("FunScene"))
			{
				SceneManager.LoadScene("FunScene");
			}
			else if (Application.CanStreamedLevelBeLoaded("MoreFunScene"))
			{
				SceneManager.LoadScene("MoreFunScene");
			}
			else
			{
				Application.Quit();
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			SceneManager.LoadScene("SchoolScene");
		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
			SceneManager.LoadScene("YanvaniaScene");
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
					if (this.BeginLabel.color.a >= 1f)
					{
						if (this.WelcomePanel.activeInHierarchy && Input.anyKeyDown)
						{
							this.Darkness.color = new Color(1f, 1f, 1f, 0f);
							this.Continue = true;
						}
						if (this.WarningPanel.activeInHierarchy && Input.anyKeyDown)
						{
							this.Darkness.color = new Color(1f, 1f, 1f, 0f);
							this.Continue = true;
						}
					}
				}
			}
		}
		else
		{
			this.Music.volume -= Time.deltaTime;
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				SceneManager.LoadScene("SponsorScene");
			}
		}
		if (!this.FlashRed)
		{
			this.FlashingLabel.color = new Color(this.FlashingLabel.color.r + Time.deltaTime * 10f, this.FlashingLabel.color.g, this.FlashingLabel.color.b, this.FlashingLabel.color.a);
			if (this.FlashingLabel.color.r > 1f)
			{
				this.FlashRed = true;
			}
		}
		else
		{
			this.FlashingLabel.color = new Color(this.FlashingLabel.color.r - Time.deltaTime * 10f, this.FlashingLabel.color.g, this.FlashingLabel.color.b, this.FlashingLabel.color.a);
			if (this.FlashingLabel.color.r < 0f)
			{
				this.FlashRed = false;
			}
		}
	}
}
