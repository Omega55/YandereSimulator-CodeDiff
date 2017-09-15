using System;

public static class YanvaniaGlobals
{
	private const string Str_DraculaDefeated = "DraculaDefeated";

	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";

	public static bool DraculaDefeated
	{
		get
		{
			return GlobalsHelper.GetBool("DraculaDefeated");
		}
		set
		{
			GlobalsHelper.SetBool("DraculaDefeated", value);
		}
	}

	public static bool MidoriEasterEgg
	{
		get
		{
			return GlobalsHelper.GetBool("MidoriEasterEgg");
		}
		set
		{
			GlobalsHelper.SetBool("MidoriEasterEgg", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("DraculaDefeated");
		Globals.Delete("MidoriEasterEgg");
	}
}
