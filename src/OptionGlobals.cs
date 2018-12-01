using System;
using UnityEngine;

public static class OptionGlobals
{
	private const string Str_DisableBloom = "DisableBloom";

	private const string Str_DisableFarAnimations = "DisableFarAnimations";

	private const string Str_DisableOutlines = "DisableOutlines";

	private const string Str_DisablePostAliasing = "DisablePostAliasing";

	private const string Str_DisableShadows = "DisableShadows";

	private const string Str_DrawDistance = "DrawDistance";

	private const string Str_DrawDistanceLimit = "DrawDistanceLimit";

	private const string Str_Fog = "Fog";

	private const string Str_FPSIndex = "FPSIndex";

	private const string Str_HighPopulation = "HighPopulation";

	private const string Str_LowDetailStudents = "LowDetailStudents";

	private const string Str_ParticleCount = "ParticleCount";

	private const string Str_RimLight = "RimLight";

	private const string Str_DepthOfField = "DepthOfField";

	private const string Str_Sensitivity = "Sensitivity";

	private const string Str_InvertAxis = "InvertAxis";

	public static bool DisableBloom
	{
		get
		{
			return GlobalsHelper.GetBool("DisableBloom");
		}
		set
		{
			GlobalsHelper.SetBool("DisableBloom", value);
		}
	}

	public static bool DisableFarAnimations
	{
		get
		{
			return GlobalsHelper.GetBool("DisableFarAnimations");
		}
		set
		{
			GlobalsHelper.SetBool("DisableFarAnimations", value);
		}
	}

	public static bool DisableOutlines
	{
		get
		{
			return GlobalsHelper.GetBool("DisableOutlines");
		}
		set
		{
			GlobalsHelper.SetBool("DisableOutlines", value);
		}
	}

	public static bool DisablePostAliasing
	{
		get
		{
			return GlobalsHelper.GetBool("DisablePostAliasing");
		}
		set
		{
			GlobalsHelper.SetBool("DisablePostAliasing", value);
		}
	}

	public static bool DisableShadows
	{
		get
		{
			return GlobalsHelper.GetBool("DisableShadows");
		}
		set
		{
			GlobalsHelper.SetBool("DisableShadows", value);
		}
	}

	public static int DrawDistance
	{
		get
		{
			return PlayerPrefs.GetInt("DrawDistance");
		}
		set
		{
			PlayerPrefs.SetInt("DrawDistance", value);
		}
	}

	public static int DrawDistanceLimit
	{
		get
		{
			return PlayerPrefs.GetInt("DrawDistanceLimit");
		}
		set
		{
			PlayerPrefs.SetInt("DrawDistanceLimit", value);
		}
	}

	public static bool Fog
	{
		get
		{
			return GlobalsHelper.GetBool("Fog");
		}
		set
		{
			GlobalsHelper.SetBool("Fog", value);
		}
	}

	public static int FPSIndex
	{
		get
		{
			return PlayerPrefs.GetInt("FPSIndex");
		}
		set
		{
			PlayerPrefs.SetInt("FPSIndex", value);
		}
	}

	public static bool HighPopulation
	{
		get
		{
			return GlobalsHelper.GetBool("HighPopulation");
		}
		set
		{
			GlobalsHelper.SetBool("HighPopulation", value);
		}
	}

	public static int LowDetailStudents
	{
		get
		{
			return PlayerPrefs.GetInt("LowDetailStudents");
		}
		set
		{
			PlayerPrefs.SetInt("LowDetailStudents", value);
		}
	}

	public static int ParticleCount
	{
		get
		{
			return PlayerPrefs.GetInt("ParticleCount");
		}
		set
		{
			PlayerPrefs.SetInt("ParticleCount", value);
		}
	}

	public static bool RimLight
	{
		get
		{
			return GlobalsHelper.GetBool("RimLight");
		}
		set
		{
			GlobalsHelper.SetBool("RimLight", value);
		}
	}

	public static bool DepthOfField
	{
		get
		{
			return GlobalsHelper.GetBool("DepthOfField");
		}
		set
		{
			GlobalsHelper.SetBool("DepthOfField", value);
		}
	}

	public static int Sensitivity
	{
		get
		{
			return PlayerPrefs.GetInt("Sensitivity");
		}
		set
		{
			PlayerPrefs.SetInt("Sensitivity", value);
		}
	}

	public static bool InvertAxis
	{
		get
		{
			return GlobalsHelper.GetBool("InvertAxis");
		}
		set
		{
			GlobalsHelper.SetBool("InvertAxis", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("DisableBloom");
		Globals.Delete("DisableFarAnimations");
		Globals.Delete("DisableOutlines");
		Globals.Delete("DisablePostAliasing");
		Globals.Delete("DisableShadows");
		Globals.Delete("DrawDistance");
		Globals.Delete("DrawDistanceLimit");
		Globals.Delete("Fog");
		Globals.Delete("FPSIndex");
		Globals.Delete("HighPopulation");
		Globals.Delete("LowDetailStudents");
		Globals.Delete("ParticleCount");
		Globals.Delete("RimLight");
		Globals.Delete("DepthOfField");
		Globals.Delete("Sensitivity");
		Globals.Delete("InvertAxis");
	}
}
