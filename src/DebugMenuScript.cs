﻿using System;
using UnityEngine;

[Serializable]
public class DebugMenuScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public ReputationScript Reputation;

	public YandereScript Yandere;

	public ClassScript Class;

	public ClockScript Clock;

	public Transform[] TeleportSpot;

	public Transform RooftopSpot;

	public GameObject Window;

	public int ID;

	public virtual void Start()
	{
		this.Window.active = false;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown(KeyCode.Backslash))
		{
			if (!this.Window.active)
			{
				this.Window.active = true;
			}
			else
			{
				this.Window.active = false;
			}
		}
		if (this.Window.active)
		{
			if (Input.GetKeyDown("1"))
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
				if (this.Clock.HourTime < 7.075f)
				{
					this.Clock.PresentTime = 424.5f;
				}
			}
			else if (Input.GetKeyDown("0"))
			{
				this.CameraEffects.DisableCamera();
				this.Window.active = false;
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
			else if (Input.GetKeyDown("g"))
			{
				this.StudentManager.Students[14].CurrentDestination = this.RooftopSpot;
				this.StudentManager.Students[14].Pathfinding.target = this.RooftopSpot;
				this.StudentManager.Students[14].Pathfinding.canSearch = true;
				this.StudentManager.Students[14].Pathfinding.canMove = true;
				this.StudentManager.Students[14].Meeting = true;
				this.StudentManager.Students[14].MeetTime = (float)0;
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("r"))
			{
				PlayerPrefs.SetFloat("Reputation", (float)50);
				this.Reputation.Reputation = PlayerPrefs.GetFloat("Reputation");
				this.Window.active = false;
			}
			else if (Input.GetKeyDown("s"))
			{
				this.Class.GivePoints();
				this.Window.active = false;
			}
			if (Input.GetKeyDown("`"))
			{
				PlayerPrefs.DeleteAll();
				Application.LoadLevel(Application.loadedLevel);
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