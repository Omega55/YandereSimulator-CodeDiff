using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class CreditJson : JsonData
{
	[SerializeField]
	private string name;

	[SerializeField]
	private int size;

	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	public static CreditJson[] LoadFromJson(string path)
	{
		List<CreditJson> list = new List<CreditJson>();
		foreach (Dictionary<string, object> dictionary in JsonData.Deserialize(path))
		{
			list.Add(new CreditJson
			{
				name = TFUtils.LoadString(dictionary, "Name"),
				size = TFUtils.LoadInt(dictionary, "Size")
			});
		}
		return list.ToArray();
	}

	public string Name
	{
		get
		{
			return this.name;
		}
	}

	public int Size
	{
		get
		{
			return this.size;
		}
	}
}
