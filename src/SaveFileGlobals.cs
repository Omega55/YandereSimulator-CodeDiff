using System;
using UnityEngine;

public static class SaveFileGlobals
{
	private const string Str_CurrentSaveFile = "CurrentSaveFile";

	public static int CurrentSaveFile
	{
		get
		{
			return PlayerPrefs.GetInt("CurrentSaveFile");
		}
		set
		{
			PlayerPrefs.SetInt("CurrentSaveFile", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("CurrentSaveFile");
	}
}
