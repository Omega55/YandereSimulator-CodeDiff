using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class KeysHelper
{
	private const string KeyListPrefix = "Keys";

	private const char KeyListSeparator = '|';

	public const char PairSeparator = '^';

	[CompilerGenerated]
	private static Converter<string, int> <>f__mg$cache0;

	public static int[] GetIntegerKeys(string key)
	{
		string keyList = KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key));
		string[] array = KeysHelper.SplitList(keyList);
		string[] array2 = array;
		if (KeysHelper.<>f__mg$cache0 == null)
		{
			KeysHelper.<>f__mg$cache0 = new Converter<string, int>(int.Parse);
		}
		return Array.ConvertAll<string, int>(array2, KeysHelper.<>f__mg$cache0);
	}

	public static string[] GetStringKeys(string key)
	{
		string keyList = KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key));
		return KeysHelper.SplitList(keyList);
	}

	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		string keyList = KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key));
		string[] array = KeysHelper.SplitList(keyList);
		return Array.ConvertAll<string, T>(array, (string str) => (T)((object)Enum.Parse(typeof(T), str)));
	}

	public static KeyValuePair<T, U>[] GetKeys<T, U>(string key) where T : struct where U : struct
	{
		string keyList = KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key));
		string[] array = KeysHelper.SplitList(keyList);
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
		string[] keyListStrings = KeysHelper.SplitList(keyList);
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
		return PlayerPrefs.GetString(keyListKey);
	}

	private static string[] SplitList(string keyList)
	{
		return (keyList.Length <= 0) ? new string[0] : keyList.Split(new char[]
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
