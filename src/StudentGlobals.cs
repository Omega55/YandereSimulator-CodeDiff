using System;
using UnityEngine;

public static class StudentGlobals
{
	private const string Str_CustomSuitor = "CustomSuitor";

	private const string Str_CustomSuitorAccessory = "CustomSuitorAccessory";

	private const string Str_CustomSuitorBlonde = "CustomSuitorBlonde";

	private const string Str_CustomSuitorEyewear = "CustomSuitorEyewear";

	private const string Str_CustomSuitorHair = "CustomSuitorHair";

	private const string Str_CustomSuitorJewelry = "CustomSuitorJewelry";

	private const string Str_CustomSuitorTan = "CustomSuitorTan";

	private const string Str_ExpelProgress = "ExpelProgress";

	private const string Str_FemaleUniform = "FemaleUniform";

	private const string Str_MaleUniform = "MaleUniform";

	private const string Str_StudentAccessory = "StudentAccessory_";

	private const string Str_StudentArrested = "StudentArrested_";

	private const string Str_StudentBroken = "StudentBroken_";

	private const string Str_StudentBustSize = "StudentBustSize_";

	private const string Str_StudentColor = "StudentColor_";

	private const string Str_StudentDead = "StudentDead_";

	private const string Str_StudentDying = "StudentDying_";

	private const string Str_StudentExpelled = "StudentExpelled_";

	private const string Str_StudentExposed = "StudentExposed_";

	private const string Str_StudentEyeColor = "StudentEyeColor_";

	private const string Str_StudentGrudge = "StudentGrudge_";

	private const string Str_StudentHairstyle = "StudentHairstyle_";

	private const string Str_StudentKidnapped = "StudentKidnapped_";

	private const string Str_StudentMissing = "StudentMissing_";

	private const string Str_StudentName = "StudentName_";

	private const string Str_StudentPhotographed = "StudentPhotographed_";

	private const string Str_StudentReplaced = "StudentReplaced_";

	private const string Str_StudentReputation = "StudentReputation_";

	private const string Str_StudentSanity = "StudentSanity_";

	private const string Str_StudentSlave = "StudentSlave";

	private const string Str_StudentFragileSlave = "StudentFragileSlave";

	private const string Str_FragileTarget = "FragileTarget";

	public static bool CustomSuitor
	{
		get
		{
			return GlobalsHelper.GetBool("CustomSuitor");
		}
		set
		{
			GlobalsHelper.SetBool("CustomSuitor", value);
		}
	}

	public static int CustomSuitorAccessory
	{
		get
		{
			return PlayerPrefs.GetInt("CustomSuitorAccessory");
		}
		set
		{
			PlayerPrefs.SetInt("CustomSuitorAccessory", value);
		}
	}

	public static int CustomSuitorBlonde
	{
		get
		{
			return PlayerPrefs.GetInt("CustomSuitorBlonde");
		}
		set
		{
			PlayerPrefs.SetInt("CustomSuitorBlonde", value);
		}
	}

	public static int CustomSuitorEyewear
	{
		get
		{
			return PlayerPrefs.GetInt("CustomSuitorEyewear");
		}
		set
		{
			PlayerPrefs.SetInt("CustomSuitorEyewear", value);
		}
	}

	public static int CustomSuitorHair
	{
		get
		{
			return PlayerPrefs.GetInt("CustomSuitorHair");
		}
		set
		{
			PlayerPrefs.SetInt("CustomSuitorHair", value);
		}
	}

	public static int CustomSuitorJewelry
	{
		get
		{
			return PlayerPrefs.GetInt("CustomSuitorJewelry");
		}
		set
		{
			PlayerPrefs.SetInt("CustomSuitorJewelry", value);
		}
	}

	public static bool CustomSuitorTan
	{
		get
		{
			return GlobalsHelper.GetBool("CustomSuitorTan");
		}
		set
		{
			GlobalsHelper.SetBool("CustomSuitorTan", value);
		}
	}

	public static int ExpelProgress
	{
		get
		{
			return PlayerPrefs.GetInt("ExpelProgress");
		}
		set
		{
			PlayerPrefs.SetInt("ExpelProgress", value);
		}
	}

	public static int FemaleUniform
	{
		get
		{
			return PlayerPrefs.GetInt("FemaleUniform");
		}
		set
		{
			PlayerPrefs.SetInt("FemaleUniform", value);
		}
	}

	public static int MaleUniform
	{
		get
		{
			return PlayerPrefs.GetInt("MaleUniform");
		}
		set
		{
			PlayerPrefs.SetInt("MaleUniform", value);
		}
	}

	public static string GetStudentAccessory(int studentID)
	{
		return PlayerPrefs.GetString("StudentAccessory_" + studentID.ToString());
	}

	public static void SetStudentAccessory(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentAccessory_", text);
		PlayerPrefs.SetString("StudentAccessory_" + text, value);
	}

	public static int[] KeysOfStudentAccessory()
	{
		return KeysHelper.GetIntegerKeys("StudentAccessory_");
	}

	public static bool GetStudentArrested(int studentID)
	{
		return GlobalsHelper.GetBool("StudentArrested_" + studentID.ToString());
	}

	public static void SetStudentArrested(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentArrested_", text);
		GlobalsHelper.SetBool("StudentArrested_" + text, value);
	}

	public static int[] KeysOfStudentArrested()
	{
		return KeysHelper.GetIntegerKeys("StudentArrested_");
	}

	public static bool GetStudentBroken(int studentID)
	{
		return GlobalsHelper.GetBool("StudentBroken_" + studentID.ToString());
	}

	public static void SetStudentBroken(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentBroken_", text);
		GlobalsHelper.SetBool("StudentBroken_" + text, value);
	}

	public static int[] KeysOfStudentBroken()
	{
		return KeysHelper.GetIntegerKeys("StudentBroken_");
	}

	public static float GetStudentBustSize(int studentID)
	{
		return PlayerPrefs.GetFloat("StudentBustSize_" + studentID.ToString());
	}

	public static void SetStudentBustSize(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentBustSize_", text);
		PlayerPrefs.SetFloat("StudentBustSize_" + text, value);
	}

	public static int[] KeysOfStudentBustSize()
	{
		return KeysHelper.GetIntegerKeys("StudentBustSize_");
	}

	public static Color GetStudentColor(int studentID)
	{
		return GlobalsHelper.GetColor("StudentColor_" + studentID.ToString());
	}

	public static void SetStudentColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentColor_", text);
		GlobalsHelper.SetColor("StudentColor_" + text, value);
	}

	public static int[] KeysOfStudentColor()
	{
		return KeysHelper.GetIntegerKeys("StudentColor_");
	}

	public static bool GetStudentDead(int studentID)
	{
		return GlobalsHelper.GetBool("StudentDead_" + studentID.ToString());
	}

	public static void SetStudentDead(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentDead_", text);
		GlobalsHelper.SetBool("StudentDead_" + text, value);
	}

	public static int[] KeysOfStudentDead()
	{
		return KeysHelper.GetIntegerKeys("StudentDead_");
	}

	public static bool GetStudentDying(int studentID)
	{
		return GlobalsHelper.GetBool("StudentDying_" + studentID.ToString());
	}

	public static void SetStudentDying(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentDying_", text);
		GlobalsHelper.SetBool("StudentDying_" + text, value);
	}

	public static int[] KeysOfStudentDying()
	{
		return KeysHelper.GetIntegerKeys("StudentDying_");
	}

	public static bool GetStudentExpelled(int studentID)
	{
		return GlobalsHelper.GetBool("StudentExpelled_" + studentID.ToString());
	}

	public static void SetStudentExpelled(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentExpelled_", text);
		GlobalsHelper.SetBool("StudentExpelled_" + text, value);
	}

	public static int[] KeysOfStudentExpelled()
	{
		return KeysHelper.GetIntegerKeys("StudentExpelled_");
	}

	public static bool GetStudentExposed(int studentID)
	{
		return GlobalsHelper.GetBool("StudentExposed_" + studentID.ToString());
	}

	public static void SetStudentExposed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentExposed_", text);
		GlobalsHelper.SetBool("StudentExposed_" + text, value);
	}

	public static int[] KeysOfStudentExposed()
	{
		return KeysHelper.GetIntegerKeys("StudentExposed_");
	}

	public static Color GetStudentEyeColor(int studentID)
	{
		return GlobalsHelper.GetColor("StudentEyeColor_" + studentID.ToString());
	}

	public static void SetStudentEyeColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentEyeColor_", text);
		GlobalsHelper.SetColor("StudentEyeColor_" + text, value);
	}

	public static int[] KeysOfStudentEyeColor()
	{
		return KeysHelper.GetIntegerKeys("StudentEyeColor_");
	}

	public static bool GetStudentGrudge(int studentID)
	{
		return GlobalsHelper.GetBool("StudentGrudge_" + studentID.ToString());
	}

	public static void SetStudentGrudge(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentGrudge_", text);
		GlobalsHelper.SetBool("StudentGrudge_" + text, value);
	}

	public static int[] KeysOfStudentGrudge()
	{
		return KeysHelper.GetIntegerKeys("StudentGrudge_");
	}

	public static string GetStudentHairstyle(int studentID)
	{
		return PlayerPrefs.GetString("StudentHairstyle_" + studentID.ToString());
	}

	public static void SetStudentHairstyle(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentHairstyle_", text);
		PlayerPrefs.SetString("StudentHairstyle_" + text, value);
	}

	public static int[] KeysOfStudentHairstyle()
	{
		return KeysHelper.GetIntegerKeys("StudentHairstyle_");
	}

	public static bool GetStudentKidnapped(int studentID)
	{
		return GlobalsHelper.GetBool("StudentKidnapped_" + studentID.ToString());
	}

	public static void SetStudentKidnapped(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentKidnapped_", text);
		GlobalsHelper.SetBool("StudentKidnapped_" + text, value);
	}

	public static int[] KeysOfStudentKidnapped()
	{
		return KeysHelper.GetIntegerKeys("StudentKidnapped_");
	}

	public static bool GetStudentMissing(int studentID)
	{
		return GlobalsHelper.GetBool("StudentMissing_" + studentID.ToString());
	}

	public static void SetStudentMissing(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentMissing_", text);
		GlobalsHelper.SetBool("StudentMissing_" + text, value);
	}

	public static int[] KeysOfStudentMissing()
	{
		return KeysHelper.GetIntegerKeys("StudentMissing_");
	}

	public static string GetStudentName(int studentID)
	{
		return PlayerPrefs.GetString("StudentName_" + studentID.ToString());
	}

	public static void SetStudentName(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentName_", text);
		PlayerPrefs.SetString("StudentName_" + text, value);
	}

	public static int[] KeysOfStudentName()
	{
		return KeysHelper.GetIntegerKeys("StudentName_");
	}

	public static bool GetStudentPhotographed(int studentID)
	{
		return GlobalsHelper.GetBool("StudentPhotographed_" + studentID.ToString());
	}

	public static void SetStudentPhotographed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentPhotographed_", text);
		GlobalsHelper.SetBool("StudentPhotographed_" + text, value);
	}

	public static int[] KeysOfStudentPhotographed()
	{
		return KeysHelper.GetIntegerKeys("StudentPhotographed_");
	}

	public static bool GetStudentReplaced(int studentID)
	{
		return GlobalsHelper.GetBool("StudentReplaced_" + studentID.ToString());
	}

	public static void SetStudentReplaced(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentReplaced_", text);
		GlobalsHelper.SetBool("StudentReplaced_" + text, value);
	}

	public static int[] KeysOfStudentReplaced()
	{
		return KeysHelper.GetIntegerKeys("StudentReplaced_");
	}

	public static int GetStudentReputation(int studentID)
	{
		return PlayerPrefs.GetInt("StudentReputation_" + studentID.ToString());
	}

	public static void SetStudentReputation(int studentID, int value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentReputation_", text);
		PlayerPrefs.SetInt("StudentReputation_" + text, value);
	}

	public static int[] KeysOfStudentReputation()
	{
		return KeysHelper.GetIntegerKeys("StudentReputation_");
	}

	public static float GetStudentSanity(int studentID)
	{
		return PlayerPrefs.GetFloat("StudentSanity_" + studentID.ToString());
	}

	public static void SetStudentSanity(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("StudentSanity_", text);
		PlayerPrefs.SetFloat("StudentSanity_" + text, value);
	}

	public static int[] KeysOfStudentSanity()
	{
		return KeysHelper.GetIntegerKeys("StudentSanity_");
	}

	public static int GetStudentSlave()
	{
		return PlayerPrefs.GetInt("StudentSlave");
	}

	public static int GetStudentFragileSlave()
	{
		return PlayerPrefs.GetInt("StudentFragileSlave");
	}

	public static void SetStudentSlave(int studentID)
	{
		PlayerPrefs.SetInt("StudentSlave", studentID);
	}

	public static void SetStudentFragileSlave(int studentID)
	{
		PlayerPrefs.SetInt("StudentFragileSlave", studentID);
	}

	public static int[] KeysOfStudentSlave()
	{
		return KeysHelper.GetIntegerKeys("StudentSlave");
	}

	public static int GetFragileTarget()
	{
		return PlayerPrefs.GetInt("FragileTarget");
	}

	public static void SetFragileTarget(int value)
	{
		PlayerPrefs.SetInt("FragileTarget", value);
	}

	public static void DeleteAll()
	{
		Globals.Delete("CustomSuitor");
		Globals.Delete("CustomSuitorAccessory");
		Globals.Delete("CustomSuitorBlonde");
		Globals.Delete("CustomSuitorEyewear");
		Globals.Delete("CustomSuitorHair");
		Globals.Delete("CustomSuitorJewelry");
		Globals.Delete("CustomSuitorTan");
		Globals.Delete("ExpelProgress");
		Globals.Delete("FemaleUniform");
		Globals.Delete("MaleUniform");
		Globals.DeleteCollection("StudentAccessory_", StudentGlobals.KeysOfStudentAccessory());
		Globals.DeleteCollection("StudentArrested_", StudentGlobals.KeysOfStudentArrested());
		Globals.DeleteCollection("StudentBroken_", StudentGlobals.KeysOfStudentBroken());
		Globals.DeleteCollection("StudentBustSize_", StudentGlobals.KeysOfStudentBustSize());
		GlobalsHelper.DeleteColorCollection("StudentColor_", StudentGlobals.KeysOfStudentColor());
		Globals.DeleteCollection("StudentDead_", StudentGlobals.KeysOfStudentDead());
		Globals.DeleteCollection("StudentDying_", StudentGlobals.KeysOfStudentDying());
		Globals.DeleteCollection("StudentExpelled_", StudentGlobals.KeysOfStudentExpelled());
		Globals.DeleteCollection("StudentExposed_", StudentGlobals.KeysOfStudentExposed());
		GlobalsHelper.DeleteColorCollection("StudentEyeColor_", StudentGlobals.KeysOfStudentEyeColor());
		Globals.DeleteCollection("StudentGrudge_", StudentGlobals.KeysOfStudentGrudge());
		Globals.DeleteCollection("StudentHairstyle_", StudentGlobals.KeysOfStudentHairstyle());
		Globals.DeleteCollection("StudentKidnapped_", StudentGlobals.KeysOfStudentKidnapped());
		Globals.DeleteCollection("StudentMissing_", StudentGlobals.KeysOfStudentMissing());
		Globals.DeleteCollection("StudentName_", StudentGlobals.KeysOfStudentName());
		Globals.DeleteCollection("StudentPhotographed_", StudentGlobals.KeysOfStudentPhotographed());
		Globals.DeleteCollection("StudentReplaced_", StudentGlobals.KeysOfStudentReplaced());
		Globals.DeleteCollection("StudentReputation_", StudentGlobals.KeysOfStudentReputation());
		Globals.DeleteCollection("StudentSanity_", StudentGlobals.KeysOfStudentSanity());
		Globals.DeleteCollection("StudentSlave", StudentGlobals.KeysOfStudentSlave());
	}
}
