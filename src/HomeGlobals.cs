using System;

public static class HomeGlobals
{
	private const string Str_LateForSchool = "LateForSchool";

	private const string Str_Night = "Night";

	private const string Str_StartInBasement = "StartInBasement";

	private const string Str_MiyukiDefeated = "MiyukiDefeated";

	public static bool LateForSchool
	{
		get
		{
			return GlobalsHelper.GetBool("LateForSchool");
		}
		set
		{
			GlobalsHelper.SetBool("LateForSchool", value);
		}
	}

	public static bool Night
	{
		get
		{
			return GlobalsHelper.GetBool("Night");
		}
		set
		{
			GlobalsHelper.SetBool("Night", value);
		}
	}

	public static bool StartInBasement
	{
		get
		{
			return GlobalsHelper.GetBool("StartInBasement");
		}
		set
		{
			GlobalsHelper.SetBool("StartInBasement", value);
		}
	}

	public static bool MiyukiDefeated
	{
		get
		{
			return GlobalsHelper.GetBool("MiyukiDefeated");
		}
		set
		{
			GlobalsHelper.SetBool("MiyukiDefeated", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("LateForSchool");
		Globals.Delete("Night");
		Globals.Delete("StartInBasement");
		Globals.Delete("MiyukiDefeated");
	}
}
