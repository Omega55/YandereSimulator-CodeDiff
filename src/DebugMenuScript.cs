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

	public YandereScript Yandere;

	public BentoScript Bento;

	public ClockScript Clock;

	public PrayScript Turtle;

	public ZoomScript Zoom;

	public AstarPath Astar;

	public GameObject EasterEggWindow;

	public GameObject SacrificialArm;

	public GameObject CircularSaw;

	public GameObject Knife;

	public Transform[] TeleportSpot;

	public Transform RooftopSpot;

	public Transform Lockers;

	public GameObject Window;

	public bool MissionMode;

	public int RooftopStudent = 7;

	public int ID;

	public Texture PantyCensorTexture;

	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 0f, base.transform.localPosition.z);
		this.Window.SetActive(false);
		if (PlayerPrefs.GetInt("MissionMode") == 1)
		{
			this.MissionMode = true;
		}
	}

	private void Update()
	{
		if (!this.MissionMode)
		{
			if (!this.Yandere.InClass && !this.Yandere.Chased && this.Yandere.CanMove)
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
					PlayerPrefs.SetInt("FemaleUniform", 1);
					PlayerPrefs.SetInt("MaleUniform", 1);
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F2))
				{
					PlayerPrefs.SetInt("FemaleUniform", 2);
					PlayerPrefs.SetInt("MaleUniform", 2);
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F3))
				{
					PlayerPrefs.SetInt("FemaleUniform", 3);
					PlayerPrefs.SetInt("MaleUniform", 3);
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F4))
				{
					PlayerPrefs.SetInt("FemaleUniform", 4);
					PlayerPrefs.SetInt("MaleUniform", 4);
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F5))
				{
					PlayerPrefs.SetInt("FemaleUniform", 5);
					PlayerPrefs.SetInt("MaleUniform", 5);
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F6))
				{
					PlayerPrefs.SetInt("FemaleUniform", 6);
					PlayerPrefs.SetInt("MaleUniform", 6);
					SceneManager.LoadScene("LoadingScene");
				}
				else if (!Input.GetKeyDown(KeyCode.F12))
				{
					if (Input.GetKeyDown("1"))
					{
						PlayerPrefs.SetInt("Weekday", 1);
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown("2"))
					{
						PlayerPrefs.SetInt("Weekday", 2);
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown("3"))
					{
						PlayerPrefs.SetInt("Weekday", 3);
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown("4"))
					{
						PlayerPrefs.SetInt("Weekday", 4);
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown("5"))
					{
						PlayerPrefs.SetInt("Weekday", 5);
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown("6"))
					{
						this.Yandere.transform.position = this.TeleportSpot[1].position;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown("7"))
					{
						this.Yandere.transform.position = this.TeleportSpot[2].position + new Vector3(0.75f, 0f, 0f);
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown("8"))
					{
						this.Yandere.transform.position = this.TeleportSpot[3].position;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown("9"))
					{
						this.Yandere.transform.position = this.TeleportSpot[4].position;
						this.Window.SetActive(false);
						if (this.Clock.HourTime < 7.1f)
						{
							this.Clock.PresentTime = 426f;
							StudentScript studentScript = this.StudentManager.Students[7];
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
							StudentScript studentScript2 = this.StudentManager.Students[13];
							if (studentScript2 != null)
							{
								if (studentScript2.Phase < 2)
								{
									studentScript2.ShoeRemoval.Start();
									studentScript2.ShoeRemoval.PutOnShoes();
									studentScript2.Phase = 2;
									studentScript2.CurrentDestination = studentScript2.Destinations[2];
									studentScript2.Pathfinding.target = studentScript2.Destinations[2];
								}
								studentScript2.transform.position = studentScript2.Destinations[2].position;
							}
							StudentScript studentScript3 = this.StudentManager.Students[16];
							if (studentScript3 != null)
							{
								if (studentScript3.Phase < 2)
								{
									studentScript3.ShoeRemoval.Start();
									studentScript3.ShoeRemoval.PutOnShoes();
									studentScript3.Phase = 2;
									studentScript3.CurrentDestination = studentScript3.Destinations[2];
									studentScript3.Pathfinding.target = studentScript3.Destinations[2];
								}
								studentScript3.transform.position = studentScript3.Destinations[2].position;
							}
						}
					}
					else if (Input.GetKeyDown("0"))
					{
						this.CameraEffects.DisableCamera();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown("a"))
					{
						if (PlayerPrefs.GetFloat("SchoolAtmosphere") > 66.66666f)
						{
							PlayerPrefs.SetFloat("SchoolAtmosphere", 50f);
						}
						else if (PlayerPrefs.GetFloat("SchoolAtmosphere") > 33.33333f)
						{
							PlayerPrefs.SetFloat("SchoolAtmosphere", 0f);
						}
						else
						{
							PlayerPrefs.SetFloat("SchoolAtmosphere", 100f);
						}
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown("c"))
					{
						this.ID = 1;
						while (this.ID < 11)
						{
							PlayerPrefs.SetInt("Tape_" + this.ID.ToString() + "_Collected", 1);
							this.ID++;
						}
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown("f"))
					{
						this.FakeStudentSpawner.Spawn();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown("g"))
					{
						StudentScript studentScript4 = this.StudentManager.Students[this.RooftopStudent];
						if (this.Clock.HourTime < 15f)
						{
							PlayerPrefs.SetInt(this.RooftopStudent.ToString() + "_Friend", 1);
							this.Yandere.transform.position = this.RooftopSpot.position + new Vector3(1f, 0f, 0f);
							this.WeaponManager.Weapons[6].transform.position = this.Yandere.transform.position;
							if (studentScript4 != null)
							{
								this.StudentManager.OfferHelp.UpdateLocation();
								this.StudentManager.OfferHelp.enabled = true;
								if (!studentScript4.Indoors)
								{
									if (studentScript4.ShoeRemoval.Locker == null)
									{
										studentScript4.ShoeRemoval.Start();
									}
									studentScript4.ShoeRemoval.PutOnShoes();
								}
								studentScript4.CharacterAnimation.Play(studentScript4.IdleAnim);
								studentScript4.transform.position = this.RooftopSpot.position;
								studentScript4.transform.rotation = this.RooftopSpot.rotation;
								studentScript4.Prompt.Label[0].text = "     Push";
								studentScript4.CurrentDestination = this.RooftopSpot;
								studentScript4.Pathfinding.target = this.RooftopSpot;
								studentScript4.Pathfinding.canSearch = false;
								studentScript4.Pathfinding.canMove = false;
								studentScript4.Routine = false;
								studentScript4.Meeting = true;
								studentScript4.MeetTime = 0f;
							}
							if (this.Clock.HourTime < 7.1f)
							{
								this.Clock.PresentTime = 426f;
							}
						}
						else
						{
							this.Clock.PresentTime = 960f;
							studentScript4.transform.position = this.Lockers.position;
						}
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown("k"))
					{
						PlayerPrefs.SetInt("KidnapVictim", 6);
						PlayerPrefs.SetInt("Student_6_Slave", 1);
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown("l"))
					{
						PlayerPrefs.SetInt("Event1", 1);
						this.Window.SetActive(false);
					}
					else if (!Input.GetKeyDown("m"))
					{
						if (Input.GetKeyDown("o"))
						{
							this.Yandere.Inventory.RivalPhone = true;
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("p"))
						{
							PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") + 20);
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("q"))
						{
							this.Censor();
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("r"))
						{
							if (PlayerPrefs.GetFloat("Reputation") != 66.66666f)
							{
								PlayerPrefs.SetFloat("Reputation", 66.66666f);
								this.Reputation.Reputation = PlayerPrefs.GetFloat("Reputation");
							}
							else
							{
								PlayerPrefs.SetFloat("Reputation", -66.66666f);
								this.Reputation.Reputation = PlayerPrefs.GetFloat("Reputation");
							}
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("s"))
						{
							PlayerPrefs.SetInt("PhysicalGrade", 5);
							PlayerPrefs.SetInt("Seduction", 5);
							this.ID = 1;
							while (this.ID < 101)
							{
								PlayerPrefs.SetInt("Student_" + this.ID.ToString() + "_Photographed", 1);
								this.ID++;
							}
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("t"))
						{
							this.Zoom.OverShoulder = !this.Zoom.OverShoulder;
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("u"))
						{
							PlayerPrefs.SetInt("7_Friend", 1);
							PlayerPrefs.SetInt("13_Friend", 1);
							this.ID = 1;
							while (this.ID < 26)
							{
								PlayerPrefs.SetInt("Topic_" + this.ID.ToString() + "_Student_7_Learned", 1);
								PlayerPrefs.SetInt("Topic_" + this.ID.ToString() + "_Discovered", 1);
								this.ID++;
							}
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("y"))
						{
							this.DelinquentManager.Delinquents.SetActive(!this.DelinquentManager.Delinquents.activeInHierarchy);
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("z"))
						{
							this.ID = 1;
							while (this.ID < 101)
							{
								StudentScript studentScript5 = this.StudentManager.Students[this.ID];
								if (studentScript5 != null)
								{
									studentScript5.SpawnAlarmDisc();
									studentScript5.BecomeRagdoll();
									studentScript5.DeathType = DeathType.EasterEgg;
									PlayerPrefs.SetInt("Student_" + this.ID.ToString() + "_Dead", 1);
								}
								this.ID++;
							}
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("x"))
						{
							PlayerPrefs.SetInt("HighPopulation", (PlayerPrefs.GetInt("HighPopulation") != 0) ? 0 : 1);
							SceneManager.LoadScene("LoadingScene");
						}
						else if (Input.GetKeyDown("backspace"))
						{
							Time.timeScale = 1f;
							this.Clock.PresentTime = 1079f;
							this.Clock.HourTime = this.Clock.PresentTime / 60f;
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("`"))
						{
							PlayerPrefs.DeleteAll();
							SceneManager.LoadScene("LoadingScene");
						}
						else if (Input.GetKeyDown("space"))
						{
							this.Yandere.transform.position = this.TeleportSpot[5].position;
							if (this.StudentManager.Students[21] != null)
							{
								this.StudentManager.Students[21].transform.position = this.TeleportSpot[5].position;
							}
							this.Clock.PresentTime = 1015f;
							this.Clock.HourTime = this.Clock.PresentTime / 60f;
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("left alt"))
						{
							this.Turtle.SpawnWeapons();
							this.Yandere.transform.position = this.TeleportSpot[6].position;
							this.Clock.PresentTime = 425f;
							this.Clock.HourTime = this.Clock.PresentTime / 60f;
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("left ctrl"))
						{
							this.Yandere.transform.position = this.TeleportSpot[7].position;
							if (this.StudentManager.Students[26] != null)
							{
								this.StudentManager.Students[26].transform.position = this.TeleportSpot[7].position;
							}
							this.Clock.PresentTime = 1015f;
							this.Clock.HourTime = this.Clock.PresentTime / 60f;
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("right ctrl"))
						{
							this.Yandere.transform.position = this.TeleportSpot[8].position;
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("="))
						{
							this.DelinquentManager.Timer -= 30f;
							this.Clock.PresentTime += 30f;
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("enter"))
						{
							this.Yandere.transform.eulerAngles = this.TeleportSpot[10].eulerAngles;
							this.Yandere.transform.position = this.TeleportSpot[10].position;
							this.StudentManager.Students[1].ShoeRemoval.Start();
							this.StudentManager.Students[1].ShoeRemoval.PutOnShoes();
							this.StudentManager.Students[1].transform.position = new Vector3(0f, 12.1f, -25f);
							this.StudentManager.Students[1].Alarmed = true;
							this.StudentManager.Students[33].Lethal = true;
							this.StudentManager.Students[33].ShoeRemoval.Start();
							this.StudentManager.Students[33].ShoeRemoval.PutOnShoes();
							this.StudentManager.Students[33].transform.position = new Vector3(0f, 12.1f, -25f);
							this.Clock.PresentTime = 780f;
							this.Clock.HourTime = this.Clock.PresentTime / 60f;
							this.Window.SetActive(false);
						}
						else if (Input.GetKeyDown("b"))
						{
							PlayerPrefs.SetInt("SuitorProgress", 2);
							SceneManager.LoadScene("LoadingScene");
						}
					}
				}
			}
			else if (Input.GetKeyDown("`"))
			{
				this.ID = 0;
				while (this.ID < this.StudentManager.NPCsTotal)
				{
					if (PlayerPrefs.GetInt("Student_" + this.ID.ToString() + "_Dying") == 1)
					{
						PlayerPrefs.SetInt("Student_" + this.ID.ToString() + "_Dying", 0);
					}
					this.ID++;
				}
				SceneManager.LoadScene("LoadingScene");
			}
		}
		else if (Input.GetKeyDown(KeyCode.Backslash))
		{
			this.Censor();
		}
	}

	public void Censor()
	{
		if (!this.StudentManager.Censor)
		{
			if (this.Yandere.Schoolwear == 1 && !this.Yandere.Sans)
			{
				if (!this.Yandere.FlameDemonic && !this.Yandere.TornadoHair.activeInHierarchy)
				{
					this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
					this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
				}
				else
				{
					this.Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", this.PantyCensorTexture);
					this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
					this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
					this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
				}
			}
			this.StudentManager.Censor = true;
			this.StudentManager.CensorStudents();
		}
		else
		{
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			this.StudentManager.Censor = false;
			this.StudentManager.CensorStudents();
		}
	}

	public void UpdateCensor()
	{
		this.Censor();
		this.Censor();
	}
}
