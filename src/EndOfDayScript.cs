using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfDayScript : MonoBehaviour
{
	public SecuritySystemScript SecuritySystem;

	public StudentManagerScript StudentManager;

	public WeaponManagerScript WeaponManager;

	public ClubManagerScript ClubManager;

	public HeartbrokenScript Heartbroken;

	public IncineratorScript Incinerator;

	public WoodChipperScript WoodChipper;

	public ReputationScript Reputation;

	public DumpsterLidScript Dumpster;

	public CounselorScript Counselor;

	public WeaponScript MurderWeapon;

	public TranqCaseScript TranqCase;

	public YandereScript Yandere;

	public RagdollScript Corpse;

	public PoliceScript Police;

	public JsonScript JSON;

	public GardenHoleScript[] GardenHoles;

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

	public int FragileTarget;

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
					this.Label.text = "The police arrive at school, and discover what appears to be the scene of a murder-suicide.";
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
					List<string> list = new List<string>();
					foreach (RagdollScript ragdollScript in this.Police.CorpseList)
					{
						if (ragdollScript != null)
						{
							this.VictimArray[this.Corpses] = ragdollScript.Student.StudentID;
							list.Add(ragdollScript.Student.Name);
							this.Corpses++;
						}
					}
					list.Sort();
					string text = "The police discover the corpse" + ((list.Count != 1) ? "s" : string.Empty) + " of ";
					if (list.Count == 1)
					{
						this.Label.text = text + list[0] + ".";
					}
					else if (list.Count == 2)
					{
						this.Label.text = string.Concat(new string[]
						{
							text,
							list[0],
							" and ",
							list[1],
							"."
						});
					}
					else
					{
						StringBuilder stringBuilder = new StringBuilder();
						for (int j = 0; j < list.Count - 1; j++)
						{
							stringBuilder.Append(list[j] + ", ");
						}
						stringBuilder.Append("and " + list[list.Count - 1] + ".");
						this.Label.text = text + stringBuilder.ToString();
					}
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
					List<string> list2 = new List<string>();
					this.ID = 0;
					while (this.ID < this.MurderWeapon.Victims.Length)
					{
						if (this.MurderWeapon.Victims[this.ID])
						{
							list2.Add(this.JSON.Students[this.ID].Name);
						}
						this.ID++;
					}
					list2.Sort();
					this.Victims = list2.Count;
					string name = this.MurderWeapon.Name;
					string str = (name[name.Length - 1] == 's') ? (name.ToLower() + " that are") : ("a " + name.ToLower() + " that is");
					string text2 = "The police discover " + str + " stained with the blood of ";
					if (list2.Count == 1)
					{
						this.Label.text = text2 + list2[0] + ".";
					}
					else if (list2.Count == 2)
					{
						this.Label.text = string.Concat(new string[]
						{
							text2,
							list2[0],
							" and ",
							list2[1],
							"."
						});
					}
					else
					{
						StringBuilder stringBuilder2 = new StringBuilder();
						for (int k = 0; k < list2.Count - 1; k++)
						{
							stringBuilder2.Append(list2[k] + ", ");
						}
						stringBuilder2.Append("and " + list2[list2.Count - 1] + ".");
						this.Label.text = text2 + stringBuilder2.ToString();
					}
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
				if (SchoolGlobals.HighSecurity)
				{
					if (!this.SecuritySystem.Evidence)
					{
						this.Label.text = "The police investigate the security camera recordings, but cannot find anything incriminating in the footage.";
						this.Phase++;
					}
					else if (!this.SecuritySystem.Masked)
					{
						this.Label.text = "The police investigate the security camera recordings, and find incriminating footage of Yandere-chan.";
						this.Phase = 100;
					}
					else
					{
						this.Label.text = "The police investigate the security camera recordings, and find footage of a suspicious masked person.";
						this.Police.MaskReported = true;
						this.Phase = 100;
					}
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 6)
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
								this.Phase = 8;
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
						this.Label.text = "The police question all students in the school, including Yandere-chan. The police are unable to link Yandere-chan to any crimes.";
						if (!this.TranqCase.Occupied)
						{
							this.Phase = 8;
						}
						else if (this.TranqCase.VictimID == this.ArrestID)
						{
							this.Phase = 8;
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
			else if (this.Phase == 7)
			{
				this.Label.text = "The police discover " + this.JSON.Students[this.TranqCase.VictimID].Name + " inside of a musical instrument case. However, she is unable to recall how she got inside of the case. The police are unable to determine what happened.";
				StudentGlobals.SetStudentKidnapped(this.TranqCase.VictimID, false);
				StudentGlobals.SetStudentMissing(this.TranqCase.VictimID, false);
				this.TranqCase.VictimClubType = ClubType.None;
				this.TranqCase.VictimID = 0;
				this.TranqCase.Occupied = false;
				this.Phase++;
			}
			else if (this.Phase == 8)
			{
				if (this.Police.MaskReported)
				{
					GameGlobals.MasksBanned = true;
					if (this.SecuritySystem.Masked)
					{
						this.Label.text = "In security camera footage, the killer was wearing a mask. As a result, the police are unable to gather meaningful information about the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward.";
					}
					else
					{
						this.Label.text = "Witnesses state that the killer was wearing a mask. As a result, the police are unable to gather meaningful information about the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward.";
					}
					this.Police.MaskReported = false;
					this.Phase++;
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 9)
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
			else if (this.Phase == 10)
			{
				this.Label.text = "Yandere-chan stalks Senpai until he has returned home safely, and then returns to her own home.";
				this.Phase++;
			}
			else if (this.Phase == 11)
			{
				if (!StudentGlobals.GetStudentDying(30) && !StudentGlobals.GetStudentDead(30) && !StudentGlobals.GetStudentArrested(30))
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
			else if (this.Phase == 12)
			{
				Debug.Log("Phase 12.");
				if (SchemeGlobals.GetSchemeStage(2) == 3 && !StudentGlobals.GetStudentDying(30) && !StudentGlobals.GetStudentDead(30) && !StudentGlobals.GetStudentArrested(30))
				{
					this.Label.text = "Kokona discovers Sakyu's ring inside of her book bag. She returns the ring to Sakyu, who decides to never let it out of her sight again.";
					SchemeGlobals.SetSchemeStage(2, 100);
				}
				else if (SchemeGlobals.GetSchemeStage(5) > 1 && SchemeGlobals.GetSchemeStage(5) < 5)
				{
					this.Label.text = "A faculty member discovers that an answer sheet for an upcoming test is missing. She changes all of the questions for the test and keeps the new answer sheet with her at all times.";
					SchemeGlobals.SetSchemeStage(5, 100);
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 13)
			{
				Debug.Log("Phase 13 - checking for clubs shutting down.");
				this.ClubClosed = false;
				this.ClubKicked = false;
				if (this.ClubID < this.ClubArray.Length)
				{
					if (!ClubGlobals.GetClubClosed(this.ClubArray[this.ClubID]))
					{
						Debug.Log("Right now, we're checking the " + this.ClubNames[this.ClubID].ToString() + ".");
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
							this.Label.text = string.Concat(new string[]
							{
								"The leader of the ",
								this.ClubNames[this.ClubID].ToString(),
								" is gone. The ",
								this.ClubNames[this.ClubID].ToString(),
								" cannot operate without its leader. The club disbands."
							});
							this.ClubClosed = true;
							if (ClubGlobals.Club == this.ClubArray[this.ClubID])
							{
								ClubGlobals.Club = ClubType.None;
							}
						}
						else if (this.ClubManager.LeaderAshamed)
						{
							ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
							this.Label.text = "The leader of the " + this.ClubNames[this.ClubID].ToString() + " has unexpectedly disbanded the club without explanation.";
							this.ClubClosed = true;
							this.ClubManager.LeaderAshamed = false;
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
			else if (this.Phase == 14)
			{
				Debug.Log("Phase 14.");
				if (this.TranqCase.Occupied)
				{
					this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 1f);
					this.Label.text = "Yandere-chan waits until the clock strikes midnight.\n\nUnder the cover of darkness, Yandere-chan travels back to school and sneaks inside of the main school building.\n\nYandere-chan returns to the instrument case that carries her unconscious victim.\n\nShe pushes the case back to her house, pretending to be a young musician returning home from a late-night show.\n\nYandere-chan drags the case down to her basement and ties up her victim.\n\nExhausted, Yandere-chan goes to sleep.";
					this.Phase++;
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 15)
			{
				Debug.Log("Phase 15.");
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
			else if (this.Phase == 16)
			{
				Debug.Log("Phase 16.");
				if (!SchoolGlobals.HighSecurity && this.Police.CouncilDeath)
				{
					this.Label.text = "The student council president has ordered the implementation of heightened security precautions. Security cameras and metal detectors are now present at school.";
					this.Police.CouncilDeath = false;
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 17)
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
						this.Label.text = this.JSON.Students[fingerprintID].Name + "'s fingerprints are on the same weapon that killed them. The police cannot solve this mystery.";
					}
				}
				this.Phase = 6;
			}
			else if (this.Phase == 102)
			{
				if (this.Police.SuicideStudent.activeInHierarchy)
				{
					this.Label.text = "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police treat the incident as a murder case, and search the school for any other victims.";
					this.ErectFence = true;
				}
				else
				{
					this.Label.text = "The police attempt to determine whether or not a student fell to their death from the school rooftop. The police are unable to reach a conclusion.";
				}
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
		if (this.StudentManager.Students[SchoolGlobals.KidnapVictim] != null && this.StudentManager.Students[SchoolGlobals.KidnapVictim].Ragdoll.enabled)
		{
			SchoolGlobals.KidnapVictim = 0;
		}
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
		if (this.Dumpster.StudentToGoMissing > 0)
		{
			this.Dumpster.SetVictimMissing();
		}
		this.ID = 0;
		while (this.ID < this.GardenHoles.Length)
		{
			this.GardenHoles[this.ID].EndOfDayCheck();
			this.ID++;
		}
		this.Incinerator.SetVictimsMissing();
		this.WoodChipper.SetVictimsMissing();
		if (this.FragileTarget > 0)
		{
			Debug.Log("Setting target for Fragile student.");
			StudentGlobals.SetFragileTarget(this.FragileTarget);
			StudentGlobals.SetStudentFragileSlave(5);
		}
		if (this.StudentManager.ReactedToGameLeader)
		{
			SchoolGlobals.ReactedToGameLeader = true;
		}
	}
}
