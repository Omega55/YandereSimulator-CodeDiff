using System;
using UnityEngine;

public static class PoseModeGlobals
{
	private const string Str_PosePosition = "PosePosition";

	private const string Str_PoseRotation = "PoseRotation";

	private const string Str_PoseScale = "PoseScale";

	public static Vector3 PosePosition
	{
		get
		{
			return GlobalsHelper.GetVector3("PosePosition");
		}
		set
		{
			GlobalsHelper.SetVector3("PosePosition", value);
		}
	}

	public static Vector3 PoseRotation
	{
		get
		{
			return GlobalsHelper.GetVector3("PoseRotation");
		}
		set
		{
			GlobalsHelper.SetVector3("PoseRotation", value);
		}
	}

	public static Vector3 PoseScale
	{
		get
		{
			return GlobalsHelper.GetVector3("PoseScale");
		}
		set
		{
			GlobalsHelper.SetVector3("PoseScale", value);
		}
	}

	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("PosePosition");
		GlobalsHelper.DeleteVector3("PoseRotation");
		GlobalsHelper.DeleteVector3("PoseScale");
	}
}
