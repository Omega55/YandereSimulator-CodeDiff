using System;

public static class ClubGlobals
{
	private const string Str_Club = "Club";

	private const string Str_ClubClosed = "ClubClosed_";

	private const string Str_ClubKicked = "ClubKicked_";

	private const string Str_QuitClub = "QuitClub_";

	public static ClubType Club
	{
		get
		{
			return GlobalsHelper.GetEnum<ClubType>("Club");
		}
		set
		{
			GlobalsHelper.SetEnum<ClubType>("Club", value);
		}
	}

	public static bool GetClubClosed(ClubType clubID)
	{
		string str = "ClubClosed_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + num.ToString());
	}

	public static void SetClubClosed(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("ClubClosed_", text);
		GlobalsHelper.SetBool("ClubClosed_" + text, value);
	}

	public static ClubType[] KeysOfClubClosed()
	{
		return KeysHelper.GetEnumKeys<ClubType>("ClubClosed_");
	}

	public static bool GetClubKicked(ClubType clubID)
	{
		string str = "ClubKicked_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + num.ToString());
	}

	public static void SetClubKicked(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("ClubKicked_", text);
		GlobalsHelper.SetBool("ClubKicked_" + text, value);
	}

	public static ClubType[] KeysOfClubKicked()
	{
		return KeysHelper.GetEnumKeys<ClubType>("ClubKicked_");
	}

	public static bool GetQuitClub(ClubType clubID)
	{
		string str = "QuitClub_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + num.ToString());
	}

	public static void SetQuitClub(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("QuitClub_", text);
		GlobalsHelper.SetBool("QuitClub_" + text, value);
	}

	public static ClubType[] KeysOfQuitClub()
	{
		return KeysHelper.GetEnumKeys<ClubType>("QuitClub_");
	}

	public static void DeleteAll()
	{
		Globals.Delete("Club");
		foreach (ClubType clubType in ClubGlobals.KeysOfClubClosed())
		{
			string str = "ClubClosed_";
			int num = (int)clubType;
			Globals.Delete(str + num.ToString());
		}
		foreach (ClubType clubType2 in ClubGlobals.KeysOfClubKicked())
		{
			string str2 = "ClubKicked_";
			int num2 = (int)clubType2;
			Globals.Delete(str2 + num2.ToString());
		}
		foreach (ClubType clubType3 in ClubGlobals.KeysOfQuitClub())
		{
			string str3 = "QuitClub_";
			int num3 = (int)clubType3;
			Globals.Delete(str3 + num3.ToString());
		}
		KeysHelper.Delete("ClubClosed_");
		KeysHelper.Delete("ClubKicked_");
		KeysHelper.Delete("QuitClub_");
	}
}
