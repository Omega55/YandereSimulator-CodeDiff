using System;

[Serializable]
public class CollectibleSaveData
{
	public IntHashSet basementTapeCollected;

	public IntHashSet basementTapeListened;

	public IntHashSet mangaCollected;

	public IntHashSet tapeCollected;

	public IntHashSet tapeListened;

	public CollectibleSaveData()
	{
		this.basementTapeCollected = new IntHashSet();
		this.basementTapeListened = new IntHashSet();
		this.mangaCollected = new IntHashSet();
		this.tapeCollected = new IntHashSet();
		this.tapeListened = new IntHashSet();
	}

	public static CollectibleSaveData ReadFromGlobals()
	{
		CollectibleSaveData collectibleSaveData = new CollectibleSaveData();
		foreach (int num in CollectibleGlobals.KeysOfBasementTapeCollected())
		{
			if (CollectibleGlobals.GetBasementTapeCollected(num))
			{
				collectibleSaveData.basementTapeCollected.Add(num);
			}
		}
		foreach (int num2 in CollectibleGlobals.KeysOfBasementTapeListened())
		{
			if (CollectibleGlobals.GetBasementTapeListened(num2))
			{
				collectibleSaveData.basementTapeListened.Add(num2);
			}
		}
		foreach (int num3 in CollectibleGlobals.KeysOfMangaCollected())
		{
			if (CollectibleGlobals.GetMangaCollected(num3))
			{
				collectibleSaveData.mangaCollected.Add(num3);
			}
		}
		foreach (int num4 in CollectibleGlobals.KeysOfTapeCollected())
		{
			if (CollectibleGlobals.GetTapeCollected(num4))
			{
				collectibleSaveData.tapeCollected.Add(num4);
			}
		}
		foreach (int num5 in CollectibleGlobals.KeysOfTapeListened())
		{
			if (CollectibleGlobals.GetTapeListened(num5))
			{
				collectibleSaveData.tapeListened.Add(num5);
			}
		}
		return collectibleSaveData;
	}

	public static void WriteToGlobals(CollectibleSaveData data)
	{
		foreach (int tapeID in data.basementTapeCollected)
		{
			CollectibleGlobals.SetBasementTapeCollected(tapeID, true);
		}
		foreach (int tapeID2 in data.basementTapeListened)
		{
			CollectibleGlobals.SetBasementTapeListened(tapeID2, true);
		}
		foreach (int mangaID in data.mangaCollected)
		{
			CollectibleGlobals.SetMangaCollected(mangaID, true);
		}
		foreach (int tapeID3 in data.tapeCollected)
		{
			CollectibleGlobals.SetTapeCollected(tapeID3, true);
		}
		foreach (int tapeID4 in data.tapeListened)
		{
			CollectibleGlobals.SetTapeListened(tapeID4, true);
		}
	}
}
