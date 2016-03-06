using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class EndOfDayScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public WeaponManagerScript WeaponManager;

	public ClubManagerScript ClubManager;

	public HeartbrokenScript Heartbroken;

	public ReputationScript Reputation;

	public WeaponScript MurderWeapon;

	public TranqCaseScript TranqCase;

	public YandereScript Yandere;

	public RagdollScript Corpse;

	public PoliceScript Police;

	public JsonScript JSON;

	public GameObject MainCamera;

	public UISprite EndOfDayDarkness;

	public UILabel Label;

	public bool PoliceArrived;

	public bool ClubClosed;

	public bool ClubKicked;

	public bool GameOver;

	public bool Darken;

	public string VictimString;

	public int DeadPerps;

	public int Arrests;

	public int Corpses;

	public int Victims;

	public int Weapons;

	public int Phase;

	public int WeaponID;

	public int ArrestID;

	public int ClubID;

	public int ID;

	public string[] ClubNames;

	public int[] VictimArray;

	public int[] ClubArray;

	public EndOfDayScript()
	{
		this.VictimString = string.Empty;
		this.Phase = 1;
	}

	public virtual void Start()
	{
		int num = 1;
		Color color = this.EndOfDayDarkness.color;
		float num2 = color.a = (float)num;
		Color color2 = this.EndOfDayDarkness.color = color;
		this.audio.volume = (float)0;
		this.UpdateScene();
	}

	public virtual void Update()
	{
		if (this.EndOfDayDarkness.color.a == (float)0 && Input.GetButtonDown("A"))
		{
			this.Darken = true;
		}
		if (this.Darken)
		{
			float a = Mathf.MoveTowards(this.EndOfDayDarkness.color.a, (float)1, Time.deltaTime);
			Color color = this.EndOfDayDarkness.color;
			float num = color.a = a;
			Color color2 = this.EndOfDayDarkness.color = color;
			if (this.EndOfDayDarkness.color.a == (float)1)
			{
				if (!this.GameOver)
				{
					this.Darken = false;
					this.UpdateScene();
				}
				else
				{
					this.Heartbroken.transform.parent.transform.parent = null;
					this.Heartbroken.transform.parent.active = true;
					this.Heartbroken.Noticed = false;
					this.Heartbroken.Arrested = true;
					this.MainCamera.active = false;
					this.active = false;
					Time.timeScale = (float)1;
				}
			}
		}
		else
		{
			float a2 = Mathf.MoveTowards(this.EndOfDayDarkness.color.a, (float)0, Time.deltaTime);
			Color color3 = this.EndOfDayDarkness.color;
			float num2 = color3.a = a2;
			Color color4 = this.EndOfDayDarkness.color = color3;
		}
		this.audio.volume = Mathf.MoveTowards(this.audio.volume, (float)1, Time.deltaTime);
	}

	public virtual void UpdateScene()
	{
		if (this.PoliceArrived)
		{
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
					while (this.ID < Extensions.get_length(this.Police.CorpseList))
					{
						if (this.Police.CorpseList[this.ID] != null)
						{
							this.VictimArray[this.Corpses] = this.Police.CorpseList[this.ID].Student.StudentID;
							if (this.Corpses > 0)
							{
								this.VictimString += ", and ";
							}
							this.VictimString += this.Police.CorpseList[this.ID].Student.Name;
							this.Corpses++;
						}
						this.ID++;
					}
					if (this.Corpses == 1)
					{
						this.Label.text = "The police discover the corpse of " + this.VictimString + ".";
					}
					else
					{
						this.Label.text = "The police discover the corpses of " + this.VictimString + ".";
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
					this.ID = 0;
					this.MurderWeapon = null;
					while (this.ID < Extensions.get_length(this.WeaponManager.Weapons))
					{
						if (this.MurderWeapon == null && this.WeaponManager.Weapons[this.ID] != null && this.WeaponManager.Weapons[this.ID].Blood.enabled)
						{
							this.WeaponManager.Weapons[this.ID].Blood.enabled = false;
							this.MurderWeapon = this.WeaponManager.Weapons[this.ID];
							this.WeaponID = this.ID;
						}
						this.ID++;
					}
					this.ID = 0;
					this.Victims = 0;
					this.VictimString = string.Empty;
					while (this.ID < Extensions.get_length(this.MurderWeapon.Victims))
					{
						if (this.MurderWeapon.Victims[this.ID])
						{
							if (this.Victims > 0)
							{
								this.VictimString += ", and ";
							}
							this.VictimString += this.JSON.StudentNames[this.ID];
							this.Victims++;
						}
						this.ID++;
					}
					this.Label.text = "The police discover a " + this.MurderWeapon.Name + " that is stained with the blood of " + this.VictimString + ".";
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
					this.Label.text = "The police find the fingerprints of " + this.JSON.StudentNames[this.WeaponManager.Weapons[this.WeaponID].FingerprintID] + " on the weapon.";
					this.Phase = 101;
				}
			}
			else if (this.Phase == 5)
			{
				if (this.Yandere.Sanity > 33.33333f)
				{
					if (this.Yandere.Bloodiness > (float)0 || (this.Yandere.Gloved && this.Yandere.Gloves.Blood.enabled))
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
				else if (this.Yandere.Bloodiness == (float)0)
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
				this.Label.text = "The police discover " + this.JSON.StudentNames[this.TranqCase.VictimID] + " inside of a musical instrument case. However, she is unable to recall how she got inside of the case. The police are unable to determine what happened.";
				this.TranqCase.Occupied = false;
				this.Phase++;
			}
			else if (this.Phase == 7)
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
			else if (this.Phase == 8)
			{
				this.Label.text = "Yandere-chan stalks Senpai until he has returned home safely, and then returns to her own home.";
				this.Phase++;
			}
			else if (this.Phase == 9)
			{
				this.ClubClosed = false;
				this.ClubKicked = false;
				if (this.ClubID < Extensions.get_length(this.ClubArray))
				{
					if (PlayerPrefs.GetInt("Club_" + this.ClubArray[this.ClubID] + "_Closed") == 0)
					{
						this.ClubManager.CheckClub(this.ClubArray[this.ClubID]);
						if (this.ClubManager.ClubMembers < 5)
						{
							PlayerPrefs.SetInt("Club_" + this.ClubArray[this.ClubID] + "_Closed", 1);
							this.Label.text = "The " + this.ClubNames[this.ClubID] + " no longer has enough members to remain operational. The school forces the club to disband.";
							this.ClubClosed = true;
							if (PlayerPrefs.GetInt("Club") == this.ClubArray[this.ClubID])
							{
								PlayerPrefs.SetInt("Club", 0);
							}
						}
						if (this.ClubManager.LeaderMissing)
						{
							PlayerPrefs.SetInt("Club_" + this.ClubArray[this.ClubID] + "_Closed", 1);
							this.Label.text = "The leader of the " + this.ClubNames[this.ClubID] + " has gone missing. The " + this.ClubNames[this.ClubID] + " cannot operate without its leader. The club disbands.";
							this.ClubClosed = true;
							if (PlayerPrefs.GetInt("Club") == this.ClubArray[this.ClubID])
							{
								PlayerPrefs.SetInt("Club", 0);
							}
						}
						else if (this.ClubManager.LeaderDead)
						{
							PlayerPrefs.SetInt("Club_" + this.ClubArray[this.ClubID] + "_Closed", 1);
							this.Label.text = "The leader of the " + this.ClubNames[this.ClubID] + " is dead. The remaining members of the club decide to disband the club.";
							this.ClubClosed = true;
							if (PlayerPrefs.GetInt("Club") == this.ClubArray[this.ClubID])
							{
								PlayerPrefs.SetInt("Club", 0);
							}
						}
					}
					if (PlayerPrefs.GetInt("Club_" + this.ClubArray[this.ClubID] + "_Closed") == 0 && PlayerPrefs.GetInt("Club_" + this.ClubArray[this.ClubID] + "_Kicked") == 0 && PlayerPrefs.GetInt("Club") == this.ClubArray[this.ClubID])
					{
						this.ClubManager.CheckGrudge(this.ClubArray[this.ClubID]);
						if (this.ClubManager.LeaderGrudge)
						{
							this.Label.text = "Yandere-chan receives a text message from the president of the " + this.ClubNames[this.ClubID] + ". Yandere-chan is no longer a member of the " + this.ClubNames[this.ClubID] + ", and is not welcome in the " + this.ClubNames[this.ClubID] + " room.";
							PlayerPrefs.SetInt("Club_" + this.ClubArray[this.ClubID] + "_Kicked", 1);
							PlayerPrefs.SetInt("Club", 0);
							this.ClubKicked = true;
						}
						else if (this.ClubManager.ClubGrudge)
						{
							this.Label.text = "Yandere-chan receives a text message from the president of the " + this.ClubNames[this.ClubID] + ". There is someone in the " + this.ClubNames[this.ClubID] + " who hates and fears Yandere-chan. Yandere-chan is no longer a member of the " + this.ClubNames[this.ClubID] + ", and is not welcome in the " + this.ClubNames[this.ClubID] + " room.";
							PlayerPrefs.SetInt("Club_" + this.ClubArray[this.ClubID] + "_Kicked", 1);
							PlayerPrefs.SetInt("Club", 0);
							this.ClubKicked = true;
						}
					}
					if (!this.ClubClosed && !this.ClubKicked)
					{
						this.ClubID++;
						this.UpdateScene();
					}
				}
				else if (this.TranqCase.Occupied)
				{
					this.Phase++;
					this.UpdateScene();
				}
				else
				{
					this.Phase = 11;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 10)
			{
				this.Label.text = "Yandere-chan waits until the clock strikes midnight." + "\n" + "\n" + "Under the cover of darkness, Yandere-chan travels back to school and sneaks inside of the main school building." + "\n" + "\n" + "Yandere-chan returns to the instrument case that carries her unconscious victim." + "\n" + "\n" + "She pushes the case back to her house, pretending to be a young musician returning home from a late-night show." + "\n" + "\n" + "Yandere-chan drags the case down to her basement and ties up her victim." + "\n" + "\n" + "Exhausted, Yandere-chan goes to sleep.";
				this.Phase++;
			}
			else if (this.Phase == 11)
			{
				PlayerPrefs.SetFloat("Reputation", this.Reputation.Reputation);
				PlayerPrefs.SetInt("Night", 1);
				this.Police.KillStudents();
				if (!this.TranqCase.Occupied)
				{
					Application.LoadLevel("HomeScene");
				}
				else
				{
					PlayerPrefs.SetInt("Kidnapped", 1);
					PlayerPrefs.SetInt("KidnapVictim", this.TranqCase.VictimID);
					PlayerPrefs.SetInt("Student_" + this.TranqCase.VictimID + "_Kidnapped", 1);
					PlayerPrefs.SetFloat("Student_" + this.TranqCase.VictimID + "_Sanity", 100f);
					Application.LoadLevel("CalendarScene");
				}
			}
			else if (this.Phase == 100)
			{
				this.Label.text = "Yandere-chan is arrested by the police. She will never have Senpai.";
				this.GameOver = true;
			}
			else if (this.Phase == 101)
			{
				if (!this.StudentManager.Students[this.WeaponManager.Weapons[this.WeaponID].FingerprintID].Dead)
				{
					if (!this.StudentManager.Students[this.WeaponManager.Weapons[this.WeaponID].FingerprintID].Tranquil)
					{
						this.Label.text = this.JSON.StudentNames[this.WeaponManager.Weapons[this.WeaponID].FingerprintID] + " is arrested by the police.";
						PlayerPrefs.SetInt("Student_" + this.WeaponManager.Weapons[this.WeaponID].FingerprintID + "_Arrested", 1);
						this.Arrests++;
					}
					else
					{
						this.Label.text = this.JSON.StudentNames[this.WeaponManager.Weapons[this.WeaponID].FingerprintID] + " is found asleep inside of a musical instrument case. The police assume that she hid herself inside of the box after committing murder, and arrest her.";
						PlayerPrefs.SetInt("Student_" + this.WeaponManager.Weapons[this.WeaponID].FingerprintID + "_Arrested", 1);
						this.ArrestID = this.WeaponManager.Weapons[this.WeaponID].FingerprintID;
						this.TranqCase.Occupied = false;
						this.Arrests++;
					}
				}
				else
				{
					this.ID = 0;
					bool flag;
					while (this.ID < Extensions.get_length(this.VictimArray))
					{
						if (this.VictimArray[this.ID] == this.WeaponManager.Weapons[this.WeaponID].FingerprintID && !this.StudentManager.Students[this.WeaponManager.Weapons[this.WeaponID].FingerprintID].MurderSuicide)
						{
							flag = true;
						}
						this.ID++;
					}
					if (!flag)
					{
						this.Label.text = this.JSON.StudentNames[this.WeaponManager.Weapons[this.WeaponID].FingerprintID] + " is dead. The police cannot perform an arrest.";
						this.DeadPerps++;
					}
					else
					{
						this.Label.text = this.JSON.StudentNames[this.WeaponManager.Weapons[this.WeaponID].FingerprintID] + "'s fingerprints are on the same weapon that killed her. The police cannot solve this mystery.";
					}
				}
				this.Phase = 5;
			}
			else if (this.Phase == 102)
			{
				this.Label.text = "The police inspect the corpse of the student who appears to have killed herself. The police treat the incident as a murder case, and search the school for any other victims.";
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.Police.CorpseList))
				{
					if (this.Police.CorpseList[this.ID] != null && this.Police.CorpseList[this.ID].Suicide)
					{
						this.Police.CorpseList[this.ID] = null;
						this.Police.Corpses = this.Police.Corpses - 1;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
			else if (this.Phase == 103)
			{
				this.Label.text = "The paramedics attempt to resuscitate the poisoned student, but they are unable to revive her. The police treat the incident as a murder case, and search the school for any other victims.";
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.Police.CorpseList))
				{
					if (this.Police.CorpseList[this.ID] != null && this.Police.CorpseList[this.ID].Poisoned)
					{
						this.Police.CorpseList[this.ID] = null;
						this.Police.Corpses = this.Police.Corpses - 1;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
			else if (this.Phase == 104)
			{
				this.Label.text = "The police determine that " + this.Police.DrownedStudentName + " died from drowning. The police treat her death as a possible murder, and search the school for any other victims.";
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.Police.CorpseList))
				{
					if (this.Police.CorpseList[this.ID] != null && this.Police.CorpseList[this.ID].Drowned)
					{
						this.Police.CorpseList[this.ID] = null;
						this.Police.Corpses = this.Police.Corpses - 1;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
			else if (this.Phase == 105)
			{
				this.Label.text = "The police determine that " + this.Police.ElectrocutedStudentName + " died from being electrocuted. The police treat her death as a possible murder, and search the school for any other victims.";
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.Police.CorpseList))
				{
					if (this.Police.CorpseList[this.ID] != null && this.Police.CorpseList[this.ID].Electrocuted)
					{
						this.Police.CorpseList[this.ID] = null;
						this.Police.Corpses = this.Police.Corpses - 1;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
		}
	}

	public virtual void Main()
	{
	}
}
