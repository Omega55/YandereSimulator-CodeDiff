﻿using System;
using UnityEngine;

public static class PlayerGlobals
{
	private const string Str_Money = "Money";

	private const string Str_Alerts = "Alerts";

	private const string Str_BullyPhoto = "BullyPhoto_";

	private const string Str_Enlightenment = "Enlightenment";

	private const string Str_EnlightenmentBonus = "EnlightenmentBonus";

	private const string Str_Friends = "Friends";

	private const string Str_Headset = "Headset";

	private const string Str_FakeID = "FakeID";

	private const string Str_RaibaruLoner = "RaibaruLoner";

	private const string Str_Kills = "Kills";

	private const string Str_Numbness = "Numbness";

	private const string Str_NumbnessBonus = "NumbnessBonus";

	private const string Str_PantiesEquipped = "PantiesEquipped";

	private const string Str_PantyShots = "PantyShots";

	private const string Str_Photo = "Photo_";

	private const string Str_PhotoOnCorkboard = "PhotoOnCorkboard_";

	private const string Str_PhotoPosition = "PhotoPosition_";

	private const string Str_PhotoRotation = "PhotoRotation_";

	private const string Str_Reputation = "Reputation";

	private const string Str_Seduction = "Seduction";

	private const string Str_SeductionBonus = "SeductionBonus";

	private const string Str_SenpaiPhoto = "SenpaiPhoto_";

	private const string Str_SenpaiShots = "SenpaiShots";

	private const string Str_SocialBonus = "SocialBonus";

	private const string Str_SpeedBonus = "SpeedBonus";

	private const string Str_StealthBonus = "StealthBonus";

	private const string Str_StudentFriend = "StudentFriend_";

	private const string Str_StudentPantyShot = "StudentPantyShot_";

	private const string Str_ShrineCollectible = "ShrineCollectible_";

	private const string Str_UsingGamepad = "UsingGamepad";

	public static float Money
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile + "_Money");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_Money", value);
		}
	}

	public static int Alerts
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Alerts");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Alerts", value);
		}
	}

	public static int Enlightenment
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Enlightenment");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Enlightenment", value);
		}
	}

	public static int EnlightenmentBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_EnlightenmentBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_EnlightenmentBonus", value);
		}
	}

	public static int Friends
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Friends");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Friends", value);
		}
	}

	public static bool Headset
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_Headset");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_Headset", value);
		}
	}

	public static bool FakeID
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_FakeID");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_FakeID", value);
		}
	}

	public static bool RaibaruLoner
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_RaibaruLoner");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_RaibaruLoner", value);
		}
	}

	public static int Kills
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Kills");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Kills", value);
		}
	}

	public static int Numbness
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Numbness");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Numbness", value);
		}
	}

	public static int NumbnessBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_NumbnessBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_NumbnessBonus", value);
		}
	}

	public static int PantiesEquipped
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PantiesEquipped");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PantiesEquipped", value);
		}
	}

	public static int PantyShots
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PantyShots");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PantyShots", value);
		}
	}

	public static bool GetPhoto(int photoID)
	{
		return GlobalsHelper.GetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_Photo_",
			photoID.ToString()
		}));
	}

	public static void SetPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_Photo_", text);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_Photo_",
			text
		}), value);
	}

	public static int[] KeysOfPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_Photo_");
	}

	public static bool GetPhotoOnCorkboard(int photoID)
	{
		return GlobalsHelper.GetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_PhotoOnCorkboard_",
			photoID.ToString()
		}));
	}

	public static void SetPhotoOnCorkboard(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_PhotoOnCorkboard_", text);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_PhotoOnCorkboard_",
			text
		}), value);
	}

	public static int[] KeysOfPhotoOnCorkboard()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_PhotoOnCorkboard_");
	}

	public static Vector2 GetPhotoPosition(int photoID)
	{
		return GlobalsHelper.GetVector2(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_PhotoPosition_",
			photoID.ToString()
		}));
	}

	public static void SetPhotoPosition(int photoID, Vector2 value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_PhotoPosition_", text);
		GlobalsHelper.SetVector2(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_PhotoPosition_",
			text
		}), value);
	}

	public static int[] KeysOfPhotoPosition()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_PhotoPosition_");
	}

	public static float GetPhotoRotation(int photoID)
	{
		return PlayerPrefs.GetFloat(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_PhotoRotation_",
			photoID.ToString()
		}));
	}

	public static void SetPhotoRotation(int photoID, float value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_PhotoRotation_", text);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_PhotoRotation_",
			text
		}), value);
	}

	public static int[] KeysOfPhotoRotation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_PhotoRotation_");
	}

	public static float Reputation
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile + "_Reputation");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_Reputation", value);
		}
	}

	public static int Seduction
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Seduction");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Seduction", value);
		}
	}

	public static int SeductionBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SeductionBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SeductionBonus", value);
		}
	}

	public static bool GetSenpaiPhoto(int photoID)
	{
		return GlobalsHelper.GetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_SenpaiPhoto_",
			photoID.ToString()
		}));
	}

	public static void SetSenpaiPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_SenpaiPhoto_", text);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_SenpaiPhoto_",
			text
		}), value);
	}

	public static int GetBullyPhoto(int photoID)
	{
		return PlayerPrefs.GetInt(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_BullyPhoto_",
			photoID.ToString()
		}));
	}

	public static void SetBullyPhoto(int photoID, int value)
	{
		PlayerPrefs.SetInt(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_BullyPhoto_",
			photoID.ToString()
		}), value);
	}

	public static int[] KeysOfSenpaiPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_SenpaiPhoto_");
	}

	public static int SenpaiShots
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SenpaiShots");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SenpaiShots", value);
		}
	}

	public static int SocialBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SocialBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SocialBonus", value);
		}
	}

	public static int SpeedBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SpeedBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SpeedBonus", value);
		}
	}

	public static int StealthBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_StealthBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_StealthBonus", value);
		}
	}

	public static bool GetStudentFriend(int studentID)
	{
		return GlobalsHelper.GetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_StudentFriend_",
			studentID.ToString()
		}));
	}

	public static void SetStudentFriend(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_StudentFriend_", text);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_StudentFriend_",
			text
		}), value);
	}

	public static int[] KeysOfStudentFriend()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_StudentFriend_");
	}

	public static bool GetStudentPantyShot(string studentName)
	{
		return GlobalsHelper.GetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_StudentPantyShot_",
			studentName
		}));
	}

	public static void SetStudentPantyShot(string studentName, bool value)
	{
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_StudentPantyShot_", studentName);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_StudentPantyShot_",
			studentName
		}), value);
	}

	public static string[] KeysOfStudentPantyShot()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile + "_StudentPantyShot_");
	}

	public static string[] KeysOfShrineCollectible()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile + "_ShrineCollectible_");
	}

	public static bool GetShrineCollectible(int ID)
	{
		return GlobalsHelper.GetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_ShrineCollectible_",
			ID.ToString()
		}));
	}

	public static void SetShrineCollectible(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_ShrineCollectible_", text);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"Profile_",
			GameGlobals.Profile,
			"_ShrineCollectible_",
			text
		}), value);
	}

	public static bool UsingGamepad
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_UsingGamepad");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_UsingGamepad", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Money");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Alerts");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Enlightenment");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_EnlightenmentBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Friends");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Headset");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_FakeID");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_RaibaruLoner");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Kills");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Numbness");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_NumbnessBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PantiesEquipped");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PantyShots");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_Photo_", PlayerGlobals.KeysOfPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_PhotoOnCorkboard_", PlayerGlobals.KeysOfPhotoOnCorkboard());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_PhotoPosition_", PlayerGlobals.KeysOfPhotoPosition());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_PhotoRotation_", PlayerGlobals.KeysOfPhotoRotation());
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Reputation");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Seduction");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SeductionBonus");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_SenpaiPhoto_", PlayerGlobals.KeysOfSenpaiPhoto());
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SenpaiShots");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SocialBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SpeedBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_StealthBonus");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_StudentFriend_", PlayerGlobals.KeysOfStudentFriend());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_StudentPantyShot_", PlayerGlobals.KeysOfStudentPantyShot());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_ShrineCollectible_", PlayerGlobals.KeysOfShrineCollectible());
	}
}
