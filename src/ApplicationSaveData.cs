using System;

[Serializable]
public class ApplicationSaveData
{
	public float versionNumber;

	public ApplicationSaveData()
	{
		this.versionNumber = 0f;
	}

	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}
}
