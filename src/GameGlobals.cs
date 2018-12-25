using System;
using UnityEngine;

public static class GameGlobals
{
	private const string Str_Profile = "Profile";

	private const string Str_LoveSick = "LoveSick";

	private const string Str_MasksBanned = "MasksBanned";

	private const string Str_Paranormal = "Paranormal";

	private const string Str_EasyMode = "EasyMode";

	private const string Str_HardMode = "HardMode";

	private const string Str_EmptyDemon = "EmptyDemon";

	public static int Profile
	{
		get
		{
			return PlayerPrefs.GetInt("Profile");
		}
		set
		{
			PlayerPrefs.SetInt("Profile", value);
		}
	}

	public static bool LoveSick
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_LoveSick");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_LoveSick", value);
		}
	}

	public static bool MasksBanned
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_MasksBanned");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_MasksBanned", value);
		}
	}

	public static bool Paranormal
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_Paranormal");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_Paranormal", value);
		}
	}

	public static bool EasyMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_EasyMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_EasyMode", value);
		}
	}

	public static bool HardMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_HardMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_HardMode", value);
		}
	}

	public static bool EmptyDemon
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_EmptyDemon");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_EmptyDemon", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_LoveSick");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MasksBanned");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Paranormal");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_EasyMode");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_HardMode");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_EmptyDemon");
	}
}
