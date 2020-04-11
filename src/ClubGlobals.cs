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
			return GlobalsHelper.GetEnum<ClubType>("Profile_" + GameGlobals.Profile + "_Club");
		}
		set
		{
			GlobalsHelper.SetEnum<ClubType>("Profile_" + GameGlobals.Profile + "_Club", value);
		}
	}

	public static bool GetClubClosed(ClubType clubID)
	{
		object[] array = new object[4];
		array[0] = "Profile_";
		array[1] = GameGlobals.Profile;
		array[2] = "_ClubClosed_";
		int num = 3;
		int num2 = (int)clubID;
		array[num] = num2.ToString();
		return GlobalsHelper.GetBool(string.Concat(array));
	}

	public static void SetClubClosed(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_ClubClosed_", text);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_ClubClosed_",
			text
		}), value);
	}

	public static ClubType[] KeysOfClubClosed()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile + "_ClubClosed_");
	}

	public static bool GetClubKicked(ClubType clubID)
	{
		object[] array = new object[4];
		array[0] = "Profile_";
		array[1] = GameGlobals.Profile;
		array[2] = "_ClubKicked_";
		int num = 3;
		int num2 = (int)clubID;
		array[num] = num2.ToString();
		return GlobalsHelper.GetBool(string.Concat(array));
	}

	public static void SetClubKicked(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_ClubKicked_", text);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_ClubKicked_",
			text
		}), value);
	}

	public static ClubType[] KeysOfClubKicked()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile + "_ClubKicked_");
	}

	public static bool GetQuitClub(ClubType clubID)
	{
		object[] array = new object[4];
		array[0] = "Profile_";
		array[1] = GameGlobals.Profile;
		array[2] = "_QuitClub_";
		int num = 3;
		int num2 = (int)clubID;
		array[num] = num2.ToString();
		return GlobalsHelper.GetBool(string.Concat(array));
	}

	public static void SetQuitClub(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_QuitClub_", text);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_QuitClub_",
			text
		}), value);
	}

	public static ClubType[] KeysOfQuitClub()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile + "_QuitClub_");
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Club");
		foreach (ClubType clubType in ClubGlobals.KeysOfClubClosed())
		{
			object[] array2 = new object[4];
			array2[0] = "Profile_";
			array2[1] = GameGlobals.Profile;
			array2[2] = "_ClubClosed_";
			int num = 3;
			int num2 = (int)clubType;
			array2[num] = num2.ToString();
			Globals.Delete(string.Concat(array2));
		}
		foreach (ClubType clubType2 in ClubGlobals.KeysOfClubKicked())
		{
			object[] array3 = new object[4];
			array3[0] = "Profile_";
			array3[1] = GameGlobals.Profile;
			array3[2] = "_ClubKicked_";
			int num3 = 3;
			int num2 = (int)clubType2;
			array3[num3] = num2.ToString();
			Globals.Delete(string.Concat(array3));
		}
		foreach (ClubType clubType3 in ClubGlobals.KeysOfQuitClub())
		{
			object[] array4 = new object[4];
			array4[0] = "Profile_";
			array4[1] = GameGlobals.Profile;
			array4[2] = "_QuitClub_";
			int num4 = 3;
			int num2 = (int)clubType3;
			array4[num4] = num2.ToString();
			Globals.Delete(string.Concat(array4));
		}
		KeysHelper.Delete("Profile_" + GameGlobals.Profile + "_ClubClosed_");
		KeysHelper.Delete("Profile_" + GameGlobals.Profile + "_ClubKicked_");
		KeysHelper.Delete("Profile_" + GameGlobals.Profile + "_QuitClub_");
	}
}
