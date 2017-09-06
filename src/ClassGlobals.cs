using System;
using UnityEngine;

public static class ClassGlobals
{
	private const string Str_Biology = "Biology";

	private const string Str_BiologyBonus = "BiologyBonus";

	private const string Str_BiologyGrade = "BiologyGrade";

	private const string Str_Chemistry = "Chemistry";

	private const string Str_ChemistryBonus = "ChemistryBonus";

	private const string Str_ChemistryGrade = "ChemistryGrade";

	private const string Str_Language = "Language";

	private const string Str_LanguageBonus = "LanguageBonus";

	private const string Str_LanguageGrade = "LanguageGrade";

	private const string Str_Physical = "Physical";

	private const string Str_PhysicalBonus = "PhysicalBonus";

	private const string Str_PhysicalGrade = "PhysicalGrade";

	private const string Str_Psychology = "Psychology";

	private const string Str_PsychologyBonus = "PsychologyBonus";

	private const string Str_PsychologyGrade = "PsychologyGrade";

	public static int Biology
	{
		get
		{
			return PlayerPrefs.GetInt("Biology");
		}
		set
		{
			PlayerPrefs.SetInt("Biology", value);
		}
	}

	public static int BiologyBonus
	{
		get
		{
			return PlayerPrefs.GetInt("BiologyBonus");
		}
		set
		{
			PlayerPrefs.SetInt("BiologyBonus", value);
		}
	}

	public static int BiologyGrade
	{
		get
		{
			return PlayerPrefs.GetInt("BiologyGrade");
		}
		set
		{
			PlayerPrefs.SetInt("BiologyGrade", value);
		}
	}

	public static int Chemistry
	{
		get
		{
			return PlayerPrefs.GetInt("Chemistry");
		}
		set
		{
			PlayerPrefs.SetInt("Chemistry", value);
		}
	}

	public static int ChemistryBonus
	{
		get
		{
			return PlayerPrefs.GetInt("ChemistryBonus");
		}
		set
		{
			PlayerPrefs.SetInt("ChemistryBonus", value);
		}
	}

	public static int ChemistryGrade
	{
		get
		{
			return PlayerPrefs.GetInt("ChemistryGrade");
		}
		set
		{
			PlayerPrefs.SetInt("ChemistryGrade", value);
		}
	}

	public static int Language
	{
		get
		{
			return PlayerPrefs.GetInt("Language");
		}
		set
		{
			PlayerPrefs.SetInt("Language", value);
		}
	}

	public static int LanguageBonus
	{
		get
		{
			return PlayerPrefs.GetInt("LanguageBonus");
		}
		set
		{
			PlayerPrefs.SetInt("LanguageBonus", value);
		}
	}

	public static int LanguageGrade
	{
		get
		{
			return PlayerPrefs.GetInt("LanguageGrade");
		}
		set
		{
			PlayerPrefs.SetInt("LanguageGrade", value);
		}
	}

	public static int Physical
	{
		get
		{
			return PlayerPrefs.GetInt("Physical");
		}
		set
		{
			PlayerPrefs.SetInt("Physical", value);
		}
	}

	public static int PhysicalBonus
	{
		get
		{
			return PlayerPrefs.GetInt("PhysicalBonus");
		}
		set
		{
			PlayerPrefs.SetInt("PhysicalBonus", value);
		}
	}

	public static int PhysicalGrade
	{
		get
		{
			return PlayerPrefs.GetInt("PhysicalGrade");
		}
		set
		{
			PlayerPrefs.SetInt("PhysicalGrade", value);
		}
	}

	public static int Psychology
	{
		get
		{
			return PlayerPrefs.GetInt("Psychology");
		}
		set
		{
			PlayerPrefs.SetInt("Psychology", value);
		}
	}

	public static int PsychologyBonus
	{
		get
		{
			return PlayerPrefs.GetInt("PsychologyBonus");
		}
		set
		{
			PlayerPrefs.SetInt("PsychologyBonus", value);
		}
	}

	public static int PsychologyGrade
	{
		get
		{
			return PlayerPrefs.GetInt("PsychologyGrade");
		}
		set
		{
			PlayerPrefs.SetInt("PsychologyGrade", value);
		}
	}
}
