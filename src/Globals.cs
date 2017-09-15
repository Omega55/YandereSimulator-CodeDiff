using System;
using UnityEngine;

public static class Globals
{
	public static bool KeyExists(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	public static void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}

	public static void Delete(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	public static void DeleteCollection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			PlayerPrefs.DeleteKey(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}

	public static void DeleteCollection(string key, string[] usedKeys)
	{
		foreach (string str in usedKeys)
		{
			PlayerPrefs.DeleteKey(key + str);
		}
		KeysHelper.Delete(key);
	}

	public static void Save()
	{
		PlayerPrefs.Save();
	}
}
