using System;

[Serializable]
public class SaveFileSaveData
{
	public int currentSaveFile;

	public SaveFileSaveData()
	{
		this.currentSaveFile = 0;
	}

	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}
}
