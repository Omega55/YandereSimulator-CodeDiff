using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ClubManagerScript : MonoBehaviour
{
	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public ClubWindowScript ClubWindow;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public RPG_Camera MainCamera;

	public PoliceScript Police;

	public UISprite Darkness;

	public GameObject Reputation;

	public GameObject Heartrate;

	public GameObject Watermark;

	public GameObject Ritual;

	public GameObject Clock;

	public AudioClip[] MotivationalQuotes;

	public Transform[] ClubVantages;

	public Transform[] Club6ActivitySpots;

	public int[] Club3Students;

	public int[] Club6Students;

	public bool ClubEffect;

	public AudioClip OccultAmbience;

	public int ClubPhase;

	public int Phase;

	public int Club;

	public int ID;

	public float TimeLimit;

	public float Timer;

	public bool LeaderDead;

	public int ClubMembers;

	public int[] Club3IDs;

	public int[] Club6IDs;

	public int[] ClubIDs;

	public bool LeaderGrudge;

	public bool ClubGrudge;

	public ClubManagerScript()
	{
		this.Phase = 1;
	}

	public virtual void Start()
	{
		this.ClubWindow.ActivityWindow.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void Update()
	{
		if (this.Club != 0)
		{
			if (this.Phase == 1)
			{
				float a = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
				Color color = this.Darkness.color;
				float num = color.a = a;
				Color color2 = this.Darkness.color = color;
			}
			if (this.Darkness.color.a == (float)0)
			{
				if (this.Phase == 1)
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Continue";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.ClubWindow.PerformingActivity = true;
					this.ClubWindow.ActivityLabel.text = this.ClubWindow.ActivityDescs[this.Club];
					this.Phase++;
				}
				else if (this.Phase == 2)
				{
					if (this.ClubWindow.ActivityWindow.localScale.x > 0.9f)
					{
						if (this.Club == 6)
						{
							if (this.ClubPhase == 0)
							{
								this.audio.clip = this.MotivationalQuotes[UnityEngine.Random.Range(0, Extensions.get_length(this.MotivationalQuotes))];
								this.audio.Play();
								this.ClubEffect = true;
								this.ClubPhase++;
								this.TimeLimit = this.audio.clip.length;
							}
							else if (this.ClubPhase == 1)
							{
								this.Timer += Time.deltaTime;
								if (this.Timer > this.TimeLimit)
								{
									this.ID = 0;
									while (this.ID < Extensions.get_length(this.Club6Students))
									{
										if (this.StudentManager.Students[this.ID] != null && !this.StudentManager.Students[this.ID].Tranquil)
										{
											this.StudentManager.Students[this.Club6Students[this.ID]].audio.volume = (float)1;
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
					this.Police.ClubActivity = false;
					this.Police.FadeOut = true;
				}
			}
			if (this.Club == 3)
			{
				this.audio.volume = (float)1 - this.Darkness.color.a;
			}
		}
	}

	public virtual void ClubActivity()
	{
		this.StudentManager.StopMoving();
		this.ShoulderCamera.enabled = false;
		this.MainCamera.enabled = false;
		this.MainCamera.transform.position = this.ClubVantages[this.Club].position;
		this.MainCamera.transform.rotation = this.ClubVantages[this.Club].rotation;
		if (this.Club == 3)
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Club3Students))
			{
				if (this.StudentManager.Students[this.Club3Students[this.ID]] != null && !this.StudentManager.Students[this.Club3Students[this.ID]].Tranquil)
				{
					this.StudentManager.Students[this.Club3Students[this.ID]].active = false;
				}
				this.ID++;
			}
			((AudioListener)this.MainCamera.GetComponent(typeof(AudioListener))).enabled = true;
			this.audio.clip = this.OccultAmbience;
			this.audio.loop = true;
			this.audio.volume = (float)0;
			this.audio.Play();
			this.Yandere.active = false;
			this.Ritual.active = true;
		}
		else if (this.Club == 6)
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Club6Students))
			{
				if (this.StudentManager.Students[this.Club6Students[this.ID]] != null && !this.StudentManager.Students[this.Club6Students[this.ID]].Tranquil)
				{
					this.StudentManager.Students[this.Club6Students[this.ID]].transform.position = this.Club6ActivitySpots[this.ID].position;
					this.StudentManager.Students[this.Club6Students[this.ID]].transform.rotation = this.Club6ActivitySpots[this.ID].rotation;
					this.StudentManager.Students[this.Club6Students[this.ID]].ClubActivity = true;
					this.StudentManager.Students[this.Club6Students[this.ID]].audio.volume = 0.1f;
					if (!this.StudentManager.Students[this.Club6Students[this.ID]].ClubAttire)
					{
						this.StudentManager.Students[this.Club6Students[this.ID]].ChangeClubwear();
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
		this.Clock.active = false;
		this.Reputation.active = false;
		this.Heartrate.active = false;
		this.Watermark.active = false;
	}

	public virtual void CheckClub(int Check)
	{
		if (Check == 3)
		{
			this.ClubIDs = this.Club3IDs;
		}
		else if (Check == 6)
		{
			this.ClubIDs = this.Club6IDs;
		}
		this.LeaderDead = false;
		this.ClubMembers = 0;
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.ClubIDs))
		{
			if (PlayerPrefs.GetInt("Student_" + this.ClubIDs[this.ID] + "_Dead") == 0 && PlayerPrefs.GetInt("Student_" + this.ClubIDs[this.ID] + "_Dying") == 0 && PlayerPrefs.GetInt("Student_" + this.ClubIDs[this.ID] + "_Kidnapped") == 0 && PlayerPrefs.GetInt("Student_" + this.ClubIDs[this.ID] + "_Arrested") == 0 && PlayerPrefs.GetInt("Student_" + this.ClubIDs[this.ID] + "_Reputation") > -100)
			{
				this.ClubMembers++;
			}
			this.ID++;
		}
		if (PlayerPrefs.GetInt("Club") == Check)
		{
			this.ClubMembers++;
		}
		if (Check == 3)
		{
			if (PlayerPrefs.GetInt("Student_" + 26 + "_Dead") == 1 || PlayerPrefs.GetInt("Student_" + 26 + "_Dying") == 1 || PlayerPrefs.GetInt("Student_" + 26 + "_Kidnapped") == 1 || PlayerPrefs.GetInt("Student_" + 26 + "_Arrested") == 1 || PlayerPrefs.GetInt("Student_" + 26 + "_Reputation") <= -100)
			{
				this.LeaderDead = true;
			}
		}
		else if (Check == 6 && (PlayerPrefs.GetInt("Student_" + 21 + "_Dead") == 1 || PlayerPrefs.GetInt("Student_" + 21 + "_Dying") == 1 || PlayerPrefs.GetInt("Student_" + 21 + "_Kidnapped") == 1 || PlayerPrefs.GetInt("Student_" + 21 + "_Arrested") == 1 || PlayerPrefs.GetInt("Student_" + 21 + "_Reputation") <= -100))
		{
			this.LeaderDead = true;
		}
	}

	public virtual void CheckGrudge(int Check)
	{
		if (Check == 3)
		{
			this.ClubIDs = this.Club3IDs;
		}
		else if (Check == 6)
		{
			this.ClubIDs = this.Club6IDs;
		}
		this.LeaderGrudge = false;
		this.ClubGrudge = false;
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.ClubIDs))
		{
			if (this.StudentManager.Students[this.ClubIDs[this.ID]] != null && this.StudentManager.Students[this.ClubIDs[this.ID]].Grudge)
			{
				this.ClubGrudge = true;
			}
			this.ID++;
		}
		if (Check == 3)
		{
			if (this.StudentManager.Students[26].Grudge)
			{
				this.LeaderGrudge = true;
			}
		}
		else if (Check == 6 && this.StudentManager.Students[21].Grudge)
		{
			this.LeaderGrudge = true;
		}
	}

	public virtual void Main()
	{
	}
}
