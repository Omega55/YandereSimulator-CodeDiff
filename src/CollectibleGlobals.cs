using System;

public static class CollectibleGlobals
{
	private const string Str_HeadmasterTapeCollected = "HeadmasterTapeCollected_";

	private const string Str_HeadmasterTapeListened = "HeadmasterTapeListened_";

	private const string Str_BasementTapeCollected = "BasementTapeCollected_";

	private const string Str_BasementTapeListened = "BasementTapeListened_";

	private const string Str_MangaCollected = "MangaCollected_";

	private const string Str_TapeCollected = "TapeCollected_";

	private const string Str_TapeListened = "TapeListened_";

	public static bool GetHeadmasterTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("HeadmasterTapeCollected_" + tapeID.ToString());
	}

	public static void SetHeadmasterTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("HeadmasterTapeCollected_", text);
		GlobalsHelper.SetBool("HeadmasterTapeCollected_" + text, value);
	}

	public static bool GetHeadmasterTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("HeadmasterTapeListened_" + tapeID.ToString());
	}

	public static void SetHeadmasterTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("HeadmasterTapeListened_", text);
		GlobalsHelper.SetBool("HeadmasterTapeListened_" + text, value);
	}

	public static bool GetBasementTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("BasementTapeCollected_" + tapeID.ToString());
	}

	public static void SetBasementTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("BasementTapeCollected_", text);
		GlobalsHelper.SetBool("BasementTapeCollected_" + text, value);
	}

	public static int[] KeysOfBasementTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("BasementTapeCollected_");
	}

	public static bool GetBasementTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("BasementTapeListened_" + tapeID.ToString());
	}

	public static void SetBasementTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("BasementTapeListened_", text);
		GlobalsHelper.SetBool("BasementTapeListened_" + text, value);
	}

	public static int[] KeysOfBasementTapeListened()
	{
		return KeysHelper.GetIntegerKeys("BasementTapeListened_");
	}

	public static bool GetMangaCollected(int mangaID)
	{
		return GlobalsHelper.GetBool("MangaCollected_" + mangaID.ToString());
	}

	public static void SetMangaCollected(int mangaID, bool value)
	{
		string text = mangaID.ToString();
		KeysHelper.AddIfMissing("MangaCollected_", text);
		GlobalsHelper.SetBool("MangaCollected_" + text, value);
	}

	public static int[] KeysOfMangaCollected()
	{
		return KeysHelper.GetIntegerKeys("MangaCollected_");
	}

	public static bool GetTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("TapeCollected_" + tapeID.ToString());
	}

	public static void SetTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("TapeCollected_", text);
		GlobalsHelper.SetBool("TapeCollected_" + text, value);
	}

	public static int[] KeysOfTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("TapeCollected_");
	}

	public static bool GetTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("TapeListened_" + tapeID.ToString());
	}

	public static void SetTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("TapeListened_", text);
		GlobalsHelper.SetBool("TapeListened_" + text, value);
	}

	public static int[] KeysOfTapeListened()
	{
		return KeysHelper.GetIntegerKeys("TapeListened_");
	}

	public static void DeleteAll()
	{
		Globals.DeleteCollection("BasementTapeCollected_", CollectibleGlobals.KeysOfBasementTapeCollected());
		Globals.DeleteCollection("BasementTapeListened_", CollectibleGlobals.KeysOfBasementTapeListened());
		Globals.DeleteCollection("MangaCollected_", CollectibleGlobals.KeysOfMangaCollected());
		Globals.DeleteCollection("TapeCollected_", CollectibleGlobals.KeysOfTapeCollected());
		Globals.DeleteCollection("TapeListened_", CollectibleGlobals.KeysOfTapeListened());
	}
}
