using System;
using System.Collections.Generic;

[Serializable]
public class DatingSaveData
{
	public float affection;

	public float affectionLevel;

	public IntHashSet complimentGiven = new IntHashSet();

	public IntHashSet suitorCheck = new IntHashSet();

	public int suitorProgress;

	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	public IntHashSet topicDiscussed = new IntHashSet();

	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();

	public static DatingSaveData ReadFromGlobals()
	{
		DatingSaveData datingSaveData = new DatingSaveData();
		datingSaveData.affection = DatingGlobals.Affection;
		datingSaveData.affectionLevel = DatingGlobals.AffectionLevel;
		foreach (int num in DatingGlobals.KeysOfComplimentGiven())
		{
			if (DatingGlobals.GetComplimentGiven(num))
			{
				datingSaveData.complimentGiven.Add(num);
			}
		}
		foreach (int num2 in DatingGlobals.KeysOfSuitorCheck())
		{
			if (DatingGlobals.GetSuitorCheck(num2))
			{
				datingSaveData.suitorCheck.Add(num2);
			}
		}
		datingSaveData.suitorProgress = DatingGlobals.SuitorProgress;
		foreach (int num3 in DatingGlobals.KeysOfSuitorTrait())
		{
			datingSaveData.suitorTrait.Add(num3, DatingGlobals.GetSuitorTrait(num3));
		}
		foreach (int num4 in DatingGlobals.KeysOfTopicDiscussed())
		{
			if (DatingGlobals.GetTopicDiscussed(num4))
			{
				datingSaveData.topicDiscussed.Add(num4);
			}
		}
		foreach (int num5 in DatingGlobals.KeysOfTraitDemonstrated())
		{
			datingSaveData.traitDemonstrated.Add(num5, DatingGlobals.GetTraitDemonstrated(num5));
		}
		return datingSaveData;
	}

	public static void WriteToGlobals(DatingSaveData data)
	{
		DatingGlobals.Affection = data.affection;
		DatingGlobals.AffectionLevel = data.affectionLevel;
		foreach (int complimentID in data.complimentGiven)
		{
			DatingGlobals.SetComplimentGiven(complimentID, true);
		}
		foreach (int checkID in data.suitorCheck)
		{
			DatingGlobals.SetSuitorCheck(checkID, true);
		}
		DatingGlobals.SuitorProgress = data.suitorProgress;
		foreach (KeyValuePair<int, int> keyValuePair in data.suitorTrait)
		{
			DatingGlobals.SetSuitorTrait(keyValuePair.Key, keyValuePair.Value);
		}
		foreach (int topicID in data.topicDiscussed)
		{
			DatingGlobals.SetTopicDiscussed(topicID, true);
		}
		foreach (KeyValuePair<int, int> keyValuePair2 in data.traitDemonstrated)
		{
			DatingGlobals.SetTraitDemonstrated(keyValuePair2.Key, keyValuePair2.Value);
		}
	}
}
