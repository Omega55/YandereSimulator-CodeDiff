using System;
using UnityEngine;

public static class ApplicationGlobals
{
	private const string Str_VersionNumber = "VersionNumber";

	public static float VersionNumber
	{
		get
		{
			return PlayerPrefs.GetFloat("VersionNumber");
		}
		set
		{
			PlayerPrefs.SetFloat("VersionNumber", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("VersionNumber");
	}
}
