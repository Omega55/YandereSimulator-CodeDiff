using System;
using System.Collections;
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

	public VoidGoddessScript VoidGoddess;

	public WoodChipperScript WoodChipper;

	public ReputationScript Reputation;

	public DumpsterLidScript Dumpster;

	public CounselorScript Counselor;

	public WeaponScript MurderWeapon;

	public TranqCaseScript TranqCase;

	public YandereScript Yandere;

	public RagdollScript Corpse;

	public StudentScript Patsy;

	public PoliceScript Police;

	public Transform EODCamera;

	public ClockScript Clock;

	public JsonScript JSON;

	public GardenHoleScript[] GardenHoles;

	public Animation[] CopAnimation;

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

	public int ClothingWithRedPaint;

	public int FragileTarget;

	public int NewFriends;

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

	public GameObject TextWindow;

	public GameObject Cops;

	public GameObject SearchingCop;

	public GameObject MurderScene;

	public GameObject ShruggingCops;

	public GameObject TabletCop;

	public GameObject SecuritySystemScene;

	public GameObject OpenTranqCase;

	public GameObject ClosedTranqCase;

	public GameObject GaudyRing;

	public GameObject AnswerSheet;

	public GameObject Fence;

	public GameObject SCP;

	public GameObject ArrestingCops;

	public GameObject Mask;

	public StudentScript KidnappedVictim;

	public Renderer TabletPortrait;

	public Transform CardboardBox;

	public void Start()
	{
		this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, 1f);
		this.PreviouslyActivated = true;
		base.GetComponent<AudioSource>().volume = 0f;
		this.Clock.enabled = false;
		this.Clock.MainLight.color = new Color(1f, 1f, 1f, 1f);
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
		this.UpdateScene();
		this.CopAnimation[5]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
		this.CopAnimation[6]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
		this.CopAnimation[7]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
		Time.timeScale = 1f;
		for (int i = 1; i < 6; i++)
		{
			this.Yandere.CharacterAnimation[this.Yandere.CreepyIdles[i]].weight = 0f;
			this.Yandere.CharacterAnimation[this.Yandere.CreepyWalks[i]].weight = 0f;
		}
		Debug.Log("BloodParent.childCount is: " + this.Police.BloodParent.childCount);
		IEnumerator enumerator = this.Police.BloodParent.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				PickUpScript component = transform.gameObject.GetComponent<PickUpScript>();
				if (component != null && component.RedPaint)
				{
					this.ClothingWithRedPaint++;
				}
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		Debug.Log("Clothing with red paint is: " + this.ClothingWithRedPaint);
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.EndOfDayDarkness.color = new Color(0f, 0f, 0f, 1f);
			this.Darken = true;
		}
		if (this.EndOfDayDarkness.color.a == 0f && Input.GetButtonDown("A"))
		{
			this.Darken = true;
		}
		if (this.Darken)
		{
			this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, Mathf.MoveTowards(this.EndOfDayDarkness.color.a, 1f, Time.deltaTime * 2f));
			if (this.EndOfDayDarkness.color.a == 1f)
			{
				this.Yandere.transform.parent = null;
				this.Yandere.transform.position = new Vector3(0f, 0f, -75f);
				this.EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
				this.EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0f);
				if (this.KidnappedVictim != null)
				{
					this.KidnappedVictim.gameObject.SetActive(false);
				}
				this.CardboardBox.parent = null;
				this.SearchingCop.SetActive(false);
				this.MurderScene.SetActive(false);
				this.Cops.SetActive(false);
				this.TabletCop.SetActive(false);
				this.ShruggingCops.SetActive(false);
				this.SecuritySystemScene.SetActive(false);
				this.OpenTranqCase.SetActive(false);
				this.ClosedTranqCase.SetActive(false);
				this.GaudyRing.SetActive(false);
				this.AnswerSheet.SetActive(false);
				this.Fence.SetActive(false);
				this.SCP.SetActive(false);
				this.ArrestingCops.SetActive(false);
				this.Mask.SetActive(false);
				this.Yandere.Senpai.gameObject.SetActive(false);
				if (this.Patsy != null)
				{
					this.Patsy.gameObject.SetActive(false);
				}
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
			this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, Mathf.MoveTowards(this.EndOfDayDarkness.color.a, 0f, Time.deltaTime * 2f));
		}
		AudioSource component = base.GetComponent<AudioSource>();
		component.volume = Mathf.MoveTowards(component.volume, 1f, Time.deltaTime * 2f);
	}

	public void UpdateScene()
	{
		this.ID = 0;
		while (this.ID < this.WeaponManager.Weapons.Length)
		{
			if (this.WeaponManager.Weapons[this.ID] != null)
			{
				this.WeaponManager.Weapons[this.ID].gameObject.SetActive(false);
			}
			this.ID++;
		}
		if (this.PoliceArrived)
		{
			if (Input.GetKeyDown(KeyCode.Backspace))
			{
				this.Finish();
			}
			if (this.Phase == 1)
			{
				this.CopAnimation[1]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
				this.CopAnimation[2]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
				this.CopAnimation[3]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
				this.Cops.SetActive(true);
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
						if (this.Police.LimbParent.childCount > 0)
						{
							if (this.Police.LimbParent.childCount == 1)
							{
								this.Label.text = "The police find a severed body part at school.";
							}
							else
							{
								this.Label.text = "The police find multiple severed body parts at school.";
							}
							this.MurderScene.SetActive(true);
						}
						else
						{
							this.SearchingCop.SetActive(true);
							if (this.Police.BloodParent.childCount - this.ClothingWithRedPaint > 0)
							{
								this.Label.text = "The police find mysterious blood stains, but are unable to locate any corpses on school grounds.";
							}
							else if (this.ClothingWithRedPaint == 0)
							{
								this.Label.text = "The police are unable to locate any corpses on school grounds.";
							}
							else
							{
								this.Label.text = "The police find clothing that is stained with red paint, but are unable to locate any actual blood stains, and cannot locate any corpses, either.";
							}
						}
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
					this.MurderScene.SetActive(true);
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
						this.Label.text = "The police discover multiple corpses on school grounds.";
					}
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.WeaponManager.CheckWeapons();
				if (this.WeaponManager.MurderWeapons == 0)
				{
					this.ShruggingCops.SetActive(true);
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
								if (!weaponScript.AlreadyExamined)
								{
									weaponScript.gameObject.SetActive(true);
									weaponScript.AlreadyExamined = true;
									this.MurderWeapon = weaponScript;
									this.WeaponID = this.ID;
								}
								else
								{
									weaponScript.gameObject.SetActive(false);
								}
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
						StringBuilder stringBuilder = new StringBuilder();
						for (int j = 0; j < list2.Count - 1; j++)
						{
							stringBuilder.Append(list2[j] + ", ");
						}
						stringBuilder.Append("and " + list2[list2.Count - 1] + ".");
						this.Label.text = text2 + stringBuilder.ToString();
					}
					this.Weapons++;
					this.Phase++;
					this.MurderWeapon.transform.parent = base.transform;
					this.MurderWeapon.transform.localPosition = new Vector3(0.6f, 1.4f, -1.5f);
					this.MurderWeapon.transform.localEulerAngles = new Vector3(-45f, 90f, -90f);
					this.MurderWeapon.MyRigidbody.useGravity = false;
					this.MurderWeapon.Rotate = true;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.MurderWeapon.FingerprintID == 0)
				{
					this.ShruggingCops.SetActive(true);
					this.Label.text = "The police find no fingerprints on the weapon.";
					this.Phase = 3;
				}
				else if (this.MurderWeapon.FingerprintID == 100)
				{
					this.TeleportYandere();
					this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
					this.Label.text = "The police find Ayano's fingerprints on the weapon.";
					this.Phase = 100;
				}
				else
				{
					int fingerprintID = this.WeaponManager.Weapons[this.WeaponID].FingerprintID;
					this.TabletCop.SetActive(true);
					this.CopAnimation[4]["scienceTablet_00"].speed = 0f;
					this.TabletPortrait.material.mainTexture = this.VoidGoddess.Portraits[fingerprintID].mainTexture;
					this.Label.text = "The police find the fingerprints of " + this.JSON.Students[fingerprintID].Name + " on the weapon.";
					this.Phase = 101;
				}
			}
			else if (this.Phase == 5)
			{
				if (SchoolGlobals.HighSecurity)
				{
					this.SecuritySystemScene.SetActive(true);
					if (!this.SecuritySystem.Evidence)
					{
						this.Label.text = "The police investigate the security camera recordings, but cannot find anything incriminating in the footage.";
						this.Phase++;
					}
					else if (!this.SecuritySystem.Masked)
					{
						this.Label.text = "The police investigate the security camera recordings, and find incriminating footage of Ayano.";
						this.Phase = 100;
					}
					else
					{
						this.Label.text = "The police investigate the security camera recordings, and find footage of a suspicious masked person.";
						this.Police.MaskReported = true;
						this.Phase++;
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
				this.ShruggingCops.SetActive(false);
				if (this.Yandere.Sanity > 33.33333f)
				{
					if ((this.Yandere.Bloodiness > 0f && !this.Yandere.RedPaint) || (this.Yandere.Gloved && this.Yandere.Gloves.Blood.enabled))
					{
						if (this.Arrests == 0)
						{
							this.TeleportYandere();
							this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
							this.Label.text = "The police notice that Ayano's clothing is bloody. They confirm that the blood is not hers. Ayano is unable to convince the police that she did not commit murder.";
							this.Phase = 100;
						}
						else
						{
							this.TeleportYandere();
							this.Yandere.CharacterAnimation["YandereConfessionRejected"].time = 4f;
							this.Yandere.CharacterAnimation.Play("YandereConfessionRejected");
							this.Label.text = "The police notice that Ayano's clothing is bloody. They confirm that the blood is not hers. Ayano is able to convince the police that she was splashed with blood while witnessing a murder.";
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
					else if (this.Police.BloodyClothing - this.ClothingWithRedPaint > 0)
					{
						this.TeleportYandere();
						this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
						this.Label.text = "The police find bloody clothing that has traces of Ayano's DNA. Ayano is unable to convince the police that she did not commit murder.";
						this.Phase = 100;
					}
					else
					{
						this.TeleportYandere();
						this.Yandere.CharacterAnimation["YandereConfessionRejected"].time = 4f;
						this.Yandere.CharacterAnimation.Play("YandereConfessionRejected");
						this.Label.text = "The police question all students in the school, including Ayano. The police are unable to link Ayano to any crimes.";
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
				else
				{
					this.TeleportYandere();
					this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
					if (this.Yandere.Bloodiness == 0f)
					{
						this.Label.text = "The police question Ayano, who exhibits extremely unusual behavior. The police decide to investigate Ayano further, and eventually learn of her crimes.";
						this.Phase = 100;
					}
					else
					{
						this.Label.text = "The police notice that Ayano is covered in blood and exhibiting extremely unusual behavior. The police decide to investigate Ayano further, and eventually learn of her crimes.";
						this.Phase = 100;
					}
				}
			}
			else if (this.Phase == 7)
			{
				this.KidnappedVictim = this.StudentManager.Students[this.TranqCase.VictimID];
				this.KidnappedVictim.gameObject.SetActive(true);
				this.KidnappedVictim.Ragdoll.Zs.SetActive(false);
				this.KidnappedVictim.transform.parent = base.transform;
				this.KidnappedVictim.transform.localPosition = new Vector3(0f, 0.145f, 0f);
				this.KidnappedVictim.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
				this.KidnappedVictim.CharacterAnimation.Play("f02_sit_06");
				this.KidnappedVictim.WhiteQuestionMark.SetActive(true);
				this.OpenTranqCase.SetActive(true);
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
					this.Mask.SetActive(true);
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
				this.Cops.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				this.Cops.SetActive(true);
				if (this.Arrests == 0)
				{
					if (this.DeadPerps == 0)
					{
						this.Label.text = "The police do not have enough evidence to perform an arrest. The police investigation ends, and students are free to leave.";
					}
					else
					{
						this.Label.text = "The police conclude that a murder-suicide took place, but are unable to take any further action. The police investigation ends, and students are free to leave.";
					}
				}
				else if (this.Arrests == 1)
				{
					this.Label.text = "The police believe that they have arrested the perpetrator of the crime. The police investigation ends, and students are free to leave.";
				}
				else
				{
					this.Label.text = "The police believe that they have arrested the perpetrators of the crimes. The police investigation ends, and students are free to leave.";
				}
				this.Phase++;
			}
			else if (this.Phase == 10)
			{
				this.Yandere.Senpai.parent = base.transform;
				this.Yandere.Senpai.gameObject.SetActive(true);
				this.Yandere.Senpai.localPosition = new Vector3(0f, 0f, 0f);
				this.Yandere.Senpai.localEulerAngles = new Vector3(0f, 180f, 0f);
				this.Yandere.Senpai.GetComponent<StudentScript>().EmptyHands();
				this.Yandere.Senpai.GetComponent<StudentScript>().CharacterAnimation.Play(this.Yandere.Senpai.GetComponent<StudentScript>().WalkAnim);
				this.Yandere.LookAt.enabled = true;
				this.Yandere.MyController.enabled = false;
				this.Yandere.transform.parent = base.transform;
				this.Yandere.transform.localPosition = new Vector3(2.5f, 0f, 2.5f);
				this.Yandere.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
				this.Yandere.CharacterAnimation.Play(this.Yandere.WalkAnim);
				Physics.SyncTransforms();
				this.Label.text = "Ayano stalks Senpai until he has returned home safely, and then returns to her own home.";
				this.Phase++;
			}
			else if (this.Phase == 11)
			{
				if (!StudentGlobals.GetStudentDying(30) && !StudentGlobals.GetStudentDead(30) && !StudentGlobals.GetStudentArrested(30))
				{
					if (this.Counselor.LectureID > 0)
					{
						this.Yandere.gameObject.SetActive(false);
						for (int k = 1; k < 101; k++)
						{
							this.StudentManager.DisableStudent(k);
						}
						this.EODCamera.position = new Vector3(-18.5f, 1f, 6.5f);
						this.EODCamera.eulerAngles = new Vector3(0f, -45f, 0f);
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
				if (SchemeGlobals.GetSchemeStage(2) == 3)
				{
					if (!StudentGlobals.GetStudentDying(30) && !StudentGlobals.GetStudentDead(30) && !StudentGlobals.GetStudentArrested(30))
					{
						this.GaudyRing.SetActive(true);
						this.Label.text = "Kokona discovers Sakyu's ring inside of her book bag. She returns the ring to Sakyu, who decides to stop bringing it to school.";
						SchemeGlobals.SetSchemeStage(2, 100);
					}
					else
					{
						this.GaudyRing.SetActive(true);
						this.Label.text = "Sakyu Basu's ring is permanently lost.";
						SchemeGlobals.SetSchemeStage(2, 100);
					}
				}
				else if (SchemeGlobals.GetSchemeStage(5) > 1 && SchemeGlobals.GetSchemeStage(5) < 5)
				{
					this.AnswerSheet.SetActive(true);
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
				this.ClubClosed = false;
				this.ClubKicked = false;
				float d = 1.2f;
				if (this.ClubID < this.ClubArray.Length)
				{
					if (!ClubGlobals.GetClubClosed(this.ClubArray[this.ClubID]))
					{
						this.ClubManager.CheckClub(this.ClubArray[this.ClubID]);
						if (this.ClubManager.ClubMembers < 5)
						{
							this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
							this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
							this.EODCamera.Translate(Vector3.forward * d, Space.Self);
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
							this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
							this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
							this.EODCamera.Translate(Vector3.forward * d, Space.Self);
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
							this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
							this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
							this.EODCamera.Translate(Vector3.forward * d, Space.Self);
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
							this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
							this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
							this.EODCamera.Translate(Vector3.forward * d, Space.Self);
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
							this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
							this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
							this.EODCamera.Translate(Vector3.forward * d, Space.Self);
							this.Label.text = string.Concat(new string[]
							{
								"Ayano receives a text message from the president of the ",
								this.ClubNames[this.ClubID].ToString(),
								". Ayano is no longer a member of the ",
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
							this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
							this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
							this.EODCamera.Translate(Vector3.forward * d, Space.Self);
							this.Label.text = string.Concat(new string[]
							{
								"Ayano receives a text message from the president of the ",
								this.ClubNames[this.ClubID].ToString(),
								". There is someone in the ",
								this.ClubNames[this.ClubID].ToString(),
								" who hates and fears Ayano. Ayano is no longer a member of the ",
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
					this.ClubManager.LeaderAshamed = false;
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 14)
			{
				if (this.TranqCase.Occupied)
				{
					this.ClosedTranqCase.SetActive(true);
					this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 1f);
					this.Label.text = "Ayano waits until midnight, sneaks into school, and returns to the musical instrument case that contains her unconscious victim. She pushes the case back to her house and ties  the victim to a chair in her basement.";
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
				if (this.ErectFence)
				{
					this.Fence.SetActive(true);
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
				if (!SchoolGlobals.HighSecurity && this.Police.CouncilDeath)
				{
					this.SCP.SetActive(true);
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
				this.Yandere.MyController.enabled = false;
				this.Yandere.transform.parent = base.transform;
				this.Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
				this.Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				this.Yandere.CharacterAnimation.Play("f02_handcuffs_00");
				this.Yandere.Handcuffs.SetActive(true);
				this.ArrestingCops.SetActive(true);
				Physics.SyncTransforms();
				this.Label.text = "Ayano is arrested by the police. She will never have Senpai.";
				this.GameOver = true;
			}
			else if (this.Phase == 101)
			{
				int fingerprintID2 = this.WeaponManager.Weapons[this.WeaponID].FingerprintID;
				StudentScript studentScript = this.StudentManager.Students[fingerprintID2];
				if (studentScript.Alive)
				{
					this.Patsy = this.StudentManager.Students[fingerprintID2];
					if (this.Patsy.WeaponBag != null)
					{
						this.Patsy.WeaponBag.SetActive(false);
					}
					this.Patsy.EmptyHands();
					this.Patsy.SpeechLines.Stop();
					this.Patsy.Handcuffs.SetActive(true);
					this.Patsy.gameObject.SetActive(true);
					this.Patsy.Ragdoll.Zs.SetActive(false);
					this.Patsy.MyController.enabled = false;
					this.Patsy.transform.parent = base.transform;
					this.Patsy.transform.localPosition = new Vector3(0f, 0f, 0f);
					this.Patsy.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					this.Patsy.ShoeRemoval.enabled = false;
					if (this.StudentManager.Students[fingerprintID2].Male)
					{
						this.StudentManager.Students[fingerprintID2].CharacterAnimation.Play("handcuffs_00");
					}
					else
					{
						this.StudentManager.Students[fingerprintID2].CharacterAnimation.Play("f02_handcuffs_00");
					}
					this.ArrestingCops.SetActive(true);
					if (!studentScript.Tranquil)
					{
						this.Label.text = this.JSON.Students[fingerprintID2].Name + " is arrested by the police.";
						StudentGlobals.SetStudentArrested(fingerprintID2, true);
						this.Arrests++;
					}
					else
					{
						this.Label.text = this.JSON.Students[fingerprintID2].Name + " is found asleep inside of a musical instrument case. The police assume that she hid herself inside of the box after committing murder, and arrest her.";
						StudentGlobals.SetStudentArrested(fingerprintID2, true);
						this.ArrestID = fingerprintID2;
						this.TranqCase.Occupied = false;
						this.Arrests++;
					}
				}
				else
				{
					this.ShruggingCops.SetActive(true);
					bool flag = false;
					this.ID = 0;
					while (this.ID < this.VictimArray.Length)
					{
						if (this.VictimArray[this.ID] == fingerprintID2 && !studentScript.MurderSuicide)
						{
							flag = true;
						}
						this.ID++;
					}
					if (!flag)
					{
						this.Label.text = this.JSON.Students[fingerprintID2].Name + " is dead. The police cannot perform an arrest.";
						this.DeadPerps++;
					}
					else
					{
						this.Label.text = this.JSON.Students[fingerprintID2].Name + "'s fingerprints are on the same weapon that killed them. The police cannot solve this mystery.";
					}
				}
				this.Phase = 3;
			}
			else if (this.Phase == 102)
			{
				if (this.Police.SuicideStudent.activeInHierarchy)
				{
					this.MurderScene.SetActive(true);
					this.Label.text = "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police treat the incident as a murder case, and search the school for any other victims.";
					this.ErectFence = true;
				}
				else
				{
					this.ShruggingCops.SetActive(true);
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
				this.MurderScene.SetActive(true);
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
				this.MurderScene.SetActive(true);
				this.Label.text = "The police determine that " + this.Police.DrownedStudentName + " died from drowning. The police treat the death as a possible murder, and search the school for any other victims.";
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
				this.MurderScene.SetActive(true);
				this.Label.text = "The police determine that " + this.Police.ElectrocutedStudentName + " died from being electrocuted. The police treat the death as a possible murder, and search the school for any other victims.";
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

	private void TeleportYandere()
	{
		this.Yandere.MyController.enabled = false;
		this.Yandere.transform.parent = base.transform;
		this.Yandere.transform.localPosition = new Vector3(0.75f, 0.33333f, -1.9f);
		this.Yandere.transform.localEulerAngles = new Vector3(-22.5f, 157.5f, 0f);
		Physics.SyncTransforms();
	}

	private void Finish()
	{
		PlayerGlobals.Reputation = this.Reputation.Reputation;
		HomeGlobals.Night = true;
		this.Police.KillStudents();
		if (this.Police.Suspended)
		{
			DateGlobals.PassDays = this.Police.SuspensionLength;
		}
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
		if (this.NewFriends > 0)
		{
			PlayerGlobals.Friends += this.NewFriends;
		}
		if (this.Yandere.Alerts > 0)
		{
			PlayerGlobals.Alerts += this.Yandere.Alerts;
		}
		SchoolGlobals.SchoolAtmosphere += (float)this.Arrests * 0.05f;
		if (this.Counselor.ExpelledDelinquents)
		{
			SchoolGlobals.SchoolAtmosphere += 0.25f;
		}
		this.WeaponManager.TrackDumpedWeapons();
	}
}
