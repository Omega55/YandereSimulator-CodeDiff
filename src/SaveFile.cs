using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class SaveFile
{
	[SerializeField]
	private SaveFileData data;

	[SerializeField]
	private int index;

	private static readonly string FolderPath = Path.Combine(Application.persistentDataPath, "Saves");

	public SaveFile(int index)
	{
		this.data = new SaveFileData();
		this.index = index;
	}

	private SaveFile(SaveFileData data, int index)
	{
		this.data = data;
		this.index = index;
	}

	public SaveFileData Data
	{
		get
		{
			return this.data;
		}
	}

	private static string GetSaveFileName(int index)
	{
		return Path.Combine(SaveFile.FolderPath, "Save" + index.ToString() + ".txt");
	}

	private static bool SaveFolderExists
	{
		get
		{
			return Directory.Exists(SaveFile.FolderPath);
		}
	}

	public static bool Exists(int index)
	{
		return File.Exists(SaveFile.GetSaveFileName(index));
	}

	public static SaveFile Load(int index)
	{
		SaveFile result;
		try
		{
			string s = File.ReadAllText(SaveFile.GetSaveFileName(index));
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveFileData));
			MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
			SaveFileData saveFileData = (SaveFileData)xmlSerializer.Deserialize(stream);
			result = new SaveFile(saveFileData, index);
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Concat(new string[]
			{
				"Loading save file ",
				index.ToString(),
				" failed (",
				ex.ToString(),
				")."
			}));
			result = null;
		}
		return result;
	}

	public static void Delete(int index)
	{
		try
		{
			string saveFileName = SaveFile.GetSaveFileName(index);
			File.Delete(saveFileName);
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Concat(new string[]
			{
				"Deleting save file ",
				index.ToString(),
				" failed (",
				ex.ToString(),
				")."
			}));
		}
	}

	public void Save()
	{
		try
		{
			if (!SaveFile.SaveFolderExists)
			{
				Directory.CreateDirectory(SaveFile.FolderPath);
			}
			string saveFileName = SaveFile.GetSaveFileName(this.index);
			if (!SaveFile.Exists(this.index))
			{
				FileStream fileStream = File.Create(saveFileName);
				fileStream.Dispose();
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveFileData));
			using (XmlWriter xmlWriter = XmlWriter.Create(saveFileName, new XmlWriterSettings
			{
				Indent = true,
				IndentChars = "\t"
			}))
			{
				xmlSerializer.Serialize(xmlWriter, this.data);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Concat(new string[]
			{
				"Saving save file ",
				this.index.ToString(),
				" failed (",
				ex.ToString(),
				")."
			}));
		}
	}

	public void ReadFromGlobals()
	{
		this.data.applicationData = ApplicationSaveData.ReadFromGlobals();
		this.data.classData = ClassSaveData.ReadFromGlobals();
		this.data.clubData = ClubSaveData.ReadFromGlobals();
		this.data.collectibleData = CollectibleSaveData.ReadFromGlobals();
		this.data.conversationData = ConversationSaveData.ReadFromGlobals();
		this.data.dateData = DateSaveData.ReadFromGlobals();
		this.data.datingData = DatingSaveData.ReadFromGlobals();
		this.data.eventData = EventSaveData.ReadFromGlobals();
		this.data.gameData = GameSaveData.ReadFromGlobals();
		this.data.homeData = HomeSaveData.ReadFromGlobals();
		this.data.missionModeData = MissionModeSaveData.ReadFromGlobals();
		this.data.optionData = OptionSaveData.ReadFromGlobals();
		this.data.playerData = PlayerSaveData.ReadFromGlobals();
		this.data.poseModeData = PoseModeSaveData.ReadFromGlobals();
		this.data.saveFileData = SaveFileSaveData.ReadFromGlobals();
		this.data.schemeData = SchemeSaveData.ReadFromGlobals();
		this.data.schoolData = SchoolSaveData.ReadFromGlobals();
		this.data.senpaiData = SenpaiSaveData.ReadFromGlobals();
		this.data.studentData = StudentSaveData.ReadFromGlobals();
		this.data.taskData = TaskSaveData.ReadFromGlobals();
		this.data.yanvaniaData = YanvaniaSaveData.ReadFromGlobals();
	}

	public void WriteToGlobals()
	{
		ApplicationSaveData.WriteToGlobals(this.data.applicationData);
		ClassSaveData.WriteToGlobals(this.data.classData);
		ClubSaveData.WriteToGlobals(this.data.clubData);
		CollectibleSaveData.WriteToGlobals(this.data.collectibleData);
		ConversationSaveData.WriteToGlobals(this.data.conversationData);
		DateSaveData.WriteToGlobals(this.data.dateData);
		DatingSaveData.WriteToGlobals(this.data.datingData);
		EventSaveData.WriteToGlobals(this.data.eventData);
		GameSaveData.WriteToGlobals(this.data.gameData);
		HomeSaveData.WriteToGlobals(this.data.homeData);
		MissionModeSaveData.WriteToGlobals(this.data.missionModeData);
		OptionSaveData.WriteToGlobals(this.data.optionData);
		PlayerSaveData.WriteToGlobals(this.data.playerData);
		PoseModeSaveData.WriteToGlobals(this.data.poseModeData);
		SaveFileSaveData.WriteToGlobals(this.data.saveFileData);
		SchemeSaveData.WriteToGlobals(this.data.schemeData);
		SchoolSaveData.WriteToGlobals(this.data.schoolData);
		SenpaiSaveData.WriteToGlobals(this.data.senpaiData);
		StudentSaveData.WriteToGlobals(this.data.studentData);
		TaskSaveData.WriteToGlobals(this.data.taskData);
		YanvaniaSaveData.WriteToGlobals(this.data.yanvaniaData);
	}
}
