using System;
using UnityEngine;

public static class TaskGlobals
{
	private const string Str_KittenPhoto = "KittenPhoto_";

	private const string Str_TaskStatus = "TaskStatus_";

	public static bool GetKittenPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("KittenPhoto_" + photoID.ToString());
	}

	public static void SetKittenPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("KittenPhoto_", text);
		GlobalsHelper.SetBool("KittenPhoto_" + text, value);
	}

	public static int[] KeysOfKittenPhoto()
	{
		return KeysHelper.GetIntegerKeys("KittenPhoto_");
	}

	public static int GetTaskStatus(int taskID)
	{
		return PlayerPrefs.GetInt("TaskStatus_" + taskID.ToString());
	}

	public static void SetTaskStatus(int taskID, int value)
	{
		string text = taskID.ToString();
		KeysHelper.AddIfMissing("TaskStatus_", text);
		PlayerPrefs.SetInt("TaskStatus_" + text, value);
	}

	public static int[] KeysOfTaskStatus()
	{
		return KeysHelper.GetIntegerKeys("TaskStatus_");
	}

	public static void DeleteAll()
	{
		Globals.DeleteCollection("KittenPhoto_", TaskGlobals.KeysOfKittenPhoto());
		Globals.DeleteCollection("TaskStatus_", TaskGlobals.KeysOfTaskStatus());
	}
}
