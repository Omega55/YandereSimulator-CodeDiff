using System;
using System.Collections.Generic;

[Serializable]
public class TaskSaveData
{
	public IntHashSet kittenPhoto;

	public IntAndIntDictionary taskStatus;

	public TaskSaveData()
	{
		this.kittenPhoto = new IntHashSet();
		this.taskStatus = new IntAndIntDictionary();
	}

	public static TaskSaveData ReadFromGlobals()
	{
		TaskSaveData taskSaveData = new TaskSaveData();
		foreach (int num in TaskGlobals.KeysOfKittenPhoto())
		{
			if (TaskGlobals.GetKittenPhoto(num))
			{
				taskSaveData.kittenPhoto.Add(num);
			}
		}
		foreach (int num2 in TaskGlobals.KeysOfTaskStatus())
		{
			taskSaveData.taskStatus.Add(num2, TaskGlobals.GetTaskStatus(num2));
		}
		return taskSaveData;
	}

	public static void WriteToGlobals(TaskSaveData data)
	{
		foreach (int photoID in data.kittenPhoto)
		{
			TaskGlobals.SetKittenPhoto(photoID, true);
		}
		foreach (KeyValuePair<int, int> keyValuePair in data.taskStatus)
		{
			TaskGlobals.SetTaskStatus(keyValuePair.Key, keyValuePair.Value);
		}
	}
}
