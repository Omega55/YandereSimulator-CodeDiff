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

	public static bool SaveFileExists(int index)
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
			if (!SaveFile.SaveFileExists(this.index))
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
		throw new NotImplementedException();
	}

	public void WriteToGlobals()
	{
		throw new NotImplementedException();
	}
}
