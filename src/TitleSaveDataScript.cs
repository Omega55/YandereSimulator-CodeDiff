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
			this.Kills.text = "Kills: " + this.saveFile.Data.Kills;
			this.Mood.text = "Mood: " + this.saveFile.Data.Atmosphere;
			this.Alerts.text = "Alerts: " + this.saveFile.Data.Alerts;
			this.Week.text = "Week: " + this.saveFile.Data.Week;
			this.Day.text = "Day: " + this.saveFile.Data.Day;
			this.Rival.text = "Rival: " + this.saveFile.Data.Rival;
			this.Rep.text = "Rep: " + this.saveFile.Data.Reputation;
			this.Club.text = "Club: " + this.saveFile.Data.Club;
			this.Friends.text = "Friends: " + this.saveFile.Data.Friends;
		}
		else
		{
			this.EmptyFile.SetActive(true);
			this.Data.SetActive(false);
		}
	}
}
