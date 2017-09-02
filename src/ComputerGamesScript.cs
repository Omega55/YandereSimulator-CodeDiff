using System;
using UnityEngine;

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

	public int Subject = 1;

	public int GameID;

	public int ID = 1;

	public Color OriginalColor;

	private void Start()
	{
		this.GameWindow.gameObject.SetActive(false);
		this.DeactivateAllBenefits();
		this.OriginalColor = this.Yandere.PowerUp.color;
		if (Globals.Club == ClubType.Gaming)
		{
			this.EnableGames();
		}
		else
		{
			this.DisableGames();
		}
	}

	private void Update()
	{
		if (this.ShowWindow)
		{
			this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
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
		else if (this.GameWindow.localScale.x > 0.1f)
		{
			this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else
		{
			this.GameWindow.localScale = Vector3.zero;
			this.GameWindow.gameObject.SetActive(false);
		}
		if (this.Gaming)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.ComputerGames[this.GameID].transform.position.x, this.Yandere.transform.position.y, this.ComputerGames[this.GameID].transform.position.z) - this.Yandere.transform.position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
			this.Yandere.MoveTowardsTarget(new Vector3(-25.155f, this.Chairs[this.GameID].transform.position.y, this.Chairs[this.GameID].transform.position.z));
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				this.Yandere.PowerUp.gameObject.SetActive(true);
				this.Yandere.MyController.radius = 0.2f;
				this.Yandere.CanMove = true;
				this.Yandere.EmptyHands();
				this.Gaming = false;
				this.ActivateBenefit();
				this.EnableChairs();
			}
		}
		else if (this.Timer < 5f)
		{
			this.ID = 1;
			while (this.ID < this.ComputerGames.Length)
			{
				PromptScript promptScript = this.ComputerGames[this.ID];
				if (promptScript.Circle[0].fillAmount == 0f)
				{
					promptScript.Circle[0].fillAmount = 1f;
					this.GameID = this.ID;
					if (this.ID == 1)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Confirm";
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.Label[4].text = "Select";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
						this.Yandere.Character.GetComponent<Animation>().Play(this.Yandere.IdleAnim);
						this.Yandere.CanMove = false;
						this.GameWindow.gameObject.SetActive(true);
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
		if (this.Yandere.PowerUp.gameObject.activeInHierarchy)
		{
			this.Timer += Time.deltaTime;
			this.Yandere.PowerUp.transform.localPosition = new Vector3(this.Yandere.PowerUp.transform.localPosition.x, this.Yandere.PowerUp.transform.localPosition.y + Time.deltaTime, this.Yandere.PowerUp.transform.localPosition.z);
			this.Yandere.PowerUp.transform.LookAt(this.MainCamera.position);
			this.Yandere.PowerUp.transform.localEulerAngles = new Vector3(this.Yandere.PowerUp.transform.localEulerAngles.x, this.Yandere.PowerUp.transform.localEulerAngles.y + 180f, this.Yandere.PowerUp.transform.localEulerAngles.z);
			if (this.Yandere.PowerUp.color != new Color(1f, 1f, 1f, 1f))
			{
				this.Yandere.PowerUp.color = this.OriginalColor;
			}
			else
			{
				this.Yandere.PowerUp.color = new Color(1f, 1f, 1f, 1f);
			}
			if (this.Timer > 6f)
			{
				this.Yandere.PowerUp.gameObject.SetActive(false);
				base.gameObject.SetActive(false);
			}
		}
	}

	public void EnableGames()
	{
		for (int i = 1; i < this.ComputerGames.Length; i++)
		{
			this.ComputerGames[i].enabled = true;
		}
		base.gameObject.SetActive(true);
	}

	private void PlayGames()
	{
		this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_playingGames_01");
		this.Yandere.MyController.radius = 0.1f;
		this.Yandere.CanMove = false;
		this.Gaming = true;
		this.DisableChairs();
		this.DisableGames();
	}

	public void DisableGames()
	{
		for (int i = 1; i < this.ComputerGames.Length; i++)
		{
			this.ComputerGames[i].enabled = false;
			this.ComputerGames[i].Hide();
		}
		if (!this.Gaming)
		{
			base.gameObject.SetActive(false);
		}
	}

	private void EnableChairs()
	{
		for (int i = 1; i < this.Chairs.Length; i++)
		{
			this.Chairs[i].enabled = true;
		}
		base.gameObject.SetActive(true);
	}

	private void DisableChairs()
	{
		for (int i = 1; i < this.Chairs.Length; i++)
		{
			this.Chairs[i].enabled = false;
		}
	}

	private void ActivateBenefit()
	{
		if (this.GameID == 1)
		{
			if (this.Subject == 1)
			{
				Globals.BiologyBonus = 1;
			}
			else if (this.Subject == 2)
			{
				Globals.ChemistryBonus = 1;
			}
			else if (this.Subject == 3)
			{
				Globals.LanguageBonus = 1;
			}
			else if (this.Subject == 4)
			{
				Globals.PsychologyBonus = 1;
			}
		}
		else if (this.GameID == 2)
		{
			Globals.PhysicalBonus = 1;
		}
		else if (this.GameID == 3)
		{
			Globals.SeductionBonus = 1;
		}
		else if (this.GameID == 4)
		{
			Globals.NumbnessBonus = 1;
		}
		else if (this.GameID == 5)
		{
			Globals.SocialBonus = 1;
		}
		else if (this.GameID == 6)
		{
			Globals.StealthBonus = 1;
		}
		else if (this.GameID == 7)
		{
			Globals.SpeedBonus = 1;
		}
		else if (this.GameID == 8)
		{
			Globals.EnlightenmentBonus = 1;
		}
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
		this.StudentManager.UpdatePerception();
		this.Yandere.UpdateNumbness();
	}

	private void DeactivateBenefit()
	{
		if (this.GameID == 1)
		{
			if (this.Subject == 1)
			{
				Globals.BiologyBonus = 0;
			}
			else if (this.Subject == 2)
			{
				Globals.ChemistryBonus = 0;
			}
			else if (this.Subject == 3)
			{
				Globals.LanguageBonus = 0;
			}
			else if (this.Subject == 4)
			{
				Globals.PsychologyBonus = 0;
			}
		}
		else if (this.GameID == 2)
		{
			Globals.PhysicalBonus = 0;
		}
		else if (this.GameID == 3)
		{
			Globals.SeductionBonus = 0;
		}
		else if (this.GameID == 4)
		{
			Globals.NumbnessBonus = 0;
		}
		else if (this.GameID == 5)
		{
			Globals.SocialBonus = 0;
		}
		else if (this.GameID == 6)
		{
			Globals.StealthBonus = 0;
		}
		else if (this.GameID == 7)
		{
			Globals.SpeedBonus = 0;
		}
		else if (this.GameID == 8)
		{
			Globals.EnlightenmentBonus = 0;
		}
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
		this.StudentManager.UpdatePerception();
		this.Yandere.UpdateNumbness();
	}

	public void DeactivateAllBenefits()
	{
		Globals.BiologyBonus = 0;
		Globals.ChemistryBonus = 0;
		Globals.LanguageBonus = 0;
		Globals.PsychologyBonus = 0;
		Globals.PhysicalBonus = 0;
		Globals.SeductionBonus = 0;
		Globals.NumbnessBonus = 0;
		Globals.SocialBonus = 0;
		Globals.StealthBonus = 0;
		Globals.SpeedBonus = 0;
		Globals.EnlightenmentBonus = 0;
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
	}

	private void UpdateHighlight()
	{
		if (this.Subject < 1)
		{
			this.Subject = 4;
		}
		else if (this.Subject > 4)
		{
			this.Subject = 1;
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - (float)this.Subject * 100f, this.Highlight.localPosition.z);
	}
}
