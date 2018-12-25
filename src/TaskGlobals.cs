using System;
using UnityEngine;

public static class TaskGlobals
{
	private const string Str_GuitarPhoto = "GuitarPhoto_";

	private const string Str_KittenPhoto = "KittenPhoto_";

	private const string Str_TaskStatus = "TaskStatus_";

	public static bool GetGuitarPhoto(int photoID)
	{
		return GlobalsHelper.GetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_GuitarPhoto_",
			photoID.ToString()
		}));
	}

	public static void SetGuitarPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_GuitarPhoto_", text);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_GuitarPhoto_",
			text
		}), value);
	}

	public static int[] KeysOfGuitarPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_GuitarPhoto_");
	}

	public static bool GetKittenPhoto(int photoID)
	{
		return GlobalsHelper.GetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_KittenPhoto_",
			photoID.ToString()
		}));
	}

	public static void SetKittenPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_KittenPhoto_", text);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_KittenPhoto_",
			text
		}), value);
	}

	public static int[] KeysOfKittenPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_KittenPhoto_");
	}

	public static int GetTaskStatus(int taskID)
	{
		return PlayerPrefs.GetInt(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_TaskStatus_",
			taskID.ToString()
		}));
	}

	public static void SetTaskStatus(int taskID, int value)
	{
		string text = taskID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_TaskStatus_", text);
		PlayerPrefs.SetInt(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_TaskStatus_",
			text
		}), value);
	}

	public static int[] KeysOfTaskStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_TaskStatus_");
	}

	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_GuitarPhoto_", TaskGlobals.KeysOfGuitarPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_KittenPhoto_", TaskGlobals.KeysOfKittenPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_TaskStatus_", TaskGlobals.KeysOfTaskStatus());
	}
}
