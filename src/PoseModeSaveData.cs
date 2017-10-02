using System;
using UnityEngine;

[Serializable]
public class PoseModeSaveData
{
	public Vector3 posePosition = default(Vector3);

	public Vector3 poseRotation = default(Vector3);

	public Vector3 poseScale = default(Vector3);

	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}
}
