﻿using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StudentSaveData
{
	public bool customSuitor;

	public int customSuitorAccessory;

	public bool customSuitorBlonde;

	public int customSuitorEyewear;

	public int customSuitorHair;

	public int customSuitorJewelry;

	public bool customSuitorTan;

	public int expelProgress;

	public int femaleUniform;

	public int maleUniform;

	public IntAndStringDictionary studentAccessory = new IntAndStringDictionary();

	public IntHashSet studentArrested = new IntHashSet();

	public IntHashSet studentBroken = new IntHashSet();

	public IntAndFloatDictionary studentBustSize = new IntAndFloatDictionary();

	public IntAndColorDictionary studentColor = new IntAndColorDictionary();

	public IntHashSet studentDead = new IntHashSet();

	public IntHashSet studentDying = new IntHashSet();

	public IntHashSet studentExpelled = new IntHashSet();

	public IntHashSet studentExposed = new IntHashSet();

	public IntAndColorDictionary studentEyeColor = new IntAndColorDictionary();

	public IntHashSet studentGrudge = new IntHashSet();

	public IntAndStringDictionary studentHairstyle = new IntAndStringDictionary();

	public IntHashSet studentKidnapped = new IntHashSet();

	public IntHashSet studentMissing = new IntHashSet();

	public IntAndStringDictionary studentName = new IntAndStringDictionary();

	public IntHashSet studentPhotographed = new IntHashSet();

	public IntHashSet studentReplaced = new IntHashSet();

	public IntAndIntDictionary studentReputation = new IntAndIntDictionary();

	public IntAndFloatDictionary studentSanity = new IntAndFloatDictionary();

	public IntHashSet studentSlave = new IntHashSet();

	public static StudentSaveData ReadFromGlobals()
	{
		StudentSaveData studentSaveData = new StudentSaveData();
		studentSaveData.customSuitor = StudentGlobals.CustomSuitor;
		studentSaveData.customSuitorAccessory = StudentGlobals.CustomSuitorAccessory;
		studentSaveData.customSuitorBlonde = StudentGlobals.CustomSuitorBlonde;
		studentSaveData.customSuitorEyewear = StudentGlobals.CustomSuitorEyewear;
		studentSaveData.customSuitorHair = StudentGlobals.CustomSuitorHair;
		studentSaveData.customSuitorJewelry = StudentGlobals.CustomSuitorJewelry;
		studentSaveData.customSuitorTan = StudentGlobals.CustomSuitorTan;
		studentSaveData.expelProgress = StudentGlobals.ExpelProgress;
		studentSaveData.femaleUniform = StudentGlobals.FemaleUniform;
		studentSaveData.maleUniform = StudentGlobals.MaleUniform;
		foreach (int num in StudentGlobals.KeysOfStudentAccessory())
		{
			studentSaveData.studentAccessory.Add(num, StudentGlobals.GetStudentAccessory(num));
		}
		foreach (int num2 in StudentGlobals.KeysOfStudentArrested())
		{
			if (StudentGlobals.GetStudentArrested(num2))
			{
				studentSaveData.studentArrested.Add(num2);
			}
		}
		foreach (int num3 in StudentGlobals.KeysOfStudentBroken())
		{
			if (StudentGlobals.GetStudentBroken(num3))
			{
				studentSaveData.studentBroken.Add(num3);
			}
		}
		foreach (int num4 in StudentGlobals.KeysOfStudentBustSize())
		{
			studentSaveData.studentBustSize.Add(num4, StudentGlobals.GetStudentBustSize(num4));
		}
		foreach (int num5 in StudentGlobals.KeysOfStudentColor())
		{
			studentSaveData.studentColor.Add(num5, StudentGlobals.GetStudentColor(num5));
		}
		foreach (int num6 in StudentGlobals.KeysOfStudentDead())
		{
			if (StudentGlobals.GetStudentDead(num6))
			{
				studentSaveData.studentDead.Add(num6);
			}
		}
		foreach (int num7 in StudentGlobals.KeysOfStudentDying())
		{
			if (StudentGlobals.GetStudentDying(num7))
			{
				studentSaveData.studentDying.Add(num7);
			}
		}
		foreach (int num8 in StudentGlobals.KeysOfStudentExpelled())
		{
			if (StudentGlobals.GetStudentExpelled(num8))
			{
				studentSaveData.studentExpelled.Add(num8);
			}
		}
		foreach (int num9 in StudentGlobals.KeysOfStudentExposed())
		{
			if (StudentGlobals.GetStudentExposed(num9))
			{
				studentSaveData.studentExposed.Add(num9);
			}
		}
		foreach (int num10 in StudentGlobals.KeysOfStudentEyeColor())
		{
			studentSaveData.studentEyeColor.Add(num10, StudentGlobals.GetStudentEyeColor(num10));
		}
		foreach (int num11 in StudentGlobals.KeysOfStudentGrudge())
		{
			if (StudentGlobals.GetStudentGrudge(num11))
			{
				studentSaveData.studentGrudge.Add(num11);
			}
		}
		foreach (int num12 in StudentGlobals.KeysOfStudentHairstyle())
		{
			studentSaveData.studentHairstyle.Add(num12, StudentGlobals.GetStudentHairstyle(num12));
		}
		foreach (int num13 in StudentGlobals.KeysOfStudentKidnapped())
		{
			if (StudentGlobals.GetStudentKidnapped(num13))
			{
				studentSaveData.studentKidnapped.Add(num13);
			}
		}
		foreach (int num14 in StudentGlobals.KeysOfStudentMissing())
		{
			if (StudentGlobals.GetStudentMissing(num14))
			{
				studentSaveData.studentMissing.Add(num14);
			}
		}
		foreach (int num15 in StudentGlobals.KeysOfStudentName())
		{
			studentSaveData.studentName.Add(num15, StudentGlobals.GetStudentName(num15));
		}
		foreach (int num16 in StudentGlobals.KeysOfStudentPhotographed())
		{
			if (StudentGlobals.GetStudentPhotographed(num16))
			{
				studentSaveData.studentPhotographed.Add(num16);
			}
		}
		foreach (int num17 in StudentGlobals.KeysOfStudentReplaced())
		{
			if (StudentGlobals.GetStudentReplaced(num17))
			{
				studentSaveData.studentReplaced.Add(num17);
			}
		}
		foreach (int num18 in StudentGlobals.KeysOfStudentReputation())
		{
			studentSaveData.studentReputation.Add(num18, StudentGlobals.GetStudentReputation(num18));
		}
		foreach (int num19 in StudentGlobals.KeysOfStudentSanity())
		{
			studentSaveData.studentSanity.Add(num19, StudentGlobals.GetStudentSanity(num19));
		}
		return studentSaveData;
	}

	public static void WriteToGlobals(StudentSaveData data)
	{
		StudentGlobals.CustomSuitor = data.customSuitor;
		StudentGlobals.CustomSuitorAccessory = data.customSuitorAccessory;
		StudentGlobals.CustomSuitorBlonde = data.customSuitorBlonde;
		StudentGlobals.CustomSuitorEyewear = data.customSuitorEyewear;
		StudentGlobals.CustomSuitorHair = data.customSuitorHair;
		StudentGlobals.CustomSuitorJewelry = data.customSuitorJewelry;
		StudentGlobals.CustomSuitorTan = data.customSuitorTan;
		StudentGlobals.ExpelProgress = data.expelProgress;
		StudentGlobals.FemaleUniform = data.femaleUniform;
		StudentGlobals.MaleUniform = data.maleUniform;
		foreach (KeyValuePair<int, string> keyValuePair in data.studentAccessory)
		{
			StudentGlobals.SetStudentAccessory(keyValuePair.Key, keyValuePair.Value);
		}
		foreach (int studentID in data.studentArrested)
		{
			StudentGlobals.SetStudentArrested(studentID, true);
		}
		foreach (int studentID2 in data.studentBroken)
		{
			StudentGlobals.SetStudentBroken(studentID2, true);
		}
		foreach (KeyValuePair<int, float> keyValuePair2 in data.studentBustSize)
		{
			StudentGlobals.SetStudentBustSize(keyValuePair2.Key, keyValuePair2.Value);
		}
		foreach (KeyValuePair<int, Color> keyValuePair3 in data.studentColor)
		{
			StudentGlobals.SetStudentColor(keyValuePair3.Key, keyValuePair3.Value);
		}
		foreach (int studentID3 in data.studentDead)
		{
			StudentGlobals.SetStudentDead(studentID3, true);
		}
		foreach (int studentID4 in data.studentDying)
		{
			StudentGlobals.SetStudentDying(studentID4, true);
		}
		foreach (int studentID5 in data.studentExpelled)
		{
			StudentGlobals.SetStudentExpelled(studentID5, true);
		}
		foreach (int studentID6 in data.studentExposed)
		{
			StudentGlobals.SetStudentExposed(studentID6, true);
		}
		foreach (KeyValuePair<int, Color> keyValuePair4 in data.studentEyeColor)
		{
			StudentGlobals.SetStudentEyeColor(keyValuePair4.Key, keyValuePair4.Value);
		}
		foreach (int studentID7 in data.studentGrudge)
		{
			StudentGlobals.SetStudentGrudge(studentID7, true);
		}
		foreach (KeyValuePair<int, string> keyValuePair5 in data.studentHairstyle)
		{
			StudentGlobals.SetStudentHairstyle(keyValuePair5.Key, keyValuePair5.Value);
		}
		foreach (int studentID8 in data.studentKidnapped)
		{
			StudentGlobals.SetStudentKidnapped(studentID8, true);
		}
		foreach (int studentID9 in data.studentMissing)
		{
			StudentGlobals.SetStudentMissing(studentID9, true);
		}
		foreach (KeyValuePair<int, string> keyValuePair6 in data.studentName)
		{
			StudentGlobals.SetStudentName(keyValuePair6.Key, keyValuePair6.Value);
		}
		foreach (int studentID10 in data.studentPhotographed)
		{
			StudentGlobals.SetStudentPhotographed(studentID10, true);
		}
		foreach (int studentID11 in data.studentReplaced)
		{
			StudentGlobals.SetStudentReplaced(studentID11, true);
		}
		foreach (KeyValuePair<int, int> keyValuePair7 in data.studentReputation)
		{
			StudentGlobals.SetStudentReputation(keyValuePair7.Key, keyValuePair7.Value);
		}
		foreach (KeyValuePair<int, float> keyValuePair8 in data.studentSanity)
		{
			StudentGlobals.SetStudentSanity(keyValuePair8.Key, keyValuePair8.Value);
		}
	}
}
