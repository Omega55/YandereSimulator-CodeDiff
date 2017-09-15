using System;
using UnityEngine;

[Serializable]
public class PoseModeSaveData
{
	public Vector3 posePosition;

	public Vector3 poseRotation;

	public Vector3 poseScale;

	public PoseModeSaveData()
	{
		this.posePosition = default(Vector3);
		this.poseRotation = default(Vector3);
		this.poseScale = default(Vector3);
	}

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
