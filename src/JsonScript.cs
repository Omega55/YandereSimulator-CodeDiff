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

	public string TopicFileName;

	public string[] StudentNames;

	public int[] StudentGenders;

	public int[] StudentClasses;

	public int[] StudentSeats;

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

	public int[] Topic1;

	public int[] Topic2;

	public int[] Topic3;

	public int[] Topic4;

	public int[] Topic5;

	public int[] Topic6;

	public int[] Topic7;

	public int[] Topic8;

	public int[] Topic9;

	public int[] Topic10;

	public int[] Topic11;

	public int[] Topic12;

	public int[] Topic13;

	public int[] Topic14;

	public int[] Topic15;

	public int[] Topic16;

	public int[] Topic17;

	public int[] Topic18;

	public int[] Topic19;

	public int[] Topic20;

	public int[] Topic21;

	public int[] Topic22;

	public int[] Topic23;

	public int[] Topic24;

	public int[] Topic25;

	public virtual Dictionary<string, object>[] StudentData()
	{
		string text = Path.Combine("JSON", this.StudentFileName + ".json");
		text = Path.Combine(Application.streamingAssetsPath, text);
		string value = File.ReadAllText(text);
		return JsonReader.Deserialize(value) as Dictionary<string, object>[];
	}

	public virtual Dictionary<string, object>[] TopicData()
	{
		string text = Path.Combine("JSON", this.TopicFileName + ".json");
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
			this.StudentSeats[this.ID] = TFUtils.LoadInt(array[i], "Seat");
			this.StudentClubs[this.ID] = TFUtils.LoadInt(array[i], "Club");
			this.StudentPersonas[this.ID] = TFUtils.LoadInt(array[i], "Persona");
			this.StudentCrushes[this.ID] = TFUtils.LoadInt(array[i], "Crush");
			this.StudentBreasts[this.ID] = TFUtils.LoadFloat(array[i], "BreastSize");
			this.StudentStrengths[this.ID] = (int)TFUtils.LoadFloat(array[i], "Strength");
			this.StudentHairstyles[this.ID] = TFUtils.LoadString(array[i], "Hairstyle");
			this.StudentColors[this.ID] = TFUtils.LoadString(array[i], "Color");
			this.StudentStockings[this.ID] = TFUtils.LoadString(array[i], "Stockings");
			this.StudentAccessories[this.ID] = TFUtils.LoadString(array[i], "Accessory");
			if (PlayerPrefs.GetInt("HighPopulation") == 1 && this.StudentNames[this.ID] == "Unknown")
			{
				this.StudentNames[this.ID] = "Random";
			}
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
			int j = 0;
			Dictionary<string, object>[] array2 = this.TopicData();
			int length2 = array2.Length;
			while (j < length2)
			{
				this.ID = TFUtils.LoadInt(array2[j], "ID");
				if (RuntimeServices.EqualityOperator(this.ID, null) || this.ID == 0)
				{
					break;
				}
				this.Topic1[this.ID] = TFUtils.LoadInt(array2[j], "1");
				this.Topic2[this.ID] = TFUtils.LoadInt(array2[j], "2");
				this.Topic3[this.ID] = TFUtils.LoadInt(array2[j], "3");
				this.Topic4[this.ID] = TFUtils.LoadInt(array2[j], "4");
				this.Topic5[this.ID] = TFUtils.LoadInt(array2[j], "5");
				this.Topic6[this.ID] = TFUtils.LoadInt(array2[j], "6");
				this.Topic7[this.ID] = TFUtils.LoadInt(array2[j], "7");
				this.Topic8[this.ID] = TFUtils.LoadInt(array2[j], "8");
				this.Topic9[this.ID] = TFUtils.LoadInt(array2[j], "9");
				this.Topic10[this.ID] = TFUtils.LoadInt(array2[j], "10");
				this.Topic11[this.ID] = TFUtils.LoadInt(array2[j], "11");
				this.Topic12[this.ID] = TFUtils.LoadInt(array2[j], "12");
				this.Topic13[this.ID] = TFUtils.LoadInt(array2[j], "13");
				this.Topic14[this.ID] = TFUtils.LoadInt(array2[j], "14");
				this.Topic15[this.ID] = TFUtils.LoadInt(array2[j], "15");
				this.Topic16[this.ID] = TFUtils.LoadInt(array2[j], "16");
				this.Topic17[this.ID] = TFUtils.LoadInt(array2[j], "17");
				this.Topic18[this.ID] = TFUtils.LoadInt(array2[j], "18");
				this.Topic19[this.ID] = TFUtils.LoadInt(array2[j], "19");
				this.Topic20[this.ID] = TFUtils.LoadInt(array2[j], "20");
				this.Topic21[this.ID] = TFUtils.LoadInt(array2[j], "21");
				this.Topic22[this.ID] = TFUtils.LoadInt(array2[j], "22");
				this.Topic23[this.ID] = TFUtils.LoadInt(array2[j], "23");
				this.Topic24[this.ID] = TFUtils.LoadInt(array2[j], "24");
				this.Topic25[this.ID] = TFUtils.LoadInt(array2[j], "25");
				j++;
			}
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
		this.ID = 94;
		while (this.ID < 100)
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
		this.ID = 94;
		while (this.ID < 100)
		{
			if (PlayerPrefs.GetInt("Student_" + this.ID + "_Replaced") == 1)
			{
				this.StudentNames[this.ID] = PlayerPrefs.GetString("Student_" + this.ID + "_Name");
				this.StudentBreasts[this.ID] = PlayerPrefs.GetFloat("Student_" + this.ID + "_BustSize");
				this.StudentHairstyles[this.ID] = PlayerPrefs.GetString("Student_" + this.ID + "_Hairstyle");
				this.StudentAccessories[this.ID] = PlayerPrefs.GetString("Student_" + this.ID + "_Accessory");
				if (this.ID == 100)
				{
					this.StudentAccessories[100] = "7";
				}
			}
			this.ID++;
		}
	}

	public virtual void Main()
	{
	}
}
