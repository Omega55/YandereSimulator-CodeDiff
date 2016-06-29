﻿using System;
using UnityEngine;

[Serializable]
public class DebugMenuScript : MonoBehaviour
{
	public FakeStudentSpawnerScript FakeStudentSpawner;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public ReputationScript Reputation;

	public YandereScript Yandere;

	public ClockScript Clock;

	public ZoomScript Zoom;

	public GameObject EasterEggWindow;

	public GameObject SacrificialArm;

	public GameObject CircularSaw;

	public Transform[] TeleportSpot;

	public Transform RooftopSpot;

	public Transform Lockers;

	public GameObject Window;

	public int ID;

	public virtual void Start()
	{
		int num = 0;
		Vector3 localPosition = this.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.transform.localPosition = localPosition;
		this.Window.active = false;
	}

	public virtual void Update()
	{
		if (!this.Yandere.InClass && !this.Yandere.Chased)
		{
			if (Input.GetKeyDown(KeyCode.Backslash))
			{
				this.EasterEggWindow.active = false;
				if (!this.Window.active)
				{
					this.Window.active = true;
				}
				else
				{
					this.Window.active = false;
				}
			}
		}
		else if (this.Window.active)
		{
			this.Window.active = false;
		}
		if (this.Window.active)
		{
			if (Input.GetKeyDown(KeyCode.F1))
			{
				PlayerPrefs.SetInt("FemaleUniform", 1);
				PlayerPrefs.SetInt("MaleUniform", 1);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown(KeyCode.F2))
			{
				PlayerPrefs.SetInt("FemaleUniform", 2);
				PlayerPrefs.SetInt("MaleUniform", 2);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown(KeyCode.F3))
			{
				PlayerPrefs.SetInt("FemaleUniform", 3);
				PlayerPrefs.SetInt("MaleUniform", 3);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown(KeyCode.F4))
			{
				PlayerPrefs.SetInt("FemaleUniform", 4);
				PlayerPrefs.SetInt("MaleUniform", 4);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown(KeyCode.F5))
			{
				PlayerPrefs.SetInt("FemaleUniform", 5);
				PlayerPrefs.SetInt("MaleUniform", 5);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown(KeyCode.F6))
			{
				PlayerPrefs.SetInt("FemaleUniform", 6);
				PlayerPrefs.SetInt("MaleUniform", 6);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("1"))
			{
				PlayerPrefs.SetInt("Weekday", 1);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("2"))
			{
				PlayerPrefs.SetInt("Weekday", 2);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("3"))
			{
				PlayerPrefs.SetInt("Weekday", 3);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("4"))
			{
				PlayerPrefs.SetInt("Weekday", 4);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("5"))
			{
				PlayerPrefs.SetInt("Weekday", 5);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("6"))
			{
				this.Yandere.transform.position = this.TeleportSpot[1].position;
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("7"))
			{
				this.Yandere.transform.position = this.TeleportSpot[2].position;
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("8"))
			{
				this.Yandere.transform.position = this.TeleportSpot[3].position;
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("9"))
			{
				this.Yandere.transform.position = this.TeleportSpot[4].position;
				this.Window.active = false;
				if (this.StudentManager.Students[16] != null && this.StudentManager.Students[16].Phase < 2)
				{
					this.StudentManager.Students[16].ShoeRemoval.Start();
					this.StudentManager.Students[16].ShoeRemoval.PutOnShoes();
					this.StudentManager.Students[16].transform.position = this.StudentManager.Students[16].Destinations[2].position;
					this.StudentManager.Students[16].Phase = 2;
					this.StudentManager.Students[16].CurrentDestination = this.StudentManager.Students[16].Destinations[2];
					this.StudentManager.Students[16].Pathfinding.target = this.StudentManager.Students[16].Destinations[2];
				}
			}
			else if (Input.GetKeyDown("0"))
			{
				this.CameraEffects.DisableCamera();
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("a"))
			{
				if (PlayerPrefs.GetFloat("SchoolAtmosphere") > 66.66666f)
				{
					PlayerPrefs.SetFloat("SchoolAtmosphere", (float)50);
				}
				else if (PlayerPrefs.GetFloat("SchoolAtmosphere") > 33.33333f)
				{
					PlayerPrefs.SetFloat("SchoolAtmosphere", (float)0);
				}
				else
				{
					PlayerPrefs.SetFloat("SchoolAtmosphere", (float)100);
				}
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("c"))
			{
				this.ID = 1;
				while (this.ID < 11)
				{
					PlayerPrefs.SetInt("Tape_" + this.ID + "_Collected", 1);
					this.ID++;
				}
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("f"))
			{
				this.FakeStudentSpawner.Spawn();
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("g"))
			{
				if (this.Clock.HourTime < (float)15)
				{
					PlayerPrefs.SetInt("7_Friend", 1);
					this.Yandere.transform.position = this.RooftopSpot.position;
					if (this.StudentManager.Students[7] != null)
					{
						this.StudentManager.Students[7].transform.position = this.RooftopSpot.position;
						this.StudentManager.Students[7].Prompt.Label[0].text = "     " + "Push";
						this.StudentManager.Students[7].CurrentDestination = this.RooftopSpot;
						this.StudentManager.Students[7].Pathfinding.target = this.RooftopSpot;
						this.StudentManager.Students[7].Pathfinding.canSearch = true;
						this.StudentManager.Students[7].Pathfinding.canMove = true;
						this.StudentManager.Students[7].Meeting = true;
						this.StudentManager.Students[7].MeetTime = (float)0;
					}
					if (this.Clock.HourTime < 7.1f)
					{
						this.Clock.PresentTime = 426f;
					}
				}
				else
				{
					this.Clock.PresentTime = (float)960;
					this.StudentManager.Students[7].transform.position = this.Lockers.position;
				}
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("k"))
			{
				PlayerPrefs.SetInt("KidnapVictim", 6);
				PlayerPrefs.SetInt("Student_6_Slave", 1);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("m"))
			{
				PlayerPrefs.SetInt("Student_6_Slave", 1);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("o"))
			{
				this.Yandere.Inventory.RivalPhone = true;
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("p"))
			{
				PlayerPrefs.SetInt("PantyShots", 17);
				this.Window.active = false;
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
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("s"))
			{
				PlayerPrefs.SetInt("PhysicalGrade", 5);
				PlayerPrefs.SetInt("Seduction", 5);
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("t"))
			{
				if (!this.Zoom.OverShoulder)
				{
					this.Zoom.OverShoulder = true;
				}
				else
				{
					this.Zoom.OverShoulder = false;
				}
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("backspace"))
			{
				Time.timeScale = (float)1;
				this.Clock.PresentTime = (float)1079;
				this.Clock.HourTime = this.Clock.PresentTime / (float)60;
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("`"))
			{
				PlayerPrefs.DeleteAll();
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("space"))
			{
				this.Yandere.transform.position = this.TeleportSpot[5].position;
				if (this.StudentManager.Students[21] != null)
				{
					this.StudentManager.Students[21].transform.position = this.TeleportSpot[5].position;
				}
				this.Clock.PresentTime = (float)1015;
				this.Clock.HourTime = this.Clock.PresentTime / (float)60;
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("left alt"))
			{
				this.CircularSaw.transform.position = this.TeleportSpot[6].position;
				this.Yandere.transform.position = this.TeleportSpot[6].position;
				if (this.StudentManager.Students[26] != null)
				{
					this.StudentManager.Students[26].transform.position = this.TeleportSpot[6].position;
				}
				this.Clock.PresentTime = (float)435;
				this.Clock.HourTime = this.Clock.PresentTime / (float)60;
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("left ctrl"))
			{
				this.Yandere.transform.position = this.TeleportSpot[7].position;
				if (this.StudentManager.Students[26] != null)
				{
					this.StudentManager.Students[26].transform.position = this.TeleportSpot[7].position;
				}
				this.Clock.PresentTime = (float)1015;
				this.Clock.HourTime = this.Clock.PresentTime / (float)60;
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("="))
			{
				this.Clock.PresentTime = this.Clock.PresentTime + (float)30;
				this.Window.active = false;
			}
		}
		else if (Input.GetKeyDown("`"))
		{
			this.ID = 0;
			while (this.ID < this.StudentManager.NPCsTotal)
			{
				if (PlayerPrefs.GetInt("Student_" + this.ID + "_Dying") == 1)
				{
					PlayerPrefs.SetInt("Student_" + this.ID + "_Dying", 0);
				}
				this.ID++;
			}
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public virtual void Main()
	{
	}
}
