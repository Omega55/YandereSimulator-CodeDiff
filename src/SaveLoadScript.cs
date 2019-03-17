using System;
using System.IO;
using UnityEngine;

public class SaveLoadScript : MonoBehaviour
{
	public StudentScript Student;

	public string SerializedData;

	public string SaveFilePath;

	public int SaveProfile;

	public int SaveSlot;

	private void DetermineFilePath()
	{
		this.SaveProfile = GameGlobals.Profile;
		this.SaveSlot = PlayerPrefs.GetInt("SaveSlot");
		this.SaveFilePath = string.Concat(new object[]
		{
			Application.streamingAssetsPath,
			"/SaveData/Profile_",
			this.SaveProfile,
			"/Slot_",
			this.SaveSlot,
			"/Student_",
			this.Student.StudentID,
			"_Data.txt"
		});
	}

	public void SaveData()
	{
		this.DetermineFilePath();
		this.SerializedData = JsonUtility.ToJson(this.Student);
		File.WriteAllText(this.SaveFilePath, this.SerializedData);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_posX"
		}), base.transform.position.x);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_posY"
		}), base.transform.position.y);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_posZ"
		}), base.transform.position.z);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_rotX"
		}), base.transform.eulerAngles.x);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_rotY"
		}), base.transform.eulerAngles.y);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_rotZ"
		}), base.transform.eulerAngles.z);
	}

	public void LoadData()
	{
		this.DetermineFilePath();
		if (File.Exists(this.SaveFilePath))
		{
			base.transform.position = new Vector3(PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"_Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_posX"
			})), PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"_Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_posY"
			})), PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"_Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_posZ"
			})));
			base.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_rotX"
			})), PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_rotY"
			})), PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_rotZ"
			})));
			string json = File.ReadAllText(this.SaveFilePath);
			JsonUtility.FromJsonOverwrite(json, this.Student);
		}
	}
}
