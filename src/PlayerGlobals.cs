using System;
using UnityEngine;

public static class PlayerGlobals
{
	private const string Str_Alerts = "Alerts";

	private const string Str_Enlightenment = "Enlightenment";

	private const string Str_EnlightenmentBonus = "EnlightenmentBonus";

	private const string Str_Headset = "Headset";

	private const string Str_Kills = "Kills";

	private const string Str_Numbness = "Numbness";

	private const string Str_NumbnessBonus = "NumbnessBonus";

	private const string Str_PantiesEquipped = "PantiesEquipped";

	private const string Str_PantyShots = "PantyShots";

	private const string Str_Photo = "Photo_";

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

	public static int Alerts
	{
		get
		{
			return PlayerPrefs.GetInt("Alerts");
		}
		set
		{
			PlayerPrefs.SetInt("Alerts", value);
		}
	}

	public static int Enlightenment
	{
		get
		{
			return PlayerPrefs.GetInt("Enlightenment");
		}
		set
		{
			PlayerPrefs.SetInt("Enlightenment", value);
		}
	}

	public static int EnlightenmentBonus
	{
		get
		{
			return PlayerPrefs.GetInt("EnlightenmentBonus");
		}
		set
		{
			PlayerPrefs.SetInt("EnlightenmentBonus", value);
		}
	}

	public static bool Headset
	{
		get
		{
			return GlobalsHelper.GetBool("Headset");
		}
		set
		{
			GlobalsHelper.SetBool("Headset", value);
		}
	}

	public static int Kills
	{
		get
		{
			return PlayerPrefs.GetInt("Kills");
		}
		set
		{
			PlayerPrefs.SetInt("Kills", value);
		}
	}

	public static int Numbness
	{
		get
		{
			return PlayerPrefs.GetInt("Numbness");
		}
		set
		{
			PlayerPrefs.SetInt("Numbness", value);
		}
	}

	public static int NumbnessBonus
	{
		get
		{
			return PlayerPrefs.GetInt("NumbnessBonus");
		}
		set
		{
			PlayerPrefs.SetInt("NumbnessBonus", value);
		}
	}

	public static int PantiesEquipped
	{
		get
		{
			return PlayerPrefs.GetInt("PantiesEquipped");
		}
		set
		{
			PlayerPrefs.SetInt("PantiesEquipped", value);
		}
	}

	public static int PantyShots
	{
		get
		{
			return PlayerPrefs.GetInt("PantyShots");
		}
		set
		{
			PlayerPrefs.SetInt("PantyShots", value);
		}
	}

	public static bool GetPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Photo_" + photoID.ToString());
	}

	public static void SetPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Photo_", text);
		GlobalsHelper.SetBool("Photo_" + text, value);
	}

	public static int[] KeysOfPhoto()
	{
		return KeysHelper.GetIntegerKeys("Photo_");
	}

	public static float Reputation
	{
		get
		{
			return PlayerPrefs.GetFloat("Reputation");
		}
		set
		{
			PlayerPrefs.SetFloat("Reputation", value);
		}
	}

	public static int Seduction
	{
		get
		{
			return PlayerPrefs.GetInt("Seduction");
		}
		set
		{
			PlayerPrefs.SetInt("Seduction", value);
		}
	}

	public static int SeductionBonus
	{
		get
		{
			return PlayerPrefs.GetInt("SeductionBonus");
		}
		set
		{
			PlayerPrefs.SetInt("SeductionBonus", value);
		}
	}

	public static bool GetSenpaiPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("SenpaiPhoto_" + photoID.ToString());
	}

	public static void SetSenpaiPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("SenpaiPhoto_", text);
		GlobalsHelper.SetBool("SenpaiPhoto_" + text, value);
	}

	public static int[] KeysOfSenpaiPhoto()
	{
		return KeysHelper.GetIntegerKeys("SenpaiPhoto_");
	}

	public static int SenpaiShots
	{
		get
		{
			return PlayerPrefs.GetInt("SenpaiShots");
		}
		set
		{
			PlayerPrefs.SetInt("SenpaiShots", value);
		}
	}

	public static int SocialBonus
	{
		get
		{
			return PlayerPrefs.GetInt("SocialBonus");
		}
		set
		{
			PlayerPrefs.SetInt("SocialBonus", value);
		}
	}

	public static int SpeedBonus
	{
		get
		{
			return PlayerPrefs.GetInt("SpeedBonus");
		}
		set
		{
			PlayerPrefs.SetInt("SpeedBonus", value);
		}
	}

	public static int StealthBonus
	{
		get
		{
			return PlayerPrefs.GetInt("StealthBonus");
		}
		set
		{
			PlayerPrefs.SetInt("StealthBonus", value);
		}
	}

	public static bool GetStudentFriend(int studentID)
	{
		return GlobalsHelper.GetBool("StudentFriend_" + studentID.ToString());
	}

	public static void SetStudentFriend(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentFriend_", text);
		GlobalsHelper.SetBool("StudentFriend_" + text, value);
	}

	public static int[] KeysOfStudentFriend()
	{
		return KeysHelper.GetIntegerKeys("StudentFriend_");
	}

	public static bool GetStudentPantyShot(string studentName)
	{
		return GlobalsHelper.GetBool("StudentPantyShot_" + studentName);
	}

	public static void SetStudentPantyShot(string studentName, bool value)
	{
		KeysHelper.AddIfMissing("StudentPantyShot_", studentName);
		GlobalsHelper.SetBool("StudentPantyShot_" + studentName, value);
	}

	public static string[] KeysOfStudentPantyShot()
	{
		return KeysHelper.GetStringKeys("StudentPantyShot_");
	}

	public static void DeleteAll()
	{
		Globals.Delete("Alerts");
		Globals.Delete("Enlightenment");
		Globals.Delete("EnlightenmentBonus");
		Globals.Delete("Headset");
		Globals.Delete("Kills");
		Globals.Delete("Numbness");
		Globals.Delete("NumbnessBonus");
		Globals.Delete("PantiesEquipped");
		Globals.Delete("PantyShots");
		Globals.DeleteCollection("Photo_", PlayerGlobals.KeysOfPhoto());
		Globals.Delete("Reputation");
		Globals.Delete("Seduction");
		Globals.Delete("SeductionBonus");
		Globals.DeleteCollection("SenpaiPhoto_", PlayerGlobals.KeysOfSenpaiPhoto());
		Globals.Delete("SenpaiShots");
		Globals.Delete("SocialBonus");
		Globals.Delete("SpeedBonus");
		Globals.Delete("StealthBonus");
		Globals.DeleteCollection("StudentFriend_", PlayerGlobals.KeysOfStudentFriend());
		Globals.DeleteCollection("StudentPantyShot_", PlayerGlobals.KeysOfStudentPantyShot());
	}
}
