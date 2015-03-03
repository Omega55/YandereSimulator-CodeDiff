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
	public string StudentFileName;

	public string[] StudentNames;

	public int[] StudentClasses;

	public string[] StudentClubs;

	public string[] StudentPersonalites;

	public int[] StudentCrushes;

	public float[] StudentBreasts;

	public string[] StudentHairstyles;

	public string[] StudentColors;

	public string[] StudentStockings;

	public string[] StudentPanties;

	public UnityScript.Lang.Array[] StudentTimes;

	public UnityScript.Lang.Array[] StudentDestinations;

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
		UnityEngine.Object.DontDestroyOnLoad(this.transform.gameObject);
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
			this.StudentClasses[this.ID] = TFUtils.LoadInt(array[i], "Class");
			this.StudentClubs[this.ID] = TFUtils.LoadString(array[i], "Club");
			this.StudentPersonalites[this.ID] = TFUtils.LoadString(array[i], "Personality");
			this.StudentCrushes[this.ID] = TFUtils.LoadInt(array[i], "Crush");
			this.StudentBreasts[this.ID] = TFUtils.LoadFloat(array[i], "BreastSize");
			this.StudentHairstyles[this.ID] = TFUtils.LoadString(array[i], "Hairstyle");
			this.StudentColors[this.ID] = TFUtils.LoadString(array[i], "Color");
			this.StudentStockings[this.ID] = TFUtils.LoadString(array[i], "Stockings");
			this.StudentPanties[this.ID] = TFUtils.LoadString(array[i], "Panties");
			this.TempString = TFUtils.LoadString(array[i], "ScheduleTime");
			this.ConstructTempFloatArray();
			this.StudentTimes[this.ID] = this.TempFloatArray;
			this.TempString = TFUtils.LoadString(array[i], "ScheduleDestination");
			this.ConstructTempStringArray();
			this.StudentDestinations[this.ID] = this.TempStringArray;
			i++;
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

	public virtual void Main()
	{
	}
}
