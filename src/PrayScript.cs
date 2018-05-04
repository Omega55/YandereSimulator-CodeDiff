using System;
using UnityEngine;

public class PrayScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public WeaponManagerScript WeaponManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public StudentScript Student;

	public YandereScript Yandere;

	public PoliceScript Police;

	public UILabel SanityLabel;

	public UILabel VictimLabel;

	public PromptScript GenderPrompt;

	public PromptScript Prompt;

	public Transform PrayWindow;

	public Transform SummonSpot;

	public Transform Highlight;

	public Transform[] WeaponSpot;

	public GameObject[] Weapon;

	public GameObject FemaleTurtle;

	public int StudentNumber;

	public int StudentID;

	public int Selected;

	public int Victims;

	public int Uses;

	public bool FemaleVictimChecked;

	public bool MaleVictimChecked;

	public bool JustSummoned;

	public bool SpawnMale;

	public bool Show;

	private void Start()
	{
		if (StudentGlobals.GetStudentDead(16))
		{
			this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, 0.5f);
		}
		this.PrayWindow.localScale = Vector3.zero;
		if (MissionModeGlobals.MissionMode)
		{
			this.Disable();
		}
		if (GameGlobals.LoveSick)
		{
			this.Disable();
		}
	}

	private void Disable()
	{
		this.GenderPrompt.gameObject.SetActive(false);
		base.enabled = false;
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	private void Update()
	{
		if (!this.FemaleVictimChecked)
		{
			if (this.StudentManager.Students[16] != null && !this.StudentManager.Students[16].Alive)
			{
				this.FemaleVictimChecked = true;
				this.Victims++;
			}
		}
		else if (this.StudentManager.Students[16] == null)
		{
			this.FemaleVictimChecked = false;
			this.Victims--;
		}
		if (!this.MaleVictimChecked)
		{
			if (this.StudentManager.Students[15] != null && !this.StudentManager.Students[15].Alive)
			{
				this.MaleVictimChecked = true;
				this.Victims++;
			}
		}
		else if (this.StudentManager.Students[15] == null)
		{
			this.MaleVictimChecked = false;
			this.Victims--;
		}
		if (this.JustSummoned)
		{
			this.StudentManager.UpdateMe(this.StudentID);
			this.JustSummoned = false;
		}
		if (this.GenderPrompt.Circle[0].fillAmount == 0f)
		{
			this.GenderPrompt.Circle[0].fillAmount = 1f;
			if (!this.SpawnMale)
			{
				this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, (!StudentGlobals.GetStudentDead(15)) ? 1f : 0.5f);
				this.GenderPrompt.Label[0].text = "     Male Victim";
				this.SpawnMale = true;
			}
			else
			{
				this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, (!StudentGlobals.GetStudentDead(16)) ? 1f : 0.5f);
				this.GenderPrompt.Label[0].text = "     Female Victim";
				this.SpawnMale = false;
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased)
			{
				this.Yandere.TargetStudent = this.Student;
				this.StudentManager.DisablePrompts();
				this.PrayWindow.gameObject.SetActive(true);
				this.Show = true;
				this.Yandere.ShoulderCamera.OverShoulder = true;
				this.Yandere.WeaponMenu.KeyboardShow = false;
				this.Yandere.Obscurance.enabled = false;
				this.Yandere.WeaponMenu.Show = false;
				this.Yandere.YandereVision = false;
				this.Yandere.CanMove = false;
				this.Yandere.Talking = true;
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.StudentNumber = ((!this.SpawnMale) ? 16 : 17);
				if (this.StudentManager.Students[16] != null && !this.StudentManager.Students[16].gameObject.activeInHierarchy)
				{
					this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, 0.5f);
				}
				if (this.StudentManager.Students[17] != null && !this.StudentManager.Students[17].gameObject.activeInHierarchy)
				{
					this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, 0.5f);
				}
			}
		}
		if (!this.Show)
		{
			if (this.PrayWindow.gameObject.activeInHierarchy)
			{
				if (this.PrayWindow.localScale.x > 0.1f)
				{
					this.PrayWindow.localScale = Vector3.Lerp(this.PrayWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
				}
				else
				{
					this.PrayWindow.localScale = Vector3.zero;
					this.PrayWindow.gameObject.SetActive(false);
				}
			}
		}
		else
		{
			this.PrayWindow.localScale = Vector3.Lerp(this.PrayWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (this.InputManager.TappedUp)
			{
				this.Selected--;
				if (this.Selected == 6)
				{
					this.Selected = 5;
				}
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedDown)
			{
				this.Selected++;
				if (this.Selected == 6)
				{
					this.Selected = 7;
				}
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				if (this.Selected == 1)
				{
					if (!this.Yandere.SanityBased)
					{
						this.SanityLabel.text = "Disable Sanity Anims";
						this.Yandere.SanityBased = true;
					}
					else
					{
						this.SanityLabel.text = "Enable Sanity Anims";
						this.Yandere.SanityBased = false;
					}
					this.Exit();
				}
				else if (this.Selected == 2)
				{
					this.Yandere.Sanity -= 50f;
					this.Exit();
				}
				else if (this.Selected == 3)
				{
					if (this.VictimLabel.color.a == 1f && this.StudentManager.NPCsSpawned >= this.StudentManager.NPCsTotal)
					{
						if (this.SpawnMale)
						{
							this.MaleVictimChecked = false;
							this.StudentID = 15;
						}
						else
						{
							this.FemaleVictimChecked = false;
							this.StudentID = 16;
						}
						if (this.StudentManager.Students[this.StudentID] != null)
						{
							UnityEngine.Object.Destroy(this.StudentManager.Students[this.StudentID].gameObject);
						}
						this.StudentManager.Students[this.StudentID] = null;
						this.StudentManager.ForceSpawn = true;
						this.StudentManager.SpawnPositions[this.StudentID] = this.SummonSpot;
						this.StudentManager.SpawnID = this.StudentID;
						this.StudentManager.SpawnStudent(this.StudentManager.SpawnID);
						this.StudentManager.SpawnID = 0;
						this.Police.Corpses -= this.Victims;
						this.Victims = 0;
						this.JustSummoned = true;
						this.Exit();
					}
				}
				else if (this.Selected == 4)
				{
					this.SpawnWeapons();
					this.Exit();
				}
				else if (this.Selected == 5)
				{
					this.Police.BloodyClothing = 0;
					this.Yandere.Bloodiness = 0f;
					this.Yandere.Sanity = 100f;
					this.WeaponManager.CleanWeapons();
					this.Exit();
				}
				else if (this.Selected == 7)
				{
					this.Exit();
				}
			}
		}
	}

	private void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 7;
		}
		else if (this.Selected > 7)
		{
			this.Selected = 1;
		}
		this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, 200f - 50f * (float)this.Selected, this.Highlight.transform.localPosition.z);
	}

	private void Exit()
	{
		this.Selected = 1;
		this.UpdateHighlight();
		this.Yandere.ShoulderCamera.OverShoulder = false;
		this.StudentManager.EnablePrompts();
		this.Yandere.TargetStudent = null;
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Show = false;
		this.Uses++;
		if (this.Uses > 9)
		{
			this.FemaleTurtle.SetActive(true);
		}
	}

	public void SpawnWeapons()
	{
		for (int i = 1; i < 5; i++)
		{
			if (this.Weapon[i] != null)
			{
				this.Weapon[i].transform.position = this.WeaponSpot[i].position;
			}
		}
	}
}
