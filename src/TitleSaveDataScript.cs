using System;
using UnityEngine;

public class TitleSaveDataScript : MonoBehaviour
{
	public GameObject EmptyFile;

	public GameObject Data;

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

	private SaveFile saveFile;

	public void Start()
	{
		if (SaveFile.SaveFileExists(this.ID))
		{
			this.EmptyFile.SetActive(false);
			this.Data.SetActive(true);
			this.saveFile = SaveFile.Load(this.ID);
			SaveFileData data = this.saveFile.Data;
			this.Kills.text = "Kills: " + data.playerData.kills;
			this.Mood.text = "Atm.: " + data.schoolData.schoolAtmosphere;
			this.Alerts.text = "Alerts: " + data.playerData.alerts;
			this.Week.text = "Week: " + data.dateData.week;
			this.Day.text = "Day: " + data.dateData.weekday;
			this.Rival.text = "Rival: Osana";
			this.Rep.text = "Rep: " + data.playerData.reputation;
			this.Club.text = "Club: " + data.clubData.club;
			this.Friends.text = "Friends: 0";
		}
		else
		{
			this.EmptyFile.SetActive(true);
			this.Data.SetActive(false);
		}
	}
}
