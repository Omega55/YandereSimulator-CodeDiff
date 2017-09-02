using System;
using UnityEngine;

public class TitleSaveFilesScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public TitleSaveDataScript[] SaveDatas;

	public TitleMenuScript Menu;

	public Transform Highlight;

	public bool Show;

	public int ID = 1;

	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.UpdateHighlight();
	}

	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
		}
		else
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				if (this.ID > 3)
				{
					this.ID = 1;
				}
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				if (this.ID < 1)
				{
					this.ID = 3;
				}
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				if (this.SaveDatas[this.ID].EmptyFile.activeInHierarchy)
				{
					SaveFile saveFile = new SaveFile(this.ID);
					SaveFileData data = saveFile.Data;
					data.Kills = 0;
					data.Atmosphere = 100f;
					data.Alerts = 0;
					data.Week = 1;
					data.Day = "Sunday";
					data.Rival = "Osana";
					data.Reputation = 0f;
					data.Club = "None";
					data.Friends = 0;
					saveFile.Save();
					this.SaveDatas[this.ID].Start();
				}
				else
				{
					Globals.CurrentSaveFile = this.ID;
					this.Menu.FadeOut = true;
					this.Menu.Fading = true;
				}
			}
			else if (Input.GetButtonDown("X"))
			{
				SaveFile.Delete(this.ID);
				this.SaveDatas[this.ID].Start();
			}
		}
	}

	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(0f, 700f - 350f * (float)this.ID, 0f);
	}
}
