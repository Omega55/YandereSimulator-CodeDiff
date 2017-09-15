﻿using System;

[Serializable]
public class OptionSaveData
{
	public bool disableBloom;

	public bool disableFarAnimations;

	public bool disableOutlines;

	public bool disablePostAliasing;

	public bool disableShadows;

	public int drawDistance;

	public int drawDistanceLimit;

	public bool fog;

	public bool highPopulation;

	public int lowDetailStudents;

	public int particleCount;

	public OptionSaveData()
	{
		this.disableBloom = false;
		this.disableFarAnimations = false;
		this.disableOutlines = false;
		this.disablePostAliasing = false;
		this.disableShadows = false;
		this.drawDistance = 0;
		this.drawDistanceLimit = 0;
		this.fog = false;
		this.highPopulation = false;
		this.lowDetailStudents = 0;
		this.particleCount = 0;
	}

	public static OptionSaveData ReadFromGlobals()
	{
		return new OptionSaveData
		{
			disableBloom = OptionGlobals.DisableBloom,
			disableFarAnimations = OptionGlobals.DisableFarAnimations,
			disableOutlines = OptionGlobals.DisableOutlines,
			disablePostAliasing = OptionGlobals.DisablePostAliasing,
			disableShadows = OptionGlobals.DisableShadows,
			drawDistance = OptionGlobals.DrawDistance,
			drawDistanceLimit = OptionGlobals.DrawDistanceLimit,
			fog = OptionGlobals.Fog,
			highPopulation = OptionGlobals.HighPopulation,
			lowDetailStudents = OptionGlobals.LowDetailStudents,
			particleCount = OptionGlobals.ParticleCount
		};
	}

	public static void WriteToGlobals(OptionSaveData data)
	{
		OptionGlobals.DisableBloom = data.disableBloom;
		OptionGlobals.DisableFarAnimations = data.disableFarAnimations;
		OptionGlobals.DisableOutlines = data.disableOutlines;
		OptionGlobals.DisablePostAliasing = data.disablePostAliasing;
		OptionGlobals.DisableShadows = data.disableShadows;
		OptionGlobals.DrawDistance = data.drawDistance;
		OptionGlobals.DrawDistanceLimit = data.drawDistanceLimit;
		OptionGlobals.Fog = data.fog;
		OptionGlobals.HighPopulation = data.highPopulation;
		OptionGlobals.LowDetailStudents = data.lowDetailStudents;
		OptionGlobals.ParticleCount = data.particleCount;
	}
}
