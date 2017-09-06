using System;
using System.Collections.Generic;
using UnityEngine;

internal static class KeysHelper
{
	private const string KeyListPrefix = "Keys";

	private const char KeyListSeparator = '|';

	public const char PairSeparator = '^';

	public static T[] GetKeys<T>(string key) where T : struct
	{
		string keyList = KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key));
		string[] array = KeysHelper.Split(keyList);
		return Array.ConvertAll<string, T>(array, (string str) => (T)((object)int.Parse(str)));
	}

	public static string[] GetKeys(string key)
	{
		string keyList = KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key));
		return KeysHelper.Split(keyList);
	}

	public static KeyValuePair<T, U>[] GetKeys<T, U>(string key) where T : struct where U : struct
	{
		string keyList = KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key));
		string[] array = KeysHelper.Split(keyList);
		KeyValuePair<T, U>[] array2 = new KeyValuePair<T, U>[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string[] array3 = array[i].Split(new char[]
			{
				'^'
			});
			array2[i] = new KeyValuePair<T, U>((T)((object)int.Parse(array3[0])), (U)((object)int.Parse(array3[1])));
		}
		return array2;
	}

	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		string[] keyListStrings = KeysHelper.Split(keyList);
		if (!KeysHelper.HasKey(keyListStrings, id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	public static void Delete(string key)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		Globals.Delete(keyListKey);
	}

	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	private static string GetKeyList(string keyListKey)
	{
		if (!PlayerPrefs.HasKey(keyListKey))
		{
			PlayerPrefs.SetString(keyListKey, string.Empty);
		}
		return PlayerPrefs.GetString(keyListKey);
	}

	private static string[] Split(string keyList)
	{
		return keyList.Split(new char[]
		{
			'|'
		});
	}

	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length != 0) ? (keyList + '|' + key) : (keyList + key);
		PlayerPrefs.SetString(keyListKey, value);
	}
}
