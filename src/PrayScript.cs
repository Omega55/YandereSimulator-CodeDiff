using System;
using UnityEngine;

[Serializable]
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

	public int Selected;

	public int SpawnID;

	public int Uses;

	public bool SpawnMale;

	public bool Show;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("Student_16_Dead") == 1)
		{
			float a = 0.5f;
			Color color = this.VictimLabel.color;
			float num = color.a = a;
			Color color2 = this.VictimLabel.color = color;
		}
		this.PrayWindow.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void Update()
	{
		if (this.GenderPrompt.Circle[0].fillAmount <= (float)0)
		{
			this.GenderPrompt.Circle[0].fillAmount = (float)1;
			if (!this.SpawnMale)
			{
				if (PlayerPrefs.GetInt("Student_15_Dead") == 1)
				{
					float a = 0.5f;
					Color color = this.VictimLabel.color;
					float num = color.a = a;
					Color color2 = this.VictimLabel.color = color;
				}
				else
				{
					int num2 = 1;
					Color color3 = this.VictimLabel.color;
					float num3 = color3.a = (float)num2;
					Color color4 = this.VictimLabel.color = color3;
				}
				this.GenderPrompt.Label[0].text = "     " + "Male Victim";
				this.SpawnMale = true;
			}
			else
			{
				if (PlayerPrefs.GetInt("Student_16_Dead") == 1)
				{
					float a2 = 0.5f;
					Color color5 = this.VictimLabel.color;
					float num4 = color5.a = a2;
					Color color6 = this.VictimLabel.color = color5;
				}
				else
				{
					int num5 = 1;
					Color color7 = this.VictimLabel.color;
					float num6 = color7.a = (float)num5;
					Color color8 = this.VictimLabel.color = color7;
				}
				this.GenderPrompt.Label[0].text = "     " + "Female Victim";
				this.SpawnMale = false;
			}
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			this.Yandere.TargetStudent = this.Student;
			this.StudentManager.DisablePrompts();
			this.PrayWindow.gameObject.active = true;
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
		}
		if (!this.Show)
		{
			if (this.PrayWindow.gameObject.active)
			{
				if (this.PrayWindow.localScale.x > 0.1f)
				{
					this.PrayWindow.localScale = Vector3.Lerp(this.PrayWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				}
				else
				{
					this.PrayWindow.localScale = new Vector3((float)0, (float)0, (float)0);
					this.PrayWindow.gameObject.active = false;
				}
			}
		}
		else
		{
			this.PrayWindow.localScale = Vector3.Lerp(this.PrayWindow.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
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
					this.Yandere.Sanity = this.Yandere.Sanity - (float)50;
					this.Yandere.UpdateSanity();
					this.Exit();
				}
				else if (this.Selected == 3)
				{
					if (this.VictimLabel.color.a == (float)1 && this.StudentManager.NPCsSpawned >= this.StudentManager.NPCsTotal)
					{
						int num7;
						if (this.SpawnMale)
						{
							num7 = 15;
						}
						else
						{
							num7 = 16;
						}
						if (this.StudentManager.Students[num7] != null)
						{
							UnityEngine.Object.Destroy(this.StudentManager.Students[num7].gameObject);
						}
						this.StudentManager.Students[num7] = null;
						this.StudentManager.ForceSpawn = true;
						this.StudentManager.SpawnPositions[num7] = this.SummonSpot;
						this.StudentManager.SpawnID = num7;
						this.StudentManager.SpawnStudent();
						this.StudentManager.SpawnID = 0;
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
					this.Yandere.Bloodiness = (float)0;
					this.Yandere.Sanity = (float)100;
					this.WeaponManager.CleanWeapons();
					this.Yandere.UpdateSanity();
					this.Yandere.UpdateBlood();
					this.Exit();
				}
				else if (this.Selected == 7)
				{
					this.Exit();
				}
			}
		}
	}

	public virtual void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 7;
		}
		else if (this.Selected > 7)
		{
			this.Selected = 1;
		}
		int num = 200 - 50 * this.Selected;
		Vector3 localPosition = this.Highlight.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Highlight.transform.localPosition = localPosition;
	}

	public virtual void Exit()
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
			this.FemaleTurtle.active = true;
		}
	}

	public virtual void SpawnWeapons()
	{
		for (int i = 1; i < 5; i++)
		{
			if (this.Weapon[i] != null)
			{
				this.Weapon[i].transform.position = this.WeaponSpot[i].position;
			}
		}
	}

	public virtual void Main()
	{
	}
}
