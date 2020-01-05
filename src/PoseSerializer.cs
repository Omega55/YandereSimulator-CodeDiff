using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class PoseSerializer
{
	public const string SavePath = "{0}/Poses/{1}";

	public static void SerializePose(CosmeticScript cosmeticScript, Transform root, string poseName)
	{
		StudentCosmeticSheet studentCosmeticSheet = cosmeticScript.CosmeticSheet();
		SerializedPose serializedPose;
		serializedPose.CosmeticData = JsonUtility.ToJson(studentCosmeticSheet);
		serializedPose.BoneData = PoseSerializer.getBoneData(root);
		string contents = JsonUtility.ToJson(serializedPose);
		string text = string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, poseName + ".txt");
		FileInfo fileInfo = new FileInfo(text);
		fileInfo.Directory.Create();
		File.WriteAllText(text, contents);
	}

	private static BoneData[] getBoneData(Transform root)
	{
		List<BoneData> list = new List<BoneData>();
		Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			list.Add(new BoneData
			{
				BoneName = ((!(transform == root)) ? transform.name : "StudentRoot"),
				LocalPosition = transform.localPosition,
				LocalRotation = transform.localRotation,
				LocalScale = transform.localScale
			});
		}
		return list.ToArray();
	}

	public static void DeserializePose(CosmeticScript cosmeticScript, Transform root, string poseName)
	{
		string path = string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, poseName + ".txt");
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			SerializedPose serializedPose = JsonUtility.FromJson<SerializedPose>(json);
			StudentCosmeticSheet mySheet = JsonUtility.FromJson<StudentCosmeticSheet>(serializedPose.CosmeticData);
			cosmeticScript.LoadCosmeticSheet(mySheet);
			cosmeticScript.CharacterAnimation.Stop();
			bool flag = cosmeticScript.Male == mySheet.Male;
			Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
			foreach (BoneData boneData2 in serializedPose.BoneData)
			{
				foreach (Transform transform in componentsInChildren)
				{
					if (transform.name == boneData2.BoneName)
					{
						transform.localRotation = boneData2.LocalRotation;
						if (flag)
						{
							transform.localPosition = boneData2.LocalPosition;
							transform.localScale = boneData2.LocalScale;
						}
					}
					else if (boneData2.BoneName == "StudentRoot" && transform == root)
					{
						transform.localPosition = boneData2.LocalPosition;
						transform.localRotation = boneData2.LocalRotation;
						transform.localScale = boneData2.LocalScale;
					}
				}
			}
		}
	}

	public static string[] GetSavedPoses()
	{
		string[] files = Directory.GetFiles(string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, string.Empty));
		List<string> list = new List<string>();
		foreach (string text in files)
		{
			if (text.EndsWith(".txt"))
			{
				list.Add(text);
			}
		}
		return list.ToArray();
	}
}
