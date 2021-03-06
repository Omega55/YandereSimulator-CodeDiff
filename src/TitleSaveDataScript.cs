﻿using System;
using UnityEngine;

public class TitleSaveDataScript : MonoBehaviour
{
	public GameObject EmptyFile;

	public GameObject Data;

	public Texture[] Bloods;

	public UITexture Blood;

	public UILabel Kills;

	public UILabel Mood;

	public UILabel Alerts;

	public UILabel Week;

	public UILabel Day;

	public UILabel Rival;

	public UILabel Rep;

	public UILabel Club;

	public UILabel Friends;

	public int ID;

	public void Start()
	{
		if (PlayerPrefs.GetInt("ProfileCreated_" + this.ID) == 1)
		{
			GameGlobals.Profile = this.ID;
			this.EmptyFile.SetActive(false);
			this.Data.SetActive(true);
			this.Kills.text = "Kills: " + PlayerGlobals.Kills;
			this.Mood.text = "Mood: " + Mathf.RoundToInt(SchoolGlobals.SchoolAtmosphere * 100f);
			this.Alerts.text = "Alerts: " + PlayerGlobals.Alerts;
			this.Week.text = "Week: " + 1;
			this.Day.text = "Day: " + DateGlobals.Weekday;
			this.Rival.text = "Rival: Osana";
			this.Rep.text = "Rep: " + PlayerGlobals.Reputation;
			this.Club.text = "Club: " + ClubGlobals.Club;
			this.Friends.text = "Friends: " + PlayerGlobals.Friends;
			if (PlayerGlobals.Kills == 0)
			{
				this.Blood.mainTexture = null;
				return;
			}
			if (PlayerGlobals.Kills > 0)
			{
				this.Blood.mainTexture = this.Bloods[1];
				return;
			}
			if (PlayerGlobals.Kills > 5)
			{
				this.Blood.mainTexture = this.Bloods[2];
				return;
			}
			if (PlayerGlobals.Kills > 10)
			{
				this.Blood.mainTexture = this.Bloods[3];
				return;
			}
			if (PlayerGlobals.Kills > 15)
			{
				this.Blood.mainTexture = this.Bloods[4];
				return;
			}
			if (PlayerGlobals.Kills > 20)
			{
				this.Blood.mainTexture = this.Bloods[5];
				return;
			}
		}
		else
		{
			this.EmptyFile.SetActive(true);
			this.Data.SetActive(false);
			this.Blood.enabled = false;
		}
	}
}
