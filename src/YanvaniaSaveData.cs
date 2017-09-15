﻿using System;

[Serializable]
public class YanvaniaSaveData
{
	public bool draculaDefeated;

	public bool midoriEasterEgg;

	public YanvaniaSaveData()
	{
		this.draculaDefeated = false;
		this.midoriEasterEgg = false;
	}

	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}
}
