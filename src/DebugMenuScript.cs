using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenuScript : MonoBehaviour
{
	public FakeStudentSpawnerScript FakeStudentSpawner;

	public DelinquentManagerScript DelinquentManager;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public WeaponManagerScript WeaponManager;

	public ReputationScript Reputation;

	public CounselorScript Counselor;

	public YandereScript Yandere;

	public BentoScript Bento;

	public ClockScript Clock;

	public PrayScript Turtle;

	public ZoomScript Zoom;

	public AstarPath Astar;

	public OsanaFridayBeforeClassEvent1Script OsanaEvent1;

	public OsanaFridayBeforeClassEvent2Script OsanaEvent2;

	public OsanaFridayLunchEventScript OsanaEvent3;

	public GameObject EasterEggWindow;

	public GameObject SacrificialArm;

	public GameObject DebugPoisons;

	public GameObject CircularSaw;

	public GameObject GreenScreen;

	public GameObject Knife;

	public Transform[] TeleportSpot;

	public Transform RooftopSpot;

	public Transform MidoriSpot;

	public Transform Lockers;

	public GameObject MissionModeWindow;

	public GameObject Window;

	public bool WaitingForNumber;

	public bool TryNextFrame;

	public bool MissionMode;

	public bool NoDebug;

	public int RooftopStudent = 7;

	public float Timer;

	public int ID;

	public Texture PantyCensorTexture;

	private int DebugInt;

	public GameObject Mop;

	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 0f, base.transform.localPosition.z);
		this.MissionModeWindow.SetActive(false);
		this.Window.SetActive(false);
		if (MissionModeGlobals.MissionMode)
		{
			this.MissionMode = true;
		}
		if (GameGlobals.LoveSick)
		{
			this.NoDebug = true;
		}
	}

	private void Update()
	{
		if (!this.MissionMode && !this.NoDebug)
		{
			if (!this.Yandere.InClass && !this.Yandere.Chased && this.Yandere.Chasers == 0 && this.Yandere.CanMove)
			{
				if (Input.GetKeyDown(KeyCode.Backslash) && this.Yandere.transform.position.y < 100f)
				{
					this.EasterEggWindow.SetActive(false);
					this.Window.SetActive(!this.Window.activeInHierarchy);
				}
			}
			else if (this.Window.activeInHierarchy)
			{
				this.Window.SetActive(false);
			}
			if (this.Window.activeInHierarchy)
			{
				if (Input.GetKeyDown(KeyCode.F1))
				{
					StudentGlobals.FemaleUniform = 1;
					StudentGlobals.MaleUniform = 1;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F2))
				{
					StudentGlobals.FemaleUniform = 2;
					StudentGlobals.MaleUniform = 2;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F3))
				{
					StudentGlobals.FemaleUniform = 3;
					StudentGlobals.MaleUniform = 3;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F4))
				{
					StudentGlobals.FemaleUniform = 4;
					StudentGlobals.MaleUniform = 4;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F5))
				{
					StudentGlobals.FemaleUniform = 5;
					StudentGlobals.MaleUniform = 5;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F6))
				{
					StudentGlobals.FemaleUniform = 6;
					StudentGlobals.MaleUniform = 6;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F7))
				{
					this.ID = 1;
					while (this.ID < 8)
					{
						this.StudentManager.DrinkingFountains[this.ID].PowerSwitch.PowerOutlet.SabotagedOutlet.SetActive(true);
						this.StudentManager.DrinkingFountains[this.ID].Puddle.SetActive(true);
						this.ID++;
					}
					this.Window.SetActive(false);
				}
				else if (Input.GetKeyDown(KeyCode.F8))
				{
					GameGlobals.CensorBlood = !GameGlobals.CensorBlood;
					this.WeaponManager.ChangeBloodTexture();
					YandereScript yandere = this.Yandere;
					yandere.Bloodiness = yandere.Bloodiness;
					this.Window.SetActive(false);
				}
				else if (Input.GetKeyDown(KeyCode.F9))
				{
					this.Yandere.AttackManager.Censor = !this.Yandere.AttackManager.Censor;
					this.Window.SetActive(false);
				}
				else if (!Input.GetKeyDown(KeyCode.F12))
				{
					if (Input.GetKeyDown(KeyCode.Alpha1))
					{
						DateGlobals.Weekday = DayOfWeek.Monday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha2))
					{
						DateGlobals.Weekday = DayOfWeek.Tuesday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha3))
					{
						DateGlobals.Weekday = DayOfWeek.Wednesday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha4))
					{
						DateGlobals.Weekday = DayOfWeek.Thursday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha5))
					{
						DateGlobals.Weekday = DayOfWeek.Friday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha6))
					{
						this.Yandere.transform.position = this.TeleportSpot[1].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha7))
					{
						this.Yandere.transform.position = this.TeleportSpot[2].position + new Vector3(0.75f, 0f, 0f);
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha8))
					{
						this.Yandere.transform.position = this.TeleportSpot[3].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha9))
					{
						this.Yandere.transform.position = this.TeleportSpot[4].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						if (this.Clock.HourTime < 7.1f)
						{
							this.Clock.PresentTime = 426f;
							StudentScript studentScript = this.StudentManager.Students[30];
							if (studentScript != null)
							{
								if (studentScript.Phase < 2)
								{
									studentScript.ShoeRemoval.Start();
									studentScript.ShoeRemoval.PutOnShoes();
									studentScript.CanTalk = true;
									studentScript.Phase = 2;
									studentScript.CurrentDestination = studentScript.Destinations[2];
									studentScript.Pathfinding.target = studentScript.Destinations[2];
								}
								studentScript.transform.position = studentScript.Destinations[2].position;
							}
							StudentScript studentScript2 = this.StudentManager.Students[28];
							if (studentScript2 != null)
							{
								studentScript2.ShoeRemoval.Start();
								studentScript2.ShoeRemoval.PutOnShoes();
								studentScript2.Phase = 2;
								studentScript2.CurrentDestination = studentScript2.Destinations[2];
								studentScript2.Pathfinding.target = studentScript2.Destinations[2];
								studentScript2.transform.position = studentScript2.Destinations[2].position;
							}
							StudentScript studentScript3 = this.StudentManager.Students[39];
							if (studentScript3 != null)
							{
								studentScript3.ShoeRemoval.Start();
								studentScript3.ShoeRemoval.PutOnShoes();
								studentScript3.Phase = 2;
								ScheduleBlock scheduleBlock = studentScript3.ScheduleBlocks[2];
								scheduleBlock.action = "Stand";
								studentScript3.GetDestinations();
								studentScript3.CurrentDestination = this.MidoriSpot;
								studentScript3.Pathfinding.target = this.MidoriSpot;
								studentScript3.transform.position = this.MidoriSpot.position;
							}
						}
						this.Window.SetActive(false);
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.Alpha0))
					{
						this.Yandere.transform.position = this.TeleportSpot[11].position;
						this.Window.SetActive(false);
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.A))
					{
						if (SchoolAtmosphere.Type == SchoolAtmosphereType.High)
						{
							SchoolGlobals.SchoolAtmosphere = 0.5f;
						}
						else if (SchoolAtmosphere.Type == SchoolAtmosphereType.Medium)
						{
							SchoolGlobals.SchoolAtmosphere = 0f;
						}
						else
						{
							SchoolGlobals.SchoolAtmosphere = 1f;
						}
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.C))
					{
						this.ID = 1;
						while (this.ID < 11)
						{
							CollectibleGlobals.SetTapeCollected(this.ID, true);
							this.ID++;
						}
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.D))
					{
						this.ID = 0;
						while (this.ID < 5)
						{
							StudentScript studentScript4 = this.StudentManager.Students[76 + this.ID];
							if (studentScript4 != null)
							{
								if (studentScript4.Phase < 2)
								{
									studentScript4.ShoeRemoval.Start();
									studentScript4.ShoeRemoval.PutOnShoes();
									studentScript4.Phase = 2;
									studentScript4.CurrentDestination = studentScript4.Destinations[2];
									studentScript4.Pathfinding.target = studentScript4.Destinations[2];
								}
								studentScript4.transform.position = studentScript4.Destinations[2].position;
							}
							this.ID++;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.F))
					{
						this.GreenScreen.SetActive(true);
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.G))
					{
						StudentScript studentScript5 = this.StudentManager.Students[this.RooftopStudent];
						if (this.Clock.HourTime < 15f)
						{
							PlayerGlobals.SetStudentFriend(this.RooftopStudent, true);
							this.Yandere.transform.position = this.RooftopSpot.position + new Vector3(1f, 0f, 0f);
							this.WeaponManager.Weapons[6].transform.position = this.Yandere.transform.position + new Vector3(0f, 0f, 1.915f);
							if (studentScript5 != null)
							{
								this.StudentManager.OfferHelp.UpdateLocation();
								this.StudentManager.OfferHelp.enabled = true;
								if (!studentScript5.Indoors)
								{
									if (studentScript5.ShoeRemoval.Locker == null)
									{
										studentScript5.ShoeRemoval.Start();
									}
									studentScript5.ShoeRemoval.PutOnShoes();
								}
								studentScript5.CharacterAnimation.Play(studentScript5.IdleAnim);
								studentScript5.transform.position = this.RooftopSpot.position;
								studentScript5.transform.rotation = this.RooftopSpot.rotation;
								studentScript5.Prompt.Label[0].text = "     Push";
								studentScript5.CurrentDestination = this.RooftopSpot;
								studentScript5.Pathfinding.target = this.RooftopSpot;
								studentScript5.Pathfinding.canSearch = false;
								studentScript5.Pathfinding.canMove = false;
								studentScript5.SpeechLines.Stop();
								studentScript5.Pushable = true;
								studentScript5.Routine = false;
								studentScript5.Meeting = true;
								studentScript5.MeetTime = 0f;
							}
							if (this.Clock.HourTime < 7.1f)
							{
								this.Clock.PresentTime = 426f;
							}
						}
						else
						{
							this.Clock.PresentTime = 960f;
							studentScript5.transform.position = this.Lockers.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.K))
					{
						SchoolGlobals.KidnapVictim = 25;
						StudentGlobals.SetStudentSlave(25);
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.L))
					{
						SchemeGlobals.SetSchemeStage(1, 2);
						EventGlobals.Event1 = true;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.M))
					{
						PlayerGlobals.Money = 100f;
						this.Yandere.Inventory.UpdateMoney();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.O))
					{
						this.Yandere.Inventory.RivalPhone = true;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.P))
					{
						this.ID = 2;
						while (this.ID < 93)
						{
							StudentScript studentScript6 = this.StudentManager.Students[this.ID];
							if (studentScript6 != null)
							{
								studentScript6.Patience = 999;
								studentScript6.Pestered = -999;
								studentScript6.Ignoring = false;
							}
							this.ID++;
						}
						PlayerGlobals.PantyShots += 20;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Q))
					{
						this.Censor();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.R))
					{
						if (PlayerGlobals.Reputation != 66.66666f)
						{
							PlayerGlobals.Reputation = 66.66666f;
							this.Reputation.Reputation = PlayerGlobals.Reputation;
						}
						else
						{
							PlayerGlobals.Reputation = -66.66666f;
							this.Reputation.Reputation = PlayerGlobals.Reputation;
						}
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.S))
					{
						ClassGlobals.PhysicalGrade = 5;
						PlayerGlobals.Seduction = 5;
						this.StudentManager.Police.UpdateCorpses();
						this.ID = 1;
						while (this.ID < 101)
						{
							StudentGlobals.SetStudentPhotographed(this.ID, true);
							this.ID++;
						}
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.T))
					{
						this.Zoom.OverShoulder = !this.Zoom.OverShoulder;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.U))
					{
						PlayerGlobals.SetStudentFriend(28, true);
						PlayerGlobals.SetStudentFriend(30, true);
						this.ID = 1;
						while (this.ID < 26)
						{
							ConversationGlobals.SetTopicLearnedByStudent(this.ID, 30, true);
							ConversationGlobals.SetTopicDiscovered(this.ID, true);
							this.ID++;
						}
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Z))
					{
						if (Input.GetKey(KeyCode.LeftShift))
						{
							this.ID = 2;
							while (this.ID < 93)
							{
								StudentScript x = this.StudentManager.Students[this.ID];
								if (x != null)
								{
									StudentGlobals.SetStudentMissing(this.ID, true);
								}
								this.ID++;
							}
						}
						else
						{
							this.ID = 2;
							while (this.ID < 101)
							{
								StudentScript studentScript7 = this.StudentManager.Students[this.ID];
								if (studentScript7 != null)
								{
									studentScript7.SpawnAlarmDisc();
									studentScript7.BecomeRagdoll();
									studentScript7.DeathType = DeathType.EasterEgg;
									StudentGlobals.SetStudentDead(this.ID, true);
								}
								this.ID++;
							}
						}
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.X))
					{
						TaskGlobals.SetTaskStatus(36, 3);
						SchoolGlobals.ReactedToGameLeader = false;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Backspace))
					{
						Time.timeScale = 1f;
						this.Clock.PresentTime = 1079f;
						this.Clock.HourTime = this.Clock.PresentTime / 60f;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.BackQuote))
					{
						Globals.DeleteAll();
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Space))
					{
						this.Yandere.transform.position = this.TeleportSpot[5].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						for (int i = 46; i < 51; i++)
						{
							if (this.StudentManager.Students[i] != null)
							{
								this.StudentManager.Students[i].transform.position = this.TeleportSpot[5].position;
								if (!this.StudentManager.Students[i].Indoors)
								{
									if (this.StudentManager.Students[i].ShoeRemoval.Locker == null)
									{
										this.StudentManager.Students[i].ShoeRemoval.Start();
									}
									this.StudentManager.Students[i].ShoeRemoval.PutOnShoes();
								}
							}
						}
						this.Clock.PresentTime = 1015f;
						this.Clock.HourTime = this.Clock.PresentTime / 60f;
						this.Window.SetActive(false);
						this.OsanaEvent1.enabled = false;
						this.OsanaEvent2.enabled = false;
						this.OsanaEvent3.enabled = false;
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.LeftAlt))
					{
						this.Turtle.SpawnWeapons();
						this.Yandere.transform.position = this.TeleportSpot[6].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						this.Clock.PresentTime = 425f;
						this.Clock.HourTime = this.Clock.PresentTime / 60f;
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.LeftControl))
					{
						this.Yandere.transform.position = this.TeleportSpot[7].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.RightControl))
					{
						this.Yandere.transform.position = this.TeleportSpot[8].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Equals))
					{
						this.Clock.PresentTime += 10f;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Return))
					{
						this.Yandere.transform.eulerAngles = this.TeleportSpot[10].eulerAngles;
						this.Yandere.transform.position = this.TeleportSpot[10].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						this.StudentManager.Students[1].ShoeRemoval.Start();
						this.StudentManager.Students[1].ShoeRemoval.PutOnShoes();
						this.StudentManager.Students[1].transform.position = new Vector3(0f, 12.1f, -25f);
						this.StudentManager.Students[1].Alarmed = true;
						this.StudentManager.Students[11].Lethal = true;
						this.StudentManager.Students[11].ShoeRemoval.Start();
						this.StudentManager.Students[11].ShoeRemoval.PutOnShoes();
						this.StudentManager.Students[11].transform.position = new Vector3(0f, 12.1f, -25f);
						this.Clock.PresentTime = 780f;
						this.Clock.HourTime = this.Clock.PresentTime / 60f;
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.B))
					{
						DatingGlobals.SuitorProgress = 2;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Pause))
					{
						this.Clock.StopTime = !this.Clock.StopTime;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.W))
					{
						this.StudentManager.ToggleBookBags();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.H))
					{
						StudentGlobals.SetFragileTarget(31);
						StudentGlobals.SetStudentFragileSlave(5);
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.I))
					{
						this.StudentManager.Students[3].BecomeRagdoll();
						this.WeaponManager.Weapons[1].Blood.enabled = true;
						this.WeaponManager.Weapons[1].FingerprintID = 2;
						this.WeaponManager.Weapons[1].Victims[3] = true;
						this.StudentManager.Students[5].BecomeRagdoll();
						this.WeaponManager.Weapons[2].Blood.enabled = true;
						this.WeaponManager.Weapons[2].FingerprintID = 4;
						this.WeaponManager.Weapons[2].Victims[5] = true;
					}
					else if (!Input.GetKeyDown(KeyCode.J))
					{
						if (Input.GetKeyDown(KeyCode.V))
						{
							this.StudentManager.DatingMinigame.Affection = 100f;
							DateGlobals.Weekday = DayOfWeek.Friday;
						}
					}
				}
			}
			else
			{
				if (Input.GetKey(KeyCode.BackQuote))
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						this.ID = 0;
						while (this.ID < this.StudentManager.NPCsTotal)
						{
							if (StudentGlobals.GetStudentDying(this.ID))
							{
								StudentGlobals.SetStudentDying(this.ID, false);
							}
							this.ID++;
						}
						SceneManager.LoadScene("LoadingScene");
					}
				}
				if (Input.GetKeyUp(KeyCode.BackQuote))
				{
					this.Timer = 0f;
				}
			}
			if (this.TryNextFrame)
			{
				this.UpdateCensor();
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Backslash))
			{
				this.MissionModeWindow.SetActive(!this.MissionModeWindow.activeInHierarchy);
			}
			if (this.MissionModeWindow.activeInHierarchy)
			{
				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					this.Censor();
				}
				if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					GameGlobals.CensorBlood = !GameGlobals.CensorBlood;
					this.WeaponManager.ChangeBloodTexture();
					YandereScript yandere2 = this.Yandere;
					yandere2.Bloodiness = yandere2.Bloodiness;
				}
				if (Input.GetKeyDown(KeyCode.Alpha3))
				{
					this.Yandere.AttackManager.Censor = !this.Yandere.AttackManager.Censor;
				}
			}
		}
		if (this.WaitingForNumber)
		{
			if (Input.GetKey("1"))
			{
				Debug.Log("Going to class should trigger panty shot lecture.");
				SchemeGlobals.SetSchemeStage(1, 100);
				StudentGlobals.ExpelProgress = 0;
				this.Counselor.CutsceneManager.Scheme = 1;
				this.Counselor.LectureID = 1;
				this.WaitingForNumber = false;
			}
			else if (Input.GetKey("2"))
			{
				Debug.Log("Going to class should trigger theft lecture.");
				SchemeGlobals.SetSchemeStage(2, 100);
				StudentGlobals.ExpelProgress = 1;
				this.Counselor.CutsceneManager.Scheme = 2;
				this.Counselor.LectureID = 2;
				this.WaitingForNumber = false;
			}
			else if (Input.GetKey("3"))
			{
				Debug.Log("Going to class should trigger contraband lecture.");
				SchemeGlobals.SetSchemeStage(3, 0);
				StudentGlobals.ExpelProgress = 2;
				this.Counselor.CutsceneManager.Scheme = 3;
				this.Counselor.LectureID = 3;
				this.WaitingForNumber = false;
			}
			else if (Input.GetKey("4"))
			{
				Debug.Log("Going to class should trigger Vandalism lecture.");
				SchemeGlobals.SetSchemeStage(4, 0);
				StudentGlobals.ExpelProgress = 4;
				this.Counselor.CutsceneManager.Scheme = 4;
				this.Counselor.LectureID = 4;
				this.WaitingForNumber = false;
			}
			else if (Input.GetKey("5"))
			{
				Debug.Log("Going to class at lunchtime should get Osana expelled!");
				SchemeGlobals.SetSchemeStage(5, 7);
				StudentGlobals.ExpelProgress = 4;
				this.Counselor.CutsceneManager.Scheme = 5;
				this.Counselor.LectureID = 5;
				this.WaitingForNumber = false;
			}
		}
	}

	public void Censor()
	{
		if (!this.StudentManager.Censor)
		{
			Debug.Log("We're turning the censor ON.");
			if (this.Yandere.Schoolwear == 1)
			{
				if (!this.Yandere.Sans && !this.Yandere.SithLord && !this.Yandere.BanchoActive)
				{
					if (!this.Yandere.FlameDemonic && !this.Yandere.TornadoHair.activeInHierarchy)
					{
						this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
						this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
						this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
						this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
						this.Yandere.PantyAttacher.newRenderer.enabled = false;
					}
					else
					{
						Debug.Log("This block of code activated a shadow.");
						this.Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", this.PantyCensorTexture);
						this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
						this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
						this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
					}
				}
				else
				{
					this.Yandere.PantyAttacher.newRenderer.enabled = false;
				}
			}
			if (this.Yandere.MiyukiCostume.activeInHierarchy || this.Yandere.Rain.activeInHierarchy)
			{
				this.Yandere.PantyAttacher.newRenderer.enabled = false;
				this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.PantyCensorTexture);
				this.Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", this.PantyCensorTexture);
				this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
				this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
				this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 1f);
			}
			if (this.Yandere.NierCostume.activeInHierarchy || this.Yandere.MyRenderer.sharedMesh == this.Yandere.NudeMesh || this.Yandere.MyRenderer.sharedMesh == this.Yandere.SchoolSwimsuit)
			{
				this.EasterEggCheck();
			}
			this.StudentManager.Censor = true;
			this.StudentManager.CensorStudents();
		}
		else
		{
			Debug.Log("We're turning the censor OFF.");
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
			this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			if (this.Yandere.MyRenderer.sharedMesh != this.Yandere.NudeMesh && this.Yandere.MyRenderer.sharedMesh != this.Yandere.SchoolSwimsuit)
			{
				this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
				this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
				this.Yandere.PantyAttacher.newRenderer.enabled = true;
				this.EasterEggCheck();
			}
			else
			{
				this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
				this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
				this.Yandere.PantyAttacher.newRenderer.enabled = false;
				this.EasterEggCheck();
			}
			if (this.Yandere.MiyukiCostume.activeInHierarchy)
			{
				this.Yandere.PantyAttacher.newRenderer.enabled = false;
			}
			this.StudentManager.Censor = false;
			this.StudentManager.CensorStudents();
		}
	}

	public void EasterEggCheck()
	{
		Debug.Log("Checking for easter eggs.");
		if (this.Yandere.BanchoActive || this.Yandere.Sans || this.Yandere.Raincoat.activeInHierarchy || this.Yandere.KLKSword.activeInHierarchy || this.Yandere.Gazing || this.Yandere.Ninja || this.Yandere.ClubAttire || this.Yandere.LifeNotebook.activeInHierarchy || this.Yandere.FalconHelmet.activeInHierarchy || this.Yandere.MyRenderer.sharedMesh == this.Yandere.NudeMesh || this.Yandere.MyRenderer.sharedMesh == this.Yandere.SchoolSwimsuit)
		{
			Debug.Log("A pants-wearing easter egg is active, so we're going to disable all shadows and panties.");
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
			this.Yandere.PantyAttacher.newRenderer.enabled = false;
		}
		if (this.Yandere.FlameDemonic || this.Yandere.TornadoHair.activeInHierarchy)
		{
			Debug.Log("This other block of code activated a shadow.");
			this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.PantyCensorTexture);
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
			this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
		}
		if (this.Yandere.NierCostume.activeInHierarchy)
		{
			Debug.Log("Nier costume special case.");
			this.Yandere.PantyAttacher.newRenderer.enabled = false;
			SkinnedMeshRenderer newRenderer = this.Yandere.NierCostume.GetComponent<RiggedAccessoryAttacher>().newRenderer;
			if (newRenderer == null)
			{
				this.TryNextFrame = true;
			}
			else
			{
				this.TryNextFrame = false;
				if (!this.StudentManager.Censor)
				{
					newRenderer.materials[0].SetFloat("_BlendAmount", 1f);
					newRenderer.materials[1].SetFloat("_BlendAmount", 1f);
					newRenderer.materials[2].SetFloat("_BlendAmount", 1f);
					newRenderer.materials[3].SetFloat("_BlendAmount", 1f);
				}
				else
				{
					newRenderer.materials[0].SetFloat("_BlendAmount", 0f);
					newRenderer.materials[1].SetFloat("_BlendAmount", 0f);
					newRenderer.materials[2].SetFloat("_BlendAmount", 0f);
					newRenderer.materials[3].SetFloat("_BlendAmount", 0f);
				}
			}
		}
	}

	public void UpdateCensor()
	{
		this.Censor();
		this.Censor();
	}

	public void DebugTest()
	{
		if (this.DebugInt == 0)
		{
			StudentScript studentScript = this.StudentManager.Students[39];
			studentScript.ShoeRemoval.Start();
			studentScript.ShoeRemoval.PutOnShoes();
			studentScript.Phase = 2;
			ScheduleBlock scheduleBlock = studentScript.ScheduleBlocks[2];
			scheduleBlock.action = "Stand";
			studentScript.GetDestinations();
			studentScript.CurrentDestination = this.MidoriSpot;
			studentScript.Pathfinding.target = this.MidoriSpot;
			studentScript.transform.position = this.Yandere.transform.position;
			Physics.SyncTransforms();
		}
		else if (this.DebugInt == 1)
		{
			this.Knife.transform.position = this.Yandere.transform.position + new Vector3(-1f, 1f, 0f);
			this.Knife.GetComponent<Rigidbody>().isKinematic = false;
			this.Knife.GetComponent<Rigidbody>().useGravity = true;
		}
		else if (this.DebugInt == 2)
		{
			this.Mop.transform.position = this.Yandere.transform.position + new Vector3(1f, 1f, 0f);
			this.Mop.GetComponent<Rigidbody>().isKinematic = false;
			this.Mop.GetComponent<Rigidbody>().useGravity = true;
		}
		this.DebugInt++;
	}
}
