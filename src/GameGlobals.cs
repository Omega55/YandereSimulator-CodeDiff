using System;

public static class GameGlobals
{
	private const string Str_LoveSick = "LoveSick";

	private const string Str_MasksBanned = "MasksBanned";

	private const string Str_Paranormal = "Paranormal";

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

	public static void DeleteAll()
	{
		Globals.Delete("LoveSick");
		Globals.Delete("MasksBanned");
		Globals.Delete("Paranormal");
	}
}
