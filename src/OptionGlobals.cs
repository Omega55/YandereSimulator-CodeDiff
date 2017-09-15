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

	private const string Str_HighPopulation = "HighPopulation";

	private const string Str_LowDetailStudents = "LowDetailStudents";

	private const string Str_ParticleCount = "ParticleCount";

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
		Globals.Delete("HighPopulation");
		Globals.Delete("LowDetailStudents");
		Globals.Delete("ParticleCount");
	}
}
