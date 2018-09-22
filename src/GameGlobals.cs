using System;

public static class GameGlobals
{
	private const string Str_LoveSick = "LoveSick";

	private const string Str_MasksBanned = "MasksBanned";

	private const string Str_Paranormal = "Paranormal";

	private const string Str_EasyMode = "EasyMode";

	private const string Str_HardMode = "HardMode";

	public static bool LoveSick
	{
		get
		{
			return GlobalsHelper.GetBool("LoveSick");
		}
		set
		{
			GlobalsHelper.SetBool("LoveSick", value);
		}
	}

	public static bool MasksBanned
	{
		get
		{
			return GlobalsHelper.GetBool("MasksBanned");
		}
		set
		{
			GlobalsHelper.SetBool("MasksBanned", value);
		}
	}

	public static bool Paranormal
	{
		get
		{
			return GlobalsHelper.GetBool("Paranormal");
		}
		set
		{
			GlobalsHelper.SetBool("Paranormal", value);
		}
	}

	public static bool EasyMode
	{
		get
		{
			return GlobalsHelper.GetBool("EasyMode");
		}
		set
		{
			GlobalsHelper.SetBool("EasyMode", value);
		}
	}

	public static bool HardMode
	{
		get
		{
			return GlobalsHelper.GetBool("HardMode");
		}
		set
		{
			GlobalsHelper.SetBool("HardMode", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("LoveSick");
		Globals.Delete("MasksBanned");
		Globals.Delete("Paranormal");
		Globals.Delete("HardMode");
	}
}
