﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfDayScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public WeaponManagerScript WeaponManager;

	public ClubManagerScript ClubManager;

	public HeartbrokenScript Heartbroken;

	public ReputationScript Reputation;

	public CounselorScript Counselor;

	public WeaponScript MurderWeapon;

	public TranqCaseScript TranqCase;

	public YandereScript Yandere;

	public RagdollScript Corpse;

	public PoliceScript Police;

	public JsonScript JSON;

	public GameObject MainCamera;

	public UISprite EndOfDayDarkness;

	public UILabel Label;

	public bool PreviouslyActivated;

	public bool PoliceArrived;

	public bool ClubClosed;

	public bool ClubKicked;

	public bool ErectFence;

	public bool GameOver;

	public bool Darken;

	public string VictimString = string.Empty;

	public int DeadPerps;

	public int Arrests;

	public int Corpses;

	public int Victims;

	public int Weapons;

	public int Phase = 1;

	public int WeaponID;

	public int ArrestID;

	public int ClubID;

	public int ID;

	public string[] ClubNames;

	public int[] VictimArray;

	public ClubType[] ClubArray;

	private SaveFile saveFile;

	public void Start()
	{
		this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, 1f);
		this.PreviouslyActivated = true;
		base.GetComponent<AudioSource>().volume = 0f;
		this.UpdateScene();
	}

	private void Update()
	{
		if (this.EndOfDayDarkness.color.a == 0f && Input.GetButtonDown("A"))
		{
			this.Darken = true;
		}
		if (this.Darken)
		{
			this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, Mathf.MoveTowards(this.EndOfDayDarkness.color.a, 1f, Time.deltaTime));
			if (this.EndOfDayDarkness.color.a == 1f)
			{
				if (!this.GameOver)
				{
					this.Darken = false;
					this.UpdateScene();
				}
				else
				{
					this.Heartbroken.transform.parent.transform.parent = null;
					this.Heartbroken.transform.parent.gameObject.SetActive(true);
					this.Heartbroken.Noticed = false;
					this.Heartbroken.Arrested = true;
					this.MainCamera.SetActive(false);
					base.gameObject.SetActive(false);
					Time.timeScale = 1f;
				}
			}
		}
		else
		{
			this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, Mathf.MoveTowards(this.EndOfDayDarkness.color.a, 0f, Time.deltaTime));
		}
		AudioSource component = base.GetComponent<AudioSource>();
		component.volume = Mathf.MoveTowards(component.volume, 1f, Time.deltaTime);
	}

	public void UpdateScene()
	{
		if (this.PoliceArrived)
		{
			if (Input.GetKeyDown(KeyCode.Backspace))
			{
				this.Finish();
			}
			if (this.Phase == 1)
			{
				if (this.Police.PoisonScene)
				{
					this.Label.text = "The police and the paramedics arrive at school.";
					this.Phase = 103;
				}
				else if (this.Police.DrownScene)
				{
					this.Label.text = "The police arrive at school.";
					this.Phase = 104;
				}
				else if (this.Police.ElectroScene)
				{
					this.Label.text = "The police arrive at school.";
					this.Phase = 105;
				}
				else if (this.Police.MurderSuicideScene)
				{
					this.Label.text = "The police arrive at school, and discover what appears to be the scene of murder-suicide.";
					this.Phase++;
				}
				else
				{
					this.Label.text = "The police arrive at school.";
					if (this.Police.SuicideScene)
					{
						this.Phase = 102;
					}
					else
					{
						this.Phase++;
					}
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Police.Corpses == 0)
				{
					if (!this.Police.PoisonScene && !this.Police.SuicideScene)
					{
						this.Label.text = "The police are unable to locate any corpses on school grounds.";
						this.Phase++;
					}
					else
					{
						this.Label.text = "The police are unable to locate any other corpses on school grounds.";
						this.Phase++;
					}
				}
				else
				{
					this.ID = 0;
					while (this.ID < this.Police.CorpseList.Length)
					{
						RagdollScript ragdollScript = this.Police.CorpseList[this.ID];
						if (ragdollScript != null)
						{
							this.VictimArray[this.Corpses] = ragdollScript.Student.StudentID;
							if (this.Corpses > 0)
							{
								this.VictimString += ", and ";
							}
							this.VictimString += ragdollScript.Student.Name;
							this.Corpses++;
						}
						this.ID++;
					}
					this.Label.text = string.Concat(new string[]
					{
						"The police discover the corpse",
						(this.Corpses <= 1) ? string.Empty : "s",
						" of ",
						this.VictimString,
						"."
					});
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.WeaponManager.CheckWeapons();
				if (this.WeaponManager.MurderWeapons == 0)
				{
					if (this.Weapons == 0)
					{
						this.Label.text = "The police are unable to locate any murder weapons.";
						this.Phase += 2;
					}
					else
					{
						this.Phase += 2;
						this.UpdateScene();
					}
				}
				else
				{
					this.MurderWeapon = null;
					this.ID = 0;
					while (this.ID < this.WeaponManager.Weapons.Length)
					{
						if (this.MurderWeapon == null)
						{
							WeaponScript weaponScript = this.WeaponManager.Weapons[this.ID];
							if (weaponScript != null && weaponScript.Blood.enabled)
							{
								weaponScript.Blood.enabled = false;
								this.MurderWeapon = weaponScript;
								this.WeaponID = this.ID;
							}
						}
						this.ID++;
					}
					this.Victims = 0;
					this.VictimString = string.Empty;
					this.ID = 0;
					while (this.ID < this.MurderWeapon.Victims.Length)
					{
						if (this.MurderWeapon.Victims[this.ID])
						{
							if (this.Victims > 0)
							{
								this.VictimString += ", and ";
							}
							this.VictimString += this.JSON.Students[this.ID].Name;
							this.Victims++;
						}
						this.ID++;
					}
					this.Label.text = string.Concat(new string[]
					{
						"The police discover a ",
						this.MurderWeapon.Name,
						" that is stained with the blood of ",
						this.VictimString,
						"."
					});
					this.Weapons++;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.MurderWeapon.FingerprintID == 0)
				{
					this.Label.text = "The police find no fingerprints on the weapon.";
					this.Phase = 3;
				}
				else if (this.MurderWeapon.FingerprintID == 100)
				{
					this.Label.text = "The police find Yandere-chan's fingerprints on the weapon.";
					this.Phase = 100;
				}
				else
				{
					this.Label.text = "The police find the fingerprints of " + this.JSON.Students[this.WeaponManager.Weapons[this.WeaponID].FingerprintID].Name + " on the weapon.";
					this.Phase = 101;
				}
			}
			else if (this.Phase == 5)
			{
				if (this.Yandere.Sanity > 33.33333f)
				{
					if (this.Yandere.Bloodiness > 0f || (this.Yandere.Gloved && this.Yandere.Gloves.Blood.enabled))
					{
						if (this.Arrests == 0)
						{
							this.Label.text = "The police notice that Yandere-chan's clothing is bloody. They confirm that the blood is not hers. Yandere-chan is unable to convince the police that she did not commit murder.";
							this.Phase = 100;
						}
						else
						{
							this.Label.text = "The police notice that Yandere-chan's clothing is bloody. They confirm that the blood is not hers. Yandere-chan is able to convince the police that she was splashed with blood while witnessing a murder.";
							if (!this.TranqCase.Occupied)
							{
								this.Phase = 7;
							}
							else
							{
								this.Phase++;
							}
						}
					}
					else if (this.Police.BloodyClothing > 0)
					{
						this.Label.text = "The police find bloody clothing that has traces of Yandere-chan's DNA. Yandere-chan is unable to convince the police that she did not commit murder.";
						this.Phase = 100;
					}
					else
					{
						this.Label.text = "The police question Yandere-chan, but cannot link her to any crimes.";
						if (!this.TranqCase.Occupied)
						{
							this.Phase = 7;
						}
						else if (this.TranqCase.VictimID == this.ArrestID)
						{
							this.Phase = 7;
						}
						else
						{
							this.Phase++;
						}
					}
				}
				else if (this.Yandere.Bloodiness == 0f)
				{
					this.Label.text = "The police question Yandere-chan, who exhibits extremely unusual behavior. The police decide to investigate Yandere-chan further, and eventually learn of her crimes.";
					this.Phase = 100;
				}
				else
				{
					this.Label.text = "The police notice that Yandere-chan is covered in blood and exhibiting extremely unusual behavior. The police decide to investigate Yandere-chan further, and eventually learn of her crimes.";
					this.Phase = 100;
				}
			}
			else if (this.Phase == 6)
			{
				this.Label.text = "The police discover " + this.JSON.Students[this.TranqCase.VictimID].Name + " inside of a musical instrument case. However, she is unable to recall how she got inside of the case. The police are unable to determine what happened.";
				StudentGlobals.SetStudentMissing(this.TranqCase.VictimID, false);
				this.TranqCase.VictimID = 0;
				this.TranqCase.Occupied = false;
				this.Phase++;
			}
			else if (this.Phase == 7)
			{
				if (this.Police.MaskReported)
				{
					GameGlobals.MasksBanned = true;
					this.Label.text = "Witnesses state that the killer was wearing a mask. As a result, the police are unable to identify the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward.";
					this.Police.MaskReported = false;
					this.Phase++;
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 8)
			{
				if (this.Arrests == 0)
				{
					if (this.DeadPerps == 0)
					{
						this.Label.text = "The police do not have enough evidence to perform an arrest. The police investigation ends, and students are free to leave.";
						this.Phase++;
					}
					else
					{
						this.Label.text = "The police conclude that a murder-suicide took place, but are unable to take any further action. The police investigation ends, and students are free to leave.";
						this.Phase++;
					}
				}
				else
				{
					this.Label.text = "The police believe that they have arrested the perpetrator of the crime. The police investigation ends, and students are free to leave.";
					this.Phase++;
				}
			}
			else if (this.Phase == 9)
			{
				this.Label.text = "Yandere-chan stalks Senpai until he has returned home safely, and then returns to her own home.";
				this.Phase++;
			}
			else if (this.Phase == 10)
			{
				if (!StudentGlobals.GetStudentDying(7) && !StudentGlobals.GetStudentDead(7) && !StudentGlobals.GetStudentArrested(7))
				{
					if (this.Counselor.LectureID > 0)
					{
						this.Counselor.Lecturing = true;
						base.enabled = false;
					}
					else
					{
						this.Phase++;
						this.UpdateScene();
					}
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 11)
			{
				Debug.Log("Phase 11.");
				if (SchemeGlobals.GetSchemeStage(2) == 3)
				{
					if (!StudentGlobals.GetStudentDying(7) && !StudentGlobals.GetStudentDead(7) && !StudentGlobals.GetStudentArrested(7))
					{
						this.Label.text = "Kokona discovers Sakyu's ring inside of her book bag. She returns the ring to Sakyu, who decides to never let it out of her sight again.";
						SchemeGlobals.SetSchemeStage(2, 100);
					}
				}
				else if (SchemeGlobals.GetSchemeStage(5) > 1 && SchemeGlobals.GetSchemeStage(5) < 5)
				{
					this.Label.text = "A teacher discovers that an answer sheet for an upcoming test is missing. She changes all of the questions for the test and keeps the new answer sheet with her at all times.";
					SchemeGlobals.SetSchemeStage(5, 100);
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 12)
			{
				Debug.Log("Phase 12.");
				this.ClubClosed = false;
				this.ClubKicked = false;
				if (this.ClubID < this.ClubArray.Length)
				{
					if (!ClubGlobals.GetClubClosed(this.ClubArray[this.ClubID]))
					{
						this.ClubManager.CheckClub(this.ClubArray[this.ClubID]);
						if (this.ClubManager.ClubMembers < 5)
						{
							ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
							this.Label.text = "The " + this.ClubNames[this.ClubID].ToString() + " no longer has enough members to remain operational. The school forces the club to disband.";
							this.ClubClosed = true;
							if (ClubGlobals.Club == this.ClubArray[this.ClubID])
							{
								ClubGlobals.Club = ClubType.None;
							}
						}
						if (this.ClubManager.LeaderMissing)
						{
							ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
							this.Label.text = string.Concat(new string[]
							{
								"The leader of the ",
								this.ClubNames[this.ClubID].ToString(),
								" has gone missing. The ",
								this.ClubNames[this.ClubID].ToString(),
								" cannot operate without its leader. The club disbands."
							});
							this.ClubClosed = true;
							if (ClubGlobals.Club == this.ClubArray[this.ClubID])
							{
								ClubGlobals.Club = ClubType.None;
							}
						}
						else if (this.ClubManager.LeaderDead)
						{
							ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
							this.Label.text = "The leader of the " + this.ClubNames[this.ClubID].ToString() + " is dead. The remaining members of the club decide to disband the club.";
							this.ClubClosed = true;
							if (ClubGlobals.Club == this.ClubArray[this.ClubID])
							{
								ClubGlobals.Club = ClubType.None;
							}
						}
					}
					if (!ClubGlobals.GetClubClosed(this.ClubArray[this.ClubID]) && !ClubGlobals.GetClubKicked(this.ClubArray[this.ClubID]) && ClubGlobals.Club == this.ClubArray[this.ClubID])
					{
						this.ClubManager.CheckGrudge(this.ClubArray[this.ClubID]);
						if (this.ClubManager.LeaderGrudge)
						{
							this.Label.text = string.Concat(new string[]
							{
								"Yandere-chan receives a text message from the president of the ",
								this.ClubNames[this.ClubID].ToString(),
								". Yandere-chan is no longer a member of the ",
								this.ClubNames[this.ClubID].ToString(),
								", and is not welcome in the ",
								this.ClubNames[this.ClubID].ToString(),
								" room."
							});
							ClubGlobals.SetClubKicked(this.ClubArray[this.ClubID], true);
							ClubGlobals.Club = ClubType.None;
							this.ClubKicked = true;
						}
						else if (this.ClubManager.ClubGrudge)
						{
							this.Label.text = string.Concat(new string[]
							{
								"Yandere-chan receives a text message from the president of the ",
								this.ClubNames[this.ClubID].ToString(),
								". There is someone in the ",
								this.ClubNames[this.ClubID].ToString(),
								" who hates and fears Yandere-chan. Yandere-chan is no longer a member of the ",
								this.ClubNames[this.ClubID].ToString(),
								", and is not welcome in the ",
								this.ClubNames[this.ClubID].ToString(),
								" room."
							});
							ClubGlobals.SetClubKicked(this.ClubArray[this.ClubID], true);
							ClubGlobals.Club = ClubType.None;
							this.ClubKicked = true;
						}
					}
					if (!this.ClubClosed && !this.ClubKicked)
					{
						this.ClubID++;
						this.UpdateScene();
					}
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 13)
			{
				Debug.Log("Phase 13.");
				if (this.TranqCase.Occupied)
				{
					this.Label.text = "Yandere-chan waits until the clock strikes midnight.\n\nUnder the cover of darkness, Yandere-chan travels back to school and sneaks inside of the main school building.\n\nYandere-chan returns to the instrument case that carries her unconscious victim.\n\nShe pushes the case back to her house, pretending to be a young musician returning home from a late-night show.\n\nYandere-chan drags the case down to her basement and ties up her victim.\n\nExhausted, Yandere-chan goes to sleep.";
					this.Phase++;
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 14)
			{
				Debug.Log("Phase 14.");
				if (this.ErectFence)
				{
					this.Label.text = "To prevent any other students from falling off of the school rooftop, the school erects a fence around the roof.";
					SchoolGlobals.RoofFence = true;
					this.ErectFence = false;
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 15)
			{
				this.Finish();
			}
			else if (this.Phase == 100)
			{
				this.Label.text = "Yandere-chan is arrested by the police. She will never have Senpai.";
				this.GameOver = true;
			}
			else if (this.Phase == 101)
			{
				int fingerprintID = this.WeaponManager.Weapons[this.WeaponID].FingerprintID;
				StudentScript studentScript = this.StudentManager.Students[fingerprintID];
				if (studentScript.Alive)
				{
					if (!studentScript.Tranquil)
					{
						this.Label.text = this.JSON.Students[fingerprintID].Name + " is arrested by the police.";
						StudentGlobals.SetStudentArrested(fingerprintID, true);
						this.Arrests++;
					}
					else
					{
						this.Label.text = this.JSON.Students[fingerprintID].Name + " is found asleep inside of a musical instrument case. The police assume that she hid herself inside of the box after committing murder, and arrest her.";
						StudentGlobals.SetStudentArrested(fingerprintID, true);
						this.ArrestID = fingerprintID;
						this.TranqCase.Occupied = false;
						this.Arrests++;
					}
				}
				else
				{
					bool flag = false;
					this.ID = 0;
					while (this.ID < this.VictimArray.Length)
					{
						if (this.VictimArray[this.ID] == fingerprintID && !studentScript.MurderSuicide)
						{
							flag = true;
						}
						this.ID++;
					}
					if (!flag)
					{
						this.Label.text = this.JSON.Students[fingerprintID].Name + " is dead. The police cannot perform an arrest.";
						this.DeadPerps++;
					}
					else
					{
						this.Label.text = this.JSON.Students[fingerprintID].Name + "'s fingerprints are on the same weapon that killed her. The police cannot solve this mystery.";
					}
				}
				this.Phase = 5;
			}
			else if (this.Phase == 102)
			{
				this.Label.text = "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police treat the incident as a murder case, and search the school for any other victims.";
				this.ErectFence = true;
				this.ID = 0;
				while (this.ID < this.Police.CorpseList.Length)
				{
					RagdollScript ragdollScript2 = this.Police.CorpseList[this.ID];
					if (ragdollScript2 != null && ragdollScript2.Suicide)
					{
						this.Police.Corpses--;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
			else if (this.Phase == 103)
			{
				this.Label.text = "The paramedics attempt to resuscitate the poisoned student, but they are unable to revive her. The police treat the incident as a murder case, and search the school for any other victims.";
				this.ID = 0;
				while (this.ID < this.Police.CorpseList.Length)
				{
					RagdollScript ragdollScript3 = this.Police.CorpseList[this.ID];
					if (ragdollScript3 != null && ragdollScript3.Poisoned)
					{
						this.Police.Corpses--;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
			else if (this.Phase == 104)
			{
				this.Label.text = "The police determine that " + this.Police.DrownedStudentName + " died from drowning. The police treat her death as a possible murder, and search the school for any other victims.";
				this.ID = 0;
				while (this.ID < this.Police.CorpseList.Length)
				{
					RagdollScript ragdollScript4 = this.Police.CorpseList[this.ID];
					if (ragdollScript4 != null && ragdollScript4.Drowned)
					{
						this.Police.Corpses--;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
			else if (this.Phase == 105)
			{
				this.Label.text = "The police determine that " + this.Police.ElectrocutedStudentName + " died from being electrocuted. The police treat her death as a possible murder, and search the school for any other victims.";
				this.ID = 0;
				while (this.ID < this.Police.CorpseList.Length)
				{
					RagdollScript ragdollScript5 = this.Police.CorpseList[this.ID];
					if (ragdollScript5 != null && ragdollScript5.Electrocuted)
					{
						this.Police.Corpses--;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
		}
	}

	private void Finish()
	{
		PlayerGlobals.Reputation = this.Reputation.Reputation;
		HomeGlobals.Night = true;
		this.Police.KillStudents();
		if (!this.TranqCase.Occupied)
		{
			SceneManager.LoadScene("HomeScene");
		}
		else
		{
			SchoolGlobals.KidnapVictim = this.TranqCase.VictimID;
			StudentGlobals.SetStudentKidnapped(this.TranqCase.VictimID, true);
			StudentGlobals.SetStudentSanity(this.TranqCase.VictimID, 100f);
			SceneManager.LoadScene("CalendarScene");
		}
	}
}
