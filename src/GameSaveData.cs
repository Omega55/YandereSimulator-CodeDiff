using System;

[Serializable]
public class GameSaveData
{
	public bool loveSick;

	public bool masksBanned;

	public bool paranormal;

	public GameSaveData()
	{
		this.loveSick = false;
		this.masksBanned = false;
		this.paranormal = false;
	}

	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}
}
