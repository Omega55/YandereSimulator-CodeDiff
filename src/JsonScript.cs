using System;
using System.Collections.Generic;
using System.IO;
using Boo.Lang.Runtime;
using JsonFx.Json;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class JsonScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public string StudentFileName;

	public string[] StudentNames;

	public int[] StudentGenders;

	public int[] StudentClasses;

	public int[] StudentClubs;

	public int[] StudentPersonas;

	public int[] StudentCrushes;

	public float[] StudentBreasts;

	public int[] StudentStrengths;

	public string[] StudentHairstyles;

	public string[] StudentColors;

	public string[] StudentStockings;

	public string[] StudentAccessories;

	public UnityScript.Lang.Array[] StudentTimes;

	public UnityScript.Lang.Array[] StudentDestinations;

	public UnityScript.Lang.Array[] StudentActions;

	public int TotalStudents;

	private string[] TempStringArray;

	private float[] TempFloatArray;

	private int[] TempIntArray;

	private string TempString;

	private float TempFloat;

	private int TempInt;

	private int ID;

	public virtual Dictionary<string, object>[] StudentData()
	{
		string text = Path.Combine("JSON", this.StudentFileName + ".json");
		text = Path.Combine(Application.streamingAssetsPath, text);
		string value = File.ReadAllText(text);
		return JsonReader.Deserialize(value) as Dictionary<string, object>[];
	}

	public virtual void Start()
	{
		this.StudentTimes = new UnityScript.Lang.Array[this.TotalStudents + 1];
		this.StudentDestinations = new UnityScript.Lang.Array[this.TotalStudents + 1];
		this.StudentActions = new UnityScript.Lang.Array[this.TotalStudents + 1];
		int i = 0;
		Dictionary<string, object>[] array = this.StudentData();
		int length = array.Length;
		while (i < length)
		{
			this.ID = TFUtils.LoadInt(array[i], "ID");
			if (RuntimeServices.EqualityOperator(this.ID, null) || this.ID == 0)
			{
				break;
			}
			this.StudentNames[this.ID] = TFUtils.LoadString(array[i], "Name");
			this.StudentGenders[this.ID] = TFUtils.LoadInt(array[i], "Gender");
			this.StudentClasses[this.ID] = TFUtils.LoadInt(array[i], "Class");
			this.StudentClubs[this.ID] = TFUtils.LoadInt(array[i], "Club");
			this.StudentPersonas[this.ID] = TFUtils.LoadInt(array[i], "Persona");
			this.StudentCrushes[this.ID] = TFUtils.LoadInt(array[i], "Crush");
			this.StudentBreasts[this.ID] = TFUtils.LoadFloat(array[i], "BreastSize");
			this.StudentStrengths[this.ID] = (int)TFUtils.LoadFloat(array[i], "Strength");
			this.StudentHairstyles[this.ID] = TFUtils.LoadString(array[i], "Hairstyle");
			this.StudentColors[this.ID] = TFUtils.LoadString(array[i], "Color");
			this.StudentStockings[this.ID] = TFUtils.LoadString(array[i], "Stockings");
			this.StudentAccessories[this.ID] = TFUtils.LoadString(array[i], "Accessory");
			this.TempString = TFUtils.LoadString(array[i], "ScheduleTime");
			this.ConstructTempFloatArray();
			this.StudentTimes[this.ID] = this.TempFloatArray;
			this.TempString = TFUtils.LoadString(array[i], "ScheduleDestination");
			this.ConstructTempStringArray();
			this.StudentDestinations[this.ID] = this.TempStringArray;
			this.TempString = TFUtils.LoadString(array[i], "ScheduleAction");
			this.ConstructTempStringArray();
			this.StudentActions[this.ID] = this.TempStringArray;
			i++;
		}
		if (Application.loadedLevelName == "SchoolScene")
		{
			this.ReplaceDeadTeachers();
		}
	}

	public virtual void ConstructTempFloatArray()
	{
		this.TempStringArray = this.TempString.Split(new char[]
		{
			"_"[0]
		});
		this.TempFloatArray = new float[this.TempStringArray.Length];
		for (int i = 0; i < this.TempStringArray.Length; i++)
		{
			this.TempFloatArray[i] = float.Parse(this.TempStringArray[i]);
		}
	}

	public virtual void ConstructTempStringArray()
	{
		this.TempStringArray = this.TempString.Split(new char[]
		{
			"_"[0]
		});
	}

	public virtual void ReplaceDeadTeachers()
	{
		this.ID = 35;
		while (this.ID < 42)
		{
			if (PlayerPrefs.GetInt("Student_" + this.ID + "_Dead") == 1)
			{
				PlayerPrefs.SetInt("Student_" + this.ID + "_Replaced", 1);
				PlayerPrefs.SetInt("Student_" + this.ID + "_Dead", 0);
				string value = string.Empty + this.StudentManager.FirstNames[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentManager.FirstNames))] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentManager.LastNames))];
				PlayerPrefs.SetString("Student_" + this.ID + "_Name", value);
				PlayerPrefs.SetFloat("Student_" + this.ID + "_BustSize", UnityEngine.Random.Range(1f, 1.5f));
				PlayerPrefs.SetString("Student_" + this.ID + "_Hairstyle", string.Empty + UnityEngine.Random.Range(1, 8));
				float value2 = UnityEngine.Random.Range((float)0, 1f);
				float value3 = UnityEngine.Random.Range((float)0, 1f);
				float value4 = UnityEngine.Random.Range((float)0, 1f);
				PlayerPrefs.SetFloat("Student_" + this.ID + "_ColorR", value2);
				PlayerPrefs.SetFloat("Student_" + this.ID + "_ColorG", value3);
				PlayerPrefs.SetFloat("Student_" + this.ID + "_ColorB", value4);
				PlayerPrefs.SetString("Student_" + this.ID + "_Accessory", string.Empty + UnityEngine.Random.Range(1, 7));
			}
			this.ID++;
		}
		this.ID = 35;
		while (this.ID < 42)
		{
			if (PlayerPrefs.GetInt("Student_" + this.ID + "_Replaced") == 1)
			{
				this.StudentNames[this.ID] = PlayerPrefs.GetString("Student_" + this.ID + "_Name");
				this.StudentBreasts[this.ID] = PlayerPrefs.GetFloat("Student_" + this.ID + "_BustSize");
				this.StudentHairstyles[this.ID] = PlayerPrefs.GetString("Student_" + this.ID + "_Hairstyle");
				this.StudentAccessories[this.ID] = PlayerPrefs.GetString("Student_" + this.ID + "_Accessory");
				if (this.ID == 41)
				{
					this.StudentAccessories[41] = "7";
				}
			}
			this.ID++;
		}
	}

	public virtual void Main()
	{
	}
}
