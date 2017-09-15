using System;

[Serializable]
public class SenpaiSaveData
{
	public bool customSenpai;

	public string senpaiEyeColor;

	public int senpaiEyeWear;

	public int senpaiFacialHair;

	public string senpaiHairColor;

	public int senpaiHairStyle;

	public int senpaiSkinColor;

	public SenpaiSaveData()
	{
		this.customSenpai = false;
		this.senpaiEyeColor = string.Empty;
		this.senpaiEyeWear = 0;
		this.senpaiFacialHair = 0;
		this.senpaiHairColor = string.Empty;
		this.senpaiHairStyle = 0;
		this.senpaiSkinColor = 0;
	}

	public static SenpaiSaveData ReadFromGlobals()
	{
		return new SenpaiSaveData
		{
			customSenpai = SenpaiGlobals.CustomSenpai,
			senpaiEyeColor = SenpaiGlobals.SenpaiEyeColor,
			senpaiEyeWear = SenpaiGlobals.SenpaiEyeWear,
			senpaiFacialHair = SenpaiGlobals.SenpaiFacialHair,
			senpaiHairColor = SenpaiGlobals.SenpaiHairColor,
			senpaiHairStyle = SenpaiGlobals.SenpaiHairStyle,
			senpaiSkinColor = SenpaiGlobals.SenpaiSkinColor
		};
	}

	public static void WriteToGlobals(SenpaiSaveData data)
	{
		SenpaiGlobals.CustomSenpai = data.customSenpai;
		SenpaiGlobals.SenpaiEyeColor = data.senpaiEyeColor;
		SenpaiGlobals.SenpaiEyeWear = data.senpaiEyeWear;
		SenpaiGlobals.SenpaiFacialHair = data.senpaiFacialHair;
		SenpaiGlobals.SenpaiHairColor = data.senpaiHairColor;
		SenpaiGlobals.SenpaiHairStyle = data.senpaiHairStyle;
		SenpaiGlobals.SenpaiSkinColor = data.senpaiSkinColor;
	}
}
