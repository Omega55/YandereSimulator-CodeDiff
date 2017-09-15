using System;
using UnityEngine;

public static class SenpaiGlobals
{
	private const string Str_CustomSenpai = "CustomSenpai";

	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";

	public static bool CustomSenpai
	{
		get
		{
			return GlobalsHelper.GetBool("CustomSenpai");
		}
		set
		{
			GlobalsHelper.SetBool("CustomSenpai", value);
		}
	}

	public static string SenpaiEyeColor
	{
		get
		{
			return PlayerPrefs.GetString("SenpaiEyeColor");
		}
		set
		{
			PlayerPrefs.SetString("SenpaiEyeColor", value);
		}
	}

	public static int SenpaiEyeWear
	{
		get
		{
			return PlayerPrefs.GetInt("SenpaiEyeWear");
		}
		set
		{
			PlayerPrefs.SetInt("SenpaiEyeWear", value);
		}
	}

	public static int SenpaiFacialHair
	{
		get
		{
			return PlayerPrefs.GetInt("SenpaiFacialHair");
		}
		set
		{
			PlayerPrefs.SetInt("SenpaiFacialHair", value);
		}
	}

	public static string SenpaiHairColor
	{
		get
		{
			return PlayerPrefs.GetString("SenpaiHairColor");
		}
		set
		{
			PlayerPrefs.SetString("SenpaiHairColor", value);
		}
	}

	public static int SenpaiHairStyle
	{
		get
		{
			return PlayerPrefs.GetInt("SenpaiHairStyle");
		}
		set
		{
			PlayerPrefs.SetInt("SenpaiHairStyle", value);
		}
	}

	public static int SenpaiSkinColor
	{
		get
		{
			return PlayerPrefs.GetInt("SenpaiSkinColor");
		}
		set
		{
			PlayerPrefs.SetInt("SenpaiSkinColor", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("CustomSenpai");
		Globals.Delete("SenpaiEyeColor");
		Globals.Delete("SenpaiEyeWear");
		Globals.Delete("SenpaiFacialHair");
		Globals.Delete("SenpaiHairColor");
		Globals.Delete("SenpaiHairStyle");
		Globals.Delete("SenpaiSkinColor");
	}
}
