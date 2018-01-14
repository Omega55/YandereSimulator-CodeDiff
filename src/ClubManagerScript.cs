using System;
using UnityEngine;

public class ClubManagerScript : MonoBehaviour
{
	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public ComputerGamesScript ComputerGames;

	public BloodCleanerScript BloodCleaner;

	public RefrigeratorScript Refrigerator;

	public ClubWindowScript ClubWindow;

	public ContainerScript Container;

	public PromptBarScript PromptBar;

	public TranqCaseScript TranqCase;

	public YandereScript Yandere;

	public RPG_Camera MainCamera;

	public DoorScript ShedDoor;

	public PoliceScript Police;

	public GloveScript Gloves;

	public UISprite Darkness;

	public GameObject Reputation;

	public GameObject Heartrate;

	public GameObject Watermark;

	public GameObject Padlock;

	public GameObject Ritual;

	public GameObject Clock;

	public AudioClip[] MotivationalQuotes;

	public Transform[] ClubPatrolPoints;

	public Transform[] ClubVantages;

	public MaskScript[] Masks;

	public Transform[] Club6ActivitySpots;

	public int[] Club3Students;

	public int[] Club6Students;

	public bool ClubEffect;

	public AudioClip OccultAmbience;

	public int ClubPhase;

	public int Phase = 1;

	public ClubType Club;

	public int ID;

	public float TimeLimit;

	public float Timer;

	public ClubType[] ClubArray;

	public bool LeaderMissing;

	public bool LeaderDead;

	public int ClubMembers;

	public int[] Club3IDs;

	public int[] Club6IDs;

	public int[] ClubIDs;

	public bool LeaderGrudge;

	public bool ClubGrudge;

	private void Start()
	{
		this.ClubWindow.ActivityWindow.localScale = Vector3.zero;
		this.ClubWindow.ActivityWindow.gameObject.SetActive(false);
		this.ActivateClubBenefit();
		this.ID = 0;
		while (this.ID < this.ClubArray.Length)
		{
			if (ClubGlobals.GetClubClosed(this.ClubArray[this.ID]))
			{
				this.ClubPatrolPoints[this.ID].transform.position = new Vector3(this.ClubPatrolPoints[this.ID].transform.position.x, this.ClubPatrolPoints[this.ID].transform.position.y, 20f);
			}
			this.ID++;
		}
		this.ID = 0;
	}

	private void Update()
	{
		if (this.Club != ClubType.None)
		{
			if (this.Phase == 1)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			}
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.Darkness.color.a == 0f)
			{
				if (this.Phase == 1)
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Continue";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.ClubWindow.PerformingActivity = true;
					this.ClubWindow.ActivityWindow.gameObject.SetActive(true);
					this.ClubWindow.ActivityLabel.text = this.ClubWindow.ActivityDescs[(int)this.Club];
					this.Phase++;
				}
				else if (this.Phase == 2)
				{
					if (this.ClubWindow.ActivityWindow.localScale.x > 0.9f)
					{
						if (this.Club == ClubType.MartialArts)
						{
							if (this.ClubPhase == 0)
							{
								component.clip = this.MotivationalQuotes[UnityEngine.Random.Range(0, this.MotivationalQuotes.Length)];
								component.Play();
								this.ClubEffect = true;
								this.ClubPhase++;
								this.TimeLimit = component.clip.length;
							}
							else if (this.ClubPhase == 1)
							{
								this.Timer += Time.deltaTime;
								if (this.Timer > this.TimeLimit)
								{
									this.ID = 0;
									while (this.ID < this.Club6Students.Length)
									{
										if (this.StudentManager.Students[this.ID] != null && !this.StudentManager.Students[this.ID].Tranquil)
										{
											this.StudentManager.Students[this.Club6Students[this.ID]].GetComponent<AudioSource>().volume = 1f;
										}
										this.ID++;
									}
									this.ClubPhase++;
								}
							}
						}
						if (Input.GetButtonDown("A"))
						{
							this.ClubWindow.PerformingActivity = false;
							this.PromptBar.Show = false;
							this.Phase++;
						}
					}
				}
				else if (this.ClubWindow.ActivityWindow.localScale.x < 0.1f)
				{
					this.Police.Darkness.enabled = true;
					this.Police.ClubActivity = false;
					this.Police.FadeOut = true;
				}
			}
			if (this.Club == ClubType.Occult)
			{
				component.volume = 1f - this.Darkness.color.a;
			}
		}
	}

	public void ClubActivity()
	{
		this.StudentManager.StopMoving();
		this.ShoulderCamera.enabled = false;
		this.MainCamera.enabled = false;
		this.MainCamera.transform.position = this.ClubVantages[(int)this.Club].position;
		this.MainCamera.transform.rotation = this.ClubVantages[(int)this.Club].rotation;
		if (this.Club == ClubType.Occult)
		{
			this.ID = 0;
			while (this.ID < this.Club3Students.Length)
			{
				StudentScript studentScript = this.StudentManager.Students[this.Club3Students[this.ID]];
				if (studentScript != null && !studentScript.Tranquil)
				{
					studentScript.gameObject.SetActive(false);
				}
				this.ID++;
			}
			this.MainCamera.GetComponent<AudioListener>().enabled = true;
			AudioSource component = base.GetComponent<AudioSource>();
			component.clip = this.OccultAmbience;
			component.loop = true;
			component.volume = 0f;
			component.Play();
			this.Yandere.gameObject.SetActive(false);
			this.Ritual.SetActive(true);
		}
		else if (this.Club == ClubType.MartialArts)
		{
			this.ID = 0;
			while (this.ID < this.Club6Students.Length)
			{
				StudentScript studentScript2 = this.StudentManager.Students[this.Club6Students[this.ID]];
				if (studentScript2 != null && !studentScript2.Tranquil && studentScript2.Alive)
				{
					studentScript2.transform.position = this.Club6ActivitySpots[this.ID].position;
					studentScript2.transform.rotation = this.Club6ActivitySpots[this.ID].rotation;
					studentScript2.ClubActivity = true;
					studentScript2.GetComponent<AudioSource>().volume = 0.1f;
					if (!studentScript2.ClubAttire)
					{
						studentScript2.ChangeClubwear();
					}
				}
				this.ID++;
			}
			this.Yandere.CanMove = false;
			this.Yandere.ClubActivity = true;
			this.Yandere.transform.position = this.Club6ActivitySpots[5].position;
			this.Yandere.transform.rotation = this.Club6ActivitySpots[5].rotation;
			if (!this.Yandere.ClubAttire)
			{
				this.Yandere.ChangeClubwear();
			}
		}
		this.Clock.SetActive(false);
		this.Reputation.SetActive(false);
		this.Heartrate.SetActive(false);
		this.Watermark.SetActive(false);
	}

	public void CheckClub(ClubType Check)
	{
		if (Check == ClubType.Occult)
		{
			this.ClubIDs = this.Club3IDs;
		}
		else if (Check == ClubType.MartialArts)
		{
			this.ClubIDs = this.Club6IDs;
		}
		this.LeaderMissing = false;
		this.LeaderDead = false;
		this.ClubMembers = 0;
		this.ID = 1;
		while (this.ID < this.ClubIDs.Length)
		{
			if (!StudentGlobals.GetStudentDead(this.ClubIDs[this.ID]) && !StudentGlobals.GetStudentDying(this.ClubIDs[this.ID]) && !StudentGlobals.GetStudentKidnapped(this.ClubIDs[this.ID]) && !StudentGlobals.GetStudentArrested(this.ClubIDs[this.ID]) && StudentGlobals.GetStudentReputation(this.ClubIDs[this.ID]) > -100)
			{
				this.ClubMembers++;
			}
			this.ID++;
		}
		if (this.TranqCase.VictimClubType == Check)
		{
			this.ClubMembers--;
		}
		if (ClubGlobals.Club == Check)
		{
			this.ClubMembers++;
		}
		if (Check == ClubType.Occult)
		{
			int num = 26;
			if (StudentGlobals.GetStudentDead(num) || StudentGlobals.GetStudentDying(num) || StudentGlobals.GetStudentArrested(num) || StudentGlobals.GetStudentReputation(num) <= -100)
			{
				this.LeaderDead = true;
			}
			if (StudentGlobals.GetStudentMissing(num) || StudentGlobals.GetStudentKidnapped(num) || this.TranqCase.VictimID == num)
			{
				this.LeaderMissing = true;
			}
		}
		else if (Check == ClubType.MartialArts)
		{
			int num2 = 21;
			if (StudentGlobals.GetStudentDead(num2) || StudentGlobals.GetStudentDying(num2) || StudentGlobals.GetStudentArrested(num2) || StudentGlobals.GetStudentReputation(num2) <= -100)
			{
				this.LeaderDead = true;
			}
			if (StudentGlobals.GetStudentMissing(num2) || StudentGlobals.GetStudentKidnapped(num2) || this.TranqCase.VictimID == num2)
			{
				this.LeaderMissing = true;
			}
		}
	}

	public void CheckGrudge(ClubType Check)
	{
		if (Check == ClubType.Occult)
		{
			this.ClubIDs = this.Club3IDs;
		}
		else if (Check == ClubType.MartialArts)
		{
			this.ClubIDs = this.Club6IDs;
		}
		this.LeaderGrudge = false;
		this.ClubGrudge = false;
		this.ID = 1;
		while (this.ID < this.ClubIDs.Length)
		{
			if (this.StudentManager.Students[this.ClubIDs[this.ID]] != null && this.StudentManager.Students[this.ClubIDs[this.ID]].Grudge)
			{
				this.ClubGrudge = true;
			}
			this.ID++;
		}
		if (Check == ClubType.Occult)
		{
			if (this.StudentManager.Students[26].Grudge)
			{
				this.LeaderGrudge = true;
			}
		}
		else if (Check == ClubType.MartialArts && this.StudentManager.Students[21].Grudge)
		{
			this.LeaderGrudge = true;
		}
	}

	public void ActivateClubBenefit()
	{
		if (ClubGlobals.Club == ClubType.Cooking)
		{
			this.Refrigerator.enabled = true;
			this.Refrigerator.Prompt.enabled = true;
		}
		else if (ClubGlobals.Club == ClubType.Drama)
		{
			this.ID = 1;
			while (this.ID < this.Masks.Length)
			{
				this.Masks[this.ID].enabled = true;
				this.Masks[this.ID].Prompt.enabled = true;
				this.ID++;
			}
			this.Gloves.enabled = true;
			this.Gloves.Prompt.enabled = true;
		}
		else if (ClubGlobals.Club == ClubType.Occult)
		{
			this.StudentManager.UpdatePerception();
			this.Yandere.Numbness -= 0.5f;
		}
		else if (ClubGlobals.Club == ClubType.Art)
		{
			this.StudentManager.UpdateBooths();
		}
		else if (ClubGlobals.Club == ClubType.LightMusic)
		{
			this.Container.enabled = true;
			this.Container.Prompt.enabled = true;
		}
		else if (ClubGlobals.Club == ClubType.MartialArts)
		{
			this.StudentManager.UpdateBooths();
		}
		else if (ClubGlobals.Club != ClubType.Photography)
		{
			if (ClubGlobals.Club == ClubType.Science)
			{
				this.BloodCleaner.Prompt.enabled = true;
			}
			else if (ClubGlobals.Club == ClubType.Sports)
			{
				this.Yandere.RunSpeed += 1f;
				if (this.Yandere.Armed)
				{
					this.Yandere.EquippedWeapon.SuspicionCheck();
				}
			}
			else if (ClubGlobals.Club == ClubType.Gardening)
			{
				this.ShedDoor.Prompt.Label[0].text = "     Open";
				this.Padlock.SetActive(false);
				this.ShedDoor.Locked = false;
				if (this.Yandere.Armed)
				{
					this.Yandere.EquippedWeapon.SuspicionCheck();
				}
			}
			else if (ClubGlobals.Club == ClubType.Gaming)
			{
				this.ComputerGames.EnableGames();
			}
		}
	}

	public void DeactivateClubBenefit()
	{
		if (ClubGlobals.Club == ClubType.Cooking)
		{
			this.Refrigerator.enabled = false;
			this.Refrigerator.Prompt.Hide();
			this.Refrigerator.Prompt.enabled = false;
		}
		else if (ClubGlobals.Club == ClubType.Drama)
		{
			this.ID = 1;
			while (this.ID < this.Masks.Length)
			{
				if (this.Masks[this.ID] != null)
				{
					this.Masks[this.ID].enabled = false;
					this.Masks[this.ID].Prompt.Hide();
					this.Masks[this.ID].Prompt.enabled = false;
				}
				this.ID++;
			}
			this.Gloves.enabled = false;
			this.Gloves.Prompt.Hide();
			this.Gloves.Prompt.enabled = false;
		}
		else if (ClubGlobals.Club == ClubType.Occult)
		{
			ClubGlobals.Club = ClubType.None;
			this.StudentManager.UpdatePerception();
			this.Yandere.Numbness += 0.5f;
		}
		else if (ClubGlobals.Club == ClubType.Art)
		{
			this.StudentManager.UpdateBooths();
		}
		else if (ClubGlobals.Club == ClubType.LightMusic)
		{
			this.Container.enabled = false;
			this.Container.Prompt.Hide();
			this.Container.Prompt.enabled = false;
		}
		else if (ClubGlobals.Club == ClubType.MartialArts)
		{
			this.StudentManager.UpdateBooths();
		}
		else if (ClubGlobals.Club != ClubType.Photography)
		{
			if (ClubGlobals.Club == ClubType.Science)
			{
				this.BloodCleaner.enabled = false;
				this.BloodCleaner.Prompt.Hide();
				this.BloodCleaner.Prompt.enabled = false;
			}
			else if (ClubGlobals.Club == ClubType.Sports)
			{
				this.Yandere.RunSpeed -= 1f;
				if (this.Yandere.Armed)
				{
					ClubGlobals.Club = ClubType.None;
					this.Yandere.EquippedWeapon.SuspicionCheck();
				}
			}
			else if (ClubGlobals.Club == ClubType.Gardening)
			{
				if (!this.Yandere.Inventory.ShedKey)
				{
					this.ShedDoor.Prompt.Label[0].text = "     Locked";
					this.Padlock.SetActive(true);
					this.ShedDoor.Locked = true;
				}
				if (this.Yandere.Armed)
				{
					ClubGlobals.Club = ClubType.None;
					this.Yandere.EquippedWeapon.SuspicionCheck();
				}
			}
			else if (ClubGlobals.Club == ClubType.Gaming)
			{
				this.ComputerGames.DeactivateAllBenefits();
				this.ComputerGames.DisableGames();
			}
		}
	}

	public void UpdateMasks()
	{
		bool flag = this.Yandere.Mask != null;
		this.ID = 1;
		while (this.ID < this.Masks.Length)
		{
			this.Masks[this.ID].Prompt.HideButton[0] = flag;
			this.ID++;
		}
	}
}
