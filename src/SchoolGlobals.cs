using System;
using UnityEngine;

public static class SchoolGlobals
{
	private const string Str_DemonActive = "DemonActive_";

	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	private const string Str_KidnapVictim = "KidnapVictim";

	private const string Str_Population = "Population";

	private const string Str_RoofFence = "RoofFence";

	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	private const string Str_SCP = "SCP";

	private const string Str_HighSecurity = "HighSecurity";

	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("DemonActive_" + demonID.ToString());
	}

	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("DemonActive_", text);
		GlobalsHelper.SetBool("DemonActive_" + text, value);
	}

	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("DemonActive_");
	}

	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("GardenGraveOccupied_" + graveID.ToString());
	}

	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("GardenGraveOccupied_" + text, value);
	}

	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("GardenGraveOccupied_");
	}

	public static int KidnapVictim
	{
		get
		{
			return PlayerPrefs.GetInt("KidnapVictim");
		}
		set
		{
			PlayerPrefs.SetInt("KidnapVictim", value);
		}
	}

	public static int Population
	{
		get
		{
			return PlayerPrefs.GetInt("Population");
		}
		set
		{
			PlayerPrefs.SetInt("Population", value);
		}
	}

	public static bool RoofFence
	{
		get
		{
			return GlobalsHelper.GetBool("RoofFence");
		}
		set
		{
			GlobalsHelper.SetBool("RoofFence", value);
		}
	}

	public static float SchoolAtmosphere
	{
		get
		{
			return PlayerPrefs.GetFloat("SchoolAtmosphere");
		}
		set
		{
			PlayerPrefs.SetFloat("SchoolAtmosphere", value);
		}
	}

	public static bool SchoolAtmosphereSet
	{
		get
		{
			return GlobalsHelper.GetBool("SchoolAtmosphereSet");
		}
		set
		{
			GlobalsHelper.SetBool("SchoolAtmosphereSet", value);
		}
	}

	public static bool ReactedToGameLeader
	{
		get
		{
			return GlobalsHelper.GetBool("ReactedToGameLeader");
		}
		set
		{
			GlobalsHelper.SetBool("ReactedToGameLeader", value);
		}
	}

	public static bool SCP
	{
		get
		{
			return GlobalsHelper.GetBool("SCP");
		}
		set
		{
			GlobalsHelper.SetBool("SCP", value);
		}
	}

	public static bool HighSecurity
	{
		get
		{
			return GlobalsHelper.GetBool("HighSecurity");
		}
		set
		{
			GlobalsHelper.SetBool("HighSecurity", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.DeleteCollection("DemonActive_", SchoolGlobals.KeysOfDemonActive());
		Globals.DeleteCollection("GardenGraveOccupied_", SchoolGlobals.KeysOfGardenGraveOccupied());
		Globals.Delete("KidnapVictim");
		Globals.Delete("Population");
		Globals.Delete("RoofFence");
		Globals.Delete("SchoolAtmosphere");
		Globals.Delete("SchoolAtmosphereSet");
		Globals.Delete("ReactedToGameLeader");
		Globals.Delete("SCP");
	}
}
