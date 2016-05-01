using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ComputerGamesScript : MonoBehaviour
{
	public PromptScript[] ComputerGames;

	public Collider[] Chairs;

	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PoisonScript Poison;

	public Quaternion targetRotation;

	public Transform GameWindow;

	public Transform MainCamera;

	public Transform Highlight;

	public bool ShowWindow;

	public bool Gaming;

	public float Timer;

	public int Subject;

	public int GameID;

	public int ID;

	public Color OriginalColor;

	public ComputerGamesScript()
	{
		this.Subject = 1;
		this.ID = 1;
	}

	public virtual void Start()
	{
		this.DeactivateAllBenefits();
		this.OriginalColor = this.Yandere.PowerUp.color;
		if (PlayerPrefs.GetInt("Club") == 11)
		{
			this.EnableGames();
		}
		else
		{
			this.DisableGames();
		}
	}

	public virtual void Update()
	{
		if (this.ShowWindow)
		{
			this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (this.InputManager.TappedUp)
			{
				this.Subject--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedDown)
			{
				this.Subject++;
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				this.ShowWindow = false;
				this.PlayGames();
				this.PromptBar.ClearButtons();
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = false;
			}
			if (Input.GetButtonDown("B"))
			{
				this.Yandere.CanMove = true;
				this.ShowWindow = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = false;
			}
		}
		else
		{
			this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		if (this.Gaming)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.ComputerGames[this.GameID].transform.position.x, this.Yandere.transform.position.y, this.ComputerGames[this.GameID].transform.position.z) - this.Yandere.transform.position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
			this.Yandere.MoveTowardsTarget(new Vector3(-25.155f, this.Chairs[this.GameID].transform.position.y, this.Chairs[this.GameID].transform.position.z));
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)5)
			{
				this.Yandere.PowerUp.gameObject.active = true;
				this.Yandere.MyController.radius = 0.2f;
				this.Yandere.CanMove = true;
				this.Gaming = false;
				this.ActivateBenefit();
				this.EnableChairs();
			}
		}
		else if (this.Timer < (float)5)
		{
			this.ID = 1;
			while (this.ID < Extensions.get_length(this.ComputerGames))
			{
				if (this.ComputerGames[this.ID].Circle[0].fillAmount == (float)0)
				{
					this.ComputerGames[this.ID].Circle[0].fillAmount = (float)1;
					this.GameID = this.ID;
					if (this.ID == 1)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Confirm";
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.Label[4].text = "Select";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
						this.Yandere.Character.animation.Play(this.Yandere.IdleAnim);
						this.Yandere.CanMove = false;
						this.ShowWindow = true;
					}
					else
					{
						this.PlayGames();
					}
				}
				this.ID++;
			}
		}
		if (this.Yandere.PowerUp.gameObject.active)
		{
			this.Timer += Time.deltaTime;
			float y = this.Yandere.PowerUp.transform.localPosition.y + Time.deltaTime;
			Vector3 localPosition = this.Yandere.PowerUp.transform.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.Yandere.PowerUp.transform.localPosition = localPosition;
			this.Yandere.PowerUp.transform.LookAt(this.MainCamera.position);
			float y2 = this.Yandere.PowerUp.transform.localEulerAngles.y + (float)180;
			Vector3 localEulerAngles = this.Yandere.PowerUp.transform.localEulerAngles;
			float num2 = localEulerAngles.y = y2;
			Vector3 vector2 = this.Yandere.PowerUp.transform.localEulerAngles = localEulerAngles;
			if (this.Yandere.PowerUp.color != new Color((float)1, (float)1, (float)1, (float)1))
			{
				this.Yandere.PowerUp.color = this.OriginalColor;
			}
			else
			{
				this.Yandere.PowerUp.color = new Color((float)1, (float)1, (float)1, (float)1);
			}
			if (this.Timer > (float)6)
			{
				this.Yandere.PowerUp.gameObject.active = false;
				this.gameObject.active = false;
			}
		}
	}

	public virtual void EnableGames()
	{
		for (int i = 1; i < Extensions.get_length(this.ComputerGames); i++)
		{
			this.ComputerGames[i].enabled = true;
		}
		this.gameObject.active = true;
	}

	public virtual void PlayGames()
	{
		this.Yandere.Character.animation.CrossFade("f02_playingGames_01");
		this.Yandere.MyController.radius = 0.1f;
		this.Yandere.CanMove = false;
		this.Gaming = true;
		this.DisableChairs();
		this.DisableGames();
	}

	public virtual void DisableGames()
	{
		for (int i = 1; i < Extensions.get_length(this.ComputerGames); i++)
		{
			this.ComputerGames[i].enabled = false;
			this.ComputerGames[i].Hide();
		}
		if (!this.Gaming)
		{
			this.gameObject.active = false;
		}
	}

	public virtual void EnableChairs()
	{
		for (int i = 1; i < Extensions.get_length(this.Chairs); i++)
		{
			this.Chairs[i].enabled = true;
		}
		this.gameObject.active = true;
	}

	public virtual void DisableChairs()
	{
		for (int i = 1; i < Extensions.get_length(this.Chairs); i++)
		{
			this.Chairs[i].enabled = false;
		}
	}

	public virtual void ActivateBenefit()
	{
		if (this.GameID == 1)
		{
			if (this.Subject == 1)
			{
				PlayerPrefs.SetInt("BiologyBonus", 1);
			}
			else if (this.Subject == 2)
			{
				PlayerPrefs.SetInt("ChemistryBonus", 1);
			}
			else if (this.Subject == 3)
			{
				PlayerPrefs.SetInt("LanguageBonus", 1);
			}
			else if (this.Subject == 4)
			{
				PlayerPrefs.SetInt("PsychologyBonus", 1);
			}
		}
		else if (this.GameID == 2)
		{
			PlayerPrefs.SetInt("PhysicalBonus", 1);
		}
		else if (this.GameID == 3)
		{
			PlayerPrefs.SetInt("SeductionBonus", 1);
		}
		else if (this.GameID == 4)
		{
			PlayerPrefs.SetInt("NumbnessBonus", 1);
		}
		else if (this.GameID == 5)
		{
			PlayerPrefs.SetInt("SocialBonus", 1);
		}
		else if (this.GameID == 6)
		{
			PlayerPrefs.SetInt("StealthBonus", 1);
		}
		else if (this.GameID == 7)
		{
			PlayerPrefs.SetInt("SpeedBonus", 1);
		}
		else if (this.GameID == 8)
		{
			PlayerPrefs.SetInt("EnlightenmentBonus", 1);
		}
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
		this.StudentManager.UpdatePerception();
		this.Yandere.UpdateNumbness();
	}

	public virtual void DeactivateBenefit()
	{
		if (this.GameID == 1)
		{
			if (this.Subject == 1)
			{
				PlayerPrefs.SetInt("BiologyBonus", 0);
			}
			else if (this.Subject == 2)
			{
				PlayerPrefs.SetInt("ChemistryBonus", 0);
			}
			else if (this.Subject == 3)
			{
				PlayerPrefs.SetInt("LanguageBonus", 0);
			}
			else if (this.Subject == 4)
			{
				PlayerPrefs.SetInt("PsychologyBonus", 0);
			}
		}
		else if (this.GameID == 2)
		{
			PlayerPrefs.SetInt("PhysicalBonus", 0);
		}
		else if (this.GameID == 3)
		{
			PlayerPrefs.SetInt("SeductionBonus", 0);
		}
		else if (this.GameID == 4)
		{
			PlayerPrefs.SetInt("NumbnessBonus", 0);
		}
		else if (this.GameID == 5)
		{
			PlayerPrefs.SetInt("SocialBonus", 0);
		}
		else if (this.GameID == 6)
		{
			PlayerPrefs.SetInt("StealthBonus", 0);
		}
		else if (this.GameID == 7)
		{
			PlayerPrefs.SetInt("SpeedBonus", 0);
		}
		else if (this.GameID == 8)
		{
			PlayerPrefs.SetInt("EnlightenmentBonus", 0);
		}
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
		this.StudentManager.UpdatePerception();
		this.Yandere.UpdateNumbness();
	}

	public virtual void DeactivateAllBenefits()
	{
		PlayerPrefs.SetInt("BiologyBonus", 0);
		PlayerPrefs.SetInt("ChemistryBonus", 0);
		PlayerPrefs.SetInt("LanguageBonus", 0);
		PlayerPrefs.SetInt("PsychologyBonus", 0);
		PlayerPrefs.SetInt("PhysicalBonus", 0);
		PlayerPrefs.SetInt("SeductionBonus", 0);
		PlayerPrefs.SetInt("NumbnessBonus", 0);
		PlayerPrefs.SetInt("SocialBonus", 0);
		PlayerPrefs.SetInt("StealthBonus", 0);
		PlayerPrefs.SetInt("SpeedBonus", 0);
		PlayerPrefs.SetInt("EnlightenmentBonus", 0);
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
	}

	public virtual void UpdateHighlight()
	{
		if (this.Subject < 1)
		{
			this.Subject = 4;
		}
		else if (this.Subject > 4)
		{
			this.Subject = 1;
		}
		int num = 200 - this.Subject * 100;
		Vector3 localPosition = this.Highlight.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Highlight.localPosition = localPosition;
	}

	public virtual void Main()
	{
	}
}
