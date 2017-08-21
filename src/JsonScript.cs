﻿using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JsonScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public string StudentFileName;

	public string CreditsFileName;

	public string TopicFileName;

	public string[] StudentNames;

	public int[] StudentGenders;

	public int[] StudentClasses;

	public int[] StudentSeats;

	public int[] StudentClubs;

	public PersonaType[] StudentPersonas;

	public int[] StudentCrushes;

	public float[] StudentBreasts;

	public int[] StudentStrengths;

	public string[] StudentHairstyles;

	public string[] StudentColors;

	public string[] StudentEyes;

	public string[] StudentStockings;

	public string[] StudentAccessories;

	public string[] StudentInfos;

	public bool[] StudentSuccess;

	public ScheduleBlockArrayWrapper[] StudentScheduleBlocks;

	public int TotalStudents;

	public string[] CreditsNames;

	public int[] CreditsSizes;

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

	private Dictionary<string, object>[] StudentData()
	{
		string path = Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", this.StudentFileName + ".json"));
		string value = File.ReadAllText(path);
		return JsonReader.Deserialize<Dictionary<string, object>[]>(value);
	}

	private Dictionary<string, object>[] TopicData()
	{
		string path = Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", this.TopicFileName + ".json"));
		string value = File.ReadAllText(path);
		return JsonReader.Deserialize<Dictionary<string, object>[]>(value);
	}

	private Dictionary<string, object>[] CreditsData()
	{
		string path = Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", this.CreditsFileName + ".json"));
		string value = File.ReadAllText(path);
		return JsonReader.Deserialize<Dictionary<string, object>[]>(value);
	}

	private void Start()
	{
		this.StudentScheduleBlocks = new ScheduleBlockArrayWrapper[this.TotalStudents + 1];
		foreach (Dictionary<string, object> dictionary in this.StudentData())
		{
			int num = TFUtils.LoadInt(dictionary, "ID");
			if (num == 0)
			{
				break;
			}
			this.StudentNames[num] = TFUtils.LoadString(dictionary, "Name");
			this.StudentGenders[num] = TFUtils.LoadInt(dictionary, "Gender");
			this.StudentClasses[num] = TFUtils.LoadInt(dictionary, "Class");
			this.StudentSeats[num] = TFUtils.LoadInt(dictionary, "Seat");
			this.StudentClubs[num] = TFUtils.LoadInt(dictionary, "Club");
			this.StudentPersonas[num] = (PersonaType)TFUtils.LoadInt(dictionary, "Persona");
			this.StudentCrushes[num] = TFUtils.LoadInt(dictionary, "Crush");
			this.StudentBreasts[num] = TFUtils.LoadFloat(dictionary, "BreastSize");
			this.StudentStrengths[num] = TFUtils.LoadInt(dictionary, "Strength");
			this.StudentHairstyles[num] = TFUtils.LoadString(dictionary, "Hairstyle");
			this.StudentColors[num] = TFUtils.LoadString(dictionary, "Color");
			this.StudentEyes[num] = TFUtils.LoadString(dictionary, "Eyes");
			this.StudentStockings[num] = TFUtils.LoadString(dictionary, "Stockings");
			this.StudentAccessories[num] = TFUtils.LoadString(dictionary, "Accessory");
			this.StudentInfos[num] = TFUtils.LoadString(dictionary, "Info");
			this.StudentSuccess[num] = true;
			if (Globals.HighPopulation && this.StudentNames[num] == "Unknown")
			{
				this.StudentNames[num] = "Random";
			}
			float[] array2 = this.ConstructTempFloatArray(TFUtils.LoadString(dictionary, "ScheduleTime"));
			string[] array3 = this.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleDestination"));
			string[] array4 = this.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleAction"));
			this.StudentScheduleBlocks[num] = new ScheduleBlockArrayWrapper(array2.Length);
			for (int j = 0; j < this.StudentScheduleBlocks[num].Length; j++)
			{
				this.StudentScheduleBlocks[num][j] = new ScheduleBlock(array2[j], array3[j], array4[j]);
			}
		}
		if (SceneManager.GetActiveScene().name == "SchoolScene")
		{
			foreach (Dictionary<string, object> d in this.TopicData())
			{
				int num2 = TFUtils.LoadInt(d, "ID");
				if (num2 == 0)
				{
					break;
				}
				this.Topic1[num2] = TFUtils.LoadInt(d, "1");
				this.Topic2[num2] = TFUtils.LoadInt(d, "2");
				this.Topic3[num2] = TFUtils.LoadInt(d, "3");
				this.Topic4[num2] = TFUtils.LoadInt(d, "4");
				this.Topic5[num2] = TFUtils.LoadInt(d, "5");
				this.Topic6[num2] = TFUtils.LoadInt(d, "6");
				this.Topic7[num2] = TFUtils.LoadInt(d, "7");
				this.Topic8[num2] = TFUtils.LoadInt(d, "8");
				this.Topic9[num2] = TFUtils.LoadInt(d, "9");
				this.Topic10[num2] = TFUtils.LoadInt(d, "10");
				this.Topic11[num2] = TFUtils.LoadInt(d, "11");
				this.Topic12[num2] = TFUtils.LoadInt(d, "12");
				this.Topic13[num2] = TFUtils.LoadInt(d, "13");
				this.Topic14[num2] = TFUtils.LoadInt(d, "14");
				this.Topic15[num2] = TFUtils.LoadInt(d, "15");
				this.Topic16[num2] = TFUtils.LoadInt(d, "16");
				this.Topic17[num2] = TFUtils.LoadInt(d, "17");
				this.Topic18[num2] = TFUtils.LoadInt(d, "18");
				this.Topic19[num2] = TFUtils.LoadInt(d, "19");
				this.Topic20[num2] = TFUtils.LoadInt(d, "20");
				this.Topic21[num2] = TFUtils.LoadInt(d, "21");
				this.Topic22[num2] = TFUtils.LoadInt(d, "22");
				this.Topic23[num2] = TFUtils.LoadInt(d, "23");
				this.Topic24[num2] = TFUtils.LoadInt(d, "24");
				this.Topic25[num2] = TFUtils.LoadInt(d, "25");
			}
			this.ReplaceDeadTeachers();
		}
		if (SceneManager.GetActiveScene().name == "CreditsScene")
		{
			foreach (Dictionary<string, object> dictionary2 in this.CreditsData())
			{
				int num3 = TFUtils.LoadInt(dictionary2, "ID");
				if (num3 == 0)
				{
					break;
				}
				this.CreditsNames[num3] = TFUtils.LoadString(dictionary2, "Name");
				this.CreditsSizes[num3] = TFUtils.LoadInt(dictionary2, "Size");
			}
		}
	}

	private float[] ConstructTempFloatArray(string str)
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

	private string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	private void ReplaceDeadTeachers()
	{
		for (int i = 94; i < 101; i++)
		{
			if (Globals.GetStudentDead(i))
			{
				Globals.SetStudentReplaced(i, true);
				Globals.SetStudentDead(i, false);
				string value = this.StudentManager.FirstNames[UnityEngine.Random.Range(0, this.StudentManager.FirstNames.Length)] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, this.StudentManager.LastNames.Length)];
				Globals.SetStudentName(i, value);
				Globals.SetStudentBustSize(i, UnityEngine.Random.Range(1f, 1.5f));
				Globals.SetStudentHairstyle(i, UnityEngine.Random.Range(1, 8).ToString());
				float r = UnityEngine.Random.Range(0f, 1f);
				float g = UnityEngine.Random.Range(0f, 1f);
				float b = UnityEngine.Random.Range(0f, 1f);
				Globals.SetStudentColor(i, new Color(r, g, b));
				r = UnityEngine.Random.Range(0f, 1f);
				g = UnityEngine.Random.Range(0f, 1f);
				b = UnityEngine.Random.Range(0f, 1f);
				Globals.SetStudentEyeColor(i, new Color(r, g, b));
				Globals.SetStudentAccessory(i, UnityEngine.Random.Range(1, 7).ToString());
			}
		}
		for (int j = 94; j < 101; j++)
		{
			if (Globals.GetStudentReplaced(j))
			{
				this.StudentNames[j] = Globals.GetStudentName(j);
				this.StudentBreasts[j] = Globals.GetStudentBustSize(j);
				this.StudentHairstyles[j] = Globals.GetStudentHairstyle(j);
				this.StudentAccessories[j] = Globals.GetStudentAccessory(j);
				if (j == 100)
				{
					this.StudentAccessories[100] = "7";
				}
			}
		}
	}
}
