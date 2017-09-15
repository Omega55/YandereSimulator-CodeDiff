using System;
using UnityEngine;

public static class SchemeGlobals
{
	private const string Str_CurrentScheme = "CurrentScheme";

	private const string Str_DarkSecret = "DarkSecret";

	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	private const string Str_SchemeStage = "SchemeStage_";

	private const string Str_SchemeStatus = "SchemeStatus_";

	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	private const string Str_ServicePurchased = "ServicePurchased_";

	public static int CurrentScheme
	{
		get
		{
			return PlayerPrefs.GetInt("CurrentScheme");
		}
		set
		{
			PlayerPrefs.SetInt("CurrentScheme", value);
		}
	}

	public static bool DarkSecret
	{
		get
		{
			return GlobalsHelper.GetBool("DarkSecret");
		}
		set
		{
			GlobalsHelper.SetBool("DarkSecret", value);
		}
	}

	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("SchemePreviousStage_" + schemeID.ToString());
	}

	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("SchemePreviousStage_", text);
		PlayerPrefs.SetInt("SchemePreviousStage_" + text, value);
	}

	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("SchemePreviousStage_");
	}

	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("SchemeStage_" + schemeID.ToString());
	}

	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("SchemeStage_", text);
		PlayerPrefs.SetInt("SchemeStage_" + text, value);
	}

	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("SchemeStage_");
	}

	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("SchemeStatus_" + schemeID.ToString());
	}

	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("SchemeStatus_", text);
		GlobalsHelper.SetBool("SchemeStatus_" + text, value);
	}

	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("SchemeStatus_");
	}

	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("SchemeUnlocked_" + schemeID.ToString());
	}

	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("SchemeUnlocked_", text);
		GlobalsHelper.SetBool("SchemeUnlocked_" + text, value);
	}

	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("SchemeUnlocked_");
	}

	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("ServicePurchased_" + serviceID.ToString());
	}

	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("ServicePurchased_", text);
		GlobalsHelper.SetBool("ServicePurchased_" + text, value);
	}

	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("ServicePurchased_");
	}

	public static void DeleteAll()
	{
		Globals.Delete("CurrentScheme");
		Globals.Delete("DarkSecret");
		Globals.DeleteCollection("SchemePreviousStage_", SchemeGlobals.KeysOfSchemePreviousStage());
		Globals.DeleteCollection("SchemeStage_", SchemeGlobals.KeysOfSchemeStage());
		Globals.DeleteCollection("SchemeStatus_", SchemeGlobals.KeysOfSchemeStatus());
		Globals.DeleteCollection("SchemeUnlocked_", SchemeGlobals.KeysOfSchemeUnlocked());
		Globals.DeleteCollection("ServicePurchased_", SchemeGlobals.KeysOfServicePurchased());
	}
}
