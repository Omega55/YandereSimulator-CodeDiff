using System;

[Serializable]
public class HomeSaveData
{
	public bool lateForSchool;

	public bool night;

	public bool startInBasement;

	public HomeSaveData()
	{
		this.lateForSchool = false;
		this.night = false;
		this.startInBasement = false;
	}

	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}
}
