using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class StudentJson : JsonData
{
	[SerializeField]
	private string name;

	[SerializeField]
	private int gender;

	[SerializeField]
	private int classID;

	[SerializeField]
	private int seat;

	[SerializeField]
	private ClubType club;

	[SerializeField]
	private PersonaType persona;

	[SerializeField]
	private int crush;

	[SerializeField]
	private float breastSize;

	[SerializeField]
	private int strength;

	[SerializeField]
	private string hairstyle;

	[SerializeField]
	private string color;

	[SerializeField]
	private string eyes;

	[SerializeField]
	private string eyeType;

	[SerializeField]
	private string stockings;

	[SerializeField]
	private string accessory;

	[SerializeField]
	private string info;

	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	[SerializeField]
	private bool success;

	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Students.json");
		}
	}

	public static StudentJson[] LoadFromJson(string path)
	{
		StudentJson[] array = new StudentJson[101];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new StudentJson();
		}
		StudentJson studentJson = array[0];
		studentJson.name = "Info-chan";
		studentJson.club = ClubType.Nemesis;
		studentJson.persona = PersonaType.Nemesis;
		studentJson.crush = 99;
		StudentJson studentJson2 = array[90];
		studentJson2.name = "Info-chan";
		studentJson2.club = ClubType.Nemesis;
		studentJson2.persona = PersonaType.Nemesis;
		studentJson2.crush = 99;
		foreach (Dictionary<string, object> dictionary in JsonData.Deserialize(path))
		{
			int num = TFUtils.LoadInt(dictionary, "ID");
			if (num == 0)
			{
				break;
			}
			StudentJson studentJson3 = array[num];
			studentJson3.name = TFUtils.LoadString(dictionary, "Name");
			studentJson3.gender = TFUtils.LoadInt(dictionary, "Gender");
			studentJson3.classID = TFUtils.LoadInt(dictionary, "Class");
			studentJson3.seat = TFUtils.LoadInt(dictionary, "Seat");
			studentJson3.club = (ClubType)TFUtils.LoadInt(dictionary, "Club");
			studentJson3.persona = (PersonaType)TFUtils.LoadInt(dictionary, "Persona");
			studentJson3.crush = TFUtils.LoadInt(dictionary, "Crush");
			studentJson3.breastSize = TFUtils.LoadFloat(dictionary, "BreastSize");
			studentJson3.strength = TFUtils.LoadInt(dictionary, "Strength");
			studentJson3.hairstyle = TFUtils.LoadString(dictionary, "Hairstyle");
			studentJson3.color = TFUtils.LoadString(dictionary, "Color");
			studentJson3.eyes = TFUtils.LoadString(dictionary, "Eyes");
			studentJson3.eyeType = TFUtils.LoadString(dictionary, "EyeType");
			studentJson3.stockings = TFUtils.LoadString(dictionary, "Stockings");
			studentJson3.accessory = TFUtils.LoadString(dictionary, "Accessory");
			studentJson3.info = TFUtils.LoadString(dictionary, "Info");
			if (GameGlobals.LoveSick && studentJson3.name == "Mai Waifu")
			{
				studentJson3.name = "Mai Wakabayashi";
			}
			if (OptionGlobals.HighPopulation && studentJson3.name == "Unknown")
			{
				studentJson3.name = "Random";
			}
			float[] array3 = StudentJson.ConstructTempFloatArray(TFUtils.LoadString(dictionary, "ScheduleTime"));
			string[] array4 = StudentJson.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleDestination"));
			string[] array5 = StudentJson.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleAction"));
			studentJson3.scheduleBlocks = new ScheduleBlock[array3.Length];
			for (int k = 0; k < studentJson3.scheduleBlocks.Length; k++)
			{
				studentJson3.scheduleBlocks[k] = new ScheduleBlock(array3[k], array4[k], array5[k]);
			}
			studentJson3.success = true;
		}
		return array;
	}

	public string Name
	{
		get
		{
			return this.name;
		}
		set
		{
			this.name = value;
		}
	}

	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	public int Class
	{
		get
		{
			return this.classID;
		}
		set
		{
			this.classID = value;
		}
	}

	public int Seat
	{
		get
		{
			return this.seat;
		}
		set
		{
			this.seat = value;
		}
	}

	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	public PersonaType Persona
	{
		get
		{
			return this.persona;
		}
		set
		{
			this.persona = value;
		}
	}

	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	public float BreastSize
	{
		get
		{
			return this.breastSize;
		}
		set
		{
			this.breastSize = value;
		}
	}

	public int Strength
	{
		get
		{
			return this.strength;
		}
		set
		{
			this.strength = value;
		}
	}

	public string Hairstyle
	{
		get
		{
			return this.hairstyle;
		}
		set
		{
			this.hairstyle = value;
		}
	}

	public string Color
	{
		get
		{
			return this.color;
		}
	}

	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	public string Accessory
	{
		get
		{
			return this.accessory;
		}
		set
		{
			this.accessory = value;
		}
	}

	public string Info
	{
		get
		{
			return this.info;
		}
	}

	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	private static float[] ConstructTempFloatArray(string str)
	{
		string[] array = str.Split(new char[]
		{
			'_'
		});
		float[] array2 = new float[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = float.Parse(array[i]);
		}
		return array2;
	}

	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}
}
