using System;

public static class SchoolAtmosphere
{
	public static SchoolAtmosphereType Type
	{
		get
		{
			float schoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
			if (schoolAtmosphere > 0.6666667f)
			{
				return SchoolAtmosphereType.High;
			}
			if (schoolAtmosphere > 0.333333343f)
			{
				return SchoolAtmosphereType.Medium;
			}
			return SchoolAtmosphereType.Low;
		}
	}
}
