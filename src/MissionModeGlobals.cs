using System;
using UnityEngine;

public static class MissionModeGlobals
{
	private const string Str_MissionCondition = "MissionCondition_";

	private const string Str_MissionDifficulty = "MissionDifficulty";

	private const string Str_MissionMode = "MissionMode";

	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	private const string Str_MissionTarget = "MissionTarget";

	private const string Str_MissionTargetName = "MissionTargetName";

	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_MissionCondition_",
			id.ToString()
		}));
	}

	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_MissionCondition_", text);
		PlayerPrefs.SetInt(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_MissionCondition_",
			text
		}), value);
	}

	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_MissionCondition_");
	}

	public static int MissionDifficulty
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_MissionDifficulty");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_MissionDifficulty", value);
		}
	}

	public static bool MissionMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_MissionMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_MissionMode", value);
		}
	}

	public static int MissionRequiredClothing
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_MissionRequiredClothing");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_MissionRequiredClothing", value);
		}
	}

	public static int MissionRequiredDisposal
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_MissionRequiredDisposal");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_MissionRequiredDisposal", value);
		}
	}

	public static int MissionRequiredWeapon
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_MissionRequiredWeapon");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_MissionRequiredWeapon", value);
		}
	}

	public static int MissionTarget
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_MissionTarget");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_MissionTarget", value);
		}
	}

	public static string MissionTargetName
	{
		get
		{
			return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile + "_MissionTargetName");
		}
		set
		{
			PlayerPrefs.SetString("Profile_" + GameGlobals.Profile + "_MissionTargetName", value);
		}
	}

	public static int NemesisDifficulty
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_NemesisDifficulty");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_NemesisDifficulty", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_MissionCondition_", MissionModeGlobals.KeysOfMissionCondition());
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MissionDifficulty");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MissionMode");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MissionRequiredClothing");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MissionRequiredDisposal");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MissionRequiredWeapon");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MissionTarget");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MissionTargetName");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_NemesisDifficulty");
	}
}
