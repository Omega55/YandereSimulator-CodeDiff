using System;
using System.Collections.Generic;

public static class ConversationGlobals
{
	private const string Str_TopicDiscovered = "TopicDiscovered_";

	private const string Str_TopicLearnedByStudent = "TopicLearnedByStudent_";

	public static bool GetTopicDiscovered(int topicID)
	{
		return GlobalsHelper.GetBool("TopicDiscovered_" + topicID.ToString());
	}

	public static void SetTopicDiscovered(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("TopicDiscovered_", text);
		GlobalsHelper.SetBool("TopicDiscovered_" + text, value);
	}

	public static int[] KeysOfTopicDiscovered()
	{
		return KeysHelper.GetIntegerKeys("TopicDiscovered_");
	}

	public static bool GetTopicLearnedByStudent(int topicID, int studentID)
	{
		return GlobalsHelper.GetBool(string.Concat(new object[]
		{
			"TopicLearnedByStudent_",
			topicID.ToString(),
			'_',
			studentID.ToString()
		}));
	}

	public static void SetTopicLearnedByStudent(int topicID, int studentID, bool value)
	{
		string text = topicID.ToString();
		string text2 = studentID.ToString();
		KeysHelper.AddIfMissing("TopicLearnedByStudent_", text + '^' + text2);
		GlobalsHelper.SetBool(string.Concat(new object[]
		{
			"TopicLearnedByStudent_",
			text,
			'_',
			text2
		}), value);
	}

	public static IntAndIntPair[] KeysOfTopicLearnedByStudent()
	{
		KeyValuePair<int, int>[] keys = KeysHelper.GetKeys<int, int>("TopicLearnedByStudent_");
		IntAndIntPair[] array = new IntAndIntPair[keys.Length];
		for (int i = 0; i < keys.Length; i++)
		{
			KeyValuePair<int, int> keyValuePair = keys[i];
			array[i] = new IntAndIntPair(keyValuePair.Key, keyValuePair.Value);
		}
		return array;
	}

	public static void DeleteAll()
	{
		Globals.DeleteCollection("TopicDiscovered_", ConversationGlobals.KeysOfTopicDiscovered());
		foreach (IntAndIntPair intAndIntPair in ConversationGlobals.KeysOfTopicLearnedByStudent())
		{
			Globals.Delete(string.Concat(new object[]
			{
				"TopicLearnedByStudent_",
				intAndIntPair.first.ToString(),
				'_',
				intAndIntPair.second.ToString()
			}));
		}
		KeysHelper.Delete("TopicLearnedByStudent_");
	}
}
